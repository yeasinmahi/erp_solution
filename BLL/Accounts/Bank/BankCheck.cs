using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Bank;
using DAL.Accounts.Bank.BankCheckTDSTableAdapters;

namespace BLL.Accounts.Bank
{
    public class BankCheck
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public string GetCheckNo(string accountID)
        {
            string checkNo = "";
            bool? isReuse = false;
            SprBankGetCheckNoTableAdapter ta = new SprBankGetCheckNoTableAdapter();
            if (accountID != "") ta.GetData(int.Parse(accountID), ref checkNo, ref isReuse);

            return checkNo;
        }
        /// <summary>
        /// Developped By Konock
        /// </summary>
        public string GetAdviceNo(int unit)
        {
            string adviceNo = "";
            SprGetGeneratedAdviceCodeTableAdapter ta = new SprGetGeneratedAdviceCodeTableAdapter();
            ta.GetAdviceLastNoData(unit, ref adviceNo);
            return adviceNo;
        }
        /// <summary>
        /// Developped By Akramul Haider
        /// Active > a, Inactive > i, Completed > c
        /// </summary>
        public BankCheckTDS.TblBankCheckBookInfoDataTable GetCheckBookList(string accountID, char type)
        {
            TblBankCheckBookInfoTableAdapter ta = new TblBankCheckBookInfoTableAdapter();
            try
            {
                if(type=='a')return ta.GetDataByAccount(10, int.Parse(accountID), true, false);
                else if (type == 'i') return ta.GetDataByAccount(10, int.Parse(accountID), false, false);
                else return ta.GetDataByAccount(10, int.Parse(accountID), true, true);
            }
            catch { return null; }
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void CheckBookAdd(string accountID, string startNo, string endNo, string userID)
        {
            string leftPart = "";
            int lastUsedNum = 0, endUsedNum = 0;
            GetChequeDetails(startNo, endNo, ref leftPart, ref lastUsedNum, ref endUsedNum);

            SprBankCheckBookAddTableAdapter ta = new SprBankCheckBookAddTableAdapter();
            ta.GetData(null, int.Parse(accountID), startNo, endNo, int.Parse(userID), leftPart, lastUsedNum, endUsedNum, null);
            
        }
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void CheckBookUpdate(string userID, string strStart, string strEnd, string strCancelledCheckNo, bool ysnEnable, int intCheckBookID)
        {
            string leftPart = "";
            int lastUsedNum = 0, endUsedNum = 0;
            GetChequeDetails(strStart, strEnd, ref leftPart, ref lastUsedNum, ref endUsedNum);

            SprBankCheckBookAddTableAdapter ta = new SprBankCheckBookAddTableAdapter();
            ta.GetData(intCheckBookID, null, strStart, strEnd, int.Parse(userID), leftPart, lastUsedNum, endUsedNum, ysnEnable);

        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void CheckCancel(string userID, string checkNo, string checkBookID, bool isManuallyEntered,string note, string bankAccountId)
        {
            TblBankCheckCancelTableAdapter ta = new TblBankCheckCancelTableAdapter();
            ta.InsertQuery(int.Parse(checkBookID), checkNo, int.Parse(userID), isManuallyEntered, note, int.Parse(bankAccountId));
        }

        private void GetChequeDetails(string startNo, string endNo,ref string leftPart,ref int lastUsedNum,ref int endUsedNum)
        {
            string str1, str2;
            int length = 1;

            if (startNo.Length >= endNo.Length)
            {
                str1 = startNo;
                str2 = endNo;
            }
            else
            {
                str2 = startNo;
                str1 = endNo;
            }

            while (length <= str2.Length)
            {
                if (str1.Substring(0, length) == str2.Substring(0, length))
                {
                    leftPart = str1.Substring(0, length);
                    length++;
                }
                else
                {
                    break;
                }
            }
            length--;
            str1 = str1.Substring(length);
            str2 = str2.Substring(length);

            try
            {
                lastUsedNum = Convert.ToInt32(str1);
                endUsedNum = Convert.ToInt32(str2);
            }
            catch
            {
                lastUsedNum = 0;
                endUsedNum = 0;
            }
        }
    }
}
