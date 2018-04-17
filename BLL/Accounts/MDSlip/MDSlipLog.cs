using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.MDSlip;
using DAL.Accounts.MDSlip.MDSlipLogTDSTableAdapters;

namespace BLL.Accounts.MDSlip
{
    public class MDSlipLog
    {
        public MDSlipLogTDS.TblAccountsMDSlipLogDataTable GetMDSlipLogByUnit(int unitID)
        {
            TblAccountsMDSlipLogTableAdapter adp = new TblAccountsMDSlipLogTableAdapter();
            return adp.GetMDSlipLogDataByUnit(unitID);
        }

        public MDSlipLogTDS.SprAccountsMDSlipGetLogDataForRequestDataTable GetMDSlipRequestLogByUnit(int unitID,string datetime)
        {
            if (datetime != null)
            {
                SprAccountsMDSlipGetLogDataForRequestTableAdapter adp = new SprAccountsMDSlipGetLogDataForRequestTableAdapter();
                return adp.GetMDSilpRequestLogData(unitID, DateTime.Parse(datetime));
            }
            else
            {
                return null;
            }
        }
    }
}
