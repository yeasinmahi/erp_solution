using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Global.IncentiveTDSTableAdapters;
using SAD_DAL.Global;

namespace SAD_BLL.Global
{
    public class Incentive
    {
        public IncentiveTDS.TblIncentiveDataTable GetIncentiveList(string unitId)
        {
            TblIncentiveTableAdapter ta = new TblIncentiveTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitId));
        }
        public decimal GetIncentive(string extId, string uom, string product, string currency)
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

            SprItemGetIncentiveTableAdapter ta = new SprItemGetIncentiveTableAdapter();
            ta.GetData(int.Parse(extId), uom_, pr, cr, ref price);

            return price.Value;
        }
    }
}

