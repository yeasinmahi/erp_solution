using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.DutyTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Duty
    {
        public DutyTDS.SprCommercialGetDutyInformationDataTable GetDutyInfo( int lcID, int shipmentID, decimal exRate, ref decimal? invoiceVal, ref decimal? assesmentVal, ref string currency,ref decimal? crfAmount)
        {
            SprCommercialGetDutyInformationTableAdapter adp = new SprCommercialGetDutyInformationTableAdapter();
            return adp.GetDutyData(lcID, shipmentID,  exRate, ref invoiceVal, ref currency, ref assesmentVal,ref crfAmount);
        }


        public DutyTDS.SprCommercialGetItemsWithHSCodeDataTable GetItemWithHSCode(int shipmentID)
        {
            SprCommercialGetItemsWithHSCodeTableAdapter adp = new SprCommercialGetItemsWithHSCodeTableAdapter();
            return adp.GetItemWithHSCodeCRFData(shipmentID);
        }

        public string InsertCRF(int ShipmentID, string crfXML, int totalItem)
        {
            string result = "";
            SprCommercialInsertCRFAmountTableAdapter adp = new SprCommercialInsertCRFAmountTableAdapter();
            try
            {
                adp.InsertCRFAmount(totalItem, crfXML, ShipmentID);
                result = "Successfull";
            }
            catch
            {
                result = "Not Successfull";
            }

            return result;
        }


    }
}
