using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;
using SCM_BLL;

namespace UI.Wastage
{
    public partial class frmIssue : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        TransferBLLNew objwestage = new TransferBLLNew();
        DataTable dt;     
        string COAName, HOCOAName, filePathForXML,narration, xmlString, qty, rate, value, remarks, MRRNO;
        int intItemid,intSalesId, intSalesOrderQty, intIssuedQty, intTransactionTypeID, unitid, intinsertby, intWastageWareHouseID, intInOutReffID;
        int? COAid=null, HOCOAid = null, intQty = null, intOutQty = null, intWHID = null, intSalesID = null, intCustromerID = null, intDeliveryChallanNo = null, intWeightIDNo = null,
        intDepartmentID = null, strRequisitionID = null, intTransferWastageWareHouseID = null;
        Decimal monOutRate, monOutValue;


        DateTime dteTransactionDate;
        string strRemarks, strSalesOrderNo; bool? ysnActive = null, ysnIssueComplete = null;
        Decimal? monInRate = null, monInValue = null, monTotalIssueAmount=null;
      
         
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/Wastage/Data/SO_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML);

                    dt = new DataTable();
                    dt = obj.getInvintoryWH(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
                    ddlLocation.DataTextField = "strWareHoseName";
                    ddlLocation.DataValueField = "intWHID";
                    ddlLocation.DataSource = dt;
                    ddlLocation.DataBind();
                 
                    WHlist();
                    getSO();
                    getSODetails();

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        protected void ddlSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSODetails();
        }

        private void WHlist()
        {
            dt = obj.getWH(int.Parse(Session[SessionParams.USER_ID].ToString()));
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWHID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
            //dt=obj.getSalesOrderList(int.Parse(Session[SessionParams.USER_ID].ToString()));
        }
   
        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvSOItem.DataSource;
                dsGrid.Tables[0].Rows[dgvSOItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvSOItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(filePathForXML); dgvSOItem.DataSource = ""; dgvSOItem.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void ddlWHName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSO();
            getSODetails();
        }

        private void getSO()
        {
            dt = obj.getSalesOrderList(int.Parse(ddlWHName.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                ddlSO.DataTextField = "strSalesOrderNo";
                ddlSO.DataValueField = "strSalesOrderNo";
                ddlSO.DataSource = dt;
                ddlSO.DataBind();
            }
        }

        private void getSODetails()
        {
          

            dt = obj.getSODetails(int.Parse(ddlWHName.SelectedValue),(ddlSO.SelectedItem.ToString()));
            if (dt.Rows.Count > 0)
            {
                txtMRRN.Text = dt.Rows[0]["strMoneyRecNo"].ToString();
                txtDate.Text = DateTime.Parse(dt.Rows[0]["dteSalesDate"].ToString()).ToString("yyyy/mm/dd");
                txtCustomer.Text = dt.Rows[0]["strCustomerName"].ToString();
                hdncustomerid.Value = dt.Rows[0]["intCustomerID"].ToString();
                
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            getRpt();
        }

        private void getRpt()
        {
            unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString().ToString());
            if(unitid==11)
            { unitid = 16; }
            else { unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString().ToString()); }
            dt = obj.getSalesOrderView(ddlSO.SelectedItem.ToString(), unitid);
            if (dt.Rows.Count > 0)
            {
                dgvSOItem.DataSource = dt;
                dgvSOItem.DataBind();
            }
        }

      
        #region ===== Item Add & Load Grid Action ===========================================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSODate.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Date.');", true);

            }
            else
            {
                dt = obj.getCOA(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdncustomerid.Value));
                COAid = int.Parse(dt.Rows[0]["intCOAID"].ToString());
                COAName = (dt.Rows[0]["strCOAName"].ToString());
                dt = obj.getCOAAcc(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
                HOCOAid = int.Parse(dt.Rows[0]["intWastageSalesACCID"].ToString());
                HOCOAName = (dt.Rows[0]["strWastageSalesACCName"].ToString());

                monTotalIssueAmount = 0;
                #region ********** XML ************
                for (int index = 0; index < dgvSOItem.Rows.Count; index++)
                {
                    intItemid = int.Parse(((Label)dgvSOItem.Rows[index].FindControl("lblItemID")).Text.ToString());
                    intOutQty = int.Parse(((TextBox)dgvSOItem.Rows[index].FindControl("txtIssue")).Text.ToString());
                    intIssuedQty = int.Parse(((TextBox)dgvSOItem.Rows[index].FindControl("lblIssued")).Text.ToString());
                    intSalesOrderQty = int.Parse(((Label)dgvSOItem.Rows[index].FindControl("lblQty")).Text.ToString());
                    monOutRate = decimal.Parse(((Label)dgvSOItem.Rows[index].FindControl("lblRate")).Text.ToString());
                    monOutValue = decimal.Parse(monOutRate.ToString()) * decimal.Parse(intOutQty.ToString());
                    intSalesID = int.Parse(((HiddenField)dgvSOItem.Rows[index].FindControl("hdnSalesId")).Value.ToString());

                    if (decimal.Parse(intOutQty.ToString()) > 0)
                    {

                        dteTransactionDate = DateTime.Parse(txtSODate.Text);
                        intTransactionTypeID = 3;
                        unitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                        intinsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                        if (intSalesOrderQty == (intOutQty + intIssuedQty))
                        {
                            ysnIssueComplete = true;
                        }
                        else { ysnIssueComplete = false; }
                        ysnActive = true;
                        intWHID = int.Parse(ddlLocation.SelectedValue);
                        intWastageWareHouseID = int.Parse(ddlWHName.SelectedValue);
                        monTotalIssueAmount = monTotalIssueAmount + (monOutValue);
                        if (txtDeliveryChallano.Text == "")
                        {
                            intDeliveryChallanNo = int.Parse(txtDeliveryChallano.Text);
                        }
                        else { intDeliveryChallanNo = 0; }
                        intCustromerID = int.Parse(hdncustomerid.Value);
                        strSalesOrderNo = ddlSO.SelectedItem.ToString();
                        obj.getReceiveEntry(intInOutReffID, dteTransactionDate, intItemid, intQty, monInRate, monInValue, intOutQty, monOutRate, monOutValue, intTransactionTypeID, unitid, intinsertby, DateTime.Now, intWHID, ysnActive, strRemarks, ysnIssueComplete, intSalesID, intCustromerID, intDeliveryChallanNo, strSalesOrderNo, intWeightIDNo, intDepartmentID, int.Parse(Session[SessionParams.JOBSTATION_ID].ToString()), strRequisitionID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), intWastageWareHouseID, intTransferWastageWareHouseID);
                        narration = "Wastage Sales Order No. " + ddlSO.SelectedItem.ToString() + " & Delivery Challan No. " + txtDeliveryChallano.Text;
                        obj.gtCreateVoucher(dteTransactionDate, unitid, narration, monTotalIssueAmount, COAid, COAName, HOCOAid, HOCOAName, int.Parse(Session[SessionParams.USER_ID].ToString()));
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully.');", true);
                       
                    }
                   
                }
                getRpt();
            }
            #endregion **************** End **************

           
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            string strSearchKey = senderdata;
            string[] searchKey = Regex.Split(strSearchKey, ",");
            intSalesId =int.Parse(searchKey[0].ToString());

            objwestage.IssueDelete(int.Parse(Session[SessionParams.UNIT_ID].ToString()),intSalesId);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully.');", true);
            getRpt();
           
        }
      
        private void CreateAddXml(string itemid, string itemname, string uom, string qty, string rate, string value, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, rate, value, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, rate, value, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(filePathForXML);
                XmlNode xlnd = doc.SelectSingleNode("SOItem");
                xmlString = xlnd.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvSOItem.DataSource = ds; } else { dgvSOItem.DataSource = ""; }
                dgvSOItem.DataBind();
            }
            catch { dgvSOItem.DataSource = ""; dgvSOItem.DataBind(); }
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string itemname, string uom, string qty, string rate, string value, string remarks)
        {
            XmlNode node = doc.CreateElement("SOItem");

            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname"); Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate"); Rate.Value = rate;
            XmlAttribute Value = doc.CreateAttribute("value"); Value.Value = value;
            XmlAttribute Remarks = doc.CreateAttribute("remarks"); Remarks.Value = remarks;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Value);
            node.Attributes.Append(Remarks);
            return node;
        }
        protected void dgvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvSOItem.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvSOItem.DataSource;
                dsGrid.Tables[0].Rows[dgvSOItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvSOItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvSOItem.DataSource = ""; dgvSOItem.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected decimal totalqty = 0;
        protected decimal totalvalue = 0, totalIssuevalue=0;
        protected void dgvSOItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                    totalIssuevalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("txtIssueValues")).Text);

                }
            }
            catch { }
        }

        #endregion ==========================================================================================

       

























    }
}