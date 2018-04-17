using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.Trip;
using LOGIS_DAL.Trip.TripTDSTableAdapters;
using System.Data;

namespace LOGIS_BLL.Trip
{
    public class Trip
    {
        public TripTDS.SprGetTripInfoDataTable GetChallanInfo(string fromDate, string toDate, string code, string DOcode, string unitID, string userID, string vehicleId, string isCompleted, string isTripAssignCompleted, string shippingPoint)
        {
            int? vid = null;
            try { vid = int.Parse(vehicleId); }
            catch { }

            SprGetTripInfoTableAdapter adp = new SprGetTripInfoTableAdapter();                       

            DateTime? fromDate_ = null, toDate_ = null;

            try
            {
                fromDate_ = DateTime.Parse(fromDate);
            }
            catch { }
            try
            {
                toDate_ = DateTime.Parse(toDate);
            }
            catch { }

            bool? isCompleted_=null, isTripAssignCompleted_=null;
            try { isCompleted_ = bool.Parse(isCompleted); }
            catch { }
            try { isTripAssignCompleted_ = bool.Parse(isTripAssignCompleted); }
            catch { }


            if (!isCompleted_.Value)
            {
                if (fromDate_ == null) { fromDate_ = DateTime.Now.Date.AddDays(-360); }
                if (toDate_ == null) { toDate_ = DateTime.Now.Date.AddDays(7); }
            }
            else
            {
                if (fromDate_ == null) { fromDate_ = DateTime.Now.Date.AddDays(-7); }
                if (toDate_ == null) { toDate_ = DateTime.Now.Date.AddDays(6); }
            }

            return adp.GetData(int.Parse(userID), int.Parse(unitID), vid, fromDate_, toDate_, isCompleted_, isTripAssignCompleted_, code, DOcode, int.Parse(shippingPoint));

        }

        public void CompleteTripAssign(string tripId, string userId)
        {
            SprGetTripInfoTableAdapter adp = new SprGetTripInfoTableAdapter();
            adp.CompleteTripAssign(int.Parse(userId), int.Parse(tripId));
        }

        public void RollbackTripAssign(string tripId, string userId)
        {
            SprGetTripInfoTableAdapter adp = new SprGetTripInfoTableAdapter();
            adp.RollbackTripAssign(int.Parse(userId), int.Parse(tripId));
        }

        public string GetTripCodeById(string tripId)
        {
            QryTripTableAdapter ta = new QryTripTableAdapter();
            return ta.GetCodeById(int.Parse(tripId));
        }

        public string GetTripCodeByVehicle(string vehicleId)
        {
            QryTripTableAdapter ta = new QryTripTableAdapter();
            return ta.GetCodeByVehicle(int.Parse(vehicleId));
        }

        public void CompleteTrip(string userId, string unitId,string code,string shipPoint, string brandissunumb, ref string error)
        {
            SprTripCompleteTableAdapter ta = new SprTripCompleteTableAdapter();
            ta.GetData(int.Parse(userId), int.Parse(unitId), code, int.Parse(shipPoint), int.Parse(brandissunumb), ref error);
        }

