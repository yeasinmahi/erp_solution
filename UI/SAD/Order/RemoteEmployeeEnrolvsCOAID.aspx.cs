using HR_BLL.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteEmployeeEnrolvsCOAID : System.Web.UI.Page
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        string filePathForXML;
        int intEnrol,  intEmployeeCoAId, intInsertBy;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Order/Data/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadanobikeEntryForAnotherUser.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }

            else
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int enr = int.Parse(code.ToString());
                    LoadFieldValue(enr);

                }
                else
                {
                    //ClearControls();
                }
            }
        }

        private void LoadFieldValue(int enrol)
        {
            try
            {

                EmployeeRegistration objenrol = new EmployeeRegistration();
                DataTable objDT = new DataTable();
                objDT = objenrol.GetEmployeeProfileByEnrol(enrol);
                if (objDT.Rows.Count >= 0)
                {

                    txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                    txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                    textEnrol.Text = objDT.Rows[0]["strEmployeeCode"].ToString();
                }

            }
            catch (Exception ex) { throw ex; }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataForEmplEnrolvsCOAID(string strSearchKey)
        {

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.getemployeewithCOAID(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), strSearchKey);
            return result;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
              try
            {
            string strAplName = txtFullName.Text;
            string strSearchKey = txtFullName.Text;
            arrayKey = strSearchKey.Split(delimiterChars);
            string enrol = arrayKey[1].ToString();
            int enr = int.Parse(enrol.ToString());
            string strSearchCOAID = txtCOAName.Text;
            arrayKey = strSearchCOAID.Split(delimiterChars);
            string coa = arrayKey[1].ToString();
            int coaid = int.Parse(coa.ToString());
            intInsertBy = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            Int32 unit = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Int32 intPart = 1;
            bll.getRmtEmplEnrolvsCOAID(enr, coaid, unit, intInsertBy, intPart);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully inserted Employee Enrol with COA ID');", true);
            }
              catch
              {
                  ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Failed .........');", true);
              }
        



        }




    }
}