using HR_BLL.Global;
using HR_DAL.Global;
using HR_DAL.TourPlan;
using HR_DAL.TourPlan.TourPlanningTDSTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.TourPlan
{
    public class TourPlanning
    {
        public DataTable getEmployeeinfo(int enrol)
        {
            DataTable dt = new DataTable();
            try
            {
                tblEmployeeInfoForTourTableAdapter bll = new tblEmployeeInfoForTourTableAdapter();
                return bll.dtEmployeeInfo(enrol);
            }

            catch
            {
                return new DataTable();
            }


        }

        public string TourplaninfoInsertByApplicant(string xmlString, int Enrol, int unit, int jobstation)
        {
            string msg = "";
            try
            {
                SprInsTourPlanInfoTableAdapter bll = new SprInsTourPlanInfoTableAdapter();
                bll.tasprInsTourPlanInfo(xmlString, Enrol, unit, jobstation, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public DataTable getRptForTourPlan(DateTime dtFromDate, DateTime dtTodate, int unit, int enrol)
        {
            try
            {
                SprRptTourPlansTableAdapter bll = new SprRptTourPlansTableAdapter();
                return bll.tasprRptTourPlans(dtFromDate, dtTodate, unit, enrol);

            }

            catch
            {
                return new DataTable();

            }

        }

        public DataTable getRptForAccountsTADAWithRoutingNumber(DateTime dtFromDate, DateTime dtTodate, int unit, int ReporTypeid, int Areaid)
        {
            try
            {
                SprTADAWihtAccountNumberTableAdapter bll = new SprTADAWihtAccountNumberTableAdapter();
                return bll.tasprTADAWihtAccountNumber(dtFromDate, dtTodate, unit, ReporTypeid, Areaid);

            }

            catch
            {
                return new DataTable();

            }

        }

        public DataTable getRegionName(int intUnitID, string strOfficeEmail)
        {
            try
            {
                SprRegionForGloblOSTableAdapter bll = new SprRegionForGloblOSTableAdapter();
                return bll.tasprRegionForGloblOS(intUnitID, strOfficeEmail);
            }

            catch
            {
                return new DataTable();

            }

        }

        public DataTable getTourAreaName(int RegionId, int intUnitID)
        {
            try
            {
                SprAreaForGlobalOSTableAdapter bll = new SprAreaForGlobalOSTableAdapter();
                return bll.tasprAreaForGlobalOS(RegionId, intUnitID);
            }

            catch
            {
                return new DataTable();

            }

        }

        public DataTable getTourTerritoryName(int Areaid, int Unitid)
        {
            try
            {
                SprTourTerritoryGloblOSTableAdapter bll = new SprTourTerritoryGloblOSTableAdapter();
                return bll.tasprTourTerritoryGloblOS(Areaid, Unitid);
            }

            catch
            {
                return new DataTable();
            }
        }

        public DataTable getTourHotelName(int Unitid)
        {
            try
            {
                TblTourHotelNameTableAdapter bll = new TblTourHotelNameTableAdapter();
                return bll.taTourHotelList(Unitid);

            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable getTourDistrictName()
        {
            try
            {
                TblTourDistrictNameTableAdapter bll = new TblTourDistrictNameTableAdapter();
                return bll.taTourDistrictName();

            }
            catch { return new DataTable(); }
        }

        public DataTable getTourThanaName(int Districtid)
        {
            try
            {
                TblTourThanaNameTableAdapter bll = new TblTourThanaNameTableAdapter();
                return bll.taGetDistrictVsThana(Districtid);
            }
            catch
            {
                return new DataTable();
            }
        }

        public string tourNewHotelIns(string xmlString, int Enrol, int Unit)
        {
            string msg = "";

            try
            {
                SprInsTourHotelNameTableAdapter bll = new SprInsTourHotelNameTableAdapter();
                bll.tasprInsTourHotelName(xmlString, Enrol, Unit, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }



     


        public List<string> getBrandItemNameforReqs(int unitid, string perf)
        {
            List<string> result = new List<string>();
            //TblBrandItemTableAdapter bllitem = new TblBrandItemTableAdapter();
            TblBrandItemTableAdapter bllitem = new TblBrandItemTableAdapter();
            
            DataTable oDT = new DataTable();
            oDT = bllitem.taGetBrandItemUnitBasis(unitid, perf);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strItemName"].ToString());
                }

            }
            return result;

  }

        public List<string> getBrandItemNameWithstockstatus(int whid, string perf)
        {
            List<string> result = new List<string>();

            SprBrandItemReqsSearchTableAdapter bllitem = new SprBrandItemReqsSearchTableAdapter();

            DataTable oDT = new DataTable();
            oDT = bllitem.tasprBrandItemReqsSearch(whid, perf);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strItemName"].ToString());
                }

            }
            return result;

        }


        public DataTable CreateStoreRequisitionForBrandItem(int type, int actionby, string xml, int id, DateTime fdate, DateTime tdate)
        {
            SprBrandItemRequisitionTableAdapter adp = new SprBrandItemRequisitionTableAdapter();
            try { return adp.tainssprBrandItemRequisition(type, actionby, xml, id, fdate, tdate); }
            catch { return new DataTable(); }
        }

        public DataTable getBrandItmNameforstockentry(string intunitid, string perf)
        {
            TblBrandItemTableAdapter bllitemstock = new TblBrandItemTableAdapter();
            DataTable dt = new DataTable();
            dt = bllitemstock.taGetBrandItemUnitBasis(int.Parse(intunitid), perf);
            return bllitemstock.taGetBrandItemUnitBasis(int.Parse(intunitid), perf);
        }



        public DataTable getOvertimePurpouse()
        {
            TblOvertimePurpouseTableAdapter bllpurpouse = new TblOvertimePurpouseTableAdapter();
            DataTable dt = new DataTable();
            dt = bllpurpouse.taOvertimePurpouse();
            return bllpurpouse.taOvertimePurpouse();
        }

        public string overtimeInsertion(string xmlString, DateTime dteFromDate, int Enrol, string ipaddress)
        {
            string msg = "";
            try
            {
                SprEmplOverTimeTableAdapter bllTadaInsertByBikeAndCarUser = new SprEmplOverTimeTableAdapter();
                bllTadaInsertByBikeAndCarUser.tasprEmplOverTime(xmlString, dteFromDate, Enrol, ipaddress, ref msg);
                return msg;

            }

            catch (Exception ex) { return ex.ToString(); }

        }




       

        public DataTable getRptOverTime(int intReportType ,int intActionby ,string xml,int intid,DateTime fromdate,DateTime TODATE,int jsid,int unitid )
        {
       
            SprEmplOverTimeForReportsTableAdapter bllOvertimeRpt = new SprEmplOverTimeForReportsTableAdapter();
            DataTable dt = new DataTable();
            dt = bllOvertimeRpt.tasprEmplOverTimeForReports(intReportType, intActionby, xml, intid, fromdate, TODATE, jsid, unitid);
            return bllOvertimeRpt.tasprEmplOverTimeForReports(intReportType, intActionby, xml, intid, fromdate, TODATE,jsid, unitid);
        }

        public DataTable getUnitNamebyEnrol(int Enrol)
        {
            try { 
            SprUnitListForSeparationTableAdapter bll = new SprUnitListForSeparationTableAdapter();
            return bll.tasprUnitListForSeparation(Enrol);
                }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable getJobstationbyEnrol(int Enrol)
        {
            try
            {
                sprGetAllJobStationByLoginIdTableAdapter bll = new sprGetAllJobStationByLoginIdTableAdapter();
                return bll.tasprGetAllJobStationByLoginId(Enrol);
            }
            catch
            {
                return new DataTable();
            }
        }


        public string overtimeUpdation(string xmlString, DateTime dteFromDate, int Enrol)
        {
            string msg = "";
            try
            {
                SprEmplOverTimeUpdateInformationTableAdapter bllTadaInsertByBikeAndCarUser = new SprEmplOverTimeUpdateInformationTableAdapter();
                bllTadaInsertByBikeAndCarUser.tasprEmplOverTimeUpdateInformation(xmlString, dteFromDate, Enrol, ref msg);
                return msg;

            }

            catch (Exception ex) { return ex.ToString(); }

        }


        public List<string> getBrandItemSupplierList(int unitid, string perf)
        {
            List<string> result = new List<string>();
            TblBrandItemSupplierTableAdapter bll = new TblBrandItemSupplierTableAdapter();
            DataTable oDT = new DataTable();
            oDT = bll.taBrandItemSupplier(unitid, perf);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strSupplierName"].ToString());
                }

            }
            return result;
        }

        public DataTable CreateBrandItmRecvChallanbyWH(int type, int actionby, string xml, int id, DateTime fdate, DateTime tdate, int unitid)
        {
        SprBrandItemReciveByWHTableAdapter adp =new SprBrandItemReciveByWHTableAdapter();
        try { return adp.tasprBrandItemReciveByWH(type, actionby, xml, id, fdate, tdate, unitid); }
        catch { return new DataTable(); }
        }


        public DataTable GetBrandItemWarehouseList(int enroll, int type)
        {
            try
            {
                SprBrandItemStoreRequisitionWhTableAdapter ta = new SprBrandItemStoreRequisitionWhTableAdapter();
                return ta.tasprBrandItemStoreRequisitionWh(enroll, type);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetBrandItemWHBaseStockTopSheet(int whid,int intUnitID )
        {
            try
            {
                SprBrandItemInventoryByItemTableAdapter ta = new SprBrandItemInventoryByItemTableAdapter();
                return ta.tasprBrandItemInventoryByItem(whid, intUnitID);
            }
            catch { return new DataTable(); }
        }
 
        public DataTable GetBrandItemREPORT(int type, int action,int unit,int wh,DateTime dtfrom,DateTime dtto)
        {
            try
            {
                SprBrandItemRequistionReportsTableAdapter ta = new SprBrandItemRequistionReportsTableAdapter();
                return ta.tasprBrandItemRequistionReports(type,action,unit,wh,dtfrom,dtto);
            }
            catch { return new DataTable(); }
        }


        public DataTable GetAclDirectPointList(int Unitid)
        {
            try
            {
                SprGetACLDirectPointListTableAdapter bll = new SprGetACLDirectPointListTableAdapter();
                return bll.tasprGetACLDirectPointList(Unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetBrandMktProgramList(int Unitid)
        {
            try
            {
                SprBrandMktProgramNamelistTableAdapter bll = new SprBrandMktProgramNamelistTableAdapter();
                return bll.tasprBrandMktProgramNamelist(Unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetTADASupervisroApproveMonitoring(DateTime dtform,DateTime dtTo,int emplid,int unitid,int reporttypeid)
        {
            try
            {
                SprTADASupervisorApproveMonitoringTableAdapter bll = new SprTADASupervisorApproveMonitoringTableAdapter();
                return bll.tasprTADASupervisorApproveMonitoring(dtform, dtTo, emplid, unitid, reporttypeid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetUnitpermissionbaseemployeeid(int enrol)
        {
            try
            {
                SprGetEmpPermissionUnitTableAdapter objemplunitpermission = new SprGetEmpPermissionUnitTableAdapter();
                return objemplunitpermission.GetDataGetEmpPermissionUnit(enrol);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetdataforConferenceRoom(int type,int hallid )
        {
            SprConferenceRoomTableAdapter adp = new SprConferenceRoomTableAdapter();
            try { return adp.GetDataConferenceRoom(type, hallid); }
            catch { return new DataTable(); }
        }
        public string SubmitConferenceroomshedulinfo(int hallid, int unitid, int deptid, int totalparticipants, DateTime fromdate, TimeSpan tmstart, TimeSpan tmend, int actionBy)
        {
            
            string rtnMessage = "0";
            try
            {
                SprConferenceRoomSheduleInfoTableAdapter ta = new SprConferenceRoomSheduleInfoTableAdapter();
                ta.GetDataConferenceRoomSheduleInfo(hallid,  unitid,  deptid,  totalparticipants,  fromdate,  tmstart,  tmend,  actionBy, ref rtnMessage);
            }
            catch { return rtnMessage; }
            return rtnMessage;
        }

        public string HallBookingApproveProcessed(int applicationId, Boolean ysnapprovebyadmin, Boolean ysncancelbyadmin, int actionBy)
        {
            string rtnMessage = "";
            try
            {
                SprConferenceRoomApprovedInfoTableAdapter ta = new SprConferenceRoomApprovedInfoTableAdapter();
                ta.GetDataConferenceRoomApprovedInfo(applicationId, ysnapprovebyadmin, ysncancelbyadmin, actionBy, ref rtnMessage);
            }
            catch { rtnMessage = "0"; }
            return rtnMessage;
        }
        public DataTable ConferenceRoomBookingStatus(DateTime dtdate, int hallid)
        {
            SprConferenceRoomBookingStatusTableAdapter adp = new SprConferenceRoomBookingStatusTableAdapter();
            try { return adp.GetDataConferenceRoomBookingStatus(dtdate, hallid); }
            catch { return new DataTable(); }
        }

        public DataTable ConferenceRoomBookinginfovsHallid(int hallid)
        {
            SprConferenceRoomBookinginfovsHallidTableAdapter adp = new SprConferenceRoomBookinginfovsHallidTableAdapter();
            try { return adp.GetDataConferenceRoomBookinginfovsHallid(hallid); }
            catch { return new DataTable(); }
        }
        public DataTable GetdataforConferenceRoomLoadlist()
        {
            TblConferenceRoomListTableAdapter adp = new TblConferenceRoomListTableAdapter();
            try { return adp.GetDataConferenceforloadlist(); }
            catch { return new DataTable(); }
        }
        public DataTable ConferenceRoomBookingMonthvsHallid(int hallid,DateTime dtedate)
        {
            SprConferenceRoomBookingMonthvsHallidTableAdapter adp = new SprConferenceRoomBookingMonthvsHallidTableAdapter();
            try { return adp.GetDataConferenceRoomBookingMonthvsHallid(hallid, dtedate); }
            catch { return new DataTable(); }
        }
        public DataTable GetRemoteSalesMktReportType()
        {
            try
            {
                TblSalesMktReportTypeTableAdapter objreporttype = new TblSalesMktReportTypeTableAdapter();
                return objreporttype.GetDataSalesMktReportType();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetSalesforacast( DateTime dtefromdate,DateTime dtetodate,string emailadress)
        {
            SprACCLForeCastAreaWiseTableAdapter adp = new SprACCLForeCastAreaWiseTableAdapter();
            try { return adp.GetDatasprACCLForeCastAreaWise(dtefromdate,  dtetodate,  emailadress); }
            catch { return new DataTable(); }
        }

        public DataTable GetValueForOne(int assetid)
        {
            //TblValueOneTableAdapter adp = new TblValueOneTableAdapter();
            //try { return adp.GetDataValuecheckingone(assetid); }
            //catch { return new DataTable(); }

            return new DataTable();
        }



        private static TourPlanningTDS.TblBrandItemFDataTable[] tableProducts = null;
        private static TourPlanningTDS.TblRawMaterialtemListDataTable[] tableProductsRawMaterial = null;
        private static Hashtable ht = new Hashtable();

        private static void Inatialize()
        {
            if (tableProducts == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableProducts = new TourPlanningTDS.TblBrandItemFDataTable[tblUnit.Rows.Count];
                TblBrandItemFTableAdapter adpCOA = new TblBrandItemFTableAdapter();

                int id = 0;

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
                    TourPlanningTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(tblUnit[i].intUnitID);

                    if (tbl.Rows.Count > 0) id = tbl[0].intID;

                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableProducts[i] = adpCOA.GetDataByUnit_Type(tblUnit[i].intUnitID, true);
                }
            }
        }

        private static void InatializeRM()
        {
            if (tableProductsRawMaterial == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableProductsRawMaterial = new TourPlanningTDS.TblRawMaterialtemListDataTable[tblUnit.Rows.Count];
                TblRawMaterialtemListTableAdapter adpCOA = new TblRawMaterialtemListTableAdapter();

                int id = 0;

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
                    TourPlanningTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(tblUnit[i].intUnitID);

                    if (tbl.Rows.Count > 0) id = tbl[0].intID;

                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    //tableProductsRawMaterial[i] = adpCOA.GetDataByUnit_Type(tblUnit[i].intUnitID, id, true);
                    tableProductsRawMaterial[i] = adpCOA.GetData();
                }
            }
        }



        public static string[] GetProductDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableProducts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.strItemName
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
                    var rows = from tmp in tableProducts[Convert.ToInt32(ht[unitID])]
                               where tmp.strItemName.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strItemName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strItemName"] + " [" + tbl.Rows[i]["BrandPid"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetRAWMaterialProductDataForAutoFill(string unitID, string prefix)
        {
            InatializeRM();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableProductsRawMaterial[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.strItemName
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
                    var rows = from tmp in tableProductsRawMaterial[Convert.ToInt32(ht[unitID])]
                               where tmp.strItemName.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strItemName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strItemName"] + " [" + tbl.Rows[i]["intItemID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }





        public TourPlanningTDS.SprGetUOMRelationforBrandItemDataTable GetUOMRelationBrand(string productId)
        {
            if (productId == null ) return null;
            SprGetUOMRelationforBrandItemTableAdapter ta = new SprGetUOMRelationforBrandItemTableAdapter();

            return ta.GetData(long.Parse(productId));
        }

     public TourPlanningTDS.SprGetUOMRelationforInventoryItemDataTable GetUOMRelationforInventoryitem(string productid)
        {
            if (productid == null) return null;
            SprGetUOMRelationforInventoryItemTableAdapter ta = new SprGetUOMRelationforInventoryItemTableAdapter();
            return ta.GetDataUOMForInventoryitem(int.Parse(productid));
        }



        public TourPlanningTDS.TblBrandItemChallanDetDataTable GetBrandChallanDetails(string id)
        {
            TblBrandItemChallanDetTableAdapter ta = new TblBrandItemChallanDetTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }

        public TourPlanningTDS.TblRawMaterialChallanDetDataTable GetRawMaterialChallanDetails(string id)
        {
            TblRawMaterialChallanDetTableAdapter ta = new TblRawMaterialChallanDetTableAdapter();
            return ta.GetDataByID(int.Parse(id));
        }



        public TourPlanningTDS.QryBrandItemChallanCustomerDataTable GetBrandItemEntry(string id)
        {
            QryBrandItemChallanCustomerTableAdapter ta = new QryBrandItemChallanCustomerTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }

        //public TourPlanningTDS.QryRawMaterialChallanDetDataTable GetRawMaterialItemEntry(string id)
        //{
        //    QryRawMaterialChallanDetTableAdapter ta = new QryRawMaterialChallanDetTableAdapter();
        //    return ta.GetDataById(int.Parse(id));
        //}



        public void AddbranditemchallanInformation(string xmlStr, string userId, string unitId
        , DateTime date, string challanNo
        , string customerId, string customerType, string narration, string address
       , bool isLogistic, bool isLogisticByCompany
        , string vehicleId, string vehicleRegNo, string vehicleTypeId,
       string other, string driver, string driverContact, string salesOffice, string shippingPoint, ref string code, ref string entryId
        )
        {
            long? id = null;
            int? priceVar_ = null, vehicleId_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, vehicleTypeId_ = null;
            try { id = long.Parse(entryId); }
            catch { }
          
            try { vehicleId_ = int.Parse(vehicleId); }
            catch { }
          
            try { vehicleTypeId_ = int.Parse(vehicleTypeId); }
            catch { }

            //SprSalesEntryTableAdapter ta = new SprSalesEntryTableAdapter();
            SprRAWMaterialEntryTableAdapter ta = new SprRAWMaterialEntryTableAdapter();
            ta.GetDataRawMaterialEntry(xmlStr,  int.Parse(userId), int.Parse(unitId), date, challanNo
               , int.Parse(customerId), int.Parse(customerType)
                , narration, address
                ,  isLogistic, isLogisticByCompany, vehicleId_, vehicleRegNo
                ,  vehicleTypeId_, other, driver, driverContact, int.Parse(salesOffice), int.Parse(shippingPoint), ref code,ref id);

            entryId = id.ToString();
        }
        

        public TourPlanningTDS.SprBrandItemChallanEnterdInfoDataTable GetBrandItemInformationForChallan(string unitID, string shippointid, string salesofficeid, string customertype, string code, DateTime fromDate, DateTime toDate, string rdbselection)
        {
            SprBrandItemChallanEnterdInfoTableAdapter adp = new SprBrandItemChallanEnterdInfoTableAdapter();

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

   
            //if (type == "act") { isCompleted = false; isEnable = true; }
            //else if (type == "inc") { isCompleted = null; isEnable = false; }
            //else if (type == "com") { isCompleted = true; isEnable = true; }

            if (rdbselection == "act") { isCompleted = false; isEnable = true; }
            else if (rdbselection == "inc") { isCompleted = false; isEnable = false; }
            else if (rdbselection == "com") { isCompleted = true; isEnable = true; }
         

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

            //@intUnitID int, @fromdate datetime,@todate datetime, @ysnEnable bit = null,@ysnChallanCompleted bit, @intCustomerType int, @code varchar(50) = null,@intShipPointId int
            if ("" + customertype == "") return null;
            return adp.GetData(int.Parse(unitID), int.Parse(shippointid), int.Parse(salesofficeid), int.Parse(customertype), code, fromDate, toDate, isEnable, isCompleted);
        }


        public void ChallanCancel(string id, string userId)
        {
            SprBrandItemChallanEnterdInfoTableAdapter adp = new SprBrandItemChallanEnterdInfoTableAdapter();
            adp.Cancel(int.Parse(userId), int.Parse(id));
        }

        public void ChallanComplete(string id, string userId)
        {
            SprBrandItemChallanEnterdInfoTableAdapter adp = new SprBrandItemChallanEnterdInfoTableAdapter();
            adp.ChallanComplete(int.Parse(userId), int.Parse(id));
        }


        public TourPlanningTDS.SprBrandItemChallaninformationforPrintDataTable GetData(string id, string userId, string separator, ref DateTime date, ref string unitName
            , ref string unitAddress, ref string userName, ref string challanNo, ref string customerName
            , ref string customerPhone, ref string delevaryAddress, ref string otherInfo
            , ref string vehicle, ref string propitor
            , ref string driver, ref string driverPh,  ref string logistic)
        {
            SprBrandItemChallaninformationforPrintTableAdapter ta = new SprBrandItemChallaninformationforPrintTableAdapter();
            DateTime? dt = null;
            bool? isLogBasedOnUOM_ = null, isCharBasedOnUOM_ = null, isIncenBasedOnUOM_ = null;

            TourPlanningTDS.SprBrandItemChallaninformationforPrintDataTable table = ta.GetData(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref challanNo, ref customerName, ref customerPhone, ref delevaryAddress, ref otherInfo
                , ref vehicle, ref propitor, ref driver, ref driverPh, ref logistic);
            date = dt.Value;
           

            return table;
        }


        public bool GetPriceVisibilityRawMaterials(int itemid)
        {
            TblRAWMatPricevisibilityTableAdapter adp = new TblRAWMatPricevisibilityTableAdapter();
            return bool.Parse(adp.GetData(itemid).ToString());
        }

        public void AddRawMaterialitemchallanInformation(string xmlStr, string userId, string unitId
       , DateTime date, string challanNo
       , string customerId, string customerType, string narration, string address
      , bool isLogistic, bool isLogisticByCompany
       , string vehicleId, string vehicleRegNo, string vehicleTypeId,
      string other, string driver, string driverContact, string salesOffice, string shippingPoint, ref string code, ref string entryId
       )
        {
            long? id = null;
            int? priceVar_ = null, vehicleId_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, vehicleTypeId_ = null;
            try { id = long.Parse(entryId); }
            catch { }

            try { vehicleId_ = int.Parse(vehicleId); }
            catch { }

            try { vehicleTypeId_ = int.Parse(vehicleTypeId); }
            catch { }

            //SprSalesEntryTableAdapter ta = new SprSalesEntryTableAdapter();
            SprBrandItemChallanEntryTableAdapter ta = new SprBrandItemChallanEntryTableAdapter();
            ta.GetData(xmlStr, int.Parse(userId), int.Parse(unitId), date, challanNo
               , int.Parse(customerId), int.Parse(customerType)
                , narration, address
                , isLogistic, isLogisticByCompany, vehicleId_, vehicleRegNo
                , vehicleTypeId_, other, driver, driverContact, int.Parse(salesOffice), int.Parse(shippingPoint), ref code, ref id);

            entryId = id.ToString();
        }





    }
}
