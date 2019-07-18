using BLL.AutoSearch;
using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.HR.Employee
{
    public partial class PubEmployeeFullInformation : BasePage
    {
        private EmployeeFullInformationBll _bll = new EmployeeFullInformationBll();
        private DataTable _dt = new DataTable();

        public static EmployeeBll employeeBll;
        string[] arrayKey;
        char[] delimiterChars = { '[', ']' };
        int EmpID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                employeeBll = new EmployeeBll();

                LoadDepartment();
                LoadDesignation();
                LoadLevelOfEducation();
                LoadResult();
                LoadExam();
                LoadBoard();
                LoadYearOfPassing();
                LoadCountry();
                LoadTrainigYear();

                
            }
        }
        #region Tab 1: Personal Info
        private void LoadDepartment()
        {
            _dt = _bll.GetDepartment();
            ddlPresentDepartment.Loads(_dt, "intDepartmentID", "strDepatrment");
        }
        private void LoadDesignation()
        {
            _dt = _bll.GetDesignation();
            ddlJoiningDesignation.Loads(_dt, "intDesignationID", "strDesignation");
            ddlPresentDesignation.Loads(_dt, "intDesignationID", "strDesignation");
        }
        protected void btnInsertPersonalInfo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            string code = txtCode.Text;
            string name = txtName.Text;
            string fathersName = txtFatherName.Text;
            string mothersName = txtMotherNmae.Text;
            string permanentAddress = txtPermanetAddress.Text;
            string presentAddress = txtPresentAddress.Text;
            string nid = txtNidNo.Text;
            string mobileNo = txtMobileNo.Text;
            DateTime? promotionDate = null;
            if (!DateTime.TryParseExact(txtPromotionDate.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime proDate))
            {
                promotionDate = null;
            }
            else
            {
                promotionDate = proDate;
            }
            int presentDepartmentId = ddlPresentDepartment.SelectedValue();
            string presentDepartment = ddlPresentDepartment.SelectedText();
            int presentDesignationId = ddlPresentDesignation.SelectedValue();
            string presentDesignation = ddlPresentDesignation.SelectedText();
            if (!decimal.TryParse(txtPresentSalary.Text, out decimal presentSalry))
            {
                Toaster("Please Enter Present Salary Properly");
                return;
            }
            if (!DateTime.TryParseExact(txtJoiningDate.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime joiningDate))
            {
                Toaster("Please Enter Joining Date Format Properly");
                return;
            }
            int joiningDesignationId = ddlJoiningDesignation.SelectedValue();
            string joiningDesignation = ddlJoiningDesignation.SelectedText();
            if (!decimal.TryParse(txtJoiningSalary.Text, out decimal joiningSalary))
            {
                Toaster("Please Enter Joining Salary Properly");
                return;
            }
            string akijResponsibilities = txtAkijResponsibilities.Text;
            string previousOrganization = txtPreviousOrganization.Text;
            string previousDesignation = txtPreviousDesignation.Text;
            decimal.TryParse(txtPreviousSalary.Text, out decimal previousSalary);

            string message = _bll.Insert(enroll, code, name, fathersName, mothersName, permanentAddress, presentAddress, nid, promotionDate, presentDesignationId, presentDesignation, presentDepartmentId, presentDepartment, presentSalry, joiningDate, joiningDesignationId, joiningDesignation, joiningSalary, akijResponsibilities, previousOrganization, previousDesignation, previousSalary, Enroll);
            if (message.ToLower().Contains("success"))
            {
                Toaster(message, Common.TosterType.Success);
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }

        public void LoadEmployeeInfo()
        {
            if (!String.IsNullOrEmpty(txtEmployeeName.Text))
            {
                arrayKey = txtEmployeeName.Text.Split(delimiterChars);

                if (arrayKey.Length > 0)
                {
                    EmpID = Convert.ToInt32(arrayKey[1].ToString());
                    LoadFieldValue(Convert.ToInt32(arrayKey[1].ToString()));
                }
                else
                {
                    Toaster("Your Employee Name Format Error", Common.TosterType.Warning);
                }
            }
        }

        private void LoadFieldValue(int enroll)
        {
            try
            {
                if (enroll>0)
                {
                    _dt = _bll.GetEmployeeInfo(enroll);
                    if (_dt.Rows.Count > 0)
                    {
                        txtEnroll.Text = enroll.ToString();
                        txtCode.Text = _dt.GetValue<string>("strEmployeeCode");
                        txtName.Text = _dt.GetValue<string>("strEmployeeName");
                        txtEmail.Text = _dt.GetValue<string>("strOfficeEmail");
                        txtPermanetAddress.Text = _dt.GetValue<string>("strPermanentAddress");
                        txtPresentAddress.Text = _dt.GetValue<string>("strPresentAddress");
                        txtMobileNo.Text = _dt.GetValue<string>("strContactNo1");
                        txtNidNo.Text = _dt.GetValue<string>("strNationalId");
                        ddlPresentDesignation.SetSelectedValue(_dt.GetValue<string>("intDesignationID"));
                        ddlPresentDepartment.SetSelectedValue(_dt.GetValue<string>("intDepartmentID"));
                        txtPresentSalary.Text = _dt.GetValue<string>("monSalary");
                        txtJoiningDate.Text = _dt.GetValue<string>("dteJoiningDate").ToDateTime().ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Employee Information Update", Common.TosterType.Error);
            }
        }

        protected void btnShowEmployeeInformation_Click(object sender, EventArgs e)
        {
            LoadEmployeeInfo();

            LoadEducation();
            LoadEmperience();
            LoadTrainingInfo();
            LoadWorkInfo();
            LoadImage();


            //string strEnroll = txtEmployeeName.Text;
            //string code = txtCode.Text;
            //if (string.IsNullOrWhiteSpace(strEnroll) && string.IsNullOrWhiteSpace(code))
            //{
            //    Toaster("Please input enroll or employee code");
            //    return;
            //}
            //if (!string.IsNullOrWhiteSpace(strEnroll))
            //{
            //    if (!int.TryParse(txtEnroll.Text, out int enroll))
            //    {
            //        Toaster("Please Enter Enroll Properly");
            //        return;
            //    }
            //    _dt = _bll.GetEmployeeInfo(enroll);
            //    if (_dt.Rows.Count > 0)
            //    {
            //        txtCode.Text = _dt.GetValue<string>("strEmployeeCode");
            //    }
            //    else
            //    {
            //        Toaster("No Employee Information Found Aginest This Enroll");
            //        return;
            //    }
            //}
            //else if (!string.IsNullOrWhiteSpace(code))
            //{
            //    _dt = _bll.GetEmployeeInfo(code);
            //    if (_dt.Rows.Count > 0)
            //    {
            //        txtEnroll.Text = _dt.GetValue<string>("intEmployeeID");
            //    }
            //    else
            //    {
            //        Toaster("No Employee Information Found Aginest This Code");
            //        return;
            //    }
            //}

        }
        public void LoadEmpInfo(DataTable dt)
        {
            if (_dt.Rows.Count > 0)
            {
                txtCode.Text = _dt.GetValue<string>("strEmployeeCode");
            }
            else
            {
                Toaster("No Employee Information Found");
                return;
            }
        }

        
        [WebMethod]
        public static string[] GetAutoCompleteData(string strSearchKey)
        {
            return employeeBll.GetAllEmployee(strSearchKey);
        }

        #endregion
        #region Tab 2: Education
        private void LoadLevelOfEducation()
        {
            _dt = _bll.GetLevelOfEducation();
            ddlLevelOfEducation.LoadWithSelect(_dt, "intEducationID", "strEducationName");
        }
        private void LoadResult()
        {
            _dt = _bll.GetGradeList();
            ddlResult.LoadWithSelect(_dt, "intResultID", "strResult");
        }
        private void LoadExam()
        {
            _dt = _bll.GetExamList(ddlLevelOfEducation.SelectedValue());
            ddlExam.LoadWithSelect(_dt, "intExamID", "strExamName");
        }
        private void LoadBoard()
        {
            _dt = _bll.GetEducationBoard();
            ddlBoard.LoadWithSelect(_dt, "intBoardID", "strBoard");
        }
        private void LoadYearOfPassing()
        {
            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                ListItem li = new ListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                ddlYearOfPassing.Items.Add(li);
            }
            ddlYearOfPassing.DataBind();
        }
        protected void btnAddEducationInfo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            int intEducationID = ddlLevelOfEducation.SelectedValue();
            string strEducationName = ddlLevelOfEducation.SelectedText();
            int intResultID = ddlResult.SelectedValue();
            string strResult = ddlResult.SelectedText();
            int intExamID = ddlExam.SelectedValue();
            string strExamName = ddlExam.SelectedText();
            decimal.TryParse(txtCgpa.Text, out decimal numCGPAMarks);
            decimal.TryParse(txtScale.Text, out decimal numScale);
            string strConcentrationMajorGroup = txtMajorGroup.Text;
            int intBoardID = ddlBoard.SelectedValue();
            string strBoard = ddlBoard.SelectedText();
            string strInstituteName = txtInstitude.Text;
            int intYearOfPassing = ddlYearOfPassing.SelectedValue();
            string strDurationYear = txtDuration.Text;
            string strAchievement = txtAchivement.Text;
            string message = _bll.InsertEdicationInfo(1, enroll, intEducationID, strEducationName, intResultID, strResult, intExamID, strExamName, numCGPAMarks, numScale, strConcentrationMajorGroup, intBoardID, strBoard, strInstituteName, intYearOfPassing, strDurationYear, strAchievement, Enroll, true, 0);
            if (message.ToLower().Contains("success"))
            {
                Toaster(message, Common.TosterType.Success);
                LoadEducation();
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }
        protected void ddlLevelOfEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExam();
        }
        private void LoadEducation()
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            _dt = _bll.GetEducationInfo(enroll);
            gridviewEducation.Loads(_dt);
        }
        protected void btnDeleteEducation_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            int id = Convert.ToInt32(gridviewEducation.DataKeys[row.RowIndex].Values[0].ToString());
            if (_bll.DeleteEducation(id).Rows.Count > 0)
            {
                Toaster("Delete Successfully", Common.TosterType.Success);
                LoadEducation();
            }
            else
            {
                Toaster("Delete failed", Common.TosterType.Error);
            }

        }
        #endregion
        #region Tab 3: Experience
        protected void btnAddExperience_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }

            string strCompanyName = txtCompanyName.Text;
            string strCompanyLocation = txtCompanyAddress.Text;
            string strCompanyBusiness = txtCompanyBusiness.Text;
            string strDesignation = txtEmploymentDesignation.Text;
            string strDepartment = txtEmployementDepartment.Text;
            string strResponsibilities = txtResponsibilities.Text;
            DateTime dteEmploymentPeriodFrom = txtFromDate.Text.ToDateTime("dd/MM/yyyy");
            DateTime? dteEmploymentPeriodTo = null;
            if (!string.IsNullOrWhiteSpace(txtToDate.Text))
            {
                txtToDate.Text.ToDateTime("dd/MM/yyyy");
            }
            string strCurrentlyWorking = string.Empty;
            if (chkCurentlyWorking.Checked)
            {
                strCurrentlyWorking = chkCurentlyWorking.Text;
            }
            string strExpertiseSkill = txtAreaOfExperience.Text;


            string message = _bll.InsertExperienceInfo(1, enroll, strCompanyName, strCompanyLocation, strCompanyBusiness, strDesignation, strDepartment, strResponsibilities, dteEmploymentPeriodFrom, dteEmploymentPeriodTo, strCurrentlyWorking, strExpertiseSkill, Enroll);
            if (message.ToLower().Contains("success"))
            {
                Toaster(message, Common.TosterType.Success);
                LoadEmperience();
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }
        private void LoadEmperience()
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            _dt = _bll.GetExperience(enroll);
            gridviewExperience.Loads(_dt);
        }
        protected void btnDeleteExperience_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            int id = Convert.ToInt32(gridviewExperience.DataKeys[row.RowIndex].Values[0].ToString());
            if (_bll.DeleteExperience(id).Rows.Count > 0)
            {
                Toaster("Delete Successfully", Common.TosterType.Success);
                LoadEmperience();
            }
            else
            {
                Toaster("Delete failed", Common.TosterType.Error);
            }

        }
        #endregion
        #region Tab 4: Training
        private void LoadCountry()
        {
            _dt = _bll.GetCountry();
            ddlCountry.Loads(_dt, "intCountryID", "strCountry");
            ddlCountry.SetSelectedValue("22");
        }
        private void LoadTrainigYear()
        {
            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                ListItem li = new ListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                ddlTrainingYear.Items.Add(li);
            }
            ddlTrainingYear.DataBind();
        }
        protected void btnAddTrainig_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            string strTrainingTitle = txtTrainingTitle.Text;
            string strTopicsCovered = txtTopicCovered.Text;
            string strInstitute = txtTrainingInstitude.Text;
            string strLocation = txtTrainingLocation.Text;
            int intCountry = ddlCountry.SelectedValue();
            string strCountry = ddlCountry.SelectedText();
            int intTrainingYear = ddlTrainingYear.SelectedValue();
            string strDuration = txtDuration.Text;

            string message = _bll.InsertTrainigInfo(1, enroll, strTrainingTitle, strTopicsCovered, strInstitute, strLocation, intCountry, strCountry, intTrainingYear, strDuration, Enroll);
            ShowMessage(message);
            LoadTrainingInfo();
        }
        private void LoadTrainingInfo()
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            _dt = _bll.GetTrainigInfo(enroll);
            gridviewTraining.Loads(_dt);
        }
        protected void btnDeleteTraining_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            int id = Convert.ToInt32(gridviewTraining.DataKeys[row.RowIndex].Values[0].ToString());
            if (_bll.DeleteTraining(id).Rows.Count > 0)
            {
                Toaster("Delete Successfully", Common.TosterType.Success);
                LoadTrainingInfo();
            }
            else
            {
                Toaster("Delete failed", Common.TosterType.Error);
            }

        }
        #endregion
        #region Tab 5: Others
        protected void btnAddWorkTitle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            string workTitle = txtWorkTitle.Text;
            string message = _bll.InsertWorkInfo(enroll, workTitle, Enroll);
            ShowMessage(message);
            LoadWorkInfo();
        }
        public void LoadWorkInfo()
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            _dt = _bll.GetWorkInfo(enroll);
            gridviewWorkTitle.Loads(_dt);
        }
        protected void btnDeleteWork_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            int id = Convert.ToInt32(gridviewWorkTitle.DataKeys[row.RowIndex].Values[0].ToString());
            if (_bll.DeleteWorkTitle(id).Rows.Count > 0)
            {
                Toaster("Delete Successfully", Common.TosterType.Success);
                LoadWorkInfo();
            }
            else
            {
                Toaster("Delete failed", Common.TosterType.Error);
            }

        }
        #endregion
        #region Tab 6: Photography
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            if (ImageUpload.HasFile)
            {
                string filename = Enroll + "_" + Path.GetFileName(ImageUpload.FileName);
                string localPath = Server.MapPath("~/HR/Employee/Upload/") + filename;
                try
                {
                    string extension = Path.GetExtension(ImageUpload.FileName);
                    if (extension != null && (extension.ToLower().Contains("jpeg") ||
                                              extension.ToLower().Contains("jpg") ||
                                              extension.ToLower().Contains("png")))
                    {
                        MemoryStream ms = new MemoryStream(ImageUpload.FileBytes);
                        ms.ImageCompress(200, localPath);
                    }
                    else
                    {
                        ImageUpload.SaveAs(localPath);
                    }


                    string strFilePath = "EmpPicture/" + filename;
                    string ftpPath = ProjectConfig.Instance.GetFtpBaseUrl() + strFilePath;

                    if (ftpPath.UploadToFtp(localPath))
                    {
                        if (_bll.UpdateImageInfo(strFilePath, enroll).Rows.Count > 0)
                        {
                            Toaster("Image Upload Successfully", Common.TosterType.Success);
                        }
                        else
                        {
                            Toaster("Image upload error while updatating image info into database", Common.TosterType.Error);
                        }
                    }
                    else
                    {
                        Toaster("Image Upload Failed", Common.TosterType.Success);
                    }

                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
                finally
                {
                    localPath.DeleteFile();
                }

            }
            else
            {
                Toaster("Please Select a Image file.");
            }
        }

        public void LoadImage()
        {
            if (!int.TryParse(txtEnroll.Text, out int enroll))
            {
                Toaster("Please Enter Enroll Properly");
                return;
            }
            _dt = _bll.GetImageInfo(enroll);
            if (_dt.Rows.Count > 0)
            {
                string url = _dt.GetValue<string>("strImageUrl");
                if (!string.IsNullOrWhiteSpace(url))
                {
                    string FtpUrl = ProjectConfig.Instance.GetFtpBaseUrl() + url;
                    byte[]  image = FtpUrl.DownloadFromFtp();
                    impPrev.SetImage(image);

                }
                
            }
        }


        #endregion
        
    }
}