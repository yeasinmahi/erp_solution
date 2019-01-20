using System;
using System.Data;
using SAD_DAL.Transfer.FGTransferTableAdapters;

namespace SCM_BLL
{
    public class FgTransferBll
    {
        public DataTable GetData(int type, int outWh, DateTime fromDate, DateTime toDate)
        {
            SprFGTransferTableAdapter adp = new SprFGTransferTableAdapter();
            return adp.GetData(type, outWh, fromDate, toDate);
        }
    }
}