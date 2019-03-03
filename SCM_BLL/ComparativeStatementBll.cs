using System;
using System.Data;
using SCM_DAL.ComparativeStatementTDSTableAdapters;

namespace SCM_BLL
{
    public class ComparativeStatementBll
    {
        public DataTable InsertRfq(int intUnitId, int intWhid,string xmlString,int enroll, out string msg)
        {
            msg = string.Empty;
            try
            {
                sprRFQTableAdapter adp = new sprRFQTableAdapter();
                return adp.GetData(intUnitId, intWhid, xmlString, enroll, ref msg);
            }
            catch (Exception e)
            {
                
                msg = e.Message;
                return new DataTable();
            }

        }
    }
}
