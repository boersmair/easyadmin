using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace EasyAdmin
{
    public partial class InvoicePanel : UserControl
    {
        private const int INVOICE_ADDR_TABLE = 1;
        private const int INVOICE_INV_TABLE = 2;
        private const int INVOICE_ITEMS_TABLE = 3;
        private const int INVOICE_PAYM_TABLE = 4;
        private const string payment_default = "Betaling uiterlijk binnen 14 dagen";
        public DBUpdated OnDBUpdated;
        private string EmailAttachement = "";
        private DataBaseClass _db;


        public InvoicePanel()
        {
            InitializeComponent();
            tbPayment.Text = payment_default;
        }

        public void UpdateInvoiceSettings()
        {
            invoiceBodyPanel1.UpdateInvoiceSettings();
        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            invoiceHeaderPanel1.UpdateDBSettings(db);
            invoiceHeaderPanel1.OnPaymentFieldChanged = PaymentTextChanged;
            invoiceHeaderPanel1.OnResellerFieldChanged = ResellerInvoiceChanged;
            invoiceHeaderPanel1.OnDBUpdated = DBUpdated;
            invoiceBodyPanel1.UpdateDBSettings(db);
            invoiceBodyPanel1.OnGetDiscountRequest = GetDiscount;
            _db = db;
        }

        private void DBUpdated(object sender)
        {
            if (OnDBUpdated != null)
                OnDBUpdated(this);
        }

        private decimal GetDiscount()
        {
            return invoiceHeaderPanel1.GetDiscount();
        }

        private void PaymentTextChanged(string text)
        {
            tbPayment.Text = text.Length > 0 ? text : payment_default;
        }

        private void ResellerInvoiceChanged(bool reseller)
        {
            cbReselInvoice.Checked = reseller;
        }

        private void btnGenerateIncoice_Click(object sender, EventArgs e)
        {
            GenerateDoc(false);
        }

        private void btnGenerateHead_Click(object sender, EventArgs e)
        {
            GenerateDoc(true);
        }

        private void GenerateDoc(bool header)
        {
            InvoiceHeaderData headerdata = invoiceHeaderPanel1.GetInvoiceHeaderData();
            String template;
            String savefolder = "";
            template = header ? Properties.Settings.Default.TemplateHeader : 
                cbReselInvoice.Checked?Properties.Settings.Default.TemplateInvoiceWordReseller:
                invoiceBodyPanel1.DiscountUsed?Properties.Settings.Default.TemplateInvoiceWordDiscount:
                Properties.Settings.Default.TemplateInvoiceWord;
            int row;
            EmailAttachement = "";
            try
            {
                // Get the class type and instantiate Word.              
                Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
               
                // Get the Documents collection.
                oWord.Visible = true;
                oWordDoc = oWord.Documents.Add(template);
                oWordDoc.Activate();

                //address
                row = 1;
                oWordDoc.Tables[INVOICE_ADDR_TABLE].Cell(row++, 1).Range.InsertAfter(headerdata.fullname);
                if (headerdata.attn1.Length > 0)
                {
                    oWordDoc.Tables[INVOICE_ADDR_TABLE].Cell(row++, 1).Range.InsertAfter(headerdata.attn1);
                }
                if (headerdata.attn2.Length > 0)
                {
                    oWordDoc.Tables[INVOICE_ADDR_TABLE].Cell(row++, 1).Range.InsertAfter(headerdata.attn2);
                }
                oWordDoc.Tables[INVOICE_ADDR_TABLE].Cell(row++, 1).Range.InsertAfter(headerdata.addr1);
                if (headerdata.addr2.Length > 0)
                {
                    oWordDoc.Tables[INVOICE_ADDR_TABLE].Cell(row++, 1).Range.InsertAfter(headerdata.addr2);
                }
                oWordDoc.Tables[INVOICE_ADDR_TABLE].Cell(row++, 1).Range.InsertAfter(headerdata.postalcode + " " + headerdata.city);
                savefolder = headerdata.savefolder;

                //invoice data
                if (!header)
                {
                    oWordDoc.Tables[INVOICE_INV_TABLE].Cell(1, 4).Range.InsertAfter(headerdata.date);
                    oWordDoc.Tables[INVOICE_INV_TABLE].Cell(2, 4).Range.InsertAfter(headerdata.invoiceno);
                    oWordDoc.Tables[INVOICE_INV_TABLE].Cell(3, 4).Range.InsertAfter(headerdata.customno);
                    //oWordDoc.Tables[INVOICE_INV_TABLE].Cell(4, 4).Range.InsertAfter(headerdata.fatno);

                    if (tbPayment.Text.Length > 0)
                    {
                        oWordDoc.Tables[INVOICE_PAYM_TABLE].Cell(1, 1).Range.InsertAfter(tbPayment.Text);
                    }
                    //fat data
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(30, 3).Range.InsertAfter(String.Format("BTW ({0:0.0}%)", Properties.Settings.Default.FATLow));
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(31, 3).Range.InsertAfter(String.Format("BTW ({0:0.0}%)", Properties.Settings.Default.FATHigh));


                    //products
                    List<ProductItemData> items = invoiceBodyPanel1.ItemsList;
                    int lastrow = 2;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].description.Length > 0)
                        {
                            int col = 2;
                            oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(i + 2, col++).Range.InsertAfter(items[i].description);
                            oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(i + 2, col++).Range.InsertAfter(items[i].ammount);
                            oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(i + 2, col++).Range.InsertAfter(items[i].priceperitem);
                            if (items[i].ammount.Length > 0 || items[i].priceperitem.Length > 0)
                            {
                                if (invoiceBodyPanel1.DiscountUsed)
                                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(i + 2, col++).Range.InsertAfter(items[i].discount);
                                oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(i + 2, col++).Range.InsertAfter(items[i].price);
                                oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(i + 2, col++).Range.InsertAfter(items[i].fatpercent);
                            }
                            lastrow = i + 3;
                        }
                    }
                    // extra text
                    string[] text = invoiceBodyPanel1.ExtaTextLines;
                    if (lastrow > 2)
                        lastrow++; //1 line space
                    for (int i = 0; i < text.Length; i++)
                    {
                        oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(lastrow++, 2).Range.InsertAfter(text[i]);
                    }

                    //totals
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(29, 4).Range.InsertAfter(String.Format("€ {0:0.00}", invoiceBodyPanel1.SubTotalPrice));
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(30, 4).Range.InsertAfter(String.Format("€ {0:0.00}", invoiceBodyPanel1.FatLow));
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(31, 4).Range.InsertAfter(String.Format("€ {0:0.00}", invoiceBodyPanel1.FatHigh));
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(32, 4).Range.InsertAfter(String.Format("€ {0:0.00}", invoiceBodyPanel1.TotalPrice));
                    oWordDoc.Tables[INVOICE_ITEMS_TABLE].Cell(34, 4).Range.InsertAfter(String.Format("€ {0:0.00}", invoiceBodyPanel1.TotalPrice));

                    if (cbSaveInvoiceDoc.Checked || cbSaveInvoicePDF.Checked || cbEmail.Checked)
                    {
                        //create folder for year?
                        string folderyear = Properties.Settings.Default.SaveDirYearSubFolder ? Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy") : "";
                        string docxname = headerdata.fullname; //use customer name as file name
                        //replace invalid chars in name
                        docxname = docxname.Replace(".", " ");
                        docxname = docxname.Replace("\\", "_");
                        docxname = docxname.Replace("/", "_");
                        docxname = docxname.Replace("'", " ");
                        docxname = docxname.Replace("\"", " ");
                        // store in custom subfolder?
                        docxname = (savefolder.Length>0?Path.DirectorySeparatorChar+savefolder:"")+ Path.DirectorySeparatorChar + docxname;
                        docxname += "_" + headerdata.invoiceno; //add invoice no. to name
                        //create pdf and docx filepath
                        string pdfname = Properties.Settings.Default.PDFOutputInvoice + folderyear + docxname + ".pdf";
                        docxname = (cbReselInvoice.Checked ? Properties.Settings.Default.SaveDirInvoiceReseller : Properties.Settings.Default.SaveDirInvoice) + folderyear + docxname + ".docx";
                        if(cbSaveInvoiceDoc.Checked)
                            SaveInvoice(oWord, docxname);
                        if (cbSaveInvoicePDF.Checked || cbEmail.Checked)
                        {
                            SaveInvoice(oWord, pdfname);
                            if (cbEmail.Checked)
                                EmailAttachement = pdfname;
                        }
                    }
                    invoiceHeaderPanel1.GenerateNewInvoiceNo();
                    invoiceBodyPanel1.UpdateProductsDatabase();
                }
                if (cbPrint.Checked)
                {
                    //oWordDoc.PrintPreview();
                    for (int i = 0; i < nUDPrintCount.Value; i++)
                        oWordDoc.PrintOut();
                }
                if (cbCloseWord.Checked)
                {
                    oWordDoc.Close(WdSaveOptions.wdDoNotSaveChanges, Type.Missing, Type.Missing);
                    oWord.Quit();
                }
                if (cbEmail.Checked)
                {
                    ShowEmailForm();
                }

               

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Fout: ";
                errorMessage += theException.Message;
                errorMessage += " Regel: ";
                errorMessage += theException.Source;
                MessageBox.Show(errorMessage, "Er ging iets fout");
            }
            finally
            {
                ;
            }          
        }

        /// <summary>
        /// Save invoice doc
        /// </summary>
        /// <param name="oWord"></param>
        /// <param name="filename"></param>
        private void SaveInvoice(Microsoft.Office.Interop.Word.Application oWord, string filename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filename))) //create director if not exists
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
            }
            if (File.Exists(filename))
            {
                if (MessageBox.Show("Document bestaat all!\nOverschrijven?", System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }
            if (filename.EndsWith(".pdf"))
                oWord.ActiveDocument.SaveAs(filename, WdExportFormat.wdExportFormatPDF, false);
            else
                oWord.ActiveDocument.SaveAs(filename);
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            invoiceBodyPanel1.ClearAllFields();
            //tbPayment.Text = payment_default;
            EmailAttachement = "";
            invoiceHeaderPanel1.ResetDate();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            ShowEmailForm();
        }

        private void ShowEmailForm()
        {
            InvoiceHeaderData headerdata = invoiceHeaderPanel1.GetInvoiceHeaderData();
            EmailForm emailfrm = new EmailForm(_db);
            emailfrm.SetEmailType(EmailForm.Emailtype.invoice);
            emailfrm.SetCustomerInfo(headerdata.fullname, headerdata.customno, headerdata.customerid);
            emailfrm.SetEmailAddress(new string[] { invoiceHeaderPanel1.GetEmail() }, null, new string[] { "vandeputbv@online.nl" });
            emailfrm.SetSubject("Factuur");
            if (EmailAttachement.Length > 0)
                emailfrm.AddAttachment(EmailAttachement);
            emailfrm.ShowDialog();
        }



    }
}
