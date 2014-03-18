namespace EasyAdmin
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInvoice = new System.Windows.Forms.TabPage();
            this.invoicePanel1 = new EasyAdmin.InvoicePanel();
            this.tabPageAFIS12 = new System.Windows.Forms.TabPage();
            this.createAFIS121 = new EasyAdmin.CreateAFIS12();
            this.tabPageCustomers = new System.Windows.Forms.TabPage();
            this.customersPanel = new EasyAdmin.CustomersPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.instellingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algemeenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailPanel1 = new EasyAdmin.SendEmailPanel();
            this.tabControl1.SuspendLayout();
            this.tabPageInvoice.SuspendLayout();
            this.tabPageAFIS12.SuspendLayout();
            this.tabPageCustomers.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInvoice);
            this.tabControl1.Controls.Add(this.tabPageAFIS12);
            this.tabControl1.Controls.Add(this.tabPageCustomers);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(991, 814);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInvoice
            // 
            this.tabPageInvoice.Controls.Add(this.invoicePanel1);
            this.tabPageInvoice.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvoice.Name = "tabPageInvoice";
            this.tabPageInvoice.Size = new System.Drawing.Size(983, 788);
            this.tabPageInvoice.TabIndex = 2;
            this.tabPageInvoice.Text = "Facturen";
            this.tabPageInvoice.UseVisualStyleBackColor = true;
            // 
            // invoicePanel1
            // 
            this.invoicePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoicePanel1.Location = new System.Drawing.Point(0, 0);
            this.invoicePanel1.Name = "invoicePanel1";
            this.invoicePanel1.Size = new System.Drawing.Size(983, 788);
            this.invoicePanel1.TabIndex = 0;
            // 
            // tabPageAFIS12
            // 
            this.tabPageAFIS12.Controls.Add(this.createAFIS121);
            this.tabPageAFIS12.Location = new System.Drawing.Point(4, 22);
            this.tabPageAFIS12.Name = "tabPageAFIS12";
            this.tabPageAFIS12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAFIS12.Size = new System.Drawing.Size(983, 788);
            this.tabPageAFIS12.TabIndex = 1;
            this.tabPageAFIS12.Text = "AFIS12";
            this.tabPageAFIS12.UseVisualStyleBackColor = true;
            // 
            // createAFIS121
            // 
            this.createAFIS121.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createAFIS121.Location = new System.Drawing.Point(3, 3);
            this.createAFIS121.Name = "createAFIS121";
            this.createAFIS121.Size = new System.Drawing.Size(977, 782);
            this.createAFIS121.TabIndex = 0;
            // 
            // tabPageCustomers
            // 
            this.tabPageCustomers.Controls.Add(this.customersPanel);
            this.tabPageCustomers.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustomers.Name = "tabPageCustomers";
            this.tabPageCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomers.Size = new System.Drawing.Size(983, 788);
            this.tabPageCustomers.TabIndex = 0;
            this.tabPageCustomers.Text = "Klanten";
            this.tabPageCustomers.UseVisualStyleBackColor = true;
            // 
            // customersPanel
            // 
            this.customersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersPanel.Location = new System.Drawing.Point(3, 3);
            this.customersPanel.Name = "customersPanel";
            this.customersPanel.Size = new System.Drawing.Size(977, 782);
            this.customersPanel.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.sendEmailPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(983, 788);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Verzonden mail";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instellingenToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // instellingenToolStripMenuItem
            // 
            this.instellingenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algemeenToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.instellingenToolStripMenuItem.Name = "instellingenToolStripMenuItem";
            this.instellingenToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.instellingenToolStripMenuItem.Text = "Instellingen";
            // 
            // algemeenToolStripMenuItem
            // 
            this.algemeenToolStripMenuItem.Name = "algemeenToolStripMenuItem";
            this.algemeenToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.algemeenToolStripMenuItem.Text = "Algemeen";
            this.algemeenToolStripMenuItem.Click += new System.EventHandler(this.algemeenToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseCheckToolStripMenuItem,
            this.importerenToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // databaseCheckToolStripMenuItem
            // 
            this.databaseCheckToolStripMenuItem.Name = "databaseCheckToolStripMenuItem";
            this.databaseCheckToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.databaseCheckToolStripMenuItem.Text = "Database check";
            this.databaseCheckToolStripMenuItem.Click += new System.EventHandler(this.databaseCheckToolStripMenuItem_Click);
            // 
            // importerenToolStripMenuItem
            // 
            this.importerenToolStripMenuItem.Name = "importerenToolStripMenuItem";
            this.importerenToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.importerenToolStripMenuItem.Text = "Importeren";
            this.importerenToolStripMenuItem.Click += new System.EventHandler(this.importerenToolStripMenuItem_Click_1);
            // 
            // sendEmailPanel1
            // 
            this.sendEmailPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendEmailPanel1.Location = new System.Drawing.Point(3, 3);
            this.sendEmailPanel1.Name = "sendEmailPanel1";
            this.sendEmailPanel1.Size = new System.Drawing.Size(977, 782);
            this.sendEmailPanel1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 838);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "EasyAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInvoice.ResumeLayout(false);
            this.tabPageAFIS12.ResumeLayout(false);
            this.tabPageCustomers.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCustomers;
        private System.Windows.Forms.TabPage tabPageAFIS12;
        private CreateAFIS12 createAFIS121;
        private CustomersPanel customersPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem instellingenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageInvoice;
        private InvoicePanel invoicePanel1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importerenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algemeenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseCheckToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private SendEmailPanel sendEmailPanel1;
    }
}

