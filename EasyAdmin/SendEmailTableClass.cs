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
    class SendEmailTableClass : DataBaseTableClassBase
    {
        public const int FIELD_COUNT = 13;
        public const int ID = 0;
        public const int CUSTOMERTABLEID = 1;
        public const int CUSTOMERNUMBER = 2;
        public const int CUSTOMERNAME = 3;
        public const int MSTTYPE = 4; //afis12, invoice
        public const int MSGTXT = 5;
        public const int ISHTML = 6;
        public const int SUBJECT = 7;
        public const int EMAILTO = 8;
        public const int EMAILCC = 9;
        public const int EMAILBCC = 10;
        public const int SENDDATE = 11;
        public const int EMAILFROM = 12;
        //public const int ATTACHM1 = 13;
        //public const int ATTACHM2 = 14;
        //public const int ATTACHM3 = 15;
        //public const int ATTACHM4 = 16;
        //public const int ATTACHM5 = 17;
        EmailAttachmTableClass attmtable;

        public SendEmailTableClass(DataBaseClass database)
            : base(database)
        {
            tablename = db.Settings.emailsend;
            attmtable = new EmailAttachmTableClass(database);

            fieldnames = new string[FIELD_COUNT];
            fieldnames[ID] = FIELDNAME_PRIMARY;
            fieldnames[CUSTOMERTABLEID] = "customid";
            fieldnames[CUSTOMERNUMBER] = "customernumber";
            fieldnames[CUSTOMERNAME] = "customername";
            fieldnames[MSTTYPE] = "msgtype";
            fieldnames[MSGTXT] = "msgtxt";
            fieldnames[ISHTML] = "ishtml";
            fieldnames[SUBJECT] = "subject";
            fieldnames[EMAILTO] = "emailto";
            fieldnames[EMAILCC] = "emailcc";
            fieldnames[EMAILBCC] = "emailbcc";
            fieldnames[SENDDATE] = "senddate";
            fieldnames[EMAILFROM] = "emailfrom";
            //fieldnames[ATTACHM1] = "attachm1";
            //fieldnames[ATTACHM2] = "attachm2";
            //fieldnames[ATTACHM3] = "attachm3";
            //fieldnames[ATTACHM4] = "attachm4";
            //fieldnames[ATTACHM5] = "attachm5";

            fieldtypes = new string[FIELD_COUNT];

            fieldtypes[ID] = "INT UNSIGNED NOT NULL AUTO_INCREMENT";
            fieldtypes[CUSTOMERTABLEID] = "INT";
            fieldtypes[CUSTOMERNUMBER] = "VARCHAR(30)";
            fieldtypes[CUSTOMERNAME] = "VARCHAR(100)";
            fieldtypes[MSTTYPE] = "INT";
            fieldtypes[MSGTXT] = "VARCHAR(4096)";
            fieldtypes[ISHTML] = "BOOL";
            fieldtypes[SUBJECT] = "VARCHAR(255)";
            fieldtypes[EMAILTO] = "VARCHAR(255)";
            fieldtypes[EMAILCC] = "VARCHAR(255)";
            fieldtypes[EMAILBCC] = "VARCHAR(255)";
            fieldtypes[SENDDATE] = "BIGINT";
            fieldtypes[EMAILFROM] = "VARCHAR(255)";
            //fieldtypes[ATTACHM1] = "BLOB";
            //fieldtypes[ATTACHM2] = "BLOB";
            //fieldtypes[ATTACHM3] = "BLOB";
            //fieldtypes[ATTACHM4] = "BLOB";
            //fieldtypes[ATTACHM5] = "BLOB";
        }

        public int[] FieldIds
        {
            get { return new int[] { ID, CUSTOMERTABLEID, CUSTOMERNUMBER, CUSTOMERNAME, MSTTYPE, MSGTXT, ISHTML, SUBJECT, EMAILTO, EMAILCC, EMAILBCC, SENDDATE, EMAILFROM/*, ATTACHM1, ATTACHM2, ATTACHM3, ATTACHM4, ATTACHM5*/ }; }
        }

        public bool AddRow(object[] data, List<object[]> attachmentdata)
        {
            int id = InsertRow(data);
            if (id < 0)
                return false;

            if (attachmentdata.Count > 0 && attmtable!= null)
            {
                if (!attmtable.TableExist())
                {
                    if (!attmtable.CreateTable())
                        return false;
                }

                for (int i = 0; i < attachmentdata.Count; i++)
                {
                    attachmentdata[i][EmailAttachmTableClass.EMAILSENDID] = id;
                    if (!attmtable.Insert(attachmentdata[i]))
                        return false;
                }
            }
            return true;
        }

        public bool CreateTableFull()
        {
            if (!CreateTable())
                return false;

            if(!attmtable.TableExist())
                return attmtable.CreateTable();

            return true;
        }



    }

    class EmailAttachmTableClass : DataBaseTableClassBase
    {
        public const int FIELD_COUNT = 3;
        public const int ID = 0;
        public const int EMAILSENDID = 1;
        public const int ATTACHMFILELOC = 2;
        //public const int ATTACHMENT = 2;

        public EmailAttachmTableClass(DataBaseClass database)
            : base(database)
        {
            tablename = db.Settings.emailattachm;

            fieldnames = new string[FIELD_COUNT];
            fieldnames[ID] = FIELDNAME_PRIMARY;
            fieldnames[EMAILSENDID] = "emailsendid";
            fieldnames[ATTACHMFILELOC] = "attachmfileloc";
            //fieldnames[ATTACHMENT] = "ATTACHMENT";

            fieldtypes = new string[FIELD_COUNT];

            fieldtypes[ID] = "INT UNSIGNED NOT NULL AUTO_INCREMENT";
            fieldtypes[EMAILSENDID] = "INT UNSIGNED";
            fieldtypes[ATTACHMFILELOC] = "VARCHAR(1024)";
            //fieldtypes[ATTACHMENT] = "BLOB";
            foreignkeys.Add(String.Format("FOREIGN KEY ({0}) REFERENCES {1}({2}) ON DELETE CASCADE ON UPDATE CASCADE", fieldnames[EMAILSENDID], db.Settings.emailsend, FIELDNAME_PRIMARY));
        }

        public int[] FieldIds
        {
            get { return new int[] { ID, EMAILSENDID, ATTACHMFILELOC }; }
        }

    }

}
