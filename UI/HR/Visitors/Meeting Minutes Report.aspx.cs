using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HR_BLL.Visitors;
using UI.ClassFiles;

namespace UI.HR.Visitors
{

    public partial class Meeting_Minutes_Report : BasePage
    {
         MeetingMiniutesReport metinforeport=new  MeetingMiniutesReport();
         DataTable dtmeeting = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                //Int32 intenroll = int.Parse("32897".ToString());
                pnlUpperControl.DataBind();
               
            }




           

        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
           
            //Int32 intunitid = Convert.ToInt32("16".ToString());

            //Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            ////Int32 intenroll = int.Parse("32897".ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());


            DateTime dtefo = DateTime.Parse(txtDtefo.Text);
            DateTime dteto = DateTime.Parse(txtDteto.Text);
            dtmeeting = metinforeport.metinformation(dtefo, dteto,intunitid);
            GridView1.DataSource = dtmeeting;
            GridView1.DataBind();
        }

        protected void BtnDetalis_Click(object sender, EventArgs e)
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
                    Session["intid"] = ordernumber1;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('MeetingMinutesPrint.aspx');", true);
                }
                catch { }

            }

        }

       

       
    }
}