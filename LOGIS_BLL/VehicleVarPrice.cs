using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL.VehicleVarPriceTDSTableAdapters;
using LOGIS_BLL.GLOBAL;

namespace LOGIS_BLL
{
    public class VehicleVarPrice
    {
        public decimal GetPrice(string shipPointId, string productId, string vehicleID, string vehicleTypeID,string customerId, string vehicleVariable, string currency, string uom, DateTime date,bool enableLogis, bool logisBy3rdParty,ref decimal logisGain)
        {
            if (customerId == null || customerId == "" || productId == null || productId == "") return 0;
            int? cur = null, pv = null, vhlId = null, vhlTypeId = null, uomId = null;
            
            try { cur = int.Parse(currency); }
            catch { }
            
            try { pv = int.Parse(vehicleVariable); }
            catch { }

            try { vhlId = int.Parse(vehicleID); }
            catch { }

            try { vhlTypeId = int.Parse(vehicleTypeID); }
            catch { }

            try { uomId = int.Parse(uom); }
            catch { }

            decimal? price = 0;
            decimal? logGain = 0;
            SprVehicleVarGetPriceTableAdapter ta = new SprVehicleVarGetPriceTableAdapter();
            ta.GetData(int.Parse(shipPointId), int.Parse(productId), vhlId, pv, vhlTypeId, int.Parse(customerId), enableLogis, logisBy3rdParty, date.Date, uomId, cur, ref price, ref logGain);

            logisGain = logGain.Value;
            price = price == null ? 0 : price;
            
            return price.Value;
        }

        public decimal GetPriceBySO(string salesOrderId,string shipPointId,string unitId, string customerId, string vehicleID, string vehicleVariable
            , string currency, DateTime date, bool enableLogis, bool logisBy3rdParty
            , bool isLogisByCompany, bool isLogisBy3rdParty, bool isLogisByCustomer
            , ref decimal logisGain,ref int logisChargeUom,ref bool isVehicleOk
            ,ref decimal capacity, ref decimal loaded, ref DateTime? weightBridgeInTime,ref string tripId)
        {
            if (customerId == null || customerId == "" || salesOrderId == null || salesOrderId == "") return 0;
            int? cur = null, pv = null, vhlId = null;

            try { cur = int.Parse(currency); }
            catch { }

            try { pv = int.Parse(vehicleVariable); }
            catch { }

            try { vhlId = int.Parse(vehicleID); }
            catch { }

            
            decimal? price = 0, logGain = 0;
            decimal? capacity_ = 0, loaded_ = 0;
            int? logisChargeUom_ = 0, tripId_ = 0;

            
            SprVehicleVarGetPriceBySOTableAdapter ta = new SprVehicleVarGetPriceBySOTableAdapter();
            ta.GetData(int.Parse(salesOrderId), int.Parse(shipPointId), int.Parse(customerId), vhlId, pv, date.Date, int.Parse(unitId), cur
                , enableLogis, logisBy3rdParty, isLogisByCompany, isLogisBy3rdParty, isLogisByCustomer
                , ref price, ref logGain, ref logisChargeUom_, ref isVehicleOk
                , ref weightBridgeInTime, ref capacity_, ref loaded_,ref tripId_);

            logisGain = logGain.Value;
            price = price == null ? 0 : price;
            logisChargeUom = logisChargeUom_.Value;
            capacity = capacity_ == null ? 0 : capacity_.Value;
            loaded = loaded_ == null ? 0 : loaded_.Value;
            tripId = tripId_ == null ? "0" : tripId_.Value.ToString();

            return price.Value;
        }

        public void SetPrice(string userId,string shipPoint, string unitId, string vehicleRegNoList, string vehicleVarID, string vehicleTypeList, DateTime startDate, DateTime? endDate, decimal price,decimal partyPrice, string uom, string currency,string product, ref int? error)
        {
            CodeGenatator cg = new CodeGenatator();
            string code = cg.GetPriceBatchCode(unitId);

            int? vhlVarID = null, uomID = null, pr = null;
            try
            {
                vhlVarID = int.Parse(vehicleVarID);
            }
            catch { }

            try
            {
                uomID = int.Parse(uom);
            }
            catch { }
            
            try { pr = int.Parse(product); }
            catch { }


            SprVehicleVarSetPriceTableAdapter ta = new SprVehicleVarSetPriceTableAdapter();
            ta.GetData(int.Parse(userId),int.Parse(shipPoint), vehicleRegNoList, vhlVarID, vehicleTypeList, true, startDate.Date, endDate, price, partyPrice, int.Parse(unitId), code, uomID, int.Parse(currency), pr, ref error);
        }

    }
}
