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
    public partial class AGLandPlotByMouzaSetup : System.Web.UI.Page
    {
        #region INIT
        PropertyBLL pbll = new PropertyBLL();
        string xmlString, filePathForXML;
        string MouzaName, PlotTypeName, PlotNo;
        int MouzaID,PlotTypeID, ysnActive;
        private int CheckItem = 1;
        private decimal PlotArea;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Property/Data/PlotByMoza__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML);
                FillDropDownData();
                LoadActive();
                btnUpdate.Visible = false;
                btnPlotByMouzaSubmit.Visible = true;
            }
        }
        #endregion

        #region Event
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation() == true)
                {
                    MouzaID = int.Parse(ddlMouzaName.SelectedValue);
                    MouzaName = ddlMouzaName.SelectedItem.ToString();
                    PlotTypeID = int.Parse(ddlPlotType.SelectedValue);
                    PlotTypeName = ddlPlotType.SelectedItem.ToString();

                    PlotNo = !string.IsNullOrEmpty(txtPlotNo.Text) ? txtPlotNo.Text : "N/A";
                    PlotArea = !string.IsNullOrEmpty(txtPlotArea.Text) ? decimal.Parse(txtPlotArea.Text) : 0;
                    ysnActive = int.Parse(ddlIsActive.SelectedValue);

                    checkXmlItemData(MouzaName);
                    if (CheckItem == 1)
                    {
                        CreateXml(MouzaID.ToString(), MouzaName, PlotTypeID.ToString(), PlotTypeName, PlotNo, PlotArea.ToString(), ysnActive.ToString());

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
        protected void btnPlotByMouzaSubmit_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("PMouza");
                xmlString = dSftTm.InnerXml;
                xmlString = "<PMouza>" + xmlString + "</PMouza>";
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                }
                if (hdnconfirm.Value == "1")
                {
                    Message = pbll.InsertPlotByMouza(xmlString);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + Message + "');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Canceled Submit Data');", true);
                }
                dgvPlotByMouzaSetup.DataSource = null;
                dgvPlotByMouzaSetup.DataBind();
            }
            catch (Exception ex)
            {
                string sms = "Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int PlotID = !string.IsNullOrEmpty(hfPlotID.Value) ? int.Parse(hfPlotID.Value) : 0;
                if (PlotID > 0)
                {
                    if (Validation() == true)
                    {
                        int MouzaID = int.Parse(ddlMouzaName.SelectedValue);
                        string Mouza = ddlMouzaName.SelectedItem.ToString();
                        int PlotTypeID = int.Parse(ddlPlotType.SelectedValue);
                        string PlotType = ddlPlotType.SelectedItem.ToString();
                        string PlotNo = !string.IsNullOrEmpty(txtPlotNo.Text) ? txtPlotNo.Text : "N/A";
                        decimal PlotArea = !string.IsNullOrEmpty(txtPlotArea.Text) ? decimal.Parse(txtPlotArea.Text) : 0;
                        int active = int.Parse(ddlIsActive.SelectedValue);
                        int result = pbll.EditExistingPlotByMouza(MouzaID, PlotTypeID, PlotNo, PlotArea, active, PlotID);
                        if (result > 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Plot Update Successfully.');", true);
                            LoadExistingPlot();
                            Clear();
                            btnUpdate.Visible = false;
                            btnPlotByMouzaSubmit.Visible = true;
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
        protected void dgvPlotByMouzaSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridWithXml();
                DataSet dsGrid = (DataSet)dgvPlotByMouzaSetup.DataSource;
                dsGrid.Tables[0].Rows[dgvPlotByMouzaSetup.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvPlotByMouzaSetup.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvPlotByMouzaSetup.DataSource = "";
                    dgvPlotByMouzaSetup.DataBind();
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
        protected void dgvPlotByMouzaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                short PlotID = Convert.ToInt16(dgvPlotByMouzaList.SelectedDataKey["ID"]);

                ShowDetailDataForEdit(PlotID);
                btnUpdate.Visible = true;
                btnPlotByMouzaSubmit.Visible = false;
            }
            catch (Exception ex)
            {
                string sms = "Data Load From Grid : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadExistingPlot();
        }
        #endregion

        #region Method
        private void FillDropDownData()
        {
            DataTable dtMouza = new DataTable();
            DataTable dtPlotType = new DataTable();
            try
            {
                dtMouza = pbll.GetMouzaForPlot();
                dtPlotType = pbll.GetPlotType();
                if (dtMouza != null && dtMouza.Rows.Count > 0)
                {
                    ddlMouzaName.DataSource = dtMouza;
                    ddlMouzaName.DataTextField = "MouzaDetail";
                    ddlMouzaName.DataValueField = "intMouzaId";
                    ddlMouzaName.DataBind();
                }

                if (dtPlotType != null && dtPlotType.Rows.Count > 0)
                {
                    ddlPlotType.DataSource = dtPlotType;
                    ddlPlotType.DataTextField = "strPlotType";
                    ddlPlotType.DataValueField = "intPlotTypeId";
                    ddlPlotType.DataBind();
                }

                ddlMouzaName.Items.Insert(0, new ListItem("--- Select Mouza ---", "-1"));
                ddlPlotType.Items.Insert(0, new ListItem("--- Select Plot Type ---", "-1"));
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
        private void CreateXml(string intMouzaID,string strMouza, string intPlotTypeID, string strPlotType, string strPlotNo, string strPlotArea, string ysnActive)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("PMouza");
                XmlNode addItem = CreateItemNode(doc, intMouzaID, strMouza, intPlotTypeID, strPlotType, strPlotNo, strPlotArea, ysnActive);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("PMouza");
                XmlNode addItem = CreateItemNode(doc, intMouzaID, strMouza, intPlotTypeID, strPlotType, strPlotNo, strPlotArea, ysnActive);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

        }
        private XmlNode CreateItemNode(XmlDocument doc, string intMouzaID, string strMouza, string intPlotTypeID, string strPlotType, string strPlotNo, string strPlotArea, string ysnActive)
        {
            XmlNode node = doc.CreateElement("PMouza");

            XmlAttribute IntMouzaID = doc.CreateAttribute("intMouzaID");
            IntMouzaID.Value = intMouzaID;
            XmlAttribute StrMouza = doc.CreateAttribute("strMouza");
            StrMouza.Value = strMouza;
            XmlAttribute IntPlotTypeID = doc.CreateAttribute("intPlotTypeID");
            IntPlotTypeID.Value = intPlotTypeID;
            XmlAttribute StrPlotType = doc.CreateAttribute("strPlotType");
            StrPlotType.Value = strPlotType;
            XmlAttribute StrPlotNo = doc.CreateAttribute("strPlotNo");
            StrPlotNo.Value = strPlotNo;
            XmlAttribute StrPlotArea = doc.CreateAttribute("strPlotArea");
            StrPlotArea.Value = strPlotArea;
            XmlAttribute YsnActive = doc.CreateAttribute("ysnActive");
            YsnActive.Value = ysnActive;

            node.Attributes.Append(IntMouzaID);
            node.Attributes.Append(StrMouza);
            node.Attributes.Append(IntPlotTypeID);
            node.Attributes.Append(StrPlotType);
            node.Attributes.Append(StrPlotNo);
            node.Attributes.Append(StrPlotArea);
            node.Attributes.Append(YsnActive);

            return node;
        }
        private void checkXmlItemData(string PlotNo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (PlotNo == (ds.Tables[0].Rows[i]["strPlotNo"].ToString()))
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
            if (ddlMouzaName.SelectedValue == "-1")
            {
                ddlMouzaName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select A Mouza.');", true);
                return false;
            }
            if (ddlPlotType.SelectedValue == "-1")
            {
                ddlPlotType.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Plot Type.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtPlotArea.Text))
            {
                txtPlotArea.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Plot Area');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtPlotNo.Text))
            {
                txtPlotNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Plot No');", true);
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
            txtPlotNo.Text = string.Empty;
            txtPlotArea.Text = string.Empty;
            ddlMouzaName.SelectedValue = "-1";
            ddlIsActive.SelectedValue = "-1";
            ddlPlotType.SelectedValue = "-1";
        }
        private void LoadGridWithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("PMouza");
                xmlString = dSftTm.InnerXml;
                xmlString = "<PMouza>" + xmlString + "</PMouza>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvPlotByMouzaSetup.DataSource = ds;
                }
                else
                {
                    dgvPlotByMouzaSetup.DataSource = "";
                }
                dgvPlotByMouzaSetup.DataBind();
            }
            catch { }
        }
        private void LoadExistingPlot()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = pbll.GetPlotByMouzaData();
                dgvPlotByMouzaList.DataSource = dt;
                dgvPlotByMouzaList.DataBind();
            }
            catch (Exception ex)
            {
                string sms = "Data Loading Problem" + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void ShowDetailDataForEdit(int PlotID)
        {
            DataTable dt = new DataTable();
            try
            {
                hfPlotID.Value = PlotID.ToString();
                dt = pbll.GetSinglePlotByMouzaData(PlotID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlMouzaName.SelectedValue = !string.IsNullOrEmpty(dt.Rows[0]["intMouzaId"].ToString()) ? dt.Rows[0]["intMouzaId"].ToString() : "-1";
                    ddlPlotType.SelectedValue = !string.IsNullOrEmpty(dt.Rows[0]["intPlotTypeId"].ToString()) ? dt.Rows[0]["intPlotTypeId"].ToString() : "-1";
                    txtPlotArea.Text = !string.IsNullOrEmpty(dt.Rows[0]["numPlotArea"].ToString()) ? dt.Rows[0]["numPlotArea"].ToString() : string.Empty;
                    txtPlotNo.Text = !string.IsNullOrEmpty(dt.Rows[0]["strPlotNo"].ToString()) ? dt.Rows[0]["strPlotNo"].ToString() : string.Empty;
                    
                    ddlIsActive.SelectedValue = "1";
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