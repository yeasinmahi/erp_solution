using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Web.Script.Services;
using System.Web.Services;
 
using HR_BLL.Global;
using HR_BLL.Employee;
using System.Data;

namespace UI.HR.Employee
{
    public partial class EmpPersonalInformationUpdate : BasePage
    {
        EmployeeDetails bll = new EmployeeDetails();
        DataTable details = new DataTable();
        DataTable personalDetails = new DataTable();
        DataTable countId = new DataTable();
        char[] deli = { '[', ']' }; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GVPersonalInfoUpdateList.Visible = false;
                GVPersonalInfoUpdateList.DataSource = bll.getEmployeeUpdateInfoList();
                GVPersonalInfoUpdateList.DataBind();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int number = 0; ;
            arrayKey = TxtEmployee.Text.Split(delimiterChars); 
            if (arrayKey.Length > 0)
            {
                number = int.Parse(arrayKey[3].ToString());
            }

            string strFatherName = TxtFather.Text.ToString();
            string strMotherName = TxtMother.Text.ToString();
            string strSpouseName = TxtSpouse.Text.ToString();
            string strPermanentVillage = TxtVillage.Text.ToString();
            string strPermanentPostOffice = TxtPermanentPostOffice.Text.ToString();
            string strPermanentPoliceStation = TxtPermanentPoliceStation.Text.ToString();
            string strPermanentDistrict = TxtPermanentDistricts.Text.ToString();
            string House = TxtHouse.Text.ToString();
            int Road = int.Parse(TxtRoad.Text.ToString());
            string PresentPostOffice = TxtPresentPostOffice.Text.ToString();
            string PresentPoliceStation = TxtPresentPoliceStation.Text.ToString();
            string PresentDistrict = TxtPresentDistricts.Text.ToString();

            countId = bll.CountEmpId(number);
            if (countId.Rows.Count > 0)
            {
                bll.updateEmployeeDetailById(strFatherName, strMotherName, strSpouseName, strPermanentVillage, strPermanentPostOffice, strPermanentPoliceStation, strPermanentDistrict, House, Road, PresentPostOffice,
                 PresentPoliceStation, PresentDistrict, number);

            }
            else
            {
                bll.insertEmployeePersonalData(number, strFatherName, strMotherName, strSpouseName, strPermanentVillage, strPermanentPostOffice, strPermanentPoliceStation, strPermanentDistrict, House, Road, PresentPostOffice,
                        PresentPoliceStation, PresentDistrict);

            }




            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);

            GVPersonalInfoUpdateList.Visible = true;
            GVPersonalInfoUpdateList.DataSource = bll.getEmployeeUpdateInfoList();
            GVPersonalInfoUpdateList.DataBind();
            TxtFather.Text = "";
            TxtMother.Text = "";
            TxtHouse.Text = "";
            TxtSpouse.Text = "";
            TxtVillage.Text = "";
            TxtPermanentDistricts.Text = "";
            TxtPermanentPoliceStation.Text = "";
            TxtPermanentPostOffice.Text = "";
            TxtPresentDistricts.Text = "";
            TxtPresentPoliceStation.Text = "";
            TxtPresentPostOffice.Text = "";
            TxtRoad.Text = "";

        }

        protected void TxtEmployee_TextChanged(object sender, EventArgs e)
        {
            //TxtEmployee.Text.Split(deli);
               int number = 0; 

               arrayKey = TxtEmployee.Text.Split(delimiterChars);
               
                if (arrayKey.Length > 0)
                {
                    number= int.Parse(arrayKey[3].ToString()); 
                }
             
              details = bll.getEmployeeDetails(number);
            if (details.Rows.Count > 0)
            {
                TxtName.Text = details.Rows[0]["strEmployeeName"].ToString();
                TxtUnit.Text = details.Rows[0]["strUnit"].ToString();
                TxtJobStation.Text = details.Rows[0]["strJobStationName"].ToString();
                TxtDepartment.Text = details.Rows[0]["strDepatrment"].ToString();
                TxtDesignation.Text = details.Rows[0]["strDesignation"].ToString();
                TxtDateOfJoin.Text = details.Rows[0]["dteJoiningDate"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

            }

            personalDetails = bll.getEmployeePersonalDataByEmpId(number);
            if (personalDetails.Rows.Count > 0)
            {
                TxtFather.Text = personalDetails.Rows[0]["strFatherName"].ToString();
                TxtMother.Text = personalDetails.Rows[0]["strMotherName"].ToString();
                TxtSpouse.Text = personalDetails.Rows[0]["strSpouseName"].ToString();
                TxtVillage.Text = personalDetails.Rows[0]["strPermanentVillage"].ToString();
                TxtPermanentPostOffice.Text = personalDetails.Rows[0]["strPermanentPostOffice"].ToString();
                TxtPermanentPoliceStation.Text = personalDetails.Rows[0]["strPermanentPoliceStation"].ToString();
                TxtPermanentDistricts.Text = personalDetails.Rows[0]["strPermanentDistrict"].ToString();
                TxtHouse.Text = personalDetails.Rows[0]["strPresentHouseNo"].ToString();
                TxtRoad.Text = personalDetails.Rows[0]["intPresentRoadNo"].ToString();
                TxtPresentPostOffice.Text = personalDetails.Rows[0]["strPresentPostOffice"].ToString();
                TxtPresentPoliceStation.Text = personalDetails.Rows[0]["strPresentPoliceStation"].ToString();
                TxtPresentDistricts.Text = personalDetails.Rows[0]["strPresentDistrict"].ToString();

            }
            else
            {
                TxtFather.Text = "";
                TxtMother.Text = "";
                TxtHouse.Text = "";
                TxtSpouse.Text = "";
                TxtVillage.Text = "";
                TxtPermanentDistricts.Text = "";
                TxtPermanentPoliceStation.Text = "";
                TxtPermanentPostOffice.Text = "";
                TxtPresentDistricts.Text = "";
                TxtPresentPoliceStation.Text = "";
                TxtPresentPostOffice.Text = "";
                TxtRoad.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Personal Data Not Found');", true);

            }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());

            return objAutoSearch_BLL.GetEmployeeByJobstationOperator(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), prefixText);

        }
    }
}