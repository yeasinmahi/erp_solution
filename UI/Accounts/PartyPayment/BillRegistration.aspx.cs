using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using UI.ClassFiles;
using QRCoder;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;

namespace UI.Accounts.PartyPayment
{
    public partial class BillRegistration : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string Code = "dfs";
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewQRCode();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewQRCode('" + strDate + "','" + strTodate + "','" + hdUnit + "','" + enrol + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewQRCode('" + Code + "');", true);
        }








    }
}