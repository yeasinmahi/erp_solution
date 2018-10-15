using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class RequisitionDetails : BasePage
    {
        int intInsertBy = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DaysOfWeek bll = new DaysOfWeek();
                DataTable dtbl = new DataTable();
                string reqid = Request.QueryString["ID"];
                dtbl = bll.CreateStoreRequisition(1, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Now, DateTime.Now, intInsertBy);
                if (dtbl.Rows.Count > 0)
                {
                    dgvlist.DataSource = dtbl;
                    dgvlist.DataBind();
                }
                else
                {
                    dgvlist.DataSource = "";
                    dgvlist.DataBind();
                }
                //dtbl = bll.GetRequisitionDetailsBYReqID(Convert.ToInt32(reqid));
                dtbl = bll.GetAllRequisitionDetails(Convert.ToInt32(reqid));
                
                if (dtbl.Rows.Count>0)
                {
                    lblWH.Text = dtbl.Rows[0]["strWareHoseName"].ToString();
                    DateTime reqdate = Convert.ToDateTime(dtbl.Rows[0]["dteReqDate"].ToString());
                    lbldteRequest.Text = reqdate.ToString("dd-MM-yyyy");
                    lblrequisition.Text = reqid;
                    lblReqBY.Text = dtbl.Rows[0]["Requester"].ToString();
                    DateTime appDate = Convert.ToDateTime(dtbl.Rows[0]["dteApproveDate"].ToString());
                    lbldteApprove.Text = appDate.ToString("dd-MM-yyyy");
                    
                    //string unit = dtbl.Rows[0]["intUnitID"].ToString();
                    //imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                    //dtbl = bll.GetRequisitionRequesterAndApprover(Convert.ToInt32(reqid));
                   
                    lblApproveBy.Text = dtbl.Rows[0]["Approver"].ToString();
                }
                else
                {
                    lblWH.Text = "";
                    lbldteRequest.Text = "";
                    lbldteApprove.Text = "";
                    lblrequisition.Text = "";
                    lblReqBY.Text = "";
                    lblApproveBy.Text = "";
                    lblreq.Text = "";
                    lblApp.Text = "";
                    lblReqNo.Text = "";
                    lblReqDate.Text = "";
                    lblAppDate.Text = "";
                }
               
               
            }
        }
    }
}