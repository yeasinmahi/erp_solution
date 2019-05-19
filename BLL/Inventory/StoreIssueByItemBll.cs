using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class StoreIssueByItemBll
    {
        private readonly StoreIssueByItemDal _dal = new StoreIssueByItemDal();
        public int Insert(int intIssueId, int intItemId, int intUnitId, int intWhId, int intDept, int intSection, string strUseFor, int intLocation, decimal numQty, decimal monValue, string strSection, int intCostCenter, string strRemarks)
        {
            return _dal.Insert(intIssueId, intItemId, intUnitId, intWhId, intDept, intSection, strUseFor, intLocation,
                numQty, monValue, strSection, intCostCenter, strRemarks);
        }
    }
}
