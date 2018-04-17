using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using System.Drawing;

namespace UI.Dairy
{
    public partial class Task_Main_Form : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intWork; int intEnroll; string Unitid; int intSearchEnroll; string strReportType;
        int intID; int intCount; int intPBack; int intCheck; int intReqCheck;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            //hdnEnroll.Value = "1459";

            if (!IsPostBack)
            {
                try
                {
                    //try { intPBack = int.Parse(HttpContext.Current.Session["intPBack"].ToString()); } catch { }

                    //if (intPBack == 0)
                    //{
                    pnlUpperControl.DataBind();
                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();

                    dt = objtask.GetEmpListBySupervisor(int.Parse(hdnEnroll.Value));
                    ddlTeamM1.DataTextField = "strEmployeeName";
                    ddlTeamM1.DataValueField = "intEmployeeID";
                    ddlTeamM1.DataSource = dt;
                    ddlTeamM1.DataBind();
                    ddlTeamM1.SelectedValue = "0";

                    ddlTeamM2.DataTextField = "strEmployeeName";
                    ddlTeamM2.DataValueField = "intEmployeeID";
                    ddlTeamM2.DataSource = dt;
                    ddlTeamM2.DataBind();
                    ddlTeamM2.SelectedValue = "0";

                    ddlTeamM3.DataTextField = "strEmployeeName";
                    ddlTeamM3.DataValueField = "intEmployeeID";
                    ddlTeamM3.DataSource = dt;
                    ddlTeamM3.DataBind();
                    ddlTeamM3.SelectedValue = "0";

                    ddlTeamM1.Visible = false;
                    ddlTeamM2.Visible = false;
                    ddlTeamM3.Visible = false;

                    try
                    {
                        dt = new DataTable();
                        dt = objtask.GetPicturePath(int.Parse(hdnEnroll.Value));
                        if (dt.Rows.Count > 0)
                        {
                            img.ImageUrl = "ftp://erp:erp123@ftp.akij.net" + dt.Rows[0]["strFtpFilePath"].ToString();
                        }
                        else { img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg"; }
                    }
                    catch { img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg"; }

                    LoadGrid();

                    //int intPostB = 1;
                    //HttpContext.Current.Session["intPBack"] = intPostB.ToString();
                    //intPBack = int.Parse(HttpContext.Current.Session["intPBack"].ToString());

                    //Session["intPBack"] = "1";
                    //intPBack = int.Parse(Session["intPBack"].ToString());

                    //else 
                    //{
                    //    ddlTeamM1.Visible = false;
                    //    ddlTeamM2.Visible = false;
                    //    ddlTeamM3.Visible = false;

                    //    LoadGrid(); 
                    //}
                }
                catch { }

            }
            ////else { if (hdnConfirmAppMarks.Value == "10") { Approved(); } }            
        }

        //private void Approved()
        //{
        //    if (hdnID.Value != "" && hdnConfirmAppMarks.Value == "10")
        //    {
        //        try
        //        { 
        //            int id = int.Parse(hdnID.Value);
        //            int marks = int.Parse(txtApproveMarks.Text);                                                             
        //            int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());   

        //            //Final Insert
        //            string message = objtask.UpdateTaskComplete(marks, id);
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ClearControls();", true);
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
        //            LoadGrid();                    
        //        }
        //        catch { }
        //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ClearControls();", true);
        //        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
        //        //LoadGrid();
                
        //    }
        //}

        //public string FilterControls(string Id, string marks)
        //{ return "Fillcontrols('" + Id + "','" + marks + "')"; }

        private void LoadGrid()
        {
            //char[] chr = { '[', ']' };
            //string[] temp1 = txtAssignBy.Text.Split(chr, StringSplitOptions.RemoveEmptyEntries);
            //try { intAssignBy = int.Parse(temp1[1].ToString()); }
            //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign By.');", true); return; }

            //char[] ch = { '[', ']' };
            //string[] temp = txtSearchAssignedTo.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            //try { intAssignTo = int.Parse(temp[1].ToString()); }
            //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign To.');", true); return; }
              
            try
            {   
                lblReportName.Text = "Task Assignment Report";
                strReportType = ddlReportType.SelectedItem.ToString();
                
                if (ddlReportType.SelectedValue.ToString() == "8")
                {
                    #region ======== All Report ==================================================================
                    if (rdoAssignedBy.Checked == true) { intWork = 27;} else { intWork = 28; }
                    intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intSearchEnroll = 0;
                    //intEnroll = 1459;
                    
                    dt = new DataTable();
                    dt = objtask.GetNewR(intWork, intEnroll, intSearchEnroll);
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                    #endregion =================================================================================
                }
                else
                {

                    if (cbMyTeam.Checked == false)
                    {
                        if (txtAllTask.Text == "")
                        {
                            if (rdoAssignedBy.Checked == true)
                            {
                                char[] chr = { '[', ']' };
                                string[] temp1 = txtAssignBy.Text.Split(chr, StringSplitOptions.RemoveEmptyEntries);
                                try { intSearchEnroll = int.Parse(temp1[1].ToString()); }
                                catch { intSearchEnroll = 0; }

                                if (intSearchEnroll == 0)
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 1;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 3;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 5;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 14;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 18;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 22;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }
                                else
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 7;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 9;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 11;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 15;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 19;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 23;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }

                            }
                            else
                            {
                                char[] ch = { '[', ']' };
                                string[] temp = txtSearchAssignedTo.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                                try { intSearchEnroll = int.Parse(temp[1].ToString()); }
                                catch { intSearchEnroll = 0; }

                                if (intSearchEnroll == 0)
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 2;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 4;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 6;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 16;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 20;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 24;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }
                                else
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 8;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 10;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 12;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 17;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 21;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 25;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }
                            }

                            intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                            //intEnroll = 1459;

                            dt = new DataTable();
                            dt = objtask.GetTaskReport2(intWork, intEnroll, intSearchEnroll);
                            dgvReport.DataSource = dt;
                            dgvReport.DataBind();

                            if (dt.Rows.Count > 0)
                            {
                                lblReportName.Visible = true;

                                //if (intWork == 1 || intWork == 5 || intWork == 7 || intWork == 11)
                                //{ dgvReport.Columns[0].Visible = true; dgvReport.Columns[1].Visible = true; }
                                //else { dgvReport.Columns[0].Visible = true; dgvReport.Columns[1].Visible = false; }

                                dgvReport.Columns[0].Visible = true;
                                dgvReport.Columns[1].Visible = true;

                                if (rdoAssignedBy.Checked == true) { dgvReport.Columns[8].Visible = false; dgvReport.Columns[7].Visible = true; }
                                else { dgvReport.Columns[8].Visible = true; dgvReport.Columns[7].Visible = false; }

                            }
                            else { lblReportName.Visible = false; }
                        }
                        else
                        {
                            char[] chall = { '[', ']' };
                            string[] temp2 = txtAllTask.Text.Split(chall, StringSplitOptions.RemoveEmptyEntries);
                            try { intEnroll = int.Parse(temp2[1].ToString()); }
                            catch { intEnroll = 0; }

                            intSearchEnroll = 0;
                            intWork = 13;

                            dt = new DataTable();
                            dt = objtask.GetTaskReport2(intWork, intEnroll, intSearchEnroll);
                            dgvReport.DataSource = dt;
                            dgvReport.DataBind();

                            if (dt.Rows.Count > 0)
                            {
                                lblReportName.Visible = true;
                                dgvReport.Columns[8].Visible = false;
                                dgvReport.Columns[7].Visible = true;
                                dgvReport.Columns[0].Visible = false;
                                dgvReport.Columns[1].Visible = false;

                                //if (rdoAssignedBy.Checked == true) { dgvReport.Columns[8].Visible = false; dgvReport.Columns[7].Visible = true; }
                                //else { dgvReport.Columns[8].Visible = true; dgvReport.Columns[7].Visible = false; }

                            }
                            else { lblReportName.Visible = false; }
                        }

                    }
                    //***************************************************************************************************************
                    else
                    {
                        if (ddlTeamM3.SelectedValue.ToString() == "0")
                        {

                            if (rdoAssignedBy.Checked == true)
                            {
                                //char[] chr = { '[', ']' };
                                //string[] temp1 = txtAssignBy.Text.Split(chr, StringSplitOptions.RemoveEmptyEntries);
                                //try { intSearchEnroll = int.Parse(temp1[1].ToString()); }
                                //catch { intSearchEnroll = 0; }

                                intSearchEnroll = int.Parse(ddlTeamM1.SelectedValue.ToString());

                                if (intSearchEnroll == 0)
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 1;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 3;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 5;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 14;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 18;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 22;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }

                                }
                                else
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 7;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 9;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 11;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 15;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 19;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 23;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }
                            }
                            else
                            {
                                //char[] ch = { '[', ']' };
                                //string[] temp = txtSearchAssignedTo.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                                //try { intSearchEnroll = int.Parse(temp[1].ToString()); }
                                //catch { intSearchEnroll = 0; }

                                intSearchEnroll = int.Parse(ddlTeamM2.SelectedValue.ToString());

                                if (intSearchEnroll == 0)
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 2;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 4;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 6;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 16;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 20;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 24;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }
                                else
                                {
                                    if (strReportType == "Tasks Due")
                                    {
                                        intWork = 8;
                                    }
                                    else if (strReportType == "Completed Tasks")
                                    {
                                        intWork = 10;
                                    }
                                    else if (strReportType == "Overdue Tasks")
                                    {
                                        intWork = 12;
                                    }
                                    else if (strReportType == "Daily Progress")
                                    {
                                        intWork = 17;
                                    }
                                    else if (strReportType == "Previous Day Progress")
                                    {
                                        intWork = 21;
                                    }
                                    else if (strReportType == "Last 7 Days Progress")
                                    {
                                        intWork = 25;
                                    }
                                    else if (strReportType == "Next Day Overdue Task List")
                                    {
                                        intWork = 26;
                                    }
                                }
                            }

                            intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                            //intEnroll = 1459;

                            dt = new DataTable();
                            dt = objtask.GetTaskReport2(intWork, intEnroll, intSearchEnroll);
                            dgvReport.DataSource = dt;
                            dgvReport.DataBind();

                            if (dt.Rows.Count > 0)
                            {
                                lblReportName.Visible = true;

                                //if (intWork == 1 || intWork == 5 || intWork == 7 || intWork == 11)
                                //{ dgvReport.Columns[0].Visible = true; dgvReport.Columns[1].Visible = true; }
                                //else { dgvReport.Columns[0].Visible = true; dgvReport.Columns[1].Visible = false; }

                                dgvReport.Columns[0].Visible = true;
                                dgvReport.Columns[1].Visible = true;

                                if (rdoAssignedBy.Checked == true) { dgvReport.Columns[8].Visible = false; dgvReport.Columns[7].Visible = true; }
                                else { dgvReport.Columns[8].Visible = true; dgvReport.Columns[7].Visible = false; }

                            }
                            else { lblReportName.Visible = false; }
                        }
                        else
                        {
                            //char[] chall = { '[', ']' };
                            //string[] temp2 = txtAllTask.Text.Split(chall, StringSplitOptions.RemoveEmptyEntries);
                            //try { intEnroll = int.Parse(temp2[1].ToString()); }
                            //catch { intEnroll = 0; }

                            intEnroll = int.Parse(ddlTeamM3.SelectedValue.ToString());

                            intSearchEnroll = 0;
                            intWork = 13;

                            dt = new DataTable();
                            dt = objtask.GetTaskReport2(intWork, intEnroll, intSearchEnroll);
                            dgvReport.DataSource = dt;
                            dgvReport.DataBind();

                            if (dt.Rows.Count > 0)
                            {
                                lblReportName.Visible = true;
                                dgvReport.Columns[8].Visible = false;
                                dgvReport.Columns[7].Visible = true;
                                dgvReport.Columns[0].Visible = false;
                                dgvReport.Columns[1].Visible = false;

                                //if (rdoAssignedBy.Checked == true) { dgvReport.Columns[8].Visible = false; dgvReport.Columns[7].Visible = true; }
                                //else { dgvReport.Columns[8].Visible = true; dgvReport.Columns[7].Visible = false; }

                            }
                            else { lblReportName.Visible = false; }
                        }
                    }
                    //***************************************************************************************************************
                }
            }
            catch { }
        }

        protected void btnNewTask_Click(object sender, EventArgs e)
        {
            string senderdata = "0";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "NewTask('" + senderdata + "');", true);
            lblReportName.Visible = false;
        }

        protected void btnOpen_Click(object sender, EventArgs e) 
        {
            //try
            //{
            string senderdata = ((Button)sender).CommandArgument.ToString();

            if (rdoAssignedBy.Checked == true)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "UpdateTask('" + senderdata + "');", true);                
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DeadlineChange('" + senderdata + "');", true);
            }

            //string strSearchKey = senderdata;
            //string[] searchKey = Regex.Split(strSearchKey, ",");

            //string intccid = searchKey[0];
            //string intmrrno = searchKey[1];
            //string dtemrrdate = searchKey[2];

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewDocList('" + strDate + "','" + strTodate + "','" + hdUnit + "','" + enrol + "');", true);
            ////////ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "MRDetailsReport('" + intccid + "','" + intmrrno + "','" + dtemrrdate + "');", true);
           
        }

        protected void btnDetails_Click(object sender, EventArgs e) 
        {             
            string senderdata = ((Button)sender).CommandArgument.ToString();

            intID = int.Parse(senderdata.ToString());
            intCount = 0;

            ////dt = new DataTable();
            ////dt = objtask.GetCountDetailsByTask(intID);
            ////if (dt.Rows.Count > 0)
            ////{intCount = int.Parse(dt.Rows[0]["intCountDetails"].ToString()); }            

            //if (intCount > 0)
            //{
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TaskDetails('" + senderdata + "');", true);
            //}
            //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There are no update in this task.');", true); return; }
        }

        protected void rdoAssignedBy_CheckedChanged(object sender, EventArgs e) 
        {
            if (rdoAssignedBy.Checked == true) { rdoAssignedTo.Checked = false; } else { rdoAssignedBy.Checked = true; }
            dgvReport.DataSource = "";
            dgvReport.DataBind();
            lblReportName.Visible = false;

            LoadGrid(); 
        }
        protected void rdoAssignedTo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAssignedTo.Checked == true) { rdoAssignedBy.Checked = false; } else { rdoAssignedTo.Checked = true; }
            dgvReport.DataSource = "";
            dgvReport.DataBind();
            lblReportName.Visible = false;

            LoadGrid(); 
        }
              
        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid(); 
        }

        protected void txtAssignBy_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
            //GetResult();
        }

        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void txtAllTask_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void GetResult()
        {
            if (txtAssignBy.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtAssignBy.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                //strSuppCodeNo = temp[temp.Length - 1];
                //string strName = temp[0];

                //hdnCustomer.Value = temp[temp.Length - 1];
                //hdnCustomerText.Value = temp[0];
            }
        }

        protected void btnPicUpload_Click(object sender, EventArgs e)
        {
            string senderdata = "0";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "PicUpload('" + senderdata + "');", true);            
        }

        protected void btnDocVew_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();

            intID = int.Parse(senderdata.ToString());
            intCount = 0;

            dt = new DataTable();
            dt = objtask.GetMyDocCheckCount(intID);
            if (dt.Rows.Count > 0)
            {
                intCount = int.Parse(dt.Rows[0]["intDocCount"].ToString());
            }

            if (intCount > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocListView('" + senderdata + "');", true);
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There are no document attach in this task.');", true); return; }
        }

        protected void cbMyTeam_CheckedChanged(object sender, EventArgs e)
        {
            if(cbMyTeam.Checked == true)
            {
                txtAssignBy.Visible = false;
                txtSearchAssignedTo.Visible = false;
                txtAllTask.Visible = false;
                ddlTeamM1.Visible = true;
                ddlTeamM2.Visible = true;
                ddlTeamM3.Visible = true;

                ddlTeamM1.SelectedValue = "0";
                ddlTeamM2.SelectedValue = "0";
                ddlTeamM3.SelectedValue = "0";
            }
            else
            {
                txtAssignBy.Visible = true;
                txtSearchAssignedTo.Visible = true;
                txtAllTask.Visible = true;
                ddlTeamM1.Visible = false;
                ddlTeamM2.Visible = false;
                ddlTeamM3.Visible = false;
            }
        }

        protected void ddlTeamM1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void ddlTeamM2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void ddlTeamM3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           try
            {
                if (dgvReport.Rows.Count > 0)
                {
                    e.Row.Attributes.Add("onmouseover",
                    "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    for (int index = 0; index < dgvReport.Rows.Count; index++)
                    {
                        intID = int.Parse(((Label)dgvReport.Rows[index].FindControl("lblTaskID")).Text.ToString());

                        //*** For Details Button Start ********************************************************
                        //////dt = new DataTable();
                        //////dt = objtask.GetUpdateRowCountDataByDetails(intID);                        
                        //////if (dt.Rows.Count > 0)
                        //////{ intCount = int.Parse(dt.Rows[0]["UpdateCount"].ToString()); }

                        //////////////////dt = new DataTable();
                        //////////////////dt = objtask.GetCountWorkPlan(intID);
                        //////////////////if (dt.Rows.Count > 0)
                        //////////////////{ intCheck = int.Parse(dt.Rows[0]["intWPCount"].ToString()); }

                        intCheck = int.Parse(((Label)dgvReport.Rows[index].FindControl("lblWP")).Text.ToString());

                        if (intCheck == 0)
                        {
                            ((Button)dgvReport.Rows[index].FindControl("btnDetails")).Visible = false;
                        }
                        else { ((Button)dgvReport.Rows[index].FindControl("btnDetails")).Visible = true; }

                        //*** For Details Button End ********************************************************
                        //*** For Complete Button Start ********************************************************
                        if (rdoAssignedTo.Checked == true)
                        {
                            //////////dt = new DataTable();
                            //////////dt = objtask.GetCompletePerCheck(intID);

                            //////////if (dt.Rows.Count > 0)
                            //////////{
                            //////////    intCount = int.Parse(dt.Rows[0]["intCompletePer"].ToString());

                            intCount = int.Parse(((Label)dgvReport.Rows[index].FindControl("lblComp")).Text.ToString());

                            if (intCount == 100)
                            {
                                ((Button)dgvReport.Rows[index].FindControl("btnComplete")).Visible = true;
                            }
                            else { ((Button)dgvReport.Rows[index].FindControl("btnComplete")).Visible = false; }
                            //////////}

                            //***********************************************************************************

                            //*** Deadline Change Request
                            //////////dt = new DataTable();
                            //////////dt = objtask.GetDReqCount(intID);                            
                            //////////if (dt.Rows.Count > 0)
                            //////////{
                            //////////    intReqCheck = int.Parse(dt.Rows[0]["DeadlineReqCount"].ToString());

                            intReqCheck = int.Parse(((Label)dgvReport.Rows[index].FindControl("lblDReq")).Text.ToString());
                            if (intReqCheck == 0)
                            {
                                ((Button)dgvReport.Rows[index].FindControl("btnDchangeReq")).Visible = false;
                            }
                            else { ((Button)dgvReport.Rows[index].FindControl("btnDchangeReq")).Visible = true; }

                                //////////}
                            
                            //else { ((Button)dgvReport.Rows[index].FindControl("btnDchangeReq")).Visible = false; }
                            //*** For Complete Button End ********************************************************

                        }
                        else
                        {
                            ((Button)dgvReport.Rows[index].FindControl("btnComplete")).Visible = false;
                            ((Button)dgvReport.Rows[index].FindControl("btnDchangeReq")).Visible = false;
                        }

                        //===============================================================
                        string strStatusForColor = ((Label)dgvReport.Rows[index].FindControl("lblStatusForColor")).Text;
                        ////////e.Row.Attributes.Add("onmouseover",
                        ////////"this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                        ////////e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                        
                        if (strStatusForColor == "Defereed")
                        {
                            dgvReport.Rows[index].BackColor = System.Drawing.Color.Red;
                        }
                        else if (strStatusForColor == "Completed")
                        {
                            dgvReport.Rows[index].BackColor = System.Drawing.Color.Green;
                        }
                        else if (strStatusForColor == "In Progress")
                        {
                            dgvReport.Rows[index].BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (strStatusForColor == "Not Started")
                        {
                            dgvReport.Rows[index].BackColor = System.Drawing.Color.Yellow;
                        }

                        //===================================================================


                    }
                }
            }
            catch { }

            //***********************************************************************************
            //try
            //{
            //    if (dgvReport.Rows.Count > 0)
            //    {
            //        for (int index = 0; index < dgvReport.Rows.Count; index++)
            //        {
            //            intID = int.Parse(((Label)dgvReport.Rows[index].FindControl("lblTaskID")).Text.ToString());

            //            //*** For Complete Button Start ********************************************************
            //            if (rdoAssignedTo.Checked == true)
            //            {
            //                dt = new DataTable();
            //                dt = objtask.GetCompletePerCheck(intID);

            //                if (dt.Rows.Count > 0)
            //                {
            //                    int intCount = int.Parse(dt.Rows[0]["intCompletePer"].ToString());

            //                    if (intCount == 100)
            //                    {
            //                        ((Button)dgvReport.Rows[index].FindControl("btnComplete")).Visible = true;
            //                    }
            //                    else { ((Button)dgvReport.Rows[index].FindControl("btnComplete")).Visible = false; }
            //                }
            //            }
            //            else { ((Button)dgvReport.Rows[index].FindControl("btnComplete")).Visible = false; }
            //            //*** For Complete Button End ********************************************************

            //        }
            //    }
            //}
            //catch { }
        }


        protected void btnComplete_Click(object sender, EventArgs e) 
        {
            //if (hdnconfirm.Value == "1")
            //{
                try
                {
                    string senderdata = ((Button)sender).CommandArgument.ToString();
                    intID = int.Parse(senderdata.ToString());
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TaskComplete('" + senderdata + "');", true);
                    
                    //Final Insert
                    /////string message = objtask.UpdateTaskComplete(intID);
                    ////ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ////LoadGrid();
                }
                catch { }
            //}
        }

        protected void btnDchangeReq_Click(object sender, EventArgs e) 
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();

                intID = int.Parse(senderdata.ToString());
                
                ////dt = new DataTable();
                ////dt = objtask.GetCountDetailsByTask(intID);
                ////if (dt.Rows.Count > 0)
                ////{intCount = int.Parse(dt.Rows[0]["intCountDetails"].ToString()); }            

                //if (intCount > 0)
                //{
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DeadlineChange('" + senderdata + "');", true);
            }
            catch { }
        }
       
        //******************************************************************************

        //protected void txtSearchSupp_TextChanged(object sender, EventArgs e)
        //{
        //    GetResult();
        //}

        //private void GetResult()
        //{
        //    if (txtSearchSupp.Text.Trim() != "")
        //    {
        //        char[] ch = { '[', ']' };
        //        string[] temp = txtSearchSupp.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
        //        strSuppCodeNo = temp[temp.Length - 1];
        //        string strName = temp[0];

        //        //hdnCustomer.Value = temp[temp.Length - 1];
        //        //hdnCustomerText.Value = temp[0];
        //    }
        //}
       
        //intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
        //intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());

        //intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
        //        intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
        //        intCheck = int.Parse(ddlReportType.SelectedValue.ToString());

        //        HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
        //        HttpContext.Current.Session["intShipPointID"] = intShipPointID.ToString();
        //        HttpContext.Current.Session["intCheck"] = intCheck.ToString();
















    }
}