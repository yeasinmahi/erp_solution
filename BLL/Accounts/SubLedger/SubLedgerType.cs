using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Accounts.SubLedger
{    
    public class SubLedgerType
    {
        public enum SubLedgerInputTypes
        {
            BankPay
            ,
            BankReceive
                ,
            CashPay
                ,
            CashReceive
                ,
            Journal
                , Contra
        };

        public string GetKeyForType(SubLedgerInputTypes type)
        {   
            switch (type)
            {
                case SubLedgerInputTypes.BankPay:
                    return "BP";

                case SubLedgerInputTypes.BankReceive:
                    return "BR";

                case SubLedgerInputTypes.CashPay:
                    return "CP";

                case SubLedgerInputTypes.CashReceive:
                    return "CR";

                case SubLedgerInputTypes.Contra:
                    return "CN";

                case SubLedgerInputTypes.Journal:
                    return "JR";

                default:
                    return "";

            }
        }        
    }
}
