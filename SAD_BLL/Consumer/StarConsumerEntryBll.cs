using System;
using System.Data;
using SAD_DAL.Consumer.StarConsumeEntryTableAdapters;

namespace SAD_BLL.Consumer
{
    public class StarConsumerEntryBll
    {
        public DataTable GetTeritory(string email)
        {
            tblItemPriceManagerTableAdapter adapter = new tblItemPriceManagerTableAdapter();
            return adapter.GetTeritoryByEmail(email);
        }
        public DataTable GetProgram()
        {
            DataTable1TableAdapter adapter = new DataTable1TableAdapter();
            return adapter.GetProgram();
        }
        public DataTable GetDoubleCashOffer(string teritory, DateTime fromDate, DateTime toDate)
        {
            sprACCLDoubleCashOfferTableAdapter adapter = new sprACCLDoubleCashOfferTableAdapter();
            return adapter.GetDoubleCashOffer(teritory, fromDate, toDate, fromDate, toDate);
        }
    }
}
