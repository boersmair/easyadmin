using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;

namespace EasyAdmin
{
    public partial class EmailForm : Form
    {
        public enum Emailtype
        {
            unknown = 0,
            afis12 = 1,
            invoice = 2
        }
        private Emailtype _emailtype = Emailtype.unknown;
        private SendEmailTableClass _sendemail_datatable;

        public EmailForm(DataBaseClass db)
        {
            InitializeComponent();
            _sendemail_datatable = new SendEmailTableClass(db);
        }

        /// <summary>
        /// Database settings updated. Update ref to database.
        /// </summary>
        /// <param name="db"></param>
        public void UpdateDBSettings(DataBaseClass db)
        {
            _sendemail_datatable = new SendEmailTableClass(db);
        }


        public void AddAttachment(string filename)
        {
            panelAttachments.Show();
            AttachmentLabel attachm = new AttachmentLabel();
            if (panelAttachments.Controls.Count > 0)
            {
                int x = panelAttachments.Controls[panelAttachments.Controls.Count - 1].Location.X + panelAttachments.Controls[panelAttachments.Controls.Count - 1].Size.Width;
                attachm.Location = new System.Drawing.Point(x, panelAttachments.Controls[panelAttachments.Controls.Count - 1].Location.Y);
            }
            attachm.FileName = filename;
            attachm.OnDeletePressed = DeleteAttachement;
            panelAttachments.Controls.Add(attachm);

        }

        public void SetSubject(string subject)
        {
            tbSubject.Text = subject;
        }
        public void SetBodyPlainText(string text)
        {
            tbMessage.Text = text;
        }

        public void SetEmailAddress(string[] To, string[] CC, string[] BCC)
        {
            SetEmail(tbEmailTo, To);
            SetEmail(tbEmailCC, CC);
            SetEmail(tbEmailBCC, BCC);
        }

        public void SetCustomerInfo(string name, String no = "", int id = -1)
        {
            tbCustomerName.Text = name.Length>0?name:"Onbekend";
            tbCustomerNo.Text = no;
            nUDCustomerID.Value = no.Length>0?id:-1;
        }

        public void SetEmailType(Emailtype type)
        {
            _emailtype = type;
        }

        private void SetEmail(TextBox tb, string[] addr)
        {
            tb.Text = "";
            if (addr != null)
            {
                for (int i = 0; i < addr.Length; i++)
                {
                    if (addr[i].Length <= 0 || !addr[i].Contains("@"))
                        continue;
                    tb.Text += addr[i];
                    if (i < addr.Length - 1)
                        tb.Text += ";";
                }
            }
        }

        private void RemoveAttachements()
        {
            panelAttachments.Controls.Clear();
        }

