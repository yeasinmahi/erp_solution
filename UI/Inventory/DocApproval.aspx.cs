using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UI.ClassFiles;
using Purchase_BLL.SupplyChain;

namespace UI.Inventory
{
    public partial class DocApproval : System.Web.UI.Page
    {
        CSM obj = new CSM();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dl = new DataTable();
            if (!IsPostBack)
            {

                //int intEmployeeID = int.Parse(Session[SessionParams.USER_ID].ToString());
                //int intDocTypeId = int.Parse(ddlDT.SelectedValue);
                dl = obj.GetDocHistory();
                dgvDocHistory.DataSource = dl;
                dgvDocHistory.DataBind();
            }
        }
        
        protected void DeliveryClk(object sender, EventArgs e)
        {

            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int intDocID = int.Parse(searchKey[0].ToString());

                //int intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //int intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                obj.UpdateDeliver(intDocID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Deliver Successfully');", true);

            }
            catch { }

        }



        protected void Rejectclk(object sender, EventArgs e)
        {

            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int intDocID = int.Parse(searchKey[0].ToString());

                //int intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //int intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                obj.UpdateReject(intDocID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Reject Successfully');", true);

            }
            catch { }


        }

        protected void dgvDocHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
           

            //int intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            //int intActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());

           // obj.UpdateTask(intDocID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Deliver Successfully');", true);


        }
    }
}