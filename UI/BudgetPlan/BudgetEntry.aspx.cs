using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Budget_BLL;
using Budget_BLL.Budget;
using System.Collections;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using System.Drawing;

namespace UI.BudgetPlan
{
    public partial class BudgetEntry : BasePage
    {
        Budget_Entry_BLL obj = new Budget_Entry_BLL();
        DataTable dt;

        string filePathForXML; string xmlString = ""; string xml;
        int intUnitID; int intCCID; int intYear; int intUserID; string strYear;
        string coaid; string strmonth; string bamo; string tamo;

        int intMonth; decimal monBAmount; decimal monTAmount;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/BudgetPlan/Data/BudgetEntry_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                //hdnEnroll.Value = "42815";
                pnlUpperControl.DataBind();
                File.Delete(filePathForXML);

                dt = obj.GetUnit(int.Parse(hdnEnroll.Value));                
                if (dt.Rows.Count > 0)
                {
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();
                }
                else { btnBudgetSave.Visible = false; return; }
                
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = obj.GetCostCenterName(int.Parse(hdnEnroll.Value), intUnitID);
                if (dt.Rows.Count > 0)
                {
                    ddlCostCenter.DataTextField = "strCCName";
                    ddlCostCenter.DataValueField = "intCostCenterID";
                    ddlCostCenter.DataSource = dt;
                    ddlCostCenter.DataBind();
                }
                else { btnBudgetSave.Visible = false; return; }

                //dt = obj.GetYearList();
                //ddlYear.DataTextField = "intYear";
                //ddlYear.DataValueField = "intAutoID";
                //ddlYear.DataSource = dt;
                //ddlYear.DataBind();

