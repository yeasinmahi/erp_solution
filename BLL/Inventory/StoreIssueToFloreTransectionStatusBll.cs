using System.Data;
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
        public DataTable GetAll()
        {
            return _dal.GetAll();
        }
        public DataTable GetTodays()
        {
            return _dal.GetTodays();
        }
        public DataTable GetTodaysComplete()
        {
            return _dal.GetTodaysComplete();
        }

    }
}
