using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Vat.CreditNoteTDSTableAdapters;

namespace SAD_BLL.Vat
{
    public class CreditNoteBLL
    {
        public DataTable getCreditchallan(int unitid,int accid,int intitemid)
        {
            try
            {
                tblChallanListTableAdapter adp = new tblChallanListTableAdapter();
                return adp.GetChallanList(unitid, accid, intitemid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GETCreditlist(string Challanno, int unitid, int Accid)
        {
            try
            {
                tblChallanINFOTableAdapter adp = new tblChallanINFOTableAdapter();
                return adp.GetChallanView(Challanno, unitid, Accid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getChallanInfo(string Challanno, int unitid, int Accid, int intitemid)
        {
            try
            {
                tblProductInfoTableAdapter adp = new tblProductInfoTableAdapter();
                return adp.GetProductList(Challanno, unitid, Accid, intitemid);
            }
            catch { return new DataTable(); }
        }
    }
}
