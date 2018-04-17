using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class TADAInfoDelete : BasePage
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey; int intTSOEnroll;
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";
                ////---------xml----------
                //try { File.Delete(filePathForXML); }
                //catch { }
                ////-----**----------//
            }
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
        

        protected void btnShowdata_Click(object sender, EventArgs e)
        {
            showdataforDelete();
        }

        private void showdataforDelete()
        {
            

            try
            {
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtEffectiveDate.Text).Value;


                if (rdbUserOption.SelectedItem.Text == "In- Active")
                {
                    string strSearchKey = txtEmployeeSearch.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    string empCode = hdfEmpCode.Value;
                    int intpkid = 0;
                    int intInactiveby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    int aprvstatus = int.Parse(rdbUserOption.SelectedItem.Value.ToString());
                    dt = bll.getDataforTADAInfoDelete(dtFromDate, empCode, aprvstatus, intpkid, intInactiveby);

                    if (dt.Rows.Count > 0)
                    {

                        grdvTADAInfoDelete.DataSource = dt;
                        grdvTADAInfoDelete.DataBind();

                    }
                    else
                    {


                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                    }
                }


            }
            catch { }
        }
        protected void rdbUserOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvTADAInfoDelete_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtEffectiveDate.Text).Value;
            //string strSearchKey = txtEmployeeSearch.Text;
            //arrayKey = strSearchKey.Split(delimiterChars);
            //string code = arrayKey[1].ToString();

            //string TSOName = strSearchKey;
            //intTSOEnroll = int.Parse(code);
            int rowIndex = 0; 
            string empCode = hdfEmpCode.Value;

            char[] delimiter = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] search = temp.Split(delimiter);
            string intpkid = search[0].ToString();
            int pkid = int.Parse(intpkid);
            int aprovestatsu = 2;
            int inactiveby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int rowscount = grdvTADAInfoDelete.Rows.Count;
            decimal tot =decimal.Parse (grdvTADAInfoDelete.Rows[rowIndex].Cells[5].Text.ToString());

            if (tot >0)
            {
               dt = bll.getDataforTADAInfoDelete(dtFromDate, empCode, aprovestatsu, pkid, inactiveby);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

            }
          


        }
    }
}