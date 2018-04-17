using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
namespace UI.Asset
{
    public partial class PMScheduleServicePopUp :BasePage
    {
        AssetMaintenance objPMService= new AssetMaintenance();
        DataTable dt = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Int32 data = Convert.ToInt32(Session["intID"].ToString());
           // hdnEnroll.Value = data.ToString();
            
              if (!IsPostBack)
              {
                 
                  
                  pnlUpperControl.DataBind();
              }
        }

        private void showdata()
        {
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                intItem = 9;
                dt = new DataTable();
                dt = objPMService.dgvViewServiceName(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvServiceName.DataSource = dt;
                dgvServiceName.DataBind();

                DdlServiceName.DataSource = dt;
                DdlServiceName.DataTextField = "strServiceName";
                DdlServiceName.DataValueField = "ID";
                DdlServiceName.DataBind();

                pnlUpperControl.DataBind();


                int serviceID = int.Parse(DdlServiceName.SelectedValue.ToString());
                dt = new DataTable();
                dt = objPMService.ViewServiceData(serviceID);
                if (dt.Rows.Count > 0)
                {
                    TxtServiceU.Text = dt.Rows[0]["strServiceName"].ToString();
                    TxtServiceCharge.Text = dt.Rows[0]["monServiceCharge"].ToString();

                }
            }
            catch { }
           
         
                 
        }
        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
            showdata();
        }
       protected void Tab2_Click(object sender, EventArgs e)
           {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                MainView.ActiveViewIndex = 1;
                showdata();
           }
        protected void BtnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                //Int32 data = Convert.ToInt32(Session["intID"].ToString());
                int Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                string servicename = TxtService.Text.ToString();
                decimal charge = decimal.Parse(TxtSeviceCost.Text.ToString());


                objPMService.PMServiceInsertData(servicename, charge, intenroll, intjobid, intdept);

                showdata();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Service Add');", true);
            }
            catch { }
            
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
        }

        protected void DdlServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int serviceID = int.Parse(DdlServiceName.SelectedValue.ToString());
                dt = new DataTable();
                dt = objPMService.ViewServiceData(serviceID);
                if (dt.Rows.Count > 0)
                {
                    TxtServiceU.Text = dt.Rows[0]["strServiceName"].ToString();
                    TxtServiceCharge.Text = dt.Rows[0]["monServiceCharge"].ToString();

                }

            }
            catch { }
           
        }

        protected void BtnUpdateService_Click(object sender, EventArgs e)
        {
            decimal cost;
            int serviceID = int.Parse(DdlServiceName.SelectedValue.ToString());
            string serviceName = TxtServiceU.Text.ToString();
            

            try
            {
                cost = decimal.Parse(TxtServiceCharge.Text.ToString());
            }
            catch { cost = decimal.Parse(0.ToString()); }

            objPMService.UpdatePMServiceName(serviceName, cost, serviceID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully');", true);

               

            
        }
    }
}