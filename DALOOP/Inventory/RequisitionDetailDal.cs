using System;
using System.Data;
using DAL.Inventory.RequisitionDetailTdsTableAdapters;

namespace DALOOP.Inventory
{
    public class RequisitionDetailDal
    {
        private DataTable _dt = new DataTable();
        public bool UpdateIssueQuantity(decimal issueQty, int reqId,int itemId)
        {
            try
            {
                tblRequisitionDetailTableAdapter adp = new tblRequisitionDetailTableAdapter();
                _dt= adp.UpdateIssueQuantity(issueQty, reqId, itemId);
                return _dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
