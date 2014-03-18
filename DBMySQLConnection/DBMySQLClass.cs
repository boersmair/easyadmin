using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using DataBaseData;

namespace DBMySQLConnection
{
    /// <summary>
    /// MySQL database access
    /// </summary>
    public class DBMySQL : IDataBase
    {
        MySqlConnection connection;
        DataBaseSettings dbsetting = new DataBaseSettings();
        private string lastMessage = "";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">database settings. Full copy of data will be made.</param>
        public DBMySQL(DataBaseSettings db)
        {
            dbsetting = (DataBaseSettings)db.Clone();
            Initialize();
        }

        /// <summary>
        /// Initialize values
        /// </summary>
        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + dbsetting.server + ";" + "Port=" + dbsetting.port + ";" + "DATABASE=" +
            dbsetting.database + ";" + "UID=" + dbsetting.username + ";" + "PASSWORD=" + dbsetting.password + ";"
            /*+ "Convert Zero Datetime=True;"*/ + "Allow Zero Datetime=True;";
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Open an connection to the database
        /// </summary>
        /// <returns></returns>
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        lastMessage = "Kan geen verbinding met de server maken.  Contact de administrator";
                        break;

                    case 1045:
                        lastMessage = "Ongeldige gebruiksnaam/wachtwoord, probeer het nogmaals";
                        break;
                    default:
                        lastMessage = ex.Message + " ("+ex.Number+")";
                        break;
                }
                return false;
            }
        }

        /// <summary>
        /// Close connection to database
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                lastMessage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Check if connection to database is available
        /// </summary>
        /// <returns>true if ok, else false</returns>
        public bool TestConnection()
        {
            if (this.OpenConnection() == true)
            {
                lastMessage = "Verbinding is ok";
                this.CloseConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get last status/error message
        /// </summary>
        public string LastMessage
        {
            get { return lastMessage; }
        }

        /// <summary>
        /// Get reference to connection
        /// </summary>
        public object Connection
        {
            get { return connection; }
        }

    }

    /// <summary>
    /// MySQL table access
    /// </summary>
    public class MySQLTable : IDataBaseTable
    {
        private IDataBase db;
        private MySqlDataAdapter mySqlDataAdapter;
        private string lastMessage = "";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="database"></param>
        public MySQLTable(IDataBase database)
        {
            db = database;
        }

        /// <summary>
        /// Get last status/error message
        /// </summary>
        public string LastMessage
        {
            get { return lastMessage; }
        }

        /// <summary>
        /// Get all or filtered data of table. Non filtered data can be udated using UpdateTable
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataTable GetTableData(string table, string filter=null)
        {
            DataSet ds = null;
            DataTable dt = null;
            if (Connect() == true)
            {
                try
                {
                    if(filter==null || filter.Length<=0)
                        mySqlDataAdapter = new MySqlDataAdapter(String.Format("select * from {0}",table), (MySqlConnection)db.Connection);
                    else
                        mySqlDataAdapter = new MySqlDataAdapter(String.Format("select * from {0} where {1}", table, filter), (MySqlConnection)db.Connection);
                    ds = new DataSet();
                    mySqlDataAdapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (Exception e)
                {
                    lastMessage = e.Message;
                }

                //close connection
                db.CloseConnection();
            }
            return dt;
        }

        /// <summary>
        /// Update table data. GetTableData must be called first.
        /// </summary>
        /// <param name="changes"></param>
        /// <returns>true if ok.</returns>
        public bool UpdateTable(DataTable changes)
        {
            try
            {
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                int count = mySqlDataAdapter.Update(changes);
                return true;
            }
            catch (Exception e)
            {
                lastMessage = e.Message;
                return false;
            }
            
        }

        /// <summary>
        /// Execute non query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>true if ok</returns>
        public bool NonQuery(string query)
        {
            bool ret = false;
            //open connection
            if (Connect() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)db.Connection);
                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    ret = true;
                }
                catch (Exception e)
                {
                    lastMessage = e.Message;
                }

                //close connection
                db.CloseConnection();
                return ret;
            }
            return false;
        }


        public int Count(string query)
        {
            int Count = -1;

            //Open Connection
            if (Connect() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)db.Connection);
                //ExecuteScalar will return one value
                //object result = cmd.ExecuteScalar();
                try
                {
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                }
                catch (Exception e)
                {
                    lastMessage = e.Message;
                }
                //close Connection
                db.CloseConnection();
                return Count;
            }
            else
            {
                return Count;
            }
        }

        private bool Connect()
        {
            if (db.OpenConnection() != true)
            {
                lastMessage = db.LastMessage;
                return false;
            }
            return true;
        }


 /*
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        */
        /*
        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
        */
    }
}
