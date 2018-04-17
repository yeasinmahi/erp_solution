using DAL.Accounts.Approval.IndentApproval_TDSTableAdapters;
using System;
using System.Data;

namespace BLL.Accounts.Approval
{
    public class IndentApporval_BLL
    {
        public DataTable UserbyUnitList(int enroll)
        {
            try
            {
                UnitByUserTableAdapter users = new UnitByUserTableAdapter();
                return users.UnitbyUserGetData(enroll);
            }

            catch { return new DataTable(); }
        }

        public DataTable WHbyUnitID(int unit)
        {
            try
            {
                WHByUnitTableAdapter wh = new WHByUnitTableAdapter();
                return wh.WHByUnitIDGetData(unit);
            }
            catch { return new DataTable(); }
        }
        public DataTable IndentPendingView(int wh,DateTime fdate, DateTime todate)
        {
            try
            {
                PendingIndentViewTableAdapter pending = new PendingIndentViewTableAdapter();
                return pending.IndentPendingViewGetData(wh,Convert.ToString(fdate), Convert.ToString(todate));
            }
            catch { return new DataTable(); }
        }
        public DataTable IndentApprovedView(int wh,DateTime fdate, DateTime todate)
        {
            try
            {
                ApproveIndentViewTableAdapter approved = new ApproveIndentViewTableAdapter();
                return approved.ApprovedIndentViewGetData(wh, Convert.ToString(fdate), Convert.ToString(todate));

            }
            catch { return new DataTable(); }
        }

        public DataTable CostCenterByUnit(int unit)
        {
            try
            {
                CostCenterByUnitTableAdapter costcenter = new CostCenterByUnitTableAdapter();
                return costcenter.CostCenterByUnitGetData(unit);
            }
            catch { return new DataTable(); }
        }

        public DataTable ChartofAccountName(int v)
        {
            try
            {
                SprAccountsCOAGetGlobalAccByParentTableAdapter coa = new SprAccountsCOAGetGlobalAccByParentTableAdapter();
                return coa.COANameGetData(108);
            }
            catch { return new DataTable(); };

        }

        public DataTable IndentDetalisView(int indentid)
        {
            try
            {
                IndentDetalisbyIndentIDTableAdapter indent = new IndentDetalisbyIndentIDTableAdapter();
                return indent.IndentDetalisGetData(indentid);

            }
            catch { return new DataTable(); }
        }

        public void IndentapprovedbyUser(int enroll, int intCOS, int intCOA, string  narration, int indent)
        {
            try
            {
                IndentApproveActionTableAdapter approvedaction = new IndentApproveActionTableAdapter();
                approvedaction.IndentApprovedActionGetData(enroll, intCOS, intCOA, narration, indent);
            }
            catch {new DataTable();}
        }

        public DataTable TotalBudgetView(int unit, int intCOS, int intCOA, int intyear, int intmonth)
        {
            try
            {
                TotalBudgetTableAdapter totalbud = new TotalBudgetTableAdapter();
                return totalbud.TotalBudgetGetData(Convert.ToInt32(unit), intCOS, intCOA, intyear, intmonth);
            }
            catch { return new DataTable(); }
        }

        public DataTable TotalAmountView(int intyear, int intmonth, int intCOS, int intCOA)
        {
            try
            {
                TotalBudgetTableAdapter totalamo = new TotalBudgetTableAdapter();
                return totalamo.TotalCostAmountGetData(intyear, intmonth, intCOS, intCOA);
            }
            catch { return new DataTable(); }
        }
    }
}