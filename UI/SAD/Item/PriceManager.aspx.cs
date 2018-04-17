﻿using System;
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
using SAD_DAL.Item;
using SAD_BLL.Item;
using BLL.Accounts.ChartOfAccount;
using UI.ClassFiles;


namespace UI.SAD.Item
{
    public partial class PriceManager : BasePage
    {
        private string nextParentID = "";
        Table tbl = new Table();
        TableRow tr = new TableRow();
        TableCell td = new TableCell();
        TableCell tdLbl = new TableCell();
        TableCell tdCon = new TableCell();
        ItemPriceManagerTDS.SprItemPriceManagerGetAllUpperLevelDataTable tblUpperLevel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                BuildTree();
            }
            else
            {
                //Session["sesUserID"] = "1";
                pnlUpperControl.DataBind();
                //tbl.Style.Add("background-color", "#F0F0F0");
            }
        }


        protected void btnPopSubmit_Click(object sender, EventArgs e)
        {
            ItemPriceManager im = new ItemPriceManager();

            if (hdnMode.Value == "new")
            {
                im.AddItem(hdnParent.Value, hdnLevel.Value, txtPopText.Text, ddlUnit.SelectedValue, txtPopLabel.Text, txtCode.Text);
            }
            else if (hdnMode.Value == "sub")
            {
                im.AddSubItem(hdnParent.Value, hdnLevel.Value, hdnSubLevel.Value, txtPopText.Text, txtPopLabel.Text, ddlUnit.SelectedValue, txtCode.Text);
            }
            else if (hdnMode.Value == "mod")
            {
                im.UpdateLabel(hdnParent.Value, hdnLevel.Value, txtPopLabel.Text, ddlUnit.SelectedValue);
            }

            tbl.Controls.Clear();
            GetItemInfo("");
            pnlMain.Controls.Add(tbl);

            ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);

        }

        private void BuildTree()
        {
            if (IsPostBack)
            {
                ItemPriceManager im = new ItemPriceManager();
                tblUpperLevel = im.GetAllUpperLevel(hdnDDLChangedSelectedIndex.Value);
            }

            GetItemInfo("");
            pnlMain.Controls.Add(tbl);
        }

        private void GetItemInfo(string parentID)
        {
            int level;
            td = new TableCell();
            tdLbl = new TableCell();
            tdCon = new TableCell();

            ItemPriceManager item = new ItemPriceManager();
            ItemPriceManagerTDS.TblItemPriceManagerDataTable dataTable;

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

                tdCon.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + 1 + ");"));

                ddl.AutoPostBack = true;
                ddl.Attributes.Add("onChange", "DDLChange('" + ddl.ID + "');");

                nextParentID = ddl.SelectedValue;

                //just only have not any child
                if (item.GetChildCount(ddl.SelectedValue) <= 0)
                {
                    hdnGeoId.Value = ddl.SelectedValue;
                    tdCon.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + 1 + ");"));
                }


                tdCon.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + /*subLevel*/1 + ");"));
                tr.Cells.Add(tdLbl);
                tr.Cells.Add(td);
                tdCon.Style.Add("padding-left", "10px");
                tdCon.Style.Add("padding-right", "20px");
                tr.Controls.Add(tdCon);

                tbl.Rows.Add(tr);
                tr = new TableRow();

                GetItemInfo(ddl.SelectedValue);
            }
            else
            {
                if (nextParentID == "")
                {
                    td.Controls.Add(BuildAnchor("Add", "ShowDiv(1,1);"));
                    tr.Cells.Add(td);
                    tbl.Rows.Add(tr);
                    hdnGeoId.Value = "";
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

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            BuildTree();

        }

    }
}