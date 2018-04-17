using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.PortDueTDSTableAdapters;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.PortContainnerTDSTableAdapters;

namespace Purchase_BLL.Commercial
{
    public class Port
    {

        public Table GetPortDuesForView(int lcID, int shipmentID, DateTime landingDate, DateTime clearingdate,decimal exRate,string opxml,int? storageID,int? ourTruck,int? foreignTruck,decimal? carpenterPer,string csvText)
        {
            Table tblPort = new Table();
            TableHeaderRow htr = new TableHeaderRow();
            TableHeaderCell htd1 = new TableHeaderCell();
            TableHeaderCell htd2 = new TableHeaderCell();
            TableHeaderCell htd3 = new TableHeaderCell();
            htd1.CssClass = "tableInstallmentHeader";
            htd2.CssClass = "tableInstallmentHeader";
            htd3.CssClass = "tableInstallmentHeader";
            htd1.Text = "SL No";
            htd2.Text = "Cost Catagory";
            htd3.Text = "Amount";
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            htr.Controls.Add(htd1);
            htr.Controls.Add(htd2);
            htr.Controls.Add(htd3);

            tblPort.Width = Unit.Percentage(60);
            tblPort.CellPadding = 0;
            tblPort.CellSpacing = 0;

            tblPort.Controls.Add(htr);

            //FunCommercialPaymentPortDueTableAdapter adp = new FunCommercialPaymentPortDueTableAdapter();
            FunCommercialPaymentPortDueMainTableAdapter adp = new FunCommercialPaymentPortDueMainTableAdapter();
            //decimal ex = decimal.Parse("10.70");
            PortDueTDS.FunCommercialPaymentPortDueMainDataTable tbl = adp.GetPortChargeCalcData(lcID, shipmentID, landingDate, clearingdate, exRate, opxml, storageID, ourTruck, foreignTruck, carpenterPer, csvText,null);

            TableRow tr = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                tr = new TableRow();
                TableCell td1 = new TableCell();
                TableCell td2 = new TableCell();
                TableCell td3 = new TableCell();

                if (i % 2 == 0) //even
                {
                    td1.CssClass = "tableInstallmentEvenrows";
                    td2.CssClass = "tableInstallmentEvenrows";
                    td3.CssClass = "tableInstallmentEvenrows";
                }
                else // ODD
                {
                    td1.CssClass = "tableInstallmentOddrows";
                    td2.CssClass = "tableInstallmentOddrows";
                    td3.CssClass = "tableInstallmentOddrows";
                }

                td1.HorizontalAlign = HorizontalAlign.Center;
                td2.HorizontalAlign = HorizontalAlign.Center;
                td3.HorizontalAlign = HorizontalAlign.Center;

                td1.Text = (i + 1).ToString();
                td2.Text = tbl[i].attName.ToString();
                td3.Text = (tbl[i].IsmonAmountNull()) ? "0" : String.Format("{0:F2}", tbl[i].monAmount.ToString());

                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                tblPort.Controls.Add(tr);


            }


            return tblPort;
        }


        public Table GetPortContainerReturnDuesForView(int lcID, int shipmentID, DateTime portINDate,  decimal exRate, decimal demageAmount)
        {
            Table tblPort = new Table();
            TableHeaderRow htr = new TableHeaderRow();
            TableHeaderCell htd1 = new TableHeaderCell();
            TableHeaderCell htd2 = new TableHeaderCell();
            TableHeaderCell htd3 = new TableHeaderCell();
            htd1.CssClass = "tableInstallmentHeader";
            htd2.CssClass = "tableInstallmentHeader";
            htd3.CssClass = "tableInstallmentHeader";
            htd1.Text = "SL No";
            htd2.Text = "Cost Catagory";
            htd3.Text = "Amount";
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            htr.Controls.Add(htd1);
            htr.Controls.Add(htd2);
            htr.Controls.Add(htd3);

            tblPort.Width = Unit.Percentage(60);
            tblPort.CellPadding = 0;
            tblPort.CellSpacing = 0;

            tblPort.Controls.Add(htr);

            FunCommercialPaymentPortContainerReturnTableAdapter adp = new FunCommercialPaymentPortContainerReturnTableAdapter();
            //decimal ex = decimal.Parse("10.70");
            PortDueTDS.FunCommercialPaymentPortContainerReturnDataTable tbl = adp.GetContainerReturnCalData(lcID, shipmentID, portINDate, exRate,demageAmount);

            TableRow tr = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                tr = new TableRow();
                TableCell td1 = new TableCell();
                TableCell td2 = new TableCell();
                TableCell td3 = new TableCell();

                if (i % 2 == 0) //even
                {
                    td1.CssClass = "tableInstallmentEvenrows";
                    td2.CssClass = "tableInstallmentEvenrows";
                    td3.CssClass = "tableInstallmentEvenrows";
                }
                else // ODD
                {
                    td1.CssClass = "tableInstallmentOddrows";
                    td2.CssClass = "tableInstallmentOddrows";
                    td3.CssClass = "tableInstallmentOddrows";
                }

                td1.HorizontalAlign = HorizontalAlign.Center;
                td2.HorizontalAlign = HorizontalAlign.Center;
                td3.HorizontalAlign = HorizontalAlign.Center;

                td1.Text = (i + 1).ToString();
                td2.Text = tbl[i].attName.ToString();
                td3.Text = (tbl[i].IsmonAmountNull()) ? "0" : String.Format("{0:F2}", tbl[i].monAmount.ToString());

                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                tblPort.Controls.Add(tr);


            }


