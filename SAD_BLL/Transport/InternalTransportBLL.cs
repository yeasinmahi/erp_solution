using SAD_DAL.Transport.InternalTransportTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Transport;

namespace SAD_BLL.Transport
{
    public class InternalTransportBLL
    {
        private static SAD_DAL.Transport.InternalTransportTDS.TblFixedAssetRegisterDataTable[] tableVehicle = null;
        int e; //SAD_DAL.Transport.TblFixedAssetRegisterTableAdapter

        public string[] AutoSearchVehicleAsset(string intUnitID, string prefix)
        {
            intUnitID = "8";
            int unit = 8;
            //Inatialize(intwh);

            tableVehicle = new SAD_DAL.Transport.InternalTransportTDS.TblFixedAssetRegisterDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeListDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeDataTable[e];
            TblFixedAssetRegisterTableAdapter adpCOA = new TblFixedAssetRegisterTableAdapter();
            tableVehicle[e] = adpCOA.GetVehicleList(unit);
            //tableEmplist[e] = adpCOA.GetEmpList(Convert.ToInt32(intUnitID)); 
            //tableEmplist[e] = adpCOA.GetEmpListByUnit();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableVehicle[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strNameOfAsset
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in tableVehicle[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strNameOfAsset.ToLower().Contains(prefix) || tmp.strAssetID.ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strNameOfAsset
                                   select tmp;
                        if (rows.Count() > 0)
                        {
                            tbl = rows.CopyToDataTable();
                        }
                    }
                    catch { return null; }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    //retStr[i] = tbl.Rows[i]["strEmployeeName"] + "; " + tbl.Rows[i]["intEmployeeID"];
                    retStr[i] = tbl.Rows[i]["strNameOfAsset"] + " [" + tbl.Rows[i]["strAssetID"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }

        public string InsertAccidentRegister(DateTime dteAccidentDate, int intVehicleID, string strVehicleRegistrationNumber, int intUserUnitID, string strUserUnit, int intDriverEnroll, string strDriverName, string strTravelingRouteFrom, string strTravelingRouteTo, string strPlaceOfAccident, TimeSpan tmTimeOfAccident, string strAccidentType, string strDescription, string strLossIncurredByAccident, decimal monSettlementPenaltyPaid, decimal monSettlementPenaltyReceive, int intSettlementPenaltyChargedCompanyUnit, string strSettlementPenaltyChargedCompanyUnit, int intSettlementPenaltyChargedDutyDriver, string strSettlementPenaltyChargedDutyDriver, string strSupportVehicleRegNo, decimal numRecoveredGoodsOrMaterialsQty, decimal monRecoveredGoodsOrMaterialsValue, decimal numLossGoodOrMaterialsQty, decimal monLossGoodOrMaterialsValue, int intInvestigationReportedByEnroll, string strInvestigationReportedByName, string strInvestigationReportedByDesignation, int intInsertBy)
        {
            string msg = "";
            SprAccidentRegisterInsertTableAdapter adp = new SprAccidentRegisterInsertTableAdapter();
            adp.InsertAccidentRegister(dteAccidentDate, intVehicleID, strVehicleRegistrationNumber, intUserUnitID, strUserUnit, intDriverEnroll, strDriverName, strTravelingRouteFrom, strTravelingRouteTo, strPlaceOfAccident, tmTimeOfAccident, strAccidentType, strDescription, strLossIncurredByAccident, monSettlementPenaltyPaid, monSettlementPenaltyReceive, intSettlementPenaltyChargedCompanyUnit, strSettlementPenaltyChargedCompanyUnit, intSettlementPenaltyChargedDutyDriver, strSettlementPenaltyChargedDutyDriver, strSupportVehicleRegNo, numRecoveredGoodsOrMaterialsQty, monRecoveredGoodsOrMaterialsValue, numLossGoodOrMaterialsQty, monLossGoodOrMaterialsValue, intInvestigationReportedByEnroll, strInvestigationReportedByName, strInvestigationReportedByDesignation, intInsertBy, ref msg);
            return msg;
        }

        

        public DataTable GetUnitListForTransport(int Enroll) 
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            { return adp.GetUnitListForTransport(Enroll); }
            catch { return new DataTable(); }
        }
       public DataTable GetUnitList() 
       {
           SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
           try
           { return adp.GetUnitList(); }
           catch { return new DataTable(); }
       }
       public DataTable GetShipPointList(int intUnitID)  
        {
            TblShippingPointTableAdapter adp = new TblShippingPointTableAdapter();
            try
            { return adp.GetShipPoint(intUnitID); } 
            catch { return new DataTable(); }
        }
       public DataTable GetTripReportForInEntry(int intUnitID, int intShipPointID)   
        {
            GetTripReportForInEntryTableAdapter adp = new GetTripReportForInEntryTableAdapter();
            try
            { return adp.GetTripReportForInEntry(intUnitID, intShipPointID); } 
            catch { return new DataTable(); }
        }
       public DataTable GetFuelStationList() 
       {
           SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
           try
           { return adp.GetFuelStationList(); }
           catch { return new DataTable(); }
       }
       public DataTable GetCustomerWiseCostForUpdate(int intWork, int intReffID)  
       {
           SprInternalTransportAllReportTableAdapter adp = new SprInternalTransportAllReportTableAdapter();
           try
           { return adp.GetCustomerWiseInfoUpdateReport(intWork, intReffID); }
           catch { return new DataTable(); }
       }
       public DataTable GetTripFareAndToll(int intTripid)  
       {
           /*SprTripFareAndTollCalculationTableAdapter adp = new SprTripFareAndTollCalculationTableAdapter();*/
           SprTripFareAndTollCalculation1TableAdapter adp = new SprTripFareAndTollCalculation1TableAdapter();
           try
           { return adp.GetTripF(intTripid); }
           catch { return new DataTable(); }
       }
       public string InsertOutEntry(int intReffID, decimal monBridgeToll, decimal monFerryEXP, decimal monLabourEXP, decimal monPoliceEXP, int intDriverEnroll, decimal monFuelCash, decimal monAdvance, int intInsertBy, string xml, decimal TotalRouteExp) 
        {
            string msg = "";
            SprInternalTInsertOutEntry1TableAdapter adp = new SprInternalTInsertOutEntry1TableAdapter();
            //SprInternalTInsertOutEntryTableAdapter adp = new SprInternalTInsertOutEntryTableAdapter();
            adp.InsertOutEntry(intReffID, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, intDriverEnroll, monFuelCash, monAdvance, intInsertBy, xml, TotalRouteExp, ref msg);
            return msg;
        }
       public DataTable GetDriverList(int intUnitID)
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDriverList(intUnitID); }
           catch { return new DataTable(); }
       }
       public DataTable GetDocTypeList()
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDocTypeList(); }
           catch { return new DataTable(); }
       }
       
       public DataTable GetDocTypeListForVendorT() 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDocTypeListForVendorT(); }
           catch { return new DataTable(); }
       }
       public DataTable GetDocPathList(int intReffID) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDocPathList(intReffID); }
           catch { return new DataTable(); }
       }
       public DataTable GetVehicleSupplierList(int intUnitid) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetVehicleSupplierList(intUnitid); }  
           catch { return new DataTable(); }
       }
       public DataTable GetVehicleType(int intUnitid) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetVehicleType(intUnitid); }
           catch { return new DataTable(); }
       }
       public DataTable GetDocPathListExistCheck(int intReffID) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDocPathListExistCheck(intReffID); }
           catch { return new DataTable(); }
       }
       public DataTable GetDocPathListExistCheckTypeWise(int intReffID, int intDocType) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDocPathListExistCheckTypeWise(intReffID, intDocType); }
           catch { return new DataTable(); }
       }
       public DataTable GetDocTypeWiseDPathList(int intReffID, int intDocType)
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDocTypeWiseDPathList(intReffID, intDocType); }
           catch { return new DataTable(); }
       }
       public DataTable GetDriverEnrollAndUnitidByTrip(int intReffid) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDriverEnrollAndUnitid(intReffid); }
           catch { return new DataTable(); }
       }

       public DataTable GetCheckExpEntry(int intReffid)
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetCheckExpEntry(intReffid); }
           catch { return new DataTable(); }
       }
       public string UpdateRouteCostByCustomer(int intReffid, int intInsertBy, string xml) 
        {
            string msg = "";
            SprInternalTRouteCostUpdateByCustomerTableAdapter adp = new SprInternalTRouteCostUpdateByCustomerTableAdapter();
            adp.UpdateRouteCostByCustomer(intReffid, intInsertBy, xml, ref msg);
            return msg;
        }
       public string InsertAndUpdateCustInfoBridge(int intWork, int intReffid, int intInsertBy, string xml) 
       {
           string msg = "";
           SprInternalTRouteCostUpdateByCustomer1TableAdapter adp = new SprInternalTRouteCostUpdateByCustomer1TableAdapter();
           adp.InsertAndUpdateCustInfoBridge(intWork, intReffid, intInsertBy, xml, ref msg);
           return msg;
       }
       public DataTable GetLadgerBalanceOfDriver(int intDriverEnroll) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetLadgerBalanceOfDriver(intDriverEnroll); } 
           catch { return new DataTable(); }
       }
       public DataTable GetTripFareForInEntry(int intReffid)
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetTripFareForInEntry(intReffid); } 
           catch { return new DataTable(); }
       }
       public string InsertInEntry(int intReffID, DateTime dteInDate, int intAdditionalMillage, decimal monBridgeToll, decimal monFerryEXP, decimal monLabourEXP, decimal monPoliceEXP, string strMaintenanceDesc, decimal monMaintenanceTK, string strOhtersDetail, decimal monOthersTK, decimal intNoOfDA, decimal monTotalDTripFareCash, decimal monAdditionalFare, int intInInsertBy, string strAgentName, string xml, string xmlDtFare, decimal monFuelCash, string xmlDtFareCash, decimal monTripBonus, decimal monTimeAllow, string strCauseOfAdditionalMillage, string strCauseOfAdditionalFare, string xmlDocUpload)  
        {
            string msg = "";
            SprInternalTInposting1TableAdapter adp = new SprInternalTInposting1TableAdapter();
            //SprInternalTInpostingTableAdapter adp = new SprInternalTInpostingTableAdapter();
            adp.InEntry(intReffID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow, strCauseOfAdditionalMillage, strCauseOfAdditionalFare, xmlDocUpload, ref msg);
            return msg;
        }

       //public string InsertInEntry1(int intReffID, DateTime dteInDate, int intAdditionalMillage, decimal monBridgeToll, decimal monFerryEXP, decimal monLabourEXP, decimal monPoliceEXP, string strMaintenanceDesc, decimal monMaintenanceTK, string strOhtersDetail, decimal monOthersTK, decimal intNoOfDA, decimal monTotalDTripFareCash, decimal monAdditionalFare, int intInInsertBy, string strAgentName, string xml, string xmlDtFare, decimal monFuelCash, string xmlDtFareCash, decimal monTripBonus, decimal monTimeAllow, string strCauseOfAdditionalMillage, string strCauseOfAdditionalFare, string xmlDocUpload)  
       // {
       //     string msg = "";
       //     SprInternalTInposting1TableAdapter adp = new SprInternalTInposting1TableAdapter();
       //     adp.InsertInPosting(intReffID, dteInDate, intAdditionalMillage, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, strMaintenanceDesc, monMaintenanceTK, strOhtersDetail, monOthersTK, intNoOfDA, monTotalDTripFareCash, monAdditionalFare, intInInsertBy, strAgentName, xml, xmlDtFare, monFuelCash, xmlDtFareCash, monTripBonus, monTimeAllow, strCauseOfAdditionalMillage, strCauseOfAdditionalFare, xmlDocUpload, ref msg);
       //     return msg;
       // }

        
       public DataTable GetTripInfoReport(int intWork, int intUnitId, int intShipPointid, string strTripSLNo, int ysnWonVehicle)  
       {
           sprInternalTGetTripSlNoForReport1TableAdapter adp = new sprInternalTGetTripSlNoForReport1TableAdapter();
           try
           { return adp.GetTripSLNoForReport(intWork, intUnitId, intShipPointid, strTripSLNo, ysnWonVehicle); }
           catch { return new DataTable(); }
       }
       public DataTable GetDateWiseCompleteReport(int intWork, int intShipPoint, DateTime dteFromDate, DateTime dteToDate, int intFuelStationid, int intBillStatus, int intEnroll, int intReportCategory)  
       {
           SprInternalTCompleteReportTableAdapter adp = new SprInternalTCompleteReportTableAdapter();
           //SprInternalTCompleteReport1TableAdapter adp = new SprInternalTCompleteReport1TableAdapter();
           try
           { return adp.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory); }
           catch { return new DataTable(); }
       }

       public DataTable GetCompleteReportVehicleSearch(int intWork, int intShipPoint, DateTime dteFromDate, DateTime dteToDate, int intFuelStationid, int intBillStatus, int intEnroll, string strVehicleNo, int intReportCategory)  
       {
           SprInternalTCompleteReportVehicleWiseTableAdapter adp = new SprInternalTCompleteReportVehicleWiseTableAdapter();
           try
           { return adp.GetCompleteReportVehicleWiseSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory); }
           catch { return new DataTable(); }
       }
                 
       public DataTable GetDriverLedgerBalance(int intWork, int intShipPoint, DateTime dteFromDate, DateTime dteToDate, int intDriverEnroll)  
       {
           SprInternalTDriverLedgerBalanceTableAdapter adp = new SprInternalTDriverLedgerBalanceTableAdapter();
           try
           { return adp.GetDriverLedgerBalance(intWork, intShipPoint, dteFromDate, dteToDate, intDriverEnroll); }
           catch { return new DataTable(); }
       }
       public DataTable GetDriverListForLBalance(int intUnitID)
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDriverListForLBalance(intUnitID); } 
           catch { return new DataTable(); }
       }
       public DataTable GetVehicleList(int intUnitID) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetVehicleList(intUnitID); }
           catch { return new DataTable(); }
       }
       public DataTable GetConfirmTripEntry(int intReffID) 
       {
           GetConFirmEntryTableAdapter adp = new GetConFirmEntryTableAdapter();
           try
           { return adp.GetConfirmEntry(intReffID); } 
           catch { return new DataTable(); }
       }
       public DataTable GetDriverSelect(int intVehicleid) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetDriverSelectByEnroll(intVehicleid); }
           catch { return new DataTable(); }
       }
       public DataTable GetCustomerList(int intUnitid, int intShipPointid) 
       {
           TblCustomerTableAdapter adp = new TblCustomerTableAdapter();
           try
           { return adp.GetCustomerList(intUnitid, intShipPointid); }
           catch { return new DataTable(); }
       }
       public DataTable GetMillageCustWise(int intCustid, int intShipPointid) 
       {
           TblCustomerTableAdapter adp = new TblCustomerTableAdapter();
           try
           { return adp.GetMillageCustomerWise(intCustid, intShipPointid); }
           catch { return new DataTable(); }
       }

       public string InsertManualVehicleOutEntry(DateTime dteDate, int intUnitID, int intShipPointId, int intVehicleID, string strVehicleNo, int intDriverEnroll, decimal monBridgeToll, decimal monFerryEXP, decimal monLabourEXP, decimal monPoliceEXP, decimal monAdvance, int intInsertBy, string xml, string xmlCustInfo, decimal TotalRouteExp)  
        {
            string msg = "";
            SprInternalTManualOutEntry1TableAdapter adp = new SprInternalTManualOutEntry1TableAdapter();
            //SprInternalTManualOutEntryTableAdapter adp = new SprInternalTManualOutEntryTableAdapter();
            adp.InsertManualVehicleOutEntry(dteDate, intUnitID, intShipPointId, intVehicleID, strVehicleNo, intDriverEnroll, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, monAdvance, intInsertBy, xml, xmlCustInfo, TotalRouteExp, ref msg);
            return msg;
        }
       public string InsertMEntryForGLT(int intUnitID, int intShipPointId, int intVehicleID, string strVehicleNo, int intDriverEnroll, decimal monBridgeToll, decimal monFerryEXP, decimal monLabourEXP, decimal monPoliceEXP, decimal monAdvance, int intInsertBy, string xml, string xmlCustInfo, decimal TotalRouteExp)  
        {
            string msg = "";
            SprInternalTManualOutEntryForGLTTableAdapter adp = new SprInternalTManualOutEntryForGLTTableAdapter();
            //SprInternalTManualOutEntryTableAdapter adp = new SprInternalTManualOutEntryTableAdapter();
            adp.InsertMEntryForGLT(intUnitID, intShipPointId, intVehicleID, strVehicleNo, intDriverEnroll, monBridgeToll, monFerryEXP, monLabourEXP, monPoliceEXP, monAdvance, intInsertBy, xml, xmlCustInfo, TotalRouteExp, ref msg);
            return msg;
        }

       public string InsertVendorTTripComplete(int intReffid, string strCauseOfCompanyDemVT, decimal monCompanyDemVT, string strCauseOfPartyDemVT, decimal monPartyDemVT, string strCauseOfAddFareVT, decimal monAddFareVT, string strCauseOfSpecialFareVT, decimal monSpecialFareVT, decimal monTripFareVendorVT, decimal monTotalTripFareVT, int intInInsertBy, string xmlDocUpload, string strCauseOfOther, decimal monOthers, int int3rdPartyCOAid, string strVehicleSupplier)
       {
           string msg = ""; 
           SprVendorTransportTripCompleteTableAdapter adp = new SprVendorTransportTripCompleteTableAdapter();
           adp.InsertVendorTTripComplete(intReffid, strCauseOfCompanyDemVT, monCompanyDemVT, strCauseOfPartyDemVT, monPartyDemVT, strCauseOfAddFareVT, monAddFareVT, strCauseOfSpecialFareVT, monSpecialFareVT, monTripFareVendorVT, monTotalTripFareVT, intInInsertBy, xmlDocUpload, strCauseOfOther, monOthers,  int3rdPartyCOAid, strVehicleSupplier, ref msg);
           return msg;
       }
       public DataTable GetLocalAccountsReportForWH(int intWork, int intReffid, int intShipPointId, int ysnWonVehicle, DateTime dteFromDate, DateTime dteToDate, int intInsertBy, decimal monAdvance, string strVehicleNo) 
       {
           SprInternalTLocalAccountsReportTableAdapter adp = new SprInternalTLocalAccountsReportTableAdapter();
           try
           { return adp.GetLocalAccountsReportForWH(intWork, intReffid, intShipPointId, ysnWonVehicle, dteFromDate, dteToDate, intInsertBy, monAdvance, strVehicleNo); }
           catch { return new DataTable(); }
       }

       public DataTable GetLocalAccFundApprovalR(int intWork, int intShipPointId, DateTime dteFromDate, DateTime dteToDate, int ysnWonVehicle, int intReffid, decimal monPaymentAmount, int intInsertByPayment, string strVehicleNo)
       {
           SprInternalLocalAccFundAppRTableAdapter adp = new SprInternalLocalAccFundAppRTableAdapter();  
           try
           { return adp.GetFundAppLocalAccR(intWork, intShipPointId, dteFromDate, dteToDate, ysnWonVehicle, intReffid, monPaymentAmount, intInsertByPayment, strVehicleNo); }
           catch { return new DataTable(); }  
       }
       public DataTable GetPaymentAmountCheck(int intReffid) 
       {
           TblInternalTRouteCostMainTableAdapter adp = new TblInternalTRouteCostMainTableAdapter();
           try
           { return adp.GetPaymentAmountCheck(intReffid); } 
           catch { return new DataTable(); }
       }
       public DataTable GetDriverWiseLedgerBNew(int intWork, DateTime dteFromDate, DateTime dteToDateint, int intDriverEnroll, int intShipPointid)
       {
           SprDriverWiseLedgerBTableAdapter adp = new SprDriverWiseLedgerBTableAdapter(); 
           try
           { return adp.GetDriverWiseLedgerBNew(intWork, dteFromDate, dteToDateint, intDriverEnroll, intShipPointid); }
           catch { return new DataTable(); }
       }
       public DataTable GetLedgerBalanceAllNew(int intWork, DateTime dteFromDate, DateTime dteToDateint, int intShipPointid, int intDriverEnroll)
       {
           SprLedgerBalanceAllTableAdapter adp = new SprLedgerBalanceAllTableAdapter();
           try
           { return adp.GetLedgerBalanceAllNew(intWork, dteFromDate, dteToDateint, intShipPointid, intDriverEnroll); }
           catch { return new DataTable(); }
       }
       public string InsertRentedVehicleReg(string strRegNo, int intUnitID, int intTypeId, string strDriverName, string strDriverContact, string strDriverNID, string strLisenceNo, string strHelperName)
       {
           string msg = "Vehicle Registration Successfully."; 
           TblVehicleTableAdapter adp = new TblVehicleTableAdapter();
           adp.InsertRentedVehicleReg(strRegNo, intUnitID, intTypeId, strDriverName, strDriverContact, strDriverNID, strLisenceNo, strHelperName);
           return msg;
       }
        public DataTable GetInternalTAuditAnalysisReport(int intWork, int intShipPointid, DateTime Fdate, DateTime TDate)
        {
            SprInternalTAuditAnalysisReportTableAdapter adp = new SprInternalTAuditAnalysisReportTableAdapter();
            try
            { return adp.GetInternalTAuditAnalysisReport(intWork,intShipPointid,Fdate,TDate); }
            catch { return new DataTable(); }
        }
        public DataTable GetReportData(int intWork, DateTime dteFDate, DateTime dteTDate, int intShipPointid, int intID)
        {
            SprInternalTAnalysisReportTableAdapter adp = new SprInternalTAnalysisReportTableAdapter();
            try
            { return adp.GetReportData(intWork, dteFDate, dteTDate, intShipPointid, intID); }
            catch { return new DataTable(); }
        }

        /*=====================Accident Register================================================= */
        public DataTable GetAllUnit()
        {
            TblUnitTableAdapter adp = new TblUnitTableAdapter();
            try
            { return adp.GetAllUnit(); }
            catch { return new DataTable(); }
        }
        


    }
}
