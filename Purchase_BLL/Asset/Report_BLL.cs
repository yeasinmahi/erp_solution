using Purchase_DAL.Asset.ReportTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_BLL.Asset
{
    public class Report_BLL
    {
        public DataTable GetData(int intPart  , string   xml, int unit  ,  int jobstation, DateTime? dteFrom , DateTime? dteTo , int  intRptType ,int intEnroll)
        {
            try
            {
                SprAssetReportTableAdapter adp = new SprAssetReportTableAdapter();
                return adp.GetReportData(intPart, xml, unit, jobstation,  dteFrom, dteTo, intRptType, intEnroll);
            }
            catch (Exception ex ){ return new DataTable(); }
            
            
        }
    }
}
