namespace EasyAdmin
{
    partial class CustomersPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersPanel));
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPasses = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbCardsFilter = new System.Windows.Forms.ComboBox();
            this.tbCardFilter = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbCustomCustomerFilter = new System.Windows.Forms.TextBox();
            this.cbAutoColumnHide = new System.Windows.Forms.CheckBox();
            this.cbLBColumns = new System.Windows.Forms.CheckedListBox();
            this.cbCustomTypeFilter = new System.Windows.Forms.ComboBox();
            this.dTPDate = new System.Windows.Forms.DateTimePicker();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.btnToDate = new System.Windows.Forms.Button();
            this.btnToNumber = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nUDCardCustomNo = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbLBCardsColumns = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPasses)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCardCustomNo)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.AllowUserToOrderColumns = true;
            this.dataGridViewCustomers.AllowUserToResizeRows = false;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCustomers.MultiSelect = false;
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.Size = new System.Drawing.Size(899, 209);
            this.dataGridViewCustomers.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(11, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Vernieuwen";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 414);
            this.panel1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewCustomers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPasses);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(899, 414);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridViewPasses
            // 
            this.dataGridViewPasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPasses.Location = new System.Drawing.Point(0, 57);
            this.dataGridViewPasses.Name = "dataGridViewPasses";
            this.dataGridViewPasses.Size = new System.Drawing.Size(899, 144);
            this.dataGridViewPasses.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbLBCardsColumns);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(899, 57);
            this.panel3.TabIndex = 1;
            // 
            // cbCardsFilter
            // 
            this.cbCardsFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardsFilter.FormattingEnabled = true;
            this.cbCardsFilter.Items.AddRange(new object[] {
            "Alles",
            "Vervallen en/of geblokkeerd",
            "Vervallen",
            "Geblokkeerd",
            "Eigen filter:",
            "Klantnummer:"});
            this.cbCardsFilter.Location = new System.Drawing.Point(3, 3);
            this.cbCardsFilter.Name = "cbCardsFilter";
            this.cbCardsFilter.Size = new System.Drawing.Size(197, 21);
            this.cbCardsFilter.TabIndex = 1;
            this.cbCardsFilter.SelectedIndexChanged += new System.EventHandler(this.cbCardsFilter_SelectedIndexChanged);
            // 
            // tbCardFilter
            // 
            this.tbCardFilter.Location = new System.Drawing.Point(3, 29);
            this.tbCardFilter.Name = "tbCardFilter";
            this.tbCardFilter.Size = new System.Drawing.Size(197, 20);
            this.tbCardFilter.TabIndex = 0;
            this.tbCardFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCardFilter_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbLBColumns);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 84);
            this.panel2.TabIndex = 5;
            // 
            // tbCustomCustomerFilter
            // 
            this.tbCustomCustomerFilter.Location = new System.Drawing.Point(112, 60);
            this.tbCustomCustomerFilter.Name = "tbCustomCustomerFilter";
            this.tbCustomCustomerFilter.Size = new System.Drawing.Size(231, 20);
            this.tbCustomCustomerFilter.TabIndex = 13;
            this.tbCustomCustomerFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCustomCustomerFilter_KeyDown);
            // 
            // cbAutoColumnHide
            // 
            this.cbAutoColumnHide.AutoSize = true;
            this.cbAutoColumnHide.Checked = true;
            this.cbAutoColumnHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoColumnHide.Location = new System.Drawing.Point(305, 33);
            this.cbAutoColumnHide.Name = "cbAutoColumnHide";
            this.cbAutoColumnHide.Size = new System.Drawing.Size(130, 17);
            this.cbAutoColumnHide.TabIndex = 12;
            this.cbAutoColumnHide.Text = "Auto kolom verbergen";
            this.cbAutoColumnHide.UseVisualStyleBackColor = true;
            // 
            // cbLBColumns
            // 
            this.cbLBColumns.CheckOnClick = true;
            this.cbLBColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLBColumns.FormattingEnabled = true;
            this.cbLBColumns.Location = new System.Drawing.Point(455, 0);
            this.cbLBColumns.MultiColumn = true;
            this.cbLBColumns.Name = "cbLBColumns";
            this.cbLBColumns.Size = new System.Drawing.Size(444, 84);
            this.cbLBColumns.TabIndex = 11;
            // 
            // cbCustomTypeFilter
            // 
            this.cbCustomTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomTypeFilter.FormattingEnabled = true;
            this.cbCustomTypeFilter.Items.AddRange(new object[] {
            "Alles",
            "CCV",
            "Niet CCV",
            "Vervallen en/of geblokkeerd",
            "Vervallen",
            "Geblokkeerd",
            "Eigen filter:"});
            this.cbCustomTypeFilter.Location = new System.Drawing.Point(112, 31);
            this.cbCustomTypeFilter.Name = "cbCustomTypeFilter";
            this.cbCustomTypeFilter.Size = new System.Drawing.Size(183, 21);
            this.cbCustomTypeFilter.TabIndex = 10;
            this.cbCustomTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cbCustomTypeFilter_SelectedIndexChanged);
            // 
            // dTPDate
            // 
            this.dTPDate.CustomFormat = "dd-MMMM-yyyy hh:mm";
            this.dTPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPDate.Location = new System.Drawing.Point(272, 3);
            this.dTPDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dTPDate.Name = "dTPDate";
            this.dTPDate.Size = new System.Drawing.Size(163, 20);
            this.dTPDate.TabIndex = 9;
            this.dTPDate.Value = new System.DateTime(2019, 12, 25, 23, 59, 59, 0);
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(111, 3);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(95, 20);
            this.tbDate.TabIndex = 8;
            // 
            // btnToDate
            // 
            this.btnToDate.Location = new System.Drawing.Point(242, 1);
            this.btnToDate.Name = "btnToDate";
            this.btnToDate.Size = new System.Drawing.Size(27, 23);
            this.btnToDate.TabIndex = 7;
            this.btnToDate.Text = ">>";
            this.btnToDate.UseVisualStyleBackColor = true;
            this.btnToDate.Click += new System.EventHandler(this.btnToDate_Click);
            // 
            // btnToNumber
            // 
            this.btnToNumber.Location = new System.Drawing.Point(212, 1);
            this.btnToNumber.Name = "btnToNumber";
            this.btnToNumber.Size = new System.Drawing.Size(27, 23);
            this.btnToNumber.TabIndex = 6;
            this.btnToNumber.Text = "<<";
            this.btnToNumber.UseVisualStyleBackColor = true;
            this.btnToNumber.Click += new System.EventHandler(this.btnToNumber_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(11, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(11, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnRefresh);
            this.panel4.Controls.Add(this.tbCustomCustomerFilter);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.cbAutoColumnHide);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnToNumber);
            this.panel4.Controls.Add(this.cbCustomTypeFilter);
            this.panel4.Controls.Add(this.btnToDate);
            this.panel4.Controls.Add(this.dTPDate);
            this.panel4.Controls.Add(this.tbDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(455, 84);
            this.panel4.TabIndex = 14;
            // 
            // nUDCardCustomNo
            // 
            this.nUDCardCustomNo.Location = new System.Drawing.Point(217, 4);
            this.nUDCardCustomNo.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nUDCardCustomNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDCardCustomNo.Name = "nUDCardCustomNo";
            this.nUDCardCustomNo.Size = new System.Drawing.Size(60, 20);
            this.nUDCardCustomNo.TabIndex = 2;
            this.nUDCardCustomNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDCardCustomNo.ValueChanged += new System.EventHandler(this.nUDCardCustomNo_ValueChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbCardsFilter);
            this.panel5.Controls.Add(this.nUDCardCustomNo);
            this.panel5.Controls.Add(this.tbCardFilter);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(295, 57);
            this.panel5.TabIndex = 3;
            // 
            // cbLBCardsColumns
            // 
            this.cbLBCardsColumns.CheckOnClick = true;
            this.cbLBCardsColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLBCardsColumns.FormattingEnabled = true;
            this.cbLBCardsColumns.Location = new System.Drawing.Point(295, 0);
            this.cbLBCardsColumns.MultiColumn = true;
            this.cbLBCardsColumns.Name = "cbLBCardsColumns";
            this.cbLBCardsColumns.Size = new System.Drawing.Size(604, 57);
            this.cbLBCardsColumns.TabIndex = 4;
            // 
            // CustomersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CustomersPanel";
            this.Size = new System.Drawing.Size(899, 498);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPasses)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCardCustomNo)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewPasses;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Button btnToDate;
        private System.Windows.Forms.Button btnToNumber;
        private System.Windows.Forms.DateTimePicker dTPDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbCustomTypeFilter;
        private System.Windows.Forms.TextBox tbCardFilter;
        private System.Windows.Forms.CheckedListBox cbLBColumns;
        private System.Windows.Forms.CheckBox cbAutoColumnHide;
        private System.Windows.Forms.TextBox tbCustomCustomerFilter;
        private System.Windows.Forms.ComboBox cbCardsFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nUDCardCustomNo;
        private System.Windows.Forms.CheckedListBox cbLBCardsColumns;
        private System.Windows.Forms.Panel panel5;
    }
}
