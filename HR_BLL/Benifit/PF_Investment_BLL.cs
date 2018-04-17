using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HR_DAL.Benifit;
using System.Web.UI.WebControls;
using HR_DAL.Benifit.PF_InvestmentTDSTableAdapters;

namespace HR_BLL.Benifit
{
   public  class PF_Investment_BLL
    {
       public string InvestUnitwisePF(int? intPfUnitId, int? intPFInvestmentBankAccountNo, int? intPFBankAccountNo,decimal? monInvestmentAmount, decimal? numInvestmentDuration, decimal? numInterestRate, DateTime? dteDateEffectedFrom, int? intInvestmentTypeID, string strListOfMonthAndYear, string strSeparator, int? intUserID)
        {
            //Summary    :   This function will use to Insert data into tblPFInvestment
            //Created    :   Md. Yeasir Arafat / July-23-2012
            //Modified   :   
            //Parameters :   return investmentStatus
            try
            {
                string strInvestmentStatus = "";
                SprPF_InvestmentTableAdapter tbl = new SprPF_InvestmentTableAdapter();
                tbl.InvestProvidentFund(intPfUnitId, intPFInvestmentBankAccountNo, intPFBankAccountNo, monInvestmentAmount, numInvestmentDuration, numInterestRate, dteDateEffectedFrom, intInvestmentTypeID, strListOfMonthAndYear, strSeparator, intUserID, ref strInvestmentStatus);
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

            SprPF_InvestmentGetTypeTableAdapter ad = new SprPF_InvestmentGetTypeTableAdapter();
            PF_InvestmentTDS.SprPF_InvestmentGetTypeDataTable tbl = ad.GetInvestmentType();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strInvestmentType, tbl[i].intInvestmentTypeID.ToString()));

            }

            return col;
        }
       public DataTable GetAllNonInvestedRecievedPfTransaction(int? intSoftwareLoginUserID)
        {
            //Summary    :   This function will use to get all non invested recieved pf transaction by login users permitted unit
            //Created    :   Md. Yeasir Arafat / August-25-2012
            //Modified   :   
            //Parameters :  

            SprPF_InvestmentGetAllNonInvestedRecievedPfTransactionTableAdapter objTbl = new SprPF_InvestmentGetAllNonInvestedRecievedPfTransactionTableAdapter();
            return objTbl.GetAllNonInvestedRecievedPfTransaction(intSoftwareLoginUserID);
        }
    }
}
