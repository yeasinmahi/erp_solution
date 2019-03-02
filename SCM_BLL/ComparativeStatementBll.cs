using System;
using SCM_DAL.ComparativeStatementTDSTableAdapters;

namespace SCM_BLL
{
    public class ComparativeStatementBll
    {
        public string InsertRfq(int intUnitId, int intWhid,string xmlString,int enroll)
        {
            string msg = string.Empty;
            try
            {
                sprRFQTableAdapter adp = new sprRFQTableAdapter();
                adp.GetData(intUnitId, intWhid, xmlString, enroll, ref msg);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;

        }
    }
}
