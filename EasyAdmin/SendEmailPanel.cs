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
    public partial class SendEmailPanel : UserControl
    {
        private DataBaseClass db;
        private SendEmailTableClass _sendemail_dbtable;
        private EmailAttachmTableClass _attachments_dbtable;
        private DataTable _sendemail_datatable;
        private DataTable _attachments_datatable;
        public DBUpdated OnDBUpdated;

        public SendEmailPanel()
        {
            InitializeComponent();
            dataGridViewSendEmail.RowValidated += new DataGridViewCellEventHandler(dataGridView_RowValidated);
            dataGridViewSendEmail.UserDeletedRow += new DataGridViewRowEventHandler(dataGridView_UserDeletedRow);
            dataGridViewAttachments.RowValidated += new DataGridViewCellEventHandler(dataGridView_RowValidated);
            dataGridViewAttachments.UserDeletedRow += new DataGridViewRowEventHandler(dataGridView_UserDeletedRow);
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadTables();
        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            this.db = db;
            _sendemail_dbtable = new SendEmailTableClass(this.db);
            _attachments_dbtable = new EmailAttachmTableClass(this.db);
            //ReloadTables();
        }


        public void ReloadTables()
        {
            if (db.TestConnection(false))
            {
                _sendemail_datatable = _sendemail_dbtable.GetAllData();
                if (_sendemail_datatable != null)
                {
                    dataGridViewSendEmail.DataSource = _sendemail_datatable;//.Select(filter).CopyToDataTable();
                    setRowNumber(dataGridViewSendEmail);


                }
                else
                {
                    MessageBox.Show("Er iets fout gegaan:\n" + _sendemail_dbtable.LastMessage);
                }

                _attachments_datatable = _attachments_dbtable.GetAllData();
                if (_attachments_datatable != null)
                {
                    dataGridViewAttachments.DataSource = _attachments_datatable;//.Select(filter).CopyToDataTable();
                    setRowNumber(dataGridViewAttachments);
                }
                else
                {
                    MessageBox.Show("Er iets fout gegaan:\n" + _attachments_dbtable.LastMessage);
                }
            }
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }


        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            CheckForChanges();
        }

        private void CheckForChanges()
        {
            DataTable changes1 = null;
            DataTable changes2 = null;

            if (dataGridViewSendEmail.DataSource != null)
                changes1 = ((DataTable)dataGridViewSendEmail.DataSource).GetChanges();

            if (dataGridViewAttachments.DataSource != null)
                changes2 = ((DataTable)dataGridViewAttachments.DataSource).GetChanges();

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
            if (sender == dataGridViewSendEmail)
            {
                if (_sendemail_datatable == null)
                    return;
                DataTable changes = ((DataTable)dataGridViewSendEmail.DataSource).GetChanges();
                if (changes != null)
                {
                    if (!cancel)
                    {
                        Tools.FillDataTableNullValues(changes);
                        if (_sendemail_dbtable.UpdateTable(changes))
                        {
                            ((DataTable)dataGridViewSendEmail.DataSource).AcceptChanges();
                            return;
                        }
                    }
                    ((DataTable)dataGridViewSendEmail.DataSource).RejectChanges();

                }
            }
            else
            {
                if (_attachments_datatable == null)
                    return;
                DataTable changes = ((DataTable)dataGridViewAttachments.DataSource).GetChanges();
                if (changes != null)
                {
                    if (!cancel)
                    {
                        Tools.FillDataTableNullValues(changes);
                        if (_attachments_dbtable.UpdateTable(changes))
                        {
                            ((DataTable)dataGridViewAttachments.DataSource).AcceptChanges();
                            return;
                        }
                    }
                    ((DataTable)dataGridViewAttachments.DataSource).RejectChanges();

                }
            }
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            UpdateData(dataGridViewSendEmail, false);
            UpdateData(dataGridViewAttachments, false);
            ReloadTables();
            if (OnDBUpdated != null)
                OnDBUpdated(this);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            UpdateData(dataGridViewSendEmail, true);
            UpdateData(dataGridViewAttachments, true);
            ReloadTables();
        }


    }
}
