using System;
using System.Data;
using DAL.HR.UnitTdsTableAdapters;

namespace DALOOP.HR
{
    public class UnitDal
    {
        public DataTable GetUnitByWhId(int whId)
        {
            try
            {
                tblWearHouseTableAdapter adp = new tblWearHouseTableAdapter();
                return adp.GetData(whId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }
    }
}
