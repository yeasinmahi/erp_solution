using HR_DAL.CreativeSupport.CreativeS_DALTableAdapters;
//using HR_DAL.CreativeS_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HR_DAL.CreativeSupport.CreativeS_DAL;

namespace HR_BLL.CreativeSupport
{
    public class CreativeS_BLL
    {
        DataTable tbl;
        int e;
        private static ItemListForCreativeSDataTable[] tblCRItem = null;
        private static EmpListForCreativeSupportDataTable[] tblEmpListForCS = null;
        
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

        public string[] AutoSearchItemCRList(string prefix)
        {
            string intUnitID = "1";
            int unit = Int32.Parse(intUnitID.ToString());

            tblCRItem = new ItemListForCreativeSDataTable[Convert.ToInt32(intUnitID)];
            ItemListForCreativeSTableAdapter adpCOA = new ItemListForCreativeSTableAdapter();
            tblCRItem[e] = adpCOA.GetCreativeItemList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblCRItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strCreativeItemName
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
                        var rows = from tmp in tblCRItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strCreativeItemName.ToLower().Contains(prefix) || tmp.intCreativeItemID.ToString().ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strCreativeItemName
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
                    retStr[i] = tbl.Rows[i]["strCreativeItemName"] + " [" + tbl.Rows[i]["intCreativeItemID"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }
        public string[] AutoEmpListForCreativeSupport(string prefix)
        {
            string intUnitID = "1";
            int unit = Int32.Parse(intUnitID.ToString());

            tblEmpListForCS = new EmpListForCreativeSupportDataTable[Convert.ToInt32(intUnitID)];
            EmpListForCreativeSupportTableAdapter adpCOA = new EmpListForCreativeSupportTableAdapter();
            tblEmpListForCS[e] = adpCOA.GetEmpListForCreativeSupport();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tblEmpListForCS[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
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
                        var rows = from tmp in tblEmpListForCS[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) || tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
                                   orderby tmp.strEmployeeName
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
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["strDesignation"] + "]" + " [" + tbl.Rows[i]["intEmployeeID"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }

        public string InsertAllBillApproval(int intAssignBy, DateTime dteRequiredDate, TimeSpan tmRequiredTime, int intAssignTo, int intJobDescriptionID, string strJobType, int intTotalPoint, string strRemarks, string xmlItem, string xmlDoc, int intPOID)
        {
            try
            {
                string msg = "";
                SprCreativeSupportEntryTableAdapter adp = new SprCreativeSupportEntryTableAdapter();
                adp.InsertCreativeSupport(intAssignBy, dteRequiredDate, tmRequiredTime, intAssignTo, intJobDescriptionID, strJobType, intTotalPoint, strRemarks, xmlItem, xmlDoc, intPOID, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetItemWisePoint(int intItemID)
        {
            GetPointTableAdapter adp = new GetPointTableAdapter();
            try
            { return adp.GetItemWisePoint(intItemID); }
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
        public DataTable GetJobDetailsR(int intPart, int intJobID)
        {
            SprCreativeSupportReportForViewDetailsTableAdapter adp = new SprCreativeSupportReportForViewDetailsTableAdapter();
            try
            { return adp.GetJobDetailsR(intPart, intJobID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string UpdateJobStatus(int intPart, int intJobID, int intJobStatusID, string strStatus, string strStatusRemarks, int intInsertBy, string xmlDoc)
        {
            try
            {
                string msg = "";
                SprCreativeSupportStatusUpdateTableAdapter adp = new SprCreativeSupportStatusUpdateTableAdapter();
                adp.UpdateJobStatus(intPart, intJobID, intJobStatusID, strStatus, strStatusRemarks, intInsertBy, xmlDoc, ref msg);
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
        public string ItemCreateAndPointSet(int intPart, string strItemName, int intPoint, int intID)
        {
            try
            {
                string msg = "";
                SprItemCreateAndPointSetTableAdapter adp = new SprItemCreateAndPointSetTableAdapter();
                adp.ItemCreateAndPointSet(intPart, strItemName, intPoint, intID, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetCreativeItemListForDDL()
        {
            ItemListForCreativeSTableAdapter adp = new ItemListForCreativeSTableAdapter();
            try
            { return adp.GetCreativeItemList(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetAllDocumentView(int intJobID)
        {
            AllDocViewTableAdapter adp = new AllDocViewTableAdapter();
            try
            { return adp.GetAllDocumentView(intJobID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        






    }
}
