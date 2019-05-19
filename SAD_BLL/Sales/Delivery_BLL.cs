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
                return new DataTable();
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
                return new DataTable();
            }

        }
    }
}
