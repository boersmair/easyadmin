using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataBaseData;

namespace EasyAdmin
{
    public class CustomerData : ICloneable
    {
        public int number = 1000000;
        public string title = "";
        public string firstname = "";
        public string name = "";
        public string attn1 = "";
        public string attn2 = "";
        public string address = "";
        public string postalcode = "";
        public string city = "";
        public string addressextra = "";
        public string iban = "";
        public string fatno = "";
        public bool reseller=false;
        public string payment = "";
        public int invoiceperiod=0;
        public int ccvcategory=0;
        public string phone = "";
        public string mobile = "";
        public string status = "";
        public string remarks = "";
        public double discountproductsperc =0.0;
        public double discountlabour = 0.0;
        public double discount95 = 0.0;
        public double discountdiesel = 0.0;
        public double discount98 = 0.0;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// Class for specific database table
    /// </summary>
    class CustomerTableClass : DataBaseTableClassBase
    {
        //private Dictionary<string, string> tablenames = new Dictionary<string, string>();
        public const int FIELD_COUNT = 26;
        public const int ID = 0;
        public const int NUMBER = 1;
        public const int TITLE = 2;
        public const int FIRSTNAME = 3;
        public const int NAME = 4;
        public const int ATTN1 = 5;
        public const int ATTN2 = 6;
        public const int ADDRESS = 7;
        public const int POSTALCODE = 8;
        public const int CITY = 9;
        public const int ADDRESSEXTRA = 10;
        public const int IBAN = 11;
        public const int FATNO = 12;
        public const int RESELLER = 13;
        public const int PAYMENT = 14;
        public const int INVOICEPERIOD = 15;
        public const int CCVCATEGORY = 16;
        public const int PHONE = 17;
        public const int MOBILE = 18;
        public const int STATUS = 19;
        public const int REMARKS = 20;
        public const int DISCOUNTPRODUCTSPERC = 21;
        public const int DISCOUNTLABOUR = 22;
        public const int DISCOUNT95 = 23;
        public const int DISCONTDIESEL = 24;
        public const int DISCOUNT98 = 25;
 

        public CustomerTableClass(DataBaseClass database) : base(database)
        {
            fieldnames = new string[FIELD_COUNT];
            fieldnames[ID] = "id";
            fieldnames[NUMBER] = "number";
            fieldnames[TITLE] = "title";
            fieldnames[FIRSTNAME] = "firstname";
            fieldnames[NAME] = "name";
            fieldnames[ATTN1] = "attn1";
            fieldnames[ATTN2] = "attn2";
            fieldnames[ADDRESS] = "address";
            fieldnames[POSTALCODE] = "postalcode";
            fieldnames[CITY] = "city";
            fieldnames[ADDRESSEXTRA] = "addressextra";
            fieldnames[IBAN] = "iban";
            fieldnames[FATNO] = "fatno";
            fieldnames[RESELLER] = "reseller";
            fieldnames[PAYMENT] = "payment";
            fieldnames[INVOICEPERIOD] = "invoiceperiod";
            fieldnames[CCVCATEGORY] = "ccvcategory";
            fieldnames[PHONE] = "phone";
            fieldnames[MOBILE] = "mobile";
            fieldnames[STATUS] = "status";
            fieldnames[REMARKS] = "remarks";
            fieldnames[DISCOUNTPRODUCTSPERC] = "discountproductsperc";
            fieldnames[DISCOUNTLABOUR] = "discountlabour";
            fieldnames[DISCOUNT95] = "discount95";
            fieldnames[DISCONTDIESEL] = "discountdiesel";
            fieldnames[DISCOUNT98] = "discount98";
        }
        /// <summary>
        /// Get full table data
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllData()
        {
            return activetable.GetTableData(db.Settings.customertable);
        }

        /// <summary>
        /// Update table data
        /// </summary>
        /// <param name="changes"></param>
        /// <returns></returns>
        public bool UpdateTable(DataTable changes)
        {
            return activetable.UpdateTable(changes);
        }

        /// <summary>
        /// Check if table exists in database
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return base.TableExist(db.Settings.customertable);
        }

