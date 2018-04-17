using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.GLOBAL.CodeGenatatorTDSTableAdapters;

namespace LOGIS_BLL.GLOBAL
{
    public class CodeGenatator
    {
        public string GetPriceBatchCode(string unitID)
        {
            string code = "";
            SprGetGeneratedCodeTableAdapter ta = new SprGetGeneratedCodeTableAdapter();
            ta.GetData(int.Parse(unitID), "priceChange", DateTime.Now.Date, "PR", true, ref code);

            return code;
        }

        public string GetLogisGainBatchCode(string unitID)
        {
            string code = "";
            SprGetGeneratedCodeTableAdapter ta = new SprGetGeneratedCodeTableAdapter();
            ta.GetData(int.Parse(unitID), "priceChangeLogis", DateTime.Now.Date, "LP", true, ref code);

            return code;
        }

        public string GetLogisGainGroupBatchCode(string unitID)
        {
            string code = "";
            SprGetGeneratedCodeTableAdapter ta = new SprGetGeneratedCodeTableAdapter();
            ta.GetData(int.Parse(unitID), "priceChangeLogisGroup", DateTime.Now.Date, "LG", true, ref code);

            return code;
        }
    }
}
