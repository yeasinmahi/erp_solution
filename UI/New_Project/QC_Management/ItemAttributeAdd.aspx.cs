using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using Purchase_BLL.Qc_Management;

namespace UI.QC_Management
{
    public partial class ItemAttributAdd : BasePage
    {
        DataTable dtReport = new DataTable();
        DataTable dtUnitname = new DataTable();

        QcBllManagement Report = new QcBllManagement();

        QcBllManagement rpt = new QcBllManagement();
        string filePathForXML;

        string xmlString = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = (Session[SessionParams.USER_ID].ToString());

            filePathForXML = Server.MapPath("agorder" + strEnroll + ".xml");
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();

                try { File.Delete(filePathForXML); }
                catch { }

              //  txtCustomer.Attributes.Add("onkeyUp", "SearchText();");
               // int intjobstation = int.Parse((Session[SessionParams.JOBSTATION_ID].ToString()));
                int intjobstation = int.Parse(("28".ToString()));

                int enroll =int.Parse((Session[SessionParams.USER_ID].ToString()));
             
             
                int Custid = int.Parse(Session["itemid"].ToString());
                dtReport = Report.getITemReport(Custid);

                string itemname = dtReport.Rows[0]["strItemName"].ToString();
                string subcatagory = dtReport.Rows[0]["strSubCategory"].ToString();
                string strUoM = dtReport.Rows[0]["strUoM"].ToString();
                string Category = dtReport.Rows[0]["strCategory"].ToString();

                txtcatagory.Text = Category;
                txtuom.Text = strUoM;
                txtcatagory.Text = Category;
                txtitemname.Text = itemname;
                DataTable dtAttriubtesDetailsReport = new DataTable();
                dtAttriubtesDetailsReport = Report.getAttributesDetailsReport(Custid);
                try
                {
                    GridView2.DataSource = dtAttriubtesDetailsReport;
                    GridView2.DataBind();
                }
                catch { }


                DataTable dtReportddllab = new DataTable();
                dtReportddllab = Report.getReportinlabeqpt(intjobstation);
                try
                {
                    ddllab.DataTextField = "strNameOfAsset";
                    ddllab.DataValueField = "strAssetID";
                    ddllab.DataSource = dtReportddllab;
                    ddllab.DataBind();
                }
                catch { }

            }
         
