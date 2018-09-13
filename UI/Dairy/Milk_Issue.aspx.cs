using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.Dairy
{
    public partial class Milk_Issue : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Milk_Issue.aspx";
        string stop = "stopping Dairy/Milk_Issue.aspx";

        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        string filePathForXML; string xmlString = ""; string xml;
        string filePathForXMLIssue; /*string xmlString = ""; string xml;*/

        string rdate; string supplname; string recqty; string preissuqty; string balanceqty; string issuqty;
        string rate; string issuvalu; string fatper; string billamount; string suppid; string avftp;
        string totalqt; string totalval;

        int intUnitID; int intCCID; DateTime dteIssue; int intInsertBy; int intVID; string strChamberNo;
        decimal decFTP; int intWork; DateTime dteFrom; DateTime dteTo; 

        string decqty; string decrate; string decvalue; string dterdate; string intsuppid; string decrqty; string decpreqty; 
        string ysnissuecom;  

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Issue.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            filePathForXML = Server.MapPath("~/Dairy/Data/MilkIssue_" + hdnEnroll.Value + ".xml");
            filePathForXMLIssue = Server.MapPath("~/Dairy/Data/MilkIssueInsert_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {                    
                    pnlUpperControl.DataBind(); 

                    File.Delete(filePathForXML); dgvIssue.DataSource = ""; dgvIssue.DataBind();
                    File.Delete(filePathForXMLIssue); /*dgvIssue.DataSource = ""; dgvIssue.DataBind();*/

                    dt = obj.GetUnitList();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetChillingCenterList(intUnitID);
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataBind();

                    dt = obj.GetVehicleNoList();
                    ddlVehicleNo.DataTextField = "strVehicleNo";
                    ddlVehicleNo.DataValueField = "intVehicleID";
                    ddlVehicleNo.DataSource = dt;
                    ddlVehicleNo.DataBind();

                }
                catch
                { }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Issue.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);


            try
            {  
                File.Delete(filePathForXML); dgvIssue.DataSource = ""; dgvIssue.DataBind();

                lblUnitName.Text = ddlUnit.SelectedItem.ToString();
                lblCCName.Text = ddlChillingCenter.SelectedItem.ToString();

                intWork = 1;
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtReceiveDate.Text);

                dt = new DataTable();
                dt = obj.GetReportForIssue(intWork, intCCID, dteFrom, dteTo);
                //dgvIssue.DataSource = dt;
                //dgvIssue.DataBind();

                //*************************************************************

                if (dt.Rows.Count > 0)
                {
                    for (int index = 0; index < dt.Rows.Count; index++)
                    {
                        rdate = dt.Rows[index]["dteTransactionDate"].ToString();
                        supplname = dt.Rows[index]["SupplierName"].ToString();
                        recqty = dt.Rows[index]["RecQty"].ToString();
                        preissuqty = dt.Rows[index]["PreviousIssueQty"].ToString();
                        balanceqty = dt.Rows[index]["BalanceQty"].ToString();
                        issuqty = dt.Rows[index]["IssueQty"].ToString();
                        rate = dt.Rows[index]["RecRate"].ToString();
                        issuvalu = dt.Rows[index]["IssueValue"].ToString();
                        fatper = dt.Rows[index]["FatPercent"].ToString();
                        billamount = dt.Rows[index]["BillAmount"].ToString();
                        suppid = dt.Rows[index]["intSupplierID"].ToString();
                        avftp = dt.Rows[index]["AvFatPer"].ToString();

                        totalreceive = 0;
                        totalpreqty = 0;
                        totalbalanc = 0;
                        totalissueq = 0;
                        totalissuevalue = 0;
                        totalbillamou = 0;

                        CreateXml(rdate, supplname, recqty, preissuqty, balanceqty, issuqty, rate, issuvalu, fatper, billamount, suppid, avftp);
                        //txtDieselCredit.Text = "";
                        //txtCNGCredit.Text = "";
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Visible = true;
                    lblCCName.Visible = true;                   
                }
                else
                {
                    lblUnitName.Visible = false;
                    lblCCName.Visible = false;                    
                }

                //**************************************************************
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateXml(string rdate, string supplname, string recqty, string preissuqty, string balanceqty, string issuqty, string rate, string issuvalu, string fatper, string billamount, string suppid, string avftp) 
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("MilkIssue");
                XmlNode addItem = CreateItemNode(doc, rdate, supplname, recqty, preissuqty, balanceqty, issuqty, rate, issuvalu, fatper, billamount, suppid, avftp);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("MilkIssue");
                XmlNode addItem = CreateItemNode(doc, rdate, supplname, recqty, preissuqty, balanceqty, issuqty, rate, issuvalu, fatper, billamount, suppid, avftp);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            //Clear(); 
        }
        private XmlNode CreateItemNode(XmlDocument doc, string rdate, string supplname, string recqty, string preissuqty, string balanceqty, string issuqty, string rate, string issuvalu, string fatper, string billamount, string suppid, string avftp)
        {
            XmlNode node = doc.CreateElement("MilkIssue");

            //strdate, supplname, recqty, preissuqty, balanceqty, issuqty, rate, issuvalu, fatper, billamount, suppid

            XmlAttribute Rdate = doc.CreateAttribute("rdate"); Rdate.Value = rdate;
            XmlAttribute Supplname = doc.CreateAttribute("supplname"); Supplname.Value = supplname;
            XmlAttribute Recqty = doc.CreateAttribute("recqty"); Recqty.Value = recqty;
            XmlAttribute Preissuqty = doc.CreateAttribute("preissuqty"); Preissuqty.Value = preissuqty;
            XmlAttribute Balanceqty = doc.CreateAttribute("balanceqty"); Balanceqty.Value = balanceqty;
            XmlAttribute Issuqty = doc.CreateAttribute("issuqty"); Issuqty.Value = issuqty;
            XmlAttribute Rate = doc.CreateAttribute("rate"); Rate.Value = rate;
            XmlAttribute Issuvalu = doc.CreateAttribute("issuvalu"); Issuvalu.Value = issuvalu;
            XmlAttribute Fatper = doc.CreateAttribute("fatper"); Fatper.Value = fatper;
            XmlAttribute Billamount = doc.CreateAttribute("billamount"); Billamount.Value = billamount;
            XmlAttribute Suppid = doc.CreateAttribute("suppid"); Suppid.Value = suppid;
            XmlAttribute Avftp = doc.CreateAttribute("avftp"); Avftp.Value = avftp;
            
            node.Attributes.Append(Rdate);
            node.Attributes.Append(Supplname);
            node.Attributes.Append(Recqty);
            node.Attributes.Append(Preissuqty);
            node.Attributes.Append(Balanceqty);
            node.Attributes.Append(Issuqty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Issuvalu);
            node.Attributes.Append(Fatper);
            node.Attributes.Append(Billamount);
            node.Attributes.Append(Suppid);
            node.Attributes.Append(Avftp);            
            return node;
        }
        private void LoadGridwithXml() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("MilkIssue");
            xmlString = dSftTm.InnerXml;            
            xmlString = "<MilkIssue>" + xmlString + "</MilkIssue>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr); 
            if (ds.Tables[0].Rows.Count > 0) { dgvIssue.DataSource = ds; }
            else { dgvIssue.DataSource = ""; } dgvIssue.DataBind();
        }
        
        protected void btnIssue_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Issue.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());                
                try { dteIssue = DateTime.Parse(txtReceiveDate.Text); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Date.');", true); return; }
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                try { intVID = int.Parse(ddlVehicleNo.SelectedValue.ToString()); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Vehicle No.');", true); return; }
                if(txtChamberNo.Text != "") { strChamberNo = txtChamberNo.Text; } 
                else {ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Chamber No.');", true); return;}                 
                try { decFTP = decimal.Parse(txtAverageFatPercent.Text); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Average Fat %.');", true); return; }

                if (dgvIssue.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvIssue.Rows.Count; index++)
                    {
                        decqty = ((TextBox)dgvIssue.Rows[index].FindControl("txtIssueQty")).Text.ToString();
                        decrate = ((Label)dgvIssue.Rows[index].FindControl("lblRate")).Text.ToString();
                        decvalue = (decimal.Parse(decqty.ToString()) * decimal.Parse(decrate.ToString())).ToString(); //((Label)dgvIssue.Rows[index].FindControl("lblRate")).Text.ToString();
                        dterdate = ((Label)dgvIssue.Rows[index].FindControl("lbldteTransactionDate")).Text.ToString();
                        intsuppid = ((Label)dgvIssue.Rows[index].FindControl("lblSuppID")).Text.ToString();
                        decrqty = ((Label)dgvIssue.Rows[index].FindControl("lblReceiveQty")).Text.ToString();
                        decpreqty = ((Label)dgvIssue.Rows[index].FindControl("lblPreQty")).Text.ToString();

                        if (decimal.Parse(decrqty.ToString()) == (decimal.Parse(decpreqty.ToString()) + decimal.Parse(decqty.ToString())))
                        { ysnissuecom = "1"; } else {ysnissuecom = "0";}

                        if (decqty != "0")
                        {
                            CreateXmlIssue(decqty, decrate, decvalue, dterdate, intsuppid, decrqty, decpreqty, ysnissuecom);
                        }
                    }
                }
                else { return; }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLIssue);
                    XmlNode dSftTm = doc.SelectSingleNode("MilkIssueInsert");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<MilkIssueInsert>" + xmlString + "</MilkIssueInsert>";
                    xml = xmlString;
                }
                catch { }
                if (xml == "") { return; }

                string message = obj.InsertIssueEntry(intUnitID, intCCID, dteIssue, intInsertBy, intVID, strChamberNo, decFTP, xml);

                txtChamberNo.Text = "";
                txtAverageFatPercent.Text = "";
                txtTotalBalanceQty.Text = "";
                txtTotalIssuQty.Text = "";
                txtTotalIssuValue.Text = "";

                if (filePathForXML != null)
                { File.Delete(filePathForXML); } dgvIssue.DataSource = ""; dgvIssue.DataBind();
                if (filePathForXMLIssue != null)
                { File.Delete(filePathForXMLIssue); }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);                
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void CreateXmlIssue(string decqty, string decrate, string decvalue, string dterdate, string intsuppid, string decrqty, string decpreqty, string ysnissuecom)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLIssue))
            {
                doc.Load(filePathForXMLIssue);
                XmlNode rootNode = doc.SelectSingleNode("MilkIssueInsert");
                XmlNode addItem = CreateIssueNode(doc, decqty, decrate, decvalue, dterdate, intsuppid, decrqty, decpreqty, ysnissuecom);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("MilkIssueInsert");
                XmlNode addItem = CreateIssueNode(doc, decqty, decrate, decvalue, dterdate, intsuppid, decrqty, decpreqty, ysnissuecom);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLIssue);
            LoadGridwithXmlIssue();
            //Clear(); 
        }
        private XmlNode CreateIssueNode(XmlDocument doc, string decqty, string decrate, string decvalue, string dterdate, string intsuppid, string decrqty, string decpreqty, string ysnissuecom)
        {
            XmlNode node = doc.CreateElement("MilkIssueInsert");

            //strdate, supplname, recqty, preissuqty, balanceqty, issuqty, rate, issuvalu, fatper, billamount, suppid

            XmlAttribute Decqty = doc.CreateAttribute("decqty"); Decqty.Value = decqty;
            XmlAttribute Decrate = doc.CreateAttribute("decrate"); Decrate.Value = decrate;
            XmlAttribute Decvalue = doc.CreateAttribute("decvalue"); Decvalue.Value = decvalue;
            XmlAttribute Dterdate = doc.CreateAttribute("dterdate"); Dterdate.Value = dterdate;
            XmlAttribute Intsuppid = doc.CreateAttribute("intsuppid"); Intsuppid.Value = intsuppid;            
            XmlAttribute Decrqty = doc.CreateAttribute("decrqty"); Decrqty.Value = decrqty;
            XmlAttribute Decpreqty = doc.CreateAttribute("decpreqty"); Decpreqty.Value = decpreqty;
            XmlAttribute Ysnissuecom = doc.CreateAttribute("ysnissuecom"); Ysnissuecom.Value = ysnissuecom; 
                        
            node.Attributes.Append(Decqty);
            node.Attributes.Append(Decrate);
            node.Attributes.Append(Decvalue);
            node.Attributes.Append(Dterdate);
            node.Attributes.Append(Intsuppid);
            node.Attributes.Append(Decrqty);
            node.Attributes.Append(Decpreqty);
            node.Attributes.Append(Ysnissuecom);
            return node;
        }
        private void LoadGridwithXmlIssue() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLIssue);
            XmlNode dSftTm = doc.SelectSingleNode("MilkIssueInsert");
            xmlString = dSftTm.InnerXml;
            xmlString = "<MilkIssueInsert>" + xmlString + "</MilkIssueInsert>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            //dgvIssue.DataSource = "";
            //dgvIssue.DataBind();
            
            //if (ds.Tables[0].Rows.Count > 0) { dgvIssue.DataSource = ds; }
            //else { dgvIssue.DataSource = ""; } dgvIssue.DataBind();
        }

        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvIssue.DataSource = "";
            dgvIssue.DataBind();

            lblUnitName.Visible = false;
            lblCCName.Visible = false; 
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = obj.GetChillingCenterList(intUnitID);
                ddlChillingCenter.DataTextField = "strChillingCenterName";
                ddlChillingCenter.DataValueField = "intChillingCenterID";
                ddlChillingCenter.DataSource = dt;
                ddlChillingCenter.DataBind();
            }
            catch { }

            dgvIssue.DataSource = "";
            dgvIssue.DataBind();

            lblUnitName.Visible = false;
            lblCCName.Visible = false; 
        }

        protected decimal totalreceive = 0;
        protected decimal totalpreqty = 0;
        protected decimal totalbalanc = 0;
        protected decimal totalissueq = 0;
        protected decimal totalissuevalue = 0;
        protected decimal totalbillamou = 0;

        protected void dgvIssue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalreceive += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblReceiveQty")).Text);
                    totalpreqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblPreQty")).Text);
                    totalbalanc += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblbalancqty")).Text);
                    totalissueq += decimal.Parse(((TextBox)e.Row.Cells[6].FindControl("txtIssueQty")).Text);
                    totalissuevalue += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblIssueVal")).Text);
                    totalbillamou += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblBillAmo")).Text);
                }
            }
            catch { }
        }

        protected void dgvIssue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}