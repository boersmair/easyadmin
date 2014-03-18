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
    class CustomerTableClass : DataBaseTableClassBase
    {
        public const int FIELD_COUNT = 35;
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
        public const int BLOCKED = 20;
        public const int REMARKS = 21;
        public const int DISCOUNTPRODUCTSPERC = 22;
        public const int DISCOUNTLABOUR = 23;
        public const int DISCOUNT95 = 24;
        public const int DISCONTDIESEL = 25;
        public const int DISCOUNT98 = 26;
        public const int DATECREATE = 27;
        public const int DATELASTUPDATE = 28;
        public const int DATEEXPIRED = 29;
        public const int DATEBLOCKED = 30;
        public const int DATACCVDIRECTDEBIT = 31;
        public const int EXPIRED = 32;
        public const int SAVEFOLDER = 33;
        public const int EMAIL = 34;
 

        public CustomerTableClass(DataBaseClass database) : base(database)
        {
            tablename = db.Settings.customertable;

            fieldnames = new string[FIELD_COUNT];
            fieldnames[ID] = FIELDNAME_PRIMARY;
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
            fieldnames[INVOICEPERIOD] = "invoiceinterval";
            fieldnames[CCVCATEGORY] = "ccvcategory";
            fieldnames[PHONE] = "phone";
            fieldnames[MOBILE] = "mobile";
            fieldnames[STATUS] = "status";
            fieldnames[BLOCKED] = "blocked";
            fieldnames[REMARKS] = "remarks";
            fieldnames[DISCOUNTPRODUCTSPERC] = "discountproductsperc";
            fieldnames[DISCOUNTLABOUR] = "discountlabour";
            fieldnames[DISCOUNT95] = "discount95";
            fieldnames[DISCONTDIESEL] = "discountdiesel";
            fieldnames[DISCOUNT98] = "discount98";
            fieldnames[DATECREATE] = "date_create";
            fieldnames[DATELASTUPDATE] = "date_lastupdate";
            fieldnames[DATEEXPIRED] = "date_expired";
            fieldnames[DATEBLOCKED] = "date_blocked";
            fieldnames[DATACCVDIRECTDEBIT] = "ccv_direct_debit";
            fieldnames[EXPIRED] = "expired";
            fieldnames[SAVEFOLDER] = "savefolder";
            fieldnames[EMAIL] = "email";

            fieldtypes = new string[FIELD_COUNT];

            fieldtypes[ID] = "INT NOT NULL AUTO_INCREMENT";
            fieldtypes[NUMBER] = "VARCHAR(30)";
            fieldtypes[TITLE] = "VARCHAR(30)";
            fieldtypes[FIRSTNAME] = "VARCHAR(100)";
            fieldtypes[NAME] = "VARCHAR(100)";
            fieldtypes[ATTN1] = "VARCHAR(100)";
            fieldtypes[ATTN2] = "VARCHAR(100)";
            fieldtypes[ADDRESS] = "VARCHAR(100)";
            fieldtypes[POSTALCODE] = "VARCHAR(10)";
            fieldtypes[CITY] = "VARCHAR(100)";
            fieldtypes[ADDRESSEXTRA] = "VARCHAR(100)";
            fieldtypes[IBAN] = "VARCHAR(100)";
            fieldtypes[FATNO] = "VARCHAR(100)";
            fieldtypes[RESELLER] = "BOOL";
            fieldtypes[PAYMENT] = "VARCHAR(100)";
            fieldtypes[INVOICEPERIOD] = "INT";
            fieldtypes[CCVCATEGORY] = "INT";
            fieldtypes[PHONE] = "VARCHAR(100)";
            fieldtypes[MOBILE] = "VARCHAR(100)";
            fieldtypes[STATUS] = "VARCHAR(100)";
            fieldtypes[BLOCKED] = "BOOL";
            fieldtypes[REMARKS] = "VARCHAR(255)";
            fieldtypes[DISCOUNTPRODUCTSPERC] = "DOUBLE";
            fieldtypes[DISCOUNTLABOUR] = "DOUBLE";
            fieldtypes[DISCOUNT95] = "DOUBLE";
            fieldtypes[DISCONTDIESEL] = "DOUBLE";
            fieldtypes[DISCOUNT98] = "DOUBLE";
            fieldtypes[DATECREATE] = "BIGINT";
            fieldtypes[DATELASTUPDATE] = "BIGINT";
            fieldtypes[DATEEXPIRED] = "BIGINT";
            fieldtypes[DATEBLOCKED] = "BIGINT";
            fieldtypes[DATACCVDIRECTDEBIT] = "BIGINT";
            fieldtypes[EXPIRED] = "BOOL";
            fieldtypes[SAVEFOLDER] = "VARCHAR(100)";
            fieldtypes[EMAIL] = "VARCHAR(100)";
        }

        public int[] FieldIds
        {
            get { return new int[] { ID, NUMBER, TITLE , FIRSTNAME, NAME, ATTN1, ATTN2, ADDRESS, POSTALCODE, CITY, 
                    ADDRESSEXTRA, IBAN, FATNO, RESELLER, PAYMENT, INVOICEPERIOD, CCVCATEGORY, PHONE, MOBILE, STATUS, BLOCKED, REMARKS, 
                    DISCOUNTPRODUCTSPERC, DISCOUNTLABOUR, DISCOUNT95, DISCONTDIESEL, DISCOUNT98, DATECREATE, DATELASTUPDATE, 
                    DATEEXPIRED, DATEBLOCKED, DATACCVDIRECTDEBIT, EXPIRED, SAVEFOLDER,EMAIL};
            }
        }
 
     }
}
