using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using HR_BLL.KPI;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.KPI
{
    public partial class EmpJobDescription_UI : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/KPI/EmpJobDescription_UI.aspx";
        string stop = "stopping HR/KPI/EmpJobDescription_UI.aspx";

        KPI_BLL objJobD = new KPI_BLL();
        DataTable dt = new DataTable();
        string filePathForXMLRJDC;
        string xmlStringKPIEX = "";
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMLRJDC = Server.MapPath("~/HR/KPI/Data/JDCK_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if(!IsPostBack)
            {
                try { File.Delete(filePathForXMLRJDC);  }
                catch { }
                pnlUpperControl.DataBind();
                Int32 intDept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intJob = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                 Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Session["intDeptID"] = intDept;
                Session["intJobID"] = intJob;
                Session["intEnrollID"] = enroll;

            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmployeeName(string prefixText, int count)
        {

        
            string Dept = Convert.ToString(HttpContext.Current.Session["intDeptID"].ToString());
            string job = Convert.ToString(HttpContext.Current.Session["intJobID"].ToString());
            string enroll = Convert.ToString(HttpContext.Current.Session["intEnrollID"].ToString());

            if (Dept=="14")
            {
              
                AutoSearchKPI_BLL objAutoSearch_BLL = new AutoSearchKPI_BLL();

                return objAutoSearch_BLL.GetEmployeeNameHRJobstation(job,prefixText);
            }
            else
            {
               
                AutoSearchKPI_BLL objAutoSearch_BLL = new AutoSearchKPI_BLL();

                return objAutoSearch_BLL.GetEmployeeNameSupervisor(enroll, prefixText);
            }

          


        }

      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/KPI/EmpJobDescription_UI.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                arrayKeyItem = TxtEnroll.Text.Split(delimiterChars);
                string empname = arrayKeyItem[0].ToString();
                string empid = arrayKeyItem[1].ToString();
              
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
              
                
                //string xmlStringEmployee = "<voucher><voucherentry empid=" + '"' + empid + '"' + " description=" + '"' + description + '"' + " weight=" + '"' + weight + '"' + "/></voucher>".ToString();

               DateTime evdate = DateTime.Parse("2016-01-01".ToString());
               
                int monthrange = int.Parse(0.ToString());
                int kpitype = int.Parse(0.ToString());
                
                if (dgvEmpView.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvEmpView.Rows.Count; index++)
                    {
                        string autoid = ((Label)dgvEmpView.Rows[index].FindControl("lblAutoID")).Text.ToString();
                        string description = ((Label)dgvEmpView.Rows[index].FindControl("lblFileName")).Text.ToString();
                        string weight = ((TextBox)dgvEmpView.Rows[index].FindControl("Txtweight")).Text.ToString();

                        CreateVoucherXml(empid,autoid, description, weight);
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLRJDC);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    string xmlStringKPIEX = dSftTm.InnerXml;
                    xmlStringKPIEX = "<voucher>" + xmlStringKPIEX + "</voucher>";

                    int intType = 10;
                    dt = new DataTable();
                    dt = objJobD.KPIEmployeeJobDescriptionXML(intType, xmlStringKPIEX, evdate, enroll, monthrange, kpitype);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
                    try { File.Delete(filePathForXMLRJDC); }
                    catch { }
                    loadgrid();
                }


            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void CreateVoucherXml(string empid,string autoid, string description, string weight)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLRJDC))
            {
                doc.Load(filePathForXMLRJDC);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeKPI(doc, empid, autoid, description, weight);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeKPI(doc, empid, autoid, description, weight);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLRJDC);
        }

        private XmlNode CreateItemNodeKPI(XmlDocument doc, string empid, string autoid, string description, string weight)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Empid = doc.CreateAttribute("empid");
            Empid.Value = empid;
            XmlAttribute Autoid = doc.CreateAttribute("autoid");
            Autoid.Value = autoid;
            XmlAttribute Description = doc.CreateAttribute("description");
            Description.Value = description;
            XmlAttribute Weight = doc.CreateAttribute("weight");
            Weight.Value = weight;





            node.Attributes.Append(Empid);
            node.Attributes.Append(Autoid);
            node.Attributes.Append(Description);
            node.Attributes.Append(Weight);
            return node;
        }

      
       

        protected void TxtEnroll_TextChanged(object sender, EventArgs e)
        {
           

                loadgrid();
           
        }

        private void loadgrid()
        {
            try
            {
               
                arrayKeyItem = TxtEnroll.Text.Split(delimiterChars);
               
                string empid = arrayKeyItem[1].ToString();
                DateTime evdate = DateTime.Parse("2016-01-01".ToString());
                Int32 enroll = Int32.Parse(empid.ToString());
                
                dt = new DataTable();
                dt = objJobD.EmpJobDescription(enroll);
                dgvEmpView.DataSource = dt;
                dgvEmpView.DataBind();
                ViewState["Customers"] = dt;

                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("decWeight"));

                dgvEmpView.FooterRow.Cells[3].Text = "Total";

                dgvEmpView.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                dgvEmpView.FooterRow.Cells[4].Text = total.ToString("N2");
               
               

                
            }

            catch { }
        }

       

        

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            arrayKeyItem = TxtEnroll.Text.Split(delimiterChars);

            string empid = arrayKeyItem[1].ToString();
            DateTime evdate = DateTime.Parse("2016-01-01".ToString());
            Int32 enroll = Int32.Parse(empid.ToString());
            string strEmployeeName = arrayKeyItem[0].ToString();
            string intautoid = "0".ToString();
            DataTable dt = (DataTable)ViewState["Customers"];

            dt.Rows.Add(intautoid,strEmployeeName, TxtDescription.Text.Trim(), TxtWeight.Text.Trim());

            ViewState["Customers"] = dt;

            this.BindGrid();

            TxtDescription.Text = string.Empty;

            TxtWeight.Text = string.Empty;

        }

        private void BindGrid()
        {
             dgvEmpView.DataSource= (DataTable)ViewState["Customers"];

             dgvEmpView.DataBind();
             dt = new DataTable();
             dt = (DataTable)ViewState["Customers"];
             decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("decWeight"));

             dgvEmpView.FooterRow.Cells[3].Text = "Total";

             dgvEmpView.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;

             dgvEmpView.FooterRow.Cells[4].Text = total.ToString("N2");
        }
    }
}