using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class EditRequisition : BasePage
    {
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId, intBomStandard; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey;DateTime dteDate;
        string dteFrom, dteTo;
        

        char[] delimiterChars = { '[', ']' };

        

        string filePathForXML; string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
               // dteTo.SelectedDate = DateTime.Now;
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    try { Session["Unit"] = hdnUnit.Value; } catch { }
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            { 
                string interval = ddlInterval.SelectedItem.ToString();
                string vtypes = ddlvTypes.SelectedItem.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dteDate = DateTime.Parse(txtdteDate.Text.ToString());

                 
                if (interval== "12:00-12:00")
                {
                     
                    string dteFrom =dteDate.ToString("yyyy-MM-dd")+" "+"00:00:00.000" ;
                    string dteTo =dteDate.ToString("yyyy-MM-dd")+ " "+"23:59:59.999" ;
                    xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                }
                else if (interval=="6:00-6:00"){
                      
                    string dteFrom = dteDate.ToString("yyyy-MM-dd") + " " + "06:00:00.000";
                    string dteTo = dteDate.ToString("yyyy-MM-dd") + " " + "05:59:59.999";
                    xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                }
                if(vtypes=="SR")
                {
                    
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objBom.GetBomData(11, xmlData, intwh, BomId, DateTime.Now, enroll);
                    
                    dgvReq.DataSource = dt;
                    dgvReq.DataBind();
                    dgvReq.Visible = true;
                    dgvItem.Visible = false;

                }
                else
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objBom.GetBomData(10, xmlData, intwh, BomId, DateTime.Now, enroll);
                    dgvItem.DataSource = dt;
                    dgvItem.DataBind();
                    dgvReq.Visible = false;
                    dgvItem.Visible = true;
                }
                 
            }
            catch { }
        }

        

        protected void btnDetalisReq_Click(object sender, EventArgs e)
        {
            try
            {
                string interval = ddlInterval.SelectedItem.ToString();
                string vtypes = ddlvTypes.SelectedItem.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dteDate = DateTime.Parse(txtdteDate.Text.ToString());


                if (interval == "12:00-12:00")
                {

                    dteFrom = dteDate.ToString("yyyy-MM-dd") + " " + "00:00:00.000";
                    dteTo = dteDate.ToString("yyyy-MM-dd") + " " + "23:59:59.999";
                    xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                }
                else if (interval == "6:00-6:00")
                {

                    dteFrom = dteDate.ToString("yyyy-MM-dd") + " " + "06:00:00.000";
                    dteTo = dteDate.ToString("yyyy-MM-dd") + " " + "05:59:59.999";
                    xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                }

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblReqId = row.FindControl("lblReqId") as Label;

                string srrId = lblReqId.Text.ToString();
                string itemId = lblReqId.Text.ToString();
                string whid = ddlWH.SelectedValue.ToString();
                string Vtype = ddlvTypes.SelectedItem.ToString();
                 

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + srrId + "','" + itemId.ToString() + "','" + whid + "','" + Vtype + "','" + dteFrom + "','" + dteTo + "');", true);

            }
            catch { }
        }

        protected void btnDetalisItem_Click(object sender, EventArgs e)
        {
            try
            {
                string interval = ddlInterval.SelectedItem.ToString();
                string vtypes = ddlvTypes.SelectedItem.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dteDate = DateTime.Parse(txtdteDate.Text.ToString());


                if (interval == "12:00-12:00")
                {

                      dteFrom = dteDate.ToString("yyyy-MM-dd") + " " + "00:00:00.000";
                      dteTo = dteDate.ToString("yyyy-MM-dd") + " " + "23:59:59.999";
                    xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                }
                else if (interval == "6:00-6:00")
                {

                      dteFrom = dteDate.ToString("yyyy-MM-dd") + " " + "06:00:00.000";
                      dteTo = dteDate.ToString("yyyy-MM-dd") + " " + "05:59:59.999";
                    xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                }

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblItemId = row.FindControl("lblItemId") as Label;
              
                string srrId = lblItemId.Text.ToString();
                string itemId = lblItemId.Text.ToString();
                string whid = ddlWH.SelectedValue.ToString();
                string Vtype = ddlvTypes.SelectedItem.ToString();


                



                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + srrId + "','" + itemId.ToString() + "','" + whid + "','" + Vtype + "','" + dteFrom + "','" + dteTo + "');", true);

            }
            catch { }
        }
    }
}