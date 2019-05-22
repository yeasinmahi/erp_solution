using System;
using System.Data;
using DAL.Inventory.StoreIssueTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class StoreIssueDal
    {
        private DataTable _dt = new DataTable();
        public int Insert(int intUnitId, int intWhid, int intSrid, string strSrNo,string dteSrDate,string strReceivedBy,
           int intLastActionBy, int intCostCenter)
        {
            try
            {
                tblStoreIssueTableAdapter adp = new tblStoreIssueTableAdapter();
                _dt = adp.Insert1(intUnitId, intWhid, intSrid, strSrNo, dteSrDate, strReceivedBy,
                    intLastActionBy, intCostCenter);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.GetAutoId("intIssueID");
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
