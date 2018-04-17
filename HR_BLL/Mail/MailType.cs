using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Mail;
using HR_DAL.Mail.MailTypeTDSTableAdapters;

namespace HR_BLL.Mail
{
    public class MailType
    {

        public MailTypeTDS.TblMailTypeInfoDataTable GetMailType()
        {
            TblMailTypeInfoTableAdapter adp = new TblMailTypeInfoTableAdapter();
            return adp.GetMailTypeData();
        }


        public MailTypeTDS.TblMailTypeInfoDataTable GetMailTypeDetailsByID(int mailTypeID)
        {
            TblMailTypeInfoTableAdapter adp = new TblMailTypeInfoTableAdapter();
            return adp.GetMailTypeDetailsDataByID(mailTypeID);
        }

    }
}
