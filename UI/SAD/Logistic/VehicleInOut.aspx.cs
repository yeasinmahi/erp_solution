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
using System.Drawing;
using LOGIS_BLL.Supplier;
using UI.ClassFiles;

namespace UI.SAD.Logistic
{
    public partial class VehicleInOut : BasePage
    {
        int unitid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";
                Session["sesCurType"] = rdoVhlCompany.SelectedValue;
                pnlMarque.DataBind();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleOutList(string prefixText, int count)
        {
            return VehicleSt.GetVehicleDataForAutoFillAll(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText, true, null);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleList(string prefixText, int count)
        {
            if (("" + HttpContext.Current.Session["sesCurVhlCom"]).ToLower() == "true" || HttpContext.Current.Session["sesCurVhlCom"] == null)
            {
                if (HttpContext.Current.Session["sesCurType"].ToString() == "c")
                {
                    return VehicleSt.GetVehicleDataForAutoFillCompany(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), "", prefixText, false, null);
                }
                else if (HttpContext.Current.Session["sesCurType"].ToString() == "p")
                {
                    return VehicleSt.GetVehicleDataForAutoFillParty(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), "", prefixText, false, null);
                }
                else
                {
                    return VehicleSt.GetVehicleDataForAutoFillCustomer(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), "", prefixText, false, null);
                }

            }
            else return null;
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierList(string prefixText, int count)
        {
            if (HttpContext.Current.Session["sesCurType"].ToString() == "p")
            {
                return VehicleSupplierST.GetSupplierDataForAutoFillAll(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session["sesCurType"].ToString() == "s")
            {
                return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }

            return null;
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

        protected void rdoVhlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoVhlCompany.SelectedIndex == 0)
            {
                pnlVehicle3rd.Visible = false;
                pnlKM.Visible = true;
            }
            else if (rdoVhlCompany.SelectedIndex == 1)
            {
                pnlVehicle3rd.Visible = true;
                lblSupp.Text = "Supplier";
                pnlKM.Visible = false;
            }
            else
            {
                pnlVehicle3rd.Visible = true;
                lblSupp.Text = "Customer";
                pnlKM.Visible = false;
            }

            Session["sesCurType"] = rdoVhlCompany.SelectedValue;
            btnIn.Visible = false;
            ResetIn();
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
            ResetIn();
        }

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
            ResetIn();
        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            hdnVehicle.Value = "";
            hdnVehicleText.Value = "";
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
                    }
                    catch
                    {
                        hdnVehicle.Value = "";
                    }
                }


                hdnVehicleText.Value = temp[0].Trim();

                if (hdnVehicle.Value != "")
                {
                    Vehicle v = new Vehicle();
                    VehicleTDS.TblVehicleDataTable table = v.GetVehicleById(hdnVehicle.Value);
                    if (table.Rows.Count > 0)
                    {
                        txtDriver.Text = table[0].IsstrDriverNameNull() ? "" : table[0].strDriverName;
                        txtContact.Text = table[0].IsstrDriverContactNull() ? "" : table[0].strDriverContact;

                        txtHelper.Text = table[0].IsstrHelperNameNull() ? "" : table[0].strHelperName;
                        txtkm.Text = table[0].IsnumLastKMReadingNull() ? "" : CommonClass.GetFormettingNumber(table[0].numLastKMReading);
                        txtNid.Text = table[0].IsstrDriverNIDNull() ? "" : table[0].strDriverNID;
                        txtCapacity.Text = table[0].IsnumLoadingCapacityNull() ? "" : CommonClass.GetFormettingNumber(table[0].numLoadingCapacity);
                        if (!table[0].Isint3rdPartyCOAidNull() && rdoVhlCompany.SelectedValue == "p")
                        {
                            txtSupplier.Text = table[0].str3rdPartyName + "[" + table[0].int3rdPartyCOAid + "]";
                            hdnSpCs.Value = table[0].int3rdPartyCOAid.ToString();
                            hdnSpCsText.Value = table[0].str3rdPartyName;
                        }
                        else if (!table[0].IsintForThisCustomerNull() && rdoVhlCompany.SelectedValue == "s")
                        {
                            txtSupplier.Text = table[0].strCustomerName + "[" + table[0].intForThisCustomer + "]";
                            hdnSpCs.Value = table[0].intForThisCustomer.ToString();
                            hdnSpCsText.Value = table[0].strCustomerName;
                        }

                        if (pnlVehicle3rd.Visible && !table[0].IsintTypeIdNull())
                        {
                            for (int i = 0; i < ddlVhlType.Items.Count; i++)
                            {
                                if (ddlVhlType.Items[i].Value == table[0].intTypeId.ToString())
                                {
                                    ddlVhlType.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (hdnVehicle.Value != "")
            {
                btnIn.Visible = true;
                lblCode.Text = "";
            }
            else
            {
                if (rdoVhlCompany.SelectedIndex == 0)
                {
                    btnIn.Visible = false;
                    lblCode.Text = "Invalid Vehicle";
                    ResetIn();
                }
                else
                {
                    btnIn.Visible = true;
                    lblCode.Text = "";
                }
                hdnVehicle.Value = "";
            }
        }

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            SetSupp();
        }
        protected void txtVehicleOut_TextChanged(object sender, EventArgs e)
        {
            SetValueOut();
        }


        protected void btnIn_Click(object sender, EventArgs e)
        {
            Trip tp = new Trip();
            string code = "", error = "";
            string customer = "", cusId="";
            if (int.Parse(ddlUnit.SelectedValue) == 53)
            {
                txtDO.Text = "25410164";
                customer = "M/S. Kalipodo Kundu";
                cusId = "355573";
                txtSupplier.Text = customer + " [" + cusId + "]";
            }



            if (txtDO.Text != "" && hdnDo.Value == "" && txtSupplier.Text != "")
            {
                code = "Please verify DO no";
            }
            else if (rdoVhlCompany.SelectedValue == "c")
            {
                if (hdnVehicle.Value != "")
                {
                    tp.CreateNewTripForOwn(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                        , hdnVehicle.Value, hdnVehicleText.Value, txtDriver.Text, txtContact.Text, ddlShip.SelectedValue
                        , txtkm.Text, txtNid.Text, txtHelper.Text, txtCapacity.Text, ddlUOMWgt.SelectedValue
                        , txtLisence.Text, hdnDo.Value
                        , ref code, ref error);
                }
            }
            else if (rdoVhlCompany.SelectedValue == "p")
            {
                if (hdnSpCs.Value != "")
                {
                    tp.CreateNewTripForParty(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                        , hdnVehicle.Value, hdnVehicleText.Value, ddlVhlType.SelectedValue
                        , txtDriver.Text, txtContact.Text, ddlShip.SelectedValue
                        , hdnSpCs.Value, hdnSpCsText.Value, txtNid.Text, txtHelper.Text, txtCapacity.Text
                        , ddlUOMWgt.SelectedValue, txtLisence.Text, hdnDo.Value
                        , ref code, ref error);
                }
            }
            else
            {
                if (hdnSpCs.Value != "")
                {
                    tp.CreateNewTripForCustomer(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                        , hdnVehicle.Value, hdnVehicleText.Value, ddlVhlType.SelectedValue
                        , txtDriver.Text, txtContact.Text, ddlShip.SelectedValue
                        , hdnSpCs.Value, hdnSpCsText.Value, txtNid.Text, txtHelper.Text, txtCapacity.Text
                        , ddlUOMWgt.SelectedValue, txtLisence.Text, hdnDo.Value
                        , ref code, ref error);
                }
            }

            lblCode.Text = code;
            if (error != "") lblCode.Text = error;

            btnIn.Visible = false;
            ResetIn();
            VehicleSt.ReloadVehicle(ddlUnit.SelectedValue);
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            Trip t = new Trip();
            string error = "";
            string brandissuenumber = txtBrandIssue.Text.ToString();
            if (brandissuenumber.Length < 0) { brandissuenumber = "0"; }
            else { brandissuenumber = txtBrandIssue.Text.ToString(); }
            unitid = int.Parse(ddlUnit.SelectedValue.ToString());

            if (txtTrip.Text.Trim() != "")
            {
               
                
                if (unitid ==90 || unitid == 53) { t.CompleteTripTest(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, txtTrip.Text.Trim(), ddlShip.SelectedValue, brandissuenumber, ref error); }
                else
                { t.CompleteTrip(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, txtTrip.Text.Trim(), ddlShip.SelectedValue, brandissuenumber, ref error);}
                lblError.Text = error;
                VehicleSt.ReloadVehicle(ddlUnit.SelectedValue);
            }

            ResetOut();
        }


        protected void btnGo_Click(object sender, EventArgs e)
        {
            txtVehicleOut.Text = "";
            SetValueOut();
        }

        private void SetSupp()
        {
            if (txtSupplier.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtSupplier.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                if (temp.Length <= 1) hdnSpCs.Value = "";
                else
                {
                    try
                    {
                        hdnSpCs.Value = temp[temp.Length - 1];
                    }
                    catch
                    {
                        hdnSpCs.Value = "";
                    }
                }


                hdnSpCsText.Value = temp[0].Trim();
            }
            else
            {
                hdnSpCs.Value = "";
                hdnSpCsText.Value = "";
            }
        }
        private void SetSupplierParentCOA()
        {
            SalesConfig sc = new SalesConfig();
            Session["sesSupplierParent"] = sc.GetSupplierParentCOAByUnit(Session[SessionParams.CURRENT_UNIT].ToString());
        }
        private void SetValueOut()
        {
            Trip t = new Trip();

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
                if (id != "")
                {
                    txtTrip.Text = t.GetTripCodeByVehicle(id);
                }
                else
                {
                    txtTrip.Text = "";
                }
            }

            if (txtTrip.Text.Trim() == "")
            {
                lblError.Text = "Trip not found";
                btnOut.Visible = false;
                ResetOut();
            }
            else
            {
                btnOut.Visible = true;
                lblError.Text = "";

                string driver = "", healper = "", uom = "", tripId = "";
                decimal? emptyWeight = 0, loadedWeight = 0, goodsWeight = 0, diffarence = 0, tawlarence = 0;
                bool isLoaded = false, isMaintain = false;

                t.GetWeightInfoForWeightBridge(ddlUnit.SelectedValue, ref tripId, txtTrip.Text.Trim(), ref driver, ref healper
                    , ref emptyWeight, ref loadedWeight, ref goodsWeight, ref diffarence, ref tawlarence
                    , ref uom, ref isLoaded, ref isMaintain);



                hdnTrip.Value = tripId;

                if (tripId != "")
                {

                    lblDriver.Text = driver;
                    lblHealper.Text = healper;
                    lblUnLoad.Text = CommonClass.GetFormettingNumber(emptyWeight);
                    lblLoad.Text = CommonClass.GetFormettingNumber(loadedWeight);
                    lblGoods.Text = CommonClass.GetFormettingNumber(goodsWeight);
                    lblDiff.Text = CommonClass.GetFormettingNumber(diffarence);

                    pnlStat.Visible = true;

                    if (((emptyWeight > 0 && loadedWeight > 0) || goodsWeight <= 0) && !isMaintain)
                    {
                        lblError.Text = "Passed";
                        btnOut.Visible = true;
                        imgSignal.ImageUrl = "../../Content/images/img/GreenSignal.jpg";
                    }
                    else
                    {
                        if (isMaintain)
                            lblError.Text = "Please take clearence from maintanance";
                        else if (emptyWeight <= 0 && loadedWeight <= 0 && goodsWeight > 0)
                            lblError.Text = "Not Passed. You have assigned to carry goods.";
                        else if (emptyWeight > 0 && loadedWeight <= 0 && goodsWeight > 0)
                            lblError.Text = "Not Passed. You did not take loaded weight.";
                        else
                            lblError.Text = "Not Passed.";

                        btnOut.Visible = false;
                        imgSignal.ImageUrl = "../../Content/images/img/RedSignal.jpg";
                    }
                }
                else
                {
                    pnlStat.Visible = false;
                    btnOut.Visible = false;
                    lblError.Text = "Trip not found";
                }
            }
        }

        private void ResetIn()
        {
            txtVehicle.Text = "";
            txtSupplier.Text = "";
            txtDriver.Text = "";
            txtContact.Text = "";
            hdnVehicle.Value = "";
            hdnVehicleText.Value = "";
            hdnSpCs.Value = "";
            hdnSpCsText.Value = "";
            txtNid.Text = "";
            txtkm.Text = "";
            txtCapacity.Text = "";
            txtHelper.Text = "";
            imgChk.Visible = false;
            txtDO.Text = "";
            txtLisence.Text = "";
            hdnDo.Value = "";
        }

        private void ResetOut()
        {
            txtVehicleOut.Text = "";
            lblDriver.Text = "";
            lblHealper.Text = "";
            lblError.Text = "";
            pnlStat.Visible = false;
            txtTrip.Text = "";
        }
        protected void lnkChk_Click(object sender, EventArgs e)
        {

            SalesOrder so = new SalesOrder();
            imgChk.Visible = true;
            string customer = "", cusId = "";
            if (int.Parse(ddlUnit.SelectedValue) == 53)
            {
                txtDO.Text = "25410164";
                customer = "M/S. Kalipodo Kundu";
                cusId = "355573";
                txtSupplier.Text = customer + " [" + cusId + "]";
            }
            long? doNo;
            if (int.Parse(ddlUnit.SelectedValue) == 53) { doNo = 25410164; }
            else { doNo = so.ExistsDO(txtDO.Text, ddlShip.SelectedValue, ddlUnit.SelectedValue, ref customer, ref cusId); }

           

          
     

                if (doNo != null)
            {
                hdnDo.Value = doNo.Value.ToString();
                if (rdoVhlCompany.SelectedValue == "s") { txtSupplier.Text = customer + " [" + cusId + "]"; }
                else { txtSupplier.Text = ""; }
                imgChk.ImageUrl = "../../Content/images/img/yes.jpg";
            }
            else
            {
                hdnDo.Value = "";
                imgChk.ImageUrl = "../../Content/images/img/no.png";
                txtDO.Text = "";
            }

            SetSupp();
        }

    }
}