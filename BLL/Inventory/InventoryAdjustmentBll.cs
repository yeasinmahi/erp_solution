using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class InventoryAdjustmentBll
    {
        private readonly InventoryAdjustmentDal _dal = new InventoryAdjustmentDal();
        public DataTable GetLabel1PendingInventoryAdjustmentByWh(int whId)
        {
            return _dal.GetLabel1PendingInventoryAdjustmentByWh(whId);
        }
        public DataTable GetLabel2PendingInventoryAdjustmentByWh(int whId)
        {
            return _dal.GetLabel2PendingInventoryAdjustmentByWh(whId);
        }
    }
}
