using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Benifit.PF_MaturityTableAdapters;
using System.Data;

namespace HR_BLL.Benifit
{
   public class PF_Maturity_BLL
    {
       public string MaturedPfInvestment(int? intInvestmentId, decimal? monTotalProfit, decimal? numActualDuration, decimal? numMaturedInterest,int? intUserID)
       {
           //Summary    :   This function will use to Matured Invested amount
           //Created    :   Md. Yeasir Arafat / September-04-2012
           //Modified   :   
           //Parameters :   return strMaturityStatus
           try
           {
               string strMaturityStatus = "";
               SprPF_MaturedTableAdapter tbl = new SprPF_MaturedTableAdapter();
               tbl.MaturedProvidentFund(intInvestmentId, monTotalProfit, numActualDuration, numMaturedInterest, intUserID, ref strMaturityStatus);
               return strMaturityStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }
       }

       public DataTable GetNonMaturedInvestmentDetailsForDatagridByUnitId(int? intUnitID)
       {
           //Summary    :   This function will use to get pf investment non matured details for datagrid by unit id
           //Created    :   Md. Yeasir Arafat / September-03-2012
           //Modified   :   
           //Parameters :   

           try
           {
               SprPF_MaturedGetNonMaturedInvestmentDetailsForDatagridByUnitIdTableAdapter tbl = new SprPF_MaturedGetNonMaturedInvestmentDetailsForDatagridByUnitIdTableAdapter();
               DataTable odtReturn = new DataTable();
               return tbl.GetNonMaturedInvestmentDetailsForDatagridByUnitId(intUnitID);
           }
           catch
           {
               DataTable odt = new DataTable();
               return odt;
           }
       }
    }
}
