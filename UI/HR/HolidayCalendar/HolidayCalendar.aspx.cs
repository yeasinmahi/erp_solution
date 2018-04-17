using HR_BLL.HolidayCalendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.HolidayCalendar
{
    public partial class HolidayCalendar : BasePage
    {
        string filePathForXML; DirectoryInfo dirInfo; 
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/HolidayCalendar/Holiday/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString()+".xml");
            dirInfo = new DirectoryInfo(Server.MapPath("~/HR/HolidayCalendar/Holiday/"));
            if (!IsPostBack)
            { pnlUpperControl.DataBind(); }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlJobStation.DataBind();
        }
        
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGridwithXml();
                int rowindex = int.Parse(((Button)sender).CommandArgument.ToString());
                DataSet dsGrid = (DataSet)dgvholiday.DataSource;
                dsGrid.Tables[0].Rows[dgvholiday.Rows[rowindex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);

                DataSet dsGridAfterDelete = (DataSet)dgvholiday.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); }
                LoadGridwithXml();
            }
            catch { }
        }
        private void LoadGridwithXml()
        {
            string validExtensions = HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml";
            string[] extFilter = validExtensions.Split(new char[] { ',' });
            ArrayList files = new ArrayList();
            foreach (string extension in extFilter)
            { files.AddRange(dirInfo.GetFiles(extension)); }
            if (files.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("HoliDay");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<HoliDay>" + xmlString + "</HoliDay>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvholiday.DataSource = ds;                    
                }
                else
                {
                    dgvholiday.DataSource = "";
                }
            }
            dgvholiday.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    string station = ddlJobStation.SelectedItem.ToString();
                    string stationid = ddlJobStation.SelectedValue.ToString();
                    string group = ddlGroup.SelectedItem.ToString();
                    string groupid = ddlGroup.SelectedValue.ToString();
                    string jtype = ddlJobStatus.SelectedItem.ToString();
                    string jtypeid = ddlJobStatus.SelectedValue.ToString();
                    string fromdte = DateTime.Parse (txtFromDate.Text).ToString("yyyy-MM-dd");
                    string todte = DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd");
                    CreateXml(station, stationid, group, groupid, jtype, jtypeid, fromdte, todte);
                    LoadGridwithXml();   //ClearControls();
                }
                catch { }
           }
        }
        private void CreateXml(string station, string stationid, string group, string groupid, string jtype, string jtypeid, string fromdte, string todte)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("HoliDay");
                XmlNode addItem = CreateItemNode(doc, station, stationid, group, groupid, jtype, jtypeid, fromdte, todte);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("HoliDay");
                XmlNode addItem = CreateItemNode(doc, station, stationid, group, groupid, jtype, jtypeid, fromdte, todte);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string station, string stationid, string group, string groupid, string jtype, string jtypeid, string fromdte, string todte)
        {
            XmlNode node = doc.CreateElement("holidayrow");
            XmlAttribute Station = doc.CreateAttribute("station");
            Station.Value = station;
            XmlAttribute StationID = doc.CreateAttribute("stationid");
            StationID.Value = stationid;
            XmlAttribute Group = doc.CreateAttribute("group");
            Group.Value = group;
            XmlAttribute GroupID = doc.CreateAttribute("groupid");
            GroupID.Value = groupid;
            XmlAttribute Jtype = doc.CreateAttribute("jtype");
            Jtype.Value = jtype;
            XmlAttribute JtypeID = doc.CreateAttribute("jtypeid");
            JtypeID.Value = jtypeid;
            XmlAttribute FromDate = doc.CreateAttribute("fromdte");
            FromDate.Value = fromdte;
            XmlAttribute ToDate = doc.CreateAttribute("todte");
            ToDate.Value = todte;

            node.Attributes.Append(Station);
            node.Attributes.Append(StationID);
            node.Attributes.Append(Group);
            node.Attributes.Append(GroupID);
            node.Attributes.Append(Jtype);
            node.Attributes.Append(JtypeID);
            node.Attributes.Append(FromDate);
            node.Attributes.Append(ToDate);
            return node; 
        }
        private void ClearControls()
        {
            txtFromDate.Text = ""; txtToDate.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("HoliDay");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<HoliDay>" + xmlString + "</HoliDay>";
                int userID = int.Parse(Session[SessionParams.USER_ID].ToString());
                if (dgvholiday.Rows.Count > 0)
                {
                    HolidaySetup holiday = new HolidaySetup();
                    string msgStatus = holiday.InsertHolidayInformation(xmlString, int.Parse(ddlHoliday.SelectedValue.ToString()), userID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    File.Delete(filePathForXML); LoadGridwithXml();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to insertion.');", true); }
            }
            catch { }
        }































    }
}