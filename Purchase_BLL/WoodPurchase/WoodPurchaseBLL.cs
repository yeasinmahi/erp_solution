using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Purchase_DAL.WoodPurchase.WoodPurchaseTDSTableAdapters;

namespace Purchase_BLL.WoodPurchase
{
    public class WoodPurchaseBLL
    {
        #region ---------------------- Global ---------------------------------
        public DataTable GetWHList(int intEnroll)
        {
            WHTableAdapter adp = new WHTableAdapter();
            try
            {
                return adp.GetWHByEnroll(intEnroll);
            }
            catch { return new DataTable(); }
        }
        public void POEntry(int intPOID, int intInsertBy, int intUnitID, int intJobStationID)
        {
            TblPOTableAdapter adp = new TblPOTableAdapter();
            try
            {
                adp.POEntry(intPOID, intInsertBy, intUnitID, intJobStationID);
            }
            catch { }
        }
        public DataTable GetInsertedPO(int intUnitID, int intJobStationID)
        {
            POListTableAdapter adp = new POListTableAdapter();
            try
            {
                return adp.GetInsertedPO(intUnitID, intJobStationID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetUnitJobStation(int intWH)
        {
            TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
            try
            {
                return adp.GetUnitJobStationByWH(intWH);
            }
            catch { return new DataTable(); }
        }
        public void UpdatePO(bool ysnActive, int intPOID)
        {
            UpdateTableAdapter adp = new UpdateTableAdapter();
            try
            {
                adp.UpdatePO(ysnActive, intPOID);
            }
            catch {}
        }
        public void DeletePO(int intPOID)
        {
            DeletePOTableAdapter adp = new DeletePOTableAdapter();
            try
            {
                adp.DeletePO(intPOID);
            }
            catch { }
        }
        public DataTable GetPOList(int intWH)
        {
            GetDataTableAdapter adp = new GetDataTableAdapter();
            try
            {
                return adp.GetPOList(intWH);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetWoodType(int intUnitID)
        {
            GetDataTableAdapter adp = new GetDataTableAdapter();
            try
            {
                return adp.GetWoodType(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetZone(int intUnitID, int intJobStationID)
        {
            GetDataTableAdapter adp = new GetDataTableAdapter();
            try
            {
                return adp.GetZone(intUnitID, intJobStationID);
            }
            catch { return new DataTable(); }
        }

        #endregion ------------------------------------------------------------
        #region ----------------------- Wood Receive -------------------------------

        public DataTable GetItemByPO(int intPOID)
        {
            GetDataTableAdapter adp = new GetDataTableAdapter();
            try
            {
                return adp.GetItemByPO(intPOID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetSuppID(int intPOID)
        {
            SupplierTableAdapter adp = new SupplierTableAdapter();
            try
            {
                return adp.GetSuppID(intPOID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetItemDetails(int intPOID, int intItemID)
        {
            TblPurchaseOrderShipmentItemDetailTableAdapter adp = new TblPurchaseOrderShipmentItemDetailTableAdapter();
            try
            {
                return adp.GetItemDetails(intPOID, intItemID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetLocation(int intWH)
        {
            TblWearHouseStoreLocationTableAdapter adp = new TblWearHouseStoreLocationTableAdapter();
            try
            {
                return adp.GetLocationList(intWH);
            }
            catch { return new DataTable(); }
        }
        public DataTable InsertWOPO(int intUnitID, int intWH, int intActionBy, int intItemID, decimal rcvQty, decimal monRate, int intLocation, string strRemarks, DateTime dteDate)
        {
            SprInsertMrrItemDetailWithoutPOTableAdapter adp = new SprInsertMrrItemDetailWithoutPOTableAdapter();
            try
            {
                return adp.InsertMRRWithoutPO(intUnitID, intWH, intActionBy, intItemID, rcvQty, monRate, intLocation, strRemarks, dteDate);
            }
            catch { return new DataTable(); }
        }
        public void InsertMRR(int intPOID, int intItemID, decimal numPOQty, decimal NetQty, decimal monReceRate, decimal numTotalWeight, int intLocationID, int intSupplierID, int intInsertBy, DateTime dteReceiveDate, string strChallan, DateTime dteChallanDate, int intWHID, string strVatChallan, decimal numDeduction, int intWoodTypeID, int intZoneID, string strRemarks, string strGateEntryNo, string strVehicleNo, string strWeightID, int intJobStationID, int intMouisture)
        {
            SprWoodReceiveTableAdapter adp = new SprWoodReceiveTableAdapter();
            try
            {
                adp.InsertWoodMRR(intPOID, intItemID, numPOQty, NetQty, monReceRate, numTotalWeight, intLocationID, intSupplierID, intInsertBy, dteReceiveDate, strChallan, dteChallanDate, intWHID, strVatChallan, numDeduction, intWoodTypeID, intZoneID, strRemarks, strGateEntryNo, strVehicleNo, strWeightID, intJobStationID, intMouisture);
            }
            catch { }
        }
        public DataTable GetRate(int intPOID, int intType, int intCirCum)
        {
            GetRateTableAdapter adp = new GetRateTableAdapter();
            try
            {
                return adp.GetItemID(intPOID, intType, intCirCum);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPOWiseItem(int intPOID)
        {
            POWiseItemTableAdapter adp = new POWiseItemTableAdapter();
            try
            {
                return adp.GetPOWiseItem(intPOID);
            }
            catch { return new DataTable(); }
        }
        public string InsertPreReceive(int intPart, int intSupplierID, int intZoneID, int intPOID, DateTime dteReceiveDate, int intTypeID, DateTime dteChallanDate, int intGateEntry, string strVehicleNo, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprLogReceiveTableAdapter adp = new SprLogReceiveTableAdapter();
                adp.InsertPreReceive(intPart, intSupplierID, intZoneID, intPOID, dteReceiveDate, intTypeID, dteChallanDate, intGateEntry, strVehicleNo, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        #endregion ------------------------------------------------------------
        #region ---------------- Post Receive ---------------------------------

        public DataTable GetPOForDetails()
        {
            POForDetailsTableAdapter adp = new POForDetailsTableAdapter();
            try
            {
                return adp.GetPOForDetails();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetReportForEdit(int intPOID, string dteTransactionDate)
        {
            GetReportForEditTableAdapter adp = new GetReportForEditTableAdapter();
            try
            {
                return adp.GetReportForEdit(intPOID, dteTransactionDate);
            }
            catch { return new DataTable(); }
        }
        public void InactiveByReceiveID(int intReceiveID)
        {
            InactiveReceiveIDTableAdapter adp = new InactiveReceiveIDTableAdapter();
            try
            {
                adp.InactiveByReceiveID(intReceiveID);
            }
            catch { }
        }
        public DataTable GetChallan(int intPOID)
        {
            GetChallanTableAdapter adp = new GetChallanTableAdapter();
            try
            {
                return adp.GetChallanList(intPOID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetReportForSubmit(int intPOID, string dteChallanDate, int intChallan)
        {
            ReportForSubmitTableAdapter adp = new ReportForSubmitTableAdapter();
            try
            {
                return adp.GetReportForSubmit(intPOID, dteChallanDate, intChallan);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetTotalPOQty(int intPOID)
        {
            GetTotalPOQtyTableAdapter adp = new GetTotalPOQtyTableAdapter();
            try
            {
                return adp.GetTotalPOQty(intPOID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetTotalPreReceive(int intPOID)
        {
            GetTotalPreReceiveTableAdapter adp = new GetTotalPreReceiveTableAdapter();
            try
            {
                return adp.GetTotalPreReceive(intPOID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetTotalQtyAmount(int intPOID, string dteChallanDate, int intChallan)
        {
            TotalQtyAmountTableAdapter adp = new TotalQtyAmountTableAdapter();
            try
            {
                return adp.GetTotalQtyAmount(intPOID, dteChallanDate, intChallan);
            }
            catch { return new DataTable(); }
        }
        public DataTable InsertFinalMRRAMFL(int intPOID, int intSupplierID, int intInsertBy, DateTime dteTransactionDate, string strChallan, DateTime dteChallanDate, int intChallan, decimal monLoanInstallmentAmount, decimal monTranportAdvance)
        {
            SprFinalMRRSubmitforAMFLTableAdapter adp = new SprFinalMRRSubmitforAMFLTableAdapter();
            try
            {
                return adp.InsertFinalMRRForAMFL(intPOID, intSupplierID, intInsertBy, dteTransactionDate, strChallan, dteChallanDate, intChallan, monLoanInstallmentAmount, monTranportAdvance);
            }
            catch { return new DataTable(); }
        }
        public DataTable InsertJVAMFL(decimal monAmount, int intSupplierID, int intInsertBy)
        {
            SprJVWoodOfAMFLTableAdapter adp = new SprJVWoodOfAMFLTableAdapter();
            try
            {
                return adp.InsertJVAMFL(monAmount, intSupplierID, intInsertBy);
            }
            catch { return new DataTable(); }
        }
        #endregion ------------------------------------------------------------

        #region =============== Report APBML ==========================
        public DataTable GetWoodReport(DateTime dteFromDate, DateTime dteToDate, int intJobStationID, int intPart, int intPOID)
        {
            SprWoodReportTableAdapter adp = new SprWoodReportTableAdapter();
            try
            {
                return adp.GetWoodReport(dteFromDate, dteToDate, intJobStationID, intPart, intPOID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPOListForReport(int intWHID, int intJobStationID, int intUnitID)
        {
            POForReportTableAdapter adp = new POForReportTableAdapter();
            try
            {
                return adp.GetPOForReport(intWHID, intJobStationID, intUnitID);
            }
            catch { return new DataTable(); }
        }

        #endregion ====================================================

















    }
}
