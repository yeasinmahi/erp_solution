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

        public string InsertStarConsumerBill(string xml, DateTime fromDate, DateTime toDate, int insertBy,
            int intProgramType, int unitId, int insertBy2)
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

        public DataTable UpdateConsumerBill(int intSiteCardCode, decimal decQntForSiteCard, decimal decShopvsDelvQnt,
            decimal monEditedTotalCost, int intId)
        {
            DataTable3TableAdapter adapter = new DataTable3TableAdapter();
            return adapter.UpdateConsumerBill(intSiteCardCode, decQntForSiteCard, decShopvsDelvQnt, monEditedTotalCost,
                intId);
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


        public DataTable GetFactorySubsidiary(DateTime dteFormDate, DateTime dteToDate, int strSalesoffice,
            decimal factoryRate, decimal ghatRate)
        {
            sprACCLFactorySubsidiaryTableAdapter adapter = new sprACCLFactorySubsidiaryTableAdapter();
            return adapter.GetFactorySubsidiary(dteFormDate, dteToDate, strSalesoffice, factoryRate, ghatRate);
        }

        public DataTable GetTransportSubsidiary(DateTime dteFormDate, DateTime dteToDate, int strSalesoffice)
        {
            sprACCLSubsidiarytrnsportTableAdapter adapter = new sprACCLSubsidiarytrnsportTableAdapter();
            return adapter.GetTransportSubsidiary(dteFormDate, dteToDate, strSalesoffice);
        }

        public string InsertGhat(string shippointname, int intenrol, string strAddress, string strContactperson,
            string strContactNo, int intunit)
        {
            string message = String.Empty;
            sprNewShippingpointopenTableAdapter adapter = new sprNewShippingpointopenTableAdapter();
            adapter.InsertGhat(shippointname, intenrol, strAddress, strContactperson, strContactNo, intunit,
                ref message);
            return message;
        }

        public DataTable GetGhatInfo(int intId)
        {
            tblShippingPointTableAdapter adapter = new tblShippingPointTableAdapter();
            return adapter.GetGhatInfo(intId);
        }

        public DataTable GetTrading(DateTime dteFormDate, DateTime dteTodate, decimal monFamilySaving,
            decimal monTradepromo)
        {
            sprACCLAllTradingHouseTableAdapter adapter = new sprACCLAllTradingHouseTableAdapter();
            return adapter.GetTrading(dteFormDate, dteTodate, monFamilySaving, monTradepromo);
        }

        public DataTable GetDistributorYearlyAch(DateTime dteFormDate, DateTime dteTodate, decimal monCommisionRate,
            string reportType)
        {
            sprACCLDistributorYearlyachTableAdapter adapter = new sprACCLDistributorYearlyachTableAdapter();
            return adapter.GetDistributorYearlyAch(dteFormDate, dteTodate, monCommisionRate, reportType);
        }

        public DataTable GetExclusiveRetailer(DateTime dteFormDate, DateTime dteTodate, decimal monCommisionRate,
            string reportType)
        {
            sprACCLDistributorYearlyachTableAdapter adapter = new sprACCLDistributorYearlyachTableAdapter();
            return adapter.GetDistributorYearlyAch(dteFormDate, dteTodate, monCommisionRate, reportType);
        }

        public DataTable GetExlusiveRetailer(DateTime dteFormDate, DateTime dteTodate, decimal monCommisionRate,
            string reportType)
        {
            sprACCLExclusiveRetaillComTableAdapter adapter = new sprACCLExclusiveRetaillComTableAdapter();
            return adapter.GetExlusiveRetailer(dteFormDate, dteTodate, monCommisionRate, reportType);
        }

        public DataTable GetExclusiveDistributor(DateTime dteFormDate, DateTime dteTodate, decimal monCommisionRate)
        {
            sprACCLExclusiveDistributroCommTableAdapter adapter = new sprACCLExclusiveDistributroCommTableAdapter();
            return adapter.GetExclusiveDistributor(dteFormDate, dteTodate, monCommisionRate);
        }

        public DataTable GetDitributorCoverage(DateTime dteFormDate, DateTime dteTodate, int minimumCoverg,
            double commissionrate, string reportname)
        {
            sprACCLDistributorCoverageCommissionTableAdapter adapter =
                new sprACCLDistributorCoverageCommissionTableAdapter();
            return adapter.GetDitributorCoverage(dteFormDate, dteTodate, minimumCoverg, commissionrate, reportname);
        }

        public DataTable GetManpowerManager(DateTime dteFormDate, DateTime dteTodate)
        {
            sprACCCustmManpowerOnlyManagerTableAdapter adapter = new sprACCCustmManpowerOnlyManagerTableAdapter();
            return adapter.GetManpowerManager(dteFormDate, dteTodate);
        }

        public DataTable GetDistributorManpowerCommission(DateTime dteFormDate, DateTime dteTodate, int reportType)
        {
            sprACCLDistributorManpowerCommissionTableAdapter adapter =
                new sprACCLDistributorManpowerCommissionTableAdapter();
            return adapter.GetDistributorManpowerCommission(dteFormDate, dteTodate, reportType);
        }

        public DataTable GetDistributorAndIhbSales(DateTime dteFormDate, DateTime dteTodate)
        {
            sprACCLDistributorandIHBSalesTableAdapter adapter = new sprACCLDistributorandIHBSalesTableAdapter();
            return adapter.GetDistributorAndIhbSales(dteFormDate, dteTodate);
        }

        public DataTable GetBoostupCom(DateTime dteFormDate, DateTime dteTodate)
        {
            sprACCLBoostupCommissionReportTableAdapter adapter = new sprACCLBoostupCommissionReportTableAdapter();
            return adapter.GetBoostupCom(dteFormDate, dteTodate);
        }

        public DataTable GetCashOrRetailCom(DateTime dteFormDate, DateTime dteTodate, int monCreditLimit)
        {
            sprACCLCashBoostupCommissionTableAdapter adapter = new sprACCLCashBoostupCommissionTableAdapter();
            return adapter.GetCashOrRetail(dteFormDate, dteTodate, monCreditLimit);
        }

        public DataTable GetAllJvWithCostCenterId(string programName, DateTime dteFormDate, DateTime dteTodate,
            string areaName)
        {
            sprACCLAllJVWithCostecenteridTableAdapter adapter = new sprACCLAllJVWithCostecenteridTableAdapter();
            return adapter.GetAllJvWithCostCenterId(programName, dteFormDate, dteTodate, areaName);
        }

        public DataTable GetArea()
        {
            DataTable8TableAdapter adapter = new DataTable8TableAdapter();
            return adapter.GetArea();
        }
        public DataTable FoodBiilingInfo(int type,int actionby,string xml,DateTime fromDate,DateTime toDate,int unitId,int insertBy)
        {
            sprFoodingBillDetTableAdapter adapter = new sprFoodingBillDetTableAdapter();
            return adapter.FoodBiilingInfo(type, actionby, xml, fromDate, toDate, unitId, insertBy);
        }
    }
}
