using GLOBAL_BLL;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UI.ClassFiles;
namespace UI.Accounts.MDSlip
{
    public partial class MDSlipRequest : BasePage
    {
       
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Session["sesUserID"] = "1";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "Generate MD Slip";
            }
            else
            {
                Label1.Text = "regenerate";
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string dateString = Calendar1.SelectedDate.Day + "/" + Calendar1.SelectedDate.Month + "/" + Calendar1.SelectedDate.Year;
            txtFrom.Text = dateString;
            GridView1.DataBind();
            Calendar1.Visible = false;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }
    }
}
