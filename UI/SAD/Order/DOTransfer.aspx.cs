using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Sales;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class DOTransfer : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DOTransfer";
        string stop = "stopping SAD\\Order\\DOTransfer";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";
            }
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            ddlShip.DataBind();
        }

        protected void ddlShipOther_DataBound(object sender, EventArgs e)
        {
            if (ddlShipOther.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\DOTransfer Do Transer Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                SAD_BLL.Sales.SalesOrder so = new SAD_BLL.Sales.SalesOrder();
            if (so.ExistsDO(ddlUnit.SelectedValue, ddlShip.SelectedValue, txtDo.Text))
            {
                so.SetDOToAnotherShipPoint(ddlUnit.SelectedValue, ddlShip.SelectedValue, txtDo.Text, ddlShipOther.SelectedValue, Session[SessionParams.USER_ID].ToString());
                lblStatus.Text = "Successfully DO transfered from " + ddlShip.SelectedItem.Text + " To " + ddlShipOther.SelectedItem.Text;
            }
            else
            {
                lblStatus.Text = "DO not exists";
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }


            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}