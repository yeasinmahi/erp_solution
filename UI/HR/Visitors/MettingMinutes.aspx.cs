using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using HR_BLL.Visitors;
using UI.ClassFiles;

namespace UI.HR.Visitors
{
    public partial class MettingMinutes : BasePage
    {
        MeetingMinutes minutes = new MeetingMinutes();
        DataTable meeting = new DataTable();
        MeetingMinutes rpt = new MeetingMinutes();
       
        string filePathForXMLAttend;
        string filePathForXMLAgenda;
        string filePathForXMLDecissions;
        string filePathForXMLNextMetting;

        string xmlStringAttend = "";
        string xmlStringAgenda = "";
        string xmlStringDecissions = "";
        string xmlStringNextMetting = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());
            //string strEnroll = Convert.ToString("32897".ToString());



            filePathForXMLAttend = Server.MapPath("Attend" + strEnroll + ".xml");
            filePathForXMLAgenda = Server.MapPath("Agenda" + strEnroll + ".xml");
            filePathForXMLDecissions = Server.MapPath("Decissions" + strEnroll + ".xml");
            filePathForXMLNextMetting = Server.MapPath("NextMetting" + strEnroll + ".xml");
            if (!IsPostBack)
            {


                pnlUpperControl.DataBind();
                try { File.Delete(filePathForXMLAttend); }
                catch { }
                try { File.Delete(filePathForXMLAgenda); }
                catch { }
                try { File.Delete(filePathForXMLDecissions); }
                catch { }
                try { File.Delete(filePathForXMLNextMetting); }
                catch { }

            }
            LoadGridwithXmlAttend();
            LoadGridwithXmlAgenda();
            LoadGridwithXmlDecissions();
            LoadGridwithXmlNextMetting();
        }

        protected void BtnAtend_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string pattend = TxtPersonAttn.Text.ToString();

            CreateVoucherXmlAttend(pattend);
        }

        private void CreateVoucherXmlAttend(string pattend)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAttend))
            {
                doc.Load(filePathForXMLAttend);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeAttend(doc, pattend);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeAttend(doc, pattend);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAttend);
            LoadGridwithXmlAttend();
        }

        private void LoadGridwithXmlAttend()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLAttend);
                XmlNode dSftTmz = doc.SelectSingleNode("voucher");
                xmlStringAttend = dSftTmz.InnerXml;
                xmlStringAttend = "<voucher>" + xmlStringAttend + "</voucher>";
                StringReader sr = new StringReader(xmlStringAttend);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgv.DataSource = ds; }

                else { dgv.DataSource = ""; }
                dgv.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeAttend(XmlDocument doc, string pattend)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Pattend = doc.CreateAttribute("pattend");
            Pattend.Value = pattend;

            node.Attributes.Append(Pattend);


            return node;
        }

        protected void BtnAgenda_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string agendaname = TxtAgenda.Text.ToString();
            string presentername = TxtPresenter.Text.ToString();
            string timeallot = TxtAlloted.Text.ToString();
            CreateVoucherXmlAgenda(agendaname, presentername, timeallot);
        }

        private void CreateVoucherXmlAgenda(string agendaname, string presentername, string timeallot)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAgenda))
            {
                doc.Load(filePathForXMLAgenda);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeAgenda(doc, agendaname, presentername, timeallot);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeAgenda(doc, agendaname, presentername, timeallot);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAgenda);
            LoadGridwithXmlAgenda();
        }

        private void LoadGridwithXmlAgenda()
        {
            try
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(filePathForXMLAgenda);
                XmlNode dSftTm = doc2.SelectSingleNode("voucher");
                xmlStringAgenda = dSftTm.InnerXml;
                xmlStringAgenda = "<voucher>" + xmlStringAgenda + "</voucher>";
                StringReader sr= new StringReader(xmlStringAgenda);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgv2.DataSource = ds; }

                else { dgv2.DataSource = ""; }
                dgv2.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeAgenda(XmlDocument doc, string agendaname, string presentername, string timeallot)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Agendaname = doc.CreateAttribute("agendaname");
            Agendaname.Value = agendaname;
            XmlAttribute Presentername = doc.CreateAttribute("presentername");
            Presentername.Value = presentername;
            XmlAttribute Timeallot = doc.CreateAttribute("timeallot");
            Timeallot.Value = timeallot;


            node.Attributes.Append(Agendaname);

            node.Attributes.Append(Presentername);
            node.Attributes.Append(Timeallot);
            return node;
        }

        protected void BtnDecissions_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string decission1 = TxtDecssions1.Text.ToString();
            //string decission2 = TxtDecssions2.Text.ToString();
            //string decission3 = TxtDecssions3.Text.ToString();
            CreateVoucherXmlDecissions(decission1);
        }

        private void CreateVoucherXmlDecissions(string decission1)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDecissions))
            {
                doc.Load(filePathForXMLDecissions);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeDecissions(doc, decission1);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeDecissions(doc, decission1);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDecissions);
            LoadGridwithXmlDecissions();
        }

        private void LoadGridwithXmlDecissions()
        {
            try
            {
                XmlDocument doc3 = new XmlDocument();
                doc3.Load(filePathForXMLDecissions);
                XmlNode dSftTm = doc3.SelectSingleNode("voucher");
                xmlStringDecissions = dSftTm.InnerXml;
                xmlStringDecissions = "<voucher>" + xmlStringDecissions + "</voucher>";
                StringReader sr = new StringReader(xmlStringDecissions);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgv3.DataSource = ds; }

                else { dgv3.DataSource = ""; }
                dgv3.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeDecissions(XmlDocument doc, string decission1)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Decission1 = doc.CreateAttribute("decission1");
            Decission1.Value = decission1;


            node.Attributes.Append(Decission1);


            return node;
        }

        protected void BtnNextMetting_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string dtenextmet = TxtDteNextmet.Text.ToString();
            string nextmettime = (string.Format("{0}:{1}:{2} {3}", TimeSelector4.Hour, TimeSelector4.Minute, TimeSelector4.Second, TimeSelector4.AmPm));
            
            string nextagenda = TxtNextAgenda.Text.ToString();
            string nextparticipant = TxtParticipants.Text.ToString();

            CreateVoucherXmlNextMetting(dtenextmet,nextmettime, nextagenda, nextparticipant);
        }

        private void CreateVoucherXmlNextMetting(string dtenextmet, string nextmettime, string nextagenda, string nextparticipant)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLNextMetting))
            {
                doc.Load(filePathForXMLNextMetting);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeNextMetting(doc, dtenextmet, nextmettime, nextagenda, nextparticipant);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeNextMetting(doc, dtenextmet, nextmettime, nextagenda, nextparticipant);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLNextMetting);
            LoadGridwithXmlNextMetting();

        }

        private void LoadGridwithXmlNextMetting()
        {
            try
            {
                XmlDocument doc4 = new XmlDocument();
                doc4.Load(filePathForXMLNextMetting);
                XmlNode dSftTm = doc4.SelectSingleNode("voucher");
                xmlStringNextMetting = dSftTm.InnerXml;
                xmlStringNextMetting = "<voucher>" + xmlStringNextMetting + "</voucher>";
                StringReader sr = new StringReader(xmlStringNextMetting);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgv4.DataSource = ds; }

                else { dgv4.DataSource = ""; }
                dgv4.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeNextMetting(XmlDocument doc, string dtenextmet,string nextmettime , string nextagenda, string nextparticipant)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute Dtenextmet = doc.CreateAttribute("dtenextmet");
            Dtenextmet.Value = dtenextmet;
            XmlAttribute Nextmettime = doc.CreateAttribute("nextmettime");
            Nextmettime.Value = nextmettime;
           
            XmlAttribute Nextagenda = doc.CreateAttribute("nextagenda");
            Nextagenda.Value = nextagenda;
            XmlAttribute Nextparticipant = doc.CreateAttribute("nextparticipant");
            Nextparticipant.Value = nextparticipant;


            node.Attributes.Append(Dtenextmet);
            node.Attributes.Append(Nextmettime);

           
            node.Attributes.Append(Nextagenda);
            node.Attributes.Append(Nextparticipant);
            return node;
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXmlAttend();
                DataSet dsGrid = (DataSet)dgv.DataSource;
                dsGrid.Tables[0].Rows[dgv.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLAttend);
                DataSet dsGridAfterDelete = (DataSet)dgv.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLAttend); dgv.DataSource = ""; dgv.DataBind(); }
                else { LoadGridwithXmlAttend(); }
            }

            catch { }


        }

        protected void dgv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXmlAgenda();
                DataSet dsGrid = (DataSet)dgv2.DataSource;
                dsGrid.Tables[0].Rows[dgv2.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLAgenda);
                DataSet dsGridAfterDelete = (DataSet)dgv2.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLAgenda); dgv.DataSource = ""; dgv2.DataBind(); }
                else { LoadGridwithXmlAgenda(); }
            }

            catch { }


        }

        protected void dgv3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXmlDecissions();
                DataSet dsGrid = (DataSet)dgv3.DataSource;
                dsGrid.Tables[0].Rows[dgv3.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDecissions);
                DataSet dsGridAfterDelete = (DataSet)dgv3.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLDecissions); dgv.DataSource = ""; dgv3.DataBind(); }
                else { LoadGridwithXmlDecissions(); }
            }

            catch { }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            
            string mettingtitle = TxtMinuts.Text;
            string meetinginfo = TxtMetInfo.Text;
            DateTime dtemetdate = DateTime.Parse(txtDte.Text);
            DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));

            DateTime starttime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector2.Hour, TimeSelector2.Minute, TimeSelector2.Second, TimeSelector2.AmPm));
            DateTime endtime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector3.Hour, TimeSelector3.Minute, TimeSelector3.Second, TimeSelector3.AmPm));
            string location = TxtLocation.Text;
            string calledby = TxtCalled.Text;
            string reffno = TxtReffNo.Text;





          

            string pattend = TxtPersonAttn.Text.ToString();
            string agendaname = TxtAgenda.Text.ToString();
            string objective = TxtObjective.Text.ToString();
            string presentername = TxtPresenter.Text.ToString();
            string timeallot = TxtAlloted.Text.ToString();
            string decission1 = TxtDecssions1.Text.ToString();
            string nextmettime = (string.Format("{0}:{1}:{2} {3}", TimeSelector4.Hour, TimeSelector4.Minute, TimeSelector4.Second, TimeSelector4.AmPm));
            string dtenextmet = Convert.ToString(TxtDteNextmet.Text.ToString());
            string nextagenda = TxtNextAgenda.Text.ToString();
            string nextparticipant = TxtParticipants.Text.ToString();

            if (dgv.Rows.Count > 0)
            {
                
                XmlDocument doc = new XmlDocument();
                XmlDocument doc2 = new XmlDocument();
                XmlDocument doc3 = new XmlDocument();
                XmlDocument doc4 = new XmlDocument();


                doc.Load(filePathForXMLAttend);
                doc2.Load(filePathForXMLAgenda);
                doc3.Load(filePathForXMLDecissions);
                doc4.Load(filePathForXMLNextMetting);


                string msg = rpt.MeetingMinutesXMLInsert(mettingtitle, meetinginfo, dtemetdate, time, location, starttime, endtime, calledby, reffno, objective, xmlStringAttend, xmlStringAgenda, xmlStringDecissions, xmlStringNextMetting, intenroll, intunitid);
              
               

                File.Delete(filePathForXMLAttend); dgv.DataSource = ""; dgv.DataBind(); LoadGridwithXmlAttend();
                File.Delete(filePathForXMLAgenda); dgv2.DataSource = ""; dgv2.DataBind(); LoadGridwithXmlAgenda();
               File.Delete(filePathForXMLDecissions); dgv3.DataSource = ""; dgv3.DataBind(); LoadGridwithXmlDecissions();
               File.Delete(filePathForXMLNextMetting); dgv4.DataSource = ""; dgv4.DataBind(); LoadGridwithXmlNextMetting();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                TxtMinuts.Text="";
                TxtMetInfo.Text="";
                TxtLocation.Text="";
                TxtCalled.Text="";
                TxtReffNo.Text="";
                TxtPersonAttn.Text="";
                TxtAgenda.Text="";
                TxtPresenter.Text="";
                TxtAlloted.Text="";
               TxtDecssions1.Text="";
               TxtNextAgenda.Text="";
               TxtParticipants.Text = "";
               TxtObjective.Text = "";
            }


        }

        protected void dgv4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXmlNextMetting();
                DataSet dsGrid = (DataSet)dgv4.DataSource;
                dsGrid.Tables[0].Rows[dgv4.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLNextMetting);
                DataSet dsGridAfterDelete = (DataSet)dgv4.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLNextMetting); dgv4.DataSource = ""; dgv4.DataBind(); }
                else { LoadGridwithXmlNextMetting(); }
            }

            catch { }
        }




    }
}

