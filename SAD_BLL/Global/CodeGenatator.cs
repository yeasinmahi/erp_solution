using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Global.CodeGenaratorTDSTableAdapters;

namespace SAD_BLL.Global
{
    public class CodeGenatator
    {
        public string GetPriceBatchCode(string unitID)
        {
            string code="";
            SprGetGeneratedCodeTableAdapter ta = new SprGetGeneratedCodeTableAdapter();
            ta.GetData(int.Parse(unitID), "priceChange", DateTime.Now.Date, "PR", true, ref code);

            return code;
        }
    }
}
