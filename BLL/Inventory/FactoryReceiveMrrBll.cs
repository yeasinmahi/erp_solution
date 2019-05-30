using DALOOP.Inventory;

namespace BLL.Inventory
{
    public class FactoryReceiveMrrBll
    {
        private readonly FactoryReceiveMrrDal _dal = new FactoryReceiveMrrDal();
        public int Insert(int intPOID, int intSupplierID, int intShipmentSL, int intLastActionBy, int intUnitID,
            string strExtnlReff, string dteChallanDate, int intWHID, string strVatChallan, decimal monTotaVAT, decimal monTotalAIT, bool ysnInventory,
            int intShipmentID)
        {


            return _dal.Insert(intPOID, intSupplierID, intShipmentSL, intLastActionBy, intUnitID,
                strExtnlReff, dteChallanDate, intWHID, strVatChallan, monTotaVAT, monTotalAIT, ysnInventory,
                intShipmentID);

        }
    }
}
