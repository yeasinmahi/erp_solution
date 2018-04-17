using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTADATourAdvanceApprove : BasePage
    {
        //int rowIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            int enrol = int.Parse(hdnAreamanagerEnrol.Value);
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            DataTable dt = new DataTable();
            
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                dt = bll.getTADAPendingAdvanceStatus(enrol);

                if (dt.Rows.Count > 0)
                {

                    grdvForPendingTADAShow.DataSource = dt;
                    grdvForPendingTADAShow.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
        }

        protected void grdvForPendingTADAShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvForPendingTADAShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Complete_Click(object sender, EventArgs e)
        {
           

            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intID = searchKey[0].ToString();
            int id = int.Parse(intID);

            Session["id"] = id;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('RemoteTADATourAdvanceApproveDetaills.aspx');", true);

        }

       

        //protected void btnApproveAdvance_Click(object sender, EventArgs e)
        //{
           
        //        hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
        //        int ApprovedBy = Convert.ToInt32(hdnAreamanagerEnrol.Value);



        //        char[] delimiterChars = { ',' };
        //        string temp = ((Button)sender).CommandArgument.ToString();
        //        string[] searchKey = temp.Split(delimiterChars);
        //        string intID = searchKey[0].ToString();
        //        int id = int.Parse(intID);
        //        string intApplicantEnrol = searchKey[1].ToString();
        //        int apenrol = int.Parse(intApplicantEnrol);
              

        //        string dtTourStartDate = searchKey[3].ToString();
        //        DateTime dtTourApproveFrom = DateTime.Parse(dtTourStartDate.ToString());

        //        string dtTourEndDate = searchKey[4].ToString();
        //        DateTime dtTourApproveTo = DateTime.Parse(dtTourEndDate.ToString());

        //        TextBox txtAprvAmountBySupervs = (TextBox)grdvForPendingTADAShow.Rows[0].Cells[9].FindControl("txtdecApproveAmount");
        //        string aprvAMount = txtAprvAmountBySupervs.Text;
        //        Decimal aprv = decimal.Parse(aprvAMount);

               

        //        string strApproveStatus = "Y";

        //        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        //        bll.TADAAdvanceApprovebySupervisor(id, apenrol, dtTourApproveFrom, dtTourApproveTo, aprv, ApprovedBy, strApproveStatus);

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Insert');", true);

            
            

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fail to...');", true);

           
            
        //}

       

    }
}