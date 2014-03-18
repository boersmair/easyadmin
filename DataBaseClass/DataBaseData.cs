using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace DataBaseData
{
    /// <summary>
    /// Database settings class
    /// </summary>
    public class DataBaseSettings : ICloneable
    {
        public const string DB_MYSQL = "MySql";

        public string databasetype = DB_MYSQL;
        public string server = "localhost";
        public int port = 3306;
        public string database = "vdput";
        public string username = "root";
        public string password = "";
        public string customertable = "customers";
        public string ccvcardstable = "ccvcards";
        public string invoicetable = "invoices";
        public string producttable = "products";
        public string AFIS12table = "afis12";
        public string emailsend = "emailsend";
        public string emailattachm = "emailattachm";

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// Interface for implemented database
    /// </summary>
    public interface IDataBase
    {
        string LastMessage
        {
            get;
        }
        object Connection
        {
            get;
        }
        bool OpenConnection();
        bool CloseConnection();
        bool TestConnection();
    }

    public interface IDataBaseTable
    {
        string LastMessage
        {
            get;
        }

        DataTable GetTableData(string tablename, string filter=null);
        bool UpdateTable(DataTable changes);
        bool NonQuery(string query);
        int Count(string query);

    }

}
