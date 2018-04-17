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
    public partial class TransferReport : BasePage
    {
        int intWHID, intEnroll, intType, intComplete; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        DateTime dteFromDate, dteToDate; bool ysnComplete;
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
                intType = int.Parse(ddlType.SelectedValue.ToString());
                intComplete = int.Parse(ddlStatus.SelectedValue.ToString());
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dteFromDate = DateTime.Parse(txtFrom.Text);
                dteToDate = DateTime.Parse(txtTo.Text);
                if (intComplete == 1)
                {
                    ysnComplete = false;
                }
                else
                {
                    ysnComplete = true;
                }

                if (intType == 1)
                {
                    dt = bll.GetSales(7, intWHID, dteFromDate, dteToDate, 0, ysnComplete);
                    dgvTransfer.DataSource = dt;
                    dgvTransfer.DataBind();
                }
                else if (intType == 2)
                {
                    dt = bll.GetSales(8, intWHID, dteFromDate, dteToDate, 0, ysnComplete);
                    dgvTransfer.DataSource = dt;
                    dgvTransfer.DataBind();
                }
            }
            catch { }
        }
        protected decimal totalvalue = 0;
        protected void dgvReceive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAmount")).Text);
                }
            }
            catch { }
        }
    }
}