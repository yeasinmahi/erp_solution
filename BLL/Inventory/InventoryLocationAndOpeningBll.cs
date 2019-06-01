using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class InventoryLocationAndOpeningBll
    {
        private readonly InventoryLocationAndOpeningDal _dal = new InventoryLocationAndOpeningDal();

        public int Insert(int intItem, int unitId, int whId, int locationId, int enroll)
        {
            return _dal.Insert(intItem, unitId, whId, locationId, enroll);
        }
        public DataTable GetInventoryLocationOpening(int intItem, int unitId, int whId, int locationId, int enroll)
        {
            return _dal.GetInventoryLocationOpening(intItem, whId, locationId);
        }
    }
}
