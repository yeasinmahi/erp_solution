using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.ProvidentFund.ProvidentFund_TDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.ProvidentFund;

namespace HR_BLL.ProvidentFund
{
   public class PF_Investment
    {
       public DataTable GetAllNonInvestedPFTransaction(int? intSoftwareLoginUserID)
       {
           //Summary    :   This function will use to get all non-invested provident fund
           //Created    :   Md. Yeasir Arafat / July-21-2012
           //Modified   :   
           //Parameters :   return datatable 

           try
           {
               SprPFInvestment_GetAllNonInvestedPFTransactionTableAdapter objSprPFInvestment_GetAllNonInvestedPFTransactionTableAdapter = new SprPFInvestment_GetAllNonInvestedPFTransactionTableAdapter();
               return objSprPFInvestment_GetAllNonInvestedPFTransactionTableAdapter.GetNonInvestedPFAmount(intSoftwareLoginUserID);
           }
           catch
           {return  new DataTable ();
               
           }
       }

       public string InvestUnitwisePF(int? intUnitId, int? intBankId, int? intBranchId, decimal? monInvestedAmount, decimal? numInvestmentDuration, decimal? numInterestRate, DateTime? dteDateEffectedFrom, int? intInvestmentTypeID, string strListOfMonthAndYear, string strSeparator)
       {
           //Summary    :   This function will use to Insert data into tblPFInvestment
           //Created    :   Md. Yeasir Arafat / July-23-2012
           //Modified   :   
           //Parameters :   return investmentStatus
           try
           {
               string strInvestmentStatus = "";
               SprPFInvestment_InvestUnitwiseSelectedAmountTableAdapter tbl = new SprPFInvestment_InvestUnitwiseSelectedAmountTableAdapter();
               tbl.InvestUnitwisePF(intUnitId, intBankId, intBranchId, monInvestedAmount, numInvestmentDuration, numInterestRate, dteDateEffectedFrom, intInvestmentTypeID,strListOfMonthAndYear, strSeparator, ref strInvestmentStatus);
               return strInvestmentStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }
       
       public ListItemCollection GetInvestmentType()
        {
            //Summary    :   This function will use to get all Active Investment type
            //Created    :   Md. Yeasir Arafat / July-24-2012
            //Modified   :   
            //Parameters :   

            ListItemCollection col = new ListItemCollection();

            SprPF_GetInvestmentTypeTableAdapter ad = new SprPF_GetInvestmentTypeTableAdapter();
            ProvidentFund_TDS.SprPF_GetInvestmentTypeDataTable tbl = ad.GetData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strInvestmentType, tbl[i].intInvestmentTypeID.ToString()));

            }

            return col;
        }
    }
    
}
