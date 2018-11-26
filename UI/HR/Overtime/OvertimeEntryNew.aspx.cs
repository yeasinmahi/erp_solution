﻿using System;
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
            if (hdnSearch.Value=="1")
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
            
        }

        protected void OvertimeEntryGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void btnActive_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            
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
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('"+ex.Message+"')", true);
            }
            
        }
    }
}