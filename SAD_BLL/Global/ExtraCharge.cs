using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Global.ExtraChargeTDSTableAdapters;
using SAD_DAL.Global;

namespace SAD_BLL.Global
{
    public class ExtraCharge
    {
        public ExtraChargeTDS.TblExtraChargeDataTable GetExtraChargeList(string unitId)
        {
            TblExtraChargeTableAdapter ta = new TblExtraChargeTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitId));
        }
        public decimal GetExtraCharg(string extId, string uom,string product,string currency)
        {

            if (extId.ToString() == "") return 0;

            int? uom_ = null, pr = null, cr = null;

            try { uom_ = int.Parse(uom); }
            catch { }
            try { pr = int.Parse(product); }
            catch { }
            try { cr = int.Parse(currency); }
            catch { }

            decimal? price = 0;
            
            SprItemGetExtraChargeTableAdapter ta = new SprItemGetExtraChargeTableAdapter();
            ta.GetData(int.Parse(extId), uom_, pr, cr, ref price);

            return price.Value;
        }
    }
}
