using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;


namespace UI.Inventory
{
    public partial class BrandItemReceiveFromSupplierPointEnd : BasePage
    {
        string xmlpath; string xmlString = ""; TourPlanning bll = new TourPlanning();
        string[] arrayKey; char[] delimiterChars = { '[', ']' }; string[] arrayKeySupplier;
        string secid = "0"; DataTable dtbl = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/BrandITEMReceivbyPOINT_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "brandItemRecvbywh.xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                hdnunit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

                txtItem.Attributes.Add("onkeyUp", "SearchItemText();");
                txtSupplierName.Attributes.Add("onkeyUp", "SearchSupplierlistText();");
                hdnAction.Value = "0";
                ////---------xml----------
                try { File.Delete(xmlpath); }
                catch { }
                ////-----**----------//
            }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteBrandItemName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemNameforReqs(int.Parse("13"), prefix);
            return result;

        }

        [WebMethod]
        public static List<string> GetAutoCompleteBrandItemNameWithStockStatus(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemNameWithstockstatus(int.Parse("12"), prefix);
            return result;

        }



        /////


        [WebMethod]
        public static List<string> GetAutoCompleteSupplierName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemSupplierList(int.Parse("16"), prefix);
            return result;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }
                string dptid = HttpContext.Current.Session[SessionParams.DEPT_ID].ToString();
                string dudt = DateTime.Parse(txtDueDate.Text).ToString("yyyy-MM-dd");
                string quantity = txtQuantity.Text;
                string purhcaseorder = txtpo.Text;
                string recvchallan = txtChallan.Text;
                arrayKeySupplier = txtSupplierName.Text.Split(delimiterChars);
                string supplier = ""; string supplierid = "";
                string wh = ddlWH.SelectedValue.ToString();

                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

                if (arrayKeySupplier.Length > 0)
                { supplier = arrayKeySupplier[0].ToString(); supplierid = arrayKeySupplier[1].ToString(); }

                int cnt = dgv.Rows.Count;

                if (cnt == 0)
                {
                    CreateXml(dudt, item, itemid, quantity, purhcaseorder, recvchallan, supplierid, supplier, wh);
                    Clearcontrols();
                }

                else
                {
                    for (int r = 0; r < cnt; r++)
                    {
                        string itmid = ((HiddenField)dgv.Rows[r].FindControl("hdnitmid")).Value.ToString();
                        if (itemid != itmid) { proceed = true; }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select another item.');", true);
                            break;
                        }
                    }

                    if (proceed == true)
                    {
                        CreateXml(dudt, item, itemid, quantity, purhcaseorder, recvchallan, supplierid, supplier, wh);
                        Clearcontrols();
                    }
                }

            }
        }

        private void Clearcontrols()
        {
            txtQuantity.Text = "0.00"; txtItem.Text = ""; hdfEmpCode.Value = ""; txtChallan.Text = "";
            txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void CreateXml(string dudt, string item, string itemid, string quantity, string po, string challan, string supplierid, string suppliername, string whid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("BrandItemRecvbywh");
                XmlNode addItem = CreateNode(doc, dudt, item, itemid, quantity, po, challan, supplierid, suppliername, whid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BrandItemRecvbywh");
                XmlNode addItem = CreateNode(doc, dudt, item, itemid, quantity, po, challan, supplierid, suppliername, whid);
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
                XmlNode xlnd = doc.SelectSingleNode("BrandItemRecvbywh");
                xmlString = xlnd.InnerXml;
                xmlString = "<BrandItemRecvbywh>" + xmlString + "</BrandItemRecvbywh>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; } dgv.DataBind();
            }
            catch { dgv.DataSource = ""; dgv.DataBind(); }
        }

        private XmlNode CreateNode(XmlDocument doc, string dudt, string item, string itemid, string quantity, string po, string challan, string supplierid, string suppliername, string whid)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute DUDT = doc.CreateAttribute("dudt");
            DUDT.Value = dudt;
            XmlAttribute ITEM = doc.CreateAttribute("item");
            ITEM.Value = item;
            XmlAttribute ITEMID = doc.CreateAttribute("itemid");
            ITEMID.Value = itemid;
            XmlAttribute QUANTITY = doc.CreateAttribute("quantity");
            QUANTITY.Value = quantity;
            XmlAttribute PURCHASEORDER = doc.CreateAttribute("po");
            PURCHASEORDER.Value = po;
            XmlAttribute CHALLAN = doc.CreateAttribute("challan");
            CHALLAN.Value = challan;
            XmlAttribute SUPPLIERID = doc.CreateAttribute("supplierid");
            SUPPLIERID.Value = supplierid;
            XmlAttribute SUPPLIERNAME = doc.CreateAttribute("suppliername");
            SUPPLIERNAME.Value = suppliername;
            XmlAttribute WHID = doc.CreateAttribute("whid");
            WHID.Value = whid;
            node.Attributes.Append(DUDT);
            node.Attributes.Append(ITEM);
            node.Attributes.Append(ITEMID);
            node.Attributes.Append(QUANTITY);
            node.Attributes.Append(PURCHASEORDER);
            node.Attributes.Append(CHALLAN);
            node.Attributes.Append(SUPPLIERID);
            node.Attributes.Append(SUPPLIERNAME);
            node.Attributes.Append(WHID);



            return node;
        }
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string Recvdate = DateTime.Parse(txtDueDate.Text).ToString("yyyy-MM-dd");
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument(); XmlNode xmls;
                    if (File.Exists(xmlpath))
                    {
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("BrandItemRecvbywh");
                        xmlString = xmls.InnerXml;
                        xmlString = "<BrandItemRecvbywh>" + xmlString + "</BrandItemRecvbywh>";

                        dtbl = bll.CreateBrandItmRecvChallanbyWH(1, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, 0, DateTime.Now, DateTime.Now, int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()));
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dtbl.Rows[0]["Messages"].ToString() + "');", true);
                        File.Delete(xmlpath); Clearcontrols(); dgv.DataSource = ""; dgv.DataBind();
                        //dgvlist.DataBind();
                    }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            }
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

        protected void ddlWH_DataBound(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
            File.Delete(xmlpath); LoadXml();
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
            File.Delete(xmlpath); LoadXml();
        }


    }
}