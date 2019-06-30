using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Payment.BillRegisterDetailMrrTableAdapters;

namespace DALOOP.Payment
{
    public class BillRegisterDetailMrrDal
    {
        public DataTable GetBillRegisterDetailsMrrByMrrId(int mrrId)
        {
            try
            {
                tblBillRegisterDetailMRRTableAdapter adp = new tblBillRegisterDetailMRRTableAdapter();
                return adp.GetDataByMrrId(mrrId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetBillRegisterDetailsMrrByBillId(int billId)
        {
            try
            {
                tblBillRegisterDetailMRRTableAdapter adp = new tblBillRegisterDetailMRRTableAdapter();
                return adp.GetDataByBillId(billId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
