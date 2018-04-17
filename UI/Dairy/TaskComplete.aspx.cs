using Dairy_BLL;
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
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

namespace UI.Dairy
{
    public partial class TaskComplete : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intID;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();
                    GetPropostMarks(); 

                }
                catch { }
            }
        }

        private void GetPropostMarks() 
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            dt = new DataTable();
            dt = objtask.GetPropostMarks(intID);
            if (dt.Rows.Count > 0)
            {
                txtPropostM.Text = dt.Rows[0]["intPropostMarks"].ToString();                 
            }
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    int intMarks = int.Parse(txtAppMarks.Text);
                    if (intMarks > 100)
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Approved Marks.');", true); return; }

                    //Final Insert
                    string message = objtask.UpdateTaskComplete(intMarks, intID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                    ////LoadGrid();
                }
                catch { }
            }
        }









    }
}