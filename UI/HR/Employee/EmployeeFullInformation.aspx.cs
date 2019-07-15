using HR_BLL.Employee;
using System;
using System.Data;
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
            }
        }
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
    }
}