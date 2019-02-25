using System;
using System.Data;
using DAL.AutoSearch.CostCenterTDSTableAdapters;

namespace BLL.AutoSearch
{
    public class CostCenterBll
    {
        public DataTable GetCostCenter(int whId)
        {
            try
            {
                sprCostCenterTableAdapter adp = new sprCostCenterTableAdapter();
                return adp.GetData(whId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
            
        }
    }
}
