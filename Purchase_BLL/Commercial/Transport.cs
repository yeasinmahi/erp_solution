using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.TransportDueTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
   public class Transport
    {

       public ListItemCollection GetVicheleType()
       {
           ListItemCollection vitypeCol = new ListItemCollection();
           TblCommercialTransportVicheleTypeTableAdapter adp = new TblCommercialTransportVicheleTypeTableAdapter();
           TransportDue.TblCommercialTransportVicheleTypeDataTable tbl = adp.GetViTypeData();
           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               vitypeCol.Add(new ListItem(tbl[i].strVicheleTypeName, tbl[i].intVicheleTypeID.ToString()));
           }

           return vitypeCol;
       }

       public ListItemCollection GetVicheleTypeForRoad()
       {
           ListItemCollection vitypeCol = new ListItemCollection();
           TblCommercialTransportVicheleTypeTableAdapter adp = new TblCommercialTransportVicheleTypeTableAdapter();
           TransportDue.TblCommercialTransportVicheleTypeDataTable tbl = adp.GetViTypeDataForRoad();
           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               vitypeCol.Add(new ListItem(tbl[i].strVicheleTypeName, tbl[i].intVicheleTypeID.ToString()));
           }

           return vitypeCol;
       }

       public ListItemCollection GetVicheleTypeForSea()
       {
           ListItemCollection vitypeCol = new ListItemCollection();
           TblCommercialTransportVicheleTypeTableAdapter adp = new TblCommercialTransportVicheleTypeTableAdapter();
           TransportDue.TblCommercialTransportVicheleTypeDataTable tbl = adp.GetViTypeDataForSea();
           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               vitypeCol.Add(new ListItem(tbl[i].strVicheleTypeName, tbl[i].intVicheleTypeID.ToString()));
           }

           return vitypeCol;
       }

       public ListItemCollection GetTransportCompany()
       {
           ListItemCollection tcCol = new ListItemCollection();
           TblCommercialTransportCompanyTableAdapter adp = new TblCommercialTransportCompanyTableAdapter();
           TransportDue.TblCommercialTransportCompanyDataTable tbl = adp.GetTransComData();
           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               tcCol.Add(new ListItem(tbl[i].strTransportComName, tbl[i].intTansportComID.ToString()));
           }

           return tcCol;
       }

       public string Getrate(int shipmentID, int viTypeID, int agencyID)
       {
           FunCommercialPaymentTransportDueTableAdapter adp = new FunCommercialPaymentTransportDueTableAdapter();
           TransportDue.FunCommercialPaymentTransportDueDataTable tbl = adp.GetRateData(shipmentID, agencyID, viTypeID);

           return tbl[0].monAmount.ToString();
       }

       public ListItemCollection GetTransportZone()
       {
           ListItemCollection tcCol = new ListItemCollection();
           TblCommercialTransportGEOTableAdapter adp = new TblCommercialTransportGEOTableAdapter();
           TransportDue.TblCommercialTransportGEODataTable tbl = adp.GetTransportZoneData();
           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               tcCol.Add(new ListItem(tbl[i].strName, tbl[i].intGEOID.ToString()));
           }

           return tcCol;
       }

       public string InsertTheDuesOfTransport(int intLCID,int intShipmentID,DateTime dtePaymentdate,string viInfoXML,bool isPaid )
       {

           string result = "";

           SprCommercialCalTransportDueTableAdapter adp = new SprCommercialCalTransportDueTableAdapter();

           try
           {
               adp.InsertTransportDueData(intLCID, intShipmentID, dtePaymentdate, viInfoXML, isPaid);
               result = "successfully Inserted";

           }
           catch
           {
               result = "Cannot Insert";
           }

           return result;

       }

       public ListItemCollection GetLOAgent()
       {
           ListItemCollection col = new ListItemCollection();
           TblCommercialTransportLOAgentTableAdapter adp = new TblCommercialTransportLOAgentTableAdapter();
           TransportDue.TblCommercialTransportLOAgentDataTable tbl = adp.GetLOAgentData();

           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               col.Add(new ListItem(tbl[i].strName, tbl[i].intLOAgentID.ToString()));
           }

           return col;
       }

       public void GetLighterCalculation(int shipmentID, int loAgentID, decimal rentWaight, decimal ownWeight, decimal? adper, bool ysnAD, bool ysnpayment, ref decimal totalCharge,ref decimal totalChargeAkijShipping)
       {
           
           FunCommercialTransportDueLighterCal1TableAdapter adp = new FunCommercialTransportDueLighterCal1TableAdapter();
           TransportDue.FunCommercialTransportDueLighterCal1DataTable tbl = adp.GetDataLighterCalc(shipmentID, loAgentID, ownWeight,rentWaight,  adper, ysnAD, ysnpayment);
           if (ysnAD)
           {
               totalCharge = tbl[0].monAdvanced;
               totalChargeAkijShipping = 0;
           }
           else
           {
               totalCharge = tbl[0].monChargeOther ;
               totalChargeAkijShipping = tbl[0].monChargeOwn;
           }
           /*totalDemerage = tbl[0].monDemerage;
           totalDiscount = tbl[0].monDiscount;*/

       }

       public string InsertSeaProvitionData( int lcID,int shipmentID,int loAgentID,decimal ourShipWeight, decimal rentWeight,
	                                         DateTime facIn,DateTime facOut,DateTime budgetDate,int userID)
	
       {
           string result="";

           SprCommercialProvitionTransportDueSeaTableAdapter adp = new SprCommercialProvitionTransportDueSeaTableAdapter();
           try
           {
               adp.InsertTransportSeaProvitionData(lcID, shipmentID, loAgentID, ourShipWeight, rentWeight, facIn, facOut, budgetDate, userID);
               result = "Inserted Successfully";
           }
           catch
           {
               result = "Insertion Failed";
           }

           return result;

       }

    }
}
