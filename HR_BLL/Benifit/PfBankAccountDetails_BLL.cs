using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Benifit.PfBankAccountDetails_TDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Benifit;

namespace HR_BLL.Benifit
{
   public class PfBankAccountDetails_BLL
    {

       public ListItemCollection GetPfInvestmentBankAccountNoByUnitIdBankIdBranchId(int? intUnitId, int? intBankID, int? intBranchID)
        {
            //Summary    :   This function will use to Load Get Pf Investment Bank AccountNo By UnitId BankId BranchId for pfInvestmentDropdown load
            //Created    :   Md. Yeasir Arafat / SEPTEMBER-02-2012
            //Modified   :   
            //Parameters :

            SprPfInvestmentBankAccountNoByUnitIdBankIdBranchIdTableAdapter objSprPfInvestmentBankAccountNoByUnitIdBankIdBranchIdTableAdapter = new SprPfInvestmentBankAccountNoByUnitIdBankIdBranchIdTableAdapter();
            ListItemCollection col = new ListItemCollection();
            PfBankAccountDetails_TDS.SprPfInvestmentBankAccountNoByUnitIdBankIdBranchIdDataTable tbl = objSprPfInvestmentBankAccountNoByUnitIdBankIdBranchIdTableAdapter.GetPfInvestmentBankAccountNoByUnitIdBankIdBranchId(intUnitId,intBankID,intBranchID);
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                col.Add(new ListItem(tbl[index].strAccountNo.ToString(), tbl[index].intAccountID.ToString()));
            }

            return col;
        }

       public ListItemCollection GetBankAccountNoBy_PfUnitIdAndSearchKey(int? intPfUnitId, string strSearchKey)
       {
           //Summary    :   This function will use to Load Get Pf Investment Bank AccountNo By UnitId,search key for ddlPfBankAccount,ddlPfInvestmentAccount load
           //Created    :   Md. Yeasir Arafat / SEPTEMBER-30-2012
           //Modified   :   
           //Parameters :

           SprPF_GetBankAccountNoBy_PfUnitIdAndSearchKeyTableAdapter objSprPF_GetBankAccountNoBy_PfUnitIdAndSearchKeyTableAdapter = new SprPF_GetBankAccountNoBy_PfUnitIdAndSearchKeyTableAdapter();
           ListItemCollection col = new ListItemCollection();
           PfBankAccountDetails_TDS.SprPF_GetBankAccountNoBy_PfUnitIdAndSearchKeyDataTable tbl = objSprPF_GetBankAccountNoBy_PfUnitIdAndSearchKeyTableAdapter.GetBankAccountNoBy_PfUnitIdAndSearchKey(intPfUnitId, strSearchKey);
           for (int index = 0; index < tbl.Rows.Count; index++)
           {
               col.Add(new ListItem(tbl[index].strAccountNo.ToString(), tbl[index].intAccountID.ToString()));
           }

           return col;
       }
    }
}
