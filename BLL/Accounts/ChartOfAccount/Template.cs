using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount.TemplateTDSTableAdapters;

namespace BLL.Accounts.ChartOfAccount
{
    public class Template
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public TemplateTDS.TblAccountsChartOfAccTemplateDataTable GetTemplate()
        {
            TblAccountsChartOfAccTemplateTableAdapter ta = new TblAccountsChartOfAccTemplateTableAdapter();
            return ta.GetData();
        }
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public TemplateTDS.TblAccountsChartOfAccTemplateForDDlDataTable GetTemplateByParent(string parentID)
        {
            TblAccountsChartOfAccTemplateForDDlTableAdapter ta = new TblAccountsChartOfAccTemplateForDDlTableAdapter();
            return ta.GetData(int.Parse(parentID));
        }

        ///<summary>
        ///Developped By Himadri Das
        ///</summary>

        public void AddChild(string accName, int parentID, bool ysnSubLedger, bool ysnLedger, bool ysnTrbalance, bool ysnIncomeSt, bool ysnBalanceSh, int userID, int childCodeLength,int? moduleID)
        {
            SprAccountsCOATempleteChildAddTableAdapter adp = new SprAccountsCOATempleteChildAddTableAdapter();
            try
            {
                adp.InsertChildIntoTemplete(accName, parentID, ysnSubLedger, ysnLedger, ysnTrbalance, ysnIncomeSt, ysnBalanceSh, userID, childCodeLength,moduleID);
            }
            catch
            {
            }
        }

        ///<summary>
        ///Developped By Himadri Das
        ///</summary>

        public void EnableDisableAccountFromTemplete(int accountID, int userID,bool ysnEnable,bool ysnOnlyThis)
        {
            SprAccountsCOATempleteInactiveAccountsTableAdapter adp = new SprAccountsCOATempleteInactiveAccountsTableAdapter();
            try
            {
                adp.EnableDisableAccounts(accountID, userID,ysnEnable);
            }
            catch
            {
            }
        }

        ///<summary>
        ///Developped By Himadri Das
        ///</summary>

        public TemplateTDS.TblAccountsChartOfAccTemplateDataTable GetCOATempleteByAccount(int accountID)
        {
            TblAccountsChartOfAccTemplateTableAdapter adp = new TblAccountsChartOfAccTemplateTableAdapter();
            return adp.GetDataByAccountID(accountID);
        }

        ///<summary>
        ///Developped By Himadri Das
        ///</summary>

        public void EditTempleteAccount(string accName, int accountID, bool ysnSubLedger, bool ysnLedger, bool ysnTrbalance, bool ysnIncomeSt, bool ysnBalanceSh, int userID, int childCodeLength, int? moduleID)
        {
            SprAccountsCOATempleteAccountEditTableAdapter adp = new SprAccountsCOATempleteAccountEditTableAdapter();
            try
            {
                adp.COATempleteAccountEdit(accName, accountID, ysnSubLedger, ysnLedger, ysnTrbalance, ysnIncomeSt, ysnTrbalance, userID, childCodeLength, moduleID);
            }
            catch
            {
            }
        }

    }
}
