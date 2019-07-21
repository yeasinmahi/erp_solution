using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SAD_DAL.Item.UomTDSTableAdapters;
using SAD_DAL.Sales;
using SAD_DAL.Sales.SalesOrderTDSTableAdapters;
using SAD_DAL.Sales.SalesOrderViewTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class SalesOrderView
    {
        public SalesOrderViewTDS.SprSalesOrderByCustomerDataTable GetSalesOrder(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprSalesOrderByCustomerTableAdapter adp = new SprSalesOrderByCustomerTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetData(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }
        
        public void CancelSO(string soId, string userId)
        {
            SprSalesOrderByCustomerTableAdapter adp = new SprSalesOrderByCustomerTableAdapter();
            adp.CancelSO(int.Parse(userId), long.Parse(soId));
        }
        
        public void CompleteSO(string soId, string userId)
        {
            SprSalesOrderByCustomerTableAdapter adp = new SprSalesOrderByCustomerTableAdapter();
            adp.CompleteSO(int.Parse(userId), long.Parse(soId));
        }

        public SalesOrderViewTDS.SprSalesQuationByCustomerDataTable GetSalesQuation(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
           , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprSalesQuationByCustomerTableAdapter adp = new SprSalesQuationByCustomerTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetDataSalesQuationByCustomer(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }

        public SalesOrderViewTDS.SprSalesOrderViewDataTable GetSalesOrderView(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , string customerId, int customerType, int intReportType, string shippingPoint, string salesOffice, string ordertype)
        {
            SprSalesOrderViewTableAdapter adp = new SprSalesOrderViewTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            cId = 0;

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetSalesOrderViewData(int.Parse(unitID), cId, fromDate, toDate, customerType, intReportType, code, int.Parse(shippingPoint), int.Parse(salesOffice), int.Parse(ordertype));

        }

        public SalesOrderViewTDS.SprSalesOrderViewForPickingDataTable GetSalesOrderViewForPicking(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , string customerId, int customerType, int intReportType, string shippingPoint, string salesOffice, string ordertype)
        {
            SprSalesOrderViewForPickingTableAdapter adp = new SprSalesOrderViewForPickingTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            cId = 0;

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetSalesOrderViewForPickingData(int.Parse(unitID), cId, fromDate, toDate, customerType, intReportType, code, int.Parse(shippingPoint), int.Parse(salesOffice), int.Parse(ordertype));

        }

/* Below Code is Monir Vai
        public SalesOrderViewTDS.SprDelivaryOrderStatusDataTable GetDeliveryOrderStatus (DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
       , string customerId, int customerType, int intReportType, string shippingPoint, string salesOffice)
        {
            SprDelivaryOrderStatusTableAdapter adp = new SprDelivaryOrderStatusTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            cId = 0;

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetDataDelivaryOrderStatus(int.Parse(unitID), cId, fromDate, toDate, customerType, intReportType, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }

    */
    

        public SalesOrderViewTDS.SprPickingViewDataTable GetViewPickingData(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
           , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice, string ordertype)
        {
            SprPickingViewTableAdapter adp = new SprPickingViewTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetViewPickingData(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice), int.Parse(ordertype));

        }

        public SalesOrderViewTDS.SprViewSalesDataForInvoiceDataTable GetDataForInvoice(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
           , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprViewSalesDataForInvoiceTableAdapter adp = new SprViewSalesDataForInvoiceTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetDataForInvoice(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }
        
        public string DOApproveCancelClose(int intDOId, int intType, int intInsertBy)
        {
            string msg = "";            
            try
            {
                SprDOApproveCancelCloseTableAdapter adpdo = new SprDOApproveCancelCloseTableAdapter();
                adpdo.OrderApproveCancelClose(intDOId, intType, intInsertBy, ref msg);                
            }
            catch (Exception e) { msg = e.ToString(); }

            return msg;
        }

        public string InvoiceGenerate(int intType, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprInvoiceGenerateTableAdapter adpdo = new SprInvoiceGenerateTableAdapter();
                adpdo.InvoiceGenerate(intType, intInsertBy, xml, ref msg);
            }
            catch (Exception e) { msg = e.ToString(); }

            return msg;
        }
        
        public DataTable GetPickingCreateStatusData(int intUnitId)
        {
            TblSalesConfigTableAdapter ta = new TblSalesConfigTableAdapter();
            return ta.GetPickingCreateStatusData(intUnitId);
        }

        public DataTable getQuationDet(int quatationid)
        {
            SprSalesQuationByCustomerDetTableAdapter ta = new SprSalesQuationByCustomerDetTableAdapter();
            return ta.GetDataSalesQuationByCustomerDet(quatationid);
        }
        public DataTable getQuationDets(int quatationid)
        {
            SprSalesQuationByCustomerDetsTableAdapter ta = new SprSalesQuationByCustomerDetsTableAdapter();
            return ta.GetDataSalesQuationByCustomerDets(quatationid);
        }
        public DataTable getCustPending(int custid)
        {
            SprGetDealerInfoForSalesOrderTableAdapter ta = new SprGetDealerInfoForSalesOrderTableAdapter();
            return ta.GetDataGetDealerInfoForSalesOrder(custid);
        }




        public DataTable getCOAID(string itemid, int unitid, int seletid)
        {

            try
            {
                SprCOAIDTableAdapter adpItemCoAId = new SprCOAIDTableAdapter();
                return adpItemCoAId.GetDataCOAID(int.Parse(itemid), unitid);
            }
            catch { return new DataTable(); }

        }
        //public DataTable getUOM(int v)
        //{
        //    try
        //    {
        //        TblUMTableAdapter adpCoA = new TblUMTableAdapter();
        //        return adpCoA.GetDataUOM((v));
        //    }
        //    catch { return new DataTable(); }
        //}

        public DataTable getUOM(int itemid,int intcustid , int intpricevar , int intsalestype , DateTime dateins )
        {
            try
            {

                SprGetUOMRelationByPriceTableAdapter adpCo = new SprGetUOMRelationByPriceTableAdapter();
                return adpCo.GetData(itemid, intcustid, intpricevar, intsalestype, dateins);
            }
            catch { return new DataTable(); }
        }

        public string DoCreate(string xmlString, ref string entryid, int enroll, int unit, DateTime date1, DateTime date2, int custtype, int Customerid, int shopid, string narration, string addresss, int territoryid, int charge1, bool islog, int charge2, int charge3, int incentiveId1, int incentiveId2, int currencyId, decimal conversionRate, int salestype, decimal totalamount, string extCause, string note, string contatcAt, string contactPhone, int intSalesOffId, int depotid, bool ysnDelivaryOrder, bool ysnsdv, ref string code)
        {
            string msg = "";
            long? id = null;

            try
            {
                SprSalesOrderTableAdapter adpdo = new SprSalesOrderTableAdapter();
                adpdo.GetData(xmlString, ref id, enroll, unit, date1, date2, custtype, Customerid,
                    shopid, narration, addresss, territoryid, charge1, islog, charge2, charge3, incentiveId1, incentiveId2, currencyId, conversionRate, salestype, totalamount, extCause, note
                            , contatcAt, contactPhone, intSalesOffId, depotid, ysnDelivaryOrder, ysnsdv, ref code);
                msg = "Successfully";
            }
            catch (Exception e) { msg = e.ToString(); }

            return msg;

        }


        public string DoCreateFromQuotaion(string xmlString, ref string entryid, int enroll, int unit, DateTime date1, DateTime date2, int custtype, int Customerid, int shopid, string narration, string addresss, int territoryid, int charge1, bool islog, int charge2, int charge3, int incentiveId1, int incentiveId2, int currencyId, decimal conversionRate, int salestype, decimal totalamount, string extCause, string note, string contatcAt, string contactPhone, int intSalesOffId, int depotid, bool ysnDelivaryOrder, bool ysnsdv, ref string code)
        {
            string msg = "";
            long? id = null;

            try
            {
                SprSalesOrderFromQuotationTableAdapter adpdo = new SprSalesOrderFromQuotationTableAdapter();
                adpdo.GetDataSalesOrderFromQuotation(xmlString, ref id, enroll, unit, date1, date2, custtype, Customerid,
                    shopid, narration, addresss, territoryid, charge1, islog, charge2, charge3, incentiveId1, incentiveId2, currencyId, conversionRate, salestype, totalamount, extCause, note
                            , contatcAt, contactPhone, intSalesOffId, depotid, ysnDelivaryOrder, ysnsdv, ref code);
                msg = "Successfully";
            }
            catch (Exception e) { msg = e.ToString(); }

            return msg;

        }


        public string QuotationEditNSave(string xmlString,   int enroll, int unit, int entryid,ref string code)
        {
            string msg = "";
            long? id = null;

            try
            {
                SprSalesQutationEditNSaveTableAdapter adpdo = new SprSalesQutationEditNSaveTableAdapter();
                adpdo.GetDataSalesQutationEditNSave(xmlString, enroll, unit, entryid,ref code);
                msg = "Updated Succesfully";
            }
            catch (Exception e) { msg = e.ToString(); }

            return msg;

        }




        public DataTable getcustomerinformations(int custid)
        {
            try
            {
                SprGetCustomerInfoForQuatationTableAdapter adpCoA = new SprGetCustomerInfoForQuatationTableAdapter();
                return adpCoA.GetDataGetCustomerInfoForQuatation(custid);
            }
            catch { return new DataTable(); }
        }

        public void getDoCompleteComplete(int enroll, string code, int unit)
        {

            try
            {
                TblSalesOrderUpdateTableAdapter adp = new TblSalesOrderUpdateTableAdapter();
                adp.GetData(enroll, code, unit);
            }
            catch { }
        }

        public DataTable getUnitVsLocalSalesType (int unitid)
        {
            try
            {
                SprUnitVsLocalSalesTypeTableAdapter adp = new SprUnitVsLocalSalesTypeTableAdapter();
                return adp.GetDataUnitVsLocalSalesType(unitid);
             
            }
            catch(Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetFGItemvsInvItem(int fgitmid)
        {
            try
            {
                SprInvItemNSADitemTableAdapter adp = new SprInvItemNSADitemTableAdapter();
                return adp.GetDataInvItemNSADitem(fgitmid);

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }


    }  
}
