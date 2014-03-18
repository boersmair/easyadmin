namespace EasyAdmin
{
    partial class DataImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataImportForm));
            this.btnFile = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStatusEnd1 = new System.Windows.Forms.Label();
            this.labelImportStatus = new System.Windows.Forms.Label();
            this.panelFile = new System.Windows.Forms.Panel();
            this.cbImportSelected = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTableCustomers = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nupCustomerNumberOffset = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCustomerInfo = new System.Windows.Forms.Label();
            this.cbImportCustomers = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewCCV = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbCCVUpdateSameNo = new System.Windows.Forms.CheckBox();
            this.labelCCVcardsInfo = new System.Windows.Forms.Label();
            this.cbImportCCV = new System.Windows.Forms.CheckBox();
            this.tbTableCCV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbLog = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupCustomerNumberOffset)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCCV)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFile.Location = new System.Drawing.Point(6, 28);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(88, 23);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "Bestand";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(12, 62);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(114, 13);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "Selecteer een bestand";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Access Db|*.mdb|Comma gescheiden|*.csv|Alle bestanden|*.*";
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.AllowUserToAddRows = false;
            this.dataGridViewCustomers.AllowUserToDeleteRows = false;
            this.dataGridViewCustomers.AllowUserToResizeRows = false;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.ReadOnly = true;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(785, 204);
            this.dataGridViewCustomers.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelStatusEnd1);
            this.panel1.Controls.Add(this.labelImportStatus);
            this.panel1.Controls.Add(this.panelFile);
            this.panel1.Controls.Add(this.pbProgress);
            this.panel1.Controls.Add(this.btnStartImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 91);
            this.panel1.TabIndex = 3;
            // 
            // labelStatusEnd1
            // 
            this.labelStatusEnd1.AutoSize = true;
            this.labelStatusEnd1.Location = new System.Drawing.Point(505, 28);
            this.labelStatusEnd1.Name = "labelStatusEnd1";
            this.labelStatusEnd1.Size = new System.Drawing.Size(35, 13);
            this.labelStatusEnd1.TabIndex = 8;
            this.labelStatusEnd1.Text = "label5";
            this.labelStatusEnd1.Visible = false;
            // 
            // labelImportStatus
            // 
            this.labelImportStatus.AutoSize = true;
            this.labelImportStatus.Location = new System.Drawing.Point(505, 9);
            this.labelImportStatus.Name = "labelImportStatus";
            this.labelImportStatus.Size = new System.Drawing.Size(35, 13);
            this.labelImportStatus.TabIndex = 7;
            this.labelImportStatus.Text = "label4";
            this.labelImportStatus.Visible = false;
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.cbLog);
            this.panelFile.Controls.Add(this.cbImportSelected);
            this.panelFile.Controls.Add(this.tbPassword);
            this.panelFile.Controls.Add(this.label2);
            this.panelFile.Controls.Add(this.labelFileName);
            this.panelFile.Controls.Add(this.btnFile);
            this.panelFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFile.Location = new System.Drawing.Point(0, 0);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(385, 91);
            this.panelFile.TabIndex = 6;
            // 
            // cbImportSelected
            // 
            this.cbImportSelected.AutoSize = true;
            this.cbImportSelected.Location = new System.Drawing.Point(100, 32);
            this.cbImportSelected.Name = "cbImportSelected";
            this.cbImportSelected.Size = new System.Drawing.Size(171, 17);
            this.cbImportSelected.TabIndex = 5;
            this.cbImportSelected.Text = "Importeer alleen geselecteerde";
            this.cbImportSelected.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(100, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "bitank_bv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wachtwoord:";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(391, 62);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(382, 23);
            this.pbProgress.Step = 1;
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 5;
            this.pbProgress.Visible = false;
            // 
            // btnStartImport
            // 
            this.btnStartImport.Enabled = false;
            this.btnStartImport.Location = new System.Drawing.Point(391, 5);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(78, 23);
            this.btnStartImport.TabIndex = 4;
            this.btnStartImport.Text = "Importeren";
            this.btnStartImport.UseVisualStyleBackColor = true;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tabel:";
            // 
            // tbTableCustomers
            // 
            this.tbTableCustomers.Location = new System.Drawing.Point(40, 6);
            this.tbTableCustomers.Name = "tbTableCustomers";
            this.tbTableCustomers.Size = new System.Drawing.Size(69, 20);
            this.tbTableCustomers.TabIndex = 4;
            this.tbTableCustomers.Text = "Klanten";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewCustomers);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 234);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nupCustomerNumberOffset);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.labelCustomerInfo);
            this.panel3.Controls.Add(this.cbImportCustomers);
            this.panel3.Controls.Add(this.tbTableCustomers);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(785, 30);
            this.panel3.TabIndex = 6;
            // 
            // nupCustomerNumberOffset
            // 
            this.nupCustomerNumberOffset.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupCustomerNumberOffset.Location = new System.Drawing.Point(541, 6);
            this.nupCustomerNumberOffset.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nupCustomerNumberOffset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupCustomerNumberOffset.Name = "nupCustomerNumberOffset";
            this.nupCustomerNumberOffset.Size = new System.Drawing.Size(33, 20);
            this.nupCustomerNumberOffset.TabIndex = 9;
            this.nupCustomerNumberOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Klant nummer 1e digit:";
            // 
            // labelCustomerInfo
            // 
            this.labelCustomerInfo.AutoSize = true;
            this.labelCustomerInfo.Location = new System.Drawing.Point(580, 10);
            this.labelCustomerInfo.Name = "labelCustomerInfo";
            this.labelCustomerInfo.Size = new System.Drawing.Size(84, 13);
            this.labelCustomerInfo.TabIndex = 7;
            this.labelCustomerInfo.Text = "Aantal records= ";
            this.labelCustomerInfo.Visible = false;
            // 
            // cbImportCustomers
            // 
            this.cbImportCustomers.AutoSize = true;
            this.cbImportCustomers.Checked = true;
            this.cbImportCustomers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImportCustomers.Location = new System.Drawing.Point(115, 7);
            this.cbImportCustomers.Name = "cbImportCustomers";
            this.cbImportCustomers.Size = new System.Drawing.Size(76, 17);
            this.cbImportCustomers.TabIndex = 6;
            this.cbImportCustomers.Text = "Importeren";
            this.cbImportCustomers.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewCCV);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(785, 235);
            this.panel4.TabIndex = 5;
            // 
            // dataGridViewCCV
            // 
            this.dataGridViewCCV.AllowUserToAddRows = false;
            this.dataGridViewCCV.AllowUserToDeleteRows = false;
            this.dataGridViewCCV.AllowUserToResizeRows = false;
            this.dataGridViewCCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCCV.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewCCV.MultiSelect = false;
            this.dataGridViewCCV.Name = "dataGridViewCCV";
            this.dataGridViewCCV.ReadOnly = true;
            this.dataGridViewCCV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCCV.Size = new System.Drawing.Size(785, 210);
            this.dataGridViewCCV.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbCCVUpdateSameNo);
            this.panel5.Controls.Add(this.labelCCVcardsInfo);
            this.panel5.Controls.Add(this.cbImportCCV);
            this.panel5.Controls.Add(this.tbTableCCV);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(785, 25);
            this.panel5.TabIndex = 3;
            // 
            // cbCCVUpdateSameNo
            // 
            this.cbCCVUpdateSameNo.AutoSize = true;
            this.cbCCVUpdateSameNo.Checked = true;
            this.cbCCVUpdateSameNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCCVUpdateSameNo.Location = new System.Drawing.Point(198, 5);
            this.cbCCVUpdateSameNo.Name = "cbCCVUpdateSameNo";
            this.cbCCVUpdateSameNo.Size = new System.Drawing.Size(205, 17);
            this.cbCCVUpdateSameNo.TabIndex = 5;
            this.cbCCVUpdateSameNo.Text = "Klant met bestaand nummer bijwerken";
            this.cbCCVUpdateSameNo.UseVisualStyleBackColor = true;
            // 
            // labelCCVcardsInfo
            // 
            this.labelCCVcardsInfo.AutoSize = true;
            this.labelCCVcardsInfo.Location = new System.Drawing.Point(580, 6);
            this.labelCCVcardsInfo.Name = "labelCCVcardsInfo";
            this.labelCCVcardsInfo.Size = new System.Drawing.Size(87, 13);
            this.labelCCVcardsInfo.TabIndex = 4;
            this.labelCCVcardsInfo.Text = "Aantal records = ";
            this.labelCCVcardsInfo.Visible = false;
            // 
            // cbImportCCV
            // 
            this.cbImportCCV.AutoSize = true;
            this.cbImportCCV.Checked = true;
            this.cbImportCCV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImportCCV.Location = new System.Drawing.Point(115, 5);
            this.cbImportCCV.Name = "cbImportCCV";
            this.cbImportCCV.Size = new System.Drawing.Size(76, 17);
            this.cbImportCCV.TabIndex = 3;
            this.cbImportCCV.Text = "Importeren";
            this.cbImportCCV.UseVisualStyleBackColor = true;
            // 
            // tbTableCCV
            // 
            this.tbTableCCV.Location = new System.Drawing.Point(40, 4);
            this.tbTableCCV.Name = "tbTableCCV";
            this.tbTableCCV.Size = new System.Drawing.Size(69, 20);
            this.tbTableCCV.TabIndex = 1;
            this.tbTableCCV.Text = "Passen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tabel:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 91);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 473);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 6;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 564);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(785, 40);
            this.panelBottom.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(680, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Sluiten";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbLog
            // 
            this.cbLog.AutoSize = true;
            this.cbLog.Checked = true;
            this.cbLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLog.Location = new System.Drawing.Point(277, 32);
            this.cbLog.Name = "cbLog";
            this.cbLog.Size = new System.Drawing.Size(70, 17);
            this.cbLog.TabIndex = 9;
            this.cbLog.Text = "Maak log";
            this.cbLog.UseVisualStyleBackColor = true;
            // 
            // DataImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 604);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel1);
            this.Name = "DataImportForm";
            this.Text = "Gegevens importeren";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFile.ResumeLayout(false);
            this.panelFile.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupCustomerNumberOffset)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCCV)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTableCustomers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewCCV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTableCCV;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox cbImportCustomers;
        private System.Windows.Forms.CheckBox cbImportCCV;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.Label labelCustomerInfo;
        private System.Windows.Forms.Label labelCCVcardsInfo;
        private System.Windows.Forms.Label labelImportStatus;
        private System.Windows.Forms.NumericUpDown nupCustomerNumberOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbImportSelected;
        private System.Windows.Forms.CheckBox cbCCVUpdateSameNo;
        private System.Windows.Forms.Label labelStatusEnd1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbLog;
    }
}