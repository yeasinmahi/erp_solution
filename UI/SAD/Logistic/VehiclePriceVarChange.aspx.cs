using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LOGIS_BLL;
using LOGIS_DAL;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Item;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Logistic
{
    public partial class VehiclePriceVarChange : BasePage
    //public partial class SAD_Logistic_VehiclePriceVarChange : System.Web.UI.Page
    {
        private string nextParentID = "";
        Table tbl = new Table();
        TableRow tr = new TableRow();
        TableCell td = new TableCell();
        TableCell tdLbl = new TableCell();
        TableCell tdCon = new TableCell();
        VehicleManagerTDS.SprVehiclePriceManagerGetAllUpperLevelDataTable tblUpperLevel;
        string goeLevel = "";
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Logistic\\VehiclePriceVarChange";
        string stop = "stopping SAD\\Logistic\\VehiclePriceVarChange";

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            SetConfig();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                BuildTree();
            }
            else
            {
                //Session["sesUserID"] = "53";
                pnlUpperControl.DataBind();
                lblError.Text = "";
                //tbl.Style.Add("background-color", "#F0F0F0");
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        protected void btnPopSubmit_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Logistic\\VehiclePriceVarChange  Vehicle Price Change", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                VehicleVarLogisGainGroup vg = new VehicleVarLogisGainGroup();
            vg.AddGroupByUnit(ddlUnit.SelectedValue, txtPopText.Text.Trim());
            ddlGroup.DataBind();
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

        private void BuildTree()
        {
            if (IsPostBack)
            {
                VehicleManager im = new VehicleManager();
                tblUpperLevel = im.GetAllUpperLevel(hdnDDLChangedSelectedIndex.Value);
            }

            GetItemInfo("");
            pnlMain.Controls.Add(tbl);
        }

        private void GetItemInfo(string parentID)
        {

            var fd = log.GetFlogDetail(start, location, "show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Logistic\\VehiclePriceVarChange Item Info", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int level;
            td = new TableCell();
            tdLbl = new TableCell();
            tdCon = new TableCell();

            VehicleManager item = new VehicleManager();
            VehicleManagerTDS.TblVehiclePriceManagerDataTable dataTable;

            dataTable = item.GetDataByParent(parentID, ddlUnit.SelectedValue);
            if (dataTable.Rows.Count > 0)
            {
                DropDownList ddl = new DropDownList();

                level = dataTable[0].intLevel;
                ddl.ID = "ddl" + level + "_" + 1;
                ddl.Items.Add(new ListItem(dataTable[0].strText, dataTable[0].intID.ToString()));

                string id = "";

                if (tblUpperLevel != null && tblUpperLevel.Rows.Count > 0)
                {
                    DataRow[] row = tblUpperLevel.Select("intLevel=" + level);
                    if (row.Length > 0) id = row[0][0].ToString();
                }

                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dataTable[i].strText, dataTable[i].intID.ToString()));
                    if (dataTable[i].intID.ToString() == id)
                    {
                        ddl.SelectedIndex = i;
                    }
                }

                Label lbl = new Label();
                lbl.Text = item.GetLabel(level.ToString(), ddlUnit.SelectedValue, parentID) + " ";
                tdLbl.Controls.Add(lbl);
                td.Controls.Add(ddl);

                //tdCon.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + 1 + ");"));

                ddl.AutoPostBack = true;
                ddl.Attributes.Add("onChange", "DDLChange('" + ddl.ID + "');");

                nextParentID = ddl.SelectedValue;

                //just only have not any child
                if (item.GetChildCount(ddl.SelectedValue) <= 0)
                {
                    hdnGeoId.Value = ddl.SelectedValue;
                    goeLevel = ddl.SelectedItem.Text;
                    //tdCon.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + 1 + ");"));
                }


                //tdCon.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + /*subLevel*/1 + ");"));
                tr.Cells.Add(tdLbl);
                tr.Cells.Add(td);
                tdCon.Style.Add("padding-left", "10px");
                tdCon.Style.Add("padding-right", "20px");
                tr.Controls.Add(tdCon);

                tbl.Rows.Add(tr);
                tr = new TableRow();

                GetItemInfo(ddl.SelectedValue);
            }
                /*else
                {
                    if (nextParentID == "")
                    {
                        td.Controls.Add(BuildAnchor("Add", "ShowDiv(1,1);"));
                        tr.Cells.Add(td);
                        tbl.Rows.Add(tr);
                        hdnGeoId.Value = "";
                    }
                }*/
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private HtmlAnchor BuildAnchor(string text, string attrMethod)
        {
            HtmlAnchor htA = new HtmlAnchor();
            htA.InnerText = text;
            htA.HRef = "#";
            htA.Attributes.Add("onclick", attrMethod);
            return htA;
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            BuildTree();
            SetConfig();
            chkType.DataBind();
            ddlGroup.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            chkType.DataBind();
            ddlGroup.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string vhIdList = "", vhTypeList = "";

            foreach (ListItem cb in CheckBoxList1.Items)
            {
                vhIdList += cb.Selected ? (cb.Value + ",") : ("");
            }

            if (vhIdList.Length > 0)
            {
                vhIdList = vhIdList.Substring(0, vhIdList.Length - 1);
            }

            foreach (ListItem cb in chkType.Items)
            {
                vhTypeList += cb.Selected ? (cb.Value + ",") : ("");
            }

            if (vhTypeList.Length > 0)
            {
                vhTypeList = vhTypeList.Substring(0, vhTypeList.Length - 1);
            }


            if (vhIdList.Length <= 0 && rdoSelect.SelectedIndex == 2)
            {
                lblError.Text = "Select Vehicle";
            }
            else if (vhTypeList.Length <= 0 && rdoSelect.SelectedIndex == 1)
            {
                lblError.Text = "Select Vehicle";
            }
            else if (CommonClass.GetDateAtSQLDateFormat(txtFrom.Text) < DateTime.Now.Date)
            {
                lblError.Text = "Please select from date greter or equal today";
            }
            else if (CommonClass.GetDateAtSQLDateFormat(txtFrom.Text) > CommonClass.GetDateAtSQLDateFormat(txtTo.Text))
            {
                lblError.Text = "Please select to date greter or equal from date";
            }
            else if (txtPrice.Text.Trim() == "")
            {
                lblError.Text = "Please enter price";
            }
            else
            {
                lblError.Text = "";

                DateTime? ed = null;
                if (txtTo.Text != "")
                {
                    ed = CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
                }

                string product = "";

                if (txtProduct.Text.Trim() != "")
                {
                    char[] ch = { '[', ']' };
                    string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    product = temp[temp.Length - 1];
                }


                int? error = null;



                if (rdoType.SelectedIndex == 0)
                {
                    VehicleVarPrice vp = new VehicleVarPrice();
                    vp.SetPrice(Session[SessionParams.USER_ID].ToString(), ddlShip.SelectedValue, ddlUnit.SelectedValue, vhIdList, hdnGeoId.Value, vhTypeList, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), decimal.Parse(txtPartyPrice.Text), ddlUOM.SelectedValue, ddlCurrency.SelectedValue, product, ref error);
                }
                else if (rdoType.SelectedIndex == 1)
                {
                    VehicleLogisticgain vl = new VehicleLogisticgain();
                    vl.SetGainValue(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, vhIdList, hdnGeoId.Value, vhTypeList, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), decimal.Parse(txtPartyPrice.Text), ddlUOM.SelectedValue, ddlCurrency.SelectedValue, product, ref error);
                }
                else if (rdoType.SelectedIndex == 2)
                {
                    if (ddlGroup.Items.Count > 0)
                    {
                        VehicleLogisticgain vl = new VehicleLogisticgain();
                        vl.SetGainGroupValue(Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ddlGroup.SelectedValue, vhTypeList, hdnGeoId.Value, vhIdList, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), decimal.Parse(txtPartyPrice.Text), ddlUOM.SelectedValue, ddlCurrency.SelectedValue, product, ref error);
                    }
                }

                if (error == 1)
                {
                    lblError.Text = "Price cann't be set";
                }

                else
                {
                    lblError.Text = goeLevel + " Price set Successfull..............";
                }
            }
        }


        protected void rdoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoSelect.SelectedIndex == 0)
            {
                pnlVhl.Visible = false;
                pnlType.Visible = false;
            }
            else if (rdoSelect.SelectedIndex == 1)
            {
                pnlVhl.Visible = false;
                pnlType.Visible = true;
            }
            else
            {
                pnlVhl.Visible = true;
                pnlType.Visible = false;
            }

            CheckBoxList1.DataBind();
        }

        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoType.SelectedIndex == 0)
            {
                pnlGroup.Visible = false;
            }
            else if (rdoType.SelectedIndex == 1)
            {
                pnlGroup.Visible = false;
            }
            else if (rdoType.SelectedIndex == 2)
            {
                pnlGroup.Visible = true;
            }
        }

        private void SetConfig()
        {
            SalesConfig lc = new SalesConfig();
            SalesConfigTDS.TblSalesConfigDataTable tbl = lc.GetConfigByUnit(ddlUnit.SelectedValue);

            if (tbl.Rows.Count > 0)
            {
                if (tbl[0].ysnLogisBasedOnUOM)
                {
                    ddlUOM.Visible = true;
                    lblUom.Visible = true;
                }
                else
                {
                    ddlUOM.Visible = false;
                    lblUom.Visible = false;
                }
            }
        }


    }
}