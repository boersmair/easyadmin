using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace EasyAdmin
{
    public partial class DataImportForm : Form
    {
        private DataBaseClass db;
        private const string ABORT = "Afbreken";
        private const string STARTIMPORT = "Start importeren";
        bool importaborted = false;

        public DataImportForm(DataBaseClass db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(openFileDialog1.FileName.EndsWith(".mdb"))
                {
                    labelFileName.Text = openFileDialog1.FileName;
                    OleDbConnection conn;
                    string constring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + openFileDialog1.FileName + ";Jet OLEDB:Database Password=" + tbPassword.Text;
                    DataSet dscustomer = new DataSet();
                    DataSet dsccv = new DataSet();


                    try
                    {
                        conn = new OleDbConnection(constring);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fout:\n"+ ex.Message);
                        return;
                    }

                    try
                    {

                        OleDbCommand cmdcustomer = new OleDbCommand("SELECT * FROM " + tbTableCustomers.Text, conn);
                        OleDbDataAdapter adaptercustomer = new OleDbDataAdapter(cmdcustomer);
                        OleDbCommand cmdccv = new OleDbCommand("SELECT * FROM " + tbTableCCV.Text, conn);
                        OleDbDataAdapter adapterccv = new OleDbDataAdapter(cmdccv);

                        conn.Open();
                        adaptercustomer.Fill(dscustomer, tbTableCustomers.Text);
                        adapterccv.Fill(dsccv, tbTableCCV.Text);
                        btnStartImport.Enabled = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fout:\n" + ex.Message);
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }

                    dataGridViewCustomers.DataSource = dscustomer.Tables[0];
                    dataGridViewCustomers.Sort(dataGridViewCustomers.Columns[1], ListSortDirection.Ascending);                    
                    dataGridViewCCV.DataSource = dsccv.Tables[0];
                    dataGridViewCCV.Sort(dataGridViewCCV.Columns[0], ListSortDirection.Ascending);
                    labelCustomerInfo.Text = string.Format("Aantal = {0}", dataGridViewCustomers.RowCount);
                    labelCustomerInfo.Visible = true;
                    labelCCVcardsInfo.Text = string.Format("Aantal = {0}", dataGridViewCCV.RowCount);
                    labelCCVcardsInfo.Visible = true;

                }
                else
                    MessageBox.Show("Bestandstype wordt (nog) niet ondersteund");

                /*
                 
             // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            foreach (DataTable dt in dta)
            {
            Console.WriteLine("Found data table {0}", dt.TableName);
            }
          
            // The next two lines show two different ways you can get the
            // count of tables in a dataset:
            Console.WriteLine("{0} tables in data set", myDataSet.Tables.Count);
            Console.WriteLine("{0} tables in data set", dta.Count);
            // The next several lines show how to get information on
            // a specific table by name from the dataset:
            Console.WriteLine("{0} rows in Categories table", myDataSet.Tables["Categories"].Rows.Count);
            // The column info is automatically fetched from the database,
            // so we can read it here:
            Console.WriteLine("{0} columns in Categories table", myDataSet.Tables["Categories"].Columns.Count);
            DataColumnCollection drc = myDataSet.Tables["Categories"].Columns;
            int i = 0;
            foreach (DataColumn dc in drc)
            {
                  // Print the column subscript, then the column's name
                  // and its data type:
                  Console.WriteLine("Column name[{0}] is {1}, of type {2}",i++ , dc.ColumnName, dc.DataType);
            }
            DataRowCollection dra = myDataSet.Tables["Categories"].Rows;
            foreach (DataRow dr in dra)
            {
                  // Print the CategoryID as a subscript, then the CategoryName:
                  Console.WriteLine("CategoryName[{0}] is {1}", dr[0], dr[1]);
            }
 
                 
                 */

            }
        }

        /// <summary>
        /// Start import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartImport_Click(object sender, EventArgs e)
        {
            if (btnStartImport.Text == ABORT)
            {
                importaborted = true;
                btnStartImport.Enabled = false;
                labelImportStatus.Text = "Aborting...";
            }
            else
            {
                int end = 0;
                int start = 0;
                bool exists;
                bool queryresult;
                int totalcustomimported = 0;
                int totalcustomskipped = 0;
                int totalcustomupdated = 0;
                int totalcardimported = 0;
                int totalcardskipped = 0;
                int totalcardupdated = 0;
                string logpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + AssemblyInfo.Company;
                string fileprefix = logpath + Path.DirectorySeparatorChar + "easyadminimport_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm") + "_";
                string logfile_skip = fileprefix + "skip.txt";
                string logfile_imported = fileprefix + "imported.txt";
                string logfile_updated = fileprefix + "updated.txt";
                StreamWriter log_skip = null;
                StreamWriter log_imp = null;
                StreamWriter log_upd = null;

                importaborted = false;
                btnStartImport.Text = ABORT;
                labelImportStatus.Text = "Starten met importeren";
                labelImportStatus.Visible = true;
                labelStatusEnd1.Visible = false;
                //labelStatusEnd2.Visible = false;
                panelFile.Enabled = false;
                panelBottom.Enabled = false;

                pbProgress.Value = 0;
                pbProgress.Visible = true;

                try
                {
                    if (cbLog.Checked)
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(logfile_skip))) //create director if not exists
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(logfile_skip));
                        }
                        log_skip = new StreamWriter(logfile_skip);
                        log_imp = new StreamWriter(logfile_imported);
                        log_upd = new StreamWriter(logfile_updated);
                    }

                    CustomerTableClass ctbl = new CustomerTableClass(this.db);
                    CCVCardsTableClass cardtbl = new CCVCardsTableClass(this.db);
                    if (db.TestConnection(false)) // connection to the database?
                    {
                        if (!ctbl.TableExist())  //customer table
                        {
                            if (!ctbl.CreateTable()) //create the table if not exists
                            {
                                throw new Exception(ctbl.LastMessage);
                            }
                        }
                        if (!cardtbl.TableExist()) //ccv card table
                        {
                            if (!cardtbl.CreateTable()) //create the table if not exists
                            {
                                throw new Exception(cardtbl.LastMessage);
                            }
                        }
                    }
                    else
                        throw new Exception(db.LastMessage);

                    if (cbImportCCV.Checked) // ccv customers/cards
                    {
                        // ccv
                        string no, temp, name;
                        bool iscard = true;
                        bool blocked = false;
                        bool expired = false;
                        string phone;
                        end = dataGridViewCCV.RowCount;
                        labelImportStatus.Text = "Importeren tabel " + tbTableCCV.Text;
                        Application.DoEvents();
                        if (cbImportSelected.Checked) //import only selected
                        {
                            start = dataGridViewCCV.SelectedRows[0].Index;
                            end = start + 1;
                        }
                        for (int i = start; i < end && !importaborted; i++)
                        {
                            no = Object2String(dataGridViewCCV.Rows[i].Cells[0].Value);
                            if (no.Length < 6)
                            {
                                if (MessageBox.Show("Ongeldig Pas/debt veld: " + no + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                                {
                                    break;
                                }
                                AppendToLogFile(log_skip, false, tbTableCCV.Text + String.Format(" no: {0}", no));
                                continue; // and skip this one
                            }

                            no = no.ToUpper(); //b = B
                            iscard = true;
                            blocked = false;
                            if (no.Substring(3, 2) == "00") // it is a customer no.
                            {
                                iscard = false;
                            }
                            else if (no.Substring(3, 2) == "0B") // it is a customer no.
                            {
                                iscard = false;
                                blocked = true;
                                no = no.Replace("B", "0");
                            }
                            else if (no.Substring(3, 2) == "B0")// XXXB0X //may be a customer, but also a card (10)
                            {
                                blocked = true;
                                no = no.Replace("B", "0"); // B = 0
                                iscard = ctbl.RecordExists(new int[] { CustomerTableClass.NUMBER }, new object[] { no }); // if record already exists with we assume it is a card
                            }

                            name = Object2String(dataGridViewCCV.Rows[i].Cells[2].Value, false);
                            expired = name.ToLower().Contains("vervallen") ? true : false;

                            if (!iscard) //customer number
                            {
                                object[] data = new object[ctbl.FieldNames.Length];

                                //make sure length = 7
                                int l = no.Length;
                                for (; l < 7; l++)
                                {
                                    no = "0" + no;
                                }
                                data[CustomerTableClass.NUMBER] = no;
                                data[CustomerTableClass.NAME] = dataGridViewCCV.Rows[i].Cells[2].Value;
                                data[CustomerTableClass.ADDRESS] = dataGridViewCCV.Rows[i].Cells[3].Value;
                                data[CustomerTableClass.POSTALCODE] = dataGridViewCCV.Rows[i].Cells[4].Value;
                                data[CustomerTableClass.CITY] = dataGridViewCCV.Rows[i].Cells[5].Value;
                                phone = Object2String(dataGridViewCCV.Rows[i].Cells[6].Value);
                                if(phone.StartsWith("06"))
                                    data[CustomerTableClass.MOBILE] = dataGridViewCCV.Rows[i].Cells[6].Value;
                                else
                                    data[CustomerTableClass.PHONE] = dataGridViewCCV.Rows[i].Cells[6].Value;

                                temp = Object2String(dataGridViewCCV.Rows[i].Cells[7].Value); //bank
                                if (temp.Length < 9)
                                    temp = Object2String(dataGridViewCCV.Rows[i].Cells[8].Value); //old ing no.

                                data[CustomerTableClass.IBAN] = temp;

                                data[CustomerTableClass.CCVCATEGORY] = dataGridViewCCV.Rows[i].Cells[10].Value;
                                data[CustomerTableClass.INVOICEPERIOD] = dataGridViewCCV.Rows[i].Cells[11].Value;

                                data[CustomerTableClass.DISCOUNT98] = Object2Double(dataGridViewCCV.Rows[i].Cells[14].Value) / 1000;
                                data[CustomerTableClass.DISCOUNT95] = Object2Double(dataGridViewCCV.Rows[i].Cells[16].Value) / 1000;
                                data[CustomerTableClass.DISCONTDIESEL] = Object2Double(dataGridViewCCV.Rows[i].Cells[18].Value) / 1000;

                                data[CustomerTableClass.REMARKS] = dataGridViewCCV.Rows[i].Cells[25].Value;
                                data[CustomerTableClass.FATNO] = dataGridViewCCV.Rows[i].Cells[26].Value;

                                data[CustomerTableClass.BLOCKED] = blocked ? 1 : 0;
                                data[CustomerTableClass.EXPIRED] = expired ? 1 : 0;

                                exists = ctbl.RecordExists(new int[] { CustomerTableClass.NUMBER }, new object[] { data[CustomerTableClass.NUMBER] });

                                if (exists && !cbCCVUpdateSameNo.Checked)
                                {
                                    UpdateProgress(i, start, end, tbTableCCV.Text);
                                    totalcustomskipped++;
                                    AppendToLogFile(log_skip, false, tbTableCCV.Text + String.Format(" no: {0}, name: {1}", data[CustomerTableClass.NUMBER], data[CustomerTableClass.NAME]));                                                                        
                                    continue; //skip
                                }
                                if (exists)
                                {
                                    data[CustomerTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
                                    queryresult = ctbl.Update(new int[] { CustomerTableClass.NUMBER }, new object[] { data[CustomerTableClass.NUMBER] },
                                                                            new int[]  //update only field which contain data
                                                                            {
                                                                                CustomerTableClass.NAME,
                                                                                CustomerTableClass.ADDRESS,
                                                                                CustomerTableClass.POSTALCODE,
                                                                                CustomerTableClass.CITY,
                                                                                phone.StartsWith("06")?CustomerTableClass.MOBILE:CustomerTableClass.PHONE,
                                                                                CustomerTableClass.IBAN,
                                                                                CustomerTableClass.CCVCATEGORY,
                                                                                CustomerTableClass.INVOICEPERIOD,
                                                                                CustomerTableClass.DISCOUNT98,
                                                                                CustomerTableClass.DISCOUNT95,
                                                                                CustomerTableClass.DISCONTDIESEL,
                                                                                CustomerTableClass.REMARKS,
                                                                                CustomerTableClass.FATNO,
                                                                                CustomerTableClass.DATELASTUPDATE
                                                                            },
                                                                            data);
                                    AppendToLogFile(log_upd, !queryresult, tbTableCCV.Text + String.Format(" no: {0}, name: {1}", data[CustomerTableClass.NUMBER], data[CustomerTableClass.NAME]));                                                                        
                                    totalcustomupdated++;
                                }
                                else
                                {
                                    data[CustomerTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue(); ;
                                    data[CustomerTableClass.DATECREATE] = DataBaseTableClassBase.GetDateValue();
                                    queryresult = ctbl.Insert(data);
                                    AppendToLogFile(log_imp, !queryresult, tbTableCCV.Text + String.Format(" no: {0}, name: {1}", data[CustomerTableClass.NUMBER], data[CustomerTableClass.NAME]));
                                    totalcustomimported++;
                                }

                                if (!queryresult)
                                {
                                    if (MessageBox.Show("Er is een fout opgetreden:\n" + ctbl.LastMessage + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNoCancel) != System.Windows.Forms.DialogResult.Yes)
                                    {
                                        break;
                                    }
                                }
                            }
                            else //card
                            {
                                object[] data = new object[cardtbl.FieldNames.Length];
                                if (!blocked) //B may already be replaced!
                                {
                                    blocked = no.Contains("B");
                                    if (blocked)
                                    {
                                        no = no.Replace("B", "0");
                                    }
                                }
                                data[CCVCardsTableClass.CARDNUMBER] = no;
                                data[CCVCardsTableClass.PIN] = dataGridViewCCV.Rows[i].Cells[1].Value;
                                data[CCVCardsTableClass.CUSTOMNUMBER] = dataGridViewCCV.Rows[i].Cells[9].Value;
                                data[CCVCardsTableClass.NAME] = dataGridViewCCV.Rows[i].Cells[2].Value;
                                data[CCVCardsTableClass.MARK] = dataGridViewCCV.Rows[i].Cells[12].Value;
                                data[CCVCardsTableClass.BLOCKED] = blocked?1:0;
                                data[CCVCardsTableClass.EXPIRED] = expired ? 1 : 0;
                                //data[CCVCardsTableClass.STATUS] = ;
                                //data[CCVCardsTableClass.REMARKS] = ;
                                //data[CCVCardsTableClass.DATEBLOCKED] = ;
                                //data[CCVCardsTableClass.DATEEXPIRED] = ;

                                exists = cardtbl.RecordExists(new int[] { CCVCardsTableClass.CARDNUMBER }, new object[] { data[CCVCardsTableClass.CARDNUMBER] });

                                if (exists && !cbCCVUpdateSameNo.Checked)
                                {
                                    UpdateProgress(i, start, end, tbTableCCV.Text);
                                    totalcardskipped++;
                                    AppendToLogFile(log_skip, false, tbTableCCV.Text + String.Format(" no: {0}, cardno: {1}, name: {2}", data[CCVCardsTableClass.CUSTOMNUMBER], data[CCVCardsTableClass.CARDNUMBER], data[CCVCardsTableClass.NAME]));                                                                        
                                    continue; //skip
                                }
                                if (exists)
                                {
                                    data[CCVCardsTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
                                    queryresult = cardtbl.Update(new int[] { CCVCardsTableClass.CARDNUMBER }, new object[] { data[CCVCardsTableClass.CARDNUMBER] },
                                                                new int[] { //update only field with (new) data
                                                                            CCVCardsTableClass.CUSTOMNUMBER, 
                                                                            CCVCardsTableClass.PIN,
                                                                            CCVCardsTableClass.NAME,
                                                                            CCVCardsTableClass.MARK,
                                                                            CCVCardsTableClass.BLOCKED,
                                                                            CCVCardsTableClass.DATELASTUPDATE
                                                                           },
                                                                data);
                                    AppendToLogFile(log_upd, !queryresult, tbTableCCV.Text + String.Format(" no: {0}, cardno: {1}, name: {2}", data[CCVCardsTableClass.CUSTOMNUMBER], data[CCVCardsTableClass.CARDNUMBER], data[CCVCardsTableClass.NAME]));
                                    totalcardupdated++;
                                }
                                else
                                {
                                    data[CCVCardsTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
                                    data[CCVCardsTableClass.DATECREATE] = DataBaseTableClassBase.GetDateValue();
                                    queryresult = cardtbl.Insert(data);
                                    AppendToLogFile(log_imp, !queryresult, tbTableCCV.Text + String.Format(" no: {0}, cardno: {1}, name: {2}", data[CCVCardsTableClass.CUSTOMNUMBER], data[CCVCardsTableClass.CARDNUMBER], data[CCVCardsTableClass.NAME]));
                                    totalcardimported++;
                                }

                                if (!queryresult)
                                {
                                    if (MessageBox.Show("Er is een fout opgetreden:\n" + cardtbl.LastMessage + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNoCancel) != System.Windows.Forms.DialogResult.Yes)
                                    {
                                        break;
                                    }
                                }
                            }
                            UpdateProgress(i, start, end, tbTableCCV.Text);
                        }
                    }


                    if (cbImportCustomers.Checked && !importaborted)
                    {
                        // customers
                        double disc;
                        string cn, savefolder;
                        end = dataGridViewCustomers.RowCount;
                        labelImportStatus.Text = "Importeren tabel " + tbTableCustomers.Text;
                        string title, name, oriname;
                        Application.DoEvents();
                        if (cbImportSelected.Checked)
                        {
                            start = dataGridViewCustomers.SelectedRows[0].Index;
                            end = start + 1;
                        }
                        for (int i = start; i < end && !importaborted; i++)
                        {
                            cn = Object2String(dataGridViewCustomers.Rows[i].Cells[1].Value, false);
                            //check if ccv custom no already exists. CCV customers imported first!!
                            exists = ctbl.RecordExists(new int[] { CustomerTableClass.NUMBER }, new object[] { cn });
                            if (!exists && cn.Length < 7)
                            {
                                int l = cn.Length;
                                for (; l < 7; l++)
                                {
                                    cn = "0" + cn;
                                }
                                exists = ctbl.RecordExists(new int[] { CustomerTableClass.NUMBER }, new object[] { cn });
                            }
                            if (exists)
                            {
                                UpdateProgress(i, start, end, tbTableCustomers.Text);
                                AppendToLogFile(log_skip, false, tbTableCustomers.Text + String.Format(" no: {0}", cn));
                                totalcustomskipped++;
                                continue; //skip
                            }
                            
                            object[] data = new object[ctbl.FieldNames.Length];

                            title = "";
                            name = Object2String(dataGridViewCustomers.Rows[i].Cells[0].Value, false);
                            oriname = name;
                            if (name.ToLower().StartsWith("dhr") || name.ToLower().StartsWith("mevr") || name.ToLower().StartsWith("fam"))
                            {
                                if (name.IndexOf(" ") > 0)
                                {
                                    title = name.Substring(0, name.IndexOf(" "));
                                    name = name.Substring(name.IndexOf(" ") + 1);
                                }
                            }
                            title = title.Replace("'", "''");
                            name = name.Replace("'", "''");
                            data[CustomerTableClass.TITLE] = title;
                            data[CustomerTableClass.NAME] = name;
                            data[CustomerTableClass.NUMBER] = String.Format("{0}", (int)nupCustomerNumberOffset.Value) + Object2String(dataGridViewCustomers.Rows[i].Cells[1].Value, false);
                            data[CustomerTableClass.ATTN1] = dataGridViewCustomers.Rows[i].Cells[2].Value;
                            data[CustomerTableClass.ADDRESS] = dataGridViewCustomers.Rows[i].Cells[3].Value;
                            data[CustomerTableClass.POSTALCODE] = Object2String(dataGridViewCustomers.Rows[i].Cells[4].Value).Replace(" ", "");
                            data[CustomerTableClass.REMARKS] = dataGridViewCustomers.Rows[i].Cells[5].Value;
                            data[CustomerTableClass.PHONE] = dataGridViewCustomers.Rows[i].Cells[6].Value;
                            data[CustomerTableClass.PAYMENT] = dataGridViewCustomers.Rows[i].Cells[8].Value;
                            savefolder = Object2String(dataGridViewCustomers.Rows[i].Cells[9].Value, false);
                            data[CustomerTableClass.SAVEFOLDER] = savefolder.ToLower() == "doorleveringen" ? "" : savefolder;

                            disc = Object2Double(dataGridViewCustomers.Rows[i].Cells[10].Value);
                            disc = disc > 100 ? disc / 10 : disc; //culture import issue (, <-> .)
                            data[CustomerTableClass.DISCOUNTPRODUCTSPERC] = disc<0||disc>100?0:disc;

                            data[CustomerTableClass.FATNO] = dataGridViewCustomers.Rows[i].Cells[11].Value;
                            data[CustomerTableClass.RESELLER] = Object2Int32(dataGridViewCustomers.Rows[i].Cells[12].Value) == -1 ? 1 : 0;
                            data[CustomerTableClass.CITY] = dataGridViewCustomers.Rows[i].Cells[13].Value;

                            exists = ctbl.RecordExists(new int[] { CustomerTableClass.ADDRESS, CustomerTableClass.POSTALCODE, CustomerTableClass.NAME }, new object[] { data[CustomerTableClass.ADDRESS], data[CustomerTableClass.POSTALCODE], oriname });

                            if (exists)
                            {
                                UpdateProgress(i, start, end, tbTableCustomers.Text);
                                totalcustomskipped++;
                                AppendToLogFile(log_skip, false, tbTableCustomers.Text + String.Format(" no: {0}, name: {1}", data[CustomerTableClass.NUMBER], data[CustomerTableClass.NAME]));
                                continue; //skip
                            }

                            data[CustomerTableClass.DATELASTUPDATE] = DataBaseTableClassBase.GetDateValue();
                            data[CustomerTableClass.DATECREATE] = DataBaseTableClassBase.GetDateValue();
                            queryresult = ctbl.Insert(data);
                            AppendToLogFile(log_imp, !queryresult, tbTableCustomers.Text + String.Format(" no: {0}, name: {1}", data[CustomerTableClass.NUMBER], data[CustomerTableClass.NAME]));
                            totalcustomimported++;

                            if (!queryresult)
                            {
                                if (MessageBox.Show("Er is een fout opgetreden:\n" + ctbl.LastMessage + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                                {
                                    break;
                                }
                            }
                            UpdateProgress(i, start, end, tbTableCustomers.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets fout gegaan\n" + ex.Message);
                    db.Close();
                }
                finally
                {
                    labelImportStatus.Text = importaborted ? "Importeren afgebroken" : "Importeren gereed";
                    labelStatusEnd1.Text = String.Format("Klanten: {0} geïmporteerd, {1} bijgewerkt, {2} overgeslagen", totalcustomimported, totalcustomupdated, totalcustomskipped);
                    labelStatusEnd1.Text += String.Format("\nPassen: {0} geïmporteerd, {1} bijgewerkt, {2} overgeslagen", totalcardimported, totalcardupdated, totalcardskipped);
                    labelStatusEnd1.Visible = true;
                    //labelStatusEnd2.Visible = true;
                    pbProgress.Visible = false;
                    btnStartImport.Enabled = true;
                    btnStartImport.Text = STARTIMPORT;
                    panelFile.Enabled = true;
                    panelBottom.Enabled = true;
                    if (log_skip!=null) log_skip.Close();
                    if (log_upd!=null) log_upd.Close();
                    if (log_imp!=null) log_imp.Close();
                }
            }
        }

        private void AppendToLogFile(StreamWriter w, bool error,  string log)
        {
            if (w != null)
                w.WriteLine((error?"ERROR: ":"")+log);
        }

        private void UpdateProgress(int pr, int start, int end, string tablename)
        {
            if (pr % 10 == 0 || pr == end)
            {
                pbProgress.Value = (int)((((double)pr / (double)(end - start)) * 100.0) + 0.5);
                labelImportStatus.Text = "Importeren tabel " + tablename + string.Format(" ({0} / {1})", pr, (end - start)); ;
                Application.DoEvents();
            }

        }

        private string Object2String(object field, bool escape=true)
        {
            string data="";
            try
            {
                data = (string)field;
                if(escape)
                    data = data.Replace("'", "''");
            }
            catch(Exception){;};

            return data;
        }


        private double Object2Double(object dvalue)
        {
            double value = 0;
            try
            {
                value = Double.Parse((string)dvalue);
            }
            catch (Exception) { ;};

            return value;
        }

        private Int32 Object2Int32(object ivalue)
        {
            Int32 value = 0;
            try
            {
                value = Int32.Parse((string)ivalue);
            }
            catch (Exception) { ;};

            return value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
 
     }
}
