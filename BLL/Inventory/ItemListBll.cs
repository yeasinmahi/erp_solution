using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class ItemListBll
    {
        private readonly ItemListDal _dal = new ItemListDal();
        private DataTable _dt = new DataTable();
        public DataTable GetItem(int itemid)
        {
            return _dal.GetItem(itemid);
        }
        public int GetItemCoaId(int itemid)
        {
            _dt = GetItem(itemid);
            if (_dt.Rows.Count>0)
            {
                return Convert.ToInt32(_dt.Rows[0]["intCOAID"].ToString());
            }
            return 0;
        }
    }
}
