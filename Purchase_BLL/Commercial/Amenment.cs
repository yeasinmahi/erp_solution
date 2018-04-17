using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Drawing;
using Purchase_DAL.Commercial.AmenmentTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
    public class Amenment
    {

        public Table GetAmenmantData(int lcID,  decimal? presentPIAmount, decimal exrate,DateTime? exDate,decimal? newTollerce)
        {
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
            //TableCell td3 = null;

            FunCommercialPaymentAmenmentTableAdapter adp = new FunCommercialPaymentAmenmentTableAdapter();
            AmenmentTDS.FunCommercialPaymentAmenmentDataTable tblData = adp.GetAmenmentData(lcID, presentPIAmount, exrate, exDate, newTollerce);

            for (int i = 0; i < tblData.Rows.Count; i++)
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
                td2.Text = tblData[i].attName;
                tr.Controls.Add(td2);
                td3.Text = string.Format("{0:F2}", tblData[i].monAmount);
                tr.Controls.Add(td3);

                tbl.Controls.Add(tr);

            }

            return tbl;
        }

        public string InsertAmenment(int intLCID, decimal? presentPIAmount,  decimal exrate, bool ysnPaid,DateTime paymentDate,DateTime? exDate,decimal? newTollerence)
        {
            string result = "";
            SprCommercialCalAmenmentTableAdapter adp = new SprCommercialCalAmenmentTableAdapter();
            try
            {
                adp.InsertPaymentData(intLCID, presentPIAmount, exrate, paymentDate, ysnPaid, exDate, newTollerence);
                result = "Inserted SUccessfully";
            }
            catch
            {
                result = "Cannot Inserted Amenment";
            }
            return result;
        }
	

    }
}