        /// <summary>
        /// Create a new database table.
        /// </summary>
        /// <returns></returns>
        public bool CreateNew()
        {
            string columns = "id INT NOT NULL AUTO_INCREMENT,"+
                            "number INT NOT NULL,"+
                            "title VARCHAR(30),"+
                            "firstname VARCHAR(100),"+
                            "name VARCHAR(100),"+
                            "attn1 VARCHAR(100),"+
                            "attn2 VARCHAR(100),"+
                            "address VARCHAR(100),"+
                            "postalcode VARCHAR(10),"+
                            "city VARCHAR(100),"+
                            "addressextra VARCHAR(100),"+
                            "iban VARCHAR(34),"+
                            "fatno VARCHAR(100),"+
                            "reseller BOOL,"+
                            "payment VARCHAR(100),"+
                            "invoiceperiod INT,"+
                            "ccvcategory INT,"+
                            "phone VARCHAR(100),"+
                            "mobile VARCHAR(100),"+
                            "status VARCHAR(100),"+
                            "remarks VARCHAR(255),"+
                            "discountproductsperc DOUBLE,"+
                            "discountlabour DOUBLE,"+
                            "discount95 DOUBLE,"+
                            "discountdiesel DOUBLE,"+
                            "discount98 DOUBLE," +
                            "PRIMARY KEY (id )";
            return base.CreateTable(db.Settings.customertable, columns);
        }

        public bool RecordExists(int number)
        {
            string query = String.Format("SELECT EXISTS(SELECT 1 FROM {0} WHERE number = '{1}' LIMIT 1)", db.Settings.customertable, number);
            if (activetable.Count(query) > 0) return true;
            return false;
        }

        public bool RecordExists(string address, string postalcode, string name)
        {
            string query = String.Format("SELECT EXISTS(SELECT 1 FROM {0} WHERE address = '{1}' AND postalcode = '{2}' AND name = '{3}' LIMIT 1)", db.Settings.customertable, address, postalcode, name);
            if (activetable.Count(query) > 0) return true;
            return false;
        }

        /// <summary>
        /// Insert new customer data
        /// </summary>
        /// <param name="data">customer data</param>
        /// <returns></returns>
        public bool Insert(CustomerData data)
        {
            string query = "INSERT INTO "+db.Settings.customertable+" ("+
                            "number,"+
                            "title,"+
                            "firstname,"+
                            "name,"+
                            "attn1,"+
                            "attn2,"+
                            "address,"+
                            "postalcode,"+
                            "city,"+
                            "addressextra,"+
                            "iban,"+
                            "fatno,"+
                            "reseller,"+
                            "payment,"+
                            "invoiceperiod,"+
                            "ccvcategory,"+
                            "phone,"+
                            "mobile,"+
                            "status,"+
                            "remarks,"+
                            "discountproductsperc,"+
                            "discountlabour,"+
                            "discount95,"+
                            "discountdiesel,"+
                            "discount98"+
                            ") "+
                            "VALUES("+
                            "'" + string.Format("{0}", data.number) + "'," +
                            "'"+data.title+"',"+
                            "'" + data.firstname + "'," +
                            "'" + data.name + "'," +
                            "'" + data.attn1 + "'," +
                            "'" + data.attn2 + "'," +
                            "'" + data.address + "'," +
                            "'" + data.postalcode + "'," +
                            "'" + data.city + "'," +
                            "'" + data.addressextra + "'," +
                            "'" + data.iban + "'," +
                            "'" + data.fatno + "'," +
                            "'" + data.reseller + "'," +
                            "'" + data.payment + "'," +
                            "'" + data.invoiceperiod + "'," +
                            "'" + data.ccvcategory + "'," +
                            "'" + data.phone + "'," +
                            "'" + data.mobile + "'," +
                            "'" + data.status + "'," +
                            "'" + data.remarks + "'," +
                            "'" + data.discountproductsperc + "'," +
                            "'" + data.discountlabour + "'," +
                            "'" + data.discount95 + "'," +
                            "'" + data.discountdiesel + "'," +
                            "'" + data.discount98 + "'" +
                            ")";

            return activetable.NonQuery(query);
        }

        public bool Insert(object[] fields)
        {

            string query = "INSERT INTO "+db.Settings.customertable+" (";

            for (int i = 0; i < fields.Length; i++)
                query += fieldnames[i] + ",";

            query = query.Substring(0,query.Length-1) + ")"; // replace last comma

            query += "VALUES(";

            for (int i = 0; i < fields.Length; i++)
                query += string.Format("'{0}',", fields[i]);

            query = query.Substring(0, query.Length - 1) + ")"; // replace last comma

            return activetable.NonQuery(query);
        }


        //Update statement
        public bool Update(int number, CustomerData data)
        {
            string query = "UPDATE " + db.Settings.customertable + " SET "+
                String.Format("name='{0}',", data.name) +                
                string.Format("WHERE number='{0}'", data.number);

            return activetable.NonQuery(query);
        }

        //Delete statement
        public bool Delete(int id)
        {
            string query = String.Format("DELETE FROM {0} WHERE id='{1}'", db.Settings.customertable, id);

            return activetable.NonQuery(query);
        }

        public string LastMessage
        {
            get { return activetable.LastMessage; }
        }

     }
}
