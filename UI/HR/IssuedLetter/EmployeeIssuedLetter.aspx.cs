using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.IssuedLetter
{
    public partial class EmployeeIssuedLetter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("PRINTPREVIEW"))
            {
                string value = (e.CommandArgument).ToString();
                string[] data = value.Split(',');
                string intLetterId = data[1]; string intEmployeeId = data[0];
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Focus", "window.open('EmployeeIssuedLetterView.aspx?intEmployeeID="
               + data[0].ToString() + "&intLetterId=" + data[1].ToString() + "',null,'')", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "PopupZone(" + data[0] + "," + data[1] + ");", true);
            }
        }

        public string ReturnFrmdate(object intEmployeeID, object intLetterId)
        {
            string str = "";
            str = intEmployeeID.ToString() + ',' + intLetterId.ToString();
            return str;
        }


    }
}