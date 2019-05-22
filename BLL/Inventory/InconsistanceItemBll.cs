using System;
using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class InconsistanceItemBll
    {
        private readonly InconsistanceItemDal _dal = new InconsistanceItemDal();
        private DataTable _dt = new DataTable();

        public int Insert(int whId, int itemId, decimal itemQuantity, decimal itemValue, int locationId, int enroll)
        {
            _dt = _dal.Insert(whId,itemId, itemQuantity, itemValue, locationId, enroll);
            if (_dt.Rows.Count > 0)
            { 
                return Convert.ToInt32(_dt.Rows[0]["inConsistanceId"].ToString());
            }
            return 0;
        }
    }
}
