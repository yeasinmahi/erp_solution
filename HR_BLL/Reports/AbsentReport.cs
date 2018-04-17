using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLOBAL_BLL;
using HR_DAL.Reports;
using HR_DAL.Reports.ReportDataTDSTableAdapters;

namespace HR_BLL.Reports
{
    public class AbsentReport
    {

        public ReportDataTDS.SprReportAbsentReportDataTable GetAbsentDataByJobStation(int jobstationID, string date)
        {
            try
            {
                SprReportAbsentReportTableAdapter adp = new SprReportAbsentReportTableAdapter();

                return adp.GetAbsentData(jobstationID,DateFormat.GetDateAtSQLDateFormat(date));
            }
            catch
            {
                return null;
            }


        }

        public ReportDataTDS.SprGetTaxAbleEmployeeDataTable GetTaxAbleEmployee(int unit)
        {
            try
            {
                SprGetTaxAbleEmployeeTableAdapter adp = new SprGetTaxAbleEmployeeTableAdapter();
                return adp.GetTaxAbleEmployeeData(unit);
            }
            catch  {   return null; }

        }

        public void UpdatePaidRequestForTax(int actionby, int enroll)
        {
            try
            {
                SprGetTaxAbleEmployeeTableAdapter adp = new SprGetTaxAbleEmployeeTableAdapter();
                adp.UpdateRequestForTaxPaid(actionby, enroll);
            }
            catch {}

        }

        public DataTable GetTreasuryInformation(int unit, bool status)
        {
            try
            {
                SprGetTreasuryInformationTableAdapter adp = new SprGetTreasuryInformationTableAdapter();
                return adp.GetTreasuryInformationData(status, unit);
            }
            catch { return null; }

        }
        public Decimal GetTotalTreasuryAmount(int unit)
        {
            try
            {
                SprGetTaxAbleEmployeeTableAdapter adp = new SprGetTaxAbleEmployeeTableAdapter();
                return Convert.ToDecimal(adp.GetTotalTreasury(unit));
            }
            catch { return 0; }

        }

        public string TreasuryInformation(int unit, string narration, decimal treasuryamount, int actionby)
        { 
            string strmsg ="";
            try
            {
                SprEmployeeTaxTreasuryInformationTableAdapter adp = new SprEmployeeTaxTreasuryInformationTableAdapter();
                adp.TreasuryInformationData(unit, narration, treasuryamount, actionby, ref strmsg);
            }
            catch { strmsg = ""; }
            return strmsg;
        }
        public void CompleteTreasuryInformation(int usrid, string challanno, int autoid)
        {
            try
            {
                SprEmployeeTaxTreasuryInformationTableAdapter adp = new SprEmployeeTaxTreasuryInformationTableAdapter();
                adp.CompleteTreasuryDeposite(challanno, usrid, autoid);
            }
            catch {}
        }

        public void JobstationRegistration(int unit, string station, string address, string latitudeY, string longitudeX, int usrid)
        {
            TblEmployeeJobStationRegTableAdapter adp = new TblEmployeeJobStationRegTableAdapter();
            adp.InsertNewStationData(station,address, unit, longitudeX, latitudeY, usrid);
        }
    }
}
