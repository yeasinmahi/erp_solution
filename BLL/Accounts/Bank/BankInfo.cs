using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Accounts.Bank;
using DAL.Accounts.Bank.BankInfoTDSTableAdapters;
using System.Web.UI.WebControls;

namespace BLL.Accounts.Bank
{
    public class BankInfo
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankInfoTDS.TblBankInfoShortDataTable GetActiveForDDL()
        {
            TblBankInfoShortTableAdapter ta = new TblBankInfoShortTableAdapter();
            try
            {
                return ta.GetData();
            }
            catch { return null; }
        }

        public ListItemCollection GetBankList()
        {
            //Summary    :   This function will use to Load Get Banklist for Bank Dropdownlist load
            //Created    :   Md. Yeasir Arafat / July-23-2012
            //Modified   :   
            //Parameters :

            ListItemCollection col = new ListItemCollection();
            BankInfo objBankInfo = new BankInfo();
            BankInfoTDS.TblBankInfoShortDataTable tbl = new BankInfoTDS.TblBankInfoShortDataTable();
            tbl = objBankInfo.GetActiveForDDL();
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                col.Add(new ListItem(tbl[index].strBankName, tbl[index].intBankID.ToString()));
            }

            return col;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankInfoTDS.TblBankInfoShortDataTable GetActiveForDDLWithAll()
        {
            try
            {
                TblBankInfoShortTableAdapter ta = new TblBankInfoShortTableAdapter();
                BankInfoTDS.TblBankInfoShortDataTable table = ta.GetData();

                BankInfoTDS.TblBankInfoShortRow row = table.NewTblBankInfoShortRow();
                row.intBankID = 0;
                row.strBankName = "All";

                table.AddTblBankInfoShortRow(row);

                return table;
            }
            catch { return null; }
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public string BankInsertion(string bankName,string description,string code,int userID)
        {
            string result="";
            SprBankAddTableAdapter adp = new SprBankAddTableAdapter();
            try
            {
                adp.InsertBank(bankName, description,code,userID, ref result);
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            
            return result;
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>

        public BankInfoTDS.TblBankInfoDataTable GetBankInfoByID(int bankID)
        {
            TblBankInfoTableAdapter adp = new TblBankInfoTableAdapter();
            return adp.GetDataByBankID(bankID);
        }


        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public void BankInfoEdit(int bankID, string strBankCode, string strBankName, string strDescription, bool ysnEnable, string userID, int intBankID)
        {
            try
            {
                new SprBankEditTableAdapter().EditBank(intBankID, strBankName, strDescription, strBankCode, ysnEnable,int.Parse(userID));
            }
            catch
            {
            }
        }



        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public ListItemCollection GetActiveForDDL_Commercial()
        {
            ListItemCollection col = new ListItemCollection();

            TblBankInfoShortTableAdapter ta = new TblBankInfoShortTableAdapter();
            BankInfoTDS.TblBankInfoShortDataTable tbl=ta.GetData();
            col.Add(new ListItem("---Select Bank---","-1"));
                
           /* try
            {
                return ta.GetData();
            }
            catch { return null; }*/

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strBankName, tbl[i].intBankID.ToString()));
            }

            return col;

        }
    
    }

}
