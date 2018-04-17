using System.Collections.Generic;
//using System.Web.UI.WebControls;

using DAL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount.ChartOfAccTDSTableAdapters;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;

namespace BLL.Accounts.ChartOfAccount
{
    public class ChartOfAcc
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ChartOfAccTDS.TblAccountsChartOfAccForDLLDataTable GetEndLevelDataForDDL(string parentID)
        {
            try
            {
                TblAccountsChartOfAccForDLLTableAdapter ta = new TblAccountsChartOfAccForDLLTableAdapter();
                return ta.GetData(int.Parse(parentID));
            }
            catch
            {
                return new ChartOfAccTDS.TblAccountsChartOfAccForDLLDataTable();
            }
        }
        
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ChartOfAccTDS.TblAccountsChartOfAccDataTable GetDataByAccCode(string code)
        {
            try
            {
                TblAccountsChartOfAccTableAdapter ta = new TblAccountsChartOfAccTableAdapter();
                return ta.GetDataByCode(code);
            }
            catch
            {
                return new ChartOfAccTDS.TblAccountsChartOfAccDataTable();
            }
        }
        

        /// <summary>
        /// Developped By Himadri das
        /// </summary>

        public ChartOfAccTDS.TblAccountsChartOfAccDataTable GetDataByParentID(int parentID,int unitID)
        {
            TblAccountsChartOfAccTableAdapter adp = new TblAccountsChartOfAccTableAdapter();
            try
            {
                return adp.GetDataByParentID(parentID,unitID);
            }
            catch
            {
                return new ChartOfAccTDS.TblAccountsChartOfAccDataTable();
            }

        }

        /// <summary>
        /// Developped By Himadri das
        /// Modified By Himadri For LINQ Implementation at COA
        /// </summary>
        public TreeNode GetCOANodes(int parentID,int unitID)
        {
            TreeNode root = new TreeNode("Chart Of Accounts", parentID.ToString());
            TreeNode childNode;
            //string text = "";
            //string tmpText;
            //TblAccountsChartOfAccTableAdapter adp=new TblAccountsChartOfAccTableAdapter();
            //ChartOfAccTDS.TblAccountsChartOfAccDataTable tbl = adp.GetDataByParentID(parentID, unitID);
            IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> rows = ChartOfAccStaticDataProvider.GetDataByUnitAndParentID(unitID.ToString(), parentID);

            foreach (ChartOfAccTDS.TblAccountsChartOfAccRow row in rows)
            {
                if (!row.ysnEnable)
                {
                    row.strAccName = "<font color=\"red\">" + row.strAccName + "</font>";
                }

                childNode = new TreeNode(GetAccountTextForNaode(row.strAccName, row.ysnCommandButton), (row.intAccID.ToString() + "#" + row.ysnCommandButton.ToString() + "#" + row.ysnEnable + "#" + (row.IsintModulesAutoIDNull() ? true : false) + "#" + row.ysnSubLedger));

               /* if (!row.ysnCommandButton)
                {
                    childNode.SelectAction = TreeNodeSelectAction.None;
                }*/

                childNode = GetCOAChildNode(row.intAccID, childNode, unitID);

                root.ChildNodes.Add(childNode);

            }


           /* if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (!tbl[i].ysnEnable)
                    {
                        tbl[i].strAccName = "<font color=\"red\">" + tbl[i].strAccName + "</font>";
                    }

                    
                    childNode = new TreeNode(GetAccountTextForNaode(tbl[i].strAccName,tbl[i].ysnCommandButton), (tbl[i].intAccID.ToString()+"#"+tbl[i].ysnCommandButton.ToString()+"#"+tbl[i].ysnEnable+"#"+(tbl[i].IsintModulesAutoIDNull()?true:false)));

                    if (!tbl[i].ysnCommandButton)
                    {
                        childNode.SelectAction = TreeNodeSelectAction.None;
                    }
                    
                   
                    childNode = GetCOAChildNode(tbl[i].intAccID, childNode,unitID);
                    
                    root.ChildNodes.Add(childNode);
                    
                }
            }*/
            
            return root;

        }

        /// <summary>
        /// Developped By Himadri das
        /// Modified By Himadri For LINQ Implementation at COA
        /// </summary>

