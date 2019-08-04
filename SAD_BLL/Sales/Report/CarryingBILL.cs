using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Sales.Report.CarryingTDSTableAdapters;
namespace SAD_BLL.Sales.Report
{
    public class CarryingBILL
    {
        public DataTable getCarrringBill(string rate, string fdate, string tdate)
        {
            try
            {
                TblCarryingBillTableAdapter apd = new TblCarryingBillTableAdapter();
                return apd.GetData(rate, fdate, tdate);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCarryingbillJ(string narration, decimal totalsum,int unitid)
        {
            try
            {
                JVCreateALLTableAdapter apd = new JVCreateALLTableAdapter();
                return apd.GetData(narration, totalsum.ToString(), unitid);
            }
            catch { return new DataTable(); }
        }

        public void getCarryingbillJV(int jvid, int coaid, string narration, decimal Amount, string coaname)
        {
            try
            {
                tblAccountsVoucherJournalDetailsTableAdapter apd = new tblAccountsVoucherJournalDetailsTableAdapter();
                 apd.GetData(jvid, coaid, narration, Amount, coaname);
            }
            catch {  }
        }
    }
}