        private void btnAddAttachm_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddAttachment(openFileDialog1.FileName);
            }
        }

        private void DeleteAttachement(object sender)
        {
            for (int i = 0; i < panelAttachments.Controls.Count; i++)
            {
                if (panelAttachments.Controls[i] == sender)
                {
                    panelAttachments.Controls.Remove(panelAttachments.Controls[i]);
                    break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SetMailStatus(true);
            if(tbEmailTo.Text.Length<=0 || !tbEmailTo.Text.Contains("@"))
            {
                MessageBox.Show("Geen geaddresseerde ingevuld!");
                SetMailStatus(false);
                return;
            }
            if (panelAttachments.Controls.Count <= 0)
            {
                if (MessageBox.Show("Er zijn geen bijlagen.\nToch doorgaan?", "E-mail verzenden", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    SetMailStatus(false);
                    return;
                }
            }

            try
            {

                MailMessage message = new MailMessage();
                string[] addr = tbEmailTo.Text.Split(new char[] { ';' });
                for (int i = 0; i < addr.Length; i++)
                {
                    if (addr[i].Length > 0 && addr[i].Contains("@"))
                        message.To.Add(addr[i]);
                }
                if (tbEmailCC.Text.Length > 0 && tbEmailCC.Text.Contains("@"))
                {
                    addr = tbEmailCC.Text.Split(new char[] { ';' });
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (addr[i].Length > 0 && addr[i].Contains("@"))
                            message.CC.Add(addr[i]);
                    }
                }
                if (tbEmailBCC.Text.Length > 0 && tbEmailBCC.Text.Contains("@"))
                {
                    addr = tbEmailBCC.Text.Split(new char[] { ';' });
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (addr[i].Length > 0 && addr[i].Contains("@"))
                            message.Bcc.Add(addr[i]);
                    }
                }

                message.Subject = tbSubject.Text;
                message.Body = tbMessage.Text;
                for (int i = 0; i < panelAttachments.Controls.Count; i++)
                {
                    Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(((AttachmentLabel)panelAttachments.Controls[i]).FileName);
                    message.Attachments.Add(attachment);
                }
                /*
                #if DEBUG
                                message.From = new MailAddress("bitankbv@gmail.com");
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                smtp.Credentials = new System.Net.NetworkCredential("bitankbv@gmail.com", "bitank_bv");
                                smtp.EnableSsl = true;
                #else
                                message.From = new MailAddress("vandeputbv@online.nl");
                                SmtpClient smtp = new SmtpClient("smtp.online.nl", 25);
                #endif
                 */
                message.From = new MailAddress(Properties.Settings.Default.EmailFrom);
                SmtpClient smtp = new SmtpClient(Properties.Settings.Default.EmailSMTPServer, (int)Properties.Settings.Default.EmailSMTPPort);
                if (Properties.Settings.Default.EmailSMTPSSL)
                {
                    smtp.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.EmailSMTPUser, Properties.Settings.Default.EmailSMTPPassw);
                    smtp.EnableSsl = true;
                }

                smtp.Timeout = (int)Properties.Settings.Default.EmailTimeout;
                smtp.Send(message);
                MessageBox.Show("E-mail is verstuurd");
                if (cbSaveSendItems.Checked)
                {
                    if (AddToDbTable())
                        Close();
                }
                else
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout:\n" + ex.Message);
            }
            SetMailStatus(false);
        }

        private bool AddToDbTable()
        {
            if (_sendemail_datatable == null)
                return false;

            if (!_sendemail_datatable.TableExist())
            {
                if (!_sendemail_datatable.CreateTableFull())
                {
                    MessageBox.Show(String.Format("Kan de send e-email tabel niet maken:\n{0}", _sendemail_datatable.LastMessage));
                    return false;
                }
            }
 
            object[] data = new object[SendEmailTableClass.FIELD_COUNT];
            List<object[]> attm = new List<object[]>();

            data[SendEmailTableClass.CUSTOMERNAME] = tbCustomerName.Text;
            data[SendEmailTableClass.CUSTOMERNUMBER] = tbCustomerNo.Text;
            data[SendEmailTableClass.CUSTOMERTABLEID] = (int)nUDCustomerID.Value;
            data[SendEmailTableClass.MSTTYPE] = Emailtype.afis12;
            data[SendEmailTableClass.MSGTXT] = tbMessage.Text;
            data[SendEmailTableClass.ISHTML] = 0;
            data[SendEmailTableClass.SUBJECT] = tbSubject.Text;
            data[SendEmailTableClass.EMAILTO] = tbEmailTo.Text;
            data[SendEmailTableClass.EMAILFROM] = Properties.Settings.Default.EmailFrom;
            data[SendEmailTableClass.EMAILCC] = tbEmailCC.Text;
            data[SendEmailTableClass.EMAILBCC] = tbEmailBCC.Text;
            data[SendEmailTableClass.SENDDATE] = DataBaseTableClassBase.GetDateValue();

            for (int i = 0; i < panelAttachments.Controls.Count; i++)
            {
                object[] attachmdata = new object[EmailAttachmTableClass.FIELD_COUNT];
                attachmdata[EmailAttachmTableClass.ATTACHMFILELOC] = ((AttachmentLabel)panelAttachments.Controls[i]).FileName;
                attm.Add(attachmdata);
            }
            if (!_sendemail_datatable.AddRow(data, attm))
            {
                MessageBox.Show("Kan het bericht niet toevoegen aan de verzonden e-mail items");
                return false;
            }
            return true;
        }


        private void SetMailStatus(bool busy)
        {
            if (busy)
            {
                panelButtons.Enabled = false;

            }
            else
            {
                panelButtons.Enabled = true;

            }
        }

        private void cbSaveSendItems_CheckedChanged(object sender, EventArgs e)
        {
            tbCustomerName.Enabled = cbSaveSendItems.Checked;
            tbCustomerNo.Enabled = cbSaveSendItems.Checked;
            nUDCustomerID.Enabled = cbSaveSendItems.Checked;
        }
    }

   
    


    public class AttachmentLabel : TextBox
    {
        private string _filename;
        public delegate void DeletePressed(object sender);
        public DeletePressed OnDeletePressed;

        public AttachmentLabel()
        {
            BackColor = SystemColors.Control;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Cursor = Cursors.Arrow;
            ReadOnly = true;
            DoubleClick += this_DoubleClick;
            KeyDown += this_KeyDown;
            ForeColor = Color.Blue;
            Font = new Font(Font, FontStyle.Underline);
            
        }

        public string FileName
        {
            set
            {
                _filename = value;
                Text = Path.GetFileName(_filename);
                Size size = TextRenderer.MeasureText(Text, Font);
                Width = size.Width;
            }
            get
            {
                return _filename;
            }
        }

        private void this_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_filename);
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (OnDeletePressed != null)
                    OnDeletePressed(this);
            }
        }

    }
}
