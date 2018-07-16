using Budget_DAL;
using Budget_DAL.Budget_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Budget_BLL.Budget
{
    public class Budget_Entry_BLL
    {
        public DataTable GetUnit(int intEnroll)
        {
            ForBudgetTableAdapter adp = new ForBudgetTableAdapter();
            try
            { return adp.GetUnit(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetCostCenterName(int intEnroll, int intUnitID)
        {
            TblCostCenterTableAdapter adp = new TblCostCenterTableAdapter();
            try
            { return adp.GetCCName(intEnroll, intUnitID); }
            catch { return new DataTable(); }
        }
        public DataTable GetYearList() 
        {
            YearListTableAdapter adp = new YearListTableAdapter();
            try
            { return adp.GetData(); }
            catch { return new DataTable(); }
        }

        public DataTable GetBudgetEntryR()  
        {
            TblEmployeeTableAdapter adp = new TblEmployeeTableAdapter();
            try
            { return adp.GetBudgetEntryR(); }
            catch { return new DataTable(); }
        }
        public DataTable GetDataForBudgetEntry(int intUnit, string strYear, int intType, int intCC)   
        {
            SprAccountsBudgetTableAdapter adp = new SprAccountsBudgetTableAdapter();
            try
            { return adp.GetDataForBudgetEntry(intUnit, strYear, intType, intCC); }
            catch { return new DataTable(); }
        }

        public string InsertBudgetEntry(int intUnitID, int intCOAID, int intYear, int intMonth, decimal monBAmount, decimal monTAmount, int intUserID, int intCCID) 
        {
            string msg = "";
            SprBudgetEntryTableAdapter adp = new SprBudgetEntryTableAdapter();
            adp.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
            return msg;
        }

        public DataTable getyear()
        {
            
                 try
            {
                YearListTableAdapter adp = new YearListTableAdapter();
                return adp.GetData();
            }
            catch { return new DataTable(); }
        }

        public DataTable getEntryDateCack(int unitid)
        {   try
            {
                tblBudgetEntryDateTableAdapter adp = new tblBudgetEntryDateTableAdapter();
                return adp.GetData(unitid); }
            catch { return new DataTable(); }
        }


        //@intUnitID int, @intCOAID int, @intYear int, @intMonth int, @monBAmount money, @monTAmount money, @intUserID int, @intCCID













    }
}
