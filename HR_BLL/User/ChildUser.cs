using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.User;
using HR_DAL.User.ChildUserTDSTableAdapters;

namespace HR_BLL.User
{
    public class ChildUser
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ChildUserTDS.TblChildUserInfoDataTable GetAllActiveChildUser(string parentUser)
        {
            TblChildUserInfoTableAdapter ta = new TblChildUserInfoTableAdapter();
            return ta.GetData(int.Parse(parentUser));
        }

        public ChildUserTDS.TblChildUserInfoByCodeDataTable GetAllActiveChildUserOnCode(string parentUser)
        {
            TblChildUserInfoByCodeTableAdapter ta = new TblChildUserInfoByCodeTableAdapter();
            return ta.GetData(int.Parse(parentUser));
        }
    }
}
