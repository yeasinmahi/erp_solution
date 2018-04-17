using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking;
using DAL.Accounts.Banking.AdviceTDSTableAdapters;

namespace BLL.Accounts.Banking
{
    public class Advice
    {
        public AdviceTDS.SprBankLoanAdvicePrintGetDataDataTable GetPrintData(string vCode,int vID,int unitID,ref string unitName,ref string unitAddress,ref string accountNo,ref DateTime? adviceDate,ref string adviceNumber,ref string securityCode)
        {
            SprBankLoanAdvicePrintGetDataTableAdapter adp = new SprBankLoanAdvicePrintGetDataTableAdapter();
            return adp.GetPrintAdviceData(vID, vCode, unitID,
                                            ref unitName,
                                            ref unitAddress,
                                            ref accountNo,
                                            ref adviceDate,
                                            ref adviceNumber,
                                            ref securityCode);
        }

    }
}
