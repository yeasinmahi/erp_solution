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
        private Bom_BLL _objBom = new Bom_BLL();
        private DataTable _dt = new DataTable();
        private int _intwh, _enroll, _bomId, _intBomStandard; private string _xmlData;
        private int _checkItem = 1, _intWh; private string[] _arrayKey;

        private char[] _delimiterChars = { '[', ']' };
        private string _filePathForXml; private string _xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            _enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            _filePathForXml = Server.MapPath("~/SCM/Data/ber__" + _enroll + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(_filePathForXml); }
                catch
                {
                    // ignored
                }

                LoadGrid();
            }
        }

        public void LoadGrid()
        {
            string srrId = Request.QueryString["srrId"];
            string itemId = Request.QueryString["itemId"];
            int intwh = int.Parse(Request.QueryString["whid"]);
            string vtype = Request.QueryString["Vtype"];
            string dteFrom = Request.QueryString["dteFrom"];
            string dteTo = Request.QueryString["dteTo"];
            claenderDte.SelectedDate = DateTime.Parse(dteFrom);
            _xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>";
            if (vtype == "Item")
            {
                _dt = _objBom.GetBomData(12, _xmlData, intwh, int.Parse(itemId), DateTime.Now, _enroll);
                if (_dt.Rows.Count > 0)
                {
                    dgvReq.DataSource = _dt;
                    dgvReq.DataBind();
                }
            }
            else
            {
                _dt = _objBom.GetBomData(13, _xmlData, intwh, int.Parse(srrId), DateTime.Now, _enroll);
                dgvItems.DataSource = _dt;
                dgvItems.DataBind();
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
                        _objBom.UpdateRequsitionByReqId(qnt, Convert.ToInt32(productionId), Convert.ToInt32(itemId));
                    }
                    else
                    {
                        _objBom.UpdateRequsitionByProductId(qnt, Convert.ToInt32(productionId), Convert.ToInt32(itemId));
                    }
                    LoadGrid();
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