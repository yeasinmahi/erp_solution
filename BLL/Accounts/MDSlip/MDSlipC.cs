using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.MDSlip;
using DAL.Accounts.MDSlip.MDSlipTDSTableAdapters;

namespace BLL.Accounts.MDSlip
{
    public  class MDSlipC
    {

        public MDSlipTDS.SprAccountsMDSlipGetDataDataTable GetDataForMDSlip(DateTime date,int unitID,int userID,ref string unitName,ref string unitAddress,ref string userName,ref decimal? wcUsed,ref decimal? plUsed,ref decimal? wcLimit,ref decimal? plLimit,ref decimal? cashInHand,ref decimal? cashAtBank)
        {
            SprAccountsMDSlipGetDataTableAdapter adp = new SprAccountsMDSlipGetDataTableAdapter();
            return adp.GetData(date,unitID,userID,ref unitName,ref unitAddress,ref userName,ref wcUsed,ref plUsed,ref wcLimit,ref plLimit,ref cashAtBank,ref cashInHand);
        }

        public MDSlipTDS.SprAccountsMDSlipQueryDataDataTable GetDataForMDAlipQuery(DateTime date, int unitID, string type)
        {
            SprAccountsMDSlipQueryDataTableAdapter adp = new SprAccountsMDSlipQueryDataTableAdapter();
            return adp.GetQueryData(date, type, unitID, 0);
        }


    }
}
