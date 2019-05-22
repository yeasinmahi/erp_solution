using System;
using System.Data;
using DAL.Inventory.InventoryAdjustmentTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class InventoryAdjustmentDal
    {
        private DataTable _dt = new DataTable();
        public DataTable GetAllInventoryAdjustments()
        {
            try
            {
                tblInventoryAdjustmentTableAdapter adp = new tblInventoryAdjustmentTableAdapter();
                return adp.GetData();
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetInventoryAdjustmentByWh(int whId)
        {
            try
            {
                _dt = GetAllInventoryAdjustments();
                return _dt.GetRows("intWHID", whId);
                
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetLabel1PendingInventoryAdjustmentByWh(int whId)
        {
            try
            {
                _dt = GetInventoryAdjustmentByWh(whId);
                return _dt.GetRows("ysnCompleteL1", false);

            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetLabel2PendingInventoryAdjustmentByWh(int whId)
        {
            try
            {
                _dt = GetInventoryAdjustmentByWh(whId);
                return _dt.GetRows("ysnCompleteL1", true).GetRows("ysnCompleteL2", false);

            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
