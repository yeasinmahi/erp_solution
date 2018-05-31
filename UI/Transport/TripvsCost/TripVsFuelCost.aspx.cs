using LOGIS_BLL.Trip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Transport.TripvsCost
{
    public partial class TripVsFuelCost : System.Web.UI.Page
    {
        Trip bll = new Trip();
        DataTable dt = new DataTable();
        int unitid, enroll, intTrip, intFuel, intToll, intGrandPrimary, intAddition, intDeduct, intGrandFinal, intInsertBy, intLitterIncreased, intLitterDecreased;
        string tripcode, strVehicle, strDriver, strCustomer, strAddress, strAdditional, strDeduct;
        DateTime dtfomdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //intTrip,strVehicle,dteFromDate,strDriver,strCustomer,strAddress,intFuel ,intToll,intGrandPrimary,strAdditional
            //,intAddition,strDeduct,intDeduct,intGrandFinal,dteUpdateDate,intInsertBy,intLitterIncreased,intLitterDecreased
            //    ,intTypeid


            //tripcode = txtTripCode.Text.ToString();
            //intTrip = int.Parse(tripcode);
            //int mrrNo = int.Parse(hdnMrrNo.Value.ToString());
            
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            TextBox txtAdditional = row.FindControl("txtAdditional") as TextBox;
            TextBox txtDeductional = row.FindControl("txtDeductional") as TextBox;
            TextBox txtfinalcost = row.FindControl("txtfinalcost") as TextBox;
            TextBox txtReson = row.FindControl("txtReson") as TextBox;
            Label lbltripcode = row.FindControl("lbltripcode") as Label;
            Label lblstrRegno = row.FindControl("lblstrRegno") as Label;
            Label lblstrdiver = row.FindControl("lblstrdiver") as Label;
            Label lbldteinsertime = row.FindControl("lbldteinsertime") as Label;
         
            Label lblstrhelper = row.FindControl("lblstrhelper") as Label;
            Label lblstrcustname = row.FindControl("lblstrcustname") as Label;
            Label lblstraddre = row.FindControl("lblstraddre") as Label;
            Label lbldeclitpertrip = row.FindControl("lbldeclitpertrip") as Label;
            Label lblmonpertripcost = row.FindControl("lblmonpertripcost") as Label;
            Label lbldispointid = row.FindControl("lbldispointid") as Label;
            Label lbldecdistance = row.FindControl("lbldecdistance") as Label;
            Label lbldecinitialcost = row.FindControl("lbldecinitialcost") as Label;
           
            string tripcode = lbltripcode.Text.ToString();
            intTrip = Convert.ToInt32(tripcode);
            string strRegno = lblstrRegno.Text.ToString();

            //     dtfomdate = DateTime.ParseExact(lbldteinsertime.Text, "dd-MM-yyyy",
            //System.Globalization.CultureInfo.InvariantCulture);
            dtfomdate = DateTime.Now;
            string strdiver = lblstrdiver.Text.ToString();
            string strhelper = lblstrhelper.Text.ToString();
            string strcustname = lblstrcustname.Text.ToString();
            string straddre = lblstraddre.Text.ToString();
           
            string decinitialcost = lbldecinitialcost.Text.ToString();
            intGrandPrimary = Convert.ToInt32(decinitialcost);
            intFuel = intGrandPrimary;
            intToll = 0;
           
            strAdditional = txtReson.Text.ToString();
            int Additional = int.Parse(txtAdditional.Text.ToString());
            int deductional = int.Parse(txtDeductional.Text.ToString());
            int intGrandFinal = int.Parse(txtfinalcost.Text.ToString());
            string declitpertrip = lbldeclitpertrip.Text.ToString();
            string monpertripcost = lblmonpertripcost.Text.ToString();
            int literrate = Convert.ToInt32(monpertripcost);
            intLitterIncreased = Convert.ToInt32(Additional / literrate);
            intLitterDecreased= Convert.ToInt32(deductional / literrate);
            string dispointid = lbldispointid.Text.ToString();
            string decdistance = lbldecdistance.Text.ToString();
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            string msg =bll.TripvsFuelinsertion(intTrip, strRegno, dtfomdate, strdiver, strcustname, straddre
        , intFuel, intToll, intGrandPrimary, strAdditional, Additional, strAdditional, deductional
        , intGrandFinal, enroll, intLitterIncreased, intLitterDecreased);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);


        }

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                tripcode =txtTripCode.Text.ToString();
                
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                dt = bll.GetTripVsCost(tripcode,unitid);

                dgvTripVSFuelCost.DataSource = dt;
                dgvTripVSFuelCost.DataBind();
            }
            catch { }
        }
    }
}