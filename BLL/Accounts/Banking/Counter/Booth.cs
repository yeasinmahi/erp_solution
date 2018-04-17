using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking.Counter.BoothTDSTableAdapters;
using DAL.Accounts.Banking.Counter;

namespace BLL.Accounts.Banking.Counter
{
    public class Booth
    {
        public BoothTDS.QryBoothByLocationDataTable GetAllActiveBoothsByLocation(string locationId)
        {
            QryBoothByLocationTableAdapter ta = new QryBoothByLocationTableAdapter();
            return ta.GetDataByLocation(true, int.Parse(locationId));
        }

        public BoothTDS.QryBoothByUnitDataTable GetAllActiveBoothsByUnit(string unitId)
        {
            QryBoothByUnitTableAdapter ta = new QryBoothByUnitTableAdapter();
            return ta.GetDataByUnit(true, int.Parse(unitId));
        }

        public BoothTDS.TblBoothDataTable GetAllActiveBooths()
        {
            TblBoothTableAdapter ta = new TblBoothTableAdapter();
            return ta.GetActIncData(true);
        }

        public BoothTDS.TblBoothLocationDataTable GetBoothsLocation()
        {
            TblBoothLocationTableAdapter ta = new TblBoothLocationTableAdapter();
            return ta.GetActiveData(true);
        }
    }
}
