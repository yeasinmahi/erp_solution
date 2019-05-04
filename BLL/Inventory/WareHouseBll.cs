﻿using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class WareHouseBll
    {
        private readonly WareHouseDal _dal = new WareHouseDal();
        private readonly WarehouseOperatorDal _dalOp = new WarehouseOperatorDal();

        public DataTable GetAllWarehouseByEnroll(int enroll)
        {
            if (_dalOp.IsSuperUser(enroll) || _dalOp.IsAllPoAccess(enroll))
            {
                return _dal.GetAllWarehouse();
            }
            if (_dalOp.IsStoreUser(enroll))
            {
                return _dal.GetAllWarehouseByEnroll(enroll);
            }
            if (_dalOp.IsIndentUser(enroll))
            {
                return _dal.GetIndentWarehouse(enroll);
            }
            return _dal.GetAllWarehouse();
        }

    }
}
