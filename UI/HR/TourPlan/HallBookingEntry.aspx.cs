using HR_BLL.Employee;
using HR_BLL.Reports;
using HR_BLL.TourPlan;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{

   
    public partial class HallBookingEntry : BasePage
    {
        DateTime dtt;
        EmployeeAttendanceReports objEmployeeAttendanceReports = new EmployeeAttendanceReports();
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        TourPlanning bll = new TourPlanning();
        DataTable dt = new DataTable();
        int hallid, unitid, deptid, totalparticipants=0, actionBy, confID;
        public string strinformation = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
                pnlUpperControl.DataBind();
                hdnUserID.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmployeeID.Value = objEmployeeBasicInfo.GetEmployeeIdByUserIdOrEmpcode(int.Parse(hdnUserID.Value.ToString()), null);
                dt = bll.GetdataforConferenceRoomLoadlist();
                ddlLocation.DataTextField = "strConferenceRoomName";
                ddlLocation.DataValueField = "intid";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();
                hallid = int.Parse(ddlLocation.SelectedValue.ToString());
                dt = bll.GetdataforConferenceRoom(2, hallid);
                DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
                lblLevelnumber.Text = dt.Rows[0]["LevelNumber"].ToString();
                lblCapacitytotal.Text = dt.Rows[0]["SeatCapacity"].ToString();
                lblProjector.Text = dt.Rows[0]["Projector"].ToString();
                dt = bll.ConferenceRoomBookingStatus(fromdate, 1);
                string bokst = dt.Rows[0]["strstatis"].ToString();
                if (bokst == "Not Booked") { imgSignal.ImageUrl = "../../Content/images/img/GreenSignal.jpg"; }
                else if (bokst == "booked") { imgSignal.ImageUrl = "../../Content/images/img/RedSignal.jpg"; }
                else { }
                fromdate = DateTime.Parse(txtDteFrom.Text);
                string fromdated = fromdate.ToString("MMMM");
                lblSelectMonth.Text = fromdated.ToString();
               
            }






        }

        protected void txtDteFrom_TextChanged(object sender, EventArgs e)
        {
            DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
            string fromdated = fromdate.ToString("MMMM");
            lblSelectMonth.Text = fromdated.ToString();
           
        }

       

       

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
     
            DateTime fromdate = DateTime.Parse(Calendar1.SelectedDate.ToString());
        }

        #region =====================Submit Action ===================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (hdnconfirm.Value == "1")
            {
                lblCapacitytotal.Text = (float.Parse(lblCapacitytotal.Text).ToString());
                int cpv = int.Parse(lblCapacitytotal.Text);
                int inputval = int.Parse(txtParticipant.Text);
                TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("HH:mm:ss"));
                TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("HH:mm:ss"));
                if (tmstart < tmend)
                {
                    if (inputval >= cpv)
                    {
                        try
                        {
                            hallid = int.Parse(ddlLocation.SelectedValue.ToString());
                            unitid = int.Parse(drdlUnit.SelectedValue.ToString());
                            deptid = int.Parse(drdlDepartment.SelectedValue.ToString());
                            totalparticipants = int.Parse(txtParticipant.Text.ToString());
                            DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
                            actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                            string alertMessage = bll.SubmitConferenceroomshedulinfo(hallid, unitid, deptid, totalparticipants, fromdate, tmstart, tmend, actionBy);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                        }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit this application !!!');", true); }
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Failled  !!!! Because participant must be equal or greater than capacity');", true); }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Failled  !!!! End time can not greater than start time');", true); }
            }
        }

        #endregion=====================Close==========================================

        #region =====================Selection Changed ================================
        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             confID = int.Parse(ddlLocation.SelectedValue);
            dt = bll.GetdataforConferenceRoom(2,confID);
            lblLevelnumber.Text = dt.Rows[0]["LevelNumber"].ToString();
            lblCapacitytotal.Text = dt.Rows[0]["SeatCapacity"].ToString();
            lblProjector.Text= dt.Rows[0]["Projector"].ToString();
            DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
            dt = bll.ConferenceRoomBookingStatus(fromdate, confID);
            string bokst= dt.Rows[0]["strstatis"].ToString();
            if (bokst == "Not Booked") { imgSignal.ImageUrl = "../../Content/images/img/GreenSignal.jpg";}
            else if (bokst == "booked"){imgSignal.ImageUrl = "../../Content/images/img/RedSignal.jpg";}
            else { }
              
            }
            catch { }
        }
        #endregion =====================Close ===================================
        

        #region =====================Claender View Setup================================

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.Calendar1_DayRender);
            //this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler("2017-03-01");
            this.Load += new System.EventHandler(this.Page_Load);
            
        }
       

        
        private void Calendar1_DayRender(Object source, DayRenderEventArgs e)
        {
            confID = int.Parse(ddlLocation.SelectedValue);

            int fromdate11 = Calendar1.VisibleDate.Month;
            int fromdate2 = e.Day.Date.Month;
            DateTime fromdate = e.Day.Date;
            //DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
            Label lbldet = new Label();
            Label lbldettooltip = new Label();
           dt = bll.ConferenceRoomBookingMonthvsHallid(confID, fromdate);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (e.Day.DayNumberText == dt.Rows[i]["daysorder"].ToString() )
                        {
                        if (dt.Rows[i]["status"].ToString() == "Approved") { e.Cell.BackColor = System.Drawing.Color.LightSkyBlue; }
                        else { e.Cell.BackColor = System.Drawing.Color.Khaki; }
                        Label lbl = new Label();
                        lbl.ForeColor = System.Drawing.Color.DarkOrchid;
                        lbl.Text = "<br/>" + dt.Rows[i]["Duration"].ToString();
                        e.Cell.Controls.Add(lbl);
                        lbldettooltip.Text += " " + dt.Rows[i]["DetaillsInfo"].ToString();
                        e.Cell.Attributes.Add("title", lbldettooltip.Text.ToString());
                        //lbldettooltip.BackColor("BackColor", "#00ffaa");
                    }
                }
              
            }
            else
            {
                //e.Cell.BackColor = System.Drawing.Color.LightGray;
                Label lbl = new Label();
                lbl.Text = "";
                e.Cell.Controls.Add(lbl);

            }
        }
      


        #endregion =====================Close================================
      
    }
}