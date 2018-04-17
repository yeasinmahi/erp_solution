using SCM_DAL.IndentTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class StoreIssue_BLL
    {
        public DataTable GetViewData(int part, string xml,int Wh, int reqId, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            SprStoreIssueTableAdapter adp = new SprStoreIssueTableAdapter();
            return adp.GetStoreIssueData(part, xml, Wh, reqId, dteDate, enroll, ref strMsg);

        }

        public string StoreIssue(int part, string xml, int Wh, int reqId, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                SprStoreIssueTableAdapter adp = new SprStoreIssueTableAdapter();
                adp.GetStoreIssueData(part, xml, Wh, reqId, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }
    }
}
