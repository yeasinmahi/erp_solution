using System.Collections.Generic;
using DALOOP.Inventory;
using Model;

namespace BLL.Inventory
{
    public class FactoryReceiveMrrBll
    {
        private readonly FactoryReceiveMrrDal _dal = new FactoryReceiveMrrDal();
        private readonly FactoryReceiveMrrItemDetailBll _factoryReceiveMrrItemDetailBll = new FactoryReceiveMrrItemDetailBll();
        private readonly InventoryBll _inventory = new InventoryBll();
        public int Insert(int intPOID, int intSupplierID, int intShipmentSL, int intLastActionBy, int intUnitID,
            string strExtnlReff, string dteChallanDate, int intWHID, string strVatChallan, decimal monTotaVAT, decimal monTotalAIT, bool ysnInventory,
            int intShipmentID)
        {


            return _dal.Insert(intPOID, intSupplierID, intShipmentSL, intLastActionBy, intUnitID,
                strExtnlReff, dteChallanDate, intWHID, strVatChallan, monTotaVAT, monTotalAIT, ysnInventory,
                intShipmentID);

        }

        public void MrrReceive(FactoryReceiveMrr factoryReceiveMrr, List<FactoryReceiveMRRItemDetail> factoryReceiveMrrItemDetails)
        {
            if (factoryReceiveMrr.ShipmentSl > 0) // import
            {
                int mrrId=  _dal.Insert(factoryReceiveMrr.PoId, factoryReceiveMrr.SupplierId, factoryReceiveMrr.ShipmentSl, factoryReceiveMrr.LastActionBy, factoryReceiveMrr.UnitId,
                    factoryReceiveMrr.ExternalRef, factoryReceiveMrr.ChallanDate.ToString("dd/MM/yyyy"), factoryReceiveMrr.WhId, factoryReceiveMrr.VatChallan, factoryReceiveMrr.TotalVat, factoryReceiveMrr.TotalAit, factoryReceiveMrr.IsInventoryInserted,
                    factoryReceiveMrr.ShipmentId);
                if (mrrId > 0)
                {
                    foreach (FactoryReceiveMRRItemDetail obj in factoryReceiveMrrItemDetails)
                    {
                        int autoId = _factoryReceiveMrrItemDetailBll.Insert(obj.MrrId, obj.ItemId, obj.PoQuantity,
                            obj.ReceiveQuantity, obj.FcRate, obj.FcTotal, obj.BdtTotal, obj.LocationId, obj.PoId,
                            obj.ReceiveRemarks, obj.VatAmount, obj.AitAmount, null, null, null);
                        if (autoId > 0)
                        {
                            int inventoryId = _inventory.InsertBySpInventoryTransection(factoryReceiveMrr.UnitId,
                                factoryReceiveMrr.WhId, obj.LocationId, obj.LocationId, obj.ReceiveQuantity,
                                obj.BdtTotal, mrrId, 1);
                            if (inventoryId > 0)
                            {
                                //TODO: success
                            }
                            else
                            {
                                //TODO: inventory Insert Fail
                            }
                        }
                        else
                        {
                            //TODO: MRR item Insert Fail 
                        }
                    }
                }
                else
                {
                    //TODO: MRR Insert Fail 
                }
            }
            else // Local
            {
                int mrrId = _dal.Insert(factoryReceiveMrr.PoId, factoryReceiveMrr.SupplierId, factoryReceiveMrr.ShipmentSl, factoryReceiveMrr.LastActionBy, factoryReceiveMrr.UnitId,
                    factoryReceiveMrr.ExternalRef, factoryReceiveMrr.ChallanDate.ToString("dd/MM/yyyy"), factoryReceiveMrr.WhId, factoryReceiveMrr.VatChallan, factoryReceiveMrr.TotalVat, factoryReceiveMrr.TotalAit, factoryReceiveMrr.IsInventoryInserted,
                    factoryReceiveMrr.ShipmentId);
                if (mrrId > 0)
                {
                    foreach (FactoryReceiveMRRItemDetail obj in factoryReceiveMrrItemDetails)
                    {
                        int autoId = _factoryReceiveMrrItemDetailBll.Insert(obj.MrrId, obj.ItemId, obj.PoQuantity,
                            obj.ReceiveQuantity, obj.FcRate, obj.FcTotal, obj.BdtTotal, obj.LocationId, obj.PoId,
                            obj.ReceiveRemarks, obj.VatAmount, obj.AitAmount, null, null, null);
                        if (autoId > 0)
                        {
                            int inventoryId = _inventory.InsertBySpInventoryTransection(factoryReceiveMrr.UnitId,
                                factoryReceiveMrr.WhId, obj.LocationId, obj.LocationId, obj.ReceiveQuantity,
                                obj.BdtTotal, mrrId, 1);
                            if (inventoryId > 0)
                            {
                                //TODO: success
                            }
                            else
                            {
                                //TODO: inventory Insert Fail
                            }
                        }
                        else
                        {
                            //TODO: MRR item Insert Fail 
                        }
                    }
                }
                else
                {
                    //TODO: MRR Insert Fail 
                }
            }
        }
    }
}
