using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using HR_BLL.Visitors;
using Microsoft.Reporting.WebForms;
using System.Data;
using UI.ClassFiles;


namespace UI.HR.Visitors
{
    public partial class MeetingMinutesPrint : BasePage
    {
        MeetingMiniutesReport report = new MeetingMiniutesReport();
        DataTable dt = new DataTable();
        DataTable decissions = new DataTable();
        DataTable nextmeeting = new DataTable();
        DataTable agenda = new DataTable();
        DataTable attend = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                Int32 datadt = Convert.ToInt32(Session["intid"].ToString());
                string sesdata = datadt.ToString();
                
                Int32 data = Convert.ToInt32(sesdata.ToString());
                //Int32 intenroll = int.Parse("32897".ToString());

               




                
                dt = report.MeetingReport(data);


                TxtMinuts.Text = dt.Rows[0]["strMeetTitle"].ToString();
                TxtMetInfo.Text = dt.Rows[0]["strMeetInfo"].ToString();
                TxtObjective.Text = dt.Rows[0]["strObjective"].ToString();
                txtDte.Text = Convert.ToDateTime(dt.Rows[0]["dteDate"].ToString()).ToString("dd/MM/yyyy"); 
               

                //TxtTime.Text = dt.Rows[0]["dtetime"].ToString();
                TxtLocation.Text = dt.Rows[0]["strLocation"].ToString();
                TxtStartTime.Text = dt.Rows[0]["dteMeetStrtTime"].ToString();
                TxtEndTime.Text = dt.Rows[0]["dteMeetEndTime"].ToString();

                TxtCalled.Text = dt.Rows[0]["strCalledby"].ToString();
                TxtReffNo.Text = dt.Rows[0]["strReffNo"].ToString();




                


                attend = report.personattenddata(data);
                dgv.DataSource = dt;
                dgv.DataSource = dt;
                dgv.DataBind();

                agenda = report.agendadreport(data);
                dgv2.DataSource = agenda;
                dgv2.DataBind();

                decissions = report.decissiondatareportget(data);

                dgv3.DataSource = decissions;
                dgv3.DataBind();

                nextmeeting = report.nextmeetingschedule(data);

                dgv4.DataSource = nextmeeting;
                dgv4.DataBind();

            }

        }




    }
}