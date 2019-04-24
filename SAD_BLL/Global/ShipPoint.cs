using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Global.ShipPointTDSTableAdapters;
using SAD_DAL.Global;
using System.Data;

namespace SAD_BLL.Global
{
    public class ShipPoint
    {
        public ShipPointTDS.TblShippingPointBySODataTable GetSODataById(string shipPointId)
        {
            TblShippingPointBySOTableAdapter ta = new TblShippingPointBySOTableAdapter();
            return ta.GetData(int.Parse(shipPointId));
        }

        public ShipPointTDS.SprShipPointByUserDataTable GetShipPoint(string userId, string unitId)
        {
            if (userId == "" || unitId == "" || unitId == null) return new ShipPointTDS.SprShipPointByUserDataTable();
            SprShipPointByUserTableAdapter ta = new SprShipPointByUserTableAdapter();
            return ta.GetData(int.Parse(userId), int.Parse(unitId),true);
             

        }
        public DataTable GetShipingPoint(int userID,int Unitid)
        {



            return new DataTable();
        }


            public string GetPrefix(string shipPoint)
        {
            if (shipPoint == "") return "";
            TblShippingPointBySOTableAdapter ta = new TblShippingPointBySOTableAdapter();
            return ta.GetPrefixByShipPointId(int.Parse(shipPoint));
        }

        public ShipPointTDS.TblShippingPointOtherDataTable GetShipPointExceptThis(string unitId, string shipPointId)
        {
            if (shipPointId == "" || unitId == "" || unitId == null) return new ShipPointTDS.TblShippingPointOtherDataTable();
            TblShippingPointOtherTableAdapter ta = new TblShippingPointOtherTableAdapter();
            return ta.GetData(int.Parse(unitId), int.Parse(shipPointId));
        }

        public ShipPointTDS.TblShippingPointDataTable GetShipPointInfo(string shipPointId)
        {
            if (shipPointId == "") return new ShipPointTDS.TblShippingPointDataTable();
            TblShippingPointTableAdapter ta = new TblShippingPointTableAdapter();
            return ta.GetDataById(int.Parse(shipPointId));
        }
    }
}
