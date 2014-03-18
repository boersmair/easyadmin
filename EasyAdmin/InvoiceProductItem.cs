using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace EasyAdmin
{
    public partial class InvoiceProductItem : UserControl
    {        
        private double[] fat_data_percent = {21.0, 6.0, 0.0 };
        private AutoFillHelperClass autofillhelper_products;
        private ProductsTableClass products_dbtable;
        private DataTable products_datatable;
        public delegate void PriceUpdate();
        public PriceUpdate OnPriceUpdate;
        public delegate void Go2NextProductLine(object sender);
        public Go2NextProductLine OnGo2NextProductLine;
        public delegate decimal GetDiscount();
        public GetDiscount OnGetDiscount;
        private bool firstdiscountrequest = true;
        private bool _dbzeros_detected = false;

        public InvoiceProductItem()
        {
            InitializeComponent();

            cbAdd.Enabled = false;
            cbUpdate.Enabled = false;

            UpdateInvoiceSettings();

            autofillhelper_products = new AutoFillHelperClass();

            autofillhelper_products.OnFieldFound = TableFieldFound;
            autofillhelper_products.OnNoFieldFound = NoTableFieldFound;
            //autofillhelper_products.OnPostTextBoxChange = PostTextChanges;

            autofillhelper_products.ListTB.Clear();
            //autofillhelper_products.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbArticleID, ProductsTableClass.ARTICLENUMBER, null, null));
            autofillhelper_products.ListTB.Add(new AutoFillHelperClass.TextBoxContainer(tbDescription, ProductsTableClass.DESCRIPTION, null, null));

            autofillhelper_products.SetTBEvents();

            SetBTWValues(fat_data_percent, 0);
            tbPrice.Validated += new EventHandler(this.tb_Validated);
            tbDiscount.Validated += new EventHandler(this.tb_Validated);
            tbPrice.KeyDown += new KeyEventHandler(this.tbKeyDown);
            //tbPrice.KeyUp += new KeyEventHandler(this.tbKeyUp);
            tbDescription.KeyDown += new KeyEventHandler(this.tbKeyDown);
            nUDAmount.KeyDown += new KeyEventHandler(this.tbKeyDown);
            tbDiscount.KeyDown += new KeyEventHandler(this.tbKeyDown);
        }

        public void ClearFields()
        {
            cbUpdate.Checked = false;
            cbAdd.Checked = false;
            tbArticleID.Text = "";
            tbDescription.Text = "";
            firstdiscountrequest = true;
            tbPrice.Text = "";
            nUDAmount.Value = 1;
            tbDiscount.Text = "";
            cbFAT.SelectedIndex = 0;
            cbPriceExFAT.Checked = false;
            UpdatePriceAndFat();
        }

        public void UpdateInvoiceSettings()
        {
            nUDAmount.DecimalPlaces = (int)(Properties.Settings.Default.DecimalsInvoiceAmount + 0.5m);
        }

        public void SetFocusDescription()
        {
            tbDescription.Focus();
        }

        public void SetBTWValues(double[] fat_data, int defaultindex = 0)
        {
            cbFAT.Items.Clear();
            for (int i = 0; i < fat_data.Length; i++)
            {
                fat_data_percent[i] = fat_data[i];
                cbFAT.Items.Add(String.Format("BTW {0:0.0}%", fat_data[i]));
            }
            cbFAT.SelectedIndex = defaultindex;
        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public bool UpdateDBSettings(DataBaseClass db, int con)
        {
            autofillhelper_products.DBRef = db;
            products_dbtable = new ProductsTableClass(autofillhelper_products.DBRef);
            return ReloadTable(con);
        }

        private bool ReloadTable(int con)
        {
            bool dbconnectionok = con==0?false:con==1?true:false; //con==2 = error, con==1 = ok, con==0 must check connection
            if (con==0) //first time check connection
                dbconnectionok = autofillhelper_products.DBRef.TestConnection(false);
            if (dbconnectionok)
            {
                autofillhelper_products.AutoFillDisable = true;
                autofillhelper_products.SetAutoCompleteMode(AutoCompleteMode.None);

                if (!products_dbtable.TableExist())
                {
                    if (!products_dbtable.CreateTable())
                    {
                        MessageBox.Show(String.Format("Kan de producten tabel niet maken:\n{0}", products_dbtable.LastMessage));
                        dbconnectionok = false;
                    }
                }
                if (dbconnectionok)
                {
                    products_datatable = products_dbtable.GetAllData();
                    _dbzeros_detected = Tools.HasNull(products_datatable);
                    if (_dbzeros_detected)
                    {
                        MessageBox.Show(String.Format("{0} tabel bevat NULL waarden!", products_datatable.TableName));
                    }
                    for (int i = 0; i < autofillhelper_products.ListTB.Count; i++)
                    {
                        autofillhelper_products.ListTB[i].DBTable = products_dbtable;
                        autofillhelper_products.ListTB[i].Datatable = products_datatable;
                    }
                    autofillhelper_products.UpdateAutFillData();
                }

                if (products_datatable != null || !_dbzeros_detected)
                {
                    autofillhelper_products.AutoFillDisable = false;// cbAutoFillDisable.Checked;
                    //if (!cbAutoFillDisable.Checked)
                   // {
                    autofillhelper_products.SetAutoCompleteMode(AutoCompleteMode.Suggest);
                    //}
                }
                else
                {
                    ;// cbAutoFillDisable.Checked = true;
                }


            }

            return dbconnectionok;
        }


        /// <summary>
        /// match with existing item in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="idx"></param>
        private void TableFieldFound(object sender, int idx)
        {
            //non textbox controls
            int fatcat = 0;
            //non textbox controls
            tbPrice.Text = String.Format("{0:0.00}", ((double)products_datatable.Rows[idx][ProductsTableClass.PRICE]));
            fatcat = (int)products_datatable.Rows[idx][ProductsTableClass.FATCAT];
            cbFAT.SelectedIndex = fatcat >= cbFAT.Items.Count ? 0 : fatcat;
            tbArticleID.Text = (string)products_datatable.Rows[idx][ProductsTableClass.ARTICLENUMBER];
            cbAdd.Checked = false;
            cbAdd.Enabled = false;
            cbUpdate.Enabled = true;
        }

        /// <summary>
        /// No match with database item
        /// </summary>
        /// <param name="sender"></param>
        private void NoTableFieldFound(object sender)
        {
            cbUpdate.Enabled = false;
            cbAdd.Enabled = tbDescription.Text.Length > 0;
            cbAdd.Checked = cbAdd.Enabled;
        }
        /*
        private void PostTextChanges(object sender, EventArgs e)
        {
            if (sender == tbDescription)
            {

                int i = Array.IndexOf(tbDescription.Values, tbDescription.Text);
                cbUpdate.Enabled = true;
                cbUpdate.Checked = !cbadduncheckedbyuser;// !cbadduncheckedbyuser;
                cbUpdate.Enabled = tbDescription.Text.Length > 0 && !cbUpdate.Enabled;
                cbUpdate.Checked = tbDescription.Text.Length > 0 && !cbAdd.Checked;
            }
        }
        
        */

        private void nUDAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceAndFat();
        }

        private void nUDPrice_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceAndFat();
        }

        private void tb_Validated(object sender, EventArgs e)
        {
            if (sender == tbPrice)
            {
                //if (tbPrice.Text.Length > 0)
                //{
                    UpdatePriceAndFat();
                //}                
            }
            else if (sender == tbDiscount)
            {
                //if (tbDiscount.Text.Length > 0)
               // {
                    UpdatePriceAndFat();
               // }
            }
        }
        private void tbKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == tbDiscount && OnGo2NextProductLine != null)
                {
                    OnGo2NextProductLine(this);
                }
                else
                {
                    if (sender == tbDescription)
                    {
                        if (OnGetDiscount != null && firstdiscountrequest)
                        {
                            tbDiscount.Text = String.Format("{0:0.00}",OnGetDiscount());
                            firstdiscountrequest = false;
                        }
                    }
                    SendKeys.Send("{TAB}");
                }
                //e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void UpdatePriceAndFat()
        {
            double fat,totalprice, totalfat;
            double pr, disc;

            pr = StringToDouble(tbPrice.Text);
            disc = StringToDouble(tbDiscount.Text);
            totalprice = (pr * (double)nUDAmount.Value)*(1.0 - disc/100);
            fat = fat_data_percent[cbFAT.SelectedIndex]/100.0;
            nUDTotal.Value = (decimal)(cbPriceExFAT.Checked? totalprice*(1.0+fat) : totalprice);

            totalfat = cbPriceExFAT.Checked ? totalprice * fat : fat * (totalprice / (1.0 + fat));
            nUDFAT.Value = (decimal)totalfat;
            if (OnPriceUpdate != null)
                OnPriceUpdate();
        }

        private double StringToDouble(string value)
        {
            double v = 0;
            if (value.Length <= 0)
                return v;

            value = value.Replace(",", ".");
            double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out v);
            return v;
        }

        public decimal TotalFat
        {
            get { return nUDFAT.Value; }
        }

        public int Fatidx
        {
            get { return cbFAT.SelectedIndex; }
        }

        public decimal TotalPrice
        {
            get { return nUDTotal.Value; }
        }

        public void SetNo(int no)
        {
            labelNo.Text = String.Format("{0}", no); 
        }

        public decimal DiscountPercent
        {
            get { return (decimal)StringToDouble(tbDiscount.Text); }
        }

        private void cbFAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceAndFat();
        }

        private void cbPriceExFAT_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePriceAndFat();
        }

        private void nUDDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceAndFat();
        }

        public ProductItemData GetProductData()
        {
            ProductItemData pd = new ProductItemData();

            pd.articleno = tbArticleID.Text;
            pd.description = tbDescription.Text;
            pd.ammount = String.Format(String.Format("{{0:F{0}}}", nUDAmount.DecimalPlaces), nUDAmount.Value);
            if (Properties.Settings.Default.InvoiceAmountRemove0s &&  nUDAmount.DecimalPlaces > 0 && pd.ammount.EndsWith("0"))
            {
                do
                {
                    pd.ammount = pd.ammount.Substring(0, pd.ammount.Length - 1);
                } while (pd.ammount.EndsWith("0") || pd.ammount.EndsWith(".") || pd.ammount.EndsWith(","));
            }
            pd.priceperitem = DecimalSepCheck(tbPrice.Text, true);
            pd.fat = string.Format("{0:0.00}", nUDFAT.Value);
            pd.price = string.Format("{0:0.00}", nUDTotal.Value);
            pd.discount = DecimalSepCheck(tbDiscount.Text, false);
            pd.fatpercent = string.Format("{0:0.0}", fat_data_percent[cbFAT.SelectedIndex]);

            return pd;
        }

        private string DecimalSepCheck(string value, bool addzeros)
        {
            string retval = value;
            string uiSep = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
            if (value.Contains(".") || value.Contains(","))
            {
                string repl = uiSep == "." ? "," : ".";
                if (!value.Contains(uiSep)) // replace with system seperator
                {
                    retval = value.Replace(repl, uiSep);
                }
            }
            else
            {
                if (addzeros && value.Length>0)
                    retval = value + uiSep + "00";
            }
            return retval;
        }


        public void UpdateProductDB()
        {
            if (cbAdd.Checked && cbAdd.Enabled)
            {
                object[] data = GetRecordData();

                if (!products_dbtable.Insert(data))
                {
                    MessageBox.Show("Er is een fout opgetreden:\n" + products_dbtable.LastMessage);
                }
                else
                {
                    ReloadTable(1);                    
                }

            }
            else if (cbUpdate.Checked && cbUpdate.Enabled)
            {
                string filter = String.Format("{0} = '{1}'", products_dbtable.FieldNames[ProductsTableClass.DESCRIPTION], tbDescription.Text);
                string sort = "";
                DataRow[] cd = products_datatable.Select(filter, sort);
                if(cd.Length<=0)
                {
                    MessageBox.Show("Dit artikel bestaat niet!");
                    return;
                }
                object[] upddata = new object[products_dbtable.FieldNames.Length];
                for (int i = 0; i < products_dbtable.FieldNames.Length; i++)
                {
                    upddata[i] = cd[0][i];
                }

                upddata = GetRecordData(false, upddata);

                if (!products_dbtable.Update(new int[] { ProductsTableClass.DESCRIPTION }, new object[] { upddata[ProductsTableClass.DESCRIPTION] }, products_dbtable.FieldIds, upddata))
                {
                    MessageBox.Show("Er is een fout opgetreden:\n" + products_dbtable.LastMessage);
                }
                else
                {
                    ReloadTable(1);
                }          

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
                data = new object[products_dbtable.FieldNames.Length];
            else
                data = updatedata;

            data[ProductsTableClass.ARTICLENUMBER] = tbArticleID.Text;
            data[ProductsTableClass.DESCRIPTION] = tbDescription.Text;
            data[ProductsTableClass.FATCAT] = cbFAT.SelectedIndex;
            data[ProductsTableClass.PRICE] = StringToDouble(tbPrice.Text);
            data[ProductsTableClass.PRICEEXFAT] = cbPriceExFAT.Checked?1:0;
            data[ProductsTableClass.REMARKS] = "";
            data[ProductsTableClass.STATUS] = "";
            data[ProductsTableClass.CATEGORY] = "";
            data[ProductsTableClass.CATEGORYID] = 0;

            data[ProductsTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
            if (updatecreatedata)
                data[ProductsTableClass.DATECREATE] = DataBaseTableClassBase.GetDateValue();

            return data;
        }


    }

    public class ProductItemData
    {
        public string articleno;
        public string description;
        public string ammount;
        public string priceperitem;
        public string fat;
        public string price;
        public string discount;
        public string fatpercent;

        public ProductItemData()
        {
        }
    }

}
