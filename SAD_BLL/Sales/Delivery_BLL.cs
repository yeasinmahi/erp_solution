using SAD_DAL.Delivery.Delivery_TDSTableAdapters;
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
        public DataTable DeliveryHeaderDataByCustomer(int intCustId,int intUnitId)
        {
            try
            {
                QryDOProfileTableAdapter adp = new QryDOProfileTableAdapter();
                return adp.GetDoProfileByCustomer(intCustId, intUnitId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public DataTable DeliveryHeaderDataByDo(int intDo, int intUnitId)
        {
            try
            {
                QryDOProfileTableAdapter adp = new QryDOProfileTableAdapter();
                return adp.GetDoProfileByDo(intDo, intUnitId);
            }
            catch (Exception ex)
            {
                 throw ex;
            }

        }

        public DataTable FgWarehouseLocation(int jobstation)
        {
            try
            {
                FGLocationDataTableAdapter adp = new FGLocationDataTableAdapter();
                return adp.fgLOCATIONData(jobstation);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeliveryOrderCreate(string xmlHeader,string xmlRow,ref  string orderId, ref string strCode)
        {
            try
            {
                long? orderNo = null;
                SprDOCreateTableAdapter adp = new SprDOCreateTableAdapter();
                adp.DeliveryOrderCreate(xmlRow, xmlHeader, ref orderNo, ref strCode);
                orderId = orderNo.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
