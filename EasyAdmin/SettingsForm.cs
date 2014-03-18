using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyAdmin
{
    public partial class SettingsForm : Form
    {
        public class TextBoxText
        {
            private string text;
            private TextBox textbox;
            public TextBoxText(TextBox Textbox, string Text)
            {
                textbox = Textbox;
                text = Text;
            }

            public TextBox Textbox
            {
                get { return textbox; }
            }

            public string Text
            {
                get { return text; }
            }
        }
        public class NumericUDValue
        {
            private decimal value;
            private NumericUpDown numericupd;
            public NumericUDValue(NumericUpDown NumericUD, decimal val)
            {
                numericupd = NumericUD;
                value = val;
            }

            public NumericUpDown NumericUD
            {
                get { return numericupd; }
            }

            public decimal Value
            {
                get { return value; }
            }
        }
        public class CheckBoxCheckedS
        {
            private bool checkedst;
            private CheckBox checkb;
            public CheckBoxCheckedS(CheckBox CheckB, bool CheckedSt)
            {
                checkb = CheckB;
                checkedst = CheckedSt;
            }

            public CheckBox CheckB
            {
                get { return checkb; }
            }

            public bool CheckedSt
            {
                get { return checkedst; }
            }
        }

        private List<TextBoxText> TextBoxData = new List<TextBoxText>();
        private List<NumericUDValue> NumericValue = new List<NumericUDValue>();
        private List<CheckBoxCheckedS> CheckBValue = new List<CheckBoxCheckedS>();

        public SettingsForm()
        {
            InitializeComponent();
            TextBoxData.Clear();
            TextBoxData.Add(new TextBoxText(tbAFIS12, tbAFIS12.Text));
            TextBoxData.Add(new TextBoxText(tbInvoice, tbInvoice.Text));
            TextBoxData.Add(new TextBoxText(tbInvoiceDiscount, tbInvoiceDiscount.Text));
            TextBoxData.Add(new TextBoxText(tbInvoiceReseller, tbInvoiceReseller.Text));
            TextBoxData.Add(new TextBoxText(tbAFIS12Save, tbAFIS12Save.Text));
            TextBoxData.Add(new TextBoxText(tbInvoiceSave, tbInvoiceSave.Text));
            TextBoxData.Add(new TextBoxText(tbInvoiceResellerSave, tbInvoiceResellerSave.Text));
            TextBoxData.Add(new TextBoxText(tbHeader, tbHeader.Text));
            TextBoxData.Add(new TextBoxText(tbPDFOutputAFIS, tbPDFOutputAFIS.Text));
            TextBoxData.Add(new TextBoxText(tbPDFOutputInvoice, tbPDFOutputInvoice.Text));
            TextBoxData.Add(new TextBoxText(tbEmailFrom, tbEmailFrom.Text));
            TextBoxData.Add(new TextBoxText(tbEmailSMTPServer, tbEmailSMTPServer.Text));
            TextBoxData.Add(new TextBoxText(tbEmailSMTPUser, tbEmailSMTPUser.Text));
            TextBoxData.Add(new TextBoxText(tbEmailSMTPPassw, tbEmailSMTPPassw.Text));
            TextBoxData.Add(new TextBoxText(tbEmailCCV, tbEmailCCV.Text));

            NumericValue.Clear();
            NumericValue.Add(new NumericUDValue(nUDFATHigh, nUDFATHigh.Value));
            NumericValue.Add(new NumericUDValue(nUDFATLow, nUDFATLow.Value));
            NumericValue.Add(new NumericUDValue(nUDDecimals, nUDDecimals.Value));
            NumericValue.Add(new NumericUDValue(nUDInvoiceOffset, nUDInvoiceOffset.Value));
            NumericValue.Add(new NumericUDValue(nUDEmailSMTPPort, nUDEmailSMTPPort.Value));
            NumericValue.Add(new NumericUDValue(nUDEmailTimeout, nUDEmailTimeout.Value));

            CheckBValue.Clear();
            CheckBValue.Add(new CheckBoxCheckedS(cbAmountRemove0s, cbAmountRemove0s.Checked));
            CheckBValue.Add(new CheckBoxCheckedS(cbEmailSSL, cbEmailSSL.Checked));
            CheckBValue.Add(new CheckBoxCheckedS(cbStoreFolderYear, cbStoreFolderYear.Checked));
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            //save settings
            Properties.Settings.Default.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //restore data
            for (int i = 0; i < TextBoxData.Count; i++)
                TextBoxData[i].Textbox.Text = TextBoxData[i].Text;
            for (int i = 0; i < NumericValue.Count; i++)
                NumericValue[i].NumericUD.Value = NumericValue[i].Value;
            for (int i = 0; i < CheckBValue.Count; i++)
                CheckBValue[i].CheckB.Checked = CheckBValue[i].CheckedSt;
        }
    }
}
