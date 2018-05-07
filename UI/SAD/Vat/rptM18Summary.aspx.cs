using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;

namespace UI.SAD.Vat
{
    public partial class rptM18Summary : BasePage
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
            if (txtdtefdate.Text != "")
            {
                dtedate = DateTime.Parse(txtdtefdate.Text);
                dt = objMush.getM18Summary(int.Parse(hdnAccno.Value), dtedate.Month, dtedate.Year);
                if (dt.Rows.Count > 0)
                {
                    lblOpsB.Text = dt.Rows[0]["monTotal"].ToString();
                    lblTDSD.Text = dt.Rows[2]["monAmount"].ToString();
                    lblTDVAT.Text = dt.Rows[3]["monAmount"].ToString();
                    lblTDSur.Text = dt.Rows[4]["monAmount"].ToString();
                    lblTDTotal.Text = dt.Rows[5]["monTotal"].ToString();
                    lblTFA.Text = dt.Rows[6]["monTotal"].ToString();
                    lblLP.Text = dt.Rows[8]["SubAmount"].ToString();
                    lblLPurAmt.Text = dt.Rows[8]["monAmount"].ToString();
                    lblELocalPur.Text = dt.Rows[9]["SubAmount"].ToString();
                    lblImport.Text = dt.Rows[10]["SubAmount"].ToString();
                    lblImportAmt.Text = dt.Rows[10]["monAmount"].ToString();
                    lblOthersReb.Text = dt.Rows[11]["SubAmount"].ToString();
                    lblTotalRebate.Text = dt.Rows[12]["monTotal"].ToString();
                    lblTotalBalane.Text = dt.Rows[13]["monTotal"].ToString();
                    lblSDAdj.Text = dt.Rows[15]["monAmount"].ToString();
                    lblVatAdj.Text = dt.Rows[16]["monAmount"].ToString();
                    lblSurAdj.Text = dt.Rows[17]["monAmount"].ToString();
                    lblTotalAdj.Text = dt.Rows[18]["monTotal"].ToString();
                    lblNetPayable.Text = dt.Rows[19]["monTotal"].ToString();
                    lblLS.Text = dt.Rows[21]["SubAmount"].ToString();
                    lblSDPay.Text = dt.Rows[21]["monAmount"].ToString();
                    lblES.Text = dt.Rows[22]["SubAmount"].ToString();
                    lblVatPay.Text = dt.Rows[23]["monAmount"].ToString();
                    lblExmS.Text = dt.Rows[24]["SubAmount"].ToString();
                    lblSurPay.Text = dt.Rows[25]["monAmount"].ToString();
                    lblTotalPay.Text = dt.Rows[26]["monTotal"].ToString();
                    lblClosing.Text = dt.Rows[27]["monTotal"].ToString();
                }
            }
        }     
    }
}