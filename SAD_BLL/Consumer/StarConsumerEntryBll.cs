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

        public string InsertStarConsumerBill(string xml, DateTime fromDate, DateTime toDate, int insertBy, int intProgramType, int unitId, int insertBy2)
        {
            string message = String.Empty;
            sprStarConsumerBillTableAdapter adapter = new sprStarConsumerBillTableAdapter();
            adapter.InsertConsumerBill(xml, fromDate, toDate, insertBy, intProgramType, unitId, insertBy2, ref message);
            return message;
        }
        public DataTable GetStarConsumeReport(DateTime fromDate, DateTime toDate, string email)
        {
            DataTable2TableAdapter adapter = new DataTable2TableAdapter();
            return adapter.GetStarConsumeReport(fromDate, toDate, email);
        }

        public DataTable UpdateConsumerBill(int intSiteCardCode, decimal decQntForSiteCard, decimal decShopvsDelvQnt, decimal monEditedTotalCost, int intId)
        {
            DataTable3TableAdapter adapter = new DataTable3TableAdapter();
            return adapter.UpdateConsumerBill(intSiteCardCode, decQntForSiteCard, decShopvsDelvQnt, monEditedTotalCost,intId);
        }
        public DataTable DeactiveConsumerDoubleCashOffer(int intId)
        {
            DataTable4TableAdapter adapter = new DataTable4TableAdapter();
            return adapter.DeactiveConsumerDoubleCashOffer(intId);
        }

        public DataTable GetDoTopSheet(DateTime fromDate, DateTime toDate)
        {
            DataTable5TableAdapter adapter = new DataTable5TableAdapter();
            return adapter.GetDoTopSheet(fromDate, toDate);
        }
        public DataTable GetDoBySalesId(int salesOffId, DateTime fromDate, DateTime toDate)
        {
            DataTable6TableAdapter adapter = new DataTable6TableAdapter();
            return adapter.GetDoBySalesId(salesOffId, fromDate, toDate);
        }
        public DataTable GetDoByDoNumber(string doNumber)
        {
            DataTable7TableAdapter adapter = new DataTable7TableAdapter();
            return adapter.GetDoByDoNumber(doNumber);
        }
        public DataTable GetSalesOffice()
        {
            tblSalesOfficeTableAdapter adapter = new tblSalesOfficeTableAdapter();
            return adapter.GetSalesOffice();
        }


        public DataTable GetFactorySubsidiary(DateTime dteFormDate, DateTime dteToDate, int strSalesoffice,decimal factoryRate, decimal ghatRate)
        {
            sprACCLFactorySubsidiaryTableAdapter adapter = new sprACCLFactorySubsidiaryTableAdapter();
            return adapter.GetFactorySubsidiary(dteFormDate, dteToDate, strSalesoffice, factoryRate, ghatRate);
        }
        public DataTable GetTransportSubsidiary(DateTime dteFormDate, DateTime dteToDate, int strSalesoffice)
        {
            sprACCLSubsidiarytrnsportTableAdapter adapter = new sprACCLSubsidiarytrnsportTableAdapter();
            return adapter.GetTransportSubsidiary(dteFormDate, dteToDate, strSalesoffice);
        }

        public string InsertGhat(string shippointname, int intenrol, string strAddress, string strContactperson, string strContactNo, int intunit)
        {
            string message = String.Empty;
            sprNewShippingpointopenTableAdapter adapter = new sprNewShippingpointopenTableAdapter();
            adapter.InsertGhat(shippointname, intenrol, strAddress, strContactperson, strContactNo, intunit, ref message);
            return message;
        }
        public DataTable GetGhatInfo(int intId)
        {
            tblShippingPointTableAdapter adapter = new tblShippingPointTableAdapter();
            return adapter.GetGhatInfo(intId);
        }


    }
}
