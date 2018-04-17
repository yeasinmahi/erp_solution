using LOGIS_BLL;
using LOGIS_BLL.Trip;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Logistic
{
    public partial class VehicleWeightCustomize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                //txtTrip.Text = "TR-" + pre + "-";

                if (!IsPostBack)
                {
                    //Session["sesUserID"] = "53";
                    pnlMarque.DataBind();
                }
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
            SetSupplierParentCOA();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            SetSupplierParentCOA();
        }

        private void SetSupplierParentCOA()
        {
            Reset();
            SalesConfig sc = new SalesConfig();
            Session["sesSupplierParent"] = sc.GetSupplierParentCOAByUnit(Session[SessionParams.CURRENT_UNIT].ToString());
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
            Trip t = new Trip();
            //txtWeight.Enabled = false;
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
                    }
                    catch
                    {
                        id = "";
                    }
                }

                txtTrip.Text = t.GetTripCodeByVehicle(id);
            }

            if (txtTrip.Text.Trim() == "")
            {
                lblError.Text = "Trip not found";
            }
            else
            {
                string driver = "", healper = "", uom = "", tripId = "";
                decimal? emptyWeight = 0, loadedWeight = 0, goodsWeight = 0, diffarence = 0, tawlarence = 0;
                bool isLoaded = false, isMaintain = false;

                t.GetWeightInfoForWeightBridge(ddlUnit.SelectedValue, ref tripId, txtTrip.Text.Trim(), ref driver, ref healper
                    , ref emptyWeight, ref loadedWeight, ref goodsWeight, ref diffarence, ref tawlarence
                    , ref uom, ref isLoaded, ref isMaintain);

                if (isMaintain)
                {
                    pnlButton.Visible = false;
                    pnlStat.Visible = false;
                    btnCal.Visible = false;
                    lblStat.Text = "Please take clearence from maintanance";
                }
                else
                {
                    hdnTrip.Value = tripId;

                    lblChallan.Text = "<a href=\"#\" onclick=\"ShowPopUpE('../Order/ChallanOneGPCustomize1.aspx?id=" + tripId + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Challan</a>";
                    //+ "<a href=\"#\" onclick=\"ShowPopUpE('../Vat/Report/Mushok11.aspx?id=" + tripId + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">VAT Challan</a>";
                    lblDriver.Text = driver;
                    lblHealper.Text = healper;


                    if (isLoaded)
                    {
                        pnlStat.Visible = true;
                        btnCal.Visible = true;
                        lblStat.Text = "Loaded";

                        lblUnLoad.Text = CommonClass.GetFormettingNumber(emptyWeight);
                        lblLoad.Text = CommonClass.GetFormettingNumber(loadedWeight);
                        lblGoods.Text = CommonClass.GetFormettingNumber(goodsWeight);
                        lblDiff.Text = CommonClass.GetFormettingNumber(diffarence);


                        pnlButton.Visible = true;
                        decimal tmpDiff = 0;
                        if (t.WeightCalculationForWeightBridge(emptyWeight.Value, loadedWeight.Value, goodsWeight.Value, tawlarence.Value, ref tmpDiff))
                        {
                            imgSignal.Visible = true;
                            imgSignal.ImageUrl = "../../Content/images/img/GreenSignal.jpg";
                            lblRemarks.Text = "";
                        }
                        else
                        {
                            imgSignal.Visible = false;
                        }

                        if (tmpDiff == 0 && goodsWeight != 0)
                        {
                            pnlButton.Visible = true;
                            lblStat.Text = "Loaded";
                        }
                        else
                        {
                            pnlButton.Visible = false;
                            lblStat.Text = "Have completed weight bridge.";
                        }

                        hdnGd.Value = goodsWeight.ToString();
                        hdnLd.Value = loadedWeight.ToString();
                        hdnTw.Value = tawlarence.ToString();
                        hdnUn.Value = emptyWeight.ToString();
                    }
                    else
                    {
                        pnlButton.Visible = true;
                        pnlStat.Visible = false;
                        btnCal.Visible = false;
                        lblStat.Text = "Unloaded";
                    }
                }
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
            //txtVehicleOut.Text = "";        
            //string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            //txtTrip.Text = "TR-" + pre + "-";

            txtWeight.Text = "";
            lblStat.Text = "";
            lblDriver.Text = "";
            lblHealper.Text = "";
            hdnGd.Value = "";
            hdnLd.Value = "";
            hdnTw.Value = "";
            hdnUn.Value = "";
            lblChallan.Text = "";
            lblRemarks.Text = "";
        }

        protected void btnWeight_Click(object sender, EventArgs e)
        {
            if (txtWeight.Text.Trim() != "")
            {
                lblError.Text = "";
                Trip t = new Trip();

                if ("" + hdnUn.Value == "")
                {
                    t.SetEmptyWeight(hdnTrip.Value, Session[SessionParams.USER_ID].ToString(), decimal.Parse(txtWeight.Text.Trim()), ddlUOMWgt.SelectedValue);
                    GridView1.DataBind();
                }
                else
                {
                    t.SetLoadedWeight(hdnTrip.Value, Session[SessionParams.USER_ID].ToString(), decimal.Parse(txtWeight.Text.Trim()));
                }

                txtVehicleOut.Text = "";
                Reset();
                pnlStat.Visible = false;
                pnlButton.Visible = false;
            }
            else
            {
                lblError.Text = "Enter weight";
            }

            //txtWeight.Enabled = false;
        }
        protected void btnCal_Click(object sender, EventArgs e)
        {
            if (txtWeight.Text.Trim() != "")
            {
                lblError.Text = "";
                decimal diffarence = 0;
                Trip t = new Trip();

                bool isOk = t.WeightCalculationForWeightBridge(decimal.Parse(hdnUn.Value), decimal.Parse(txtWeight.Text.Trim()), decimal.Parse(hdnGd.Value)
                    , decimal.Parse(hdnTw.Value), ref diffarence);

                lblDiff.Text = CommonClass.GetFormettingNumber(diffarence);
                lblLoad.Text = txtWeight.Text.Trim();
                imgSignal.Visible = true;

                if (isOk)
                {
                    imgSignal.ImageUrl = "../../Content/images/img/GreenSignal.jpg";
                    lblRemarks.Text = "Weight is in tawlarence level. You can permit this.";
                }
                else
                {
                    imgSignal.ImageUrl = "../../Content/images/img/RedSignal.jpg";
                    lblRemarks.Text = "Need to recheck.";
                }
            }
            else
            {
                lblError.Text = "Enter weight";
            }
        }

        /*protected void btnAxWgt_Click(object sender, EventArgs e)
        {
            if (txtWeight.Text == "")
            {
                txtWeight.Enabled = true;
            }
            else
            {
                txtWeight.Enabled = false;
            }
        }*/

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
    }
}