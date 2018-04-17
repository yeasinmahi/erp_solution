using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.SupplyChain;
using System.Data;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class IndentApproval : System.Web.UI.Page
    {
        DataTable dt1=new DataTable();
        DataTable dt = new DataTable();
        CSM Suppliereport = new CSM();
        CSM report = new CSM();
        CSM obj=new CSM();

        int intWHID; DateTime dteFromDate; DateTime dteToDate; int number;



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                int intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt1 = obj.getwarehouse(intRequestBy);
                ddlWNName.DataTextField = "strWareHoseName";
                ddlWNName.DataValueField = "intWHID";
                ddlWNName.DataSource = dt1;
                ddlWNName.DataBind();




                //Int32 enroll = Convert.ToInt32(Session["enroll"].ToString());
                //try
                //{

                //    enroll = int.Parse(Session["enroll"].ToString());
                //}
                //catch { }

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Int32 Number =Convert.ToInt32 (ddlStatus.SelectedValue.ToString());
            Int32 intWHID = Convert.ToInt32(ddlWNName.SelectedValue.ToString());
            dteFromDate = DateTime.Parse(txtFromDate.Text);
            dteToDate = DateTime.Parse(txtTodate.Text);


            //RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = report.GetIndentList(intWHID, dteFromDate, dteToDate, Number);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
            
        }

        protected void Complete_Click(object sender, EventArgs e)
        {
            try
            {

                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string Indentid = searchKey[0].ToString();
                Session["Indentid"] = Indentid;
                

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('IndentDetail.aspx');", true);

                //string senderdata = ((Button)sender).CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "SupApproval('" + senderdata + "');", true);
            }
            catch { }
            //catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

        }

        protected void ddlWNName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int whid = int.Parse(ddlWNName.SelectedValue.ToString());
            string whname = Convert.ToString(ddlWNName.SelectedItem.ToString());
            Session["whid"] = whid;
            Session["whname"] = whname;
        }

    }
}

