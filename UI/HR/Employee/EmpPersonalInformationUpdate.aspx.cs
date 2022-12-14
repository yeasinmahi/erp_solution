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
using System.Globalization;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Employee
{
    public partial class EmpPersonalInformationUpdate : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Employee/EmpPersonalInformationUpdate.aspx";
        string stop = "stopping HR/Employee/EmpPersonalInformationUpdate.aspx";

        EmployeeDetails bll = new EmployeeDetails();
        DataTable details = new DataTable();
        DataTable personalDetails = new DataTable();
        DataTable countId = new DataTable();
        char[] deli = { '[', ']' }; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Label6.Visible = false;
                //LblSpouse.Visible = false;
                //Label11.Visible = false;
                //Label12.Visible = false;
                //Label13.Visible = false;
                //Label14.Visible = false;
                //Label15.Visible = false;
                //TxtMother.Visible = false;
                //TxtSpouse.Visible = false;
                //TxtHouse.Visible = false;
                //TxtRoad.Visible = false;
                //TxtPresentDistricts.Visible = false;
                //TxtPresentPoliceStation.Visible = false;
                //TxtPresentPostOffice.Visible = false;

            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "BtnUpdate_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/EmpPersonalInformationUpdate.aspx BtnUpdate_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnConfirm.Value == "1")
                {
                    int number = 0; ;
                    arrayKey = TxtEmployee.Text.Split(delimiterChars);
                    if (arrayKey.Length > 0)
                    {
                        number = int.Parse(arrayKey[3].ToString());
                    }

                    string strFatherName = TxtFather.Text.ToString();
                    //string strMotherName = TxtMother.Text.ToString();
                    string strMotherName = "";
                    string strSpouseName = "";
                    string strPermanentVillage = TxtVillage.Text.ToString();
                    string strPermanentPostOffice = TxtPermanentPostOffice.Text.ToString();
                    string strPermanentPoliceStation = TxtPermanentPoliceStation.Text.ToString();
                    string strPermanentDistrict = TxtPermanentDistricts.Text.ToString();
                    string House = "";
                    string Road = "";
                    string PresentPostOffice = "";
                    string PresentPoliceStation = "";
                    string PresentDistrict = "";

                    countId = bll.CountEmpId(number);
                    if (countId.Rows.Count > 0)
                    {
                        bll.updateEmployeeDetailById(strFatherName, strMotherName, strSpouseName, strPermanentVillage, strPermanentPostOffice, strPermanentPoliceStation, strPermanentDistrict, House, Road, PresentPostOffice,
                         PresentPoliceStation, PresentDistrict, number);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Update Request');", true);

                    }
                    else
                    {
                        bll.insertEmployeePersonalData(number, strFatherName, strMotherName, strSpouseName, strPermanentVillage, strPermanentPostOffice, strPermanentPoliceStation, strPermanentDistrict, House, Road, PresentPostOffice,
                                PresentPoliceStation, PresentDistrict);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);

                    }

                    TxtEmployee.Text = "";
                    TxtName.Text = "";
                    TxtDateOfJoin.Text = "";
                    TxtDesignation.Text = "";
                    TxtDepartment.Text = "";
                    TxtJobStation.Text = "";
                    TxtUnit.Text = "";
                    ClearControl();
                }
                else { }
                

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "BtnUpdate_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "BtnUpdate_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void TxtEmployee_TextChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "TxtEmployee_TextChanged", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Employee/EmpPersonalInformationUpdate.aspx TxtEmployee_TextChanged", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                ClearControl(); 
                int number = 0;
                arrayKey = TxtEmployee.Text.Split(delimiterChars);

                if (arrayKey.Length > 0)
                {
                    number = int.Parse(arrayKey[3].ToString());
                }

                details = bll.getEmployeeDetails(number);
                if (details.Rows.Count > 0)
                {
                    TxtName.Text = details.Rows[0]["strEmployeeName"].ToString();
                    TxtUnit.Text = details.Rows[0]["strUnit"].ToString();
                    TxtJobStation.Text = details.Rows[0]["strJobStationName"].ToString();
                    TxtDepartment.Text = details.Rows[0]["strDepatrment"].ToString();
                    TxtDesignation.Text = details.Rows[0]["strDesignation"].ToString();
                    try
                    {
                        DateTime dteJoin = DateTime.Parse(details.Rows[0]["dteJoiningDate"].ToString());
                        string joinDate = dteJoin.ToString("dd-MM-yyyy");
                        TxtDateOfJoin.Text = joinDate.ToString();
                    }
                    catch { }

                }
                personalDetails = bll.getEmployeePersonalDataByEmpId(number);
                if (personalDetails.Rows.Count > 0)
                {
                    TxtFather.Text = personalDetails.Rows[0]["strFatherName"].ToString();
                    //TxtMother.Text = personalDetails.Rows[0]["strMotherName"].ToString();
                    //TxtSpouse.Text = personalDetails.Rows[0]["strSpouseName"].ToString();
                    TxtVillage.Text = personalDetails.Rows[0]["strPermanentVillage"].ToString();
                    TxtPermanentPostOffice.Text = personalDetails.Rows[0]["strPermanentPostOffice"].ToString();
                    TxtPermanentPoliceStation.Text = personalDetails.Rows[0]["strPermanentPoliceStation"].ToString();
                    TxtPermanentDistricts.Text = personalDetails.Rows[0]["strPermanentDistrict"].ToString();
                    //TxtHouse.Text = personalDetails.Rows[0]["strPresentHouseNo"].ToString();
                    //TxtRoad.Text = personalDetails.Rows[0]["intPresentRoadNo"].ToString();
                    //TxtPresentPostOffice.Text = personalDetails.Rows[0]["strPresentPostOffice"].ToString();
                    //TxtPresentPoliceStation.Text = personalDetails.Rows[0]["strPresentPoliceStation"].ToString();
                    //TxtPresentDistricts.Text = personalDetails.Rows[0]["strPresentDistrict"].ToString();

                }
                


            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "TxtEmployee_TextChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void ClearControl()
        {
            
            TxtFather.Text = "";
            //TxtMother.Text = "";
            //TxtHouse.Text = "";
            //TxtSpouse.Text = "";
            TxtVillage.Text = "";
            TxtPermanentDistricts.Text = "";
            TxtPermanentPoliceStation.Text = "";
            TxtPermanentPostOffice.Text = "";
            //TxtPresentDistricts.Text = "";
            //TxtPresentPoliceStation.Text = "";
            //TxtPresentPostOffice.Text = "";
            //TxtRoad.Text = "";
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());

            return objAutoSearch_BLL.GetEmployeeByJobstationOperator(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), prefixText.ToLower());

        }
    }
}