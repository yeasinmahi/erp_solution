using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.LcTDSTableAdapters;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.BankTDSTableAdapters;
using System.Data;
using Purchase_DAL.Commercial.InsertionTDSTableAdapters;
using System.Drawing;

namespace Purchase_BLL.Commercial
{
    public class Lc
    {
        public static BankTDS.FunCommercialGetBankAccountForLCDataTable tblbnkAccount = null;
        
       public ListItemCollection GetLcNumberForDropDown()
        {
            ListItemCollection listCol=new ListItemCollection();
            SprCommercialGetLCListTableAdapter adp=new SprCommercialGetLCListTableAdapter();
            LcTDS.SprCommercialGetLCListDataTable tbl=adp.GetLCData();
             listCol.Add(new ListItem("----","0"));
            for(int i=0; i<tbl.Rows.Count;i++)

            {
                listCol.Add(new ListItem(tbl[i].strLCNumber,tbl[i].intLCID.ToString()));
            }

            return listCol;
        }

        public void GetPaymentModeInfoByLC(int LcID,ref decimal? invoiceValue, ref string paymentMode, ref string currency,ref int? numDays,ref int? frequency,ref int? totalIns)
        {
            SprCommercialGetPaymenTypeInfoTableAdapter adp = new SprCommercialGetPaymenTypeInfoTableAdapter();
            adp.GetDatapaymentMode(LcID,ref invoiceValue,ref paymentMode,ref currency,ref numDays,ref frequency,ref totalIns);
        }


        public LcTDS.QryCommercialLCDetailWithItemDataTable GetLCItemList(int lcID)
        {
            QryCommercialLCDetailWithItemTableAdapter adp = new QryCommercialLCDetailWithItemTableAdapter();
            return adp.GetItemDataByID(lcID);
        }

        public ListItemCollection GetPoCollection()
        {
            ListItemCollection poColl = new ListItemCollection();
            TblCommercialLCTableAdapter adp = new TblCommercialLCTableAdapter();
            LcTDS.TblCommercialLCDataTable tbl = adp.GetPoData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                poColl.Add(new ListItem(tbl[i].strPOCode,tbl[i].intLCID.ToString()));
            }

            return poColl;

        }

        public ListItemCollection GetBankAccountInfoForLC()
        {
            ListItemCollection accColl = new ListItemCollection();
            QryBankAccountinfoTableAdapter adp = new QryBankAccountinfoTableAdapter();
            BankTDS.QryBankAccountinfoDataTable tbl = adp.GetBankData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                accColl.Add(new ListItem(tbl[i].strDisplayName, tbl[i].intAccountID.ToString()));
            }

