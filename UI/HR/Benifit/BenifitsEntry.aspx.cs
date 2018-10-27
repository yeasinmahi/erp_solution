using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using HR_BLL.Benifit;
using System.Globalization;
using System.IO;

namespace UI.HR.Benifit
{
    public partial class BenifitsEntry : BasePage
    {
        DataTable dt = new DataTable();
        JobStation objbll = new JobStation();
        EmployeeBasicInfo objEmp = new EmployeeBasicInfo();
        EmpBenifit objBenifit = new EmpBenifit();
        string filePathForXML,msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/Benifit/Data/Benifit_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //divItemInfo.Visible = false;
                try
                {
                    dt = objbll.GetJobStationList();
                    ddlJobStation.DataSource = dt;
                    ddlJobStation.DataTextField = "strJobStationName";
                    ddlJobStation.DataValueField = "intEmployeeJobStationId";
                    ddlJobStation.DataBind();
                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
            int intjobid = Convert.ToInt32(ddlJobStation.SelectedItem.Value);
            dt = objEmp.GetEmpInfoByJobStation(intjobid);
            if(dt.Rows.Count>0)
            {
                //divItemInfo.Visible = true;
                dgvEmployeeInfo.DataSource = dt;
                dgvEmployeeInfo.DataBind();
            }
            else
            {
                //divItemInfo.Visible = false;
                dgvEmployeeInfo.DataSource = "";
                dgvEmployeeInfo.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string insertBy = Session[SessionParams.USER_ID].ToString();
                DateTime Date = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string toDate = Date.ToString("yyyy/MM/dd");
                DateTime insertdate = DateTime.Now;
                string insertDate = insertdate.ToString();
                string intJobstationId = ddlJobStation.SelectedItem.Value;
                string amount = txtAmount.Text;
                if (dgvEmployeeInfo.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvEmployeeInfo.Rows.Count; index++)
                    {
                        CheckBox check = (CheckBox)dgvEmployeeInfo.Rows[index].FindControl("chkRow");
                        if (check.Checked == true)
                        {
                            string enrollid = dgvEmployeeInfo.Rows[index].Cells[1].Text;
                            CreateXml(enrollid, amount, insertBy, insertDate, intJobstationId, toDate);
                            check.Checked = false;
                        }

                    }


                    if (hdnConfirm.Value == "1")
                    {

                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode node = doc.SelectSingleNode("BenifitEntry");
                        string xmlString = node.InnerXml;
                        xmlString = "<BenifitEntry>" + xmlString + "</BenifitEntry>";

                        msg = objBenifit.InsertBenifitInfo(xmlString);

                        //int intjobid = Convert.ToInt32(ddlJobStation.SelectedItem.Value);
                        //dt = objEmp.GetEmpInfoByJobStation(intjobid);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    //divItemInfo.Visible = true;
                        //    dgvEmployeeInfo.DataSource = dt;
                        //    dgvEmployeeInfo.DataBind();
                        //}
                        txtDate.Text = "";
                        txtAmount.Text = "";
                       // ddlJobStation.Text = "";
                    
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        try {
                            File.Delete(filePathForXML);
                        }

                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }
        }

        
        
        #region=======xml=========
        private void CreateXml(string enrollid, string Amount, string insertBy, string insertDate, string JobStation, string Date)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("BenifitEntry");
                XmlNode addItem = CreateItemNode(doc,enrollid,  Amount,  insertBy,  insertDate,  JobStation,  Date);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BenifitEntry");
                XmlNode addItem = CreateItemNode(doc, enrollid, Amount, insertBy, insertDate, JobStation, Date);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string enrollid, string amount, string insertBy, string insertDate, string jobStation, string Date)
        {

            XmlNode node = doc.CreateElement("Benifit");
          

            XmlAttribute Enrollid = doc.CreateAttribute("enrollid");
            Enrollid.Value = enrollid;

            XmlAttribute InsertBy = doc.CreateAttribute("insertBy");
            InsertBy.Value = insertBy;

            XmlAttribute InsertDate = doc.CreateAttribute("insertDate");
            InsertDate.Value = insertDate;

            XmlAttribute JobStation = doc.CreateAttribute("jobStation");
            JobStation.Value = jobStation;

            XmlAttribute ToDate = doc.CreateAttribute("Date");
            ToDate.Value = Date;


            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            node.Attributes.Append(Enrollid);
            node.Attributes.Append(ToDate);
            node.Attributes.Append(InsertBy);
            node.Attributes.Append(InsertDate);
            node.Attributes.Append(JobStation);
            node.Attributes.Append(Amount);
            return node;
        }

        #endregion ======= end xml =======


    }
}