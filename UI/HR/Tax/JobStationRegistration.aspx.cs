using HR_BLL.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Tax
{
    public partial class JobStationRegistration : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); 
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    AbsentReport rpt = new AbsentReport();
                    int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int unit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    string station = txtStationName.Text;
                    string address = txtAddress.Text;
                    string latitudeY = txtYCoordinate.Value;
                    string longitudeX = txtXcoordinate.Value;
                    //rpt.JobstationRegistration(unit, station, address, latitudeY, longitudeX, usrid);
                    txtAddress.Text = ""; txtStationName.Text = ""; txtYCoordinate.Value = "";
                }
                catch
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry for this request.');", true); }
            }
        }
    }
}