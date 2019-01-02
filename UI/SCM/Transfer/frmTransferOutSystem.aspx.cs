using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using SCM_BLL;
using System.Data;
using SAD_BLL.AutoChallan;
using UI.ClassFiles;
using System.Xml;
using System.IO;

namespace UI.SCM.Transfer
{
    public partial class frmTransferOutSystem : System.Web.UI.Page
    {
        private int intShipid, intLocationid, intOutWHid, intWHID, intVid, intUomid, vid, enroll, itemid, intReff = 0, inttTransferTypeid;
        private decimal Qty, Values, Stock; private string xmlpath = "", xmlString, ItemName, UOM, msg, Remarks;
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
                getShippointTo();
                getTransferType();
                getSavePermission(int.Parse(Session[SessionParams.USER_ID].ToString()));
            }
            else { }
        }

        private void getSavePermission(int Enroll)
        {
            dt = TBLL.getpermission(Enroll);
            if (bool.Parse(dt.Rows[0]["ysnDistribution"].ToString()) == false)
            {
                btnSave.Visible = true;
                btnTransfer.Visible = false;
            }
            else
            {
                btnSave.Visible = false;
                btnTransfer.Visible = true;
            }
        }

        protected void txtItemName_TextChanged(object sender, EventArgs e)
        {
            GETItemUomInof();
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                for (int index = 0; index < dgv.Rows.Count; index++)
                {
                    string pid = ((Label)dgv.Rows[index].FindControl("lblitemid")).Text.ToString();
                    string paname = ((Label)dgv.Rows[index].FindControl("lblItemname")).Text.ToString();
                    string qty = ((Label)dgv.Rows[index].FindControl("lblQty")).Text.ToString();
                    string uom = ((Label)dgv.Rows[index].FindControl("lblIUom")).Text.ToString();
                    string Type = ((Label)dgv.Rows[index].FindControl("lbltype")).Text.ToString();
                    inttTransferTypeid = 2;
                    intReff = 0;
                    intWHID = int.Parse(ddlshippoint.SelectedValue);
                    intOutWHid = int.Parse(ddlToWH.SelectedValue);
                    intLocationid = 0;
                    if (lblstock.Text == "0")
                    {
                        Stock = Decimal.Parse("0");
                    }
                    else { Stock = Decimal.Parse(lblstock.Text); }
                    Values = (decimal.Parse(lblStockvalue.Text.ToString()) / Stock) * decimal.Parse(txtQty.Text);
                    if (txtVehicle.Text != "")
                    {
                        char[] delimiterCharss = { '[', ']' };
                        arrayKeyItem = txtVehicle.Text.Split(delimiterCharss);
                        if (arrayKeyItem.Length > 0)
                        { intVid = Int32.Parse(arrayKeyItem[1].ToString()); }
                    }
                    else { intVid = 0; }
                    Remarks = txtRemax.Text;
                    msg = TBLL.getSavedata(int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWHID, intOutWHid, intLocationid, int.Parse(Session[SessionParams.USER_ID].ToString()), 0, qty = "0", Values = 0, intVid, Remarks, intReff, inttTransferTypeid, true);

                    msg = TBLL.GetSalesEntryDetils(int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWHID, intOutWHid, intLocationid, int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(msg), int.Parse(pid), qty, Remarks, inttTransferTypeid, ddlTType.SelectedItem.ToString());
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        private void getTransferType()
        {
            dt = TBLL.getTranfertype();
            ddlTType.DataTextField = "strItemTransferType";
            ddlTType.DataValueField = "intAutoID";
            ddlTType.DataSource = dt;
            ddlTType.DataBind();
        }

        private void GETItemUomInof()
        {
            if (txtItemName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtItemName.Text.Split(delimiterCharss);
                itemid = Int32.Parse(arrayKeyItem[1].ToString());
                int? id = null;
                dt = TBLL.getIteminfo(int.Parse(ddlshippoint.SelectedValue), itemid, id);
                if (dt.Rows.Count > 0)
                {
                    ddlLocation.DataTextField = "strLocation";
                    ddlLocation.DataValueField = "intLocation";
                    ddlLocation.DataSource = dt;
                    ddlLocation.DataBind();

                    lblstock.Text = dt.Rows[0]["monStock"].ToString();
                    lblStockvalue.Text = dt.Rows[0]["monValue"].ToString();
                    lblUOM.Text = dt.Rows[0]["strUoM"].ToString();
                    lblstockUOM.Text = dt.Rows[0]["strUoM"].ToString();
                }
                else
                {
                    if (hdnItemid.Value == "")
                    {
                        hdnItemid.Value = "0";
                    }
                    if (int.Parse(hdnItemid.Value.ToString()) != itemid)
                    {
                        dt = TBLL.getStockAlternative(itemid);
                        lblstock.Text = "0".ToString();
                        lblStockvalue.Text = "0".ToString();
                        lblUOM.Text = dt.Rows[0]["strUoM"].ToString();
                        ddlLocation.Items.Add(new ListItem(dt.Rows[0]["strlocationname"].ToString(), dt.Rows[0]["intlocationid"].ToString()));
                        hdnItemid.Value = itemid.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                for (int index = 0; index < dgv.Rows.Count; index++)
                {
                    string pid = ((Label)dgv.Rows[index].FindControl("lblitemid")).Text.ToString();
                    string paname = ((Label)dgv.Rows[index].FindControl("lblItemname")).Text.ToString();
                    string qty = ((Label)dgv.Rows[index].FindControl("lblQty")).Text.ToString();
                    string uom = ((Label)dgv.Rows[index].FindControl("lblIUom")).Text.ToString();
                    string Type = ((Label)dgv.Rows[index].FindControl("lbltype")).Text.ToString();
                    inttTransferTypeid = 2;
                    intReff = 0;
                    intWHID = int.Parse(ddlshippoint.SelectedValue);
                    intOutWHid = int.Parse(ddlToWH.SelectedValue);
                    intLocationid = int.Parse(ddlLocation.SelectedValue);
                    if (lblstock.Text == "0")
                    {
                        Stock = Decimal.Parse("0");
                    }
                    else { Stock = Decimal.Parse(lblstock.Text); }
                    Values = (decimal.Parse(lblStockvalue.Text.ToString()) / Stock) * decimal.Parse(txtQty.Text);
                    if (txtVehicle.Text != "")
                    {
                        char[] delimiterCharss = { '[', ']' };
                        arrayKeyItem = txtVehicle.Text.Split(delimiterCharss);
                        if (arrayKeyItem.Length > 0)
                        { intVid = Int32.Parse(arrayKeyItem[1].ToString()); }
                    }
                    else { intVid = 0; }
                    Remarks = txtRemax.Text;
                    msg = TBLL.getSavedata(int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWHID, intOutWHid, intLocationid, int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(pid), qty, Values, intVid, Remarks, intReff, inttTransferTypeid, false);
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            if (txtItemName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtItemName.Text.Split(delimiterCharss);
                if (arrayKeyItem.Length > 0)
                {
                    intUomid = int.Parse("1");
                    Qty = decimal.Parse(txtQty.Text);
                    itemid = Int32.Parse(arrayKeyItem[1].ToString());
                    ItemName = arrayKeyItem[0].ToString();
                    CreateXml(itemid.ToString(), ItemName, lblUOM.Text.ToString(), Qty.ToString(), ddlTType.SelectedItem.ToString());
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Customer Blance.');", true);
            }
            //Clearcontrols();
        }

        private void CreateXml(string Itemid, string itemname, string uom, string Qty, string Type)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Voucher");
                XmlNode addItem = CreateNode(doc, Itemid, itemname, uom, Qty, Type);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Voucher");
                XmlNode addItem = CreateNode(doc, Itemid, itemname, uom, Qty, Type);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("Voucher");
                xmlString = xlnd.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; }
                dgv.DataBind();
            }
            catch { dgv.DataSource = ""; dgv.DataBind(); }
        }

        private XmlNode CreateNode(XmlDocument doc, string Itemid, string itemname, string uom, string Qty, string Type)
        {
            XmlNode node = doc.CreateElement("Item");
            XmlAttribute itemid = doc.CreateAttribute("Itemid");
            itemid.Value = Itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute qty = doc.CreateAttribute("Qty");
            qty.Value = Qty;
            XmlAttribute ItemType = doc.CreateAttribute("Type");
            ItemType.Value = Type;

            node.Attributes.Append(itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(qty);
            node.Attributes.Append(ItemType);
            return node;
        }

        protected void ddlShipPointTo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void getShippointTo()
        {
            dt = TBLL.getALLWH();
            ddlToWH.DataTextField = "strWareHoseName";
            ddlToWH.DataValueField = "intWHID";
            ddlToWH.DataSource = dt;
            ddlToWH.DataBind();
        }

        #region ******* search **********

        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            int typeid;
            DataTable dt;
            dt = DataClass.GetItemType(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()));
            typeid = int.Parse(dt.Rows[0]["intID"].ToString());
            TransferBLLNew objAutoSearch_BLL = new TransferBLLNew();
            return objAutoSearch_BLL.GetItemlistInv(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] VehicleSearch(string prefixText)
        {
            ExcelDataBLL objAutoSearch_BLL = new ExcelDataBLL();
            return objAutoSearch_BLL.GetVehicle(prefixText);
        }

        protected void dgv_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)dgv.DataSource;
                dsGrid.Tables[0].Rows[dgv.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgv.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(xmlpath); dgv.DataSource = ""; dgv.DataBind(); }
                else { LoadXml(); }
            }
            catch { }
        }

        #endregion ******* search **********

    }
}

public class DataClassNew
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