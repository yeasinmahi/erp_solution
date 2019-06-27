using System.Data;
using DALOOP.Payment;

namespace BLL.Payment
{
    public class BillRegisterDetailMrrBll
    {
        private readonly BillRegisterDetailMrrDal _dal = new BillRegisterDetailMrrDal();

        public DataTable GetBillRegisterDetailsMrrByBillId(int billId)
        {
            return _dal.GetBillRegisterDetailsMrrByBillId(billId);
        }
        public DataTable GetBillRegisterDetailsMrrByMrrId(int mrrId)
        {
            return _dal.GetBillRegisterDetailsMrrByMrrId(mrrId);
        }
    }
}
