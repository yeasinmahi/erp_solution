using Purchase_DAL.VehicleRegRenewal.VehicleRenewal_DALTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Purchase_BLL.VehicleRegRenewal_BLL
{
    public class RegistrationRenewals_BLL
    {
        public DataTable BrtaItemDropdown()
        {
            TblBRTAItemNameTableAdapter drodown = new TblBRTAItemNameTableAdapter();
            return drodown.VehicleBrtaItemGetData();
        }

        public DataTable detalisview(int itemid)
        {
            TblBRTAProfileTableAdapter detalis = new TblBRTAProfileTableAdapter();
            return detalis.BRTAProfileGetData(itemid);
        }

        public DataTable unitnamewithAssetname(string assetid)
        {
            UnitandAssetNameDataTableTableAdapter assetdetalis = new UnitandAssetNameDataTableTableAdapter();
            return assetdetalis.UnitNameWithAssetNameGetData(assetid);
        }

        public DataTable UnitNameGet()
        {
            UnitNameDataTableTableAdapter unitname = new UnitNameDataTableTableAdapter();
            return unitname.UnitNameGetData();
        }

        public DataTable InsertVehicleRegistration(int intItem,string assetid,string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {
            try
            {
                SPVehicleRenewalTableAdapter registrationsTax = new SPVehicleRenewalTableAdapter();
                return registrationsTax.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                      ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);

            }
            catch { return new DataTable(); }
            
        }

        public DataTable InsertVehicleTaxTokenInsert(int intItem,string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {
            try
            {
                SPVehicleRenewalTableAdapter registrations = new SPVehicleRenewalTableAdapter();

              return  registrations.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                    ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            }
            catch { return new DataTable(); }
            
        }

        public DataTable InsertVehicleFitness(int intItem, string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {
            try
            {
                SPVehicleRenewalTableAdapter fiteness = new SPVehicleRenewalTableAdapter();

                return fiteness.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                     ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            }
            catch { return new DataTable(); }
           
        }

        public DataTable InsertVehicleRootpermit(int intItem, string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {
            try
            {
                SPVehicleRenewalTableAdapter rootpermit = new SPVehicleRenewalTableAdapter();

               return rootpermit.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                    ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
            }
            catch { return new DataTable(); }
            
        }

        public DataTable InsertVehicleInsurance(int intItem, string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc
            , decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {

 
           SPVehicleRenewalTableAdapter Insurance = new SPVehicleRenewalTableAdapter();

            return  Insurance.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
   
        }

        public DataTable InsertVehicleNamePlate(int intItem, string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {

            SPVehicleRenewalTableAdapter NmaPlate = new SPVehicleRenewalTableAdapter();

           return NmaPlate.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
        }



        public DataTable RegistrtionReportForSubmit(int intItem, string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {
            SPVehicleRenewalTableAdapter ReportReg = new SPVehicleRenewalTableAdapter();

           return  ReportReg.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);

        }

       

        

        public DataTable ReportRegistrationView(int intItem, string assetid, string strtype, int intType, string unit, DateTime dtereg, DateTime expairdate, DateTime nextExpairdate, int expDay, decimal registrationTaka, decimal nameplate, decimal drc, decimal ownership, decimal addresschange, decimal bodyvat, decimal certificate, string certificatedNo, decimal duplicatedcopy, decimal miscellounes)
        {
            SPVehicleRenewalTableAdapter ReportViewRegistrationV= new SPVehicleRenewalTableAdapter();
            return ReportViewRegistrationV.SPInsertDataGetData(intItem, assetid, strtype, intType, unit, dtereg, expairdate, nextExpairdate, expDay, registrationTaka, nameplate, drc,
                 ownership, addresschange, bodyvat, certificate, certificatedNo, duplicatedcopy, miscellounes);
        }

       


        public void UpdateBRTAProfile(decimal refistrationfee, decimal nameplate, decimal ownership, decimal addresschange, decimal certificatecopy, decimal duplicatecertifite, decimal registrationMisc, decimal taxtokenfee, decimal taxtokenLatefine3_1, decimal taxtokenLatefine6_2, decimal taxtokenLatefine6_3, decimal taxtokenmisscellenous, decimal fitenssfee, decimal fitnessLate, decimal fitnessMisc, decimal AIT, decimal insurancefee, decimal routepermit, decimal routelatefine, decimal routepermitMisc, decimal bodyvat, decimal DRC, int enroll, int itemid)
        {
            TblBRTAProfileUpdateTableAdapter updateBrta = new TblBRTAProfileUpdateTableAdapter();
            updateBrta.BRTAProfileUpdateGetData(refistrationfee, nameplate, ownership, addresschange, certificatecopy, duplicatecertifite, registrationMisc, taxtokenfee,
            taxtokenLatefine3_1, taxtokenLatefine6_2, taxtokenLatefine6_3, taxtokenmisscellenous, fitenssfee, fitnessLate, fitnessMisc, AIT, insurancefee,
            routepermit, routelatefine, routepermitMisc, bodyvat, DRC, enroll, itemid);
        }

        public DataTable RenewalDetalis(int IDs)
        {
            TblVehicleRenewalCofigureViewTableAdapter dtview = new TblVehicleRenewalCofigureViewTableAdapter();
            return dtview.ViewDataLabelGetData(IDs);
        }

        public DataTable totalDetalisView(int IDs)
        {
            DataTableTotalGridViewTableAdapter totalviews = new DataTableTotalGridViewTableAdapter();
            return totalviews.TotalViewGridGetData(IDs);
        }

        public DataTable RouteTransportCostDet(DateTime dtefromdate,DateTime dttodate)
        {
            SprRouteTransportCostDetTableAdapter bll = new SprRouteTransportCostDetTableAdapter();
          return  bll.GetDatasprRouteTransportCostDet(dtefromdate, dttodate);
        }
        public DataTable RouteTransportCostDetAssetidbase(string assetid)
        {
            SprTransportRouteCostAssetidBaseTableAdapter bll = new SprTransportRouteCostAssetidBaseTableAdapter();
            return bll.GetDatasprTransportRouteCostAssetidBase(assetid);
        }
        public string UpdateAuditAprvStaus(bool ysnaprvaudit,int auditarpvby ,int autoid,int deptid)
        {
            string msg = "";
            try
            {
                SprAuditAprvStatusforVheicleRenewalCostTableAdapter updatevhrenewal = new SprAuditAprvStatusforVheicleRenewalCostTableAdapter();
                updatevhrenewal.GetDataAprvsprAuditAprvStatusforVheicleRenewalCost(ysnaprvaudit, auditarpvby, autoid, deptid, ref msg);
                return msg;

            }
            catch (Exception ex) { return ex.ToString(); }
        }
     
        public List<string> AutoSearchAssetName(string strSearchKey )
        {
            List<string> result = new List<string>();
            SprAssetNameSearchingTableAdapter objSprAutoSearchAsset = new SprAssetNameSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = objSprAutoSearchAsset.GetDatasprAssetNameSearching(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strNameOfAsset"].ToString());
                }

            }
            return result;
        }

        public string FixedDataLandInfoinsert(string xmlString, int Enrol, int unit, int jobstation,string assetid )
        {
            string msg = "";
            try
            {
                SprFixedAssetLandRegisterDetaillsTableAdapter bll = new SprFixedAssetLandRegisterDetaillsTableAdapter();
                bll.GetDatasprFixedAssetLandRegisterDetaills(xmlString, Enrol, unit, jobstation, assetid, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public DataTable dagvslandstatus(int dagid)
        {
            try
            {
                SprDagVsLandStatusTableAdapter bll = new SprDagVsLandStatusTableAdapter();
                return bll.GetDatasprDagVsLandStatus(dagid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetDataDagCategory()
        {
            try
            {
                TblDagCategoryTableAdapter bll = new TblDagCategoryTableAdapter();
                return bll.TblDagCategory();
            }
            catch { return new DataTable(); }
        }
        public DataTable RouteTransportCostDetAssetidbasePendinginHeadEnd(string assetid)
        {
            SprTransportRouteCostdataPendingAprvInDeptHeadEndTableAdapter bll = new SprTransportRouteCostdataPendingAprvInDeptHeadEndTableAdapter();
            return bll.GetDatasprTransportRouteCostdataPendingAprvInDeptHeadEnd(assetid);
        }
        public DataTable RouteTransportCostDataApproveforDptHead(DateTime dtfromdate,DateTime dttodate,bool aprvstatus,int unitid)
        {
            try
            {
                SprTransportRouteCostdataPendingAprvforDptHeadTableAdapter bll = new SprTransportRouteCostdataPendingAprvforDptHeadTableAdapter();
                return bll.GetDatasprTransportRouteCostdataPendingAprvforDptHead(dtfromdate,  dttodate,  aprvstatus, unitid);
            }
            catch { return new DataTable(); }
        }

        public string UpdateDeptHeadAprvStaus(int aprvhead, int auditarpvby, int deptid, DateTime fromdate, DateTime todate, int aprvorrejectid, int autoid,int intpartid,int unitid )
        {
            string msg = "";
            try
            {
                SprTransportcostaprvbyHeadofDeptTableAdapter updatevhrenewal = new SprTransportcostaprvbyHeadofDeptTableAdapter();
                updatevhrenewal.GetDatasprTransportcostaprvbyHeadofDept(aprvhead, auditarpvby, deptid, fromdate, todate, aprvorrejectid, autoid, intpartid,  unitid, ref msg);
                return msg;

            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public DataTable RouteTransportCostDataApproveforDptHeadForRenewal(int partid,int unitid,int jobstationid, DateTime dtfromdate, DateTime dttodate,  bool ysnheadaprvstatus)
        {
            try
            {
                SprTransportRouteCostdataPendingAprvforDptHeadforRenewalTableAdapter bll = new SprTransportRouteCostdataPendingAprvforDptHeadforRenewalTableAdapter();
                return bll.GetDatasprTransportRouteCostdataPendingAprvforDptHeadforRenewal(partid,  unitid,  jobstationid,  dtfromdate,  dttodate, ysnheadaprvstatus);
            }
            catch { return new DataTable(); }
        }
        public DataTable RouteTransportCostDataApproveforDptHeadForRegistration(int partid, int unitid, int jobstationid, DateTime dtfromdate, DateTime dttodate,int typeid, bool ysnheadaprvstatus)
        {
            try
            {
                SprTransportRouteCostdataPendingAprvforDptHeadforRegistrationTableAdapter bll = new SprTransportRouteCostdataPendingAprvforDptHeadforRegistrationTableAdapter();
                return bll.GetDataTransportRouteCostdataPendingAprvforDptHeadforRegistration(partid, unitid, jobstationid, dtfromdate, dttodate, typeid, ysnheadaprvstatus);
            }
            catch { return new DataTable(); }
        }


        public string transportcostrejectbyheadofdept(int aprvhead, int auditarpvby, int deptid, DateTime fromdate, DateTime todate, int aprvorrejectid, int autoid, int intpartid, int unitid)
        {
            //@intAprv int, @intAprvBy int, @deptid int, @dtefromdate date,@dtetodate date, @intrepttype int, @intautoid int, @intPartid int, @unit int, @strMessage varchar(200) out
            string msg = "";
            try
            {
                SprTranscostrejectbyheadofdeparmentTableAdapter updatevhrenewal = new SprTranscostrejectbyheadofdeparmentTableAdapter();
                updatevhrenewal.GetDataTranscostrejectbyheadofdeparment(aprvhead, auditarpvby, deptid, fromdate, todate, aprvorrejectid, autoid, intpartid, unitid, ref msg);
                return msg;

            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public DataTable RouteTransportCostDelete(string assetid)
        {
            SprTransportRouteCostInactiveTableAdapter bll = new SprTransportRouteCostInactiveTableAdapter();
            return bll.GetData(assetid);
        }

        public string transportcostdeletebyuser(int reconfigid, int deleteby)
        {
            string msg = "";
            try
            {
                SprTransportRouteCostDeleteByUserTableAdapter delrenwal = new SprTransportRouteCostDeleteByUserTableAdapter();
                delrenwal.GetData(reconfigid, deleteby, ref msg);
                return msg;

            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public List<string> AutoSearchJobStationName(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprJobStationSearchingTableAdapter objSprAutoSearchJobstation = new SprJobStationSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = objSprAutoSearchJobstation.GetDataJostationSearching(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strJobStationName"].ToString());
                }

            }
            return result;
        }

        public List<string> AutoSearchVheicleName(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprVheicleNameSearchingTableAdapter objSprAutoSearchJobstation = new SprVheicleNameSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = objSprAutoSearchJobstation.GetData(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strRegNo"].ToString());
                }

            }
            return result;
        }
        public DataTable Vheicleinfo(string assetid)
        {
            SprVheicleInformationTableAdapter bll = new SprVheicleInformationTableAdapter();
            return bll.GetData(int.Parse(assetid));
        }
        public string insertmntcost(string xmlString, DateTime date,  int enrol, int unit)
        {
            string msg = "";

            try
            {
                SprOwnVhclMntCostEntryTableAdapter bll = new SprOwnVhclMntCostEntryTableAdapter();
                bll.GetData(xmlString, date, enrol, unit,  ref msg);

                return msg;
            }

            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetOwnvhclMntCost(DateTime frm,DateTime todate,int unitid,int rpttype )
        {
            SprOwnVhclMntCostRptTableAdapter bll = new SprOwnVhclMntCostRptTableAdapter();
            return bll.GetData(frm, todate, unitid, rpttype);
        }

        public DataTable Getownvheicleincomeandexpense(DateTime frm,DateTime todate,int unitid ,int rpttype)
        {
            try
            {
                SprOwnVhclIncomeAndExpenseTableAdapter bll = new SprOwnVhclIncomeAndExpenseTableAdapter();
                return bll.GetData(frm, todate, unitid, rpttype);

            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetAssetAprvPermission(int deptid)
        {

            try
            {
                SprAssetBillAprvPermissionTableAdapter dtview = new SprAssetBillAprvPermissionTableAdapter();
                return dtview.GetDataAssetBillAprvPermission(deptid);
            }
            catch
            {
                return new DataTable();
            }
           
        }


        public List<string> AutoSearchVhcleName(string strSearchKey)
        {
            List<string> result = new List<string>();
            SprAssetNameSearchingTableAdapter objSprAutoSearchAsset = new SprAssetNameSearchingTableAdapter();
            DataTable oDT = new DataTable();
            oDT = objSprAutoSearchAsset.GetDatasprAssetNameSearching(strSearchKey);
            if (oDT.Rows.Count > 0)
            {
                for (int index = 0; index < oDT.Rows.Count; index++)
                {
                    result.Add(oDT.Rows[index]["strNameOfAsset"].ToString());
                }

            }
            return result;
        }
    }
}
