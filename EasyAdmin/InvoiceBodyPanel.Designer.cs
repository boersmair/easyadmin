namespace EasyAdmin
{
    partial class InvoiceBodyPanel
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
            this.nUDTotal = new System.Windows.Forms.NumericUpDown();
            this.nUDFAT2 = new System.Windows.Forms.NumericUpDown();
            this.nUDFAT1 = new System.Windows.Forms.NumericUpDown();
            this.nUDSubTotal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.rtbRemarks = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFAT2 = new System.Windows.Forms.Label();
            this.labelFAT1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceProductItem1 = new EasyAdmin.InvoiceProductItem();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFAT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFAT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSubTotal)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelProducts.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nUDTotal
            // 
            this.nUDTotal.DecimalPlaces = 2;
            this.nUDTotal.Location = new System.Drawing.Point(676, 92);
            this.nUDTotal.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.nUDTotal.Minimum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            -2147483648});
            this.nUDTotal.Name = "nUDTotal";
            this.nUDTotal.ReadOnly = true;
            this.nUDTotal.Size = new System.Drawing.Size(74, 20);
            this.nUDTotal.TabIndex = 4;
            // 
            // nUDFAT2
            // 
            this.nUDFAT2.DecimalPlaces = 2;
            this.nUDFAT2.Location = new System.Drawing.Point(676, 66);
            this.nUDFAT2.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.nUDFAT2.Minimum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            -2147483648});
            this.nUDFAT2.Name = "nUDFAT2";
            this.nUDFAT2.ReadOnly = true;
            this.nUDFAT2.Size = new System.Drawing.Size(74, 20);
            this.nUDFAT2.TabIndex = 3;
            // 
            // nUDFAT1
            // 
            this.nUDFAT1.DecimalPlaces = 2;
            this.nUDFAT1.Location = new System.Drawing.Point(676, 40);
            this.nUDFAT1.Maximum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            0});
            this.nUDFAT1.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.nUDFAT1.Name = "nUDFAT1";
            this.nUDFAT1.ReadOnly = true;
            this.nUDFAT1.Size = new System.Drawing.Size(74, 20);
            this.nUDFAT1.TabIndex = 2;
            // 
            // nUDSubTotal
            // 
            this.nUDSubTotal.DecimalPlaces = 2;
            this.nUDSubTotal.Location = new System.Drawing.Point(676, 14);
            this.nUDSubTotal.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this.nUDSubTotal.Minimum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            -2147483648});
            this.nUDSubTotal.Name = "nUDSubTotal";
            this.nUDSubTotal.ReadOnly = true;
            this.nUDSubTotal.Size = new System.Drawing.Size(74, 20);
            this.nUDSubTotal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "€";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "€";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(663, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "€";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(663, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "€";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.rtbRemarks);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.labelFAT2);
            this.panel1.Controls.Add(this.labelFAT1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nUDTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nUDFAT2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nUDFAT1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nUDSubTotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 125);
            this.panel1.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Extra tekst:";
            // 
            // rtbRemarks
            // 
            this.rtbRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbRemarks.ContextMenuStrip = this.contextMenuStrip1;
            this.rtbRemarks.Location = new System.Drawing.Point(0, 19);
            this.rtbRemarks.Name = "rtbRemarks";
            this.rtbRemarks.Size = new System.Drawing.Size(501, 106);
            this.rtbRemarks.TabIndex = 0;
            this.rtbRemarks.Text = "";
            this.rtbRemarks.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(594, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Totaal:";
            // 
            // labelFAT2
            // 
            this.labelFAT2.AutoSize = true;
            this.labelFAT2.Location = new System.Drawing.Point(594, 68);
            this.labelFAT2.Name = "labelFAT2";
            this.labelFAT2.Size = new System.Drawing.Size(61, 13);
            this.labelFAT2.TabIndex = 10;
            this.labelFAT2.Text = "BTW (21%)";
            // 
            // labelFAT1
            // 
            this.labelFAT1.AutoSize = true;
            this.labelFAT1.Location = new System.Drawing.Point(594, 40);
            this.labelFAT1.Name = "labelFAT1";
            this.labelFAT1.Size = new System.Drawing.Size(55, 13);
            this.labelFAT1.TabIndex = 9;
            this.labelFAT1.Text = "BTW (6%)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Subtotaal:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panelProducts);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(940, 401);
            this.panel4.TabIndex = 9;
            // 
            // panelProducts
            // 
            this.panelProducts.AutoScroll = true;
            this.panelProducts.Controls.Add(this.invoiceProductItem1);
            this.panelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProducts.Location = new System.Drawing.Point(0, 34);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(940, 367);
            this.panelProducts.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 34);
            this.panel2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(754, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Korting";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "Bijwerken";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Artikelnr.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Opslaan/";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Omschrijving";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(886, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "ex BTW";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(443, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Aantal";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(661, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Totaal incl. BTW";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(515, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Prijs";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(594, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "BTW totaal";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vetToolStripMenuItem,
            this.roodToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 48);
            // 
            // vetToolStripMenuItem
            // 
            this.vetToolStripMenuItem.Name = "vetToolStripMenuItem";
            this.vetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.vetToolStripMenuItem.Text = "Vet";
            this.vetToolStripMenuItem.Click += new System.EventHandler(this.vetToolStripMenuItem_Click);
            // 
            // roodToolStripMenuItem
            // 
            this.roodToolStripMenuItem.Name = "roodToolStripMenuItem";
            this.roodToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.roodToolStripMenuItem.Text = "Rood";
            this.roodToolStripMenuItem.Click += new System.EventHandler(this.roodToolStripMenuItem_Click);
            // 
            // invoiceProductItem1
            // 
            this.invoiceProductItem1.Location = new System.Drawing.Point(0, 3);
            this.invoiceProductItem1.Name = "invoiceProductItem1";
            this.invoiceProductItem1.Size = new System.Drawing.Size(932, 26);
            this.invoiceProductItem1.TabIndex = 0;
            // 
            // InvoiceBodyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "InvoiceBodyPanel";
            this.Size = new System.Drawing.Size(940, 526);
            ((System.ComponentModel.ISupportInitialize)(this.nUDTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFAT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFAT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSubTotal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panelProducts.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDTotal;
        private System.Windows.Forms.NumericUpDown nUDFAT2;
        private System.Windows.Forms.NumericUpDown nUDFAT1;
        private System.Windows.Forms.NumericUpDown nUDSubTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelFAT2;
        private System.Windows.Forms.Label labelFAT1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private InvoiceProductItem invoiceProductItem1;
        private System.Windows.Forms.RichTextBox rtbRemarks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roodToolStripMenuItem;
    }
}
