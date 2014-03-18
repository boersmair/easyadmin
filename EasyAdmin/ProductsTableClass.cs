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
    class ProductsTableClass : DataBaseTableClassBase
    {
        public const int FIELD_COUNT = 12;
        public const int ID = 0;
        public const int ARTICLENUMBER = 1;
        public const int DESCRIPTION = 2;
        public const int FATCAT = 3;
        public const int PRICE = 4;
        public const int PRICEEXFAT = 5;
        public const int STATUS = 6;
        public const int REMARKS = 7;
        public const int CATEGORY = 8;
        public const int CATEGORYID = 9;
        public const int DATECREATE = 10;
        public const int DATELASTUPDATE = 11;


        public ProductsTableClass(DataBaseClass database) : base(database)
        {
            tablename = db.Settings.producttable;

            fieldnames = new string[FIELD_COUNT];
            fieldnames[ID] = FIELDNAME_PRIMARY;
            fieldnames[ARTICLENUMBER] = "articlenumber";
            fieldnames[DESCRIPTION] = "description";
            fieldnames[FATCAT] = "fatcat";
            fieldnames[PRICE] = "price";
            fieldnames[PRICEEXFAT] = "priceexfat";
            fieldnames[STATUS] = "status";
            fieldnames[REMARKS] = "remarks";
            fieldnames[CATEGORY] = "category";
            fieldnames[CATEGORYID] = "categoryid";
            fieldnames[DATECREATE] = "date_create";
            fieldnames[DATELASTUPDATE] = "date_lastupdate";
 
            fieldtypes = new string[FIELD_COUNT];

            fieldtypes[ID] = "INT NOT NULL AUTO_INCREMENT";
            fieldtypes[ARTICLENUMBER] = "VARCHAR(30)";
            fieldtypes[DESCRIPTION] = "VARCHAR(100)";
            fieldtypes[FATCAT] = "INT";
            fieldtypes[PRICE] = "DOUBLE";
            fieldtypes[PRICEEXFAT] = "BOOL";
            fieldtypes[STATUS] = "VARCHAR(100)";
            fieldtypes[REMARKS] = "VARCHAR(255)";
            fieldtypes[CATEGORY] = "VARCHAR(100)";
            fieldtypes[CATEGORYID] = "INT";
            fieldtypes[DATECREATE] = "BIGINT";
            fieldtypes[DATELASTUPDATE] = "BIGINT";
        }

        public int[] FieldIds
        {
            get { return new int[] { ID, ARTICLENUMBER, DESCRIPTION, FATCAT, PRICE, PRICEEXFAT, STATUS, REMARKS, CATEGORY, CATEGORYID, DATECREATE, DATELASTUPDATE }; }
        }
 
     }
}
