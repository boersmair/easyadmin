namespace EasyAdmin
{
    partial class InvoiceProductItem
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nUDTotal = new System.Windows.Forms.NumericUpDown();
            this.nUDAmount = new System.Windows.Forms.NumericUpDown();
            this.cbFAT = new System.Windows.Forms.ComboBox();
            this.tbDescription = new EasyAdmin.AutoCompleteTextBox();
            this.cbAdd = new System.Windows.Forms.CheckBox();
            this.cbUpdate = new System.Windows.Forms.CheckBox();
            this.nUDFAT = new System.Windows.Forms.NumericUpDown();
            this.tbArticleID = new EasyAdmin.AutoCompleteTextBox();
            this.cbPriceExFAT = new System.Windows.Forms.CheckBox();
            this.labelNo = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFAT)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Controls.Add(this.nUDTotal, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.nUDAmount, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbFAT, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbDescription, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbAdd, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbUpdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nUDFAT, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbArticleID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbPriceExFAT, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbPrice, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbDiscount, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nUDTotal
            // 
            this.nUDTotal.DecimalPlaces = 2;
            this.nUDTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDTotal.Location = new System.Drawing.Point(675, 3);
            this.nUDTotal.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this.nUDTotal.Minimum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            -2147483648});
            this.nUDTotal.Name = "nUDTotal";
            this.nUDTotal.ReadOnly = true;
            this.nUDTotal.Size = new System.Drawing.Size(74, 20);
            this.nUDTotal.TabIndex = 9;
            // 
            // nUDAmount
            // 
            this.nUDAmount.DecimalPlaces = 2;
            this.nUDAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDAmount.Location = new System.Drawing.Point(445, 3);
            this.nUDAmount.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.nUDAmount.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.nUDAmount.Name = "nUDAmount";
            this.nUDAmount.Size = new System.Drawing.Size(64, 20);
            this.nUDAmount.TabIndex = 2;
            this.nUDAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDAmount.ValueChanged += new System.EventHandler(this.nUDAmount_ValueChanged);
            // 
            // cbFAT
            // 
            this.cbFAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFAT.FormattingEnabled = true;
            this.cbFAT.Location = new System.Drawing.Point(820, 3);
            this.cbFAT.Name = "cbFAT";
            this.cbFAT.Size = new System.Drawing.Size(85, 21);
            this.cbFAT.TabIndex = 5;
            this.cbFAT.SelectedIndexChanged += new System.EventHandler(this.cbFAT_SelectedIndexChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(145, 3);
            this.tbDescription.MaxLength = 100;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(294, 20);
            this.tbDescription.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbDescription, "Omschrijving van het artikel");
            this.tbDescription.Values = null;
            // 
            // cbAdd
            // 
            this.cbAdd.AutoSize = true;
            this.cbAdd.Location = new System.Drawing.Point(41, 3);
            this.cbAdd.Name = "cbAdd";
            this.cbAdd.Size = new System.Drawing.Size(13, 17);
            this.cbAdd.TabIndex = 7;
            this.cbAdd.Text = "checkBox1";
            this.toolTip1.SetToolTip(this.cbAdd, "Artikel toevoegen");
            this.cbAdd.UseVisualStyleBackColor = true;
            // 
            // cbUpdate
            // 
            this.cbUpdate.AutoSize = true;
            this.cbUpdate.Location = new System.Drawing.Point(22, 3);
            this.cbUpdate.Name = "cbUpdate";
            this.cbUpdate.Size = new System.Drawing.Size(13, 17);
            this.cbUpdate.TabIndex = 7;
            this.cbUpdate.Text = "checkBox2";
            this.toolTip1.SetToolTip(this.cbUpdate, "Artikel bijwerken");
            this.cbUpdate.UseVisualStyleBackColor = true;
            // 
            // nUDFAT
            // 
            this.nUDFAT.DecimalPlaces = 2;
            this.nUDFAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDFAT.Location = new System.Drawing.Point(595, 3);
            this.nUDFAT.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.nUDFAT.Minimum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            -2147483648});
            this.nUDFAT.Name = "nUDFAT";
            this.nUDFAT.ReadOnly = true;
            this.nUDFAT.Size = new System.Drawing.Size(74, 20);
            this.nUDFAT.TabIndex = 8;
            // 
            // tbArticleID
            // 
            this.tbArticleID.Location = new System.Drawing.Point(60, 3);
            this.tbArticleID.MaxLength = 30;
            this.tbArticleID.Name = "tbArticleID";
            this.tbArticleID.Size = new System.Drawing.Size(79, 20);
            this.tbArticleID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tbArticleID, "Artikel nummer");
            this.tbArticleID.Values = null;
            // 
            // cbPriceExFAT
            // 
            this.cbPriceExFAT.AutoSize = true;
            this.cbPriceExFAT.Location = new System.Drawing.Point(911, 3);
            this.cbPriceExFAT.Name = "cbPriceExFAT";
            this.cbPriceExFAT.Size = new System.Drawing.Size(18, 17);
            this.cbPriceExFAT.TabIndex = 6;
            this.cbPriceExFAT.Text = "checkBox1";
            this.toolTip1.SetToolTip(this.cbPriceExFAT, "Prijs is exclusief BTW");
            this.cbPriceExFAT.UseVisualStyleBackColor = true;
            this.cbPriceExFAT.CheckedChanged += new System.EventHandler(this.cbPriceExFAT_CheckedChanged);
            // 
            // labelNo
            // 
            this.labelNo.AutoSize = true;
            this.labelNo.Location = new System.Drawing.Point(0, 4);
            this.labelNo.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelNo.Name = "labelNo";
            this.labelNo.Size = new System.Drawing.Size(13, 13);
            this.labelNo.TabIndex = 8;
            this.labelNo.Text = "1";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(515, 3);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(74, 20);
            this.tbPrice.TabIndex = 3;
            // 
            // tbDiscount
            // 
            this.tbDiscount.Location = new System.Drawing.Point(755, 3);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(59, 20);
            this.tbDiscount.TabIndex = 4;
            // 
            // InvoiceProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InvoiceProductItem";
            this.Size = new System.Drawing.Size(932, 26);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFAT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown nUDTotal;
        private System.Windows.Forms.NumericUpDown nUDAmount;
        private System.Windows.Forms.ComboBox cbFAT;
        private AutoCompleteTextBox tbDescription;
        private System.Windows.Forms.CheckBox cbAdd;
        private System.Windows.Forms.CheckBox cbUpdate;
        private System.Windows.Forms.NumericUpDown nUDFAT;
        private AutoCompleteTextBox tbArticleID;
        private System.Windows.Forms.CheckBox cbPriceExFAT;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelNo;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbDiscount;
    }
}
