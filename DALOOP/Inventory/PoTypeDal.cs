using System;
using System.Data;
using DAL.Inventory.PoTypeTdsTableAdapters;

namespace DALOOP.Inventory
{
    public class PoTypeDal
    {
        public DataTable GetAllPoType()
        {
            try
            {
                tblPOTypeTableAdapter adp = new tblPOTypeTableAdapter();
                return adp.GetData();
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
    }
}
