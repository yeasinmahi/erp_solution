﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        private int enroll = 369116;
        protected void Page_Load(object sender, EventArgs e)
        {
            //enroll = Int32.Parse(Session[SessionParams.USER_ID].ToString());

            if (!IsPostBack)
            {
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
            double hour = time.TotalSeconds / 3600;
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
            message = _bll.OvertimeEntryNew(xmlString, enroll, ipaddress);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
        }

        private void LoadPurpose()
        {
            ddlPurpose.DataSource = _bll.getOvertimePurpouse();
            ddlPurpose.DataValueField = "intID";
            ddlPurpose.DataTextField = "strPurpouse";
            ddlPurpose.DataBind();
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

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

        }
        private void LoadGridwithXml(string xmlString, GridView gridView)
        {
            if (!GridViewUtil.LoadGridwithXml(xmlString, gridView, out string message))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('" + message + "')", true);
            }
        }
        

        
    }
}