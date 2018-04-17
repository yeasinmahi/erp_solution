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
using System.Drawing;

namespace UI.HR.KPI
{
    public partial class KPI_UI : BasePage
    {
        KPI_BLL objKPI = new KPI_BLL();
        DataTable dt = new DataTable();
        string filePathForXMLKPI;

        string XmlStringKPI = "";
        KPI_BLL rpt = new KPI_BLL();
        int intType; string grade; string dts = "0.0000"; DateTime evdate;
        protected void Page_Load(object sender, EventArgs e)
        {
           filePathForXMLKPI= Server.MapPath("~/HR/KPI/Data/EmpKPI_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
              if (!IsPostBack)
              {
                 try { File.Delete(filePathForXMLKPI); }
                 catch { }
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                dt = new DataTable();
                dt = objKPI.TypeView();
                ddltype.DataSource = dt;
                ddltype.DataTextField = "strName";
                ddltype.DataValueField = "intID";
                ddltype.DataBind();

                dt = new DataTable();
                dt = objKPI.gradesummery();
                dgvlist.DataSource = dt;
                dgvlist.DataBind();
               
                string evaluation = ddltype.SelectedItem.ToString();
                LblDtePO.Text = evaluation.ToString();
                pnlUpperControl.DataBind();
       


              }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgvGridView.Rows.Count > 0)
            {

                for (int index = 0; index < dgvGridView.Rows.Count; index++)
                {
                    if (((CheckBox)dgvGridView.Rows[index].FindControl("chkRow")).Checked == true)
                    {

                        string empid = ((Label)dgvGridView.Rows[index].FindControl("intEmployeeID")).Text.ToString();
                        //string grade = ((Label)dgvGridView.Rows[index].FindControl("lblGrade")).Text.ToString();
                        
                         string gradenumber = ((TextBox)dgvGridView.Rows[index].FindControl("TxtGradeNumber")).Text.ToString();

                         if (int.Parse(gradenumber) == 0) { grade = "".ToString(); }
                        else if (int.Parse(gradenumber) >= 90) { grade = "A+".ToString(); }
                        else if (int.Parse(gradenumber) >= 80) { grade = "A".ToString(); }
                        else if (int.Parse(gradenumber) >= 70) { grade = "B".ToString(); }
                        else if (int.Parse(gradenumber) >= 60) { grade = "C".ToString(); }
                        else if (int.Parse(gradenumber) >= 50) { grade = "D".ToString(); }
                        else { grade = "F".ToString(); }

                         string gradetype = ddltype.SelectedValue.ToString();
                         string gradeid = "0".ToString();
                       
                        evdate = DateTime.Parse(TxtDte.Text.ToString()); 
                        
                         
                         Int32 dtmonth =Int32.Parse(evdate.ToString("MM"));
                        Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                        {
                            CreateVoucherXml(empid, gradenumber, grade,gradeid, gradetype);

                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLKPI);
                            XmlNode dSftTm = doc.SelectSingleNode("voucher");
                            string XmlStringKPI = dSftTm.InnerXml;
                            XmlStringKPI = "<voucher>" + XmlStringKPI + "</voucher>";
                            if (gradetype == "1") 
                            {
                                intType = 2;
                                string message = rpt.InsertKPIinformation(intType, XmlStringKPI, evdate, enroll, 0, 0);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                                File.Delete(filePathForXMLKPI);
                            }
                            if (gradetype == "2")
                            {
                                intType = 4;
                                string message = rpt.InsertKPIinformation(intType, XmlStringKPI, evdate, enroll, 0, 0);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                                File.Delete(filePathForXMLKPI);
                            }



                              
                          
                         

                        }
                    }


                }
            }
            LoadView();
            //
        }

        private void CreateVoucherXml(string empid, string gradenumber, string grade,string gradeid, string gradetype)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLKPI))
            {
                doc.Load(filePathForXMLKPI);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeKPI(doc, empid, gradenumber, grade,gradeid, gradetype);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeKPI(doc, empid, gradenumber, grade,gradeid, gradetype);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLKPI);
        }

        private XmlNode CreateItemNodeKPI(XmlDocument doc, string empid, string gradenumber, string grade,string gradeid, string gradetype)
        {

            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Empid = doc.CreateAttribute("empid");
            Empid.Value = empid;
            XmlAttribute Gradenumber = doc.CreateAttribute("gradenumber");
            Gradenumber.Value = gradenumber;
            XmlAttribute Grade = doc.CreateAttribute("grade");
            Grade.Value = grade;
            XmlAttribute Gradeid = doc.CreateAttribute("gradeid");
            Gradeid.Value = gradeid;
            XmlAttribute Gradetype = doc.CreateAttribute("gradetype");
            Gradetype.Value = gradetype;



            node.Attributes.Append(Empid);
            node.Attributes.Append(Gradenumber);
            node.Attributes.Append(Grade);
            node.Attributes.Append(Gradeid);
            node.Attributes.Append(Gradetype);



            return node;
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var tes = (TextBox)e.Row.FindControl("txtGradeNumber");
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        if (tes.Text == "0" || tes.Text == "null" || tes.Text == "0.0000" || tes.Text == "")
                        {

                            cell.BackColor = Color.Empty;

                        }
                        else
                        {
                            cell.BackColor = Color.YellowGreen;
                        }
                    }
                }

          


           

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            
            LoadView();
        }

        private void LoadView()
        {
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            //Int32 enroll = int.Parse(110269.ToString());
           
            int kpitype = int.Parse(ddltype.SelectedValue.ToString());
            if (kpitype == 1)
            {
                intType = 1;
                DateTime evdate = DateTime.Parse(TxtDte.Text.ToString());
                Int32 monthrange = Int32.Parse(evdate.ToString("MM"));
                dt = objKPI.Employeeview(intType, 0, evdate, enroll, monthrange, kpitype);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }
            else
            {
                DateTime yearte = DateTime.Parse(TxtDte.Text.ToString());
                Int32 yearrange = Int32.Parse(yearte.ToString("yyyy"));
                intType = 3;
                dt = objKPI.EmployeeviewYearly(intType, 0, evdate, enroll, yearrange, kpitype);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }
          
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string evaluation = ddltype.SelectedItem.ToString();
            LblDtePO.Text = evaluation.ToString();
            dt = new DataTable();
            dgvGridView.DataSource =dt;
            dgvGridView.DataBind();
            
        }

        
    }
}