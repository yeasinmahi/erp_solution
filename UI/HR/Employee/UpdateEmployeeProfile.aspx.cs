using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using HR_BLL.Employee;
using UI.ClassFiles;
using System.IO;
using System.Net;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Employee
{
    public partial class UpdateEmployeeProfile : BasePage //System.Web.UI.Page
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <16-01-2013>
        Description: <Update Employee Profile>
        =============================================*/
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Employee/UpdateEmployeeProfile.aspx";
        string stop = "stopping HR/Employee/UpdateEmployeeProfile.aspx";

        string alertMessage = ""; int intActive; int intHold; string photofile; string filePath; string documentfile;
        EmployeeRegistration bll = new EmployeeRegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/UpdateEmployeeProfile.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            filePath = Server.MapPath("~/HR/Employee/Upload/");
            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                    txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                    hdnAction.Value = "0"; photo.Visible = false;

                    DataTable dt = new DataTable();
                    dt = bll.GetFlorrList();
                    ddlFloorAccess.DataSource = dt;
                    ddlFloorAccess.DataTextField = "strName";
                    ddlFloorAccess.DataValueField = "intID";
                    ddlFloorAccess.DataBind();
                }
                else
                {
                    
                    if (hdnAction.Value != "0") { UpdateProfile(); }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                        {
                            string strSearchKey = txtEmployeeSearch.Text;
                            string[] searchKey = Regex.Split(strSearchKey, ",");
                            hdfEmpCode.Value = searchKey[1];
                            if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                            {
                                LoadFieldValue(searchKey[1]);
                                hdfSearchBoxTextChange.Value = "false";
                                photo.Visible = true;
                            }
                        }
                        else
                        {
                            ClearControls();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
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
        
        private void LoadFieldValue(string empCode)
        {
            var fd = log.GetFlogDetail(start, location, "LoadFieldValue", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/UpdateEmployeeProfile.aspx LoadFieldValue", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDT.Rows.Count > 0)
                    {
                        ddlUnit.DataBind();
                        /*=================================================================*/
                        string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + objDT.Rows[0]["strEmpImageUrl"].ToString();
                        photo.ImageUrl = imageUrl;
                        txtJobStatus.Text = objDT.Rows[0]["strJobType"].ToString();
                        txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                        txtStation.Text = objDT.Rows[0]["strJobStationName"].ToString();
                        txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                        txtShiftStatus.Text = objDT.Rows[0]["strTeamName"].ToString();
                        txtCurrentShift.Text = objDT.Rows[0]["strShiftName"].ToString();
                        /*==================================================================*/
                        txtFullName.Text = objDT.Rows[0]["strEmployeeName"].ToString();
                        txtEmail.Text = objDT.Rows[0]["strOfficeEmail"].ToString();
                        if (!String.IsNullOrEmpty(objDT.Rows[0]["intReligionID"].ToString()))
                        {
                            ddlReligion.SelectedValue = objDT.Rows[0]["intReligionID"].ToString();
                        }
                        if (!String.IsNullOrEmpty(objDT.Rows[0]["intDayOffId"].ToString()))
                        {
                            ddlOffDay.SelectedValue = objDT.Rows[0]["intDayOffId"].ToString();
                        }
                        ddlGroup.SelectedValue = objDT.Rows[0]["intGroupID"].ToString();
                        ddlUnit.SelectedValue = objDT.Rows[0]["intUnitID"].ToString();
                        ddlJobStation.DataBind();
                        ddlJobStation.SelectedValue = objDT.Rows[0]["intEmployeeJobStationId"].ToString();
                        ddlJobStatus.DataBind();
                        ddlJobStatus.SelectedValue = objDT.Rows[0]["intJobTypeID"].ToString();
                        ddlDepartment.SelectedValue = objDT.Rows[0]["intDepartmentID"].ToString();
                        ddlDesignation.SelectedValue = objDT.Rows[0]["intDesignationID"].ToString();
                        ddlDutyCategory.SelectedValue = objDT.Rows[0]["intDutyCatID"].ToString();
                        txtContact.Text = objDT.Rows[0]["strContactPeriod"].ToString();

                        //ddlShiftStatus.DataBind();
                        //ddlShiftStatus.SelectedValue = objDT.Rows[0]["intTeamId"].ToString();
                        //ddlPresentShift.DataBind();
                        //ddlPresentShift.SelectedValue = objDT.Rows[0]["intShiftId"].ToString();
                        //txtBankName.Text = objDT.Rows[0]["strBankName"].ToString();txtBranchName.Text = 

                        ddlBank.DataBind();
                        if (!String.IsNullOrEmpty(objDT.Rows[0]["intBankID"].ToString()))
                        { ddlBank.SelectedValue = objDT.Rows[0]["intBankID"].ToString(); }

                        ddlDistrict.DataBind();
                        if (!String.IsNullOrEmpty(objDT.Rows[0]["intDistrictID"].ToString()))
                        { ddlDistrict.SelectedValue = objDT.Rows[0]["intDistrictID"].ToString(); }

                        
                        if (!String.IsNullOrEmpty(objDT.Rows[0]["intBranchID"].ToString()))
                        { ddlBranch.DataBind(); ddlBranch.SelectedValue = objDT.Rows[0]["intBranchID"].ToString(); }

                        txtAccountNo.Text = objDT.Rows[0]["strBankAccountNo"].ToString();
                        monSalary.Text = objDT.Rows[0]["monSalary"].ToString();
                        monBasic.Text = objDT.Rows[0]["monBasic"].ToString();
                        txtContactNo.Text = objDT.Rows[0]["strContactNo1"].ToString();

                        txtPermanentAddress.Text = objDT.Rows[0]["strPermanentAddress"].ToString();
                        txtPresentAddress.Text = objDT.Rows[0]["strPresentAddress"].ToString();
                        txtReportingBoss.Text = objDT.Rows[0]["strEmployeeCode"].ToString();
                        string strActive = objDT.Rows[0]["ysnActive"].ToString();
                        string strSalaryhold = objDT.Rows[0]["ysnSalaryHold"].ToString();
                        txtDOB.Text = DateTime.Parse(objDT.Rows[0]["dteBirth"].ToString()).ToString("yyyy-MM-dd");

                        ddlFloorAccess.DataBind();
                        if (!String.IsNullOrEmpty(objDT.Rows[0]["strFloorAccess"].ToString()))
                        { ddlFloorAccess.SelectedValue = objDT.Rows[0]["strFloorAccess"].ToString(); }

                        if (strActive.ToUpper() == "TRUE")
                        { chkActive.Checked = true; }
                        else { chkActive.Checked = false; }

                        if (strSalaryhold.ToUpper() == "TRUE")
                        { chkHold.Checked = true; }
                        else { chkHold.Checked = false; }
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "LoadFieldValue", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "LoadFieldValue", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void UpdateProfile()
        {
            var fd = log.GetFlogDetail(start, location, "UpdateProfile", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/UpdateEmployeeProfile.aspx UpdateProfile", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                string empCode = hdfEmpCode.Value;
                string fullname = txtFullName.Text;
                string email = txtEmail.Text;
                int religionid = int.Parse(ddlReligion.SelectedValue);
                int dayoffid = int.Parse(ddlOffDay.SelectedValue);
                int groupid = int.Parse(ddlGroup.SelectedValue);
                int unitid = int.Parse(ddlUnit.SelectedValue);
                int stationid = int.Parse(ddlJobStation.SelectedValue);
                int jobtypeid = int.Parse(ddlJobStatus.SelectedValue);
                int departmentid = int.Parse(ddlDepartment.SelectedValue);
                int designationid = int.Parse(ddlDesignation.SelectedValue);
                int dutycategoryid = int.Parse(ddlDutyCategory.SelectedValue);
                string contactperiod = txtContact.Text;
                string bankname = ddlBank.SelectedItem.ToString();
                string branchname = ddlBranch.SelectedItem.ToString() + "," + ddlDistrict.SelectedItem.ToString();

                int bank = int.Parse(ddlBank.SelectedValue.ToString());
                int branch = int.Parse(ddlBranch.SelectedValue.ToString());
                int dist = int.Parse(ddlDistrict.SelectedValue.ToString());

                string accountno = txtAccountNo.Text;
                decimal totalsalary = decimal.Parse(monSalary.Text);
                decimal basicsalary = decimal.Parse(monBasic.Text);
                string contactno = txtContactNo.Text;
                string permanentAdd = txtPermanentAddress.Text;
                string presentAdd = txtPresentAddress.Text;
                if (chkActive.Checked == true) { intActive = 1; }
                else { intActive = 0; }
                if (chkHold.Checked == true) { intHold = 1; }
                else { intHold = 0; }
                string supervisor = txtReportingBoss.Text;
                int loginUserID = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string strFloorAccess = ddlFloorAccess.SelectedValue.ToString();
                
                HR_BLL.Employee.EmployeeRegistration empUpdate = new HR_BLL.Employee.EmployeeRegistration();
                UploadPhotoDocumentToFTP();
                string documenttype = ddlDocumentType.SelectedValue.ToString();
                DateTime dob = DateTime.Parse(txtDOB.Text);

                alertMessage = empUpdate.UpdateEmployeeProfile(empCode, fullname, email, religionid,dayoffid,groupid,unitid,stationid,jobtypeid,
                departmentid, designationid, dutycategoryid, contactperiod, bankname, branchname, accountno, totalsalary,basicsalary,
                contactno, permanentAdd, presentAdd, intActive, intHold, supervisor, "/EmployeeInformation/" + photofile,
                "/EmployeeInformation/" + documentfile, documenttype, loginUserID, bank, branch, dist, dob, strFloorAccess);
                hdnAction.Value = "0";

                if (alertMessage != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                    ClearControls(); 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to update this employee !!!');", true);
                }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "UpdateProfile", ex);
                Flogger.WriteError(efd);
                throw ex;
            }

            fd = log.GetFlogDetail(stop, location, "UpdateProfile", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void UploadPhotoDocumentToFTP()
        {
            var fd = log.GetFlogDetail(start, location, "UploadPhotoDocumentToFTP", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/UpdateEmployeeProfile.aspx UploadPhotoDocumentToFTP", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                photofile = "EmployeePhoto_" + Session[SessionParams.USER_ID].ToString() + Path.GetExtension(photoUpload.FileName);
                HttpPostedFile http = photoUpload.PostedFile;
                int length = http.ContentLength;
                byte[] photoData = new byte[length];
                http.InputStream.Read(photoData, 0, length);
                FileStream photoFile = new FileStream(filePath + photofile, FileMode.Create);
                photoFile.Write(photoData, 0, photoData.Length);
                photoFile.Close();
                WebClient wcp = new WebClient();
                Uri uriphotoadd = new Uri("ftp://ftp.akij.net/EmployeeInformation/" + photofile);
                wcp.Credentials = new NetworkCredential("erp@akij.net", "erp123");
                wcp.UploadFile(uriphotoadd, filePath + photofile);
                File.Delete(filePath + photofile);

                //============ Document Upload =================

                documentfile = "Document_" + Session[SessionParams.USER_ID].ToString() + Path.GetExtension(documentUpload.FileName);
                HttpPostedFile htp = documentUpload.PostedFile;
                int len = htp.ContentLength;
                byte[] myData = new byte[len];
                htp.InputStream.Read(myData, 0, len);
                FileStream newFile = new FileStream(filePath + documentfile, FileMode.Create);
                newFile.Write(myData, 0, myData.Length);
                newFile.Close();
                WebClient wc = new WebClient();
                Uri uriadd = new Uri("ftp://ftp.akij.net/EmployeeInformation/" + documentfile);
                wc.Credentials = new NetworkCredential("erp@akij.net", "erp123");
                wc.UploadFile(uriadd, filePath + documentfile);
                File.Delete(filePath + documentfile);
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "UploadPhotoDocumentToFTP", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnCancel_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/UpdateEmployeeProfile.aspx btnCancel_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnCancel_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnCancel_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void ClearControls()
        {
            txtEmployeeSearch.Text = ""; hdfEmpCode.Value = ""; txtJobStatus.Text = ""; txtUnit.Text = ""; txtStation.Text = "";
            txtDepartment.Text = ""; txtDesignation.Text = ""; txtShiftStatus.Text = ""; txtCurrentShift.Text = ""; txtDOB.Text = "";

            txtFullName.Text = ""; txtEmail.Text = ""; ddlReligion.DataBind(); ddlOffDay.DataBind(); ddlGroup.DataBind();
            ddlUnit.DataBind(); ddlJobStation.DataBind(); ddlJobStatus.DataBind(); ddlDepartment.DataBind(); ddlDesignation.DataBind();
            ddlDutyCategory.DataBind(); txtContact.Text = "";//ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();txtBankName.Text = ""; txtBranchName.Text = "";

            ddlBank.DataBind(); ddlDistrict.DataBind(); ddlBranch.DataBind(); txtAccountNo.Text = ""; monSalary.Text = ""; monBasic.Text = "";
            txtContactNo.Text = ""; txtPermanentAddress.Text = ""; txtPresentAddress.Text = ""; txtReportingBoss.Text = "";  chkActive.Checked = false;
            chkHold.Checked = false; photo.Visible = false;
            //ddlFloorAccess.Text = "";
        }

        

        




















    }
}