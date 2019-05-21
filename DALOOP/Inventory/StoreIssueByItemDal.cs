using System;
using System.Data;
using DAL.Inventory.StoreIssueByItemTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class StoreIssueByItemDal
    {
        private DataTable _dt = new DataTable();

        public int Insert(int intIssueId, int intItemId, int intUnitId, int intWhId, int intDept, int intSection, string strUseFor, int intLocation, decimal numQty, decimal monValue, string strSection, int intCostCenter, string strRemarks)
        {
            try
            {
                tblStoreIssueByItemTableAdapter adp = new tblStoreIssueByItemTableAdapter();
                _dt = adp.Insert1(intIssueId, intItemId, intUnitId, intWhId, intDept, intSection, strUseFor, intLocation,
                    numQty, monValue, strSection, intCostCenter, strRemarks);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.GetAutoId("intAutoID");
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
