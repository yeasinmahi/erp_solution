using Purchase_BLL;
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

namespace UI.WoodPurchase
{
    public partial class WoodReceiveAMFLExcel : BasePage
    {
        DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL bll = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        int intPart, intEnroll, intWH, intPOID, intSupplierID, intWoodTypeID, intZoneID, intJobStationID, intUnitID, intCirCum, intGateEntry;
        decimal numPOQty, monRate, numTotalWeight, numDeduction;
        string strChallan, xml, xmlString, strVehicleNo, message, tagno, length, circum, cft, rate, itemid, recdate, chdate;
        DateTime dteReceiveDate, dteChallanDate;

        string xmlpath, strDocUploadPath, ext, path, ConStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                xmlpath = Server.MapPath("~/WoodPurchase/Data/Excelupload_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //

                    //Wear House Bind
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = bll.GetWHList(intEnroll);
                    ddlWHList.DataSource = dt;
                    ddlWHList.DataTextField = "strWareHoseName";
                    ddlWHList.DataValueField = "intWHID";
                    ddlWHList.DataBind();

                    intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetUnitJobStation(intWH);
                    hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                    hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                    LoadDropDown();
                    try
                    {
                        File.Delete(xmlpath);
                    }
                    catch { }
                }
            }
            catch { }
        }
        protected void ddlWHList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitJobStation(intWH);
                hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                LoadDropDown();
            }
            catch { }
        }
        protected void ddlPOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
            }
            catch { }
        }
        private void LoadDropDown()
        {
            try
            {
                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intJobStationID = int.Parse(hdnJobStaion.Value.ToString());

                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetPOList(intWH);
                ddlPOList.DataSource = dt;
                ddlPOList.DataValueField = "intPOID";
                ddlPOList.DataTextField = "strSupplierName";
                ddlPOList.DataBind();

                dt = new DataTable();
                dt = bll.GetWoodType(intUnitID);
                ddlWoodType.DataSource = dt;
                ddlWoodType.DataTextField = "strWoodType";
                ddlWoodType.DataValueField = "intWoodTypeID";
                ddlWoodType.DataBind();

                dt = new DataTable();
                dt = bll.GetZone(intUnitID, intJobStationID);
                ddlMokam.DataSource = dt;
                ddlMokam.DataTextField = "strZoneName";
                ddlMokam.DataValueField = "intZoneID";
                ddlMokam.DataBind();
            }
            catch { }
        }
        protected void btnShowPOItem_Click(object sender, EventArgs e)
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetPOWiseItem(intPOID);
                dgvReceive.DataSource = dt;
                dgvReceive.DataBind();
            }
            catch { }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            dgvReceive.DataSource = "";
            dgvReceive.DataBind();
            uploadfile();
        }
        private void uploadfile()
        {
            string ConStr = "";

            string strDocUploadPath = Path.GetFileName(FileUpload1.FileName);
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            string path = Server.MapPath("~/WoodPurchase/Data/" + FileUpload1.FileName);
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
                string query = "SELECT * FROM [Process$]";
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
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    //for (int j = 2; j < dtTable.Columns.Count; j++)
                    //{
                    tagno = dtTable.Rows[i][0].ToString();
                    length = dtTable.Rows[i][1].ToString();
                    circum = dtTable.Rows[i][2].ToString();
                    cft = dtTable.Rows[i][3].ToString();
                    rate = dtTable.Rows[i][4].ToString();
                    itemid = dtTable.Rows[i][5].ToString();
                    recdate = dtTable.Rows[i][5].ToString();
                    chdate = dtTable.Rows[i][5].ToString();

                    { CreateVoucherXml(tagno, length, circum, cft, rate, itemid); }
                    //}
                }

                intPart = 1;
                intSupplierID = int.Parse(hdnSupplierID.Value.ToString());
                intZoneID = int.Parse(ddlMokam.SelectedValue.ToString());
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                intWoodTypeID = int.Parse(ddlWoodType.SelectedValue.ToString());
                intGateEntry = int.Parse(txtGateEntry.Text);
                strVehicleNo = txtVehicleNo.Text;
                intEnroll = int.Parse(hdnEnroll.Value.ToString());
                dteReceiveDate = DateTime.Parse(recdate.ToString());
                dteChallanDate = DateTime.Parse(chdate.ToString());

                message = bll.InsertPreReceive(intPart, intSupplierID, intZoneID, intPOID, dteReceiveDate, intWoodTypeID, dteChallanDate, intGateEntry, strVehicleNo, intEnroll, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                #endregion **************** End Excel data get **************

            }
            File.Delete(path);
        }
        private void CreateVoucherXml(string tagno, string length, string circum, string cft, string rate, string itemid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("PreReceive");
                XmlNode addItem = CreateItemNodePre(doc, tagno, length, circum, cft, rate, itemid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("PreReceive");
                XmlNode addItem = CreateItemNodePre(doc, tagno, length, circum, cft, rate, itemid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }

        private XmlNode CreateItemNodePre(XmlDocument doc, string tagno, string length, string circum, string cft, string rate, string itemid)
        {
            XmlNode node = doc.CreateElement("PreReceive");

            XmlAttribute TagNo = doc.CreateAttribute("tagno");
            TagNo.Value = tagno;
            XmlAttribute Length = doc.CreateAttribute("length");
            Length.Value = length;
            XmlAttribute Circum = doc.CreateAttribute("circum");
            Circum.Value = circum;
            XmlAttribute CFT = doc.CreateAttribute("cft");
            CFT.Value = cft;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;
            XmlAttribute ItemID = doc.CreateAttribute("itemid");
            ItemID.Value = itemid;

            node.Attributes.Append(TagNo);
            node.Attributes.Append(Length);
            node.Attributes.Append(Circum);
            node.Attributes.Append(CFT);
            node.Attributes.Append(Rate);
            node.Attributes.Append(ItemID);
            return node;
        }
    }
}