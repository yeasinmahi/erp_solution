using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Xml;
using UI.ClassFiles;
using System.Drawing;

namespace UI.Asset
{
    public partial class AssetCOAConfigure_UI :BasePage
    {
        AssetMaintenance configure = new AssetMaintenance();
        DataTable dt = new DataTable();

        string filePathForXMLAssetAccoA;

        string xmlStringAssetAccoA = "";
        AssetMaintenance rpt = new AssetMaintenance();
        int type;
        protected void Page_Load(object sender, EventArgs e)
        {
           filePathForXMLAssetAccoA = Server.MapPath("~/Asset/Data/depc_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
        
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXMLAssetAccoA); dgvGridView.DataSource = ""; dgvGridView.DataBind(); }
                catch { }

                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = new DataTable();
                dt = configure.CheckCorporate(intenroll);
                if(dt.Rows.Count>0)
                {
                    dt = new DataTable();
                    dt = configure.UnitName();
                    DdlBillUnit.DataSource = dt;
                    DdlBillUnit.DataTextField = "Name";
                    DdlBillUnit.DataValueField = "ID";
                    DdlBillUnit.DataBind();
                    dt = new DataTable();
                    Int32 unit = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
                    dt = configure.UitbyJobstation(unit);
                    DdlJobstation.DataSource = dt;
                    DdlJobstation.DataTextField = "Name";
                    DdlJobstation.DataValueField = "ID";
                    DdlJobstation.DataBind();
                   // DdlJobstation.Items.Insert(0, new ListItem("All", "0"));
                }

                else
                {
                    Int32 unit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    Int32 jobstation = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = new DataTable();
                    dt = configure.UserUnitName(unit);
                    DdlBillUnit.DataSource = dt;
                    DdlBillUnit.DataTextField = "Name";
                    DdlBillUnit.DataValueField = "ID";
                    DdlBillUnit.DataBind();
                    dt = new DataTable();
                  
                    dt = configure.UserJobstation(jobstation);
                    DdlJobstation.DataSource = dt;
                    DdlJobstation.DataTextField = "Name";
                    DdlJobstation.DataValueField = "ID";
                    DdlJobstation.DataBind();
                   
                }
               
              
                dt = new DataTable();
                dt = configure.AssetType(); 
                ddlType.DataSource = dt;
                ddlType.DataTextField = "strAssetTypeName";
                ddlType.DataValueField = "intAssetTypeID";
                ddlType.DataBind();

               ddlType.Items.Insert(0, new ListItem("All", "0"));
              
