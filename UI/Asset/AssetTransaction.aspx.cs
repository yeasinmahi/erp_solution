using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using UI.ClassFiles;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace UI.Asset
{
    public partial class AssetTransaction : BasePage
    {
        AssetMaintenance objTransction = new AssetMaintenance();
        Assetregister_BLL objregister = new Assetregister_BLL();
        AssetParking_BLL parking = new AssetParking_BLL();
        Assetregister_BLL objregisterUpdate = new Assetregister_BLL();
        DataTable dt = new DataTable();
        string filePathForXMlAssetParking;
        string XMLVehicle, XMLBuilding, XMLLand; int enroll; decimal recieveqty;
        string xmlStringG = ""; string[] arrayKey; char[] delimiterChars = { '[', ']' };
       string accCOAid = null,accCOAName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMlAssetParking = Server.MapPath("~/Asset/Data/p_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {

                // CommonDataBind();



                //TransferXml();
                //DisposalXml();
                //RevaluationXml();
                //ReClasificationXml();
                //SalePageXml();
            }
            else { }

        }
        #region===============================Asset Sales Process=================================
        private void SalePageLoad()
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.Unitname(5, 1, intenroll, intjobid, intdept, "0"); ;
            ddlSaleUnit.DataSource = dt;
            ddlSaleUnit.DataTextField = "strUnit";
            ddlSaleUnit.DataValueField = "intUnitID";
            ddlSaleUnit.DataBind();

            dt = objregister.JobstationName(8, int.Parse(ddlSaleUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlSaleJob.DataSource = dt;
            ddlSaleJob.DataTextField = "strJobStationName";
            ddlSaleJob.DataValueField = "intEmployeeJobStationId";
            ddlSaleJob.DataBind();




            dt = objregister.AssetTypeName();
            ddlSaMajorCat.DataSource = dt;
            ddlSaMajorCat.DataTextField = "strAssetTypeName";
            ddlSaMajorCat.DataValueField = "intAssetTypeID";
            ddlSaMajorCat.DataBind();





            dt = objregister.DropdownCategoryView(int.Parse(ddlSaleJob.SelectedValue));
            ddlSaMinorCat1.DataSource = dt;
            ddlSaMinorCat1.DataTextField = "strCategoryName";
            ddlSaMinorCat1.DataValueField = "intCategoryID";
            ddlSaMinorCat1.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlSaMinorCat2.DataSource = dt;
            ddlSaMinorCat2.DataTextField = "Name";
            ddlSaMinorCat2.DataValueField = "ID";
            ddlSaMinorCat2.DataBind();


            dt = objregister.RegCostCenter(int.Parse(ddlSaleUnit.SelectedValue));
            ddlSaCostCenter.DataSource = dt;
            ddlSaCostCenter.DataTextField = "Name";
            ddlSaCostCenter.DataValueField = "Id";
            ddlSaCostCenter.DataBind();

            int Mnumber = int.Parse("1".ToString());
            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetcode = searchKey[1];


            DataTable rt = new DataTable();

            rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);

            if (rt.Rows.Count > 0)
            {
                try { ddlSaleUnit.SelectedValue = rt.Rows[0]["intUnit"].ToString(); }
                catch { }
                try
                {
                    dt = objregister.JobstationName(8, int.Parse(ddlSaleUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                    ddlSaleJob.DataSource = dt;
                    ddlSaleJob.DataTextField = "strJobStationName";
                    ddlSaleJob.DataValueField = "intEmployeeJobStationId";
                    ddlSaleJob.DataBind();
                }
                catch { }
                try { ddlSaleJob.SelectedValue = rt.Rows[0]["intEmployeeJobStationId"].ToString(); } catch { }
                try { ddlSaleAssetType.SelectedValue = rt.Rows[0]["intMaintype"].ToString(); } catch { }
                try { ddlSaMajorCat.SelectedValue = rt.Rows[0]["intAssetType"].ToString(); } catch { }

                //dt = objregister.DropdownCategoryView(int.Parse(ddlTrnsJobstation.SelectedValue));
                dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlSaleJob.SelectedValue));//Parking List

                ddlSaMinorCat1.DataSource = dt;
                ddlSaMinorCat1.DataTextField = "strCategoryName";
                ddlSaMinorCat1.DataValueField = "intCategoryID";
                ddlSaMinorCat1.DataBind();

                try { ddlSaMinorCat1.SelectedValue = rt.Rows[0]["intCategory"].ToString(); } catch { }

                try { ddlSaMinorCat2.SelectedValue = rt.Rows[0]["intMinorCatagory2"].ToString(); } catch { }

                dt = objregister.RegCostCenter(int.Parse(ddlSaleUnit.SelectedValue));
                ddlSaCostCenter.DataSource = dt;
                ddlSaCostCenter.DataTextField = "Name";
                ddlSaCostCenter.DataValueField = "Id";
                ddlSaCostCenter.DataBind();

                try
                {
                    ddlSaCostCenter.SelectedValue = rt.Rows[0]["intCostCenter"].ToString();
                }
                catch { }
                txtSaleAssetName.Text = rt.Rows[0]["strNameOfAsset"].ToString();
                txtSaleAssetDescrip.Text = rt.Rows[0]["strDescriptionAsset"].ToString();
                txtSaTotalDep.Text = rt.Rows[0]["totalDep"].ToString();
                txtSaTotalCost.Text = rt.Rows[0]["monTAccumulatedCost"].ToString();
                try { txtSaCapitalLoss.Text = (decimal.Parse(txtSaTotalDep.Text) - decimal.Parse(txtSaTotalCost.Text)).ToString(); }
                catch { txtSaCapitalLoss.Text = "0".ToString(); }
            }
        }

        private void SalePageXml()
        {
            int enroll; decimal totalcost, depValue, capitalloss, salesprocess;
            string unit = ddlSaleUnit.SelectedValue.ToString();
            string name = txtSaleAssetName.Text.ToString();
            string jobstation = ddlSaleJob.SelectedValue.ToString();
            string description = txtSaleAssetDescrip.Text.ToString();
            string maintype = ddlSaleAssetType.SelectedValue.ToString();
            string majorcat = ddlSaMajorCat.SelectedValue.ToString();
            string minorcat = ddlSaMinorCat1.SelectedValue.ToString();
            string minorcat2 = ddlSaMinorCat2.SelectedValue.ToString();
            string costcenter = ddlSaCostCenter.SelectedValue.ToString();
            try { enroll =int.Parse(txtSaUserEnroll.Text.ToString()); }catch { enroll = 0; }
            string reff = txtSaReff.Text.ToString();
            string dteTransaction = txtSaDteDate.Text.ToString();
            string remarks = txtSaRemarks.Text.ToString();
            string depStartDate = "2017-01-01".ToString();
            string depEndDate = "2017-01-01".ToString();
            try { depValue = decimal.Parse(txtSaTotalDep.Text.ToString()); } catch { depValue = 0; }
            try {   totalcost = decimal.Parse(txtSaTotalCost.Text.ToString()); } catch { totalcost = 0; }
            try {  salesprocess = decimal.Parse(txtSalesProcess.Text.ToString()); } catch { salesprocess = 0; }
            try { capitalloss = decimal.Parse(txtSaCapitalLoss.Text.ToString()); } catch { capitalloss = 0; }
          
            arrayKey = txtSaReceivealeID.Text.Split(delimiterChars);
            if (arrayKey.Length > 0)
            { accCOAName = arrayKey[0].ToString(); accCOAid = arrayKey[1].ToString(); }

            string recieveId = accCOAid.ToString();
            string receiveName = txtSaReceiveableName.Text.ToString();
            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetid = searchKey[1];         

            CreateXmlSales( assetid,reff, dteTransaction, remarks,depValue.ToString(),totalcost.ToString(), salesprocess.ToString(), capitalloss.ToString(), receiveName, recieveId);

        }

        private void CreateXmlSales(string assetid, string reff, string dteTransaction, string remarks, string depValue, string totalcost, string salesprocess, string capitalloss, string receiveName, string recieveId)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeSales(doc, assetid, reff, dteTransaction, remarks, depValue, totalcost, salesprocess, capitalloss, receiveName, recieveId);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeSales(doc, assetid, reff, dteTransaction, remarks, depValue, totalcost, salesprocess, capitalloss, receiveName, recieveId);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeSales(XmlDocument doc, string assetid, string reff, string dteTransaction, string remarks, string depValue, string totalcost, string salesprocess, string capitalloss, string receiveName, string recieveId)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Assetid = doc.CreateAttribute("assetid");
            Assetid.Value = assetid;

            XmlAttribute Reff = doc.CreateAttribute("reff");
            Reff.Value = reff;

            XmlAttribute DteTransaction = doc.CreateAttribute("dteTransaction");
            DteTransaction.Value = dteTransaction;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute DepValue = doc.CreateAttribute("depValue");
            DepValue.Value = depValue;

            XmlAttribute Totalcost = doc.CreateAttribute("totalcost");
            Totalcost.Value = totalcost;
            XmlAttribute Salesprocess = doc.CreateAttribute("salesprocess");
            Salesprocess.Value = salesprocess;

            XmlAttribute Capitalloss = doc.CreateAttribute("capitalloss");
            Capitalloss.Value = capitalloss;

            XmlAttribute ReceiveName = doc.CreateAttribute("receiveName");
            ReceiveName.Value = receiveName;
            XmlAttribute RecieveId = doc.CreateAttribute("recieveId");
            RecieveId.Value = recieveId;

            node.Attributes.Append(Assetid);
            node.Attributes.Append(Reff);
            node.Attributes.Append(DteTransaction);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(DepValue);
            node.Attributes.Append(Totalcost);
            node.Attributes.Append(Salesprocess);
            node.Attributes.Append(Capitalloss);
            node.Attributes.Append(ReceiveName);
            node.Attributes.Append(RecieveId);
           
            return node;


        }

        protected void ddlSaleUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            int Mnumber = int.Parse("1".ToString());
            string assetcode = "162820122".ToString();
            DataTable rt = new DataTable();
            rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);

            dt = objregister.JobstationName(8, int.Parse(ddlSaleUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlSaleJob.DataSource = dt;
            ddlSaleJob.DataTextField = "strJobStationName";
            ddlSaleJob.DataValueField = "intEmployeeJobStationId";
            ddlSaleJob.DataBind();

            dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlSaleJob.SelectedValue));//Parking List

            ddlSaCostCenter.DataSource = dt;
            ddlSaCostCenter.DataTextField = "Name";
            ddlSaCostCenter.DataValueField = "Id";
            ddlSaCostCenter.DataBind();
            try
            {
                Session["UnitID"] = ddlSaleUnit.SelectedValue.ToString();
            }
            catch { }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnSaleDiv();", true);
        }

        protected void ddlSaleJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = objregister.DropdownCategoryView(int.Parse(ddlSaleJob.SelectedValue));
            ddlSaMinorCat1.DataSource = dt;
            ddlSaMinorCat1.DataTextField = "strCategoryName";
            ddlSaMinorCat1.DataValueField = "intCategoryID";
            ddlSaMinorCat1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnSaleDiv();", true);
        }
        protected void btnSales_Click(object sender, EventArgs e)
        {
            SalePageXml();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMlAssetParking);
            XmlNode dSftTm = doc.SelectSingleNode("voucher");
            string xmlString = dSftTm.InnerXml;
            xmlString = "<voucher>" + xmlString + "</voucher>";
            try { File.Delete(filePathForXMlAssetParking); } catch { }

            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = objTransction.DepreciationView(11, xmlString, DateTime.Now, DateTime.Now, int.Parse(ddlTransactionType.SelectedValue), 0);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

            divClose();
          
        }
        protected void txtSalesProcess_TextChanged(object sender, EventArgs e)
        {
            try { txtSaCapitalLoss.Text = (decimal.Parse(txtSaTotalDep.Text) - decimal.Parse(txtSaTotalCost.Text) + decimal.Parse(txtSalesProcess.Text)).ToString(); }
            catch { txtSaCapitalLoss.Text = "0".ToString(); }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnSaleDiv();", true);

        }
        protected void ddlSaleUnit_DataBound(object sender, EventArgs e)
        {
            try
            {
                Session["UnitID"] = ddlSaleUnit.SelectedValue.ToString();
            }
            catch { }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetAccCoaSearch(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int intunit = Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString());
            return objAutoSearch_BLL.AutoSearchAccountsChartOfACC(intunit.ToString(), prefixText);

        }
        #endregion=============================Close ===============================================

        #region=======================Asset Re-Classification=======================================

        private void ReClasificationPageLoad()
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.Unitname(5, 1, intenroll, intjobid, intdept, "0"); ;
            ddlReUnit.DataSource = dt;
            ddlReUnit.DataTextField = "strUnit";
            ddlReUnit.DataValueField = "intUnitID";
            ddlReUnit.DataBind();

            dt = objregister.JobstationName(8, int.Parse(ddlReUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlRejobstation.DataSource = dt;
            ddlRejobstation.DataTextField = "strJobStationName";
            ddlRejobstation.DataValueField = "intEmployeeJobStationId";
            ddlRejobstation.DataBind();

            dt = objregister.AssetTypeName();
            ddlReMejorCat.DataSource = dt;
            ddlReMejorCat.DataTextField = "strAssetTypeName";
            ddlReMejorCat.DataValueField = "intAssetTypeID";
            ddlReMejorCat.DataBind();

            dt = objregister.DropdownCategoryView(int.Parse(ddlRejobstation.SelectedValue));
            ddlReMinorCat1.DataSource = dt;
            ddlReMinorCat1.DataTextField = "strCategoryName";
            ddlReMinorCat1.DataValueField = "intCategoryID";
            ddlReMinorCat1.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlRemonorCat2.DataSource = dt;
            ddlRemonorCat2.DataTextField = "Name";
            ddlRemonorCat2.DataValueField = "ID";
            ddlRemonorCat2.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlReUnit.SelectedValue));
            ddlReCostCenter.DataSource = dt;
            ddlReCostCenter.DataTextField = "Name";
            ddlReCostCenter.DataValueField = "Id";
            ddlReCostCenter.DataBind();


            int Mnumber = int.Parse("1".ToString());
            string assetcode = "162820122".ToString();
            DataTable rt = new DataTable();

            rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);

            if (rt.Rows.Count > 0)
            {
                try { ddlReUnit.SelectedValue = rt.Rows[0]["intUnit"].ToString(); }
                catch { }
                try
                {
                    dt = objregister.JobstationName(8, int.Parse(ddlReUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                    ddlRejobstation.DataSource = dt;
                    ddlRejobstation.DataTextField = "strJobStationName";
                    ddlRejobstation.DataValueField = "intEmployeeJobStationId";
                    ddlRejobstation.DataBind();
                }
                catch { }
                try { ddlRejobstation.SelectedValue = rt.Rows[0]["intEmployeeJobStationId"].ToString(); } catch { }
                try { ddlReAssetType.SelectedValue = rt.Rows[0]["intMaintype"].ToString(); } catch { }
                try { ddlReMejorCat.SelectedValue = rt.Rows[0]["intAssetType"].ToString(); } catch { }

                //dt = objregister.DropdownCategoryView(int.Parse(ddlTrnsJobstation.SelectedValue));
                dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlRejobstation.SelectedValue));//Parking List

                ddlReMinorCat1.DataSource = dt;
                ddlReMinorCat1.DataTextField = "strCategoryName";
                ddlReMinorCat1.DataValueField = "intCategoryID";
                ddlReMinorCat1.DataBind();

                try { ddlReMinorCat1.SelectedValue = rt.Rows[0]["intCategory"].ToString(); } catch { }

                try { ddlRemonorCat2.SelectedValue = rt.Rows[0]["intMinorCatagory2"].ToString(); } catch { }

                dt = objregister.RegCostCenter(int.Parse(ddlReUnit.SelectedValue));
                ddlReCostCenter.DataSource = dt;
                ddlReCostCenter.DataTextField = "Name";
                ddlReCostCenter.DataValueField = "Id";
                ddlReCostCenter.DataBind();

                try
                {
                    ddlReCostCenter.SelectedValue = rt.Rows[0]["intCostCenter"].ToString();
                }
                catch { }
                txtReAsetname.Text = rt.Rows[0]["strNameOfAsset"].ToString();
            }
        }
        private void ReClasificationXml()
        {
            int enroll;
            string unit = ddlReUnit.SelectedValue.ToString();
            string assetname = txtReAsetname.Text.ToString();
            string jostation = ddlRejobstation.SelectedValue.ToString();
            string description = txtReDescrip.Text.ToString();
            string mainType = ddlReAssetType.SelectedValue.ToString();
            string mejorcat = ddlReMejorCat.SelectedValue.ToString();
            string minorcat1 = ddlReMinorCat1.SelectedValue.ToString();
            string minorcat2 = ddlRemonorCat2.SelectedValue.ToString();
            string costcenter = ddlReCostCenter.SelectedValue.ToString();
            try { enroll =int.Parse(txtReUserEnroll.Text.ToString()); } catch { enroll = 0; }
            string reff = txtReReff.Text.ToString();
            string dteTransaction = txtReDate.Text.ToString();
            string remarks = txtReRemarks.Text.ToString();
            string assetid = "".ToString();
            CreateXmlReclasification(assetid, mainType, mejorcat, minorcat1, minorcat2,  reff, dteTransaction, remarks);
        }

        private void CreateXmlReclasification(string assetid, string mainType, string mejorcat, string minorcat1, string minorcat2, string reff, string dteTransaction, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeReClas(doc, assetid, mainType, mejorcat, minorcat1, minorcat2, reff, dteTransaction, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeReClas(doc, assetid, mainType, mejorcat, minorcat1, minorcat2, reff, dteTransaction, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeReClas(XmlDocument doc, string assetid, string mainType, string mejorcat, string minorcat1, string minorcat2, string reff, string dteTransaction, string remarks)
        {

            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Assetid = doc.CreateAttribute("assetid");
            Assetid.Value = assetid;

            XmlAttribute MainType = doc.CreateAttribute("mainType");
            MainType.Value = mainType;

            XmlAttribute Mejorcat = doc.CreateAttribute("mejorcat");
            Mejorcat.Value = mejorcat;

            XmlAttribute Minorcat1 = doc.CreateAttribute("minorcat1");
            Minorcat1.Value = minorcat1;
            XmlAttribute Minorcat2 = doc.CreateAttribute("minorcat2");
            Minorcat2.Value = minorcat2;

            XmlAttribute Reff = doc.CreateAttribute("reff");
            Reff.Value = reff;
            XmlAttribute DteTransaction = doc.CreateAttribute("dteTransaction");
            DteTransaction.Value = dteTransaction;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

           

            node.Attributes.Append(Assetid);
            node.Attributes.Append(MainType);
            node.Attributes.Append(Mejorcat);
            node.Attributes.Append(Minorcat1);
            node.Attributes.Append(Minorcat2);
            node.Attributes.Append(Reff);
            node.Attributes.Append(DteTransaction);
            node.Attributes.Append(Remarks);
          

            return node;
        }

        protected void ddlRejobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            
            dt = objregister.DropdownCategoryView(int.Parse(ddlRejobstation.SelectedValue));
            ddlReMinorCat1.DataSource = dt;
            ddlReMinorCat1.DataTextField = "strCategoryName";
            ddlReMinorCat1.DataValueField = "intCategoryID";
            ddlReMinorCat1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnReclassDiv();", true);
        }

        protected void ddlReUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.JobstationName(8, int.Parse(ddlReUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlRejobstation.DataSource = dt;
            ddlRejobstation.DataTextField = "strJobStationName";
            ddlRejobstation.DataValueField = "intEmployeeJobStationId";
            ddlRejobstation.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlReUnit.SelectedValue));
            ddlReCostCenter.DataSource = dt;
            ddlReCostCenter.DataTextField = "Name";
            ddlReCostCenter.DataValueField = "Id";
            ddlReCostCenter.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnReclassDiv();", true);
        }
        protected void btnReclassSubmit_Click(object sender, EventArgs e)
        {
            ReClasificationXml();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMlAssetParking);
            XmlNode dSftTm = doc.SelectSingleNode("voucher");
            string xmlString = dSftTm.InnerXml;
            xmlString = "<voucher>" + xmlString + "</voucher>";
            try { File.Delete(filePathForXMlAssetParking); } catch { }

            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = objTransction.DepreciationView(11, xmlString, DateTime.Now, DateTime.Now, int.Parse(ddlTransactionType.SelectedValue), 0);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

            divClose();
        }

        #endregion===========================Close====================================================

        #region============================Asset Revalution===========================================
        private void RevaluationPageLoad()
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.Unitname(5, 1, intenroll, intjobid, intdept, "0"); ;
            ddlRevUnit.DataSource = dt;
            ddlRevUnit.DataTextField = "strUnit";
            ddlRevUnit.DataValueField = "intUnitID";
            ddlRevUnit.DataBind();

            dt = objregister.JobstationName(8, int.Parse(ddlRevUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlRevJobstation.DataSource = dt;
            ddlRevJobstation.DataTextField = "strJobStationName";
            ddlRevJobstation.DataValueField = "intEmployeeJobStationId";
            ddlRevJobstation.DataBind();

            dt = objregister.AssetTypeName();
            ddlRevMejorCat.DataSource = dt;
            ddlRevMejorCat.DataTextField = "strAssetTypeName";
            ddlRevMejorCat.DataValueField = "intAssetTypeID";
            ddlRevMejorCat.DataBind();

            dt = objregister.DropdownCategoryView(int.Parse(ddlRevJobstation.SelectedValue));
            ddlRevMinorCat1.DataSource = dt;
            ddlRevMinorCat1.DataTextField = "strCategoryName";
            ddlRevMinorCat1.DataValueField = "intCategoryID";
            ddlRevMinorCat1.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlRevMinorCat2.DataSource = dt;
            ddlRevMinorCat2.DataTextField = "Name";
            ddlRevMinorCat2.DataValueField = "ID";
            ddlRevMinorCat2.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlRevUnit.SelectedValue));
            ddlRevCostCenter.DataSource = dt;
            ddlRevCostCenter.DataTextField = "Name";
            ddlRevCostCenter.DataValueField = "Id";
            ddlRevCostCenter.DataBind();

            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetcode = searchKey[1];

            int Mnumber = int.Parse("1".ToString());
          
            DataTable rt = new DataTable();

            rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);

            if (rt.Rows.Count > 0)
            {
                try { ddlRevUnit.SelectedValue = rt.Rows[0]["intUnit"].ToString(); }
                catch { }
                try
                {
                    dt = objregister.JobstationName(8, int.Parse(ddlRevUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                    ddlRevJobstation.DataSource = dt;
                    ddlRevJobstation.DataTextField = "strJobStationName";
                    ddlRevJobstation.DataValueField = "intEmployeeJobStationId";
                    ddlRevJobstation.DataBind();
                }
                catch { }
                try { ddlRevJobstation.SelectedValue = rt.Rows[0]["intEmployeeJobStationId"].ToString(); } catch { }
                try { ddlRevType.SelectedValue = rt.Rows[0]["intMaintype"].ToString(); } catch { }
                try { ddlRevMejorCat.SelectedValue = rt.Rows[0]["intAssetType"].ToString(); } catch { }

                //dt = objregister.DropdownCategoryView(int.Parse(ddlTrnsJobstation.SelectedValue));
                dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlRevJobstation.SelectedValue));//Parking List

                ddlRevMinorCat1.DataSource = dt;
                ddlRevMinorCat1.DataTextField = "strCategoryName";
                ddlRevMinorCat1.DataValueField = "intCategoryID";
                ddlRevMinorCat1.DataBind();

                try { ddlRevMinorCat1.SelectedValue = rt.Rows[0]["intCategory"].ToString(); } catch { }

                try { ddlRevMinorCat2.SelectedValue = rt.Rows[0]["intMinorCatagory2"].ToString(); } catch { }

                dt = objregister.RegCostCenter(int.Parse(ddlRevUnit.SelectedValue));
                ddlRevCostCenter.DataSource = dt;
                ddlRevCostCenter.DataTextField = "Name";
                ddlRevCostCenter.DataValueField = "Id";
                ddlRevCostCenter.DataBind();

                try
                {
                    ddlRevCostCenter.SelectedValue = rt.Rows[0]["intCostCenter"].ToString();
                }
                catch { }
                txtRevAssetname.Text = rt.Rows[0]["strNameOfAsset"].ToString();
            }
        }
        private void RevaluationXml()
        {
            decimal increse;
            string unit = ddlRevUnit.SelectedValue.ToString();
            string assetname = txtRevAssetname.Text.ToString();
            string jobstation = ddlRevJobstation.Text.ToString();
            string description = txtRevDescrip.Text.ToString();
            string maintype = ddlRevType.Text.ToString();
            string mejorcat = ddlRevMejorCat.SelectedValue.ToString();
            string minorcate1 = ddlRevMinorCat1.SelectedValue.ToString();
            string minorcat2 = ddlRevMinorCat2.SelectedValue.ToString();
            string costcenter = ddlRevCostCenter.SelectedValue.ToString();
            string enroll = txtRevUserEnroll.Text.ToString();
            string reff = txtRevReff.Text.ToString();
            string dtetransaction = txtRevDate.Text.ToString();
            string remarks = txtReVRemarks.Text.ToString();
            try { increse =decimal.Parse(txtRevIncrease.Text.ToString()); } catch { increse = 0; }
            string totalcost = txtRevTotalCost.Text.ToString();

            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetid = searchKey[1];

            string totalRev = "".ToString();
            CreateXmlRevalutation(assetid,reff, dtetransaction, remarks, increse.ToString(), totalcost, totalRev);
        }

        private void CreateXmlRevalutation(string assetid,string reff, string dtetransaction, string remarks, string increse, string totalcost,string totalRev)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeReValution(doc, assetid, reff, dtetransaction, remarks, increse, totalcost, totalRev);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeReValution(doc, assetid, reff, dtetransaction, remarks, increse, totalcost, totalRev);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeReValution(XmlDocument doc, string assetid, string reff, string dtetransaction, string remarks, string increse, string totalcost, string totalRev)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Assetid = doc.CreateAttribute("assetid");
            Assetid.Value = assetid;

            XmlAttribute Reff = doc.CreateAttribute("reff");
            Reff.Value = reff;

            XmlAttribute Dtetransaction = doc.CreateAttribute("dtetransaction");
            Dtetransaction.Value = dtetransaction;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Increse = doc.CreateAttribute("increse");
            Increse.Value = increse;

            XmlAttribute Totalcost = doc.CreateAttribute("totalcost");
            Totalcost.Value = totalcost;
            XmlAttribute TotalRev = doc.CreateAttribute("totalRev");
            TotalRev.Value = totalRev;         


            node.Attributes.Append(Assetid);
            node.Attributes.Append(Reff);
            node.Attributes.Append(Dtetransaction);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(Increse);
            node.Attributes.Append(Totalcost);
            node.Attributes.Append(TotalRev);
          


            return node;
        }

        protected void ddlRevUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.JobstationName(8, int.Parse(ddlRevUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlRevJobstation.DataSource = dt;
            ddlRevJobstation.DataTextField = "strJobStationName";
            ddlRevJobstation.DataValueField = "intEmployeeJobStationId";
            ddlRevJobstation.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlReUnit.SelectedValue));
            ddlRevCostCenter.DataSource = dt;
            ddlRevCostCenter.DataTextField = "Name";
            ddlRevCostCenter.DataValueField = "Id";
            ddlRevCostCenter.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnRevDiv();", true);
        }

        protected void ddlRevJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
    
            dt = objregister.DropdownCategoryView(int.Parse(ddlRevJobstation.SelectedValue));
            ddlRevMinorCat1.DataSource = dt;
            ddlRevMinorCat1.DataTextField = "strCategoryName";
            ddlRevMinorCat1.DataValueField = "intCategoryID";
            ddlRevMinorCat1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnRevDiv();", true);

        }
        protected void btnReValution_Click(object sender, EventArgs e)
        {
            RevaluationXml();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMlAssetParking);
            XmlNode dSftTm = doc.SelectSingleNode("voucher");
            string xmlString = dSftTm.InnerXml;
            xmlString = "<voucher>" + xmlString + "</voucher>";
            try { File.Delete(filePathForXMlAssetParking); } catch { }

            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = objTransction.DepreciationView(11, xmlString, DateTime.Now, DateTime.Now, int.Parse(ddlTransactionType.SelectedValue), 0);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

            divClose();
        }

        #endregion==============================Close==================================================

        #region==================================Asset Disposal========================================
        private void DisposalPageLoad()
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.Unitname(5, 1, intenroll, intjobid, intdept, "0"); ;
            ddlDispoUnit.DataSource = dt;
            ddlDispoUnit.DataTextField = "strUnit";
            ddlDispoUnit.DataValueField = "intUnitID";
            ddlDispoUnit.DataBind();

            dt = objregister.JobstationName(8, int.Parse(ddlDispoUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlDispoJobstation.DataSource = dt;
            ddlDispoJobstation.DataTextField = "strJobStationName";
            ddlDispoJobstation.DataValueField = "intEmployeeJobStationId";
            ddlDispoJobstation.DataBind();

            dt = objregister.AssetTypeName();
            ddlDispoMejorCat.DataSource = dt;
            ddlDispoMejorCat.DataTextField = "strAssetTypeName";
            ddlDispoMejorCat.DataValueField = "intAssetTypeID";
            ddlDispoMejorCat.DataBind();

            dt = objregister.DropdownCategoryView(int.Parse(ddlDispoJobstation.SelectedValue));
            ddlDispoMonorCat1.DataSource = dt;
            ddlDispoMonorCat1.DataTextField = "strCategoryName";
            ddlDispoMonorCat1.DataValueField = "intCategoryID";
            ddlDispoMonorCat1.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlDisMinorCat2.DataSource = dt;
            ddlDisMinorCat2.DataTextField = "Name";
            ddlDisMinorCat2.DataValueField = "ID";
            ddlDisMinorCat2.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlDispoUnit.SelectedValue));
            ddlDispoCostCenter.DataSource = dt;
            ddlDispoCostCenter.DataTextField = "Name";
            ddlDispoCostCenter.DataValueField = "Id";
            ddlDispoCostCenter.DataBind();

            int Mnumber = int.Parse("1".ToString());
            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetcode = searchKey[1];

            DataTable rt = new DataTable();

            rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);

            if (rt.Rows.Count > 0)
            {
                try { ddlDispoUnit.SelectedValue = rt.Rows[0]["intUnit"].ToString(); }
                catch { }
                try
                {
                    dt = objregister.JobstationName(8, int.Parse(ddlDispoUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                    ddlDispoJobstation.DataSource = dt;
                    ddlDispoJobstation.DataTextField = "strJobStationName";
                    ddlDispoJobstation.DataValueField = "intEmployeeJobStationId";
                    ddlDispoJobstation.DataBind();
                }
                catch { }
                try { ddlDispoJobstation.SelectedValue = rt.Rows[0]["intEmployeeJobStationId"].ToString(); } catch { }
                try { ddlDispoAssetType.SelectedValue = rt.Rows[0]["intMaintype"].ToString(); } catch { }
                try { ddlDispoMejorCat.SelectedValue = rt.Rows[0]["intAssetType"].ToString(); } catch { }

                //dt = objregister.DropdownCategoryView(int.Parse(ddlTrnsJobstation.SelectedValue));
                dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlDispoJobstation.SelectedValue));//Parking List

                ddlDispoMonorCat1.DataSource = dt;
                ddlDispoMonorCat1.DataTextField = "strCategoryName";
                ddlDispoMonorCat1.DataValueField = "intCategoryID";
                ddlDispoMonorCat1.DataBind();

                try { ddlDispoMonorCat1.SelectedValue = rt.Rows[0]["intCategory"].ToString(); } catch { }

                try { ddlDisMinorCat2.SelectedValue = rt.Rows[0]["intMinorCatagory2"].ToString(); } catch { }

                dt = objregister.RegCostCenter(int.Parse(ddlDispoUnit.SelectedValue));
                ddlDispoCostCenter.DataSource = dt;
                ddlDispoCostCenter.DataTextField = "Name";
                ddlDispoCostCenter.DataValueField = "Id";
                ddlDispoCostCenter.DataBind();

                try
                {
                    ddlDispoCostCenter.SelectedValue = rt.Rows[0]["intCostCenter"].ToString();
                }
                catch { }
                txtDispoAssetName.Text = rt.Rows[0]["strNameOfAsset"].ToString();
                txtDispoTotalDep.Text = rt.Rows[0]["totalDep"].ToString();
                txtDispoTotalCost.Text = rt.Rows[0]["monTAccumulatedCost"].ToString();
                try { txtDispoCapitalLoss.Text = (decimal.Parse(txtDispoTotalDep.Text) - decimal.Parse(txtDispoTotalCost.Text)).ToString(); }
                catch { txtDispoCapitalLoss.Text = "0".ToString(); }
            }

        }
        private void DisposalXml()
        {
            decimal depTotalvalue, totalCost, capitallos;
            string unit = ddlDispoUnit.SelectedValue.ToString();
            string assetname = txtDispoAssetName.Text.ToString();
            string jobstation = ddlDispoJobstation.SelectedValue.ToString();

            string description = txtDespoDescrip.Text.ToString();
            string mainType = ddlDispoAssetType.SelectedValue.ToString();
            string mejorcat = ddlDispoMejorCat.SelectedValue.ToString();
            string minorcat = ddlDispoMonorCat1.SelectedValue.ToString();
            string minorcat2 = ddlDisMinorCat2.SelectedValue.ToString();
            string costcenter = ddlDispoCostCenter.SelectedValue.ToString();
            string enroll = txtDispoUserenroll.Text.ToString();
            string reff = txtDispoReff.Text.ToString();
            string dteTransaction = txtDispoDate.Text.ToString();
            string remarks = txtDispoRemarks.Text.ToString();

            try { depTotalvalue = decimal.Parse(txtDispoTotalDep.Text.ToString()); } catch { depTotalvalue = 0; }
            try { totalCost = decimal.Parse(txtDispoTotalCost.Text.ToString()); } catch { totalCost = 0; }
            try { capitallos = decimal.Parse(txtDispoCapitalLoss.Text.ToString()); } catch { capitallos = 0; }
            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetid = searchKey[1];
          
            CreateXmlDisposal(assetid,reff, dteTransaction, remarks, "0", depTotalvalue.ToString(), totalCost.ToString(), capitallos.ToString());

        }

        private void CreateXmlDisposal(string assetid, string reff, string dteTransaction, string remarks, string depValue, string depTotalvalue, string totalCost, string capitallos)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeDisposal(doc, assetid, reff, dteTransaction, remarks, depValue, depTotalvalue, totalCost, capitallos);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeDisposal(doc, assetid, reff, dteTransaction, remarks, depValue, depTotalvalue, totalCost, capitallos);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeDisposal(XmlDocument doc, string assetid, string reff, string dteTransaction, string remarks, string depValue, string depTotalvalue, string totalCost, string capitallos)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Assetid = doc.CreateAttribute("assetid");
            Assetid.Value = assetid;

            XmlAttribute Reff = doc.CreateAttribute("reff");
            Reff.Value = reff;

            XmlAttribute DteTransaction = doc.CreateAttribute("dteTransaction");
            DteTransaction.Value = dteTransaction;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute DepValue = doc.CreateAttribute("depValue");
            DepValue.Value = depValue;

            XmlAttribute DepTotalvalue = doc.CreateAttribute("depTotalvalue");
            DepTotalvalue.Value = depTotalvalue;
            XmlAttribute TotalCost = doc.CreateAttribute("totalCost");
            TotalCost.Value = totalCost;
            XmlAttribute Capitallos = doc.CreateAttribute("capitallos");
            Capitallos.Value = capitallos;


            node.Attributes.Append(Assetid);
            node.Attributes.Append(Reff);
            node.Attributes.Append(DteTransaction);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(DepValue);
            node.Attributes.Append(DepTotalvalue);
            node.Attributes.Append(TotalCost);
            node.Attributes.Append(Capitallos);



            return node;
        }

        protected void ddlDispoUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.JobstationName(8, int.Parse(ddlDispoUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlDispoJobstation.DataSource = dt;
            ddlDispoJobstation.DataTextField = "strJobStationName";
            ddlDispoJobstation.DataValueField = "intEmployeeJobStationId";
            ddlDispoJobstation.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlDispoUnit.SelectedValue));
            ddlDispoCostCenter.DataSource = dt;
            ddlDispoCostCenter.DataTextField = "Name";
            ddlDispoCostCenter.DataValueField = "Id";
            ddlDispoCostCenter.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDivDisposal();", true);
        }

        protected void ddlDispoJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
           
            dt = objregister.DropdownCategoryView(int.Parse(ddlDispoJobstation.SelectedValue));
            ddlDispoMonorCat1.DataSource = dt;
            ddlDispoMonorCat1.DataTextField = "strCategoryName";
            ddlDispoMonorCat1.DataValueField = "intCategoryID";
            ddlDispoMonorCat1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDivDisposal();", true);
        }
        protected void btnDisposal_Click(object sender, EventArgs e)
        {

            DisposalXml();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMlAssetParking);
            XmlNode dSftTm = doc.SelectSingleNode("voucher");
            string xmlString = dSftTm.InnerXml;
            xmlString = "<voucher>" + xmlString + "</voucher>";
            try { File.Delete(filePathForXMlAssetParking); } catch { }

            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = objTransction.DepreciationView(11, xmlString, DateTime.Now, DateTime.Now, int.Parse(ddlTransactionType.SelectedValue), 0);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

            divClose();

        }
        #endregion=======================Close===============================================================

        #region===========================Asset Transfer========================================

        private void TransferPageLoad()
        {

            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.Unitname(5, 1, intenroll, intjobid, intdept, "0"); ;
            ddlTrnsUnit.DataSource = dt;
            ddlTrnsUnit.DataTextField = "strUnit";
            ddlTrnsUnit.DataValueField = "intUnitID";
            ddlTrnsUnit.DataBind();

            dt = objregister.JobstationName(8, int.Parse(ddlTrnsUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlTrnsJobstation.DataSource = dt;
            ddlTrnsJobstation.DataTextField = "strJobStationName";
            ddlTrnsJobstation.DataValueField = "intEmployeeJobStationId";
            ddlTrnsJobstation.DataBind();

            dt = objregister.AssetTypeName();
            ddlTrnsMajorCat.DataSource = dt;
            ddlTrnsMajorCat.DataTextField = "strAssetTypeName";
            ddlTrnsMajorCat.DataValueField = "intAssetTypeID";
            ddlTrnsMajorCat.DataBind();

            dt = objregister.DropdownCategoryView(int.Parse(ddlTrnsJobstation.SelectedValue));
            ddlTrnsMinorCat1.DataSource = dt;
            ddlTrnsMinorCat1.DataTextField = "strCategoryName";
            ddlTrnsMinorCat1.DataValueField = "intCategoryID";
            ddlTrnsMinorCat1.DataBind();

            dt = parking.CwipAssetView(6, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, recieveqty, intenroll);//Parking List
            ddlTrnsMinorCat2.DataSource = dt;
            ddlTrnsMinorCat2.DataTextField = "Name";
            ddlTrnsMinorCat2.DataValueField = "ID";
            ddlTrnsMinorCat2.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlTrnsUnit.SelectedValue));
            ddlTrnsCostCenter.DataSource = dt;
            ddlTrnsCostCenter.DataTextField = "Name";
            ddlTrnsCostCenter.DataValueField = "Id";
            ddlTrnsCostCenter.DataBind();

            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetcode = searchKey[1];

            int Mnumber = int.Parse("1".ToString());
             
                DataTable rt = new DataTable();
        
                rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);

                if (rt.Rows.Count > 0)
                {


                    try { ddlTrnsUnit.SelectedValue = rt.Rows[0]["intUnit"].ToString(); }
                    catch { }
                    try
                    {
                        dt = objregister.JobstationName(8, int.Parse(ddlTrnsUnit.SelectedValue), intenroll, intjobid, intdept, "0");
                        ddlTrnsJobstation.DataSource = dt;
                        ddlTrnsJobstation.DataTextField = "strJobStationName";
                        ddlTrnsJobstation.DataValueField = "intEmployeeJobStationId";
                        ddlTrnsJobstation.DataBind();
                    }
                    catch { }
                    try { ddlTrnsJobstation.SelectedValue = rt.Rows[0]["intEmployeeJobStationId"].ToString(); } catch { }
                    try { ddlTrnsAssetType.SelectedValue = rt.Rows[0]["intMaintype"].ToString(); } catch { }
                    try { ddlTrnsMajorCat.SelectedValue = rt.Rows[0]["intAssetType"].ToString(); } catch { }

                    //dt = objregister.DropdownCategoryView(int.Parse(ddlTrnsJobstation.SelectedValue));
                    dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlTrnsJobstation.SelectedValue));//Parking List

                    ddlTrnsMinorCat1.DataSource = dt;
                    ddlTrnsMinorCat1.DataTextField = "strCategoryName";
                    ddlTrnsMinorCat1.DataValueField = "intCategoryID";
                    ddlTrnsMinorCat1.DataBind();

                    try { ddlTrnsMinorCat1.SelectedValue = rt.Rows[0]["intCategory"].ToString(); } catch { }

                    try { ddlTrnsMinorCat1.SelectedValue = rt.Rows[0]["intMinorCatagory2"].ToString(); } catch { }





                    dt = objregister.RegCostCenter(int.Parse(ddlTrnsUnit.SelectedValue));
                    ddlTrnsCostCenter.DataSource = dt;
                    ddlTrnsCostCenter.DataTextField = "Name";
                    ddlTrnsCostCenter.DataValueField = "Id";
                    ddlTrnsCostCenter.DataBind();

                    try
                    {
                        ddlTrnsCostCenter.SelectedValue = rt.Rows[0]["intCostCenter"].ToString();
                    }
                    catch { }
                    txtTrnsAssetName.Text = rt.Rows[0]["strNameOfAsset"].ToString();
                  txtTrnsDescription.Text= rt.Rows[0]["strDescriptionAsset"].ToString();
              

            }
                
            }

        private void TransferXml()
        {
            string unit = ddlTrnsUnit.SelectedValue.ToString();
            string assetname = txtTrnsAssetName.Text.ToString();
            string jobstation = ddlTrnsJobstation.SelectedValue.ToString();
            string description = txtTrnsDescription.Text.ToString();
            string mainType = ddlTrnsAssetType.SelectedValue.ToString();
            string mejorcat = ddlTrnsMajorCat.SelectedValue.ToString();
            string minorcat1 = ddlTrnsMinorCat1.SelectedValue.ToString();
            string minorcat2 = ddlTrnsMinorCat2.SelectedValue.ToString();
            string costcentrer = ddlTrnsCostCenter.SelectedValue.ToString();
            string enroll = txtTrnsUserEnroll.Text.ToString();
            string reffno = txtTrnsRefe.Text.ToString();
            string remarks = txtTrnsRemarks.Text.ToString();
            string dteTransaction = txtDteTrnsDate.Text.ToString();
            string trnType = ddlTransactionType.SelectedValue.ToString();
            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetId = searchKey[1];
            CreateTransferXml(assetId, unit, jobstation,costcentrer, enroll, reffno, remarks, dteTransaction, trnType);
        }

        private void CreateTransferXml(string assetId,string unit, string jobstation, string costcentrer, string enroll, string reffno, string remarks,string dteTransaction,string trnType)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMlAssetParking))
            {
                doc.Load(filePathForXMlAssetParking);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeTransfer(doc, assetId, unit, jobstation, costcentrer, enroll, reffno, remarks, dteTransaction, trnType);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeTransfer(doc, assetId, unit, jobstation, costcentrer, enroll, reffno, remarks, dteTransaction, trnType);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMlAssetParking);
        }

        private XmlNode CreateItemNodeTransfer(XmlDocument doc, string assetId, string unit, string jobstation, string costcentrer, string enroll, string reffno, string remarks,string dteTransaction,string trnType)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute AssetId = doc.CreateAttribute("assetId");
            AssetId.Value = assetId;

            XmlAttribute Unit = doc.CreateAttribute("unit");
            Unit.Value = unit;

            XmlAttribute Jobstation = doc.CreateAttribute("jobstation");
            Jobstation.Value = jobstation;

            XmlAttribute Costcentrer = doc.CreateAttribute("costcentrer");
            Costcentrer.Value = costcentrer;
            XmlAttribute Enroll = doc.CreateAttribute("enroll");
            Enroll.Value = enroll;

            XmlAttribute Reffno = doc.CreateAttribute("reffno");
            Reffno.Value = reffno;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            XmlAttribute DteTransaction = doc.CreateAttribute("dteTransaction");
            DteTransaction.Value = dteTransaction;
            XmlAttribute TrnType = doc.CreateAttribute("trnType");
            TrnType.Value = trnType;
            


            node.Attributes.Append(AssetId);
            node.Attributes.Append(Unit);
            node.Attributes.Append(Jobstation);
            node.Attributes.Append(Costcentrer);
            node.Attributes.Append(Enroll);
            node.Attributes.Append(Reffno);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(DteTransaction);
            node.Attributes.Append(TrnType);




            return node;
        }

        protected void ddlTrnsUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            dt = objregister.JobstationName(8, int.Parse(ddlTrnsUnit.SelectedValue), intenroll, intjobid, intdept, "0");
            ddlTrnsJobstation.DataSource = dt;
            ddlTrnsJobstation.DataTextField = "strJobStationName";
            ddlTrnsJobstation.DataValueField = "intEmployeeJobStationId";
            ddlTrnsJobstation.DataBind();

            dt = objregister.RegCostCenter(int.Parse(ddlTrnsUnit.SelectedValue));
            ddlTrnsCostCenter.DataSource = dt;
            ddlTrnsCostCenter.DataTextField = "Name";
            ddlTrnsCostCenter.DataValueField = "Id";
            ddlTrnsCostCenter.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);

        }

        protected void ddlTrnsJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {

            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

            string strSearchKey = txtAssetID.Text;
            string[] searchKey = Regex.Split(strSearchKey, ";");
            string assetcode = searchKey[1];

            int Mnumber = int.Parse("1".ToString());

            DataTable rt = new DataTable();
            rt = objregisterUpdate.AssetVehicleView(9, Mnumber, intenroll, intjobid, intdept, assetcode);
            dt = parking.CwipAssetView(7, xmlStringG, XMLVehicle, XMLBuilding, XMLLand, int.Parse(rt.Rows[0]["intAssetType"].ToString()), int.Parse(ddlTrnsJobstation.SelectedValue));//Parking List

            ddlTrnsMinorCat1.DataSource = dt;
            ddlTrnsMinorCat1.DataTextField = "strCategoryName";
            ddlTrnsMinorCat1.DataValueField = "intCategoryID";
            ddlTrnsMinorCat1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            TransferXml();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMlAssetParking);
            XmlNode dSftTm = doc.SelectSingleNode("voucher");
            string xmlString = dSftTm.InnerXml;
            xmlString = "<voucher>" + xmlString + "</voucher>";
            try { File.Delete(filePathForXMlAssetParking); } catch { }

            int intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            dt = objTransction.DepreciationView(11, xmlString, DateTime.Now, DateTime.Now, int.Parse(ddlTransactionType.SelectedValue), 0);
             ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
                      
            divClose();
          
        }
        #endregion ==========================Close================================================

        protected void btnClose_Click(object sender, EventArgs e)
        {

            divClose();
        }

        protected void ddlTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = int.Parse(ddlTransactionType.SelectedValue);
            if (type == 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                try { File.Delete(filePathForXMlAssetParking); } catch { }
                TransferPageLoad();
               
            }
           else if (type == 4)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnReclassDiv();", true);
                try { File.Delete(filePathForXMlAssetParking); } catch { }

                ReClasificationPageLoad();
              
               
               
            }
          else  if (type == 5)
            {
                try { File.Delete(filePathForXMlAssetParking); } catch { }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnSaleDiv();", true);
                SalePageLoad();
            }
         else   if (type == 6)
            {
                try { File.Delete(filePathForXMlAssetParking); } catch { }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnRevDiv();", true);
                RevaluationPageLoad();
            }
          else if (type == 7)
            {
                try { File.Delete(filePathForXMlAssetParking); } catch { }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDivDisposal();", true);
                DisposalPageLoad();
            }

        }

      

        private void divClose()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
        }
        #region===============AutoSearch==============================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetTransaction(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            return objAutoSearch_BLL.GetAssetItem(Active, prefixText);

        }



        #endregion===============Close================================


      
    }
}