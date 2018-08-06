using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales.SalesOrderTDSTableAdapters;
using SAD_DAL.Sales;
using System.Data;

namespace SAD_BLL.Sales
{
    public class SalesOrder
    {
                
        public void AddUpdateSalesOrder(string xmlStr, string userId, string unitId
            , DateTime date,DateTime reqDOdate
            , string customerId, string customerType, string narration, string address, string distributionPointId
            , string priceVar, string logisticPriceVar, bool isLogistic
            , string chargeId, decimal charge
            , string incentiveId, decimal incentive
            , string currencyId,decimal conversionRate, string salesTypeId
            , decimal extAmount, string extCause
            , string note, string contatcAt, string ContactPhone
            , string salesOffice, string shippingPoint, ref string code, ref string entryId
            )
        {
            long? id = null;
            int? priceVar_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, chargeId_ = null, incentiveId_ = null;

            try { id = long.Parse(entryId); }
            catch { }
            try { priceVar_ = int.Parse(priceVar); }
            catch { }
            
            try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
            catch { }
            try { distributionPointId_ = int.Parse(distributionPointId); }
            catch { }
            
            try { chargeId_ = int.Parse(chargeId); }
            catch { }
            try { incentiveId_ = int.Parse(incentiveId); }
            catch { }

            SprSalesOrderTableAdapter ta = new SprSalesOrderTableAdapter();

            ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, reqDOdate
                , int.Parse(customerType), int.Parse(customerId)
                , distributionPointId_, narration, address
                , priceVar_, logisticPriceVar_, isLogistic
                , chargeId_, charge, incentiveId_, incentive
                , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause
                , note, contatcAt, ContactPhone, int.Parse(salesOffice)
                , int.Parse(shippingPoint), false, false, ref code);

            entryId = id.ToString();
        }

        public void AddUpdateDelivaryOrder(string xmlStr, string userId, string unitId
            , DateTime date, DateTime reqDOdate
            , string customerId, string customerType, string narration, string address, string distributionPointId
            , string priceVar, string logisticPriceVar, bool isLogistic
            , string chargeId, decimal charge
            , string incentiveId, decimal incentive
            , string currencyId, decimal conversionRate, string salesTypeId
            , decimal extAmount, string extCause
            , string note, string contatcAt, string ContactPhone
            , string salesOffice, string shippingPoint, bool sdv, ref string code, ref string entryId
            )
        {
            long? id = null;
            int? priceVar_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, chargeId_ = null, incentiveId_ = null;

            try { id = long.Parse(entryId); }
            catch { }
            try { priceVar_ = int.Parse(priceVar); }
            catch { }

            try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
            catch { }
            try { distributionPointId_ = int.Parse(distributionPointId); }
            catch { }

            try { chargeId_ = int.Parse(chargeId); }
            catch { }
            try { incentiveId_ = int.Parse(incentiveId); }
            catch { }

            SprSalesOrderTableAdapter ta = new SprSalesOrderTableAdapter();

            ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, reqDOdate
                , int.Parse(customerType), int.Parse(customerId)
                , distributionPointId_, narration, address
                , priceVar_, logisticPriceVar_, isLogistic
                , chargeId_, charge, incentiveId_, incentive
                , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause
                , note, contatcAt, ContactPhone, int.Parse(salesOffice)
                , int.Parse(shippingPoint), true, sdv, ref code);

