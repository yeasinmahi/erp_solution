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
    public partial class frmTransferOrder : BasePage
    {
        private int intShipid, intOffId, intUomid, vid, enroll, itemid;
        private decimal Qty; private string xmlpath = "", xmlString, ItemName;
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
                dt = objExcel.getShippoint(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(Session[SessionParams.UNIT_ID].ToString()), true);
                ddlshippoint.DataTextField = "strName";
                ddlshippoint.DataValueField = "intShipPointId";
                ddlshippoint.DataSource = dt;
                ddlshippoint.DataBind();
                dt.Clear();
                dt = objExcel.getOffice(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(Session[SessionParams.UNIT_ID].ToString()), true);
                ddlOfficeName.DataTextField = "strName";
                ddlOfficeName.DataValueField = "intSalesOffId";
                ddlOfficeName.DataSource = dt;
                ddlOfficeName.DataBind();
                dt.Clear();
                getShippointTo();
                UomList();
            }
            else { GETItemUom(); }
        }

        private void GETItemUom()
        {
            if (txtItemName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtItemName.Text.Split(delimiterCharss);
                itemid = Int32.Parse(arrayKeyItem[1].ToString());

                dt = TBLL.getUOMlist(itemid);
                ddlUOM.DataTextField = "STRUOM";
                ddlUOM.DataValueField = "INTID";
                ddlUOM.DataSource = dt;
                ddlUOM.DataBind();
            }
        }

        private void UomList()
        {
            dt = DataClass.GetUomList(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlUOM.DataTextField = "strUOM";
            ddlUOM.DataValueField = "intID";
            ddlUOM.DataSource = dt;
            ddlUOM.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    DateTime date = DateTime.Parse("2018-3-24");
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<Voucher>" + xmlString + "</Voucher>";
                    string message = TBLL.RemoteTransferEnrl(xmlString, int.Parse(Session[SessionParams.USER_ID].ToString()), ddlshippoint.SelectedValue, ddlOfficeName.SelectedValue, enroll, ddlShipPointTo.SelectedValue, ddlOfficeTo.SelectedValue, 1);
                    File.Delete(xmlpath);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                catch { }
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
                    intUomid = int.Parse(ddlOfficeTo.Text);
                    Qty = decimal.Parse(txtQty.Text);
                    itemid = Int32.Parse(arrayKeyItem[1].ToString());
                    ItemName = arrayKeyItem[0].ToString();
                    CreateXml(itemid.ToString(), ItemName, Qty.ToString(), intUomid.ToString());
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Customer Blance.');", true);
            }
            //Clearcontrols();
        }

        private void CreateXml(string Itemid, string itemname, string Qty, string UomId)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Voucher");
                XmlNode addItem = CreateNode(doc, Itemid, itemname, Qty, UomId);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Voucher");
                XmlNode addItem = CreateNode(doc, Itemid, itemname, Qty, UomId);
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

        private XmlNode CreateNode(XmlDocument doc, string Itemid, string itemname, string Qty, string UomId)
        {
            XmlNode node = doc.CreateElement("Item");
            XmlAttribute itemid = doc.CreateAttribute("Itemid");
            itemid.Value = Itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute qty = doc.CreateAttribute("Qty");
            qty.Value = Qty;
            XmlAttribute uomId = doc.CreateAttribute("UomId");
            uomId.Value = UomId;

            node.Attributes.Append(itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(qty);
            node.Attributes.Append(uomId);
            return node;
        }

        protected void ddlShipPointTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = DataClass.getToOffice(int.Parse(ddlShipPointTo.SelectedValue));
            ddlOfficeTo.DataTextField = "strName";
            ddlOfficeTo.DataValueField = "intId";
            ddlOfficeTo.DataSource = dt;
            ddlOfficeTo.DataBind();
        }

        private void getShippointTo()
        {
            dt = DataClass.getShipPointList(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlShipPointTo.DataTextField = "strName";
            ddlShipPointTo.DataValueField = "intId";
            ddlShipPointTo.DataSource = dt;
            ddlShipPointTo.DataBind();
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
            return objAutoSearch_BLL.GetItemlist(typeid, int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), prefixText);
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

public class DataClass
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