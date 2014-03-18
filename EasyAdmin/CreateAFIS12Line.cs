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
    public delegate void OnClickHandler(CreateAFIS12Line item);
 
    public partial class CreateAFIS12Line : UserControl
    {
        /// <summary>
        /// Local class for product prices
        /// </summary>
        class ProductPrice
        {
            private DateTime _date;
            private string _price;
            public ProductPrice (DateTime date, string price)
            {
                Update(date, price);
            }

            public void Update(DateTime date, string price)
            {
                _date = date;
                _price = price;
            }

            public DateTime Date
            {
                get
                {
                    return _date;
                }
            }
            public long DateTicks
            {
                get{
                    return _date.Ticks;
                }
            }
            public string Price
            {
                get
                {
                    return _price;
                }
            }
        }

        public OnClickHandler OnDeleteItemClick;
        public OnClickHandler OnOrderChange;
        public delegate void TotalPriceValidated();
        public TotalPriceValidated OnTotalPriceValidated;
        private bool DisableOrderChange = false;
        private int oldorder;
        private List<ProductPrice> _pricediesel = new List<ProductPrice>();
        private List<ProductPrice> _price95 = new List<ProductPrice>();
        private List<ProductPrice> _price98 = new List<ProductPrice>();

        public CreateAFIS12Line()
        {
            InitializeComponent();
            oldorder = (int)nupOrder.Value; //keep track of order value before order changed

            tbACCustomName.KeyDown += new KeyEventHandler(this.tbKeyDown);
            tbDate.KeyDown += new KeyEventHandler(this.tbKeyDown);
            tbProductCode.KeyDown += new KeyEventHandler(this.tbKeyDown);
            tbPrice.KeyDown += new KeyEventHandler(this.tbKeyDown);
            tbAmount.KeyDown += new KeyEventHandler(this.tbKeyDown);
            tbTotal.KeyDown += new KeyEventHandler(this.tbKeyDown);

            tbDate.KeyUp += new KeyEventHandler(this.tbKeyUp);
            tbProductCode.KeyUp += new KeyEventHandler(this.tbKeyUp);
            //tbPrice.KeyUp += new KeyEventHandler(this.tbKeyUp);

            //tbDate.Validated += new EventHandler(this.tb_Validated);
            tbProductCode.Validated += new EventHandler(this.tb_Validated);
            tbPrice.Validated += new EventHandler(this.tb_Validated);
            tbAmount.Validated += new EventHandler(this.tb_Validated);
            tbTotal.Validated += new EventHandler(this.tb_Validated);

            string[] pcodes = {"01", "04", "06", "21", "36", "37", "38"};
            tbProductCode.AutoCompleteCustomSource.AddRange(pcodes);
            tbProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        public TextBox TBCardNo
        {
            get { return tbPassNumber; }
        }

        public AutoCompleteTextBox TBName
        {
            get { return tbACCustomName; }
        }

        public void ClearAllFields()
        {
            //tbACCustomName.Text = "";
            //tbPassNumber.Text = "";
            tbDate.Text = "";
            tbDate.BackColor = SystemColors.Window;
            tbProductCode.Text = "";
            tbProductCode.BackColor = SystemColors.Window;
            tbPrice.Text = "";
            tbAmount.Text = "";
            tbTotal.Text = "";
            tbACCustomName.Focus();
        }

        public void GetProperties(CreateAFIS12Line target)
        {
            target.tbDate.Text = tbDate.Text;
            target.tbDate.BackColor = tbDate.BackColor;
            target.tbPassNumber.Text = tbPassNumber.Text;
            target.tbACCustomName.Text = tbACCustomName.Text;
            target.nupTicketNo.Value = nupTicketNo.Value;
            target.tbProductCode.Text = tbProductCode.Text;
            target.tbProductCode.BackColor = tbProductCode.BackColor;
            target.tbAmount.Text = tbAmount.Text;
            target.tbPrice.Text = tbPrice.Text;
            target.tbPrice.BackColor = tbPrice.BackColor;
            target.tbTotal.Text = tbTotal.Text;
        }

        public void GetData(AFIS12LineData data)
        {
            data.Date = tbDate.Text;
            data.Passnumber = tbPassNumber.Text;
            data.name = tbACCustomName.Text;
            data.TicketNumber = nupTicketNo.Value;
            data.ProductCode = tbProductCode.Text;
            GetNumber(tbAmount.Text, out data.AmountInt, out data.AmountDec);
            GetNumber(tbPrice.Text, out data.PriceInt, out data.PriceDec);
            GetNumber(tbTotal.Text, out data.TotalPriceInt, out data.TotalPriceDec);
        }

        /// <summary>
        /// Convert string to number, split in an integer part and a decimal part. 
        /// A thousand separator is not supported. Supported decimals separators are . and ,
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="intv"></param>
        /// <param name="decv"></param>
        private void GetNumber(string txt, out string intv, out string decv)
        {
            intv = "";
            decv = "";
            if (txt.Length <= 0)
                return;
            if (txt.Contains("."))
            {
                string[] v = txt.Split('.');
                intv = v[0];
                decv = v[1];
            }
            else if (txt.Contains(","))
            {
                string[] v = txt.Split(',');
                intv = v[0];
                decv = v[1];
            }
            else
            {
                intv = txt;
            }
            decv = decv.Length <= 0 ? "0" : decv;
            intv = intv.Length <= 0 ? "0" : intv;
        }

        /// <summary>
        /// Show delete item button
        /// </summary>
        public void SetDeleteButtonVisible()
        {
            btnDelete.Visible = true;
        }

        /// <summary>
        /// Show order control
        /// </summary>
        public void SetOrderVisible()
        {
            nupOrder.Visible = true;
        }
        /// <summary>
        /// Return current order value
        /// </summary>
        /// <returns></returns>
        public int GetOrder()
        {
            return (int)nupOrder.Value;
        }
        /// <summary>
        /// Get older value before order is changed
        /// </summary>
        /// <returns></returns>
        public int GetOldOrder()
        {
            return oldorder;
        }
        /// <summary>
        /// Update order by code
        /// </summary>
        /// <param name="order"></param>
        public void SetOrder(decimal order)
        {
            DisableOrderChange = true;
            nupOrder.Value = order;
            oldorder = (int)order;
            DisableOrderChange = false;
        }
        /// <summary>
        /// Update maximum order value
        /// </summary>
        /// <param name="maxorder"></param>
        public void SetMaxOrder(decimal maxorder)
        {
            nupOrder.Maximum = maxorder;
        }
        /// <summary>
        /// Inc. ticket number by one
        /// </summary>
        public void IncTicketNo()
        {
            nupTicketNo.Value++;
        }

        /// <summary>
        /// Validate event. Update the other events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Validated(object sender, EventArgs e)
        {
            double p,a,t;
            if (sender == tbProductCode)
            {
                if (tbDate.Text.Length == 4 && tbPrice.Text.Length <= 0 && tbProductCode.Text.Length == 2) //update price if not already filled in
                {
                    tbPrice.Text = GetProductPrice();
                }
            }
            else if (sender == tbPrice)
            {
                if (tbPrice.Text.Length > 0)
                {
                    p = StringToDouble(tbPrice.Text);
                    if (tbAmount.Text.Length > 0)
                    {
                        a = StringToDouble(tbAmount.Text);
                        tbTotal.Text = String.Format("{0:0.00}", a * p);
                    }
                    else if (tbTotal.Text.Length > 0)
                    {
                        t = StringToDouble(tbTotal.Text);
                        tbAmount.Text = String.Format("{0:0.00}", t * p);
                    }
                    UpdateProductPriceList();
                }
                tbPrice.BackColor = SystemColors.Window; //restore color in case of warning color
            }
            else if (sender == tbAmount)
            {
                if (tbAmount.Text.Length > 0)
                {
                    a = StringToDouble(tbAmount.Text);
                    if (tbPrice.Text.Length > 0)
                    {
                        p = StringToDouble(tbPrice.Text);
                        tbTotal.Text = String.Format("{0:0.00}", a * p);
                    }
                }
            }
            else if (sender == tbTotal)
            {
                if (tbTotal.Text.Length > 0)
                {
                    t = StringToDouble(tbTotal.Text);
                    if (tbPrice.Text.Length > 0)
                    {
                        p = StringToDouble(tbPrice.Text);
                        if(p>0)
                            tbAmount.Text = String.Format("{0:0.00}", t / p);
                    }
                }
                if (OnTotalPriceValidated != null)
                    OnTotalPriceValidated();
            }

        }

        /// <summary>
        /// Read date from date input field and return DataTime format
        /// </summary>
        /// <returns></returns>
        private DateTime GetDateFromFields()
        {
            DateTime dt = DateTime.MaxValue;
            try
            {
                dt = new DateTime(DateTime.Now.Year, StringToInt(tbDate.Text.Substring(2, 2)), StringToInt(tbDate.Text.Substring(0, 2)));
            }
            catch (Exception) {  }
            return dt;
        }

        /// <summary>
        /// Get price for product if available
        /// </summary>
        /// <returns></returns>
        private string GetProductPrice()
        {
            string price = "";
            if (tbProductCode.Text == "06") //diesel
            {
                price = FindProductPrice(_pricediesel);
            }
            else if (tbProductCode.Text == "04") //euro
            {
                price = FindProductPrice(_price95);
            }
            else if (tbProductCode.Text == "01") //98
            {
                price = FindProductPrice(_price98);
            }
            return price;
        }

        /// <summary>
        /// Find closest match for price
        /// </summary>
        /// <param name="pricelist"></param>
        /// <returns></returns>
        private string FindProductPrice(List<ProductPrice> pricelist)
        {
            string price = pricelist.Count > 0 ? pricelist[0].Price : ""; //init with first if available
            long pricedateticks = pricelist.Count > 0 ? pricelist[0].DateTicks : 0;
            DateTime dt = GetDateFromFields();
            if (dt == DateTime.MaxValue)
                return price;
            for (int i = 1; i < pricelist.Count; i++)
            {
                if (dt.Ticks >= pricelist[i].DateTicks && (dt.Ticks - pricelist[i].DateTicks < dt.Ticks - pricedateticks || pricedateticks > dt.Ticks) )
                {
                    price = pricelist[i].Price;
                    pricedateticks = pricelist[i].DateTicks;
                }
            }
            if (price.Length > 0 && pricedateticks > dt.Ticks) //date before requested data, warning color
            {
                tbPrice.BackColor = Color.Orange;
            }

            return price;                
        }

        /// <summary>
        /// Add price to pricelist
        /// </summary>
        private void UpdateProductPriceList()
        {
            if (tbDate.Text.Length == 4 && tbProductCode.Text.Length == 2 && tbPrice.Text.Length > 0)
            {
                if (tbProductCode.Text == "06") //diesel
                {
                    AddProductPrice(_pricediesel);
                }
                else if (tbProductCode.Text == "04") //euro
                {
                    AddProductPrice(_price95);
                }
                else if (tbProductCode.Text == "01") //98
                {
                    AddProductPrice(_price98);
                }
            }
        }

        /// <summary>
        /// Add an price to the pricelist if not already present in list
        /// </summary>
        /// <param name="pricelist"></param>
        private void AddProductPrice(List<ProductPrice> pricelist)
        {
            DateTime dt = GetDateFromFields();
            if (dt == DateTime.MaxValue)
                return;
            bool present = false;
            for (int i = 0; i < pricelist.Count; i++)
            {
                if (pricelist[i].DateTicks == dt.Ticks) //update 
                {
                    pricelist[i].Update(dt, tbPrice.Text);
                    present = true;
                    break;
                }
            }
            if (!present)
                pricelist.Add(new ProductPrice(dt, tbPrice.Text));
        }


        /// <summary>
        /// Convert string to a double value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double StringToDouble(string value)
        {
            double v = 0;
            if (value.Length <= 0)
                return v;

            value = value.Replace(",", ".");
            try
            {
                v = double.Parse(value, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
            }
            catch (Exception)
            {
            }
            return v;
        }

        private void tbKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == tbACCustomName)
                    tbDate.Focus();
                else
                    SendKeys.Send("{TAB}");
                //e.Handled = true;
                e.SuppressKeyPress = true; //surpress sound
            }

            //else
             //   ReplaceCtrlKeys(e);
        }

        private void tbKeyUp(object sender, KeyEventArgs e)
        {
            if (sender == tbDate) //check date
            {
                if (tbDate.Text.Length <= 0) tbDate.BackColor = System.Drawing.SystemColors.Window;
                else
                {
                    if (tbDate.Text.Length == 4)
                    {
                        int day = StringToInt(tbDate.Text.Substring(0, 2));
                        int month = StringToInt(tbDate.Text.Substring(2, 2));
                        try
                        {
                            DateTime dt = new DateTime(DateTime.Now.Year, month, day);
                            tbDate.BackColor = dt.Ticks > DateTime.Now.Ticks ? Color.Red : System.Drawing.SystemColors.Window;
                        }
                        catch (Exception) { tbDate.BackColor = Color.Red; }
                        
                    }
                    else
                    {
                        tbDate.BackColor = Color.Red;
                    }
                }
            }
            else if (sender == tbProductCode)
            {
                if (tbProductCode.Text.Length <= 0) tbProductCode.BackColor = System.Drawing.SystemColors.Window;
                else
                {
                    if (tbProductCode.Text.Length == 2)
                    {
                        tbProductCode.BackColor = tbProductCode.AutoCompleteCustomSource.Contains(tbProductCode.Text) ? System.Drawing.SystemColors.Window : Color.Red;
                    }
                    else
                    {
                        tbProductCode.BackColor = Color.Red;
                    }
                }
            }
        }

        private int StringToInt(string value)
        {
            int v = 0;
            try
            {
                v = Convert.ToInt32(value);
            }
            catch (Exception) { ;}
            return v;
        }

        /*
        /// <summary>
        /// replace arrow key by tab
        /// </summary>
        /// <param name="e"></param>
        private void ReplaceCtrlKeys(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            //else if(e.KeyCode == Keys.Left)
            //    SendKeys.Send("+{TAB}");
        }*/

        /// <summary>
        /// Delete this item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnDeleteItemClick != null)
            {
                if (MessageBox.Show("Zeker weten?", System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)                            
                    OnDeleteItemClick(this);
            }
        }

        /// <summary>
        /// Change order of this item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nupOrder_ValueChanged(object sender, EventArgs e)
        {
            if (!DisableOrderChange && OnOrderChange != null)
                OnOrderChange(this);
            oldorder = (int)nupOrder.Value;
        }

    }

    /// <summary>
    /// Class containing the data for a ticket
    /// </summary>
    public class AFIS12LineData
    {
        public string Date;
        public string Passnumber;
        public string name;
        public decimal TicketNumber;
        public string ProductCode;
        public string AmountInt;
        public string AmountDec;
        public string PriceInt;
        public string PriceDec;
        public string TotalPriceInt;
        public string TotalPriceDec;
    }

}
