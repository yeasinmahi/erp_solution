﻿using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IssueForProduction : System.Web.UI.Page
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();
        Location_BLL objOperation = new Location_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataBind();

                }
                catch { }
            }
            else
            { }
        }
        public string GetJSFunctionString(object ReqId, object ReqCode, object dteReqDate, object strDepartmentName, object strReqBy, object strApproveBy, object intDeptID, object intSectionID, object SectionName)
        {
            //  Eval("Id"),Eval("ReqCode"),Eval("dteReqDate"),Eval("strDepartmentName"),Eval("strReqBy"),Eval("strApproveBy"))
            string str = "";
            str = ReqId.ToString() + ',' + ReqCode.ToString() + "," + dteReqDate.ToString() + ',' + strDepartmentName.ToString() + ',' + strReqBy.ToString() + ',' + strApproveBy.ToString() + "," + intDeptID.ToString() + "," + intSectionID.ToString() + "," + SectionName.ToString();
            return str;
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvReq.DataSource = "";
                dgvReq.DataBind();
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            intwh = int.Parse(ddlWH.SelectedValue);
            DateTime dteFrom = DateTime.Parse(txtdteFrom.Text.ToString());
            DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
            string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
            dt = objIssue.GetViewData(17, xmlData, intwh, 0, DateTime.Now, enroll);
            dgvReq.DataSource = dt;
            dgvReq.DataBind();
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                //Label lblReqId = row.FindControl("lblReqId") as Label;
               // int ReqId = int.Parse(lblReqId.Text);
                intwh = int.Parse(ddlWH.SelectedValue);


                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string Reqid = datas[0].ToString();
                string ReqCode = datas[1].ToString();
                string dteReqDate = datas[2].ToString();
                string strDepartmentName = datas[3].ToString();
                string strReqBy = datas[4].ToString();
                string strApproveBy = datas[5].ToString();

                string DeptID = datas[6].ToString();
                string SectionID = datas[7].ToString();
                string SectionName = datas[8].ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + Reqid + "','" + ReqCode.ToString() + "','" + dteReqDate + "','" + strDepartmentName + "','" + strReqBy + "','" + strApproveBy + "','" + intwh.ToString() + "','" + DeptID + "','" + SectionID + "','" + SectionName + "');", true);

            }
            catch { }
        }

    }
}