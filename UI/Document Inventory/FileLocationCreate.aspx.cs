using LOGIS_BLL.GLOBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Document_Inventory
{
    public partial class FileLocationCreate : System.Web.UI.Page
    {
        FileLocationBLL locationbll = new FileLocationBLL();
        string locationtype, LocationName, msg;
        int enroll, Locationid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LocationName = txtLocationName.Text.ToString();
            Locationid =int.Parse(ddllocationtype.SelectedValue.ToString());
            enroll = 1355;
            if (Locationid == 1)
            {

                msg = locationbll.getinsertLocationofFile(LocationName, Locationid, enroll);
            }
            else
            {
                msg = locationbll.getinsertLocationofFileName(LocationName, Locationid, enroll);
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);


            txtLocationName.Text = "";

        }
    }
}