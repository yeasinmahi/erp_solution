using System;
using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class PoTypeBll
    {
        private readonly PoTypeDal _dal = new PoTypeDal();
        public DataTable GetAllPoType()
        {
            return _dal.GetAllPoType();
        }
    }
}
