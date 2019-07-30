using System;
using HR_DAL.PiceRateCalculation.PiceRateCalculationTableAdapters;
using System.Data;
using Utility;

namespace HR_BLL.PiceRateCalculation
{
    public class PiceRateCalculation_BLL
    {
        public string InsertPiceRateData(int? intLoginUserId, string empCode, DateTime dteSalaryGenerateDate, decimal? numProductionPerDay, decimal? numRatePerUnit, decimal? monPayableSalaryPerDay)
        {
            //Summary    :   This function will use to Insert data into pice rate data table.
            //Created    :   Md. Yeasir Arafat / June-16-2012
            //Modified   :   
            //Parameters :   return insertStatus
            try
            {
                string insertStatus = "";
                SprPiceRateDataInsertTableAdapter objSprPiceRateDataInsertTableAdapter = new SprPiceRateDataInsertTableAdapter();
                objSprPiceRateDataInsertTableAdapter.InsertData(intLoginUserId, empCode, numProductionPerDay, numRatePerUnit, monPayableSalaryPerDay, dteSalaryGenerateDate,ref insertStatus);
                return insertStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        public DataTable GetPiceRateDetailsByEmployeeCode(string strEmployeeCode)
        {
            //Summary    :   This function will use to pice rate data details by employee code
            //Created    :   Md. Yeasir Arafat / June-18-2012
            //Modified   :   
            //Parameters :   return data table

            try
            {
                SprPiceRateGetDetailsByEmployeeCodeTableAdapter tbl = new SprPiceRateGetDetailsByEmployeeCodeTableAdapter();
                return tbl.GetData(strEmployeeCode);
            }
            catch
            {
                DataTable odt = new DataTable();
                return odt;
            }
        }

        public string UpdatePiceRateData(int? intLoginUserId, string empCode, DateTime dteSalaryGenerateDate, decimal? numProductionPerDay, decimal? numRatePerUnit, decimal? monPayableSalaryPerDay)
        {
            //Summary    :   This function will use to Update data into pice rate data table.
            //Created    :   Md. Yeasir Arafat / June-19-2012
            //Modified   :   
            //Parameters :   return updateStatus
            try
            {
                string updateStatus = "";
                SprPiceRateDataUpdateTableAdapter objSprPiceRateDataUpdateTableAdapter = new SprPiceRateDataUpdateTableAdapter();
                objSprPiceRateDataUpdateTableAdapter.UpdateData(intLoginUserId, empCode, numProductionPerDay, numRatePerUnit, monPayableSalaryPerDay, dteSalaryGenerateDate, ref updateStatus);
                return updateStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }

        public string DeletePiceRateData(int? intLoginUserId, string empCode, DateTime dteSalaryGenerateDate)
        {
            //Summary    :   This function will use to delete data into pice rate data table.
            //Created    :   Md. Yeasir Arafat / June-19-2012
            //Modified   :   
            //Parameters :   return deleteStatus
            try
            {
                string deleteStatus = "";
                SprPiceRateDataDeleteTableAdapter objSprPiceRateDataDeleteTableAdapter = new SprPiceRateDataDeleteTableAdapter();
                objSprPiceRateDataDeleteTableAdapter.DeleteData(intLoginUserId, empCode,dteSalaryGenerateDate, ref deleteStatus);
                return deleteStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        public DataTable GetAttendentEmployeeList(DateTime date)
        {
            try
            {
                sprATMLCausalTableAdapter adp = new sprATMLCausalTableAdapter();
                return adp.GetData(date);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetProductList()
        {
            try
            {
                tblCasualWorkerProductTableAdapter adp = new tblCasualWorkerProductTableAdapter();
                return adp.GetData();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public int InsertCasualSalary(int employeeId, int unitId, string date, int quantity, int productionId)
        {
            try
            {
                tblCasualSalaryTableAdapter adp = new tblCasualSalaryTableAdapter();
                DataTable dt = adp.Insert1(employeeId,unitId,date,quantity,productionId);
                return dt.GetAutoId("intEmpID");
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public DataTable GetAllReport(int unitId, DateTime month)
        {
            try
            {
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetAllReport(unitId, month);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetIndividualReport(int unitId, int enroll, DateTime month)
        {
            try
            {
                DataTable2TableAdapter adp = new DataTable2TableAdapter();
                return adp.GetIndividualReport(unitId,enroll, month);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable PiecesRateSalaryGenarate(int intWork, int intEnroll, decimal monAmount, int intGenerateBy, int unitId, int intBankid)
        {
            try
            {
                sprPiceRateSalaryGenerateTableAdapter adp = new sprPiceRateSalaryGenerateTableAdapter();
                return adp.GetData(intWork, intEnroll, monAmount, intGenerateBy, unitId, intBankid);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable PiecesRateSalaryGenarateFinal(int empEnroll, DateTime fromDate, DateTime toDate,int unitId, int actionBy, ref string message)
        {
            try
            {
                
                sprPieceRateCalculationTableAdapter adp = new sprPieceRateCalculationTableAdapter();
                return adp.GetData(3, empEnroll, fromDate, toDate, unitId, actionBy, ref message);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}
