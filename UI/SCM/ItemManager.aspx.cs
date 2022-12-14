using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ItemManager : BasePage
    {
        #region INIT
        private readonly StoreIssue_BLL _bll = new StoreIssue_BLL();
        private DataTable _dt = new DataTable();
        private int _wh;
        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IndentStatus";
        private string stop = "stopping SCM\\IndentStatus";
        private string perform = "Performance on SCM\\IndentStatus";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ItemManager"] = null;
                LoadWh();
                //LoadStoreLocation();
            }
        }
        #endregion

        #region Event
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string strSearchKey = txtItem.Text.ToString();
                _dt = _bll.GetMasterItem(strSearchKey);
                ListDatas.DataSource = _dt;
                ListDatas.DataValueField = "intItemMasterID";
                ListDatas.DataTextField = "strItemMasterName";
                ListDatas.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void gridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            LoadStoreLocation(e.Row.FindControl("ddlStoreLocation") as DropDownList);
            LoadItemCategory(e.Row.FindControl("ddlCategory") as DropDownList);
            LoadItemSubCategory(e.Row.FindControl("ddlSubCategory") as DropDownList);
            LoadItemMinorCategory(e.Row.FindControl("ddlMinorCategory") as DropDownList);


        }
        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            RemoveRow(sender);
        }
        protected void ListDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemId = ListDatas.SelectedItem.Value;
            string itemFullName = ListDatas.SelectedItem.Text;

            string[] array = itemFullName.Split(Variables.GetInstance().DelimiterChars);
            if (array.Length > 0)
            {
                itemName = array[2];
                uom = array[3];
            }
            else
            {
                return;
            }

            DataTable dataTable;
            dynamic obj = new
            {
                intMasterId = itemId,
                strItemName = itemName,
                strUom = uom
            };
            if (Session["ItemManager"] == null)
            {
                dataTable = GridViewUtil.InitDataTable(obj);
            }
            else
            {
                dataTable = (DataTable)Session["ItemManager"];
            }
            if (!dataTable.IsExist<string>("intMasterId", itemId))
            {
                dataTable.AddRow((object)obj);
                Session["ItemManager"] = dataTable;

                gridView.DataSource = dataTable;
                gridView.DataBind();
            }
            else
            {
                Toaster(Message.AlreadyAdded.ToFriendlyString(), Common.TosterType.Warning);
            }


        }
        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_bll.Test();
            try
            {
                List<Control> exceptList = new List<Control>();
                exceptList.Add(ddlWh);
                UpdatePanel0.Controls.Clear(exceptList);
                ListDatas.Items.Clear();
                if (gridView.UnLoad())
                {
                    Session["ItemManager"] = null;
                }
                //LoadStoreLocation();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    var fd = log.GetFlogDetail(start, location, "btnAdd_Click", null);
        //    Flogger.WriteDiagnostic(fd);

        //    var tracker = new PerfTracker(perform + " " + "btnAdd_Click", "", fd.UserName, fd.Location,
        //        fd.Product, fd.Layer);
        //    try
        //    {
        //        string masteritem = ListDatas.SelectedValue.ToString();
        //        _wh = int.Parse(ddlWh.SelectedValue);
        //        string xmlData = "<voucher><voucherentry masteritem=" + '"' + masteritem + '"' + "/></voucher>".ToString();
        //        int location = int.Parse(ddlLocation.SelectedValue);
        //        if (location > 0)
        //        {
        //            string msg = _bll.StoreIssue(13, xmlData, _wh, location, DateTime.Now, Enroll);
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
        //        }
        //        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Sselect your location');", true); }
        //    }
        //    catch (Exception ex)
        //    {
        //        var efd = log.GetFlogDetail(stop, location, "btnAdd_Click", ex);
        //        Flogger.WriteError(efd);
        //    }

        //    fd = log.GetFlogDetail(stop, location, "btnAdd_Click", null);
        //    Flogger.WriteDiagnostic(fd);
        //    // ends
        //    tracker.Stop();
        //}
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {

                _wh = ddlWh.SelectedValue();


                GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
                int itemMasterId = Convert.ToInt32((row.FindControl("lblMasterId") as Label)?.Text);

                int locationId = (row.FindControl("ddlStoreLocation") as DropDownList).SelectedValue();
                int subCategoryId = (row.FindControl("ddlSubCategory") as DropDownList).SelectedValue();
                string strSubCategory = (row.FindControl("ddlSubCategory") as DropDownList).SelectedItem.ToString();
                int minorCategoryId = (row.FindControl("ddlMinorCategory") as DropDownList).SelectedValue();
                int categoryId = (row.FindControl("ddlCategory") as DropDownList).SelectedValue();
                if (itemMasterId > 0)
                {
                    if (locationId > 0)
                    {
                        string msg = _bll.InsertIntoItem(Enroll, _wh, locationId, itemMasterId, subCategoryId,
                            minorCategoryId, categoryId, strSubCategory);
                        if (msg.ToLower().Contains("success"))
                        {
                            RemoveRow(sender);
                            Toaster(msg, Common.TosterType.Success);
                        }
                        else
                        {
                            Toaster(msg, Common.TosterType.Error);
                        }
                    }
                    else
                    {
                        Toaster("Please Select store location", Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster("Problem in item master ID.", Common.TosterType.Warning);
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        #endregion

        #region Method
        public void LoadWh()
        {
            _dt = _bll.GetViewData(1, "", _wh, 0, DateTime.Now, Enroll);
            ddlWh.Loads(_dt, "Id", "strName");
            _dt.Clear();
        }
        //public void LoadStoreLocation()
        //{
        //    _wh = ddlWh.SelectedValue();
        //    _dt = _bll.GetLocationByWh(_wh);
        //    ddlLocation.Loads(_dt, "Id", "strName");
        //    _dt.Clear();
        //}
        public void LoadStoreLocation(DropDownList ddl)
        {
            _wh = ddlWh.SelectedValue();
            _dt = _bll.GetLocationByWh(_wh);
            ddl.LoadWithSelect(_dt, "Id", "strName");
            _dt.Clear();
        }
        public void LoadItemCategory(DropDownList ddl)
        {
            _wh = ddlWh.SelectedValue();
            _dt = _bll.GetItemDropDownData(3, _wh);
            ddl.LoadWithSelect(_dt, "Id", "strName");
            _dt.Clear();
        }
        public void LoadItemSubCategory(DropDownList ddl)
        {
            _wh = ddlWh.SelectedValue();
            _dt = _bll.GetItemDropDownData(2, _wh);
            ddl.LoadWithSelect(_dt, "Id", "strName");
            _dt.Clear();
        }
        public void LoadItemMinorCategory(DropDownList ddl)
        {
            _wh = ddlWh.SelectedValue();
            _dt = _bll.GetItemDropDownData(1, _wh);
            ddl.LoadWithSelect(_dt, "Id", "strName");
            _dt.Clear();
        }
        private void RemoveRow(object sender)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string itemId = (row.FindControl("lblMasterId") as Label)?.Text;
            DataTable dt = (DataTable)Session["ItemManager"];
            dt.RemoveRow("intMasterId", itemId);
            gridView.Loads(dt);
            Session["ItemManager"] = dt;
        }
        private string itemId, itemName, uom;
        #endregion








        
       
    }
}