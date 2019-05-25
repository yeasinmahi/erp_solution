using System;
using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class InventoryBll
    {
        private readonly InventoryDal _dal = new InventoryDal();
        private DataTable _dt = new DataTable();
        public int GetInventoryJvByDateType(DateTime transectionDate, int transectionTypeId)
        {
            _dt =  _dal.GetInventoryJvByDateType(transectionDate, transectionTypeId);
            if (_dt.Rows.Count > 0)
            {
                return Convert.ToInt32(_dt.Rows[0]["intDailyJvId"].ToString());
            }
            return 0;
        }
        public int Insert(int intInOutReffId, int intItemId, decimal numTransactionQty, decimal monTransactionValue, decimal numCurrentQty, decimal monCurrentValue, int intUnitId, int intWhid, int intLocationId, int intTransactionTypeId, bool ysnOld, int intDailyJvId)
        {
            return _dal.Insert(intInOutReffId, intItemId, numTransactionQty, monTransactionValue, numCurrentQty, monCurrentValue, intUnitId, intWhid, intLocationId, intTransactionTypeId, ysnOld, intDailyJvId);
        }
        public int InsertBySpInventoryTransection(int intUnitId, int intWhid, int intLocationId, int intItemId, decimal numTransactionQty, decimal monTransactionValue, int intInOutReffId, int intTransactionTypeId)
        {
            return _dal.InsertBySpInventoryTransection(intUnitId, intWhid, intLocationId, intItemId, numTransactionQty, monTransactionValue, intInOutReffId, intTransactionTypeId);
        }
    }
}
