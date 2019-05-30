using System;
using System.Data;
using DAL.Inventory.SupplierTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class SupplierDal
    {
        private DataTable _dt = new DataTable();
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
        public string GetSupplierName(int supplierId)
        {
            DataTable dt = GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strSupplierName"].ToString();
            }
            return string.Empty;
        }
        public string GetSupplierAddress(int supplierId)
        {
            DataTable dt = GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strOrgAddress"].ToString();
            }
            return string.Empty;
        }
        public string GetSupplierEmail(int supplierId)
        {
            DataTable dt = GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strOrgMail"].ToString();
            }
            return string.Empty;
        }
        public string GetSupplierPhone(int supplierId)
        {
            DataTable dt = GetSupplier(supplierId);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["strOrgContactNo"].ToString();
            }
            return string.Empty;
        }
        public int  GetCoaId(int supplierId)
        {
            _dt = GetSupplier(supplierId);
            if (_dt.Rows.Count > 0)
            {
                return _dt.GetAutoId("intCOAID");
            }

            return 0;
        }
    }
}
