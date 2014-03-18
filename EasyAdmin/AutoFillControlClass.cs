using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace EasyAdmin
{
    public class AutoFillHelperClass : IAutoFillHelper
    {
        /// <summary>
        /// local class containing reference to a textbox and a database table fieldid
        /// </summary>
        public class TextBoxContainer
        {
            private TextBox tb=null;
            private AutoCompleteTextBox actb=null;
            private int fieldid;
            private DataTable datatable;
            private DataBaseTableClassBase dbtable;

            /// <summary>
            /// constructor for textbox container. Private fields must be initialized
            /// </summary>
            /// <param name="TextB"></param>
            /// <param name="FieldId"></param>
            /// <param name="Table"></param>
            /// <param name="Datatable"></param>
            public TextBoxContainer(TextBox TextB, int FieldId, DataBaseTableClassBase Table, DataTable Datatable)
            {
                tb = TextB;
                this.fieldid = FieldId;
                dbtable = Table;
                datatable = Datatable;                
            }
            public TextBoxContainer(TextBox TextB, int FieldId)
            {
                tb = TextB;
                this.fieldid = FieldId;
                dbtable = null;
                datatable = null;
            }
            /// <summary>
            /// constructor for autocompletetextbox container. Private fields must be initialized
            /// </summary>
            /// <param name="TextB"></param>
            /// <param name="FieldId"></param>
            /// <param name="Table"></param>
            /// <param name="Datatable"></param>
            public TextBoxContainer(AutoCompleteTextBox TextB, int FieldId, DataBaseTableClassBase Table, DataTable Datatable)
            {
                actb = TextB;
                this.fieldid = FieldId;
                dbtable = Table;
                datatable = Datatable;
            }
            public TextBoxContainer(AutoCompleteTextBox TextB, int FieldId)
            {
                actb = TextB;
                this.fieldid = FieldId;
                dbtable = null;
                datatable = null;
            }

            /// <summary>
            /// Get reference to (autocomplete)textbox
            /// </summary>
            public TextBox TextB
            {
                get { return tb!=null?tb:actb; }
            }

            public AutoCompleteTextBox ACTextTB
            {
                get { return actb; }
            }

            /// <summary>
            /// Get database table field id
            /// </summary>
            public int FieldId
            {
                get { return fieldid; }
            }

            public DataTable Datatable
            {
                get { return datatable; }
                set { datatable = value;}
            }
            public DataBaseTableClassBase DBTable
            {
                get { return dbtable; }
                set { dbtable = value;}
            }

            public void SetAutoCompleteValues(string[] values)
            {
                if (tb!=null)
                {
                    tb.AutoCompleteCustomSource.Clear();
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource.AddRange(values);
                }
                else
                {
                    actb.Values = values;
                }
            }

            public int AutoCompleteValueIndexOf(string svalue)
            {
                if (tb != null)
                {
                    return tb.AutoCompleteCustomSource.IndexOf(svalue);
                }
                else
                {
                    return Array.IndexOf(actb.Values, svalue);
                }
            }


            public string AutoCompleteValueByIndex(int i)
            {
                if (tb != null)
                    return tb.AutoCompleteCustomSource[i];
                else if (actb != null)
                    return actb.Values[i];
                else
                    return "";
            }
        }
 
        public List<TextBoxContainer> ListTB = new List<TextBoxContainer>();
        public DataBaseClass DBRef;
        private bool autofilldisabled = true;
        private bool avoidrecursivetbcalls = false;
        public delegate void CustomTextBoxChange(object sender, EventArgs e);
        public delegate void FieldFound(object sender, int idx);
        public FieldFound OnFieldFound;
        public CustomTextBoxChange OnPreTextBoxChange;
        public CustomTextBoxChange OnPostTextBoxChange;
        public delegate void NoFieldFound(object sender);
        public NoFieldFound OnNoFieldFound;

        /// <summary>
        /// Add text box text change events
        /// </summary>
        public void SetTBEvents()
        {
            // add text box events
            for (int t = 0; t < ListTB.Count; t++)
            {
                ListTB[t].TextB.TextChanged += new System.EventHandler(this.tb_TextChanged);
                if (ListTB[t].ACTextTB != null)
                    ListTB[t].ACTextTB.OnSelectedDublicateChange = AutoCompleteDuplicateChanged;
            }
         }

        /// <summary>
        /// Set the autocomplet mode of the text boxes
        /// </summary>
        /// <param name="mode"></param>
        public void SetAutoCompleteMode(AutoCompleteMode mode)
        {
            for (int t = 0; t < ListTB.Count; t++)
            {
                ListTB[t].TextB.AutoCompleteMode = mode;
            }
        }
        /// <summary>
        /// Update Auto file value due to data table update. 
        /// </summary>
        public void UpdateAutFillData()
        {
            for (int t = 0; t < ListTB.Count; t++)
            {
                if (ListTB[t].Datatable == null || ListTB[t].DBTable == null)
                    continue;
                ListTB[t].SetAutoCompleteValues(ListTB[t].Datatable.AsEnumerable().Select<System.Data.DataRow, String>(x => x.Field<String>(ListTB[t].DBTable.FieldNames[ListTB[t].FieldId])).ToArray());
            }
        }

        /// <summary>
        /// A text field is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (OnPreTextBoxChange != null)
                OnPreTextBoxChange(sender, e);
            if (autofilldisabled || avoidrecursivetbcalls) return; //avoid recursive calls (stackoverflow)

            //find match
            int i = -1;
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length > 0)
            {
                if (sender.GetType() == typeof(AutoCompleteTextBox)) //other type of textbox (custom autocompletetextbox)
                {
                    i = FindSelectedIndex(((AutoCompleteTextBox)sender).Values, tb.Text, ((AutoCompleteTextBox)sender).SelectedDuplicate);
                }
                else
                {
                    //check if available in database
                    i = tb.AutoCompleteCustomSource.IndexOf(tb.Text);
                    if (i >= 0) //match found, identical values not support by default textbox
                    {
                        ;
                    }
                }
            }
            UpdateFields(sender, i);

            if (OnPostTextBoxChange != null)
                OnPostTextBoxChange(sender, e);
        }

        //some field will have the same text, but a different database index.
        void AutoCompleteDuplicateChanged(object sender, int seldub)
        {
            int i = FindSelectedIndex(((AutoCompleteTextBox)sender).Values, ((AutoCompleteTextBox)sender).Text, seldub);
            if (i >= 0)
                UpdateFields(sender, i);
        }

        /// <summary>
        /// Find the selected index. Check if a duplicate is selected.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="text"></param>
        /// <param name="duplcateidx"></param>
        /// <returns></returns>
        private int FindSelectedIndex(string[] values, string text, int duplcateidx)
        {
            int i = -1;
            int found = 0;
            int count = values.Length;

            for (int t = 0; t < count; t++)
            {
                if(text.Equals(values[t]))
                {
                    i = t;
                    if (found == duplcateidx || duplcateidx<0)
                        break;
                    found++;
                }
            }
            return i;
        }


        /// <summary>
        /// Update all other text fields if match is found
        /// </summary>
        /// <param name="tbChanged"></param>
        private void UpdateFields(object sender, int i)
        {
            if (i >= 0) //yes, found, update other fields
            {
                avoidrecursivetbcalls = true; //avoid recursive calls
                //update textboxes
                for (int t = 0; t < ListTB.Count; t++)
                {
                    if (sender == ListTB[t].TextB)//do no change changing field :)
                        continue;
                    ListTB[t].TextB.Text = ListTB[t].AutoCompleteValueByIndex(i);
                }
                avoidrecursivetbcalls = false;
                if (OnFieldFound != null)
                    OnFieldFound(this, i);
            }
            else
            {
                if (OnNoFieldFound != null)
                    OnNoFieldFound(this);
            }
        }

        /// <summary>
        /// Autofill disable control
        /// </summary>
        public bool AutoFillDisable
        {
            set { autofilldisabled = value; }
        }

    }

    public interface IAutoFillHelper
    {
        //public void UpdateDBSettings(DataBaseClass db);
    }

}