        public void CreateNewTripForOwn(string userId, string unitId, string vehicleId, string vehicleRegNo
            , string driver, string contact, string shipPoint,string kmReading
            , string driverNid, string healperName, string loadingCapacity, string uom
            , string driverLisenceNo, string doNo
            , ref string code, ref string error)
        {
            decimal? km = null;
            try { km = decimal.Parse(kmReading); }
            catch { }
            int uom_ = 0;
            decimal lc = 0;
            try { lc = decimal.Parse(loadingCapacity); }
            catch { }
            try { uom_ = int.Parse(uom); }
            catch { }

            CreateNewTrip(int.Parse(userId), int.Parse(unitId), int.Parse(vehicleId), vehicleRegNo
                , null, driver, contact, int.Parse(shipPoint), true, null, "", null, "", km
                ,driverNid, healperName, lc, uom_
                , driverLisenceNo, doNo
                , ref code, ref error);
        }
        public void CreateNewTripForParty(string userId, string unitId, string vehicleId, string vehicleRegNo
            , string vehicleType, string driver, string contact, string shipPoint, string supplierId, string supplierName
            , string driverNid, string healperName, string loadingCapacity, string uom
            , string driverLisenceNo, string doNo
            , ref string code, ref string error)
        {
            int? vid = null;
            try { vid = int.Parse(vehicleId); }
            catch { }
            int uom_ = 0;
            decimal lc = 0;
            try { lc = decimal.Parse(loadingCapacity); }
            catch { }
            try { uom_ = int.Parse(uom); }
            catch { }

            CreateNewTrip(int.Parse(userId), int.Parse(unitId), vid, vehicleRegNo
                , int.Parse(vehicleType), driver, contact, int.Parse(shipPoint), false, int.Parse(supplierId), supplierName
                , null, "", null, driverNid, healperName, lc, uom_
                , driverLisenceNo, doNo, ref code, ref error);
        }
        public void CreateNewTripForCustomer(string userId, string unitId, string vehicleId, string vehicleRegNo
            , string vehicleType, string driver, string contact, string shipPoint, string customerId, string customerName
            ,string driverNid,string healperName,string loadingCapacity,string uom,string driverLisenceNo,string doNo
            , ref string code, ref string error)
        {
            int? vid = null;
            try { vid = int.Parse(vehicleId); }
            catch { }
            int cus = 0,uom_=0;
            try { cus = int.Parse(customerId); }
            catch { }
            decimal lc = 0;
            try { lc = decimal.Parse(loadingCapacity); }
            catch { }
            try { uom_ = int.Parse(uom); }
            catch { }

            CreateNewTrip(int.Parse(userId), int.Parse(unitId), vid, vehicleRegNo
                , int.Parse(vehicleType), driver, contact, int.Parse(shipPoint), false
                , null, "", cus, customerName, null, driverNid, healperName, lc, uom_
                , driverLisenceNo, doNo, ref code, ref error);
        }

        private void CreateNewTrip(int userId, int unitId, int? vehicleId, string vehicleRegNo
            , int? vehicleType, string driver, string contact, int shipPoint, bool isOwn
            , int? suppId, string suppName, int? cusId, string cusName
            ,decimal? kmReading,string driverNid,string healperName,decimal? loadingCapacity
            ,int? uom,string driverLisenceNo,string doNo
            , ref string code, ref string error)
        {

            long? doNo_ = null;
            try
            {
                doNo_ = long.Parse(doNo);
            }
            catch { }

            SprTripCreateTableAdapter ta = new SprTripCreateTableAdapter();
            ta.GetData(DateTime.Now, userId, unitId, vehicleId, vehicleRegNo, vehicleType
                , driver, contact, shipPoint, isOwn, suppId, suppName, cusId, cusName
                , kmReading, driverNid, healperName, loadingCapacity, uom
                , driverLisenceNo, doNo_, ref code, ref error);
        }

        public void UpdateTripDO(string vehicleId, string doId,string doCode,string userId)
        {
            SprTripCreateTableAdapter ta = new SprTripCreateTableAdapter();
            ta.UpdateDONo(long.Parse(doId), doCode, int.Parse(userId), int.Parse(vehicleId));
        }

        public void GetGatePass(string id, string userId, string separator, ref DateTime date, ref string unitName
           , ref string unitAddress, ref string userName, ref string vehicle, ref string driver, ref string driverPh)
        {
            SprTripInfoForChallanGatePassTableAdapter ta = new SprTripInfoForChallanGatePassTableAdapter();
            DateTime? dt = null;

            ta.GetData(long.Parse(id), int.Parse(userId), separator, ref dt, ref unitName
                , ref unitAddress, ref userName, ref vehicle, ref driver, ref driverPh);
        }

