namespace EasyAdmin
{
    partial class EmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailForm));
            this.panelButtons = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDCustomerID = new System.Windows.Forms.NumericUpDown();
            this.tbCustomerNo = new System.Windows.Forms.TextBox();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.cbSaveSendItems = new System.Windows.Forms.CheckBox();
            this.btnAddAttachm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.panelEmailAddr = new System.Windows.Forms.Panel();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmailBCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmailCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmailTo = new System.Windows.Forms.TextBox();
            this.panelAttachments = new System.Windows.Forms.Panel();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCustomerID)).BeginInit();
            this.panelEmailAddr.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.label7);
            this.panelButtons.Controls.Add(this.label6);
            this.panelButtons.Controls.Add(this.label5);
            this.panelButtons.Controls.Add(this.nUDCustomerID);
            this.panelButtons.Controls.Add(this.tbCustomerNo);
            this.panelButtons.Controls.Add(this.tbCustomerName);
            this.panelButtons.Controls.Add(this.cbSaveSendItems);
            this.panelButtons.Controls.Add(this.btnAddAttachm);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnSend);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 360);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(444, 72);
            this.panelButtons.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Klant ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Klant nr.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Naam:";
            // 
            // nUDCustomerID
            // 
            this.nUDCustomerID.Location = new System.Drawing.Point(343, 50);
            this.nUDCustomerID.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.nUDCustomerID.Minimum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            -2147483648});
            this.nUDCustomerID.Name = "nUDCustomerID";
            this.nUDCustomerID.Size = new System.Drawing.Size(98, 20);
            this.nUDCustomerID.TabIndex = 4;
            this.nUDCustomerID.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // tbCustomerNo
            // 
            this.tbCustomerNo.Location = new System.Drawing.Point(237, 50);
            this.tbCustomerNo.Name = "tbCustomerNo";
            this.tbCustomerNo.Size = new System.Drawing.Size(100, 20);
            this.tbCustomerNo.TabIndex = 3;
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Location = new System.Drawing.Point(131, 50);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(100, 20);
            this.tbCustomerName.TabIndex = 2;
            this.tbCustomerName.Text = "Onbekend";
            // 
            // cbSaveSendItems
            // 
            this.cbSaveSendItems.AutoSize = true;
            this.cbSaveSendItems.Checked = true;
            this.cbSaveSendItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveSendItems.Location = new System.Drawing.Point(136, 13);
            this.cbSaveSendItems.Name = "cbSaveSendItems";
            this.cbSaveSendItems.Size = new System.Drawing.Size(170, 17);
            this.cbSaveSendItems.TabIndex = 1;
            this.cbSaveSendItems.Text = "Voeg toe aan verzonden items";
            this.cbSaveSendItems.UseVisualStyleBackColor = true;
            this.cbSaveSendItems.CheckedChanged += new System.EventHandler(this.cbSaveSendItems_CheckedChanged);
            // 
            // btnAddAttachm
            // 
            this.btnAddAttachm.Location = new System.Drawing.Point(12, 10);
            this.btnAddAttachm.Name = "btnAddAttachm";
            this.btnAddAttachm.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttachm.TabIndex = 0;
            this.btnAddAttachm.Text = "+Bijlage";
            this.btnAddAttachm.UseVisualStyleBackColor = true;
            this.btnAddAttachm.Click += new System.EventHandler(this.btnAddAttachm_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Sluiten";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(361, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Verzenden";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panelEmailAddr
            // 
            this.panelEmailAddr.Controls.Add(this.tbSubject);
            this.panelEmailAddr.Controls.Add(this.label4);
            this.panelEmailAddr.Controls.Add(this.label3);
            this.panelEmailAddr.Controls.Add(this.tbEmailBCC);
            this.panelEmailAddr.Controls.Add(this.label2);
            this.panelEmailAddr.Controls.Add(this.tbEmailCC);
            this.panelEmailAddr.Controls.Add(this.label1);
            this.panelEmailAddr.Controls.Add(this.tbEmailTo);
            this.panelEmailAddr.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmailAddr.Location = new System.Drawing.Point(0, 0);
            this.panelEmailAddr.Name = "panelEmailAddr";
            this.panelEmailAddr.Size = new System.Drawing.Size(444, 104);
            this.panelEmailAddr.TabIndex = 0;
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(70, 78);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(366, 20);
            this.tbSubject.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Onderwerp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "BCC:";
            // 
            // tbEmailBCC
            // 
            this.tbEmailBCC.Location = new System.Drawing.Point(70, 55);
            this.tbEmailBCC.Name = "tbEmailBCC";
            this.tbEmailBCC.Size = new System.Drawing.Size(366, 20);
            this.tbEmailBCC.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CC:";
            // 
            // tbEmailCC
            // 
            this.tbEmailCC.Location = new System.Drawing.Point(70, 29);
            this.tbEmailCC.Name = "tbEmailCC";
            this.tbEmailCC.Size = new System.Drawing.Size(366, 20);
            this.tbEmailCC.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naar:";
            // 
            // tbEmailTo
            // 
            this.tbEmailTo.Location = new System.Drawing.Point(70, 3);
            this.tbEmailTo.Name = "tbEmailTo";
            this.tbEmailTo.Size = new System.Drawing.Size(366, 20);
            this.tbEmailTo.TabIndex = 0;
            // 
            // panelAttachments
            // 
            this.panelAttachments.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttachments.Location = new System.Drawing.Point(0, 104);
            this.panelAttachments.Name = "panelAttachments";
            this.panelAttachments.Size = new System.Drawing.Size(444, 25);
            this.panelAttachments.TabIndex = 1;
            this.panelAttachments.Visible = false;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.Location = new System.Drawing.Point(0, 129);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(444, 231);
            this.tbMessage.TabIndex = 2;
            this.tbMessage.Text = resources.GetString("tbMessage.Text");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "pdf";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PDF documenten|*.pdf|Alle bestanden|*.*";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verwijderenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            // 
            // verwijderenToolStripMenuItem
            // 
            this.verwijderenToolStripMenuItem.Name = "verwijderenToolStripMenuItem";
            this.verwijderenToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(444, 432);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.panelAttachments);
            this.Controls.Add(this.panelEmailAddr);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(460, 300);
            this.Name = "EmailForm";
            this.Text = "EmailForm";
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCustomerID)).EndInit();
            this.panelEmailAddr.ResumeLayout(false);
            this.panelEmailAddr.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panelEmailAddr;
        private System.Windows.Forms.TextBox tbEmailTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEmailBCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEmailCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAttachments;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Button btnAddAttachm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verwijderenToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbSaveSendItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDCustomerID;
        private System.Windows.Forms.TextBox tbCustomerNo;
        private System.Windows.Forms.TextBox tbCustomerName;
    }
}