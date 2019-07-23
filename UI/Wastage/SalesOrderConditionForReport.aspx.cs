using Projects_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Wastage
{
    public partial class SalesOrderConditionForReport : BasePage
    {

        #region Declaration
        WastageBLL objWastageBLL = new WastageBLL();
        string filePathForXML = string.Empty;
        string xmlString = string.Empty, xml = string.Empty;

        #endregion

        #region Event_Base

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/Wastage/Data/WOC_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML);

                    pnlUpperControl.DataBind();
                    BindWarehouse();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtSOCondition.Text != "") && (!string.IsNullOrEmpty(ddlSO.SelectedValue)))
            {
                CreateAddXml(ddlWHName.SelectedValue.ToString(), ddlSO.SelectedItem.ToString(), txtSOCondition.Text);

                txtSOCondition.Text = "";               
            }
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found To Add');", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void ddlWHName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSalesOrder();
        }

        protected void dgvWOCond_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void dgvWOCond_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("WOCond");
                xmlString = dSftTm.InnerXml;
                xmlString = "<WOCond>" + xmlString + "</WOCond>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvWOCond.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvWOCond.DataSource;
                dsGrid.Tables[0].Rows[dgvWOCond.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvWOCond.DataSource;

                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvWOCond.DataSource = "";
                    dgvWOCond.DataBind();
                }
                else {
                    LoadGridwithXml();
                }
            }
            catch { }
        }

        #endregion

        #region UMethod

        private void BindWarehouse()
        {
            DataTable dt = new DataTable();

            dt = objWastageBLL.getWHALL();
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWHID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
        }

        private void BindSalesOrder()
        {
            DataTable dt = new DataTable();

            dt = objWastageBLL.getSalesOrderList(int.Parse(ddlWHName.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                ddlSO.DataTextField = "strSalesOrderNo";
                ddlSO.DataValueField = "strSalesOrderNo";
                ddlSO.DataSource = dt;
                ddlSO.DataBind();
            }
        }

        private void CreateAddXml(string wareHouseId, string salesOrderId, string condition)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("WOCond");
                XmlNode addItem = CreateItemNode(doc, wareHouseId, salesOrderId, condition);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("WOCond");
                XmlNode addItem = CreateItemNode(doc, wareHouseId, salesOrderId, condition);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string wareHouseId, string salesOrderId, string condition)
        {
            XmlNode node = doc.CreateElement("WOCond");

            XmlAttribute WareHouseId = doc.CreateAttribute("WareHouseId");
            WareHouseId.Value = wareHouseId;

            XmlAttribute SalesOrderId = doc.CreateAttribute("SalesOrderId");
            SalesOrderId.Value = salesOrderId;   
            
            XmlAttribute Condition = doc.CreateAttribute("Condition");
            Condition.Value = condition;

            node.Attributes.Append(WareHouseId);
            node.Attributes.Append(SalesOrderId);
            node.Attributes.Append(Condition);
            return node;
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode xlnd = doc.SelectSingleNode("WOCond");

                xmlString = xlnd.InnerXml;
                xmlString = "<WOCond>" + xmlString + "</WOCond>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) {
                    dgvWOCond.DataSource = ds;
                }
                else {
                    dgvWOCond.DataSource = null;
                }
                dgvWOCond.DataBind();
            }
            catch {
                dgvWOCond.DataSource = null;
                dgvWOCond.DataBind();
            }
        }

        private void SaveData()
        {
            string msg = string.Empty;
            DateTime insertDate = DateTime.Now;
            int insertBy = 0;
            try
            {
                insertBy = int.Parse(hdnEnroll.Value);
                if (dgvWOCond.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvWOCond.Rows.Count; index++)
                    {
                        string condition = string.Empty;
                        int salesOId = 0, whId = 0;

                        string wareHouse = ((Label)dgvWOCond.Rows[index].FindControl("lblWHId")).Text.ToString();
                        string salesOrder = ((Label)dgvWOCond.Rows[index].FindControl("lblSalesOrder")).Text.ToString();
                        condition = ((Label)dgvWOCond.Rows[index].FindControl("lblCondition")).Text.ToString();

                        salesOId = int.Parse(salesOrder);
                        whId = int.Parse(wareHouse);

                        objWastageBLL.SaveWOCondition(salesOId, whId, condition, insertBy, insertDate);
                    }

                    msg = "Condition Save Successfully";
                    dgvWOCond.DataSource = null;
                    dgvWOCond.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                else
                {
                    msg = "No Data Found To Save";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }                                
        }

        #endregion


    }
}