        public void GetWeightInfoForWeightBridge(string unitId,ref string tripId,string tripCode,ref string driver,ref string healper
            , ref decimal? emptyWeight, ref decimal? loadedWeight, ref decimal? goodsWeight, ref decimal? diffarence,ref decimal? tawlarence
            ,ref string uom,ref bool isLoaded,ref bool isInMaintain)
        {
            SprTripWeightVolumeInfoTableAdapter ta = new SprTripWeightVolumeInfoTableAdapter();
            
            long? id = null;
            try { id = long.Parse(tripId); }
            catch { }
            bool? isInMaintain_ = true;

            ta.GetData(int.Parse(unitId), ref id, tripCode, ref driver, ref healper
                , ref emptyWeight, ref loadedWeight, ref goodsWeight, ref tawlarence
                , ref uom,ref isInMaintain_);

            isInMaintain = isInMaintain_.Value;

            tripId = id == null ? "" : id.Value.ToString();

            if (tripId != "")
            {
                if (emptyWeight > 0)
                {
                    if (loadedWeight > 0) diffarence = loadedWeight.Value - emptyWeight.Value - goodsWeight.Value;
                    else diffarence = 0;
                    isLoaded = true;
                }
                else
                {
                    isLoaded = false;
                    diffarence = 0;
                }

            }
        }

        public bool WeightCalculationForWeightBridge(decimal emptyWeight, decimal loadedWeight
            , decimal goodsWeight, decimal tawlarence,ref decimal diffarence)
        {
            if (loadedWeight <= 0 || loadedWeight < emptyWeight)
            {
                return false;
            }
            else
            {
                diffarence = loadedWeight - emptyWeight - goodsWeight;

                if (((goodsWeight / 100) * tawlarence) >= Math.Abs(diffarence))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void SetEmptyWeight(string tripId,string userId, decimal weight,string uom)
        {
            SprTripWeightVolumeInfoTableAdapter ta = new SprTripWeightVolumeInfoTableAdapter();
            ta.SetEmptyWeight(weight, int.Parse(uom), int.Parse(userId), int.Parse(tripId));
        }

        public void SetLoadedWeight(string tripId, string userId, decimal weight)
        {
            SprTripWeightVolumeInfoTableAdapter ta = new SprTripWeightVolumeInfoTableAdapter();
            ta.SetLoadedWeight(weight, int.Parse(userId), int.Parse(tripId));
        }

        public string GetDOCodeByVehicle(string vehicleId)
        {
            SprTripCreateTableAdapter ta = new SprTripCreateTableAdapter();
            return ta.GetDOCodeByVehicle(int.Parse(vehicleId));
        }
        public DataTable GetTripvsCost(DateTime fromdate, DateTime todate,string shippingpoinname,int categoryid)
        {
            try
            {
                SprTripvsTADATableAdapter bll = new SprTripvsTADATableAdapter();
                return bll.GetDatasprTripvsTADA(fromdate, todate, shippingpoinname, categoryid);

            }
            catch { return new DataTable(); }
        }
        public DataTable GetShippingPointNamet(int unitid)
        {
            try
            {
                DataTableShippingPointTableAdapter bll = new DataTableShippingPointTableAdapter();
                return bll.GetDataShippingPointName(unitid);
            }
            catch { return new DataTable(); }
        }
        //dteFromdate datetime, dteTodate datetime,strshippingpoint varchar(500),intunitid int,intreporttype int,strdriver varchar(500),strhelper varchar(500)
        public DataTable GetTripvsChallanDet(DateTime fromdate, DateTime todate, string shippingpoinname, int unitid,int rpttypeid,string drivername,string helpername)
        {
            try
            {
                SprTripvsTADAChallanDetaillsTableAdapter bll = new SprTripvsTADAChallanDetaillsTableAdapter();
                return bll.GetDatasprTripvsTADAChallanDetaills( fromdate,  todate,  shippingpoinname,  unitid,  rpttypeid,  drivername,  helpername);
            }
            catch { return new DataTable(); }
        }


        public void CompleteTripTest(string userId, string unitId, string code, string shipPoint, string brandissunumb, ref string error)
        {
            SprTripCompleteTestTableAdapter ta = new SprTripCompleteTestTableAdapter();
            ta.GetData(int.Parse(userId), int.Parse(unitId), code, int.Parse(shipPoint), int.Parse(brandissunumb), ref error);
        }

        public DataTable GetTripvsChallan(string tripcode, string  unitid )
        {
            try
            {
                SprChallanInsertionCheckingTableAdapter bll = new SprChallanInsertionCheckingTableAdapter();
                return bll.GetDataChallanInsertionChecking(tripcode,   int.Parse(unitid));
            }
            catch { return new DataTable(); }
        }

    }
}