            return tblPort;
        }

        public string InsertPortDuesData(int lcID, int shipmentID, DateTime landingDate, DateTime paymentdate, bool ysnPaid, decimal exRate, DateTime clearingdate, string opXML, int? storageID, int? ourTruck, int? foreignTruck,decimal? carpenterRate,string deliverableCSV)
        {
            string result="";
            SprCommercialCalPortDuesTableAdapter adp = new SprCommercialCalPortDuesTableAdapter();
            try
            {
                adp.InsertPortDues(lcID, shipmentID, exRate, paymentdate, landingDate, ysnPaid, clearingdate, opXML, storageID, ourTruck, foreignTruck, carpenterRate, deliverableCSV);
                result = "Successfully Inserted";
            }
            catch
            {
                result = "Cannot Successfully Inserted";
            }


            return result;

        }

        public string InsertPortContainerReturnCalData(int lcID, int shipmentID, DateTime factoryRDate, DateTime PortInDate,  decimal exRate, decimal demageCharge,DateTime paymentdate)
        {
            string result = "";
            SprCommercialProvitionPortContainerReturnDueTableAdapter adp = new SprCommercialProvitionPortContainerReturnDueTableAdapter();
            try
            {
                adp.InsertCRCProvition(lcID, shipmentID, PortInDate, factoryRDate, paymentdate, exRate, demageCharge);
                result = "Provitioned Successfully";
            }
            catch
            {
                result = "error Occured";
            }

            return result;
        }

        public ListItemCollection GetPort()
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialPortTableAdapter adp = new TblCommercialPortTableAdapter();
            PortDueTDS.TblCommercialPortDataTable tbl = adp.GetPortData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strPortName, tbl[i].intPortID.ToString()));
            }

            return col;
        }

        public ListItemCollection GetPrivatePort()
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialPortTableAdapter adp = new TblCommercialPortTableAdapter();
            PortDueTDS.TblCommercialPortDataTable tbl = adp.GetPrivatePortData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strPortName, tbl[i].intPortID.ToString()));
            }

            return col;
        }

        public ListItemCollection GetOptionalPortChargesList(int intLCID)
        {
            ListItemCollection col = new ListItemCollection();

            FunCommercialPortOptionalChargesTableAdapter adp = new FunCommercialPortOptionalChargesTableAdapter();
            PortDueTDS.FunCommercialPortOptionalChargesDataTable tbl = adp.GetPortOptioalChargeData(intLCID);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strName, tbl[i].intPaymentAttID.ToString()));
            }

            return col;
        }

        public ListItemCollection GetPortStorageType(int lcID)
        {
            FunCommercialGetStorageTypeTableAdapter adp = new FunCommercialGetStorageTypeTableAdapter();
            PortDueTDS.FunCommercialGetStorageTypeDataTable tbl = adp.GetPortStorageDataByLC(lcID);
            ListItemCollection col = new ListItemCollection();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strStorageName, tbl[i].intPortStorageID.ToString()));

            }

            return col;
            
        }


        public static void GetPortDetailsByLC(int lcID, ref string portName, ref string portShortName)
        {
            TblCommercialPortTableAdapter adp = new TblCommercialPortTableAdapter();
            PortDueTDS.TblCommercialPortDataTable tbl = adp.GetPortDataByLC(lcID);
            portName = tbl[0].strPortName;
            portShortName = tbl[0].strShortName;
        }


        public PortContainnerTDS.FunCommercialContainerNumberForArrSetDataTable GetContainerForSetArrDate(int shipmentID)
        {
            FunCommercialContainerNumberForArrSetTableAdapter adp = new FunCommercialContainerNumberForArrSetTableAdapter();
            return adp.GetData(shipmentID);
        }


        public ListItemCollection GetDiliverableContainers(int shipmentID)
        {
            ListItemCollection col = new ListItemCollection();

            TblCommercialShippingContainnersDetailsTableAdapter adp = new TblCommercialShippingContainnersDetailsTableAdapter();
            PortContainnerTDS.TblCommercialShippingContainnersDetailsDataTable tbl = adp.GetDataForDiliveryable(shipmentID);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strContainerNumber, tbl[i].strContainerNumber));
            }

            return col;
        }

        public void InsertArrivanAndLandingDate(int shipmentID, string dateXML)
        {
            SprCommercialContainerArrLandingInsertTableAdapter adp = new SprCommercialContainerArrLandingInsertTableAdapter();
            try
            {
                adp.InsertLandingAndArrivalOFContainerData(shipmentID, dateXML);
            }
            catch
            {

            }
        }

    }
}
