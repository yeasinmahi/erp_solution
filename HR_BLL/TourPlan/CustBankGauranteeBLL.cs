using HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.TourPlan
{
    public class CustBankGauranteeBLL
    {
        public DataTable GetCustInfo(int customerId)
        {
            TblCustomerInfoTableAdapter adp = new TblCustomerInfoTableAdapter();
            return adp.GetCustomerInfo(customerId);
        }
        public DataTable InsertCustomerBankGauranteeXml(string xml)
        {
           
                insertCustomerBankGauranteeXmlDataTableAdapter adp = new insertCustomerBankGauranteeXmlDataTableAdapter();
                return adp.InsertCustomerBankGauranteeXmlData(xml);

        }

        public DataTable getCustomerBankGauranteeList(DateTime dteFromDate,DateTime dteToDate)
        {
            CustomerBankGauranteeListTableAdapter adp = new CustomerBankGauranteeListTableAdapter();
            return adp.GetCustomerBankGauranteeList(dteFromDate, dteToDate);
        }
    }
}
