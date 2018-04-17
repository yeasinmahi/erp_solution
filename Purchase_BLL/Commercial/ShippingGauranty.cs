using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial.ShippingGaurantyTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class ShippingGauranty
    {

        public void GetShippingGaurantyNecessaryData(int lcID, int shipmentID, ref decimal payableAmount, ref decimal bankCharge, ref bool ysnError, ref string errorMsg,ref decimal vatAmount)
        {
            FunCommercialGetCopyDocumentTableAdapter adp = new FunCommercialGetCopyDocumentTableAdapter();
            ShippingGaurantyTDS.FunCommercialGetCopyDocumentDataTable tbl = adp.GetDataCopyDocument(lcID, shipmentID);

            payableAmount = tbl[0].monPayableAmount;
            bankCharge = tbl[0].monBankCharge;
            ysnError = tbl[0].ysnHaveError;
            errorMsg = tbl[0].strErrorDes;
            vatAmount = tbl[0].monVat;
        }

        public string provitionShippingGurantyData(decimal? monBC,decimal? vat,decimal? monPayableAmount,decimal exrate,int lcID,int shipmentID,DateTime? tentativeDate)
        {
            string result = "";
            SprCommercialProvitionShippingGaurantyTableAdapter adp = new SprCommercialProvitionShippingGaurantyTableAdapter();
            try
            {
                adp.PrivitionShippingGuarantyData(monBC, vat, monPayableAmount, exrate, lcID, shipmentID, tentativeDate);
                result = "Sccessfully Added ToString Budget";

            }

            catch
            {
                result = "Not Successful";
            }
            return result;

        }
    }
}
