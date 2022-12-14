using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class TargetAcvReport : Page
    {
        private readonly StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        private string _reportType;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Consumer\\TargetAcvReport";
        string stop = "stopping SAD\\Consumer\\TargetAcvReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNecessaryUi();
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadAreaDdl();
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            DataTable source = new DataTable();
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\TargetAcvReport Achievement Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = fromDate.ToDateTime("MM/dd/yyyy");
                fromDateTime = fromDateTime.AddHours(6);
                DateTime toDateTime = toDate.ToDateTime("MM/dd/yyyy");
                toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
                if (_reportType.Equals("TargetAchievement"))
                {
                    source = _bll.GetDistributorAndIhbSales(fromDateTime, toDateTime);
                }
                else if (_reportType.Equals("DistributorBoostup"))
                {
                    source = _bll.GetBoostupCom(fromDateTime, toDateTime);
                }
                else if (_reportType.Equals("CashCom"))
                {
                    source = _bll.GetCashOrRetailCom(fromDateTime, toDateTime, 4);
                }
                else if (_reportType.Equals("RetailCom"))
                {
                    source = _bll.GetCashOrRetailCom(fromDateTime, toDateTime, 6);
                }
                else if (_reportType.Equals("BankCom"))
                {
                    source = _bll.GetAllJvWithCostCenterId("99",fromDateTime, toDateTime, "0");
                }
                else if (_reportType.Equals("StarProgramCom"))
                {
                    string area = ddlArea.SelectedItem.Text;
                    source = _bll.GetAllJvWithCostCenterId("Star Consumer program", fromDateTime, toDateTime, area);
                }
                else if (_reportType.Equals("BondhutterBondhon"))
                {
                    string area = ddlArea.SelectedItem.Text;
                    source = _bll.GetAllJvWithCostCenterId("Bondhutter Bondhon", fromDateTime, toDateTime, area);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select All input Properly. " + ex.Message + "');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
           

            //LoadGridView(source);
            CreateGridView(source);
        }
        private void CreateGridView(DataTable source)
        {
            GridView gridView = grdv;
            gridView = GridViewUtil.RemoveGridColumn(gridView);
            gridView.Visible = true;

            //GridView gridView = new GridView();
            //gridView.AutoGenerateColumns = false;


            //TemplateField tfObject = new TemplateField();
            //tfObject.HeaderTemplate = new CreateItemTemplate(ListItemType.Header, CreateItemTemplate.ControlType.CheckBox);
            //tfObject.ItemTemplate = new CreateItemTemplate(ListItemType.Item,CreateItemTemplate.ControlType.CheckBox);
            //gridView.Columns.Add(tfObject);

            if (_reportType.Equals("TargetAchievement"))
            {
                gridView = CreateTargetAchievement(gridView);
            }
            else if (_reportType.Equals("DistributorBoostup"))
            {
                gridView = CreateDistributorBoostup(gridView);
            }
            else if (_reportType.Equals("CashCom"))
            {
                gridView = CreateCashCom(gridView);
            }
            else if (_reportType.Equals("RetailCom"))
            {
                gridView = CreateRetailCom(gridView);
            }
            else if (_reportType.Equals("BankCom"))
            {
                gridView = CreateBankCom(gridView);
            }
            else if (_reportType.Equals("StarProgramCom"))
            {
                gridView = CreateStarProgramCom(gridView);
            }
            else if (_reportType.Equals("BondhutterBondhon"))
            {
                gridView = CreateBondhutterBondhon(gridView);
            }

            gridView.DataSource = source;
            gridView.DataBind();
            //dyGv.Controls.Add(gridView);
        }

        

        private GridView CreateTargetAchievement(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("ditributorDelv", "ditributorDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("IHBDelv", "IHBDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalSale", "totalSale"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("achv", "achv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("areaId", "areaId"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("commissionRate", "commissionRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            return gridView;
        }
        private GridView CreateDistributorBoostup(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalDo", "totalDo"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalDelv", "totalDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("cashDo", "cashDo"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("adjustablAmount", "adjustablAmount"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        private GridView CreateCashCom(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sales", "sales"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("ach", "ach"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("commissionCategory", "commissionCategory"));
            return gridView;
        }
        private GridView CreateRetailCom(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sales", "sales"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("ach", "ach"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("commissionCategory", "commissionCategory"));
            return gridView;
        }
        private GridView CreateBankCom(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalDelv", "totalDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("editedCost", "editedCost"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("amountOnProcess", "amountOnProcess"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            return gridView;
        }
        private GridView CreateStarProgramCom(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("programName", "programName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalDelv", "totalDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            return gridView;
        }
        private GridView CreateBondhutterBondhon(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("programName", "programName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            return gridView;
        }
        protected void ddlReportType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNecessaryUi();
        }
        private void LoadNecessaryUi()
        {
            _reportType = ddlReportType.SelectedItem.Value;
            switch (_reportType)
            {
                case "TargetAchievement":
                    areaDdlTr.Visible = false;
                    break;
                case "DistributorBoostup":
                    areaDdlTr.Visible = false;
                    break;
                case "CashCom":
                    areaDdlTr.Visible = false;
                    break;
                case "RetailCom":
                    areaDdlTr.Visible = false;
                    break;
                case "BankCom":
                    areaDdlTr.Visible = false;
                    break;
                case "StarProgramCom":
                    areaDdlTr.Visible = true;
                    break;
                case "BondhutterBondhon":
                    areaDdlTr.Visible = true;
                    break;
                default:
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select report type properly');", true);
                    break;
            }
        }

        private void LoadAreaDdl()
        {
            ddlArea.DataSource = _bll.GetArea();
            ddlArea.DataTextField = "strText";
            ddlArea.DataValueField = "intID";
            ddlArea.DataBind();

        }
    }
}