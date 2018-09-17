using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Consumer;
using SAD_BLL.Customer.Report;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class SubsidiaryJv : Page
    {
        readonly StarConsumerEntryBll _bll = new StarConsumerEntryBll();
        readonly StatementC _statement = new StatementC();
        private string _filePathForXml;
        private string _jvType;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Consumer\\SubsidiaryJv";
        string stop = "stopping SAD\\Consumer\\SubsidiaryJv";
        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/Consumer/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "subsidairyJv.xml");
            LoadNecessaryUi();
            XmlParser.DeleteFile(_filePathForXml);
            if (!IsPostBack)
            {
            }
        }

        protected void createSubsidiary_OnClick(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\SubsidiaryJv Subsidiary entry", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string strVcode = "voucherJV";
            string strPrefix = "JV";
            string reportType = ddlJvType.SelectedItem.Text;
            string glblnarration = "ACCL "+ reportType + " Commission from :" + fromTextBox.Text + "to " + toTextBox.Text;
            decimal totalCommision = 0;
            //totalcom = Convert.ToDecimal(lbltotalcomamount.Text);

            int enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            const int intmainheadcoaid = 33855;
            const int unitId = 4;

            foreach (GridViewRow gvr in grdv.Rows)
            {
                if (((CheckBox)gvr.FindControl("checkBox")).Checked)
                {
                    string customerCoaId;
                    string eachcCustNarration;
                    string eachCustAmount;
                    string customerName;
                    if (_jvType.Equals("Subsidairy"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[19].Text;
                        eachCustAmount = gvr.Cells[18].Text;
                        customerName = gvr.Cells[2].Text;
                        
                    }
                    else if (_jvType.Equals("TradingHouse"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[12].Text;
                        eachCustAmount = gvr.Cells[11].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else if (_jvType.Equals("YearlyAch"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[13].Text;
                        eachCustAmount = gvr.Cells[12].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else if (_jvType.Equals("ExclusiveRetailer"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[12].Text;
                        eachCustAmount = gvr.Cells[11].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else if (_jvType.Equals("ExclusiveDistributor"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[12].Text;
                        eachCustAmount = gvr.Cells[11].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else if (_jvType.Equals("DistributorCovarage"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[12].Text;
                        eachCustAmount = gvr.Cells[11].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else if (_jvType.Equals("ManpowerManager"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[18].Text;
                        eachCustAmount = gvr.Cells[17].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else if (_jvType.Equals("ManpowerDistributor"))
                    {
                        customerCoaId = gvr.Cells[6].Text;
                        eachcCustNarration = gvr.Cells[18].Text;
                        eachCustAmount = gvr.Cells[17].Text;
                        customerName = gvr.Cells[2].Text;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('Select JV Type Properly');", true);
                        break;
                    }
                    dynamic obj = new
                    {
                        customercoaid = customerCoaId,
                        eachcustnarration = eachcCustNarration,
                        eachcustamount = eachCustAmount,
                        customername = customerName

                    };
                    string message;
                    if (!XmlParser.CreateXml("RemoteCommission", "req", obj, _filePathForXml, out message))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('XmlFile-- " + message + "');", true);
                        break;
                    }
                    totalCommision  +=  Convert.ToDecimal(eachCustAmount);
                }
            }
            
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePathForXml);
            DataTable dt = _statement.insertdataforsalescommissionjv(doc.OuterXml, unitId, strVcode, strPrefix, glblnarration, totalCommision, enroll, intmainheadcoaid);
            jvNumverLbl.Text = dt.Rows[0][2].ToString();
            XmlParser.DeleteFile(_filePathForXml);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            DataTable source = new DataTable();
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Consumer\\DoReport Office Load", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string fromDate = fromTextBox.Text;
                string toDate = toTextBox.Text;
                DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
                fromDateTime = fromDateTime.AddHours(6);
                DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
                toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-3);
                if (_jvType.Equals("Subsidairy"))
                {
                    int salseOffice = Convert.ToInt32(ddlSalesOffice.SelectedItem.Value);
                    int type = Convert.ToInt32(ddlType.SelectedItem.Value);


                    if (type == 1)
                    {
                        decimal factoryRate = Convert.ToDecimal(factoryRateTextBox.Text);
                        decimal ghatRate = Convert.ToDecimal(ghatRateTextBox.Text);
                        source = _bll.GetFactorySubsidiary(fromDateTime, toDateTime, salseOffice, factoryRate, ghatRate);
                    }
                    else if (type == 2)
                    {
                        source = _bll.GetTransportSubsidiary(fromDateTime, toDateTime, salseOffice);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Type Properly');", true);
                    }
                }
                else if (_jvType.Equals("TradingHouse"))
                {
                    decimal familyRate = Convert.ToDecimal(factoryRateTextBox.Text);
                    decimal tradingRate = Convert.ToDecimal(ghatRateTextBox.Text);
                    source = _bll.GetTrading(fromDateTime, toDateTime, familyRate, tradingRate);
                }
                else if (_jvType.Equals("YearlyAch"))
                {
                    decimal familyRate = Convert.ToDecimal(factoryRateTextBox.Text);
                    source = _bll.GetDistributorYearlyAch(fromDateTime, toDateTime, familyRate, "Top Sheet");
                }
                else if (_jvType.Equals("ExclusiveRetailer"))
                {
                    decimal familyRate = Convert.ToDecimal(factoryRateTextBox.Text);
                    source = _bll.GetExlusiveRetailer(fromDateTime, toDateTime, familyRate, "Topsheet");
                }
                else if (_jvType.Equals("ExclusiveDistributor"))
                {
                    decimal familyRate = Convert.ToDecimal(factoryRateTextBox.Text);
                    source = _bll.GetExclusiveDistributor(fromDateTime, toDateTime, familyRate);
                }
                else if (_jvType.Equals("DistributorCovarage"))
                {
                    int familyRate = Convert.ToInt32(factoryRateTextBox.Text);
                    double ghatrate = Convert.ToDouble(ghatRateTextBox.Text);
                    source = _bll.GetDitributorCoverage(fromDateTime, toDateTime, familyRate, ghatrate, "Topsheet");
                }
                else if (_jvType.Equals("ManpowerManager"))
                {
                    source = _bll.GetManpowerManager(fromDateTime, toDateTime);
                }
                else if (_jvType.Equals("ManpowerDistributor"))
                {
                    source = _bll.GetDistributorManpowerCommission(fromDateTime, toDateTime, 2);
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

        //private void LoadGridView(DataTable source)
        //{
        //    totalAmount.Value = source.AsEnumerable()
        //        .Sum(x => x.Field<decimal>("grandSubsidiary"))
        //        .ToString(CultureInfo.CurrentCulture);
        //    grdv.DataSource = source;
        //    grdv.DataBind();
        //}

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

            if (_jvType.Equals("Subsidairy"))
            {
                gridView = CreateSubsidiaryGridColumn(gridView);
            }
            else if (_jvType.Equals("TradingHouse"))
            {
                gridView = CreateTradingGridColumn(gridView);
            }
            else if (_jvType.Equals("YearlyAch"))
            {
                gridView = CreateYearlyAcv(gridView);
            }
            else if (_jvType.Equals("ExclusiveRetailer"))
            {
                gridView = CreateExclusiveRetailer(gridView);
            }
            else if (_jvType.Equals("ExclusiveDistributor"))
            {
                gridView = CreateExclusiveDistributor(gridView);
            }
            else if (_jvType.Equals("DistributorCovarage"))
            {
                gridView = CreateDistributorCovarage(gridView);
            }
            else if (_jvType.Equals("ManpowerManager"))
            {
                gridView = CreateManpowerManager(gridView);
            }
            else if (_jvType.Equals("ManpowerDistributor"))
            {
                gridView = CreateManpowerDistributor(gridView);
            }

            totalAmount.Value = source.AsEnumerable()
                .Sum(x => x.Field<decimal>("grand"))
                .ToString(CultureInfo.CurrentCulture);
            gridView.DataSource = source;
            gridView.DataBind();
            //dyGv.Controls.Add(gridView);
        }

        private GridView CreateSubsidiaryGridColumn(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("qntCustVhFactory", "qntCustVhFactory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("factoryRate", "factoryRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("factorySubsidiary", "factorySubsidiary"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("qntCustVhGhat", "qntCustVhGhat"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("ghatRate", "ghatRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("ghatSubsidiary", "ghatSubsidiary"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalCusVh", "totalCusVh"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("qntCompanyCustomerVh", "qntCompanyCustomerVh"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("qntCompanyVh", "qntCompanyVh"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("qntRentedVh", "qntRentedVh"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalVh", "totalVh"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        
        private GridView CreateTradingGridColumn(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("entrpriceDelv", "entrpriceDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("familyComRate", "familyComRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tradeComRate", "tradeComRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("TotalDelv", "TotalDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }

        private GridView CreateYearlyAcv(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("enterpriseDelv", "enterpriseDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("ihbDelv", "ihbDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalDelv", "totalDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("commisionRate", "commisionRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        private GridView CreateExclusiveRetailer(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("shopId", "shopId"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("shopName", "shopName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("numPieces", "numPieces"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("commisionRate", "commisionRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        private GridView CreateExclusiveDistributor(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sales", "sales"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("achivement", "ach"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("commisionRate", "commisionRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        private GridView CreateDistributorCovarage(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalDelv", "totalDelv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalShop", "totalShop"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("soldShop", "soldShop"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coverageRate", "coverageRate"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        private GridView CreateManpowerManager(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("salesOffice", "salesOffice"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalSales", "totalSales"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("acv", "acv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("manager", "manager"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr1", "sr1"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr2", "sr2"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("managerCom", "managerCom"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr1Com", "sr1Com"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr2Com", "sr2Com"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        private GridView CreateManpowerDistributor(GridView gridView)
        {
            gridView.Columns.Add(GridViewUtil.CreateBoundField("customerName", "customerName"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("tarritory", "tarritory"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("area", "area"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("region", "region"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("coa", "coa"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("salesOffice", "salesOffice"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("totalSales", "totalSales"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("targets", "targets"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("acv", "acv"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("manager", "manager"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr1", "sr1"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr2", "sr2"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("managerCom", "managerCom"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr1Com", "sr1Com"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("sr2Com", "sr2Com"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("grand", "grand"));
            gridView.Columns.Add(GridViewUtil.CreateBoundField("narrations", "narrations"));
            return gridView;
        }
        
        protected void ddlJvType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNecessaryUi();
        }

        private void LoadNecessaryUi()
        {
            
            _jvType = ddlJvType.SelectedItem.Value;
            switch (_jvType)
            {
                case "Subsidairy":
                    subsidaryDropDown.Visible = true;
                    factoryRateLbl.Text = @"Factory Rate";
                    ghatRateLbl.Text = @"Ghat Rate";
                    ghatRateLbl.Visible = true;
                    ghatRateTextBox.Visible = true;
                    inputTextBox.Visible = true;
                    break;
                case "TradingHouse":
                    subsidaryDropDown.Visible = false;
                    factoryRateLbl.Text = @"Family Rate";
                    ghatRateLbl.Text = @"Trade Rate";
                    ghatRateLbl.Visible = true;
                    ghatRateTextBox.Visible = true;
                    inputTextBox.Visible = true;
                    break;
                case "YearlyAch":
                    subsidaryDropDown.Visible = false;
                    factoryRateLbl.Text = @"Commistion Rate";
                    ghatRateLbl.Visible = false;
                    ghatRateTextBox.Visible = false;
                    inputTextBox.Visible = true;
                    break;
                case "ExclusiveRetailer":
                    subsidaryDropDown.Visible = false;
                    factoryRateLbl.Text = @"Commistion Rate";
                    ghatRateLbl.Visible = false;
                    ghatRateTextBox.Visible = false;
                    inputTextBox.Visible = true;
                    break;
                case "ExclusiveDistributor":
                    subsidaryDropDown.Visible = false;
                    factoryRateLbl.Text = @"Commistion Rate";
                    ghatRateLbl.Visible = false;
                    ghatRateTextBox.Visible = false;
                    inputTextBox.Visible = true;
                    break;
                case "DistributorCovarage":
                    subsidaryDropDown.Visible = false;
                    factoryRateLbl.Text = @"Minimum Coverage";
                    factoryRateLbl.Text = @"Commision Rate/Bag";
                    ghatRateLbl.Visible = true;
                    ghatRateTextBox.Visible = true;
                    inputTextBox.Visible = true;
                    break;
                case "ManpowerManager":
                    subsidaryDropDown.Visible = false;
                    ghatRateLbl.Visible = true;
                    ghatRateTextBox.Visible = true;
                    inputTextBox.Visible = false;
                    break;
                case "ManpowerDistributor":
                    subsidaryDropDown.Visible = false;
                    ghatRateLbl.Visible = true;
                    ghatRateTextBox.Visible = true;
                    inputTextBox.Visible = false;
                    break;

                default:
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select JV type properly');", true);
                    break;
            }
        }
    }
}