using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL.TourPlan;
using System.Globalization;
using System.IO;
using System.Xml;

namespace UI.HR.TourPlan
{
    public partial class CustomerBankGuarantee : BasePage
    {
        CustBankGauranteeBLL objbankGauranteeBLL = new CustBankGauranteeBLL();
        DataTable dt = new DataTable();
        string xmlpath, xmlString;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath= Server.MapPath("~/HR/TourPlan/Data/CustomerList_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            btnAdd.Visible = false;
            GVCustDetails.Visible = false;
            btnSubmit.Visible = false;
            GVCustList.Visible = false;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int custid = int.Parse(DdlCustomerName.SelectedItem.Value);
            dt = objbankGauranteeBLL.GetCustInfo(custid);
            if (dt.Rows.Count > 0)
            {
                GVCustDetails.DataSource = dt;
                GVCustDetails.DataBind();
                GVCustDetails.Visible = true;
                btnAdd.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                GVCustDetails.Visible = false;
                btnAdd.Visible = false;
            }

            if (GVCustList.Visible==true)
            {
                btnSubmit.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GVCustDetails.Visible = true;
                GVCustList.Visible = true;
                string InsertBy = Session[SessionParams.USER_ID].ToString();
                string unitId = ddlUnit.SelectedValue.ToString();
                string custId = DdlCustomerName.SelectedValue.ToString();
                string bankId = DdlBank.SelectedValue.ToString();
                string branchId = DdlBranch.SelectedValue.ToString();
                string districtId = DdlDistrict.SelectedValue.ToString();
                string BGNo = TxtBGNo.Text;
                string Amount = TxtAmount.Text;
                string fromdate =  DateTime.Parse(txtFormDate.Text).ToString("yyyy-MM-dd");
                string todate = DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd");              
                string bankName = DdlBank.SelectedItem.Text.ToString();
                string branchName = DdlBranch.SelectedItem.Text.ToString();
                string remarks = "Na";
                //int count = GVCustList.Rows.Count;
                

                CreateXml(custId, bankId, branchId, districtId, BGNo, Amount, fromdate, todate, bankName, branchName, remarks, unitId, InsertBy);                   
                 btnSubmit.Visible = true;

            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

        }
       
        private void CreateXml(string custId, string bankId, string branchId, string districtId, string BGNo, string Amount,string fromdate, string todate, string bankName, string branchName, string remarks, string unitId, string InsertBy)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("CustomerBankGaurantee");
                XmlNode addItem = CreateNode(doc, custId, bankId, branchId, districtId, BGNo, Amount, fromdate, todate, bankName, branchName, remarks, unitId, InsertBy);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclarationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclarationNode);
                XmlNode rootNode = doc.CreateElement("CustomerBankGaurantee");
                XmlNode addItem = CreateNode(doc, custId, bankId, branchId, districtId, BGNo, Amount, fromdate, todate, bankName, branchName, remarks, unitId, InsertBy);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string custId, string bankId, string branchId, string districtId, string BGNo, string Amount, string fromdate, string todate, string bankName, string branchName, string remarks, string unitId, string InsertBy)
        {
            XmlNode node = doc.CreateElement("CustomerList");
            XmlAttribute CustId = doc.CreateAttribute("custId");
            CustId.Value = custId;
            XmlAttribute BankId = doc.CreateAttribute("bankId");
            BankId.Value = bankId;
            XmlAttribute BranchId = doc.CreateAttribute("branchId");
            BranchId.Value = branchId;
            XmlAttribute DistrictId = doc.CreateAttribute("districtId");
            DistrictId.Value = districtId;
            XmlAttribute BgNo = doc.CreateAttribute("BGNo");
            BgNo.Value = BGNo;
            XmlAttribute amount = doc.CreateAttribute("Amount");
            amount.Value = Amount;
            XmlAttribute Fromdate = doc.CreateAttribute("fromdate");
            Fromdate.Value = fromdate;
            XmlAttribute Todate = doc.CreateAttribute("todate");
            Todate.Value = todate;           
            XmlAttribute BankName = doc.CreateAttribute("bankName");
            BankName.Value = bankName;
            XmlAttribute BranchName = doc.CreateAttribute("branchName");
            BranchName.Value = branchName;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute UnitId = doc.CreateAttribute("unitId");
            UnitId.Value = unitId;
            XmlAttribute insertBy = doc.CreateAttribute("InsertBy");
            insertBy.Value = InsertBy;
          

            node.Attributes.Append(CustId);
            node.Attributes.Append(BankId);
            node.Attributes.Append(BranchId);
            node.Attributes.Append(DistrictId);
            node.Attributes.Append(BgNo);
            node.Attributes.Append(amount);
            node.Attributes.Append(Fromdate);
            node.Attributes.Append(Todate);           
            node.Attributes.Append(BankName);
            node.Attributes.Append(BranchName);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(UnitId);
            node.Attributes.Append(insertBy);
          
            return node;
        }

        protected void GVCustList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)GVCustList.DataSource;
                dsGrid.Tables[0].Rows[GVCustList.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)GVCustList.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(xmlpath);
                    GVCustList.DataSource = "";
                    GVCustList.DataBind();
                    GVCustList.Visible = false;
                    btnSubmit.Visible = false;
                    GVCustDetails.Visible = false;
                }
                else
                {
                    GVCustDetails.Visible = true;
                    GVCustList.Visible = true;
                    btnSubmit.Visible = true;
                    LoadXml();
                }
                
            }
            catch { }
        }

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("CustomerBankGaurantee");
                xmlString = xlnd.InnerXml;
                xmlString = "<CustomerBankGaurantee>" + xmlString + "</CustomerBankGaurantee>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVCustList.DataSource = ds;
                }
                else
                {
                    GVCustList.DataSource = "";
                }
                GVCustList.DataBind();
            }
            catch
            {
                GVCustList.DataSource = "";
                GVCustList.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (GVCustList.Rows.Count > 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode xmls;
                    if (File.Exists(xmlpath))
                    {
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("CustomerBankGaurantee");
                        xmlString = xmls.InnerXml;
                        xmlString = "<CustomerBankGaurantee>" + xmlString + "</CustomerBankGaurantee>";
                        dt = objbankGauranteeBLL.InsertCustomerBankGauranteeXml(xmlString);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your Request is Successfully Submited...');", true);

                        try { File.Delete(xmlpath); }

                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                        }
                    txtFormDate.Text = "";
                    txtToDate.Text = "";
                    TxtBGNo.Text = "";
                    TxtAmount.Text = "";
                    GVCustList.DataSource = "";
                    GVCustList.DataBind();

                    }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            }
        }

        






















    }
}