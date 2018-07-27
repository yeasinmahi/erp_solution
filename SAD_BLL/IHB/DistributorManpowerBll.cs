
using System;
using System.Data;
using SAD_DAL.IHB.DistributorManpowerTableAdapters;

namespace SAD_BLL.IHB
{
    public class DistributorManpowerBll
    {
        public DataTable GetDistributorManpowerInfo(DateTime fromDate, DateTime toDate)
        {
            DataTable1TableAdapter adapter = new DataTable1TableAdapter();
            return adapter.GetDistributorManpowerInfo(fromDate, toDate);
        }
        public DataTable UpdateCustomerInfo(string distributorManager, string salesRepresentative1, string salesRepresentative2, int updateBy, DateTime updateDate, int customerId)
        {
            DataTable2TableAdapter adapter = new DataTable2TableAdapter();
            return adapter.UpdateCustomerInfo(distributorManager, salesRepresentative1, salesRepresentative2, updateBy,updateDate, customerId);
        }

        public DataTable GetAllDistributor()
        {
            tblCustomerTableAdapter adapter = new tblCustomerTableAdapter();
            return adapter.GetAllDistributor();
        }

        public string InsertCustomerIntoDistributorManpower(string xml, int insertBy, int unitId, DateTime fromDate, DateTime toDate)
        {
            string message= String.Empty;
            sprDistributorManpowerInfoTableAdapter adapter = new sprDistributorManpowerInfoTableAdapter();
            adapter.InsertCustomerIntoDistributorManpower(xml, insertBy, unitId, insertBy, fromDate, toDate, ref message);
            return message;
        }
    }
}
