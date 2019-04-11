using System;
using System.Data;
using DAL.Inventory.WarehouseTdsTableAdapters;

namespace BLL.Inventory
{
    public class WareHouseBll
    {
        public DataTable GetUnitIdByWhId(int whId)
        {
            try
            {
                tblWearHouseTableAdapter adp = new tblWearHouseTableAdapter();
                return adp.GetData(whId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
            
        }
    }
}