        private TreeNode GetCOAChildNode(int parentID, TreeNode parentNode ,int unitID)
        {
            TreeNode childNode;
            IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> rows = ChartOfAccStaticDataProvider.GetDataByUnitAndParentID(unitID.ToString(), parentID);

            foreach (ChartOfAccTDS.TblAccountsChartOfAccRow row in rows)
            {
                if (!row.ysnEnable)
                {
                    row.strAccName = "<font color=\"red\">" + row.strAccName + "</font>";
                }
                    childNode = new TreeNode(GetAccountTextForNaode(row.strAccName, row.ysnCommandButton), (row.intAccID.ToString() + "#" + row.ysnCommandButton.ToString() + "#" + row.ysnEnable + "#" + (row.IsintModulesAutoIDNull() ? true : false)+"#"+row.ysnSubLedger));
                   /* if (!row.ysnCommandButton)
                    {
                        childNode.SelectAction = TreeNodeSelectAction.None;
                    }*/

                    childNode = GetCOAChildNode(row.intAccID, childNode, unitID);

                    parentNode.ChildNodes.Add(childNode);

                
            }

           /* TblAccountsChartOfAccTableAdapter adp = new TblAccountsChartOfAccTableAdapter();
            ChartOfAccTDS.TblAccountsChartOfAccDataTable tbl = adp.GetDataByParentID(parentID, unitID);
            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)

                {
                    if (!tbl[i].ysnEnable)
                    {
                        tbl[i].strAccName = "<font color=\"red\">" + tbl[i].strAccName + "</font>";
                    }
                    childNode = new TreeNode(GetAccountTextForNaode(tbl[i].strAccName,tbl[i].ysnCommandButton), (tbl[i].intAccID.ToString()+"#"+tbl[i].ysnCommandButton.ToString()+"#"+tbl[i].ysnEnable+"#"+(tbl[i].IsintModulesAutoIDNull()? true:false)));
                    
                    if (!tbl[i].ysnCommandButton)
                    {
                        childNode.SelectAction = TreeNodeSelectAction.None;
                    }
                    
                    childNode = GetCOAChildNode(tbl[i].intAccID, childNode,unitID);
                    
                    parentNode.ChildNodes.Add(childNode);
                }
            }*/

            return parentNode;
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>

        private string GetAccountTextForNaode(string accountName, bool ysnCommandButton)
        {
            //if (ysnCommandButton)
            //{
                return accountName + "&nbsp :.";
            //}
            //else
            //{
            //    return accountName;
            //}
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>

        public ChartOfAccTDS.TblAccountsChartOfAccDataTable GetDataByAccountIDForEdit(int accountID)
        {
            TblAccountsChartOfAccTableAdapter adp = new TblAccountsChartOfAccTableAdapter();
            try
            {
                return adp.GetDataByAccountID(accountID);
            }
            catch
            {
                return new ChartOfAccTDS.TblAccountsChartOfAccDataTable();
            }
        }


        /// <summary>
        /// Developped By Himadri das
        /// </summary>

        public string InsertAccount(string accName, int parentID, bool ysnSubLedger, bool ysnLedger, bool ysnTrbalance, bool ysnIncomeSt, bool ysnBalanceSh, int userID, int childCodeLength, int? moduleID,int unitID,decimal accountBalance)
        {
            int? accid=-1;
            int? moduleDetailsID = null;
           
            SprAccountsCOAChildAddTableAdapter adp = new SprAccountsCOAChildAddTableAdapter();
            try
            {
                adp.InsertChildAccount(accName,parentID,ysnSubLedger,ysnLedger,ysnTrbalance,ysnIncomeSt,ysnBalanceSh,userID,childCodeLength,moduleID,unitID,moduleDetailsID,null,accountBalance, ref accid);
            }
            catch
            {
                accid =-1;
            }
            return accid.ToString();
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public bool COAAccountEnableDisable(int accountID, int userID, int unitID, bool ysnEnable,bool ysnOnlyThis,ref string text,ref string value)
        {
            SprAccountsCOAEnableDisableAccountsTableAdapter adp = new SprAccountsCOAEnableDisableAccountsTableAdapter();
            try
            {
                adp.AccountsEnableDisable(accountID, userID, unitID, ysnEnable,ref text,ref value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public bool COAAccountEdit(string accName, int accountID, bool ysnSubLedger, bool ysnLedger, bool ysnTrbalance, bool ysnIncomeSt, bool ysnBalanceSh, int userID, int childCodeLength, int? moduleID, int unitID,ref string text,ref string value)
        {
           // bool ysnSuceess = false;
            SprAccountsCOAAccountEditTableAdapter adp = new SprAccountsCOAAccountEditTableAdapter();
            try
            {
                adp.EditCOAAccount(accName, accountID, ysnSubLedger, ysnLedger, ysnTrbalance, ysnIncomeSt, ysnBalanceSh, userID, childCodeLength, moduleID, unitID,ref text,ref value);
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public DataTable GetIsExpenses(string code, int unit)
        {
            try
            {
                SprAccountsCOAnochildTableAdapter adp = new SprAccountsCOAnochildTableAdapter();
                return adp.GetIsExpensesData(code, unit);
            }
            catch { return new DataTable(); }
        }        

        /// <summary>
        /// Developped By Himadri das
        /// For new Formet of Chart of Account
        /// </summary>

        public IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> GetChildDataByParentID(int unitID, int parentID)
        {
            return ChartOfAccStaticDataProvider.GetDataByUnitAndParentID(unitID.ToString(), parentID);
        }

    }
}
