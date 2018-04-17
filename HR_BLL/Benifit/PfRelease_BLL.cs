using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Benifit.PfRelease_TDSTableAdapters;
using System.Data;

namespace HR_BLL.Benifit
{
   public class PfRelease_BLL
    {

       public string ReleaseProvidentFund(string strEmployeeCode, decimal? monProfitAmount, decimal? monTotalReleaseAmount, decimal? monEmployeeSubcription, decimal? monEmployerContribution, DateTime? dteReleaseDate, int? intPaidBy, int? intUserID)
       {
           string strReleaseStatus = "";
           SprPfRealseTableAdapter objSprPfRealseTableAdapter = new SprPfRealseTableAdapter();
           objSprPfRealseTableAdapter.RealseProvidentFund(strEmployeeCode, monProfitAmount, monEmployeeSubcription, monEmployerContribution, dteReleaseDate, intPaidBy, intUserID, ref strReleaseStatus);
           return strReleaseStatus;
       }

       public DataTable GetProvidentFundSummaryByEmployeeCode(string strEmployeeCode,ref bool? ysnPaid)
       {
           try
           {
               SprPF_RealseGetProvidentFundSummaryByEmployeeCodeTableAdapter tbl = new SprPF_RealseGetProvidentFundSummaryByEmployeeCodeTableAdapter();
               return tbl.GetProvidentFundSummaryByEmployeeCode(strEmployeeCode, ref ysnPaid);
           }
           catch 
           {
               DataTable odt = new DataTable();
               return odt;
           }
       }


    }
}
