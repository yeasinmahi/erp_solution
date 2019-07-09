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
        decimal monRate=0; decimal total = 0;
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
            dt = inventoryTransfer_Obj.GetFgCostUpdate(2, Enroll, xmlString, UnitID);
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
                if (Session["obj"] != null)
                {
                    List<object> objects = (List<object>)Session["obj"];
                    objects.RemoveAt(e.RowIndex);
                    if (objects.Count > 0)
                    {
                        string xmlString = XmlParser.GetXml("CostGroup", "items", objects, out string _);
                        LoadGridwithXml(xmlString);
                    }
                    else
                    {
                        dgvReport.UnLoad();
                    }

                    //LoadGridwithXml();

                    //DataSet dsGrid = (DataSet)dgvReport.DataSource;
                    //dsGrid.Tables[0].Rows[dgvReport.Rows[e.RowIndex].DataItemIndex].Delete();
                    //dsGrid.WriteXml(GetXmlFilePath());
                    //DataSet dsGridAfterDelete = (DataSet)dgvReport.DataSource;
                    //if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                    //{
                    //    File.Delete(GetXmlFilePath());
                    //    dgvReport.UnLoad();
                    //    lblUnitName.Visible = false;
                    //    lblReportName.Visible = false;
                    //}
                    //else
                    //{
                    //    LoadGridwithXml();
                    //}
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            ItemId = Convert.ToInt32(ddlItem.SelectedItem.Value);
            dt = inventoryTransfer_Obj.GetFGDetail(ItemId, UnitID);
            if(dt.Rows.Count>0)
            {
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
                report.Visible = true;
                dgvShowReport.DataSource = dt;
                dgvShowReport.DataBind();
                dgvShowReport.FooterRow.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                dgvShowReport.UnLoad();
                Toaster("There is no data","Product Cost", Common.TosterType.Warning);
            }
            dgvReport.UnLoad();

        }

        protected void dgvShowReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monCost"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label LabelTotal = (Label)e.Row.FindControl("lblTotal");
                if (LabelTotal != null)
                {
                    LabelTotal.Text = total.ToString();
                }
            }
        }
        #region =========== action button =================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            string ItemId = ddlItem.SelectedItem.Value;
            string ItemName = ddlItem.SelectedItem.Text;
            string costGroup = ddlCostGroup.SelectedItem.Text;
            string GLName = ddlGL.SelectedItem.Text;
            string value = txtValue.Text;
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            int CoAID = Convert.ToInt32(ddlGL.SelectedItem.Value);
            monRate = Convert.ToDecimal(txtValue.Text);
            dteDate = CommonClass.GetDateAtSQLDateFormat(txtEffectDate.Text).Date;

            if (dgvReport.Rows.Count>0)
            {
                //File.Delete(GetXmlFilePath());
                //dgvReport.UnLoad();
                CreateFGXML(ItemId, ItemName, GLName, costGroup, value, UnitID.ToString(), GroupID.ToString(), CoAID.ToString(), monRate.ToString(), dteDate.ToString());
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
            }
            else
            {
                CreateFGXML(ItemId, ItemName, GLName, costGroup, value, UnitID.ToString(), GroupID.ToString(), CoAID.ToString(), monRate.ToString(), dteDate.ToString());
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
            }
            dgvShowReport.UnLoad();
            

        }     

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ItemId = Convert.ToInt32( ddlItem.SelectedItem.Value);
            int UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            int CoAID = Convert.ToInt32(ddlGL.SelectedItem.Value);
            monRate = Convert.ToDecimal(txtValue.Text);
            dteDate=CommonClass.GetDateAtSQLDateFormat(txtEffectDate.Text).Date;
            string a=  xmlString;
            //inventoryTransfer_Obj.GetFgCostUpdate(1, dteDate, Enroll, xmlString, ItemId, UnitID, GroupID, CoAID, monRate);
            //try { File.Delete(GetXmlFilePath()); } catch { }

            List<object> objects = new List<object>();
            List<object> objectsNew = new List<object>();
            if (Session["obj"] != null)
            {
                objects = (List<object>)Session["obj"];
            }
            foreach (object o in objects)
            {
                dynamic obj = new
                {
                    ItemId = Common.GetPropertyValue(o, "ItemId"),
                    ItemName = Common.GetPropertyValue(o, "ItemName"),
                    GLName = Common.GetPropertyValue(o, "GLName"),
                    costGroup = Common.GetPropertyValue(o, "costGroup"),
                    UnitID= Common.GetPropertyValue(o, "UnitID"),
                    value = Common.GetPropertyValue(o, "value"),
                    GroupID = Common.GetPropertyValue(o, "GroupID"),
                    CoAID = Common.GetPropertyValue(o, "CoAID"),
                    monRate = Common.GetPropertyValue(o, "monRate"),
                    dteDate = Common.GetPropertyValue(o, "dteDate")

                };
                objectsNew.Add(obj);
            }
            if (objectsNew.Count > 0)
            {
                xmlString = XmlParser.GetXml("CostGroup", "items", objectsNew, out string message);
                inventoryTransfer_Obj.GetFgCostUpdate(1, Enroll, xmlString, UnitID);
                dgvReport.UnLoad();
                Session["obj"] = null;
                lblUnitName.Visible = false;
                lblReportName.Visible = false;
                txtEffectDate.Text = "";
                txtValue.Text = "";
                Toaster("Submitted Successfully", "Product Cost", Common.TosterType.Success);
            }
            else
            {
                Toaster("No Data Found to Insert", "OverTime", Common.TosterType.Warning);
            }
            Session["obj"] = null;
            dgvReport.DataSource="";
            dgvReport.DataBind();

        }
        #endregion ========= end button action ===========
        #region ================ XML Bind ===================
        private string GetXmlFilePath()
        {            
            _filePathForXml = Server.MapPath("~/PaymentModule/Data/FG__" + Enroll + ".xml");
            return _filePathForXml;
        }
        private void LoadGridwithXml(string itemXML)
        {
            //string itemXML = XmlParser.GetXml(GetXmlFilePath());
            GridViewUtil.LoadGridwithXml(itemXML, dgvReport, out string message);

        }
        private void CreateFGXML(string ItemId,string ItemName,string GLName,string costGroup,string value,string UnitID, string GroupID, string CoAID, string monRate, string dteDate)
        {
            dynamic obj = new
            {
                ItemId,ItemName,GLName,costGroup,value,UnitID,GroupID,CoAID,monRate,dteDate
            };
            List<object> objects = new List<object>();
            if (Session["obj"] != null)
            {
                objects = (List<object>)Session["obj"];
            }
            objects.Add(obj);
            Session["obj"] = objects;

            //XmlParser.CreateXml("CostGroup", "items", obj, GetXmlFilePath(), out message);

            xmlString =  XmlParser.GetXml("CostGroup", "items", objects, out string _);

            LoadGridwithXml(xmlString);
        }

        #endregion ================= End XML Bind =================


    }
}