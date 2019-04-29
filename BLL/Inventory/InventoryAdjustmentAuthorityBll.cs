using DALOOP.Inventory;
using static Utility.AccessPermission;

namespace BLL.Inventory
{
    public class InventoryAdjustmentAuthorityBll
    {
        private readonly InventoryAdjustmentAuthorityDal _dal = new InventoryAdjustmentAuthorityDal();
        public InventoryAdjustmentPermission GetInventoryAdjustmentApprovalLabel(int enroll, int whId)
        {
            if (_dal.GetInventoryAdjustmentApprovalLabel(enroll, whId)==1)
            {
                return InventoryAdjustmentPermission.Lavel1;
            }
            if (_dal.GetInventoryAdjustmentApprovalLabel(enroll, whId) == 2)
            {
                return InventoryAdjustmentPermission.Lavel2;
            }
            if (_dal.GetInventoryAdjustmentApprovalLabel(enroll, whId) == 0)
            {
                return InventoryAdjustmentPermission.NoPermit;
            }
            return InventoryAdjustmentPermission.NoPermit;
        }
    }
}
