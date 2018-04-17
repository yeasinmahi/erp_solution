using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLOBAL_BLL;
using SAD_DAL.Customer.Report;
using SAD_DAL.Customer.Report.StatementTDSTableAdapters;
using System.Data;
using System.Collections;

namespace SAD_BLL.Customer.Report
{
    public class StatementC
    {
        //private static SearchTDS.SprAutosearchRequesitionDataTable[] tableCusts = null;
        private static Hashtable ht = new Hashtable();     

        #region  -------------- This Region for General Erp ---------------
        public StatementTDS.SprCustomerStatementDataTable GetStatementByCustomer(string fromDate, string toDate, string customerId, string userID, string unitID, ref string accountName,ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
        {
            DateTime? frm = null, to = null;           

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now; }

            SprCustomerStatementTableAdapter ta = new SprCustomerStatementTableAdapter();
            return ta.GetData(frm, to, int.Parse(customerId), int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }

        public StatementTDS.SprCustomerStatementDrCrDataTable GetStatementDrCrByCustomer(string fromDate, string toDate, string customerId, string userID, string unitID,string salesOffice,string type, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
        {
            DateTime? frm = null, to = null;
            int? id = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now; }

            try { id = int.Parse(customerId); }
            catch { }


            SprCustomerStatementDrCrTableAdapter ta = new SprCustomerStatementDrCrTableAdapter();
            return ta.GetData(frm, to, id, int.Parse(userID), int.Parse(unitID),int.Parse(salesOffice),int.Parse(type), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }

        public StatementTDS.SprCustomerStatementOnCrLimitDataTable GetStatementByCustomerCreditBalance(string date, string customerId, string userID
            , string unitID,string periodList,string salesOfficeId,string type, ref string unitName, ref string unitAddress)
        {
            DateTime? day = null;
            int? cus = null;

            try
            {
                cus = int.Parse(customerId);
            }
            catch { }
            try
            {
                day = DateFormat.GetDateAtSQLDateFormat(date).Value;
            }
            catch { }
                        

            SprCustomerStatementOnCrLimitTableAdapter ta = new SprCustomerStatementOnCrLimitTableAdapter();
            return ta.GetData(day, cus, int.Parse(userID), int.Parse(unitID), periodList, int.Parse(salesOfficeId), int.Parse(type), ref unitName, ref unitAddress);
        }

        public StatementTDS.SprCustomerStatementOnCrLimitByCustomerDataTable GetStatementByCustomerCreditBalanceByCustomer(string date, string customerId, string userID
            , string unitID, string salesOfficeId, string type)
        {
            DateTime? day = null;
            int? cus = null;

            try
            {
                cus = int.Parse(customerId);
            }
            catch { }
            try
            {
                day = DateFormat.GetDateAtSQLDateFormat(date).Value.Date;
            }
            catch { }


            SprCustomerStatementOnCrLimitByCustomerTableAdapter ta = new SprCustomerStatementOnCrLimitByCustomerTableAdapter();
            return ta.GetData(day, cus, int.Parse(userID), int.Parse(unitID), int.Parse(salesOfficeId), int.Parse(type));
        }
        #endregion


        #region  -------------- This Region for Remote Sales Report (ACCL) ---------------
        public DataTable GetStatementByCustomerCreditBalanceRemote(string date, string email
        , string unitID, string periodList, string salesOfficeId, string type)
        {
            DateTime? day = null;
            try
            {
                day = DateFormat.GetDateAtSQLDateFormat(date).Value;
            }
            catch { }


            SprCustomerStatementOnCrLimitRemoteTableAdapter adp = new SprCustomerStatementOnCrLimitRemoteTableAdapter();
            try
            {
                return adp.GetCRRemoteBalanceData(day, email, int.Parse(unitID), int.Parse(salesOfficeId), int.Parse(type));
            }
            catch { return new DataTable(); }

        }
        public DataTable GetTerritoryCustomerAchbll(DateTime FromDate, DateTime ToDate, String tsoemail)
        {
            SprACCLTSOBaseCustTargSalesTableAdapter taTerritoryCustSalesTarget = new SprACCLTSOBaseCustTargSalesTableAdapter();
            try
            {
                return taTerritoryCustSalesTarget.GetTeritoryAchiveData(FromDate, ToDate, tsoemail);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetDistributorCoverage(DateTime FromDate, DateTime Todate, String tsoemail)
        {
            SprACCLDistributorCoverTSOTableAdapter bllCoverage = new SprACCLDistributorCoverTSOTableAdapter();
            try
            {
                return bllCoverage.GetDistributorCoverageData(FromDate, Todate, tsoemail);
            }
            catch
            {
                return new DataTable();

            }


        }
        public DataTable bllGetRetaillerYearlysales(String tsoemail, DateTime fromDateJanu)
        {
            SprACCLRetailleryearlySalesTSOBaseTableAdapter bllRetaillersales = new SprACCLRetailleryearlySalesTSOBaseTableAdapter();
            try
            {

                //return bllRetaillersales.GetDataRetaillerTotalSalesTerritoryBase(tsoemail, fromDateJanu, toDateJanu, fromDateFeb, toDateFeb, fromDateMarch, toDateMarch, fromDateApril, toDateApril, fromDateMay, toDateMay, fromDateJune, toDateJune, fromDateJuly, toDateJuly, fromDateAugest, toDateAugest, fromDateSept, toDateSept, fromDateOct, toDateOct, fromDateNovem, toDateNovem, fromDateDecem, toDateDecem);

                return bllRetaillersales.GetDatasprACCLRetailleryearlySalesTSOBase(tsoemail, fromDateJanu);
            }
            catch
            {
                return new DataTable();
            }

        }
        public DataTable bllGetActiveInactiveRetailer(String tsoemail, DateTime fromdate, DateTime todate)
        {
            SprACCLSolshopvsNotSoldsShopTableAdapter bllActiveinactive = new SprACCLSolshopvsNotSoldsShopTableAdapter();
            try
            {
                return bllActiveinactive.GetDataActiveInactiveRetailerSales(tsoemail, fromdate, todate);

            }

            catch
            {
                return new DataTable();
            }



        }
        public DataTable bllGetShopList(String tsoemail)
        {
            SprACCLTSOBaseShopListTableAdapter bllshop = new SprACCLTSOBaseShopListTableAdapter();
            try
            {

                return bllshop.GetDataTSOBaseShopList(tsoemail);

            }
            catch
            {
                return new DataTable();
            }



        }
        public DataTable bllGetMRRListTerritoryBase(DateTime dtFromdate, DateTime dtTodate, String tsoemail)
        {

            SprACCLMRStatusTerritoryBaseTableAdapter bllMRStatus = new SprACCLMRStatusTerritoryBaseTableAdapter();

            try
            {
                return bllMRStatus.GetDataMRStatusTerritoryBase(dtFromdate, dtTodate, tsoemail);
            }

            catch
            {
                return new DataTable();
            }
        }
        public DataTable bllTerritorysalesDaybyDay(DateTime dtFromDate, String tsoemail)
        {
            SprACCLTerritorySalesDayByDayBasisTableAdapter bllRetailSales = new SprACCLTerritorySalesDayByDayBasisTableAdapter();

            try
            {
                return bllRetailSales.taACCLTerritorySalesDayByDay(dtFromDate, tsoemail);

            }

            catch
            {
                return new DataTable();
            }
        }

        public DataTable bllRemoteCustomerStatement(DateTime dtFromDate, DateTime dtToDate, int CustCOAid)
        {
            sprRemoteACCLCustomerStatementTableAdapter bllRCS = new sprRemoteACCLCustomerStatementTableAdapter();
            try
            {
                return bllRCS.taRemoteCustomerStatement(dtFromDate, dtToDate, CustCOAid);
            }

            catch
            {
                return new DataTable();
            }
        }
        public DataTable bllRmtProductDelivery(DateTime dtFromDate, DateTime dtTodate, int intCustomerid)
        {
            SprACCLProductDeliveryTableAdapter bllRProductDelivery = new SprACCLProductDeliveryTableAdapter();

            try
            {
                return bllRProductDelivery.taRmtProductDelivery(dtFromDate, dtTodate, intCustomerid);
            }

            catch
            {
                return new DataTable();
            }

        }
        public DataTable bllRmtVehicleListWeightBridge()
        {
            SprACCLVehicleListWeightBridgeRmtUserTableAdapter bllVehicleList = new SprACCLVehicleListWeightBridgeRmtUserTableAdapter();
            try
            {
                return bllVehicleList.taVehicleListWeightBridge();
            }
            catch
            {
                return new DataTable();
            }


        }
        public DataTable bllRmtDOSearch(String DOnumber)
        {
            SpACCLDOSearchTableAdapter bllDOSearch = new SpACCLDOSearchTableAdapter();

            try
            {
                return bllDOSearch.taACCLDoSearching(DOnumber);
            }

            catch
            {
                return new DataTable();
            }



        }
        public DataTable GetTerritoryCustomer(string enrol, string prefix)
        {
            DataTable1TableAdapter adpcust = new DataTable1TableAdapter();
            return adpcust.tblCustomer1TableAdapter(int.Parse(enrol), prefix);
        }
        public DataTable getCustomerid(string custname)
        {

            SprACCLCustomeridFromNameTableAdapter bllGetcustid = new SprACCLCustomeridFromNameTableAdapter();

            try
            {
                return bllGetcustid.taGetACCLCustid(custname);
            }

            catch
            {
                return new DataTable();
            }


        }
        public DataTable GetTerCustomerCOAid(string enrol, string prefix)
        {
            //DataTable2TableAdapter adpCustCOAid = new DataTable2TableAdapter();
            //return adpCustCOAid.taCustomerCOAid(int.Parse(enrol), prefix);
            SprACCLCustomerSearchingBaseonOperationalSetupTableAdapter adpCustCOAid = new SprACCLCustomerSearchingBaseonOperationalSetupTableAdapter();
            return adpCustCOAid.GetDatasprACCLCustomerSearchingBaseonOperationalSetup(int.Parse(enrol), prefix);

        }

        public string tadainsert(string xmlString, int enroll, DateTime dteFromDate, DateTime dteTodate, int ApplicantCatg)
        {
            string msg = "";

            try
            {
                SprRemoteUserTADABillNoneCarTableAdapter bllRmtNoncar = new SprRemoteUserTADABillNoneCarTableAdapter();
                bllRmtNoncar.taRmtInsNonCarUserBillInfo(xmlString, enroll, dteFromDate, dteTodate, ApplicantCatg, ref msg);

                return msg;

            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public string tadainsertNoneBikeUserAfterApprove(string xmlString, int Approverenroll, int intTADAApplicantEnrol, DateTime dteFromDate, DateTime dteTodate, int Unit, int intApplicantType, int Jobstation)
        {
            string msg = "";
            try
            {

                SprRmtInsNoneBikeUserTADAAInfoAfterApproveTableAdapter bllTADANoneBikeInfoAfterAprv = new SprRmtInsNoneBikeUserTADAAInfoAfterApproveTableAdapter();
                bllTADANoneBikeInfoAfterAprv.taInsRmtTADANoneBikeUserInfo(xmlString, Approverenroll, intTADAApplicantEnrol, dteFromDate, dteTodate, Unit, intApplicantType, Jobstation, ref msg);
                return msg;

            }
            catch (Exception ex) { return ex.ToString(); }


        }
        public string tadaInsertbyBikeAndCarUser(string xmlString, DateTime dteTodate, int intApplicantEnrol, int ApplicantbilCatg)
        {
            string msg = "";
            try
            {
                SprRemoteTADAForBikeAndCarUserTableAdapter bllRmtTADABikeCarUser = new SprRemoteTADAForBikeAndCarUserTableAdapter();
                bllRmtTADABikeCarUser.taRemoteTADAforBikeCarUser(xmlString, dteTodate, intApplicantEnrol, ApplicantbilCatg, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public string tadainsertAfterApproveForBikeAndCarUser(string xmlString, int Approverenroll, int intTADAApplicantEnrol, DateTime dteFromDate, DateTime dteTodate, int Jobstation, int Unit)
        {
            string msg = "";
            try
            {
                SprRmtInsBikeCarUserTADAAInfoAfterApproveTableAdapter bllRmtInsApprBikeCar = new SprRmtInsBikeCarUserTADAAInfoAfterApproveTableAdapter();
                bllRmtInsApprBikeCar.taRmtInsBikeCarUserApprovedInfo(xmlString, dteFromDate, dteTodate, Approverenroll, intTADAApplicantEnrol, Unit, Jobstation, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }

        }
        public DataTable getRmtRptTaDaNonCarUser(DateTime dtFromDate, DateTime dtTodate, int intEnrol)
        {
            SprRemoteTADANonCarUserTableAdapter blRmtRptTaDaNonCarU = new SprRemoteTADANonCarUserTableAdapter();
            return blRmtRptTaDaNonCarU.taRemotRptTaDaNonCarUser(dtFromDate, dtTodate, intEnrol);
        }
        public DataTable getRmtbllRptTaDaNonCarTopsheet(DateTime dtFromdate, DateTime dtTodate, int intenrol)
        {
            SprRemoteTADANonCarUserTopSheetTableAdapter blRmtNonCarTopsheet = new SprRemoteTADANonCarUserTopSheetTableAdapter();
            return blRmtNonCarTopsheet.taGetDataRmtNonCarUserTopSheet(dtFromdate, dtTodate, intenrol);
        }
        public DataTable getAreabaseTsolist(string enrol, string prefix)
        {
            DataTable3TableAdapter adTSOlist = new DataTable3TableAdapter();
            DataTable dt = new DataTable();
            dt = adTSOlist.taTSOList(int.Parse(enrol), prefix);
            return adTSOlist.taTSOList(int.Parse(enrol), prefix);
        }
        public DataTable getAreabaseJSOorHONoneBikeuserlist(string enrol, string prefix)
        {
            DataTable4TableAdapter adNoneBikeuserlist = new DataTable4TableAdapter();
            DataTable dt = new DataTable();
            dt = adNoneBikeuserlist.GetDataJSOListOrNoneBikeUser(int.Parse(enrol), prefix);
            return adNoneBikeuserlist.GetDataJSOListOrNoneBikeUser(int.Parse(enrol), prefix);
        }
        public DataTable getRptRmtTADAForBikeCarUserDetaills(DateTime dtFromDate, DateTime dtTodate, int enrol)
        {
            SprRemoteTADADetaillsForBIKEAndCarUserTableAdapter bllRptRmtTADABikeCarDetaills = new SprRemoteTADADetaillsForBIKEAndCarUserTableAdapter();
            try
            {
                return bllRptRmtTADABikeCarDetaills.taRptRemoteTADAForBikeCarUserDetaills(dtFromDate, dtTodate, enrol);
            }

            catch
            {
                return new DataTable();
            }

        }
        public DataTable getRptRmtTADAForBikeCarUserTopsheet(DateTime dtFromDate, DateTime dtTodate, int intEnrol)
        {
            SprRptRemoteTADAForBikeCarUserTopsheetTableAdapter blRptRmtTADABikeCarTopsheet = new SprRptRemoteTADAForBikeCarUserTopsheetTableAdapter();
            try
            {
                return blRptRmtTADABikeCarTopsheet.taRptRemoteTADAForBikeCarUser(dtFromDate, dtTodate, intEnrol);


            }
            catch
            {
                return new DataTable();
            }
        }

        #region  --------------Report TA DA None bike user  detaills data  ---------------

        public DataTable getRptTADANoneCarUserDetaills(DateTime dtfromdate, DateTime dtTodate, int Enrol, int Unit, int userType)
        {
            SprRptTADANoneBikeUserGbTableAdapter bllRptNonebikeuserdeta = new SprRptTADANoneBikeUserGbTableAdapter();
            try
            {
                return bllRptNonebikeuserdeta.tasprRptTADANoneBikeUserGb(dtfromdate, dtTodate, Enrol, Unit, userType);
            }
            catch
            {
                return new DataTable();
            }
        }





        #endregion

        #region  --------------Get employeelist for approve their bill (Use in approve page)  ---------------


        public DataTable getApplicantListForApproveBillGB(string enrol, string prefix)
        {

            DataTable6TableAdapter bllApplicantList = new DataTable6TableAdapter();
            DataTable dt = new DataTable();
            dt = bllApplicantList.taApplicantListForApproveTADABill(int.Parse(enrol), prefix);
            return bllApplicantList.taApplicantListForApproveTADABill(int.Parse(enrol), prefix);

        }

        #endregion
        #region  --------------Report TA DA None bike user  TopSheet data  ---------------

        public DataTable getRptTADANoneCarUserTopSheet(DateTime dtfromdate, DateTime dtTodate, int Enrol, int Unit, int userType)
        {
            SprRptTADANoneBikeUserGbTopSheetTableAdapter bllRptNoneBikeUserTADATopsheet = new SprRptTADANoneBikeUserGbTopSheetTableAdapter();

            try
            {
                return bllRptNoneBikeUserTADATopsheet.taSprRptTADANoneBikeUserGbTopSheet(dtfromdate, dtTodate, Enrol, Unit, userType);
            }

            catch
            {
                return new DataTable();
            }
        }


        #endregion

        #region  --------------Report TA DA Bike And Car User Detaills data  ---------------

        public DataTable getRptTADABikeAndCarUserDetaillsGB(DateTime dtFormDate, DateTime dtTodate, int enrol, int unit, int RptTypeid)
        {
            SprRptTADABikeAndCarUserGbDetAndTopsheetTableAdapter bllRptTADAForBikeAndCarUser = new SprRptTADABikeAndCarUserGbDetAndTopsheetTableAdapter();
            try
            {

                return bllRptTADAForBikeAndCarUser.tasprRptTADABikeAndCarUserGbDetAndTopsheet(dtFormDate, dtTodate, enrol, unit, RptTypeid);
            }

            catch
            {
                return new DataTable();

            }

        }
        #region  -------------TA DA sUPERVISOV VS EMPLOYEE LIST  -------------
        public DataTable getSupervisorvsEmployeeWithBillStatus(DateTime fromdate, DateTime todate, int unitid, int Reporttype, int Supervisorid)
        {
            try
            {
                SprTADASupervisorVsEmloyeeListTableAdapter bll = new SprTADASupervisorVsEmloyeeListTableAdapter();
                return bll.tasprTADASupervisorVsEmloyeeList(fromdate, todate, unitid, Reporttype, Supervisorid);

            }
            catch (Exception ex) { return new DataTable(); }


        }


        #endregion





        #endregion
        #region  -------------- TA DA None bike user submit data  ---------------


        public string tadaInsertByApplicantNoneCarUser(string xmlString, DateTime dteFromDate, DateTime dtToDate, int Enrol, int ApplicantCatg, int unit, int jobstation)
        {
            string msg = "";

            try
            {
                SprRmtInsNoneBikeUserTADAAGblInfoByApplicantTableAdapter blltadaInsertByApplicantNoneCarUser = new SprRmtInsNoneBikeUserTADAAGblInfoByApplicantTableAdapter();
                blltadaInsertByApplicantNoneCarUser.taInsTADANoneBikeUserGB(xmlString, dteFromDate, dtToDate, Enrol, ApplicantCatg, unit, jobstation, ref msg);

                return msg;
            }

            catch (Exception ex) { return ex.ToString(); }
        }


        #endregion



        #region  -------------- TA DA None bike user report and also for aprove ---------------


        public DataTable getRmtRptTaDaNonCarUser(DateTime dtFromDate, DateTime dtTodate, int intEnrol, int unit, int userType)
        {


            SprRptTADANoneBikeUserGbTableAdapter blRmtRptTaDaNonCarU = new SprRptTADANoneBikeUserGbTableAdapter();
            return blRmtRptTaDaNonCarU.tasprRptTADANoneBikeUserGb(dtFromDate, dtTodate, intEnrol, unit, userType);

        }



        #endregion


        #region  -------------- TA DA  bike and Car user submited dat (user Entry Form) ---------------

        public string tadaInsertByApplicantBikeAndCarUser(string xmlString, DateTime dteFromDate, int Enrol, int ApplicantCatg, int unit, int jobstation)
        {
            string msg = "";
            try
            {
                SprRmtInsBikeUserTADAAGblInfoByApplicantTableAdapter bllTadaInsertByBikeAndCarUser = new SprRmtInsBikeUserTADAAGblInfoByApplicantTableAdapter();
                bllTadaInsertByBikeAndCarUser.tasprRmtInsBikeUserTADAAGblInfoByApplicant(xmlString, dteFromDate, Enrol, ApplicantCatg, unit, jobstation, ref msg);
                return msg;

            }

            catch (Exception ex) { return ex.ToString(); }

        }

        public string tadainsertAfterApproveForBikeAndCarUserGB(string xmlString, int Approverenroll, int intTADAApplicantEnrol, DateTime dteFromDate, int Unit, int intApplicantCatge, int intjobstation)
        {
            string msg = "";
            try
            {
                //SprRmtInsBikeCarUserTADAAInfoAfterApproveTableAdapter bllRmtInsApprBikeCar = new SprRmtInsBikeCarUserTADAAInfoAfterApproveTableAdapter();
                //bllRmtInsApprBikeCar.taRmtInsBikeCarUserApprovedInfo(xmlString, Approverenroll, intTADAApplicantEnrol, dteFromDate, dteTodate, Jobstation, Unit, ref msg);
                //return msg;

                SprRmtInsBikeUserTADAAGblInfoAfterApproveTableAdapter bllRmtInsApprovedDataForBikeCareUser = new SprRmtInsBikeUserTADAAGblInfoAfterApproveTableAdapter();
                bllRmtInsApprovedDataForBikeCareUser.tasprRmtInsBikeUserTADAAGblInfoAfterApprove(xmlString, Approverenroll, intTADAApplicantEnrol, dteFromDate, Unit, intApplicantCatge, intjobstation, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }


        }



        #endregion

        public DataTable getAttachment(int unit, string dtformdate, string dtTodate, int Enrol)
        {
            tblAttachmentDetaillsTableAdapter bllAttach = new tblAttachmentDetaillsTableAdapter();
            try
            {
                return bllAttach.taAttachment(unit, dtformdate, dtTodate, Enrol);
            }
            catch
            {return new DataTable();}
        }

        public DataTable getTADARptNoneBikeHRLeb(DateTime fromDate, DateTime toDate, int areaid, int Unit, int ReportType, int Applicantype)
        {

            if (ReportType == 2)
            {


                SprRptRmtTADAbyHRTableAdapter bllNoneHr = new SprRptRmtTADAbyHRTableAdapter();

                try
                {

                    return bllNoneHr.tasprRptRmtTADAbyHR(fromDate, toDate, areaid, Unit, ReportType, Applicantype);

                }
                catch
                {

                    return new DataTable();
                }
            }

            else
            {

                SprRptRmtTADAbyHRTableAdapter bllNoneHrDetailss = new SprRptRmtTADAbyHRTableAdapter();
                try { return bllNoneHrDetailss.tasprRptRmtTADAbyHR(fromDate, toDate, areaid, Unit, ReportType, Applicantype); }
                catch { return new DataTable(); }

            }



        }
        public DataTable getRptTADABikeCarHRLeb(DateTime fromDate, DateTime toDate, int areaid, int Unit, int ReportType, int Applicantype)
        {
            if (ReportType == 2)
            {


                SprRptRmtTADAOnlyBikeAndCarUserbyHRTableAdapter bllBikeCarHRLeb = new SprRptRmtTADAOnlyBikeAndCarUserbyHRTableAdapter();

                try
                {

                    return bllBikeCarHRLeb.tasprRptRmtTADAOnlyBikeAndCarUserbyHR(fromDate, toDate, areaid, Unit, ReportType, Applicantype);

                }
                catch
                {

                    return new DataTable();
                }
            }
            else
            {
                SprRptRmtTADAOnlyBikeAndCarUserbyHRTableAdapter bllBikeCarHRLeb = new SprRptRmtTADAOnlyBikeAndCarUserbyHRTableAdapter();

                try
                {

                    return bllBikeCarHRLeb.tasprRptRmtTADAOnlyBikeAndCarUserbyHR(fromDate, toDate, areaid, Unit, ReportType, Applicantype);

                }
                catch
                {

                    return new DataTable();
                }

            }

        }

        public string tadaInsertByHRBikeCarUser(string xmlString, int ApproverEnrol, DateTime dteFromDate, DateTime dtToDate, int ApplicantCatg)
        {
            string msg = "";
            try
            {
                SprRmtInsBikeAndCarUserTADAGbAprByHRTableAdapter bllBikeInsHR = new SprRmtInsBikeAndCarUserTADAGbAprByHRTableAdapter();
                bllBikeInsHR.tasprRmtInsBikeAndCarUserTADAGbAprByHR(xmlString, ApproverEnrol, dteFromDate, dtToDate, ApplicantCatg, ref msg);
                return msg;

            }

            catch (Exception ex) { return ex.ToString(); }

        }

        public string tadaInsertByHR(string xmlString, int ApproverEnrol, DateTime dteFromDate, DateTime dtToDate, int ApplicantCatg)
        {
            string msg = "";
            try
            {
                SprRmtInsNoneBikeUserTADAGbAprByHRTableAdapter bllNoneBikeInsHR = new SprRmtInsNoneBikeUserTADAGbAprByHRTableAdapter();
                bllNoneBikeInsHR.tasprRmtInsNoneBikeUserTADAGbAprByHR(xmlString, ApproverEnrol, dteFromDate, dtToDate, ApplicantCatg, ref msg);
                return msg;

            }

            catch (Exception ex) { return ex.ToString(); }

        }

         public void docimageinsert(string filename, int size, string path, int enrol, int unit, string dtBillDate)
        {
            try
            {
                tblAttachmentDetaills1TableAdapter bllimage = new tblAttachmentDetaills1TableAdapter();
                bllimage.uploadimage(filename, size, path, enrol, unit, dtBillDate);
            }
            catch
            {
            }
        }

        #endregion

         #region  --------------Report TA DA None Car user Audit LEVEL ---------------
         public DataTable getRptTADABikeCarAuditLeb(DateTime fromDate, DateTime toDate, int applEnrol, int ReportType)
         {
             if (ReportType == 2)
             {
                 SprRptRmtTADAbyAuditTableAdapter blltadaAudit = new SprRptRmtTADAbyAuditTableAdapter();
                 try
                 {
                     return blltadaAudit.tasprRptRmtTADAbyAudit(fromDate, toDate, applEnrol, ReportType);
                 }
                 catch
                 {
                     return new DataTable();
                 }


             }
             else
             {
                 SprRptRmtTADAbyAuditTableAdapter blltadaAudit = new SprRptRmtTADAbyAuditTableAdapter();
                 try
                 {
                     return blltadaAudit.tasprRptRmtTADAbyAudit(fromDate, toDate, applEnrol, ReportType);
                 }
                 catch
                 {
                     return new DataTable();
                 }

             }



         }

         #endregion
         #region  --------------Report TA DA Bike And Car user Audit LEVEL ---------------         
        
    




         #endregion

         #region  -------------- TA DA  bike user  APPROVE INFO INSERT BY Audit LEBEL  ---------------

         public string tadaInsertbyAuditNoneCaruser(string xmlString, int ApproverEnrol, int ApplicnatEnrol, DateTime dteFromDate, DateTime dtToDate, int ApplicantCatg)
         {
             string msg = "";
             try
             {
                 SprRmtInsNoneBikeUserTADAGbAprByAuditTableAdapter bllNoneBikeAudit = new SprRmtInsNoneBikeUserTADAGbAprByAuditTableAdapter();
                 bllNoneBikeAudit.tasprRmtInsNoneBikeUserTADAGbAprByAudit(xmlString, ApproverEnrol, ApplicnatEnrol, dteFromDate, dtToDate, ApplicantCatg, ref msg);
                 return msg;
             }
             catch (Exception ex)
             {
                 return ex.ToString();
             }

         }



         #endregion
         #region  -------------- TA DA  bike user  APPROVE INFO INSERT BY Audit LEBEL  ---------------

         public string tadaInsertByAuditBikeCarUser(string xmlString, int ApproverEnrol, int ApplicnatEnrol, DateTime dteFromDate, DateTime dtToDate, int ApplicantCatg)
         {
             string msg = "";
             try
             {

                 SprRmtInsBikeAndCarUserTADAGbAprByAuditTableAdapter bllBikeCarAudit = new SprRmtInsBikeAndCarUserTADAGbAprByAuditTableAdapter();
                 bllBikeCarAudit.tasprRmtInsBikeAndCarUserTADAGbAprByAudit(xmlString, ApproverEnrol, ApplicnatEnrol, dteFromDate, dtToDate, ApplicantCatg, ref msg);
                 return msg;
             }
             catch (Exception ex)
             {
                 return ex.ToString();
             }
         }



         #endregion

         #region  --------------Remote TA DA Attachment Insertion ---------------
         public string tadaAttachmentInsert(string strcontent, decimal size, string url, int enrol, int unit, DateTime dtbilldate, int attachtype, int jobstation)
         {
             string msg = "";
             //try
             //{
                 SprRmtInsAttachmentDetTableAdapter blltadaattachment = new SprRmtInsAttachmentDetTableAdapter();
                 blltadaattachment.tasprRmtInsAttachmentDet(strcontent, size, url, enrol, unit, dtbilldate, attachtype, jobstation, ref msg);
                 return msg;

             //}
             //catch (Exception ex)
             //{
             //    return ex.ToString();
             //}

         }
         


         public DataTable getEndMilageApplicant(int Enrolaplicant)
         {
             DataTable dt = new DataTable();
             try
             {

                 tblRemoteTADATableAdapter bll = new tblRemoteTADATableAdapter();
                 dt = bll.taEndMilage(Enrolaplicant);
                 return bll.taEndMilage(Enrolaplicant);

             }

             catch { return new DataTable(); }
         }
         public DataTable getFuelStationList(int Unit)
         {
             try
             {
                 tblRemoteTADAFuelStationListTableAdapter bll = new tblRemoteTADAFuelStationListTableAdapter();
                 return bll.taFuelStationList(Unit);
             }
             catch { return new DataTable(); }
         }
         #endregion

         #region  --------------AttachmentDetaills TA DA with Category For Super level and Audit lebel ---------------
         public DataTable getReportTADAHRpRINT(DateTime dtformdate, DateTime dtTodate, int Unitid, int ReportType)
         {
             try
             {

                 SprRptRmtTADAAprvByHRForPrintTableAdapter hrPrint = new SprRptRmtTADAAprvByHRForPrintTableAdapter();
                 return hrPrint.tasprRptRmtTADAAprvByHRForPrint(dtformdate, dtTodate, Unitid, ReportType);
             }
             catch { return new DataTable(); }
         }
         public DataTable getAreaNameHR(int UNIT)
         {
             try
             {

                 DataTableUnitVsAreaTableAdapter bll = new DataTableUnitVsAreaTableAdapter();
                 return bll.taGetAreaNameBaseOnUnitName(UNIT);
             }

             catch { return new DataTable(); }
         }
         public DataTable getUnitName()
         {
             try
             {

                 DataTableUnitTableAdapter bll = new DataTableUnitTableAdapter();
                 return bll.taGetUnitList();
             }
             catch { return new DataTable(); }
         }
         public DataTable getAttachmentWithCategory(int unit, DateTime dtformdate, DateTime dtTodate, int Enrol, int AttachmentTypeid)
         {
             SprRmtRptAttachmentDetTableAdapter bll = new SprRmtRptAttachmentDetTableAdapter();
             try
             {
                 return bll.tasprRmtRptAttachmentDet(unit, dtformdate, dtTodate, Enrol, AttachmentTypeid);
             }
             catch
             {
                 return new DataTable();
             }
         }


         #endregion


         #region  -------- Employee with enrol ----------
         public DataTable getNoEmailEmployeelist(string enrol, string prefix)
         {
             DataTableNoEmaiEmployeelistTableAdapter bll = new DataTableNoEmaiEmployeelistTableAdapter();
             DataTable dt = new DataTable();
             dt = bll.taNoEmailEmployeeList(int.Parse(enrol), prefix);
             return bll.taNoEmailEmployeeList(int.Parse(enrol), prefix);

         }
         #endregion

         #region  -------------- Geta applicantlist with Code  ---------------
         public DataTable getApplicantListForApproveBillGBwithCode(string enrol, string prefix)
         {

             DataTableEmployeeNameCodeTableAdapter bllApplicantList = new DataTableEmployeeNameCodeTableAdapter();
             DataTable dt = new DataTable();
             dt = bllApplicantList.taEmployeeNamewithcode(int.Parse(enrol), prefix);
             return bllApplicantList.taEmployeeNamewithcode(int.Parse(enrol), prefix);

         }

         public DataTable getSupervisorNameForUpdate(string intJobsid, string perf)
         {
             TblTADASupervisorSearchTableAdapter bllsupervisorlist = new TblTADASupervisorSearchTableAdapter();
             DataTable dt = new DataTable();
             dt = bllsupervisorlist.taSearchSupervisorName(int.Parse(intJobsid), perf);
             return bllsupervisorlist.taSearchSupervisorName(int.Parse(intJobsid), perf);
         }



         #endregion

         #region  -------------- TA DA INSERTION FOR NO EMAIL ADDRESS EMPLOYEE   ---------------


         public string tadaInsertByApplicantNoEmailid(string xmlString, DateTime dteFromDate, DateTime dtToDate, int insertby, int ApplicantCatg, int unit, int jobstation)
         {
             string msg = "";

             try
             {
                 SprRmtInsTADAforNoOfficialEmailEmployeeTableAdapter blltadaInsertByApplicantNoneCarUser = new SprRmtInsTADAforNoOfficialEmailEmployeeTableAdapter();
                 blltadaInsertByApplicantNoneCarUser.tasprRmtInsTADAforNoOfficialEmailEmployee(xmlString, dteFromDate, dtToDate, insertby, ApplicantCatg, unit, jobstation, ref msg);

                 return msg;
             }

             catch (Exception ex) { return ex.ToString(); }
         }


         #endregion

         #region  -------------- TA DA Report TYpe   ---------------
         public DataTable getReportType()
         {

             tblRemoteTADAReportTypeTableAdapter bllreptype = new tblRemoteTADAReportTypeTableAdapter();
             return bllreptype.taRemoteTaDaReportType();

         }





         #endregion

         #region  -------------Employee Vs Area permission for TA DA Entry-------------
         public DataTable getEmployeeVsAraPermission(string enrol)
         {
             try
             {
                 DataTableEmployeeVsAreaPermissionTableAdapter bll = new DataTableEmployeeVsAreaPermissionTableAdapter();
                 return bll.taEmployeeVsAreaId(int.Parse(enrol));
             }
             catch { return new DataTable(); }
         }

         #endregion
         #region  -------------TA DA REPORT FOR NO OFFICE EMAIL EMPLOYEE-------------

         public DataTable getReportForNoEmailAddressEmployee(DateTime dtfromdate, DateTime dtTodate, int Area, int unit, int ReporType, int enrol)
         {
             try
             {
                 SprRptRmtTADAForNoOficeEmailEmployeeTableAdapter bll = new SprRptRmtTADAForNoOficeEmailEmployeeTableAdapter();
                 return bll.tasprRptRmtTADAForNoOficeEmailEmployee(dtfromdate, dtTodate, Area, unit, ReporType, enrol);

             }
             catch { return new DataTable(); }

         }

         #endregion

         #region  -------------TA DA REPORT FOR ANALYSIS IN AUDIT-------------
         public DataTable getNoneCategoryuserlist()
         {
             try
             {
                 tblRemoteTADANoneCategoryUserTableAdapter bll = new tblRemoteTADANoneCategoryUserTableAdapter();
                 return bll.taNoneCategoryUserList();
             }
             catch { return new DataTable(); }
         }
         public DataTable getAnalysticalReportTADA(DateTime dtfromdate, DateTime dtTodate, int unit, int ReporType)
         {
             try
             {
                 SprRptTADAAnalyticalForAuditTableAdapter bll = new SprRptTADAAnalyticalForAuditTableAdapter();
                 return bll.tasprRptTADAAnalyticalForAudit(dtfromdate, dtTodate, unit, ReporType);

             }
             catch { return new DataTable(); }


         }



         #endregion

         public DataTable getTADAAdvanceSingleIDBase(int intAutoID)
         {
             try
             {
                 SprTADAAdvancePendingByidTableAdapter bll = new SprTADAAdvancePendingByidTableAdapter();
                 return bll.tasprTADAAdvancePendingByid(intAutoID);

             }
             catch (Exception ex) { return new DataTable(); }


         }
         public string TADAAdvanceApprovebySupervisor(int applicationId, int ApplicnatEnrol, DateTime fromdateApprove, DateTime todateApprove, Decimal ApproveAmountBySupervisor, int actionBy, string approveStatus)
         {
             string rtnMessage = "";
             try
             {
                 SprTADATourAdvanceApproveBySupervisorTableAdapter ta = new SprTADATourAdvanceApproveBySupervisorTableAdapter();
                 ta.tasprTADATourAdvanceApproveBySupervisor(applicationId, ApplicnatEnrol, fromdateApprove, todateApprove, ApproveAmountBySupervisor, actionBy, approveStatus, ref rtnMessage);
             }
             catch (Exception ex) { rtnMessage = "0"; }
             return rtnMessage;
         }

         public DataTable getTADAPendingAdvanceStatus(int Supervisorid)
         {
             try
             {
                 SprTADAAdvancePendingStatusTableAdapter bll = new SprTADAAdvancePendingStatusTableAdapter();
                 return bll.tasprTADAAdvancePendingStatus(Supervisorid);

             }
             catch (Exception ex) { return new DataTable(); }


         }

         public DataTable getTADAAdvanceForAccountDeptAprv()
         {
             try
             {
                 SprTADAAdvancePendingForAccountDeptTableAdapter bll = new SprTADAAdvancePendingForAccountDeptTableAdapter();
                 return bll.tasprTADAAdvancePendingForAccountDept();

             }
             catch (Exception ex) { return new DataTable(); }


         }
         public DataTable getTADAAdvanceSingleIDBaseForAccountDept(int intAutoID)
         {
             try
             {
                 SprTADAAdvancePendingByidForAccountDeptTableAdapter bll = new SprTADAAdvancePendingByidForAccountDeptTableAdapter();
                 return bll.tasprTADAAdvancePendingByidForAccountDept(intAutoID);

             }
             catch (Exception ex) { return new DataTable(); }


         }
         public string TADAAdvanceApprovebyAccountDept(int applicationId, int ApplicnatEnrol, Decimal ApproveAmountByAccount, int actionBy, DateTime tourStartdate)
         {
             string rtnMessage = "";
             try
             {
                 SprTADAAdvanceAprvInsByAccountTableAdapter ta = new SprTADAAdvanceAprvInsByAccountTableAdapter();
                 ta.tasprTADAAdvanceAprvInsByAccount(applicationId, ApplicnatEnrol, ApproveAmountByAccount, actionBy, tourStartdate, ref rtnMessage);
             }
             catch (Exception ex) { rtnMessage = "0"; }
             return rtnMessage;
         }

         public DataTable getACCLGhatStock(DateTime dtfromdate, DateTime dtTodate, int shippingpointid, int productid)
         {
             try
             {
                 // SprACCLGHATSTOCKTableAdapter bll = new SprACCLGHATSTOCKTableAdapter();
                 SprACCLShippingpointStockTableAdapter bll = new SprACCLShippingpointStockTableAdapter();
                 return bll.tasprACCLShippingpointStock(dtfromdate, dtTodate, shippingpointid, productid);


             }
             catch { return new DataTable(); }

         }

         public DataTable getShippingPoint(string officeemail)
         {
             try
             {
                 tblShippingPointListTableAdapter bll = new tblShippingPointListTableAdapter();
                 return bll.taShippingPointList(officeemail);
             }

             catch { return new DataTable(); }

         }

         public DataTable getProductList()
         {
             try
             {
                 tblProductNameTableAdapter bll = new tblProductNameTableAdapter();
                 return bll.taProductList();
             }

             catch { return new DataTable(); }

         }

     

         public DataTable getGhatDeportDeliveryReceiveStatus(DateTime dtFromDate, DateTime dtTodate, int shippingpoint, int unit, int Productid)
         {
             try
             {
                 SprACCLGhatDeliveryReciveTableAdapter bll = new SprACCLGhatDeliveryReciveTableAdapter();
                 return bll.tasprACCLGhatDeliveryRecive(dtFromDate, dtTodate, shippingpoint, unit, Productid);

             }
             catch { return new DataTable(); }
         }

         public List<string> AutoSearchEmployeesDataTADA(int intLoginId, int intJobStationId, string strSearchKey)
         {
             List<string> result = new List<string>();
             SprEmployeeSearchByJobstationBaseTableAdapter objSprAutoSearchEmployeeFilterByJobStationTableAdapter = new SprEmployeeSearchByJobstationBaseTableAdapter();
             DataTable oDT = new DataTable();
             oDT = objSprAutoSearchEmployeeFilterByJobStationTableAdapter.tasprEmployeeSearchByJobstationBase(intLoginId, intJobStationId, strSearchKey);
             if (oDT.Rows.Count > 0)
             {
                 for (int index = 0; index < oDT.Rows.Count; index++)
                 {
                     result.Add(oDT.Rows[index]["Emplname"].ToString());
                 }

             }
             return result;
         }

         public DataTable TransferChallReceivestatusUpdate(int unit, int seID, Boolean ysnTransit)
         {

             try
             {
                 SprACCLTransitStatusUpdateTableAdapter transupdate = new SprACCLTransitStatusUpdateTableAdapter();
                 return transupdate.tasprACCLTransitStatusUpdate(unit, seID, ysnTransit);


             }
             catch
             {
                 return new DataTable();

             }

         }

         public DataTable getEmployeeBasicInfo(DateTime dtform, DateTime dtTodate, int unit, int ReportType, int Enrolaplicant)
         {
             DataTable dt = new DataTable();
             try
             {

                 SprACCLTADASingleEmployeeTopsheetTableAdapter bll = new SprACCLTADASingleEmployeeTopsheetTableAdapter();
                 dt = bll.tasprACCLTADASingleEmployeeTopsheet(dtform, dtTodate, unit, ReportType, Enrolaplicant);
                 return bll.tasprACCLTADASingleEmployeeTopsheet(dtform, dtTodate, unit, ReportType, Enrolaplicant);

             }

             catch { return new DataTable(); }
         }
         public string taDaAdanceInsertbyApplicant(string xmlString, DateTime dteFromDate, DateTime dtToDate, int Enrol, int unit, int jobstation,int insertbyenrol)
         {
             string msg = "";

             try
             {
                 SprTADATourAdvanceInsertionbyApplicantTableAdapter blltadaInsertByApplicantNoneCarUser = new SprTADATourAdvanceInsertionbyApplicantTableAdapter();
                 blltadaInsertByApplicantNoneCarUser.tasprTADATourAdvanceInsertionbyApplicant(xmlString, dteFromDate, dtToDate, Enrol, unit, jobstation, insertbyenrol, ref msg);

                 return msg;
             }

             catch (Exception ex) { return ex.ToString(); }
         }

         public DataTable getsprTADABillStatusForAllunits(DateTime fromdate, DateTime todate, int unitid, int Reporttype, int Areaid)
         {
             try
             {
                 SprTADABillStatusForAllunitsTableAdapter bll = new SprTADABillStatusForAllunitsTableAdapter();
                 return bll.tasprTADABillStatusForAllunits(fromdate, todate, unitid, Reporttype, Areaid);

             }
             catch (Exception ex) { return new DataTable(); }


         }

         public string tadaInsertByAuditFromTopsheetV2(string xmlString, int ApproverEnrol, DateTime dteFromDate, DateTime dtToDate, int ApplicantCatg, int Unit, int Area)
         {
             string msg = "";
             try
             {
                 SprAuditApproveFromTopsheetV2TableAdapter bllBikeInsHR = new SprAuditApproveFromTopsheetV2TableAdapter();
                 bllBikeInsHR.tasprAuditApproveFromTopsheetV2(xmlString, ApproverEnrol, dteFromDate, dtToDate, ApplicantCatg, Unit, Area, ref msg);
                 return msg;

             }

             catch (Exception ex) { return ex.ToString(); }

         }



         public string tadaInsertByHRTESTING(string xmlString, int ApproverEnrol, DateTime dteFromDate, DateTime dtToDate, int ApplicantCatg)
         {
             string msg = "";
             try
             {
                 SprAproveNoneCarByHRTESTINGTableAdapter bllNoneBikeInsHR = new SprAproveNoneCarByHRTESTINGTableAdapter();
                 bllNoneBikeInsHR.tasprAproveNoneCarByHR(xmlString, ApproverEnrol, dteFromDate, dtToDate, ApplicantCatg, ref msg);
                 return msg;

             }

             catch (Exception ex) { return ex.ToString(); }

         }
         public DataTable getStandVhDetaills()
         {
             try
             {
                 SprStandbyVhechileDetaillsTableAdapter bll = new SprStandbyVhechileDetaillsTableAdapter();
                 return bll.tasprStandbyVhechileDetaills();

             }
             catch (Exception ex) { return new DataTable(); }


         }

         public string tadaInsertByStandByVheicle(string xmlString, DateTime dteFromDate, int insertby, int unit, int jobstation, int ApplicantCatg)
         {
             string msg = "";
             try
             {
                 SprTADAStandVheicleInfoInsertByApplicantTableAdapter bllTadaInsertByBikeAndCarUser = new SprTADAStandVheicleInfoInsertByApplicantTableAdapter();
                 bllTadaInsertByBikeAndCarUser.tasprTADAStandVheicleInfoInsertByApplicant(xmlString, dteFromDate, insertby, unit, jobstation, ApplicantCatg, ref msg);
                 return msg;

             }

             catch (Exception ex) { return ex.ToString(); }

         }

         public DataTable getStandByVheicleCostDetaills(DateTime dtFromDate, DateTime dtToDate, int Enrol, int Unit)
         {
             try
             {
                 SprStandByVheicleDailyCostAnalysisTableAdapter bll = new SprStandByVheicleDailyCostAnalysisTableAdapter();
                 return bll.tasprStandByVheicleDailyCostAnalysis(dtFromDate, dtToDate, Enrol, Unit);

             }
             catch (Exception ex)
             {

                 return new DataTable();
             }
         }

         public DataTable getTADAApplicantInfoForApproveBySuperVisorV2(DateTime dtFromDate, DateTime dtToDate, int supervisorEnrol)
         {
             try
             {
                 SprTADAApproveByImmediateSuperVisorTableAdapter bll = new SprTADAApproveByImmediateSuperVisorTableAdapter();
                 return bll.tasprTADAApproveByImmediateSuperVisor(dtFromDate, dtToDate, supervisorEnrol);

             }
             catch (Exception ex)
             {

                 return new DataTable();
             }
         }
        
         public DataTable getHRunitPermissionforTADA(int Enrol)
         {

             try
             {
                 tblHRVsUnitPermissionTableAdapter bll = new tblHRVsUnitPermissionTableAdapter();
                 return bll.taEmployeeVsUnitPermission(Enrol);
             }
             catch { return new DataTable(); }



         }

         public DataTable getHRunitvsAreaPermissionforTADA(int Enrol, int unitid)
         {

             try
             {
                 tblHRUnitVsAreaPermissionTableAdapter bll = new tblHRUnitVsAreaPermissionTableAdapter();
                 return bll.taHRUnitVsAreaPermission(Enrol, unitid);
             }
             catch { return new DataTable(); }



         }

         public DataTable getTADAApplicantDataForUpdate(DateTime dtFormDate, DateTime dtTodate, int enrol)
         {
             SprTADAGetAplicantDataForUpdateTableAdapter bllRptTADAForBikeAndCarUser = new SprTADAGetAplicantDataForUpdateTableAdapter();
             try
             {

                 return bllRptTADAForBikeAndCarUser.tasprTADAGetAplicantDataForUpdate(dtFormDate, dtTodate, enrol);
             }

             catch
             {
                 return new DataTable();

             }

         }



         public string updateRemoteTADAInfo(int intId, int intEnrol,
 DateTime dtForm, decimal StartMilage, decimal EndMilage, decimal ConsumedKM, string strRemarks,
 decimal QntPetrol, decimal CostPetrol, decimal QntOcten, decimal CostOcten, decimal QntCarBonNitr
 , decimal CostCarbonNit, decimal QntLubricant, decimal CostLubricant, decimal BusFareTaka,
 decimal RickFare, decimal CNGFare, decimal OtherVhFare, decimal MntCost, decimal FerryTol, decimal OwnDA
 , decimal OtherDA, decimal OwnHotel, decimal DriverHotel, decimal Photocopy, decimal Courier, decimal OtherCost, decimal RowTotal, decimal intRowsl, int paymenttype
 , int intCNGCredit1Stationid, decimal cngcredit1Amount, string cngcredit1stationname, int intCNGCredit2Stationid, decimal cngcredit2Amount, string cngcredit2stationname
 , int oilCreditStationid, decimal oilCreditAmount, string oilCreditstationname
 , decimal personalMilageuseQnt, decimal personalUseMilagRate, decimal personalUseTotalCOST, int intUpdatBy)
         {

             SprUpdateTADAInfoTableAdapter bll = new SprUpdateTADAInfoTableAdapter();
             string rtnMessage = "";
             try
             {
                 bll.tasprUpdateTADAInfo(intId, intEnrol, dtForm, StartMilage, EndMilage, ConsumedKM, strRemarks,
                 QntPetrol, CostPetrol, QntOcten, CostOcten, QntCarBonNitr
                 , CostCarbonNit, QntLubricant, CostLubricant, BusFareTaka,
                 RickFare, CNGFare, OtherVhFare, MntCost, FerryTol, OwnDA
                 , OtherDA, OwnHotel, DriverHotel, Photocopy, Courier, OtherCost, RowTotal, intRowsl, paymenttype
                 , intCNGCredit1Stationid, cngcredit1Amount, cngcredit1stationname, intCNGCredit2Stationid, cngcredit2Amount, cngcredit2stationname,
                 oilCreditStationid, oilCreditAmount, oilCreditstationname
                 , personalMilageuseQnt, personalUseMilagRate, personalUseTotalCOST, intUpdatBy, ref rtnMessage);

             }
             catch (Exception ex) { rtnMessage = ex.ToString(); }
             {
                 return rtnMessage;
             }

         }



         public DataTable getTADARptforSUpervisorAproveV2(DateTime dtFromDate, DateTime dtTodate, int enrol)
         {
             SprRmtTADAInsByImmediateSupvV2TableAdapter bllRptRmtTADABikeCarDetaills = new SprRmtTADAInsByImmediateSupvV2TableAdapter();
             try
             {
                 return bllRptRmtTADABikeCarDetaills.tasprRmtTADAInsByImmediateSupvV2(dtFromDate, dtTodate, enrol);
             }

             catch
             {
                 return new DataTable();
             }

         }
         public DataTable getTADABasicInfo(DateTime dtform, DateTime dtTodate, int Enrolaplicant)
         {
             DataTable dt = new DataTable();
             try
             {

                 SprBasicInfoTADATableAdapter bll = new SprBasicInfoTADATableAdapter();
                 dt = bll.tasprBasicInfoTADA(dtform, dtTodate, Enrolaplicant);
                 return bll.tasprBasicInfoTADA(dtform, dtTodate, Enrolaplicant);

             }

             catch { return new DataTable(); }
         }

         public DataTable getOwnbilApproveStatus(DateTime dtfromdate, DateTime dtTodate, int unit, int employeeid)
         {
             try
             {

                 SprOwnBillApproveStatusCheckingTableAdapter bll = new SprOwnBillApproveStatusCheckingTableAdapter();
                 return bll.tasprOwnBillApproveStatusChecking(dtfromdate, dtTodate, unit, employeeid);


             }
             catch { return new DataTable(); }

         }
         public string tadaInsertByAnotherUserForBikeAndCarUser(string xmlString, DateTime dteFromDate, int Enrol, int ApplicantCatg, int unit, int jobstation,int InsertbyEnrol)
         {
             string msg = "";
             try
             {
                 SprRmtInsBikeUserTADAAGblInfoByAnotherUserTableAdapter bllTadaInsertByBikeAndCarUser = new SprRmtInsBikeUserTADAAGblInfoByAnotherUserTableAdapter();
                 bllTadaInsertByBikeAndCarUser.tasprRmtInsBikeUserTADAAGblInfoByAnotherUser(xmlString, dteFromDate, Enrol, ApplicantCatg, unit, jobstation,InsertbyEnrol, ref msg);
                 return msg;

             }

             catch (Exception ex) { return ex.ToString(); }

         }
         public DataTable getTADAAreaTopsheet(DateTime dtformdate, DateTime dtTodate, int Areaid, int Unitid, int ReportType)
         {
             try
             {

                 SprTADAAreaTopSheetTableAdapter hrPrint = new SprTADAAreaTopSheetTableAdapter();
                 return hrPrint.tasprTADAAreaTopSheet(dtformdate, dtTodate, Areaid, Unitid, ReportType);
             }
             catch { return new DataTable(); }
         }

         public DataTable getDataForCreateVoucherForTADAAdvance(DateTime dtformdate, DateTime dtTodate, int Unitid, int bantkid)
         {
             try
             {

                 SprPrefareVoucherForTADAAdvanceTableAdapter TADAAdvPrepareVoucher = new SprPrefareVoucherForTADAAdvanceTableAdapter();
                 return TADAAdvPrepareVoucher.tasprPrefareVoucherForTADAAdvance(dtformdate, dtTodate, Unitid, bantkid);
             }
             catch { return new DataTable(); }
         }

         public string InsertTADAAdvanceVoucher(int intApplicationID, string strPayTo, int intModeOfPayment, decimal monAmount, int intUser, DateTime dteInstrumentDate, DateTime strDate, int insertby, string strDetaills)
         {
             try
             {
                 string msg = "";
                 SprTADAAdvanceVoucherPrepareTableAdapter adp = new SprTADAAdvanceVoucherPrepareTableAdapter();
                 adp.objsprTADAAdvanceVoucherPrepare(intApplicationID, strPayTo, intModeOfPayment, monAmount, intUser, dteInstrumentDate, strDate, insertby, strDetaills, ref msg);
                 return msg;
             }
             catch (Exception ex)
             {

                 return ex.ToString();
             }


         }

         public DataTable getTADAAdvanceDetaills(DateTime dtformdate, DateTime dtTodate, int Unitid, int reporttype)
         {
             try
             {

                 SprTADAAdvanceDetaillsTableAdapter TADAAdvPrepareVoucher = new SprTADAAdvanceDetaillsTableAdapter();
                 return TADAAdvPrepareVoucher.tasprTADAAdvanceDetaills(dtformdate, dtTodate, Unitid, reporttype);
             }
             catch { return new DataTable(); }

         }
         public DataTable getAccountDeptTADAReportType()
         {
             try
             {
                 tblAccountDeptReportTypeTableAdapter bll = new tblAccountDeptReportTypeTableAdapter();
                 return bll.GetDataAccountsDeptReportType();
             }

             catch
             {
                 return new DataTable();
             }

         }


         public DataTable getRptTADABikeAndCarUserAuditlebel(DateTime dtFrom, DateTime dtTo, int ApplicantEnrol, int Reporttype)
         {

             SprRptRmtTADAOnlyBikeAndCarUserbyAuditTableAdapter bll = new SprRptRmtTADAOnlyBikeAndCarUserbyAuditTableAdapter();
             try
             {
                 return bll.tasprRptRmtTADAOnlyBikeAndCarUserbyAudit(dtFrom, dtTo, ApplicantEnrol, Reporttype);

             }
             catch
             {
                 return new DataTable();
             }
         }


         public DataTable getTADAReportForAuditChkVerson2(DateTime dtFromDate, DateTime dtTodate, int unit, int ReportType, int Areaid, int ApplicantCatg)
         {
             try
             {
                 SprTADRptForAuditChekingTopsheetTableAdapter bll = new SprTADRptForAuditChekingTopsheetTableAdapter();
                 return bll.tasprTADRptForAuditChekingTopsheet(dtFromDate, dtTodate, unit, ReportType, Areaid, ApplicantCatg);

             }
             catch { return new DataTable(); }
         }

         public DataTable getTADASuperviorinfUpdateData(int unit,int jobstation,int ReportType,int EmployeeEnrol,int insertby,int supervisorenrol)
         {
             try
             {
                 SprUpdateTADASperviorNameTableAdapter bll = new SprUpdateTADASperviorNameTableAdapter();
                 return bll.tasprUpdateTADASperviorName(unit, jobstation, ReportType, EmployeeEnrol, insertby, supervisorenrol);

             }
             catch { return new DataTable(); }
         }


       public DataTable UpdateTADASupervisor(int emplenrol,int supervisorenrol,int jobstationid,int insertby,int idofpermtbl,int typeid)
         {
             try
             {
                 SprTADASupervisorUpdatebyUserTableAdapter bll = new SprTADASupervisorUpdatebyUserTableAdapter();
                 return bll.tasprTADASupervisorUpdatebyUser(emplenrol, supervisorenrol, jobstationid, insertby, idofpermtbl, typeid);

             }
             catch { return new DataTable(); }

         }

        public DataTable getUnitPermission(int Enrol)
       {
           try{SprGetEmpPermissionUnitTableAdapter bll = new SprGetEmpPermissionUnitTableAdapter(); return bll.tasprGetEmpPermissionUnit(Enrol); }
           catch{ return new DataTable();}

       }

        public DataTable getJobstationbasedonUnit(int Unitid)
        {
            try { SprGetJobStationTableAdapter bll = new SprGetJobStationTableAdapter(); return bll.tasprGetJobStation(Unitid); }
            catch { return new DataTable(); }
        }
        public DataTable getTADAFuelStationlistforUpdate(int unit)
        {
            try
            {
                tblRemoteTADAFuelStationList1TableAdapter bll = new tblRemoteTADAFuelStationList1TableAdapter();
                return bll.taFuelstationForUpdateinfo(unit);

            }
            catch { return new DataTable(); }
        }

        public DataTable getRptStandVheicleDateBasis(DateTime dtfromdate,DateTime dtTodate,int Enrol,int ReportType)
        {
            try
            {
                SprRptForSTANDVheicleTableAdapter bll = new SprRptForSTANDVheicleTableAdapter();
                return bll.tasprRptForSTANDVheicle(dtfromdate, dtTodate, Enrol, ReportType);

            }
            catch { return new DataTable(); }
        }

        public DataTable getRptCreditStationCNGBill(DateTime dtFromDate,DateTime dteTodate ,int Enrol, int Jobstationid,int Unit,int FuelStationid)
        {
            try
            {
                SprTADACreditStationBillTableAdapter bll = new SprTADACreditStationBillTableAdapter();
                return bll.tasprTADACreditStationBill(dtFromDate, dteTodate, Enrol, Jobstationid, Unit, FuelStationid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getRptCreditStationVSEmployee(DateTime dtFromDate, DateTime dteTodate, int Jobstationid, int Unit, int ReportType)
        {
            try
            {
                SprTADACreditStationBillEmployeebasisTableAdapter bll = new SprTADACreditStationBillEmployeebasisTableAdapter();
                return bll.tasprTADACreditStationBillEmployeebasis(dtFromDate, dteTodate, Jobstationid, Unit, ReportType);
            }
            catch { return new DataTable(); }
        }


        public DataTable getRptTADACostAnalysis(DateTime dtFromDate, DateTime dteTodate, int Unit, int ReportType,int Areaid )
        {
            try
            {
                SprRptTADACostAnalysisTableAdapter bll = new SprRptTADACostAnalysisTableAdapter();
                return bll.tasprRptTADACostAnalysis(dtFromDate, dteTodate, Unit, ReportType, Areaid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getRptPaytocompany(DateTime dtFromDate, DateTime dteTodate, int ReportType, int Unit,int Employeeid )
        {
            try
            {
                SprAllUnitTADAAtaGlanceeTableAdapter bll = new SprAllUnitTADAAtaGlanceeTableAdapter();
                return bll.tasprAllUnitTADAAtaGlancee(dtFromDate, dteTodate, ReportType, Unit, Employeeid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getRptTADAAdvanceAprvStatus(int AplEnrol, int Jobstation, int Unit, int ReportType, DateTime dtFromDate, DateTime dteTodate)
        {
            try
            {
                SprTADAAdvanceAprvStatusTableAdapter bll = new SprTADAAdvanceAprvStatusTableAdapter();
                return bll.tasprTADAAdvanceAprvStatus(AplEnrol, Jobstation, Unit, ReportType, dtFromDate, dteTodate);
            }
            catch { return new DataTable(); }
        }

        public DataTable getRptLastTransactionDateAndLastDelvDate(DateTime dtFromDate, int limitday, int salesofficeid, int unit)
        {
            try
            {
                SprLastDayofTransactionAndDelvTableAdapter bll = new SprLastDayofTransactionAndDelvTableAdapter();
                return bll.tasprLastDayofTransactionAndDelv(dtFromDate, limitday, salesofficeid, unit);
            }
            catch { return new DataTable(); }
        }

        public DataTable getSalesofficeList(int unit)
        {
            try
            {
                TblSalesOfficeTableAdapter bll = new TblSalesOfficeTableAdapter();
                return bll.taSalesofficeList(unit);
            }
            catch { return new DataTable(); }
        }
        public DataTable getCreditLimitDayslist(int salesoffid)
        {
            try
            {
                TblCustomerCreditLimitDayTableAdapter bll = new TblCustomerCreditLimitDayTableAdapter();
                return bll.taCreditInDays(salesoffid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getDelvOrderSummerReports(int reporttype,int unitdid,DateTime dtefromdate,DateTime dttodate)
        {
            try
            {
                SprDOSummeryReportsTableAdapter bll = new SprDOSummeryReportsTableAdapter();
                return bll.tasprDOSummeryReports(reporttype, unitdid, dtefromdate, dttodate);
            }
            catch { return new DataTable(); }
        }

        public DataTable getDataforTADAInfoDelete( DateTime dtefromdate, string  employeecode,int ApproveStatus,int intPkid ,int intInactiveby )
        {
            try
            {
                SprTADABillActiveInactiveTableAdapter bll = new SprTADABillActiveInactiveTableAdapter();
                return bll.tasprTADABillActiveInactive(dtefromdate, employeecode, ApproveStatus, intPkid, intInactiveby);
            }
            catch { return new DataTable(); }
        }

        public void getTADAAttachinsertion(string strcontent, decimal size, string url, int enrol, int unit, DateTime dtbilldate, int attachtype, int jobstation, int partno)
        {
            SprRmtInsAttachmentDetaillsTableAdapter approvalsubmit = new SprRmtInsAttachmentDetaillsTableAdapter();
            approvalsubmit.tasprRmtInsAttachmentDetaills(strcontent,  size,  url,  enrol,  unit,  dtbilldate,  attachtype,  jobstation,  partno);

        }

        public DataTable getAreafromUnit(int unitid)
        {

            try
            {
                TblAreafromUnitTableAdapter bll = new TblAreafromUnitTableAdapter();
                return bll.taAreapermissionfromunint( unitid);
            }
            catch { return new DataTable(); }



        }

        public DataTable getTADAHRApproveMonitoringData(DateTime fromdate, DateTime todate, int employeeid, int unitid,int reporttype,int rptid)
        {
            try
            {
                SprTADAHRApproveMonitoringTableAdapter bll = new SprTADAHRApproveMonitoringTableAdapter();
                return bll.tasprTADAHRApproveMonitoring(fromdate, todate, employeeid, unitid, reporttype, rptid);

            }
            catch { return new DataTable(); }
        }

        public DataTable insertTADASupervisor(int emplenrol, int supervisorenrol, int jobstationid, int insertby, int idofpermtbl, int typeid)
        {
            try
            {
                SprTADASupervisorUpdatebyUserTableAdapter bll = new SprTADASupervisorUpdatebyUserTableAdapter();
                return bll.tasprTADASupervisorUpdatebyUser(emplenrol, supervisorenrol, jobstationid, insertby, idofpermtbl, typeid);

            }
            catch { return new DataTable(); }

        }
       
        public string InsertTADABPVoucher( DateTime dtefromdate, DateTime toDate, int insertby, int bankid, DateTime dteInstrumentDate, int unitid, decimal totalamount,int travelconveycoaid,decimal totaladvanceamnt)
        {
            try
            {
                string msg = "";
                SprTADABPVoucherPrepareTableAdapter adp = new SprTADABPVoucherPrepareTableAdapter();
                adp.GetDataForTADABPVoucherPrepare( dtefromdate,  toDate, insertby,  bankid,  dteInstrumentDate,    unitid, totalamount,travelconveycoaid,totaladvanceamnt, ref msg);
                return msg;
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }


        }
        public DataTable BankNameList()
        {
            try
            {
                TblBankNameListTableAdapter bll = new TblBankNameListTableAdapter();
                return bll.GetDataBankNameList();

            }
            catch { return new DataTable(); }

        }

        public DataTable travellingandconvey(int unitid)
        {
            try
            {
                SprTravelConveyCOANameTableAdapter bll = new SprTravelConveyCOANameTableAdapter();
                return bll.GetDataTravelConveyCOAName(unitid);


            }
            catch { return new DataTable(); }

        }
        public DataTable getrptforjvandbp(DateTime dtFromDate, DateTime dteTodate, int ReportType, int Unit, int travelconveyCOAidreference)
        {
            try
            {
                SprTADAReportJournalAndBankVoucherDetTableAdapter bll = new SprTADAReportJournalAndBankVoucherDetTableAdapter();
                return bll.GetDataTADAReportJournalAndBankVoucherDet(dtFromDate, dteTodate, ReportType, Unit, travelconveyCOAidreference);
            }
            catch { return new DataTable(); }
        }

        public List<string> getemployeebaseTADASupervisor(int intLoginId, string strSearchKey)
        {
            List<string> result = new List<string>();
            SprAutoserchEmployeebaseTADASupervisorTableAdapter ojbEmployeebaseonsupvisor = new SprAutoserchEmployeebaseTADASupervisorTableAdapter();
            DataTable oDT = new DataTable();
            oDT = ojbEmployeebaseonsupvisor.GetDataAutoserchEmployeebaseTADASupervisor(intLoginId, strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["Emplname"].ToString());
                }

            }
            return result;
        }

   

        public DataTable getrptforTADACreditstation(DateTime dteFromDate, DateTime dteTodate, int intJobstationid, int intUnitid, int intReportType, int intareid, int intFuelstationid, int intenrol)
        {
            try
            {
                SprRemoteTADAFuelstationCreditAmountTableAdapter bll = new SprRemoteTADAFuelstationCreditAmountTableAdapter();
                return bll.GetDataRemoteTADAFuelstationCreditAmount(dteFromDate, dteTodate, intJobstationid, intUnitid, intReportType, intareid, intFuelstationid, intenrol);
            }
            catch { return new DataTable(); }
        }


        public List<string> getemployeewithCOAID(int unitid, string strSearchKey)
        {
            List<string> result = new List<string>();
            SprAutoSearchEmplforCOATableAdapter ojbEmployeewithcoa = new SprAutoSearchEmplforCOATableAdapter();
            DataTable oDT = new DataTable();
            oDT = ojbEmployeewithcoa.GetDatasprAutoSearchEmplforCOA(unitid, strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strAccName"].ToString());
                }

            }
            return result;
        }

        public void getRmtEmplEnrolvsCOAID(int intEnrol, int intEmployeeCoAId, int intUnit, int intInsertBy, int intPart)
        {
            SprRmtInsEmplEnrolvsCOAIDTableAdapter approvalsubmit = new SprRmtInsEmplEnrolvsCOAIDTableAdapter();
            approvalsubmit.GetDataRmtInsEmplEnrolvsCOAID(intEnrol, intEmployeeCoAId, intUnit, intInsertBy, intPart);

        }

        public DataTable getdataforDOPrint(string donumber)
        {
            try
            {
                SprDelvOrderPrintTableAdapter bll = new SprDelvOrderPrintTableAdapter();
                return bll.GetDataDelvOrderPrint(donumber);
            }
            catch { return new DataTable(); }
        }

        public DataTable getdataFactoryAddressDet(int unitid)
        {
            try
            {
                SprFactoryAddressDetaillsTableAdapter bll = new SprFactoryAddressDetaillsTableAdapter();
                return bll.GetDataFactoryAddressDetaills(unitid);
            }
            catch { return new DataTable(); }
        }
        public DataTable getdataDeliverayOrderInactiveforRemaningQnt(int unitid,string delvordernumber,int level, int insertby,int pointid)
        {
            try
            {
                SprDeliveryOrderCancelForRestofQuantityTableAdapter bll = new SprDeliveryOrderCancelForRestofQuantityTableAdapter();
                return bll.GetDatasprDeliveryOrderCancelForRestofQuantity(unitid, delvordernumber, level, insertby, pointid);
            }
            catch { return new DataTable(); }
        }
      

        public DataTable getdataRetaillshopMonthlySalesAndTarget(string email, DateTime dtfromdate, DateTime dttodate, int reportoption,int customerCOAId, string xmlString)
        {
            try
            {
                SprRetaillTargetMonthlyTableAdapter bll = new SprRetaillTargetMonthlyTableAdapter();
                return bll.GetDatasprRetaillTargetMonthly(email,  dtfromdate,  dttodate,  reportoption,  customerCOAId, xmlString);
            }
            catch { return new DataTable(); }
        }

        public DataTable getdataSalesCommissionReportType()
        {
            try
            {
                TblSalesComReportTypeTableAdapter bll = new TblSalesComReportTypeTableAdapter();
                return bll.GetDataSalesCommissionReportType();
            }
            catch { return new DataTable(); }
        }

        public DataTable getdataCashDOCommissionjv( DateTime dtfromdate, DateTime dttodate, string salesoficelike, string reptname)
        {
            try
            {
                SprACCCashDOCommissionTableAdapter bll = new SprACCCashDOCommissionTableAdapter();
                return bll.GetDatasprACCCashDOCommission(dtfromdate, dttodate, salesoficelike, reptname);
            }
            catch { return new DataTable(); }
        }

        public DataTable getdataSalesCommissionCOAHead()
        {
            try
            {
                TblSalesCommCOATableAdapter bll = new TblSalesCommCOATableAdapter();
                return bll.GetDataSalesCommissionCOA();
            }
            catch { return new DataTable(); }
        }

        public DataTable getdataBrandMktProgramName(int unitid)
        {
            try
            {
                TblBrandMktProgramNameTableAdapter bll = new TblBrandMktProgramNameTableAdapter();
                return bll.GetDataBrandMktProgramName( unitid);
            }
            catch { return new DataTable(); }
        }
        public DataTable insertdataforsalescommissionjv(string xmlstring, int unitid, string gbcode, string prefix, string gbnarattion, decimal totalcommission, int  enrol,  int headcoaid)
        {
            try
            {
                SprVoucherCreateForSalesComissionTableAdapter bll = new SprVoucherCreateForSalesComissionTableAdapter();
                return bll.GetDataVoucherCreateForSalesComission(xmlstring,unitid, gbcode, prefix, gbnarattion, totalcommission, enrol, headcoaid);

            }
            catch { return new DataTable(); }
        }
        public DataTable GetItembaseofUnit(int unitid)
        {
            try
            {
                TblItembaseOfUnitTableAdapter bll = new TblItembaseOfUnitTableAdapter();
                return bll.GetDataProductNameBaseofUnit( unitid);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetProductBaseCommission(DateTime dtfromdate, DateTime dttodate, decimal commrate,int unitid,int productid )
        {
            try
            {
                SprACCLCTGPCC2ProductCommissionTableAdapter bll = new SprACCLCTGPCC2ProductCommissionTableAdapter();
                return bll.GetDatasprACCLCTGPCC2ProductCommission(dtfromdate,  dttodate,  commrate,  unitid,  productid);

            }
            catch { return new DataTable(); }
        }
        public DataTable insertdataforindividualproductcommissionjv(string xmlstring, int unitid, string gbcode, string prefix, string gbnarattion, decimal totalcommission, int enrol, int headcoaid)
        {
            //@xml xml, @intUnitID int, @strVcode varchar(500),@strPrefix varchar(500), @strNarration varchar(max), @monAmount decimal, @intEnrollID int, @coaHeadACCID int
            try
            {
                SprVoucherCreateForProductbaseCommissionTableAdapter bll = new SprVoucherCreateForProductbaseCommissionTableAdapter();
                return bll.InsertDatasprVoucherCreateForProductbaseCommission(xmlstring, unitid, gbcode, prefix, gbnarattion, totalcommission, enrol, headcoaid);

            }
            catch { return new DataTable(); }
        }

        public DataTable getdataChartofAccountHead(int unitid)
        {
            try
            {
                TblCOANameTableAdapter bll = new TblCOANameTableAdapter();
                return bll.GetData(unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getdataDiscountAdjustment(DateTime dtfromdate, DateTime dttodate, int salesofice, string reptname,int unitid)
        {
            try
            {
                SprDiscountAdjustmentTableAdapter bll = new SprDiscountAdjustmentTableAdapter();
                return bll.GetDatasprDiscountAdjustment(dtfromdate, dttodate, salesofice, reptname, unitid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetDelvQntVsChallanQnt(DateTime dtfromdate, DateTime dttodate, int  customerid, int unitid)
        {
            try
            {
                SprCustomerDelvQntAnalysisTableAdapter bll = new SprCustomerDelvQntAnalysisTableAdapter();
                return bll.GetData(dtfromdate, dttodate, customerid, unitid);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetVehicleTransportmodeinchallan(DateTime dtfromdate, DateTime dttodate, int customerid, int rpttype, string donumber, string challannumber, int unitid)
        {
            try
            {
                SprChallanvsTransportRentOptionTableAdapter bll = new SprChallanvsTransportRentOptionTableAdapter();
                return bll.GetData(dtfromdate, dttodate, customerid, rpttype, donumber, challannumber, unitid);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetCustomerDelvOrderResQntPriceAmount(int customerid ,string pendingamount)
        {
            try {
                SprCustomerDORestqntPendingamountTableAdapter bll = new SprCustomerDORestqntPendingamountTableAdapter();
                return bll.GetData(customerid, Convert.ToInt32( pendingamount));
            }
            catch
            {
                return new DataTable();
            }
        }
        //public DataTable GetCustomerOutstandingbasedonUndelvQnt(string customerid)
        //{
        //    try
        //    {
        //        SprUnDelvQntBaseOutstandingAmountTableAdapter bll = new SprUnDelvQntBaseOutstandingAmountTableAdapter();
        //        return bll.GetData(int.Parse(customerid));
        //    }
        //    catch
        //    {
        //        return new DataTable();
        //    }
        //}


        public StatementTDS.SprUnDelvQntBaseOutstandingAmountDataTable GetCustomerOutstandingbasedonUndelvQnt(string customerid)
        {
            if (customerid == "") return new StatementTDS.SprUnDelvQntBaseOutstandingAmountDataTable();
            SprUnDelvQntBaseOutstandingAmountTableAdapter ta = new SprUnDelvQntBaseOutstandingAmountTableAdapter();
            return ta.GetData(int.Parse(customerid));
        }
        public StatementTDS.SprUndelvQntRateDataTable GetCustomerProductRate(string intsoid)
        {
            if (intsoid == "") return new StatementTDS.SprUndelvQntRateDataTable();
            SprUndelvQntRateTableAdapter ta = new SprUndelvQntRateTableAdapter();
            return ta.GetData(int.Parse(intsoid));
        }

        public DataTable GetDelvQntVsChallanQntTopSheet(DateTime dtfromdate, DateTime dttodate, int unitid)
        {
            try
            {
                SprCustomerDelvQntTTopsheetTableAdapter bll = new SprCustomerDelvQntTTopsheetTableAdapter();
                return bll.GetData(dtfromdate, dttodate, unitid);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetPersonalBreakdownTADA(DateTime dtfromdate, DateTime dttodate, int enrol, int reportype, int areaid)
        {
            try
            {
                SprTADAAnalysisTableAdapter bll = new SprTADAAnalysisTableAdapter();
                return bll.GetData(dtfromdate, dttodate, enrol, reportype, areaid);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetUndelvQntWithDONumber( int reportype, int salesoffice,int customerid ,int unitid)
        {
            try
            {
                SprRemaingQntSalesOfficeBasisTableAdapter bll = new SprRemaingQntSalesOfficeBasisTableAdapter();
                return bll.GetData(reportype,  salesoffice,  customerid,  unitid);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetCreditstationvsEmployeecost(DateTime from,DateTime to,int enrol,int reportype)
        {
            try
            {
                SprTADAAnalysisforStationvsSingleEmployeeTableAdapter bll = new SprTADAAnalysisforStationvsSingleEmployeeTableAdapter();
                return bll.GetData(from,  to,  enrol,  reportype);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetCreditstationvsJobstation(DateTime from, DateTime to, int unit, int jobstation,int rpttype,int fuelstation)
        {
            try
            {
                TADACreditstationvsJobstationTableAdapter bll = new TADACreditstationvsJobstationTableAdapter();
                return bll.GetData(from,  to,  unit,  jobstation,  rpttype,  fuelstation);

            }
            catch { return new DataTable(); }
        }
        public DataTable GetUndelvQntWithSalesAmount(DateTime from, DateTime to, int custid, int unitid, int rpttype)
        {
            try
            {
                SprUndelvQntWithSalesAmountTableAdapter bll = new SprUndelvQntWithSalesAmountTableAdapter();
                return bll.GetData(from, to, custid, unitid, rpttype);

            }
            catch { return new DataTable(); }
        }

    }
}
