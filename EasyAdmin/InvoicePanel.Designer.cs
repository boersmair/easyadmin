namespace EasyAdmin
{
    partial class InvoicePanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.nUDPrintCount = new System.Windows.Forms.NumericUpDown();
            this.cbEmail = new System.Windows.Forms.CheckBox();
            this.cbCloseWord = new System.Windows.Forms.CheckBox();
            this.cbPrint = new System.Windows.Forms.CheckBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.cbSaveInvoicePDF = new System.Windows.Forms.CheckBox();
            this.tbPayment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReselInvoice = new System.Windows.Forms.CheckBox();
            this.cbSaveInvoiceDoc = new System.Windows.Forms.CheckBox();
            this.btnGenerateHead = new System.Windows.Forms.Button();
            this.btnGenerateIncoice = new System.Windows.Forms.Button();
            this.invoiceBodyPanel1 = new EasyAdmin.InvoiceBodyPanel();
            this.invoiceHeaderPanel1 = new EasyAdmin.InvoiceHeaderPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPrintCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nUDPrintCount);
            this.panel1.Controls.Add(this.cbEmail);
            this.panel1.Controls.Add(this.cbCloseWord);
            this.panel1.Controls.Add(this.cbPrint);
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.btnClearFields);
            this.panel1.Controls.Add(this.cbSaveInvoicePDF);
            this.panel1.Controls.Add(this.tbPayment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbReselInvoice);
            this.panel1.Controls.Add(this.cbSaveInvoiceDoc);
            this.panel1.Controls.Add(this.btnGenerateHead);
            this.panel1.Controls.Add(this.btnGenerateIncoice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 731);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 62);
            this.panel1.TabIndex = 2;
            // 
            // nUDPrintCount
            // 
            this.nUDPrintCount.Location = new System.Drawing.Point(316, 4);
            this.nUDPrintCount.Name = "nUDPrintCount";
            this.nUDPrintCount.Size = new System.Drawing.Size(54, 20);
            this.nUDPrintCount.TabIndex = 12;
            this.nUDPrintCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Location = new System.Drawing.Point(251, 40);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(54, 17);
            this.cbEmail.TabIndex = 11;
            this.cbEmail.Text = "E-mail";
            this.cbEmail.UseVisualStyleBackColor = true;
            // 
            // cbCloseWord
            // 
            this.cbCloseWord.AutoSize = true;
            this.cbCloseWord.Location = new System.Drawing.Point(251, 23);
            this.cbCloseWord.Name = "cbCloseWord";
            this.cbCloseWord.Size = new System.Drawing.Size(85, 17);
            this.cbCloseWord.TabIndex = 10;
            this.cbCloseWord.Text = "Word sluiten";
            this.cbCloseWord.UseVisualStyleBackColor = true;
            // 
            // cbPrint
            // 
            this.cbPrint.AutoSize = true;
            this.cbPrint.Location = new System.Drawing.Point(251, 6);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(59, 17);
            this.cbPrint.TabIndex = 9;
            this.cbPrint.Text = "Printen";
            this.cbPrint.UseVisualStyleBackColor = true;
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(483, 34);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEmail.TabIndex = 8;
            this.btnEmail.Text = "E-mail";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.Location = new System.Drawing.Point(483, 5);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(75, 23);
            this.btnClearFields.TabIndex = 7;
            this.btnClearFields.Text = "Wis velden";
            this.btnClearFields.UseVisualStyleBackColor = true;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // cbSaveInvoicePDF
            // 
            this.cbSaveInvoicePDF.AutoSize = true;
            this.cbSaveInvoicePDF.Location = new System.Drawing.Point(108, 40);
            this.cbSaveInvoicePDF.Name = "cbSaveInvoicePDF";
            this.cbSaveInvoicePDF.Size = new System.Drawing.Size(129, 17);
            this.cbSaveInvoicePDF.TabIndex = 6;
            this.cbSaveInvoicePDF.Text = "Factuur opslaan (.pdf)";
            this.cbSaveInvoicePDF.UseVisualStyleBackColor = true;
            // 
            // tbPayment
            // 
            this.tbPayment.Location = new System.Drawing.Point(642, 6);
            this.tbPayment.Name = "tbPayment";
            this.tbPayment.Size = new System.Drawing.Size(295, 20);
            this.tbPayment.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Betaalwijze:";
            // 
            // cbReselInvoice
            // 
            this.cbReselInvoice.AutoSize = true;
            this.cbReselInvoice.Location = new System.Drawing.Point(108, 5);
            this.cbReselInvoice.Name = "cbReselInvoice";
            this.cbReselInvoice.Size = new System.Drawing.Size(127, 17);
            this.cbReselInvoice.TabIndex = 3;
            this.cbReselInvoice.Text = "Doorleverings factuur";
            this.cbReselInvoice.UseVisualStyleBackColor = true;
            // 
            // cbSaveInvoiceDoc
            // 
            this.cbSaveInvoiceDoc.AutoSize = true;
            this.cbSaveInvoiceDoc.Checked = true;
            this.cbSaveInvoiceDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveInvoiceDoc.Location = new System.Drawing.Point(108, 23);
            this.cbSaveInvoiceDoc.Name = "cbSaveInvoiceDoc";
            this.cbSaveInvoiceDoc.Size = new System.Drawing.Size(137, 17);
            this.cbSaveInvoiceDoc.TabIndex = 2;
            this.cbSaveInvoiceDoc.Text = "Factuur opslaan (.docx)";
            this.cbSaveInvoiceDoc.UseVisualStyleBackColor = true;
            // 
            // btnGenerateHead
            // 
            this.btnGenerateHead.Location = new System.Drawing.Point(9, 31);
            this.btnGenerateHead.Name = "btnGenerateHead";
            this.btnGenerateHead.Size = new System.Drawing.Size(94, 23);
            this.btnGenerateHead.TabIndex = 1;
            this.btnGenerateHead.Text = "Maak briefhoofd";
            this.btnGenerateHead.UseVisualStyleBackColor = true;
            this.btnGenerateHead.Click += new System.EventHandler(this.btnGenerateHead_Click);
            // 
            // btnGenerateIncoice
            // 
            this.btnGenerateIncoice.Location = new System.Drawing.Point(9, 4);
            this.btnGenerateIncoice.Name = "btnGenerateIncoice";
            this.btnGenerateIncoice.Size = new System.Drawing.Size(94, 23);
            this.btnGenerateIncoice.TabIndex = 0;
            this.btnGenerateIncoice.Text = "Maak factuur";
            this.btnGenerateIncoice.UseVisualStyleBackColor = true;
            this.btnGenerateIncoice.Click += new System.EventHandler(this.btnGenerateIncoice_Click);
            // 
            // invoiceBodyPanel1
            // 
            this.invoiceBodyPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceBodyPanel1.Location = new System.Drawing.Point(0, 263);
            this.invoiceBodyPanel1.Name = "invoiceBodyPanel1";
            this.invoiceBodyPanel1.Size = new System.Drawing.Size(957, 468);
            this.invoiceBodyPanel1.TabIndex = 1;
            // 
            // invoiceHeaderPanel1
            // 
            this.invoiceHeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.invoiceHeaderPanel1.Location = new System.Drawing.Point(0, 0);
            this.invoiceHeaderPanel1.Name = "invoiceHeaderPanel1";
            this.invoiceHeaderPanel1.Size = new System.Drawing.Size(957, 263);
            this.invoiceHeaderPanel1.TabIndex = 0;
            // 
            // InvoicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.invoiceBodyPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.invoiceHeaderPanel1);
            this.Name = "InvoicePanel";
            this.Size = new System.Drawing.Size(957, 793);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPrintCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InvoiceHeaderPanel invoiceHeaderPanel1;
        private InvoiceBodyPanel invoiceBodyPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbSaveInvoiceDoc;
        private System.Windows.Forms.Button btnGenerateHead;
        private System.Windows.Forms.Button btnGenerateIncoice;
        private System.Windows.Forms.CheckBox cbReselInvoice;
        private System.Windows.Forms.TextBox tbPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSaveInvoicePDF;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.CheckBox cbEmail;
        private System.Windows.Forms.CheckBox cbCloseWord;
        private System.Windows.Forms.CheckBox cbPrint;
        private System.Windows.Forms.NumericUpDown nUDPrintCount;

    }
}
