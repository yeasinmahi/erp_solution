using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SCM_BLL;
using System.Data;
using SAD_BLL.AutoChallan;
using UI.ClassFiles;

namespace UI.SCM.Transfer
{
    public partial class frmTransferIn : BasePage
    {
        private int intShipid, intLocationid, intOutWHid, intWHID, intVid, intUomid, vid, enroll, itemid, intReff = 0, inttTransferTypeid;
        private decimal Qty, Values, Stock; private string xmlpath = "", UOM, msg, Remarks;
        private DataTable dt;
        private string[] arrayKeyItem; private char[] delimiterChars = { '[', ']' };
        private TransferBLLNew TBLL = new TransferBLLNew();
        private ExcelDataBLL objExcel = new ExcelDataBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SCM/Data/TOrder_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                hdnEnroll.Value = "1";
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = TBLL.getWhbyuser(int.Parse(Session[SessionParams.USER_ID].ToString()));
                ddlshippoint.DataTextField = "strDescription";
                ddlshippoint.DataValueField = "intWHID";
                ddlshippoint.DataSource = dt;
                ddlshippoint.DataBind();
                dt.Clear();
                getTransferInId();
            }
            else { }
        }

        private void GETItemUomInof()
        {
            itemid = Int32.Parse(ddlItem.SelectedValue);
            int? id = null;
            dt = TBLL.getIteminfo(int.Parse(ddlshippoint.SelectedValue), itemid, id);
            if (dt.Rows.Count > 0)
            {
                ddlLocation.DataTextField = "strLocation";
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();

                lblStockqty.Text = dt.Rows[0]["monStock"].ToString();

                lblUOm.Text = dt.Rows[0]["strUoM"].ToString();
                lblRUOM.Text = dt.Rows[0]["strUoM"].ToString();
            }
            else
            {
                dt = TBLL.getStockAlternative(itemid);
                lblStockqty.Text = "0".ToString();
                lblUOm.Text = dt.Rows[0]["strUoM"].ToString();
                lblRUOM.Text = dt.Rows[0]["strUoM"].ToString();
                ddlLocation.Items.Add(new ListItem(dt.Rows[0]["strlocationname"].ToString(), dt.Rows[0]["intlocationid"].ToString()));
            }
            dt = TBLL.getLocation(int.Parse(ddlItem.SelectedValue), int.Parse(ddlshippoint.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                ddlLocation.DataTextField = "strLocation";
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();
            }
            else { GETItemUomInof(); }
        }

        protected void ddlTransferIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItem.Items.Add(new ListItem("--Select--", "0"));
            dt = TBLL.GetTINItemlist(int.Parse(ddlTransferIn.SelectedValue));
            ddlItem.DataTextField = "strItem";
            ddlItem.DataValueField = "intitemid";
            ddlItem.DataSource = dt;
            ddlItem.DataBind();
            lblUOm.Text = dt.Rows[0]["strUoM"].ToString();
            lblRUOM.Text = dt.Rows[0]["strUoM"].ToString();
            // lblFromDate.Text ="Date: "+ DateTime.Parse(dt.Rows[0]["dteTransactionDate"].ToString());
            lblFromDate.Text = "Date: " + string.Format("{0:d MMM yyyy}", dt.Rows[0]["dteTransactionDate"]);
            lblItemid.Text = dt.Rows[0]["intitemid"].ToString();
            lblFromWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
            lblQty.Text = "Qty : " + dt.Rows[0]["monQty"].ToString();
            txtQty.Text = dt.Rows[0]["monQty"].ToString();
            hdnFromWH.Value = dt.Rows[0]["intOutWHID"].ToString();
            hdnTransfromValue.Value = dt.Rows[0]["monValue"].ToString();
            hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();

            dt = TBLL.getLocation(int.Parse(ddlItem.SelectedValue), int.Parse(ddlshippoint.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                ddlLocation.DataTextField = "strLocation";
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();
            }
            GETItemUomInof();
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = TBLL.getLocation(int.Parse(ddlItem.SelectedValue), int.Parse(ddlshippoint.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                ddlLocation.DataTextField = "strLocation";
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();
            }
            else { GETItemUomInof(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            inttTransferTypeid = 2;
            intReff = 0;
            intWHID = int.Parse(ddlshippoint.SelectedValue);
            intOutWHid = int.Parse(hdnFromWH.Value);
            intLocationid = int.Parse(ddlLocation.SelectedValue);
            itemid = int.Parse(lblItemid.Text);
            if (lblStockqty.Text == "0")
            { Stock = Decimal.Parse("0"); }
            else { Stock = Decimal.Parse(lblStockqty.Text); }
            Values = (decimal.Parse(hdnTransfromValue.Value));
            intVid = 0; Remarks = txtRemax.Text;
            intReff = int.Parse(ddlTransferIn.SelectedValue);
            inttTransferTypeid = 1;
            Qty = decimal.Parse(txtQty.Text);
            msg = TBLL.getSavedata(int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWHID, intOutWHid, intLocationid, int.Parse(Session[SessionParams.USER_ID].ToString()), itemid, Qty.ToString(), Values, intVid, Remarks, intReff, inttTransferTypeid, false);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
        }

        protected void ddlShipPointTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTransferInId();
        }

        private void getTransferInId()
        {
            dt = TBLL.getTID(int.Parse(ddlshippoint.SelectedValue));
            ddlTransferIn.DataTextField = "strItem";
            ddlTransferIn.DataValueField = "intTransferID";
            ddlTransferIn.DataSource = dt;
            ddlTransferIn.DataBind();
        }
    }
}

public class DataClassNewTransFerIN
{
    public static TransferBLLNew TBLL = new TransferBLLNew();
    public static DataTable dt;

    internal static DataTable GetItemType(int unitid)
    {
        dt = TBLL.Itemtype(unitid);
        return dt;
    }

    internal static DataTable getShipPointList(int unitid)
    {
        dt = TBLL.getShippontList(unitid);
        return dt;
    }

    internal static DataTable getToOffice(int Officeid)
    {
        dt = TBLL.getToOffice(Officeid);
        return dt;
    }

    internal static DataTable GetUomList(int Unitid)
    {
        dt = TBLL.getUOMlist(Unitid);
        return dt;
    }
}