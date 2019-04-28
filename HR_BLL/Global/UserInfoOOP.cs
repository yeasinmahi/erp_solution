using HR_DAL.Global.UserInfoTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Global
{
   public class UserInfoOOP
    {
        public DataTable getuserinfo(int enroll)
        {
            try{
                tblUserInfoTableAdapter adp = new tblUserInfoTableAdapter();
                return adp.GetData(enroll);
            }
            catch { return new DataTable(); }
        }

    }
}
