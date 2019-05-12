using System;

namespace BLL.Inventory
{
    public class StoreIssueBll
    {
        
        public void  StoreIssue(int whId, int itemId, decimal itemQuantity, decimal itemValue, int locationId,int enroll)
        {
            InventoryBll inventoryBll = new InventoryBll();
            int jvId = inventoryBll.GetInventoryJvByDateType(DateTime.Now, 3);
            if (jvId > 0)
            {
                ItemListBll itemList = new ItemListBll();
                if (itemList.GetItemCoaId(itemId) > 0)
                {
                    //TODO: insert
                }
                else
                {
                    InconsistanceItemBll inconsistanceItemBll = new InconsistanceItemBll();
                    if (inconsistanceItemBll.Insert(whId, itemId, itemQuantity, itemValue, locationId, enroll) > 0)
                    {
                        //TODO: success insert
                    }
                    else
                    {
                        //TODO: fails insert
                    }
                }
                
            }
            else
            {
                //TODO: insert
            }


        }
    }
}
