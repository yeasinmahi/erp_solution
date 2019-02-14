using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item.ItemPriceTDSTableAdapters;
using SAD_DAL.Item;
using SAD_BLL.Global;
using SAD_DAL.Item.ItemTDSTableAdapters;

namespace SAD_BLL.Item
{
    public class ItemPrice
    {
        public decimal GetPrice(string productId, string customerId, string priceVariable, string UOM, string currency, string salesType
            , DateTime date,ref decimal comission, ref decimal suppTax, ref decimal vat, ref decimal vatPrice, ref decimal conversionRate)
        {
            int? cus = null, pv = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pv = int.Parse(priceVariable); }
            catch { }

            decimal? price = 0;            
            decimal? commission_ = 0;
            
            decimal? suppTax_ = 0;
            decimal? vat_ = 0;
            decimal? vatPrice_ = 0;

            decimal? conversionRate_ = 0;

            if (productId.ToString() == "" || UOM.ToString() == "") return price.Value;
            
            SprItemGetPriceTableAdapter ta = new SprItemGetPriceTableAdapter();
            ta.GetData(int.Parse(productId), cus, pv, int.Parse(UOM), int.Parse(currency), int.Parse(salesType), date.Date, ref price, ref commission_, ref suppTax_, ref vat_, ref vatPrice_, true, ref conversionRate_);
                         
            comission = commission_.Value;
            
            suppTax = suppTax_.Value;
            vat = vat_.Value;
            vatPrice = vatPrice_.Value;

            conversionRate = conversionRate_.Value;

            return price.Value;
        }

        public decimal GetPriceWithCommPromoInc(string productId,string chargeId,string incentiveId, string customerId, string priceVariable, string UOM, string currency, string salesType
            , DateTime date,ref decimal charge,ref decimal incentive, ref decimal comission, ref decimal suppTax, ref decimal vat, ref decimal vatPrice
            , ref decimal promQnty, ref int promItemId, ref string promItem, ref int promItemUOM, ref string promUom, ref decimal conversionRate)
        {
            int? cus = null, pv = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pv = int.Parse(priceVariable); }
            catch { }

            decimal? price = 0;
            decimal? charge_ = 0;
            decimal? incentive_ = 0;
            decimal? commission_ = 0;

            decimal? suppTax_ = 0;
            decimal? vat_ = 0;
            decimal? vatPrice_ = 0;
            
            decimal? promQnty_ = 0;
            int? promItemId_ = 0;
            int? promItemUOM_ = 0;

            decimal? conversionRate_ = 0;

            if (productId.ToString() == "" || UOM.ToString() == "") return price.Value;

            SprItemGetPriceInfoTableAdapter ta = new SprItemGetPriceInfoTableAdapter();
            ta.GetData(int.Parse(productId), cus, pv, int.Parse(UOM), int.Parse(currency)
                , int.Parse(salesType), date.Date,int.Parse(chargeId),int.Parse(incentiveId)
                , ref price, ref charge_,ref incentive_, ref commission_, ref suppTax_, ref vat_
                , ref vatPrice_, ref promQnty_, ref promItemId_, ref promItem
                , ref promItemUOM_, ref promUom, ref conversionRate_);

            comission = commission_.Value;
            charge = charge_.Value;
            incentive = incentive_.Value;

            suppTax = suppTax_.Value;
            vat = vat_.Value;
            vatPrice = vatPrice_.Value;

            promQnty = promQnty_.Value;
            promItemId = promItemId_.Value;
            promItemUOM = promItemUOM_.Value;

            conversionRate = conversionRate_.Value;

