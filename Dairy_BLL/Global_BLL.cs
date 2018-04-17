using Dairy_DAL.Global_DALTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Dairy_DAL;
using HR_DAL.Global.AutoSearch_TDSTableAdapters;
using HR_DAL.Global.InventoryTDSTableAdapters;
using System.Collections;
using HR_DAL.Global;


namespace Dairy_BLL
{
    public class Global_BLL
    {

        //private static Global_DAL.SprRequesitionAutosearchDataTable[] tableCusts = null;
        private static Global_DAL.TblAG_SupplierDataTable[] tableCusts = null;        
        int e;
        private static Global_DAL.TblEmployeeListDataTable[] tableEmplist = null;

        public DataTable GetChillingCenterList(int intUnitID)
        {
            TblChillingCenterTableAdapter adp = new TblChillingCenterTableAdapter();
            try
            { return adp.GetChillingCenterList(intUnitID); }
            catch { return new DataTable(); }
        }
        public DataTable GetChillingCenterListWithAll(int intUnitID)
        {
            TblChillingCenterTableAdapter adp = new TblChillingCenterTableAdapter();
            try
            { return adp.GetChillingCenterListWithAll(intUnitID); }
            catch { return new DataTable(); }
        }
        public DataTable GetSupplierCode(int intCCID) 
        {
            TblChillingCenterTableAdapter adp = new TblChillingCenterTableAdapter();
            try
            { return adp.GetSPCode(intCCID); }
            catch { return new DataTable(); }
        }
        public DataTable GetSupplierName(int intSuppID)
        {
            TblChillingCenterTableAdapter adp = new TblChillingCenterTableAdapter();
            try
            { return adp.GetSupplierName(intSuppID); }
            catch { return new DataTable(); }
        }
        public DataTable GetFatPercentList(int intCCID) 
        {
            TblChillingCenterTableAdapter adp = new TblChillingCenterTableAdapter();
            try
            { return adp.GetFatPercentList(intCCID); } 
            catch { return new DataTable(); }
        }
        public DataTable GetRateAmount(int intAutoID)
        {
            TblChillingCenterTableAdapter adp = new TblChillingCenterTableAdapter();
            try
            { return adp.GetRateAmount(intAutoID); }
            catch { return new DataTable(); }
        }

        public DataTable GetReportForIssue(int intWork, int intCCID, DateTime dteFrom, DateTime dteTo)
        {
            SprDairyMilkTransaction1TableAdapter adp = new SprDairyMilkTransaction1TableAdapter();
            try
            { return adp.GetReportForIssue(intWork, intCCID, dteFrom, dteTo); } 
            catch { return new DataTable(); }
        }

        public DataTable GetVehicleNoList() 
        {
            TblVehicleInfoTableAdapter adp = new TblVehicleInfoTableAdapter();
            try
            { return adp.GetVehicleNoList(); }
            catch { return new DataTable(); }
        }

        public string InsertIssueEntry(int intUnitID, int intCCID, DateTime dteIssue, int intInsertBy, int intVID, string strChamberNo, decimal decFTP, string xml)
        {
            string msg = "";
            SprMilkIssueTableAdapter adp = new SprMilkIssueTableAdapter();            
            adp.InsertMillkIssue(intUnitID, intCCID, dteIssue, intInsertBy, intVID, strChamberNo, decFTP, xml, ref msg);
            return msg;
        }
        public string InsertMilkReceive(DateTime dteRDate, int intCCID, int intSuppID, string strSuppCodeNo, string strMorEve, 
        decimal decRQty, decimal decRFP, string strAlcoholTest, decimal decCLR, decimal decTemperature, decimal decLactoReading, 
        string strColourTest, decimal decAcidityTest, string strFormalinTest, string strSodaTest, string strSaltTest, string strSugarTest, 
        string strCOB, decimal decReceFatKgs, decimal monRRate, decimal monRBill, decimal monRCMcomm, decimal monRGrandTotal,
        int intInsertBy, int intUnitID, int intPONo)
        {
            string msg = "";
            SprMilkReceiveTableAdapter adp = new SprMilkReceiveTableAdapter();
            adp.InsertMilkReceive(dteRDate, intCCID, intSuppID, strSuppCodeNo, strMorEve, decRQty, decRFP, strAlcoholTest, decCLR, 
            decTemperature, decLactoReading, strColourTest, decAcidityTest, strFormalinTest, strSodaTest, strSaltTest, strSugarTest, 
            strCOB, decReceFatKgs, monRRate, monRBill, monRCMcomm, monRGrandTotal, intInsertBy, intUnitID, intPONo, ref msg);
            return msg; 
        }
        public DataTable GetInventoryReport(int intCCID, DateTime dteFrom, DateTime dteTo) 
        {
            SprMilkInventoryTableAdapter adp = new SprMilkInventoryTableAdapter();
            try
            { return adp.GetInventoryReport(intCCID, dteFrom, dteTo); }
            catch { return new DataTable(); }
        }
        public DataTable GetBankList() 
        {
            tblBankTableAdapter adp = new tblBankTableAdapter();
            try
            { return adp.GetBankList(); }
            catch { return new DataTable(); }
        }
        public DataTable GetDistrictList() 
        {
            tblBankTableAdapter adp = new tblBankTableAdapter();
            try
            { return adp.GetDistrictList(); }
            catch { return new DataTable(); }
        }
        public DataTable GetBranchList(int intBankID, int intDistrictID)
        {
            tblBankTableAdapter adp = new tblBankTableAdapter();
            try
            { return adp.GetBranchList(intBankID, intDistrictID); }
            catch { return new DataTable(); }
        }

