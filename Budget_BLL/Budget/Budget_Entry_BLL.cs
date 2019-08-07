using Budget_DAL;
using Budget_DAL.Budget_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        public string UpdateLedgerCostcenter(int intUnitId, int intSubledgerId, int intCostCenterId, string costcenter)
        {
            string msg = "Update Sucessfull";
            LedgerCostCenterUpdateTableAdapter adp = new LedgerCostCenterUpdateTableAdapter();
            adp.UdateLedgerCoscenter(intCostCenterId, costcenter, intSubledgerId, intUnitId);
            return msg;
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

        public DataTable GetUnitforCostCenter(int unitid)
        {
            try
            {
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                return adp.GetUnit(unitid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetCostCenter(int unitid, int enroll)
        {
            try
            {
                tblCostCenterTableAdapter adp = new tblCostCenterTableAdapter();
                return adp.GetCostCenter(unitid, enroll);
            }
            catch(Exception exception)
            {
                return new DataTable();
            }
        }
        public DataTable GetCostCenterData(int unitid, DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable2TableAdapter adp = new DataTable2TableAdapter();
                return adp.GetCostCenterData(unitid, Convert.ToString(fromDate, CultureInfo.InvariantCulture), Convert.ToString(toDate, CultureInfo.InvariantCulture));
            }
            catch { return new DataTable(); }
        }
        public DataTable UpdateCostCenterSelected(string xml, out string message)
        {
            try
            {
                SprCostCenterCorrectionUpdateTableAdapter adp = new SprCostCenterCorrectionUpdateTableAdapter();
                message = null;
                return adp.UpdateCostCenterSelected(xml, ref message);
            }
            catch
            {
                message = null;
                return new DataTable();
            }
        }

        public DataTable GetUnitvsCostecenter(int unitid)
        {
            try
            {
                TblUnitVsCostCenterTableAdapter adp = new TblUnitVsCostCenterTableAdapter();
                return adp.GetDataUnitVsCostCenter(unitid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetBudgetType()
        {
            try
            {
                TblBudgetTypeTableAdapter adp = new TblBudgetTypeTableAdapter();
                return adp.GetDataBudgetType();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetYearNAmount()
        {
            try
            {
                TblYearNAmountTableAdapter adp = new TblYearNAmountTableAdapter();
                return adp.GetDataYearAndAmount();
            }
            catch { return new DataTable(); }
        }

      public string InsertOPSetupBaseBudget(string xmlString,  int Enrol, int unit)
        {
            SprOperationalSetUpBaseBudgetTableAdapter obj = new SprOperationalSetUpBaseBudgetTableAdapter();
            string msg = "";
            try
            {
                obj.GetDataOperationalSetUpBaseBudget(xmlString, Enrol, unit, ref msg);
                return msg;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }


        public DataTable GetBudgetProductInfo(int prdid)
        {
            try
            {
                SprBudgetProductPriceTableAdapter adp = new SprBudgetProductPriceTableAdapter();
                return adp.GetDataBudgetProductPrice(prdid);
            }
            catch { return new DataTable(); }
        }


        public DataTable GetBudgetModificationInfo(string XMLString , int intEnrol , int intUnit ,DateTime fromdate ,DateTime todate ,int intbudgettyep ,int  prdid ,int actiontype )
        {
            try
            {
                SprOperationalSetUpBaseBudgetModificationTableAdapter adp = new SprOperationalSetUpBaseBudgetModificationTableAdapter();
                return adp.GetDataOperationalSetUpBaseBudgetModification(XMLString,  intEnrol,  intUnit,  fromdate,  todate,  intbudgettyep,   prdid,  actiontype);
            }
            catch { return new DataTable(); }
        }



        public DataTable GetBudgetFGQntvsMaterialQnt( int budgtyr, int invitmid)
        {
            try
            {
                SprOperationalBudgetFGQntvsMaterialQntTableAdapter adp = new SprOperationalBudgetFGQntvsMaterialQntTableAdapter();
                return adp.GetDataOperationalBudgetFGQntvsMaterialQnt(budgtyr, invitmid);
            }
            catch { return new DataTable(); }
        }


        public DataTable GetMonthandID()
        {
            try
            {
                SprMonthAndIDTableAdapter adp = new SprMonthAndIDTableAdapter();
                return adp.GetDataMonthAndID();
            }
            catch { return new DataTable(); }
        }

        public DataTable GetFGVsRawMaterialMonthly(int budgetyear,int unitid, int monthid)
        {
            try
            {
                SprBudgetFGVsRmMonthLyTableAdapter adp = new SprBudgetFGVsRmMonthLyTableAdapter();
                return adp.GetDataBudgetFGVsRmMonthLy(budgetyear,  unitid,  monthid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetBudgetYearCombindly()
        {
            try
            {
                SprBudgetYearCombindlyTableAdapter adp = new SprBudgetYearCombindlyTableAdapter();
                return adp.GetDataBudgetYearCombindly();
            }
            catch { return new DataTable(); }
        }

        public string InsertRawMaterialBudget(string xmlString, int Enrol, int unit)
        {
            SprBudgetEntryForRawMaterialMonthlyTableAdapter obj = new SprBudgetEntryForRawMaterialMonthlyTableAdapter();
            string msg = "";
            try
            {
                obj.GetDataBudgetEntryForRawMaterialMonthly(xmlString, Enrol, unit, ref msg);
                return msg;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }


    }
}
