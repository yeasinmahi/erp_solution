using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;

namespace UI.Asset
{
    public partial class CorrectiveRequestUser : BasePage
    {
        AssetMaintenance objrequest = new AssetMaintenance();
        DataTable depertmnet = new DataTable();
        DataTable dt = new DataTable();
        DataTable asset = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string problem = TxtProblem.Text.ToString();
                //string priority = DdlREPriotiy.SelectedItem.ToString();
                //string name = TxtName.Text.ToString();
                ////Int32 dept =Int32.Parse(DdlDept.SelectedValue.ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 Mnumber = int.Parse("0".ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            

                intItem = 36;
                dt = objrequest.GriedViewUserRequestData(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvView.DataSource = dt;
                dgvView.DataBind();
                if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
                {
                    depertmnet = objrequest.DepartmentbyCorporate();
                    DdlDept.DataSource = depertmnet;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();
                }

                else
                {

                    depertmnet = objrequest.DepartmentbyJobstation(intjobid);
                    DdlDept.DataSource = depertmnet;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();
                }

                pnlUpperControl.DataBind();

            }
        }

        protected void BtnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                string problem = TxtProblem.Text.ToString();
                string priority = DdlREPriotiy.SelectedItem.ToString();
                string name = TxtAsset.Text.ToString();
                string location = TxtLocation.Text.ToString();
                Int32 dept = Int32.Parse(DdlDept.SelectedValue.ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 Mnumber = int.Parse("0".ToString());
                objrequest.UserRequestMaintenance(name, priority, problem, intenroll, intjobid, location, dept);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);
                TxtAsset.Text = "";
                TxtName.Text = "";
                TxtProblem.Text = "";

                intItem = 36;
                dt = objrequest.GriedViewUserRequestData(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvView.DataSource = dt;
                dgvView.DataBind();

                
            }
            catch { }
      
        }

        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            string number = TxtAsset.Text.ToString();
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

       
    }
}