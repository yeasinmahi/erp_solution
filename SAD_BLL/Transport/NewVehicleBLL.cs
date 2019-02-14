using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public DataTable getVehicletype(string unitid)
        {
            try
            {
                TblVehicleTypeTableAdapter adp = new TblVehicleTypeTableAdapter();
                return adp.GetVehicleLogistictype(int.Parse(unitid));
            }
            catch { return new DataTable(); }
        }

        public DataTable getLocation(string unitid)
        {
            
            try
            {
                tblShipPointTableAdapter adp = new tblShipPointTableAdapter();
                return adp.GetData(int.Parse(unitid));
            }
            catch { return new DataTable(); }
        }

        public void getVehcilEntry(string vno, int unitid, int typeid, int intCOAID, int locationid, string driverName, string driverContact, string driverNid, string helperName1, decimal loadingCapacity, int uOMid, string lisenceNo, int driverenroll, decimal driverDA, int helperenroll, decimal helperDA, decimal diselperkm, decimal diselPerKMLitter, decimal downTripDiselPerKM, decimal cNGPerKM, decimal downTripDA, decimal cNGAllowance, decimal millageAllowance100KM, decimal millageAllowance100KMAbove, decimal millageLocal, decimal millageOutstation, decimal diselPerKmOutstation, decimal cNGPerKMOutstation)
        {
            try
            {
                tblVehicleTableAdapter adp = new tblVehicleTableAdapter();
                 adp.GetData( vno, unitid, typeid, intCOAID, locationid, driverName,  driverContact,  driverNid,  helperName1,  loadingCapacity,  uOMid,  lisenceNo,  driverenroll,  driverDA, helperenroll,  helperDA,  diselperkm,  diselPerKMLitter,  downTripDiselPerKM,  cNGPerKM,  downTripDA,  cNGAllowance,  millageAllowance100KM,  millageAllowance100KMAbove,  millageLocal,  millageOutstation,  diselPerKmOutstation,  cNGPerKMOutstation);
            }
            catch {  }
        }

        public DataTable getAutoid()
        {
            try
            {
                tblVehicle1TableAdapter adp = new tblVehicle1TableAdapter();
                return adp.GetData();
            }
            catch { return new DataTable(); }
        }

        public void getVehcilCOA(string vno, int v1, bool v2, bool v3, bool v4, bool v5, bool v6, int enroll, int v7, int vid1, int unitid, int v8, int vid2, object p, int v9, ref int? intCOAID)
        {
            try
            {
                int? intcoaid_ = 0;
                sprAccountsCOAChildAddTableAdapter adp = new sprAccountsCOAChildAddTableAdapter();
                 adp.GetData(vno, 33881, true, false, false, false, false, enroll, 0, vid1, unitid, vid2, null, 0, ref intCOAID);
                intCOAID = intcoaid_.Value;
            }
            catch { }
        }

        public void getupdate(int coaid,int vid)
        {
            try
            {
                tblVehicleCOAupdateTableAdapter adp = new tblVehicleCOAupdateTableAdapter();
                adp.GetData(coaid, vid);
            }
            catch { }
        }
    }
}
