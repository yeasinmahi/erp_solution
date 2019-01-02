using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.Transfer
{
    public partial class InventoryLoanReceive : BasePage
    {
        private InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        private AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        private DataTable dt = new DataTable(); private string xmlString; private int Id;
        private int enroll, intWh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlWh.DataSource = dt;
                ddlWh.DataTextField = "strName";
                ddlWh.DataValueField = "Id";
                ddlWh.DataBind();
                ddlWh.Items.Insert(0, new ListItem("Select", "0"));

                Session["WareID"] = ddlWh.SelectedValue.ToString();
                dt = objTransfer.GetTtransferDatas(13, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlFrom.DataSource = dt;
                ddlFrom.DataTextField = "strName";
                ddlFrom.DataValueField = "Id";
                ddlFrom.DataBind();
                ddlFrom.Items.Insert(0, new ListItem("Select", "0"));
                ddlLocation.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        #region========================Auto Search============================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            AutoSearch_BLL ast = new AutoSearch_BLL();
            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        #endregion====================Close======================================

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWh.SelectedValue);
                Session["WareID"] = ddlWh.SelectedValue.ToString();
                dt = objTransfer.GetTtransferDatas(13, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlFrom.DataSource = dt;
                ddlFrom.DataTextField = "strName";
                ddlFrom.DataValueField = "Id";
                ddlFrom.DataBind();
                ddlFrom.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch { }
        }

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnPreConfirm.Value == "1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid = arrayKey[1].ToString(); }
                    intWh = int.Parse(ddlWh.SelectedValue);
                    string locationId = ddlLocation.SelectedValue.ToString();
                    int loanPartyId = int.Parse(ddlFrom.SelectedValue.ToString());
                    string recveQty = txtReceQty.Text.ToString();
                    string monValue = txtValue.Text.ToString();
                    string remarks = txtRemarks.Text.ToString();

                    xmlString = "<voucher><voucherentry locationId=" + '"' + locationId + '"' + " recveQty=" + '"' + recveQty + '"' + " itemid=" + '"' + itemid + '"' + " monValue=" + '"' + monValue + '"' + " remarks=" + '"' + remarks + '"' + "/></voucher>".ToString();
                    if (decimal.Parse(recveQty) > 0 && loanPartyId > 0)
                    {
                        string msg = objTransfer.PostTransfer(15, xmlString, intWh, loanPartyId, DateTime.Now, enroll);
                        lblDetalis.Text = ""; txtItem.Text = ""; txtValue.Text = "0"; txtReceQty.Text = "0"; txtRemarks.Text = "";
                        ddlLocation.DataSource = "";
                        ddlLocation.DataBind();
                        ddlLocation.Items.Insert(0, new ListItem("Select", "0"));

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    }
                }
            }
            catch { }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid = arrayKey[1].ToString(); }
                Id = int.Parse(itemid.ToString());
                intWh = int.Parse(ddlWh.SelectedValue);

                dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    string strItems = dt.Rows[0]["strItem"].ToString();
                    string intItem = dt.Rows[0]["intItem"].ToString();
                    string strUom = dt.Rows[0]["strUom"].ToString();
                    string intLocation = dt.Rows[0]["intLocation"].ToString();
                    string strLocation = dt.Rows[0]["strLocation"].ToString();
                    string monStock = dt.Rows[0]["monStock"].ToString();
                    string monValues = dt.Rows[0]["monValue"].ToString();
                    hdnStockQty.Value = dt.Rows[0]["monValue"].ToString();
                    hdnUom.Value = dt.Rows[0]["strUom"].ToString();
                    hdnValue.Value = dt.Rows[0]["monValue"].ToString();
                    string detaliss = "  Stock: " + monStock;
                    lblUom.Text = strUom;
                    lblDetalis.Text = detaliss;
                    //  lblValue.Text = "Value: " + monValues.ToString();
                }
                else { }
                dt = objTransfer.GetTtransferDatas(4, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "strName";
                ddlLocation.DataValueField = "Id";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("Select", "0"));
                dt.Clear();

                //lblDetalis.Text = ""; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Stock is not avaiable!');", true);
            }
            catch { }
        }
    }
}