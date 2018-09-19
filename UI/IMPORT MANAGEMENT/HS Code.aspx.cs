using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.IMPORT_MANAGEMENT
{
    public partial class HS_Code : BasePage
    {
        InventoryTransfer_BLL objBll = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strHSCode, strDescription, strUnit,msg;
            decimal CD, RD, SD, VAT, AIT, ATV, PSI, TTI, EXD;
            DataTable dt = new DataTable();
            strHSCode = txtHsCode.Text;
            strDescription = txtDescription.Text;
            strUnit = txtUnit.Text;
            CD = Convert.ToDecimal(txtCD.Text);
            RD = Convert.ToDecimal(txtRD.Text);
            SD = Convert.ToDecimal(txtSD.Text);
            VAT = Convert.ToDecimal(txtVAT.Text);
            AIT = Convert.ToDecimal(txtAIT.Text);
            ATV = Convert.ToDecimal(txtATV.Text);
            PSI = Convert.ToDecimal(txtPSI.Text);
            TTI = Convert.ToDecimal(txtTTI.Text);
            EXD = Convert.ToDecimal(txtEXD.Text);
            dt = objBll.InsertHSCodeData(strHSCode, strDescription, CD, RD, SD, VAT, AIT, ATV, PSI, strUnit, TTI, EXD);
            msg = dt.Rows[0]["strmsg"].ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            ClearControl();
        }

        private void ClearControl()
        {
            txtHsCode.Text = "";
            txtDescription.Text = "";
            txtUnit.Text = "";
            txtCD.Text = "";
            txtRD.Text = "";
            txtSD.Text = "";
            txtVAT.Text = "";
            txtAIT.Text = "";
            txtATV.Text = "";
            txtPSI.Text = "";
            txtTTI.Text = "";
            txtEXD.Text = "";
        }
    }
}