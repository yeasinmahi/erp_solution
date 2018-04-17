using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales;
using SAD_DAL.Sales.SalesViewTDSTableAdapters;
using SAD_DAL.Sales.SalesEntryTDSTableAdapters;
using System.Data;
using HR_DAL.Global.InventoryTDSTableAdapters;
using System.Collections;
using HR_BLL.Global;
using HR_DAL.Global;
using SAD_DAL.Sales.SalesOrderTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class SalesView
    {
        public SalesViewTDS.SprSalesInfoDataTable GetSalesInfoForChallan(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID, string type, string customerType, string shippingPoint)
        {
            SprSalesInfoTableAdapter adp = new SprSalesInfoTableAdapter();

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            bool? isCompleted = null, isEnable = null;

            #region ---------- Change By Konock -------------
            //if (type == "act") { isCompleted = false; isEnable = true; }
            //else if (type == "inc") { isCompleted = null; isEnable = false; }
            //else if (type == "com") { isCompleted = true; isEnable = true; }

            if (type == "act") { isCompleted = false; isEnable = true; }
            else if (type == "inc") { isCompleted = false; isEnable = false; }
            else if (type == "com") { isCompleted = true; isEnable = true; }
            #endregion ------------------------------------------------

            if (isEnable.Value && !isCompleted.Value)
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-1000); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(1000); }
            }
            else
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-7); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(6); }
            }

            if (""+customerType == "") return null;
            return adp.GetSalesData(int.Parse(unitID), fromDate, toDate, isEnable, isCompleted, false, int.Parse(customerType), code, int.Parse(shippingPoint));

        }

        public SalesViewTDS.SprSalesInfoByAccountsDataTable GetSalesInfoForAccounts(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID, string type, string byAccounts, string customerType, string shippingPoint)
        {
            SprSalesInfoByAccountsTableAdapter adp = new SprSalesInfoByAccountsTableAdapter();
            bool? isCompleted = null, isEnable = null, byAcc = null;

            if (""+code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            #region ---------- Change By Konock -------------
            //if (type == "act") { isCompleted = false; isEnable = true; }
            //else if (type == "inc") { isCompleted = null; isEnable = false; }
            //else if (type == "com") { isCompleted = true; isEnable = true; }

            if (type == "act") { isCompleted = false; isEnable = true; }
            else if (type == "inc") { isCompleted = false; isEnable = false; }
            else if (type == "com") { isCompleted = true; isEnable = true; }
            #endregion ------------------------------------------------

            if (byAccounts == "acc") { byAcc = true;}
            else if (byAccounts == "do") { byAcc = false;}

            if (""+customerType == "") return null;
            DataTable dt = new DataTable();
            return adp.GetData(int.Parse(unitID), fromDate, toDate, int.Parse(customerType), isCompleted,  isEnable, true, byAcc, code, int.Parse(shippingPoint));

        }
               

        public SalesViewTDS.SprSalesInfoByCustomerDataTable GetSalesInfoForMarketting(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID, string customerId, string customerType, bool isCompleted, string shippingPoint)
        {
            SprSalesInfoByCustomerTableAdapter adp = new SprSalesInfoByCustomerTableAdapter();

            int? cId = null;
            if (""+customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if (""+customerType == "") return null;
            return adp.GetData(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), null, isCompleted, code, int.Parse(shippingPoint));

        }
        public void ChallanComplete(string id,string userId)
        {
            SprSalesInfoTableAdapter adp = new SprSalesInfoTableAdapter();
            adp.ChallanComplete(int.Parse(userId), long.Parse(id));
        }

        public void ChallanCancel(string id, string userId)
        {
            try
            {
                SprSalesInfoTableAdapter adp = new SprSalesInfoTableAdapter();
                adp.Cancell(int.Parse(userId), long.Parse(id));

                sprInventoryTransferDeleteTableAdapter getinventorydelete = new sprInventoryTransferDeleteTableAdapter();
                getinventorydelete.GetInventoryTransferDelete(int.Parse(id));
            }
            catch { }

        }
       
        public void TripCancel(string id)
        {
            SprInternalTTripCancelTableAdapter adp = new SprInternalTTripCancelTableAdapter();
            adp.UpdateTripCancel(int.Parse(id));
        }
        

        public void SubLedgerEntry(string voucherId,string unitId,string userId,DateTime date)
        {
            SprSubledgerEntryFromSalesTableAdapter ta = new SprSubledgerEntryFromSalesTableAdapter();
            ta.GetData(long.Parse(voucherId), int.Parse(unitId), int.Parse(userId), date);
        }

        public void ChallanCompleteHO(string id, string userId)
        {
            SprSalesInfoByCustomerTableAdapter adp = new SprSalesInfoByCustomerTableAdapter();
            adp.CompleteHO(int.Parse(userId), long.Parse(id));
        }

        public SalesEntryTDS.QrySalesEntryCustomerDataTable GetDataByCode(string code,string unitId)
        {
            QrySalesEntryCustomerTableAdapter ta = new QrySalesEntryCustomerTableAdapter();
            return ta.GetDataByCode(code, int.Parse(unitId));
        }

        public SalesViewTDS.SprPointVsCollectionDataTable GetPointVsCollection(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID, string type, string customerType, string shippingPoint,string reporttype,string salesoffice)
        {
            SprPointVsCollectionTableAdapter adp = new SprPointVsCollectionTableAdapter();

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            bool? isCompleted = null, isEnable = null;

          

            if (type == "act") { isCompleted = false; isEnable = true; }
            else if (type == "inc") { isCompleted = false; isEnable = false; }
            else if (type == "com") { isCompleted = true; isEnable = true; }





          
            if (isEnable.Value && !isCompleted.Value)
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-1000); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(1000); }
            }
            else
            {
                if (fromDate == null) { fromDate = DateTime.Now.Date.AddDays(-7); }
                if (toDate == null) { toDate = DateTime.Now.Date.AddDays(6); }
            }

            if ("" + customerType == "") return null;
            return adp.GetDataPointVsCollection(int.Parse(unitID), fromDate, toDate, isEnable, isCompleted, false, int.Parse(customerType), code, int.Parse(shippingPoint),int.Parse(reporttype),int.Parse(salesoffice));

        }

        public DataTable getShippingpointDelv(DateTime fromdate, DateTime todate, int unitid, int shippingpointid)
        {
            try
            {
                SprGhatDelivaryTableAdapter bll = new SprGhatDelivaryTableAdapter();
                return bll.GetData(fromdate, todate, unitid, shippingpointid);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable getPointToPointDelv(DateTime fromdate, DateTime todate, int unitid, int Fromshippingpointid, int ToShippingid,int rptype)
        {
            try
            {
                SprPointToPointDelvTableAdapter bll = new SprPointToPointDelvTableAdapter();
                return bll.GetData(fromdate, todate, unitid, Fromshippingpointid, ToShippingid, rptype);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable getDOAndChallan(int intunitid , DateTime fromdate , DateTime todate , int intteritoryid , int intareaid , int regionid , int rpttype )
        {
            try
            {
                SprOperationalSetupvsDOAndChallanTableAdapter bll = new SprOperationalSetupvsDOAndChallanTableAdapter();
              return   bll.GetDataOperationalSetupvsDOAndChallan(intunitid, fromdate, todate, intteritoryid, intareaid, regionid, rpttype);
            }
            catch(Exception ex) { return new DataTable(); }

        }

        public DataTable getUndelvqnt(int intunitid, int intteritoryid, int intareaid, int regionid, int rpttype)
        {
            try
            {
                SprPendingAmountAndQntOSBaseTableAdapter bll = new SprPendingAmountAndQntOSBaseTableAdapter();
                return bll.GetDataPendingAmountAndQntOSBase(intunitid, intteritoryid, intareaid, regionid, rpttype);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable getUndelvqntForPrint(int Customerid,int unitid ,int rptytpe)
        {
            try
            {
                SprDelvOrderPendingQntPrintTableAdapter bll = new SprDelvOrderPendingQntPrintTableAdapter();
                return bll.GetDataDelvOrderPendingQntPrint(Customerid, unitid, rptytpe);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable UnitvsCommisionTypeName(int unitid)
        {
            try
            {
                TblCommissionTypeTableAdapter bll = new TblCommissionTypeTableAdapter();
                return bll.GetDataCommissionTypeName(unitid);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable UnitvsOutstandingCOA(int unitid,int rpttype)
        {
            try
            {
                TblUnitvsGlovalCOAOutstandingTableAdapter bll = new TblUnitvsGlovalCOAOutstandingTableAdapter();
                return bll.GetDataGlobalOutstandingCOA(unitid, rpttype);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable UnitvsCommisionCoa(int unitid,int commtype)
        {
            try {
                TblAccountsChartOfAccTableAdapter bll = new TblAccountsChartOfAccTableAdapter();
                return bll.GetDataUnitVsCommissionCOA(unitid,commtype);
            }
            catch (Exception ex) { return new DataTable(); }
            
        }

        public DataTable CollectionbaseCommission (DateTime from,DateTime to,int unit, int salesoffice, int rpttype)
        {
            try
            {
                SprCollectionBaseCommissionTableAdapter bll = new SprCollectionBaseCommissionTableAdapter();
                return bll.GetData(from, to, unit, salesoffice, rpttype);
            }
            catch(Exception ex) { return new DataTable(); }
           

        }

        public DataTable UnitvsBankinfo(int unitid)
        {
            try
            {
                TblUnitvsBankInfoTableAdapter bll = new TblUnitvsBankInfoTableAdapter();
                return bll.GetData(unitid);
            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable  insertionsalescommission(string xml,DateTime dteFromDate , DateTime dteToDate , int intUser  , int intBankID , DateTime dteInstrument , int intUnitID , decimal monAmount,int outstandingcoa , int nonoutstandingcoa , int intsalesofid , int intrpttype)
        {
            

            try
            {
                SprCommissionForCollectionAmountTableAdapter bll = new SprCommissionForCollectionAmountTableAdapter();
                return bll.GetData(xml,dteFromDate,  dteToDate,  intUser,  intBankID,  dteInstrument,  intUnitID, Convert.ToDecimal( monAmount), outstandingcoa, nonoutstandingcoa,  intsalesofid,  intrpttype);
               
            }
            catch (Exception ex) { return new DataTable();  }


        }

        public DataTable DeliveryVscommission( DateTime dteFromDate, DateTime dteToDate,  int intsalesofid, int intrpttype)
        {


            try
            {
                SprDeliveryVsCommissionTableAdapter bll = new SprDeliveryVsCommissionTableAdapter();
                return bll.GetDataDeiliveryVSCommission( dteFromDate, dteToDate, intsalesofid, intrpttype);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable GetUservsWHPermission( int enrol, int unit)
        {


            try
            {
                TblWHPermissionUnitTableAdapter bll = new TblWHPermissionUnitTableAdapter();
                return bll.GetDataWH(enrol, unit);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable FinishGoodsstock(int unit, int stockstatus,int whstatus)
        {


            try
            {
                SprFinishGoodsStockStatusTableAdapter bll = new SprFinishGoodsStockStatusTableAdapter();
                return bll.GetDataFinishGoodsStockStatus(unit, stockstatus, whstatus);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public List<string> AutoSearchcustomer(int Unitid, int emplid, string strSearchKey)
        {
            List<string> result = new List<string>();
            SprzSetupvsCustomerTableAdapter bll = new SprzSetupvsCustomerTableAdapter();
            DataTable oDT = new DataTable();
            oDT = bll.GetData(Unitid, emplid, strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["Column1"].ToString());
                }

            }
            return result;
        }

        public DataTable Getchalaninfoinfo(int type, int actionby, string xml, int id, DateTime fdate, DateTime tdate, int unitid, string chalan)
        {
            SprDamageDetailsInfoTableAdapter adp = new SprDamageDetailsInfoTableAdapter();
            try { return adp.GetDatachallaninfo(type, actionby, xml, id, fdate, tdate,unitid,chalan); }
            catch { return new DataTable(); }
        }

        public DataTable getUndelvqntTopsheetPartybase(int rpttype, int unitid, DateTime dtfrom, DateTime dtto, int salesoffice,int shippingpoint, int territoryid, int areaid ,int regionid,int customerid)
        {
           
            try
            {
                SprzDelvTransferPendingQntTableAdapter bll = new SprzDelvTransferPendingQntTableAdapter();
                return bll.GetDataDelvTransferPendingQnt(rpttype,  unitid,  dtfrom,  dtto,  salesoffice,  shippingpoint,  territoryid,  areaid,  regionid, customerid);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable getCustandUnitinfo(int customerid)
        {

            try
            {
                TblCustomerAndUnitInfoTableAdapter bll = new TblCustomerAndUnitInfoTableAdapter();
                return bll.GetDataUnitInfo( customerid);
            }
            catch (Exception ex) { return new DataTable(); }

        }
        public List<string> AutoSearchTADAEmploye(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprTADAEmplSearchingTableAdapter bll = new SprTADAEmplSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = bll.GetDataTADAEmplSearching(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strname"].ToString());
                }

            }
            return result;
        }
        public DataTable getPersonalUseBreakage(int rpttype,DateTime fromdate,DateTime todate,int enrol)
        {
           
            try
            {
                SprtTADAEntryByAnotherRptTableAdapter bll = new SprtTADAEntryByAnotherRptTableAdapter();
                return bll.GetDataTADAEntryByAnotherRpt(  enrol, fromdate, todate, rpttype);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable getPointToPointDelvWithItemCode(DateTime fromdate, DateTime todate, int unitid, int Fromshippingpointid, int ToShippingid, int rptype)
        {
            try
            {
                SprPointToPointDelvWithConvertedcodeTableAdapter bll = new SprPointToPointDelvWithConvertedcodeTableAdapter();
                return bll.GetDataPointToPointDelvWithConvertedcode(fromdate, todate, unitid, Fromshippingpointid, ToShippingid, rptype);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable getMissingchallan(int rptype)
        {
            try
            {
                SprzChallanGateoutbutnotcountTableAdapter bll = new SprzChallanGateoutbutnotcountTableAdapter();
                return bll.GetDataChallanGateoutbutnotcount( rptype);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable getDOQntvsChallanqntwithpendingqnt( DateTime fromdate,DateTime todate,int salesofficeid, int shippingpoint, int unit,int rptype)
        {
            try
            {
                SprDOQntVsChallanStatusTableAdapter bll = new SprDOQntVsChallanStatusTableAdapter();
                return bll.GetDataDOQntVsChallanStatus(fromdate,  todate,    salesofficeid, shippingpoint, unit,  rptype);

            }
            catch (Exception ex) { return new DataTable(); }


        }

        public DataTable getpendingfromtripid(int tripid)
        {
            try
            {
                SprTripIdVsPendingQntAndValueTableAdapter ta = new SprTripIdVsPendingQntAndValueTableAdapter();
                return ta.GetDataTripIdVsPendingQntAndValue(tripid);
            }
            catch (Exception ex) { return new DataTable(); }


        }

        //public DataTable getcustomerlistfromtripcode(string tripid)
        //{
        //    try
        //    {
        //        SprCustListfromTripcodeTableAdapter ta = new SprCustListfromTripcodeTableAdapter();
        //        return ta.GetDataCustListfromTripcode(int.Parse(tripid));
        //    }
        //    catch(Exception ex) { return new DataTable(); }
        //}

        public SalesOrderTDS.SprCustListfromTripcodeDataTable getcustomerlistfromtripcode(string tripId)
        {
            SprCustListfromTripcodeTableAdapter ta = new SprCustListfromTripcodeTableAdapter();
            return ta.GetDataCustListfromTripcode(int.Parse(tripId));
        }









        public DataTable getcustomerbasependingqnt(int tripid,int customerid)
        {
            try
            {
                SprTripIdVsPendingQntAndValueCustomerBaseTableAdapter ta = new SprTripIdVsPendingQntAndValueCustomerBaseTableAdapter();
                return ta.GetDataTripIdVsPendingQntAndValueCustomerBase(tripid, customerid);
            }
            catch (Exception ex) { return new DataTable(); }
        }
     
        public DataTable DRSummeryRpt(int unitid, int ToShippingid, DateTime fromdate, DateTime todate, int rptype)
        {
            try
            {
                SprDRSummeryTableAdapter bll = new SprDRSummeryTableAdapter();
                return bll.GetDataDRSummery(unitid, ToShippingid, fromdate, todate,   rptype);

            }
            catch (Exception ex) { return new DataTable(); }


        }
      
        public DataTable getYearlyDOSummery( DateTime fromdate, DateTime todate, int rpttype,int salesoffid,int unitid, int intteritoryid, int intareaid, int regionid)
        {
            try
            {
                SprMonthlySalesRptTableAdapter bll = new SprMonthlySalesRptTableAdapter();
                return bll.GetDataMonthlySalesRpt(fromdate,  todate,  rpttype,  salesoffid,  unitid,  intteritoryid,  intareaid,  regionid);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable getYearlyItemCatgBasisDO(DateTime fromdate, DateTime todate, int rpttype, int salesoffid, int unitid, int intteritoryid, int intareaid, int regionid)
        {
            try
            {
                SprMonthlyItemCatgBaseDetaillsTableAdapter bll = new SprMonthlyItemCatgBaseDetaillsTableAdapter();
                return bll.GetDataMonthlyItemCatgBaseDetaills(fromdate, todate, rpttype, salesoffid, unitid, intteritoryid, intareaid, regionid);
            }
            catch (Exception ex) { return new DataTable(); }

        }
     
        public DataTable getPendingDOCHALLANPENDING(int  rpttype, int unit, DateTime frm, DateTime tdt, int salesoff,int shippingpoint, int intteritoryid, int intareaid, int regionid,int custid)
        {
            try
            {
                SprDOvsOperationalSetupTableAdapter bll = new SprDOvsOperationalSetupTableAdapter();
                return bll.GetDataDOvsOperationalSetup(rpttype,  unit,  frm,  tdt,  salesoff,  shippingpoint,  intteritoryid,  intareaid,  regionid,  custid);
            }
            catch (Exception ex) { return new DataTable(); }

        }
        
        public DataTable getDelvPointStatus( int unit, DateTime frm, DateTime tdt,  int shippingpoint, int rpttype, int salesoff)
        {
            try
            {
                SprPointBasiTopsheetTableAdapter bll = new SprPointBasiTopsheetTableAdapter();
                return bll.GetDataPointBasiTopsheet(unit,  frm,  tdt,  shippingpoint,  rpttype,  salesoff);
            }
            catch (Exception ex) { return new DataTable(); }

        }

        public DataTable DamageCatg(int unit)
        {
            try
            {
                TblDamageCatgTableAdapter bll = new TblDamageCatgTableAdapter();
                return bll.GetDataUnitVsDamageType(unit);
            }
            catch (Exception ex) { return new DataTable(); }

        }



    }
}
