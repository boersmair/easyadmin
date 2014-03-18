using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EasyAdmin
{
    public partial class InvoiceHeaderPanel : UserControl
    {
        private const string BTN_NEW = "Nieuw";
        private const string BTN_SAVE = "Opslaan";

        private AutoFillHelperClass autofillhelper_cust;
        private CustomerTableClass customers_dbtable;
        private DataTable customers_datatable;        
        public delegate void PaymentFieldChanged(string paymenttext);
        public PaymentFieldChanged OnPaymentFieldChanged;
        public delegate void ResellerFieldChanged(bool reseller);
        public ResellerFieldChanged OnResellerFieldChanged;
        public DBUpdated OnDBUpdated;
        private int invoice_no = 1;
        private bool _dbzeros_detected = false;
        private bool _user_autodisable = false;

        /// <summary>
        /// constructor. Init variables;
        /// </summary>
        public InvoiceHeaderPanel()
        {
            InitializeComponent();
            invoice_no = (int)Properties.Settings.Default.InvoiceNoOffset;

            autofillhelper_cust = new AutoFillHelperClass();
            autofillhelper_cust.OnFieldFound = TableFieldFound;
            autofillhelper_cust.OnPostTextBoxChange = PostTextChanges;

            btnUpdate.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;


            autofillhelper_cust.ListTB.Clear();
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbTitle, CustomerTableClass.TITLE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbFirstName, CustomerTableClass.FIRSTNAME));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbName, CustomerTableClass.NAME));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbAttn1, CustomerTableClass.ATTN1));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbAttn2, CustomerTableClass.ATTN2));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbAddress, CustomerTableClass.ADDRESS));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbAddressExtra, CustomerTableClass.ADDRESSEXTRA));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbPostalCode, CustomerTableClass.POSTALCODE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCity, CustomerTableClass.CITY));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCustomNo, CustomerTableClass.NUMBER));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbFatNo, CustomerTableClass.FATNO));


            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbIBAN, CustomerTableClass.IBAN));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbStatus, CustomerTableClass.STATUS));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbRemarks, CustomerTableClass.REMARKS));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbPhone, CustomerTableClass.PHONE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbMobile, CustomerTableClass.MOBILE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbPayment, CustomerTableClass.PAYMENT));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbFolder, CustomerTableClass.SAVEFOLDER));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbEmail, CustomerTableClass.EMAIL));

            GenerateNewInvoiceNo();

            // text box events
            autofillhelper_cust.SetTBEvents();
        }

        public decimal GetDiscount()
        {
            return nUDDiscountPr.Value;
        }

        public string GetEmail()
        {
            return tbEmail.Text;
        }

        public void ResetDate()
        {
            dTPDate.Value = DateTime.Now;
        }


        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            autofillhelper_cust.DBRef = db;
            customers_dbtable = new CustomerTableClass(autofillhelper_cust.DBRef);
            ReloadTable();
        }

        private void ReloadTable()
        {
            autofillhelper_cust.AutoFillDisable = true;

            autofillhelper_cust.SetAutoCompleteMode(AutoCompleteMode.None);

            customers_datatable = customers_dbtable.GetAllData();
            _dbzeros_detected = Tools.HasNull(customers_datatable);
            if (_dbzeros_detected)
            {
                MessageBox.Show(String.Format("{0} tabel bevat NULL waarden!", customers_dbtable.TableName));
            }

            for (int i = 0; i < autofillhelper_cust.ListTB.Count; i++)
            {
                autofillhelper_cust.ListTB[i].DBTable = customers_dbtable;
                autofillhelper_cust.ListTB[i].Datatable = customers_datatable;
            }
            autofillhelper_cust.UpdateAutFillData();

            if (customers_datatable != null && !_dbzeros_detected)
            {
                cbAutoFillDisable.Enabled = true;
                autofillhelper_cust.AutoFillDisable = cbAutoFillDisable.Checked;
                if (!cbAutoFillDisable.Checked)
                {
                    autofillhelper_cust.SetAutoCompleteMode(AutoCompleteMode.Suggest);
                }
                btnNew.Enabled = true;
            }
            else
            {
                cbAutoFillDisable.Checked = true;
                cbAutoFillDisable.Enabled = false;
                btnNew.Enabled = false;
            }
        }

        private void TableFieldFound(object sender, int idx)
        {
            if (sender == autofillhelper_cust)
            {
                //non textbox controls
                nUDID.Value = (decimal)((int)customers_datatable.Rows[idx][CustomerTableClass.ID]);
                //reseller
                cbReseller.Checked = (bool)customers_datatable.Rows[idx][CustomerTableClass.RESELLER];
                //blocked
                cbBlocked.Checked = (bool)customers_datatable.Rows[idx][CustomerTableClass.BLOCKED];
                //expired
                cbExpired.Checked = (bool)customers_datatable.Rows[idx][CustomerTableClass.EXPIRED];
                //ccv
                nUDInvoicePeriod.Value = (decimal)((int)customers_datatable.Rows[idx][CustomerTableClass.INVOICEPERIOD]);
                nUDCategory.Value = (decimal)((int)customers_datatable.Rows[idx][CustomerTableClass.CCVCATEGORY]);
                //discount
                nUDDiscountPr.Value = Doule2Dec((double)customers_datatable.Rows[idx][CustomerTableClass.DISCOUNTPRODUCTSPERC], nUDDiscountPr.Maximum);
                nUDDiscountLabor.Value = (decimal)((double)customers_datatable.Rows[idx][CustomerTableClass.DISCOUNTLABOUR]);
                //ccv discount
                nUDDiscountDiesel.Value = (decimal)((double)customers_datatable.Rows[idx][CustomerTableClass.DISCONTDIESEL]);
                nUDDiscount95.Value = (decimal)((double)customers_datatable.Rows[idx][CustomerTableClass.DISCOUNT95]);
                nUDDiscount98.Value = (decimal)((double)customers_datatable.Rows[idx][CustomerTableClass.DISCOUNT98]);
                //date
                dateTimePickerBlocked.Value = DataBaseTableClassBase.GetDate((Int64)customers_datatable.Rows[idx][CustomerTableClass.DATEBLOCKED]);
                dateTimePickerDirectDebit.Value = DataBaseTableClassBase.GetDate((Int64)customers_datatable.Rows[idx][CustomerTableClass.DATACCVDIRECTDEBIT]);
                dateTimePickerExpired.Value = DataBaseTableClassBase.GetDate((Int64)customers_datatable.Rows[idx][CustomerTableClass.DATEEXPIRED]);
                dateTimePickerLastModified.Value = DataBaseTableClassBase.GetDate((Int64)customers_datatable.Rows[idx][CustomerTableClass.DATELASTUPDATE]);
                dateTimePickerCreate.Value = DataBaseTableClassBase.GetDate((Int64)customers_datatable.Rows[idx][CustomerTableClass.DATECREATE]);
                if (OnPaymentFieldChanged != null)
                    OnPaymentFieldChanged(tbPayment.Text);
            }
        }

        private void PostTextChanges(object sender, EventArgs e)
        {
            btnUpdate.Enabled = (tbName.Text.Length > 0) && (tbCustomNo.Text.Length > 0) && (btnNew.Text == BTN_NEW); //update current customer
            btnDelete.Enabled = btnUpdate.Enabled;
            if (sender == tbPayment &&  OnPaymentFieldChanged != null)
                OnPaymentFieldChanged(tbPayment.Text);
            //btnNew.Enabled = tbName.Text.Length > 0;    //or add as new (new customer no should be created)
        }

        private decimal Doule2Dec(double value, decimal max)
        {
            decimal v = (decimal)(value);
            v = v > max ? max : v;
            return v;
        }

        /// <summary>
        /// Update customer data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string customerno = tbCustomNo.Text;
            int id = (int)((double)nUDID.Value+0.5);

            //DataTable data = customers_dbtable.GetFilteredData(String.Format("{0} = '{1}' AND {2} = '{3}'", customers_dbtable.FieldNames[CustomerTableClass.NUMBER], customerno, customers_dbtable.FieldNames[CustomerTableClass.ID], id));
            //string filter = String.Format("{0} = '{1}' AND {2} = '{3}'", customers_dbtable.FieldNames[CustomerTableClass.NUMBER], customerno, customers_dbtable.FieldNames[CustomerTableClass.ID], id);
            string filter = String.Format("{0} = '{1}'",  customers_dbtable.FieldNames[CustomerTableClass.ID], id);
            string sort = "";
            DataRow[] cd = customers_datatable.Select(filter, sort);
            //if (data.Rows.Count <= 0)
            if (cd.Length <= 0)
            {
                MessageBox.Show("Deze klant bestaat niet!\nKlantnummer: " + customerno);
                return;
            }
            object[] upddata = new object[customers_dbtable.FieldNames.Length];
            for (int i = 0; i < customers_dbtable.FieldNames.Length; i++)
            {
                upddata[i] = cd[0][i];// data.Rows[0][i];
            }

            upddata = GetRecordData(false, upddata);

            if (!customers_dbtable.Update(new int[] { CustomerTableClass.ID }, new object[] { id }, customers_dbtable.FieldIds, upddata))
            {
                MessageBox.Show("Er is een fout opgetreden:\n" + customers_dbtable.LastMessage);
            }
            else
            {
                ReloadTable();
                tbCustomNo.Text = customerno;
                if (OnDBUpdated != null)
                    OnDBUpdated(this);
            }          
        }

        /// <summary>
        /// Get record data from input fields
        /// </summary>
        /// <param name="updatecreatedata"></param>
        /// <param name="updatedata"></param>
        /// <returns></returns>
        private object[] GetRecordData(bool updatecreatedata = true, object[] updatedata = null)
        {
            object[] data;
            if (updatedata == null)
                data = new object[customers_dbtable.FieldNames.Length];
            else
                data = updatedata;

            data[CustomerTableClass.TITLE] = tbTitle.Text;
            data[CustomerTableClass.FIRSTNAME] = tbFirstName.Text;
            data[CustomerTableClass.NAME] = tbName.Text;
            data[CustomerTableClass.NUMBER] = tbCustomNo.Text;
            data[CustomerTableClass.ATTN1] = tbAttn1.Text;
            data[CustomerTableClass.ATTN2] = tbAttn2.Text;
            data[CustomerTableClass.ADDRESS] = tbAddress.Text;
            data[CustomerTableClass.ADDRESSEXTRA] = tbAddressExtra.Text;
            data[CustomerTableClass.POSTALCODE] = tbPostalCode.Text;
            data[CustomerTableClass.CITY] = tbCity.Text;
            data[CustomerTableClass.IBAN] = tbIBAN.Text;
            data[CustomerTableClass.REMARKS] = tbRemarks.Text;
            data[CustomerTableClass.STATUS] = tbStatus.Text;
            data[CustomerTableClass.PHONE] = tbPhone.Text;
            data[CustomerTableClass.MOBILE] = tbMobile.Text;
            data[CustomerTableClass.PAYMENT] = tbPayment.Text;
            data[CustomerTableClass.SAVEFOLDER] = tbFolder.Text;
            data[CustomerTableClass.EMAIL] = tbEmail.Text;
            data[CustomerTableClass.DISCOUNTPRODUCTSPERC] = (double)nUDDiscountPr.Value;
            data[CustomerTableClass.DISCOUNTLABOUR] = (double)nUDDiscountLabor.Value;
            data[CustomerTableClass.FATNO] = tbFatNo.Text;
            data[CustomerTableClass.DISCOUNT95] = (double)nUDDiscount95.Value;
            data[CustomerTableClass.DISCONTDIESEL] = (double)nUDDiscountDiesel.Value;
            data[CustomerTableClass.DISCOUNT98] = (double)nUDDiscount98.Value;

            data[CustomerTableClass.CCVCATEGORY] = (int)nUDCategory.Value;
            data[CustomerTableClass.INVOICEPERIOD] = (int)nUDInvoicePeriod.Value;
            data[CustomerTableClass.BLOCKED] = cbBlocked.Checked?1:0;
            data[CustomerTableClass.EXPIRED] = cbExpired.Checked ? 1 : 0;

            data[CustomerTableClass.DATEBLOCKED] = DataBaseTableClassBase.ConvertDateValue(dateTimePickerBlocked.Value);
            data[CustomerTableClass.DATEEXPIRED] = DataBaseTableClassBase.ConvertDateValue(dateTimePickerExpired.Value);
            data[CustomerTableClass.DATACCVDIRECTDEBIT] = DataBaseTableClassBase.ConvertDateValue(dateTimePickerDirectDebit.Value);

            data[CustomerTableClass.RESELLER] = cbReseller.Checked?1:0;
            data[CustomerTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
            if (updatecreatedata)
                data[CustomerTableClass.DATECREATE] = DataBaseTableClassBase.GetDateValue();

            return data;
        }

        private void cbAutoFillDisable_CheckedChanged(object sender, EventArgs e)
        {
            SetAutoCompleteMode(cbAutoFillDisable.Checked);
        }

        private void SetAutoCompleteMode(bool disabled)
        {
            autofillhelper_cust.AutoFillDisable = disabled;
            autofillhelper_cust.SetAutoCompleteMode(disabled ? AutoCompleteMode.None : AutoCompleteMode.Suggest);
        }

        public void GenerateNewInvoiceNo()
        {
            tbInvoiceNo.Text = DateTime.Now.ToString("yyMMdd") + String.Format("{0:D4}", invoice_no++);
        }

        public InvoiceHeaderData GetInvoiceHeaderData()
        {
            InvoiceHeaderData header = new InvoiceHeaderData();

            header.fullname = tbTitle.Text + (tbTitle.Text.Length > 0 ? " " : "") + tbFirstName.Text + (tbFirstName.Text.Length > 0 ? " " : "") + tbName.Text;
            header.attn1 = tbAttn1.Text;
            header.attn2 = tbAttn2.Text;
            header.addr1 = tbAddress.Text;
            header.addr2 = tbAddressExtra.Text;
            header.postalcode = tbPostalCode.Text;
            header.city = tbCity.Text;
            header.invoiceno = tbInvoiceNo.Text;
            header.customno = tbCustomNo.Text;
            header.fatno = tbFatNo.Text;
            header.date = dTPDate.Value.ToString("dd MMMM yyyy");
            header.savefolder = tbFolder.Text;
            header.email = tbEmail.Text;
            header.customerid = (int)nUDID.Value;
            return header;             
        }

        private void cbReseller_CheckedChanged(object sender, EventArgs e)
        {
            if (OnResellerFieldChanged != null)
                OnResellerFieldChanged(cbReseller.Checked);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == BTN_NEW)
            {
                ResetAllFields();
                tbCustomNo.Text = GenerateNewCustomerNo();
                btnNew.Text = BTN_SAVE;
                btnCancel.Enabled = true;
                _user_autodisable = cbAutoFillDisable.Checked;
                cbAutoFillDisable.Checked = true;
                tbName.Focus();
            }
            else
            {
                object[] data = GetRecordData();

                if(customers_dbtable.RecordExists(new int[] { CustomerTableClass.NUMBER }, new object[] { data[CustomerTableClass.NUMBER] }))
                {
                     if (MessageBox.Show("Dit klant nummmer bestaat al\nEen kopie aanmaken?", "Nieuwe klant", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                if (!customers_dbtable.Insert(data))
                {
                    MessageBox.Show("Er is een fout opgetreden:\n" + customers_dbtable.LastMessage);
                }
                else
                {
                    ReloadTable();
                    cbAutoFillDisable.Checked = _user_autodisable;
                    if (OnDBUpdated != null)
                        OnDBUpdated(this);
                    btnNew.Text = BTN_NEW;
                    btnCancel.Enabled = false;
                    if (customers_datatable != null)
                    {
                        nUDID.Value = (decimal)((int)customers_datatable.Rows[customers_datatable.Rows.Count-1][CustomerTableClass.ID]);
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = btnUpdate.Enabled;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAllFields();
            btnNew.Text = BTN_NEW;
            btnCancel.Enabled = false;
            cbAutoFillDisable.Checked = _user_autodisable;
        }

        private void ResetAllFields()
        {
            bool acmodedisabled = cbAutoFillDisable.Checked;
            if (!acmodedisabled)
                SetAutoCompleteMode(true); //disable

            tbTitle.Text = "";
            tbFirstName.Text = "";
            tbName.Text = "";
            tbCustomNo.Text = "";
            tbAttn1.Text = "";
            tbAttn2.Text = "";
            tbAddress.Text = "";
            tbAddressExtra.Text = "";
            tbPostalCode.Text = "";
            tbCity.Text = "";
            tbIBAN.Text = "";
            tbRemarks.Text = "";
            tbStatus.Text = "";
            tbPhone.Text = "";
            tbMobile.Text = "";
            tbPayment.Text = "";
            tbFatNo.Text = "";
            tbFolder.Text = "";
            tbEmail.Text = "";

            //non textbox controls
            nUDID.Value = -1;
            //reseller
            cbReseller.Checked = false;
            //blocked
            cbBlocked.Checked = false;
            //expired
            cbExpired.Checked = false;
            //ccv
            nUDInvoicePeriod.Value = 0;
            nUDCategory.Value = 0;
            //discount
            nUDDiscountPr.Value = 0;
            nUDDiscountLabor.Value = 0;
            //ccv discount
            nUDDiscountDiesel.Value = 0;
            nUDDiscount95.Value = 0;
            nUDDiscount98.Value = 0;
            //date
            dateTimePickerBlocked.Value = DataBaseTableClassBase.GetDate(0);
            dateTimePickerDirectDebit.Value = DataBaseTableClassBase.GetDate(0);
            dateTimePickerExpired.Value = DataBaseTableClassBase.GetDate(0);
            dateTimePickerLastModified.Value = DateTime.Now;
            dateTimePickerCreate.Value = DateTime.Now;

            if (!acmodedisabled)
                SetAutoCompleteMode(false); //re-enable
        }

        public string GenerateNewCustomerNo()
        {
            //get new customer no.
            string filter = "";
            string sort = string.Format("{0} asc", customers_dbtable.FieldNames[CustomerTableClass.NUMBER]);
            DataRow[] cno = customers_datatable.Select(filter, sort);
            int custno = 0;
            if (cno.Length > 0)
            {
                for (int i = cno.Length - 1; i >= 0; i--)
                {
                    try
                    {
                        custno = Int32.Parse((string)cno[i][CustomerTableClass.NUMBER]);
                        break; //ready
                    }
                    catch (Exception) { continue; }
                }
            }
            custno = custno == 0 ? 1000001 : custno + 1; // offset or new number
            return String.Format("{0}", custno);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zeker weten?", "Verwijder klant", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                if (!customers_dbtable.Delete(new int[] { CustomerTableClass.NUMBER }, new object[] { tbCustomNo.Text }))
                {
                    MessageBox.Show("Er is een fout opgetreden:\n" + customers_dbtable.LastMessage);
                }
                else
                {
                    ReloadTable();
                    ResetAllFields();
                }
            }
        }


    }

    public class InvoiceHeaderData
    {
        public string fullname;
        public string attn1;
        public string attn2;
        public string addr1;
        public string addr2;
        public string postalcode;
        public string city;
        public string invoiceno;
        public string date;
        public string customno;
        public string fatno;
        public string savefolder;
        public string email;
        public int customerid;
        public InvoiceHeaderData()
        {
        }

    }

}
