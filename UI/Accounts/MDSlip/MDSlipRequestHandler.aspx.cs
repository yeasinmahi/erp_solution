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
using BLL.Accounts.MDSlip;
using UI.ClassFiles;
namespace UI.Accounts.MDSlip
{
    public partial class MDSlipRequestHandler : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string requestDateForMDSlip = Request.QueryString["rdate"];
            string unitID = Request.QueryString["unit"];
            string userID = "" + Session[SessionParams.USER_ID];

            MDSlipRequst req = new MDSlipRequst();

            int? waitTimeinSeconds = null;
            req.InsertMDSlipRequest(unitID, userID, requestDateForMDSlip, ref waitTimeinSeconds);
            string jsString = "<script type=\"text/javascript\">";
            jsString = jsString + "parent.ShowStatus(" + waitTimeinSeconds + ")";
            jsString = jsString + "</script>";

            Response.Write(jsString);
        }
    }
}
