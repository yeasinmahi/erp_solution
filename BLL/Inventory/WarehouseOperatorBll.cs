using System;
using System.Data;
using System.Linq;
using DAL.Inventory.WarehouseOperatorTdsTableAdapters;
using Utility;

namespace BLL.Inventory
{
    public class WarehouseOperatorBll
    {
        private readonly tblWearHouseOperatorTableAdapter _adp = new tblWearHouseOperatorTableAdapter();
        private DataTable _dt;
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
        //public bool IsSuperUser(int enroll)
        //{
        //    try
        //    {
        //        _dt = GetWarehouseByEnroll(enroll);
        //        DataRow row = _dt.GetRow("", 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
