using System.Data;
using SCM_DAL.RFQTDSTableAdapters;
namespace SCM_BLL
{
    public class RFQBLL
    {
        public DataTable getRFQBreakup(string hscode)
        {
            try
            {
                tblIndentCOuntTableAdapter adp = new tblIndentCOuntTableAdapter();
                return adp.GetCounts(hscode);
            }
            catch { return new DataTable(); }
        }

        public void getRFQItemUpdate( string hscode, int Itemid)
        {
            try
            {
                tblItemListTableAdapter adp = new tblItemListTableAdapter();
                 adp.GetData(hscode, Itemid);
            }
            catch { }
        }

        public void getInsert(int unitid, int whid, int enroll)
        {
            try
            {
                tblRFQMainTableAdapter adp = new tblRFQMainTableAdapter();
                adp.GetRFQInsert(unitid, whid,  enroll);
            }
            catch { }
        }

        public DataTable getAutoid(int userid)
        {
            try
            {
                tblRFQMain1TableAdapter adp = new tblRFQMain1TableAdapter();
                return   adp.GetData(userid);
            }
            catch { return new DataTable(); }
        }

        public void getinsertDetailsRFQ(int intAutoid, int indentId, int itemId, decimal numIndentQty, decimal newRFQQTY, int userid, int whid)
        {
            try
            {
                tblRFQDetailTableAdapter adp = new tblRFQDetailTableAdapter();
                 adp.GetData(intAutoid, indentId, itemId, numIndentQty, newRFQQTY, userid,whid);
            }
            catch {  }
        }
    }
}
