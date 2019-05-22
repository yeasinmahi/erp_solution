using System;
using System.Data;
using DAL.Inventory.InventoryTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class InventoryDal
    {
        private DataTable _dt = new DataTable();
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
        public int Insert(int intInOutReffId, int intItemId, decimal numTransactionQty, decimal monTransactionValue, decimal numCurrentQty, decimal monCurrentValue, int intUnitId, int intWhid, int intLocationId, int intTransactionTypeId, bool ysnOld, int intDailyJvId)
        {
            try
            {
                tblInventory1TableAdapter adp = new tblInventory1TableAdapter();
                _dt = adp.Insert1(intInOutReffId,intItemId,numTransactionQty,monTransactionValue,numCurrentQty,monCurrentValue,intUnitId,intWhid,intLocationId,intTransactionTypeId,ysnOld,intDailyJvId);
                return _dt.GetAutoId("intAutoID");
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int InsertBySpInventoryTransection(int intUnitId, int intWhid, int intLocationId, int intItemId, decimal numTransactionQty, decimal monTransactionValue, int intInOutReffId, int intTransactionTypeId)
        {
            try
            {
                sprInventoryTransactionTableAdapter adp = new sprInventoryTransactionTableAdapter();
                _dt = adp.InsertBySpInventoryTransection(intUnitId, intWhid, intLocationId, intItemId, numTransactionQty, monTransactionValue,intInOutReffId, intTransactionTypeId);
                return _dt.GetAutoId("autoId");
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
