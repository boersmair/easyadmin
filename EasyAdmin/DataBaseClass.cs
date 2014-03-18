using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DBMySQLConnection;
using DataBaseData;

namespace EasyAdmin
{
    /// <summary>
    /// Access to underlying database
    /// </summary>
    public class DataBaseClass
    {
        private DataBaseSettings dbsettings;
        private Dictionary<string, IDataBase> database = new Dictionary<string, IDataBase>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbsettings">database settings. Local copy will be made.</param>
        public DataBaseClass(DataBaseSettings dbsettings)
        {
            UpdateSettings(dbsettings);
         }

        public void UpdateSettings(DataBaseSettings dbsettings)
        {
            this.dbsettings = (DataBaseSettings)dbsettings.Clone();
            database[DataBaseSettings.DB_MYSQL] = new DBMySQL(this.dbsettings);
        }

        /// <summary>
        /// Connect to database
        /// </summary>
        /// <param name="showmsgbox"></param>
        /// <returns></returns>
        public bool Connect(bool showmsgbox = true)
        {
            if (database[dbsettings.databasetype].OpenConnection() == false)
            {
                MessageBox.Show(database[dbsettings.databasetype].LastMessage);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Close database connection
        /// </summary>
        /// <param name="showmsgbox"></param>
        /// <returns></returns>
        public bool Close(bool showmsgbox = true)
        {
            if (database[dbsettings.databasetype].CloseConnection() == false)
            {
                MessageBox.Show(database[dbsettings.databasetype].LastMessage);
                return false;
            }
            return true;

        }

        /// <summary>
        /// Test for valid database connection
        /// </summary>
        /// <param name="showmsgbox"></param>
        /// <returns></returns>
        public bool TestConnection(bool showmsgbox = true)
        {
            if (database[dbsettings.databasetype].TestConnection() == false)
            {
                if(showmsgbox)
                    MessageBox.Show(database[dbsettings.databasetype].LastMessage);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get reference to selected datase
        /// </summary>
        public IDataBase ActiveDb
        {
            get { return database[dbsettings.databasetype]; }
        }

        /// <summary>
        /// Get reference to settings
        /// </summary>
        public DataBaseSettings Settings
        {
            get { return dbsettings; }
        }

        public string LastMessage
        {
            get { return database[dbsettings.databasetype].LastMessage; }
        }

    }

    /// <summary>
    /// General table class to underlying table. Derive application table classes from this class.
    /// </summary>
    public class DataBaseTableClassBase
    {
        protected DataBaseClass db;
        protected Dictionary<string, IDataBaseTable> table = new Dictionary<string, IDataBaseTable>();
        protected IDataBaseTable activetable = null;
        protected string[] fieldnames; //init in parent class
        protected string[] fieldtypes; //init in parent class
        protected string tablename; //init in parent class
        protected const string FIELDNAME_PRIMARY = "id";
        protected string primarykey = FIELDNAME_PRIMARY;
        protected List<string> foreignkeys = new List<string>();
        protected string engine = "";
        protected string collate = "";
        protected string charset = "";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="database">General database class. Reference to datbase will be used.</param>
        public DataBaseTableClassBase(DataBaseClass database)
        {
            UpdateSettings(database);
        }

        /// <summary>
        /// Database settings changed. The table class should be informed.
        /// </summary>
        /// <param name="database"></param>
        public void UpdateSettings(DataBaseClass database)
        {
            db = database;
            table[DataBaseSettings.DB_MYSQL] = new MySQLTable(db.ActiveDb);
            activetable = table[db.Settings.databasetype];
            if (db.Settings.databasetype == DataBaseSettings.DB_MYSQL)
            {
                engine = "InnoDB";
                collate = "latin1_swedish_ci";
                charset = "latin1";
            }
            else
            {
                engine = "";
                collate = "";
                charset = "";
            }
        }

        /// <summary>
        /// Get the name of the table
        /// </summary>
        public string TableName
        {
            get { return tablename; }
        }

        /// <summary>
        /// Get the names of the fields
        /// </summary>
        public string[] FieldNames
        {
            get { return fieldnames; }
        }

        static public DateTime Epoch
        {
            get { return new DateTime(1970, 1, 1); }
        }

        static public Int64 GetDateValue()
        {
            return (Int64)(new TimeSpan(DateTime.Now.Ticks - DataBaseTableClassBase.Epoch.Ticks).TotalSeconds);
        }

        static public Int64 ConvertDateValue(DateTime date)
        {
            return (Int64)(new TimeSpan(date.Ticks - DataBaseTableClassBase.Epoch.Ticks).TotalSeconds);
        }

        static public DateTime GetDate(Int64 value)
        {
            DateTime date = Epoch.AddSeconds(value);
            return date;
        }
        
        /// <summary>
        /// Get all data from table
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllData()
        {
            return activetable.GetTableData(tablename);
        }

        public DataTable GetFilteredData(string filter)
        {
            return activetable.GetTableData(tablename, filter);
        }

        /// <summary>
        /// Update table data. Data should be retreived with GetAllData before.
        /// </summary>
        /// <param name="changes"></param>
        /// <returns></returns>
        public bool UpdateTable(DataTable changes)
        {
            return activetable.UpdateTable(changes);
        }

        /// <summary>
        /// Check if table already exists
        /// </summary>
        /// <returns></returns>
        public bool TableExist()
        {
            string query = "SELECT count(*) FROM information_schema.TABLES WHERE (TABLE_SCHEMA = '" + db.Settings.database + "') AND (TABLE_NAME = '" + tablename + "');";
            if (activetable.Count(query) > 0) return true;
            return false;
        }


        /// <summary>
        /// insert new record
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if ok</returns>
        public bool Insert(object[] data)
        {
            return activetable.NonQuery(GetInsertQuery(data));
        }

        /// <summary>
        /// insert a new record. Return Id of inserted row
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ID of inserted row</returns>
        public int InsertRow(object[] data)
        {
            return activetable.Count(GetInsertQuery(data)+"SELECT "+(db.Settings.databasetype == DataBaseSettings.DB_MYSQL?"LAST_INSERT_ID();":"SCOPE_IDENTITY();"));
        }

        /// <summary>
        /// Check if record exists.
        /// </summary>
        /// <param name="fieldids"></param>
        /// <param name="data"></param>
        /// <returns>true if exist</returns>
        public bool RecordExists(int[] fieldids, object[] data)
        {
            string query = String.Format("SELECT EXISTS(SELECT 1 FROM {0} WHERE ", tablename);

            for (int i = 0; i < fieldids.Length && i < data.Length; i++)
                query += string.Format("{0} = '{1}' AND ", fieldnames[fieldids[i]], EscapeData(data[i], fieldids[i]));

            query = query.Substring(0, query.Length - 5); // remove last AND statement
           
            query += " LIMIT 1)";

            if (activetable.Count(query) > 0) return true;
            return false;
        }

        /// <summary>
        /// Delete record from table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = String.Format("DELETE FROM {0} WHERE id='{1}'", tablename, id);

            return activetable.NonQuery(query);
        }

        /// <summary>
        /// Delet record.
        /// </summary>
        /// <param name="wherefieldids">ids of fiels in where statement</param>
        /// <param name="wherefielddata">data of field ids. Arraysize is same size as wherefieldids.</param>
        /// <returns></returns>
        public bool Delete(int[] wherefieldids, object[] wherefielddata)
        {
            string query = String.Format("DELETE FROM {0} WHERE ", tablename);

            for (int i = 0; i < wherefieldids.Length && i < wherefielddata.Length; i++)
                query += String.Format("{0}='{1}' AND ", fieldnames[wherefieldids[i]], EscapeData(wherefielddata[i], wherefieldids[i]));

            query = query.Substring(0, query.Length - 5); // remove last AND statement

            return activetable.NonQuery(query);
        }


        /// <summary>
        /// Update record.
        /// </summary>
        /// <param name="wherefieldids">ids of fiels in where statement</param>
        /// <param name="wherefielddata">data of field ids. Arraysize is same size as wherefieldids.</param>
        /// <param name="fieldids">field ids to update. Array may be shorter than data array.</param>
        /// <param name="data">Full (!) data array of FIELD_COUNT size. only fields with of fieldids array are updated</param>
        /// <returns></returns>
        public bool Update(int[] wherefieldids, object[] wherefielddata, int[] fieldids, object[] data)
        {
            string query = String.Format("UPDATE {0} SET ", tablename);

            for (int i = 0; i < fieldids.Length; i++) //field id must be valid!
            {
                if (fieldnames[fieldids[i]] == FIELDNAME_PRIMARY)
                    continue;
                query += String.Format("{0}='{1}',", fieldnames[fieldids[i]], EscapeData(data[fieldids[i]], fieldids[i]));
            }
            query = query.Substring(0, query.Length - 1); // remove last comma

            query += " WHERE ";

            for (int i = 0; i < wherefieldids.Length && i < wherefielddata.Length; i++)
                query += String.Format("{0}='{1}' AND ", fieldnames[wherefieldids[i]], EscapeData(wherefielddata[i], wherefieldids[i]));

            query = query.Substring(0, query.Length - 5); // remove last AND statement

            return activetable.NonQuery(query);
        }

        /// <summary>
        /// Get last message from underlying table interface
        /// </summary>
        public string LastMessage
        {
            get { return activetable.LastMessage; }
        }

        /// <summary>
        /// Add table to database
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public bool CreateTable()
        {
            string query = "CREATE TABLE " + tablename + "(";

            for (int i = 0; i < fieldnames.Length; i++)
                query += fieldnames[i] + " " + fieldtypes[i] + ",";

            query += string.Format("PRIMARY KEY ({0})", primarykey);
            for (int i = 0; i < foreignkeys.Count; i++)
            {
                query += ","+foreignkeys[i];
            }
            query += ")";
            query += charset.Length > 0 ? String.Format(" CHARACTER SET {0}", charset) : "";
            query += collate.Length > 0 ? String.Format(" COLLATE {0}", collate) : "";
            query += engine.Length > 0 ? String.Format(" ENGINE = {0}", engine) : "";
            query += ";";
            return activetable.NonQuery(query);
        }

        protected object EscapeData(object data, int fieldid)
        {
            if(!fieldtypes[fieldid].Contains("VARCHAR")) return data; //not a string value
            
            string stringdata;
            object retdata = data;
            try
            {
                stringdata = (string)data;
                retdata = stringdata.Replace("'", "''");
            }
            catch (Exception) { ;};

            return retdata;
        }

        protected string GetInsertQuery(object[] data)
        {
            string query = "INSERT INTO " + tablename + " (";

            for (int i = 0; i < data.Length; i++)
                query += fieldnames[i] + ",";

            query = query.Substring(0, query.Length - 1) + ")"; // replace last comma

            query += "VALUES(";

            for (int i = 0; i < data.Length; i++)
                query += string.Format("'{0}',", EscapeData(data[i], i));

            query = query.Substring(0, query.Length - 1) + ");"; // replace last comma

            return query;
        }
 

    }
}
