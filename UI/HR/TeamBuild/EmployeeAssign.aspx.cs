using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using HR_BLL.Global;
using System.Data;
using System.IO;
using System.Collections;
using System.Xml;
using HR_BLL.TeamBuild;
using UI.ClassFiles;


namespace UI.HR.TeamBuild
{

    public partial class EmployeeAssign : BasePage //System.Web.UI.Page
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <06-09-2012>
        Description: <Employee Assign in Shift and Team>
        =============================================*/

        #region============Global Variables Are Here===================
        TeamAndShiftInformation teamShift = new TeamAndShiftInformation();
        string empName = ""; string empCode = ""; string sftName = ""; string team = ""; int softwareLoginUserID; string xmlString = "";
        string station = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
        DirectoryInfo dirInfo = new DirectoryInfo("D:\\Team-Shift-XML-Files\\"); string msgStatus = ""; string filePathForXML = "";
        int stationID; int teamID; int shiftID;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtSearchEmp.Attributes.Add("onkeyUp", "SearchText();");
            }
            filePathForXML = "D://Team-Shift-XML-Files/EmployeeAssignInShift@" + station + ".xml";
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData//(11754, 2, strSearchKey);
            (int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        private void ClearControls()
        {
            txtSearchEmp.Text = "";
        }

        private void LoadGridwithXml()
        {
            try
            {
                string validExtensions = "EmployeeAssignInShift@" + station + ".xml";
                string[] extFilter = validExtensions.Split(new char[] { ',' });
                ArrayList files = new ArrayList();
                foreach (string extension in extFilter)
                { files.AddRange(dirInfo.GetFiles(extension)); }
                if (files.Count > 0)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("AssignTeamAndShift");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<AssignTeamAndShift>" + xmlString + "</AssignTeamAndShift>";
                    StringReader sr = new StringReader(xmlString);
                    DataSet ds = new DataSet();
                    ds.ReadXml(sr);
                    dgvAssignedEmployee.DataSource = ds;
                    dgvAssignedEmployee.DataBind();
                }
                else
                {
                    dgvAssignedEmployee.DataSource = "";
                    dgvAssignedEmployee.DataBind();
                }
            }
            catch { }
        }

        protected void dgvAssignedEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LoadGridwithXml();
            DataSet dsGrid = (DataSet)dgvAssignedEmployee.DataSource;
            dsGrid.Tables[0].Rows[dgvAssignedEmployee.Rows[e.RowIndex].DataItemIndex].Delete();
            dsGrid.WriteXml(filePathForXML);

            DataSet dsGridAfterDelete = (DataSet)dgvAssignedEmployee.DataSource;
            if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            { File.Delete(filePathForXML); }

            LoadGridwithXml();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            #region ============Create an XMLString and Insert File Into Database===============
            string nameCode = txtSearchEmp.Text;
            string[] spltData = nameCode.Split(',');
            empName = spltData[0].ToString(); empCode = spltData[1].ToString();
            sftName = ddlShift.SelectedItem.ToString(); team = ddlTeam.SelectedItem.ToString();
            stationID = int.Parse(ddlJobStation.SelectedValue.ToString());
            teamID = int.Parse(ddlTeam.SelectedValue.ToString());
            shiftID = int.Parse(ddlShift.SelectedValue.ToString());
            CreateXml(empName, empCode, sftName, team, stationID.ToString(), teamID.ToString(), shiftID.ToString());

            LoadGridwithXml();
            ClearControls();

            #endregion
        }

        private void CreateXml(string empName, string empCode, string sftName, string team, string stationID, string teamID, string shiftID)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("AssignTeamAndShift");
                XmlNode addItem = CreateItemNode(doc, empName, empCode, sftName, team, stationID, teamID, shiftID);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("AssignTeamAndShift");
                XmlNode addItem = CreateItemNode(doc, empName, empCode, sftName, team, stationID, teamID, shiftID);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string empName, string empCode, string sftName, string team, string stationID, string teamID, string shiftID)
        {
            XmlNode node = doc.CreateElement("assignedshift");
            XmlAttribute EmpName = doc.CreateAttribute("empName");
            EmpName.Value = empName;
            XmlAttribute EmpCode = doc.CreateAttribute("empCode");
            EmpCode.Value = empCode;
            XmlAttribute SftName = doc.CreateAttribute("sftName");
            SftName.Value = sftName;
            XmlAttribute TeamName = doc.CreateAttribute("team");
            TeamName.Value = team;
            //=======================
            XmlAttribute StationId = doc.CreateAttribute("stationID");
            StationId.Value = stationID;
            XmlAttribute TeamID = doc.CreateAttribute("teamID");
            TeamID.Value = teamID;
            XmlAttribute ShiftID = doc.CreateAttribute("shiftID");
            ShiftID.Value = shiftID;


            node.Attributes.Append(EmpName);
            node.Attributes.Append(EmpCode);
            node.Attributes.Append(SftName);
            node.Attributes.Append(TeamName);
            node.Attributes.Append(StationId);
            node.Attributes.Append(TeamID);
            node.Attributes.Append(ShiftID);
            return node;
        }

        protected void btnAddtoDB_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dAssignInfo = doc.SelectSingleNode("AssignTeamAndShift");
                xmlString = dAssignInfo.InnerXml;
                xmlString = "<AssignTeamAndShift>" + xmlString + "</AssignTeamAndShift>";
                softwareLoginUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                if (dgvAssignedEmployee.Rows.Count > 0)
                {
                    msgStatus = teamShift.InsertAssignedShiftInformation(xmlString, softwareLoginUserID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    File.Delete(filePathForXML); LoadGridwithXml();
                    ClearControls();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please add atleast single information.');", true); }
            }
            catch (Exception ex) { throw ex; }
        }

    }
}