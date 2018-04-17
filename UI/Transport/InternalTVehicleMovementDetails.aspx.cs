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
    public partial class InternalTVehicleMovementDetails : BasePage
    {

        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt; DataTable dtn;

        int intID; DateTime dteFDate; DateTime dteTDate; int intShipPointid, intReportType, intWork, intunitid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();
                                        
                    LoadGrid();
                }
                catch
                { }
            }
        }

        private void LoadGrid()
        {
            dteFDate = DateTime.Parse(HttpContext.Current.Session["dteFDate"].ToString());
            dteTDate = DateTime.Parse(HttpContext.Current.Session["dteTDate"].ToString());
            intShipPointid = int.Parse(HttpContext.Current.Session["intShipPointid"].ToString());
            intWork = 3;
            dt = new DataTable();
            dt = obj.GetReportData(intWork, dteFDate, dteTDate, intShipPointid, intID);            
            dgvTripDetails.DataSource = dt;
            dgvTripDetails.DataBind();
        }













    }
}