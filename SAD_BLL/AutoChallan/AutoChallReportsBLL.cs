
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.AutoChallan.AutoChallanReportTDSTableAdapters;
using System.Data;

namespace SAD_BLL.AutoChallan
{
    public class autoChallReportsBLL
    {
        public DataTable getDeliveryChallanCheck(int custid, string slipno)
        {
            try
            {
                sprRemoteDeliveryChallanCheckTableAdapter deliveryChallancheck = new sprRemoteDeliveryChallanCheckTableAdapter();
                return deliveryChallancheck.GetCheckChallan(custid, slipno);
            }
            catch { return new DataTable(); }
        }
    }
}