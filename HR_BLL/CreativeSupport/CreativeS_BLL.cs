using HR_DAL.CreativeSupport.CreativeS_DALTableAdapters;
//using HR_DAL.CreativeS_TDSTableAdapters;
using System;
using System.Data;
using System.Linq;
using static HR_DAL.CreativeSupport.CreativeS_DAL;

namespace HR_BLL.CreativeSupport
{
    public class CreativeSBll
    {
        DataTable _tbl;
        int _e;
        private static ItemListForCreativeSDataTable[] _tblCrItem = null;
        private static EmpListForCreativeSupportDataTable[] _tblEmpListForCs = null;

        public DataTable GetJobDescription()
        {
            JobDesctionListTableAdapter adp = new JobDesctionListTableAdapter();
            try
            { return adp.GetJobDescription(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetLoginInfo(int intEnroll)
        {
            LoginUserInfoTableAdapter adp = new LoginUserInfoTableAdapter();
            try
            { return adp.GetLoginInfo(intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public string[] AutoSearchItemCrList(string prefix)
        {
            prefix = prefix.Trim().ToLower();
            string intUnitId = "1";

            _tblCrItem = new ItemListForCreativeSDataTable[Convert.ToInt32(intUnitId)];
            ItemListForCreativeSTableAdapter adpCoa = new ItemListForCreativeSTableAdapter();
            _tblCrItem[_e] = adpCoa.GetCreativeItemList();

            DataTable tbl = new DataTable();
            if (prefix.Length >= 3)
            {
                try
                {
                    var rows = from tmp in _tblCrItem[_e]  //[Convert.ToInt32(ht[WHID])]
                               where tmp.strCreativeItemName.ToLower().Contains(prefix) || tmp.intCreativeItemID.ToString().ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                               orderby tmp.strCreativeItemName
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch { return null; }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strCreativeItemName"] + " [" + tbl.Rows[i]["intCreativeItemID"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }
        public string[] AutoEmpListForCreativeSupport(string prefix)
        {
            string intUnitId = "1";
            int unit = Int32.Parse(intUnitId.ToString());

            _tblEmpListForCs = new EmpListForCreativeSupportDataTable[Convert.ToInt32(intUnitId)];
            EmpListForCreativeSupportTableAdapter adpCoa = new EmpListForCreativeSupportTableAdapter();
            _tblEmpListForCs[_e] = adpCoa.GetEmpListForCreativeSupport();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in _tblEmpListForCs[_e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
                               select tmp;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                else
                {
                    try
                    {
                        var rows = from tmp in _tblEmpListForCs[_e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) || tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strEmployeeName
                                   select tmp;
                        if (rows.Any())
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
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["strDesignation"] + "]" + " [" + tbl.Rows[i]["intEmployeeID"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }

        public string InsertAllBillApproval(int intAssignBy, DateTime dteRequiredDate, TimeSpan tmRequiredTime, int intAssignTo, int intJobDescriptionId, string strJobType, int intTotalPoint, string strRemarks, string xmlItem, string xmlDoc, int intPoid)
        {
            try
            {
                string msg = "";
                SprCreativeSupportEntryTableAdapter adp = new SprCreativeSupportEntryTableAdapter();
                adp.InsertCreativeSupport(intAssignBy, dteRequiredDate, tmRequiredTime, intAssignTo, intJobDescriptionId, strJobType, intTotalPoint, strRemarks, xmlItem, xmlDoc, intPoid, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetItemWisePoint(int intItemId)
        {
            GetPointTableAdapter adp = new GetPointTableAdapter();
            try
            { return adp.GetItemWisePoint(intItemId); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetJobTypeWisePoint(string strJobType)
        {
            GetPointTableAdapter adp = new GetPointTableAdapter();
            try
            { return adp.GetJobTypeWisePoint(strJobType); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetReportForDashboard()
        {
            ReportForDashboardWithoutCompleteTableAdapter adp = new ReportForDashboardWithoutCompleteTableAdapter();
            try
            { return adp.GetReportForDashboard(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetStatusList()
        {
            StatusListTableAdapter adp = new StatusListTableAdapter();
            try
            { return adp.GetStatusList(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetJobDetailsR(int intPart, int intJobId)
        {
            SprCreativeSupportReportForViewDetailsTableAdapter adp = new SprCreativeSupportReportForViewDetailsTableAdapter();
            try
            { return adp.GetJobDetailsR(intPart, intJobId); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string UpdateJobStatus(int intPart, int intJobId, int intJobStatusId, string strStatus, string strStatusRemarks, int intInsertBy, string xmlDoc)
        {
            try
            {
                string msg = "";
                SprCreativeSupportStatusUpdateTableAdapter adp = new SprCreativeSupportStatusUpdateTableAdapter();
                adp.UpdateJobStatus(intPart, intJobId, intJobStatusId, strStatus, strStatusRemarks, intInsertBy, xmlDoc, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetAllReport(int intPart, int intReceiver, DateTime dteFrom, DateTime dteTo)
        {
            SprCreativeSupportAllReportTableAdapter adp = new SprCreativeSupportAllReportTableAdapter();
            try
            { return adp.GetAllReport(intPart, intReceiver, dteFrom, dteTo); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string ItemCreateAndPointSet(int intPart, string strItemName, int intPoint, int intId)
        {
            try
            {
                string msg = "";
                SprItemCreateAndPointSetTableAdapter adp = new SprItemCreateAndPointSetTableAdapter();
                adp.ItemCreateAndPointSet(intPart, strItemName, intPoint, intId, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetCreativeItemListForDdl()
        {
            ItemListForCreativeSTableAdapter adp = new ItemListForCreativeSTableAdapter();
            try
            { return adp.GetCreativeItemList(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetAllDocumentView(int intJobId)
        {
            AllDocViewTableAdapter adp = new AllDocViewTableAdapter();
            try
            { return adp.GetAllDocumentView(intJobId); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public bool DisableCreativeSupport(int intJobId)
        {
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            try
            {
                 adp.DisableCreativeSupport(intJobId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
