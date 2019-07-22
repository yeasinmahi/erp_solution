using BLL.Property;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Property
{
    public partial class AGLandTrxGeneral : System.Web.UI.Page
    {
        #region INIT
        private PropertyBLL pbll = new PropertyBLL();
        DocumentUpload_BLL objDocUp = new DocumentUpload_BLL();
        private int UnitId, MouzaId, SubOfficeId, DeedTypeID, Complete, PlotTypeID;
        private int CheckItem = 1;
        private string UnitName, DeedNo, MouzaName, SellerName, SubOfficeName, DeedTypeName, Remarks, OtherCostRemarks,
            North, South, East, West, KahtianCS, KahtianBS, KahtianRS, KahtianSA, KahtianMutation, PlotCS, PlotBS,
            PlotRS, PlotSA, PlotMutation, PlotType, PlotNo, PurchesedPlot, LDTR, RemDeedArea, RemPlotArea,
            xmlString, filePathForXML;



        string fileName;
        string strFileName;
        string[] arrayKey;
        char[] delimiterChars = { '.' };
        string filen;
        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;

        DateTime DeedDate;
        private decimal PurchasedLand, DeedValue, AIT, Vat, MutationFee, ExtendedValue, OtherCost, Broker, RegistrationCost,
            TotalExpense, AddPlotQty;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Property/Data/LandTrxGeneral__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLDocUpload = Server.MapPath("~/Property/Data/DocUpload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML);
                File.Delete(filePathForXMLDocUpload);
                FillDropdown();
                LoadCompleteDDL();
            }
            else if (hdnconfirm.Value == "3")
            {
                FinalUpload();
            }
        }
        #endregion

        #region Event
        protected void ddlMouza_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MouzaID = 0;
            DataTable dtSubOffice = new DataTable();
            try
            {
                if (ddlMouza.SelectedValue != "-1")
                {
                    ddlSubOffice.Items.Clear();
                    MouzaID = Convert.ToInt32(ddlMouza.SelectedValue);
                    dtSubOffice = pbll.GetAllSubOffice(MouzaID);
                    if (dtSubOffice != null && dtSubOffice.Rows.Count > 0)
                    {
                        ddlSubOffice.DataSource = dtSubOffice;
                        ddlSubOffice.DataTextField = "SubOffice";
                        ddlSubOffice.DataValueField = "intSubOfficeId";
                        ddlSubOffice.DataBind();
                    }
                    ddlSubOffice.Items.Insert(0, new ListItem("--- Select Sub-Office ---", "-1"));
                }
            }
            catch (Exception ex)
            {
                string sms = "Sub Office Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void ddlPlotType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PlotNo = string.Empty;
            try
            {
                if (ddlPlotType.SelectedValue != "-1")
                {
                    if (ddlPlotType.SelectedValue == "1")
                        PlotNo = txtPlotCS.Text;
                    else if (ddlPlotType.SelectedValue == "2")
                        PlotNo = txtPlotSA.Text;
                    else if (ddlPlotType.SelectedValue == "3")
                        PlotNo = txtPlotRS.Text;
                    else if (ddlPlotType.SelectedValue == "4")
                        PlotNo = txtPlotBS.Text;
                }

                txtPlotNo.Text = PlotNo;
            }
            catch (Exception ex)
            {
                string sms = "Plot Type DropDown : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnCalculation_Click(object sender, EventArgs e)
        {
            try
            {
                AIT = !string.IsNullOrEmpty(txtAIT.Text) ? decimal.Parse(txtAIT.Text.Trim()) : 0;
                Vat = !string.IsNullOrEmpty(txtVat.Text) ? decimal.Parse(txtVat.Text.Trim()) : 0;
                MutationFee = !string.IsNullOrEmpty(txtMutationFee.Text) ? decimal.Parse(txtMutationFee.Text.Trim()) : 0;
                ExtendedValue = !string.IsNullOrEmpty(txtExtendedValue.Text) ? decimal.Parse(txtExtendedValue.Text.Trim()) : 0;
                OtherCost = !string.IsNullOrEmpty(txtOtherCost.Text) ? decimal.Parse(txtOtherCost.Text.Trim()) : 0;
                Broker = !string.IsNullOrEmpty(txtBroker.Text) ? decimal.Parse(txtBroker.Text.Trim()) : 0;
                RegistrationCost = !string.IsNullOrEmpty(txtRegistrationCost.Text) ? decimal.Parse(txtRegistrationCost.Text.Trim()) : 0;
                TotalExpense = RegistrationCost + Broker + OtherCost + ExtendedValue + MutationFee + Vat + AIT;
                txtTotalExpence.Text = TotalExpense.ToString();
                decimal PurchasePlot = !string.IsNullOrEmpty(txtPurchasedPlot.Text) ?
                        Convert.ToDecimal(txtPurchasedPlot.Text) : 0;
                LandCalculation(PurchasePlot);

            }
            catch (Exception ex)
            {
                string sms = "Calculation Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void txtPurchasedPlot_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal PurchasePlot = !string.IsNullOrEmpty(txtPurchasedPlot.Text) ? Convert.ToDecimal(txtPurchasedPlot.Text) : 0;
                if (!string.IsNullOrEmpty(hfPurshedPlot.Value) && Convert.ToDecimal(hfPurshedPlot.Value) >= 0)
                {
                    hfPurshedPlot.Value = (Convert.ToDecimal(hfPurshedPlot.Value) + PurchasePlot).ToString();
                }
                else
                {
                    hfPurshedPlot.Value = PurchasePlot.ToString();
                }

                LandCalculation(Convert.ToDecimal(hfPurshedPlot.Value));
            }
            catch (Exception ex)
            {
                string sms = "PurchasedPlot Event : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (DetailedValidation() == true)
                {
                    MouzaId = int.Parse(ddlMouza.SelectedValue);
                    MouzaName = ddlMouza.SelectedItem.ToString();
                    PurchasedLand = decimal.Parse(txtPurchaseLand.Text.Trim());
                    KahtianCS = !string.IsNullOrEmpty(txtKhatianCS.Text) ? txtKhatianCS.Text : string.Empty;
                    KahtianBS = !string.IsNullOrEmpty(txtKhatianBS.Text) ? txtKhatianBS.Text : string.Empty;
                    KahtianRS = !string.IsNullOrEmpty(txtKhatianRS.Text) ? txtKhatianRS.Text : string.Empty;
                    KahtianSA = !string.IsNullOrEmpty(txtKhatianSA.Text) ? txtKhatianSA.Text : string.Empty;
                    KahtianMutation = !string.IsNullOrEmpty(txtKhatianMutation.Text) ? txtKhatianMutation.Text : string.Empty;
                    PlotCS = !string.IsNullOrEmpty(txtPlotCS.Text) ? txtPlotCS.Text : string.Empty;
                    PlotBS = !string.IsNullOrEmpty(txtPlotBS.Text) ? txtPlotBS.Text : string.Empty;
                    PlotRS = !string.IsNullOrEmpty(txtPlotRS.Text) ? txtPlotRS.Text : string.Empty;
                    PlotSA = !string.IsNullOrEmpty(txtPlotSA.Text) ? txtPlotSA.Text : string.Empty;
                    PlotMutation = !string.IsNullOrEmpty(txtPlotMutation.Text) ? txtPlotMutation.Text : string.Empty;
                    PlotTypeID = int.Parse(ddlPlotType.SelectedValue);
                    PlotType = ddlPlotType.SelectedItem.ToString();
                    PlotNo = txtPlotNo.Text;
                    PurchesedPlot = txtPurchasedPlot.Text.Trim();
                    LDTR = ddlUpdatedLDTR.SelectedItem.ToString();
                    decimal PlotByMouza = PurchasedLand - Convert.ToDecimal(hfPurshedPlot.Value);

                    checkXmlItemData(PlotNo);
                    if (CheckItem == 1)
                    {
                        CreateXml(KahtianCS, KahtianSA, KahtianRS, KahtianBS, KahtianMutation, PlotCS, PlotSA, PlotRS, PlotBS, PlotMutation,
                            LDTR, PlotTypeID.ToString(), PlotType, PlotNo, PurchesedPlot, MouzaName, PlotByMouza.ToString());

                        LoadGridWithXml();
                        DetailClear();
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("LandTrxGen");
                xmlString = dSftTm.InnerXml;
                xmlString = "<LandTrxGen>" + xmlString + "</LandTrxGen>";
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                }

                if (MasterValidation() == true)
                {
                    Message = FillSubmitData(xmlString,null, Enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + Message + "');", true);
                    MasterClear();
                }

            }
            catch (Exception ex)
            {
                string sms = "Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnFileAdd_Click(object sender, EventArgs e)
        {
            FTPUpload();
        }

        protected void dgvFileUp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("FileUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<FileUpload>" + xmlStringDocUpload + "</FileUpload>";
                StringReader sr = new StringReader(xmlStringDocUpload);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvFileUp.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvFileUp.DataSource;
                fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();
                File.Delete(Server.MapPath("~/Property/Files/") + fileName);

                //hdndgvDTFCash.Value = grandtotaldtfarecash.ToString();
                dsGrid.Tables[0].Rows[dgvFileUp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvFileUp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload);
                    dgvFileUp.DataSource = "";
                    dgvFileUp.DataBind();
                }
                else
                {
                    LoadGridwithXmlDocUpload();
                }
            }
            catch { }
        }
        #endregion

        #region Method
        private void FillDropdown()
        {
            DataTable dtUnit = new DataTable();
            DataTable dtMouza = new DataTable();
            DataTable dtDeedType = new DataTable();
            DataTable dtPlotType = new DataTable();
            DataTable dtLDTR = new DataTable();
            try
            {
                dtUnit = pbll.GetAllUnit();
                dtMouza = pbll.GetAllMouza();
                dtDeedType = pbll.GetAllDeedType();
                dtPlotType = pbll.GetAllPlotType();
                dtLDTR = pbll.GetAllLDTR();



                if (dtUnit != null && dtUnit.Rows.Count > 0)
                {
                    ddlUnit.DataSource = dtUnit;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();
                }

                if (dtMouza != null && dtMouza.Rows.Count > 0)
                {
                    ddlMouza.DataSource = dtMouza;
                    ddlMouza.DataTextField = "MouzaDetail";
                    ddlMouza.DataValueField = "intMouzaId";
                    ddlMouza.DataBind();
                }

                if (dtDeedType != null && dtDeedType.Rows.Count > 0)
                {
                    ddlDeedType.DataSource = dtDeedType;
                    ddlDeedType.DataTextField = "strDeedType";
                    ddlDeedType.DataValueField = "intDeedTypeId";
                    ddlDeedType.DataBind();
                }

                if (dtPlotType != null && dtPlotType.Rows.Count > 0)
                {
                    ddlPlotType.DataSource = dtPlotType;
                    ddlPlotType.DataTextField = "strPlotType";
                    ddlPlotType.DataValueField = "intPlotTypeId";
                    ddlPlotType.DataBind();

                    ddlFilePlotType.DataSource = dtPlotType;
                    ddlFilePlotType.DataTextField = "strPlotType";
                    ddlFilePlotType.DataValueField = "intPlotTypeId";
                    ddlFilePlotType.DataBind();
                }
                if (dtLDTR != null && dtLDTR.Rows.Count > 0)
                {
                    ddlUpdatedLDTR.DataSource = dtLDTR;
                    ddlUpdatedLDTR.DataTextField = "intBanglaYear";
                    ddlUpdatedLDTR.DataValueField = "intBanglaYear";
                    ddlUpdatedLDTR.DataBind();
                }



                ddlUnit.Items.Insert(0, new ListItem("--- Select An Unit ---", "-1"));
                ddlMouza.Items.Insert(0, new ListItem("--- Select Mouza ---", "-1"));
                ddlSubOffice.Items.Insert(0, new ListItem("--- Select Sub-Office ---", "-1"));
                ddlDeedType.Items.Insert(0, new ListItem("--- Select Deed Type ---", "-1"));
                ddlPlotType.Items.Insert(0, new ListItem("--- Select Plot Type ---", "-1"));
                ddlFilePlotType.Items.Insert(0, new ListItem("--- Select Plot Type ---", "-1"));
                ddlUpdatedLDTR.Items.Insert(0, new ListItem("--- Select LDTR ---", "-1"));

            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LandCalculation(decimal PurchasePlot)
        {
            MouzaId = Convert.ToInt32(ddlMouza.SelectedValue);
            if (ddlPlotType.SelectedValue != "-1" && !string.IsNullOrEmpty(txtPlotNo.Text))
            {
                PlotTypeID = int.Parse(ddlPlotType.SelectedValue);
                PlotNo = !string.IsNullOrEmpty(txtPlotNo.Text.Trim()) ? txtPlotNo.Text : string.Empty;

                decimal PlotArea = pbll.GetPlotAreaData(MouzaId, PlotTypeID, PlotNo);
                decimal PurchasePlotArea = pbll.GetPurchasePlotArea(PlotTypeID, PlotNo);

                if (pbll.CheckPlotArea(PlotTypeID, PlotNo) > 0)
                {
                    txtRemPlotArea.Text = (PlotArea - PurchasePlotArea).ToString();
                }
                else
                {
                    txtRemPlotArea.Text = (PlotArea - PurchasePlot).ToString();
                }
                decimal PurchaseLand = !string.IsNullOrEmpty(txtPurchaseLand.Text) ? Convert.ToDecimal(txtPurchaseLand.Text) : 0;
                txtRemDeedArea.Text = (PurchaseLand - PurchasePlot).ToString();
            }
        }
        public void LoadCompleteDDL()
        {
            ddlComplete.Items.Insert(0, new ListItem("--- Select ---", "-1"));
            ddlComplete.Items.Insert(1, new ListItem("Yes", "1"));
            ddlComplete.Items.Insert(2, new ListItem("No", "0"));
        }
        private bool DetailedValidation()
        {
            if (!string.IsNullOrEmpty(txtKhatianCS.Text)
            || !string.IsNullOrEmpty(txtKhatianSA.Text)
            || !string.IsNullOrEmpty(txtKhatianRS.Text)
            || !string.IsNullOrEmpty(txtKhatianBS.Text))
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Khatian CS/RS/BS/SA');", true);
                return false;
            }

            if (!string.IsNullOrEmpty(txtPlotCS.Text)
            || !string.IsNullOrEmpty(txtPlotSA.Text)
            || !string.IsNullOrEmpty(txtPlotRS.Text)
            || !string.IsNullOrEmpty(txtPlotBS.Text))
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Plot CS/RS/BS/SA');", true);
                return false;
            }

            if (ddlPlotType.SelectedValue == "-1")
            {
                ddlPlotType.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Plot Type');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtPlotNo.Text))
            {
                txtPlotNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Plot No');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtPurchasedPlot.Text))
            {
                txtPurchasedPlot.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Purchased Plot');", true);
                return false;
            }
            if (ddlUpdatedLDTR.SelectedValue == "-1")
            {
                ddlUpdatedLDTR.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select LDTR');", true);
                return false;
            }
            if (ddlMouza.SelectedValue == "-1")
            {
                ddlMouza.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Mouza');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtPurchaseLand.Text))
            {
                txtPurchaseLand.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Purchased Land.');", true);
                return false;
            }
            return true;
        }
        private bool MasterValidation()
        {

            if (ddlUnit.SelectedValue == "-1")
            {
                ddlUnit.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Unit');", true);
                return false;
            }
            if (ddlMouza.SelectedValue == "-1")
            {
                ddlMouza.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Mouza');", true);
                return false;
            }
            if (ddlSubOffice.SelectedValue == "-1")
            {
                ddlSubOffice.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Sub-Office');", true);
                return false;
            }
            if (ddlDeedType.SelectedValue == "-1")
            {
                ddlDeedType.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Deed Type');", true);
                return false;
            }
            if (ddlComplete.SelectedValue == "-1")
            {
                ddlComplete.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Complete');", true);
                return false;
            }


            if (string.IsNullOrEmpty(txtDeedNo.Text))
            {
                txtDeedNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Deed No');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtDeedDate.Text))
            {
                txtDeedDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Deed Date');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtSellerName.Text))
            {
                txtSellerName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Seller Name');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtPurchaseLand.Text))
            {
                txtPurchaseLand.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Purchase Land');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtRemarks.Text))
            {
                txtRemarks.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Remarks');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtDeedValue.Text))
            {
                txtDeedValue.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Deed Value');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtRegistrationCost.Text))
            {
                txtRegistrationCost.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Registration Cost');", true);
                return false;
            }
            return true;
        }
        private void DetailClear()
        {
            ddlPlotType.SelectedValue = "-1";
            txtPlotNo.Text = string.Empty;
            txtPurchasedPlot.Text = string.Empty;
            ddlUpdatedLDTR.SelectedValue = "-1";
        }
        private bool Validation()
        {
            return true;
        }

        private void MasterClear()
        {
            ddlUnit.SelectedValue = "-1";
            ddlMouza.SelectedValue = "-1";
            ddlSubOffice.SelectedValue = "-1";
            ddlDeedType.SelectedValue = "-1";
            ddlComplete.SelectedValue = "-1";
            ddlPlotType.SelectedValue = "-1";
            //ddlUpdatedLDTR.SelectedValue = "-1";
            txtDeedNo.Text = string.Empty;
            txtDeedDate.Text = string.Empty;
            txtSellerName.Text = string.Empty;
            txtPurchaseLand.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtDeedValue.Text = string.Empty;
            txtAIT.Text = string.Empty;
            txtVat.Text = string.Empty;
            txtMutationFee.Text = string.Empty;
            txtExtendedValue.Text = string.Empty;
            txtOtherCost.Text = string.Empty;
            txtBroker.Text = string.Empty;
            txtRegistrationCost.Text = string.Empty;
            txtOtherCostRemarks.Text = string.Empty;
            txtNorth.Text = string.Empty;
            txtSouth.Text = string.Empty;
            txtEast.Text = string.Empty;
            txtWest.Text = string.Empty;
            txtKhatianCS.Text = string.Empty;
            txtKhatianBS.Text = string.Empty;
            txtKhatianRS.Text = string.Empty;
            txtKhatianSA.Text = string.Empty;
            txtKhatianMutation.Text = string.Empty;
            txtPlotCS.Text = string.Empty;
            txtPlotBS.Text = string.Empty;
            txtPlotRS.Text = string.Empty;
            txtPlotSA.Text = string.Empty;
            txtPlotMutation.Text = string.Empty;

            gvLandTrxGeneral.DataSource = null;
            gvLandTrxGeneral.DataBind();
        }
        private string FillSubmitData(string MainXml, string DocXml, int Enroll)
        {
            string Message = string.Empty;
            try
            {
                UnitId = int.Parse(ddlUnit.SelectedValue);
                UnitName = ddlUnit.SelectedItem.ToString();
                DeedNo = txtDeedNo.Text;
                DeedDate = DateTime.ParseExact(txtDeedDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                MouzaId = int.Parse(ddlMouza.SelectedValue);
                MouzaName = ddlMouza.SelectedItem.ToString();
                SellerName = txtSellerName.Text;
                SubOfficeId = int.Parse(ddlSubOffice.SelectedValue);
                SubOfficeName = ddlSubOffice.SelectedItem.ToString();
                PurchasedLand = decimal.Parse(txtPurchaseLand.Text.Trim());
                DeedTypeID = int.Parse(ddlDeedType.SelectedValue);
                DeedTypeName = ddlDeedType.SelectedItem.ToString();
                Complete = int.Parse(ddlComplete.SelectedValue);
                Remarks = !string.IsNullOrEmpty(txtRemarks.Text) ? txtRemarks.Text : "N/A";
                DeedValue = decimal.Parse(txtDeedValue.Text.Trim());
                AIT = !string.IsNullOrEmpty(txtAIT.Text) ? decimal.Parse(txtAIT.Text.Trim()) : 0;
                Vat = !string.IsNullOrEmpty(txtVat.Text) ? decimal.Parse(txtVat.Text.Trim()) : 0;
                MutationFee = !string.IsNullOrEmpty(txtMutationFee.Text) ? decimal.Parse(txtMutationFee.Text.Trim()) : 0;
                ExtendedValue = !string.IsNullOrEmpty(txtExtendedValue.Text) ? decimal.Parse(txtExtendedValue.Text.Trim()) : 0;
                OtherCost = !string.IsNullOrEmpty(txtOtherCost.Text) ? decimal.Parse(txtOtherCost.Text.Trim()) : 0;
                Broker = !string.IsNullOrEmpty(txtBroker.Text) ? decimal.Parse(txtBroker.Text.Trim()) : 0;
                RegistrationCost = !string.IsNullOrEmpty(txtRegistrationCost.Text) ? decimal.Parse(txtRegistrationCost.Text.Trim()) : 0;
                OtherCostRemarks = !string.IsNullOrEmpty(txtOtherCostRemarks.Text) ? txtOtherCostRemarks.Text : "N/A";
                North = !string.IsNullOrEmpty(txtNorth.Text) ? txtNorth.Text : string.Empty;
                South = !string.IsNullOrEmpty(txtSouth.Text) ? txtSouth.Text : string.Empty;
                East = !string.IsNullOrEmpty(txtEast.Text) ? txtEast.Text : string.Empty;
                West = !string.IsNullOrEmpty(txtWest.Text) ? txtWest.Text : string.Empty;

                RemDeedArea = !string.IsNullOrEmpty(txtRemDeedArea.Text) ? txtRemDeedArea.Text : string.Empty;
                RemPlotArea = !string.IsNullOrEmpty(txtRemPlotArea.Text) ? txtRemPlotArea.Text : string.Empty;

                Message = pbll.InsertAGLandTrxGeneral(MainXml, DocXml, UnitId, MouzaId, SubOfficeId, DeedTypeID, DeedNo, DeedDate, SellerName, PurchasedLand,
                    Remarks, DeedValue, Vat, ExtendedValue, Broker, RegistrationCost, AIT, MutationFee, OtherCost, OtherCostRemarks,
                    East, West, North, South);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Message;
        }

        private void CreateXml(string strKhaCS, string strKhaSA, string strKhaRS, string strKhaBS, string strKhaMut,
            string strPloCS, string strPloSA, string strPloRS, string strPloBS, string strPloMut, string BanglaYear,
            string PlotTypeId, string PlotType, string strPlotNo, string numPurchasedPlotArea, string Mouza, string plotByMouza)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("LandTrxGen");
                XmlNode addItem = CreateItemNode(doc, strKhaCS, strKhaSA, strKhaRS, strKhaBS, strKhaMut, strPloCS, strPloSA,
                    strPloRS, strPloBS, strPloMut, BanglaYear, PlotTypeId, PlotType, strPlotNo, numPurchasedPlotArea, Mouza,
                    plotByMouza);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("LandTrxGen");
                XmlNode addItem = CreateItemNode(doc, strKhaCS, strKhaSA, strKhaRS, strKhaBS, strKhaMut, strPloCS, strPloSA,
                    strPloRS, strPloBS, strPloMut, BanglaYear, PlotTypeId, PlotType, strPlotNo, numPurchasedPlotArea, Mouza,
                    plotByMouza);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);

        }
        private XmlNode CreateItemNode(XmlDocument doc, string strKhaCS, string strKhaSA, string strKhaRS, string strKhaBS, string strKhaMut,
            string strPloCS, string strPloSA, string strPloRS, string strPloBS, string strPloMut, string banglaYear,
            string plotTypeId, string plotType, string strPlotNo, string numPurchasedPlotArea, string mouza, string plotByMouza)
        {
            XmlNode node = doc.CreateElement("LandTrxGen");

            XmlAttribute StrKhaCS = doc.CreateAttribute("strKhaCS");
            StrKhaCS.Value = strKhaCS;
            XmlAttribute StrKhaSA = doc.CreateAttribute("strKhaSA");
            StrKhaSA.Value = strKhaSA;
            XmlAttribute StrKhaRS = doc.CreateAttribute("strKhaRS");
            StrKhaRS.Value = strKhaRS;
            XmlAttribute StrKhaBS = doc.CreateAttribute("strKhaBS");
            StrKhaBS.Value = strKhaBS;
            XmlAttribute StrKhaMut = doc.CreateAttribute("strKhaMut");
            StrKhaMut.Value = strKhaMut;
            XmlAttribute StrPloCS = doc.CreateAttribute("strPloCS");
            StrPloCS.Value = strPloCS;
            XmlAttribute StrPloSA = doc.CreateAttribute("strPloSA");
            StrPloSA.Value = strPloSA;
            XmlAttribute StrPloRS = doc.CreateAttribute("strPloRS");
            StrPloRS.Value = strPloRS;
            XmlAttribute StrPloBS = doc.CreateAttribute("strPloBS");
            StrPloBS.Value = strPloBS;
            XmlAttribute StrPloMut = doc.CreateAttribute("strPloMut");
            StrPloMut.Value = strPloMut;
            XmlAttribute BanglaYear = doc.CreateAttribute("banglaYear");
            BanglaYear.Value = banglaYear;
            XmlAttribute PlotTypeId = doc.CreateAttribute("plotTypeId");
            PlotTypeId.Value = plotTypeId;
            XmlAttribute PlotType = doc.CreateAttribute("plotType");
            PlotType.Value = plotType;
            XmlAttribute StrPlotNo = doc.CreateAttribute("strPlotNo");
            StrPlotNo.Value = strPlotNo;
            XmlAttribute NumPurchasedPlotArea = doc.CreateAttribute("numPurchasedPlotArea");
            NumPurchasedPlotArea.Value = numPurchasedPlotArea;
            XmlAttribute Mouza = doc.CreateAttribute("mouza");
            Mouza.Value = mouza;
            XmlAttribute PlotByMouza = doc.CreateAttribute("plotByMouza");
            PlotByMouza.Value = plotByMouza;

            node.Attributes.Append(StrKhaCS);
            node.Attributes.Append(StrKhaSA);
            node.Attributes.Append(StrKhaRS);
            node.Attributes.Append(StrKhaBS);
            node.Attributes.Append(StrKhaMut);
            node.Attributes.Append(StrPloCS);
            node.Attributes.Append(StrPloSA);
            node.Attributes.Append(StrPloRS);
            node.Attributes.Append(StrPloBS);
            node.Attributes.Append(StrPloMut);
            node.Attributes.Append(BanglaYear);
            node.Attributes.Append(PlotTypeId);
            node.Attributes.Append(PlotType);
            node.Attributes.Append(StrPlotNo);
            node.Attributes.Append(NumPurchasedPlotArea);
            node.Attributes.Append(Mouza);
            node.Attributes.Append(PlotByMouza);

            return node;
        }
        private void checkXmlItemData(string PlotNo)
        {
            try
            {
                AddPlotQty = 0;
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
                        AddPlotQty += Convert.ToDecimal(ds.Tables[0].Rows[i]["numPurchasedPlotArea"]);
                        CheckItem = 1;
                    }
                }
            }
            catch { }
        }
        private void LoadGridWithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("LandTrxGen");
                xmlString = dSftTm.InnerXml;
                xmlString = "<LandTrxGen>" + xmlString + "</LandTrxGen>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvLandTrxGeneral.DataSource = ds;
                }
                else
                {
                    gvLandTrxGeneral.DataSource = "";
                }
                gvLandTrxGeneral.DataBind();
            }
            catch { }
        }

        private void FTPUpload()
        {
            try
            {
                if (fuDocUpload.FileName.ToString() != "")
                {
                    string Mouza = Convert.ToInt32(ddlMouza.SelectedValue) > 0 ? ddlMouza.SelectedItem.ToString() : "N/A";
                    string DeedNo = !string.IsNullOrEmpty(txtDeedNo.Text) ? txtDeedNo.Text : "";
                    int PlotType = int.Parse(ddlFilePlotType.SelectedValue.ToString());
                    string strPlotType = ddlFilePlotType.SelectedItem.ToString();
                    string PlotNo = txtFilePlotNo.Text.ToString();

                    int intCount = 0;
                    if (fuDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in fuDocUpload.PostedFiles)
                        {
                            intCount = intCount + 1;
                            Stream strm = uploadedFile.InputStream;
                            string strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            strDocUploadPath = "Land_" + DeedNo + "_" + strPlotType + "_" + PlotNo + "_00" + intCount.ToString() + "_" + strDocUploadPath;


                            fileName = strDocUploadPath.Replace(" ", "");

                            strFileName = fileName.Trim();
                            arrayKey = strFileName.Split(delimiterChars);
                            if (arrayKey.Length > 0)
                            {
                                filen = arrayKey[0];
                            }


                            fileName = intCount.ToString() + "_" + filen.Trim() + ".png";

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();

                            if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            {
                                objDocUp.ReduceImageSize(0.5, strm, Server.MapPath("~/Property/Files/") + fileName.Trim());
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true);
                                return;
                            }

                            CreateVoucherXmlDocUpload(fileName, Mouza, DeedNo, strPlotType, PlotNo);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void CreateVoucherXmlDocUpload(string strFileName, string Mouza, string DeedNo, string strPlotType, string PlotNo)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("FileUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, Mouza, DeedNo, strPlotType, PlotNo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("FileUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, Mouza, DeedNo, strPlotType, PlotNo);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDocUpload);
            LoadGridwithXmlDocUpload();
            //Clear(); 
        }
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName, string mouza, string deedNo, string strPlotType, string plotNo)
        {
            XmlNode node = doc.CreateElement("FileUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName");
            StrFileName.Value = strFileName;
            XmlAttribute Mouza = doc.CreateAttribute("mouza");
            Mouza.Value = mouza;
            XmlAttribute DeedNo = doc.CreateAttribute("deedNo");
            DeedNo.Value = deedNo;
            XmlAttribute StrPlotType = doc.CreateAttribute("strPlotType");
            StrPlotType.Value = strPlotType;
            XmlAttribute PlotNo = doc.CreateAttribute("plotNo");
            PlotNo.Value = plotNo;

            node.Attributes.Append(StrFileName);
            node.Attributes.Append(Mouza);
            node.Attributes.Append(DeedNo);
            node.Attributes.Append(StrPlotType);
            node.Attributes.Append(PlotNo);
            return node;
        }
        private void LoadGridwithXmlDocUpload()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDocUpload);
            XmlNode dSfiletTm = doc.SelectSingleNode("FileUpload");
            xmlStringDocUpload = dSfiletTm.InnerXml;
            xmlStringDocUpload = "<FileUpload>" + xmlStringDocUpload + "</FileUpload>";
            StringReader sr = new StringReader(xmlStringDocUpload);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvFileUp.DataSource = ds;
            }
            else
            {
                dgvFileUp.DataSource = "";
            }
            dgvFileUp.DataBind();
        }
        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                string Message = string.Empty;
                try
                {
                    XmlDocument doc = new XmlDocument();
                    int UnitID = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    int Enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("LandTrxGen");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<LandTrxGen>" + xmlString + "</LandTrxGen>";
                    try
                    {
                        File.Delete(filePathForXML);
                    }
                    catch
                    {
                    }

                    try
                    {
                        XmlDocument docfile = new XmlDocument();
                        docfile.Load(filePathForXMLDocUpload);
                        XmlNode dSfiletTm = docfile.SelectSingleNode("FileUpload");
                        xmlStringDocUpload = dSfiletTm.InnerXml;
                        xmlStringDocUpload = "<FileUpload>" + xmlStringDocUpload + "</FileUpload>";
                        xmlDocUpload = xmlStringDocUpload;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.Message + "');", true);
                    }

                    if (dgvFileUp.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvFileUp.Rows.Count; index++)
                        {
                            fileName = ((Label)dgvFileUp.Rows[index].FindControl("lblgvFileName")).Text.ToString();
                            FileUploadFTP(Server.MapPath("~/Property/Files/"), fileName, "ftp://ftp.akij.net/Land/", "erp@akij.net", "erp123");
                        }
                    }

                    if (MasterValidation() == true)
                    {
                        Message = FillSubmitData(xmlString, xmlStringDocUpload, Enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + Message + "');", true);
                        MasterClear();
                    }

                    hdnconfirm.Value = "0";

                    //****Document Upload End

                    
                    if (filePathForXMLDocUpload != null)
                    {
                        File.Delete(filePathForXMLDocUpload);
                    }
                    dgvFileUp.DataSource = "";
                    dgvFileUp.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('File Upload Successfully.');", true);
                }
                catch (Exception ex)
                {
                    string sms = "File Upload : " + ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
                }
            }
            
        }
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            try
            {
                FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
                requestFTPUploader.Credentials = new NetworkCredential(user, pass);
                requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileInfo = new FileInfo(localPath + fileName);
                FileStream fileStream = fileInfo.OpenRead();

                int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];

                Stream uploadStream = requestFTPUploader.GetRequestStream();
                int contentLength = fileStream.Read(buffer, 0, bufferLength);

                while (contentLength != 0)
                {
                    uploadStream.Write(buffer, 0, contentLength);
                    contentLength = fileStream.Read(buffer, 0, bufferLength);
                }

                uploadStream.Close();
                fileStream.Close();


                requestFTPUploader = null;
                File.Delete(Server.MapPath("~/Property/Files/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

    }
}