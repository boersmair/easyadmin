namespace EasyAdmin
{
    partial class CreateAFIS12
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelAFIS12 = new System.Windows.Forms.Panel();
            this.btnGenerateDoc = new System.Windows.Forms.Button();
            this.cbCreateEmail = new System.Windows.Forms.CheckBox();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDFormNo = new System.Windows.Forms.NumericUpDown();
            this.cbSavePDF = new System.Windows.Forms.CheckBox();
            this.cbSaveAsDoc = new System.Windows.Forms.CheckBox();
            this.createAFIS12Header1 = new EasyAdmin.CreateAFIS12Header();
            this.cbPrint = new System.Windows.Forms.CheckBox();
            this.cbAutoClose = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFormNo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelAFIS12);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(915, 315);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AFIS12";
            // 
            // panelAFIS12
            // 
            this.panelAFIS12.AutoScroll = true;
            this.panelAFIS12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAFIS12.Location = new System.Drawing.Point(3, 16);
            this.panelAFIS12.Name = "panelAFIS12";
            this.panelAFIS12.Size = new System.Drawing.Size(909, 296);
            this.panelAFIS12.TabIndex = 0;
            // 
            // btnGenerateDoc
            // 
            this.btnGenerateDoc.Location = new System.Drawing.Point(15, 3);
            this.btnGenerateDoc.Name = "btnGenerateDoc";
            this.btnGenerateDoc.Size = new System.Drawing.Size(99, 23);
            this.btnGenerateDoc.TabIndex = 4;
            this.btnGenerateDoc.Text = "Maak formulier";
            this.btnGenerateDoc.UseVisualStyleBackColor = true;
            this.btnGenerateDoc.Click += new System.EventHandler(this.btnGenerateDoc_Click);
            // 
            // cbCreateEmail
            // 
            this.cbCreateEmail.AutoSize = true;
            this.cbCreateEmail.Checked = true;
            this.cbCreateEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCreateEmail.Location = new System.Drawing.Point(133, 7);
            this.cbCreateEmail.Name = "cbCreateEmail";
            this.cbCreateEmail.Size = new System.Drawing.Size(83, 17);
            this.cbCreateEmail.TabIndex = 5;
            this.cbCreateEmail.Text = "Maak e-mail";
            this.cbCreateEmail.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(620, 11);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.Text = "Verwijder alles";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAutoClose);
            this.panel1.Controls.Add(this.cbPrint);
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nUDFormNo);
            this.panel1.Controls.Add(this.cbSavePDF);
            this.panel1.Controls.Add(this.cbSaveAsDoc);
            this.panel1.Controls.Add(this.btnGenerateDoc);
            this.panel1.Controls.Add(this.btnDeleteAll);
            this.panel1.Controls.Add(this.cbCreateEmail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 58);
            this.panel1.TabIndex = 7;
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(515, 11);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(99, 23);
            this.btnEmail.TabIndex = 11;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Formulier nr:";
            // 
            // nUDFormNo
            // 
            this.nUDFormNo.Location = new System.Drawing.Point(458, 11);
            this.nUDFormNo.Name = "nUDFormNo";
            this.nUDFormNo.Size = new System.Drawing.Size(33, 20);
            this.nUDFormNo.TabIndex = 9;
            this.nUDFormNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbSavePDF
            // 
            this.cbSavePDF.AutoSize = true;
            this.cbSavePDF.Location = new System.Drawing.Point(233, 32);
            this.cbSavePDF.Name = "cbSavePDF";
            this.cbSavePDF.Size = new System.Drawing.Size(92, 17);
            this.cbSavePDF.TabIndex = 8;
            this.cbSavePDF.Text = "Opslaan (.pdf)";
            this.cbSavePDF.UseVisualStyleBackColor = true;
            // 
            // cbSaveAsDoc
            // 
            this.cbSaveAsDoc.AutoSize = true;
            this.cbSaveAsDoc.Checked = true;
            this.cbSaveAsDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveAsDoc.Location = new System.Drawing.Point(233, 9);
            this.cbSaveAsDoc.Name = "cbSaveAsDoc";
            this.cbSaveAsDoc.Size = new System.Drawing.Size(100, 17);
            this.cbSaveAsDoc.TabIndex = 7;
            this.cbSaveAsDoc.Text = "Opslaan (.docx)";
            this.cbSaveAsDoc.UseVisualStyleBackColor = true;
            // 
            // createAFIS12Header1
            // 
            this.createAFIS12Header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.createAFIS12Header1.Location = new System.Drawing.Point(0, 0);
            this.createAFIS12Header1.Name = "createAFIS12Header1";
            this.createAFIS12Header1.Size = new System.Drawing.Size(915, 305);
            this.createAFIS12Header1.TabIndex = 8;
            // 
            // cbPrint
            // 
            this.cbPrint.AutoSize = true;
            this.cbPrint.Checked = true;
            this.cbPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrint.Location = new System.Drawing.Point(133, 34);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(59, 17);
            this.cbPrint.TabIndex = 12;
            this.cbPrint.Text = "Printen";
            this.cbPrint.UseVisualStyleBackColor = true;
            // 
            // cbAutoClose
            // 
            this.cbAutoClose.AutoSize = true;
            this.cbAutoClose.Checked = true;
            this.cbAutoClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoClose.Location = new System.Drawing.Point(15, 32);
            this.cbAutoClose.Name = "cbAutoClose";
            this.cbAutoClose.Size = new System.Drawing.Size(85, 17);
            this.cbAutoClose.TabIndex = 13;
            this.cbAutoClose.Text = "Word sluiten";
            this.cbAutoClose.UseVisualStyleBackColor = true;
            // 
            // CreateAFIS12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.createAFIS12Header1);
            this.Controls.Add(this.panel1);
            this.Name = "CreateAFIS12";
            this.Size = new System.Drawing.Size(915, 678);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFormNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panelAFIS12;
        private System.Windows.Forms.Button btnGenerateDoc;
        private System.Windows.Forms.CheckBox cbCreateEmail;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbSavePDF;
        private System.Windows.Forms.CheckBox cbSaveAsDoc;
        private CreateAFIS12Header createAFIS12Header1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDFormNo;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.CheckBox cbAutoClose;
        private System.Windows.Forms.CheckBox cbPrint;
    }
}
