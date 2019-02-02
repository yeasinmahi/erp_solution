using SCM_DAL.MrrCorrectionTableAdapters;
using System;
using System.Data;

namespace SCM_BLL
{
    public class MrrCorrectionBll
    {
        public DataTable CorrectionMrr(int intPart, int intMrrid, int enroll, out string message)
        {
            message = null;
            sprMRRCorrectionTableAdapter adp = new sprMRRCorrectionTableAdapter();
            try
            {
                return adp.GetData(intPart, intMrrid, enroll,ref message);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return new DataTable();
            }
        }
    }
}
