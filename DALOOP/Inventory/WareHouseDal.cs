using System;
using System.Data;
using DAL.Inventory.WarehouseTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    
    public class WareHouseDal
    {
        public DataTable GetAllWarehouse()
        {
            try
            {
                tblWearHouse1TableAdapter adp = new tblWearHouse1TableAdapter();
                return adp.GetData();
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
        public DataTable GetAllWarehouseByEnroll(int enroll)
        {
            try
            {
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetData(enroll);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
        public DataTable GetIndentWarehouse(int enroll)
        {
            try
            {
                DataTable dt = GetAllWarehouseByEnroll(enroll);
                DataTable row = dt.GetRows("ysnIndent", true);
                return row;
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
        
    }
}
