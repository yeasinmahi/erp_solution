using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.HR.Salary
{
    public partial class EmpSalaryAdditionDeduction : BasePage
    {
         //DataTable dt = new DataTable();
            //JobStation objbll = new JobStation();
            //EmployeeBasicInfo objEmp = new EmployeeBasicInfo();
            //EmpBenifit objBenifit = new EmpBenifit();
       string filePathForXML, path, msg;
        private readonly string ftp = "ftp://ftp.akij.net/ExcelUpload/Benifit.xlsx";
        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath("~/HR/Salary/FileExcell/" + FileUpload1.FileName);
            filePathForXML = Server.MapPath("~/HR/Salary/FileExcell/Emp_Salary_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                
               
                try
                {
               
                }
                catch { }
            }
        }
        

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
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
        private void CreateXml(string enrollid, string Amount, string insertBy)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("salary");
                XmlNode addItem = CreateItemNode(doc, enrollid, Amount, insertBy);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("salary");
                XmlNode addItem = CreateItemNode(doc, enrollid, Amount, insertBy);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(ftp);
            byte[] bytes = (ftp).DownloadFromFtp();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void btnSubmitExcel_Click(object sender, EventArgs e)
        {
            string insertBy = Session[SessionParams.USER_ID].ToString();
           
            if (gvExcelFile.Rows.Count > 0)
            {

                for (int index = 0; index < gvExcelFile.Rows.Count; index++)
                {
                    string enrollid = gvExcelFile.Rows[index].Cells[0].Text;
                    string amount = gvExcelFile.Rows[index].Cells[1].Text;
                    CreateXml(enrollid, amount, insertBy);
                }
            }

            if (hdnConfirm.Value == "1")
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode node = doc.SelectSingleNode("SalaryEntry");
                string xmlString = node.InnerXml;
                xmlString = "<SalaryEntry>" + xmlString + "</SalaryEntry>";

                //dt = objBenifit.InsertBenifitInfo(1, 0, 0, xmlString);

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

        private XmlNode CreateItemNode(XmlDocument doc, string enrollid, string amount, string insertBy)
        {

            XmlNode node = doc.CreateElement("Salary");


            XmlAttribute Enrollid = doc.CreateAttribute("enrollid");
            Enrollid.Value = enrollid;

            XmlAttribute InsertBy = doc.CreateAttribute("insertBy");
            InsertBy.Value = insertBy;

            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            node.Attributes.Append(Enrollid);
            node.Attributes.Append(InsertBy);
            node.Attributes.Append(Amount);
            return node;
        }

        #endregion ======= end xml =======

    }

}