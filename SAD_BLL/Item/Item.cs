using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item;
using SAD_DAL.Item.ItemTDSTableAdapters;
using SAD_DAL.Item.ItemCOATDSTableAdapters;

namespace SAD_BLL.Item
{
    public class Item
    {
        public ItemTDS.TblItemTypeDataTable GetActiveItemType(string unitID)
        {
            if (unitID != null)
            {
                TblItemTypeTableAdapter ta = new TblItemTypeTableAdapter();
                return ta.GetActiveData(int.Parse(unitID));
            }

            return null;
        }
        public ItemTDS.TblItemTypeDataTable GetActiveItemType_FG(string unitID)
        {
            if (unitID != null)
            {
                TblItemTypeTableAdapter ta = new TblItemTypeTableAdapter();
                return ta.GetFinishGoods(int.Parse(unitID));
            }

            return null;
        }

        public ItemTDS.SprItemGetDataDataTable GetActiveItems(string levelOneId,string idList,string subLevelList)
        {
            ItemTDS.SprItemGetDataDataTable table = new ItemTDS.SprItemGetDataDataTable();
            if (""+levelOneId != "")
            {
                SprItemGetDataTableAdapter ta = new SprItemGetDataTableAdapter();
                table = ta.GetData(int.Parse(levelOneId), idList, subLevelList, true);
            }

            return table;
        }

        public void AddItem(string id,string unitId,string typeId,string levelOneId,string idList,string subLevelList,string userId,string salesTypeList)
        {
            long? id_ = null;
            try { id_ = long.Parse(id); }
            catch { }

            if (salesTypeList.Length > 0 && salesTypeList.EndsWith(","))
            {
                salesTypeList = salesTypeList.Substring(0, salesTypeList.Length - 1);
            }

            SprItemAddTableAdapter ta = new SprItemAddTableAdapter();
            ta.GetData(id_, int.Parse(unitId), int.Parse(userId), int.Parse(typeId), int.Parse(levelOneId), idList, subLevelList, salesTypeList);
        }

        public ItemTDS.TblItemDataTable GetActiveFinishGoods(string unitId)
        {
            TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
            SAD_DAL.Item.ItemTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(int.Parse(unitId));

            int id = 0;
            if (tbl.Rows.Count > 0) id = tbl[0].intID;

            TblItemTableAdapter ta = new TblItemTableAdapter();
            return ta.GetDataByUnit_Type(int.Parse(unitId), id, true);
        }
        public ItemTDS.TblItemDataTable GetItemsByID(string id)
        {
            TblItemTableAdapter ta = new TblItemTableAdapter();
            return ta.GetDataById(long.Parse(id));
        }

        public void GetCOAByItemId(string itemId,string unitId,string salesType,ref string coaId,ref string coaName)
        {
            int? coa = null;
            SprItemGetCOAInfoByIdTableAdapter ta = new SprItemGetCOAInfoByIdTableAdapter();
            ta.GetData(int.Parse(itemId), int.Parse(unitId), int.Parse(salesType), ref coa, ref coaName);

            coaId = coa.ToString();
        }

        public void GetDiscountamountbyItemId(string itemId, string unitId, ref string discountamount)
        {
            decimal? discamnt = null;
            SprItemGetDiscountAmountInfoByIdTableAdapter ta = new SprItemGetDiscountAmountInfoByIdTableAdapter();
            ta.GetDataItembasisDiscountAmount(int.Parse(itemId), int.Parse(unitId), ref discamnt);

            discountamount = discamnt.ToString();
        }

        public void GetDeductionalamountinfobyItemId(string unitId, string itemId, ref string discountamount, ref string mondamage, ref string monspecial,ref string monsubsidiary,ref string monsuppliervhc,ref string moncustomervhc,ref string moncompanyvhc)
        {
            decimal? discamnt = null;
            decimal? disdamage = null;
            decimal? disspecial = null;
            decimal? dissubsidy = null;
            decimal? dissupplier = null;
            decimal? discustomer = null;
            decimal? discompany = null;

            SprCustomersubsidyallowinfoTableAdapter ta = new SprCustomersubsidyallowinfoTableAdapter();
            ta.GetData(int.Parse(unitId), int.Parse(itemId), ref discamnt, ref disdamage, ref disspecial,ref dissubsidy,ref dissupplier,ref discustomer,ref discompany);

            discountamount = discamnt.ToString();
            mondamage = disdamage.ToString();
            monspecial = disspecial.ToString();
            monsubsidiary = dissubsidy.ToString();
            monsuppliervhc = dissupplier.ToString();
            moncustomervhc = discustomer.ToString();
            moncompanyvhc = discompany.ToString();
        }

        public void discountallowstatus(string unitid ,string salesofficeid,ref bool ysndiscstatus)
        {
            bool? ysndis = null;
            SprDiscountApplicableStatusTableAdapter ta = new SprDiscountApplicableStatusTableAdapter();
            ta.GetDataDiscountApplicableStatus(int.Parse(unitid), int.Parse(salesofficeid), ref  ysndis);
            ysndiscstatus =Convert.ToBoolean (ysndis.ToString());
        }

    }
}
