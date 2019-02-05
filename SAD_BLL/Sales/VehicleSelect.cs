using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales.VehicleSelectTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class VehicleSelect
    {

        public void VehicleAssign(string xmlStr, string userId, string unitId
            , DateTime date, string salesOrderId
           , string shippingPoint, string vehicleId
            , bool isLogistic, bool isLogisByCompany, bool isChargeToSupplier
            , decimal charge, decimal gain, string logisUOM, string chargeId
            , string incentiveId, string narration
            , ref string code, ref string entryId)
        {
            long? id = null;

            try { id = long.Parse(entryId); }
            catch { }

            SprVehicleAssignTableAdapter ta = new SprVehicleAssignTableAdapter();
            //SprVehicleAssignForRNDTableAdapter ta= new SprVehicleAssignForRNDTableAdapter();

            ta.GetData(xmlStr, ref id, long.Parse(salesOrderId), int.Parse(userId)
                , int.Parse(unitId), date, int.Parse(shippingPoint)
                , int.Parse(vehicleId), isLogistic, isLogisByCompany
                , isChargeToSupplier, charge, gain, int.Parse(logisUOM), int.Parse(chargeId)
                , int.Parse(incentiveId), narration
                , ref code);
        }


        //public void VehicleAssignTest(string xmlStr, string userId, string unitId
        //   , DateTime date, string salesOrderId
        //  , string shippingPoint, string vehicleId
        //   , bool isLogistic, bool isLogisByCompany, bool isChargeToSupplier
        //   , decimal charge, decimal gain, string logisUOM, string chargeId
        //   , string incentiveId, string narration
        //   , ref string code, ref string entryId)
        //{
        //    long? id = null;

        //    try { id = long.Parse(entryId); }
        //    catch { }

        //    SprVehicleAssignTestTableAdapter ta = new SprVehicleAssignTestTableAdapter();
        //    ta.GetDataVehicleAssignTest(xmlStr, ref id, long.Parse(salesOrderId), int.Parse(userId)
        //        , int.Parse(unitId), date, int.Parse(shippingPoint)
        //        , int.Parse(vehicleId), isLogistic, isLogisByCompany
        //        , isChargeToSupplier, charge, gain, int.Parse(logisUOM), int.Parse(chargeId)
        //        , int.Parse(incentiveId), narration
        //        , ref code);
        //}
    }
}
