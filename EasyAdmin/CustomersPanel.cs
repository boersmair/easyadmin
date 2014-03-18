using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseData;

namespace EasyAdmin
{
    public partial class CustomersPanel : UserControl
    {
        private DataBaseClass db;
        private CustomerTableClass customers_dbtable;
        private CCVCardsTableClass ccvc_dbtable;
        private DataTable customers_datatable;
        private DataTable ccv_datatable;
        public DBUpdated OnDBUpdated;

        public CustomersPanel()
        {
            InitializeComponent();
            dataGridViewCustomers.RowValidated += new DataGridViewCellEventHandler(dataGridView_RowValidated);
            dataGridViewCustomers.UserDeletedRow += new DataGridViewRowEventHandler(dataGridView_UserDeletedRow);
            dataGridViewPasses.RowValidated += new DataGridViewCellEventHandler(dataGridView_RowValidated);
            dataGridViewPasses.UserDeletedRow += new DataGridViewRowEventHandler(dataGridView_UserDeletedRow);
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            cbLBColumns.Items.Clear();
            cbLBColumns.ItemCheck += cbLBColumns_ItemCheck;
            cbLBCardsColumns.Items.Clear();
            cbLBCardsColumns.ItemCheck += cbLBCardsColumns_ItemCheck;
        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            this.db = db;
            customers_dbtable = new CustomerTableClass(this.db);
            ccvc_dbtable = new CCVCardsTableClass(this.db);
            //ReloadTables();
        }

