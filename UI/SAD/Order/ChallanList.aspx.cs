using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using LOGIS_BLL;
using LOGIS_BLL.Trip;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class ChallanList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMarque.DataBind();
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleList(string prefixText, int count)
        {
            return VehicleSt.GetVehicleDataForAutoFillAll(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText, true, false);
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }
        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            if (txtVehicle.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtVehicle.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                if (temp.Length >= 1)
                {
                    hdnVehicle.Value = temp[temp.Length - 1];
                }
                else
                {
                    hdnVehicle.Value = "";
                }
            }
            else
            {
                hdnVehicle.Value = "";
            }

            GridView1.DataBind();
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            hdnTr.Value = txtCode.Text.Trim();
            hdnDo.Value = "";
            GridView1.DataBind();
        }
        protected void btnGoDo_Click(object sender, EventArgs e)
        {
            hdnDo.Value = txtDoCode.Text.Trim();
            hdnTr.Value = "";
            GridView1.DataBind();
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            char[] ch = { '#' };
            string[] temp = ((Button)sender).CommandArgument.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            if (temp.Length >= 1)
            {
                Trip t = new Trip();
                if (temp[1] == "c")
                {
                    t.CompleteTripAssign(temp[0], Session[SessionParams.USER_ID].ToString());
                }
                else if (temp[1] == "r")
                {
                    t.RollbackTripAssign(temp[0], Session[SessionParams.USER_ID].ToString());
                }
            }

            GridView1.DataBind();
        }
        protected string GetEditLink(object ID, object intLoadedWgtBy)
        {
            string str = "Loading Completed";

            switch (("" + intLoadedWgtBy))
            {

                case "":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('ChallanCancel.aspx?id=" + ID + "')\"class=\"link\">Cancel</a>";
                    break;
            }

            return str;
        }
        protected string GetVhlType(object ysnOwn, object int3rdPartyCOAid, object intForThisCustomer)
        {
            string str = "";

            if ((bool)ysnOwn) return "Company";
            else if ("" + int3rdPartyCOAid != "") return "Rented";
            else if ("" + intForThisCustomer != "") return "Customer";

            return str;
        }
        protected string GetPrintLink(object voucherID, object completed)
        {
            string str = "";

            switch (("" + completed).ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('ChallanOneGP.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Details</a>";
                    //str = "";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }

        protected void rdoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnDo.Value = "";
            hdnTr.Value = "";
            txtCode.Text = "";
            txtDoCode.Text = "";
        }
    }
}