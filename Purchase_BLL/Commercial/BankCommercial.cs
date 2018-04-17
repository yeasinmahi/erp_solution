using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial.BankTDSTableAdapters;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class BankCommercial
    {
        public ListItemCollection GetBankAccount(string BankID, string unitID)
        {
            ListItemCollection col = new ListItemCollection();
            QryBankAccountInfoWithUnitTableAdapter adp=new QryBankAccountInfoWithUnitTableAdapter();
            BankTDS.QryBankAccountInfoWithUnitDataTable tbl=adp.GetDataByUnitAndBank(int.Parse(BankID),unitID==""?0:int.Parse(unitID));

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strDisplayName,tbl[i].intAccountID.ToString()));
            }
            return col;
        }
    }
}
