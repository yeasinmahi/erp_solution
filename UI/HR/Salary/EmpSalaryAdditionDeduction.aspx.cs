using HR_BLL.Salary;
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
        DataTable dt = new DataTable();

        SalaryInfo objSal = new SalaryInfo();
        string filePathForXML, path, msg="";
        private readonly string ftp = "ftp://ftp.akij.net/ExcelUpload/Benifit.xlsx";
        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath("~/HR/Salary/FileExcell/" + FileUpload1.FileName);
            filePathForXML = Server.MapPath("~/HR/Salary/FileExcell/Emp_Salary_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
               
                File.Delete(filePathForXML);
                try
                {
                    LoadType();
                }
                catch { }
            }
        }
        
        public void LoadType()
        {
            dt = objSal.GetType();
            ddlType.LoadWithSelect(dt, "intID", "strType");
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
                Session["mydataset"] = ds.Tables[0];
                //gvExcelFile.DataSource = ds.Tables[0];
                //gvExcelFile.DataBind();
                string insertBy = Session[SessionParams.USER_ID].ToString();
                dt = new DataTable();
                dt = (DataTable)Session["mydataset"];
                if (dt.Rows.Count > 0)
                {

                    for (int index = 0; index < dt.Rows.Count; index++)
                    {

                        //string enrollid = gvExcelFile.Rows[index].Cells[0].Text;
                        //string amount = gvExcelFile.Rows[index].Cells[1].Text;
                        string enrollid = dt.Rows[index]["Employee ID"].ToString();
                        string amount = dt.Rows[index]["Amount"].ToString();
                        CreateXml(enrollid, amount, insertBy);
                    }
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode node = doc.SelectSingleNode("SalaryEntry");
                string xmlString = node.InnerXml;
                xmlString = "<SalaryEntry>" + xmlString + "</SalaryEntry>";
                dt = objSal.SubmitSalaryAdditionDeduction(2, Convert.ToInt32(ddlType.SelectedItem.Value), xmlString);
                gvExcelFile.DataSource = dt;
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
                XmlNode rootNode = doc.SelectSingleNode("SalaryEntry");
                XmlNode addItem = CreateItemNode(doc, enrollid, Amount, insertBy);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SalaryEntry");
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
            

            if (hdnConfirm.Value == "1")
            {
                
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode node = doc.SelectSingleNode("SalaryEntry");
                    string xmlString = node.InnerXml;
                    xmlString = "<SalaryEntry>" + xmlString + "</SalaryEntry>";
                    objSal.SubmitSalaryAdditionDeduction(1, Convert.ToInt32(ddlType.SelectedItem.Value), xmlString);
                    string msg = "Data Submitted Successfully.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    try
                    {


                        File.Delete(filePathForXML);
                        gvExcelFile.UnLoad();
                        Session["mydataset"] = null;
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