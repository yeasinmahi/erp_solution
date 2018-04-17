using Purchase_BLL.SupplyChain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Text.RegularExpressions;

namespace UI.Inventory
{
    public partial class DocHistory : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dm = new DataTable();

        CSM obj = new CSM();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                dt = obj.GetDocTypes();
                ddlDT.DataSource = dt;
                ddlDT.DataTextField = "TypeName";
                ddlDT.DataValueField = "intId";
                ddlDT.DataBind();
            }

                int intEmployeeID = int.Parse(Session[SessionParams.USER_ID].ToString());
                dm = obj.GetDepartment(intEmployeeID);

                txtDepartment.Text = dm.Rows[0]["strDepatrment"].ToString();
                txtDepartment.Enabled = false;

                //if (dt.Rows.Count > 0)
                //{
                //    txtDepartment.Text = dt.Rows[0][2].ToString();
                //}
            
        }

        protected void dgvDocHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            DataTable dl = new DataTable();

            int intEmployeeID = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intDocTypeId = int.Parse(ddlDT.SelectedValue);
            dl = obj.GetDocDetailsData(intDocTypeId, intEmployeeID);
            dgvDocHistory.DataSource = dl;
            dgvDocHistory.DataBind();
        }

        protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void DocSubmit(object sender, EventArgs e)
        {

            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int intDocID = int.Parse(searchKey[0].ToString());

                int intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                obj.InsertTask(intDocID, intEnroll, intActionBy);


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucess');", true);

            }
            catch { }
           
        }

           




        }
}