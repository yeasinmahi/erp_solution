using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Attendance
{
    public partial class CalenderView : BasePage
    {
        HR_BLL.Attendance.EmployeeAttendance calenderview = new HR_BLL.Attendance.EmployeeAttendance();
        protected System.Web.UI.WebControls.Calendar Calendar1; public string strinformation = "";
        protected System.Web.UI.WebControls.Label lbl;
                            

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                    txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                    {
                        string strSearchKey = txtEmployeeSearch.Text;
                        string[] searchKey = Regex.Split(strSearchKey, ",");
                        hdfEmpCode.Value = searchKey[1];
                        EmployeeRegistration objGetProfile = new EmployeeRegistration();
                        DataTable objDT = new DataTable();
                        DataTable objinfo = new DataTable();
                        objDT = objGetProfile.GetEmployeeProfileByEmpCode(hdfEmpCode.Value);
                        HR_BLL.Attendance.EmployeeAttendance objatt = new HR_BLL.Attendance.EmployeeAttendance();
                        if (objDT.Rows.Count > 0)
                        {
                            hdnempid.Value = objDT.Rows[0]["intEmployeeID"].ToString();
                            objinfo = objatt.EmployeeInformation(int.Parse(hdnempid.Value));
                            string name = objinfo.Rows[0]["strEmployeeName"].ToString().ToUpper();
                            string unit = objinfo.Rows[0]["strUnit"].ToString().ToUpper();
                            string station = objinfo.Rows[0]["strJobStationName"].ToString().ToUpper();
                            string department = objinfo.Rows[0]["strDepatrment"].ToString().ToUpper();
                            string designation = objinfo.Rows[0]["strDesignation"].ToString().ToUpper();
                            string jobtype = objinfo.Rows[0]["strJobTypeShort"].ToString().ToUpper();
                            strinformation = @" <table border='0' style = 'width:340px;'>
                            <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Employee :</td>
                            <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; strinformation = strinformation + name + @"</td></tr>
                            <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Unit :</td>
                            <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; strinformation = strinformation + unit + @"</td></tr>
                            <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Station :</td>
                            <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; strinformation = strinformation + station + @"</td></tr>
                            <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Department :</td>
                            <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; strinformation = strinformation + department + @"</td></tr>
                            <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Designation :</td>
                            <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; strinformation = strinformation + designation + @"</td></tr>
                            <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Job-Type :</td>
                            <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; strinformation = strinformation + jobtype + @"</td></tr>                    
                            <tr><td colspan='3'><hr /></td></tr></table>";
                            pnlpersonalinformation.DataBind();
                        }
                    }
                }
            }
            catch { }
        }
        
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.Calendar1_DayRender);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        private void Calendar1_DayRender(Object source, DayRenderEventArgs e)
        {
            if (!String.IsNullOrEmpty(hdfEmpCode.Value))
            {
                DataTable objDT = new DataTable();
                objDT = calenderview.GetCalenderAttendance(hdfEmpCode.Value, null);
                if (objDT.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        if (e.Day.DayNumberText == objDT.Rows[i]["intDayId"].ToString() && e.Day.Date.Month == DateTime.Now.Month)
                        {
                            if (objDT.Rows[i]["ysnPresent"].ToString() == "True" && objDT.Rows[i]["ysnLate"].ToString() == "False")
                            {

                                e.Cell.BackColor = System.Drawing.Color.Green;
                                Label lbl = new Label();
                                lbl.Text = "<br>Present!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else if (objDT.Rows[i]["ysnPresent"].ToString() == "True" && objDT.Rows[i]["ysnLate"].ToString() == "True")
                            {

                                e.Cell.BackColor = System.Drawing.Color.YellowGreen;
                                Label lbl = new Label();
                                lbl.Text = "<br>Late!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else if (objDT.Rows[i]["ysnAbsent"].ToString() == "True")
                            {
                                e.Cell.BackColor = System.Drawing.Color.Red;
                                Label lbl = new Label();
                                lbl.Text = "<br>Absent!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else if (objDT.Rows[i]["ysnLeave"].ToString() == "True")
                            {
                                e.Cell.BackColor = System.Drawing.Color.BlueViolet;
                                Label lbl = new Label();
                                lbl.Text = "<br>Leave!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else if (objDT.Rows[i]["ysnMovement"].ToString() == "True")
                            {
                                e.Cell.BackColor = System.Drawing.Color.Pink;
                                Label lbl = new Label();
                                lbl.Text = "<br>Movement!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else if (objDT.Rows[i]["ysnHoliday"].ToString() == "True")
                            {
                                e.Cell.BackColor = System.Drawing.Color.Brown;
                                Label lbl = new Label();
                                lbl.Text = "<br>Holiday!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else if (objDT.Rows[i]["ysnOffday"].ToString() == "True")
                            {
                                e.Cell.BackColor = System.Drawing.Color.Peru;
                                Label lbl = new Label();
                                lbl.Text = "<br>Dayoff!";
                                e.Cell.Controls.Add(lbl);
                            }
                            else
                            {
                                e.Cell.BackColor = System.Drawing.Color.Aqua;
                                Label lbl = new Label();
                                lbl.Text = "<br>Unprocess!" +i.ToString();
                                e.Cell.Controls.Add(lbl);
                            }
                        }
                    }
                }
                else
                {
                    e.Cell.BackColor = System.Drawing.Color.Aqua;
                    Label lbl = new Label();
                    lbl.Text = "<br>No punch!";
                    e.Cell.Controls.Add(lbl);
                }
                hdfSearchBoxTextChange.Value = "false";
            }
            
        }
        





    }
}