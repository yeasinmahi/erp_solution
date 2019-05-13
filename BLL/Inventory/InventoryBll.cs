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
    }
}
