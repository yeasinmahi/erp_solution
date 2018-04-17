using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.ShippingTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class Shipping
    {
        public Table GetShippingDueCalculationData(int lcID, int shipmentID,decimal exRate,DateTime arrivalDate,DateTime clearingDate,string opXML,int deliveryID)
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

            FunCommercialPaymentShippingDueTableAdapter adp = new FunCommercialPaymentShippingDueTableAdapter();
            ShippingTDS.FunCommercialPaymentShippingDueDataTable tbl = adp.GetShipmentDueData(lcID, shipmentID, exRate, arrivalDate, clearingDate, opXML, deliveryID);

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

        public ListItemCollection GetShippingLineInfo()
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialShippingLineInfoTableAdapter adp = new TblCommercialShippingLineInfoTableAdapter();
            ShippingTDS.TblCommercialShippingLineInfoDataTable tbl = adp.GetShippingLineData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strShipingLine, tbl[i].intShpingLineID.ToString()));
            }
            return col;
        }


        public string InsertShippingDues(int lcID, int shipmentID, DateTime arrivingDate, DateTime paymentdate, bool ysnPaid, decimal exRate,DateTime clearingdate,string opXML,int deliveyID)
        {
            string result="";
            SprCommercialCalShippingDuesTableAdapter adp = new SprCommercialCalShippingDuesTableAdapter();
            try
            {
                adp.InsertShippingDueData(lcID, shipmentID, exRate, paymentdate, ysnPaid, arrivingDate, clearingdate, opXML, deliveyID);
                result = "Successfully Inserted";
            }
            catch
            {
                result = "Cannot Successfully Inserted";
            }


            return result;

        }


        public ListItemCollection GetOptionalShippingChargesList()
        {
            ListItemCollection col = new ListItemCollection();

            FunCommercialShippingOptionalChargesTableAdapter adp = new FunCommercialShippingOptionalChargesTableAdapter();
            ShippingTDS.FunCommercialShippingOptionalChargesDataTable tbl = adp.GetData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strName, tbl[i].intPaymentAttID.ToString()));
            }

            return col;
        }

        public ListItemCollection GetContainerDeliveyList(int shipmentID)
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialPortContainerDeliveryTableAdapter adp = new TblCommercialPortContainerDeliveryTableAdapter();
            ShippingTDS.TblCommercialPortContainerDeliveryDataTable tbl = adp.GetDataDeliveryContainerByShipment(shipmentID);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strDeliveryCode, tbl[i].intDeliveryID.ToString()));
            }

            return col;


        }

        public static string GetContainerByDelivery(int shipmentID, int deliveryID)
        {
            StringBuilder sbl = new StringBuilder();
            TblCommercialPortContainerDeliveyDetailsTableAdapter adp = new TblCommercialPortContainerDeliveyDetailsTableAdapter();
            ShippingTDS.TblCommercialPortContainerDeliveyDetailsDataTable tbl = adp.GetDataDeliveredContainer(shipmentID, deliveryID);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                sbl.Append(tbl[i].strContainerID.ToString() + ",");
            }

            return sbl.ToString();
        }

    }
}
