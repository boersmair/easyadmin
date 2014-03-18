namespace EasyAdmin
{
    partial class CreateAFIS12Line
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAFIS12Line));
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.tbPassNumber = new System.Windows.Forms.TextBox();
            this.nupTicketNo = new System.Windows.Forms.NumericUpDown();
            this.btnDelete = new System.Windows.Forms.Button();
            this.nupOrder = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbACCustomName = new EasyAdmin.AutoCompleteTextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupTicketNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupOrder)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(298, 3);
            this.tbDate.MaxLength = 4;
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(44, 20);
            this.tbDate.TabIndex = 2;
            // 
            // tbProductCode
            // 
            this.tbProductCode.AutoCompleteCustomSource.AddRange(new string[] {
            "01",
            "02",
            "04",
            "06",
            "21",
            "36",
            "37",
            "38"});
            this.tbProductCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbProductCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbProductCode.Location = new System.Drawing.Point(348, 3);
            this.tbProductCode.MaxLength = 2;
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.Size = new System.Drawing.Size(44, 20);
            this.tbProductCode.TabIndex = 3;
            // 
            // tbPassNumber
            // 
            this.tbPassNumber.Location = new System.Drawing.Point(218, 3);
            this.tbPassNumber.MaxLength = 7;
            this.tbPassNumber.Name = "tbPassNumber";
            this.tbPassNumber.Size = new System.Drawing.Size(74, 20);
            this.tbPassNumber.TabIndex = 1;
            // 
            // nupTicketNo
            // 
            this.nupTicketNo.Location = new System.Drawing.Point(3, 3);
            this.nupTicketNo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nupTicketNo.Name = "nupTicketNo";
            this.nupTicketNo.Size = new System.Drawing.Size(59, 20);
            this.nupTicketNo.TabIndex = 7;
            this.nupTicketNo.Value = new decimal(new int[] {
            123400,
            0,
            0,
            0});
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(713, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(20, 19);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // nupOrder
            // 
            this.nupOrder.Location = new System.Drawing.Point(673, 3);
            this.nupOrder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupOrder.Name = "nupOrder";
            this.nupOrder.Size = new System.Drawing.Size(34, 20);
            this.nupOrder.TabIndex = 8;
            this.nupOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupOrder.Visible = false;
            this.nupOrder.ValueChanged += new System.EventHandler(this.nupOrder_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Controls.Add(this.nupTicketNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.nupOrder, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbPassNumber, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbProductCode, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbACCustomName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbPrice, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbAmount, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbTotal, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 26);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tbACCustomName
            // 
            this.tbACCustomName.Location = new System.Drawing.Point(68, 3);
            this.tbACCustomName.Name = "tbACCustomName";
            this.tbACCustomName.Size = new System.Drawing.Size(144, 20);
            this.tbACCustomName.TabIndex = 0;
            this.tbACCustomName.Values = null;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(398, 3);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(84, 20);
            this.tbPrice.TabIndex = 4;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(488, 3);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(84, 20);
            this.tbAmount.TabIndex = 5;
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(578, 3);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(89, 20);
            this.tbTotal.TabIndex = 6;
            // 
            // CreateAFIS12Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreateAFIS12Line";
            this.Size = new System.Drawing.Size(737, 26);
            ((System.ComponentModel.ISupportInitialize)(this.nupTicketNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupOrder)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.TextBox tbPassNumber;
        private System.Windows.Forms.NumericUpDown nupTicketNo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.NumericUpDown nupOrder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AutoCompleteTextBox tbACCustomName;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbTotal;
    }
}
