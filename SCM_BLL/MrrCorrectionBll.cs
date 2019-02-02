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
        public DataTable GetMrrItemInfo( int intMrrid)
        {
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            try
            {
                return adp.GetMrrItemInfo(intMrrid);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetMrrInfo(int intMrrid)
        {
            DataTable2TableAdapter adp = new DataTable2TableAdapter();
            try
            {
                return adp.GetMrrInfo(intMrrid);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}
