using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Accounts.Bank;
using DAL.Accounts.Bank.BankBranchTDSTableAdapters;
using System.Web.UI.WebControls;

namespace BLL.Accounts.Bank
{
    public class BankBranch
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankBranchTDS.TblBankBranchInfoShortDataTable GetActiveForDDL(string bankID)
        {
            TblBankBranchInfoShortTableAdapter ta = new TblBankBranchInfoShortTableAdapter();
            try
            {
                return ta.GetData(int.Parse(bankID));
            }
            catch { return null; }
        }
        public ListItemCollection GetBankBranchList(string bankID)
        {
            //Summary    :   This function will use to Load Get BankBranchlist for load
            //Created    :   Md. Yeasir Arafat / July-23-2012
            //Modified   :   
            //Parameters :

            ListItemCollection col = new ListItemCollection();
            BankBranchTDS.TblBankBranchInfoShortDataTable tbl = new BankBranchTDS.TblBankBranchInfoShortDataTable();
            tbl = GetActiveForDDL(bankID);
            for (int index = 0; index < tbl.Rows.Count; index++)
            {
                col.Add(new ListItem(tbl[index].strBranchName, tbl[index].intBranchID.ToString()));
            }

            return col;
        }
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankBranchTDS.TblBankBranchInfoShortDataTable GetActiveForDDLWithAll(string bankID)
        {
            TblBankBranchInfoShortTableAdapter ta = new TblBankBranchInfoShortTableAdapter();
            try
            {
                
                BankBranchTDS.TblBankBranchInfoShortDataTable table = ta.GetData(int.Parse(bankID));
                BankBranchTDS.TblBankBranchInfoShortRow row = table.NewTblBankBranchInfoShortRow();
                row.intBranchID = 0;
                row.strBranchName = "All";
                table.AddTblBankBranchInfoShortRow(row);
                return table;    
            }
            catch { return null; }
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public string BankBranchInsertion(int bankid, string branchName, string description,string code,int userID)
        {
            string result="";
            SprBankBranchAddTableAdapter add = new SprBankBranchAddTableAdapter();
            try
            {
                add.InsertBranch(bankid, branchName, description,code,userID, ref result);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public BankBranchTDS.TblBankBranchInfoDataTable GetBranchDataByBankID(int bankID)
        {
            TblBankBranchInfoTableAdapter adp = new TblBankBranchInfoTableAdapter();
            return adp.GetDataByBankID(bankID);
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public void EditBranchInfo(int bankID, string strBranchCode, string strBranchName, string strDescription, bool ysnEnable, string userID, int original_intBranchID)
        {
            try
            {
                new SprBankBranchEditTableAdapter().EditBankBranch(original_intBranchID, strBranchCode, strBranchName, strDescription, ysnEnable, int.Parse(userID));
            }
            catch
            {

            }
        }

    }
}
