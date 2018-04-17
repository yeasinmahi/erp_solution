using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.ProvitionTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Provition
    {

        public ProvitionTDS.SprCommercialProvitionGetDataDataTable GetProvitionByDate(int? unitID,DateTime dteDate,int? lcID)
        {
            SprCommercialProvitionGetDataTableAdapter adp = new SprCommercialProvitionGetDataTableAdapter();
            return adp.GetProvitionData(unitID, dteDate, lcID);
        }

        public ProvitionTDS.SprCommercialProvitionGetDataForConfirmationDataTable GetProvitionForConfirmation()
        {
            SprCommercialProvitionGetDataForConfirmationTableAdapter adp = new SprCommercialProvitionGetDataForConfirmationTableAdapter();
            return adp.GetProvitionDataForCon();
        }

        public string UpdateProvitionConfirmation(int detailsID, int userID)
        {
            string result = "";
            SprCommercialProvitionConfirmedTableAdapter adp = new SprCommercialProvitionConfirmedTableAdapter();
            try
            {
                adp.UpdateProvitionData(detailsID, userID);
                result = "Update Sucessfull";
            }
            catch
            {
                result = "Error Occured";
            }

            return result;

        }

        public string InsertProvotionpayment(int? intStepID , decimal? monAmount , decimal? exRate ,int? intProvitionID ,
	                                         int? intProvitionDetailsID ,int? intLCID ,int? intShipmentID ,DateTime? dtePaymentDate ,
	                                         string strLCnumber ,int? intBankAccountID,bool? ysnOther,DateTime? lcDate,int userID )
        {
            string result = "";

            SprCommercialProvitionPaymentTableAdapter adp = new SprCommercialProvitionPaymentTableAdapter();

            try
            {
                adp.InsertProvitionPaymentData(intStepID, monAmount, exRate, intProvitionID, intProvitionDetailsID, intLCID, intShipmentID, dtePaymentDate, strLCnumber, intBankAccountID,ysnOther,lcDate,userID);
                result = "Sucessfull";
            }
            catch
            {
                result = "Not Successfull";
            }



            return result;
        }

    }
}