            LoadGridwithXml();

        }

        //protected void GetResult()
        //{
        //    int Custid;

        //    if (!String.IsNullOrEmpty(txtCustomer.Text))
        //    {
        //        string strSearchKey = txtCustomer.Text;
        //        string[] searchKey = Regex.Split(strSearchKey, ";");
        //        hdnCustomer.Value = searchKey[1];
        //        Int32 technichin = Int32.Parse(hdnCustomer.Value.ToString());
        //        Custid = Convert.ToInt32(technichin.ToString());
        //    }
        //    else
        //    {
        //        Custid = int.Parse("0");
        //    }

        //    dtReport = Report.getITemReport(Custid);

        //    string itemname = dtReport.Rows[0]["strItemName"].ToString();
        //    string subcatagory = dtReport.Rows[0]["strSubCategory"].ToString();
        //    string strUoM = dtReport.Rows[0]["strUoM"].ToString();
        //    string Category = dtReport.Rows[0]["strCategory"].ToString();

        //    txtcatagory.Text = Category;
        //    txtuom.Text = strUoM;
        //    txtcatagory.Text = Category;
        //    txtitemname.Text = itemname;


        //}
        [WebMethod]
        public static List<string> GetAutoCompleteData(string whid, string strSearchKey)
        {
            QcBllManagement objAutoSearch_BLL = new QcBllManagement();
        
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchItemData(int.Parse(whid), strSearchKey);
            return result;

        }

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

       

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtqctest = new DataTable();
            string type = "Specification";
            int intEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            dtqctest = Report.getqctAttributespcifcation(type);
            ddlAttribute.DataTextField = "strItemAttributesName";
            ddlAttribute.DataValueField = "intid";
            ddlAttribute.DataSource = dtqctest;
            ddlAttribute.DataBind();
            hdnattributecatagory.Value = "Specification";
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            DataTable dtqctest = new DataTable();
           // int intEnroll =int.Parse(Session[SessionParams.UNIT_ID].ToString());
           int intEnroll = int.Parse("6".ToString());
            string type = "Qc_test";
            dtqctest = Report.getqctAttribute(type, intEnroll);
            ddlAttribute.DataTextField = "strItemAttributesName";
            ddlAttribute.DataValueField = "intid";
            ddlAttribute.DataSource = dtqctest;
            ddlAttribute.DataBind();
            hdnattributecatagory.Value = "Qc_Test";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dtReportitem = new DataTable();
            int Custid = int.Parse(Session["itemid"].ToString());


            dtReportitem = Report.getITemReport(Custid);

            string itemname = dtReportitem.Rows[0]["strItemName"].ToString();
            string subcatagory = dtReportitem.Rows[0]["strSubCategory"].ToString();
            string strUoM = dtReportitem.Rows[0]["strUoM"].ToString();
            string Category = dtReportitem.Rows[0]["strCategory"].ToString();
            string Itemmasterid =dtReportitem.Rows[0]["intItemMasterID"].ToString();
            string itemid = Custid.ToString();

            Int32 unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            string itemAttribute = ddlAttribute.SelectedItem.ToString();
            string strattributecatagory = hdnattributecatagory.Value;
            string strlabEqptname = ddllab.SelectedItem.ToString();
            string labeqptid = ddllab.SelectedValue.ToString();
            CreateVoucherXml(itemAttribute, itemid, Itemmasterid, strattributecatagory, strlabEqptname,labeqptid);


        }

        private void CreateVoucherXml(string itemAttribute, string itemid, string Itemmasterid, string strattributecatagory,string strlabEqptname,string labeqptid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemAttribute, itemid, Itemmasterid, strattributecatagory,strlabEqptname,labeqptid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemAttribute, itemid, Itemmasterid, strattributecatagory, strlabEqptname, labeqptid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
              LoadGridwithXml();
            // Clear();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemAttribute, string itemid, string Itemmasterid, string strattributecatagory,string strlabEqptname,string labeqptid)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute ItemAttribute = doc.CreateAttribute("itemAttribute");
            ItemAttribute.Value = itemAttribute;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute mItemmasterid = doc.CreateAttribute("Itemmasterid");
            mItemmasterid.Value = Itemmasterid;
            XmlAttribute Strattributecatagory = doc.CreateAttribute("strattributecatagory");
            Strattributecatagory.Value = strattributecatagory;
            XmlAttribute StrlabEqptname = doc.CreateAttribute("strlabEqptname");
            StrlabEqptname.Value = strlabEqptname;
            XmlAttribute Labeqptid = doc.CreateAttribute("labeqptid");
            Labeqptid.Value = labeqptid;

            node.Attributes.Append(ItemAttribute);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(mItemmasterid);
            node.Attributes.Append(Strattributecatagory);
            node.Attributes.Append(StrlabEqptname);
            node.Attributes.Append(Labeqptid);
        

            return node;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)GridView1.DataSource;
                dsGrid.Tables[0].Rows[GridView1.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)GridView1.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); GridView1.DataSource = ""; GridView1.DataBind(); }
                else { LoadGridwithXml(); }

            }

            catch { } 
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { GridView1.DataSource = ds; }

                else { GridView1.DataSource = ""; }
                GridView1.DataBind();
            }
            catch { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dtReportitem = new DataTable();
            int Custid = int.Parse(Session["itemid"].ToString());

            dtReportitem = Report.getITemReport(Custid);

            string itemname = dtReportitem.Rows[0]["strItemName"].ToString();
            string subcatagory = dtReportitem.Rows[0]["strSubCategory"].ToString();
            string strUoM = dtReportitem.Rows[0]["strUoM"].ToString();
            string Category = dtReportitem.Rows[0]["strCategory"].ToString();
            string Itemmasterid = dtReportitem.Rows[0]["intItemMasterID"].ToString();
            string itemid = Custid.ToString();

            Int32 unitid = int.Parse(Session["intUnitID"].ToString());
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            string itemAttribute = ddlAttribute.SelectedItem.ToString();
            string strattributecatagory = hdnattributecatagory.Value;
            string strlabEqptname = ddllab.SelectedItem.ToString();
            string labeqptid = ddllab.SelectedValue.ToString();
            CreateVoucherXml(itemAttribute, itemid, Itemmasterid, strattributecatagory, strlabEqptname, labeqptid);

         
            if (GridView1.Rows.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode vouchers = doc.SelectSingleNode("voucher");
                xmlString = vouchers.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                string msg = rpt.insertAttributeadd(xmlString, unitid, enroll);
                File.Delete(filePathForXML); GridView1.DataSource = ""; GridView1.DataBind(); LoadGridwithXml();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please add first a voucher.');", true);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlcatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    hdnwh.Value = ddlcatagory.SelectedValue.ToString();
            //    int values = int.Parse(hdnwh.Value.ToString());
            //}
            //catch { }
        }

        protected void ddlcatagory_DataBound(object sender, EventArgs e)
        {
            //try
            //{
            //    hdnwh.Value = ddlcatagory.SelectedValue.ToString();
            //}
            //catch { }
        }
    }
}