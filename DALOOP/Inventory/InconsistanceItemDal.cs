using System;
using System.Data;
using DAL.Inventory.InConsistanceItemTdsTableAdapters;

namespace DALOOP.Inventory
{
    public class InconsistanceItemDal
    {
        public DataTable Insert(int whId, int itemId, decimal itemQuantity, decimal itemValue, int locationId, int insertBy)
        {
            try
            {
                tblInconsistanceItemTableAdapter adp = new tblInconsistanceItemTableAdapter();
                return adp.Insert1(whId, itemId, itemQuantity, itemValue, locationId,insertBy);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
