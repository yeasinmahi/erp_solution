using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class InventoryAdjustmentBll
    {
        private readonly InventoryAdjustmentDal _dal = new InventoryAdjustmentDal();
        public DataTable GetPendingInventoryAdjustmentByWh(int whId)
        {
            return _dal.GetPendingInventoryAdjustmentByWh(whId);
        }
    }
}
