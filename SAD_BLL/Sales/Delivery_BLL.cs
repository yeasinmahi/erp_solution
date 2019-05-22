﻿using SAD_DAL.Delivery.Delivery_TDSTableAdapters;
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
        public DataTable DeliveryHeaderDataByCustomer(string intCustId,string intUnitId)
        {
            try
            {
                QryDOProfileTableAdapter adp = new QryDOProfileTableAdapter();
                return adp.GetDoProfileByCustomer(int.Parse(intCustId), int.Parse(intUnitId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public DataTable DeliveryHeaderDataByDo(string intDo, string intUnitId)
        {
            try
            {
                QryDOProfileTableAdapter adp = new QryDOProfileTableAdapter();
                return adp.GetDoProfileByDo(int.Parse(intDo), int.Parse(intUnitId));
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
        public DataTable InvenotoryStockByItem(string FgId,string wh)
        { 
            try
            {
                InventoryFgItemBlanceTableAdapter adp = new InventoryFgItemBlanceTableAdapter();
                return adp.GetInventoryItemBlance(int.Parse(FgId), int.Parse(wh));
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
      
        public string DeliveryOrderCreate(string xmlHeader,string xmlRow,ref  string orderId, ref string strCode)
        {
            try
            {
                long? orderNo = null;
                SprDOCreateTableAdapter adp = new SprDOCreateTableAdapter();
                adp.DeliveryOrderCreate(xmlRow, xmlHeader, ref orderNo, ref strCode);
                orderId = orderNo.ToString();
                msg = "Submitted Successfully";
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
