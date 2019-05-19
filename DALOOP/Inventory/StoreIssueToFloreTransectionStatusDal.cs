using System;
using System.Data;
using DAL.Inventory.StoreIssueToFloreTransectionStatusTdsTableAdapters;

namespace DALOOP.Inventory
{
    public class StoreIssueToFloreTransectionStatusDal
    {
        private DataTable _dt;
        public int Insert(int itemId,int inventoryId)
        {
            try
            {
                tblStoreIssueToFloreTransectionStatusTableAdapter adp = new tblStoreIssueToFloreTransectionStatusTableAdapter();
                _dt = adp.Insert1(itemId, inventoryId);
                if (_dt.Rows.Count > 0)
                {
                    int inventoryStatusId = Convert.ToInt32(_dt.Rows[0]["autoId"].ToString());
                    return inventoryStatusId;
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
