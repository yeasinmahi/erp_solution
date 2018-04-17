using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAD_DAL.Sales.Report.SalesByCusProTDSTableAdapters;
using SAD_DAL.Sales.Report;
using GLOBAL_BLL;
using System.Data;

namespace SAD_BLL.Sales.Report
{
    public class SalesByCusPro
    {

        public SalesByCusProTDS.SprCustomerStatementOnProductDataTable GetStatementByCustomerProduct(string fromDate, string toDate, string customerId,string productId, string userID, string unitID,string customerType,string salesOffice,bool isPromotionIncluded, ref string unitName, ref string unitAddress)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { frm = DateTime.Now.Date; }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now.Date; }

            int? cus = null, pro = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pro = int.Parse(productId); }
            catch { }

            SprCustomerStatementOnProductTableAdapter ta = new SprCustomerStatementOnProductTableAdapter();
            return ta.GetData(frm, to, cus, pro, int.Parse(userID), int.Parse(unitID), int.Parse(customerType), int.Parse(salesOffice), isPromotionIncluded, ref unitName, ref unitAddress);
        }
        public DataTable getshipingpoints(int unitid)
        {

            DataTable1TableAdapter shiping = new DataTable1TableAdapter();
            return shiping.GetData(unitid);


        }
        public DataTable getfree(int intreportid, int number, string fromDate, string toDate, int intshipingid, int unitid)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { frm = DateTime.Now.Date; }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now.Date; }

            AFBLFreeProductReportTableAdapter getfreeqty = new AFBLFreeProductReportTableAdapter();
            return getfreeqty.GetData(intreportid, number, frm, to, intshipingid, unitid);

        }
   
        public SalesByCusProTDS.SprCustomerStatementOnProductGrossDataTable GetStatementByCustomerProductGross(string fromDate, string toDate, string customerId, string productId, string userID, string unitID, string customerType, string salesOffice, bool isPromotionIncluded, ref string unitName, ref string unitAddress)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { frm = DateTime.Now.Date; }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now.Date; }

            int? cus = null, pro = null, so = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pro = int.Parse(productId); }
            catch { }
            try { so = int.Parse(salesOffice); }
            catch { }


            SprCustomerStatementOnProductGrossTableAdapter ta = new SprCustomerStatementOnProductGrossTableAdapter();
            return ta.GetData(frm, to, cus, pro, int.Parse(userID), int.Parse(unitID), int.Parse(customerType), so, isPromotionIncluded, ref unitName, ref unitAddress);
        }
    }
}
