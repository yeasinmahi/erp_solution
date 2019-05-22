using System;
using System.Data;
using DAL.Inventory.SupplierTdsTableAdapters;

namespace DALOOP.Inventory
{
    public class SupplierDal
    {
        public DataTable GetSupplier(int supplierId)
        {
            try
            {
                tblSupplierTableAdapter adp = new tblSupplierTableAdapter();
                return adp.GetData(supplierId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
    }
}
