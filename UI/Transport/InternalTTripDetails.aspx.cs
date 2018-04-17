using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Transport
{
    public partial class InternalTTripDetails : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt; DataTable dtn; 

        int intID; int intWork;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();

                    dtn = new DataTable();
                    dtn = obj.GetDriverEnrollAndUnitidByTrip(intID);
                    
                    GetTripFareAndToll();
                    LoadGrid();                   
                }
                catch
                { }
            }
        }
        private void GetTripFareAndToll()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
            
            dt = new DataTable();
            dt = obj.GetTripFareAndToll(intID);
            if (dt.Rows.Count > 0)
            {            
                lblTripNo.Text = dt.Rows[0]["TripNo"].ToString();               
                lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                lblVehicleType.Text = dt.Rows[0]["VehicleType"].ToString();                
            }            
        }
        private void LoadGrid()
        { 
            intWork = 2;
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
            dt = new DataTable();
            dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
            dgvTripDetails.DataSource = dt;
            dgvTripDetails.DataBind(); 
        }


    }
}