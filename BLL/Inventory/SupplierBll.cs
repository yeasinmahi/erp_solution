using System.Data;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class SupplierBll
    {
        private readonly SupplierDal _dal = new SupplierDal();
        public DataTable GetSupplier(int supplierId)
        {
            return _dal.GetSupplier(supplierId);
        }
        public string GetSupplierName(int supplierId)
        {
            return _dal.GetSupplierName(supplierId);
        }
        public string GetSupplierAddress(int supplierId)
        {
            return _dal.GetSupplierAddress(supplierId);
        }
        public string GetSupplierEmail(int supplierId)
        {
            return _dal.GetSupplierEmail(supplierId);
        }
        public string GetSupplierPhone(int supplierId)
        {
            return _dal.GetSupplierPhone(supplierId);
        }
        public int GetCoaId(int supplierId)
        {
            return _dal.GetCoaId(supplierId);
        }
    }
}
