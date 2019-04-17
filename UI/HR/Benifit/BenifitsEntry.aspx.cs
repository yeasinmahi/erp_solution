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
using System.Data.OleDb;

namespace UI.HR.Benifit
{
    public partial class BenifitsEntry : BasePage
    {
        DataTable dt = new DataTable();
        JobStation objbll = new JobStation();
        EmployeeBasicInfo objEmp = new EmployeeBasicInfo();
        EmpBenifit objBenifit = new EmpBenifit();
        string filePathForXML, path, msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath("~/HR/Benifit/Data/" + FileUpload1.FileName);
            filePathForXML = Server.MapPath("~/HR/Benifit/Data/Benifit_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //divItemInfo.Visible = false;
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

        //protected void btnShow_Click(object sender, EventArgs e)
        //{

        //    int intjobid = Convert.ToInt32(ddlJobStation.SelectedItem.Value);
        //    //dt = objEmp.GetEmpInfoByJobStation(intjobid);

        //    if (string.IsNullOrWhiteSpace(txtEmp.Text))
        //    {
        //        dt = objBenifit.InsertBenifitInfo(2, intjobid, 0, "");
        //    }
        //    else
        //    {
        //        int empid = 0;
        //        if (int.TryParse(txtEmp.Text, out empid))
        //        {
        //            dt = objBenifit.InsertBenifitInfo(3, intjobid, empid, "");
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Check your enroll properly.');", true);
        //        }

        //    }

        //    if (dt.Rows.Count > 0)
        //    {
        //        //divItemInfo.Visible = true;
        //        dgvEmployeeInfo.DataSource = dt;
        //        dgvEmployeeInfo.DataBind();
        //    }
        //    else
        //    {
        //        //divItemInfo.Visible = false;
        //        dgvEmployeeInfo.DataSource = "";
        //        dgvEmployeeInfo.DataBind();
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
        //    }

        //}

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string insertBy = Session[SessionParams.USER_ID].ToString();
        //        DateTime Date = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //        string toDate = Date.ToString("yyyy/MM/dd");
        //        DateTime insertdate = DateTime.Now;
        //        string insertDate = insertdate.ToString();
        //        string intJobstationId = ddlJobStation.SelectedItem.Value;
        //        string amount = txtAmount.Text;
        //        if (dgvEmployeeInfo.Rows.Count > 0)
        //        {

        //            for (int index = 0; index < dgvEmployeeInfo.Rows.Count; index++)
        //            {
        //                CheckBox check = (CheckBox)dgvEmployeeInfo.Rows[index].FindControl("chkRow");
        //                if (check.Checked == true)
        //                {
        //                    string enrollid = dgvEmployeeInfo.Rows[index].Cells[1].Text;
        //                    CreateXml(enrollid, amount, insertBy, insertDate, intJobstationId, toDate);
        //                    check.Checked = false;
        //                }

        //            }


        //            if (hdnConfirm.Value == "1")
        //            {

        //                XmlDocument doc = new XmlDocument();
        //                doc.Load(filePathForXML);
        //                XmlNode node = doc.SelectSingleNode("BenifitEntry");
        //                string xmlString = node.InnerXml;
        //                xmlString = "<BenifitEntry>" + xmlString + "</BenifitEntry>";

        //                dt = objBenifit.InsertBenifitInfo(1, 0, 0, xmlString);

        //                //int intjobid = Convert.ToInt32(ddlJobStation.SelectedItem.Value);
        //                //dt = objEmp.GetEmpInfoByJobStation(intjobid);
        //                //if (dt.Rows.Count > 0)
        //                //{
        //                //    //divItemInfo.Visible = true;
        //                //    dgvEmployeeInfo.DataSource = dt;
        //                //    dgvEmployeeInfo.DataBind();
        //                //}
        //                txtDate.Text = "";
        //                //txtAmount.Text = "";
        //                // ddlJobStation.Text = "";

        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Submitted Successfully');", true);
        //                try
        //                {
        //                    File.Delete(filePathForXML);
        //                }

        //                catch (Exception ex)
        //                {
        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
        //    }
        //}

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            dgvEmployeeInfo.DataSource = null;
            dgvEmployeeInfo.DataBind();
            string connectionString = "";

            if (FileUpload1.HasFile)
            {
                string strDocUploadPath = Path.GetFileName(FileUpload1.FileName);
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                
                FileUpload1.SaveAs(path);
                if (ext.Trim() == ".xls")
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (ext.Trim() == ".xlsx")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                string query = "SELECT * FROM [Sheet1$]";
                OleDbConnection conn = new OleDbConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                gvExcelFile.DataSource = ds.Tables[0];
                gvExcelFile.DataBind();
                conn.Close();
                File.Delete(path);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Upload an excel file.');", true);
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
                XmlNode addItem = CreateItemNode(doc, enrollid, Amount, insertBy, insertDate, JobStation, Date);
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

        protected void btnSubmitExcel_Click(object sender, EventArgs e)
        {
            string insertBy = Session[SessionParams.USER_ID].ToString();
            DateTime Date = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string toDate = Date.ToString("yyyy/MM/dd");
            DateTime insertdate = DateTime.Now;
            string insertDate = insertdate.ToString();
            string intJobstationId = ddlJobStation.SelectedItem.Value;
            if (gvExcelFile.Rows.Count > 0)
            {

                for (int index = 0; index < gvExcelFile.Rows.Count; index++)
                {
                    string enrollid = gvExcelFile.Rows[index].Cells[0].Text;
                    string amount = gvExcelFile.Rows[index].Cells[1].Text;
                    CreateXml(enrollid,amount,insertBy,insertDate,intJobstationId,toDate);
                }
            }

            if (hdnConfirm.Value == "1")
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode node = doc.SelectSingleNode("BenifitEntry");
                string xmlString = node.InnerXml;
                xmlString = "<BenifitEntry>" + xmlString + "</BenifitEntry>";

                dt = objBenifit.InsertBenifitInfo(1, 0, 0, xmlString);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Submitted Successfully');", true);
                try
                {
                    
                    File.Delete(filePathForXML);
                    gvExcelFile.DataSource = null;
                    gvExcelFile.DataBind();
                }

                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                }
            }
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