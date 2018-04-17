using SAD_DAL.Corporate_sales.OrderInput_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAD_BLL.Corporate_Sales
{
    public class OrderInput_BLL
    {
        public DataTable shippingpointName(int intUnit)
        {
            TblShippingPointTableAdapter ship = new TblShippingPointTableAdapter();
            return ship.ShipingPointGetData(intUnit);
        }



        public DataTable GetProductUOM(int p1, int itemCustID, int p2, int itemProductID, DateTime dateTime1, DateTime dateTime2, decimal total,int p3)
        {
            SprCorporateSalesOrderTableAdapter uom = new SprCorporateSalesOrderTableAdapter();
            return uom.CorporateSalesOrderGetData(0, itemCustID, 0, itemProductID, DateTime.Now, DateTime.Now, total,0);
        }

        public DataTable ProductPrice(int p1, int itemCustID, int p2, int itemProductID, DateTime dateTime1, DateTime dateTime2, decimal total,int P3)
        {
            SprCorporateSalesOrderTableAdapter price = new SprCorporateSalesOrderTableAdapter();
            return price.CorporateSalesOrderGetData(1, itemCustID, 0, itemProductID, DateTime.Now, DateTime.Now, total,0);
        }

        public DataTable GetCustomerBlance(int p1, int itemCustID, int p2, int itemProductID, DateTime dateTime1, DateTime dateTime2, decimal total, int p3)
        {
            SprCorporateSalesOrderTableAdapter blance = new SprCorporateSalesOrderTableAdapter();
            return blance.CorporateSalesOrderGetData(2, itemCustID, 0, itemProductID, DateTime.Now, DateTime.Now, total, 0);
        }

        public DataTable CreateCorporaeOrderNumber(int p1, int p2, string xmlString, int p3, DateTime dateTime1, DateTime dateTime2, int p4, int p5)
        {
            SprCorporateSalesOrderTableAdapter blance = new SprCorporateSalesOrderTableAdapter();
             return blance.CorporateSalesOrderGetData(3, p2, xmlString, p3, DateTime.Now, DateTime.Now, 0, 0); 
            
        }

        public DataTable Viewgrid(int enroll)
        {
            UserGridViewDataTableTableAdapter gridview = new UserGridViewDataTableTableAdapter();
            return gridview.UserGridViewGetData(enroll);
        }

        public DataTable Orderdetalis(int order)
        {
            UserGridViewDataTableTableAdapter detalisv = new UserGridViewDataTableTableAdapter();
            return detalisv.OrderDetalisGetData(order);
        }

        public DataTable getordderReport()
        {
            OrderSummaryTableAdapter getorderReport = new OrderSummaryTableAdapter();
            return getorderReport.GetData();
        }

        public DataTable getDetailsReport(int ordernumber)
        {
            OrderDetailsTableAdapter ReportDetails = new OrderDetailsTableAdapter();
            return ReportDetails.GetData(ordernumber);
        }

        public void getinsertorderApp(int unitid, string intShipPointId, string IntOrderNumber, string intCustid, string intproductid, string qty, string rate, decimal totalAmount, DateTime dtedate, int enroll)
        {
            tblCorporate_OrderFinal1TableAdapter getorderAppproe = new tblCorporate_OrderFinal1TableAdapter();
             getorderAppproe.GetOrderInsertAppr(unitid,int.Parse(intShipPointId),int.Parse(IntOrderNumber),int.Parse(intCustid),int.Parse(intproductid),decimal.Parse(qty),decimal.Parse(rate),(totalAmount),Convert.ToString(dtedate),enroll);
        }

        public void getorderupadate(string IntOrderNumber)
        {
            OrderUpdateTableAdapter getorderUpdate = new OrderUpdateTableAdapter();
            getorderUpdate.GetOrderUpdate(int.Parse(IntOrderNumber));
        }

        public DataTable getordderReportapp()
        {
            AppReportTableAdapter getApproved = new AppReportTableAdapter();
            return getApproved.GetData();
        }



        public void GetdamageReportbill(int Custid, string pono, string grnno, DateTime dtedate,int enroll,string addresss,string challanno)
        {
            tblinstitutePoNoinputTableAdapter getCustBridgeinput = new tblinstitutePoNoinputTableAdapter();
            getCustBridgeinput.GetChallanPoGRNBridge(Custid, pono, grnno, dtedate, enroll,addresss, challanno);
        }
    }
}
