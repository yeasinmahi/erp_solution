using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.MDSlip.MDSlipRequestTDSTableAdapters;
using DAL.Accounts.MDSlip;
using System.Globalization;

namespace BLL.Accounts.MDSlip
{
    public class MDSlipRequst
    {
        public void InsertMDSlipRequest(string unitID, string userID, string mdSilpRequestDate,ref int? waitTimeinSecond)
        {
            DateTimeFormatInfo dtf = new DateTimeFormatInfo();
            dtf.ShortDatePattern = "dd/MM/yyyy hh:mm tt";
            DateTime mdSlipdate = Convert.ToDateTime(mdSilpRequestDate, dtf);     
            SprAccountsMDSlipRequestInsertTableAdapter adp = new SprAccountsMDSlipRequestInsertTableAdapter();
            adp.InsertMDSliprequest(mdSlipdate,
                                     DateTime.Now,
                                     int.Parse(userID),
                                     int.Parse(unitID),
                                     ref waitTimeinSecond
                                  );
        }
    }
}
