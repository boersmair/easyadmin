namespace EasyAdmin
{
    partial class SettingsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbStoreFolderYear = new System.Windows.Forms.CheckBox();
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.tbInvoiceReseller = new System.Windows.Forms.TextBox();
            this.tbInvoiceDiscount = new System.Windows.Forms.TextBox();
            this.tbInvoice = new System.Windows.Forms.TextBox();
            this.tbAFIS12 = new System.Windows.Forms.TextBox();
            this.tbPDFOutputAFIS = new System.Windows.Forms.TextBox();
            this.tbPDFOutputInvoice = new System.Windows.Forms.TextBox();
            this.tbInvoiceResellerSave = new System.Windows.Forms.TextBox();
            this.tbInvoiceSave = new System.Windows.Forms.TextBox();
            this.tbAFIS12Save = new System.Windows.Forms.TextBox();
            this.tbEmailSMTPPassw = new System.Windows.Forms.TextBox();
            this.tbEmailCCV = new System.Windows.Forms.TextBox();
            this.tbEmailSMTPUser = new System.Windows.Forms.TextBox();
            this.cbEmailSSL = new System.Windows.Forms.CheckBox();
            this.nUDEmailSMTPPort = new System.Windows.Forms.NumericUpDown();
            this.tbEmailSMTPServer = new System.Windows.Forms.TextBox();
            this.tbEmailFrom = new System.Windows.Forms.TextBox();
            this.nUDEmailTimeout = new System.Windows.Forms.NumericUpDown();
            this.cbAmountRemove0s = new System.Windows.Forms.CheckBox();
            this.nUDInvoiceOffset = new System.Windows.Forms.NumericUpDown();
            this.nUDDecimals = new System.Windows.Forms.NumericUpDown();
            this.nUDFATHigh = new System.Windows.Forms.NumericUpDown();
            this.nUDFATLow = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEmailSMTPPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEmailTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInvoiceOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDecimals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFATHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFATLow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(442, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(361, 15);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "AFIS12:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Factuur:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(590, 159);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbInvoiceReseller);
            this.tabPage1.Controls.Add(this.tbInvoiceDiscount);
            this.tabPage1.Controls.Add(this.tbInvoice);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(582, 133);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Word";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Factuur doorlevering:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Factuur met korting:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(582, 133);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Excel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(617, 285);
            this.tabControl2.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbHeader);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Controls.Add(this.tbAFIS12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(609, 259);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Sjablonen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Briefhoofd:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbStoreFolderYear);
            this.tabPage4.Controls.Add(this.tbPDFOutputAFIS);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.tbPDFOutputInvoice);
            this.tabPage4.Controls.Add(this.tbInvoiceResellerSave);
            this.tabPage4.Controls.Add(this.tbInvoiceSave);
            this.tabPage4.Controls.Add(this.tbAFIS12Save);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(609, 259);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Oplag";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "PDF AFIS:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "PDF factuur:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Facturen doorverkoop:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Facturen:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "AFIS12:";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label23);
            this.tabPage6.Controls.Add(this.tbEmailSMTPPassw);
            this.tabPage6.Controls.Add(this.label22);
            this.tabPage6.Controls.Add(this.label21);
            this.tabPage6.Controls.Add(this.label20);
            this.tabPage6.Controls.Add(this.label19);
            this.tabPage6.Controls.Add(this.label18);
            this.tabPage6.Controls.Add(this.label17);
            this.tabPage6.Controls.Add(this.tbEmailCCV);
            this.tabPage6.Controls.Add(this.tbEmailSMTPUser);
            this.tabPage6.Controls.Add(this.cbEmailSSL);
            this.tabPage6.Controls.Add(this.nUDEmailSMTPPort);
            this.tabPage6.Controls.Add(this.tbEmailSMTPServer);
            this.tabPage6.Controls.Add(this.tbEmailFrom);
            this.tabPage6.Controls.Add(this.nUDEmailTimeout);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(609, 259);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Email";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(360, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 14;
            this.label23.Text = "E-mail CCV:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 201);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 13);
            this.label22.TabIndex = 11;
            this.label22.Text = "Wachtwoord:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 175);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "gebruiker:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "SMTP Poort:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "SMTP Server:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Van:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Timeout (ms):";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbAmountRemove0s);
            this.tabPage5.Controls.Add(this.nUDInvoiceOffset);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.nUDDecimals);
            this.tabPage5.Controls.Add(this.nUDFATHigh);
            this.tabPage5.Controls.Add(this.nUDFATLow);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(609, 259);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Overige";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(208, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Start nr factuur:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(208, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Decimalen aantal factuur:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(151, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "BTW hoog:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "BTW laag:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 50);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 285);
            this.panel2.TabIndex = 7;
            // 
            // cbStoreFolderYear
            // 
            this.cbStoreFolderYear.AutoSize = true;
            this.cbStoreFolderYear.Checked = global::EasyAdmin.Properties.Settings.Default.SaveDirYearSubFolder;
            this.cbStoreFolderYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStoreFolderYear.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EasyAdmin.Properties.Settings.Default, "SaveDirYearSubFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbStoreFolderYear.Location = new System.Drawing.Point(11, 211);
            this.cbStoreFolderYear.Name = "cbStoreFolderYear";
            this.cbStoreFolderYear.Size = new System.Drawing.Size(99, 17);
            this.cbStoreFolderYear.TabIndex = 10;
            this.cbStoreFolderYear.Text = "Folder voor jaar";
            this.cbStoreFolderYear.UseVisualStyleBackColor = true;
            // 
            // tbHeader
            // 
            this.tbHeader.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbHeader.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbHeader.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "TemplateHeader", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHeader.Location = new System.Drawing.Point(76, 49);
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(521, 20);
            this.tbHeader.TabIndex = 7;
            this.tbHeader.Text = global::EasyAdmin.Properties.Settings.Default.TemplateHeader;
            // 
            // tbInvoiceReseller
            // 
            this.tbInvoiceReseller.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbInvoiceReseller.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbInvoiceReseller.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "TemplateInvoiceWordReseller", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbInvoiceReseller.Location = new System.Drawing.Point(113, 84);
            this.tbInvoiceReseller.Name = "tbInvoiceReseller";
            this.tbInvoiceReseller.Size = new System.Drawing.Size(463, 20);
            this.tbInvoiceReseller.TabIndex = 9;
            this.tbInvoiceReseller.Text = global::EasyAdmin.Properties.Settings.Default.TemplateInvoiceWordReseller;
            // 
            // tbInvoiceDiscount
            // 
            this.tbInvoiceDiscount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbInvoiceDiscount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbInvoiceDiscount.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "TemplateInvoiceWordDiscount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbInvoiceDiscount.Location = new System.Drawing.Point(113, 47);
            this.tbInvoiceDiscount.Name = "tbInvoiceDiscount";
            this.tbInvoiceDiscount.Size = new System.Drawing.Size(463, 20);
            this.tbInvoiceDiscount.TabIndex = 8;
            this.tbInvoiceDiscount.Text = global::EasyAdmin.Properties.Settings.Default.TemplateInvoiceWordDiscount;
            // 
            // tbInvoice
            // 
            this.tbInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbInvoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "TemplateInvoiceWord", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbInvoice.Location = new System.Drawing.Point(115, 9);
            this.tbInvoice.Name = "tbInvoice";
            this.tbInvoice.Size = new System.Drawing.Size(461, 20);
            this.tbInvoice.TabIndex = 7;
            this.tbInvoice.Text = global::EasyAdmin.Properties.Settings.Default.TemplateInvoiceWord;
            // 
            // tbAFIS12
            // 
            this.tbAFIS12.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbAFIS12.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbAFIS12.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "TemplateAFIS12", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAFIS12.Location = new System.Drawing.Point(76, 18);
            this.tbAFIS12.Name = "tbAFIS12";
            this.tbAFIS12.Size = new System.Drawing.Size(521, 20);
            this.tbAFIS12.TabIndex = 2;
            this.tbAFIS12.Text = global::EasyAdmin.Properties.Settings.Default.TemplateAFIS12;
            // 
            // tbPDFOutputAFIS
            // 
            this.tbPDFOutputAFIS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbPDFOutputAFIS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPDFOutputAFIS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbPDFOutputAFIS.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "PDFOutputAFIS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPDFOutputAFIS.Location = new System.Drawing.Point(123, 169);
            this.tbPDFOutputAFIS.Name = "tbPDFOutputAFIS";
            this.tbPDFOutputAFIS.Size = new System.Drawing.Size(478, 20);
            this.tbPDFOutputAFIS.TabIndex = 9;
            this.tbPDFOutputAFIS.Text = global::EasyAdmin.Properties.Settings.Default.PDFOutputAFIS;
            // 
            // tbPDFOutputInvoice
            // 
            this.tbPDFOutputInvoice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbPDFOutputInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPDFOutputInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbPDFOutputInvoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "PDFOutputInvoice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPDFOutputInvoice.Location = new System.Drawing.Point(123, 135);
            this.tbPDFOutputInvoice.Name = "tbPDFOutputInvoice";
            this.tbPDFOutputInvoice.Size = new System.Drawing.Size(478, 20);
            this.tbPDFOutputInvoice.TabIndex = 6;
            this.tbPDFOutputInvoice.Text = global::EasyAdmin.Properties.Settings.Default.PDFOutputInvoice;
            // 
            // tbInvoiceResellerSave
            // 
            this.tbInvoiceResellerSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbInvoiceResellerSave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbInvoiceResellerSave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbInvoiceResellerSave.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "SaveDirInvoiceReseller", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbInvoiceResellerSave.Location = new System.Drawing.Point(123, 99);
            this.tbInvoiceResellerSave.Name = "tbInvoiceResellerSave";
            this.tbInvoiceResellerSave.Size = new System.Drawing.Size(478, 20);
            this.tbInvoiceResellerSave.TabIndex = 5;
            this.tbInvoiceResellerSave.Text = global::EasyAdmin.Properties.Settings.Default.SaveDirInvoiceReseller;
            // 
            // tbInvoiceSave
            // 
            this.tbInvoiceSave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbInvoiceSave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbInvoiceSave.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "SaveDirInvoice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbInvoiceSave.Location = new System.Drawing.Point(123, 61);
            this.tbInvoiceSave.Name = "tbInvoiceSave";
            this.tbInvoiceSave.Size = new System.Drawing.Size(478, 20);
            this.tbInvoiceSave.TabIndex = 2;
            this.tbInvoiceSave.Text = global::EasyAdmin.Properties.Settings.Default.SaveDirInvoice;
            // 
            // tbAFIS12Save
            // 
            this.tbAFIS12Save.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbAFIS12Save.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbAFIS12Save.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "SaveDirAFIS12", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAFIS12Save.Location = new System.Drawing.Point(123, 21);
            this.tbAFIS12Save.Name = "tbAFIS12Save";
            this.tbAFIS12Save.Size = new System.Drawing.Size(478, 20);
            this.tbAFIS12Save.TabIndex = 1;
            this.tbAFIS12Save.Text = global::EasyAdmin.Properties.Settings.Default.SaveDirAFIS12;
            // 
            // tbEmailSMTPPassw
            // 
            this.tbEmailSMTPPassw.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "EmailSMTPPassw", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailSMTPPassw.Location = new System.Drawing.Point(97, 198);
            this.tbEmailSMTPPassw.Name = "tbEmailSMTPPassw";
            this.tbEmailSMTPPassw.PasswordChar = '*';
            this.tbEmailSMTPPassw.Size = new System.Drawing.Size(139, 20);
            this.tbEmailSMTPPassw.TabIndex = 12;
            this.tbEmailSMTPPassw.Text = global::EasyAdmin.Properties.Settings.Default.EmailSMTPPassw;
            // 
            // tbEmailCCV
            // 
            this.tbEmailCCV.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "EmailCCV", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailCCV.Location = new System.Drawing.Point(428, 18);
            this.tbEmailCCV.Name = "tbEmailCCV";
            this.tbEmailCCV.Size = new System.Drawing.Size(100, 20);
            this.tbEmailCCV.TabIndex = 13;
            this.tbEmailCCV.Text = global::EasyAdmin.Properties.Settings.Default.EmailCCV;
            // 
            // tbEmailSMTPUser
            // 
            this.tbEmailSMTPUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "EmailSMTPUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailSMTPUser.Location = new System.Drawing.Point(97, 172);
            this.tbEmailSMTPUser.Name = "tbEmailSMTPUser";
            this.tbEmailSMTPUser.Size = new System.Drawing.Size(139, 20);
            this.tbEmailSMTPUser.TabIndex = 9;
            this.tbEmailSMTPUser.Text = global::EasyAdmin.Properties.Settings.Default.EmailSMTPUser;
            // 
            // cbEmailSSL
            // 
            this.cbEmailSSL.AutoSize = true;
            this.cbEmailSSL.Checked = global::EasyAdmin.Properties.Settings.Default.EmailSMTPSSL;
            this.cbEmailSSL.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EasyAdmin.Properties.Settings.Default, "EmailSMTPSSL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmailSSL.Location = new System.Drawing.Point(20, 145);
            this.cbEmailSSL.Name = "cbEmailSSL";
            this.cbEmailSSL.Size = new System.Drawing.Size(49, 17);
            this.cbEmailSSL.TabIndex = 8;
            this.cbEmailSSL.Text = "SSL:";
            this.cbEmailSSL.UseVisualStyleBackColor = true;
            // 
            // nUDEmailSMTPPort
            // 
            this.nUDEmailSMTPPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "EmailSMTPPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nUDEmailSMTPPort.Location = new System.Drawing.Point(97, 109);
            this.nUDEmailSMTPPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nUDEmailSMTPPort.Name = "nUDEmailSMTPPort";
            this.nUDEmailSMTPPort.Size = new System.Drawing.Size(139, 20);
            this.nUDEmailSMTPPort.TabIndex = 7;
            this.nUDEmailSMTPPort.Value = global::EasyAdmin.Properties.Settings.Default.EmailSMTPPort;
            // 
            // tbEmailSMTPServer
            // 
            this.tbEmailSMTPServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "EmailSMTPServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailSMTPServer.Location = new System.Drawing.Point(97, 82);
            this.tbEmailSMTPServer.Name = "tbEmailSMTPServer";
            this.tbEmailSMTPServer.Size = new System.Drawing.Size(139, 20);
            this.tbEmailSMTPServer.TabIndex = 5;
            this.tbEmailSMTPServer.Text = global::EasyAdmin.Properties.Settings.Default.EmailSMTPServer;
            // 
            // tbEmailFrom
            // 
            this.tbEmailFrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "EmailFrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailFrom.Location = new System.Drawing.Point(97, 56);
            this.tbEmailFrom.Name = "tbEmailFrom";
            this.tbEmailFrom.Size = new System.Drawing.Size(139, 20);
            this.tbEmailFrom.TabIndex = 3;
            this.tbEmailFrom.Text = global::EasyAdmin.Properties.Settings.Default.EmailFrom;
            // 
            // nUDEmailTimeout
            // 
            this.nUDEmailTimeout.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "EmailTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nUDEmailTimeout.Location = new System.Drawing.Point(97, 23);
            this.nUDEmailTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nUDEmailTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDEmailTimeout.Name = "nUDEmailTimeout";
            this.nUDEmailTimeout.Size = new System.Drawing.Size(69, 20);
            this.nUDEmailTimeout.TabIndex = 0;
            this.nUDEmailTimeout.Value = global::EasyAdmin.Properties.Settings.Default.EmailTimeout;
            // 
            // cbAmountRemove0s
            // 
            this.cbAmountRemove0s.AutoSize = true;
            this.cbAmountRemove0s.Checked = global::EasyAdmin.Properties.Settings.Default.InvoiceAmountRemove0s;
            this.cbAmountRemove0s.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAmountRemove0s.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EasyAdmin.Properties.Settings.Default, "InvoiceAmountRemove0s", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAmountRemove0s.Location = new System.Drawing.Point(388, 22);
            this.cbAmountRemove0s.Name = "cbAmountRemove0s";
            this.cbAmountRemove0s.Size = new System.Drawing.Size(93, 17);
            this.cbAmountRemove0s.TabIndex = 10;
            this.cbAmountRemove0s.Text = "Verwijder 0-en";
            this.cbAmountRemove0s.UseVisualStyleBackColor = true;
            // 
            // nUDInvoiceOffset
            // 
            this.nUDInvoiceOffset.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "InvoiceNoOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nUDInvoiceOffset.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDInvoiceOffset.Location = new System.Drawing.Point(313, 50);
            this.nUDInvoiceOffset.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.nUDInvoiceOffset.Name = "nUDInvoiceOffset";
            this.nUDInvoiceOffset.Size = new System.Drawing.Size(69, 20);
            this.nUDInvoiceOffset.TabIndex = 9;
            this.nUDInvoiceOffset.Value = global::EasyAdmin.Properties.Settings.Default.InvoiceNoOffset;
            // 
            // nUDDecimals
            // 
            this.nUDDecimals.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "DecimalsInvoiceAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nUDDecimals.Location = new System.Drawing.Point(342, 19);
            this.nUDDecimals.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nUDDecimals.Name = "nUDDecimals";
            this.nUDDecimals.Size = new System.Drawing.Size(40, 20);
            this.nUDDecimals.TabIndex = 6;
            this.nUDDecimals.Value = global::EasyAdmin.Properties.Settings.Default.DecimalsInvoiceAmount;
            // 
            // nUDFATHigh
            // 
            this.nUDFATHigh.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "FATHigh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nUDFATHigh.DecimalPlaces = 1;
            this.nUDFATHigh.Location = new System.Drawing.Point(72, 52);
            this.nUDFATHigh.Name = "nUDFATHigh";
            this.nUDFATHigh.Size = new System.Drawing.Size(74, 20);
            this.nUDFATHigh.TabIndex = 5;
            this.nUDFATHigh.Value = global::EasyAdmin.Properties.Settings.Default.FATHigh;
            // 
            // nUDFATLow
            // 
            this.nUDFATLow.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "FATLow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nUDFATLow.DecimalPlaces = 1;
            this.nUDFATLow.Location = new System.Drawing.Point(72, 19);
            this.nUDFATLow.Name = "nUDFATLow";
            this.nUDFATLow.Size = new System.Drawing.Size(74, 20);
            this.nUDFATLow.TabIndex = 0;
            this.nUDFATLow.Value = global::EasyAdmin.Properties.Settings.Default.FATLow;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 335);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Instellingen";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDEmailSMTPPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDEmailTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDInvoiceOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDecimals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFATHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFATLow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbAFIS12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbInvoice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbAFIS12Save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbInvoiceReseller;
        private System.Windows.Forms.TextBox tbInvoiceDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInvoiceSave;
        private System.Windows.Forms.TextBox tbInvoiceResellerSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.NumericUpDown nUDFATHigh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nUDFATLow;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPDFOutputInvoice;
        private System.Windows.Forms.NumericUpDown nUDDecimals;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbPDFOutputAFIS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nUDInvoiceOffset;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbAmountRemove0s;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nUDEmailTimeout;
        private System.Windows.Forms.TextBox tbEmailFrom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbEmailSMTPServer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nUDEmailSMTPPort;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox cbEmailSSL;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbEmailSMTPUser;
        private System.Windows.Forms.TextBox tbEmailSMTPPassw;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbEmailCCV;
        private System.Windows.Forms.CheckBox cbStoreFolderYear;
    }
}