using Flogging.Core;
using GLOBAL_BLL;
using HR_BLL.TourPlan;
using Purchase_BLL.VehicleRegRenewal_BLL;
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

namespace UI.Asset
{
    public partial class Assetinformation : System.Web.UI.Page
    {
        TourPlanning bll = new TourPlanning(); DataTable dt = new DataTable();
        RegistrationRenewals_BLL bllaset = new RegistrationRenewals_BLL();
        string filePathForXML; string serial;
        string xmlString = "";
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\Assetinformation";
        string stop = "stopping Asset\\Assetinformation";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Asset/Data/Assetinformation_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }
        }
        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("AssetInformation");
                xmlString = dSftTm.InnerXml;
                xmlString = "<AssetInformation>" + xmlString + "</AssetInformation>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvassetinfo.DataSource = ds; }
                else { grdvassetinfo.DataSource = ""; }

                grdvassetinfo.DataBind();

            }
            catch { }
        }
        private void CreateVoucherXml( string dagcs, string dagsa, string dagrs, string dagbrs, string khatiancs, string khatiansa, string khatianrs, string khatianbrs)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("AssetInformation");
                XmlNode addItem = CreateItemNode(doc, dagcs, dagsa, dagrs, dagbrs, khatiancs, khatiansa, khatianrs, khatianbrs);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("AssetInformation");
                XmlNode addItem = CreateItemNode(doc, dagcs, dagsa, dagrs, dagbrs, khatiancs, khatiansa, khatianrs, khatianbrs);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            Clear();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string dagcs, string dagsa, string dagrs, string dagbrs, string khatiancs, string khatiansa, string khatianrs, string khatianbrs)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Dagcs = doc.CreateAttribute("dagcs");
            Dagcs.Value = dagcs;
            XmlAttribute Dagsa = doc.CreateAttribute("dagsa");
            Dagsa.Value = dagsa;
            XmlAttribute Dagrs = doc.CreateAttribute("dagrs");
            Dagrs.Value = dagrs;
            XmlAttribute Dagbrs = doc.CreateAttribute("dagbrs");
            Dagbrs.Value = dagbrs;

            XmlAttribute Khatiancs = doc.CreateAttribute("khatiancs");
            Khatiancs.Value = khatiancs;
            XmlAttribute Khatiansa = doc.CreateAttribute("khatiansa");
            Khatiansa.Value = khatiansa;
            XmlAttribute Khatianrs = doc.CreateAttribute("khatianrs");
            Khatianrs.Value = khatianrs;
            XmlAttribute Khatianbrs = doc.CreateAttribute("khatianbrs");
            Khatianbrs.Value = khatianbrs;

            node.Attributes.Append(Dagcs);
            node.Attributes.Append(Dagsa);
            node.Attributes.Append(Dagrs);
            node.Attributes.Append(Dagbrs);
            node.Attributes.Append(Khatiancs);
            node.Attributes.Append(Khatiansa);
            node.Attributes.Append(Khatianrs);
            node.Attributes.Append(Khatianbrs);
            return node;
        }
        private void Clear()
        {

            //txtdagcs.Text = "";
            txtdagsa.Text = ""; txtdagrs.Text = ""; txtdagbrs.Text = "";
            txtkhatiancs.Text = ""; txtkhatiansa.Text = ""; txtkhatianrs.Text = ""; txtkhatianbrs.Text = "";

        }

      

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Add", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\AssetCheckReceive Add", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (hdnconfirm.Value == "1")
            {

            string strdagcs = txtdagcs.Text;
            string strdagsa = txtdagsa.Text;
            string strdagrs = txtdagrs.Text;
            string strdagbrs= txtdagbrs.Text;
            string strkhatiancs = txtkhatiancs.Text;
            string strkhatiansa = txtkhatiansa.Text;
            string strkhatianrs = txtkhatianrs.Text;
            string strkhatianbrs = txtkhatianbrs.Text;
            if (strdagcs.Length <= 0) { strdagcs = "0"; }
            if (strdagsa.Length <= 0) { strdagsa = "0"; }
            if (strdagrs.Length <= 0) { strdagrs = "0"; }
            if (strdagbrs.Length <= 0) { strdagbrs = "0"; }
            if (strkhatiancs.Length <= 0) { strkhatiancs = "0"; }
            if (strkhatiansa.Length <= 0) { strkhatiansa = "0"; }
            if (strkhatianrs.Length <= 0) { strkhatianrs = "0"; }
            if (strkhatianbrs.Length <= 0) { strkhatianbrs = "0"; }
             CreateVoucherXml(strdagcs, strdagsa, strdagrs, strdagbrs, strkhatiancs, strkhatiansa, strkhatianrs, strkhatianbrs);
            }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Add", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Add", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();


        }

        protected void grdvassetinfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvassetinfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvassetinfo.DataSource;
                dsGrid.Tables[0].Rows[grdvassetinfo.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)grdvassetinfo.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); grdvassetinfo.DataSource = ""; grdvassetinfo.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void txtone_TextChanged(object sender, EventArgs e)
        {
            //DataRow[] foundAuthors = tbl.Select("Author = '" + searchAuthor + "'");
            //if (foundAuthors.Length != 0)
            //{
            //    // do something...
            //}
           

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Asset\\Assetinformation Submit", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    if (grdvassetinfo.Rows.Count > 0)
                {
                    #region ------------ Insert into dataBase -----------


                    hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);

                    HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                    int unit = Convert.ToInt32(HiddenUnit.Value);
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    int jobstation = Convert.ToInt32(hdnstation.Value);
                    XmlDocument doc = new XmlDocument();
                    string assetid = "123";

                    try
                    {
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("AssetInformation");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<AssetInformation>" + xmlString + "</AssetInformation>";
                        string message = bllaset.FixedDataLandInfoinsert(xmlString, enroll, unit, jobstation, assetid);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }

                    catch
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                    }



                    #endregion ------------ Insertion End ----------------


                }
                grdvassetinfo.DataBind();
                File.Delete(filePathForXML);
                grdvassetinfo.DataSource = "";
                grdvassetinfo.DataBind();

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
        }
    }
}