                pnlUpperControl.DataBind();

            }
        }

       

        protected void DdlBillUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
            dt = new DataTable();
            try
            {
                dgvGridView.DataSource ="";
                dgvGridView.DataBind();
            }
            catch { };
            dt = new DataTable();
            dt = configure.UitbyJobstation(unit);
            DdlJobstation.DataSource = dt;
            DdlJobstation.DataTextField = "Name";
            DdlJobstation.DataValueField = "ID";
            DdlJobstation.DataBind();
          

        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
           
            this.BindGrid();
            
        }

        private void BindGrid()
        {
            dt = new DataTable();
            DateTime sdate = DateTime.Parse("2016-01-01".ToString());
            DateTime edate = DateTime.Parse("2016-01-01".ToString());
            int jobid = int.Parse(DdlJobstation.SelectedValue.ToString());
            string unit = DdlBillUnit.SelectedValue.ToString();
            string xmlunit = "<voucher><voucherentry UnitID=" + '"' + unit + '"' + "/></voucher>".ToString();
            int assetid = int.Parse(ddlType.SelectedValue.ToString());
            dt = configure.AssetViewforGlobalCOA(4, xmlunit, sdate, edate, jobid, assetid);
            dgvGridView.DataSource = dt;
            dgvGridView.DataBind();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgvGridView.PageIndex = e.NewPageIndex;
            this.BindGrid();
           

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int coaCodeID = int.Parse(0.ToString());
            int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
            int costcenter = int.Parse(0.ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            if (dgvGridView.Rows.Count > 0)
            {

                for (int index = 0; index < dgvGridView.Rows.Count; index++)
                {
                    if (((CheckBox)dgvGridView.Rows[index].FindControl("chkRow")).Checked == true)
                    {

                        string assetid = ((Label)dgvGridView.Rows[index].FindControl("strAssetCode")).Text.ToString();
                        string costid = ((DropDownList)dgvGridView.Rows[index].FindControl("ddlCostcenter")).SelectedValue.ToString();  
                       // string  costid =((DropDownList)dgvGridView.Rows[index].FindControl("ddlCostcenter")).SelectedValue.ToString();
                        string  gcoaid =((DropDownList)dgvGridView.Rows[index].FindControl("ddlCOA")).SelectedValue.ToString();
                        string  dteacisition = ((TextBox)dgvGridView.Rows[index].FindControl("TxtdteAcusition")).Text.ToString();
                        string  acusutionValue = ((TextBox)dgvGridView.Rows[index].FindControl("TxtAcusitionValue")).Text.ToString();
                        string  acumulatedDep = ((TextBox)dgvGridView.Rows[index].FindControl("TxtAccumulatedDep")).Text.ToString();
                        string totalAcumulatedcost = ((TextBox)dgvGridView.Rows[index].FindControl("TxtTotalAcumulatedCost")).Text.ToString();
                        string deprate = ((TextBox)dgvGridView.Rows[index].FindControl("txtDepRate")).Text.ToString(); 
                        int enroll = int.Parse(Session[SessionParams.USER_ID].ToString()); 

                        CreateVoucherXml(assetid, costid, gcoaid, dteacisition, acusutionValue, acumulatedDep, totalAcumulatedcost, deprate);

                          
                    }


                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlStringAssetAccoA = dSftTm.InnerXml;
                xmlStringAssetAccoA = "<voucher>" + xmlStringAssetAccoA + "</voucher>";
                //user SP ERP_ASSET Database  [dbo].[sprAsetACOAXML]//
                type = 0;
                string message = rpt.UpdateAssetGlobalCOA(xmlStringAssetAccoA, coaCodeID, type, costcenter, intenroll);



                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                try { File.Delete(filePathForXMLAssetAccoA); }
                catch { }

            }
            this.BindGrid();
           
        }

        private void CreateVoucherXml(string assetid, string costid, string gcoaid, string dteacisition, string acusutionValue, string acumulatedDep, string totalAcumulatedcost,string deprate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAssetAccoA))
            {
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeGetpassOut(doc, assetid, costid, gcoaid, dteacisition, acusutionValue, acumulatedDep, totalAcumulatedcost, deprate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeGetpassOut(doc, assetid, costid, gcoaid, dteacisition, acusutionValue, acumulatedDep, totalAcumulatedcost, deprate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAssetAccoA);
        }

        private XmlNode CreateItemNodeGetpassOut(XmlDocument doc, string assetid, string costid, string gcoaid, string dteacisition, string acusutionValue, string acumulatedDep, string totalAcumulatedcost,string deprate)
        {

            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Assetid = doc.CreateAttribute("assetid");
            Assetid.Value = assetid;
            XmlAttribute Costid = doc.CreateAttribute("costid");
            Costid.Value = costid;
            XmlAttribute Gcoaid = doc.CreateAttribute("gcoaid");
            Gcoaid.Value = gcoaid;
            XmlAttribute Dteacisition = doc.CreateAttribute("dteacisition");
            Dteacisition.Value = dteacisition;
            XmlAttribute AcusutionValue = doc.CreateAttribute("acusutionValue");
            AcusutionValue.Value = acusutionValue;
            XmlAttribute AcumulatedDep = doc.CreateAttribute("acumulatedDep");
            AcumulatedDep.Value = acumulatedDep;

            XmlAttribute TotalAcumulatedcost = doc.CreateAttribute("totalAcumulatedcost");
            TotalAcumulatedcost.Value = totalAcumulatedcost;
            XmlAttribute Deprate = doc.CreateAttribute("deprate");
            Deprate.Value = deprate; 


            node.Attributes.Append(Assetid);
            node.Attributes.Append(Costid);
            node.Attributes.Append(Gcoaid);
            node.Attributes.Append(Dteacisition);
            node.Attributes.Append(AcusutionValue);
            node.Attributes.Append(AcumulatedDep);
            node.Attributes.Append(TotalAcumulatedcost);
            node.Attributes.Append(Deprate); 
            return node;
        }

       

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               // int costid=int.Parse(0.ToString()); 
                string assetid = ((Label)dgvGridView.Rows[e.RowIndex].FindControl("strAssetCode")).Text.ToString();
                int costid = int.Parse(((DropDownList)dgvGridView.Rows[e.RowIndex].FindControl("ddlCostcenter")).SelectedValue.ToString());
                int gcoaid = int.Parse(((DropDownList)dgvGridView.Rows[e.RowIndex].FindControl("ddlCOA")).SelectedValue.ToString());
                DateTime dteacisition = DateTime.Parse(((TextBox)dgvGridView.Rows[e.RowIndex].FindControl("TxtdteAcusition")).Text.ToString());
                decimal acusutionValue = decimal.Parse(((TextBox)dgvGridView.Rows[e.RowIndex].FindControl("TxtTotalAcumulatedCost")).Text.ToString());
                decimal acumulatedDep = decimal.Parse(((TextBox)dgvGridView.Rows[e.RowIndex].FindControl("TxtAccumulatedDep")).Text.ToString());
                decimal deprate = decimal.Parse(((TextBox)dgvGridView.Rows[e.RowIndex].FindControl("txtDepRate")).Text.ToString());
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                configure.UpdateAsstList( gcoaid, dteacisition, acusutionValue, acumulatedDep,costid, enroll,deprate, assetid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully Update');", true);


                this.BindGrid();
            }
            catch { }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
            catch { };
        }

        protected void DdlJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
            catch { };
        }

    }
}