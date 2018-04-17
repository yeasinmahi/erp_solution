using SAD_BLL.Corporate_sales;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnFTYView : Page
    {
        DataTable dt, dtgridview = new DataTable(); Bridge obj = new Bridge();
        Button btn; int intEnroll, rollid; Boolean ysn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnenroll.Value= Session[SessionParams.USER_ID].ToString();
            }
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            intEnroll = int.Parse(hdnenroll.Value);
            try
            {
             dt = Bridge.GetProceedPermission(intEnroll);
             ysn = Boolean.Parse(dt.Rows[0]["bitysnproceed"].ToString());
            }
            catch
            {
              ysn = false;
            }
            dtgridview = Bridge.GetDataForViewByFty();
            dgvrptrtnfty.DataSource = dtgridview;
            dgvrptrtnfty.DataBind();
            if ( ysn == true)  { dgvrptrtnfty.Columns[4].Visible = true; }
            else { dgvrptrtnfty.Columns[4].Visible = false; }

        }
        protected void Select_Click(object sender, EventArgs e)
        {
            try
            {
                btn = (Button)sender;
                string[] CommandArgument = btn.CommandArgument.Split(',');
                HttpContext.Current.Session["CustId"]= CommandArgument[0];
                HttpContext.Current.Session["ChallanNo"] = CommandArgument[1];
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('CorpReturnFTYUpdate.aspx');", true);
            }
            catch { }
        }

      


























    }
}