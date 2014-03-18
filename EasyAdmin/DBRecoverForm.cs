using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyAdmin
{
    public partial class DBRecoverForm : Form
    {
        private DataBaseClass db;
        private string repairdb = "";
        public DBRecoverForm(DataBaseClass db)
        {
            InitializeComponent();
            this.db = db;
            cbTables.Items.Clear();
            cbTables.Items.Add(db.Settings.customertable);
            cbTables.Items.Add(db.Settings.ccvcardstable);
            cbTables.Items.Add(db.Settings.producttable);
            cbTables.Items.Add(db.Settings.invoicetable);
            cbTables.SelectedIndex = 0;
            btnRepair.Enabled = false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            repairdb = "";
            string table = (string)cbTables.SelectedItem;
            if (table == db.Settings.customertable)
            {
                CheckTable(new CustomerTableClass(db));
            }
            else if(table == db.Settings.ccvcardstable)
            {
                CheckTable(new CCVCardsTableClass(db));
            }
            else if(table == db.Settings.producttable)
            {
                CheckTable(new ProductsTableClass(db));
            }
            else if (table == db.Settings.invoicetable)
            {
                //CheckTable(new ProductsTableClass(db));
            }
        }

        private void CheckTable(DataBaseTableClassBase dbtableclass)
        {
            DataTable dt = dbtableclass.GetAllData();
            if (dt == null)
            {
                MessageBox.Show("Tabel fout:\n" + dbtableclass.LastMessage);
            }
            else if (Tools.HasNull(dt))
            {
                int rows = dt.Rows.Count;
                int cols = dt.Columns.Count;
                DataTable ndt = dt.Clone();

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (dt.Rows[r][c] == DBNull.Value)
                        {
                            ndt.ImportRow(dt.Rows[r]);
                            break;
                        }
                    }
                }
                dataGridView1.DataSource = ndt;
                repairdb = db.Settings.customertable;
                btnRepair.Enabled = true;
            }
            else
            {
                MessageBox.Show("Geen NULL waarden gevonden");
            }

        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            if (repairdb == db.Settings.customertable)
            {
                RepairTable(new CustomerTableClass(db));
            }
            else if(repairdb == db.Settings.ccvcardstable)
            {
                RepairTable(new CCVCardsTableClass(db));
            }
            else if(repairdb == db.Settings.producttable)
            {
                RepairTable(new ProductsTableClass(db));
            }
            else if (repairdb == db.Settings.invoicetable)
            {
                ;// CheckTable(new ProductsTableClass(db));
            }
        }

        private void RepairTable(DataBaseTableClassBase dbtableclass)
        {
            DataTable dt = dbtableclass.GetAllData();
            Tools.FillDataTableNullValues(dt);
            dbtableclass.UpdateTable(dt);
        }


    }
}
