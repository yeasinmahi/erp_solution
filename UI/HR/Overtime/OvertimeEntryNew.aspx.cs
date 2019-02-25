using HR_BLL.Employee;
using HR_BLL.Global;
using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.HR.Overtime
{
    public partial class OvertimeEntryNew : BasePage
    {
        private readonly TourPlanning _bll = new TourPlanning();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                Session["obj"] = null;
                LoadPurpose();
                LoadUnitDropDown(Enroll);
                LoadJobStationDropDown(GetUnitId(), Enroll);
                ddlUnit_OnSelectedIndexChanged(null, null);
            }
            if (hdnSearch.Value == "1")
            {
                LoadEmployeeInfo();
            }

            
            SetVisibility("itemPanel", GridViewEmployeeDetails.Rows.Count > 0);
        }
        
        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobStationDropDown(GetUnitId(), Enroll);
            ddlJobStation_OnSelectedIndexChanged(ddlJobStation, null);
        }

        protected void ddlJobStation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["jobStationId"] = (sender as DropDownList)?.SelectedValue;
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string empEnroll = txtEnroll.Text;
            string date = txtDate.Text;
            string startTime = txtStrtTime.Text;
            string endTime = txtEndTime.Text;
            string diffTime = txtMove.Text;
            string reason = ddlPurpose.SelectedItem.Text;
            string remarks = txtRemarks.Text;
            if (!TimeSpan.TryParse(diffTime, out var time))
            {
                // handle validation error
            }
            double hour = time.ToSecond();
            dynamic obj = new
            {
                empEnroll,
                date,
                startTime,
                endTime,
                diffTime,
                hour,
                reason,
                remarks
            };
            List<object> objects = new List<object>();
            if (Session["obj"] != null)
            {
                objects = (List<object>)Session["obj"];
            }
            foreach (GridViewRow row in OvertimeEntryGridView.Rows)
            {
                if (((Label)row.FindControl("lblEmpEnroll")).Text.Contains(empEnroll) && ((Label)row.FindControl("lblDate")).Text.Contains(date))
                {
                    Toaster("Can not add same enroll " + empEnroll + " and date " + date + " dublicate.", "Over Time", Common.TosterType.Error);
                    SetVisibility("panel", true);
                    return;
                }
                //row.Cells["chat1"].Style.ForeColor = Color.CadetBlue;
            }
            objects.Add(obj);

            Session["obj"] = objects;
            
            string xmlString = XmlParser.GetXml("OvertimeEntry", "items", objects, out string message);

            LoadGridwithXml(xmlString, OvertimeEntryGridView);
        }

        protected void OvertimeEntryGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["obj"] != null)
            {
                List<object> objects = (List<object>)Session["obj"];
                objects.RemoveAt(e.RowIndex);
                if (objects.Count > 0)
                {
                    string xmlString = XmlParser.GetXml("OvertimeEntry", "items", objects, out string message);
                    LoadGridwithXml(xmlString, OvertimeEntryGridView);
                }
                else
                {
                    OvertimeEntryGridView.UnLoad();
                }
            }
            else
            {
                OvertimeEntryGridView.UnLoad();
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int unitId = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            int jobStationId = Convert.ToInt32(ddlJobStation.SelectedItem.Value);

            List<object> objects = new List<object>();
            List<object> objectsNew = new List<object>();
            if (Session["obj"] != null)
            {
                objects = (List<object>)Session["obj"];
            }
            foreach (object o in objects)
            {
                dynamic obj = new
                {
                    overtimeId = 0,
                    empEnroll = Common.GetPropertyValue(o, "empEnroll"),
                    unitId,
                    jobStationId,
                    date = Common.GetPropertyValue(o, "date"),
                    startTime = Common.GetPropertyValue(o, "startTime"),
                    endTime = Common.GetPropertyValue(o, "endTime"),
                    diffTime = Common.GetPropertyValue(o, "diffTime"),
                    hour = Common.GetPropertyValue(o, "hour"),
                    reason = Common.GetPropertyValue(o, "reason"),
                    remarks = Common.GetPropertyValue(o, "remarks")
                };
                objectsNew.Add(obj);
            }
            if (objectsNew.Count > 0)
            {
                string xmlString = XmlParser.GetXml("OvertimeEntry", "items", objectsNew, out string message);
                string ipaddress = MySystem.GetIp();
                message = _bll.OvertimeEntryNew(1, xmlString, Enroll, ipaddress);

                if (message.Contains("Sucessfully"))
                {
                    Session["obj"] = null;
                    OvertimeEntryGridView.UnLoad();
                    Toaster(message, "OverTime", Common.TosterType.Success);
                    LoadOverTimeDetailsGridView(Convert.ToInt32(txtEnroll.Text));
                }
                else
                {
                    Toaster(message, "OverTime", Common.TosterType.Error);
                }
            }
            else
            {
                Toaster("No Data Found to Insert", "OverTime", Common.TosterType.Warning);
            }
        }

        private void LoadPurpose()
        {
            ddlPurpose.Loads(_bll.getOvertimePurpouse(), "intID", "strPurpouse");
        }

        private void LoadPurposeUpdate()
        {
            ddlPurposeUpdate.Loads(_bll.getOvertimePurpouse(), "intID", "strPurpouse");
        }

        public void LoadJobStationDropDown(int unitId, int enroll)
        {
            ddlJobStation.Loads(_bll.GetJobStationByPermission(unitId, Enroll), "intEmployeeJobStationId", "strJobStationName");
        }

        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.Loads(_bll.GetUnitName(enrol), "intUnitID", "strUnit");
        }

        public int GetUnitId()
        {
            return Convert.ToInt32(ddlUnit.SelectedItem.Value);
            //return int.Parse(_bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            int jobStationId = 0;
            try
            {
                jobStationId = int.Parse(HttpContext.Current.Session["jobStationId"].ToString());
            }
            catch (Exception e)
            {
            }
            AutoSearch_BLL objAutoSearchBll = new AutoSearch_BLL();
            var result = objAutoSearchBll.AutoSearchEmployeesData(//1399, 12, strSearchKey);
                int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), jobStationId, strSearchKey);
            return result;
        }

        public void LoadEmployeeInfo()
        {
            string strSearchKey = txtEmployeeName.Text;
            if (!string.IsNullOrEmpty(strSearchKey))
            {
                string[] searchKey = Regex.Split(strSearchKey, ",");
                if (searchKey.Length == 2)
                {
                    LoadFieldValue(searchKey[1]);
                }
                else
                {
                    Toaster("Your Employee Name Format Error",Common.TosterType.Warning);
                }
            }
        }

        private void LoadFieldValue(string empCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(empCode))
                {
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDt = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDt.Rows.Count > 0)
                    {
                        txtCode.Text = empCode;
                        txtDesignation.Text = objDt.Rows[0]["strDesignation"].ToString();
                        txtEnroll.Text = objDt.Rows[0]["intEmployeeID"].ToString();

                        LoadOverTimeDetailsGridView(Convert.ToInt32(txtEnroll.Text));
                    }
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Overtime", Common.TosterType.Error);
            }
        }

        private void LoadGridwithXml(string xmlString, GridView gridView)
        {
            if (!GridViewUtil.LoadGridwithXml(xmlString, gridView, out string message))
            {
                Toaster(message, "Overtime", Common.TosterType.Error);
                SetVisibility("panel", false);
            }
            else
            {
                SetVisibility("panel", true);
            }
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            txtOvertimeId.Text = GridViewEmployeeDetails.DataKeys[row.RowIndex]?.Value.ToString();
            txtEnrollUpdate.Text = ((Label)row.FindControl("lblEmpEnroll")).Text;
            txtEmployeeNameUpdate.Text = ((Label)row.FindControl("lblEmployeeName")).Text;
            txtDesignationUpdate.Text = ((Label)row.FindControl("lblDesignation")).Text;
            txtDateUpdate.Text = ((Label)row.FindControl("lblDate")).Text;
            txtStrtTimeUpdate.Text = ((Label)row.FindControl("lblStartTime")).Text;
            txtEndTimeUpdate.Text = ((Label)row.FindControl("lblEndTime")).Text;
            string hour = ((Label)row.FindControl("lblHour")).Text;
            txtMoveUpdate.Text = (Convert.ToDouble(hour) * 3600).ToTimeSpan().ToString("g");
            txtRemarksUpdate.Text = ((Label)row.FindControl("lblRemarks")).Text;

            LoadPurposeUpdate();
            //ddlPurposeUpdate.SelectedItem.Text = ((Label)row.FindControl("lblReson")).Text;
            ddlPurposeUpdate.SelectedIndex = ddlPurposeUpdate.Items.IndexOf(ddlPurposeUpdate.Items.FindByText(((Label)row.FindControl("lblReson")).Text));
            SetVisibilityModal(true);
        }

        private void LoadOverTimeDetailsGridView(int empId)
        {
            DateTime today = DateTime.Now;
            DateTime month = new DateTime(today.Year, today.Month, 1);
            DateTime fromDate = month.AddMonths(-1);
            if (today.Day > 7)
            {
                fromDate = month;
            }
            DateTime toDate = month.AddMonths(1).AddDays(-1);
            DataTable dt = _bll.GetEmployeeOvertimeDetails(empId, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            if (dt.Rows.Count > 0)
            {
                GridViewEmployeeDetails.DataSource = dt;
                GridViewEmployeeDetails.DataBind();
                SetVisibility("itemPanel", true);
            }
            else
            {
                SetVisibility("itemPanel", false);
            }
        }

        protected void btnUpdateFinal_OnClick(object sender, EventArgs e)
        {
            string overtimeId = txtOvertimeId.Text;

            string date = txtDateUpdate.Text;
            string startTime = txtStrtTimeUpdate.Text;
            string endTime = txtEndTimeUpdate.Text;

            if (!TimeSpan.TryParse(startTime, out var startTimeSpan))
            {
                // handle validation error
            }
            if (!TimeSpan.TryParse(endTime, out var endTimeSpan))
            {
                // handle validation error
            }
            DateTime defaultDate = new DateTime(2018, 01, 01);
            TimeSpan diffTime = endTimeSpan - startTimeSpan;
            if (endTimeSpan < startTimeSpan)
            {
                diffTime = defaultDate.AddDays(1).Add(endTimeSpan) - defaultDate.Add(startTimeSpan);
            }
            string reason = ddlPurposeUpdate.SelectedItem.Text;
            string remarks = txtRemarksUpdate.Text;

            double hour = diffTime.ToSecond();
            dynamic obj = new
            {
                overtimeId,
                date,
                startTime,
                endTime,
                diffTime,
                hour,
                reason,
                remarks
            };
            string xmlString = XmlParser.GetXml("OvertimeEntry", "items", obj, out string message);
            message = _bll.OvertimeEntryNew(2, xmlString, Enroll, "");
            if (!message.ToLower().Contains("sucessfully"))
            {
                SetVisibilityModal(true);
                Toaster(message,"Over Time",Common.TosterType.Error);
                return;
            }
            int empId = Convert.ToInt32(txtEnrollUpdate.Text);
            LoadOverTimeDetailsGridView(empId);
            Toaster(message, "Over Time", Common.TosterType.Success);
        }
    }
}