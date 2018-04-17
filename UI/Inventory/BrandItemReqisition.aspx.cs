using HR_BLL.Employee;
using HR_BLL.Global;
using HR_BLL.TourPlan;
using LOGIS_BLL;
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
    public partial class BrandItemReqisition : BasePage
    {
        //char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        //string filePathForXML;

        string xmlpath; string xmlString = ""; TourPlanning bll = new TourPlanning(); 
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string secid = "0"; DataTable dtbl = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/REQBrandItm_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "brandItemReqisition.xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                hdnunit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
                txtItem.Attributes.Add("onkeyUp", "SearchItemText();");
                hdnAction.Value = "0";
                ////---------xml----------
                try { File.Delete(xmlpath); }
                catch { }
                ////-----**----------//
            }
            else
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int enr = int.Parse(code.ToString());
                    LoadFieldValue(enr);

                }
                else
                {
                    //ClearControls();
                }
            }
        }

        private void LoadFieldValue(int enrol)
        {
            try
            {

                EmployeeRegistration objenrol = new EmployeeRegistration();
                DataTable objDT = new DataTable();
                objDT = objenrol.GetEmployeeProfileByEnrol(enrol);
                if (objDT.Rows.Count >= 0)
                {

                    txtSection.Text = objDT.Rows[0]["strDepatrment"].ToString();
                    lblJobstation.Text = objDT.Rows[0]["strJobStationName"].ToString();
                    lblContactNumber.Text = objDT.Rows[0]["strContactNo1"].ToString();
                    textEnrol.Text = objDT.Rows[0]["strEmployeeCode"].ToString();
                }

            }
            catch (Exception ex) { throw ex; }
        }


        private void CreateXml(string itemid, string item, string secid, string unit, string wh, string sec, string dptid, string dudt, string quantity, string remarks,string userEnrol,string territoryid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, territoryid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, territoryid);
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
                XmlNode xlnd = doc.SelectSingleNode("Requisition");
                xmlString = xlnd.InnerXml;
                xmlString = "<Requisition>" + xmlString + "</Requisition>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; } dgv.DataBind();
            }
            catch { dgv.DataSource = ""; dgv.DataBind(); }
        }

        private XmlNode CreateNode(XmlDocument doc, string itemid, string item, string secid, string unit, string wh, string sec, string dptid, string dudt, string quantity, string remarks,string userEnrol,string territoryid)
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

            XmlAttribute Userenrol = doc.CreateAttribute("userEnrol");
            Userenrol.Value = userEnrol;

            XmlAttribute Territoryid = doc.CreateAttribute("territoryid");
            Territoryid.Value = territoryid;

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
            node.Attributes.Append(Userenrol);
            node.Attributes.Append(Territoryid);


            return node;
        }











        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

   

        [WebMethod]
        public static List<string> GetAutoCompleteBrandItemName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable(); 
            List<string> result = new List<string>();
            result = objbll.getBrandItemNameforReqs(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), prefix);
            return result;
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
        private void Clearcontrols()
        {
            txtQuantity.Text = "0.00"; txtItem.Text = ""; hdfEmpCode.Value = ""; txtRemarks.Text = "";
            txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                string remarks = txtRemarks.Text;
                string wh;
                try {  wh = ddlWH.SelectedValue.ToString(); }
                catch { wh = "0"; }
                
                
                //arrayKey = ddlWH.SelectedItem.Text.Split(delimiterChars);
                string unit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                string sec = txtSection.Text;
           
                string strSearchKey = txtFullName.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();
                string strCustname = strSearchKey;
                string userEnrol =code.ToString();
                string terid;
                try
                {
                    terid = drdlTerritory.SelectedValue.ToString();
                }
                catch
                {
                    terid = "0";


                }
              
                if (terid == null || terid == "")
                {
                    terid = "0";
                }
                else
                {
                    terid = drdlTerritory.SelectedValue.ToString();

                }
                

               


                int cnt = dgv.Rows.Count;

                if (cnt == 0)
                {
                    CreateXml(itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, terid);
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
                        CreateXml(itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, terid);
                        Clearcontrols();
                    }
                }

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument(); XmlNode xmls;
                    if (File.Exists(xmlpath))
                    {
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("Requisition");
                        xmlString = xmls.InnerXml;
                        xmlString = "<Requisition>" + xmlString + "</Requisition>";
                        
                        dtbl = bll.CreateStoreRequisitionForBrandItem(0, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, 0, DateTime.Now, DateTime.Now);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dtbl.Rows[0]["Messages"].ToString() + "');", true);
                        File.Delete(xmlpath); Clearcontrols(); dgv.DataSource = ""; dgv.DataBind();
                        dgvlist.DataBind();
                    }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
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


    }
}