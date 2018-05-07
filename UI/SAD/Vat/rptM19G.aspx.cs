using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;
using UI.ClassFiles;

namespace UI.SAD.Vat
{
    public partial class rptM19G : System.Web.UI.Page
    {
        DataTable dt;
        DateTime dtedate;
        char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (txtfdate.Text != "")
            {
                dtedate = DateTime.Parse(txtfdate.Text);
                dt = objMush.getM19Summary(int.Parse(hdnAccno.Value), dtedate);
                if (dt.Rows.Count > 0)
                {
                    lblSellingValue.Text = dt.Rows[0]["monamount1"].ToString();
                    lblTDSD.Text = dt.Rows[0]["monamount2"].ToString();
                    lblSDVAT.Text = dt.Rows[0]["monAmount3"].ToString();
                    lblTDSD.Text = dt.Rows[2]["monamount1"].ToString();
                    lblSDVAT.Text = dt.Rows[4]["monamount1"].ToString();
                    lblOthersPayRow.Text = dt.Rows[5]["monamount1"].ToString();
                    lblTotalPayable.Text = dt.Rows[6]["monamount1"].ToString();
                    lblLocalPurchaseValue.Text = dt.Rows[9]["monamount2"].ToString();
                    lblLocalTaxRebit.Text = dt.Rows[9]["monamount3"].ToString();
                    lblImportTableValue.Text = dt.Rows[10]["monamount2"].ToString();
                    lblImporttaxRebit.Text = dt.Rows[10]["monamount3"].ToString();
                    lblOtherTaxRebit.Text = dt.Rows[11]["monamount3"].ToString();
                    lblPurExam.Text = dt.Rows[12]["monamount2"].ToString();
                    lblRowTotal789.Text = dt.Rows[15]["monamount3"].ToString();
                    lblOthersRowtotal.Text = dt.Rows[16]["monamount3"].ToString();
                    lblBalancePrev.Text = dt.Rows[17]["monamount3"].ToString();
                    lblTotalRebit111213.Text = dt.Rows[18]["monamount3"].ToString();
                    lblFinalNetPayable.Text = dt.Rows[21]["monamount3"].ToString();
                    lblFinalSD.Text = dt.Rows[22]["monamount1"].ToString();
                    lblFinalVat.Text = dt.Rows[22]["monamount2"].ToString();
                    lblTreasury.Text = dt.Rows[22]["monamount3"].ToString();
                    lblOpeningBalanceFinal.Text = dt.Rows[23]["monamount3"].ToString();
                    lblDEDO.Text = dt.Rows[24]["monamount3"].ToString();
                    lblTotalVAT.Text = dt.Rows[27]["monamount3"].ToString();

                }
            }
        }

        protected void btnprepare_Click(object sender, EventArgs e)
        {

        }
    }
}