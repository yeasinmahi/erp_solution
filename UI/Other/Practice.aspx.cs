using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Other
{
    public partial class Practice : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)(form1.FindControl("ifrm"))).Attributes["src"] = "https://report.akij.net/reports/report/Ruhul/Binti/Employee";
        }
    }
}