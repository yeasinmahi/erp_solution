using System;
using DAL.Accounts.CodeInfoTdsTableAdapters;

namespace DALOOP.Accounts
{
    public class CodeInfoDal
    {
        public string GetVoucherCode(int intUnitId, string strCodeFor, DateTime dateFor, string strPrefix, bool ysnNeedPrefix)
        {
            string strCode = string.Empty;
            try
            {
                sprGetGeneratedCodeTableAdapter adp = new sprGetGeneratedCodeTableAdapter();
                adp.GetData(intUnitId, strCodeFor, dateFor, strPrefix, ysnNeedPrefix, ref strCode);
            }
            catch (Exception e)
            {
                // ignored
            }
            return strCode;
        }
    }
}
