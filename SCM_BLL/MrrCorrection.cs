using SCM_DAL.MrrCorrectionTableAdapters;
using System;
using System.Data;

namespace SCM_BLL
{
    public class MrrCorrectionBll
    {
        public DataTable CorrectionMrr(int intPart, int intMRRID)
        {
            sprMRRTableAdapter adp = new sprMRRTableAdapter();
            try
            {
                return adp.GetData(intPart, intMRRID);
            }
            catch (Exception ex) {
                return new DataTable();
            }
        }
    }
}
