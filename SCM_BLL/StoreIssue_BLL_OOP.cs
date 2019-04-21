using SCM_DAL.IndentTDSTableAdapters;
using System;
using System.Data;
using SCM_DAL.ItemTDSTableAdapters;
using ServiceGateWay;


namespace SCM_BLL
{
    public class StoreIssue_BLL_OOP
    {
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
