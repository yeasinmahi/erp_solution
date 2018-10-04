using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using UI.ClassFiles;
using System.IO;
using System.Net;
using System.Data;
using HR_BLL.Employee;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Employee
{
    public partial class NewEmployeeReg : BasePage //System.Web.UI.Page //
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <10-01-2013>
        Description: <New Employee Registration>
        =============================================*/
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Employee/NewEmployeeReg.aspx";
        string stop = "stopping HR/Employee/NewEmployeeReg.aspx";

        string alertMessage = ""; string photofile; string filePath; string documentfile;
        EmployeeRegistration bll = new EmployeeRegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/NewEmployeeReg.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            filePath = Server.MapPath("~/HR/Employee/Upload/");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtReportingBoss.Attributes.Add("onkeyUp", "SearchText();");
                hdnField.Value = "0";

                DataTable dt = new DataTable();
                dt = bll.GetFlorrList();
                ddlFloorAccess.DataSource = dt;
                ddlFloorAccess.DataTextField = "strName";
                ddlFloorAccess.DataValueField = "intID";
                ddlFloorAccess.DataBind();
            }
            else {

                if (hdnField.Value != "0") { Submit(); }
                else { }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region --Dropdown list index change and Employee auto search--
        
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ShowOfficialInfo();", true);
            ddlJobStation.DataBind(); ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();
        }
        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ShowOfficialInfo();", true);
        }
        protected void ddlJobStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ShowOfficialInfo();", true);
        }
        protected void ddlShiftStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ShowOfficialInfo();", true);
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ShowSalaryInfo();", true);
        }
        #endregion

        public void Submit()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/NewEmployeeReg.aspx Submit", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                HR_BLL.Employee.EmployeeRegistration empRegistration = new HR_BLL.Employee.EmployeeRegistration();

                string fullname = txtFullName.Text; 
                string shortname = txtShortName.Text;
                string nationalId = txtNationalId.Text; 
                string contact = txtContactNo.Text;
                string bloodGroup = txtBloodGroup.Text;
                string factorycode = txtFactoryCode.Text;
                int intReligion = int.Parse(ddlReligion.SelectedValue.ToString());
                string empEmail = txtEmail.Text;
                string presentAdd = txtPresentAddress.Text;
                int dayOffId = int.Parse(ddlOffDay.SelectedValue.ToString());
                string gender = ddlGender.SelectedValue.ToString();
                string permanentAdd = txtPermanentAddress.Text;

                int groupId = int.Parse(ddlGroup.SelectedValue.ToString());
                int unitId = int.Parse(ddlUnit.SelectedValue.ToString());
                int jobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                int jobType = int.Parse(ddlJobStatus.SelectedValue.ToString());
                int designationID = int.Parse(ddlDesignation.SelectedValue.ToString());
                int departmentID = int.Parse(ddlDepartment.SelectedValue.ToString());
                int dutyCategoryID = int.Parse(ddlDutyCategory.SelectedValue.ToString());
                string contactPeriod = txtContact.Text;
                int teamID = int.Parse(ddlShiftStatus.SelectedValue.ToString());
                int presentShiftID = int.Parse(ddlPresentShift.SelectedValue.ToString());
                DateTime  appointmentDate= DateTime.Now.Date;//DateTime.Parse("");txtJoinDate.Text
                DateTime joinDate = DateTime.Parse(txtJoiningDate.Text);
                DateTime dob = DateTime.Parse(txtDOB.Text);
                string superviser = txtReportingBoss.Text;
                string[] spltData = superviser.Split(',');
                string superviserCode = spltData[1].ToString();
                string strFloorAccess = ddlFloorAccess.SelectedValue.ToString();

                string bankName = ddlBank.SelectedItem.ToString();
                string bankBranch = ddlBranch.SelectedItem.ToString() + "," + ddlDistrict.SelectedItem.ToString();

                int bank = int.Parse(ddlBank.SelectedValue.ToString());
                int branch = int.Parse(ddlBranch.SelectedValue.ToString());
                int dist = int.Parse(ddlDistrict.SelectedValue.ToString());

                string bankAccountNo = txtAccountNo.Text;
                decimal salTotal = decimal.Parse(monSalary.Text);
                //decimal salBasic = decimal.Parse(monBasic.Text);
                //string paymenttype = ddlPaymentType.SelectedValue.ToString(); 
                UploadPhotoDocumentToFTP();
                string documenttype = ddlDocumentType.SelectedValue.ToString();
                int loginUserID = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());//1396;//  salBasic, paymenttype, 
                alertMessage = empRegistration.InsertEmpRegistration(fullname, shortname, nationalId, contact, bloodGroup, factorycode, intReligion, empEmail,
                presentAdd, dayOffId, gender, permanentAdd, groupId, unitId, jobStationID, jobType, designationID, departmentID, dutyCategoryID, contactPeriod,
                teamID, presentShiftID, joinDate, appointmentDate, superviserCode, strFloorAccess, bankName, bankBranch, bankAccountNo, salTotal, "/EmployeeInformation/" + photofile,
                "/EmployeeInformation/" + documentfile, documenttype, loginUserID, bank, branch, dist, dob);
                if (alertMessage != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                    ClearControls();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to register this employee !!!');", true);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void UploadPhotoDocumentToFTP()
        {
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
        }
        public void ClearControls()
        {
            txtFullName.Text = ""; txtShortName.Text = ""; txtNationalId.Text = ""; txtContactNo.Text = ""; txtBloodGroup.Text = "";
            txtFactoryCode.Text = ""; ddlReligion.DataBind(); txtEmail.Text = ""; txtPresentAddress.Text = ""; ddlOffDay.DataBind();
            ddlGender.DataBind(); txtPermanentAddress.Text = ""; txtDOB.Text = "";

            ddlGroup.DataBind(); ddlUnit.DataBind(); ddlJobStation.DataBind(); ddlJobStatus.DataBind(); ddlDesignation.DataBind();
            ddlDepartment.DataBind(); ddlDutyCategory.DataBind(); txtContact.Text = ""; ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();
            txtJoiningDate.Text = ""; txtReportingBoss.Text = ""; ddlBank.DataBind(); ddlDistrict.DataBind(); ddlBranch.DataBind();//txtAppointmentDate.Text = ""; 

            hdnField.Value = "0"; txtAccountNo.Text = ""; monSalary.Text = "";
            //txtBankName.Text = ""; txtBranchName.Text = ""; monBasic.Text = "";ddlPaymentType.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ShowBasicInfo();", true);
        }

        
                
    }
}