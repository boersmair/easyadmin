using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyAdmin
{
    public partial class CreateAFIS12Header : UserControl, IAutoFillHelper
    {
        private const string BTN_NEW = "Nieuw";
        private const string BTN_SAVE = "Opslaan";

        public delegate void AddTicket(CreateAFIS12Line ticket);
        public AddTicket OnAddTicket;
        private AutoFillHelperClass autofillhelper_ccvc;
        private AutoFillHelperClass autofillhelper_cust;
        private CCVCardsTableClass ccvcards_dbtable;
        private DataTable ccvcards_datatable;
        private CustomerTableClass customers_dbtable;
        private DataTable customers_datatable;
        private bool _dbcustzeros_detected;
        private bool _dbccvzeros_detected;
        private bool _user_autodisable;
      
        public CreateAFIS12Header()
        {
            InitializeComponent();
            autofillhelper_ccvc = new AutoFillHelperClass();
            autofillhelper_cust = new AutoFillHelperClass();

            autofillhelper_ccvc.OnFieldFound = TableFieldFound;
            autofillhelper_ccvc.OnNoFieldFound = NoTableFieldFound;
            autofillhelper_ccvc.OnPostTextBoxChange = PostTextChanges;
            autofillhelper_cust.OnFieldFound = TableFieldFound;
            autofillhelper_cust.OnNoFieldFound = NoTableFieldFound;

            btnUpdate.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;

            autofillhelper_ccvc.ListTB.Clear();
            //textbox ccvcards
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCardno, CCVCardsTableClass.CARDNUMBER));
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(createAFIS12Line1.TBCardNo, CCVCardsTableClass.CARDNUMBER));
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCustomerno, CCVCardsTableClass.CUSTOMNUMBER));

            //autocomplete textbox ccvcards
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbName, CCVCardsTableClass.NAME));
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(createAFIS12Line1.TBName, CCVCardsTableClass.NAME));
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbMark, CCVCardsTableClass.MARK));
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbStatus, CCVCardsTableClass.STATUS));
            autofillhelper_ccvc.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbRemarks, CCVCardsTableClass.REMARKS));

            //textbox/autocomplete (customers table)
            autofillhelper_cust.ListTB.Clear();
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbNameCustomerTable, CustomerTableClass.NAME));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCustomnoCustTable, CustomerTableClass.NUMBER));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbAddress, CustomerTableClass.ADDRESS));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbPostalcode, CustomerTableClass.POSTALCODE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCity, CustomerTableClass.CITY));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbPhone, CustomerTableClass.PHONE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbCellPhone, CustomerTableClass.MOBILE));
            autofillhelper_cust.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbIBAN, CustomerTableClass.IBAN));

            autofillhelper_ccvc.SetTBEvents();
            autofillhelper_cust.SetTBEvents();

            createAFIS12Line1.OnTotalPriceValidated = TotalPriceValidated;

        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            autofillhelper_ccvc.DBRef = db;
            autofillhelper_cust.DBRef = db;
            ccvcards_dbtable = new CCVCardsTableClass(autofillhelper_ccvc.DBRef);
            customers_dbtable = new CustomerTableClass(autofillhelper_cust.DBRef);
            ReloadTables();
        }

        /// <summary>
        /// Update the memory tables from database
        /// </summary>
        private void ReloadTables()
        {
            autofillhelper_ccvc.AutoFillDisable = true;
            autofillhelper_cust.AutoFillDisable = true;

            autofillhelper_ccvc.SetAutoCompleteMode(AutoCompleteMode.None);
            autofillhelper_cust.SetAutoCompleteMode(AutoCompleteMode.None);

            ccvcards_datatable = ccvcards_dbtable.GetAllData();
            _dbccvzeros_detected = Tools.HasNull(ccvcards_datatable);
            if (_dbccvzeros_detected)
            {
                MessageBox.Show(String.Format("{0} tabel bevat NULL waarden!", ccvcards_datatable.TableName));
            }

            for (int i = 0; i < autofillhelper_ccvc.ListTB.Count; i++)
            {
                autofillhelper_ccvc.ListTB[i].DBTable = ccvcards_dbtable;
                autofillhelper_ccvc.ListTB[i].Datatable = ccvcards_datatable;
            }
            autofillhelper_ccvc.UpdateAutFillData();

            customers_datatable = customers_dbtable.GetAllData();
            _dbcustzeros_detected = Tools.HasNull(customers_datatable);
            if (_dbcustzeros_detected)
            {
                MessageBox.Show(String.Format("{0} tabel bevat NULL waarden!", customers_dbtable.TableName));
            }

            for (int i = 0; i < autofillhelper_cust.ListTB.Count; i++)
            {
                autofillhelper_cust.ListTB[i].DBTable = customers_dbtable;
                autofillhelper_cust.ListTB[i].Datatable = customers_datatable;
            }
            autofillhelper_cust.UpdateAutFillData();

            btnNew.Enabled = (ccvcards_datatable != null && !_dbccvzeros_detected);

            if (customers_datatable != null && ccvcards_datatable != null && !_dbcustzeros_detected && !_dbccvzeros_detected)
            {
                cbAutoFillDisable.Enabled = true;
                autofillhelper_ccvc.AutoFillDisable = cbAutoFillDisable.Checked;
                autofillhelper_cust.AutoFillDisable = cbAutoFillDisable.Checked;
                if (!cbAutoFillDisable.Checked)
                {
                    autofillhelper_ccvc.SetAutoCompleteMode(AutoCompleteMode.Suggest);
                    autofillhelper_cust.SetAutoCompleteMode(AutoCompleteMode.Suggest);
                }
            }
            else
            {
                cbAutoFillDisable.Checked = true;
                cbAutoFillDisable.Enabled = false;
            }

        }

        /// <summary>
        /// Autocomplete class did find a match, update non textbox fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="idx"></param>
        private void TableFieldFound(object sender, int idx)
        {
            string cn;
            if (sender == autofillhelper_ccvc)
            {
                //non textbox controls
                nUDID.Value = (decimal)((int)ccvcards_datatable.Rows[idx][CCVCardsTableClass.ID]);
                //blocked
                cbBlocked.Checked = (bool)ccvcards_datatable.Rows[idx][CCVCardsTableClass.BLOCKED];
                //expired
                cbExpired.Checked = (bool)ccvcards_datatable.Rows[idx][CCVCardsTableClass.EXPIRED];
                UpdateControlColors();
                //date
                dTPBlocked.Value = DataBaseTableClassBase.GetDate((Int64)ccvcards_datatable.Rows[idx][CCVCardsTableClass.DATEBLOCKED]);
                dTPExpired.Value = DataBaseTableClassBase.GetDate((Int64)ccvcards_datatable.Rows[idx][CCVCardsTableClass.DATEEXPIRED]);
                dTPUpdated.Value = DataBaseTableClassBase.GetDate((Int64)ccvcards_datatable.Rows[idx][CCVCardsTableClass.DATELASTUPDATE]);
                dTPCreate.Value = DataBaseTableClassBase.GetDate((Int64)ccvcards_datatable.Rows[idx][CCVCardsTableClass.DATECREATE]);   
                cn = (string)ccvcards_datatable.Rows[idx][CCVCardsTableClass.CUSTOMNUMBER];
                while (cn.Length < 7)
                    cn = "0" + cn;
               // if(cn.Length<7)
                //    cn = cn.Substring(1);
                tbCustomnoCustTable.Text = cn;
                tbPin.Text = (string)ccvcards_datatable.Rows[idx][CCVCardsTableClass.PIN];
                tbNameCustomerTable.BackColor = Color.White;
            }
            else if (sender == autofillhelper_cust)
            {
                nUDInvoicePeriod.Value = (decimal)((int)customers_datatable.Rows[idx][CustomerTableClass.INVOICEPERIOD]);
                nUDCategory.Value = (decimal)((int)customers_datatable.Rows[idx][CustomerTableClass.CCVCATEGORY]);
                cn = (string)customers_datatable.Rows[idx][CustomerTableClass.NUMBER];
                if (cn.Length > 6 && cn.StartsWith("0"))
                    cn = cn.Substring(1);
                tbCustomerno.Text = cn;
                cbExpiredCustomer.Checked = (bool)customers_datatable.Rows[idx][CustomerTableClass.EXPIRED];
                cbCustomBlocked.Checked = (bool)customers_datatable.Rows[idx][CustomerTableClass.BLOCKED];

            }
        }

        /// <summary>
        /// Blocked and expire checkboxes text color
        /// </summary>
        private void UpdateControlColors()
        {
            cbBlocked.ForeColor = cbBlocked.Checked ? Color.Red : System.Drawing.SystemColors.ControlText;
            cbExpired.ForeColor = cbExpired.Checked ? Color.Red : System.Drawing.SystemColors.ControlText;
        }

        private void NoTableFieldFound(object sender)
        {
            if (sender == autofillhelper_ccvc && tbCustomnoCustTable.Text.Length>0)
            {
                tbNameCustomerTable.BackColor = Color.Red;
            }
            //else if (sender == autofillhelper_cust && tbCustomerno.Text.Length>0)
           // {
           // }
  
        }

        private void PostTextChanges(object sender, EventArgs e)
        {
            btnUpdate.Enabled = (tbName.Text.Length > 0) && (tbCardno.Text.Length > 0) && (btnNew.Text == BTN_NEW); //update current customer
            btnDelete.Enabled = btnUpdate.Enabled;
        }

        private void TotalPriceValidated()
        {
            btnAdd.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (OnAddTicket != null)
                OnAddTicket(createAFIS12Line1);
        }

        /// <summary>
        /// Reset all fields to default for new card.
        /// </summary>
        private void ResetAllFields()
        {
            bool acmodedisabled = cbAutoFillDisable.Checked;
            if (!acmodedisabled)
                SetAutoCompleteMode(true); //disable

            tbCardno.Text = "";
            tbCustomerno.Text = "";
            tbName.Text = "";
            tbMark.Text = "";
            tbStatus.Text = "";
            tbRemarks.Text = "";            

            tbPin.Text = "";

            //non textbox controls
            nUDID.Value = -1;
            //blocked
            cbBlocked.Checked = false;
            //expired
            cbExpired.Checked = false;
            //date
            dTPBlocked.Value = DataBaseTableClassBase.GetDate(0);
            dTPExpired.Value = DataBaseTableClassBase.GetDate(0);
            dTPUpdated.Value = DateTime.Now;
            dTPCreate.Value = DateTime.Now;

            UpdateControlColors();

            if (!acmodedisabled)
                SetAutoCompleteMode(false); //re-enable
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cardno = tbCardno.Text;
            int id = (int)((double)nUDID.Value + 0.5);

           // DataTable data = ccvcards_dbtable.GetFilteredData(String.Format("{0} = '{1}' AND {2} = '{3}'", ccvcards_dbtable.FieldNames[CCVCardsTableClass.CARDNUMBER], cardno, ccvcards_dbtable.FieldNames[CCVCardsTableClass.ID], id));
            //string filter = String.Format("{0} = '{1}' AND {2} = '{3}'", ccvcards_dbtable.FieldNames[CCVCardsTableClass.CARDNUMBER], cardno, ccvcards_dbtable.FieldNames[CCVCardsTableClass.ID], id);
            string filter = String.Format("{0} = '{1}' ", ccvcards_dbtable.FieldNames[CCVCardsTableClass.ID], id);
            string sort = "";
            DataRow[] cd = ccvcards_datatable.Select(filter, sort);
            //if (data.Rows.Count <= 0)
            if (cd.Length <= 0)
            {
                MessageBox.Show("Deze kaart bestaat niet!\n(Kaartnummer: " + cardno);
                return;
            }
            object[] upddata = new object[ccvcards_dbtable.FieldNames.Length];
            for (int i = 0; i < ccvcards_dbtable.FieldNames.Length; i++)
            {
                upddata[i] = cd[0][i];
            }

            upddata = GetRecordData(false, upddata);

            if (!ccvcards_dbtable.Update(new int[] { CCVCardsTableClass.ID }, new object[] { id}, ccvcards_dbtable.FieldIds, upddata))
            {
                MessageBox.Show("Er is een fout opgetreden:\n" + ccvcards_dbtable.LastMessage);
            }
            else
            {
                ReloadTables();
                tbCardno.Text = cardno;
            }
            ReloadTables();
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
                data = new object[ccvcards_dbtable.FieldNames.Length];
            else
                data = updatedata;

            data[CCVCardsTableClass.CUSTOMNUMBER] = tbCustomerno.Text;
            data[CCVCardsTableClass.CARDNUMBER] = tbCardno.Text;
            data[CCVCardsTableClass.PIN] = tbPin.Text;
            data[CCVCardsTableClass.NAME] = tbName.Text;
            data[CCVCardsTableClass.STATUS] = tbStatus.Text;
            data[CCVCardsTableClass.REMARKS] = tbRemarks.Text;
            data[CCVCardsTableClass.MARK] = tbMark.Text;
            data[CCVCardsTableClass.BLOCKED] = cbBlocked.Checked ? 1 : 0;
            data[CCVCardsTableClass.EXPIRED] = cbExpired.Checked ? 1 : 0;

            data[CCVCardsTableClass.DATEBLOCKED] = DataBaseTableClassBase.ConvertDateValue(dTPBlocked.Value);
            data[CCVCardsTableClass.DATEEXPIRED] = DataBaseTableClassBase.ConvertDateValue(dTPExpired.Value);
            data[CCVCardsTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
            if (updatecreatedata)
                data[CCVCardsTableClass.DATECREATE] = DataBaseTableClassBase.GetDateValue();

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
            autofillhelper_ccvc.AutoFillDisable = disabled;
            autofillhelper_ccvc.SetAutoCompleteMode(disabled ? AutoCompleteMode.None : AutoCompleteMode.Suggest);
        }

        /// <summary>
        /// Create new card. Start with default field values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewCCVCard_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == BTN_NEW)
            {
                ResetAllFields();
                btnNew.Text = BTN_SAVE;
                btnCancel.Enabled = true;
                _user_autodisable = cbAutoFillDisable.Checked;
                cbAutoFillDisable.Checked = true;
                tbName.Focus();
            }
            else
            {
                object[] data = GetRecordData();

                if (ccvcards_dbtable.RecordExists(new int[] { CCVCardsTableClass.CARDNUMBER }, new object[] { data[CCVCardsTableClass.CARDNUMBER] }))
                {
                    if (MessageBox.Show("Dit pasnummmer bestaat al\nEen kopie aanmaken?", "Nieuwe pas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                if (!ccvcards_dbtable.Insert(data))
                {
                    MessageBox.Show("Er is een fout opgetreden:\n" + ccvcards_dbtable.LastMessage);
                }
                else
                {
                    ReloadTables();
                    cbAutoFillDisable.Checked = _user_autodisable;
                    btnNew.Text = BTN_NEW;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = btnUpdate.Enabled;
                    btnCancel.Enabled = false;
                    if (ccvcards_dbtable != null)
                    {
                        nUDID.Value = (decimal)((int)ccvcards_datatable.Rows[ccvcards_datatable.Rows.Count - 1][CCVCardsTableClass.ID]);
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = btnUpdate.Enabled;
                    }
                }
            }
        }

        /// <summary>
        /// Cancel new card input. Clear all fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAllFields();
            btnNew.Text = BTN_NEW;
            btnCancel.Enabled = false;
            cbAutoFillDisable.Checked = _user_autodisable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zeker weten?", "Verwijder klant", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                if (!ccvcards_dbtable.Delete(new int[] { CCVCardsTableClass.CARDNUMBER }, new object[] { tbCardno.Text }))
                {
                    MessageBox.Show("Er is een fout opgetreden:\n" + ccvcards_dbtable.LastMessage);
                }
                else
                {
                    ReloadTables();
                    ResetAllFields();
                }
            }

        }



    }
}
