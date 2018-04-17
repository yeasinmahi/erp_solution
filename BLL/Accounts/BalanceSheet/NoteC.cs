using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.BalanceSheet;
using DAL.Accounts.BalanceSheet.NoteTDSTableAdapters;
using DAL.Accounts.BalanceSheet.DepNoteTDSTableAdapters;

namespace BLL.Accounts.BalanceSheet
{
    public class NoteC
    {

        public NoteTDS.SprAccountsNoteGetDataDataTable GetData(DateTime fromDate,DateTime toDate,bool ysnAccountingPeriod,int unitID,int userID,ref string unitName,ref string unitAddress)
        {
            SprAccountsNoteGetDataTableAdapter adp = new SprAccountsNoteGetDataTableAdapter();
            return adp.GetData(fromDate, toDate, ysnAccountingPeriod, unitID, userID,ref unitName,ref unitAddress);


        }

        public DepNoteTDS.SprAccountsNoteDepreciationDataTable GetDepreciation(DateTime fromDate, DateTime toDate, bool ysnAccountingPeriod, int unitID, int userID, ref string unitName, ref string unitAddress)
        {
            SprAccountsNoteDepreciationTableAdapter adp = new SprAccountsNoteDepreciationTableAdapter();
            return adp.GetDepData(fromDate,toDate,ysnAccountingPeriod,unitID,userID,ref unitName,ref unitAddress);
        }

    }
}
