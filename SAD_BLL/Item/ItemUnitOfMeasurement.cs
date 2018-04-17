using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item.UomTDSTableAdapters;
using SAD_DAL.Item;
using GLOBAL_BLL;
using System.Data;


namespace SAD_BLL.Item
{
    public class ItemUnitOfMeasurement
    {
        //GetUOMRelationByPrice
        public UomTDS.TblUOMDataTable GetUOMList(string unitID)
        {
            TblUOMTableAdapter ta = new TblUOMTableAdapter();

            return ta.GetActiveData(int.Parse(unitID));
        }
        public UomTDS.TblUOMDataTable GetUOMById(string id)
        {
            TblUOMTableAdapter ta = new TblUOMTableAdapter();
            return ta.GetDataById(int.Parse(id));
        }
        public UomTDS.SprGetUOMRelationDataTable GetUOMRelationById(string uomId)
        {
            int? id_ = null;
            try { id_ = int.Parse(uomId); }
            catch { }

            SprGetUOMRelationTableAdapter ta = new SprGetUOMRelationTableAdapter();
            return ta.GetData(id_);
        }
        public UomTDS.SprGetUOMRelationByPriceDataTable GetUOMRelationByPrice(string productId, string customerId, string priceVariable, string salesType, string date)
        {
            if (productId == null || salesType == null) return null;

            int? cus = null, pv = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pv = int.Parse(priceVariable); }
            catch { }

            DateTime? dte = DateFormat.GetDateAtSQLDateFormat(date);

            SprGetUOMRelationByPriceTableAdapter ta = new SprGetUOMRelationByPriceTableAdapter();

            //DataTable dt = new DataTable();
            //dt = ta.GetData(long.Parse(productId), cus, pv, int.Parse(salesType), dte.Value.Date);

           return ta.GetData(long.Parse(productId), cus, pv, int.Parse(salesType), dte.Value.Date);
        }
        public UomTDS.QryUOMWeightDataTable GetWeightUOM(string unitId)
        {
            QryUOMWeightTableAdapter ta = new QryUOMWeightTableAdapter();
            return ta.GetData(int.Parse(unitId));
        }
        public UomTDS.QryItemUOMDataTable GetItemUOM(string itemId)
        {
            if (itemId == null || itemId == "") return new UomTDS.QryItemUOMDataTable();
            QryItemUOMTableAdapter ta = new QryItemUOMTableAdapter();
            return ta.GetData(int.Parse(itemId));
        }

    }
}
