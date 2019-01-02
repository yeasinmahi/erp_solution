using HR_BLL.Global;
using HR_BLL.TourPlan;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace UI.ClassFiles
{
    /// <summary>
    /// Summary description for AutoCompleteSearch
    /// Developed By Md. Golam Kibria Konock
    /// Developed Date: 2013-10-31
    /// </summary>
    
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]

    public class AutoCompleteSearch : WebService
    {
        AutoSearch_BLL objauto = new AutoSearch_BLL();
        DataTable dt = new DataTable(); StatementC objbll = new StatementC();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetSearchEmployeeList(string enroll, string station, string searchKey)
        {
            List<string> item = new List<string>();
            dt = objauto.AutoSearchEmployees(int.Parse(enroll), int.Parse(station), searchKey);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["strEmployeeNameWithCode"].ToString();
                item.Add(strName);
            }
            return item.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] getApplicantListForBikeAndCarUserBillApprove(string ApproverEnrol, string prefix)
        {
            List<string> ApplicantListGB = new List<string>();
            DataTable dt = objbll.getApplicantListForApproveBillGB(ApproverEnrol, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Emplname = dt.Rows[i]["Emplname"].ToString();
                ApplicantListGB.Add(Emplname);
            }
            return ApplicantListGB.ToArray();

        }    

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetSearchEmployeeList(string enroll, string searchKey)
        {
            List<string> item = new List<string>();
            dt = objauto.AutoSearchEmployees(int.Parse(enroll), searchKey);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["strEmployeeNameWithCode"].ToString();
                item.Add(strName);
            }
            return item.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetTerritoryCustomer(string tsoenrol, string prefix)
        {
            List<string> CustomerName = new List<string>();
            DataTable dt = objbll.GetTerritoryCustomer(tsoenrol, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["strName"].ToString();
                CustomerName.Add(strName);
            }
            return CustomerName.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string[] GetTerCustomerCOAid(string tsoenrol, string prefix)
        {
            List<string> CustomerName = new List<string>();
            DataTable dt = objbll.GetTerCustomerCOAid(tsoenrol, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["strName"].ToString();
                CustomerName.Add(strName);
            }
            return CustomerName.ToArray();

        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetSearchGuestList(string bookingby, string searchKey)
        {
            List<string> item = new List<string>();
            dt = objauto.SearchGuestHostList(0, int.Parse(bookingby), searchKey);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["Visitors"].ToString();
                item.Add(strName);
            }
            return item.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetSearchHostList(string bookingby, string searchKey)
        {
            List<string> item = new List<string>();
            dt = objauto.SearchGuestHostList(1, int.Parse(bookingby), searchKey);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["Hosts"].ToString();
                item.Add(strName);
            }
            return item.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] getAreabaseTsolist(string AreaMangerEnrol, string prefix)
        {
            List<string> TSOName = new List<string>();
            DataTable dt = objbll.getAreabaseTsolist(AreaMangerEnrol, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Emplname = dt.Rows[i]["Emplname"].ToString();
                TSOName.Add(Emplname);
            }
            return TSOName.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] getTADANoneBikeUserlistForAprvLb2(string SupervisorEnrolLb2, string prefix)
        {
            List<string> JSOName = new List<string>();
            DataTable dt = objbll.getAreabaseJSOorHONoneBikeuserlist(SupervisorEnrolLb2, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Emplname = dt.Rows[i]["Emplname"].ToString();
                JSOName.Add(Emplname);
            }
            return JSOName.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] getNoOfficeEmailEmployeeList(string ApproverEnrol, string prefix)
        {
            List<string> NoEmailEmployee = new List<string>();
            DataTable dt = objbll.getNoEmailEmployeelist(ApproverEnrol, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Emplname = dt.Rows[i]["Emplname"].ToString();
                NoEmailEmployee.Add(Emplname);
            }
            return NoEmailEmployee.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] getNoEamilEmailList(string ApproverEnrol, string prefix)
        {
            List<string> ApplicantListGB = new List<string>();
            DataTable dt = objbll.getApplicantListForApproveBillGBwithCode(ApproverEnrol, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Emplname = dt.Rows[i]["Emplname"].ToString();
                ApplicantListGB.Add(Emplname);
            }
            return ApplicantListGB.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] getSupervisorForUpdate(string intJobstaionid, string prefix)
        {
            List<string> suprvisorlist = new List<string>();
            DataTable dt = objbll.getSupervisorNameForUpdate(intJobstaionid, prefix);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Emplname = dt.Rows[i]["Emplname"].ToString();
                suprvisorlist.Add(Emplname);
            }
            return suprvisorlist.ToArray();

        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] GetAutoCompleteBrandItemName(string intunitd, string prefix)
        //{
        //    DataTable dt = new DataTable(); TourPlanning objbll = new TourPlanning();

        //    List<string> branditemlist = new List<string>();
        //    dt = objbll.getBrandItemNameforReqs(intunitd, prefix);

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string strItemName = dt.Rows[i]["strItemName"].ToString();
        //        branditemlist.Add(strItemName);
        //    }
        //    return branditemlist.ToArray();

        //}




        
    }
}
