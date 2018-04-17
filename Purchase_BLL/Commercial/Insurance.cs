using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Purchase_DAL.Commercial;
using Purchase_DAL.Commercial.InsuranceTDSTableAdapters;
using System.Data;
using System.Web.UI.WebControls;

namespace Purchase_BLL.Commercial
{
    public class Insurance
    {

        public Table GetCalculatedInsuraceData(int shipmentID,decimal exRate,int lcID,ref decimal? discountRate,ref decimal insAmount)
        {
            //FunCommercialPaymentInsuranceTableAdapter adp = new FunCommercialPaymentInsuranceTableAdapter();
            SprCommercialGetInsuranceCalInfoTableAdapter adp = new SprCommercialGetInsuranceCalInfoTableAdapter();
            InsuranceTDS.SprCommercialGetInsuranceCalInfoDataTable tbl = adp.GetDataInsurancePayment(shipmentID, exRate, lcID, null, ref discountRate);

            Table insTbl = new Table();
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

            insTbl.Width = Unit.Percentage(60);
            insTbl.CellPadding = 0;
            insTbl.CellSpacing = 0;

            insTbl.Controls.Add(htr);

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
                td2.Text = tbl[i].intPayAttributeName;
                td3.Text = tbl[i].monAmount.ToString();
                if (tbl[i].strShortName == "PRE")
                {
                    insAmount = tbl[i].monAmount;
                }

                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                insTbl.Controls.Add(tr);


            }

            return insTbl;
            
        }

        public ListItemCollection GetInsComList()
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialInsuranceCompanyInfoTableAdapter adp = new TblCommercialInsuranceCompanyInfoTableAdapter();
            InsuranceTDS.TblCommercialInsuranceCompanyInfoDataTable tbl=adp.GetData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strCompanyName, tbl[i].intInsuranceCompanyID.ToString()));
            }

            return col;
        }

    }
}
