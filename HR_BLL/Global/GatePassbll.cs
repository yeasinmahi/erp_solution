using HR_DAL.Global.GatepassTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Global
{
    public class GatePassbll
    {
        public DataTable GatepassReasonTable()
        {
            GatepassReasonTable ta = new GatepassReasonTable();
            return ta.GetGatepassReason();
        }
    }
}
