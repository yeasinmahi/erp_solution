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
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer;
using UI.ClassFiles;

namespace UI.SAD.SADCOA
{
    public partial class CusManageForCOA : BasePage
    {
        string userID;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\SADCOA\\CusManageForCOA";
        string stop = "stopping SAD\\SADCOA\\CusManageForCOA";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            userID = "" + Session[SessionParams.USER_ID];
            string id = "" + Request.QueryString["id"];
            if (id != null && id != "")
            {
                hdnParent.Value = id;

            }

        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cusTypeIndex"] = "" + ddlCusType.SelectedIndex;
            hdnCusType.Value = ddlCusType.SelectedValue;
            hdnParent.Value = "";
            GridSub.DataBind();

        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cusUnitIndex"] = "" + ddlUnit.SelectedIndex;
            hdnUnit.Value = ddlUnit.SelectedValue;
            hdnParent.Value = "";
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            string index = "" + Session["cusUnitIndex"];
            if (index != "" && index != null)
            {
                ddlUnit.SelectedIndex = int.Parse(index);

            }

            hdnUnit.Value = ddlUnit.SelectedValue;
            Session["cusUnitIndex"] = "" + ddlUnit.SelectedIndex;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            string index = "" + Session["cusTypeIndex"];
            if (index != "" && index != null)
            {

                ddlCusType.SelectedIndex = int.Parse(index);

            }
            hdnCusType.Value = ddlCusType.SelectedValue;
            Session["cusTypeIndex"] = "" + ddlCusType.SelectedIndex;
            GridSub.DataBind();
        }

        public string GetData(string ID, string name)
        {
            string hypaerString;
            hypaerString = "<a href=\"CusManageForCOA.aspx?id=";
            hypaerString = hypaerString + ID;
            //hypaerString = hypaerString + "&dataGrid=";
            //hypaerString = hypaerString + gridNum;
            //hypaerString = hypaerString + "&accName=";
            //hypaerString = hypaerString + accountName;
            //hypaerString = hypaerString + "&module=";
            //hypaerString = hypaerString + (moduleID == "" ? "false" : "true");
            //hypaerString = hypaerString + "&enable=";
            //hypaerString = hypaerString + ysnEnable;//(ysnEnable == "true" ? "1" : "0");
            hypaerString = hypaerString + "\"";
            hypaerString = hypaerString + ">";
            hypaerString = hypaerString + name;
            hypaerString = hypaerString + "</a>";
            return hypaerString;
        }

        protected void add_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\SADCOA\\CusManageForCOA Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int cusType = int.Parse(ddlCusType.SelectedValue);
            int unit = int.Parse(ddlUnit.SelectedValue);

            int pID;

            if (hdnParent.Value == "")
            {
                pID = 0;
            }
            else
            {
                pID = int.Parse(hdnParent.Value);
            }

            SAD_BLL.Customer.CusManageForCOA cusToCoa = new SAD_BLL.Customer.CusManageForCOA();

            bool ysnAdd = cusToCoa.CustomerManagementForCOAInsert(cusType, pID, unit, txtName.Text, userID);
            GridSub.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}
