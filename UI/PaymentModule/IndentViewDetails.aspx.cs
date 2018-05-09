using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.PaymentModule
{
    public partial class IndentViewDetails : BasePage
    {
        Indents_BLL objIndent = new Indents_BLL(); Billing_BLL objBillApp = new Billing_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh, indentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnBillID.Value = Session["billid"].ToString();
                    int indentID = int.Parse(Request.QueryString["Id"].ToString());                    
                    dt = new DataTable();
                    dt = objBillApp.GetIndentViewDetails(indentID);
                    if (dt.Rows.Count > 0)
                    {
                        lblIndent.Text = indentID.ToString();
                        lbldteDue.Text = DateTime.Parse(dt.Rows[0]["dteDueDate"].ToString()).ToString("yyyy-MM-dd");
                        lbldteIndent.Text = DateTime.Parse(dt.Rows[0]["dteIndentDate"].ToString()).ToString("yyyy-MM-dd");
                        lblType.Text = dt.Rows[0]["strIndentType"].ToString();
                        lblWH.Text = dt.Rows[0]["strDescription"].ToString();
                    }
                    
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objIndent.DataView(14, "", 0, indentID, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                        lblIndentBY.Text = dt.Rows[0]["indentBy"].ToString();
                        lblApproveBy.Text = dt.Rows[0]["ApproveBY"].ToString();
                        string unit = dt.Rows[0]["intUnit"].ToString();
                        imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                    }
                    dgvIndentsDetalis.DataSource = dt;
                    dgvIndentsDetalis.DataBind();
                }
                catch { }
            }
            else
            { }
        }

        protected void btnBillDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + hdnBillID.Value + "');", true);
        }






















    }
}