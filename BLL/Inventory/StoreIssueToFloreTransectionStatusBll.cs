using DALOOP.Inventory;
namespace BLL.Inventory
{
    public class StoreIssueToFloreTransectionStatusBll
    {
        private readonly StoreIssueToFloreTransectionStatusDal _dal = new StoreIssueToFloreTransectionStatusDal();
        public int Insert(int itemId, int inventoryId)
        {
            return _dal.Insert(itemId, inventoryId);
        }
    }
}
