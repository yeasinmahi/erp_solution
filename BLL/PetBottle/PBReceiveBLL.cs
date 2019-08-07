using DAL.PetBottle.PBReceiveTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PetBottle
{
    public class PBReceiveBLL
    {
        public DataTable GetPetBottlePONo()
        {
            DataTable dt = new DataTable();
            try
            {
                PetBottlePurchaseTableAdapter adapter = new PetBottlePurchaseTableAdapter();
                dt = adapter.GetPBReceivePONo(1,null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                    null, null, null, null, null, null, null, null, null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetSupplier(int SupplierID)
        {
            DataTable dt = new DataTable();
            try
            {
                SupplierTableAdapter adapter = new SupplierTableAdapter();
                dt = adapter.GetSupplierData(SupplierID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetPOItem(int POID)
        {
            DataTable dt = new DataTable();
            try
            {
                PetBottlePurchaseTableAdapter adapter = new PetBottlePurchaseTableAdapter();
                dt = adapter.GetPBReceivePONo(2, POID, null, null, null, null, null, null, null, null, null, null, null, null, null,
                    null, null, null, null, null, null, null, null, null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DataTable GetPOQtyAmount(int POID, int ItemID)
        {
            DataTable dt = new DataTable();
            try
            {
                POQtyAmountTableAdapter adapter = new POQtyAmountTableAdapter();
                dt = adapter.GetItemQtyRateData(POID, ItemID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public decimal GetPreReceivePOQty(int POID, int ItemID)
        {
            decimal Qty = 0;
            try
            {
                PreReceiveTableAdapter adapter = new PreReceiveTableAdapter();
               object  _obj = adapter.GetPreReceiveQty(4, POID, ItemID,null, null, null, null, null, null,
                    null, null, null, null, null, null, null, null, null, null, null, null, null,
                    null, null, null, null);
                if(_obj != null)
                {
                    Qty = Convert.ToDecimal(_obj.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Qty;
        }
    }
}
