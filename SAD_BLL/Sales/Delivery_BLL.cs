using SAD_DAL.Delivery.Delivery_TDSTableAdapters;
using SAD_DAL.Sales.SearchSales_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.Sales
{
  public  class Delivery_BLL
    {
        string msg = "";
        public DataTable DeliveryHeaderDataByCustomer(string CustId,string shipmentId,bool complete)
        {
            try
            {
                QryDOProfileTableAdapter adp = new QryDOProfileTableAdapter();
                return adp.GetDoProfileByCustomer(int.Parse(CustId), int.Parse(shipmentId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public DataTable DeliveryHeaderDataByDo(string doId, string ShipmentId,bool complete)
        {
            try
            {
                QryDOProfileTableAdapter adp = new QryDOProfileTableAdapter();
                return adp.GetDoProfileByDo(int.Parse(doId), int.Parse(ShipmentId));
            }
            catch (Exception ex)
            {
                 throw ex;
            }

        }

        public DataTable FgWarehouseLocation(int WH)
        {
            try
            {
                FGLocationDataTableAdapter adp = new FGLocationDataTableAdapter();
                return adp.GetFGLocation(WH);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable WareHouseByShipPoint(int intShipPointId)
        {
            try
            {
                ShipPointWHTableAdapter adp = new ShipPointWHTableAdapter();
                return adp.GetWhByShipPoint(intShipPointId);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public DataTable InvenotoryStockByItem(int productId,int promItemId, string wh)
        { 
            try
            {
                InventoryFgItemBlanceTableAdapter adp = new InventoryFgItemBlanceTableAdapter();
                return adp.GetInventoryItemBlance(productId, promItemId, int.Parse(wh));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable CustomerInfo(string custId)
        {
            try
            {
                CustomerInfoTableAdapter adp = new CustomerInfoTableAdapter();
                return adp.GetCustomerInformationData(int.Parse(custId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PaymentsTerms(string unitId)
        {
            try
            {
                TblPaymentTermsTableAdapter adp = new TblPaymentTermsTableAdapter();
                return adp.GetPaymentTermsData(int.Parse(unitId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PickingSummary(string pickingId)
        {
            try
            {
                qryPickingSummaryTableAdapter adp = new qryPickingSummaryTableAdapter();
                return adp.GetPickingSummaryData(int.Parse(pickingId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ShipToPartyAddress(string customerId)
        {
            try
            {
                QryShipToPartyTableAdapter adp = new QryShipToPartyTableAdapter();
                return adp.GetShipToPartyAddressData(int.Parse(customerId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable OrderType()
        {
            try
            {
                TblOrderTypeTableAdapter adp = new TblOrderTypeTableAdapter();
                return adp.GetSalesOrderType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable DoItemDetalis(string doid)
        {
            try
            {
                QryDoItemDetalisTableAdapter adp = new QryDoItemDetalisTableAdapter();
                return adp.GetDoItemDetalisData(int.Parse(doid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PickingDetalis(string pickingId)
        {
            try
            {
                QryPickingDetalisTableAdapter adp = new QryPickingDetalisTableAdapter();
                return adp.GetPickingDetalisData(int.Parse(pickingId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetWhAddress(string whid)
        {
            try
            {
                TblWearHouseTableAdapter adp = new TblWearHouseTableAdapter();
                return adp.GetWhareHouseData(int.Parse(whid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DeliveryOrderItemPriceByDo(int doId, int item)
        {
            try
            {
                qryDOPendingPriceByItemTableAdapter adp = new qryDOPendingPriceByItemTableAdapter();
                return adp.GetDoItemPriceByDo(doId,item );
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      
        public string DeliveryOrderCreate(string xmlHeader,string xmlRow,ref  string strOrderId, ref string strCode)
        {
            try
            {
               
                SprDOCreateTableAdapter adp = new SprDOCreateTableAdapter();
                adp.DeliveryOrderCreate(xmlRow, xmlHeader, ref strOrderId, ref strCode); 
                msg = "Submitted Successfully";
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public string UpdateDeliveryOrder (string xmlHeader, string xmlRow,int DoId)
        {
            try
            {
                   SprDOUpdateTableAdapter adp = new SprDOUpdateTableAdapter();
                adp.DOUpdate(xmlRow, xmlHeader, DoId);
                msg = "Update Successfully";
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetDiscount(string customerId, string ProductId,string quantity,string price)
        {
            try
            {
                FunGetItemDiscountTableAdapter adp = new FunGetItemDiscountTableAdapter();
                return adp.GetDiscountData(int.Parse(customerId), int.Parse(ProductId), DateTime.Now.ToString(),decimal.Parse(quantity), decimal.Parse(price));
            }
            catch
            {
                return new DataTable();
            }


        }

       

        public string InventoryCheck(string xml, ref string strMsg)
        {
            try
            {
                SprPickingStockCheckTableAdapter adp = new SprPickingStockCheckTableAdapter();
                adp.GetInvnetoryCheck(xml, ref strMsg);
                msg = "Delivery Successfully";
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string DeliveryEntry(string pickingId,ref string strCode)
        {
            try
            { 
                SprDeliverysEntryTableAdapter adp = new SprDeliverysEntryTableAdapter();
                adp.DeliveryEntry(pickingId,ref strCode);
                msg = "Delivery Successfully";
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        public string PickingUpdate(string xmlHeader, string xmlRow, int pickingId)
        {
            try
            {
                 

                SprPickingUpdateTableAdapter adp = new SprPickingUpdateTableAdapter();
                adp.UpdatePicking(xmlRow, xmlHeader, pickingId);
                msg = "Picking Update Successfully";
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string PickingCreate(string xmlHeader, string xmlRow,string customerAddress, ref string orderId, ref string strCode)
        {
            
            try
            {
               
                SprPickingCreateTableAdapter adp = new SprPickingCreateTableAdapter();
                adp.PickingInsertData( xmlRow, xmlHeader,customerAddress, ref strCode);
                msg = "Submitted Successfully";
                return msg;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
