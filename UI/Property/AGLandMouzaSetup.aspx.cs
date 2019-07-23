using BLL.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Property
{
    public partial class AGLandMouzaSetup : System.Web.UI.Page
    {
        #region INIT
        PropertyBLL pbll = new PropertyBLL();
        string xmlString, filePathForXML;
        string MouzaName, MouzaDetails, District;
        int ysnActive;
        private int CheckItem = 1;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Property/Data/MouzaSetup__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML);
                FillDropDownData();
                LoadActive();
                btnUpdate.Visible = false;
                btnMouzaSubmit.Visible = true;
            }
        }
        #endregion

        #region Event
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(Validation() == true)
                {
                    MouzaName = txtMouzaName.Text;
                    MouzaDetails = !string.IsNullOrEmpty(txtMouzaDetails.Text) ? txtMouzaDetails.Text : "N/A";
                    District = ddlDistrictName.SelectedValue;
                    ysnActive = int.Parse(ddlIsActive.SelectedValue);

                    checkXmlItemData(MouzaName);
                    if (CheckItem == 1)
                    {
                        CreateXml(MouzaName, MouzaDetails, District, ysnActive.ToString());

                        LoadGridWithXml();
                        Clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Plot Number Data Already Added.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string sms = "Add Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadExistingMouza();
        }
        protected void btnMouzaSubmit_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Mouza");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Mouza>" + xmlString + "</Mouza>";
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                }
                if(hdnconfirm.Value == "1")
                {
                    Message = pbll.CreateNewMouza(xmlString);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + Message + "');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Canceled Submit Data');", true);
                }
                dgvMouzaSetup.DataSource = null;
                dgvMouzaSetup.DataBind();
            }
            catch (Exception ex)
            {
                string sms = "Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void dgvMouzaSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridWithXml();
                DataSet dsGrid = (DataSet)dgvMouzaSetup.DataSource;
                dsGrid.Tables[0].Rows[dgvMouzaSetup.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvMouzaSetup.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvMouzaSetup.DataSource = "";
                    dgvMouzaSetup.DataBind();
                }
                else
                {
                    LoadGridWithXml();
                }
            }
            catch (Exception ex)
            {
                string sms = "Gridview Delete : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void dgvExistingMouzaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                short MouzaID = Convert.ToInt16(dgvExistingMouzaList.SelectedDataKey["ID"]);
                
                ShowDetailDataForEdit(MouzaID);
                btnUpdate.Visible = true;
                btnMouzaSubmit.Visible = false;
            }
            catch (Exception ex)
            {
                string sms = "Data Load From Grid : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ sms + "');", true);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int MouzaID = !string.IsNullOrEmpty(hfMouzaID.Value) ? int.Parse(hfMouzaID.Value) : 0 ;
                if(MouzaID > 0)
                {
                    if(Validation() == true)
                    {
                        string Mouza = txtMouzaName.Text;
                        string details = !string.IsNullOrEmpty(txtMouzaDetails.Text) ? txtMouzaDetails.Text : "N/A";
                        string District = ddlDistrictName.SelectedValue;
                        int active = int.Parse(ddlIsActive.SelectedValue);
                        int result = pbll.EditExistingMouza(MouzaID, Mouza, details, District, active);
                        if (result > 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Mouza Update Successfully.');", true);
                            LoadExistingMouza();
                            Clear();
                            btnUpdate.Visible = false;
                            btnMouzaSubmit.Visible = true;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Mouza ID Problem.');", true);
                }
                
            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region Method
        private void FillDropDownData()
        {
            DataTable dtDistrict = new DataTable();
            try
            {
                dtDistrict = pbll.GetAllGeoDistrict();
                if (dtDistrict != null && dtDistrict.Rows.Count > 0)
                {
                    ddlDistrictName.DataSource = dtDistrict;
                    ddlDistrictName.DataTextField = "strDistrict";
                    ddlDistrictName.DataValueField = "strDistrict";
                    ddlDistrictName.DataBind();
                }

                ddlDistrictName.Items.Insert(0, new ListItem("--- Select District ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        public void LoadActive()
        {
            ddlIsActive.Items.Insert(0, new ListItem("--- Select ---", "-1"));
            ddlIsActive.Items.Insert(1, new ListItem("Yes", "1"));
            ddlIsActive.Items.Insert(2, new ListItem("No", "0"));
        }
        private void CreateXml(string mouzaName, string mouzaDetails, string district, string ysnActive)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Mouza");
                XmlNode addItem = CreateItemNode(doc, mouzaName, mouzaDetails, district, ysnActive);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Mouza");
                XmlNode addItem = CreateItemNode(doc, mouzaName, mouzaDetails, district, ysnActive);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

        }
        private XmlNode CreateItemNode(XmlDocument doc, string mouzaName, string mouzaDetails, string district, string ysnActive)
        {
            XmlNode node = doc.CreateElement("Mouza");

            XmlAttribute MouzaName = doc.CreateAttribute("mouzaName");
            MouzaName.Value = mouzaName;
            XmlAttribute MouzaDetails = doc.CreateAttribute("mouzaDetails");
            MouzaDetails.Value = mouzaDetails;
            XmlAttribute District = doc.CreateAttribute("district");
            District.Value = district;
            XmlAttribute YsnActive = doc.CreateAttribute("ysnActive");
            YsnActive.Value = ysnActive;

            node.Attributes.Append(MouzaName);
            node.Attributes.Append(MouzaDetails);
            node.Attributes.Append(District);
            node.Attributes.Append(YsnActive);

            return node;
        }
        
        private void checkXmlItemData(string MouzaName)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (MouzaName == (ds.Tables[0].Rows[i]["mouzaName"].ToString()))
                    {
                        CheckItem = 0;
                        break;
                    }
                    else
                    {
                        CheckItem = 1;
                    }
                }
            }
            catch { }
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(txtMouzaName.Text))
            {
                txtMouzaName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Mouza Name');", true);
                return false;
            }
            if (ddlDistrictName.SelectedValue == "-1")
            {
                ddlDistrictName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select A District.');", true);
                return false;
            }
            if (ddlIsActive.SelectedValue == "-1")
            {
                ddlIsActive.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Active/NotActive.');", true);
                return false;
            }
            return true;
        }
        private void Clear()
        {
            txtMouzaName.Text = string.Empty;
            txtMouzaDetails.Text = string.Empty;
            ddlDistrictName.SelectedValue = "-1";
            ddlIsActive.SelectedValue = "-1";
        }
        private void LoadGridWithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Mouza");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Mouza>" + xmlString + "</Mouza>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvMouzaSetup.DataSource = ds;
                }
                else
                {
                    dgvMouzaSetup.DataSource = "";
                }
                dgvMouzaSetup.DataBind();
            }
            catch { }
        }
        private void LoadExistingMouza()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = pbll.GetAllExistingMouza();
                dgvExistingMouzaList.DataSource = dt;
                dgvExistingMouzaList.DataBind();
            }
            catch (Exception ex)
            {
                string sms = "Data Loading Problem" + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ sms + "');", true);
            }
        }
        private void ShowDetailDataForEdit(int mouzaID)
        {
            DataTable dt = new DataTable();
            int active = 0;
            try
            {
                hfMouzaID.Value = mouzaID.ToString();
                dt = pbll.GetSingleExistingMouza(mouzaID);
                if(dt != null && dt.Rows.Count > 0)
                {
                    txtMouzaName.Text = !string.IsNullOrEmpty(dt.Rows[0]["MouzaName"].ToString()) ? dt.Rows[0]["MouzaName"].ToString() : string.Empty;
                    txtMouzaDetails.Text = !string.IsNullOrEmpty(dt.Rows[0]["MouzaDetails"].ToString()) ? dt.Rows[0]["MouzaDetails"].ToString() : string.Empty;
                    ddlDistrictName.SelectedValue = !string.IsNullOrEmpty(dt.Rows[0]["District"].ToString()) ? dt.Rows[0]["District"].ToString() : "-1";
                    if(Convert.ToBoolean(dt.Rows[0]["ysnActive"].ToString()) == true)
                    {
                        active = 1;
                    }
                    ddlIsActive.SelectedValue = !string.IsNullOrEmpty(dt.Rows[0]["ysnActive"].ToString()) ? active.ToString() : "-1";
                }
            }
            catch (Exception ex)
            {
                string sms = "Data Load for Edit : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion


    }
}