using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LOGIS_BLL.GetInOut;
using UI.ClassFiles;
using System.Xml;
using System.IO;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace UI.GetInOut
{
    public partial class GetpassRecieveDetalis :BasePage
    {

        GetInoutstatus getpass = new GetInoutstatus();
        DataTable dt = new DataTable();
        int Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intRID = Int32.Parse("0".ToString());
                string code =Session["intRTGetInGetPass"].ToString();
                string vehicleno = "0".ToString();
                string driver = "0".ToString();
                Int32 fowardenroll = Int32.Parse("0".ToString());
                Item = 6;
                dt = getpass.UserendgetpassDetalis(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                dgvGetpassDetalis.DataSource = dt;
                dgvGetpassDetalis.DataBind();

            }
        }
    }
}