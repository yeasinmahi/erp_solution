using System;
using System.Data;
using DAL.Inventory.InventoryLocationAndOpeningTableAdapters;

namespace DALOOP.Inventory
{
    public class InventoryLocationAndOpeningDal
    {
        private DataTable _dt = new DataTable();
        public int Insert(int intItem, int unitId, int whId, int locationId, int enroll)
        {
            try
            {
                tblInventoryLocationAndOpeningTableAdapter adp = new tblInventoryLocationAndOpeningTableAdapter();
                _dt =  adp.Insert1(intItem, unitId, whId, locationId, enroll);
                if (_dt.Rows.Count >0)
                {
                    return Convert.ToInt32(_dt.Rows[0]["intItemID"].ToString());
                }

                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public DataTable GetInventoryLocationOpening(int intItem, int whId, int locationId)
        {
            try
            {
                tblInventoryLocationAndOpening1TableAdapter adp = new tblInventoryLocationAndOpening1TableAdapter();
                return adp.GetData(intItem, whId, locationId);
                
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
