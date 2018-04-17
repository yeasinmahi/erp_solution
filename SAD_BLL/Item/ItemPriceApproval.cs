using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item;
using SAD_DAL.Item.ItemPriceApprovalTDSTableAdapters;

namespace SAD_BLL.Item
{
    public class ItemPriceApproval
    {
        public ItemPriceApprovalTDS.SprItemGetDataWithRequestPriceForApprovalDataTable GetDataForApprovalLevelOne(string levelOneId, string idList, string subLevelList)
        {
            if (levelOneId == null || idList == null || subLevelList == null) return null;
            SprItemGetDataWithRequestPriceForApprovalTableAdapter ta = new SprItemGetDataWithRequestPriceForApprovalTableAdapter();
            return ta.GetData(int.Parse(levelOneId), idList, subLevelList, 1);
        }
        public ItemPriceApprovalTDS.SprItemGetDataWithRequestPriceForApprovalDataTable GetDataForApprovalLevelTwo(string levelOneId, string idList, string subLevelList)
        {
            if (levelOneId == null || idList == null || subLevelList == null) return null;
            SprItemGetDataWithRequestPriceForApprovalTableAdapter ta = new SprItemGetDataWithRequestPriceForApprovalTableAdapter();
            return ta.GetData(int.Parse(levelOneId), idList, subLevelList,2);
        }

        public void PriceApprovedOne(string userId,string idList,ref int? error)
        {            
            SprItemPriceForApprovalTableAdapter ta = new SprItemPriceForApprovalTableAdapter();
            ta.GetData(int.Parse(userId), 1, idList,ref error);
        }

        public void PriceApprovedTwo(string userId, string idList, ref int? error)
        {
            SprItemPriceForApprovalTableAdapter ta = new SprItemPriceForApprovalTableAdapter();
            ta.GetData(int.Parse(userId), 2, idList, ref error);
        }
    }
}
