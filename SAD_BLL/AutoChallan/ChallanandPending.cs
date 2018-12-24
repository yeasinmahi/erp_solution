using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.AutoChallan.AutoChallanAFBLTableAdapters;
using System.Data;

namespace SAD_BLL.AutoChallanBll
{
   
    public class challanandPending
    {
        public System.Data.DataTable GetShiping()
        {
            tblShippingPointTableAdapter getShiping = new tblShippingPointTableAdapter();
            return getShiping.GetShipingPoint();
        }

        public System.Data.DataTable getSalesofficeid(int Shippointid)
        {
            tblShippointBySalesOfficeBridgeTableAdapter GetSalesOfficeid = new tblShippointBySalesOfficeBridgeTableAdapter();
            return GetSalesOfficeid.GetSalesOfficeId(Shippointid);
           
        }

        public System.Data.DataTable getPendingReport(string depotname, int shippointid)
        {
            ERPPendingAFBLTableAdapter getErpPending = new ERPPendingAFBLTableAdapter();
            return getErpPending.GetERPPending(depotname,shippointid);
           
        }
        
        public System.Data.DataTable getPendingProductWiseReport(int Custid,int shippointid)
        {

            ERPPendingAFBLTableAdapter getErpProductPending = new ERPPendingAFBLTableAdapter();
            return getErpProductPending.GetPendingProductWise(Custid, shippointid);
        }
        
        public List<string> AutoSearchItemData(string strSearchKey)
        {
            List<string> result = new List<string>();
            GetItemAutoSearchTableAdapter employeelist = new GetItemAutoSearchTableAdapter();
            DataTable oDT2 = new DataTable();
            oDT2 = employeelist.GetVehicleAutoSearch(strSearchKey);
            if (oDT2.Rows.Count > 0)
            {
                for (int index = 0; index < oDT2.Rows.Count; index++)
                {
                    result.Add(oDT2.Rows[index]["strRegNo"].ToString());
                }

            }
            return result;
        }


