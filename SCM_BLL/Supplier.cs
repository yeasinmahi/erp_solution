
using System;
using System.Data;
using SCM_DAL.SupplierTableAdapters;
namespace SCM_BLL
{
    public class Supplier
    {
        public DataTable GetSupplierInfo(int type, int unitId, out string message)
        {
            message = string.Empty;
            try
            {
                sprSupplierInfoTableAdapter adp = new sprSupplierInfoTableAdapter();
                return adp.GetData(type, unitId);
            }
            catch (Exception e)
            {
                message = e.Message;
                return new DataTable();
            }
            
        }
    }
}
