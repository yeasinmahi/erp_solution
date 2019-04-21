using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Sales
{
    public partial class UnitTest : System.Web.UI.Page
    {
        UnitOOP getobj = new UnitOOP();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string enroll = "1355";
            dt = getobj.GetUnits(enroll);
            ddlunit.DataTextField = "strunit";
            ddlunit.DataValueField = "intUnitID";
            ddlunit.DataSource = dt;
            ddlunit.DataBind();

        }
    }
}