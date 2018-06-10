using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace UI.Asset
{
    public partial class CorrectiveRequestUser : BasePage
    {
        AssetMaintenance objrequest = new AssetMaintenance(); 
        DataTable dt = new DataTable();
        DataTable asset = new DataTable();
        int intItem, intjobid, intenroll, intdept;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                  intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                  int Mnumber = int.Parse("0".ToString());
                  intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                  intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                dt = objrequest.MaintenaceJobstation();
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "strName";
                ddlLocation.DataValueField = "Id";
                ddlLocation.DataBind();
                int location = int.Parse(ddlLocation.SelectedValue);
                getDepartment(location);
                intItem = 36;
                dt = objrequest.GriedViewUserRequestData(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvView.DataSource = dt;
                dgvView.DataBind();

                dt.Clear();
                pnlUpperControl.DataBind();
               

                //if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
                //{
                //    depertmnet = objrequest.DepartmentbyCorporate();
                //    DdlDept.DataSource = depertmnet;
                //    DdlDept.DataTextField = "strDepatrment";
                //    DdlDept.DataValueField = "intDepartmentID";
                //    DdlDept.DataBind();
                //} 
                //else
                //{

                //    depertmnet = objrequest.DepartmentbyJobstation(intjobid);
                //    DdlDept.DataSource = depertmnet;
                //    DdlDept.DataTextField = "strDepatrment";
                //    DdlDept.DataValueField = "intDepartmentID";
                //    DdlDept.DataBind();
                //}

              

            }
        }

        private void getDepartment(int location)
        {
            try
            {
              
                if(location==0)
                {
                    dt = objrequest.DepartmentbyCorporate();
                    DdlDept.DataSource = dt;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();

                }
                else
                {
                    dt = objrequest.DepartmentbyJobstation(location);
                    DdlDept.DataSource = dt;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();
                }
                dt.Clear();
            }
            catch { }
        }

        protected void BtnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                string problem = TxtProblem.Text.ToString();
                if (hdnConfirm.Value.ToString()=="1" && problem.Length>5)
                {
                    string strSearchKey = TxtAsset.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");

                    string priority = DdlREPriotiy.SelectedItem.ToString();
                    string name = searchKey[1].ToString();
                    string location = ddlLocation.SelectedItem.ToString();
                    int requestToLocation = int.Parse(ddlLocation.SelectedValue);
                    int dept = int.Parse(DdlDept.SelectedValue.ToString());
                    int intUserjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    int Mnumber = 0;
                    if (requestToLocation == 0)
                    {
                        objrequest.UserRequestMaintenance(name, priority, problem, intenroll, 15, location, dept);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);
                    }
                    else
                    {
                        objrequest.UserRequestMaintenance(name, priority, problem, intenroll, requestToLocation, location, dept);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);
                    }

                    TxtAsset.Text = "";
                    TxtName.Text = "";
                    TxtProblem.Text = "";

                    intItem = 36;
                    dt = objrequest.GriedViewUserRequestData(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvView.DataSource = dt;
                    dgvView.DataBind();
                }
                else { }
                
                
            }
            catch { }
      
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetData(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            return objAutoSearch_BLL.GetAssetItem(Active, prefixText);

        }
        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            string strSearchKey = TxtAsset.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";"); 

            string number = searchKey[1].ToString();
            asset = objrequest.showassetData(number);
            if (asset.Rows.Count > 0)
            {
                TxtName.Text = asset.Rows[0]["strNameOfAsset"].ToString();
                TxtUnit.Text = asset.Rows[0]["strUnit"].ToString();
                TxtStation.Text = asset.Rows[0]["strJobStationName"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

            }
        }

        protected void BtnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
                Int32 id = Int32.Parse(ordernumber1.ToString());
                // Response.Write(ordernumber); 

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + id + "');", true);


                
            }
            catch { }
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               int  location = int.Parse(ddlLocation.SelectedValue);
                getDepartment(location);
                 
            }
            catch { }
        }
    }
}