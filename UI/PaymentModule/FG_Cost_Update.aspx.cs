using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UI.ClassFiles;
using Utility;
using Label = System.Web.UI.WebControls.Label;
using BLL.AutoSearch;
using System.Web.Services;

namespace UI.PaymentModule
{
    public partial class FG_Cost_Update : BasePage
    {
        public static ItemBll itemBll;
        
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        InventoryTransfer_BLL inventoryTransfer_Obj = new InventoryTransfer_BLL();
        DateTime dteDate;
        int type, GroupID=0, ItemId=0, UnitID=0, CoAID=0, itemTypeId;
        string xmlString="", _filePathForXml, msg="", code, ItemName;
        private string message;
        decimal monRate=0; decimal total = 0;
        bool isExistM, isExistL, isExistO, isExistItemT, isExistItemM;
        string[] arrayKey;
        char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                itemBll = new ItemBll();
                Session["obj"] = null;
                dgvReport.DataSource = "";
                dgvReport.DataBind();
                //try { File.Delete(GetXmlFilePath()); } catch { }
                LoadUnit();
                LoadItemType();
                itemTypeId = Convert.ToInt32( ddlItemType.SelectedItem.Value);
                LoadCostGroup(itemTypeId);
                GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
                LoadGL(GroupID);

                UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
                //LoadItem(UnitID);
                dt = unitObj.GetUnitDescriptionByUnitID(UnitID);
                lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();

            }
            else
            {
                var tuple = Item();
                ItemId = tuple.Item1;
            }
        }
        private void LoadUnit()
        {
            dt = unitObj.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        private void LoadItemType()
        {
            ddlItemType.Items.Add(new ListItem("Trading", "1"));
            ddlItemType.Items.Add(new ListItem("Manufacturing", "2"));
        }
        private void LoadCostGroup(int itemTypeId)
        {
            dteDate = DateTime.Now;//txtEffectDate.Text.ToDateTime("yyyy-MM-dd");

            if(itemTypeId == 1)
            {                
                ddlCostGroup.UnLoad();
                ddlCostGroup.Items.Add(new ListItem("Material", "1"));
            }
            else if(itemTypeId == 2)
            {
                ddlCostGroup.UnLoad();
                dt = inventoryTransfer_Obj.GetFgCostGroup();
                ddlCostGroup.Loads(dt, "intCostGroupID", "strCostGroup");
            }
            
        }
        private void LoadGL(int CostGroupID)
        {
           
            //CostGroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            dteDate = CommonClass.GetDateAtSQLDateFormat(txtEffectDate.Text).Date;
            dt = inventoryTransfer_Obj.GetFgCostUpdate(2, CostGroupID, xmlString, UnitID);
            ddlGL.LoadWithSelect(dt, "intAccID", "strAccName");
        }
        //private void LoadItem(int unitid)
        //{          
        //    dt = inventoryTransfer_Obj.GetItemByUnitID(unitid);
        //    ddlItem.Loads(dt, "intItemID", "strProductName");
        //}
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            Session["UnitId"] = UnitID.ToString();
            //LoadItem(UnitID);

            dt = unitObj.GetUnitDescriptionByUnitID(UnitID);
            lblUnitName.Text=dt.Rows[0]["strDescription"].ToString();

        }

        protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemTypeId = Convert.ToInt32(ddlItemType.SelectedItem.Value);
            LoadCostGroup(itemTypeId);
        }
        protected void ddlCostGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            LoadGL(GroupID);
        }
        public void LoadAllDropdown()
        {
            LoadUnit();
            LoadItemType();
            itemTypeId = Convert.ToInt32(ddlItemType.SelectedItem.Value);
            LoadCostGroup(itemTypeId);
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            LoadGL(GroupID);
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            //LoadItem(UnitID);
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

        #region====Item Search====

        [WebMethod]
        public static string[] GetAutoCompleteData(string strSearchKey)
        {
            return itemBll.GetAllItemListByUnit(strSearchKey, HttpContext.Current.Session["UnitId"].ToString());
        }

        public Tuple<int,string> Item()
        {
            ItemId = 0;
            ItemName = "";
            if (!String.IsNullOrEmpty(txtItem.Text))
            {
                arrayKey = txtItem.Text.Split(delimiterChars);

                if (arrayKey.Length > 0)
                {
                    ItemId = Convert.ToInt32(arrayKey[1].ToString());
                    ItemName = arrayKey[0].ToString();
                }
            }
            return new Tuple<int, string>(ItemId,ItemName);
        }

        #endregion==End Search=======
        #region ========== Show Report Operation ===========
        protected void btnShow_Click(object sender, EventArgs e)
        {
            UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            var tuple = Item();
            ItemId = tuple.Item1;
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
                System.Web.UI.WebControls.Label LabelTotal = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblTotal");
                if (LabelTotal != null)
                {
                    LabelTotal.Text = total.ToString();
                }
            }
        }
        #endregion========= End Show Button ==============

        #region =========== action button (Add and Submit) =================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int UnitID = Convert.ToInt32(ddlUnit.SelectedItem.Value);

            //getting item id and item name
            var tuple = Item();
            string ItemId = tuple.Item1.ToString();
            string ItemName = tuple.Item2;

            string costGroup = ddlCostGroup.SelectedItem.Text;
            string GLName = ddlGL.SelectedItem.Text;
            string value = txtValue.Text;
            GroupID = Convert.ToInt32(ddlCostGroup.SelectedItem.Value);
            int CoAID = Convert.ToInt32(ddlGL.SelectedValue);
            monRate = Convert.ToDecimal(txtValue.Text);
            dteDate = CommonClass.GetDateAtSQLDateFormat(txtEffectDate.Text).Date;
            string ItemTypeID = ddlItemType.SelectedItem.Text;

            dt = inventoryTransfer_Obj.GetFGCode(CoAID);

            try {  code = dt.Rows[0]["strCode"].ToString(); }
            catch { code = ""; }
            

            if (dgvReport.Rows.Count>0)
            {
                //File.Delete(GetXmlFilePath());
                //dgvReport.UnLoad();
                CreateFGXML(ItemId, ItemName, GLName, costGroup, value, UnitID.ToString(), GroupID.ToString(), CoAID.ToString(), monRate.ToString(), dteDate.ToString(), ItemTypeID, code);
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
            }
            else
            {
                CreateFGXML(ItemId, ItemName, GLName, costGroup, value, UnitID.ToString(), GroupID.ToString(), CoAID.ToString(), monRate.ToString(), dteDate.ToString(), ItemTypeID, code);
                lblUnitName.Visible = true;
                lblReportName.Visible = true;
            }
            dgvShowReport.UnLoad();
            

        }     
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var tuple = Item();
            string ItemId = tuple.Item1.ToString();
            string ItemName = tuple.Item2;

            DataTable dt = GetDataTable(dgvReport);
            DataTable distictTable = dt.DefaultView.ToTable(true, "column0");
            if (distictTable.Rows.Count > 0)
            {
                List<string> itemIds = new List<string>();
                foreach(DataRow row in distictTable.Rows)
                {
                    itemIds.Add(row["column0"].ToString());
                }
                foreach(string itemId in itemIds)
                {
                    
                    isExistItemT = dt.IsExist(r => r.Field<string>("column6") == "Trading" && r.Field<string>("column0")==itemId);
                    isExistItemM = dt.IsExist(r => r.Field<string>("column6") == "Manufacturing" && r.Field<string>("column0") == itemId);
                    isExistM = dt.IsExist(r => r.Field<string>("column2") == "Material" && r.Field<string>("column0") == itemId);
                   
                   
                    if(isExistItemM==true)
                    {
                        isExistO = dt.IsExist(r => r.Field<string>("column2") == "Overhead" && r.Field<string>("column0") == itemId);
                        isExistL = dt.IsExist(r => r.Field<string>("column2") == "Labour" && r.Field<string>("column0") == itemId);
                        if (isExistM != true)
                        {
                            msg = "Please Enter Material Cost Group For Item: " + ItemName;
                            Toaster(msg, "Product Cost", Common.TosterType.Warning);
                            return;
                        }
                        if (isExistL != true)
                        {
                            msg = "Please Enter Labour Cost Group For Item: " + ItemName + " for Labour cost group";
                            Toaster(msg, "Product Cost", Common.TosterType.Warning);
                            return;
                        }

                        if (isExistO != true)
                        {
                            msg = "Please Enter Overhead Cost Group For Item: " + ItemName;
                            Toaster(msg, "Product Cost", Common.TosterType.Warning);
                            return;
                        }
                        
                        
                    }
                    else if(isExistItemT==true)
                    {
                        if (isExistM != true)
                        {
                            msg = "Please Enter Material Cost Group For Item: " + ItemName;
                            Toaster(msg, "Product Cost", Common.TosterType.Warning);
                            return;
                        }
                    }
                    
                }

                //End foreach

                SubmitData();


            }
            

        }
        public void SubmitData()
        {
            List<object> objects = new List<object>();
            List<object> objectsNew = new List<object>();
            List<string[]> dataList = new List<string[]>();
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
                    UnitID = Common.GetPropertyValue(o, "UnitID"),
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
                Toaster("No Data Found To Insert", "Product Cost", Common.TosterType.Warning);
            }
            Session["obj"] = null;
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        public DataTable GetDataTable(GridView gridView)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                dt.Columns.Add("column" + i.ToString());
            }
            foreach (GridViewRow row in gridView.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["column0"] = ((Label)row.FindControl("lblItemID")).Text;
                dr["column1"] = ((Label)row.FindControl("lblstrItem")).Text;
                dr["column2"] = ((Label)row.FindControl("lblstrCostGroup")).Text;
                dr["column3"] = ((Label)row.FindControl("lblGL")).Text;
                dr["column4"] = ((Label)row.FindControl("lblmonValue")).Text;
                dr["column5"] = ((Label)row.FindControl("lblItemID")).Text;
                dr["column6"] = ((Label)row.FindControl("lblItemTypeId")).Text;
                dt.Rows.Add(dr);
            }
            return dt;
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
        private void CreateFGXML(string ItemId,string ItemName, string GLName,string costGroup,string value,string UnitID, string GroupID, string CoAID, string monRate, string dteDate, string ItemTypeID,string code)
        {
            dynamic obj = new
            {
                ItemId,ItemName,GLName,costGroup,value,UnitID,GroupID,CoAID,monRate,dteDate,ItemTypeID,
                code
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