using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using HR_DAL.Benifit;
using HR_DAL.Benifit.PF_RecieveTDSTableAdapters;

namespace HR_BLL.Benifit
{
    public class PF_Recieve_BLL
   {

        public DataTable GetPfRecieveDetails(int? intPFUnitId, int? intAccountNo)
       {
           //Summary    :   This function will use to get PF_BankRecieveDetails
           //Created    :   Md. Yeasir Arafat / August-09-2012
           //Modified   :   
           //Parameters :   return bankRecieveDetails

           Spr_RecieveBankStatementDetailsTableAdapter tbl = new Spr_RecieveBankStatementDetailsTableAdapter();
           return tbl.GetPFBankRecieveDetails(intPFUnitId, intAccountNo);
       }
       public string ReceiveUnitwiseSelectedProvidentFund(int? intPFUnitId, string strVoucharCode, string strCheckNo, decimal? monAmount, int? intAccountNo, string strPerticulars, int intUserID)
       {
           //Summary    :   This function will use to insert bank recieve
           //Created    :   Md. Yeasir Arafat / August-09-2012
           //Modified   :   
           //Parameters :   return insert status

           try
           {
               SprPF_ReceiveUnitwiseSelectedProvidentFundTableAdapter tbl = new SprPF_ReceiveUnitwiseSelectedProvidentFundTableAdapter();
               string strInsertStatus = "";
               //tbl.ReceiveUnitwiseSelectedProvidentFund(intUnitId, strVoucharCode, strCheckNo, monAmount, intAccountNo, strPerticulars,
               //                       ref strInsertStatus);
               tbl.ReceiveUnitwiseSelectedProvidentFund(intPFUnitId, strVoucharCode, strCheckNo, monAmount, intAccountNo, strPerticulars, intUserID, ref strInsertStatus);
               return strInsertStatus;
           }
           catch (Exception exception)
           {
               return exception.Message.ToString();
           }
          
       }
       
       public ListItemCollection GetPfAccountByUint(int? intUnit)
        {
            //Summary    :   This function will use to Load Get CountryList for countryDropdown load
            //Created    :   Md. Yeasir Arafat / August-09-2012
            //Modified   :   
            //Parameters :

            ListItemCollection col = new ListItemCollection();
            Spr_GetPfAccountByUnitIdTableAdapter objSpr_GetPfAccountByUnitIdTableAdapter = new Spr_GetPfAccountByUnitIdTableAdapter();

            var tbl = objSpr_GetPfAccountByUnitIdTableAdapter.GetData(intUnit);
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                col.Add(new ListItem(tbl[index].strAccountNo, tbl[index].intAccountID.ToString()));
            }

            return col;
        }
       public ListItemCollection GetVoucharCodeByUnitId(int? intPfUnitId)
        {
            //Summary    :   This function will use to Load Get vouchar code by unit id
            //Created    :   Md. Yeasir Arafat / August-14-2012
            //Modified   :   
            //Parameters :

            ListItemCollection col = new ListItemCollection();
            Spr_GetVoucharCodeByUnitTableAdapter objSprPF_GetVoucharCodeByUnitTableAdapter = new Spr_GetVoucharCodeByUnitTableAdapter();

            var tbl = objSprPF_GetVoucharCodeByUnitTableAdapter.GetVoucharCodeByUnit(intPfUnitId);
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                col.Add(new ListItem(tbl[index].strVoucherCode, tbl[index].strVoucherCode));
            }

            return col;
        }
       
   }
}
