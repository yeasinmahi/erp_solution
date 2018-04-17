
using Projects_DAL.DairyDALTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects_BLL
{
    public class Project_Class
    {
        public DataTable GetEventList(int intUnitid) 
        {
            return new DataTable();
            //DropDownListTableAdapter adp = new DropDownListTableAdapter();
            //try
            //{ return adp.GetEventData(intUnitid); }
            //catch { return new DataTable(); }
        }
        public DataTable GetEventTypeList() 
        {
            return new DataTable();
            //DropDownListTableAdapter adp = new DropDownListTableAdapter();
            //try
            //{ return adp.GetEventTypeData(); }
            //catch { return new DataTable(); }
        }
        public DataTable GetBrandList() 
        {
            return new DataTable();
            //DropDownListTableAdapter adp = new DropDownListTableAdapter();
            //try
            //{ return adp.GetBrandData(); }
            //catch { return new DataTable(); }
        }
        public DataTable GetDepartmentList(int intUnitid) 
        {
            //DropDownListTableAdapter adp = new DropDownListTableAdapter();
            //try
            //{ return adp.GetDepartmentData(intUnitid); }
            //catch { return new DataTable(); }
            return new DataTable();
        }
        public DataTable GetActivityList(int intEventTypeid , int intUnitid) 
        {
            return new DataTable();
            //DropDownListTableAdapter adp = new DropDownListTableAdapter();
            //try
            //{ return adp.GetActivityData(intEventTypeid, intUnitid); }
            //catch { return new DataTable(); }
        }
        public string InsertEntry(int intPart, int intUnitid, int intDeptid, int intEventid, int intTypeid, int intLocationid, string strLocation, int intBrandid,
            DateTime dtePlan, int intActionBy, string xml, DateTime dtePlanF, DateTime dtePlanT, decimal numAdvAmount)
        {
            string msg = "";
            //SprProjectEntryTableAdapter adp = new SprProjectEntryTableAdapter();
            //adp.InsertEntry(intPart, intUnitid, intDeptid, intEventid, intTypeid, intLocationid, strLocation, intBrandid, 
            //dtePlan, intActionBy, xml, dtePlanF, dtePlanT, numAdvAmount, ref msg);
            return msg;
        }
        public DataTable GetReportForApprove(int intPart, int intUnitid, int intDept) 
        {
            //SprReportForEntryTableAdapter adp = new SprReportForEntryTableAdapter();
            //try
            //{ return adp.GetReportForApp(intPart, intUnitid, intDept); }
            //catch { return new DataTable(); }

            return new DataTable();
        }
        public DataTable GetAdvAmount(int intProjectid)  
        {
            //GetAdvAmountTableAdapter adp = new GetAdvAmountTableAdapter();
            //try
            //{ return adp.GetAdvAmount(intProjectid); } 
            //catch { return new DataTable(); }

            return new DataTable();
        }

        public DataTable GetChillingCenterName()
        {
            TblChillingCenterListTableAdapter adp = new TblChillingCenterListTableAdapter();
            try
            { return adp.GetChillingCenterList(); }
            catch { return new DataTable(); }
        }
        public DataTable GetVehicleListByCCID(int intCCID)
        {
            TblChillingCenterListTableAdapter adp = new TblChillingCenterListTableAdapter();
            try
            { return adp.GetVehicleListByCCID(intCCID); }
            catch { return new DataTable(); }
        }
        public DataTable GetDataForMRR(int intVehicleID, string dteDate, int intCCID)
        {
            TblMRRDataTableAdapter adp = new TblMRRDataTableAdapter();
            try
            { return adp.GetDataForMRR(intVehicleID, dteDate, intCCID); }
            catch { return new DataTable(); }
        }
        public string InsertMilkMrrForFactory(DateTime dteMRRDate, int intCCID, int intVehicleID, decimal decMRRFat, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprInsertDairyMilkMRRTableAdapter adp = new SprInsertDairyMilkMRRTableAdapter();
                adp.InsertMilkMrrForFactory(dteMRRDate, intCCID, intVehicleID, decMRRFat, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetDataForAudit(string dteFromDate, string dteTo, int intCCID)
        {
            TblChillingCenterListTableAdapter adp = new TblChillingCenterListTableAdapter();            
            try
            { return adp.GetDataForAudit(dteFromDate, dteTo, intCCID); }
            catch { return new DataTable(); }
        }
        public DataTable GetMRRDetailsForAudit(int intMRRID)
        {
            TblChillingCenterListTableAdapter adp = new TblChillingCenterListTableAdapter();
            try
            { return adp.GetMRRDetailsForAudit(intMRRID); }
            catch { return new DataTable(); }
        }
        public string AuditApprove(int intCCID, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprAuditApproveTableAdapter adp = new SprAuditApproveTableAdapter();
                adp.AuditApprove(intCCID, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        









    }
}
