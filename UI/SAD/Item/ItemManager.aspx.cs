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
using BLL.Accounts.ChartOfAccount;
using UI.ClassFiles;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.SAD.Item
{
    public partial class ItemManager : BasePage
    {
        private string nextParentID = "";
        Table tbl = new Table();
        TableRow tr = new TableRow();
        TableCell td = new TableCell();
        TableCell tdLbl = new TableCell();
        TableCell tdCon = new TableCell();
        ItemManagerTDS.SprItemManagerGetAllUpperLevelDataTable tblUpperLevel;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Item\\ItemManager";
        string stop = "stopping SAD\\Item\\ItemManager";
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
                tbl.Style.Add("background-color", "#F0F0F0");
            }
        }

        protected void btnPopSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\ItemManager  Item Manger Item Create", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


                SAD_BLL.Item.ItemManager im = new SAD_BLL.Item.ItemManager();

            if (hdnMode.Value == "new")
            {
                im.AddItem(hdnParent.Value, hdnLevel.Value, hdnSubLevel.Value, txtPopText.Text, ddlUnit.SelectedValue, ddlType.SelectedValue, txtCode.Text);
            }
            else if (hdnMode.Value == "sub")
            {
                im.AddSubItem(hdnParent.Value, hdnLevel.Value, hdnSubLevel.Value, txtPopText.Text, txtPopLabel.Text, ddlUnit.SelectedValue, ddlType.SelectedValue, txtCode.Text);
            }
            else if (hdnMode.Value == "mod")
            {
                im.UpdateLabel(txtPopLabel.Text, hdnSubLevel.Value, hdnLevel.Value, ddlUnit.SelectedValue);
            }

            tbl.Controls.Clear();
            GetItemInfo("", 1);
            pnlMain.Controls.Add(tbl);
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
                SAD_BLL.Item.ItemManager item = new SAD_BLL.Item.ItemManager();
                tblUpperLevel = item.GetAllUpperLevel(hdnDDLChangedSelectedIndex.Value);
            }

            GetItemInfo("", 1);
            pnlMain.Controls.Add(tbl);
        }

        private void GetItemInfo(string parentID, int subLevel)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\ItemManager  Item List Show", "", fd.UserName, fd.Location,
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

                Label lbl = new Label();
                lbl.Text = item.GetLabel(subLevel.ToString(), level.ToString(), ddlUnit.SelectedValue, parentID) + " ";
                tdLbl.Controls.Add(lbl);
                td.Controls.Add(ddl);

                tdCon.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + subLevel + ");"));


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
                    if (level == 1)
                    {
                        tdCon.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + (maxLevel + 1) + ");"));
                    }
                }

                tdCon.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + subLevel + ");"));
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

                if (nextParentID == "")
                {
                    td.Controls.Add(BuildAnchor(" Add", "ShowDiv(1,1);"));
                    tr.Cells.Add(td);
                    tbl.Rows.Add(tr);
                }
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
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\ItemManager  Item Manger Final Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
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

            string salesTypeList = "";

            foreach (ListItem chk in CheckBoxList1.Items)
            {
                if (chk.Selected)
                {
                    salesTypeList += chk.Value + ",";
                }
            }

            SAD_BLL.Item.Item it = new SAD_BLL.Item.Item();
            it.AddItem(null, ddlUnit.SelectedValue, ddlType.SelectedValue, levelOneId, id, subLevel, Session[SessionParams.USER_ID].ToString(), salesTypeList);

            hdnId.Value = id.ToString();
            hdnL1.Value = levelOneId.ToString();
            hdnSub.Value = subLevel.ToString();

            GridView1.DataBind();

            ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);
            ItemSt.ReloadProduct(ddlUnit.SelectedValue);
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
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            if (ddlType.Items.Count <= 0)
            {
                ddlType.DataBind();
            }

            BuildTree();

        }

        protected void btnShow_Click(object sender, EventArgs e)
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

            GridView1.DataBind();

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (ddlType.Items.Count <= 0)
            {
                ddlType.DataBind();
            }

            BuildTree();*/
        }
        protected void CheckBoxList1_DataBound(object sender, EventArgs e)
        {
            ChkBoxChecked();
        }

        private void ChkBoxChecked()
        {
            foreach (ListItem chk in CheckBoxList1.Items)
            {
                chk.Selected = true;
            }
        }
    }

}
