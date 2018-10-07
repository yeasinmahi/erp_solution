using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using UI.ClassFiles;
using HR_BLL.Dispatch;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.HR.Dispatch
{
    public partial class DocDispatch : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Dispatch/DocDispatch.aspx";
        string stop = "stopping HR/Dispatch/DocDispatch.aspx";

        DispatchBLL obj = new DispatchBLL(); DataTable dt = new DataTable();

        DateTime dteDate;
        //int intInsertBy; string fileName; string strDocUploadPath;
        int intPart, intDeliveryType, intActionBy, intDocNameID, intDeliveryThruID; bool ysnReceive;
        string strDocType, strDeliveryType, strFName, strFCompany, strFCompanyAdd, strFCompanyPhone, strFMobile, strFEmail;
        string strTName, strTCompany, strTCompanyAdd, strTCompanyPhone, strTMobile, strTEmail, strRemarks;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/DocDispatch.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    strDocType = ""; intDocNameID = 0;
                    strDeliveryType = ""; intDeliveryThruID = 0;
                    strFName = ""; strFCompany = ""; strFCompanyAdd = "";
                    strFCompanyPhone = ""; strFMobile = "";
                    strFEmail = ""; strTName = "";
                    strTCompany = ""; strTCompanyAdd = "";
                    strTCompanyPhone = ""; strTMobile = "";
                    strTEmail = ""; intActionBy = int.Parse(hdnEnroll.Value.ToString());
                    dteDate = DateTime.Parse(DateTime.Now.ToString()); strRemarks = "";
                    ysnReceive = false;
                    txtDelThru.Visible = false;
                    btnSearch.Visible = false;
                    lblSearch.Visible = false;

                    intPart = 1;
                    dt = new DataTable();
                    intDeliveryType = Int32.Parse(ddlDeliveryType.SelectedValue.ToString());
                    dt = obj.GetDocDispatch(intPart, intDeliveryType, strDocType, intDocNameID, strDeliveryType, intDeliveryThruID, strFName, strFCompany, strFCompanyAdd, strFCompanyPhone, strFMobile, strFEmail, strTName, strTCompany, strTCompanyAdd, strTCompanyPhone, strTMobile, strTEmail, intActionBy, dteDate, strRemarks, ysnReceive);
                    ddlDelThru.DataSource = dt;
                    ddlDelThru.DataTextField = "Name";
                    ddlDelThru.DataValueField = "intID";
                    ddlDelThru.DataBind();

                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/DocDispatch.aspx btnSubmit_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                strDocType = ddlDocType.SelectedItem.Text.ToString(); intDocNameID = int.Parse(ddlDocName.SelectedValue.ToString());
                strDeliveryType = ddlDeliveryType.SelectedItem.Text.ToString(); intDeliveryThruID = int.Parse(ddlDelThru.SelectedValue.ToString());
                strFName = txtFName.Text.ToString(); strFCompany = txtFCompany.Text.ToString(); strFCompanyAdd = txtFCompanyAdd.Text.ToString();
                strFCompanyPhone = txtFCompanyPhone.Text.ToString(); strFMobile = txtFPhone.Text.ToString();
                strFEmail = txtFMail.Text.ToString(); strTName = txtTName.Text.ToString();
                strTCompany = txtTCompany.Text.ToString(); strTCompanyAdd = txtTCompanyAdd.Text.ToString();
                strTCompanyPhone = txtTCompanyPhone.Text.ToString(); strTMobile = txtTPhone.Text.ToString();
                strTEmail = txtTMail.Text.ToString(); intActionBy = int.Parse(hdnEnroll.Value.ToString());
                dteDate = DateTime.Parse(DateTime.Now.ToString()); strRemarks = txtRemarks.Text.ToString();

                if (ddlDispathType.SelectedItem.ToString() == "Receive")
                {
                    ysnReceive = true;
                }
                else
                {
                    ysnReceive = false;
                }

                if (strFName !="" && strTName != "")
                {
                    intPart = 2;
                    dt = obj.GetDocDispatch(intPart, intDeliveryType, strDocType, intDocNameID, strDeliveryType, intDeliveryThruID, strFName, strFCompany, strFCompanyAdd, strFCompanyPhone, strFMobile, strFEmail, strTName, strTCompany, strTCompanyAdd, strTCompanyPhone, strTMobile, strTEmail, intActionBy, dteDate, strRemarks, ysnReceive);
                    if (dt.Rows.Count > 0)
                    {
                        txtDispatchID.Text = dt.Rows[0]["intID"].ToString();
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted....');", true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Name can not be blanked....');", true); }

                
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Failed....');", true); return; }

            fd = log.GetFlogDetail(stop, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void ddlDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intDeliveryType = Int32.Parse(ddlDeliveryType.SelectedValue.ToString());
                if (intDeliveryType==1)
                {
                    txtDelThru.Visible = true;
                    btnSearch.Visible = true;
                    lblSearch.Visible = true;
                }
                else { txtDelThru.Visible = false; btnSearch.Visible = false; lblSearch.Visible = false; }

                strDocType = ""; intDocNameID = 0;
                strDeliveryType = ""; intDeliveryThruID = 0;
                strFName = ""; strFCompany = ""; strFCompanyAdd = "";
                strFCompanyPhone = ""; strFMobile = "";
                strFEmail = ""; strTName = "";
                strTCompany = ""; strTCompanyAdd = "";
                strTCompanyPhone = ""; strTMobile = "";
                strTEmail = ""; intActionBy = int.Parse(hdnEnroll.Value.ToString());
                dteDate = DateTime.Parse(DateTime.Now.ToString()); strRemarks = "";
                ysnReceive = false;

                intPart = 1;
                dt = new DataTable();
                dt = obj.GetDocDispatch(intPart, intDeliveryType, strDocType, intDocNameID, strDeliveryType, intDeliveryThruID, strFName, strFCompany, strFCompanyAdd, strFCompanyPhone, strFMobile, strFEmail, strTName, strTCompany, strTCompanyAdd, strTCompanyPhone, strTMobile, strTEmail, intActionBy, dteDate, strRemarks, ysnReceive);
                ddlDelThru.DataSource = dt;
                ddlDelThru.DataTextField = "Name";
                ddlDelThru.DataValueField = "intID";
                ddlDelThru.DataBind();

            }
            catch { }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSearch_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/DocDispatch.aspx btnSearch_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intDeliveryType = Int32.Parse(ddlDeliveryType.SelectedValue.ToString());
                if (intDeliveryType == 1)
                {
                    dt = new DataTable();
                    int intEmpID = Int32.Parse(txtDelThru.Text.ToString());
                    dt = obj.GetEmpName(intEmpID);
                    ddlDelThru.DataSource = dt;
                    ddlDelThru.DataTextField = "strEmployeeName";
                    ddlDelThru.DataValueField = "intEmployeeID";
                    ddlDelThru.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select a courier name....');", true);
                }
                
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "btnSearch_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }








    }
}