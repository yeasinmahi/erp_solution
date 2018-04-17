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
using System.Text;
using BLL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
//public partial class Accounts_ChartOfAccount_Template : System.Web.UI.Page
namespace UI.Accounts.ChartOfAccount
{
    public partial class Template : BasePage
    {
        protected StringBuilder sb = new StringBuilder();
        string br = "</br>";
        string userID;

        BLL.Accounts.ChartOfAccount.Template tm = new BLL.Accounts.ChartOfAccount.Template();
        TemplateTDS.TblAccountsChartOfAccTemplateDataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                BuildTree();
            }
            userID = "" + Session[SessionParams.USER_ID];
            // userID = "1";// for Testing Purpose Only
        }

        private void BuildTree()
        {
            table = tm.GetTemplate();
            sb.Append("<input id=\"btnAdd0\" type=\"button\" value=\"N\"  onclick=\"ShowDiv(0,0)\" />");
            if (table.Rows.Count > 0)
            {
                GetTree(table[0].intParentID, br);
            }

            Panel1.DataBind();
        }

        private void GetTree(int parentID, string spacer)
        {
            DataRow[] rows = table.Select("intParentID = " + parentID);
            spacer += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

            if (rows.Length > 0)
            {
                GetChild(parentID, spacer, true);
                for (int i = 0; i < rows.Length; i++)
                {
                    GetTree(Convert.ToInt32(rows[i]["intAccTemplateID"]), spacer);
                }
            }
            else
            {
                GetChild(parentID, spacer, false);
            }
        }

        private void GetChild(int templateID, string spacer, bool bold)
        {
            string moduleID;
            bool ysnButtonEnable;
            DataRow[] rows = table.Select("intAccTemplateID = " + templateID);
            if (rows.Length > 0)
            {
                bool act = (bool)rows[0]["ysnEnable"];
                sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr>");
                sb.Append("<td style=\"color:" + (act ? "#000000" : "#FF0000") + "\">" + (bold ? "<b>" : "") + spacer + rows[0]["strAccName"] + (bold ? "</b>" : "") + "</td>");


                ysnButtonEnable = (bool)rows[0]["ysnCommandButton"];
                if (ysnButtonEnable)
                {
                    sb.Append("<td><a href=\"#\" onclick=\"ToggleDivInner('div" + templateID + "')\">:.</a></td>");
                    sb.Append("<td><div id=\"div" + templateID + "\" style=\"display: none;\">");
                    moduleID = rows[0]["intModulesAutoID"].ToString();

                    if (moduleID == "")
                    {
                        sb.Append("<input id=\"btnAdd" + templateID + "\" type=\"button\" value=\"N\"  onclick=\"ShowDiv('" + templateID + "','0')\" />");
                    }
                    sb.Append("<input id=\"btnAI" + templateID + "\" type=\"button\" value=\"" + (act ? "X" : "A") + "\" onclick=\"ShowDivAct('" + templateID + "','" + act + "'," + rows[0]["ysnHasChild"].ToString().ToLower() + ")\" />");
                    sb.Append("<input id=\"btnEdit" + templateID + "\" type=\"button\" value=\"E\"  onclick=\"ShowDiv('" + templateID + "','1')\" />");
                    // sb.Append("<input id=\"btnEdit" + templateID + "\" type=\"button\" value=\"NPC\"  onclick=\"ShowDiv('" + templateID + "','2')\" />");
                }
                sb.Append("</div></td>");
                sb.Append("</tr></table>");
            }
        }

        // Add Node to a parent Node
        // developed by Himadri das
        protected void btnPopSubmit_Click(object sender, EventArgs e)
        {

            string addOrEdit = hdnAddOrEdit.Value;
            string accName = "";
            try
            {
                accName = txtAcc.Text;
            }
            catch
            {
                accName = "-1";
            }
            BLL.Accounts.ChartOfAccount.Template tmp = new BLL.Accounts.ChartOfAccount.Template();
            int? moduleID = null;
            if (ChkModule.Checked)
            {
                moduleID = int.Parse(ddlModule.SelectedValue);
            }
            if (addOrEdit == "0") // Add
            {
                tmp.AddChild(txtAcc.Text,
                              int.Parse(hdnParent.Value),
                              chkSLed.Checked,
                              chkLed.Checked,
                              chkTrBal.Checked,
                              chkIncSt.Checked,
                              chkBalSht.Checked,
                              int.Parse(userID),
                              int.Parse(txtChildCodeLength.Text),
                              moduleID
                           );
            }
            else // edit
            {
                tmp.EditTempleteAccount((accName == "" ? "-1" : accName),
                                        int.Parse(hdnParent.Value),
                                        chkSLed.Checked,
                                        chkLed.Checked,
                                        chkTrBal.Checked,
                                        chkIncSt.Checked,
                                        chkBalSht.Checked,
                                        int.Parse(userID),
                                        int.Parse(txtChildCodeLength.Text),
                                        moduleID
                                       );
            }

            if (hdnParent.Value != "")
            {
                BuildTree();
            }
        }

        // Inactive an account as well as its Child Account
        // developed by Himadri das
        protected void btnAct_Click(object sender, EventArgs e)
        {
            Template tmp = new Template();
            //tmp.DelateAccountFromTemplete(int.Parse(hdnFunc.Value), int.Parse(userID));
            //tmp.EnableDisableAccountFromTemplete(int.Parse(hdnFunc.Value), int.Parse(userID), !bool.Parse(hdnAct.Value),chkOnlyThis.Checked);

            if (hdnFunc.Value != "")
            {
                BuildTree();
            }
        }


    }
}
