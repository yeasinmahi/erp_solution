using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOGIS_DAL;
using LOGIS_BLL;
using System.Data;
using System.Web.UI.HtmlControls;
using SAD_BLL.DisPoint;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.DisPoint
{
    public partial class SetLogisVar : BasePage
    {
        private string nextParentIDP = "";
        Table tblV = new Table();
        TableRow trV = new TableRow();
        TableCell tdV = new TableCell();
        TableCell tdLblV = new TableCell();
        TableCell tdConV = new TableCell();
        VehicleManagerTDS.SprVehiclePriceManagerGetAllUpperLevelDataTable tblUpperLevelV;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\DisPoint\\SetLogisVar";
        string stop = "stopping SAD\\DisPoint\\SetLogisVar";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnDDLChangedSelectedIndexV.Value = Request.QueryString["var"];
            }
            BuildTree();
        }

        private void BuildTree()
        {
            tblV.Controls.Clear();

            VehicleManager itemV = new VehicleManager();
            tblUpperLevelV = itemV.GetAllUpperLevel(hdnDDLChangedSelectedIndexV.Value);

            GetItemInfoP("");
            pnlVehicle.Controls.Add(tblV);
        }

        private void GetItemInfoP(string parentID)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\DisPoint\\SetLogisVar set Logis var", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


             int level;
            tdV = new TableCell();
            tdLblV = new TableCell();
            tdConV = new TableCell();

            VehicleManager item = new VehicleManager();
            VehicleManagerTDS.TblVehiclePriceManagerDataTable dataTable;

            dataTable = item.GetDataByParent(parentID, Request.QueryString["unt"]);
            if (dataTable.Rows.Count > 0)
            {
                DropDownList ddl = new DropDownList();

                level = dataTable[0].intLevel;
                ddl.ID = "ddlP" + level + "_" + 1;
                ddl.Items.Add(new ListItem(dataTable[0].strText, dataTable[0].intID.ToString()));

                string id = "";

                if (tblUpperLevelV != null && tblUpperLevelV.Rows.Count > 0)
                {
                    DataRow[] row = tblUpperLevelV.Select("intLevel=" + level);
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
                lbl.Text = item.GetLabel(level.ToString(), Request.QueryString["unt"], parentID) + " ";
                tdLblV.Controls.Add(lbl);
                tdV.Controls.Add(ddl);

                //tdConP.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + 1 + ");"));

                ddl.AutoPostBack = true;
                ddl.Attributes.Add("onChange", "DDLChangeV('" + ddl.ID + "');");

                nextParentIDP = ddl.SelectedValue;

                //just only have not any child
                if (item.GetChildCount(ddl.SelectedValue) <= 0)
                {
                    hdnPriceIdV.Value = ddl.SelectedValue;
                    //tdConP.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + 1 + ");"));
                }


                //tdConP.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + /*subLevel*/1 + ");"));
                trV.Cells.Add(tdLblV);
                trV.Cells.Add(tdV);
                tdConV.Style.Add("padding-left", "10px");
                tdConV.Style.Add("padding-right", "20px");
                trV.Controls.Add(tdConV);

                tblV.Rows.Add(trV);
                trV = new TableRow();

                GetItemInfoP(ddl.SelectedValue);
            }
            else
            {
                if (nextParentIDP == "")
                {
                    //tdP.Controls.Add(BuildAnchor("Add", "ShowDiv(1,1);"));
                    trV.Cells.Add(tdV);
                    tblV.Rows.Add(trV);
                    hdnPriceIdV.Value = "";
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            DisPointInfo di = new DisPointInfo();
            di.UpdateLogisVar(Request.QueryString["id"], Request.QueryString["unt"], hdnPriceIdV.Value);
            Response.Redirect("~/Exit.aspx");
        }
    }
}