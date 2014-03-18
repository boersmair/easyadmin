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
                    dataGridViewCCV.DataSource = dsccv.Tables[0];
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

                importaborted = false;
                btnStartImport.Text = ABORT;
                labelImportStatus.Text = "Starten met importeren";
                labelImportStatus.Visible = true;
                panelFile.Enabled = false;

                pbProgress.Value = 0;
                pbProgress.Visible = true;

                //try
                //{

                    CustomerTableClass ctbl = new CustomerTableClass(this.db);
                    if (db.TestConnection())
                    {
                        if (!ctbl.TableExist())
                        {
                            if (!ctbl.CreateTable())
                            {
                                throw new Exception(ctbl.LastMessage);                               
                            }
                        }
                    }

                    if (cbImportCCV.Checked)
                    {
                        // ccv
                        string no, temp;
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
                            no = FieldToString(dataGridViewCCV.Rows[i].Cells[0].Value);
                            if (no.Length < 6)
                            {
                                if (MessageBox.Show("Ongeldig Pas/debt veld: " + no + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                                {
                                    break;
                                }
                                continue; // and skip this one
                            }

                            if (no.Substring(3, 2) == "00") //customer number
                            {
                                object[] data = new object[ctbl.FieldNames.Length];

                                data[CustomerTableClass.NUMBER] = String2Int32(no);
                                data[CustomerTableClass.NAME] = FieldToString(dataGridViewCCV.Rows[i].Cells[2].Value);
                                data[CustomerTableClass.ADDRESS] = FieldToString(dataGridViewCCV.Rows[i].Cells[3].Value);
                                data[CustomerTableClass.POSTALCODE] = FieldToString(dataGridViewCCV.Rows[i].Cells[4].Value).Replace(" ", "");
                                data[CustomerTableClass.CITY] = FieldToString(dataGridViewCCV.Rows[i].Cells[5].Value);
                                data[CustomerTableClass.PHONE] = FieldToString(dataGridViewCCV.Rows[i].Cells[6].Value);

                                temp = FieldToString(dataGridViewCCV.Rows[i].Cells[7].Value); //bank
                                if (temp.Length < 9)
                                    temp = FieldToString(dataGridViewCCV.Rows[i].Cells[8].Value); //old ing no.

                                data[CustomerTableClass.IBAN] = temp;

                                data[CustomerTableClass.CCVCATEGORY] = String2Int32(FieldToString(dataGridViewCCV.Rows[i].Cells[10].Value));
                                data[CustomerTableClass.INVOICEPERIOD] = String2Int32(FieldToString(dataGridViewCCV.Rows[i].Cells[11].Value));

                                data[CustomerTableClass.DISCOUNT98] = String2Double(FieldToString(dataGridViewCCV.Rows[i].Cells[14].Value)) / 100;
                                data[CustomerTableClass.DISCOUNT95] = String2Double(FieldToString(dataGridViewCCV.Rows[i].Cells[16].Value)) / 100;
                                data[CustomerTableClass.DISCONTDIESEL] = String2Double(FieldToString(dataGridViewCCV.Rows[i].Cells[18].Value)) / 100;

                                data[CustomerTableClass.REMARKS] = FieldToString(dataGridViewCCV.Rows[i].Cells[25].Value);
                                data[CustomerTableClass.FATNO] = FieldToString(dataGridViewCCV.Rows[i].Cells[26].Value);

                                exists = ctbl.RecordExists(new int[] { CustomerTableClass.NUMBER }, new object[] { data[CustomerTableClass.NUMBER] });

                                if (exists && !cbCCVUpdateSameNo.Checked)
                                {
                                    UpdateProgress(i, start, end, tbTableCCV.Text);
                                    continue; //skip
                                }
                                if (exists)
                                    queryresult = ctbl.Update(new int[] { CustomerTableClass.NUMBER }, new object[] { data[CustomerTableClass.NUMBER] }, ctbl.FieldIds, data);
                                else
                                    queryresult = ctbl.Insert(data);

                                if (!queryresult)
                                {
                                    if (MessageBox.Show("Er is een fout opgetreden:\n" + ctbl.LastMessage + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNoCancel) != System.Windows.Forms.DialogResult.Yes)
                                    {
                                        break;
                                    }
                                }
                                UpdateProgress(i, start, end, tbTableCCV.Text);
                            }
                            else //card
                            {
                                ;
                            }
                        }
                    }


                    if (cbImportCustomers.Checked && !importaborted)
                    {
                        // customers
                        end = dataGridViewCustomers.RowCount;
                        labelImportStatus.Text = "Importeren tabel " + tbTableCustomers.Text;
                        Application.DoEvents();
                        if (cbImportSelected.Checked)
                        {
                            start = dataGridViewCustomers.SelectedRows[0].Index;
                            end = start + 1;
                        }
                        for (int i = start; i < end && !importaborted; i++)
                        {
                            object[] data = new object[ctbl.FieldNames.Length];

                            data[CustomerTableClass.NAME] = FieldToString(dataGridViewCustomers.Rows[i].Cells[0].Value);
                            //data[CustomerTableClass.NAME] = (string)((DataTable)dataGridViewCustomers.DataSource).Rows[i][0];
                            data[CustomerTableClass.NUMBER] = String2Int32(FieldToString(dataGridViewCustomers.Rows[i].Cells[1].Value)) + (int)nupCustomerNumberOffset.Value;
                            data[CustomerTableClass.ATTN1] = FieldToString(dataGridViewCustomers.Rows[i].Cells[2].Value);
                            data[CustomerTableClass.ADDRESS] = FieldToString(dataGridViewCustomers.Rows[i].Cells[3].Value);
                            data[CustomerTableClass.POSTALCODE] = FieldToString(dataGridViewCustomers.Rows[i].Cells[4].Value).Replace(" ", "");
                            data[CustomerTableClass.REMARKS] = FieldToString(dataGridViewCustomers.Rows[i].Cells[5].Value);
                            data[CustomerTableClass.PHONE] = FieldToString(dataGridViewCustomers.Rows[i].Cells[6].Value);
                            data[CustomerTableClass.PAYMENT] = FieldToString(dataGridViewCustomers.Rows[i].Cells[8].Value);

                            data[CustomerTableClass.DISCOUNTPRODUCTSPERC] = String2Double(FieldToString(dataGridViewCustomers.Rows[i].Cells[10].Value));

                            data[CustomerTableClass.FATNO] = FieldToString(dataGridViewCustomers.Rows[i].Cells[11].Value);
                            data[CustomerTableClass.RESELLER] = String2Int32(FieldToString(dataGridViewCustomers.Rows[i].Cells[12].Value)) == -1 ? true : false;
                            data[CustomerTableClass.CITY] = FieldToString(dataGridViewCustomers.Rows[i].Cells[13].Value);

                            exists = ctbl.RecordExists(new int[] { CustomerTableClass.ADDRESS, CustomerTableClass.POSTALCODE, CustomerTableClass.NAME }, new object[] { data[CustomerTableClass.ADDRESS], data[CustomerTableClass.POSTALCODE], data[CustomerTableClass.NAME] });

                            if (exists)
                            {
                                UpdateProgress(i, start, end, tbTableCustomers.Text);
                                continue; //skip
                            }

                            queryresult = ctbl.Insert(data);

                            if (!ctbl.Insert(data))
                            {
                                if (MessageBox.Show("Er is een fout opgetreden:\n" + ctbl.LastMessage + "\nDoorgaan?", "Importeren", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                                {
                                    break;
                                }
                            }
                            UpdateProgress(i, start, end, tbTableCustomers.Text);
                        }
                    }
                //}
                //catch (Exception ex)
                //{
               //     MessageBox.Show("Er is iets fout gegaan\n" + ex.Message);
               //     db.Close();
                //finally
                //{
                //   
                    labelImportStatus.Text = "Importeren gereed";
                    pbProgress.Visible = false;
                    btnStartImport.Enabled = true;
                    btnStartImport.Text = STARTIMPORT;
                    panelFile.Enabled = true;
                //}
            }
        }

        private void UpdateProgress(int pr, int start, int end, string tablename)
        {
            if (pr % 10 == 0 || pr == end)
            {
                pbProgress.Value = (int)((((double)pr / (double)(end - start)) * 100.0) + 0.5);
                labelImportStatus.Text = "Importeren tabel " + tablename + string.Format(" ({0} / {1}", pr, (end - start)); ;
                Application.DoEvents();
            }

        }

        private string FieldToString(object field)
        {
            string data="";
            try
            {
                data = (string)field;
                data = data.Replace("'", "''");
            }
            catch(Exception){;};

            return data;
        }


        private double String2Double(string dvalue)
        {
            double value = 0;
            try
            {
                value = Double.Parse(dvalue);
            }
            catch (Exception) { ;};

            return value;
        }

        private Int32 String2Int32(string ivalue)
        {
            Int32 value = 0;
            try
            {
                value = Int32.Parse(ivalue);
            }
            catch (Exception) { ;};

            return value;
        }
 
     }
}
