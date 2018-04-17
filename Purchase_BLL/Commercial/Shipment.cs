using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial.ShipmentTDSTableAdapters;
using Purchase_DAL.Commercial;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.InsertionTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Shipment
    {
        TblCommercialShipmentTableAdapter adp = new TblCommercialShipmentTableAdapter();
        public void GetShipmentNecessaryInfo(int? shipmentID,ref decimal? invoiceValue,ref decimal? calValue,ref bool? ysnConClaimShow,ref bool? ysnHavePerformanceGuaranty,ref decimal? performanceGuarantyPer,ref bool? ysnPGSaved,ref bool? ysnInsSaved)
        {
            /*ShipmentTDS.TblCommercialShipmentDataTable tbl = adp.GetShipmentDataByShipment(shipmentID);

            invoiceValue = tbl[0].monInvoiceValue;
            ysnConClaimShow = !tbl[0].ysnConfirmed;

            calValue = tbl[0].monInvoiceValue -(tbl[0].IsmonClaimCompensationNull()?0: tbl[0].monClaimCompensation);
            ysnHavePerformanceGuaranty = tbl[0].IsysnHavePerformanceGuarantyNull()?false:tbl[0].ysnHavePerformanceGuaranty;
            performanceGuarantyPer = tbl[0].IsnumPerfoemanceGaurantyPerNull() ? 0 : tbl[0].numPerfoemanceGaurantyPer;
            ysnPGSaved = tbl[0].IsdtePerformanceGuarantyPaymentDateNull() ? false : true;*/

            SprCommercialNecessaryInfoTableAdapter adp = new SprCommercialNecessaryInfoTableAdapter();
            adp.GetNecessaryShipmentData(shipmentID, ref invoiceValue, ref ysnConClaimShow, ref calValue, ref ysnHavePerformanceGuaranty, ref performanceGuarantyPer, ref ysnPGSaved, ref ysnInsSaved);

        }


        public ListItemCollection GetShipmentForDropDown(int lcID)
        {
            ListItemCollection col = new ListItemCollection();
            ShipmentTDS.TblCommercialShipmentDataTable tbl = adp.GetShipmentDataByLC(lcID);
            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    col.Add(new ListItem(tbl[i].strShipment, tbl[i].intShipmentID.ToString()));
                }
            }
            return col;
        }

        public string ConfirmShipmentInvoice(int shipmentID, int lcID, decimal? amount)
        {
            string result = "";
            SprCommercialClaimComsosationInsertTableAdapter adp = new SprCommercialClaimComsosationInsertTableAdapter();
            try
            {
                adp.ConfirmInvoice(lcID, shipmentID, amount);
                result = "Confirmed Invoice Amount ";
            }
            catch
            {
                result = "An error Have Ocuured While Confirm";
            }

            return result;

        }

        public void InsertShipment(decimal monInvoiceValinForeignCurr,DateTime dteShipmentDate,string strItemXML ,int intLCID ,ref string strResult, 
                                   string containerXML,string bolNumber,bool ysnFinalShipment,int intShippingLineID,int intSourceZoneID,int intDistinationZoneID,
                                    int intContainnerTypeID,decimal totalWeight,bool ysnHavePG, decimal? pgPer,int shipmentTypeID,int landingPortID,int? extendedFreeDays)
        {
            SprCommercialShipmentInsert2TableAdapter adp = new SprCommercialShipmentInsert2TableAdapter();
            try
            {
                adp.InsertDataOfShipment(monInvoiceValinForeignCurr, dteShipmentDate, strItemXML, intLCID, ref strResult, containerXML,
                                            bolNumber, ysnFinalShipment, intShippingLineID, intSourceZoneID, intDistinationZoneID, intContainnerTypeID, totalWeight, ysnHavePG, pgPer, shipmentTypeID, landingPortID, extendedFreeDays);
                                            
            }
            catch
            {
            }
        }


    }
}
