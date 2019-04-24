using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Budget_BLL.Budget;
using UI.ClassFiles;
using Utility;

namespace UI.BudgetPlan
{
    public partial class CostCenterCorrection : BasePage
    {
        private string _filePathForXml;
        private Budget_Entry_BLL _bll = new Budget_Entry_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enroll = 32897;
            _filePathForXml = Server.MapPath("~/BudgetPlan/Data/CostCenterCorrection_" + Enroll + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadUnit(Enroll);
                ddlUnit_OnSelectedIndexChanged(null, null);
            }


        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                if (row.FindControl("hdnSubledgerId") is HiddenField hdnSubledgerId)
                {
                    int intSubledgerId = int.Parse(hdnSubledgerId.Value);
                    int intCostCenterId = int.Parse(ddlCostCenter.SelectedValue);
                    string costcenter = ddlCostCenter.SelectedItem.ToString();
                    int intUnitId = int.Parse(ddlUnit.SelectedValue);
                    string msg = _bll.UpdateLedgerCostcenter(intUnitId, intSubledgerId, intCostCenterId, costcenter);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                LoadGrid();
            }
            catch
            {
                // ignored
            }
        }
        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            int intCostCenterId = int.Parse(ddlCostCenter.SelectedValue);
            string costcenter = ddlCostCenter.SelectedItem.ToString();
            int intUnitId = int.Parse(ddlUnit.SelectedValue);
            foreach (GridViewRow row in gridView.Rows)
            {
                bool checkedItem = ((CheckBox)row.FindControl("itemCheckbox")).Checked;
                if (checkedItem)
                {
                    int intSubledgerId = int.Parse(((HiddenField)row.FindControl("hdnSubledgerId")).Value);
                    if (!CreateXml(intSubledgerId, intCostCenterId, costcenter, intUnitId, out string message))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
                        break;
                    }
                }
            }

            XmlDocument document = new XmlDocument();
            document.Load(_filePathForXml);
            _bll.UpdateCostCenterSelected(document.InnerXml, out var msg);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+msg+"');", true);
            _filePathForXml.DeleteFile();
        }
        private bool CreateXml(int intSubledgerId, int intCostCenterId, string costcenter, int intUnitId, out string message)
        {
            dynamic obj = new
            {
                intSubledgerId,
                intCostCenterId,
                costcenter,
                intUnitId

            };
            return XmlParser.CreateXml("CostCenterCorrection", "items", obj, _filePathForXml, out message);

        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            LoadGrid();
        }


        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int unitId = Convert.ToInt32(ddlUnit.SelectedItem.Value);
                LoadCostCenter(Enroll, unitId);
                gridView.DataSource = "";
                gridView.DataBind();

            }
            catch
            {
                // ignored
            }
        }

        private void LoadGrid()
        {
            try
            {
                if (int.TryParse(ddlUnit.SelectedValue, out int unitId))
                {
                    if (int.TryParse(ddlCostCenter.SelectedValue, out _))
                    {
                        string fromDateText = txtFromDate.Text;
                        string toDateText = txtToDate.Text;
                        if (!string.IsNullOrWhiteSpace(fromDateText))
                        {
                            if (!string.IsNullOrWhiteSpace(toDateText))
                            {
                                var fromDate = DateTime.Parse(txtFromDate.Text);
                                var toDate = DateTime.Parse(txtToDate.Text);
                                BindGrid(unitId, fromDate, toDate);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('To date can not be blank');", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('From date can not be blank');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select cost center');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select unit first');", true);
                }
            }
            catch
            {
                // ignored
            }
        }

        private void BindGrid(int unitId, DateTime fromDate, DateTime toDate)
        {
            gridView.DataSource = _bll.GetCostCenterData(unitId, fromDate, toDate);
            gridView.DataBind();
        }
        private void LoadUnit(int enroll)
        {
            DataTable dt = _bll.GetUnitforCostCenter(enroll);
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        private void LoadCostCenter(int enroll, int unitId)
        {
            DataTable dt = _bll.GetCostCenter(unitId, enroll);
            ddlCostCenter.Loads(dt, "intCostCenterID", "strCCName");
        }


    }
}