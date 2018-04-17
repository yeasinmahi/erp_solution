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
    public partial class RemoteTourAdvanceAprvByAccount : BasePage
    {
        
        DataTable dt = new DataTable();
       SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        private void Loadgrid()
        {
            try
            {
                dt = bll.getTADAAdvanceForAccountDeptAprv();
                if (dt.Rows.Count > 0)
                {
                    dgvlistTADA.DataSource = dt;
                    dgvlistTADA.DataBind();
                   
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true); }
            }
            catch { }
        }

        protected void Complete_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intID = searchKey[0].ToString();
            int id = int.Parse(intID);

            Session["id"] = id;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('RemoteTADATourAdvanceApproveAccountDetaills.aspx');", true);
        }



      
      
       
    }
}