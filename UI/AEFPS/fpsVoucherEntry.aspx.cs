using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using System.Data;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.Drawing.Printing;
using System.Drawing;

namespace UI.AEFPS
{
    public partial class fpsVoucherEntry : BasePage
    {
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        int intWID, intInsertby;
        DataTable dt;
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtefdate;
        decimal Amount;
        int empid;
        string narration, purpose, msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                pnlUpperControl.DataBind();
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());

                dt = objAEFPS.getWH(intInsertby);
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataSource = dt;
                ddlWH.DataBind();

                ddlWHEntryE.DataTextField = "strName";
                ddlWHEntryE.DataValueField = "Id";
                ddlWHEntryE.DataSource = dt;
                ddlWHEntryE.DataBind();

            }
         

        }     

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtfdate.Text != "") )
            {
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                intWID = int.Parse(ddlWH.SelectedValue);
                narration = (txtNarration.Text);
                purpose = (txtPurpose.Text);
                Amount =decimal.Parse (txtAmount.Text.ToString());
                objAEFPS.GetVoucherEntry( dtefdate, purpose, narration, Amount, intWID, intInsertby);
                txtNarration.Text= "";
                txtPurpose.Text = "";
                txtAmount.Text = "";
                txtfdate.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);
            }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Date !');", true); }
        }
        protected decimal  TotalAmounts = 0;

        protected void btnCVEntry_Click(object sender, EventArgs e)
        {
            if ((txtfdatee.Text != ""))
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtEmployee.Text.Split(delimiterCharss);
                decimal total = Int32.Parse(0.ToString());
                empid = Int32.Parse(arrayKeyItem[1].ToString());

                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                dtefdate = DateTime.Parse(txtfdatee.Text.ToString());
                intWID = int.Parse(ddlWHEntryE.SelectedValue);
                narration = (txtNarrationE.Text);
                purpose = ("Credit");
                Amount = decimal.Parse(txtAmountE.Text.ToString());
                msg=objAEFPS.getCreditEntry(empid, dtefdate, purpose, narration, Amount, intInsertby, intWID);
                txtNarration.Text = "";
                txtPurpose.Text = "";
                txtAmount.Text = "";
                txtfdate.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ msg + "');", true);
            }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Date !');", true); }
        }

 
        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            getResult();
        }

        private void getResult()
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtEmployee.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            empid = Int32.Parse(arrayKeyItem[1].ToString());
            dt = objAEFPS.getEmpinfo(empid);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows.Count > 0)
                {

                    hdnEnroll.Value = (dt.Rows[0]["intEmployeeID"].ToString());
                   
                }
                dt = objAEFPS.getCreditAmountPurches(dt.Rows[0]["intEmployeeID"].ToString());
                txtCreditAmount.Text = dt.Rows[0]["CashReceiveamount"].ToString();
            }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] EmployeeSearch(string prefixText, int count = 0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetEmployeeSearch(prefixText);

        }
    }
}