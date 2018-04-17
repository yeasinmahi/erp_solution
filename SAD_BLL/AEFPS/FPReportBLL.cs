using SAD_DAL.AEFPS.FPReportTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.AEFPS
{
    public class FPReportBLL
    {
        public DataTable GetReceiveReport(int intWHID, string dteFrom, string dteTo)
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetReceiveReport(intWHID, dteFrom, dteTo); }
            catch { return new DataTable(); }
        }
        public DataTable GetStockReport(int intWHID)
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetStockReport(intWHID); }
            catch { return new DataTable(); }
        }
        public DataTable GetSales(int intPart, int intWHID, DateTime dteFrom, DateTime dteTo, int intEnroll, bool ysnEnable)
        {
            SprSalesReportTableAdapter adp = new SprSalesReportTableAdapter();
            try
            { return adp.GetSalesReport(intPart, intWHID, dteFrom, dteTo, intEnroll, ysnEnable); }
            catch { return new DataTable(); }
        }
        public DataTable GetPaymentType()
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetPaymentType(); }
            catch { return new DataTable(); }
        }
        public DataTable GetReportForAudit(int intWHID)
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetReportForAudit(intWHID); }
            catch { return new DataTable(); }
        }
        public string InsertAuditStock(int intWHID, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprAuditStockSubmitTableAdapter adp = new SprAuditStockSubmitTableAdapter();
                adp.InsertAuditStock(intWHID, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetLocationType()
        {
            TblRackTypeTableAdapter adp = new TblRackTypeTableAdapter();
            try
            { return adp.GetLocationType(); }
            catch { return new DataTable(); }
        }
        public DataTable GetLocationList(int intType, int intWHID)
        {
            TblRackTypeTableAdapter adp = new TblRackTypeTableAdapter();
            try
            { return adp.GetLocationList(intType, intWHID); }
            catch { return new DataTable(); }
        }
        public void InsertLocation(string strName, int intType, int intWHID, int intUnit)
        {
            try
            {
                TblRackTypeTableAdapter adp = new TblRackTypeTableAdapter();
                adp.InsertLocation(strName, intType, intWHID, intUnit);
            }
            catch {  }
        }
        public DataTable GetUnitID(int intWHID)
        {
            UnitTableAdapter adp = new UnitTableAdapter();
            try
            { return adp.GetUnitID(intWHID); }
            catch { return new DataTable(); }
        }
        public DataTable GetInventory(int intWHID, DateTime dteFrom, DateTime dteTo)
        {
            InventoryTableAdapter adp = new InventoryTableAdapter();
            try
            { return adp.GetInventory(intWHID, dteFrom, dteTo); }
            catch { return new DataTable(); }
        }
        public DataTable GetShortDatedItem(int intWHID)
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetShortDatedItem(intWHID); }
            catch { return new DataTable(); }
        }
        public DataTable GetExpiredItem(int intWHID)
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetExpiredItems(intWHID); }
            catch { return new DataTable(); }
        }
        public DataTable GetCreditReport(int intWHID)
        {
            FPReportTableAdapter adp = new FPReportTableAdapter();
            try
            { return adp.GetCreditReport(intWHID); }
            catch { return new DataTable(); }
        }
    }
}