                LoadGrid();
                getYear();
            }
              
        }
        private void getYear()
        {
            dt = obj.getyear();
            ddlYear.DataTextField = "strYearList";
            ddlYear.DataValueField = "intYear";
            ddlYear.DataSource = dt;
            ddlYear.DataBind();
        }
        private void LoadGrid()
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intCCID = int.Parse(ddlCostCenter.SelectedValue.ToString());
                strYear = ddlYear.SelectedValue.ToString();
                
                dt = obj.GetDataForBudgetEntry(intUnitID, strYear, 3, 0); //dt = obj.GetBudgetEntryR();
                dgvBudget.DataSource = dt; 
                dgvBudget.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "gridviewScroll();", true);
            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //hdnEnroll.Value = "42815";
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = obj.GetCostCenterName(int.Parse(hdnEnroll.Value), intUnitID);
                ddlCostCenter.DataTextField = "strCCName";
                ddlCostCenter.DataValueField = "intCostCenterID";
                ddlCostCenter.DataSource = dt;

                ddlCostCenter.DataBind();

                LoadGrid();
            }
            catch { }

        }
        protected void ddlCostCenter_SelectedIndexChanged(object sender, EventArgs e)
        {   
            LoadGrid();           
        }

        protected decimal grandTotal = 0;
        protected decimal GTJulAmo = 0;
        protected decimal GTJulTol = 0;
        protected decimal GTAugAmo = 0;
        protected decimal GTAugTol = 0;
        protected decimal GTSepAmo = 0;
        protected decimal GTSepTol = 0;
        protected decimal GTOctAmo = 0;
        protected decimal GTOctTol = 0;
        protected decimal GTNovAmo = 0;
        protected decimal GTNovTol = 0;
        protected decimal GTDecAmo = 0;
        protected decimal GTDecTol = 0;
        protected decimal GTJanAmo = 0;
        protected decimal GTJanTol = 0; 
        protected decimal GTFebAmo = 0;
        protected decimal GTFebTol = 0;
        protected decimal GTMarAmo = 0;
        protected decimal GTMarTol = 0;
        protected decimal GTAprAmo = 0;
        protected decimal GTAprTol = 0;
        protected decimal GTMayAmo = 0;
        protected decimal GTMayTol = 0;
        protected decimal GTJunAmo = 0;
        protected decimal GTJunTol = 0; 
        protected void dgvBudget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grandTotal += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtTotalAmount")).Text);
                    GTJulAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtJulAmo")).Text);
                    GTJulTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtJulTol")).Text);
                    GTAugAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtAugAmo")).Text);
                    GTAugTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtAugTol")).Text);
                    GTSepAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtSepAmo")).Text);
                    GTSepTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtSepTol")).Text);
                    GTOctAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtOctAmo")).Text);
                    GTOctTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtOctTol")).Text);
                    GTNovAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtNovAmo")).Text);
                    GTNovTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtNovTol")).Text);
                    GTDecAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtDecAmo")).Text);
                    GTDecTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtDecTol")).Text);
                    GTJanAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtJanAmo")).Text);
                    GTJanTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtJanTol")).Text);
                    GTFebAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtFebAmo")).Text);
                    GTFebTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtFebTol")).Text);
                    GTMarAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtMarAmo")).Text);
                    GTMarTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtMarTol")).Text);
                    GTAprAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtAprAmo")).Text);
                    GTAprTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtAprTol")).Text);
                    GTMayAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtMayAmo")).Text);
                    GTMayTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtMayTol")).Text);
                    GTJunAmo += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtJunAmo")).Text);
                    GTJunTol += decimal.Parse(((TextBox)e.Row.Cells[4].FindControl("txtJunTol")).Text);                     
                }
            }
            catch { }
        }
        protected void OnDataBound(object sender, EventArgs e)
        {
            
            //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            //TableHeaderCell cell = new TableHeaderCell();
            //cell.Text = ""; cell.ColumnSpan = 4; row.Controls.Add(cell);

            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "July"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "August"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "September"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "October"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "November"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "December"; row.Controls.Add(cell); 
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "January"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "February"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "March"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2;cell.Text = "April"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "May"; row.Controls.Add(cell);
            //cell = new TableHeaderCell(); cell.ColumnSpan = 2; cell.Text = "June"; row.Controls.Add(cell); 

            //row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            //dgvBudget.HeaderRow.Parent.Controls.AddAt(0, row);           
        }

        // Insert Budget Entry XML Start *************************************************
        protected void btnBudgetSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                dt = obj.getEntryDateCack(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
                if(dt.Rows.Count>0)
                {
                DateTime dtedate =DateTime.Parse(dt.Rows[0]["dtedate"].ToString());
                DateTime dtedatenow = DateTime.Parse(dt.Rows[0]["dtedatenow"].ToString());

                    if (dtedatenow <= dtedate)
                    {
                        intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                        intCCID = int.Parse(ddlCostCenter.SelectedValue.ToString());
                        intYear = int.Parse(ddlYear.SelectedValue.ToString());
                        intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());

                        if (filePathForXML != null) { File.Delete(filePathForXML); }

                        if (dgvBudget.Rows.Count > 0)
                        {
                            for (int index = 0; index < dgvBudget.Rows.Count; index++)
                            {
                                //coaid = ((Label)dgvBudget.Rows[index].FindControl("lblCOAID")).Text.ToString();
                                coaid = ((TextBox)dgvBudget.Rows[index].FindControl("txtCOAID")).Text.ToString();

                                strmonth = "7";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtJulAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtJulTol")).Text.ToString();
                                if (decimal.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "8";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtAugAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtAugTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "9";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtSepAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtSepTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "10";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtOctAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtOctTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "11";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtNovAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtNovTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "12";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtDecAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtDecTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "1";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtJanAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtJanTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "2";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtFebAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtFebTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "3";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtMarAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtMarTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "4";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtAprAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtAprTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "5";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtMayAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtMayTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                                strmonth = "6";
                                bamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtJunAmo")).Text.ToString();
                                tamo = ((TextBox)dgvBudget.Rows[index].FindControl("txtJunTol")).Text.ToString();
                                if (int.Parse(bamo.ToString()) != 0)
                                {
                                    CreateVoucherXml(coaid, strmonth, bamo, tamo);
                                }
                            }

                        }
                    }
                }
            }
            
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("BudgetEntry");
                xmlString = dSftTm.InnerXml;
                xmlString = "<BudgetEntry>" + xmlString + "</BudgetEntry>";
                xml = xmlString;
            }
            catch { }
            if (xml == "") { return; }

            //Final Insert
            //string message = obj.InsertBudgetEntry(intUnitID, intYear, intUserID, intCCID, xml);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            if (filePathForXML != null) { File.Delete(filePathForXML); }
        }
        //intUnitID,intGCOAID,intYear,intMonth,monBudget,monTolerancePer,intInsertBy,intFinancialYear,intCostCenterID

        private void CreateVoucherXml(string coaid, string strmonth, string bamo, string tamo)
        {
            XmlDocument doc = new XmlDocument(); 
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("BudgetEntry");
                XmlNode addItem = CreateItemNodeSHold(doc, coaid, strmonth, bamo, tamo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BudgetEntry");
                XmlNode addItem = CreateItemNodeSHold(doc, coaid, strmonth, bamo, tamo);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            //Clear(); 
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("BudgetEntry");
            xmlString = dSftTm.InnerXml;
            xmlString = "<BudgetEntry>" + xmlString + "</BudgetEntry>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            ////if (ds.Tables[0].Rows.Count > 0) { dgvWorkPlan.DataSource = ds; }
            ////else { dgvWorkPlan.DataSource = ""; } dgvWorkPlan.DataBind();
        }
        private XmlNode CreateItemNodeSHold(XmlDocument doc, string coaid, string strmonth, string bamo, string tamo)
        {
            XmlNode node = doc.CreateElement("BudgetEntry");

            XmlAttribute Coaid = doc.CreateAttribute("coaid"); Coaid.Value = coaid;
            XmlAttribute Strmonth = doc.CreateAttribute("strmonth"); Strmonth.Value = strmonth;
            XmlAttribute Bamo = doc.CreateAttribute("bamo"); Bamo.Value = bamo;
            XmlAttribute Tamo = doc.CreateAttribute("tamo"); Tamo.Value = tamo;

            node.Attributes.Append(Coaid);
            node.Attributes.Append(Strmonth);
            node.Attributes.Append(Bamo);
            node.Attributes.Append(Tamo);            
            return node;
        }

        protected void dgvBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ConfirmAll()", true);
            try
            {
                string message;

                //if (hdnconfirm.Value == "1")
                //{
                //intUnitID,intGCOAID,intYear,intMonth,monBudget,monTolerancePer,intInsertBy, dteInsertTime, intFinancialYear,intCostCenterID
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intCCID = int.Parse(ddlCostCenter.SelectedValue.ToString());
                intYear = int.Parse(ddlYear.SelectedItem.ToString());
                intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                //int intCOAID = int.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtCOAID")).Text.ToString());

                //e.RowIndex = RowIndex + 1;

                int intCOAID = int.Parse(((Label)dgvBudget.Rows[e.RowIndex ].FindControl("lblCOAID")).Text.ToString());

                intMonth = 7;
                try { monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtJulAmo")).Text.ToString()); }
                catch { monBAmount = 0; }
                try { monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtJulTol")).Text.ToString()); }
                catch { monTAmount = 0; }
                //if (monBAmount != 0)
                //{                    
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 8;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtAugAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtAugTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 9;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtSepAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtSepTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 10;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtOctAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtOctTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 11;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtNovAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtNovTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 12;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtDecAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtDecTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 1;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtJanAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtJanTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 2;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtFebAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtFebTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 3;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtMarAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtMarTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 4;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtAprAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtAprTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 5;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtMayAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtMayTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                intMonth = 6;
                monBAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtJunAmo")).Text.ToString());
                monTAmount = decimal.Parse(((TextBox)dgvBudget.Rows[e.RowIndex].FindControl("txtJunTol")).Text.ToString());
                //if (monBAmount != 0)
                //{
                message = obj.InsertBudgetEntry(intUnitID, intCOAID, intYear, intMonth, monBAmount, monTAmount, intUserID, intCCID);
                //}
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "gridviewScroll();", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('BUDGET ENTRY SUCCESSFULLY.');", true);
               
                // LoadGrid();
                //}

            }
            catch { }
            
              
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        //private void CreateVoucherXml(string coaid, string totalb, string julamo, string jultol, string augamo, string augtol, string sepamo, string septol, string octamo, string octtol, string novamo, string novtol, string decamo, string dectol, string janamo, string jantol, string febamo, string febtol, string maramo, string martol, string apramo, string aprtol, string mayamo, string maytol, string junamo, string juntol)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    if (System.IO.File.Exists(filePathForXML))
        //    {
        //        doc.Load(filePathForXML);
        //        XmlNode rootNode = doc.SelectSingleNode("BudgetEntry");
        //        XmlNode addItem = CreateItemNodeSHold(doc, coaid, totalb, julamo, jultol, augamo, augtol, sepamo, septol, octamo, octtol, novamo, novtol, decamo, dectol, janamo, jantol, febamo, febtol, maramo, martol, apramo, aprtol, mayamo, maytol, junamo, juntol);
        //        rootNode.AppendChild(addItem);
        //    }
        //    else
        //    {
        //        XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
        //        doc.AppendChild(xmldeclerationNode);
        //        XmlNode rootNode = doc.CreateElement("BudgetEntry");
        //        XmlNode addItem = CreateItemNodeSHold(doc, coaid, totalb, julamo, jultol, augamo, augtol, sepamo, septol, octamo, octtol, novamo, novtol, decamo, dectol, janamo, jantol, febamo, febtol, maramo, martol, apramo, aprtol, mayamo, maytol, junamo, juntol);
        //        rootNode.AppendChild(addItem);
        //        doc.AppendChild(rootNode);
        //    }
        //    doc.Save(filePathForXML);
        //    LoadGridwithXml();
        //    //Clear(); 
        //}
        //private void LoadGridwithXml()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filePathForXML);
        //    XmlNode dSftTm = doc.SelectSingleNode("BudgetEntry");
        //    xmlString = dSftTm.InnerXml;
        //    xmlString = "<BudgetEntry>" + xmlString + "</BudgetEntry>";
        //    StringReader sr = new StringReader(xmlString);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    ////if (ds.Tables[0].Rows.Count > 0) { dgvWorkPlan.DataSource = ds; }
        //    ////else { dgvWorkPlan.DataSource = ""; } dgvWorkPlan.DataBind();
        //}
        //private XmlNode CreateItemNodeSHold(XmlDocument doc, string coaid, string totalb, string julamo, string jultol, string augamo, string augtol, string sepamo, string septol, string octamo, string octtol, string novamo, string novtol, string decamo, string dectol, string janamo, string jantol, string febamo, string febtol, string maramo, string martol, string apramo, string aprtol, string mayamo, string maytol, string junamo, string juntol)
        //{
        //    XmlNode node = doc.CreateElement("BudgetEntry");

        //    XmlAttribute Coaid = doc.CreateAttribute("coaid"); Coaid.Value = coaid;
        //    XmlAttribute Totalb = doc.CreateAttribute("totalb"); Totalb.Value = totalb;
        //    XmlAttribute Julamo = doc.CreateAttribute("julamo"); Julamo.Value = julamo;
        //    XmlAttribute Jultol = doc.CreateAttribute("jultol"); Jultol.Value = jultol;
        //    XmlAttribute Augamo = doc.CreateAttribute("augamo"); Augamo.Value = augamo;
        //    XmlAttribute Augtol = doc.CreateAttribute("augtol"); Augtol.Value = augtol;
        //    XmlAttribute Sepamo = doc.CreateAttribute("sepamo"); Sepamo.Value = sepamo;
        //    XmlAttribute Septol = doc.CreateAttribute("septol"); Septol.Value = septol;
        //    XmlAttribute Octamo = doc.CreateAttribute("octamo"); Octamo.Value = octamo;
        //    XmlAttribute Octtol = doc.CreateAttribute("octtol"); Octtol.Value = octtol;
        //    XmlAttribute Novamo = doc.CreateAttribute("novamo"); Novamo.Value = novamo;
        //    XmlAttribute Novtol = doc.CreateAttribute("novtol"); Novtol.Value = novtol;
        //    XmlAttribute Decamo = doc.CreateAttribute("decamo"); Decamo.Value = decamo;
        //    XmlAttribute Dectol = doc.CreateAttribute("dectol"); Dectol.Value = dectol;
        //    XmlAttribute Janamo = doc.CreateAttribute("janamo"); Janamo.Value = janamo;
        //    XmlAttribute Jantol = doc.CreateAttribute("jantol"); Jantol.Value = jantol;
        //    XmlAttribute Febamo = doc.CreateAttribute("febamo"); Febamo.Value = febamo;
        //    XmlAttribute Febtol = doc.CreateAttribute("febtol"); Febtol.Value = febtol;
        //    XmlAttribute Maramo = doc.CreateAttribute("maramo"); Maramo.Value = maramo;
        //    XmlAttribute Martol = doc.CreateAttribute("martol"); Martol.Value = martol;
        //    XmlAttribute Apramo = doc.CreateAttribute("apramo"); Apramo.Value = apramo;
        //    XmlAttribute Aprtol = doc.CreateAttribute("aprtol"); Aprtol.Value = aprtol;
        //    XmlAttribute Mayamo = doc.CreateAttribute("mayamo"); Mayamo.Value = mayamo;
        //    XmlAttribute Maytol = doc.CreateAttribute("maytol"); Maytol.Value = maytol;
        //    XmlAttribute Junamo = doc.CreateAttribute("junamo"); Junamo.Value = junamo;
        //    XmlAttribute Juntol = doc.CreateAttribute("juntol"); Juntol.Value = juntol;

        //    node.Attributes.Append(Coaid);
        //    node.Attributes.Append(Totalb);
        //    node.Attributes.Append(Julamo);
        //    node.Attributes.Append(Jultol);
        //    node.Attributes.Append(Augamo);
        //    node.Attributes.Append(Augtol);
        //    node.Attributes.Append(Sepamo);
        //    node.Attributes.Append(Septol);
        //    node.Attributes.Append(Octamo);
        //    node.Attributes.Append(Octtol);
        //    node.Attributes.Append(Novamo);
        //    node.Attributes.Append(Novtol);
        //    node.Attributes.Append(Decamo);
        //    node.Attributes.Append(Dectol);
        //    node.Attributes.Append(Janamo);
        //    node.Attributes.Append(Jantol);
        //    node.Attributes.Append(Febamo);
        //    node.Attributes.Append(Febtol);
        //    node.Attributes.Append(Maramo);
        //    node.Attributes.Append(Martol);
        //    node.Attributes.Append(Apramo);
        //    node.Attributes.Append(Aprtol);
        //    node.Attributes.Append(Mayamo);
        //    node.Attributes.Append(Maytol);
        //    node.Attributes.Append(Junamo);
        //    node.Attributes.Append(Juntol);
        //    return node;
        //}
















    }
}