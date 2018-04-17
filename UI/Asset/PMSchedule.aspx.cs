using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class PMSchedule : System.Web.UI.Page
    {
        AssetMaintenance objPMSchedule = new AssetMaintenance();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            string schedule = TxtScheduleName.Text.ToString();
            if (!IsPostBack)
            {
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
               
                intItem = 8;
                if (intItem == 8)
                {
                    Int32 Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = objPMSchedule.PmShecduleshowGridview(intItem, Mnumber);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void BtnIssue_Click(object sender, EventArgs e)
        {
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
               
            string schedule = TxtScheduleName.Text.ToString();
            objPMSchedule.PMScheduleInsertData(schedule,intjobid,intunitid,intenroll);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Schedule  Add');", true);
            intItem = 8;
            if (intItem==8)
            {
                Int32 Mnumber = Int32.Parse("1".ToString());

                dt = objPMSchedule.PmShecduleshowGridview(intItem, Mnumber);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            

        }

        protected void BtnService_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PMScheduleServicePopUp.aspx');", true);
                }
                catch { }
            }
        }
    }
}