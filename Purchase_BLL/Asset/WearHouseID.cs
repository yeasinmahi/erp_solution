using Purchase_DAL.Asset;
using Purchase_DAL.Asset.SearchTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_BLL.Asset
{
    class WearHouseID
    {
        public SearchTDS.TblWearHouseDataTable GetUnits()
        {
            TblWearHouseTableAdapter ta = new TblWearHouseTableAdapter();
            return ta.WareHouseGetData( );
        }
    }
}