        public string InsertSuppRegistration(string strSuppCode, string strSuppName, string strAddress, string strMobileNo, int intInsertBy,
                      int intUnitID, string strAccountNo, string strNID, string strBankName, string strBranchName, int intCCID,
                      int intBankID, int intDistrictID, int intBranchID)
        {
            string msg = "";
            SprMilkSuppRegistrationTableAdapter adp = new SprMilkSuppRegistrationTableAdapter();
            adp.InsertSuppRegistration(strSuppCode, strSuppName, strAddress, strMobileNo, intInsertBy, intUnitID, strAccountNo, 
            strNID, strBankName, strBranchName, intCCID, intBankID, intDistrictID, intBranchID, ref msg);
            return msg; 
        }
        public DataTable GetSupplierProfile(int intCCID)  
        {
            SupplierProfileTableAdapter adp = new SupplierProfileTableAdapter();
            try
            { return adp.GetSupplierProfile(intCCID); }
            catch { return new DataTable(); }
        }
        public DataTable GetUnitList()   
        {
            TblUnitTableAdapter adp = new TblUnitTableAdapter();
            try
            { return adp.GetUnitList(); }
            catch { return new DataTable(); }
        }
         
        public DataTable GetMilkMRReport(int intWork, DateTime dteFrom, DateTime dteTo, int intCCID, int intSuppID, int intMRNo, int intPart)   
        { 
            SprMilkMRReportTableAdapter adp = new SprMilkMRReportTableAdapter(); 
            
            try
            { return adp.GetMilkMRReport(intWork, dteFrom, dteTo, intCCID, intSuppID, intMRNo, intPart); }
            catch { return new DataTable(); }
        }
        
        //@intWork int, @dteMRRReceivedDateFrom date = NULL, @dteMRRReceivedDateTo date = NULL, @intSearchChillingCenterID int = NULL, 
        //@intSearchSupplierID int = NULL,
        //@intSearchMRRNo int = NULL, @intPart

        public string[] AutoSearchChllingCenter(string WHID, string prefix) 
        {
            int intwh = Int32.Parse(WHID.ToString());
            //Inatialize(intwh);
            tableCusts = new Global_DAL.TblAG_SupplierDataTable[Convert.ToInt32(WHID)];
            TblAG_SupplierTableAdapter adpCOA = new TblAG_SupplierTableAdapter();
            tableCusts[e] = adpCOA.GetSuppSearch(Convert.ToInt32(WHID));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCusts[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strSupplierName
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
                        var rows = from tmp in tableCusts[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strSupplierName.ToLower().Contains(prefix) || tmp.strSupplierCode.ToLower().Contains(prefix)
                                   orderby tmp.strSupplierCode
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
                    retStr[i] = tbl.Rows[i]["strSupplierName"] + " [" + tbl.Rows[i]["strSupplierCode"] + "] " + " [" + tbl.Rows[i]["intSupplierID"] + "]";
                } return retStr; 
            } else { return null; }
        }
          

        public string[] AutoSearchEmpList(string intUnitID, string prefix) 
        {
            intUnitID = "1";
            int unit = Int32.Parse(intUnitID.ToString());
            //Inatialize(intwh);
            
            tableEmplist = new Global_DAL.TblEmployeeListDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeListDataTable[Convert.ToInt32(intUnitID)];
            //tableEmplist = new Global_DAL.TblEmployeeDataTable[e];
            TblEmployeeListTableAdapter adpCOA = new TblEmployeeListTableAdapter();
            tableEmplist[e] = adpCOA.GetEmpList(unit);
            //tableEmplist[e] = adpCOA.GetEmpList(Convert.ToInt32(intUnitID)); 
            //tableEmplist[e] = adpCOA.GetEmpListByUnit();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableEmplist[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableEmplist[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || tmp.intEmployeeID.ToString().ToLower().Contains(prefix) || tmp.strEmployeeCode.ToLower().Contains(prefix) || tmp.strOfficeEmail.ToLower().Contains(prefix) //|| tmp.strOfficeEmail.ToString().ToLower().Contains(prefix)  //strOfficeEmail 
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
                    //retStr[i] = tbl.Rows[i]["strEmployeeName"] + "; " + tbl.Rows[i]["intEmployeeID"];
                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + " [" + tbl.Rows[i]["intEmployeeID"] + "]";
                } return retStr;
            }
            else { return null; }
        }
        

        public DataTable GetMRReportForExecl(int intUnitid, DateTime dteFrom, DateTime dteTo)   
        {
            SprMilkMRRForExcelTableAdapter adp = new SprMilkMRRForExcelTableAdapter();
            try
            { return adp.GetMRReportForExecl(intUnitid, dteFrom, dteTo); }
            catch { return new DataTable(); }
        }

        


    }








}