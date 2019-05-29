using System;
using System.Data;
using DAL.Inventory.FactoryReceiveMRRTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class FactoryReceiveMrrDal
    {
        private DataTable _dt = new DataTable();
        public int Insert(int intPOID, int intSupplierID, int intShipmentSL, int intLastActionBy, int intUnitID,
            string strExtnlReff, string dteChallanDate, int intWHID, string strVatChallan, decimal monTotaVAT, decimal monTotalAIT, bool ysnInventory,
            int intShipmentID)
        {
            try
            {
                tblFactoryReceiveMRRTableAdapter adp = new tblFactoryReceiveMRRTableAdapter();
                _dt = adp.Insert1(intPOID, intSupplierID, intShipmentSL, intLastActionBy, DateTime.Now, intUnitID,
                    strExtnlReff, dteChallanDate, intWHID, strVatChallan, monTotaVAT, monTotalAIT, ysnInventory,
                    intShipmentID);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.GetAutoId("intMRRID");
                }

                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
