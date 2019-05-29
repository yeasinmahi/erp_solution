using DALOOP.Inventory;

namespace BLL.Inventory
{

    public class FactoryReceiveMrrItemDetailBll
    {
        private readonly FactoryReceiveMRRItemDetailDal _dal = new FactoryReceiveMRRItemDetailDal();
        public int Insert(int intMrrId, int intItemId, decimal numPoQty, decimal numReceiveQty, decimal monFcRate, decimal monFcTotal, decimal monBdtTotal,
            int intLocationId, int intPoId, string strReceiveRemarks, decimal monVatAmount, decimal monAitAmount, string dteExpireDate, string dteMfGdate,
            string strBatchNo)
        {

            return _dal.Insert(intMrrId, intItemId, numPoQty, numReceiveQty, monFcRate, monFcTotal, monBdtTotal,
                intLocationId, intPoId, strReceiveRemarks, monVatAmount, monAitAmount, dteExpireDate, dteMfGdate,
                strBatchNo);

        }
    }
}
