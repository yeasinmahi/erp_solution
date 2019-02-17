using System;
using System.Data;
using SAD_DAL.Transfer.FGTransferTableAdapters;

namespace SCM_BLL
{
    public class FgTransferBll
    {
        public DataTable GetFgTransferReport(int type, int outWh, DateTime fromDate, DateTime toDate)
        {
            SprFGTransferTableAdapter adp = new SprFGTransferTableAdapter();
            return adp.GetData(type, outWh, fromDate, toDate);
        }
        public DataTable GetFgProductionReport(int whId, DateTime fromDate, DateTime toDate)
        {
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            return adp.GetData(whId, fromDate, toDate);
        }
    }
}