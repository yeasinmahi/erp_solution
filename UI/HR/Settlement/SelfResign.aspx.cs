﻿using HR_BLL.Settlement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Settlement
{
    public partial class SelfResign : BasePage
    {
        SelfClass obj = new SelfClass();
        DataTable dt;

        int intEnroll; int intSeparateType; DateTime dteLastOfficeDate; DateTime dteLastOfficeDateByUser;
        DateTime dteSeparateDateTime; string strSeparateReason; int intSVID; DateTime dteLastOfficeDateByAuthority;
        int intPart; int intSeparateInsertBy; int intApproveBy; decimal monAmount; string strRemarks;
        string strEmailAdd; string strCurrentAddress;

        public string strinformation = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind();}
            intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = new DataTable();
            dt = obj.GetEmpInfoForSeltResign(intEnroll);

            txtSupervisorName.Text = dt.Rows[0]["strSuperviserName"].ToString();
            txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
            txtEmpCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
            txtEmpEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
            txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
            txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
            txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
            txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
            txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
            txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
            txtJoiningDate.Text = dt.Rows[0]["dteJoiningDate"].ToString();
            txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
            txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
            txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = new DataTable();
            dt = obj.CheckSelfResign(intEnroll);
            int intCheckID = int.Parse(dt.Rows[0]["intCheck"].ToString());

            if (intCheckID != 0)
            {
                txtReason.Text = "";
                txtLastOfficeDateByUser.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already resign submited.');", true);
            }
            else
            {
                if (hdnconfirm.Value == "1")
                {

                    try
                    {
                        intSeparateType = 1;
                        dteLastOfficeDate = DateTime.Parse(txtLastOfficeDateWillbe.Text);
                        dteLastOfficeDateByUser = DateTime.Parse(txtLastOfficeDateByUser.Text);
                        dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        strSeparateReason = txtReason.Text;
                        dteLastOfficeDateByAuthority = DateTime.Parse(txtLastOfficeDateByUser.Text);
                        intSeparateInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                        intPart = 1;

                        obj.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);

                        txtReason.Text = "";
                        txtLastOfficeDateByUser.Text = "";

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Submited Successfully');", true);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please try again.');", true);
                    }
                }
            }
        }



    }
}