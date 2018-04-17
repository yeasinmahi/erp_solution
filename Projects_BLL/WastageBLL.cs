using Projects_DAL.WastageTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects_BLL
{
    public class WastageBLL
    {
        public DataTable GetUnitList(int intEnroll)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            { return adp.GetUnitList(intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }




















    }
}
