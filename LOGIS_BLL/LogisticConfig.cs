using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.LogisticConfigTDSTableAdapters;
using LOGIS_DAL;

namespace LOGIS_BLL
{
    public class LogisticConfig
    {
        public LogisticConfigTDS.TblLogisticConfigDataTable GetData(string unitId)
        {
            TblLogisticConfigTableAdapter ta = new TblLogisticConfigTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitId));
        }
    }
}
