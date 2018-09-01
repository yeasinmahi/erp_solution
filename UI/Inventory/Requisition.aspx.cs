using HR_BLL.Global;
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
    public partial class Requisition : BasePage
    {
        string xmlpath; string xmlString = "", xml = ""; DaysOfWeek bll = new DaysOfWeek(); string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string secid = "0"; DataTable dtbl = new DataTable(); DataTable dt = new DataTable(); int intEnroll, intInsertBy = 0;
        int type, actionby, id;bool active;
        DateTime fdate, tdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            xmlpath = Server.MapPath("~/Inventory/Data/REQ_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                hdnpoint.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                if ((int.Parse(hdnpoint.Value) >= 1 && int.Parse(hdnpoint.Value) <= 22)) { if (hdnpoint.Value == "2") { hdntype.Value = "0"; } else { hdntype.Value = "1"; } }
                else { hdntype.Value = "0"; } txtSection.Text = ""; hdnwh.Value = ddlWH.SelectedValue.ToString();
                lblDept.Text = HttpContext.Current.Session[SessionParams.DEPT_NAME].ToString();
                pnlUpperControl.DataBind(); txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //txtItem.Attributes.Add("onkeyUp", "SearchText();"); 
                Clearcontrols();
                try { File.Delete(xmlpath); } catch { }

                Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                dt = new DataTable();
                dt =bll.CostCetnterUnit(intUnit);
                DdlCostCenter.DataSource = dt;
                DdlCostCenter.DataTextField = "Name";
                DdlCostCenter.DataValueField = "ID";
                DdlCostCenter.DataBind();

                if(hdnEnroll.Value == "1039" || hdnEnroll.Value == "1388" || hdnEnroll.Value == "11621")
                {
                    txtSearchAssignedTo.Visible = true;
                    lblReqBy.Visible = true;                    
                }
                else
                {
                    txtSearchAssignedTo.Visible = false;
                    lblReqBy.Visible = false;
                }

                dgvListByEnroll.Visible = false;
            }
            
        }

        
        //[WebMethod]
        //public static List<string> GetAutoCompleteData(string whid, string searchKey)
        //{
        //    AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        //    List<string> result = new List<string>();
        //    if (searchKey.Trim().Length >= 3)
        //    { result = objAutoSearch_BLL.GetItemLists(int.Parse(whid), searchKey); }
        //    return result;
        //}
        [WebMethod]
        [ScriptMethod]
        public static string[]GetWearHouseRequesision(string prefixText, int count)
        {
            Int32 WHID = Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
                       
           return objAutoSearch_BLL.GetItemLists(WHID.ToString(), prefixText);
           
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemListsForStoreReq(string prefixText)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.GetItemListsForStoreReq(prefixText);
        }

        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[2].ToString());
            }
            catch { intEnroll = 0; }

            dgvListByEnroll.Visible = true;
            dgvlist.Visible = false;
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                type = 1;
                xml = "";
                id = 0;
                string fd = "2020-12-31";
                string td = "2020-12-31";
                fdate = DateTime.Parse(fd.ToString());
                tdate = DateTime.Parse(td.ToString());

                dt = new DataTable();
                dt = bll.CreateStoreRequisition(type, intEnroll, xml, id, fdate, tdate, intEnroll);
                dgvListByEnroll.DataSource = dt;
                dgvListByEnroll.DataBind();
            }
            catch { }
        }
        public void linkGoSomewhere_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewPolicy('" + 0 + "','" + "Monthlyindent.jpg".ToString() + "');", true);

            
        }
        private void Clearcontrols()
        { txtQuantity.Text = "0.00"; txtItem.Text = ""; hdfEmpCode.Value = ""; txtRemarks.Text = "";
        txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); }
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
        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("Requisition");
                xmlString = xlnd.InnerXml;
                xmlString = "<Requisition>" + xmlString + "</Requisition>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; } dgv.DataBind();
            }
            catch { dgv.DataSource = ""; dgv.DataBind();}
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    string item = ""; string itemid = ""; bool proceed=false;
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }
                    string dptid = HttpContext.Current.Session[SessionParams.DEPT_ID].ToString();
                    string dudt = DateTime.Parse(txtDueDate.Text).ToString("yyyy-MM-dd");
                    string quantity = txtQuantity.Text;
                    string remarks = txtRemarks.Text;
                    string wh = hdnwh.Value;
                    arrayKey = ddlWH.SelectedItem.Text.Split(delimiterChars);
                    string unit = arrayKey[1].ToString();
                    string sec = txtSection.Text;
                    int cnt = dgv.Rows.Count;
                    string cos =DdlCostCenter.SelectedValue.ToString();
                    dt = new DataTable();
                    // dt = bll.CheckCurrentStock(Convert.ToInt32(wh), Convert.ToInt32(itemid));
                    int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = bll.CheckItemPolisy(enroll, Convert.ToInt32(itemid));
                    if (dt.Rows.Count > 0)
                    {
                        active = true;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('(Policy Violation) " +
                            "In the running month you have already given rquisition of same Item.');", true);

                    }
                    else { active = false; }
                    // decimal stocks = Decimal.Parse(dt.Rows[0]["stock"].ToString());
                    //ItemPolisyDataTableTableAdapter
                     
                        if (cnt == 0)
                        {
                            CreateXml(itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, cos);
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
                                CreateXml(itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, cos);
                                Clearcontrols();
                            }
                        }
                    
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('In the running month you have already given rquisition of same Item.');", true);
                    //}
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }


        private void CreateXml(string itemid, string item, string secid, string unit, string wh, string sec, string dptid, string dudt, string quantity, string remarks, string cos)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, cos);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, cos);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string itemid, string item, string secid, string unit, string wh, string sec, string dptid, string dudt, string quantity, string remarks,string cos)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Secid = doc.CreateAttribute("secid");
            Secid.Value = secid;
            XmlAttribute Unit = doc.CreateAttribute("unit");
            Unit.Value = unit;
            XmlAttribute Wh = doc.CreateAttribute("wh");
            Wh.Value = wh;
            XmlAttribute Sec = doc.CreateAttribute("sec");
            Sec.Value = sec;
            XmlAttribute Dptid = doc.CreateAttribute("dptid");
            Dptid.Value = dptid;
            XmlAttribute Dudt = doc.CreateAttribute("dudt");
            Dudt.Value = dudt;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
             XmlAttribute Cos = doc.CreateAttribute("cos");
            Cos.Value = cos;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Item);
            node.Attributes.Append(Secid);
            node.Attributes.Append(Unit);
            node.Attributes.Append(Wh);
            node.Attributes.Append(Sec);
            node.Attributes.Append(Dptid);
            node.Attributes.Append(Dudt);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(Remarks);
              node.Attributes.Append(Cos);
            return node;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                try
                {
                    try
                    {
                        intInsertBy = int.Parse(hdnEnroll.Value);
                        if (txtSearchAssignedTo.Text == "")
                        {
                            intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        }
                        else
                        {
                            char[] ch1 = { '[', ']' };
                            string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                            intEnroll = int.Parse(temp1[2].ToString());
                        }
                    }
                    catch { intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()); }

                    XmlDocument doc = new XmlDocument(); XmlNode xmls;
                    if (File.Exists(xmlpath))
                    {
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("Requisition");
                        xmlString = xmls.InnerXml;
                        xmlString = "<Requisition>" + xmlString + "</Requisition>";
                        dtbl = bll.CreateStoreRequisition(0, intEnroll, xmlString, 0, DateTime.Now, DateTime.Now, intInsertBy);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dtbl.Rows[0]["Messages"].ToString() + "');", true);
                        File.Delete(xmlpath); Clearcontrols(); dgv.DataSource = ""; dgv.DataBind(); dgvlist.DataBind();
                        txtSearchAssignedTo.Text = "";
                    }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            }
        }
        protected void Dtls_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + datas[0].ToString() + "');", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }



        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        { 
           // hdnwh.Value = ddlWH.SelectedValue.ToString();
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
            File.Delete(xmlpath); LoadXml();
        }
        protected void ddlWH_DataBound(object sender, EventArgs e)
        {
            //hdnwh.Value = ddlWH.SelectedValue.ToString();
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