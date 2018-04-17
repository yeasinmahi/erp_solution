using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.Trip.TripCallTDSTableAdapters;
using LOGIS_DAL.Trip;

namespace LOGIS_BLL.Trip
{
    public class TripCall
    {
        public TripCallTDS.QryTripDataTable GetDataForWeightBridge(string shipPointId, string unitId)
        {
            QryTripTableAdapter ta = new QryTripTableAdapter();
            return ta.GetData(int.Parse(shipPointId), int.Parse(unitId));
        }

        public TripCallTDS.QryDoWiseTripDataTable GetDataForVehicleAssign(string shipPointId, string unitId)
        {
            QryDoWiseTripTableAdapter ta = new QryDoWiseTripTableAdapter();
            return ta.GetData(int.Parse(shipPointId), int.Parse(unitId));
        }

        public TripCallTDS.QryTripByDoDataTable GetVehicleByDoCode(string doCode, string unitId, string shipPoint)
        {
            QryTripByDoTableAdapter ta = new QryTripByDoTableAdapter();
            return ta.GetData(doCode, int.Parse(unitId), int.Parse(shipPoint));
        }

        public TripCallTDS.SprVehicleForTripAssignDataTable GetTripAssignVehicleList(string xml, string unitId, string shipPointId,string salesOrderId, string type)
        {
            bool isComp = false, isParty = false, isCust = false;
            if (type == "c") isComp = true;
            else if (type == "p") isParty = true;
            else isCust = true;

            SprVehicleForTripAssignTableAdapter ta = new SprVehicleForTripAssignTableAdapter();
            return ta.GetData(xml, int.Parse(unitId), int.Parse(shipPointId), int.Parse(salesOrderId), isComp, isParty, isCust);
        }
    }
}
