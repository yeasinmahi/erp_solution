using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking.Counter.BoothSignTDSTableAdapters;
using DAL.Accounts.Banking.Counter;

namespace BLL.Accounts.Banking.Counter
{
    public class BoothSign
    {
        public void CancelData(string userId, string bothSignPk)
        {
            TblBoothSignDataTableAdapter ta = new TblBoothSignDataTableAdapter();
            ta.Cancel(int.Parse(userId), int.Parse(bothSignPk));
        }

        public void GiveSignature(string id, byte[] sign)
        {
            TblBoothSignDataTableAdapter ta = new TblBoothSignDataTableAdapter();
            ta.UpdateSignature(sign, int.Parse(id));
        }

        public BoothSignTDS.TblBoothSignDataDataTable GetDataById(string id)
        {
            TblBoothSignDataTableAdapter ta = new TblBoothSignDataTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }
    }
}
