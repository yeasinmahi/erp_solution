using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial.CostingTDSTableAdapters;
using Purchase_DAL.Commercial;
using System.Data;

namespace Purchase_BLL.Commercial
{
    public class Report
    {
        public DataTable GetCostingReport(int lcID)
        {
            SprCommercialGetCostingReportTableAdapter adp = new SprCommercialGetCostingReportTableAdapter();
            return (DataTable)adp.GetCostingReportData(lcID);
        }
            
    }
}
