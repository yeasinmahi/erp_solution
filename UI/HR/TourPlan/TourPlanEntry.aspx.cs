using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{
    public partial class TourPlanEntry : BasePage
    {
        string filePathForXML;
        string xmlString = "";
        string alreasons="";
        DataTable dt = new DataTable();
        HR_BLL.TourPlan.TourPlanning bll = new TourPlanning();
        protected void Page_Load(object sender, EventArgs e)
        {
            //pnlUpperControl.DataBind();
        
            filePathForXML = Server.MapPath("~/HR/TourPlan/Tour/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteTourPlan.xml");
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
               
                try { File.Delete(filePathForXML); }
                catch { }
            }
            else
            {
                lblrcd.Text = "";
            }
       
            hdnApplicantEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
            dt = bll.getEmployeeinfo(enroll);
            if (dt.Rows.Count > 0) { txtUnitName.Text = dt.Rows[0][0].ToString(); }
            else { txtUnitName.Text = "NA"; }
            if (dt.Rows.Count > 0) { txtName.Text = dt.Rows[0][1].ToString(); }
            else { txtName.Text = "NA"; }
            if (dt.Rows.Count > 0) { txtDesignation.Text = dt.Rows[0][2].ToString(); }
            else { txtDesignation.Text = "NA"; }
            if (dt.Rows.Count > 0) { txtEnrol.Text = dt.Rows[0][3].ToString(); }
            else { txtEnrol.Text = "NA"; }
           

            txtLunchBreak1.Text = "1:00 Pm - 1:30 Pm";
            txtPrayerBreak1.Text = "1:30 Pm - 2:00 Pm";
            txtPrayerBreak2.Text = "4:30 Pm - 4:45 Pm";

            if (uxVisibilityScopeCheckBoxList.Items.Count == 0)
            {
                uxVisibilityScopeCheckBoxList.Items.Add("Market visit");
                uxVisibilityScopeCheckBoxList.Items.Add("Sales Meeting");
                uxVisibilityScopeCheckBoxList.Items.Add("Sales Conference");
                uxVisibilityScopeCheckBoxList.Items.Add("Client Meeting");
                uxVisibilityScopeCheckBoxList.Items.Add("Market Analysis");
                uxVisibilityScopeCheckBoxList.Items.Add("Sales Monitoring");
            }
          

        }

        protected void uxVisibilityScopeCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = uxVisibilityScopeCheckBoxList.Items.Count;
          
            for (int i = 0; i < a; i++)
            {
                if (uxVisibilityScopeCheckBoxList.Items[i].Selected == true)
                {
                    if (lblrcd.Text.Length == 0)
                    {
                        lblrcd.Text = uxVisibilityScopeCheckBoxList.Items[i].ToString();
                    }
                    else
                    {
                    lblrcd.Text = lblrcd.Text + "," + uxVisibilityScopeCheckBoxList.Items[i].ToString();
                    }
                }
                alreasons = lblrcd.Text;
                Session["alreasons"] = alreasons;
            }
 }

        protected void rdbTourType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbTourType.SelectedItem.Text == "HQ") { drdlNightStay.Enabled = false; }
            else { drdlNightStay.Enabled = true; }
        }

        protected void btnSubmitTourPlan_Click(object sender, EventArgs e)
        {
            if (grdvTourPlanEntry.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------


                hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
             
                HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                int unit = Convert.ToInt32(HiddenUnit.Value);
                hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                int jobstation = Convert.ToInt32(hdnstation.Value);
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteTourPlan");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteTourPlan>" + xmlString + "</RemoteTourPlan>";
                    string message = bll.TourplaninfoInsertByApplicant(xmlString, enroll, unit, jobstation);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }



                #endregion ------------ Insertion End ----------------


            }
            grdvTourPlanEntry.DataBind();
            File.Delete(filePathForXML);
            grdvTourPlanEntry.DataSource = "";
            grdvTourPlanEntry.DataBind();
      }
        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("RemoteTourPlan");
                xmlString = dSftTm.InnerXml;
                xmlString = "<RemoteTourPlan>" + xmlString + "</RemoteTourPlan>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvTourPlanEntry.DataSource = ds; }
                else { grdvTourPlanEntry.DataSource = ""; }
                grdvTourPlanEntry.DataBind();
            }
            catch { }

        }
        private void CreateVoucherXml(string tourTypeid, string nightstay, string fromdate, string todate, string starttime, string endtime, string visitedarea, string reasons,string TourTypename
            , string OtherReasons, string TerritoryID, string Pointid, string RouteID, string Zoneid, string TerritoryName, string Point, string Route, string Zone)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("RemoteTourPlan");
                XmlNode addItem = CreateItemNode(doc, tourTypeid, nightstay, fromdate, todate, starttime, endtime, visitedarea, reasons, TourTypename
                     , OtherReasons, TerritoryID, Pointid, RouteID, Zoneid, TerritoryName, Point, Route,Zone 
                    );
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteTourPlan");
                XmlNode addItem = CreateItemNode(doc, tourTypeid, nightstay, fromdate, todate, starttime, endtime, visitedarea, reasons, TourTypename
                     , OtherReasons, TerritoryID, Pointid, RouteID, Zoneid, TerritoryName, Point,Route, Zone
                    );
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            //Clear();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string tourTypeid, string nightstay, string fromdate, string todate, string starttime, string endtime, string visitedarea, string reasons, string TourTypename
            , string OtherReasons, string TerritoryID, string Pointid, string RouteID, string Zoneid, string TerritoryName, string Point, string Route, string Zone 
            )
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRTOURTYPEID = doc.CreateAttribute("tourTypeid");
            STRTOURTYPEID.Value = tourTypeid;

            XmlAttribute STRNIGHSTAY = doc.CreateAttribute("nightstay");
            STRNIGHSTAY.Value = nightstay;
            XmlAttribute STRFROMDATE = doc.CreateAttribute("fromdate");
            STRFROMDATE.Value = fromdate;
            XmlAttribute STRTODATE = doc.CreateAttribute("todate");
            STRTODATE.Value = todate;
            XmlAttribute STRSTARTTIME = doc.CreateAttribute("starttime");
            STRSTARTTIME.Value = starttime;
            XmlAttribute STRENDTIME = doc.CreateAttribute("endtime");
            STRENDTIME.Value = endtime;
            XmlAttribute STRVISITEDAREA = doc.CreateAttribute("visitedarea");
            STRVISITEDAREA.Value = visitedarea;
            XmlAttribute STRREASONS = doc.CreateAttribute("reasons");
            STRREASONS.Value = reasons;
            XmlAttribute STRTOURTYPENAME = doc.CreateAttribute("TourTypename");
            STRTOURTYPENAME.Value = TourTypename;
            XmlAttribute STROTHERREASONS = doc.CreateAttribute("OtherReasons");
            STROTHERREASONS.Value = OtherReasons;
            XmlAttribute STRTERRITORYID = doc.CreateAttribute("TerritoryID");
            STRTERRITORYID.Value = TerritoryID;
            XmlAttribute STRPOINTID = doc.CreateAttribute("Pointid");
            STRPOINTID.Value = Pointid;
            XmlAttribute STRROUTEID = doc.CreateAttribute("RouteID");
            STRROUTEID.Value = RouteID;
            XmlAttribute STRZONEID = doc.CreateAttribute("Zoneid");
            STRZONEID.Value = Zoneid;
            XmlAttribute STRTERRITORYNAME = doc.CreateAttribute("TerritoryName");
            STRTERRITORYNAME.Value = TerritoryName;
            XmlAttribute STRPOINTNAME = doc.CreateAttribute("Point");
            STRPOINTNAME.Value = Point;
            XmlAttribute STRROUTE = doc.CreateAttribute("Route");
            STRROUTE.Value = Route;
            XmlAttribute STRZONENEAME = doc.CreateAttribute("Zone");
            STRZONENEAME.Value = Zone;

            node.Attributes.Append(STRTOURTYPEID);
            node.Attributes.Append(STRNIGHSTAY);
            node.Attributes.Append(STRFROMDATE);
            node.Attributes.Append(STRTODATE);
            node.Attributes.Append(STRSTARTTIME);
            node.Attributes.Append(STRENDTIME);
            node.Attributes.Append(STRVISITEDAREA);
            node.Attributes.Append(STRREASONS);
            node.Attributes.Append(STRTOURTYPENAME);
            node.Attributes.Append(STROTHERREASONS);
            node.Attributes.Append(STRTERRITORYID);
            node.Attributes.Append(STRPOINTID);
            node.Attributes.Append(STRROUTEID);
            node.Attributes.Append(STRZONEID);
            node.Attributes.Append(STRTERRITORYNAME);
            node.Attributes.Append(STRPOINTNAME);
            node.Attributes.Append(STRROUTE);
            node.Attributes.Append(STRZONENEAME);

            return node;
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string tourType = rdbTourType.SelectedValue.ToString();
            //string nighstay = txtNightStay.Text;
            string nighstay = drdlNightStay.SelectedItem.ToString();
            string TourStartDate = txtFromDate.Text;
            string TourEndDate = txtToDate.Text;
            TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
            TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
           string starttime =Convert.ToString(tmstart.ToString());
           string endtime = Convert.ToString(tmend.ToString());
           string VisitedArea = txtVisitedArea.Text;

           string Reason =Convert.ToString(Session["alreasons"].ToString());
            if (Reason.Length <= 0) { Reason = "Notfound"; }

            if (rdbTourType.SelectedItem.Text == "In-Station") { tourType = "0"; }
            else tourType = "1";

            if (nighstay.Length <= 0) { nighstay = "NA"; }
            if (VisitedArea.Length <= 0) { VisitedArea = "NA"; }
            if (Reason.Length <= 0) { Reason = "NA"; }
            string tourTypename = rdbTourType.SelectedItem.Text;
            if (tourTypename.Length < 0) { tourTypename="NA";}
            string OtherReasons = txtOtherReason.Text;
            if(OtherReasons.Length<0){OtherReasons="NA";}
            string TerritoryID;
            try { TerritoryID = (drdlTerritory.SelectedValue.ToString()); }
            catch { TerritoryID = "0"; }
            
            
            string Pointid;
            try {Pointid = (drdlPoint.SelectedValue.ToString()); }
            catch { Pointid = "0"; }
        
           
            string RouteID;
            try { RouteID = (drdlRoute.SelectedValue.ToString()); }
            catch { RouteID = "0"; }
           
            string Zoneid;
            try { Zoneid = (drdlZone.SelectedValue.ToString()); }
            catch { Zoneid = "0"; }
           
            string TerritoryName;
            try {TerritoryName = drdlTerritory.SelectedItem.Text.ToString(); }
            catch { TerritoryName = "NA"; }

            
            string Point;
            try
            {
                Point = drdlPoint.SelectedItem.ToString();

            }
            catch
            {
                Point = "NA";
            }

            string Route;
            try { Route = drdlRoute.SelectedItem.Text.ToString(); }
            catch { Route = "NA"; }
            string Zone;
            try { Zone = drdlZone.SelectedItem.Text.ToString(); }
            catch { Zone = "NA"; }
             
          
            CreateVoucherXml(tourType, nighstay, TourStartDate, TourEndDate, starttime, endtime, VisitedArea, Reason, tourTypename
                 , OtherReasons, TerritoryID, Pointid, RouteID, Zoneid, TerritoryName, Point, Route, Zone);
        }

        protected void grdvTourPlanEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void grdvTourPlanEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvTourPlanEntry.DataSource;
                dsGrid.Tables[0].Rows[grdvTourPlanEntry.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)grdvTourPlanEntry.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); grdvTourPlanEntry.DataSource = ""; grdvTourPlanEntry.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void btnAddHotel_Click(object sender, EventArgs e)
        {

        }

        protected void Complete_Click(object sender, EventArgs e)
        {
           
            char[] delimiterChars = { '^' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] datas = temp.Split(delimiterChars);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('" + datas[0].ToString() + "');", true);
         }
    }
}