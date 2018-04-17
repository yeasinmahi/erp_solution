using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.SupplierAuthorisedTDSTableAdapters;
using Purchase_DAL;

namespace Purchase_BLL
{
    public class SupplierAuthorised
    {
        public SupplierAuthorisedTDS.TblSupplierAuthorisedDataTable GetDataBySupplier(string supplier)
        {
            TblSupplierAuthorisedTableAdapter ta = new TblSupplierAuthorisedTableAdapter();
            return ta.GetDataBySupplier(int.Parse(supplier));
        }

        public SupplierAuthorisedTDS.TblSupplierAuthorisedDataTable GetDataById(string id)
        {
            TblSupplierAuthorisedTableAdapter ta = new TblSupplierAuthorisedTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }

        public void DisableEnableById(string id,string userId)
        {
            TblSupplierAuthorisedTableAdapter ta = new TblSupplierAuthorisedTableAdapter();
            ta.DisableEnableById(int.Parse(userId), int.Parse(id));
        }

        public void AddUpdate(ref string supplierAuthoId, string supplierId, string name
            , string contact, string email, string photoUrl, string signUrl, string userId)
        {
            int? id = null;
            try { id = int.Parse(supplierAuthoId); }
            catch { }
            SprSupplierAuthorisedAddUpdateTableAdapter ta = new SprSupplierAuthorisedAddUpdateTableAdapter();
            ta.GetData(ref id, int.Parse(supplierId), name, contact, email
                , int.Parse(userId), photoUrl, signUrl);
            
            supplierAuthoId = id.ToString();
        }
    }
}
