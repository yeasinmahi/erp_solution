using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial.PaymentTDSTableAdapters;
using Purchase_DAL.Commercial.DutyTDSTableAdapters;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial;
//using Purchase_DAL.Commercial.OpeningTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Payment
    {
        public string InsertLCOpeingCost(int lcID,string lcNumber,int? bankAccID, decimal exRate,decimal adCost, DateTime paymentDate, bool ysnOpen,
                                            bool isPaid,int userID
                                        )
        
        {
            string result = "";
           // SprCommercialCalOpeningOfLCTableAdapter adp=new Purchase_DAL.Commercial.PaymentTDSTableAdapters.SprCommercialCalOpeningOfLCTableAdapter
            SprCommercialCalOpeningOfLCTableAdapter adp = new SprCommercialCalOpeningOfLCTableAdapter();
            try
            {

                adp.InsertOpeingData(lcID, lcNumber, bankAccID, adCost, ysnOpen, paymentDate, isPaid, exRate, userID);
                result = "Inserted Successfully";

            }
            catch
            {
                result = "Insertion falied";
            }

            return result;
        }


        public string InsertLcFcCost(string installmentXMl,decimal? upassAmount,int lcID ,int shippingID,
	                                    bool isPaid ,DateTime? paymentDate,decimal? exRate ,bool? ysnHavePG, 
                                        decimal? pgPer, DateTime? pgDate)
        {
            string result = "";
            SprCommercialCalFCPaymentTableAdapter adp = new SprCommercialCalFCPaymentTableAdapter();
            try
            {
                adp.InsertCostOfFCPayment(installmentXMl, upassAmount, lcID, shippingID, isPaid, paymentDate, exRate, ysnHavePG, pgPer, pgDate);
                result = "Isertion Successfull";
            }
            catch
            {
                result = "An erreor has occurd during the insertion";
            }

            return result;

        }


        public string InsertLcInsuranceCost( int lcID,int intShipmentID ,decimal numExchangeRate ,bool isPaid ,DateTime? dtePaymentDate )
        {
            string result = "";

            SprCommercialCalInsuranceTableAdapter adp = new SprCommercialCalInsuranceTableAdapter();
            try
            {
                adp.InsertCostOfInsurance(lcID, intShipmentID, numExchangeRate, isPaid, dtePaymentDate);
                result = "Insuranced Sucessfully";
            }
            catch
            {
                result = "Error occured";
            }

            return result;
        }


        public string InserLcDutyCost(int lcID, int shippingID, DateTime? dtePaymentDate,
                                         decimal exRate, bool ysnPaid)
        {

            string result = "";
            SprCommercialCalDutyTableAdapter adp = new SprCommercialCalDutyTableAdapter();
            try
            {
                adp.GetInsertDutyData(lcID, shippingID, dtePaymentDate, exRate, ysnPaid);
                result = "Duty Information Successfully Added";
            }
            catch
            {
                result = "Duty Insertion Failed";
            }
            return result;

        }


        public ListItemCollection GetPaymentMode()
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialPaymentModeTableAdapter adp = new TblCommercialPaymentModeTableAdapter();

            PaymentTDS.TblCommercialPaymentModeDataTable tbl = adp.GetDataLastLevel();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strModeName, tbl[i].intPaymentModeID.ToString()));
            }



            return col;
        }


    }
}