            return accColl;
        }


        // Add by Himadri 
        private static void Inatialize(int lcID)
        {
            if (tblbnkAccount == null)
            {


               // QryBankAccountinfoTableAdapter adp = new QryBankAccountinfoTableAdapter();
                FunCommercialGetBankAccountForLCTableAdapter adp = new FunCommercialGetBankAccountForLCTableAdapter();
                tblbnkAccount = adp.GetBankDataByUnit(lcID);
            }
        }


        // Add By Himadri For Sataic Class
        public static string[] GetCommercialGetBankAccListForAutoList(string prefix)
        {
           // Inatialize();
            string[] retStr = null;
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();
            /*FunCommercialGetBankAccountForLCTableAdapter adp = new FunCommercialGetBankAccountForLCTableAdapter();
            tblbnkAccount = adp.GetBankDataByUnit(lcID);*/
            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblbnkAccount//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.intAccountID
                           select tmp;
                if (rows.Count() > 0)
                {
                    tbl = rows.CopyToDataTable();
                }
            }
            else
            {
                try
                {
                    var rows = from tmp in tblbnkAccount
                               where tmp.strDisplayName.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.intAccountID
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            // prepare the String Array
            if (tbl.Rows.Count > 0)
            {
                retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strDisplayName"] + " [" + tbl.Rows[i]["intAccountID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
            //return retStr;
        }

        public static void InatializeTheBankAccount(int LCID)
        {
            Inatialize(LCID);
        }


        public string InsertLCPIInfo(string itemXML, int intUnitID, string insuranceCoverNoteNum,int intSuplierID,
                                        decimal monTotalPIValue,int intShipmentTypeID,int intCurrencyID,decimal numExRate,
                                        int intUserID,int intPaymentModeID,DateTime dteLCDate,int numDaysForArrival,
                                        string strIndentNumbers,int insuranceAgencyID,int? numDays,int? totalIns,int? frequency,
                                        int bankID, int branchID,string portOfLoading,int distinationPortID,
                                        bool ysnHasTollerence, decimal? tollerence, bool ysnPartialShipment,
                                        DateTime? LastShipment,string termsOFShipmeent,bool ysnPSIApplicable,bool ysnConfirm,ref string code
                                        )
        {

            string result = "";

            SprCommercialPOInsertTableAdapter adp = new SprCommercialPOInsertTableAdapter();
            try
            {
                adp.InsertPOData(itemXML, intUnitID, insuranceCoverNoteNum, intSuplierID, monTotalPIValue,
                                    intShipmentTypeID, intCurrencyID, numExRate, intUserID, intPaymentModeID, dteLCDate, numDaysForArrival, strIndentNumbers, insuranceAgencyID, numDays, totalIns, frequency, ref code,
                                    bankID, branchID, portOfLoading, distinationPortID, ysnHasTollerence,
                                    tollerence, ysnPartialShipment, LastShipment, termsOFShipmeent, ysnPSIApplicable,ysnConfirm);
                result = "successful";
            }
            catch
            {
                result = "not successful";
            }
            return result;

        }


        public string InsertInstallmentSchedule(string xml, int lcID, int shipmentID, decimal exrate)
        {
            string result="";
            SprCommercialInstallmentInsertTableAdapter adp = new SprCommercialInstallmentInsertTableAdapter();

            try
            {
                adp.InsertInstallmentData(xml, exrate, lcID, shipmentID, ref result);
            }
            catch
            {
                result = "Cannot Inserted...";
            }
            return result;
        }


        public LcTDS.SprCommercialGetLCInfoDataTable GetLCDataForEdit(int lcID)
        {
            SprCommercialGetLCInfoTableAdapter adp = new SprCommercialGetLCInfoTableAdapter();
            return adp.GetDataByLC(lcID);
        }

        public LcTDS.SprCommercialGetLCDetailsListDataTable GetLCDetailsData(int lcID)
        {

            SprCommercialGetLCDetailsListTableAdapter adp = new SprCommercialGetLCDetailsListTableAdapter();
            return adp.GetLCDetailData(lcID);
        }

        public Table UpdateLCInfo(
                                   string itemXML,string strLCnumber ,string strItermsOFShipment ,int? intINSComID ,
	                                string strInsCoverNoteNumber ,int? intDistinationPortID ,bool ysPSIEnable ,
	                                DateTime? newExpireDate ,decimal? newTollerence ,decimal? exRateForAmentment ,
	                                DateTime? amentMentDate ,DateTime? dteBudgetDate ,bool ysnInfoChange ,
	                                bool ysnValueChange ,bool ysnPeriodChange ,bool ysnAmendent ,
	                                int intLCID ,int intUserID 
                        
                                )
        
        
        
        {

            SprCommercialPOEditTableAdapter adp = new SprCommercialPOEditTableAdapter();
            LcTDS.SprCommercialPOEditDataTable tblRe= adp.GetDataAmenCharges(itemXML, strLCnumber, strItermsOFShipment, intINSComID,
                                     strInsCoverNoteNumber, intDistinationPortID, ysPSIEnable,
                                     newExpireDate, newTollerence, exRateForAmentment,
                                     amentMentDate, dteBudgetDate, ysnInfoChange,
                                     ysnValueChange, ysnPeriodChange, ysnAmendent,
                                     intLCID, intUserID);


            Table tbl = new Table();
            tbl.Width = Unit.Percentage(100);
            TableRow tr = null;
            TableHeaderRow htr = new TableHeaderRow();
            TableHeaderCell htd1 = new TableHeaderCell();
            htd1.Text = "SL. No";
            TableHeaderCell htd2 = new TableHeaderCell();
            htd2.Text = "Payment Crytaria";
            TableHeaderCell htd3 = new TableHeaderCell();
            htd3.Text = "Amount";
            htr.Controls.Add(htd1);
            htr.Controls.Add(htd2);
            htr.Controls.Add(htd3);
            tbl.Controls.Add(htr);
            //TableCell td = null;
            //TableCell td2 = null;
            htd1.CssClass = "tableInstallmentHeader";
            htd2.CssClass = "tableInstallmentHeader";
            htd3.CssClass = "tableInstallmentHeader";
            tbl.CellPadding = 0;
            tbl.CellSpacing = 0;
            tbl.BorderWidth = 1;

            tbl.BorderColor = Color.Black;
            htr.BorderWidth = 1;
            htr.BorderColor = Color.Black;


            for (int i = 0; i < tblRe.Rows.Count; i++)
            {
                tr = new TableRow();


                TableCell td = new TableCell();
                TableCell td2 = new TableCell();
                TableCell td3 = new TableCell();

                if (i % 2 == 0) //even
                {
                    td.CssClass = "tableInstallmentEvenrows";
                    td2.CssClass = "tableInstallmentEvenrows";
                    td3.CssClass = "tableInstallmentEvenrows";
                }
                else // ODD
                {
                    td.CssClass = "tableInstallmentOddrows";
                    td2.CssClass = "tableInstallmentOddrows";
                    td3.CssClass = "tableInstallmentOddrows";
                }

                td.HorizontalAlign = HorizontalAlign.Center;
                td2.HorizontalAlign = HorizontalAlign.Center;
                td3.HorizontalAlign = HorizontalAlign.Center;

                td.Text = (i + 1).ToString();
                tr.Controls.Add(td);
                td2.Text = tblRe[i].strPaymentAttID;
                tr.Controls.Add(td2);
                td3.Text = string.Format("{0:F2}", tblRe[i].monAmount);
                tr.Controls.Add(td3);

                tbl.Controls.Add(tr);

            }

            return tbl;
        }


    }
}
