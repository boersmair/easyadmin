using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseData;

namespace EasyAdmin
{
    public partial class DatabaseSettingsForm : Form
    {
        public DataBaseSettings settings = new DataBaseSettings();

        public DatabaseSettingsForm(DataBaseSettings dbsettings)
        {
            InitializeComponent();
            cbDatabaseType.Items.Clear();
            cbDatabaseType.Items.Add(DataBaseData.DataBaseSettings.DB_MYSQL);
            UpdateSettings(dbsettings);

         }

        public void UpdateSettings(DataBaseSettings dbsettings)
        {
            settings = (DataBaseSettings)settings.Clone();
            for (int i = 0; i < cbDatabaseType.Items.Count; i++)
            {
                cbDatabaseType.SelectedIndex = (string)cbDatabaseType.Items[i] == settings.databasetype ? i : cbDatabaseType.SelectedIndex;
            }
            tbServer.Text = settings.server;
            nudPort.Value = settings.port;
            tbDatabase.Text = settings.database;
            tbUsername.Text = settings.username;
            tbPassword.Text = settings.password;

            tbAFIS12TableName.Text = settings.AFIS12table;
            tbCCVcardTableName.Text = settings.ccvcardstable;
            tbCustomerTableName.Text = settings.customertable;
            tbInvoiceTableName.Text = settings.invoicetable;
            tbProductTableName.Text = settings.producttable;
            tbEmailSend.Text = settings.emailsend;
            tbEmailAttachm.Text = settings.emailattachm;

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            ReadSettings();
            DataBaseClass db = new DataBaseClass(settings);
            if (db.TestConnection())
            {
                MessageBox.Show("Connectie met database ok");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ReadSettings();
        }
        private void ReadSettings()
        {
            settings.databasetype = (string)cbDatabaseType.Items[cbDatabaseType.SelectedIndex];
            settings.server = tbServer.Text;
            settings.port = (int)nudPort.Value;
            settings.database = tbDatabase.Text;
            settings.username = tbUsername.Text;
            settings.password = tbPassword.Text;

            settings.AFIS12table = tbAFIS12TableName.Text;
            settings.ccvcardstable = tbCCVcardTableName.Text;
            settings.customertable = tbCustomerTableName.Text;
            settings.invoicetable = tbInvoiceTableName.Text;
            settings.producttable = tbProductTableName.Text;
            settings.emailsend = tbEmailSend.Text;
            settings.emailattachm = tbEmailAttachm.Text;
        }
    }
}
