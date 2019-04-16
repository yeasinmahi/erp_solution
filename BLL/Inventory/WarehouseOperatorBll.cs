using System;
using System.Data;
using System.Linq;
using DAL.Inventory.WarehouseOperatorTdsTableAdapters;

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
        //        _dt= GetWarehouseByEnroll(enroll);
        //        DataRow row = (from DataRow dr in _dt.Rows
        //            where (string)dr["CountryName"] == countryName
        //            select dr).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
