using Purchase_DAL.Asset.AssetMaintenanceTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Purchase_BLL.Asset
{
    public class AssetMaintenance
    {

        public DataTable ShowServeceName()
        {
            TblAssetServicingListTableAdapter service = new TblAssetServicingListTableAdapter();
            return service.ServiceNameGetData();
        }

        public void MaitenanceTask (int Mnumber, int service, string type, decimal cost,int intenroll, int intjobid,int  intdept)
        {
            TblMaintenanceTaskTableAdapter insert = new TblMaintenanceTaskTableAdapter();
            insert.MaintenanceServicetaskGetData(Mnumber, service, type, cost, intenroll, intjobid, intdept);
        }

        public DataTable dtashgridview(int intItem, int Mnumber)
        {
            SprMaintenanceLoadViewTableAdapter taskgrid = new SprMaintenanceLoadViewTableAdapter();
            return taskgrid.TaskGridViewGetData(intItem, Mnumber,Convert.ToInt32("0"),Convert.ToInt32("0"),Convert.ToInt32("0"));
        }

        public DataTable MaintenaceJobstation()
        {
            try
            {
                TblJobstationByDeptTableAdapter adp = new TblJobstationByDeptTableAdapter();
                return adp.GetServiceJobstationData();
            }
            catch { return new DataTable(); }
        }

        public DataTable NatureOfMaintenace()
        {
            try
            {
                TblJobstationByDeptTableAdapter adp = new TblJobstationByDeptTableAdapter();
                return adp.GetNatureofMaintenaceData();
            }
            catch { return new DataTable(); }
        }

        public DataTable sparePartsView(int intItem, int Mnumber)
        {
            SprMaintenanceLoadViewTableAdapter spaere = new SprMaintenanceLoadViewTableAdapter();
            return spaere.TaskGridViewGetData(intItem, Mnumber, Convert.ToInt32("0"), Convert.ToInt32("0"), Convert.ToInt32("0"));
        }

        //public void LaborCost(int Mnumber, string technichin, string description, decimal laborrate, string hour, decimal Tcost)
        //{
        //    TblMaintenanceLaborCostTableAdapter labor = new TblMaintenanceLaborCostTableAdapter();
        //    labor.LaborCostDataGetData(Mnumber, technichin, description, laborrate, hour, Tcost);


        //}






        public void UpdateStatus(string status, DateTime dteStart, string priority, string costcenter, string assign, string notes, int intcostcenter, int technichin,string presentM,string nextM,int Heavy,string strDriverName,string strConatactNo,string strUser, int Mnumber)
        {
            TblUpdateAssetMaintenanceTableAdapter insertdate = new TblUpdateAssetMaintenanceTableAdapter();
            insertdate.UpdateMaintenanceStatusGetData(status, dteStart, priority, costcenter, assign, notes, intcostcenter, technichin,presentM,nextM,Heavy,strDriverName,strConatactNo,strUser, Mnumber);
        }



        public DataTable showassetData(string number)
        {
            DataTable2TableAdapter showdata = new DataTable2TableAdapter();
            return showdata.AssetDataShowLoadGetData(number);
        }

        
        public DataTable maintenancegridviewshow(int intItem,int Mnumber, int intenroll,int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter assetstatus = new SprMaintenanceLoadViewTableAdapter();
            return assetstatus.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        //public void MaintenanceDocumnetUpload(int Mnumber, string path, string docdesc)
        //{
        //    TblMaintenanceDocUploadTableAdapter docupload = new TblMaintenanceDocUploadTableAdapter();
        //    docupload.MaintenanceDocUploadGetData(Mnumber, path, docdesc);
        //}

       
        public DataTable ReportAsset(DateTime fromdate, DateTime todate)
        {
            ReportDataTable1TableAdapter datereport = new ReportDataTable1TableAdapter();
            return datereport.ReportDateWaiseGetData(fromdate, todate);
        }

        public void MaintenanceComplete(int intItem, int Mnumber,int intenroll, int intjobid ,int intdept)
       {
         SprMaintenanceLoadViewTableAdapter maintenanceclose = new SprMaintenanceLoadViewTableAdapter();
         maintenanceclose.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
       }

        public DataTable issuedateshow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter issuedatedata = new SprMaintenanceLoadViewTableAdapter();
            return issuedatedata.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void PMScheduleInsertData(string schedule,int  intjobid,int intunitid ,int intenroll)
        {
            PMScheduleNameTableAdapter schedulename = new PMScheduleNameTableAdapter();
            schedulename.PMScheduleNameInsertGetData(schedule,intjobid,intunitid,intenroll );
        }

        public DataTable PmShecduleshowGridview(int intItem, int Mnumber)
        {
            SprMaintenanceLoadViewTableAdapter pmshow = new SprMaintenanceLoadViewTableAdapter();
            return pmshow.TaskGridViewGetData(intItem, Mnumber, Convert.ToInt32("0"), Convert.ToInt32("0"), Convert.ToInt32("0"));
        }

        public void PMServiceInsertData(string servicename,decimal charge,int intenroll,int intjobid,int intdept )
        {
            TblPMServiceNameTableAdapter pmservice = new TblPMServiceNameTableAdapter();
            pmservice.PMServiceInsertDataGetData(servicename, charge,intenroll, intjobid, intdept);
        }

       


        public void RepairRequestInsertData(string asset, DateTime dterepair, string commonrepair, string repairtype, string DdlPriority, int intenroll, int intjobid, int intunitid)
        {
           TblRepairRequestTableAdapter repair=new TblRepairRequestTableAdapter();
           repair.RepairRequestInsertdataGetData(asset, dterepair, commonrepair, repairtype, DdlPriority, intenroll, intjobid, intunitid);
        }

        public void CommonRepairsItemInsertGet(string repairs,decimal repairscost, int intenroll, int intjobid, int intunitid, int intdept)
        {
            TblCommonRepairsListTableAdapter common = new TblCommonRepairsListTableAdapter();
            common.CommonRepairsInsertDataGetData(repairs,repairscost, intenroll, intjobid, intunitid, intdept);
        }



        public DataTable PreventiveRepairsList(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter preven = new SprMaintenanceLoadViewTableAdapter();
            return preven.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable RepairsCommonList(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter repaire = new SprMaintenanceLoadViewTableAdapter();
            return repaire.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void RepairMaintenenceTaskInsert(int Mnumber, int service,string serviceName,decimal cost, string type,  int intenroll, int intjobid, int intdept)
        {
            TblMaintenanceTaskRepairTableAdapter repir = new TblMaintenanceTaskRepairTableAdapter();
            repir.MaintenanceTaskRepairsInsertGetData(Mnumber, service, serviceName, cost, type, intenroll, intjobid, intdept);
        }




        public DataTable ScheduleNameLoad(int intItem, int Mnumber,int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter schedule = new SprMaintenanceLoadViewTableAdapter();
            return schedule.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable ServiceDropdown(int intItem, int Mnumber,int intenroll, int intjobid,int  intdept)
        {
            SprMaintenanceLoadViewTableAdapter servicel = new SprMaintenanceLoadViewTableAdapter();
            return servicel.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable getVehicleInformation(string assetId)
        {
            try
            {
                VehicleRenewalInfoDataTableTableAdapter adp = new VehicleRenewalInfoDataTableTableAdapter();
                return adp.GetAssetVehicleRenewalData(assetId);
            }
            catch { return new DataTable(); }
        }

        public void RepairRequestsInsertData(string strAssetId,int intAssetAutoId, int serviceId, string repair, string priority, DateTime dteRepair, string problem, int intenroll, int intjobid, int intdept, string provide, int ysnprovide, decimal repairsCost)
        {
            TblRequestServiceConfigureTableAdapter request = new TblRequestServiceConfigureTableAdapter();
            request.RepairRequestConfigInsertGetData(strAssetId,intAssetAutoId, serviceId,repair, priority, dteRepair, problem, intenroll, intjobid, intdept, provide, Convert.ToBoolean(ysnprovide), repairsCost);
        }

        public DataTable dgvViewPMService(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter gridvice = new SprMaintenanceLoadViewTableAdapter();
            return gridvice.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void PMSpareParts(int Reffno, int parts, Decimal pqty, int intenroll, int intjobid, int intdept, int intwh, string remarks)
        {
            TblPMSPartsTableAdapter pmservicepart = new TblPMSPartsTableAdapter();
            pmservicepart.PMServiceGetData(Reffno, parts, pqty, intenroll, intjobid, intdept, intwh, remarks);
        }

        public void PMSLaborCost(int Reffno, int technichin, string description, string hour, int intenroll, int intjobid, int intdept)
        {
            TblPMSPartsTableAdapter pmlabor = new TblPMSPartsTableAdapter();
            pmlabor.PMSLaborInsert(Reffno, technichin, description, hour,intenroll, intjobid, intdept);
        }

        public void PMSDocUpload(int Reffno, string path, string docdesc, int intenroll, int intjobid, int intdept)
        {
            TblPMSPartsTableAdapter PMSDocupload = new TblPMSPartsTableAdapter();
            PMSDocupload.PMSDocumnetUploadInsert(Reffno, path, docdesc, intenroll, intjobid, intdept);
        }



        public DataTable PMSsparePartsView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter pmspareview = new SprMaintenanceLoadViewTableAdapter();
           return pmspareview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);

        }

        public DataTable PMSLaborcostShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter pmsLaborview = new SprMaintenanceLoadViewTableAdapter();
            return pmsLaborview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable PMSdocview(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter pmsdocview = new SprMaintenanceLoadViewTableAdapter();
            return pmsdocview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void WOSpareParts(int Reffno, int parts, Decimal pqty, int intenroll, int intjobid, int intdept, int intwh, string remarks)
        {
            TblWOMaintenancePartsTableAdapter WOParts = new TblWOMaintenancePartsTableAdapter();
            WOParts.InsertPartsGetData(Reffno, parts, pqty, intenroll, intjobid, intdept, intwh, remarks);
        }

        public void WOLaborCost(int Reffno, int technichin, string description, decimal hour, int intenroll, int intjobid, int intdept, int ysnTecnichin)
        {
            TblWOMaintenancePartsTableAdapter WOLabor = new TblWOMaintenancePartsTableAdapter();
            WOLabor.WOInsertLaborCostGetData(Reffno, technichin, description, hour, intenroll, intjobid, intdept, Convert.ToBoolean(ysnTecnichin));
        }

        public void WODocUpload(int Reffno, string path, string docdesc, int intenroll, int intjobid, int intdept)
        {
            TblWOMaintenancePartsTableAdapter WoDoc = new TblWOMaintenancePartsTableAdapter();
            WoDoc.WODocUploadInsert(Reffno, path, docdesc, intenroll, intjobid, intdept);
        }

        public DataTable WOsparePartsView(int intItem, int Mnumber,int intenroll,int intjobid,int intdept)
        {
            SprMaintenanceLoadViewTableAdapter wopartsview = new SprMaintenanceLoadViewTableAdapter();
            return wopartsview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable WOLaborcostShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter laborview = new SprMaintenanceLoadViewTableAdapter();
            return laborview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
              
        }

        public DataTable WOdocview(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter docview = new SprMaintenanceLoadViewTableAdapter();
            return docview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable Sareparts(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter spareparts = new SprMaintenanceLoadViewTableAdapter();
            return spareparts.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable labor(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter wolaborv = new SprMaintenanceLoadViewTableAdapter();
            return wolaborv.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable documnetview(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter wodview = new SprMaintenanceLoadViewTableAdapter();
            return wodview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable PMservicerequestShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter PmServierequests = new SprMaintenanceLoadViewTableAdapter();
            return PmServierequests.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable RepairservicerequestShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter REService = new SprMaintenanceLoadViewTableAdapter();
            return REService.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

       
        public void insertServiceIdfromServiceConfig(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter InsertServiceIdtoTask = new SprMaintenanceLoadViewTableAdapter();
            InsertServiceIdtoTask.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable InserPMReptoMainteanceTask(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter pmreptotask = new SprMaintenanceLoadViewTableAdapter();
            return pmreptotask.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void WPMSDataInsert(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter wopminsert =new  SprMaintenanceLoadViewTableAdapter();
            wopminsert.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable ReportData(string number)
        {
            ReportDataTableTableAdapter dgvreport = new ReportDataTableTableAdapter();
            return dgvreport.ReportGetData(number);
        }



        public void InsertPMServicerequestdata(string strAssetID,int intAssetAutoId, int serviceId, string service, string priority, DateTime dtefixed, int countday, int intenroll, int intjobid, int intdept, string provide, string priode, decimal serviceCost)
        {
            SprPMServiceTableAdapter pmserviceRe = new SprPMServiceTableAdapter();
            pmserviceRe.PmServiceConfigGetData(strAssetID, intAssetAutoId, serviceId,service, priority, dtefixed, countday, intenroll, intjobid, intdept, provide, priode, serviceCost);
        }

        public DataTable dgvViewServiceName(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter servicename = new SprMaintenanceLoadViewTableAdapter();
            return servicename.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable commonrepairsView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter commonview = new SprMaintenanceLoadViewTableAdapter();
            return commonview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void dgvPartsdelete(int intIdParts, int intjobid, int intdept)
        {
            TblWOMaintenancePartsTableAdapter wopartsdelete = new TblWOMaintenancePartsTableAdapter();
            wopartsdelete.WoPartsDeleteQuery(intIdParts, intjobid, intdept);
        }

        public void dgvLabordelete(int intIdLabor, int intjobid, int intdept)
        {
            TblWOMaintenancePartsTableAdapter wolabordelete = new TblWOMaintenancePartsTableAdapter();
            wolabordelete.WOLaborCostDeleteQuery(intIdLabor, intjobid, intdept);
        }

        public DataTable DatewaiseReport(DateTime dtefrom, DateTime dteto, int intjobid)
        {
            ReportDataTableTableAdapter datereport = new ReportDataTableTableAdapter();
            return datereport.ReportWithDateGetDataBy(dtefrom,Convert.ToDateTime(dteto), intjobid);
        }

        public DataTable CostcenterShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter costcenter = new SprMaintenanceLoadViewTableAdapter();
            return costcenter.TaskGridViewGetData(intItem,  Mnumber,intenroll, intjobid,  intdept);
        }

        public DataTable InserPMtoMainteanceTask(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            
            SprMaintenanceLoadViewTableAdapter workorder = new SprMaintenanceLoadViewTableAdapter();
            return workorder.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
       

        }

        public DataTable Corporatemaintenancegridviewshow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corporatemaintenance = new SprMaintenanceLoadViewTableAdapter();
            return corporatemaintenance.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporateRepairservicerequestShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corporateRepairview = new SprMaintenanceLoadViewTableAdapter();
            return corporateRepairview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporatePMservicerequestShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corporatePMrequest = new SprMaintenanceLoadViewTableAdapter();
            return corporatePMrequest.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporateServiceDropdown(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corservicename = new SprMaintenanceLoadViewTableAdapter();
             return corservicename.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporateRepairsCommonList(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corcommonreName = new SprMaintenanceLoadViewTableAdapter();
            return corcommonreName.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporatedgvViewPMService(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter cordgvPMserviceconfig = new SprMaintenanceLoadViewTableAdapter();
            return cordgvPMserviceconfig.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporatedgvViewServiceName(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corpPmservicename = new SprMaintenanceLoadViewTableAdapter();
            return corpPmservicename.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorpRepairsCommonList(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corpcommname = new SprMaintenanceLoadViewTableAdapter();
            return corpcommname.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable warehousename(int enroll, int type)
        {
            SprStoreRequisitionWhTableAdapter warehouse = new SprStoreRequisitionWhTableAdapter();
            return warehouse.GetWarehouseList(enroll, type); 
        }

        public DataTable DepartmentbyCorporate()
        {
            DeptNameDataTableTableAdapter corporatedept = new DeptNameDataTableTableAdapter();
            return corporatedept.CorporateDeptGetDataBy();
        }

        public DataTable DepartmentbyJobstation(int intjobid)
        {
            DeptNameDataTableTableAdapter factorydept = new DeptNameDataTableTableAdapter();
            return factorydept.DepartmentNameGetData(intjobid);
        }



        public void UserRequestMaintenance(string assetId,int intAssetAutoId, string priority, string problem, int intenroll, int intLocationId, string location, int dept, string urgent,int intType)
        {
            TblRequestServiceConfigureTableAdapter userrequestinsert = new TblRequestServiceConfigureTableAdapter();
            userrequestinsert.UserRequestSupport(assetId, intAssetAutoId, priority, problem, intenroll, intLocationId, dept, location, urgent, intType);
        }

        public DataTable GriedViewUserRequestData(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter userviewdata = new SprMaintenanceLoadViewTableAdapter();
            return userviewdata.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable UserRequestShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter userreqwork = new SprMaintenanceLoadViewTableAdapter();
            return userreqwork.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CorporateUserRequestShow(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter corporateuser = new SprMaintenanceLoadViewTableAdapter();
            return corporateuser.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable InsertUserrequestWorklorder(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter userworkorder = new SprMaintenanceLoadViewTableAdapter();
            return userworkorder.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable RequesitionGenerateNumber(int Mnumber, int intenroll, int intUnitID, int intdept)
        {
            SprMaintenanceReqCodeTableAdapter autostoreReq = new SprMaintenanceReqCodeTableAdapter();
            return autostoreReq.AutoStoreReqGetData(Mnumber, intenroll, intUnitID, intdept);
        }



        public DataTable JobstationDropdoownlist(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter jobstationd = new SprMaintenanceLoadViewTableAdapter();
            return jobstationd.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable JobstationDepartment(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter jobstationdept= new SprMaintenanceLoadViewTableAdapter();
            return jobstationdept.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable Assetregistervreport(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
             SprMaintenanceLoadViewTableAdapter assetReportdata= new SprMaintenanceLoadViewTableAdapter();
            return assetReportdata.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }


        public DataTable JobcardInformation(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter jobreport= new SprMaintenanceLoadViewTableAdapter();
            return jobreport.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable VehicleTegistrationView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter vehiclereport = new SprMaintenanceLoadViewTableAdapter();
            return vehiclereport.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable PmDateReportShow( int intjobid, int intdept, DateTime dtefrom, DateTime dteto)
        {
            DatePMSReportTableAdapter datepms = new DatePMSReportTableAdapter();
            return datepms.DatePmServiceReportGetData( intjobid, intdept, Convert.ToDateTime(dtefrom), Convert.ToDateTime(dteto));
        }

        public DataTable LandRegisterReport(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter Landreport = new SprMaintenanceLoadViewTableAdapter();
            return Landreport.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
 
        }

        public DataTable landDevlopmentReport(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter buildingreport= new SprMaintenanceLoadViewTableAdapter();
            return buildingreport.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void WOTollsCost(int Reffno, string ToolsID, string description, decimal hour, int intenroll, int intjobid, int intdept)
        {
            TblWOMaintenancePartsTableAdapter WOToolsIn = new TblWOMaintenancePartsTableAdapter();
            WOToolsIn.WOToolsEquipmentInsert(Reffno, ToolsID, description, hour, intenroll, intjobid, intdept);
        }

        public DataTable CheckSubServiceView(int reffno, string service)
        {
            
            TblMaintenanceSubServiceTaskTableAdapter ap = new TblMaintenanceSubServiceTaskTableAdapter();
            return ap.CheckDuplicateServiceData(reffno, service);
        }

        public DataTable SubServiceView(int reffno)
        {
            TblMaintenanceSubServiceTaskTableAdapter ap = new TblMaintenanceSubServiceTaskTableAdapter();
            return ap.GetSubServiceData(reffno);
        }

        public void SubServiceCost(int reffno, string service, decimal cost)
        {
            TblMaintenanceSubServiceTaskTableAdapter ap = new TblMaintenanceSubServiceTaskTableAdapter();
            ap.InsetSubServiceCostData(reffno, service, cost);
        }

        public void dgvServiceDelete(int intId)
        {
            TblMaintenanceSubServiceTaskTableAdapter ap = new TblMaintenanceSubServiceTaskTableAdapter();
            ap.DeleteSubServiceData(intId);
        }

        public void ServiceChargeUpdate(int serviceId, decimal serviceCost,string serviceDesc)
        {
            try
            {
                TblUpdatelMaintenanceTaskTableAdapter adp = new TblUpdatelMaintenanceTaskTableAdapter();
                adp.UpdateServiceCostData(serviceCost, serviceDesc, serviceId);
            }
            catch { }
        }

        public DataTable MaintenanceToolsView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter MaintenanceViewtools = new SprMaintenanceLoadViewTableAdapter();
            return MaintenanceViewtools.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);

        }

        public DataTable PMToolsView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter PmToolsViePM = new SprMaintenanceLoadViewTableAdapter();
            return PmToolsViePM.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);

        }

        public void PmTollsCostinsert(int Reffno, string ToolsID, string description, decimal hour, int intenroll, int intjobid, int intdept)
        {
            TblPMSPartsTableAdapter PMTollsEqipInser = new TblPMSPartsTableAdapter();
            PMTollsEqipInser.PMToolsEqeipments(Reffno, ToolsID, description, hour, intenroll, intjobid, intdept);
        }

        public DataTable PMToolsWOView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter WOPMViewtools = new SprMaintenanceLoadViewTableAdapter();
            return WOPMViewtools.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);

        }

        public void dgvToolsdelete(int intIdParts, int intjobid, int intdept)
        {
            TblWOMaintenancePartsTableAdapter ToolsequopmentD =new  TblWOMaintenancePartsTableAdapter();
            ToolsequopmentD.WOToolsEquipmentDeleteQ(intIdParts, intjobid, intdept);
        }

        public DataTable CorrectiveUserRequestDetalisView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter CorrectiveUserDetalis = new SprMaintenanceLoadViewTableAdapter();
            return CorrectiveUserDetalis.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
 
        }



        public DataTable IndentWareHouse(int intEnroll)
        {
            IndentWHNameTableAdapter indentwh = new IndentWHNameTableAdapter();
            return indentwh.IndentWhareHouseGetData(intEnroll);
        }

        public DataTable CorporateMaintenancePOWorkOrder(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter MaintennacePO = new SprMaintenanceLoadViewTableAdapter();
            return MaintennacePO.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable FactoryPoWorkMaintenanceView(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter FactoryMaintennacePO = new SprMaintenanceLoadViewTableAdapter();
            return FactoryMaintennacePO.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public string PoServiceIndent(string xmlString, int Mnumber, int whid, int intenroll, int intunitid, int intjobid, int dept)
        {
            SprAsetServiceXMLTableAdapter poindent = new SprAsetServiceXMLTableAdapter();
            poindent.PoServiceIndentXMLGetData(xmlString, Mnumber, whid, intenroll, intunitid, intjobid, dept);
            string msg = "Successfully";
            return msg;
        }

        public DataTable Indentview(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter Indentview = new SprMaintenanceLoadViewTableAdapter();
            return Indentview.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable CheckPartsItemNumber(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter CheckSpare = new SprMaintenanceLoadViewTableAdapter();
            return CheckSpare.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }



        public DataTable ReportpageAssetTypeName(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter AssetType = new SprMaintenanceLoadViewTableAdapter();
            return AssetType.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable AssetregisterAllReportt(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter ReportAll = new SprMaintenanceLoadViewTableAdapter();
            return ReportAll.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable ReportDetalisParts(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter PartsDetalis = new SprMaintenanceLoadViewTableAdapter();
            return PartsDetalis.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable ReportDetalisPerformer(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter PerformerDetlis = new SprMaintenanceLoadViewTableAdapter();
            return PerformerDetlis.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public void UpdateMilege(string presentM, string nextM, string vehicleNumber)
        {
            TblUpdateAssetMaintenanceTableAdapter vehiclemIlege = new TblUpdateAssetMaintenanceTableAdapter();
            vehiclemIlege.UpdateVehicleMilege(presentM, nextM, vehicleNumber);
        }

        public DataTable MilegeViewTextbox(string vehicleNumber)
        {
            TblCheckAssetTypeTableAdapter checktype = new TblCheckAssetTypeTableAdapter();
            return checktype.CheckAssetTypeGetData(vehicleNumber);
        }

        public DataTable ViewServiceData(int serviceID)
        {
            TblCheckAssetTypeTableAdapter viewserviceName = new TblCheckAssetTypeTableAdapter();
           return viewserviceName.ViewServiceNameViewGetData(serviceID);
        }

        public void UpdatePMServiceName(string serviceName, decimal cost, int serviceID)
        {
            TblPMServiceNameTableAdapter updateservice = new TblPMServiceNameTableAdapter();
            updateservice.UpdatePMServiceNamewithCost(serviceName, cost, serviceID);
        }

        public DataTable commonrepairsView(int repairsID)
        {
            TblCheckAssetTypeTableAdapter commonrepView = new TblCheckAssetTypeTableAdapter();
            return commonrepView.ViewCommonRepirsGetData(repairsID);
        }

        public void UpdateCommonRepairsItem(string repairsName, decimal repairsCost, int repairsID)
        {
            TblPMServiceNameTableAdapter updatecommon = new TblPMServiceNameTableAdapter();
            updatecommon.UpdateCommonRepairsCost(repairsName, repairsCost, repairsID);
        }

        public DataTable CommonServiceCostView(int serviceiD)
        {
            TblCheckAssetTypeTableAdapter viewcostM = new TblCheckAssetTypeTableAdapter();
            return viewcostM.MaintencetaskCommonViewCostGetData(serviceiD);
        }

        public DataTable MaintenanceBillAssetDetalis(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter AssetBillDetalis = new SprMaintenanceLoadViewTableAdapter();
            return AssetBillDetalis.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);
        }

        public DataTable MaintenanceBillServiceCharge(int intItem, int Mnumber, int intenroll, int intjobid, int intdept)
        {
            SprMaintenanceLoadViewTableAdapter serviceCharge = new SprMaintenanceLoadViewTableAdapter();
            return serviceCharge.TaskGridViewGetData(intItem, Mnumber, intenroll, intjobid, intdept);

        }

        public DataTable ACWownBillingUnit()
        {
            TblBillingCodeTableAdapter acwbill = new TblBillingCodeTableAdapter();
            return acwbill.AcwOwnBillingGetData();
        }

        public DataTable InterCompanyBillunit()
        {
            TblBillingCodeTableAdapter aInterCbill = new TblBillingCodeTableAdapter();
            return aInterCbill.InterCompannyBillGetData();
        }

        public DataTable UnitName()
        {
            TblUnitNameTableAdapter unitname = new TblUnitNameTableAdapter();
            return unitname.UnitNameGetData();
        }

        public DataTable ViewVehicleUnitwaise(int job)
        {
            TblVehicleViewTableAdapter vehicleviews = new TblVehicleViewTableAdapter();
            return vehicleviews.VehicleViewGetData(job);
        }

        public DataTable UitbyJobstation(int unit)
        {
            TblUnitNameTableAdapter JobstationNames = new TblUnitNameTableAdapter();
            return JobstationNames.UnitbyJobstationNameGetData(unit);
        }

        public DataTable UnitByCostCenter(int unit)
        {
            TblUnitNameTableAdapter UnitCostCenter = new TblUnitNameTableAdapter();
            return UnitCostCenter.CostCenterUnitByGetData(unit);
        }

        public string UpdateAssetAccoAID(string xmlStringAssetAccoA, Int64 coaCodeID, int unit, int costcenter, int intenroll)
        {
            SprAsetACOAXMLTableAdapter updateACCOID = new SprAsetACOAXMLTableAdapter();
            updateACCOID.SprAssetAccIDUpdateGetData(xmlStringAssetAccoA, coaCodeID, unit, costcenter, intenroll);
            string message = "Successfully";
            return message;
        }

       

        public DataTable GlobalCOAView(int intType, int p1,DateTime dtestart,DateTime dtesend, int unitid, int p4)
        {
            SprDepreciationConfigTableAdapter coav= new SprDepreciationConfigTableAdapter();
            return coav.DepreciationConfigGetData(intType, Convert.ToString(0), Convert.ToDateTime(dtestart), Convert.ToDateTime(dtesend), unitid, p4);
        }

        public DataTable AssetType()
        {
            AssetTypeTableAdapter assetstype = new AssetTypeTableAdapter();
            return assetstype.AssetTypeGetData();
        }

        

        public DataTable AssetViewforGlobalCOA(int intType, string  xmlunit, DateTime sdate, DateTime edate, int jobid, int assetid)
        {
            SprDepreciationConfigTableAdapter assetvCoa = new SprDepreciationConfigTableAdapter();
            return assetvCoa.DepreciationConfigGetData(intType, xmlunit, sdate, edate, jobid, assetid);
        }

        public string UpdateAssetGlobalCOA(string xmlStringAssetAccoA, long coaCodeID, int type, int costcenter, int intenroll)
        {
            SprAsetACOAXMLTableAdapter updateGlobalCOA= new SprAsetACOAXMLTableAdapter();
            updateGlobalCOA.SprAssetAccIDUpdateGetData(xmlStringAssetAccoA, coaCodeID, type, costcenter, intenroll);
            string message = "Successfully";
            return message;
        }



        public DataTable XmlDepcerationConfig(int intType, string XmlStringDEP, DateTime dtefrom, DateTime dtesend, int unitid, int enroll)
        {
            SprDepreciationConfigTableAdapter depress = new SprDepreciationConfigTableAdapter();
            try { return depress.DepreciationConfigGetData(intType, XmlStringDEP, Convert.ToDateTime(dtefrom), Convert.ToDateTime(dtesend), unitid, enroll); }
            catch { return new DataTable(); }
        }

        public DataTable CheckDepreciation(int p1, int p2, DateTime dtefrom, DateTime dteenddate, int unitid, int enroll)
        {
            SprDepreciationConfigTableAdapter depcheck = new SprDepreciationConfigTableAdapter();
            try { return depcheck.DepreciationConfigGetData(5, Convert.ToString(0), Convert.ToDateTime(dtefrom), Convert.ToDateTime(dteenddate), unitid, enroll); }
            catch { return new DataTable(); }
        }

        public DataTable BRTAVehicleType()
        {
            TblUnitNameTableAdapter brta = new TblUnitNameTableAdapter();
            return brta.BrtaVehicleTypeGetData();
        }

        public DataTable ViewVehicleUnit(int unit)
        {
            TblVehicleViewTableAdapter vehicleunits = new TblVehicleViewTableAdapter();
            return vehicleunits.VehicleViewUnitRenewUpGetData(unit);
        }



        public DataTable FinencialYearlist(int intType, int p1, DateTime dtefrom, DateTime dteenddate, int unitid, int p2)
        {
            try
            {
                SprDepreciationConfigTableAdapter fy = new SprDepreciationConfigTableAdapter();
                return fy.DepreciationConfigGetData(intType, Convert.ToString(p1), dtefrom, dteenddate, unitid, p2);
            }
            catch { return new DataTable(); }
        }

        public DataTable DepreciationView(int intType, string  fyear, DateTime dtefrom, DateTime dteenddate, int unitid, int type)
        {
            try
            {
                SprDepreciationConfigTableAdapter depview = new SprDepreciationConfigTableAdapter();
                return depview.DepreciationConfigGetData(intType, Convert.ToString(fyear), dtefrom, dteenddate, unitid, type);
            }
            catch { return new DataTable(); }
        }

        public DataTable DepreciationSumeryCOA(int intType, string fyear, DateTime dtefrom, DateTime dteenddate, int unitid, int type)
        {
            try
            {
                SprDepreciationConfigTableAdapter depview = new SprDepreciationConfigTableAdapter();
                return depview.DepreciationConfigGetData(intType, Convert.ToString(fyear), dtefrom, dteenddate, unitid, type);
            }
            catch { return new DataTable(); }
        }

        public void UpdateAsstList( int gcoaid, DateTime dteacisition, decimal acusutionValue, decimal acumulatedDep, int costid,int enroll,decimal deprate,string assetid)
        {
            try { TblUpdateAccountsAssetRegisterTableAdapter updateacc = new TblUpdateAccountsAssetRegisterTableAdapter();

            updateacc.UpdateAssetAccountsGetData(gcoaid, dteacisition, acusutionValue, acumulatedDep,costid, enroll,deprate, assetid);
            }
            catch {  new  DataTable(); }
        }

        public DataTable CheckCorporate(int intenroll)
        {
            TblUnitNameTableAdapter checkcorporates = new TblUnitNameTableAdapter();
            return checkcorporates.checkUserCorporateGetData(intenroll);
        }

        public DataTable UserUnitName(int unit)
        {
            TblUnitNameTableAdapter unitnamess = new TblUnitNameTableAdapter();
            return unitnamess.UserUnitGetData(unit);
        }

        public DataTable UserJobstation(int jobstation)
        {
            TblUnitNameTableAdapter jobstationss = new TblUnitNameTableAdapter();
            return jobstationss.UserByJobatationGetData(jobstation);
        }

        public List<string> AutoSearchBRTAVheicleType(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprBRTAVheicleTypeSearchingTableAdapter objSprAutoSearchJobstation = new SprBRTAVheicleTypeSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = objSprAutoSearchJobstation.GetDataBRTAVheicleType(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strItem"].ToString());
                }

            }
            return result;
        }

        public DataTable JobStation()
        {
            try
            {
                TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
                return adp.GetJobStationData();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetServiceData(int jobcard)
        {
            try
            {
                tblMaintenanceTaskTableAdapter adp = new tblMaintenanceTaskTableAdapter();
                return adp.GetDataByJobCard(jobcard);
            }
            catch { return new DataTable(); }
        }

        public string UpdateMoney(decimal amount,int serviceID)
        {
            string msg = "";
            try
            {
                TblMaintenanceTaskTableAdapter adp = new TblMaintenanceTaskTableAdapter();
                adp.UpdateMoneyByJobCard(amount,serviceID);
                return msg = "Amount Updated Successfully";
            }
            catch(Exception ex) { return msg = ex.Message.ToString(); }
        }
        public string UpdateFixedAssetRegisterUnit(int unit,int jobstation,string assetCode)
        {
            string msg = "";
            try
            {
                TblFixedAssetRegisterTableAdapter adp = new TblFixedAssetRegisterTableAdapter();
                adp.UpdateFixedAssetRegUnit(unit, jobstation,assetCode);
                return msg = "Unit Updated Successfully";
            }
            catch (Exception ex) { return msg = ex.Message.ToString(); }
        }
        public string UpdateAssetMaintenanceUnitByJobCard(int unit,int jobstation, int jobcard)
        {
            string msg = "";
            try
            {
                TblAssetMaintenanceTableAdapter adp = new TblAssetMaintenanceTableAdapter();
                adp.UpdateAssetUnitByJobCard(unit,jobstation, jobcard);
                return msg = "Unit Updated Successfully";
            }
            catch (Exception ex) { return msg = ex.Message.ToString(); }
        }

    }
    }
