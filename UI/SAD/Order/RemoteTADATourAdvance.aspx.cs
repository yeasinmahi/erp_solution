using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTADATourAdvance : System.Web.UI.Page
    {

        string filePathForXML;
        string xmlString = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        int intCOAid; int RowIndex;
        protected decimal busfare = 0; protected decimal Rickfare = 0; protected decimal cngfare = 0; protected decimal trainfare = 0;
        protected decimal boatfare = 0; protected decimal othervhfare = 0;

        protected decimal ownda = 0; protected decimal otherda = 0; protected decimal hotel = 0; protected decimal othercost = 0;
        protected decimal rowTotal = 0; protected decimal movDuration = 0;
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADATourAdvance";
        string stop = "stopping SAD\\Order\\RemoteTADATourAdvance";


        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaAdvanceAmount.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
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
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("RemotetadaAdvanceAmount");
                xmlString = dSftTm.InnerXml;
                xmlString = "<RemotetadaAdvanceAmount>" + xmlString + "</RemotetadaAdvanceAmount>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { GridView1.DataSource = ds; }
                else { GridView1.DataSource = ""; }

                GridView1.DataBind();

            }
            catch { }
        }

        private void CreateVoucherXml(string BillDateFrom, string BillDateTo, string fromAddress, string movementAddress, string tourPurpouse,string totalcost,string applicantEnrol)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("RemotetadaAdvanceAmount");
                XmlNode addItem = CreateItemNode(doc, BillDateFrom, BillDateTo, fromAddress, movementAddress, tourPurpouse, totalcost, applicantEnrol);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaAdvanceAmount");
                XmlNode addItem = CreateItemNode(doc, BillDateFrom, BillDateTo, fromAddress, movementAddress, tourPurpouse, totalcost, applicantEnrol);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            Clear();
        }


        private void Clear()
        {

            txtFromAddr.Text = ""; txtMovementArea.Text = ""; txtTourPurpouse.Text = "";
            txtTotal.Text = "";


        }


        private XmlNode CreateItemNode(XmlDocument doc, string BillDateFrom, string BillDateTo, string fromAddress, string movementAddress, string tourPurpouse, string totalcost, string applicantEnrol)
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRBILLDATE = doc.CreateAttribute("BillDateFrom");
            STRBILLDATE.Value = BillDateFrom;
            XmlAttribute MOVDURATION = doc.CreateAttribute("BillDateTo");
            MOVDURATION.Value = BillDateTo;
            XmlAttribute FRMADDR = doc.CreateAttribute("fromAddress");
            FRMADDR.Value = fromAddress;
            XmlAttribute MOVADDR = doc.CreateAttribute("movementAddress");
            MOVADDR.Value = movementAddress;
            XmlAttribute TOADDR = doc.CreateAttribute("tourPurpouse");
            TOADDR.Value = tourPurpouse;
            XmlAttribute TOTALCOST = doc.CreateAttribute("totalcost");
            TOTALCOST.Value = totalcost;
            XmlAttribute APPLICANTENROL = doc.CreateAttribute("applicantEnrol");
            APPLICANTENROL.Value = applicantEnrol;


            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(MOVDURATION);
            node.Attributes.Append(FRMADDR);
            node.Attributes.Append(MOVADDR);
            node.Attributes.Append(TOADDR);
            node.Attributes.Append(TOTALCOST);
            node.Attributes.Append(APPLICANTENROL);
          

            return node;
        }





  
        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grvStudentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Subit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvance TATA Tour advane Add", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string BillDateFrom = txtFromDate.Text;
            string BillDateTo = txtToDate.Text;

            string fromAddress = txtFromAddr.Text;
            string movementAddress = txtMovementArea.Text;
            string tourPurpouse = txtTourPurpouse.Text;
            string totalcost = txtTotal.Text;
            string Aplenrol;
            if (rdbUserOption.SelectedItem.Text == "Other")
            {
                string strSearchKey = txtFullName.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();
                string strCustname = strSearchKey;
                Aplenrol = code;

            }
            else
            {
                hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                Aplenrol = hdnApplicantEnrol.Value;
            }


            if (BillDateFrom == string.Empty || BillDateFrom == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
            }
            else if (BillDateTo == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select to date from calender !')", true);
            }

            else if (fromAddress == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please write From Address !')", true);
            }

            else if (movementAddress == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please write Tour pleaces Address !')", true);
            }

            else if (totalcost == "" || totalcost==string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please write Advance amount !')", true);
            }


            else
            {

                 BillDateFrom = DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd");
                 BillDateTo = DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd");


                 CreateVoucherXml(BillDateFrom, BillDateTo, fromAddress, movementAddress, tourPurpouse, totalcost, Aplenrol);





            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Subit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADATourAdvance TATA Tour advane Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (GridView1.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------
                DateTime dteFromDate = DateTime.Parse(DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd"));
                DateTime dteTodate = DateTime.Parse(DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd"));
                //hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                //Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                if (rdbUserOption.SelectedItem.Text == "Other")
                {
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    string apenroll = code;
                    hdnaplenr.Value = apenroll;
                    Session["apenr"] = hdnaplenr.Value;
                }
                else
                {
                    hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    Session["apenr"] = hdnApplicantEnrol.Value;
                }

                HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                int unit = Convert.ToInt32(HiddenUnit.Value);
                hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                int jobstation = Convert.ToInt32(hdnstation.Value);
                int insertbyenrol = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("RemotetadaAdvanceAmount");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemotetadaAdvanceAmount>" + xmlString + "</RemotetadaAdvanceAmount>";
                    string message = bll.taDaAdanceInsertbyApplicant(xmlString, dteFromDate, dteTodate, int.Parse(HttpContext.Current.Session["apenr"].ToString()), unit, jobstation, insertbyenrol);
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }



                #endregion ------------ Insertion End ----------------


            }
            GridView1.DataBind();
            File.Delete(filePathForXML);
            GridView1.DataSource = "";
            GridView1.DataBind();




            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();










        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)GridView1.DataSource;
                dsGrid.Tables[0].Rows[GridView1.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)GridView1.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); GridView1.DataSource = ""; GridView1.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { } 
        }

        protected void rdbUserOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbUserOption.SelectedItem.Text == "Other")
            {
                txtFullName.Enabled = true;
               
            }
            else
            {
                txtFullName.Enabled = false;
            }

        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
    }
}