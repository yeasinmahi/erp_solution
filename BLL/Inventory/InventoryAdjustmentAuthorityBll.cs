using DALOOP.Inventory;
using static Utility.AccessPermission;

namespace BLL.Inventory
{
    public class InventoryAdjustmentAuthorityBll
    {
        private readonly InventoryAdjustmentAuthorityDal _dal = new InventoryAdjustmentAuthorityDal();
        public int GetInventoryAdjustmentApprovalLabel(int enroll, int whId)
        {
            return _dal.GetInventoryAdjustmentApprovalLabel(enroll, whId);
        }
    }
}
