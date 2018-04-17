using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Collections;
using HR_BLL.TeamBuild;
using UI.ClassFiles;

namespace UI.HR.TeamBuild
{
    public partial class TeamShiftCreation : BasePage
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <04-09-2012>
        Description: <Team and Shift Creation>
        =============================================*/

        #region============Global Variables Are Here===================
        TeamAndShiftInformation teamShift = new TeamAndShiftInformation(); string teamName = ""; string sftName = "";
        TimeSpan startTime; TimeSpan endTime; string rosterEnable; string value = ""; string xmlString = "";
        string station = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();//"2";
        DirectoryInfo dirInfo = new DirectoryInfo("D:\\Team-Shift-XML-Files\\"); string msgStatus = ""; string filePathForXML = "";
        int unitId; int jobStationId; int softwareLoginUserID; string sequenceId; int shiftType;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //LoadGridwithXml();
            }
            filePathForXML = "D://Team-Shift-XML-Files/TeamShift@" + station + ".xml";
        }

        private void ClearControls()
        {
            txtShift.Text = ""; chkRosterEnable.Checked = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            #region ============Create an XMLString and Insert File Into Database===============

            sftName = txtShift.Text; startTime = TimeSpan.Parse(txtStartTime.Date.ToString("HH:mm:ss"));
            endTime = TimeSpan.Parse(txtEndTime.Date.ToString("HH:mm:ss"));
            sequenceId = ddlSequence.SelectedItem.ToString();
            shiftType = int.Parse(ddlShiftType.SelectedValue);
            if (chkRosterEnable.Checked == true) { rosterEnable = "True"; }
            else { rosterEnable = "False"; }
            CreateXml(sftName, startTime.ToString(), endTime.ToString(), sequenceId.ToString(), rosterEnable.ToString(), shiftType.ToString());

            LoadGridwithXml();
            ClearControls();

            #endregion

        }

        private void LoadGridwithXml()
        {
            string validExtensions = "TeamShift@" + station + ".xml";
            string[] extFilter = validExtensions.Split(new char[] { ',' });
            ArrayList files = new ArrayList();
            foreach (string extension in extFilter)
            { files.AddRange(dirInfo.GetFiles(extension)); }
            if (files.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("TeamAndShift");
                xmlString = dSftTm.InnerXml;
                xmlString = "<TeamAndShift>" + xmlString + "</TeamAndShift>";
                //==========Another Way=============
                //DataSet ds = new DataSet();
                //ds.ReadXml(;
                //dgvShiftInfo.DataSource = ds;
                //dgvShiftInfo.DataBind();
                //==========Active Way=============
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvShiftInfo.DataSource = ds;
                dgvShiftInfo.DataBind();
            }
            else
            {
                dgvShiftInfo.DataSource = "";
                dgvShiftInfo.DataBind();
            }
        }

        private void CreateXml(string sftName, string startTime, string endTime, string sequenceId, string rosterEnable, string shiftType)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("TeamAndShift");
                XmlNode addItem = CreateItemNode(doc, sftName, startTime, endTime, sequenceId, rosterEnable, shiftType);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("TeamAndShift");
                XmlNode addItem = CreateItemNode(doc, sftName, startTime, endTime, sequenceId, rosterEnable, shiftType);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string sftName, string startTime, string endTime, string sequenceId, string rosterEnable, string shiftType)
        {
            XmlNode node = doc.CreateElement("teamshift");
            XmlAttribute SftName = doc.CreateAttribute("sftName");
            SftName.Value = sftName;
            XmlAttribute StartTime = doc.CreateAttribute("startTime");
            StartTime.Value = startTime;
            XmlAttribute EndTime = doc.CreateAttribute("endTime");
            EndTime.Value = endTime;
            XmlAttribute SequenceId = doc.CreateAttribute("sequenceId");
            SequenceId.Value = sequenceId;
            XmlAttribute RosterEnable = doc.CreateAttribute("rosterEnable");
            RosterEnable.Value = rosterEnable;
            XmlAttribute ShiftType = doc.CreateAttribute("shiftType");
            ShiftType.Value = shiftType;

            node.Attributes.Append(SftName);
            node.Attributes.Append(StartTime);
            node.Attributes.Append(EndTime);
            node.Attributes.Append(SequenceId);
            node.Attributes.Append(RosterEnable);
            node.Attributes.Append(ShiftType);
            return node;
        }

        public string ReturnData(object sftName, object startTime, object endTime, object rosterEnable)
        {
            string str = "";
            str = sftName.ToString() + ',' + startTime.ToString() + ',' + endTime.ToString() + ',' + rosterEnable.ToString();
            return str;
        }

        protected void dgvShiftInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LoadGridwithXml();
            DataSet dsGrid = (DataSet)dgvShiftInfo.DataSource;
            dsGrid.Tables[0].Rows[dgvShiftInfo.Rows[e.RowIndex].DataItemIndex].Delete();
            dsGrid.WriteXml(filePathForXML);

            DataSet dsGridAfterDelete = (DataSet)dgvShiftInfo.DataSource;
            if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            { File.Delete(filePathForXML); }

            LoadGridwithXml();
        }

        protected void dgvShiftInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvShiftInfo.EditIndex = e.NewEditIndex;
            LoadGridwithXml();
        }

        protected void dgvShiftInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = dgvShiftInfo.Rows[e.RowIndex].DataItemIndex;
            string sftName = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[0].FindControl("txtShift")).Text;
            string startTime = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[1].FindControl("txtStartTime")).Text;
            string endTime = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[2].FindControl("txtEndTime")).Text;
            string enableRoster = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[3].FindControl("txtRoster")).Text;
            dgvShiftInfo.EditIndex = -1;
            LoadGridwithXml();
            DataSet dsUpdate = (DataSet)dgvShiftInfo.DataSource;
            dsUpdate.Tables[0].Rows[index]["sftName"] = sftName;
            dsUpdate.Tables[0].Rows[index]["startTime"] = startTime;
            dsUpdate.Tables[0].Rows[index]["endTime"] = endTime;
            dsUpdate.Tables[0].Rows[index]["rosterEnable"] = enableRoster;
            dsUpdate.WriteXml(filePathForXML);
            LoadGridwithXml();
        }

        protected void dgvShiftInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvShiftInfo.EditIndex = -1;
            LoadGridwithXml();
        }

        protected void btnAddtoDB_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dShiftInfo = doc.SelectSingleNode("TeamAndShift");
                xmlString = dShiftInfo.InnerXml;
                xmlString = "<TeamAndShift>" + xmlString + "</TeamAndShift>";
                unitId = int.Parse(ddlUnit.SelectedValue); jobStationId = int.Parse(ddlJobStation.SelectedValue);
                teamName = txtTeam.Text; softwareLoginUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                if (dgvShiftInfo.Rows.Count > 0)
                {
                    msgStatus = teamShift.InsertTeamShiftInformation(unitId, jobStationId, teamName, xmlString, softwareLoginUserID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    File.Delete(filePathForXML); LoadGridwithXml();
                    txtTeam.Text = "";
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please add atleast single shift.');", true); }
            }
            catch (Exception ex) { /*throw ex;*/ }
        }

    }
}