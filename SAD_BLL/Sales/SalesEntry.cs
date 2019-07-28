using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales;
using SAD_DAL.Sales.SalesEntryTDSTableAdapters;
using System.Data;

namespace SAD_BLL.Sales
{
    public class SalesEntry
    {
        public void AddUpdateSalesDO(string xmlStr, string userId, string unitId
        , DateTime date, string challanNo
        , string customerId, string customerType, string narration, string address, string distributionPointId
        , string priceVar, string logisticPriceVar, decimal logisticCharge, bool isLogistic, bool isLogisticByCompany
        , string vehicleId, string vehicleRegNo, string vehicleTypeId, string chargeId, decimal charge
        , string incentiveId, decimal incentive, string supplierCOACode, string supplierName, bool chargeToSupplier
        , string currencyId,decimal conversionRate, string salesTypeId
        , decimal extAmount, string extCause
        , string other,string driver,string driverContact,string salesOffice, string shippingPoint, ref string code, ref string entryId
        )
        {
           
          
                
                long? id = null;
                int? priceVar_ = null, vehicleId_ = null, logisticPriceVar_ = null;
                int? distributionPointId_ = null, vehicleTypeId_ = null, chargeId_ = null, incentiveId_ = null;

                try { id = long.Parse(entryId); }
                catch { }
                try { priceVar_ = int.Parse(priceVar); }
                catch { }
                try { vehicleId_ = int.Parse(vehicleId); }
                catch { }
                try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
                catch { }
                try { distributionPointId_ = int.Parse(distributionPointId); }
                catch { }
                try { vehicleTypeId_ = int.Parse(vehicleTypeId); }
                catch { }
                try { chargeId_ = int.Parse(chargeId); }
                catch { }
                try { incentiveId_ = int.Parse(incentiveId); }
                catch { }

                SprSalesEntryTableAdapter ta = new SprSalesEntryTableAdapter();

                ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, challanNo
                    , int.Parse(customerType), int.Parse(customerId)
                    , distributionPointId_, narration, address, false, false
                    , priceVar_, logisticPriceVar_, logisticCharge, isLogistic, isLogisticByCompany, vehicleRegNo
                    , vehicleId_, vehicleTypeId_, chargeId_, charge, incentiveId_, incentive, supplierCOACode, supplierName, chargeToSupplier
                    , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause, other, driver, driverContact, int.Parse(salesOffice), int.Parse(shippingPoint), ref code);

                entryId = id.ToString();
              
        }

        public void AddUpdateSalesDO2(string xmlStr, string userId, string unitId
        , DateTime date, string challanNo
        , string customerId, string customerType, string narration, string address, string distributionPointId
        , string priceVar, string logisticPriceVar, decimal logisticCharge, bool isLogistic, bool isLogisticByCompany
        , string vehicleId, string vehicleRegNo, string vehicleTypeId, string chargeId, decimal charge
        , string incentiveId, decimal incentive, string supplierCOACode, string supplierName, bool chargeToSupplier
        , string currencyId, decimal conversionRate, string salesTypeId
        , decimal extAmount, string extCause
        , string other, string driver, string driverContact, string salesOffice, string shippingPoint, ref string code, ref string entryId
        )
    {
        long? id = null;
        int? priceVar_ = null, vehicleId_ = null, logisticPriceVar_ = null;
        int? distributionPointId_ = null, vehicleTypeId_ = null, chargeId_ = null, incentiveId_ = null;

        try { id = long.Parse(entryId); }
        catch { }
        try { priceVar_ = int.Parse(priceVar); }
        catch { }
        try { vehicleId_ = int.Parse(vehicleId); }
        catch { }
        try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
        catch { }
        try { distributionPointId_ = int.Parse(distributionPointId); }
        catch { }
        try { vehicleTypeId_ = int.Parse(vehicleTypeId); }
        catch { }
        try { chargeId_ = int.Parse(chargeId); }
        catch { }
        try { incentiveId_ = int.Parse(incentiveId); }
        catch { }

        SprSalesEntryTableAdapter ta = new SprSalesEntryTableAdapter();

        ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, challanNo
            , int.Parse(customerType), int.Parse(customerId)
            , distributionPointId_, narration, address, true, false
            , priceVar_, logisticPriceVar_, logisticCharge, isLogistic, isLogisticByCompany, vehicleRegNo
            , vehicleId_, vehicleTypeId_, chargeId_, charge, incentiveId_, incentive, supplierCOACode, supplierName, chargeToSupplier
            , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause, other, driver, driverContact, int.Parse(salesOffice), int.Parse(shippingPoint), ref code);

        entryId = id.ToString();
    }
        
        public SalesEntryTDS.QrySalesEntryDetailsDataTable GetSalesEntryDetails(string id)
        {
            QrySalesEntryDetailsTableAdapter ta = new QrySalesEntryDetailsTableAdapter();
            return ta.GetDataById(long.Parse(id));
        }
        public SalesEntryTDS.QrySalesEntryCustomerDataTable GetSalesEntry(string id)
        {
            QrySalesEntryCustomerTableAdapter ta = new QrySalesEntryCustomerTableAdapter();
            return ta.GetDataById(long.Parse(id));
        }
        public void SubLedgerEntryFromIdList(string voucherIdList, string unitId, string userId, DateTime date)
        {
            SprSubledgerEntryFromSalesFromIdListTableAdapter ta = new SprSubledgerEntryFromSalesFromIdListTableAdapter();
            ta.GetData(voucherIdList, int.Parse(unitId), int.Parse(userId), date);
        }


        #region ------------- For Sales Return -------------
        public DataTable GetSalesEntryInfo(string code, int unit)
        {
            try
            {
                QrySalesEntryDetailsInfoTableAdapter ta = new QrySalesEntryDetailsInfoTableAdapter();
                return ta.GetSalesInfoDetailsData(unit, code);
            }
            catch { return new DataTable(); }
        }
        public string SubmitReturn(string xmlString, int actionby)
        {
            string message = "";
            try
            {
                    
            }
            catch (Exception ex) { message = ex.ToString(); }
            return message;
        }
        
        #endregion-----------------------------------------





        
    }
}
