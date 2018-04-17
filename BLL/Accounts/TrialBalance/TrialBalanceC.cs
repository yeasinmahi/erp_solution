using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.TrialBalance;
using DAL.Accounts.TrialBalance.TBTDSTableAdapters;
using GLOBAL_BLL;

namespace BLL.Accounts.TrialBalance
{
    public class TrialBalanceC
    {
        public TBTDS.SprAccountsTrialBalanceGetDataDataTable GetTBData(string fromDate,string toDate,string userID,string unitID,ref string unitName,ref string unitAddress )
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value.Date;
            }
            catch { }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value.Date;
            }
            catch { to = DateTime.Now.Date; }

            SprAccountsTrialBalanceGetDataTableAdapter adp = new SprAccountsTrialBalanceGetDataTableAdapter();
            return adp.GetData(frm,to,int.Parse(userID),int.Parse(unitID),ref unitName,ref unitAddress);

        }
    }
}
