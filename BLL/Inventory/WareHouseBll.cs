using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class WareHouseBll
    {
        private readonly WareHouseDal _bll = new WareHouseDal();
        private readonly WarehouseOperatorDal _bllOp = new WarehouseOperatorDal();
        DataTable dt = new DataTable();
        public DataTable GetUnitIdByWhId(int whId)
        {
            return _bll.GetUnitIdByWhId(whId);
        }

        public DataTable GetGetAllWarehouseByEnroll(int enroll)
        {
            if (_bllOp.IsSuperUser(enroll) || _bllOp.IsAllPoAccess(enroll))
            {
                return _bll.GetAllWarehouse();
            }
            if (_bllOp.IsStoreUser(enroll))
            {
                return _bll.GetAllWarehouseByEnroll(enroll);
            }
            if (_bllOp.IsIndentUser(enroll))
            {
                return _bll.GetIndentWarehouse(enroll);
            }
            return _bll.GetAllWarehouse();
        }

    }
}
