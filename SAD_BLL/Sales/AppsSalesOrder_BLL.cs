using SAD_DAL.Sales.AppsOrderTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.Sales
{
    public class AppsSalesOrder_BLL
    {
        public DataTable OrderSummeryView(int part, string xml, int enroll, string ordernumber, int unitid, DateTime dteFrom, DateTime dteTo)
        {
           
            try
            {
                string rtnMessage = "";
                SprAppsRemoteSalesOrderTableAdapter adp = new SprAppsRemoteSalesOrderTableAdapter();
               return  adp.GetApprovalSummeryData(part, xml, enroll, ordernumber, unitid, dteFrom, dteTo, ref rtnMessage);
            }
           
            catch {return new DataTable(); }
            
        }
    }
}
