using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLOBAL_BLL;
using SAD_DAL.Analysis;
using SAD_DAL.Analysis.SalesAnalysisTDSTableAdapters;



namespace SAD_BLL.Analysis
{
    public class SalesAnalysisC
    {
        public SalesAnalysisTDS.SprSalesReportTargetAchievementDataTable GetDayWiseSales(string date, string customerId,string productId, string userID, string unitID,string customerType,string salesOffice,bool isPromotionIncluded, ref string unitName, ref string unitAddress)
        {
             DateTime? to = null;
           
            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(date).Value;
            }
            catch { to = DateTime.Now.Date; }

            int? cus = null, pro = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pro = int.Parse(productId); }
            catch { }

            SprSalesReportTargetAchievementTableAdapter ta = new SprSalesReportTargetAchievementTableAdapter();
            return ta.GetData(to, cus, pro, int.Parse(userID), int.Parse(unitID), int.Parse(customerType), int.Parse(salesOffice), isPromotionIncluded, ref unitName, ref unitAddress);
        }
    }
}
