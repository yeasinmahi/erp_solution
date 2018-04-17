using HR_DAL.Cafeteria.GlobalTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Cafeteria
{
    public class GlobalBLL
    {
        public DataTable GetMealReport(int intEnroll) 
        {
            QryEmployeeProfileAllTableAdapter adp = new QryEmployeeProfileAllTableAdapter();
            try
            { return adp.GetData(intEnroll); } 
            catch { return new DataTable(); }
        }
        public DataTable GetEmpInfo(int intEnroll)  
        {
            EmployeeInfoTableAdapter adp = new EmployeeInfoTableAdapter();
            try
            { return adp.GetEmpInfo(intEnroll); } 
            catch { return new DataTable(); }
        }
        public DataTable GetDateWiseMealReport(int intEnroll) 
        {
            TblCafeteriaDetailsTableAdapter adp = new TblCafeteriaDetailsTableAdapter();
            try
            { return adp.GetDateWiseReport(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetMealApprReport(int intEnroll) 
        {
            TblCafeteriaDetailsTableAdapter adp = new TblCafeteriaDetailsTableAdapter();
            try
            { return adp.GetMealApprReport(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetMenuList() 
        {
            TblDayTableAdapter adp = new TblDayTableAdapter();
            try
            { return adp.GetMenuList(); }
            catch { return new DataTable(); }
        }
        public string InsertEntryCafeteria(int intPart, DateTime tdate, int intEnroll, int intType, int intMealOption, int intMealFor, int intCountMeal, int isOwnGuest, int isPayable, string strNarration, int intActionBy)
        {
            string msg = ""; 
            try
            {
                SprCafeteriaTableAdapter adp = new SprCafeteriaTableAdapter();
                adp.InsertEntryCafeteria(intPart, tdate, intEnroll, intType, intMealOption, intMealFor, intCountMeal, isOwnGuest, isPayable, strNarration, intActionBy, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetCateteriaR(int intPart, int intEnroll)
        {
            SprCafeteriaRTableAdapter adp = new SprCafeteriaRTableAdapter();
            try
            { return adp.GetCateteriaR(intPart, intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetCafeteriaRAll(int intPart, DateTime fdate, DateTime tdate, int intRptType)
        {
            SprCafeteriaReportAllTableAdapter adp = new SprCafeteriaReportAllTableAdapter();
            try
            { return adp.GetCafeteriaRAll(intPart, fdate, tdate, intRptType); }
            catch { return new DataTable(); }
        }
        public DataTable GetMealStatus(int intEnroll)
        {
            TblCafeteriaTableAdapter adp = new TblCafeteriaTableAdapter();
            try
            { return adp.GetMealStatus(intEnroll); }
            catch { return new DataTable(); }
        }


















    }
}
