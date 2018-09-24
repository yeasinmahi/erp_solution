using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL.Reports;
using System.Globalization;
using System.Data;
using System.Xml;
using System.IO;

namespace UI.HR.Reports
{
    public partial class EmployeeDetailsReport : BasePage
    {
        HR_BLL.Reports.EmployeeDetailsReport objEmployeeDetails = new HR_BLL.Reports.EmployeeDetailsReport();
        DataTable dt = new DataTable();
        int intPart;
        string filePathForXML;
        string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/Reports/Data/attendance_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {               
               
            }
            
            GVEmpAttendance.Visible = false;           
        }


        #region ====== Drop Down Bind Start ========================================

        protected void ddlDepartment_DataBound(object sender, EventArgs e)
        {
            ddlDepartment.Items.Insert(0, new ListItem("ALL", "0"));
        }

        protected void ddlDesignation_DataBound(object sender, EventArgs e)
        {
            ddlDesignation.Items.Insert(0, new ListItem("ALL", "0"));
        }
        #endregion ====== Drop Down Bind End ========================================


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try {
                string insertBy = Session[SessionParams.USER_ID].ToString();
                DateTime date = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string AttendanceDate = date.ToString("yyyy/MM/dd");
                DateTime insertdate = DateTime.Now;
                string insertDate = insertdate.ToString();
                int intUnitId = int.Parse(ddlUnit.SelectedItem.Value);
                int intJobstationId = int.Parse(ddlJobStation.SelectedItem.Value);
                int intDepartmentId = int.Parse(ddlDepartment.SelectedItem.Value);
                int intDesignationId = int.Parse(ddlDesignation.SelectedItem.Value);
                if (GVEmpAttendance.Rows.Count > 0)
                {
                    for (int index = 0; index < GVEmpAttendance.Rows.Count; index++)                                              
                    {

                        if (((CheckBox)GVEmpAttendance.Rows[index].FindControl("chkRow")).Checked == true)
                        {                          
                            string EnrollId = GVEmpAttendance.Rows[index].Cells[1].Text;
                            //DateTime attintime = DateTime.ParseExact(GVEmpAttendance.Rows[index].Cells[7].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            string attendanceIntime = GVEmpAttendance.Rows[index].Cells[7].Text;
                            //DateTime attouttime = DateTime.ParseExact(GVEmpAttendance.Rows[index].Cells[7].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            string attendanceOutTime = GVEmpAttendance.Rows[index].Cells[8].Text;
                            CreateXml(AttendanceDate,EnrollId, insertBy, insertDate, attendanceIntime, attendanceOutTime);
                        }
                   
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode node = doc.SelectSingleNode("attendance");
                    string xmlString = node.InnerXml;
                    xmlString = "<attendance>" + xmlString + "</attendance>";

                    //dt = objEmployeeDetails.getEmployeeAttendance(date, intUnitId, intJobstationId, intDepartmentId, intDesignationId, 5, xmlString);

                    string msg = objEmployeeDetails.InsertXml(xmlString);

                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+msg+"');", true);
                    try { File.Delete(filePathForXML); }

                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }
        }

        private void CreateXml(string attendanceDate, string enrollid,string insertBy,string insertDate,string attendanceIntime,string attendanceOutTime)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("attendance");
                XmlNode addItem = CreateItemNode(doc,attendanceDate, enrollid, insertBy, insertDate, attendanceIntime, attendanceOutTime);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("attendance");
                XmlNode addItem = CreateItemNode(doc,attendanceDate, enrollid, insertBy, insertDate, attendanceIntime, attendanceOutTime);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc,string attendanceDate, string enrollid,string insertBy,string insertDate,string attendanceIntime,string attendanceOutTime)
        {

            XmlNode node = doc.CreateElement("attendanceDetails");
            XmlAttribute AttendanceDate = doc.CreateAttribute("attendanceDate");
            AttendanceDate.Value = attendanceDate;

            XmlAttribute Enrollid = doc.CreateAttribute("enrollid");
            Enrollid.Value = enrollid;

            XmlAttribute InsertBy = doc.CreateAttribute("insertBy");
            InsertBy.Value = insertBy;

            XmlAttribute InsertDate = doc.CreateAttribute("insertDate");
            InsertDate.Value = insertDate;

            XmlAttribute AttendanceIntime = doc.CreateAttribute("attendanceIntime");
            AttendanceIntime.Value = attendanceIntime;

            XmlAttribute AttendanceOutTime = doc.CreateAttribute("attendanceOutTime");
            AttendanceOutTime.Value = attendanceOutTime;

            node.Attributes.Append(Enrollid);
            node.Attributes.Append(AttendanceDate);
            node.Attributes.Append(InsertBy);
            node.Attributes.Append(InsertDate);
            node.Attributes.Append(AttendanceIntime);
            node.Attributes.Append(AttendanceOutTime);
            return node;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            try {

                intPart = 0;
                DateTime date = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                int intUnitId = int.Parse(ddlUnit.SelectedItem.Value);
                int intJobstationId = int.Parse(ddlJobStation.SelectedItem.Value);
                int intDepartmentId = int.Parse(ddlDepartment.SelectedItem.Value);
                int intDesignationId = int.Parse(ddlDesignation.SelectedItem.Value);

                if (intDepartmentId == 0 && intDesignationId == 0)
                {
                    intPart = 4;
                    dt = objEmployeeDetails.getEmployeeAttendance(date, intUnitId, intJobstationId, intDepartmentId, intDesignationId, intPart,"");
                    if (dt.Rows.Count > 0)
                    {
                        GVEmpAttendance.Visible = true;
                        GVEmpAttendance.DataSource = dt;
                        GVEmpAttendance.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                    }

                }
                else if (intDepartmentId == 0 && intDesignationId > 0)
                {
                    intPart = 2;
                    dt = objEmployeeDetails.getEmployeeAttendance(date, intUnitId, intJobstationId, intDepartmentId, intDesignationId, intPart,"");
                    if (dt.Rows.Count > 0)
                    {
                        GVEmpAttendance.Visible = true;
                        GVEmpAttendance.DataSource = dt;
                        GVEmpAttendance.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                    }
                }
                else if (intDepartmentId > 0 && intDesignationId == 0)
                {
                    intPart = 3;
                    dt = objEmployeeDetails.getEmployeeAttendance(date, intUnitId, intJobstationId, intDepartmentId, intDesignationId, intPart,"");
                    if (dt.Rows.Count > 0)
                    {
                        GVEmpAttendance.Visible = true;
                        GVEmpAttendance.DataSource = dt;
                        GVEmpAttendance.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                    }
                }
                else
                {
                    intPart = 1;
                    dt = objEmployeeDetails.getEmployeeAttendance(date, intUnitId, intJobstationId, intDepartmentId, intDesignationId, intPart,"");
                    if (dt.Rows.Count > 0)
                    {
                        GVEmpAttendance.Visible = true;
                        GVEmpAttendance.DataSource = dt;
                        GVEmpAttendance.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }

        }







































    }
}