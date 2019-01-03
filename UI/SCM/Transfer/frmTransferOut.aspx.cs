using System;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using SCM_BLL;
using System.Data;
using SAD_BLL.AutoChallan;
using UI.ClassFiles;
using System.Xml;

namespace UI.SCM.Transfer
{
    public partial class frmTransferOut : System.Web.UI.Page
    {
        private int intShipid, intOffId, intUomid, vid, enroll, itemid;
        private decimal Qty; private string xmlpath = "", xmlString, ItemName;
        private DataTable dt;
        private string[] arrayKeyItem; private char[] delimiterChars = { '[', ']' };
        private TransferBLLNew TBLL = new TransferBLLNew();
        private ExcelDataBLL objExcel = new ExcelDataBLL();

        protected void btnShow_Click(object sender, EventArgs e)
        {
        }

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
            }
            else { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void CreateXml(string Itemid, string itemname, string Qty, string UomId)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
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
            doc.Save(xmlpath);
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

        #endregion ******* search **********

    }
}

public class DataClassnew
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