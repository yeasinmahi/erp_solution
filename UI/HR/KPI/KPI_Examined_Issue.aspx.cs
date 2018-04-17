using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.KPI;
using UI.ClassFiles;
using System.Data;
using System.Xml;

namespace UI.HR.KPI
{
    public partial class KPI_Examined_Issue : BasePage
    {
        KPI_BLL objIssue = new KPI_BLL();
        DataTable dt = new DataTable();
        string filePathForXMLKPIEX;
        string filePathForXMLJDC;
        string filePathForXMLBehavior;
        string xmlStringKPIEX= "";
        string xmlStringKPIJDC = "";
        string xmlStringKPIBehave = ""; protected int grdTotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMLKPIEX = Server.MapPath("~/HR/KPI/Data/IssueK_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            filePathForXMLJDC = Server.MapPath("~/HR/KPI/Data/hdc_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            filePathForXMLBehavior = Server.MapPath("~/HR/KPI/Data/Behave_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
        
        
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXMLKPIEX);}  catch { }try{ grdTotal = 0; File.Delete(filePathForXMLJDC);}  catch { } try{ File.Delete(filePathForXMLBehavior); }  catch { }
                
                Int32 enroll = int.Parse(Session["intEmployeeID"].ToString());
                string empstatus = Session["EmpStatus"].ToString();
                Lblstatus.Text = empstatus;
               