        public List<string> AutoSearchPartsData(string strSearchKey)
        {
            List<string> result = new List<string>();
            GetItemAutoSearchTableAdapter SpareItemList = new GetItemAutoSearchTableAdapter();
            DataTable oDT = new DataTable();
            oDT = SpareItemList.GetVehicleAutoSearch(strSearchKey);
            //oDT = SpareItemList.SearPartsGetData(whid,strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strRegNo"].ToString());
                }
            }
            return result;
        }
        public List<string> AutoSearchCustNameData(string strSearchKey)
        {
            List<string> result = new List<string>();
            AutoSearchCustomerTableAdapter SpareItemList = new AutoSearchCustomerTableAdapter();
            DataTable oDT = new DataTable();
            oDT = SpareItemList.GetCustName(strSearchKey);
              if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["CustName"].ToString());
                }
            }
            return result;
        }

        public string InsertPendingform(string xmlString, int custid, string vehicleno, int vehicleids, string slipno, int shippointid, string Drivername, string mobileno, string strSupplierName)
        {

            AFBLPendingInsertformTableAdapter GetPendingInsert = new AFBLPendingInsertformTableAdapter();
            GetPendingInsert.GetAFBLPendingInsertform(xmlString, custid, vehicleno, vehicleids, slipno, shippointid, Drivername, mobileno, strSupplierName);
            string msg = "Successfully";
            return msg;
        }


        public DataTable getslipno(int intshipid)
        {
            AFBLSlipNoTableAdapter GetSlipno = new AFBLSlipNoTableAdapter();
            return GetSlipno.GetSlipnoData(intshipid);

        }

        public DataTable getSlipReport(int shippointid)
        {
            afblPendingPrintTableAdapter getSlipno = new afblPendingPrintTableAdapter();
            return getSlipno.GetallSlipData(shippointid);

           
        }

        public DataTable getSlipDetailsReportfino(string Slipno)
        {
            afblPendingPrintTableAdapter GetSlipnoreportDetails = new afblPendingPrintTableAdapter();
            return GetSlipnoreportDetails.GetSlipDetails(Slipno);


        }
        public DataTable getSlipDetailsReport(string Slipno,int unitid=2)
        {
            AFBLAutoChallanCreate1TableAdapter GetSlipnoreportDetails = new AFBLAutoChallanCreate1TableAdapter();
            return GetSlipnoreportDetails.GetAFBLAutoChallanCreateData(Slipno, unitid);


        }

        public DataTable getCustBalance(int Custid)
        {

            tblCustomerTableAdapter GetCustBalanceInfo = new tblCustomerTableAdapter();
            return GetCustBalanceInfo.GetBalanceOnCustomer(Custid);

        }
        public void getBalance(int custid, int enroll, int unit, ref decimal b, ref decimal c)
        {
            decimal? bc = null;
            decimal? cc = null;
            try
            {
                sprCustomerGetCrLmCrBalTableAdapter getOrderUpdate = new sprCustomerGetCrLmCrBalTableAdapter();
                getOrderUpdate.GetBalance(custid, enroll, unit, ref cc, ref bc);
                b = bc.Value;
                c = cc.Value;

            }
            catch { }
        }
        public string AutoChallaninsertform(string xmlString, ref string intentryid, int insertby, int intunitid, DateTime dtdate, string strChallanNo, int CustType, int custid, int intDisPointId, string narratioin, string CustAddress, bool ysnDO2, bool ysnChallanCompleted, int intPriceVarId, int intVehicleVarId, decimal numLogisticCharge, bool ysnLogistic, bool ysnLogisticByCompany, string strVehicleRegNo, int intVehicleId, int intVehicleTypeId, int intChargeId, decimal numCharge, int intIncentiveId, decimal numIncentive, string strSupplierCOACod, string strSupplier, bool ysnChargeToSupplier, int intCurrencyId, decimal numConvRate, int intsalestypeid, decimal monExtraAmount, string strExtraCause, string strOther, string strDrivername, string strDriverContact, int intSalesOffId, int intshipingpointid, ref string strCode)
        {
            long? id = null;
            //  id = long.Parse(intentryid);

            // sprSalesEntryTableAdapter autochallancreate = new sprSalesEntryTableAdapter();
            sprSalesEntryTest1TableAdapter autochallancreate = new sprSalesEntryTest1TableAdapter();
            autochallancreate.GetData(xmlString, ref  id, Convert.ToInt32(insertby), Convert.ToInt32(intunitid), dtdate, strChallanNo, Convert.ToInt32(CustType), Convert.ToInt32(custid), Convert.ToInt32(intDisPointId), narratioin, CustAddress, ysnDO2, ysnChallanCompleted, Convert.ToInt32(intPriceVarId), Convert.ToInt32(intVehicleVarId), Convert.ToDecimal(numLogisticCharge), ysnLogistic, Convert.ToBoolean(ysnLogisticByCompany), strVehicleRegNo, Convert.ToInt32(intVehicleId), Convert.ToInt32(intVehicleTypeId), Convert.ToInt32(intChargeId), Convert.ToDecimal(numCharge), Convert.ToInt32(intIncentiveId), Convert.ToDecimal(numIncentive), strSupplierCOACod, strSupplier, ysnChargeToSupplier, Convert.ToInt32(intCurrencyId), Convert.ToDecimal(numConvRate), Convert.ToInt32(intsalestypeid), Convert.ToDecimal(monExtraAmount), strExtraCause, strOther, strDrivername, strDriverContact, Convert.ToInt32(intSalesOffId),Convert.ToInt32(intshipingpointid), ref strCode);
        
            string msg = "Successfully";
            return msg;
        }


        public List<string> AutoSearchItemDataDriver(string strSearchKeyempnew)
        {
            List<string> results = new List<string>();
            DriverAutoSearchTableAdapter employeelists = new DriverAutoSearchTableAdapter();
            DataTable oDT12 = new DataTable();
            oDT12 = employeelists.GetEmployeeName(strSearchKeyempnew);
            if (oDT12.Rows.Count > 0)
            {
                for (int index = 0; index < oDT12.Rows.Count; index++)
                {
                    results.Add(oDT12.Rows[index]["strEmployeeName"].ToString());
                }

            }
            return results;
        }

        public DataTable getEmpMobile(int enroll)
        {

            tblEmployeeMobileTableAdapter getDriverMobileno = new tblEmployeeMobileTableAdapter();
            return getDriverMobileno.GetDriverMobileno(enroll);

        }

        public void insertVehicle(string Custid, string Vehicleno, int Vehicleid, string drivername, string mobibleno, int shippointid, string supliername)
        {

            afblPendingVehicleSetTableAdapter getInsertvehcile = new afblPendingVehicleSetTableAdapter();
            getInsertvehcile.GetPendingVehicleSet(int.Parse(Custid), Vehicleno, Vehicleid, drivername, mobibleno, shippointid, supliername);
           
        }

        public DataTable getVehicleProgramReport(int shippointid)
        {

            VehicleProgramReprotTableAdapter GetVehicleProgram = new VehicleProgramReprotTableAdapter();
            return GetVehicleProgram.GetVehicleProgramReport(shippointid);

        }

        public List<string> AutoSearchDriverName(string strSearchKey)
        {
            List<string> results = new List<string>();
            DriverAutoSearchTableAdapter employeelists = new DriverAutoSearchTableAdapter();
            DataTable oDT12 = new DataTable();
            oDT12 = employeelists.GetEmployeeName(strSearchKey);
            if (oDT12.Rows.Count > 0)
            {
                for (int index = 0; index < oDT12.Rows.Count; index++)
                {
                    results.Add(oDT12.Rows[index]["strEmployeeName"].ToString());
                }

            }
            return results;
        }

        public DataTable getDriverMobile(int driverenroll)
        {
            tblDriverMobileTableAdapter getDriverMobileno = new tblDriverMobileTableAdapter();
            return getDriverMobileno.GetDriverMobilenoData(driverenroll);
        }



        public DataTable getBalanceCheck(string slip, int custid)
        {
            BalanceCheckTableAdapter GetBalance = new BalanceCheckTableAdapter();
            return GetBalance.GetBalanceCheck(slip, custid);

        }

        public DataTable getChallanCountCheck(int ShipPointid, int custid)
        {

            ChallanCheckTableAdapter getChallanCountCheck = new ChallanCheckTableAdapter();
            return getChallanCountCheck.GetChallanCheck(ShipPointid,custid);



        }

        public void getUpdateSlipno(string slip, int custid)
        {
            throw new NotImplementedException();
        }

        public void getUpdateSlipno(string slip)
        {
            afblPendingPrint1TableAdapter GetChallanUpdate = new afblPendingPrint1TableAdapter();
            GetChallanUpdate.GetData(slip);
           
        }

        public void getBalanceUpdate(int custid, int ShipPointid)
        {
            afblPendingPrint1TableAdapter GetChallanUpdate = new afblPendingPrint1TableAdapter();
            GetChallanUpdate.GetUpdateVehcileDataBy(custid, ShipPointid);
        }

        public void GetChancelChallan(string slipno)
        {

            ChancelChallanTableAdapter GetChancelChallan = new ChancelChallanTableAdapter();
            GetChancelChallan.GetChallanNoData(slipno);
            
        }

        public DataTable getPendingReportVehicle(string depotname, int shippointid)
        {
            ERPPendingAFBLVSVehicleTableAdapter getErpPending = new ERPPendingAFBLVSVehicleTableAdapter();
            return getErpPending.GetERPPendingVehicleData(depotname, shippointid);
        }

        public void GetChancelChallanVehicle(int Custid)
        {


            ChancelChallanTableAdapter GetDelete = new ChancelChallanTableAdapter();
            GetDelete.GetVehicleDelete(Custid);
        }

        public DataTable getPendingReportSingleCustomer(string depotname, int shippointid, int Custid)
        {
            ERPPendingAFBLSingleCustomerTableAdapter getCustomer = new ERPPendingAFBLSingleCustomerTableAdapter();
            return getCustomer.GetSingleCustomer(depotname,shippointid,Custid);
        }

        public DataTable getDepotStock(string depotname, int shippointid, int partid, DateTime dtefromdate, DateTime dtetodate)
        {

            AFBLDepotstockDetailsTableAdapter GetDepotStock = new AFBLDepotstockDetailsTableAdapter();
            return GetDepotStock.GetDepotStock(depotname,shippointid,partid,dtefromdate,dtetodate);
            
           
        }

        public DataTable getincetiveReport(DateTime dtedate,int numbers)
        {
            
            AFBLDistributorIncentiveReportFinalAccountsTableAdapter getDistributorIncentive = new AFBLDistributorIncentiveReportFinalAccountsTableAdapter();
            return getDistributorIncentive.GetDistributorIncentiveReportAccounts(dtedate, numbers);
        }

        public DataTable getJvReport(string narrations, decimal monIncentiveTotal)
        {
            JVCreateTableAdapter getJVCreate = new JVCreateTableAdapter();
            return getJVCreate.GetJVCreateNumber(narrations,Convert.ToString(monIncentiveTotal));
        }

        public void getinsertJv(string JVnumbers, decimal intAccountid, string narations, decimal amount, string strAccName)
        {
            tblAccountsVoucherJournalDetailsTableAdapter getinsertJV = new tblAccountsVoucherJournalDetailsTableAdapter();
            getinsertJV.GetAccountsJvCreateLedgur(Int64.Parse(JVnumbers.ToString()),int.Parse(intAccountid.ToString()),narations,amount,strAccName);
        }

        public void getJVInsertTotalAmount(string JVnumbers, string narrations, decimal monIncentiveTotal)
        {
            tblAccountsVoucherJournalDetails1TableAdapter getIncentiveJVtotal = new tblAccountsVoucherJournalDetails1TableAdapter();
            getIncentiveJVtotal.GetIncentiveTotal(Int64.Parse(JVnumbers),narrations,monIncentiveTotal);
        }

        public DataTable getTradeofferbill()
        {
            tblAFBLTradeOfferBillTableAdapter gettradeoffer = new tblAFBLTradeOfferBillTableAdapter();
            return gettradeoffer.GetTradeofferBill();
        }

        public DataTable getTradeofferAccounts()
        {
            tblAFBLTradeOfferBill1TableAdapter getTradeofferAccounts = new tblAFBLTradeOfferBill1TableAdapter();
            return getTradeofferAccounts.GetTradeofferBillAccounts();
        }

        public void getApprove(string slipno)
        {
            tblAFBLTradeOfferBill2TableAdapter getApprovedir = new tblAFBLTradeOfferBill2TableAdapter();
            getApprovedir.GetApproveDirectiorSir(slipno);
        }

        public DataTable getApproveDetailsAccount(string promotionname)
        {
            AccountApproveDetailsTableAdapter getApproveAccountDetails = new AccountApproveDetailsTableAdapter();
            return getApproveAccountDetails.GetFinalTradeBill(promotionname);

        }

        public DataTable getTotalAmount(string promotionname)
        {
            PromotionTotalAmountTableAdapter getTotamBillTradeoffer = new PromotionTotalAmountTableAdapter();
            return getTotamBillTradeoffer.GetPromotionName(promotionname);
        }

        public DataTable getDiractorsirApprovedetails(string promotionname)
        {
            TradeofferBillDiractorsirTableAdapter getDiractorsirApproveDetailss = new TradeofferBillDiractorsirTableAdapter();
            return getDiractorsirApproveDetailss.GetBillforDiractorSirReport(promotionname);
        }

        public DataTable GetRiverBillAccoutReport(string billtype, DateTime dtedate)
        {
            RiverAndhillBillAccountsTableAdapter RiverBill = new RiverAndhillBillAccountsTableAdapter();
            return RiverBill.GetRiverAndHillCommission(billtype,dtedate);
        }

        public DataTable getHillandRiverReport( string billtype,DateTime dtedate)
        {
            DataTable4TableAdapter getRiverBillandHilltotal = new DataTable4TableAdapter();
            return getRiverBillandHilltotal.GetRiverAndHillBillTotal(billtype,dtedate);
        }

        public void getTraingApplicationInsert(string TrainingOrg, string Subject, string Address, string Details, DateTime dtefromdate, DateTime dteTodate, DateTime dtedate, int enroll)
        {
            tblTrainingIndentTableAdapter getTriningInsert = new tblTrainingIndentTableAdapter();
             getTriningInsert.GetTrainingApplicationiinsertfor(TrainingOrg, Subject, Address, Details,Convert.ToString(dtefromdate),Convert.ToString(dteTodate),Convert.ToString(dtedate), enroll);
        }

        public DataTable getreports()
        {
            tblTrainingIndent1TableAdapter report = new tblTrainingIndent1TableAdapter();
            return report.GetTrainingreport();
        }

        public void getApprovedApplicawtion(int intid)
        {
            tblTrainingIndentTableAdapter GetApproved = new tblTrainingIndentTableAdapter();
             GetApproved.GetUpdateApprove(intid);
        }

        public DataTable getApprovedStatus(int enroll)
        {
            tblTrainingIndent1TableAdapter getApprovedStatusReports = new tblTrainingIndent1TableAdapter();
            return getApprovedStatusReports.GetApprovedstatus(enroll);
        }

        public DataTable getDepotStockReports()
        {
            DepotStockReportTableAdapter GetstockReportDepot = new DepotStockReportTableAdapter();
            return GetstockReportDepot.GetDepotStockReports();
        }

        public DataTable getUnitname(int enroll)
        {
            UnitNameTableAdapter getUnitName = new UnitNameTableAdapter();
               return getUnitName.GetEmployeeUnitName(enroll);
        }

        public void getMealCancel(DateTime dtefromdate, DateTime dteTodate, int enroll)
        {
            CanteenmealCancelTableAdapter getCancelReport = new CanteenmealCancelTableAdapter();
            getCancelReport.GetCancelMeal(dtefromdate, dteTodate, enroll);
        }

        public DataTable getCancelReport(int enroll)
        {
            tblCanteenIndentCancel1TableAdapter getCancelReport = new tblCanteenIndentCancel1TableAdapter();
            return getCancelReport.GetChancelReport(enroll);
        }

        public void getMealCreate(DateTime dtedate, int numbers)
        {
            CanteenmealCreateTableAdapter getMealCreate = new CanteenmealCreateTableAdapter();
             getMealCreate.GetMealCreate(dtedate,numbers);
        }

   
        public DataTable getmealReport(DateTime dtedate, int numbers)
        {
            CanteenmealCreateTableAdapter getCantinReport = new CanteenmealCreateTableAdapter();
            return getCantinReport.GetMealCreate(dtedate,numbers);
        }


        public DataTable getCanteenReportbyUser(DateTime dtedte, int num, int enroll)
        {
            CanteenmealReportTableAdapter ReportCanteenReport = new CanteenmealReportTableAdapter();
            return ReportCanteenReport.GetData(dtedte, num, enroll);
        }

        public DataTable getUserbyReport(int enroll)
        {
            tblCanteenIndentEmployeeListTableAdapter getReportbyuserMeail = new tblCanteenIndentEmployeeListTableAdapter();
            return getReportbyuserMeail.GetUserByMeal(enroll);
             
        }

        public void getGustmealIndent(int enroll, int meailqty, DateTime dtedates)
        {
            GuestMealIndentTableAdapter getmailindent = new GuestMealIndentTableAdapter();
            getmailindent.GetData(enroll,meailqty,Convert.ToString(dtedates));
        }

        public DataTable getIndent(DateTime dtedate)
        {
            tblCanteenGuestindentTableAdapter getIndentReport = new tblCanteenGuestindentTableAdapter();
            return getIndentReport.GetIndentReport(Convert.ToString(dtedate));
        }

        public DataTable getDatatableIndetn(DateTime dtedates, int enr)
        {
            tblCanteenGuestindent1TableAdapter getReport = new tblCanteenGuestindent1TableAdapter();
            return getReport.GetData(Convert.ToString(dtedates), enr);
        }

        public void getUpdateMeal(decimal qty, DateTime dtedates, int enr)
        {
            tblCanteenMealEntryDailyTableAdapter getupdatemeal = new tblCanteenMealEntryDailyTableAdapter();
            getupdatemeal.GetData(qty,Convert.ToString(dtedates),enr);
        }

        public void getMeailApproved(int enr)
        {
            tblCanteenMealEntryDailyTableAdapter mealApproved = new tblCanteenMealEntryDailyTableAdapter();
            mealApproved.GetUpdateMealApprove(enr);
        }

        public DataTable getApproveMealReport(int enroll)
        {
            tblCanteenGuestindent2TableAdapter getApprovedReport = new tblCanteenGuestindent2TableAdapter();
            return getApprovedReport.GetApprovedReport(enroll);
        }

        public DataTable getDailQty(int enr, DateTime dtedates)
        {
            tblCanteenMealEntryDaily1TableAdapter getdailyQty = new tblCanteenMealEntryDaily1TableAdapter();
            return getdailyQty.GetDailyQty(enr, Convert.ToString(dtedates)); 
        }

        public void getEmployeeSetup(int enroll, string temppermant, decimal discount, decimal EmpContribute, decimal total)
        {
            EmployeeNewCreateByemailTableAdapter GetEmployeeadd = new EmployeeNewCreateByemailTableAdapter();
             GetEmployeeadd.GetEmplyenewByMeal(enroll,temppermant,discount,EmpContribute,total);
        }

        public void getEntryofrTemporry(int enroll,  DateTime dtedates,int meailqty)
        {
            CanteenMealEntryForEReguralTableAdapter getTemEntry=new CanteenMealEntryForEReguralTableAdapter();
             getTemEntry.GetEntryForTempEmployee(enroll, dtedates, meailqty);

        }

       // public DataTable getcount(int enroll, DateTime dte)
       // {
          //  DataTable7TableAdapter counts = new DataTable7TableAdapter();
           // return counts.GetEntryCancelCheck(enroll, dte);
       // }

        public DataTable getcount(int enroll, DateTime dte)
        {
            DataTable7TableAdapter countsReport = new DataTable7TableAdapter();
            return countsReport.GetEntryCancelCheck(enroll,Convert.ToString(dte));
        }

        public DataTable getmenuReport(string dayname)
        {
            tblCanteenMenuListTableAdapter getMenuReport = new tblCanteenMenuListTableAdapter();
            return getMenuReport.Getdata(dayname);

        }

        public void updateReport(int ids, string mealitem)
        {
            tblCanteenMenuList1TableAdapter getReport = new tblCanteenMenuList1TableAdapter();
             getReport.GetUpdateMenu(mealitem,ids);



        }

        public DataTable getLunchMenu(string daynames)
        {
            tblCanteenMenuListTableAdapter getMenuList = new tblCanteenMenuListTableAdapter();
            return getMenuList.Getdata(daynames);
        }

        public DataTable getDamageforAccounts(DateTime dtedate)
        {
            DamagedairyForAccountsTableAdapter getdamageReport = new DamagedairyForAccountsTableAdapter();
            return getdamageReport.GetDamagedairyForAccounts(dtedate);
        }

        public DataTable getDamageAmount(DateTime dtedate)
        {
            DamagedairyAmountTableAdapter getdamageAmount = new DamagedairyAmountTableAdapter();
            return getdamageAmount.GetDamageAmount(dtedate);
        }

       

        public void getinsertJvdamageentry(string JVnumbers, decimal intAccountid, string narations, decimal amount, string strAccName)
        {
            tblAccountsVoucherJournalDetailsTableAdapter getinsertJV = new tblAccountsVoucherJournalDetailsTableAdapter();
            getinsertJV.GetAccountsJvCreateLedgur(Int64.Parse(JVnumbers.ToString()), int.Parse(intAccountid.ToString()), narations, amount, strAccName);
        }

        public void getJVInsertDamageTotalAmount(string JVnumbers, string narrations, decimal monDamageeTotal)
        {
            DamageHeadInsertTableAdapter getInsertDamgeTotalhead = new DamageHeadInsertTableAdapter();
             getInsertDamgeTotalhead.GetDamageHeadInsert(Int64.Parse(JVnumbers),narrations,monDamageeTotal);
        }

        public void getDamageBillupdateDairy(DateTime dtedate)
        {
            DamageBillUpdateTableAdapter getDamageupdate = new DamageBillUpdateTableAdapter();
            getDamageupdate.GetDamageUpdatebyAccounts(dtedate);

        }

        public void getCancelEnrollRollback(DateTime dtefromdate, DateTime dteTodate, int enrollno)
        {
            CancelmealRollBackTableAdapter getCancelRollback = new CancelmealRollBackTableAdapter();
            getCancelRollback.GetCancelMealRollback(Convert.ToString(dtefromdate),Convert.ToString(dtefromdate),enrollno);
        }

        public DataTable getmealCancelList(DateTime dtedate)
        {
            MealCancelListTableAdapter getMealCancelList = new MealCancelListTableAdapter();
            return getMealCancelList.GetMealCancelList(Convert.ToString(dtedate));
        }



        public DataTable getMealCheckCount(DateTime dtedate)
        {
            MealCheckTableAdapter getMealCheckSubmit = new MealCheckTableAdapter();
            return getMealCheckSubmit.GetMealCheck(Convert.ToString(dtedate));
        }

        public void getEmployeeCatagoryUpdate(int enroll, string temppermant)
        {
            tblCanteenIndentEmployeeList1TableAdapter getUpdateEmpCatagory = new tblCanteenIndentEmployeeList1TableAdapter();
            getUpdateEmpCatagory.GetEmployeeCatagoryUpdate(temppermant,enroll);
        }
    }
}
