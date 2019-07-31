using SAD_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Customer
{
    public partial class AfblEmployeeSearch : System.Web.UI.Page
    {
        #region Initialize
        SalesOffice objSalesOffice = new SalesOffice();

        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownData();
            }
        }

        #endregion

        #region Method
        private void FillDropDownData()
        {
            DataTable dtEnroll = new DataTable();
            dtEnroll = objSalesOffice.GetAfblEmployeeEnroll();

            if (dtEnroll != null && dtEnroll.Rows.Count > 0)
            {
                ddlEnroll.DataSource = dtEnroll;
                ddlEnroll.DataTextField = "strEmployeeID";
                ddlEnroll.DataValueField = "intEmployeeID";
                ddlEnroll.DataBind();
            }
            ddlEnroll.Items.Insert(0, new ListItem("--- Select ---", "-1"));
        }


        #endregion
    }
}