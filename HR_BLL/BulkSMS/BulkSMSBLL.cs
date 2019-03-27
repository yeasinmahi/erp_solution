using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HR_DAL.BulkSMS.BulkSMSDALTableAdapters;
using HR_DAL.NewProject.New_ProjectTDSTableAdapters;
using HR_DAL.NewProject;
namespace HR_BLL.BulkSMS
{
    public class BulkSMSBLL
    {
        private static New_ProjectTDS.tblEmployeeDataTable[] tableEmpName = null;
       
        int e;
        public void getInsertBulkSMS(string strUserName, string strPassword, string strMaskingCli, string strOfficePhoneNo, string sms)
        {
            sprAPITableAdapter GetInsertsms = new sprAPITableAdapter();
            GetInsertsms.GetInsertSMSData(strUserName, strPassword, strMaskingCli, strOfficePhoneNo, sms);
            
        }

        public DataTable getUnitList()
        {
            try
            {
                tblUnitTableAdapter unit = new tblUnitTableAdapter();
                return unit.GetUnitName();
            }
            catch { return new DataTable(); }
        }

        public System.Data.DataTable getBulkSMSfilenname()
        {
            BulkSMSFileTableAdapter GetBulkSMSFilenameReport = new BulkSMSFileTableAdapter();
            return GetBulkSMSFilenameReport.GetBulkSMSFileNameData();
           
        }

        public DataTable getCostcenter(int v)
        {
            try {
                tblCostCenterTableAdapter CostCentername = new tblCostCenterTableAdapter();
                return CostCentername.GetUnitWiseCostcenter(v);
            } catch { return new DataTable(); }
        }
      
        public string[] getemployeenameslist(string unit, string prefix)
        {
            int strUnit = Int32.Parse(unit.ToString());
            //Inatialize(intwh);
            tableEmpName = new New_ProjectTDS.tblEmployeeDataTable[Convert.ToInt32(unit)];
            tblEmployeeTableAdapter adpCOA = new tblEmployeeTableAdapter();
            tableEmpName[e] = adpCOA.GetEmpAutoSearch();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmpName[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableEmpName[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || Convert.ToString(tmp.intEmployeeID).ToLower().Contains(prefix)
                                   orderby tmp.strEmployeeName
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }
        }

        public DataTable getProjectRpt(string txtpCode, int part)
        {
            try
            {
                sprProjectReportTableAdapter getPRpt = new sprProjectReportTableAdapter();
                return getPRpt.GetProjectRpt(txtpCode, part);
            }
            catch { return new DataTable(); }
        }

        public DataTable getPCodeRpt()
        {
            try {
                PCodeReportTableAdapter getpcode = new PCodeReportTableAdapter();
                return getpcode.GetPCodeReport();
            }
            catch { return new DataTable(); }
        }

        public DataTable getprojectcode(int intPCode)
        {
            try
            {
                ProjectCodeTableAdapter getproject = new ProjectCodeTableAdapter();
                return getproject.GetProjectCode(intPCode);
            }
            catch { return new DataTable(); }
        }

        public DataTable getItemlist(int v, string selectedValue)
        {
            try
            {
                int part =int.Parse(selectedValue);
                if (part == 1)
                {
                    TblitemServiceTableAdapter getItem = new TblitemServiceTableAdapter();
                    return getItem.GetItem(v);
                }
                else
                {
                    TblitemServiceTableAdapter getItem = new TblitemServiceTableAdapter();
                    return getItem.GetService(v);
                }
            }
            catch { return new DataTable(); }
        }

        public string getCreateNewProject(string xmlString, string xmlString1, string xmlStringfund, string xmlStringemp, string pName, string ptype, string pcode, string obj, DateTime pFromdate, DateTime ptodate, int enroll,string remarks)
        {
            string msg="";
            try
            {
                sprProjectCreateTableAdapter getNewProjectEntry = new sprProjectCreateTableAdapter();
                getNewProjectEntry.GetNewProjectCreateEntry(xmlString, xmlString1, xmlStringfund, xmlStringemp, pName, ptype, pcode, obj, pFromdate, ptodate, enroll,remarks, ref msg);
               
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
    }
}
