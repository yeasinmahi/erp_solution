using System;
using System.Data;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class CodeInfoBll
    {
        private readonly CodeInfoDal _dal = new CodeInfoDal();
        private DataTable _dt = new DataTable();
        public string GetVoucherCode(int intUnitId, string strCodeFor, DateTime dateFor, string strPrefix, bool ysnNeedPrefix)
        {
            return _dal.GetVoucherCode(intUnitId, strCodeFor, dateFor, strPrefix, ysnNeedPrefix);
        }
        public string GetJurnalVoucherCode(int intUnitId)
        {
            return _dal.GetVoucherCode(intUnitId, "voucherJV", DateTime.Now, "JV", true);
        }
    }
}
