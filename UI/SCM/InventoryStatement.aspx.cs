using System;
using System.Data;
using UI.ClassFiles;
using SCM_BLL;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SCM
{
    public partial class InventoryStatement : BasePage
    {
        private MasterMaterialBLL bll = new MasterMaterialBLL(); private DataTable dt;

        private int intSearchBy, intPart, intWHID, intInsertBy, intGroupID, intCategoryID, intCatNew, intReportType, intItemID;
        private string strItem, strID;
        private DateTime dteFDate, dteTDate;
        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\InventoryStatement";
        private string stop = "stopping SCM\\InventoryStatement";
        private string perform = "Performance on SCM\\InventoryStatement";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // starting performance tracker
                var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    lblGroup.Text = "Item Name :";
                    lblGroup.Visible = true;
                    ddlGroup.Visible = false;
                    txtItem.Visible = true;
                    txtItemID.Visible = true;
                    lblCategory.Visible = true;
                    lblCategory.Text = "Item ID :";
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    ddlCategory.Visible = false;

                    intPart = 1;
                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intPart, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlWH.DataTextField = "strWareHoseName";
                    ddlWH.DataValueField = "intWHID";
                    ddlWH.DataSource = dt;
                    ddlWH.DataBind();
                    intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                    if (intWHID == 2)
                    {
                        Label1.Visible = true;
                        Label3.Visible = true;
                        txtFTime.Visible = true;
                        txtTTime.Visible = true;
                    }
                    else
                    {
                        txtFTime.Visible = false;
                        txtTTime.Visible = false;
                        Label1.Visible = false;
                        Label3.Visible = false;
                    }
                    txtFTime.Text = "00:00";
                    txtTTime.Text = "23:59";
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlSearchBy.SelectedValue = "1";
                lblGroup.Text = "Item Name :";
                ddlCategory.Visible = false;
                ddlGroup.Visible = false;
                txtItem.Visible = true;
                txtItemID.Visible = true;
                lblCategory.Visible = true;
                lblCategory.Text = "Item ID :";
                lblSubCategory.Visible = false;
                ddlSubCategory.Visible = false;

                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                if (intWHID == 2)
                {
                    Label1.Visible = true;
                    Label3.Visible = true;
                    txtFTime.Visible = true;
                    txtTTime.Visible = true;
                }
                else
                {
                    txtFTime.Visible = false;
                    txtTTime.Visible = false;
                    Label1.Visible = false;
                    Label3.Visible = false;
                }
                txtFTime.Text = "00:00";
                txtTTime.Text = "23:59";
            }
            catch { }
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFistDropDown();
            LoadSecondDropDown();
            LoadThirdDropDown();
        }

        private void LoadFistDropDown()
        {
            try
            {
                intSearchBy = int.Parse(ddlSearchBy.SelectedValue.ToString());
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());

                if (intSearchBy == 1) //Item
                {
                    lblGroup.Text = "Item Name :";
                    ddlGroup.Visible = false;
                    txtItem.Visible = true;
                    txtItemID.Visible = true;
                    lblCategory.Visible = true;
                    lblCategory.Text = "Item ID :";
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;

                    if (intWHID == 2)
                    {
                        Label1.Visible = true;
                        Label3.Visible = true;
                        txtFTime.Visible = true;
                        txtTTime.Visible = true;
                    }
                    else
                    {
                        txtFTime.Visible = false;
                        txtTTime.Visible = false;
                        Label1.Visible = false;
                        Label3.Visible = false;
                    }
                    txtFTime.Text = "00:00";
                    txtTTime.Text = "23:59";
                }
                else if (intSearchBy == 2) //Group
                {
                    lblGroup.Text = "Group :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    txtItemID.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strGroupName";
                    ddlGroup.DataValueField = "intGroupID";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 3) //Category
                {
                    lblGroup.Text = "Group :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = true;
                    ddlCategory.Visible = true;
                    txtItemID.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    lblCategory.Text = "Category :";

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(2, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strGroupName";
                    ddlGroup.DataValueField = "intGroupID";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();

                    LoadSecondDropDown();
                }
                else if (intSearchBy == 4) //Sub Category
                {
                    lblGroup.Text = "Group :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = true;
                    ddlCategory.Visible = true;
                    txtItemID.Visible = false;
                    lblSubCategory.Visible = true;
                    ddlSubCategory.Visible = true;
                    lblCategory.Text = "Category :";
                    lblSubCategory.Text = "Sub-Category :";

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(2, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strGroupName";
                    ddlGroup.DataValueField = "intGroupID";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();

                    LoadSecondDropDown();
                    LoadThirdDropDown();
                }
                else if (intSearchBy == 5) //Minor Category
                {
                    lblGroup.Text = "Minor Category :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strMinorCategory";
                    ddlGroup.DataValueField = "intMinorCategory";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 6) //Store Location
                {
                    lblGroup.Text = "Store Location :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strLocationName";
                    ddlGroup.DataValueField = "intStoreLocationID";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 7) //Plant
                {
                    lblGroup.Text = "Plant :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strPlantName";
                    ddlGroup.DataValueField = "intPlantID";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 8) //Purchase Type
                {
                    lblGroup.Text = "Purchase Type :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strPurchaseType";
                    ddlGroup.DataValueField = "intPurchaseType";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 9) //ABC
                {
                    lblGroup.Text = "ABC Classification :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strABC";
                    ddlGroup.DataValueField = "intABC";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 10) //FSN
                {
                    lblGroup.Text = "FSN Classification :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strFSN";
                    ddlGroup.DataValueField = "intFSN";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
                else if (intSearchBy == 11) //VDE
                {
                    lblGroup.Text = "VDE Classification :";
                    ddlGroup.Visible = true;
                    txtItem.Visible = false;
                    lblCategory.Visible = false;
                    ddlCategory.Visible = false;
                    lblSubCategory.Visible = false;
                    ddlSubCategory.Visible = false;
                    txtItemID.Visible = false;

                    dt = new DataTable();
                    dt = bll.GetDropDaownData(intSearchBy, intWHID, intInsertBy, intGroupID, intCategoryID);
                    ddlGroup.DataTextField = "strVDE";
                    ddlGroup.DataValueField = "intVDE";
                    ddlGroup.DataSource = dt;
                    ddlGroup.DataBind();
                }
            }
            catch { }
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSecondDropDown();
            LoadThirdDropDown();
        }

        private void LoadSecondDropDown()
        {
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                intGroupID = int.Parse(ddlGroup.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetDropDaownData(3, intWHID, intInsertBy, intGroupID, intCategoryID);
                ddlCategory.DataTextField = "strCategoryName";
                ddlCategory.DataValueField = "intCategoryID";
                ddlCategory.DataSource = dt;
                ddlCategory.DataBind();
            }
            catch { }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThirdDropDown();
        }

        private void LoadThirdDropDown()
        {
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                intCategoryID = int.Parse(ddlGroup.SelectedValue.ToString());

                dt = new DataTable();
                dt = bll.GetDropDaownData(4, intWHID, intInsertBy, intGroupID, intCategoryID);
                ddlSubCategory.DataTextField = "strSubCategoryName";
                ddlSubCategory.DataValueField = "intSubCategoryID";
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataBind();
            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                intSearchBy = int.Parse(ddlSearchBy.SelectedValue.ToString());
                dteFDate = DateTime.Parse(txtdteFrom.Text);
                dteTDate = DateTime.Parse(txtdteTo.Text);
                try { intItemID = int.Parse(txtItemID.Text); } catch { intItemID = 0; }
                if (intSearchBy == 1 && intItemID == 0) //Search By Item Name
                {
                    intReportType = 4;
                    strID = txtItem.Text;
                }
                else if (intSearchBy == 1 && intItemID != 0) //Search By Item ID
                {
                    intReportType = 3;
                }
                else if (intSearchBy == 2) //Search By Group
                {
                    intReportType = 0;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 3) //Search By Category
                {
                    intReportType = 2;
                    strID = ddlCategory.SelectedValue.ToString();
                }
                else if (intSearchBy == 4) //Search By Sub Category
                {
                    intReportType = 1;
                    strID = ddlSubCategory.SelectedValue.ToString();
                }
                else if (intSearchBy == 5) //Search By Minor Category
                {
                    intReportType = 7;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 6) //Search By Store Location
                {
                    intReportType = 6;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 7) //Search By Plant
                {
                    intReportType = 8;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 8) //Search By Purchase Type
                {
                    intReportType = 5;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 9) //Search By ABC Classification
                {
                    intReportType = 9;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 10) //Search By FSN Classification
                {
                    intReportType = 10;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                else if (intSearchBy == 11) //Search By VDE Classification
                {
                    intReportType = 11;
                    strID = ddlGroup.SelectedValue.ToString();
                }
                dt = new DataTable();
                dt = bll.GetInventoryStatement(intWHID, dteFDate, dteTDate, intReportType, strID, 0);
                dgvInvnetory.DataSource = dt;
                dgvInvnetory.DataBind();
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
    }
}