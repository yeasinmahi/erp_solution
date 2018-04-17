using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using LOGIS_BLL;
using SAD_BLL.Sales;
using LOGIS_BLL.Trip;
using UI.ClassFiles;

namespace UI.SAD.Logistic
{
    public partial class UpdateTrip : BasePage
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
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            hdnVehicle.Value = "";
            if (txtVehicle.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtVehicle.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                if (temp.Length <= 1) hdnVehicle.Value = "";
                else
                {
                    try
                    {
                        int i = int.Parse(temp[temp.Length - 1]);
                        hdnVehicle.Value = i.ToString();

                        Trip tr = new Trip();
                        txtDo.Text = tr.GetDOCodeByVehicle(hdnVehicle.Value);
                    }
                    catch
                    {
                        hdnVehicle.Value = "";
                    }
                }
            }
        }
        protected void lnkChk_Click(object sender, EventArgs e)
        {
            SalesOrder so = new SalesOrder();
            imgChk.Visible = true;
            string customer = "", cusId = "";

            long? doNo = so.ExistsDO(txtDo.Text, ddlShip.SelectedValue, ddlUnit.SelectedValue, ref customer, ref cusId);
            if (doNo != null)
            {
                hdnDo.Value = doNo.Value.ToString();
                imgChk.ImageUrl = "../../Images/yes.jpg";
            }
            else
            {
                hdnDo.Value = "";
                imgChk.ImageUrl = "../../Images/no.png";
            }
        }

        protected void btnDo_Click(object sender, EventArgs e)
        {
            if (hdnVehicle.Value != "" && hdnDo.Value != "")
            {
                Trip tr = new Trip();
                tr.UpdateTripDO(hdnVehicle.Value, hdnDo.Value, txtDo.Text.Trim(), Session[SessionParams.USER_ID].ToString());

                Reset();
            }
        }
        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (hdnVehicle.Value != "" && txtReg.Text.Trim() != "")
            {
                Vehicle vhl = new Vehicle();
                vhl.ModifyVhlRegNo(hdnVehicle.Value, txtReg.Text.Trim(), Session[SessionParams.USER_ID].ToString());

                VehicleSt.ReloadVehicle(ddlUnit.SelectedValue);

                Reset();
            }
        }

        private void Reset()
        {
            txtVehicle.Text = "";
            txtDo.Text = "";
            txtReg.Text = "";
            hdnDo.Value = "";
            hdnVehicle.Value = "";
        }
    }
}