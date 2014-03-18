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
    public partial class InvoiceBodyPanel : UserControl
    {
        private double[] fat_data_percent = { 21.0, 6.0, 0.0 };
        private DataBaseClass db;
        private bool discountused = false;
        public delegate decimal GetDiscountRequest();
        public GetDiscountRequest OnGetDiscountRequest;
   
        public InvoiceBodyPanel()
        {
            InitializeComponent();
            for (int i = 0; i < 25; i++)
                OnAddNewProductItem();
            UpdateInvoiceSettings();
            for (int i = 0; i < panelProducts.Controls.Count; i++)
            {
                ((InvoiceProductItem)panelProducts.Controls[i]).OnPriceUpdate = OnPriceUpdate;
                ((InvoiceProductItem)panelProducts.Controls[i]).OnGo2NextProductLine = OnGo2NextProductLine;
                ((InvoiceProductItem)panelProducts.Controls[i]).OnGetDiscount = OnDiscountValueRequest;
            }           
        }

        public void UpdateInvoiceSettings()
        {
            fat_data_percent[0] = (double)Properties.Settings.Default.FATHigh;
            fat_data_percent[1] = (double)Properties.Settings.Default.FATLow;
            labelFAT1.Text = String.Format("BTW ({0:0.0}%)", fat_data_percent[1]);
            labelFAT2.Text = String.Format("BTW ({0:0.0}%)", fat_data_percent[0]);
            for (int i = 0; i < panelProducts.Controls.Count; i++)
            {
                ((InvoiceProductItem)panelProducts.Controls[i]).SetBTWValues(fat_data_percent);
                ((InvoiceProductItem)panelProducts.Controls[i]).UpdateInvoiceSettings();  
            }
        }

        public void ClearAllFields()
        {
            for (int i = 0; i < panelProducts.Controls.Count; i++)
            {
                ((InvoiceProductItem)panelProducts.Controls[i]).ClearFields();
            }
            
            rtbRemarks.Text = "";
        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            this.db = db;
            bool dbconok;
            int con=0;
            for (int i = 0; i < panelProducts.Controls.Count; i++)
            {
                dbconok = ((InvoiceProductItem)panelProducts.Controls[i]).UpdateDBSettings(db, con);
                con = dbconok ? 1 : 2;

            }
        }

        private decimal OnDiscountValueRequest()
        {
            if (OnGetDiscountRequest != null)
                return OnGetDiscountRequest();
            else
                return 0;
        }

        private void OnGo2NextProductLine(object sender)
        {
            for (int i = 0; i < panelProducts.Controls.Count-1; i++)
            {
                if (sender == panelProducts.Controls[i])
                {
                    ((InvoiceProductItem)panelProducts.Controls[i+1]).SetFocusDescription();
                    break;
                }
            }
        }

        private void OnAddNewProductItem()
        {
            InvoiceProductItem pi = new InvoiceProductItem();
            //pi.UpdateDBSettings(db);
            //pi.SetBTWValues(fat_data_percent);
            //pi.OnAddNewProductItem = OnAddNewProductItem;
            //pi.OnPriceUpdate = OnPriceUpdate;
            int y = panelProducts.Controls.Count * pi.Height;
            pi.SetNo(panelProducts.Controls.Count + 1);
            pi.Location = new System.Drawing.Point(pi.Location.X, y);
            panelProducts.Controls.Add(pi);
        }

        private void OnPriceUpdate()
        {
            decimal total = 0, fat1=0, fat2=0;

            discountused = false;

            for (int i = 0; i < panelProducts.Controls.Count; i++)
            {
                total += ((InvoiceProductItem)panelProducts.Controls[i]).TotalPrice;
                if (((InvoiceProductItem)panelProducts.Controls[i]).Fatidx == 0) //fat high
                    fat2 += ((InvoiceProductItem)panelProducts.Controls[i]).TotalFat;
                else if(((InvoiceProductItem)panelProducts.Controls[i]).Fatidx == 1) //fat low
                    fat1 += ((InvoiceProductItem)panelProducts.Controls[i]).TotalFat;
                if (((InvoiceProductItem)panelProducts.Controls[i]).DiscountPercent > 0.0m)
                    discountused = true;

            }

            nUDTotal.Value = total;
            nUDFAT1.Value = fat1;
            nUDFAT2.Value = fat2;
            nUDSubTotal.Value = nUDTotal.Value - nUDFAT1.Value - nUDFAT2.Value;
        }

        public List<ProductItemData> ItemsList
        {
            get
            {
                List<ProductItemData> data = new List<ProductItemData>();
                for (int i = 0; i < panelProducts.Controls.Count; i++)
                {
                    data.Add(((InvoiceProductItem)panelProducts.Controls[i]).GetProductData());
                }
                return data;
            }
        }

        public void UpdateProductsDatabase()
        {
            for (int i = 0; i < panelProducts.Controls.Count; i++)
            {
               ((InvoiceProductItem)panelProducts.Controls[i]).UpdateProductDB();
            }
        }

        public string[] ExtaTextLines
        {
            get
            {
                return rtbRemarks.Lines;
            }
        }

        public string RtfText
        {
            get
            {
                return rtbRemarks.Rtf;
            }
        }

        public decimal TotalPrice
        {
            get { return nUDTotal.Value; }
        }

        public decimal SubTotalPrice
        {
            get { return nUDSubTotal.Value; }
        }

        public decimal FatHigh
        {
            get { return nUDFAT2.Value; }
        }

        public decimal FatLow
        {
            get { return nUDFAT1.Value; }
        }

        public bool DiscountUsed
        {
            get { return discountused; }
        }

        private void vetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbRemarks.SelectionFont = new Font(rtbRemarks.Font, FontStyle.Bold);
        }

        private void roodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbRemarks.SelectionColor = Color.Red;
        }


    }
}
