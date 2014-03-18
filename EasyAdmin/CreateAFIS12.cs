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
    public partial class CreateAFIS12 : UserControl
    {
        private const string emailmsg = @"Beste heer/mevrouw,

Hierbij {0}. Zou u deze kunnen verwerken?
Bij voorbaat hartelijk dank,

Hans van de Put 

Q8 Tankstation van de Put BV
03-588
Hagestraat 8-10
8181 EB Heerde
tel. 0578-691609
vandeputbv@online.nl
www.vdput.nl
";
        List<string> emailattachtments = new List<string>();
        DataBaseClass _db;

        public CreateAFIS12()
        {
            InitializeComponent();
            createAFIS12Header1.OnAddTicket = AddTicked;

        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            createAFIS12Header1.UpdateDBSettings(db);
            _db = db;
        }


        /// <summary>
        /// Add new item
        /// </summary>
        ///  <param name="ticket"></param>
        private void AddTicked(CreateAFIS12Line ticket)
        {
            int y;
            CreateAFIS12Line l = new CreateAFIS12Line();
            l.SetDeleteButtonVisible();
            l.OnDeleteItemClick = OnDeleteItem;
            l.OnOrderChange = OnOrderChange;
            l.SetOrderVisible();
            ticket.GetProperties(l);
            y = panelAFIS12.Controls.Count * l.Height;
            l.Location = new System.Drawing.Point(0, y);
            panelAFIS12.VerticalScroll.Value = 0;
            panelAFIS12.Controls.Add(l);
            l.SetOrder(panelAFIS12.Controls.Count);
            UpdataMaxOrder();
            ticket.IncTicketNo();
            panelAFIS12.ScrollControlIntoView(l);
            ticket.ClearAllFields();
        }

        /// <summary>
        /// Genenerate AFIS 12 doc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateDoc_Click(object sender, EventArgs e)
        {
            string folderyear = Properties.Settings.Default.SaveDirYearSubFolder ? Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy") : "";
            String template = Properties.Settings.Default.TemplateAFIS12;
            String formnamedoc = Properties.Settings.Default.SaveDirAFIS12 + folderyear + Path.DirectorySeparatorChar + "AFIS12_" + DateTime.Now.ToString("dd-MM-yyyy") + "_";
            String formnamepdf = Properties.Settings.Default.PDFOutputAFIS + folderyear + Path.DirectorySeparatorChar + "AFIS12_" + DateTime.Now.ToString("dd-MM-yyyy") + "_";
            int formno = (int)nUDFormNo.Value;
            int table = 3;
            int row;
            int items = panelAFIS12.Controls.Count;
            int item = 0;
            AFIS12LineData itemdata = new AFIS12LineData();
            //string valueint, valuedec;

            if (!File.Exists(template))
            {
                MessageBox.Show("Template niet gevonden:\n" + template);
                return;
            }
            if (items < 1)
            {
                if (MessageBox.Show("Geen items, Maak een leeg document?", System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                    return;
            }

            try
            {
                // Get the class type and instantiate Word.              
                Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
                // Get the Documents collection.
                oWord.Visible = true;
                do
                {
                    // New document.
                    oWordDoc = oWord.Documents.Add(template);

                    oWordDoc.Activate();
                    oWord.Selection.GoTo(WdGoToItem.wdGoToTable, WdGoToDirection.wdGoToAbsolute, 3);
                    oWord.Selection.MoveRight(WdUnits.wdCell, 11);
                    //first char day
                    oWord.Selection.TypeText(String.Format("{0}", DateTime.Now.Day.ToString("D2")[0]));
                    oWord.Selection.MoveRight(WdUnits.wdCell, 1);
                    //2nd char of day
                    oWord.Selection.TypeText(String.Format("{0}", DateTime.Now.Day.ToString("D2")[1]));
                    oWord.Selection.MoveRight(WdUnits.wdCell, 2);
                    //1st char of form no.
                    oWord.Selection.TypeText(String.Format("{0}", formno.ToString("D2")[0]));
                    oWord.Selection.MoveRight(WdUnits.wdCell, 1);
                    //2nd char of form no.
                    oWord.Selection.TypeText(String.Format("{0}", formno.ToString("D2")[1]));

                    row = 3;
                    while (row <= 23 && item < items)
                    {
                        ((CreateAFIS12Line)panelAFIS12.Controls[item]).GetData(itemdata);
                        oWordDoc.Tables[table].Cell(row, 1).Range.InsertAfter(itemdata.Date); //date
                        oWordDoc.Tables[table].Cell(row, 2).Range.InsertAfter(itemdata.ProductCode); //product
                        oWordDoc.Tables[table].Cell(row, 5).Range.InsertAfter(itemdata.Passnumber); //pass number
                        oWordDoc.Tables[table].Cell(row, 6).Range.InsertAfter(String.Format("{0}", itemdata.TicketNumber)); //ticket number
                        //DecimalToDualString(itemdata.Price, out valueint, out valuedec);
                        oWordDoc.Tables[table].Cell(row, 8).Range.InsertAfter(itemdata.PriceInt); //price/unit, integer part
                        oWordDoc.Tables[table].Cell(row, 9).Range.InsertAfter(itemdata.PriceDec); //price/unit, decimals
                        //DecimalToDualString(itemdata.Amount, out valueint, out valuedec);
                        oWordDoc.Tables[table].Cell(row, 10).Range.InsertAfter(itemdata.AmountInt); //units, integer part
                        oWordDoc.Tables[table].Cell(row, 11).Range.InsertAfter(itemdata.AmountDec); //units, decimals
                        //DecimalToDualString(itemdata.TotalPrice, out valueint, out valuedec);
                        oWordDoc.Tables[table].Cell(row, 12).Range.InsertAfter(itemdata.TotalPriceInt); //total price, integer part
                        oWordDoc.Tables[table].Cell(row, 13).Range.InsertAfter(itemdata.TotalPriceDec); //total price, decimals
                        item++;
                        row++;
                    }

                    if (row > 23 && item < items) //max. items/forms, new form required
                    {
                        if (cbSaveAsDoc.Checked)
                            SaveAFISDoc(oWord, formnamedoc + formno.ToString() + ".docx");
                        if (cbSavePDF.Checked || cbCreateEmail.Checked)
                        {
                            SaveAFISDoc(oWord, formnamepdf + formno.ToString() + ".pdf");
                            if (cbCreateEmail.Checked)
                                emailattachtments.Add(formnamepdf + formno.ToString() + ".pdf");
                        }
                        if (cbPrint.Checked)
                        {
                            oWordDoc.PrintOut();
                        }
                        if(cbAutoClose.Checked)
                        {
                            oWordDoc.Close(WdSaveOptions.wdDoNotSaveChanges, Type.Missing, Type.Missing);
                        }

                        formno++;
                        nUDFormNo.Value = formno;
                    }
                } while (item < items);

                if (cbSaveAsDoc.Checked)
                    SaveAFISDoc(oWord, formnamedoc + formno.ToString() + ".docx");
                if (cbSavePDF.Checked || cbCreateEmail.Checked)
                {
                    SaveAFISDoc(oWord, formnamepdf + formno.ToString() + ".pdf");
                    if (cbCreateEmail.Checked)
                    {
                        emailattachtments.Add(formnamepdf + formno.ToString() + ".pdf");
                    }
                }
                if (cbPrint.Checked)
                {
                    oWordDoc.PrintOut();
                }
                if (cbAutoClose.Checked)
                {
                    oWordDoc.Close(WdSaveOptions.wdDoNotSaveChanges, Type.Missing, Type.Missing);
                    oWord.Quit();
                }
                if (cbCreateEmail.Checked)
                {
                    CreateEmail();
                }
                nUDFormNo.Value = formno + 1;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Fout: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Regel: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Er ging iets fout");
            }
            finally
            {
                ;
            }
        }

        /// <summary>
        /// Convert decimal value to 2 strings: an integer part and a decimal part
        /// </summary>
        /// <param name="value"></param>
        /// <param name="intpart"></param>
        /// <param name="decpart"></param>
        /*private void DecimalToDualString(decimal value, out string intpart, out string decpart)
        {
            int intvalue = (int)value;
            intpart = String.Format("{0}", intvalue);
            decpart = String.Format("{0:0.000}", value - intvalue).Substring(2);
        }*/

        /// <summary>
        /// Save AFIS12 doc
        /// </summary>
        /// <param name="oWord"></param>
        /// <param name="filename"></param>
        private void SaveAFISDoc(Microsoft.Office.Interop.Word.Application oWord, string filename)
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

        /// <summary>
        /// Delete one item from list
        /// </summary>
        /// <param name="item">item to delete</param>
        private void OnDeleteItem(CreateAFIS12Line item)
        {
            int h = item.Height;
            int remorder = item.GetOrder();
            int order;

            panelAFIS12.Controls.Remove(item);

            //update location based on order            
            for (int i = 0; i < panelAFIS12.Controls.Count; i++)
            {
                order = ((CreateAFIS12Line)(panelAFIS12.Controls[i])).GetOrder();
                order -= order >= remorder ? 1 : 0; //one removed, so all next orders should be decremented by 1
                ((CreateAFIS12Line)(panelAFIS12.Controls[i])).SetOrder(order);
                panelAFIS12.Controls[i].Location = new System.Drawing.Point(0, (order-1) * h); //update location
            }
            UpdataMaxOrder();
        }


        /// <summary>
        /// Change order of items
        /// </summary>
        /// <param name="item"></param>
        private void OnOrderChange(CreateAFIS12Line item)
        {
            int h = item.Height;
            int neworder = item.GetOrder();
            int oldorder = item.GetOldOrder();
            int order;
            CreateAFIS12Line control;

            //find missing order no = previous order

            for (int i = 0; i < panelAFIS12.Controls.Count; i++)
            {
                control = ((CreateAFIS12Line)(panelAFIS12.Controls[i]));
                order = control.GetOrder();
                if(control != item && neworder < oldorder && order >= neworder && order < oldorder){ //decr. of order, update orders between new and old order only
                    order++;
                }
                else if (control != item && neworder > oldorder &&  order > oldorder  && order <= neworder){
                    order--;
                }
                control.SetOrder(order); //update order
                panelAFIS12.Controls[i].Location = new System.Drawing.Point(0, (order-1) * h); //update location
            }
        }


        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zeker weten?", System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                panelAFIS12.Controls.Clear();
                emailattachtments.Clear();
            }
        }

        private void UpdataMaxOrder()
        {
            for (int i = 0; i < panelAFIS12.Controls.Count; i++)
            {
                ((CreateAFIS12Line)(panelAFIS12.Controls[i])).SetMaxOrder(panelAFIS12.Controls.Count);
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            CreateEmail();
        }
        private void CreateEmail()
        {
            EmailForm emailfrm = new EmailForm(_db);
            emailfrm.SetEmailType(EmailForm.Emailtype.afis12);
            emailfrm.SetCustomerInfo("CCV");
            emailfrm.SetEmailAddress(new string[] { Properties.Settings.Default.EmailCCV }, null, new string[] { "vandeputbv@online.nl" });
            if (emailattachtments.Count > 1)
            {
                emailfrm.SetSubject("AFIS 12 formulieren");
                emailfrm.SetBodyPlainText(String.Format(emailmsg, "meerdere AFIS 12 formulieren"));
            }
            else
            {
                emailfrm.SetSubject("AFIS 12 formulier");
                emailfrm.SetBodyPlainText(String.Format(emailmsg, "een AFIS 12 formulier"));
            }
            for (int i = 0; i < emailattachtments.Count; i++)
                emailfrm.AddAttachment(emailattachtments[i]);
            emailfrm.ShowDialog();
        }


    }
}
