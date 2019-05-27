using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.PaymentModule
{
    public partial class FG_Cost_Update : BasePage
    {
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        InventoryTransfer_BLL inventoryTransfer_Obj = new InventoryTransfer_BLL();
        DateTime dteDate;
        int type, GroupID=0, ItemId=0, UnitID=0, CoAID=0;
        string xmlString="", _filePathForXml;
        private string message;
        decimal monRate=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try { File.Delete(GetXmlFilePath()); } catch { }
                LoadUnit();
                LoadCostGroup();

                GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
                LoadGL(GroupID);

                UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
                LoadItem(UnitID);
                dt = unitObj.GetUnitDescriptionByUnitID(UnitID);
                lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
            }
        }
        private void LoadUnit()
        {
            dt = unitObj.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        private void LoadCostGroup()
        {
            dteDate = DateTime.Now;//txtEffectDate.Text.ToDateTime("yyyy-MM-dd");
            dt = inventoryTransfer_Obj.GetFgCostGroup();
            ddlCostGroup.Loads(dt, "intCostGroupID", "strCostGroup");
        }
        private void LoadGL(int CostGroupID)
        {
           
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            dteDate = CommonClass.GetDateAtSQLDateFormat(txtEffectDate.Text).Date;
            dt = inventoryTransfer_Obj.GetFgCostUpdate(2, dteDate, Enroll, xmlString, ItemId, UnitID, GroupID, CoAID, monRate);
            ddlGL.Loads(dt, "intAccID", "strAccName");
        }
        private void LoadItem(int unitid)
        {
           
            dt = inventoryTransfer_Obj.GetItemByUnitID(unitid);
            ddlItem.Loads(dt, "intItemID", "strProductName");
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            LoadItem(UnitID);

            dt = unitObj.GetUnitDescriptionByUnitID(UnitID);
            lblUnitName.Text=dt.Rows[0]["strDescription"].ToString();

        }
        
        protected void ddlCostGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            LoadGL(GroupID);
        }
        
        protected void dgvReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                LoadGridwithXml();

                DataSet dsGrid = (DataSet)dgvReport.DataSource;
                dsGrid.Tables[0].Rows[dgvReport.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(GetXmlFilePath());
                DataSet dsGridAfterDelete = (DataSet)dgvReport.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(GetXmlFilePath());
                    dgvReport.UnLoad();
                    lblUnitName.Visible = false;
                    lblReportName.Visible = false;
                }
                else
                {
                    LoadGridwithXml();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
       
        protected void btnShow_Click(object sender, EventArgs e)
        {

        }
        #region =========== action button =================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //string GroupID = ddlCostGroup.SelectedItem.Value;
            string ItemId = ddlItem.SelectedItem.Value;
            string ItemName = ddlItem.SelectedItem.Text;
            string costGroup = ddlCostGroup.SelectedItem.Text;
            string GLName = ddlGL.SelectedItem.Text;
            string value = txtValue.Text;

            if(dgvReport.Rows.Count>0)
            {
                File.Delete(GetXmlFilePath());
                dgvReport.UnLoad();
                CreateFGXML(ItemId, ItemName, GLName, costGroup, value);
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
            }
            else
            {
                CreateFGXML(ItemId, ItemName, GLName, costGroup, value);
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
            }
            
            

        }     

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ItemId = Convert.ToInt32( ddlItem.SelectedItem.Value);
            int UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            int CoAID = Convert.ToInt32(ddlGL.SelectedItem.Value);
            monRate = Convert.ToDecimal(txtValue.Text);
            dteDate=CommonClass.GetDateAtSQLDateFormat(txtEffectDate.Text).Date;
            inventoryTransfer_Obj.GetFgCostUpdate(1, dteDate, Enroll, xmlString, ItemId, UnitID, GroupID, CoAID, monRate);
            try { File.Delete(GetXmlFilePath()); } catch { }
            dgvReport.UnLoad();
            lblUnitName.Visible = false;
            lblReportName.Visible = false;
            txtEffectDate.Text = "";
            txtValue.Text = "";
            Toaster("Submitted Successfully", "FG Cost Update", Common.TosterType.Success);
        }
        #endregion ========= end button action ===========
        #region ================ XML Bind ===================
        private string GetXmlFilePath()
        {            
            _filePathForXml = Server.MapPath("~/PaymentModule/Data/FG__" + Enroll + ".xml");
            return _filePathForXml;
        }
        private void LoadGridwithXml()
        {
            string itemXML = XmlParser.GetXml(GetXmlFilePath());
            GridViewUtil.LoadGridwithXml(itemXML, dgvReport, out string message);

        }
        private void CreateFGXML(string ItemId,string ItemName,string GLName,string costGroup,string value)
        {
            dynamic obj = new
            {
                ItemId,ItemName,GLName,costGroup,value
            };

            XmlParser.CreateXml("CostGroup", "items", obj, GetXmlFilePath(), out message);
            LoadGridwithXml();
        }

        #endregion ================= End XML Bind =================


    }
}