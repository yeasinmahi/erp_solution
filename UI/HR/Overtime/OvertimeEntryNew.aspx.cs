using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Employee;
using HR_BLL.Global;
using HR_BLL.TourPlan;
using UI.ClassFiles;
using Utility;

namespace UI.HR.Overtime
{
    public partial class OvertimeEntryNew : Page
    {
        private readonly TourPlanning _bll = new TourPlanning();
        private int enroll = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            enroll = Int32.Parse(Session[SessionParams.USER_ID].ToString());

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                Session["obj"] = null;
                LoadPurpose();
                LoadUnitDropDown(enroll);
                LoadJobStationDropDown(GetUnitId());
                ddlUnit_OnSelectedIndexChanged(null, null);
            }
            if (hdnSearch.Value == "1")
            {
                LoadEmployeeInfo();
            }
        }

        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobStationDropDown(GetUnitId());
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
            double hour = DateTimeConverter.ConvertTimeSpanToSecond(time);
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
                objects = (List<object>) Session["obj"];
            }
            foreach (GridViewRow row in OvertimeEntryGridView.Rows)
            {
                if (((Label)row.FindControl("lblEmpEnroll")).Text.Contains(empEnroll) && ((Label)row.FindControl("lblDate")).Text.Contains(date))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                        "ShowNotification('Can not add same enroll " + empEnroll + " and date " + date + " dublicate','OverTime','error')", true);
                    return;
                }
                //row.Cells["chat1"].Style.ForeColor = Color.CadetBlue;
            }
            objects.Add(obj);
            
            Session["obj"] = objects;
            string xmlString = XmlParser.GetXml("OvertimeEntry", "items", objects, out string message);

            LoadGridwithXml(xmlString,OvertimeEntryGridView);


        }

        protected void OvertimeEntryGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["obj"] != null)
            {
                List<object> objects = (List<object>) Session["obj"];
                objects.RemoveAt(e.RowIndex);
                if (objects.Count > 0)
                {
                    string xmlString = XmlParser.GetXml("OvertimeEntry", "items", objects, out string message);
                    LoadGridwithXml(xmlString, OvertimeEntryGridView);
                }
                else
                {
                    GridViewUtil.UnLoadGridView(OvertimeEntryGridView);
                }
            }
            else
            {
                GridViewUtil.UnLoadGridView(OvertimeEntryGridView);
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
                    overtimeId=0,
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

            string xmlString = XmlParser.GetXml("OvertimeEntry", "items", objectsNew, out string message);
            string ipaddress = Common.GetIp();
            message = _bll.OvertimeEntryNew(1,xmlString, enroll, ipaddress);
            GridViewUtil.UnLoadGridView(OvertimeEntryGridView);
            if (message.Contains("Sucessfully"))
            {
                Session["obj"] = null;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('" + message + "','OverTime','success')", true);
                LoadOverTimeDetailsGridView(Convert.ToInt32(txtEnroll.Text));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('" + message + "','OverTime','error')", true);
            }
            
        }

        private void LoadPurpose()
        {
            ddlPurpose.DataSource = _bll.getOvertimePurpouse();
            ddlPurpose.DataValueField = "intID";
            ddlPurpose.DataTextField = "strPurpouse";
            ddlPurpose.DataBind();
        }
        private void LoadPurposeUpdate()
        {
            ddlPurposeUpdate.DataSource = _bll.getOvertimePurpouse();
            ddlPurposeUpdate.DataValueField = "intID";
            ddlPurposeUpdate.DataTextField = "strPurpouse";
            ddlPurposeUpdate.DataBind();
        }
        public void LoadJobStationDropDown(int unitId)
        {
            ddlJobStation.DataSource = _bll.GetJobStation(unitId);
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataBind();
        }
        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.DataSource = _bll.GetUnitName(enrol);
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }
        public int GetUnitId()
        {
            return Convert.ToInt32(ddlUnit.SelectedItem.Value);
            //return int.Parse(_bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearchBll = new AutoSearch_BLL();
            var result = objAutoSearchBll.AutoSearchEmployeesData(//1399, 12, strSearchKey);
                int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session["jobStationId"].ToString()), strSearchKey);
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

            }
            else
            {
                //ClearControls();
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
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "ShowNotification('" + ex.Message + "','OverTime','error')", true);
            }

        }
        private void LoadGridwithXml(string xmlString, GridView gridView)
        {
            if (!GridViewUtil.LoadGridwithXml(xmlString, gridView, out string message))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "ShowNotification('" + message + "','OverTime','error')", true);
            }
        }


        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            txtOvertimeId.Text = GridViewEmployeeDetails.DataKeys[row.RowIndex]?.Value.ToString();
            txtEnrollUpdate.Text = ((Label) row.FindControl("lblEmpEnroll")).Text;
            txtEmployeeNameUpdate.Text =((Label) row.FindControl("lblEmployeeName")).Text;
            txtDesignationUpdate.Text = ((Label) row.FindControl("lblDesignation")).Text;
            txtDateUpdate.Text = ((Label) row.FindControl("lblDate")).Text;
            txtStrtTimeUpdate.Text = ((Label) row.FindControl("lblStartTime")).Text;
            txtEndTimeUpdate.Text = ((Label) row.FindControl("lblEndTime")).Text;
            string hour =((Label) row.FindControl("lblHour")).Text;
            txtMoveUpdate.Text = DateTimeConverter.ConvertSecondToTimespan(Convert.ToDouble(hour) * 3600).ToString("g");
            txtRemarksUpdate.Text = ((Label) row.FindControl("lblRemarks")).Text;

            LoadPurposeUpdate();
            ddlPurpose.SelectedItem.Text = ((Label)row.FindControl("lblReson")).Text;
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);

        }

        private void LoadOverTimeDetailsGridView(int empId)
        {
            DateTime today = DateTime.Now;
            DateTime fromDate = new DateTime(today.Year,today.AddMonths(-1).Month,1);
            DateTime toDate = new DateTime(today.Year,today.Month,today.AddMonths(1).AddDays(-1).Day);
            GridViewEmployeeDetails.DataSource = _bll.GetEmployeeOvertimeDetails(empId, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            GridViewEmployeeDetails.DataBind();
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
            var diffTime = endTimeSpan - startTimeSpan;
            string reason = ddlPurposeUpdate.SelectedItem.Text;
            string remarks = txtRemarksUpdate.Text;
            
            double hour = DateTimeConverter.ConvertTimeSpanToSecond(diffTime);
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
            message = _bll.OvertimeEntryNew(2, xmlString, enroll, "");
            if (!message.Contains("Sucessfully"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "ShowNotification('" + message + "','OverTime','error')", true);
                return;
            }
            int empId = Convert.ToInt32(txtEnrollUpdate.Text);
            LoadOverTimeDetailsGridView(empId);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "ShowNotification('" + message + "','OverTime','success')", true);
        }
    }
}