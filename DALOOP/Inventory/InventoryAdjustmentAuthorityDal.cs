using System;
using System.Data;
using DAL.Inventory.InventoryAdjustmentAuthorityTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class InventoryAdjustmentAuthorityDal
    {
        private DataTable _dt = new DataTable();
        public DataTable GetInventoryAdjustmentApproval()
        {
            try
            {
                tblInventoryAdjustmentAuthorityTableAdapter adp = new tblInventoryAdjustmentAuthorityTableAdapter();
                return adp.GetData();
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetInventoryAdjustmentApprovalByEnroll(int enroll)
        {
            try
            {
                _dt = GetInventoryAdjustmentApproval();
                return _dt.GetRows("intEnrollment", enroll);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetInventoryAdjustmentApprovalByWhId(int whId)
        {
            try
            {
                _dt = GetInventoryAdjustmentApproval();
                return _dt.GetRows("intWHID", whId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public int GetInventoryAdjustmentApprovalLabel(int enroll, int whId)
        {
            try
            {
                _dt = GetInventoryAdjustmentApproval();
                _dt = _dt.GetRows("intWHID", whId).GetRows("intEnrollment", enroll);
                if (_dt.Rows.Count > 0)
                {
                    if (_dt.GetRow("intLavel", 1) != null) return 1;
                    if (_dt.GetRow("intLavel", 2) != null) return 2;
                    return 0;
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
