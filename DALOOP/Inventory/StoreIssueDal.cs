using System;
using System.Data;
using DAL.Inventory.StoreIssueTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class StoreIssueDal
    {
        private DataTable _dt;
        public int Insert(int intUnitId, int intWhid, string dteIssueDate, int intSrid, string strSrNo,string dteSrDate,string strReceivedBy,
           int intLastActionBy, DateTime dteLastActionTime, int intCostCenter)
        {
            try
            {
                tblStoreIssueTableAdapter adp = new tblStoreIssueTableAdapter();
                _dt = adp.Insert1(intUnitId, intWhid, dteIssueDate, intSrid, strSrNo, dteSrDate, strReceivedBy,
                    intLastActionBy, dteLastActionTime, intCostCenter);
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
