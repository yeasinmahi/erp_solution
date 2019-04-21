using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Global.ShipPointTDSTableAdapters;
using SAD_DAL.Global;
using System.Data;
using SAD_DAL.Global.ShipingPointOOPTableAdapters;

namespace SAD_BLL.Global
{
    public class ShipPointOOP
    {
        DataTable dtTemp = new DataTable();
        DataTable dtTemp2 = new DataTable();
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
            DataTable dt = new DataTable();
            dt = GetShipPoint(userID, Unitid);
            if (dt.Rows.Count > 0)
            {
              int  counts =int.Parse(dt.Rows[0]["intLevel"].ToString());
               
                if (counts <= 0)
                {
                    dt = getShip(Unitid);
                    dtTemp = (from DataRow dr in dt.Rows  select dr).CopyToDataTable();                  
                    dtTemp.Merge(dtTemp);

                    return dtTemp;
                }
                else
                {
                    dt = getShip(Unitid);
                    dtTemp = (from DataRow dr in dt.Rows select dr).CopyToDataTable();
                    dtTemp.Merge(dtTemp);

                    return dtTemp;
                }
            }
                    return new DataTable();
        }

        private DataTable getShip(int Unitid)
        {
            tblShippingPointTableAdapter adp = new tblShippingPointTableAdapter();
            return adp.GetData(Unitid);
        }

        private DataTable GetShipPoint(int userID,int Unitid)
        {
            qryShipPointByOperatorTableAdapter adp = new qryShipPointByOperatorTableAdapter();
            return adp.GetShipPoint(userID, Unitid);
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
