using System;
using System.Data;
using DAL.Inventory.StoreIssueToFloreTransectionStatusTdsTableAdapters;
using Utility;

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
                    int inventoryStatusId = _dt.GetAutoId("autoId");
                    return inventoryStatusId;
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                tblStoreIssueToFloreTransectionStatus2TableAdapter adp = new tblStoreIssueToFloreTransectionStatus2TableAdapter();
                return adp.GetData();
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetTodays()
        {
            try
            {
                tblStoreIssueToFloreTransectionStatus1TableAdapter adp = new tblStoreIssueToFloreTransectionStatus1TableAdapter();
                return adp.GetTodays();
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetTodaysComplete()
        {
            _dt = GetTodays();
            if (_dt.Rows.Count > 0)
            {
                _dt = _dt.GetRows("isProcessed", true);
                return _dt;
            }
            return new DataTable();
        }
    }
}
