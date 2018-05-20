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
using SAD_BLL.AutoChallan;

namespace UI.SAD.ExcelChallan
{
    public partial class frmAutoChallan : BasePage
    {
        string xmlpath;
        int ShipId, Offid, enroll;
        ExcelDataBLL objExcel = new ExcelDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/ExcelChallan/Data/AutoChallanupload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
              
                try
                {
                    File.Delete(xmlpath);
                }
                catch { }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            uploadfile();
        }

        private void uploadfile()
        {
            string ConStr = "";

            string strDocUploadPath = Path.GetFileName(FileUpload1.FileName);
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            string path = Server.MapPath("~/SAD/ExcelChallan/Data/" + FileUpload1.FileName);
            if (FileUpload1.HasFile.ToString() != null)
            {
                FileUpload1.SaveAs(path);
                if (ext.Trim() == ".xls")
                {
                    ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (ext.Trim() == ".xlsx")
                {
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                string query = "SELECT * FROM [Sheet1$]";
                OleDbConnection conn = new OleDbConnection(ConStr);
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

                DataTable dtTable = new DataTable();
                dtTable = (DataTable)ds.Tables[0];

                #region ********* Excel Data Get *************
                for (int i = 1; i < dtTable.Rows.Count; i++)
                {
                    for (int j = 4; j < dtTable.Columns.Count; j++)
                    {
                        string cid = dtTable.Rows[i][0].ToString();
                        string id = dtTable.Rows[0][j].ToString();
                        string qty = dtTable.Rows[i][j].ToString();
                        if (qty == "") { qty = "0"; }
                        //Response.Write(cid + "," + id + "," + qty + "</br>");
                        if (decimal.Parse(qty) > 0)
                        {CreateVoucherXml(cid, id, qty); }
                    }
                }

                ShipId = int.Parse(Request.QueryString["shippoint"].ToString());
                Offid = int.Parse(Request.QueryString["Office"].ToString());
                enroll = int.Parse(Request.QueryString["enroll"].ToString());
                Response.Write(ShipId);
                DateTime date = DateTime.Parse("2018-3-24");
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Voucher>" + xmlString + "</Voucher>";
                string message = objExcel.ExcelDataInsert(xmlString,ShipId,Offid,enroll,1);
                File.Delete(xmlpath);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                #endregion **************** End Excel data get **************
            }
            File.Delete(path);
        }
        private void CreateVoucherXml(string cid, string id, string qty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Voucher");
                XmlNode addItem = CreateItemNode(doc, cid, id, qty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Voucher");
                XmlNode addItem = CreateItemNode(doc, cid, id, qty);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            //LoadGridwithXml();
           // Clear();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string cid, string id, string qty)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Cid = doc.CreateAttribute("cid");
            Cid.Value = cid;
            XmlAttribute Id = doc.CreateAttribute("id");
            Id.Value = id;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
           
            node.Attributes.Append(Cid);
            node.Attributes.Append(Id);
            node.Attributes.Append(Qty);
           
            return node;
        }


    }
}