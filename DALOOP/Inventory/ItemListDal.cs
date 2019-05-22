using System;
using System.Data;
using DAL.Inventory.ItemListTableAdapters;

namespace DALOOP.Inventory
{
    public class ItemListDal
    {
        public DataTable GetItem(int itemId)
        {
            try
            {
                tblItemListTableAdapter adp = new tblItemListTableAdapter();
                return adp.GetData(itemId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
