using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class BrandItemAllotmentToSupplier : BasePage
    {

        DataTable dt = new DataTable(); TourPlanning objbll = new TourPlanning(); string message;
        string xmlpath; string xmlString = ""; string subtotal = "0.00"; string incentivesubtotal = "0.00"; string samplesubtotal = "0.00";
        string damagesubtotal = "0.00"; string programsubtotal = "0.00"; string PointID; string quantity;
        //DataTable dtbl = new DataTable();
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string secid = "0";
        string item; string itemid;
        string unit, wh, sec, dptid, dudt, remarks, userEnrol, territoryid, SUPPlierid;
        bool ysnChecked;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/REQBrandItm_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "brandItemReqisition.xml");
            if (!IsPostBack) { txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); }
            try
            {
               
                txtItem.Attributes.Add("onkeyUp", "SearchItemText();");
                hdnAction.Value = "0";
                //---------xml----------
                try { File.Delete(xmlpath); }
                catch { }
                //-----**----------//
            }
            catch { }
        }


        [WebMethod]
        public static List<string> GetAutoCompleteBrandItemName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemNameforReqs(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), prefix);
            return result;
        }

        private void CreateXml(string itemid, string item, string secid, string unit, string wh, string sec, string dptid, string dudt, string quantity, string remarks, string userEnrol, string territoryid, string programid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, territoryid, programid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, item, secid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, territoryid, programid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); 
            //LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string itemid, string item, string secid, string unit, string wh, string sec, string dptid, string dudt, string quantity, string remarks, string userEnrol, string territoryid, string programid)
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
            XmlAttribute Programid = doc.CreateAttribute("programid");
            Programid.Value = programid;



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
            node.Attributes.Append(Programid);

            return node;
        }
        protected void ddlWH_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {


            if (hdnconfirm.Value == "1")
            {
                 
                if (dgvAllotmentToSupplier.Rows.Count > 0)
                {
                    try
                    {
                        for (int index = 0; index < dgvAllotmentToSupplier.Rows.Count; index++)
                        {
                            ysnChecked = ((CheckBox)dgvAllotmentToSupplier.Rows[index].Cells[3].Controls[0]).Checked;

                            if (ysnChecked)
                            {


                                PointID = ((HiddenField)dgvAllotmentToSupplier.Rows[index].FindControl("PointID")).Value.ToString();

                                quantity = ((TextBox)dgvAllotmentToSupplier.Rows[index].FindControl("txtQuantity")).Text.ToString();
                                if (quantity == "") { quantity = "0"; }
                                arrayKey = txtItem.Text.Split(delimiterChars);
                                item = ""; itemid = ""; bool proceed = false;
                                if (arrayKey.Length > 0)
                                { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

                                SUPPlierid = txtSupplierName.Text;

                                if (SUPPlierid == "") { SUPPlierid = "0"; }
                                arrayKey = txtSupplierName.Text.Split(delimiterChars);
                             
                                if (arrayKey.Length > 0)
                                { SUPPlierid = arrayKey[1].ToString(); }

                                dptid = HttpContext.Current.Session[SessionParams.DEPT_ID].ToString();
                                dudt = DateTime.Parse(txtDueDate.Text).ToString("yyyy-MM-dd");

                                remarks = "NA";
                                wh = "12";



                                unit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                                sec = "na";


                                userEnrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                                string terid = "0";

                                string Progrmid;
                                try
                                {
                                    Progrmid = drdlProgramName.SelectedValue.ToString();
                                }
                                catch
                                {
                                    Progrmid = "0";


                                }

                                if (Progrmid == null || Progrmid == "")
                                {
                                    Progrmid = "0";
                                }
                                else
                                {
                                    Progrmid = drdlProgramName.SelectedValue.ToString();

                                }


                                CreateXml(itemid, item, SUPPlierid, unit, wh, sec, dptid, dudt, quantity, remarks, userEnrol, PointID, Progrmid);
                            }
                        }
                
                    }
                    catch (Exception ex)
                    { File.Delete(xmlpath); ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }


                    #region ------------ Insert into dataBase -----------

                    int actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    DateTime date = DateTime.Parse(txtDueDate.Text);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("Requisition");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<Requisition>" + xmlString + "</Requisition>";
                    

                    dt = objbll.CreateStoreRequisitionForBrandItem(15, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, 0, DateTime.Now, DateTime.Now);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);
                    File.Delete(xmlpath);
                    //dgvAllotmentToSupplier.DataSource = ""; 
                    dgvAllotmentToSupplier.DataBind();

                    #endregion ------------ Insertion End ----------------

                    //catch (Exception ex)
                    //{ File.Delete(filePathForXML); ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
                }

            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gridRow = ((GridViewRow)((TextBox)sender).NamingContainer);
            int index = gridRow.RowIndex;
            string strQnt = ((TextBox)dgvAllotmentToSupplier.Rows[index].FindControl("txtQuantity")).Text.ToString();
            if (decimal.Parse(strQnt) > 0)
            {
                ((CheckBox)dgvAllotmentToSupplier.Rows[index].FindControl("chkbx")).Checked = true;
            }
            else
            {
                ((CheckBox)dgvAllotmentToSupplier.Rows[index].FindControl("chkbx")).Checked = false;
            }
            
           

        }

        protected void dgvAllotmentToSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

        }
    }
}

       
  