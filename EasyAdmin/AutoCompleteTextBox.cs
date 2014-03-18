using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EasyAdmin
{
    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private Form _floatingform;
        private String[] _values;
        private String[] _valueslower;
        private String _formerValue = String.Empty;
        public delegate void SelectedDublicateChange(object sender, int item);
        public SelectedDublicateChange OnSelectedDublicateChange;
        private Control _anchorControl;
        private List<Control> _parentChain = new List<Control>();

        public AutoCompleteTextBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox();
            _floatingform = new Form();
            _floatingform.TopMost = true;
            _floatingform.ShowInTaskbar = false;
            _floatingform.FormBorderStyle = FormBorderStyle.None;
            _listBox.Dock = DockStyle.Fill;
            _floatingform.Controls.Add(_listBox);
            KeyDown += this_KeyDown;
            KeyUp += this_KeyUp;
            Leave += this_Leave;
            _listBox.SelectedIndexChanged += new EventHandler(lbSelectedIndexChanged);
            _listBox.MouseDoubleClick += new MouseEventHandler(lbMouseDoubleClickEvent);
            _listBox.KeyDown += new KeyEventHandler(lbKeyDown);
            _anchorControl = this;
            BuildChain();
        }

        /// <summary>
        /// Build chain to catch main window events
        /// </summary>
        protected void BuildChain()
        {
            foreach (var item in _parentChain)
            {
                item.LocationChanged -= ControlLocationChanged;
                item.ParentChanged -= ControlParentChanged;
            }

            var current = _anchorControl;

            while (current != null)
            {
                _parentChain.Add(current);
                current = current.Parent;
            }

            foreach (var item in _parentChain)
            {
                item.LocationChanged += ControlLocationChanged;
                item.ParentChanged += ControlParentChanged;
            }
        }

        /// <summary>
        /// Parent of the control is changed. We need to rebuild the event chain list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ControlParentChanged(object sender, EventArgs e)
        {
            BuildChain();
            ControlLocationChanged(sender, e);
        }

        /// <summary>
        /// Main windows is moved. We also need to move the popup form containing the listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ControlLocationChanged(object sender, EventArgs e)
        {
            // Update Location of Form
            if (_anchorControl.Parent != null)
            {
                //var screenLoc = _anchorControl.Parent.PointToScreen(_anchorControl.Location);
                if (_floatingform.Visible)
                    _floatingform.Location = Parent.PointToScreen(new Point(Left, Top + Height));
            }
        }

        /// <summary>
        /// Hide the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void this_Leave(object sender, EventArgs e)
        {
            if (_floatingform.Visible)
                ResetListBox();
        }
        
        /// <summary>
        /// Show the list box.
        /// </summary>
        private void ShowListBox()
        {
            _floatingform.Show();
            _floatingform.BringToFront();
            _floatingform.Location = Parent.PointToScreen(new Point(Left, Top + Height));
        }

        private void ResetListBox()
        {
            _floatingform.Hide();
        }

        private void lbSelectedIndexChanged(object sender, EventArgs e)
        {
            if (AutoCompleteMode == System.Windows.Forms.AutoCompleteMode.None)
                return;
            if ((_floatingform.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count))
            {
                if (Text == (string)_listBox.SelectedItem)
                {
                    if (OnSelectedDublicateChange != null)
                    {
                        int i = _listBox.Items.IndexOf(_listBox.SelectedItem);
                        OnSelectedDublicateChange(this, _listBox.SelectedIndex-i);
                    }
                }
                else
                    Text = (string)_listBox.SelectedItem;
            }
        }

        private void lbMouseDoubleClickEvent(object sender, MouseEventArgs e)
        {
            if (AutoCompleteMode == System.Windows.Forms.AutoCompleteMode.None)
                return;
            if (_floatingform.Visible)
                ResetListBox();
        }

        private void lbKeyDown(object sender, KeyEventArgs e)
        {
            if (AutoCompleteMode == System.Windows.Forms.AutoCompleteMode.None)
                return;
            if (e.KeyCode == Keys.Enter)
            {
                if (_floatingform.Visible)
                    ResetListBox();
            }
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (AutoCompleteMode == System.Windows.Forms.AutoCompleteMode.None)
                return;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter || e.KeyCode==Keys.Escape)
                return;
            UpdateListBox();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            if (AutoCompleteMode == System.Windows.Forms.AutoCompleteMode.None)
                return;
            switch (e.KeyCode)
            {
                case Keys.Escape:
                case Keys.Enter:
                    {
                        if (_floatingform.Visible)
                            ResetListBox();
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_floatingform.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                        {
                            _listBox.SelectedIndex++;
                            Text = (string)_listBox.SelectedItem;
                        }

                        break;
                    }
                case Keys.Up:
                    {
                        if ((_floatingform.Visible) && (_listBox.SelectedIndex > 0))
                        {
                            _listBox.SelectedIndex--;
                            Text = (string)_listBox.SelectedItem;
                        }

                        break;
                    }
            }
        }


        /// <summary>
        /// Update the item in the listbox (possible matched, case insensitive, any location in the string)
        /// </summary>
        private void UpdateListBox()
        {
            if (Text == _formerValue) return;
            _formerValue = Text;
            String word = Text;// GetWord();
            String wordlower = word.ToLower();

            if (_valueslower != null && _values != null && word.Length > 0)
            {
                String[] matches = Array.FindAll(_valueslower, x => (x.Contains(wordlower)));

                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.Items.Clear();
                    //get values for listbox (possible matches)
                    for (int i = 0; i < _values.Length; i++)
                    {
                        if (_valueslower[i].Contains(wordlower))
                            _listBox.Items.Add(_values[i]);
                    }
                    int maxh = 0;
                    int maxw = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {                           
                            // we add a little extra space by using '___'
                            int itemWidth = (int)graphics.MeasureString(((String)_listBox.Items[i]) + "___", _listBox.Font).Width;
                            maxw = (maxw < itemWidth) ? itemWidth : maxw;
                        }
                    }
                    maxh = _listBox.GetItemHeight(0) * (_listBox.Items.Count+1); //determine height
                    _floatingform.Width = maxw > Width ? Width : maxw; //limit width to textbox width
                    _floatingform.Height = maxh > 300 ? 300 : maxh; //limit to max 300px
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        /// <summary>
        /// returns number of selected duplicate if available. 0 in other cases.
        /// </summary>
        public int SelectedDuplicate
        {
            get 
            {
                if (!_floatingform.Visible || _listBox.Items.Count <= 0 || _listBox.SelectedIndex < 0)
                    return 0;
                return FindSelectedDuplicateIdx(_listBox.SelectedItem);
            }
        }

        /// <summary>
        /// Find the duplicate number.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int FindSelectedDuplicateIdx(object text)
        {
            int i = 0;
            int count = _listBox.Items.Count;

            for (int t = 0; t < count && t <= _listBox.SelectedIndex; t++)
            {
                if (_listBox.Items[t].Equals(text))
                    i++;
            }
            return i>0?i-1:0;
        }

        /// <summary>
        /// Set or get the autocomplete values.
        /// </summary>
        public String[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                if (_values != null)
                {                    
                    if (_values.Any(c => c==null))
                        _valueslower = null;
                    else
                        _valueslower = _values.Select(c => c.ToLower()).ToArray();
                }
                else
                    _valueslower = null;
            }
        }

        /// <summary>
        /// Get autocomplete values in lower case
        /// </summary>
        public String[] ValuesLower
        {
            get
            {
                return _valueslower;
            }
        }              
    }
}
