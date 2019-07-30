using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DAL.Global.WareHouseTableAdapters;
namespace HR_BLL.Global
{
    public class WareHouse
    {
        public DataTable GetWareHouseByUnit(int UnitId)
        {
            TblWHTableAdapter adp = new TblWHTableAdapter();
            try
            {
                return adp.GetFromWHByUnit(UnitId);

            }
            catch
            {
                return new DataTable();
            }
        }
    }
}
