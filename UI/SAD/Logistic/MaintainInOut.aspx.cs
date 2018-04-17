using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using LOGIS_BLL;
using BLL.Accounts.ChartOfAccount;
using SAD_BLL.Sales;
using LOGIS_DAL;
using LOGIS_BLL.Trip;
using SAD_BLL.Customer;
using UI.ClassFiles;

namespace UI.SAD.Logistic
{
    public partial class MaintainInOut : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";

                //string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                //txtTrip.Text = "TR-" + pre + "-";
                pnlMarque.DataBind();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleOutList(string prefixText, int count)
        {
            return VehicleSt.GetVehicleDataForAutoFillAll(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText, true, null);
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void txtVehicleOut_TextChanged(object sender, EventArgs e)
        {
            Reset();
            SetValue();
        }
        protected void txtTrip_TextChanged(object sender, EventArgs e)
        {
            SetValue();
        }

        private void SetValue()
        {
            string id = "";
            if (txtVehicleOut.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtVehicleOut.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                if (temp.Length <= 1) id = "";
                else
                {
                    try
                    {
                        int i = int.Parse(temp[temp.Length - 1]);
                        id = i.ToString();
                        hdnVehicle.Value = id;

                        Trip t = new Trip();
                        txtTrip.Text = t.GetTripCodeByVehicle(id);
                    }
                    catch
                    {
                        id = "";
                        hdnVehicle.Value = "";
                        txtTrip.Text = "";
                    }
                }

            }

            if (txtTrip.Text.Trim() == "")
            {
                lblError.Text = "Trip not found";
                hdnIn.Value = "";
                imgSignal.Visible = false;
                btnInOut.Visible = false;
            }
            else if (id != "")
            {
                Vehicle vhl = new Vehicle();
                VehicleTDS.TblVehicleDataTable tbl = vhl.GetVehicleById(id);

                lblDriver.Text = tbl[0].strDriverName;
                lblHealper.Text = tbl[0].strHelperName;

                if (tbl[0].IsysnInMaintananceNull() || !tbl[0].ysnInMaintanance)
                {
                    imgSignal.ImageUrl = "../../Content/images/img/in.png";
                    hdnIn.Value = "false";
                    btnInOut.Text = "Go To Maintain";
                    lblError.Text = "Is this vehicle move to maintainance department?";
                }
                else
                {
                    imgSignal.ImageUrl = "../../Content/images/img/out.png";
                    hdnIn.Value = "true";
                    btnInOut.Text = "Release";
                    lblError.Text = "Is this vehicle fit for running?";
                }

                imgSignal.Visible = true;
                btnInOut.Visible = true;
            }
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
            Reset();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
            Reset();
        }

        private void Reset()
        {
            //string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            //txtTrip.Text = "TR-" + pre + "-";

            hdnIn.Value = "";
            hdnVehicle.Value = "";
            lblDriver.Text = "";
            lblHealper.Text = "";
            lblError.Text = "";
        }

        protected void btnInOut_Click(object sender, EventArgs e)
        {
            Vehicle v = new Vehicle();
            if (hdnIn.Value == "true")
            {
                v.MaintainanceOut(hdnVehicle.Value, Session[SessionParams.USER_ID].ToString());
            }
            else
            {
                v.MaintainanceIn(hdnVehicle.Value, Session[SessionParams.USER_ID].ToString());
            }

            Reset();

            txtVehicleOut.Text = "";
            imgSignal.Visible = false;
            btnInOut.Visible = false;

            VehicleSt.ReloadVehicle(ddlUnit.SelectedValue);
        }

    }
}