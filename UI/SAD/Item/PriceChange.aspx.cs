using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SAD_BLL.Item;
using SAD_DAL.Item;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Item
{
    public partial class PriceChange : BasePage
    {
        private string nextParentID = "";
        Table tbl = new Table();
        TableRow tr = new TableRow();
        TableCell td = new TableCell();
        TableCell tdLbl = new TableCell();
        TableCell tdCon = new TableCell();
        ItemManagerTDS.SprItemManagerGetAllUpperLevelDataTable tblUpperLevel;

        private string nextParentIDP = "";
        Table tblP = new Table();
        TableRow trP = new TableRow();
        TableCell tdP = new TableCell();
        TableCell tdLblP = new TableCell();
        TableCell tdConP = new TableCell();
        ItemPriceManagerTDS.SprItemPriceManagerGetAllUpperLevelDataTable tblUpperLevelP;
        string loction = "";
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Item\\PriceChange";
        string stop = "stopping SAD\\Item\\PriceChange";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BuildTree();
            }
            else
            {
                //Session["sesUserID"] = "1";
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        private void BuildTree()
        {
            if (IsPostBack)
            {
                SAD_BLL.Item.ItemManager item = new SAD_BLL.Item.ItemManager();
                tblUpperLevel = item.GetAllUpperLevel(hdnDDLChangedSelectedIndex.Value);

                ItemPriceManager itemP = new ItemPriceManager();
                tblUpperLevelP = itemP.GetAllUpperLevel(hdnDDLChangedSelectedIndexP.Value);
            }

            GetItemInfo("", 1);
            GetItemInfo("");

            pnlMain.Controls.Add(tbl);
            pnlPrice.Controls.Add(tblP);
        }

        private void GetItemInfo(string parentID, int subLevel)
        {

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\PriceChange  Item Price Change", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int level;
            td = new TableCell();
            tdLbl = new TableCell();
            tdCon = new TableCell();

            SAD_BLL.Item.ItemManager item = new SAD_BLL.Item.ItemManager();
            ItemManagerTDS.TblItemManagerDataTable dataTable;

            dataTable = item.GetDataByParent(parentID, subLevel.ToString(), ddlType.SelectedValue, ddlUnit.SelectedValue);
            if (dataTable.Rows.Count > 0)
            {
                DropDownList ddl = new DropDownList();

                level = dataTable[0].intLevel;
                ddl.ID = "ddl" + level + "_" + subLevel;
                ddl.Items.Add(new ListItem(dataTable[0].strText, dataTable[0].intID.ToString()));

                string id = "";

                if (tblUpperLevel != null && tblUpperLevel.Rows.Count > 0 && subLevel == 1)
                {
                    DataRow[] row = tblUpperLevel.Select("intLevel=" + level);
                    if (row.Length > 0) id = row[0][0].ToString();
                }

                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dataTable[i].strText, dataTable[i].intID.ToString()));
                    if (subLevel == 1 && dataTable[i].intID.ToString() == id)
                    {
                        ddl.SelectedIndex = i;
                    }
                }

                if (level != 1)
                {
                    ddl.Items.Add(new ListItem("All", "0"));
                }

                Label lbl = new Label();
                lbl.Text = item.GetLabel(subLevel.ToString(), level.ToString(), ddlUnit.SelectedValue, parentID) + " ";
                tdLbl.Controls.Add(lbl);
                td.Controls.Add(ddl);

                //tdCon.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + subLevel + ");"));


                if (subLevel == 1)
                {
                    //just only for first level
                    if (level == 1)
                    {
                        ddl.AutoPostBack = true;
                        ddl.Attributes.Add("onChange", "DDLChange('" + ddl.ID + "');");
                    }

                    nextParentID = ddl.SelectedValue;
                    int maxLevel = item.GetMaxSubLevelByParent(nextParentID);

                    //just only for first level
                    /*if (level == 1)
                    {
                        tdCon.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + (maxLevel + 1) + ");"));
                    }*/
                }

                //tdCon.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + subLevel + ");"));
                tr.Cells.Add(tdLbl);
                tr.Cells.Add(td);
                tdCon.Style.Add("padding-left", "10px");
                tdCon.Style.Add("padding-right", "20px");
                tr.Controls.Add(tdCon);
                GetItemInfo(parentID, (subLevel + 1));
            }
            else
            {
                if (subLevel != 1)
                {
                    tbl.Rows.Add(tr);
                    tr = new TableRow();
                    GetItemInfo(nextParentID, 1);
                }

                /*if (nextParentID == "")
                {
                    td.Controls.Add(BuildAnchor(" Add", "ShowDiv(1,1);"));
                    tr.Cells.Add(td);
                    tbl.Rows.Add(tr);
                }*/
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void GetItemInfo(string parentID)
        {
            int level;
            tdP = new TableCell();
            tdLblP = new TableCell();
            tdConP = new TableCell();

            ItemPriceManager item = new ItemPriceManager();
            ItemPriceManagerTDS.TblItemPriceManagerDataTable dataTable;

            dataTable = item.GetDataByParent(parentID, ddlUnit.SelectedValue);
            if (dataTable.Rows.Count > 0)
            {
                DropDownList ddl = new DropDownList();

                level = dataTable[0].intLevel;
                ddl.ID = "ddlP" + level + "_" + 1;
                ddl.Items.Add(new ListItem(dataTable[0].strText, dataTable[0].intID.ToString()));

                string id = "";

                if (tblUpperLevelP != null && tblUpperLevelP.Rows.Count > 0)
                {
                    DataRow[] row = tblUpperLevelP.Select("intLevel=" + level);
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
                tdLblP.Controls.Add(lbl);
                tdP.Controls.Add(ddl);

                //tdConP.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + 1 + ");"));

                ddl.AutoPostBack = true;
                ddl.Attributes.Add("onChange", "DDLChangeP('" + ddl.ID + "');");

                nextParentIDP = ddl.SelectedValue;

                //just only have not any child
                if (item.GetChildCount(ddl.SelectedValue) <= 0)
                {
                    hdnPriceId.Value = ddl.SelectedValue;
                    loction = ddl.SelectedItem.Text;
                    //tdConP.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + 1 + ");"));
                }


                //tdConP.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + /*subLevel*/1 + ");"));
                trP.Cells.Add(tdLblP);
                trP.Cells.Add(tdP);
                tdConP.Style.Add("padding-left", "10px");
                tdConP.Style.Add("padding-right", "20px");
                trP.Controls.Add(tdConP);

                tblP.Rows.Add(trP);
                trP = new TableRow();

                GetItemInfo(ddl.SelectedValue);
            }
            else
            {
                if (nextParentIDP == "")
                {
                    //tdP.Controls.Add(BuildAnchor("Add", "ShowDiv(1,1);"));
                    trP.Cells.Add(tdP);
                    tblP.Rows.Add(trP);
                    hdnPriceId.Value = "";
                }
            }
        }
        private HtmlAnchor BuildAnchor(string text, string attrMethod)
        {
            HtmlAnchor htA = new HtmlAnchor();
            htA.InnerText = text;
            htA.HRef = "#";
            htA.Attributes.Add("onclick", attrMethod);
            return htA;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            SetMain();
            GridView1.DataBind();

        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            if (ddlType.Items.Count <= 0) { ddlType.DataBind(); }
            BuildTree();
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            //if (chkDiscount.Checked == false)
            //{
                SetMain();
                /*if (CommonClass.GetDateAtSQLDateFormat(txtFrom.Text) < DateTime.Now.Date)
                {
                    lblError.Text = "Please select from date greter or equal today";
                }
                else */
                if (CommonClass.GetDateAtSQLDateFormat(txtFrom.Text) > CommonClass.GetDateAtSQLDateFormat(txtTo.Text))
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

                    ItemPrice ip = new ItemPrice();
                    DateTime? ed = null;
                    if (txtTo.Text != "")
                    {
                        ed = CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
                    }

                    int? error = null;
                    if (rdoPrType.SelectedIndex == 0)
                    {
                        ip.SetPrice(Session["sesUserID"].ToString(), ddlUnit.SelectedValue, hdnL1.Value, hdnId.Value, hdnSub.Value, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, RadioButtonList1.SelectedValue, ref error);
                        if (error.Value == 0)
                        {
                            lblError.Text = loction + " Price set Successfully........";
                        }
                        else
                        {
                            lblError.Text = "Price Cannot Be set........";
                        }
                    }
                    else
                    {
                        string prType = "";
                        string cus = "", pro = "";

                        char[] ch = { '[', ']' };
                        string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                        try
                        {
                            if (!chkall.Checked)
                            {
                                cus = temp[temp.Length - 1];
                            }
                            else
                            { cus = "0"; }
                        }
                        catch { }

                        if (chkCus.Checked) prType = hdnPriceId.Value;
                        ip.SetPriceCustomer(Session[SessionParams.USER_ID].ToString(), cus, ddlSo.SelectedValue.ToString(), ddlCusType.SelectedValue.ToString(), ddlUnit.SelectedValue, hdnL1.Value, hdnId.Value, hdnSub.Value, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), prType, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, RadioButtonList1.SelectedValue, ref error);
                        if (error.Value == 0 && cus != "0")
                        {
                            lblError.Text = temp[0] + " Price set Successfully........";
                        }
                        else if (error.Value == 0 && cus == "0")
                        {
                            lblError.Text = " Price set Successfully........";
                        }
                        else
                        {
                            lblError.Text = "Price Cannot Be set........";
                        }

                    }
                    if (error == 1)
                    {
                        lblError.Text = "Date range is not perfect";
                    }

                    GridView1.DataBind();
                }
            //}
            //else
            //{
            //    SetMain();
            //    /*if (CommonClass.GetDateAtSQLDateFormat(txtFrom.Text) < DateTime.Now.Date)
            //    {
            //        lblError.Text = "Please select from date greter or equal today";
            //    }
            //    else */
            //    if (CommonClass.GetDateAtSQLDateFormat(txtFrom.Text) > CommonClass.GetDateAtSQLDateFormat(txtTo.Text))
            //    {
            //        lblError.Text = "Please select to date greter or equal from date";
            //    }
            //    else if (txtPrice.Text.Trim() == "")
            //    {
            //        lblError.Text = "Please enter price";
            //    }
            //    else
            //    {
            //        lblError.Text = "";

            //        ItemPrice ip = new ItemPrice();
            //        DateTime? ed = null;
            //        if (txtTo.Text != "")
            //        {
            //            ed = CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            //        }

            //        int? error = null;
            //        if (rdoPrType.SelectedIndex == 0)
            //        {
            //            ip.SetPriceDiscount(Session["sesUserID"].ToString(), ddlUnit.SelectedValue, hdnL1.Value, hdnId.Value, hdnSub.Value, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, RadioButtonList1.SelectedValue, ref error);
            //            if (error.Value == 0)
            //            {
            //                lblError.Text = loction + " Price set Successfully........";
            //            }
            //            else
            //            {
            //                lblError.Text = "Price Cannot Be set........";
            //            }
            //        }
            //        else
            //        {
            //            string prType = "";
            //            string cus = "", pro = "";

            //            char[] ch = { '[', ']' };
            //            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            //            try
            //            {
            //                if (!chkall.Checked)
            //                {
            //                    cus = temp[temp.Length - 1];
            //                }
            //                else
            //                { cus = "0"; }
            //            }
            //            catch { }

            //            if (chkCus.Checked) prType = hdnPriceId.Value;
            //            ip.SetPriceCustomerDiscount(Session[SessionParams.USER_ID].ToString(), cus, ddlSo.SelectedValue.ToString(), ddlCusType.SelectedValue.ToString(), ddlUnit.SelectedValue, hdnL1.Value, hdnId.Value, hdnSub.Value, CommonClass.GetDateAtSQLDateFormat(txtFrom.Text), ed, decimal.Parse(txtPrice.Text), prType, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, RadioButtonList1.SelectedValue, ref error);
            //            if (error.Value == 0 && cus != "0")
            //            {
            //                lblError.Text = temp[0] + " Price set Successfully........";
            //            }
            //            else if (error.Value == 0 && cus == "0")
            //            {
            //                lblError.Text = " Price set Successfully........";
            //            }
            //            else
            //            {
            //                lblError.Text = "Price Cannot Be set........";
            //            }

            //        }
            //        if (error == 1)
            //        {
            //            lblError.Text = "Date range is not perfect";
            //        }

            //        GridView1.DataBind();
            //    }
            //}
        }

        private void SetMain()
        {
            StringBuilder allID = new StringBuilder();
            StringBuilder level = new StringBuilder();
            for (int i = 0; i < tbl.Controls.Count; i++)
            {
                int count = 1;
                for (int j = 0; j < tbl.Controls[i].Controls.Count; j++)
                {
                    for (int k = 0; k < tbl.Controls[i].Controls[j].Controls.Count; k++)
                    {
                        if (tbl.Controls[i].Controls[j].Controls[k].ID != null)
                        {
                            allID.Append(((DropDownList)tbl.Controls[i].Controls[j].Controls[k]).SelectedValue + ",");
                            level.Append((count).ToString() + ",");
                            count++;
                        }
                    }
                }
            }
            string levelOneId;
            string id = allID.ToString();
            levelOneId = id.Substring(0, id.IndexOf(','));
            id = id.Substring(id.IndexOf(',') + 1);

            string subLevel = level.ToString();
            subLevel = subLevel.Substring(subLevel.IndexOf(',') + 1);

            hdnId.Value = id.ToString();
            hdnL1.Value = levelOneId.ToString();
            hdnSub.Value = subLevel.ToString();
        }
        protected void rdoPrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoPrType.SelectedIndex == 0)
            {
                pnlPrice.Visible = true;
                pnlCus.Visible = false;
                chkCus.Visible = false;
            }
            else
            {
                pnlPrice.Visible = false;
                pnlCus.Visible = true;
                chkCus.Visible = true;
            }

            chkCus.Checked = false;
        }
        protected void chkCus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCus.Checked)
            {
                pnlPrice.Visible = true;
            }
            else
            {
                pnlPrice.Visible = false;
            }
        }
        protected void RadioButtonList1_DataBound(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items.Count > 0) RadioButtonList1.SelectedIndex = 0;
        }


        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
    }
}