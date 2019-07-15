﻿using HR_BLL.Employee;
using System;
using System.Data;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.HR.Employee
{
    public partial class EmployeeFullInformation : BasePage
    {
        private EmployeeFullInformationBll _bll = new EmployeeFullInformationBll();
        private DataTable _dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEnroll.Text = Enroll.ToString();
                txtCode.Text = Code;
                LoadDepartment();
                LoadDesignation();
                LoadLevelOfEducation();
                LoadResult();
                LoadExam();
                LoadBoard();
                LoadYearOfPassing();
            }
        }
        #region Tab 1:Education Info
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
            string nid = txtNidNo.Text;
            string mobileNo = txtMobileNo.Text;
            if (!DateTime.TryParseExact(txtPromotionDate.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime promotionDate))
            {
                Toaster("Please Enter Promotion Date Format Properly");
                return;
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
            if (!decimal.TryParse(txtPresentSalary.Text, out decimal joiningSalary))
            {
                Toaster("Please Enter Joining Salary Properly");
                return;
            }
            string previousOrganization = txtPreviousOrganization.Text;
            string previousDesignation = txtPreviousDesignation.Text;
            if (!decimal.TryParse(txtPreviousSalary.Text, out decimal previousSalary))
            {
                Toaster("Please Enter Previous Salary Properly");
                return;
            }
            string message = _bll.Insert(enroll, code, name, fathersName, mothersName, permanentAddress, nid, promotionDate, presentDesignationId, presentDesignation, presentDepartmentId, presentDepartment, presentSalry, joiningDate, joiningDesignationId, joiningDesignation, joiningSalary, previousOrganization, previousDesignation, previousSalary, Enroll);
            if (message.ToLower().Contains("success"))
            {
                Toaster(message, Common.TosterType.Success);
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }

        protected void btnShowEmployeeInformation_Click(object sender, EventArgs e)
        {
            string strEnroll = txtEnroll.Text;
            string code = txtCode.Text;
            if (string.IsNullOrWhiteSpace(strEnroll) && string.IsNullOrWhiteSpace(code))
            {
                Toaster("Please input enroll or employee code");
                return;
            }
            if (!string.IsNullOrWhiteSpace(strEnroll))
            {
                if (!int.TryParse(txtEnroll.Text, out int enroll))
                {
                    Toaster("Please Enter Enroll Properly");
                    return;
                }
                _dt = _bll.GetEmployeeInfo(enroll);
                if (_dt.Rows.Count > 0)
                {
                    txtCode.Text = _dt.GetValue<string>("strEmployeeCode");
                }
                else
                {
                    Toaster("No Employee Information Found Aginest This Enroll");
                    return;
                }
            }
            else if(!string.IsNullOrWhiteSpace(code))
            {
                _dt = _bll.GetEmployeeInfo(code);
                if (_dt.Rows.Count > 0)
                {
                    txtEnroll.Text = _dt.GetValue<string>("intEmployeeID");
                }
                else
                {
                    Toaster("No Employee Information Found Aginest This Code");
                    return;
                }
            }
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
        #endregion
        #region Tab2: Education
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
            _dt = _bll.GetExamList();
            ddlExam.LoadWithSelect(_dt, "intExamID", "strExamName");
        }
        private void LoadBoard()
        {
            _dt = _bll.GetEducationBoard();
            ddlBoard.LoadWithSelect(_dt, "intBoardID", "strBoard");
        }
        private void LoadYearOfPassing()
        {
            for(int i = 1900; i <= DateTime.Now.Year; i++)
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
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }
        #endregion


    }
}