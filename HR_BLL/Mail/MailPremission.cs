using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Mail;
using HR_DAL.Mail.MailTypeTDSTableAdapters;
using HR_DAL.Mail.MailPermissionTDSTableAdapters;

namespace HR_BLL.Mail
{
    public class MailPremission
    {
        public MailPermissionTDS.QryHRMailPremissionInfoDataTable GetMailPermissionDetailsByMailTypeID(int typeID)
        {
            QryHRMailPremissionInfoTableAdapter adp = new QryHRMailPremissionInfoTableAdapter();
            return adp.GetMailPermissionDataByTypeID(typeID);
        }


        public void UpdateMailPermission(int ID,string  strUserCode,string strName,string strEmail,bool ysnMailUserEnable,int intEmployeeID)
        {
        }

        public void InsertMailPermission(int empID, string mailTypes, int userID)
        {

        }

    }
}
