using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.VehicleTDSTableAdapters;
using LOGIS_DAL;

namespace LOGIS_BLL
{
    public class Vehicle
    {
        public VehicleTDS.TblVehicleDataTable GetVehicleList(string unitID)
        {
            TblVehicleTableAdapter ta = new TblVehicleTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitID), true);
        }

        public VehicleTDS.TblVehicleDataTable GetVehicleById(string id)
        {
            TblVehicleTableAdapter ta = new TblVehicleTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }

        public void GetVehicleInfoById(string id,ref string driverName,ref string driverContact)
        {
           TblVehicleTableAdapter ta = new TblVehicleTableAdapter();
           VehicleTDS.TblVehicleDataTable tbl= ta.GetDataById(int.Parse(id));

           driverName = tbl[0].strDriverName;
           driverContact = tbl[0].strDriverContact;

        }

        public void  ModifyVhlRegNo(string id,string regNo, string userId)
        {
            TblVehicleRegisLogTableAdapter ta = new TblVehicleRegisLogTableAdapter();
            ta.InsertLog(int.Parse(id), regNo, int.Parse(userId));

            TblVehicleTableAdapter tad = new TblVehicleTableAdapter();
            tad.UpdateRegNo(regNo, int.Parse(id));
        }

        public VehicleTDS.TblVehicleTypeDataTable GetVhlType(string unitId)
        {
            TblVehicleTypeTableAdapter ta = new TblVehicleTypeTableAdapter();
            return ta.GetData(int.Parse(unitId), true);
        }

        public void MaintainanceIn(string id, string user)
        {
            TblVehicleTableAdapter ta = new TblVehicleTableAdapter();
            ta.MaintananceIn(true, int.Parse(user), int.Parse(id));
        }
        public void MaintainanceOut(string id, string user)
        {
            TblVehicleTableAdapter ta = new TblVehicleTableAdapter();
            ta.MaintananceOut(false, int.Parse(user), int.Parse(id));
        }
    }
}
