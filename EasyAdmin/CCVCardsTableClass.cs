using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataBaseData;

namespace EasyAdmin
{
    /// <summary>
    /// Class for specific database table
    /// </summary>
    class CCVCardsTableClass : DataBaseTableClassBase
    {
        public const int FIELD_COUNT = 14;
        public const int ID = 0;
        public const int CARDNUMBER = 1;
        public const int CUSTOMNUMBER = 2;
        public const int NAME = 3;
        public const int MARK = 4;
        public const int BLOCKED = 5;
        public const int STATUS = 6;
        public const int REMARKS = 7;
        public const int DATECREATE = 8;
        public const int DATELASTUPDATE = 9;
        public const int DATEEXPIRED = 10;
        public const int DATEBLOCKED = 11;
        public const int EXPIRED = 12;
        public const int PIN = 13;


        public CCVCardsTableClass(DataBaseClass database)
            : base(database)
        {
            tablename = db.Settings.ccvcardstable;

            fieldnames = new string[FIELD_COUNT];
            fieldnames[ID] = FIELDNAME_PRIMARY;
            fieldnames[CARDNUMBER] = "cardnumber";
            fieldnames[CUSTOMNUMBER] = "customernumber";
            fieldnames[NAME] = "name";
            fieldnames[MARK] = "mark";
            fieldnames[BLOCKED] = "blocked";
            fieldnames[STATUS] = "status";
            fieldnames[REMARKS] = "remarks";
            fieldnames[DATECREATE] = "date_create";
            fieldnames[DATELASTUPDATE] = "date_lastupdate";
            fieldnames[DATEEXPIRED] = "date_expired";
            fieldnames[DATEBLOCKED] = "date_blocked";
            fieldnames[EXPIRED] = "expired";
            fieldnames[PIN] = "pin";

            fieldtypes = new string[FIELD_COUNT];

            fieldtypes[ID] = "INT NOT NULL AUTO_INCREMENT";
            fieldtypes[CARDNUMBER] = "VARCHAR(30)";
            fieldtypes[CUSTOMNUMBER] = "VARCHAR(30)";
            fieldtypes[NAME] = "VARCHAR(100)";
            fieldtypes[MARK] = "VARCHAR(6)";
            fieldtypes[BLOCKED] = "BOOL";
            fieldtypes[STATUS] = "VARCHAR(100)";
            fieldtypes[REMARKS] = "VARCHAR(255)";
            fieldtypes[DATECREATE] = "BIGINT";
            fieldtypes[DATELASTUPDATE] = "BIGINT";
            fieldtypes[DATEEXPIRED] = "BIGINT";
            fieldtypes[DATEBLOCKED] = "BIGINT";
            fieldtypes[EXPIRED] = "BOOL";
            fieldtypes[PIN] = "VARCHAR(10)";
        }

        public int[] FieldIds
        {
            get { return new int[] { ID, CARDNUMBER, CUSTOMNUMBER, NAME, MARK, BLOCKED, STATUS, REMARKS, DATECREATE, DATELASTUPDATE, DATEEXPIRED, DATEBLOCKED, EXPIRED, PIN }; }
        }
 
     }
}