        public void ReloadTables(int updatetables=3)
        {
            if (db.TestConnection(false))
            {
                if (updatetables == 1 || updatetables == 3)
                {
                    customers_datatable = customers_dbtable.GetAllData();
                    if (customers_datatable != null)
                    {
                        string filter = "";
                        if (cbCustomTypeFilter.SelectedIndex == 0)
                            filter = "";
                        else if (cbCustomTypeFilter.SelectedIndex == 1)
                            filter = String.Format("{0} < '1000000'", customers_dbtable.FieldNames[CustomerTableClass.NUMBER]);
                        else if (cbCustomTypeFilter.SelectedIndex == 2)
                            filter = String.Format("{0} >= '1000000'", customers_dbtable.FieldNames[CustomerTableClass.NUMBER]);
                        else if (cbCustomTypeFilter.SelectedIndex == 3)
                            filter = String.Format("{0} = 'true' OR {1} = 'true'", customers_dbtable.FieldNames[CustomerTableClass.EXPIRED], customers_dbtable.FieldNames[CustomerTableClass.BLOCKED]);
                        else if (cbCustomTypeFilter.SelectedIndex == 4)
                            filter = String.Format("{0} = 'true'", customers_dbtable.FieldNames[CustomerTableClass.EXPIRED]);
                        else if (cbCustomTypeFilter.SelectedIndex == 5)
                            filter = String.Format("{0} = 'true'", customers_dbtable.FieldNames[CustomerTableClass.BLOCKED]);
                        else if (cbCustomTypeFilter.SelectedIndex == 6)
                            filter = tbCustomCustomerFilter.Text;
                        dataGridViewCustomers.DataSource = customers_datatable.Select(filter).CopyToDataTable();
                        setRowNumber(dataGridViewCustomers);
                        if (cbLBColumns.Items.Count <= 0) // create listbox list with checkboxes 
                        {
                            cbLBColumns.Items.Clear();
                            for (int i = 0; i < dataGridViewCustomers.ColumnCount; i++)
                            {
                                cbLBColumns.Items.Add(dataGridViewCustomers.Columns[i].Name);
                                cbLBColumns.SetItemChecked(i, true);
                            }
                        }
                        if (cbAutoColumnHide.Checked) //hide columns
                        {
                            bool hide;
                            for (int i = 0; i < dataGridViewCustomers.ColumnCount; i++)
                            {
                                if (cbCustomTypeFilter.SelectedIndex == 2) // non ccv customers
                                {
                                    hide = i == CustomerTableClass.ADDRESSEXTRA ||
                                           i == CustomerTableClass.FIRSTNAME ||
                                           i == CustomerTableClass.ATTN1 ||
                                           i == CustomerTableClass.BLOCKED ||
                                           i == CustomerTableClass.DATELASTUPDATE ||
                                           i == CustomerTableClass.CCVCATEGORY ||
                                           i == CustomerTableClass.DATACCVDIRECTDEBIT ||
                                           i == CustomerTableClass.DATEEXPIRED ||
                                           i == CustomerTableClass.DISCONTDIESEL ||
                                           i == CustomerTableClass.DISCOUNT95 ||
                                           i == CustomerTableClass.DISCOUNT98 ||
                                           i == CustomerTableClass.INVOICEPERIOD;
                                }
                                else if (cbCustomTypeFilter.SelectedIndex > 0 && cbCustomTypeFilter.SelectedIndex < 6)
                                {
                                    hide = i == CustomerTableClass.ADDRESSEXTRA ||
                                           i == CustomerTableClass.FIRSTNAME ||
                                           i == CustomerTableClass.FATNO ||
                                           i == CustomerTableClass.ATTN1 ||
                                           i == CustomerTableClass.ATTN2 ||
                                        //i==CustomerTableClass.RESELLER ||
                                           i == CustomerTableClass.TITLE ||
                                           i == CustomerTableClass.DATACCVDIRECTDEBIT ||
                                           i == CustomerTableClass.SAVEFOLDER ||
                                           i == CustomerTableClass.DATELASTUPDATE;
                                }
                                else
                                    hide = false;

                                cbLBColumns.SetItemChecked(i, !hide);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Er iets fout gegaan:\n" + customers_dbtable.LastMessage);
                    }
                }
                if (updatetables == 2 || updatetables == 3)
                {
                    ccv_datatable = ccvc_dbtable.GetAllData();
                    if (ccv_datatable != null)
                    {
                        string filter = "";
                        if (cbCardsFilter.SelectedIndex == 0)
                            filter = "";
                        else if (cbCardsFilter.SelectedIndex == 1)
                            filter = String.Format("{0} = 'true' OR {1} = 'true'", ccvc_dbtable.FieldNames[CCVCardsTableClass.EXPIRED], ccvc_dbtable.FieldNames[CCVCardsTableClass.BLOCKED]);
                        else if (cbCardsFilter.SelectedIndex == 2)
                            filter = String.Format("{0} = 'true'", ccvc_dbtable.FieldNames[CCVCardsTableClass.EXPIRED]);
                        else if (cbCardsFilter.SelectedIndex == 3)
                            filter = String.Format("{0} = 'true'", ccvc_dbtable.FieldNames[CCVCardsTableClass.BLOCKED]);
                        else if (cbCardsFilter.SelectedIndex == 4)
                            filter = tbCardFilter.Text;
                        else if (cbCardsFilter.SelectedIndex == 5)
                            filter = String.Format("{0} like '{1:000}*'", ccvc_dbtable.FieldNames[CCVCardsTableClass.CUSTOMNUMBER], nUDCardCustomNo.Value);
                        dataGridViewPasses.DataSource = ccv_datatable.Select(filter).CopyToDataTable();
                        setRowNumber(dataGridViewPasses);
                        if (cbLBCardsColumns.Items.Count <= 0) // create listbox list with checkboxes 
                        {
                            cbLBCardsColumns.Items.Clear();
                            for (int i = 0; i < dataGridViewPasses.ColumnCount; i++)
                            {
                                cbLBCardsColumns.Items.Add(dataGridViewPasses.Columns[i].Name);
                                cbLBCardsColumns.SetItemChecked(i, true);
                            }
                        }
 
                    }
                    else
                    {
                        MessageBox.Show("Er iets fout gegaan:\n" + ccvc_dbtable.LastMessage);
                    }
                }
            }
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }

        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            CheckForChanges();
        }

        private void CheckForChanges()
        {
            DataTable changes1 = null;
            DataTable changes2 = null;

            if (dataGridViewCustomers.DataSource != null)
                changes1 = ((DataTable)dataGridViewCustomers.DataSource).GetChanges();

            if (dataGridViewPasses.DataSource != null)
                changes2 = ((DataTable)dataGridViewPasses.DataSource).GetChanges();

            if (changes1 != null || changes2 != null)
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
        }

        private void UpdateData(object sender, bool cancel = false)
        {
            if (sender == dataGridViewCustomers)
            {
                if (customers_datatable == null)
                    return;
                DataTable changes = ((DataTable)dataGridViewCustomers.DataSource).GetChanges();
                if (changes != null)
                {
                    if (!cancel)
                    {
                        Tools.FillDataTableNullValues(changes);
                        if (customers_dbtable.UpdateTable(changes))
                        {
                            ((DataTable)dataGridViewCustomers.DataSource).AcceptChanges();
                            return;
                        }
                    }
                    ((DataTable)dataGridViewCustomers.DataSource).RejectChanges();

                }
            }
            else
            {
                if (ccv_datatable == null)
                    return;
                DataTable changes = ((DataTable)dataGridViewPasses.DataSource).GetChanges();
                if (changes != null)
                {
                    if (!cancel)
                    {
                        Tools.FillDataTableNullValues(changes);
                        if (ccvc_dbtable.UpdateTable(changes))
                        {
                            ((DataTable)dataGridViewPasses.DataSource).AcceptChanges();
                            return;
                        }
                    }
                    ((DataTable)dataGridViewPasses.DataSource).RejectChanges();

                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadTables();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData(dataGridViewCustomers, false);
            UpdateData(dataGridViewPasses, false);
            ReloadTables();
            if (OnDBUpdated != null)
                OnDBUpdated(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateData(dataGridViewCustomers, true);
            UpdateData(dataGridViewPasses, true);
            ReloadTables();

        }

        private void btnToNumber_Click(object sender, EventArgs e)
        {
            tbDate.Text = String.Format("{0}", DataBaseTableClassBase.ConvertDateValue(dTPDate.Value));
        }

        private void btnToDate_Click(object sender, EventArgs e)
        {
            if (tbDate.Text.Length > 0)
            {
                try
                {
                    Int64 v = Convert.ToInt64(tbDate.Text);
                    dTPDate.Value = DataBaseTableClassBase.GetDate(v);
                }
                catch (Exception) { };
            }
        }

        private void cbCustomTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbCustomTypeFilter.SelectedIndex == 6)
            {
                if (!CustomFilter(tbCustomCustomerFilter.Text, customers_datatable))
                    return;
            }
            ReloadTables(1);
        }

        private void cbLBColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {             
            dataGridViewCustomers.Columns[e.Index].Visible = e.NewValue == CheckState.Checked;            
        }

        private void tbCustomCustomerFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbCustomTypeFilter.SelectedIndex == 6 && e.KeyCode == Keys.Enter)
            {
                if (CustomFilter(tbCustomCustomerFilter.Text, customers_datatable))
                    ReloadTables(1);
                e.SuppressKeyPress = true;
            }
        }

