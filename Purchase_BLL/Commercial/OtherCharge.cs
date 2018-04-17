using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.OthersTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class OtherCharge
    {

        public ListItemCollection GetOtherCharges(string uiStepShortName)
        {
            ListItemCollection col = new ListItemCollection();

            FunCommercialGetOtherChargeListForStepsTableAdapter adp = new FunCommercialGetOtherChargeListForStepsTableAdapter();

            OthersTDS.FunCommercialGetOtherChargeListForStepsDataTable tbl = adp.GetOtherChargeDataByStep(uiStepShortName);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strChargeName, tbl[i].OtherChargeID.ToString()+"#"+(tbl[i].IsysnAutoCalNull()?"False":tbl[i].ysnAutoCal.ToString())+"#"+tbl[i].strShortName));
            }

            return col;
        }

        public string InsertOtherCharge(decimal? monAmount, DateTime? dteTentavivePaymentDate, decimal? liborRate, DateTime? dteAcceptenceDate,
                                        int otherChargeAttID, int intLCID, int intShipmentID, decimal? exRate, string strReason,int? numDays)
        {
            string result = "";
            SprCommercialProvitionOtherChargeTableAdapter adp = new SprCommercialProvitionOtherChargeTableAdapter();
            try
            {
                adp.InsertOtherChargeData(monAmount, dteTentavivePaymentDate, liborRate, dteAcceptenceDate, otherChargeAttID, intLCID, intShipmentID, exRate, strReason, numDays);
                result = "Successfully inserted";
            }
            catch
            {
                result = "Not Sucessfull";
            }

            return result;
        }

        public decimal GetOtherChargeCalculatedAcmount(int otherChargeAttID,int intLCID,int intShipmentID,decimal exRate,decimal? liborRate,DateTime? dteAcceptenceDate,int? numDay)
        {
            decimal totalAmount = 0;

            FunCommercialGetOtherChargeCalTableAdapter adp = new FunCommercialGetOtherChargeCalTableAdapter();
            OthersTDS.FunCommercialGetOtherChargeCalDataTable tbl = adp.GetOtherChargeCalcData(otherChargeAttID, intLCID, intShipmentID, exRate, liborRate, dteAcceptenceDate,numDay);

            totalAmount = tbl[0].monAmount + tbl[0].monVat;

            return totalAmount;

        }

        public OthersTDS.FunCommercialPaymentDocumentAcceptenceDataTable GetDocumentAcceptenceView(int lcID, int shipmentID, DateTime acceptenceDate, decimal exRate)
        {
           
            FunCommercialPaymentDocumentAcceptenceTableAdapter adp = new FunCommercialPaymentDocumentAcceptenceTableAdapter();
            return adp.GetData(lcID, shipmentID, acceptenceDate, exRate);
        }

        public string InsertProvitionDA(int lcID,int shipmentID,DateTime? acDate,DateTime? budgetDate,decimal exRate)
        {
            string error="";
            SprCommercialProvitionDocumentAcceptenceTableAdapter adp = new SprCommercialProvitionDocumentAcceptenceTableAdapter();
            adp.InsertDAProvitionData(lcID, shipmentID, acDate, exRate, budgetDate, ref error);
            return error;
        }

    }
}
