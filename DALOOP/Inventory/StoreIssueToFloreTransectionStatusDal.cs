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
        public bool UpdateIsProcessed(bool isProcessed,int autoId)
        {
            try
            {
                tblStoreIssueToFloreTransectionStatus3TableAdapter adp = new tblStoreIssueToFloreTransectionStatus3TableAdapter();
                _dt = adp.UpdateIsProcessed(isProcessed,autoId);
                return _dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateJv(int jvId, int autoId)
        {
            try
            {
                tblStoreIssueToFloreTransectionStatus4TableAdapter adp = new tblStoreIssueToFloreTransectionStatus4TableAdapter();
                _dt = adp.UpdateJv(jvId, autoId);
                return _dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateCoaId1(int coaId1, int autoId)
        {
            try
            {
                tblStoreIssueToFloreTransectionStatus5TableAdapter adp = new tblStoreIssueToFloreTransectionStatus5TableAdapter();
                _dt = adp.UpdateCoaId(coaId1, autoId);
                return _dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateCoaId2(int coaId2, int autoId)
        {
            try
            {
                tblStoreIssueToFloreTransectionStatus6TableAdapter adp = new tblStoreIssueToFloreTransectionStatus6TableAdapter();
                _dt = adp.UpdateCoaId2(coaId2, autoId);
                return _dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
