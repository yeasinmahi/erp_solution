using HR_BLL.Settlement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace UI.HR.Settlement
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        HRClass objhr = new HRClass();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetEmpList(string enroll, string station, string prefix)
        {
            List<string> employee = new List<string>();
            DataTable dt = objhr.GetEmpList(enroll, station, prefix);
            //List<string> items = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i]["SearchResult"].ToString();
                employee.Add(strName);
            }
            return employee.ToArray();

        }



    }
}