                lblJdcs.Visible = false; lblTask.Visible = false; lblBehaviors.Visible = false;
              
            }
        }

       
        

        protected void BtnEmp_Click(object sender, EventArgs e)
        {
            if (TxtDte.Text.Length > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('View First');", true);
            }

        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int totalt, tskw, jdw;
          //  string ds = (txtJdWight.Equals("1")) ? "One" : "";


            try
            {
                tskw = Int32.Parse(txtTaskWeight.Text.ToString());
            }
            catch { tskw = 0; }
            try
            {
                jdw = int.Parse(txtJdWight.Text.ToString());
            }
            catch { jdw = 0; }

            
            totalt = tskw + jdw;
           
          

            if (totalt == 80)
          
            {
              
            Int32 coaCodeID = Int32.Parse(0.ToString());

            Int32 costcenter = Int32.Parse(0.ToString());
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            DateTime evdate = DateTime.Parse(TxtDte.Text.ToString());
            Int32 dtmonth = Int32.Parse(evdate.ToString("MM"));
            Int32 dtYear = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int kpienroll = int.Parse(Session["intEmployeeID"].ToString());
            
           
           
           
            // int dts = int.Parse(dgvGridView.Rows.Count.ToString());
            if (dgvGridView.Rows.Count > 0)
            {

                for (int index = 0; index < dgvGridView.Rows.Count; index++)
                {
                    string enrolment = ((Label)dgvGridView.Rows[index].FindControl("lblEnrolment")).Text.ToString();
                    string issuemarks = ((Label)dgvGridView.Rows[index].FindControl("lblExamineMarks")).Text.ToString();
                    string taskid = ((Label)dgvGridView.Rows[index].FindControl("lblTaskID")).Text.ToString();

                    CreateVoucherXml(enrolment, issuemarks, taskid);


                }




            }


            if (DgvRegular.Rows.Count > 0)
            {

                for (int index = 0; index < DgvRegular.Rows.Count; index++)
                {
                    string jdcid = ((Label)DgvRegular.Rows[index].FindControl("lblJDC")).Text.ToString();
                    string jdcmarks = ((TextBox)DgvRegular.Rows[index].FindControl("TxtRegMarks")).Text.ToString();

                    CreateVoucherJDCXml(jdcid, jdcmarks);


                }




            }

            if (dgvBehavior.Rows.Count > 0)
            {

                for (int index = 0; index < dgvBehavior.Rows.Count; index++)
                {
                    string bhavid = ((Label)dgvBehavior.Rows[index].FindControl("lblBID")).Text.ToString();
                    string behavemarks = ((TextBox)dgvBehavior.Rows[index].FindControl("TxtBehaviorMarks")).Text.ToString();

                    CreateVoucherBehaviorXml(bhavid, behavemarks);


                }





            }
            try
            {
                if (dgvGridView.Rows.Count > 0 && DgvRegular.Rows.Count > 0)
                {

                    XmlDocument doc1 = new XmlDocument();
                    doc1.Load(filePathForXMLKPIEX);
                    XmlNode dSftTm = doc1.SelectSingleNode("voucher");
                    string xmlStringKPIEX = dSftTm.InnerXml;
                    xmlStringKPIEX = "<voucher>" + xmlStringKPIEX + "</voucher>";


                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLJDC);
                    XmlNode dSfatTme = doc.SelectSingleNode("jdc");
                    string xmlStringKPIJDC = dSfatTme.InnerXml;
                    xmlStringKPIJDC = "<jdc>" + xmlStringKPIJDC + "</jdc>";


                    XmlDocument doc3 = new XmlDocument();
                    doc3.Load(filePathForXMLBehavior);
                    XmlNode dsSftTm = doc3.SelectSingleNode("beh");
                    string xmlStringKPIBehave = dsSftTm.InnerXml;
                    xmlStringKPIBehave = "<beh>" + xmlStringKPIBehave + "</beh>";


                    int intPart = 1;

                    dt = objIssue.ExamineIssueallxmlinsert(intPart, xmlStringKPIEX, xmlStringKPIJDC, xmlStringKPIBehave, evdate, kpienroll, dtmonth, enroll, tskw, jdw);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
                    try
                    {
                        dgvGridView.DataSource = ""; dgvGridView.DataBind();
                        DgvRegular.DataSource = ""; DgvRegular.DataBind(); dgvBehavior.DataSource = ""; dgvBehavior.DataBind();
                        File.Delete(filePathForXMLKPIEX); File.Delete(filePathForXMLJDC); File.Delete(filePathForXMLBehavior);
                    }
                    catch { }
                }

                else if (dgvGridView.Rows.Count > 0 && DgvRegular.Rows.Count < 1)
                {
                    XmlDocument doc1 = new XmlDocument();
                    doc1.Load(filePathForXMLKPIEX);
                    XmlNode dSftTm = doc1.SelectSingleNode("voucher");
                    string xmlStringKPIEX = dSftTm.InnerXml;
                    xmlStringKPIEX = "<voucher>" + xmlStringKPIEX + "</voucher>";


                    XmlDocument doc3 = new XmlDocument();
                    doc3.Load(filePathForXMLBehavior);
                    XmlNode dsSftTm = doc3.SelectSingleNode("beh");
                    string xmlStringKPIBehave = dsSftTm.InnerXml;
                    xmlStringKPIBehave = "<beh>" + xmlStringKPIBehave + "</beh>";

                    tskw = 80;

                    int intPart = 3;

                    dt = objIssue.ExamineIssueTaskandBehaviorxmlinsert(intPart, xmlStringKPIEX, 0, xmlStringKPIBehave, evdate, kpienroll, dtmonth, enroll, tskw, jdw);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
                    try
                    {
                        dgvGridView.DataSource = ""; dgvGridView.DataBind();
                        dgvBehavior.DataSource = ""; dgvBehavior.DataBind();

                        File.Delete(filePathForXMLKPIEX); File.Delete(filePathForXMLBehavior);
                    }
                    catch { }

                }






                else if (dgvGridView.Rows.Count < 1 && DgvRegular.Rows.Count > 0)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLJDC);
                    XmlNode dSfatTme = doc.SelectSingleNode("jdc");
                    string xmlStringKPIJDC = dSfatTme.InnerXml;
                    xmlStringKPIJDC = "<jdc>" + xmlStringKPIJDC + "</jdc>";


                    XmlDocument doc3 = new XmlDocument();
                    doc3.Load(filePathForXMLBehavior);
                    XmlNode dsSftTm = doc3.SelectSingleNode("beh");
                    string xmlStringKPIBehave = dsSftTm.InnerXml;
                    xmlStringKPIBehave = "<beh>" + xmlStringKPIBehave + "</beh>";

                    jdw = 80;

                    int intPart = 2;

                    dt = objIssue.ExamineIssueJDCandBehaviorxmlinsert(intPart, 0, xmlStringKPIJDC, xmlStringKPIBehave, evdate, kpienroll, dtmonth, enroll, tskw, jdw);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
                    try { DgvRegular.DataSource = ""; DgvRegular.DataBind(); dgvBehavior.DataSource = ""; dgvBehavior.DataBind(); File.Delete(filePathForXMLJDC); File.Delete(filePathForXMLBehavior); }
                    catch { }
                }

           



            }


            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please fill up Job Description and Behavior Marks');", true); }

            lblgrdTotal.Text = "Achivement point :" + " " + "0".ToString();

           }
          else
           {
               ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Weight Must be  80');", true);
           }

       
        }


        private void CreateVoucherBehaviorXml(string bhavid, string behavemarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLBehavior))
            {
                doc.Load(filePathForXMLBehavior);
                XmlNode rootNode = doc.SelectSingleNode("beh");
                XmlNode addItem = CreateItemNodeBehavior(doc, bhavid, behavemarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("beh");
                XmlNode addItem = CreateItemNodeBehavior(doc, bhavid, behavemarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLBehavior);
        }

        private XmlNode CreateItemNodeBehavior(XmlDocument doc, string bhavid, string behavemarks)
        {
            XmlNode node = doc.CreateElement("behentry");
            XmlAttribute Bhavid = doc.CreateAttribute("bhavid");
            Bhavid.Value = bhavid;
            XmlAttribute Behavemarks = doc.CreateAttribute("behavemarks");
            Behavemarks.Value = behavemarks;






            node.Attributes.Append(Bhavid);
            node.Attributes.Append(Behavemarks);

            return node;
        }

        

        

        

        private void CreateVoucherJDCXml(string jdcid, string jdcmarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLJDC))
            {
                doc.Load(filePathForXMLJDC);
                XmlNode rootNode = doc.SelectSingleNode("jdc");
                XmlNode addItem = CreateItemNodeKPIJDC(doc, jdcid, jdcmarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("jdc");
                XmlNode addItem = CreateItemNodeKPIJDC(doc, jdcid, jdcmarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLJDC);
        }

        private XmlNode CreateItemNodeKPIJDC(XmlDocument doc, string jdcid, string jdcmarks)
        {
            XmlNode node = doc.CreateElement("jdcentry");
            XmlAttribute Jdcid = doc.CreateAttribute("jdcid");
            Jdcid.Value = jdcid;
            XmlAttribute Jdcmarks = doc.CreateAttribute("jdcmarks");
            Jdcmarks.Value = jdcmarks;






            node.Attributes.Append(Jdcid);
            node.Attributes.Append(Jdcmarks);
          
            return node;
        }

        private void CreateVoucherXml(string enrolment, string issuemarks, string taskid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLKPIEX))
            {
                doc.Load(filePathForXMLKPIEX);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeKPI(doc, enrolment, issuemarks, taskid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeKPI(doc, enrolment, issuemarks, taskid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLKPIEX);
        }

        private XmlNode CreateItemNodeKPI(XmlDocument doc, string enrolment, string issuemarks, string taskid)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Enrolment = doc.CreateAttribute("enrolment");
            Enrolment.Value = enrolment;
            XmlAttribute Issuemarks = doc.CreateAttribute("issuemarks");
            Issuemarks.Value = issuemarks;
            XmlAttribute Taskid = doc.CreateAttribute("taskid");
            Taskid.Value = taskid;





            node.Attributes.Append(Enrolment);
            node.Attributes.Append(Issuemarks);
            node.Attributes.Append(Taskid);
            return node;
        }

        protected void btiView_Click(object sender, EventArgs e)
        {
            int intType;string point;
            lblJdcs.Visible = true;  lblBehaviors.Visible = true;
            Int32 enroll = int.Parse(Session["intEmployeeID"].ToString());
            DateTime evdate = DateTime.Parse(TxtDte.Text.ToString());
            Int32 month = Int32.Parse(evdate.ToString("MM"));
            Int32 year = Int32.Parse(evdate.ToString("yyyy"));
            // intType = 9;
            //dt = objIssue.EmployeeJDCTotalsum(intType, 0, evdate, enroll, month, year);
            //Int32 weight = Convert.ToInt32(dt.Rows[0]["jweight"].ToString());
           
                intType = 8;
                dt = objIssue.EmployeeDetalisPerformance(intType, 0, evdate, enroll, month, year);
                if (dt.Rows.Count > 0)
                {
                    lblTask.Visible = true;
                    dgvGridView.DataSource = dt;
                    dgvGridView.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Task Data Found');", true);

                }
                intType = 12;
                dt = new DataTable();
                dt = objIssue.EmployeeJDC(intType, 0, evdate, enroll, month, year);
                DgvRegular.DataSource = dt;
                DgvRegular.DataBind();
                intType = 13;
                dt = new DataTable();
                dt = objIssue.EmployeeBehavour(intType, 0, evdate, enroll, month, year);
                dgvBehavior.DataSource = dt;
                dgvBehavior.DataBind();


                for (int index = 0; index < dgvBehavior.Rows.Count; index++)
                {
                    
                     point = ((TextBox)dgvBehavior.Rows[index].FindControl("TxtBehaviorMarks")).Text.ToString();
                    if ( string.IsNullOrEmpty(point)){point="0".ToString();}
                    try { grdTotal += int.Parse(point); }
                    catch { }
                }
                lblgrdTotal.Text = "Achivement point :" + " " + grdTotal.ToString();
          
        }

        protected void TxtDte_TextChanged(object sender, EventArgs e)
        {
            dgvGridView.DataSource = "";
            dgvGridView.DataBind();

        }

        protected void rdograding_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridRow = ((GridViewRow)((RadioButtonList)sender).NamingContainer);
            int index = gridRow.RowIndex;
           // string strQnt = ((RadioButtonList)dgvBehavior.Rows[index].FindControl("rdograding")).Text.ToString();
           
           ((TextBox)dgvBehavior.Rows[index].FindControl("TxtBehaviorMarks")).Text= ((RadioButtonList)dgvBehavior.Rows[index].FindControl("rdograding")).Text.ToString();

            grdTotal = 0; string point;
               for ( index = 0; index < dgvBehavior.Rows.Count; index++)
               {


                   point =((TextBox)dgvBehavior.Rows[index].FindControl("TxtBehaviorMarks")).Text.ToString();
                   if (string.IsNullOrEmpty(point)) { point = "0".ToString(); }
                   try { grdTotal += int.Parse(point); }
                   catch { }
               }
               lblgrdTotal.Text = "Achivement point :" + " " + grdTotal.ToString();

          
        }

        

       
    }
}