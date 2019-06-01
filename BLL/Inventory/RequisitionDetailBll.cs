using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class RequisitionDetailBll
    {
        private readonly RequisitionDetailDal _dal = new RequisitionDetailDal();
        private DataTable _dt = new DataTable();

        public bool UpdateIssueQuantity(decimal issueQty, int reqId, int itemId)
        {
            return _dal.UpdateIssueQuantity(issueQty, reqId, itemId); 
        }
    }
}