            entryId = id.ToString();
        }

        public SalesOrderTDS.QrySalesOrderDetailsDataTable GetSalesOrderDetails(string SOid)
        {
            QrySalesOrderDetailsTableAdapter ta = new QrySalesOrderDetailsTableAdapter();
            return ta.GetDataBySOid(long.Parse(SOid));
        }

        public SalesOrderTDS.QrySalesOrderDetailsDataTable GetSalesOrderDetailsById(string id)
        {
            QrySalesOrderDetailsTableAdapter ta = new QrySalesOrderDetailsTableAdapter();
            return ta.GetDataById(long.Parse(id));
        }

        public SalesOrderTDS.QrySalesOrderCustomerDataTable GetSalesOrder(string id)
        {
            QrySalesOrderCustomerTableAdapter ta = new QrySalesOrderCustomerTableAdapter();
            return ta.GetDataById(long.Parse(id));
        }

        public long? ExistsDO(string doCode, string shipPointId, string unitId,ref string customer,ref string customerId)
        {            
            if (doCode != "")
            {                
                QrySalesOrderCustomerTableAdapter ta = new QrySalesOrderCustomerTableAdapter();
                SalesOrderTDS.QrySalesOrderCustomerDataTable table = ta.GetDataIfChallanNotCom(int.Parse(unitId), int.Parse(shipPointId), doCode);

                if (table.Rows.Count > 0)
                {
                    customer = table[0].strName;
                    customerId = table[0].intCustomerId.ToString();
                    return table[0].intId;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public bool ExistsDO(string unitId, string shipPointId, string doCode)
        {
            long? id = null;
            QrySalesOrderCustomerTableAdapter ta = new QrySalesOrderCustomerTableAdapter();
            id = ta.ExistsDO(int.Parse(unitId), doCode, int.Parse(shipPointId));

            if (id == null) return false;
            return true;
        }

        public void SetDOToAnotherShipPoint(string unitId, string shipPointId, string doCode, string newShipPointId, string userId)
        {
            QrySalesOrderCustomerTableAdapter ta = new QrySalesOrderCustomerTableAdapter();
            ta.UpdateShipPoint(int.Parse(newShipPointId), int.Parse(unitId), doCode, int.Parse(shipPointId));

            QueriesTableAdapter qt = new QueriesTableAdapter();
            qt.InsertShipPointChangeLog(int.Parse(unitId), doCode, int.Parse(shipPointId), int.Parse(newShipPointId), int.Parse(userId));
        }

        public SalesOrderTDS.QrySalesOrderDetailsTestDataTable GetSalesOrderDetailsTest(string SOid)
        {
            QrySalesOrderDetailsTestTableAdapter ta = new QrySalesOrderDetailsTestTableAdapter();
            return ta.GetDataBySOid(long.Parse(SOid));
        }

        public void AddUpdateDelivaryOrderTEST(string xmlStr, string userId, string unitId
           , DateTime date, DateTime reqDOdate
           , string customerId, string customerType, string narration, string address, string distributionPointId
           , string priceVar, string logisticPriceVar, bool isLogistic
           , string chargeId, decimal charge
           , string incentiveId, decimal incentive
           , string currencyId, decimal conversionRate, string salesTypeId
           , decimal extAmount, string extCause
           , string note, string contatcAt, string ContactPhone
           , string salesOffice, string shippingPoint, bool sdv, ref string code, ref string entryId
           )
        {
            long? id = null;
            int? priceVar_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, chargeId_ = null, incentiveId_ = null;

            try { id = long.Parse(entryId); }
            catch { }
            try { priceVar_ = int.Parse(priceVar); }
            catch { }

            try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
            catch { }
            try { distributionPointId_ = int.Parse(distributionPointId); }
            catch { }

            try { chargeId_ = int.Parse(chargeId); }
            catch { }
            try { incentiveId_ = int.Parse(incentiveId); }
            catch { }

            SprSalesOrderTestTableAdapter ta = new SprSalesOrderTestTableAdapter();

            ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, reqDOdate
                , int.Parse(customerType), int.Parse(customerId)
                , distributionPointId_, narration, address
                , priceVar_, logisticPriceVar_, isLogistic
                , chargeId_, charge, incentiveId_, incentive
                , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause
                , note, contatcAt, ContactPhone, int.Parse(salesOffice)
                , int.Parse(shippingPoint), true, sdv, ref code);

            entryId = id.ToString();
        }

        /////
        public void AddUpdateDelivaryOrderTEST1(string xmlStr, string userId, string unitId
         , DateTime date, DateTime reqDOdate
         , string customerId, string customerType, string narration, string address, string distributionPointId
         , string priceVar, string logisticPriceVar, bool isLogistic
         , string chargeId, decimal charge
         , string incentiveId, decimal incentive
         , string currencyId, decimal conversionRate, string salesTypeId
         , decimal extAmount, string extCause
         , string note, string contatcAt, string ContactPhone
         , string salesOffice, string shippingPoint, bool sdv, ref string code, ref string entryId,string slotnumber
         )
        {
            long? id = null;
            int? priceVar_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, chargeId_ = null, incentiveId_ = null;

            try { id = long.Parse(entryId); }
            catch { }
            try { priceVar_ = int.Parse(priceVar); }
            catch { }

            try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
            catch { }
            try { distributionPointId_ = int.Parse(distributionPointId); }
            catch { }

            try { chargeId_ = int.Parse(chargeId); }
            catch { }
            try { incentiveId_ = int.Parse(incentiveId); }
            catch { }

            SprSalesOrderTest1TableAdapter ta = new SprSalesOrderTest1TableAdapter();

            ta.GetData(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, reqDOdate
                , int.Parse(customerType), int.Parse(customerId)
                , distributionPointId_, narration, address
                , priceVar_, logisticPriceVar_, isLogistic
                , chargeId_, charge, incentiveId_, incentive
                , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause
                , note, contatcAt, ContactPhone, int.Parse(salesOffice)
                , int.Parse(shippingPoint), true, sdv, ref code, int.Parse(slotnumber));

            entryId = id.ToString();
        }

        public SalesOrderTDS.SprSalesOrderDetaillsForTripAssignDataTable GetSalesOrderDetailsTrip(string SOid)
        {
            SprSalesOrderDetaillsForTripAssignTableAdapter ta = new SprSalesOrderDetaillsForTripAssignTableAdapter();
            return ta.GetDataSalesOrderDetaillsForTripAssign(long.Parse(SOid));
        }

        public void GetTripidfromSalesOrderID(string SOId, ref string tripid, ref string challannumber)
        {
            SprGetTripidandChallanTableAdapter ta = new SprGetTripidandChallanTableAdapter();
            ta.GetDataGetTripidandChallan(int.Parse(SOId), ref tripid, ref challannumber);
        }

        public void tripcodenumber(string tripid,ref string tripcode)
        {
            SprGetTripCodeFromIdTableAdapter ta = new SprGetTripCodeFromIdTableAdapter();
            ta.GetDataGetTripCodeFromId(tripid, ref tripcode);
        }

        public void tripidvscalculatedweight(string tripid, ref string calculwgt)
        {
            SprGetTripIdanderpcalculateWeightTableAdapter ta = new SprGetTripIdanderpcalculateWeightTableAdapter();
            ta.GetDataGetTripIdanderpcalculateWeight(tripid, ref calculwgt);
        }

        public DataTable Getpendingqnt(string tripid)
        {
            SprTripIdVsPendingQntAndValueTableAdapter ta = new SprTripIdVsPendingQntAndValueTableAdapter();
            return ta.GetDataTripIdVsPendingQntAndValue(int.Parse(tripid));
        }


        public void AddUpdateReturnSalesDO(string xmlStr, string userId, string unitId
          , DateTime date, DateTime reqDOdate
          , string customerId, string customerType, string narration, string address, string distributionPointId
          , string priceVar, string logisticPriceVar, bool isLogistic
          , string chargeId, decimal charge
          , string incentiveId, decimal incentive
          , string currencyId, decimal conversionRate, string salesTypeId
          , decimal extAmount, string extCause
          , string note, string contatcAt, string ContactPhone
          , string salesOffice, string shippingPoint, bool sdv, ref string code, ref string entryId
          )
        {
            long? id = null;
            int? priceVar_ = null, logisticPriceVar_ = null;
            int? distributionPointId_ = null, chargeId_ = null, incentiveId_ = null;

            try { id = long.Parse(entryId); }
            catch { }
            try { priceVar_ = int.Parse(priceVar); }
            catch { }

            try { logisticPriceVar_ = int.Parse(logisticPriceVar); }
            catch { }
            try { distributionPointId_ = int.Parse(distributionPointId); }
            catch { }

            try { chargeId_ = int.Parse(chargeId); }
            catch { }
            try { incentiveId_ = int.Parse(incentiveId); }
            catch { }

            SprReturnSalesDOTableAdapter ta = new SprReturnSalesDOTableAdapter();

            ta.GetDataReturnSalesDO(xmlStr, ref id, int.Parse(userId), int.Parse(unitId), date, reqDOdate
                , int.Parse(customerType), int.Parse(customerId)
                , distributionPointId_, narration, address
                , priceVar_, logisticPriceVar_, isLogistic
                , chargeId_, charge, incentiveId_, incentive
                , int.Parse(currencyId), conversionRate, int.Parse(salesTypeId), extAmount, extCause
                , note, contatcAt, ContactPhone, int.Parse(salesOffice)
                , int.Parse(shippingPoint), true, sdv, ref code);

            entryId = id.ToString();
        }

        public SalesOrderTDS.SprSalesOrderCustomerDOwithReturnDODataTable GetSalesOrderWithRetunDO(string id)
        {
            SprSalesOrderCustomerDOwithReturnDOTableAdapter ta = new SprSalesOrderCustomerDOwithReturnDOTableAdapter();
            return ta.GetDataById(long.Parse(id));
        }

        public DataTable GetDamageItemInfo(int type, int actionby, string xml, int id, DateTime fdate, DateTime tdate, int unitid, string chalan)
        {
            SprDamageDOCreateInfoTableAdapter adp = new SprDamageDOCreateInfoTableAdapter();
            try { return adp.GetDataDamageDOCreateInfo(type, actionby, xml, id, fdate, tdate, unitid, chalan); }
            catch { return new DataTable(); }
        }
        public DataTable Getsalestrendinfo(int unit, DateTime fdateMonth, DateTime tdateMonth, DateTime fdateday, DateTime tdateday, DateTime fdateLastYr, DateTime tdateLastYr, int totalday, int runningday)
        {
            SprSalesTrandAnalysisTableAdapter adp = new SprSalesTrandAnalysisTableAdapter();
            try { return adp.GetDataSalesTrandAnalysis(unit, fdateMonth, tdateMonth, fdateday, tdateday, fdateLastYr, tdateLastYr, totalday, runningday); }
            catch { return new DataTable(); }
        }
        public DataTable getTripInfo(string tripcode)
        {
            TblTripDetinfoTableAdapter adp = new TblTripDetinfoTableAdapter();
            try { return adp.GetDataTripChallaninfo(tripcode); }
            catch { return new DataTable(); }
        }

        public DataTable GetFactoryAndGhatDelv(DateTime fdateMonth, DateTime tdateMonth)
        {
            SprACCLGHATAndFactDelvTableAdapter adp = new SprACCLGHATAndFactDelvTableAdapter();
            try { return adp.GetDataACCLGHATAndFactDelv( fdateMonth, tdateMonth); }
            catch { return new DataTable(); }
        }

        public DataTable GetdataSalesINMT(DateTime fdateMonth)
        {
            SprACCLSalesComparisonBagCementTableAdapter adp = new SprACCLSalesComparisonBagCementTableAdapter();
            try { return adp.GetData(fdateMonth); }
            catch { return new DataTable(); }
        }

        public DataTable SalesComtType(int unitid)
        {
            TblSalescomTypeTableAdapter adp = new TblSalescomTypeTableAdapter();
            try { return adp.GetDataCommissiontype(unitid); }
            catch { return new DataTable(); }
        }

        public DataTable getdataCustomerCommission(DateTime dtfromdate, DateTime dttodate, int salesofice, string reptname, int unitid)
        {
            try
            {
                SprACRDCommissionTableAdapter bll = new SprACRDCommissionTableAdapter();
                return bll.GetDataACRDCommission(dtfromdate, dttodate, salesofice, reptname, unitid);
            }
            catch { return new DataTable(); }
        }

        //@type int, @actionby int, @xml xml, @id int, @from date, @to date,@intunitid int,@territoryid int
        public DataTable getdataProgrambillcostinfo(int typeid, int actionby,string xml, int id, DateTime dtfromdate, DateTime dttodate, int unitid, int territoryid)
        {
            try
            {
                SprProgramBillInfoDetaillsTableAdapter bll = new SprProgramBillInfoDetaillsTableAdapter();
                return bll.GetDataProgramBillInfoDetaills(typeid,  actionby,  xml,  id,  dtfromdate,  dttodate,  unitid,  territoryid);
            }
            catch { return new DataTable(); }
        }
    }
}
