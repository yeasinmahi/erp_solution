using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class ReceiveReport : BasePage
    {
        int intWHID, intEnroll; DataTable dt; FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        string strFrom, strTo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                    dt = objRec.DataView(1, "", 0, 0, DateTime.Now, intEnroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();

                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                strFrom = txtFrom.Text.ToString();
                strTo = txtTo.Text.ToString();

                dt = new DataTable();
                dt = bll.GetReceiveReport(intWHID, strFrom, strTo);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }
        protected decimal mrrtvalue = 0;
        protected decimal salesvalue = 0;
        protected void dgvReceive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    mrrtvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblMRRValue")).Text);
                    salesvalue += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblSalesValue")).Text);
                }
            }
            catch { }
        }
    }
}