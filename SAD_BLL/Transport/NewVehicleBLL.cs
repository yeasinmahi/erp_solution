using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Transport;
using SAD_DAL.Transport.NewVehicleRegTDSTableAdapters;

namespace SAD_BLL.Transport
{
    public class NewVehicleBLL
    {

        private static NewVehicleRegTDS.TblVehicleTypeDataTable[] tableProducts = null;
        private static Hashtable ht = new Hashtable();

        public void getVehicle(NewVehicleRegTDS.TblVehicleTypeRow tw,string text)
        {
            
            tw.intUnitId = 2;


        }
    }
}
