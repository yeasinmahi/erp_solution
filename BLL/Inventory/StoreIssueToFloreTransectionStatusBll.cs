using System.Data;
using DALOOP.Inventory;
namespace BLL.Inventory
{
    public class StoreIssueToFloreTransectionStatusBll
    {
        private readonly StoreIssueToFloreTransectionStatusDal _dal = new StoreIssueToFloreTransectionStatusDal();
        public int Insert(int itemId, int inventoryId, int whId, int unitId)
        {
            return _dal.Insert(itemId, inventoryId, whId, unitId);
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
        public DataTable GetTodaysComplete(int unitId)
        {
            return _dal.GetTodaysComplete(unitId);
        }
        public bool UpdateIsProcessed(bool isProcessed, int autoId)
        {
            return _dal.UpdateIsProcessed(isProcessed, autoId);
        }
        public bool UpdateJv(int jvId, int autoId)
        {
            return _dal.UpdateJv(jvId, autoId);
        }
        public bool UpdateCoaId1(int coaId1, int autoId)
        {
            return _dal.UpdateCoaId1(coaId1, autoId);
        }
        public bool UpdateCoaId2(int coaId2, int autoId)
        {
            return _dal.UpdateCoaId2(coaId2, autoId);
        }

    }
}
