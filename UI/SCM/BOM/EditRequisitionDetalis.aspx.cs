using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class EditRequisitionDetalis : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, enroll, BomId, intBomStandard; private string xmlData;
        private int CheckItem = 1, intWh; private string[] arrayKey;

        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/ber__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); }
                catch { }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string srrId = Request.QueryString["srrId"].ToString();
                string itemId = Request.QueryString["itemId"].ToString();
                int intwh = int.Parse(Request.QueryString["whid"].ToString());
                string Vtype = Request.QueryString["Vtype"].ToString();
                string dteFrom = Request.QueryString["dteFrom"].ToString();
                string dteTo = Request.QueryString["dteTo"].ToString();
                claenderDte.SelectedDate = DateTime.Parse(dteFrom.ToString());
                xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                if (Vtype == "Item")
                {
                    dt = objBom.GetBomData(12, xmlData, intwh, int.Parse(itemId), DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        dgvReq.DataSource = dt;
                        dgvReq.DataBind();
                    }
                }
                else
                {
                    dt = objBom.GetBomData(13, xmlData, intwh, int.Parse(srrId), DateTime.Now, enroll);
                    dgvItems.DataSource = dt;
                    dgvItems.DataBind();
                }
            }
        }

        protected void btnEditSr_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = Utility.GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string productionId = ((Label)row.FindControl("lblProductionId")).Text;
            string production = ((Label)row.FindControl("lblProduction")).Text;
            string itemId = ((Label)row.FindControl("lblItemId")).Text;
            string quantity = ((Label)row.FindControl("lblQuantity")).Text;

            txtItemId.Text = itemId;
            txtItemName.Text = production;
            txtProductionId.Text = productionId;
            txtQuantity.Text = quantity;

            hdnType.Value = "Item";
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
        }

        protected void btnEditItem_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = Utility.GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string itemId = ((Label)row.FindControl("lblItemId")).Text;
            string item = ((Label)row.FindControl("lblItem")).Text;
            string productionId = ((Label)row.FindControl("lblProductionId")).Text;
            string quantity = ((Label)row.FindControl("lblQuantity")).Text;

            txtItemId.Text = itemId;
            txtItemName.Text = item;
            txtProductionId.Text = productionId;
            txtQuantity.Text = quantity;

            hdnType.Value = "Sr";
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            string itemId = txtItemId.Text;
            string productionId = txtProductionId.Text;
            string quantity = txtQuantity.Text;
            if (string.IsNullOrWhiteSpace(itemId))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "alert('Please click edit button to select item');", true);
                return;
            }
            if (!string.IsNullOrWhiteSpace(quantity))
            {
                decimal qnt;
                try
                {
                    qnt = decimal.Parse(quantity);
                    if (hdnType.Value.Equals("Item"))
                    {
                        objBom.UpdateRequsitionByReqId(qnt, Convert.ToInt32(productionId), Convert.ToInt32(itemId));
                    }
                    else
                    {
                        //objBom.UpdateRequsition(qnt, Convert.ToInt32(productionId), Convert.ToInt32(itemId));
                    }
                }
                catch (Exception exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        "alert('Please write quantity in properly');", true);
                    return;
                }
            }
        }
    }
}