using DALOOP.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Inventory
{
    public class ItemCostingFGBll
    {
        private readonly ItemCostingFGDal _dal = new ItemCostingFGDal();
        private DataTable _dt = new DataTable();
        public DataTable GetItemCogs(int itemid)
        {
            return _dal.GetItemCogs(itemid);
        }
    }
}
