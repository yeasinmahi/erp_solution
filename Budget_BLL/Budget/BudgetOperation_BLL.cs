using Budget_DAL.BudgetOperationTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Budget_BLL.Budget
{
    public class BudgetOperation_BLL
    {
        public DataTable CostCenterName(int intunit)
        {
            TblCostCenterTableAdapter costcenter = new TblCostCenterTableAdapter();
            return costcenter.CostCenterNameGetData(intunit);
        }

        

        

        public DataTable OperationXmlInsert(int item, string xmlStringOperation, int p1, int p2, int p3, int p4, int p5,int p6, int enroll, int intjobid, int intunit, int intdept)
        {
            SprBudgetPlanningReqTableAdapter operationInsert = new SprBudgetPlanningReqTableAdapter();
            return operationInsert.BudgetPlanningReqGetData(item, xmlStringOperation, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), enroll, intjobid, intunit, intdept);
        }



        public DataTable NonOperationXmlInsert(int item, int p1, string xmlStringAssetAccoA, int p2, int p3, int p4, int p5, int p6, int enroll, int intjobid, int intunit, int intdept)
        {
            SprBudgetPlanningReqTableAdapter NonoperationInsert = new SprBudgetPlanningReqTableAdapter();
            return NonoperationInsert.BudgetPlanningReqGetData(item, Convert.ToString(0), xmlStringAssetAccoA, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), enroll, intjobid, intunit, intdept);
 
        }

        public DataTable OperationDetalisXmlInsert(int item, int p1, int p2, string xmlStringSuppliyes, string xmlStringEmployee, string xmlStringTools, string xmlStringExpance, int p3, int enroll, int intjobid, int intunit, int intdept)
        {
            SprBudgetPlanningReqTableAdapter detalisinsert = new SprBudgetPlanningReqTableAdapter();
            return detalisinsert.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), xmlStringSuppliyes, xmlStringEmployee, xmlStringTools, xmlStringExpance, Convert.ToString(0), enroll, intjobid, intunit, intdept);
 
        }

        public DataTable OperationUserView(int enroll)
        {
            DataTableOperationViewTableAdapter viewuser = new DataTableOperationViewTableAdapter();
            return viewuser.OperationViewGetData(enroll);
        }

        public DataTable userdetalisview(int enroll)
        {
            DataTableOperationViewTableAdapter viewuserdetalis = new DataTableOperationViewTableAdapter();
            return viewuserdetalis.UserDetalisGetData(enroll);
        }

        public DataTable OperationdetalisReport(int item, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int OperationID, int p8, int p9, int p10)
        {
            SprBudgetPlanningReqTableAdapter operationDetaliss = new SprBudgetPlanningReqTableAdapter();
            return operationDetaliss.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), OperationID, 0, 0, 0);
 
        }

        public DataTable ConstingSectorReport(int item, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int OperationID, int p8, int p9, int p10)
        {
            SprBudgetPlanningReqTableAdapter costingDetaliss = new SprBudgetPlanningReqTableAdapter();
            return costingDetaliss.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), OperationID, 0, 0, 0);
 
        }

        public DataTable GetOperationType(int OperationID)
        {
            TbllBudgetPlanningReqOrationTypeTableAdapter operatuinType = new TbllBudgetPlanningReqOrationTypeTableAdapter();
            return operatuinType.OperationNonOperationTypeGetData(OperationID);
        }







        public DataTable ProjectParent(int intunit)
        {
            TblAccountsChartOfAccTableAdapter parent = new TblAccountsChartOfAccTableAdapter();
            return parent.COAGetData(intunit);
        }

        public DataTable Childview(int data)
        {
            TblAccountsChartOfAccTableAdapter child = new TblAccountsChartOfAccTableAdapter();
            return child.ChildkeyGetData(data);
        }



        public void InsertCharOfProjectName(int item, int p1, int p2, int p3, int p4, int p5, int p6, string chartName, int enroll, int intjobid, int intunit, int ParentID)
        {
            SprBudgetPlanningReqTableAdapter NewCharof = new SprBudgetPlanningReqTableAdapter();
            NewCharof.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), chartName, enroll, intjobid, intunit, ParentID);
 
        }

        public DataTable BudgereqEmployee(int item, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int OperationID, int p8, int p9, int p10)
        {
            SprBudgetPlanningReqTableAdapter Employeereq = new SprBudgetPlanningReqTableAdapter();
            return Employeereq.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), OperationID, 0, 0, 0);
 
        }

        public DataTable BudgereqItems(int item, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int OperationID, int p8, int p9, int p10)
        {
            SprBudgetPlanningReqTableAdapter Itemsreq = new SprBudgetPlanningReqTableAdapter();
            return Itemsreq.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), OperationID, 0, 0, 0);
 
        }

        public DataTable BudgereqTools(int item, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int OperationID, int p8, int p9, int p10)
        {
            SprBudgetPlanningReqTableAdapter Toolsview= new SprBudgetPlanningReqTableAdapter();
            return Toolsview.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), OperationID, 0, 0, 0);
 
        }

        public DataTable BudgereqExpance(int item, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int OperationID, int p8, int p9, int p10)
        {
            SprBudgetPlanningReqTableAdapter ExpanceV = new SprBudgetPlanningReqTableAdapter();
            return ExpanceV.BudgetPlanningReqGetData(item, Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), Convert.ToString(0), OperationID, 0, 0, 0);
 
        }
    }
}
