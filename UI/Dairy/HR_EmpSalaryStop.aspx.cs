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
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

namespace UI.Dairy
{
    public partial class HR_EmpSalaryStop : BasePage
    {
        InternalTransportBLL objT = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intUnitID; int intPart; int intJobStationID; int intEnroll; int intInsertBy; DateTime dteDate;
        string filePathForXML; string xmlString = ""; string xml; string enroll; int intCheck;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/Dairy/Data/SalaryHold_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML);
                    pnlUpperControl.DataBind();

                    dt = objT.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = objtask.GetJobStationList(intUnitID);
                    ddlJobStation.DataTextField = "strJobStationName";
                    ddlJobStation.DataValueField = "intEmployeeJobStationId";
                    ddlJobStation.DataSource = dt;
                    ddlJobStation.DataBind();                    

                    ReportDiv.Visible = false;                    
                }
                catch { }
            }
        }

        private void LoadGrid()
        {
            try
            { 
                if(cbSalaryHoldR.Checked == true) { intPart = 2; } else { intPart = 1; }                
                intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                try { dteDate = DateTime.Parse(txtDate.Text); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Date.');", true); return; }

                //GetEmpList
                dt = new DataTable();
                dt = objtask.GetEmpList(3, intJobStationID, dteDate);
                if (dt.Rows.Count > 0)
                { intCheck = int.Parse(dt.Rows[0]["intCheck"].ToString());}

                if (intCheck > 0) {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already Salary Generate in this month. ');", true);
                    ReportDiv.Visible = false;
                    dgvReport.DataSource = "";
                    dgvReport.DataBind();
                    return;
                }
                else 
                {
                    dt = new DataTable();
                    dt = objtask.GetEmpList(intPart, intJobStationID, dteDate);
                    if (dt.Rows.Count > 0)
                    {
                        ReportDiv.Visible = true;
                        dgvReport.DataSource = dt;
                        dgvReport.DataBind();

                        if (intPart == 2) 
                        { dgvReport.Columns[9].Visible = false; dgvReport.Columns[10].Visible = false; }
                        else { dgvReport.Columns[9].Visible = true; dgvReport.Columns[10].Visible = true; }
                    }
                    else
                    {
                        ReportDiv.Visible = false;
                        dgvReport.DataSource = "";
                        dgvReport.DataBind();
                    }
                }
            }
            catch
            { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = objtask.GetJobStationList(intUnitID);
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataSource = dt;
            ddlJobStation.DataBind();

            ReportDiv.Visible = false;
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDiv.Visible = false;
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void btnHold_Click(object sender, EventArgs e) 
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    string senderdata = ((Button)sender).CommandArgument.ToString();
                    intPart = 1;
                    intEnroll = int.Parse(senderdata.ToString());
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    dteDate = DateTime.Parse(txtDate.Text);
                    xml = "";

                    //Final Insert
                    string message = objtask.InsertEmpSalaryStop(intPart, intEnroll, intInsertBy, intUnitID, intJobStationID, dteDate, xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadGrid();
                }
                catch { }
            }        
        }
        protected void btnAllHold_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 2;
                intEnroll = 0;
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                try { dteDate = DateTime.Parse(txtDate.Text); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Date.');", true); return; }

                if (filePathForXML != null) { File.Delete(filePathForXML);} 

                if (dgvReport.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvReport.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvReport.Rows[index].FindControl("chkRow")).Checked == true)
                        {
                            enroll = ((Label)dgvReport.Rows[index].FindControl("lblEnroll")).Text.ToString();
                            CreateVoucherXml(enroll);
                        }
                    }
                }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("SalaryHold");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<SalaryHold>" + xmlString + "</SalaryHold>";
                    xml = xmlString;
                }
                catch { }
                if (xml == "") { return; }
                
                //Final Insert
                string message = objtask.InsertEmpSalaryStop(intPart, intEnroll, intInsertBy, intUnitID, intJobStationID, dteDate, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                if (filePathForXML != null) { File.Delete(filePathForXML); } 
                LoadGrid();
            }
        }

        private void CreateVoucherXml(string enroll)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SalaryHold");
                XmlNode addItem = CreateItemNodeSHold(doc, enroll);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SalaryHold");
                XmlNode addItem = CreateItemNodeSHold(doc, enroll);
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
            XmlNode dSftTm = doc.SelectSingleNode("SalaryHold");
            xmlString = dSftTm.InnerXml;
            xmlString = "<SalaryHold>" + xmlString + "</SalaryHold>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            ////if (ds.Tables[0].Rows.Count > 0) { dgvWorkPlan.DataSource = ds; }
            ////else { dgvWorkPlan.DataSource = ""; } dgvWorkPlan.DataBind();
        }
        private XmlNode CreateItemNodeSHold(XmlDocument doc, string enroll) 
        {
            XmlNode node = doc.CreateElement("SalaryHold");

            XmlAttribute Enroll = doc.CreateAttribute("enroll"); Enroll.Value = enroll;
            node.Attributes.Append(Enroll);            
            return node;
        }

        protected void cbSalaryHoldR_CheckedChanged(object sender, EventArgs e)
        {
            ReportDiv.Visible = false;
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        

       

        






    }
}