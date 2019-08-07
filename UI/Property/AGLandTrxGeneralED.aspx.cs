using BLL.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Property
{
    public partial class AGLandTrxGeneralED : System.Web.UI.Page
    {
        #region INIT
        private PropertyBLL pbll = new PropertyBLL();
        int PKID, MouzaID, Enroll, UnitID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnGVDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                HiddenField hfLandGeneralPK = row.FindControl("hfLandGeneralPK") as HiddenField;
                HiddenField hfUnitID = row.FindControl("hfUnitID") as HiddenField;
                HiddenField hfMouzaID = row.FindControl("hfMouzaID") as HiddenField;
                HiddenField hfPlotTypeID = row.FindControl("hfPlotTypeID") as HiddenField;
                PKID = int.Parse(hfLandGeneralPK.Value);
                MouzaID = int.Parse(hfMouzaID.Value);
                Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                UnitID = int.Parse(hfUnitID.Value);
                int result = 0;

                if (hdnconfirm.Value.ToString() == "1")
                {
                    result = pbll.UpdateAGExistsLand(Enroll, PKID, UnitID, MouzaID);
                    if(result > 0)
                    {
                        btnDeedDataShow_Click(null, null);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Delete Successfully.');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Delete Failed.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Cancel Deletion.');", true);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnGVEdit_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblgvDeedNo = row.FindControl("lblgvDeedNo") as Label;
                HiddenField hfUnitID = row.FindControl("hfUnitID") as HiddenField;
                HiddenField hfLandGeneralPK = row.FindControl("hfLandGeneralPK") as HiddenField;
                HiddenField hfMouzaID = row.FindControl("hfMouzaID") as HiddenField;
                HiddenField hfPlotTypeID = row.FindControl("hfPlotTypeID") as HiddenField;
                Label lblgvLDTR = row.FindControl("lblgvLDTR") as Label;
                string DeedNo = lblgvDeedNo.Text;
                string UnitID = hfUnitID.Value;
                string PKID = hfLandGeneralPK.Value;
                string MouzaID = hfMouzaID.Value;
                string PlotTypeID = hfPlotTypeID.Value;
                string LDTR = lblgvLDTR.Text;
                ScriptManager.RegisterStartupScript
                    (
                    Page, typeof(Page), 
                    "StartupScript",
                   "Viewdetails('" + DeedNo + "','" + UnitID + "','" + MouzaID + "','" + PlotTypeID + "','" +LDTR + "','" + PKID + "');", 
                   true
                   );
            }
            catch (Exception ex)
            {
                string sms = "Edit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnDeedDataShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int IsDoct = 0;
            try
            {
                DateTime FromDate = !string.IsNullOrEmpty(txtFromDate.Text) ?
                    DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                    DateTime.ParseExact("01/01/1901", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ToDate =!string.IsNullOrEmpty(txtToDate.Text) ?
                    DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                    DateTime.ParseExact("01/01/1901", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string DeedNo = !string.IsNullOrEmpty(txtShowDeedNo.Text) ? txtShowDeedNo.Text : "0";
                IsDoct = chkLDocument.Checked == false ? 1 : 2;

                dt = pbll.GetInsertedLandMainData(FromDate, ToDate, DeedNo, IsDoct);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvDeedDataShow.DataSource = dt;
                    dgvDeedDataShow.DataBind();
                }
                else
                {
                    dgvDeedDataShow.DataSource = null;
                    dgvDeedDataShow.DataBind();
                }
            }
            catch (Exception ex)
            {
                string sms = "Data Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
    }
}