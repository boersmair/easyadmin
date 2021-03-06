﻿namespace EasyAdmin
{
    partial class DatabaseSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbUseWinAuth = new System.Windows.Forms.CheckBox();
            this.cbDatabaseType = new System.Windows.Forms.ComboBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbEmailAttachm = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbEmailSend = new System.Windows.Forms.TextBox();
            this.tbProductTableName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbAFIS12TableName = new System.Windows.Forms.TextBox();
            this.tbInvoiceTableName = new System.Windows.Forms.TextBox();
            this.tbCCVcardTableName = new System.Windows.Forms.TextBox();
            this.tbCustomerTableName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gebruikersnaam:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wachtwoord:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Poort:";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(16, 255);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(142, 255);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(223, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(290, 246);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbUseWinAuth);
            this.tabPage1.Controls.Add(this.cbDatabaseType);
            this.tabPage1.Controls.Add(this.tbPassword);
            this.tabPage1.Controls.Add(this.tbServer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbDatabase);
            this.tabPage1.Controls.Add(this.nudPort);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbUsername);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(282, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connectie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbUseWinAuth
            // 
            this.cbUseWinAuth.AutoSize = true;
            this.cbUseWinAuth.Checked = global::EasyAdmin.Properties.Settings.Default.DB_UseWinAuth;
            this.cbUseWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseWinAuth.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EasyAdmin.Properties.Settings.Default, "DB_UseWinAuth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbUseWinAuth.Location = new System.Drawing.Point(20, 44);
            this.cbUseWinAuth.Name = "cbUseWinAuth";
            this.cbUseWinAuth.Size = new System.Drawing.Size(134, 17);
            this.cbUseWinAuth.TabIndex = 11;
            this.cbUseWinAuth.Text = "Windows authenticatie";
            this.cbUseWinAuth.UseVisualStyleBackColor = true;
            // 
            // cbDatabaseType
            // 
            this.cbDatabaseType.AutoCompleteCustomSource.AddRange(new string[] {
            "MySql"});
            this.cbDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaseType.FormattingEnabled = true;
            this.cbDatabaseType.Location = new System.Drawing.Point(115, 14);
            this.cbDatabaseType.Name = "cbDatabaseType";
            this.cbDatabaseType.Size = new System.Drawing.Size(100, 21);
            this.cbDatabaseType.TabIndex = 10;
            this.cbDatabaseType.Text = global::EasyAdmin.Properties.Settings.Default.DB_dbtype;
            // 
            // tbPassword
            // 
            this.tbPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DB_Psw", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPassword.Location = new System.Drawing.Point(115, 149);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Text = global::EasyAdmin.Properties.Settings.Default.DB_Psw;
            // 
            // tbServer
            // 
            this.tbServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DB_Server", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbServer.Location = new System.Drawing.Point(115, 71);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(100, 20);
            this.tbServer.TabIndex = 0;
            this.tbServer.Text = global::EasyAdmin.Properties.Settings.Default.DB_Server;
            // 
            // tbDatabase
            // 
            this.tbDatabase.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DB_Database", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDatabase.Location = new System.Drawing.Point(115, 175);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(100, 20);
            this.tbDatabase.TabIndex = 3;
            this.tbDatabase.Text = global::EasyAdmin.Properties.Settings.Default.DB_Database;
            // 
            // nudPort
            // 
            this.nudPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::EasyAdmin.Properties.Settings.Default, "DB_Port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudPort.Location = new System.Drawing.Point(115, 97);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(100, 20);
            this.nudPort.TabIndex = 8;
            this.nudPort.Value = global::EasyAdmin.Properties.Settings.Default.DB_Port;
            // 
            // tbUsername
            // 
            this.tbUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DB_Username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbUsername.Location = new System.Drawing.Point(115, 123);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 20);
            this.tbUsername.TabIndex = 5;
            this.tbUsername.Text = global::EasyAdmin.Properties.Settings.Default.DB_Username;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbEmailAttachm);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbEmailSend);
            this.tabPage2.Controls.Add(this.tbProductTableName);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbAFIS12TableName);
            this.tabPage2.Controls.Add(this.tbInvoiceTableName);
            this.tabPage2.Controls.Add(this.tbCCVcardTableName);
            this.tabPage2.Controls.Add(this.tbCustomerTableName);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(282, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tabellen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbEmailAttachm
            // 
            this.tbEmailAttachm.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_emailattch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailAttachm.Location = new System.Drawing.Point(106, 184);
            this.tbEmailAttachm.Name = "tbEmailAttachm";
            this.tbEmailAttachm.Size = new System.Drawing.Size(158, 20);
            this.tbEmailAttachm.TabIndex = 13;
            this.tbEmailAttachm.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_emailattch;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Bijlagen e-mail:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Verzonden e-mail:";
            // 
            // tbEmailSend
            // 
            this.tbEmailSend.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_emailsend", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbEmailSend.Location = new System.Drawing.Point(106, 155);
            this.tbEmailSend.Name = "tbEmailSend";
            this.tbEmailSend.Size = new System.Drawing.Size(158, 20);
            this.tbEmailSend.TabIndex = 10;
            this.tbEmailSend.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_emailsend;
            // 
            // tbProductTableName
            // 
            this.tbProductTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_products", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbProductTableName.Location = new System.Drawing.Point(106, 129);
            this.tbProductTableName.Name = "tbProductTableName";
            this.tbProductTableName.Size = new System.Drawing.Size(158, 20);
            this.tbProductTableName.TabIndex = 9;
            this.tbProductTableName.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_products;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Producten";
            // 
            // tbAFIS12TableName
            // 
            this.tbAFIS12TableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_afis12", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAFIS12TableName.Location = new System.Drawing.Point(106, 99);
            this.tbAFIS12TableName.Name = "tbAFIS12TableName";
            this.tbAFIS12TableName.Size = new System.Drawing.Size(158, 20);
            this.tbAFIS12TableName.TabIndex = 7;
            this.tbAFIS12TableName.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_afis12;
            // 
            // tbInvoiceTableName
            // 
            this.tbInvoiceTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_invoices", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbInvoiceTableName.Location = new System.Drawing.Point(106, 73);
            this.tbInvoiceTableName.Name = "tbInvoiceTableName";
            this.tbInvoiceTableName.Size = new System.Drawing.Size(158, 20);
            this.tbInvoiceTableName.TabIndex = 6;
            this.tbInvoiceTableName.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_invoices;
            // 
            // tbCCVcardTableName
            // 
            this.tbCCVcardTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_ccvcards", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCCVcardTableName.Location = new System.Drawing.Point(106, 46);
            this.tbCCVcardTableName.Name = "tbCCVcardTableName";
            this.tbCCVcardTableName.Size = new System.Drawing.Size(158, 20);
            this.tbCCVcardTableName.TabIndex = 5;
            this.tbCCVcardTableName.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_ccvcards;
            // 
            // tbCustomerTableName
            // 
            this.tbCustomerTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EasyAdmin.Properties.Settings.Default, "DBTbl_customers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCustomerTableName.Location = new System.Drawing.Point(106, 20);
            this.tbCustomerTableName.Name = "tbCustomerTableName";
            this.tbCustomerTableName.Size = new System.Drawing.Size(158, 20);
            this.tbCustomerTableName.TabIndex = 4;
            this.tbCustomerTableName.Text = global::EasyAdmin.Properties.Settings.Default.DBTbl_customers;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "AFIS12";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Facturen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "CCV passen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Klanten";
            // 
            // DatabaseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(317, 297);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTestConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DatabaseSettingsForm";
            this.Text = "Database instellingen";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAFIS12TableName;
        private System.Windows.Forms.TextBox tbInvoiceTableName;
        private System.Windows.Forms.TextBox tbCCVcardTableName;
        private System.Windows.Forms.TextBox tbCustomerTableName;
        private System.Windows.Forms.ComboBox cbDatabaseType;
        private System.Windows.Forms.TextBox tbProductTableName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEmailAttachm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbEmailSend;
        private System.Windows.Forms.CheckBox cbUseWinAuth;
    }
}