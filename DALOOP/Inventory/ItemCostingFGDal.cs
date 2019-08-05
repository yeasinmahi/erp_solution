using DAL.Inventory.ItemCostingFGTdsTableAdapters;
using System;
using System.Data;

namespace DALOOP.Inventory
{
    public class ItemCostingFGDal
    {
        private DataTable _dt = new DataTable();

        public DataTable GetItemCogs(int itemId)
        {
            try
            {
                tblItemCostingFGTableAdapter adp = new tblItemCostingFGTableAdapter();
                return adp.GetData(itemId);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}
