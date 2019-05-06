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
            DataTable dt = _dal.GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strSupplierName"].ToString();
            }
            return string.Empty;
        }
        public string GetSupplierAddress(int supplierId)
        {
            DataTable dt = _dal.GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strOrgAddress"].ToString();
            }
            return string.Empty;
        }
        public string GetSupplierEmail(int supplierId)
        {
            DataTable dt = _dal.GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strOrgMail"].ToString();
            }
            return string.Empty;
        }
        public string GetSupplierPhone(int supplierId)
        {
            DataTable dt = _dal.GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strOrgContactNo"].ToString();
            }
            return string.Empty;
        }
    }
}
