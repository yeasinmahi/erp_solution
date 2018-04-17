using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher.VoucherRollbackTDSTableAdapters;

namespace BLL.Accounts.Voucher
{
    public class VoucherRollback
    {
        public bool Rollback(string code,string voucherID,string userID,string unitId,string type,string remark)
        {
            bool? b = false;
            SprAccountsSubledgerRollbackTableAdapter ta = new SprAccountsSubledgerRollbackTableAdapter();
            ta.GetData(code, int.Parse(voucherID), int.Parse(userID), int.Parse(unitId), type, remark, ref b);
            return b.Value;
        }

        public string ChequeNoInterchange(string unitId, string code1,string code2, string userId)
        {
            string error = "";

            SprAccountsVoucherChequeNoInterchangeTableAdapter ta = new SprAccountsVoucherChequeNoInterchangeTableAdapter();
            ta.GetData(int.Parse(unitId), code1, code2, int.Parse(userId), ref error);

            return error;
        }
    }
}
