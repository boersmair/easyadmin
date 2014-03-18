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
    public partial class FormMain : Form
    {
        private DataBaseClass db = new DataBaseClass(new DataBaseSettings());
       
        public FormMain()
        {
            List<string> propnames = new List<string>();
            propnames.Add("TemplateAFIS12");
            propnames.Add("TemplateInvoiceWord");
            propnames.Add("TemplateInvoiceWordReseller");
            propnames.Add("TemplateInvoiceWordDiscount");
            propnames.Add("SaveDirAFIS12");
            propnames.Add("SaveDirInvoice");
            propnames.Add("SaveDirInvoiceReseller");
            propnames.Add("TemplateHeader");
            propnames.Add("PDFOutputInvoice");
            propnames.Add("PDFOutputAFIS");
            for (int i = 0; i < propnames.Count; i++)
            {
                string v = (string)Properties.Settings.Default[propnames[i]];
                if(v.Length <= 0)
                {
                    Properties.Settings.Default[propnames[i]] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
            }
            InitializeComponent();
            InitDbSettings();
            DbUpdate(null);
            invoicePanel1.OnDBUpdated = DbUpdate;
            customersPanel.OnDBUpdated = DbUpdate;
            db.TestConnection();
        }

        private void InitDbSettings()
        {           
            db.Settings.databasetype = Properties.Settings.Default.DB_dbtype;
            //if (db.Settings.databasetype != DataBaseSettings.DB_MSSQL || db.Settings.databasetype != DataBaseSettings.DB_MYSQL)
                db.Settings.databasetype = DataBaseSettings.DB_MYSQL;
            db.Settings.port = (int)Properties.Settings.Default.DB_Port;
            db.Settings.password = Properties.Settings.Default.DB_Psw;
            db.Settings.username = Properties.Settings.Default.DB_Username;
            db.Settings.usewinauth = Properties.Settings.Default.DB_UseWinAuth;

            db.Settings.database = Properties.Settings.Default.DB_Database;

            db.Settings.customertable = Properties.Settings.Default.DBTbl_customers;
            db.Settings.ccvcardstable = Properties.Settings.Default.DBTbl_ccvcards;
            db.Settings.AFIS12table = Properties.Settings.Default.DBTbl_afis12;
            db.Settings.invoicetable = Properties.Settings.Default.DBTbl_invoices;
            db.Settings.producttable = Properties.Settings.Default.DBTbl_products;
            db.Settings.emailsend = Properties.Settings.Default.DBTbl_emailsend;
            db.Settings.emailattachm = Properties.Settings.Default.DBTbl_emailattch;
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseSettingsForm dbform = new DatabaseSettingsForm();
            if (dbform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitDbSettings();
                //db.UpdateSettings((DataBaseSettings)dbform.settings.Clone());
                DbUpdate(null);
            }
        }


        private void DbUpdate(object sender)
        {
            if (sender != customersPanel)
                customersPanel.UpdateDBSettings(db);
            if (sender != invoicePanel1)
                invoicePanel1.UpdateDBSettings(db);
            if (sender != createAFIS121)
                createAFIS121.UpdateDBSettings(db);
            if (sender != sendEmailPanel1)
                sendEmailPanel1.UpdateDBSettings(db);
        }

        private void importerenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataImportForm di = new DataImportForm(db);
            di.ShowDialog();
            DbUpdate(null);

        }

        private void algemeenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                invoicePanel1.UpdateInvoiceSettings();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // store window status
            if (this.WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default.MainFormWindowSize = this.Size;
                Properties.Settings.Default.MainFormWindowState = this.WindowState;
                Properties.Settings.Default.MainFormLocation = this.Location; //=-32000,-32000 when minimized!
            }
            Properties.Settings.Default.Save();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //restore window status
            if (Properties.Settings.Default.MainFormWindowState != FormWindowState.Minimized)
            {
                this.Size = Properties.Settings.Default.MainFormWindowSize;
                this.WindowState = Properties.Settings.Default.MainFormWindowState;
                this.Location = Properties.Settings.Default.MainFormLocation;
            }
        }

        private void databaseCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBRecoverForm dbrf = new DBRecoverForm(db);
            dbrf.ShowDialog();
        }
    }
}
