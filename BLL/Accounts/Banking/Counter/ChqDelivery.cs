using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking.Counter.ChqDeliveryTDSTableAdapters;
using DAL.Accounts.Banking.Counter;
using DAL.Accounts.Banking.Counter.BoothSignTDSTableAdapters;
using GLOBAL_BLL;

namespace BLL.Accounts.Banking.Counter
{
    public class ChqDelivery
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>

        public void TakeSign(string voucherId,string code,string boothId,string unitId,string userId,ref string bothSignPk,ref string error)
        {
            SprBoothChequeDeliveryTakeSignTableAdapter ta = new SprBoothChequeDeliveryTakeSignTableAdapter();
            int? boothPk=null;
            ta.GetData(int.Parse(voucherId), code, int.Parse(boothId), int.Parse(unitId), int.Parse(userId), ref boothPk, ref error);
            bothSignPk = boothPk.Value.ToString();
        }        

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ChqDeliveryTDS.SprAccountsVoucherBankGetDataForChqSearchDataTable GetBankVoucherListForChqSearch(string unitID, string fromDate, string toDate, string customerCode, string chequeNo, bool isReady, bool isPending, bool isGiven)
        {
            DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(toDate);
            if (frm == null) { frm = DateTime.Now.Date.AddDays(-365); }
            if (to == null) { to = DateTime.Now.Date.AddDays(180); }
            to = to.Value.AddDays(1);

            if ("" + chequeNo != "") customerCode = null;

            if ("" + chequeNo != "" || "" + customerCode != "")
            {
                SprAccountsVoucherBankGetDataForChqSearchTableAdapter ta = new SprAccountsVoucherBankGetDataForChqSearchTableAdapter();
                return ta.GetData(chequeNo, customerCode, int.Parse(unitID), isReady, isPending, isGiven, frm, to, true);
            }
            return null;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void ChequeIssued(string voucherId,string code,string boothId,string unitId,string userId,string bothSignPk,string imgUrl,ref string error)
        {
            SprBoothChequeDeliveryCompleteTableAdapter ta = new SprBoothChequeDeliveryCompleteTableAdapter();
            ta.GetData(int.Parse(voucherId), code, int.Parse(boothId), int.Parse(unitId), int.Parse(userId), int.Parse(bothSignPk), imgUrl, ref error);
        }
    }
}