            return price.Value;
        }

        public ItemPriceTDS.SprItemGetPriceByDateDataTable GetProductListWithPriceByDate(string levelOneId, string idList, string subLevelList, DateTime date)
        {
            if ("" + levelOneId != "" && "" + idList != "" && "" + subLevelList != "")
            {
                SprItemGetPriceByDateTableAdapter ta = new SprItemGetPriceByDateTableAdapter();
                return ta.GetData(int.Parse(levelOneId), idList, subLevelList, true, date);
            }

            return null;
        }
        public void SetPrice(string userId, string unitId, string levelOneId, string idList, string subLevelList, DateTime startDate, DateTime? endDate, decimal price,string priceCatagory, string uomId, string currencyId,string salesType, ref int? error)
        {
            CodeGenatator cg = new CodeGenatator();
            string code = cg.GetPriceBatchCode(unitId);

            int? prType = null;
            try
            {
                prType = int.Parse(priceCatagory);
            }
            catch { }

            SprItemSetPriceTableAdapter ta = new SprItemSetPriceTableAdapter();
            ta.GetData(int.Parse(userId), int.Parse(levelOneId), idList, subLevelList, true, startDate.Date, endDate, price,int.Parse(unitId), prType, int.Parse(uomId), int.Parse(currencyId), code, int.Parse(salesType), ref error);
        }




        public void SetPriceDiscount(string userId, string unitId, string levelOneId, string idList, string subLevelList, DateTime startDate, DateTime? endDate, decimal price, string priceCatagory, string uomId, string currencyId, string salesType, ref int? error)
        {
            //CodeGenatator cg = new CodeGenatator();
            //string code = cg.GetPriceBatchCode(unitId);

            //int? prType = null;
            //try
            //{
            //    prType = int.Parse(priceCatagory);
            //}
            //catch { }

            //SprItemSetPriceDiscountTableAdapter ta = new SprItemSetPriceDiscountTableAdapter();
            //ta.GetDataDiscount(int.Parse(userId), int.Parse(levelOneId), idList, subLevelList, true, startDate.Date, endDate, price, int.Parse(unitId), prType, int.Parse(uomId), int.Parse(currencyId), code, int.Parse(salesType), ref error);
        }

        public void SetPriceCustomer(string userId, string customerId, string salesoff, string custype, string unitId, string levelOneId, string idList, string subLevelList, DateTime startDate, DateTime? endDate, decimal price, string priceCatagory, string uomId, string currencyId, string salesType, ref int? error)
        {
            CodeGenatator cg = new CodeGenatator();
            string code = cg.GetPriceBatchCode(unitId);

            int? prType = null;
            try
            {
                prType = int.Parse(priceCatagory);
            }
            catch { }

            SprItemSetPriceByCustomerTableAdapter ta = new SprItemSetPriceByCustomerTableAdapter();
            //ta.GetData(int.Parse(customerId), int.Parse(userId), int.Parse(levelOneId), idList, subLevelList, true, startDate.Date, endDate, price, int.Parse(unitId), prType, int.Parse(uomId), int.Parse(currencyId), code, int.Parse(salesType), ref error);
            ta.GetData(int.Parse(customerId), int.Parse(salesoff), int.Parse(custype), int.Parse(userId), int.Parse(levelOneId), idList, subLevelList, true, startDate.Date, endDate, price, int.Parse(unitId), prType, int.Parse(uomId), int.Parse(currencyId), code, int.Parse(salesType), ref error);
        }

        public void SetPriceCustomerDiscount(string userId, string customerId, string salesoff, string custype, string unitId, string levelOneId, string idList, string subLevelList, DateTime startDate, DateTime? endDate, decimal price, string priceCatagory, string uomId, string currencyId, string salesType, ref int? error)
        {
            //CodeGenatator cg = new CodeGenatator();
            //string code = cg.GetPriceBatchCode(unitId);

            //int? prType = null;
            //try
            //{
            //    prType = int.Parse(priceCatagory);
            //}
            //catch { }

            //SprItemSetPriceByCustomerDiscountTableAdapter ta = new SprItemSetPriceByCustomerDiscountTableAdapter();
            ////ta.GetData(int.Parse(customerId), int.Parse(userId), int.Parse(levelOneId), idList, subLevelList, true, startDate.Date, endDate, price, int.Parse(unitId), prType, int.Parse(uomId), int.Parse(currencyId), code, int.Parse(salesType), ref error);
            //ta.GetDataDiscount(int.Parse(customerId), int.Parse(salesoff), int.Parse(custype), int.Parse(userId), int.Parse(levelOneId), idList, subLevelList, true, startDate.Date, endDate, price, int.Parse(unitId), prType, int.Parse(uomId), int.Parse(currencyId), code, int.Parse(salesType), ref error);
        }

        public ItemPriceTDS.SprItemGetDataWithRequestPriceDataTable GetActiveItemsWithPrice(string levelOneId, string idList, string subLevelList)
        {
            ItemPriceTDS.SprItemGetDataWithRequestPriceDataTable table = new ItemPriceTDS.SprItemGetDataWithRequestPriceDataTable();
            if ("" + levelOneId != "" && "" + idList != "" && "" + subLevelList != "")
            {
                SprItemGetDataWithRequestPriceTableAdapter ta = new SprItemGetDataWithRequestPriceTableAdapter();
                table = ta.GetData(int.Parse(levelOneId), idList, subLevelList, true);
            }

            return table;
        }

        public bool GetVisibility(int itemid)
        {
            QueriesTableAdapter adp = new QueriesTableAdapter();
            return bool.Parse(adp.GetPriceVisibility(itemid).ToString());
        }


        public string allTeritoryPriceSet(int unitId, decimal price, DateTime startDate, DateTime endDate, int prdid, int uomId, int userid  )
        {
            string msg = "";
            try
            {
                SprPriceSetAllTerritoryTableAdapter ta = new SprPriceSetAllTerritoryTableAdapter();
                ta.GetDataPriceSetAllTerritory(unitId, price, startDate, endDate, prdid, uomId, userid, ref msg);
                return msg;


            }
            catch(Exception ex) {
                return ex.ToString();
            }


        }

    }
}
