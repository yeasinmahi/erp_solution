using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class TargetAcvReport : Page
    {
        private readonly StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        private string _reportType;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNecessaryUi();
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            DataTable source = new DataTable();
            try
            {
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
                fromDateTime = fromDateTime.AddHours(6);
                DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
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
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select All input Properly. " + exception.Message + "');", true);
            }

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

            gridView.DataSource = source;
            gridView.DataBind();
            //dyGv.Controls.Add(gridView);
        }
        private GridView CreateTargetAchievement(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("Customer Name", "customerName"));
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
            gridView.Columns.Add(GridViewUtil.CreateBoundField("Customer Name", "customerName"));
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
            gridView.Columns.Add(GridViewUtil.CreateBoundField("Customer Name", "customerName"));
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
            gridView.Columns.Add(GridViewUtil.CreateBoundField("Customer Name", "customerName"));
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
        protected void ddlReportType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNecessaryUi();
        }
        private void LoadNecessaryUi()
        {
            _reportType = ddlReportType.SelectedItem.Value;
            //switch (_reportType)
            //{
            //    case "TargetAchievement":
            //        break;
            //    default:
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select report type properly');", true);
            //        break;
            //}
        }
    }
}