        private bool CustomFilter(string filter, DataTable table)
        {
            try
            {
                if (table != null)
                {
                    DataRow[] r = table.Select(filter);                    
                    if (r.Length <= 0)
                    {
                        MessageBox.Show("Geen resultaten!", "Filter");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout filter:\n" + ex.Message, "Filter");
                return false;
            }
            return true;
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void cbCardsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustomTypeFilter.SelectedIndex == 4)
            {
                if (!CustomFilter(tbCardFilter.Text, ccv_datatable))
                    return;
            }
            else if (cbCardsFilter.SelectedIndex == 5)
            {
                if (ccvc_dbtable != null)
                {
                    string filter = String.Format("{0} like '{1:000}*'", ccvc_dbtable.FieldNames[CCVCardsTableClass.CUSTOMNUMBER], nUDCardCustomNo.Value);
                    if (!CustomFilter(filter, ccv_datatable))
                        return;
                }

            }
            ReloadTables(2);

        }

        private void tbCardFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbCardsFilter.SelectedIndex == 4 && e.KeyCode == Keys.Enter)
            {
                if (CustomFilter(tbCardFilter.Text, ccv_datatable))
                    ReloadTables(2);
                e.SuppressKeyPress = true;
            }
        }

        private void nUDCardCustomNo_ValueChanged(object sender, EventArgs e)
        {
            if (cbCardsFilter.SelectedIndex == 5 && ccvc_dbtable != null)
            {
                string filter = String.Format("{0} like '{1:000}*'", ccvc_dbtable.FieldNames[CCVCardsTableClass.CUSTOMNUMBER], nUDCardCustomNo.Value);
                if (!CustomFilter(filter, ccv_datatable))
                    return;
                ReloadTables(2);
            }
        }

        private void cbLBCardsColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            dataGridViewPasses.Columns[e.Index].Visible = e.NewValue == CheckState.Checked;
        }


    }
}
