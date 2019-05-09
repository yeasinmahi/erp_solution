using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;
using BLL.Accounts.ChartOfAccount;

namespace UI.PaymentModule
{
    public partial class MaterialCOABridge : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/MaterialCOABridge.aspx";
        string stop = "stopping PaymentModule/MaterialCOABridge.aspx";

        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL(); Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;
        string[] arrayKey; char[] delimiterChars = { '[', ']' };

        string filePathForXML; string xmlString = ""; string xml, itemid,  strSupplier;
        int intUnitID, intCategoryID, intPart, intSupplierID, intCOAID;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MaterialCOABridge.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/ItemBridge_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvItemList.DataSource = ""; dgvItemList.DataBind();

                    dt = new DataTable();
                    dt = objBillReg.GetUnitListByUserID(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }

                    dt = new DataTable();
                    dt = objVoucher.GetCategory();
                    if (dt.Rows.Count > 0)
                    {
                        ddlCategory.DataTextField = "strReqItemCategory";
                        ddlCategory.DataValueField = "intAutoID";
                        ddlCategory.DataSource = dt;
                        ddlCategory.DataBind();
                        ddlCategory.Items.Insert(0, new ListItem("All Category", "0"));
                    }
                    Session["UnitM"] = ddlUnit.SelectedValue.ToString();

                    //LoadGrid();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }       
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MaterialCOABridge.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                try { intCategoryID = int.Parse(ddlCategory.SelectedValue.ToString());}
                catch { intCategoryID = 0; }
                if (intCategoryID == 0)
                {
                    dt = new DataTable();
                    dt = objVoucher.GetItemForCOABridge(intUnitID);
                }
                else
                {
                    dt = new DataTable();
                    dt = objVoucher.GetItemForCOABridgeByUnitAndCategory(intUnitID, intCategoryID);
                }                
                dgvItemList.DataSource = dt;
                dgvItemList.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region Web Method
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCOAList(string prefixText, int count)
        {
            return ChartOfAccStaticDataProvider.GetCOADataForAutoFillPaymentRegister(HttpContext.Current.Session["UnitM"].ToString(), prefixText);
        }

        #endregion Web Method

        protected void ddlUnit_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["UnitM"] = ddlUnit.SelectedValue.ToString();
            dgvItemList.DataSource = "";
            dgvItemList.DataBind();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvItemList.DataSource = "";
            dgvItemList.DataBind();
        }

        protected void dgvItemList_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in dgvItemList.Rows)
            {
                DropDownList ddlAccountName = gvRow.FindControl("ddlAccountName") as DropDownList;
                HiddenField hdnCOAID = gvRow.FindControl("hdnCOAID") as HiddenField;

                if (ddlAccountName != null && hdnCOAID != null)
                {
                    ddlAccountName.SelectedValue = hdnCOAID.Value;
                }
            }
        }
       
        protected void btnCOABankItem_Click(object sender, EventArgs e)
        {
            LoadGridBankItem();
        }        
        private void LoadGridBankItem()
        {
            var fd = log.GetFlogDetail(start, location, "btnCOABankItem_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MaterialCOABridge.aspx btnCOABankItem_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                try { intCategoryID = int.Parse(ddlCategory.SelectedValue.ToString()); }
                catch { intCategoryID = 0; }

                if (intCategoryID == 0)
                {
                    dt = new DataTable();
                    dt = objVoucher.GetCOABankItem(intUnitID);
                }
                else
                {
                    dt = new DataTable();
                    dt = objVoucher.GetCOABankItemByUnitAndCategoryID(intUnitID, intCategoryID);
                }
                dgvItemList.DataSource = dt;
                dgvItemList.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnCOABankItem_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnCOABankItem_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnUpdateBridge_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnUpdateBridge_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MaterialCOABridge.aspx btnUpdateBridge_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                if (dgvItemList.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvItemList.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvItemList.Rows[index].FindControl("chkRow")).Checked == true)
                        {
                            itemid = ((Label)dgvItemList.Rows[index].FindControl("lblItemID")).Text.ToString();
                            //coaid = ((DropDownList)dgvItemList.Rows[index].FindControl("ddlAccountName")).SelectedValue.ToString();

                            string coa = ((TextBox)dgvItemList.Rows[index].FindControl("txtCOA")).Text.ToString();
                            arrayKey = coa.Split(delimiterChars);
                            int coaid = int.Parse(arrayKey[3].ToString());

                            if (coaid > 0)
                            {
                                CreateVoucherXml(itemid, coaid.ToString());
                            }
                        }
                    }
                }

                if (dgvItemList.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("ItemBridge");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<ItemBridge>" + xmlString + "</ItemBridge>";
                        xml = xmlString;
                    }
                    catch { }
                    if (xml == "") { return; }
                }

                // string message = objVoucher.InsertAndUpdateSupplierCOA(intPart, intSupplierID, intUnitID, strSupplier, int.Parse(hdnEnroll.Value), intCOAID);
                string message = objVoucher.UpdateItemCOABridge(xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }

            fd = log.GetFlogDetail(stop, location, "btnUpdateBridge_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateVoucherXml(string itemid, string coaid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemBridge");
                XmlNode addItem = CreateItemNode(doc, itemid, coaid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemBridge");
                XmlNode addItem = CreateItemNode(doc, itemid, coaid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string coaid)
        {
            XmlNode node = doc.CreateElement("ItemBridge");
            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Coaid = doc.CreateAttribute("coaid"); Coaid.Value = coaid;
           
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Coaid);
            return node;
        }
        











    }
}