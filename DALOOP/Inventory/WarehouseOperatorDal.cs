using System;
using System.Data;
using DAL.Inventory.WarehouseOperatorTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class WarehouseOperatorDal
    {
        private readonly tblWearHouseOperatorTableAdapter _adp = new tblWearHouseOperatorTableAdapter();
        private DataTable _dt = new DataTable();
        public DataTable GetWarehouseByEnroll(int enroll)
        {
            try
            {
                return _adp.GetData(enroll);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public bool IsSuperUser(int enroll)
        {
            try
            {
                _dt = GetWarehouseByEnroll(enroll);
                DataRow row = _dt.GetRow("ysnSU", true);
                if (row != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsAllPoAccess(int enroll)
        {
            try
            {
                _dt = GetWarehouseByEnroll(enroll);
                DataRow row = _dt.GetRow("ysnAllUnitPO", true);
                if (row != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsStoreUser(int enroll)
        {
            try
            {
                _dt = GetWarehouseByEnroll(enroll);
                DataRow row = _dt.GetRow("ysnStoreUser", true);
                if (row != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool IsIndentUser(int enroll)
        {
            try
            {
                _dt = GetWarehouseByEnroll(enroll);
                DataRow row = _dt.GetRow("ysnIndent", true);
                if (row != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
