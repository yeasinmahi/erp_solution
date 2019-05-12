using System;
using System.Data;
using DAL.Inventory.InventoryTableAdapters;

namespace DALOOP.Inventory
{
    public class InventoryDal
    {
        public DataTable GetInventoryJvByDateType(DateTime transectionDate, int transectionTypeId)
        {
            try
            {
                tblInventoryTableAdapter adp = new tblInventoryTableAdapter();
                return adp.GetData(transectionDate, transectionTypeId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
