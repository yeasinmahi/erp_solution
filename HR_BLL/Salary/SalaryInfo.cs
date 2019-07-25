using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Salary.SalaryInfoTDSTableAdapters;

namespace HR_BLL.Salary
{
   public class SalaryInfo
    {
       public DataTable GetUnitwiseSalaryDetails(int? intLoginUserId)
       {
           //Summary    :   This function will use to get unit wise salary details
           //Created    :   Md. Yeasir Arafat / Mar-18-2012
           //Modified   :   FILER BY intLoginUserId ,DATE:JUNE-24-2012
           //Parameters :   

           UnitwiseSalaryDetailsByLoginUserIdTableAdapter objUnitwiseSalaryDetailsByLoginUserIdTableAdapter = new UnitwiseSalaryDetailsByLoginUserIdTableAdapter();
           return objUnitwiseSalaryDetailsByLoginUserIdTableAdapter.GetUnitwiseSalaryDetailsByLoginUserId(intLoginUserId);
       }
       public DataTable GetUnitwiseSalaryDetailsByUnitID(int? intUnitID )
       {
           //Summary    :   This function will use to get unit wise salary details
           //Created    :   Md. Yeasir Arafat / May-1-2012
           //Modified   :   
           //Parameters :   

           UnitwiseSalaryDetailsByUnitIDTableAdapter objUnitwiseSalaryDetailsByUnitIDTableAdapter = new UnitwiseSalaryDetailsByUnitIDTableAdapter();
           return objUnitwiseSalaryDetailsByUnitIDTableAdapter.GetData(intUnitID);
       }
       public DataTable GetSalaryAdviceandSupporting(int? unit, int? station, DateTime date, string viewtype)
       {
           try
           {
               SprSalaryAdviceToBankTableAdapter tbladp = new SprSalaryAdviceToBankTableAdapter();
               return tbladp.GetSalaryAdviceData(unit, station, date, viewtype);
           }
           catch
           { return new DataTable(); }
       }
       public string SubmitCashSalary(string empcode, int bank, int branch, int dist, string accholder, string accountno, decimal cash, DateTime eDate, int actionBy)
       {
           string msg = "";
           try
           {
               SprEmployeeCashSalaryTableAdapter adp = new SprEmployeeCashSalaryTableAdapter();
               adp.SetCashSalaryData(empcode, bank, branch, dist, accholder, accountno, cash, eDate, actionBy, ref msg);
           }
           catch (Exception ex) { msg = ex.ToString(); }
           return msg;
       }
       public DataTable GetCashSalary(string empcode)
       {
           try
           {
               TblCashTableAdapter adp = new TblCashTableAdapter();
               return adp.GetCashSalaryData(empcode);
           }
           catch { return new DataTable(); }
       }

        public string SubmitSalaryAdditionDeduction(int TypeId,string xml)
        {
            string msg = "";
            try
            {
                SprSalaryAdditionDeductionEntryTableAdapter adp = new SprSalaryAdditionDeductionEntryTableAdapter();
               adp.InsertData(TypeId, xml,ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetType()
        {
            try
            {
                tblSalaryAdditionDeductionTypeTableAdapter adp = new tblSalaryAdditionDeductionTypeTableAdapter();
                return adp.GetData();
            }
            catch { return new DataTable(); }
        }
        



    }
}
