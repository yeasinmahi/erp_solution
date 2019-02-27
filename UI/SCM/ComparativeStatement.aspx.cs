using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Flogging.Core;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ComparativeStatement : BasePage
    {
        private DataTable dt = new DataTable();
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private int intWh;
        private string filePathForXML, filePathForXMLPrepare, filePathForXMLPo, othersTrems, warrentyperiod;
        private string xmlString = "";
        private int indentNo, whid, unitid, supplierId, currencyId, costId, partialShipment, noOfShifment, afterMrrDay, noOfInstallment, intervalInstallment, noPayment, CheckItem;
        private string payDate, paymentTrems, destDelivery, paymentSchedule;
        

        private DateTime dtePo, dtelastShipment;
        private decimal others = 0, tansport = 0, grosDiscount = 0, commision, ait;
        private string[] arrayKey; private string strType;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/In__" + Enroll + ".xml");
            filePathForXMLPrepare = Server.MapPath("~/SCM/Data/InPre__" + Enroll + ".xml");
            filePathForXMLPo = Server.MapPath("~/SCM/Data/Po__" + Enroll + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                try { File.Delete(filePathForXMLPrepare); } catch { }
                try { File.Delete(filePathForXMLPo); } catch { }
                Session["indentItems"] = null;
                InitLoad();
            }
        }
        
        #region Tab1 Click

        protected void Tab1_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";

                MainView.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            try
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";

                MainView.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }

        #endregion

        #region Indent View
        private void InitLoad()
        {
            try
            {
                txtDtefroms.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LoadWh();
                LoadDepartment();


            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        private void LoadWh()
        {
            dt = objPo.GetPoData(1, "", 0, 0, DateTime.Now, Enroll);
            ddlWH.Loads(dt, "Id", "strName");
            dt.Clear();
        }

        private void LoadDepartment()
        {
            dt = objPo.GetPoData(21, "", 0, 0, DateTime.Now, Enroll);
            ddlDepts.Loads(dt, "Id", "strName");
            dt.Clear();
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvIndent.UnLoad();
            dgvIndentDet.UnLoad();

            dt = objPo.GetUnitID(ddlWH.SelectedValue());
            if (dt.Rows.Count > 0)
            {
                hdnUnitId.Value = dt.Rows[0]["intUnitId"].ToString();
                Session["untid"] = hdnUnitId.Value;
            }
            else
            {

                hdnUnitId.Value = "0";
            }
            hdnWHId.Value = ddlWH.SelectedValue().ToString();
            hdnWHName.Value = ddlWH.SelectedItem.ToString();

            hdnUnitName.Value = "0";
        }

        protected void btnSearchIndent_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.UnLoad();

                intWh = ddlWH.SelectedValue();
                hdnWHId.Value = intWh.ToString();
                hdnWHName.Value = ddlWH.SelectedItem.ToString();
                DateTime dteFrom = DateTime.Parse(txtDtefroms.Text);
                DateTime dteTo = DateTime.Parse(txtDteTo.Text);
                string dept = ddlDepts.SelectedItem.ToString();
                int indentId = int.Parse(txtIndentNo.Text);
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";
                dt = objPo.GetPoData(2, xmlData, intWh, indentId, dteFrom, Enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnWHId.Value = dt.Rows[0]["intWHID"].ToString();
                    hdnWHName.Value = dt.Rows[0]["strWareHoseName"].ToString();
                    string type = dt.Rows[0]["strIndentType"].ToString();

                    ddlWH.SetSelectedValue(hdnWHId.Value);
                    ddlDepts.SetSelectedText(type);

                    dgvIndent.DataSource = dt;
                    dgvIndent.DataBind();
                    dt.Clear();
                }
                else
                {
                    dgvIndent.UnLoad();
                    Toaster(Message.NoFound.ToFriendlyString(), "Indent", Common.TosterType.Warning);
                }


            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.UnLoad();
                dgvIndent.DataBind();

                intWh = ddlWH.SelectedValue();
                hdnWHId.Value = intWh.ToString();
                hdnWHName.Value = ddlWH.SelectedItem.ToString();

                DateTime dteFrom = DateTime.Parse(txtDtefroms.Text);
                DateTime dteTo = DateTime.Parse(txtDteTo.Text);
                string dept = ddlDepts.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + txtDteTo.Text + '"' + " dept=" +
                                 '"' + dept + '"' + " dteFrom=" + '"' + txtDtefroms.Text + '"' +
                                 "/></voucher>";
                dt = objPo.GetPoData(2, xmlData, intWh, 0, dteFrom, Enroll);
                if (dt.Rows.Count > 0)
                {
                    dgvIndent.DataSource = dt;
                    dgvIndent.DataBind();
                    dt.Clear();
                }
                else
                {
                    dgvIndent.UnLoad();
                    Toaster(Message.NoFound.ToFriendlyString(), "Indent", Common.TosterType.Warning);
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }

        protected void btnIndentDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    File.Delete(filePathForXML);
                    File.Delete(filePathForXMLPo);
                }
                catch
                {
                    File.Delete(filePathForXML);
                    File.Delete(filePathForXMLPo);
                }

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblIndent = row.FindControl("lblIndent") as Label;
                int indent = int.Parse(lblIndent.Text);
                intWh = int.Parse(hdnWHId.Value);
                lblIndentType.Text = ddlDepts.SelectedItem.ToString();
                dt = objPo.GetPoData(3, "", intWh, indent, DateTime.Now, Enroll);
                
                if (dt.Rows.Count > 0)
                {
                    lblIndentDetUnit.Text = dt.Rows[0]["strDescription"].ToString();
                    hdnUnitId.Value = dt.Rows[0]["intUnitID"].ToString();

                    Session["unitId"] = hdnUnitId.Value;

                    lblIndentDetWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
                    lblIndentDate.Text = DateTime.Parse(dt.Rows[0]["dteIndentDate"].ToString()).ToString("dd-MM-yyyy");
                    lblindentApproveDate.Text =
                        DateTime.Parse(dt.Rows[0]["dteApproveDate"].ToString()).ToString("dd-MM-yyyy");
                    lblInDueDate.Text = DateTime.Parse(dt.Rows[0]["dteDueDate"].ToString()).ToString("dd-MM-yyyy");
                }
                else
                {
                    Toaster("Can not Load Indent Summery", Common.TosterType.Error);
                    return;
                }

                dt = objPo.GetPoData(4, "", intWh, indent, DateTime.Now, Enroll); // Indent Detalis
                if (dt.Rows.Count > 0)
                {
                    Tab1.CssClass = "Initial";
                    Tab2.CssClass = "Clicked";
                    MainView.ActiveViewIndex = 1;
                    dgvIndentDet.Loads(dt);
                    Session["indentItems"] = dt;
                }
                else
                {
                    txtIndentNoDet.Text = "";
                    ddlItem.UnLoad();
                    return;
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
                Session["unitId"] = "0";
            }
        }
        #endregion


        #region Indent Details

        protected void btnIndentDetShow_Click(object sender, EventArgs e)
        {
            try
            {
                int indentNo = 0;
                if (!Validation.CheckTextBox(txtIndentNoDet, "Indent No", out indentNo, out string message))
                {
                    return;
                }
                string dept = ddlDepts.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + "2018-01-01" + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";

                dt = objPo.GetPoData(11, xmlData, int.Parse(hdnWHId.Value), indentNo, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    ddlItem.DataSource = dt;
                    ddlItem.DataTextField = "strName";
                    ddlItem.DataValueField = "Id";
                    ddlItem.DataBind();
                    dt.Clear();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This is not valid againest.'" + hdnWHName.Value + "'');", true); }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                string itemid = ddlItem.SelectedValue;
                intWh = int.Parse(hdnWHId.Value);
                try
                {
                    indentNo = int.Parse(txtIndentNoDet.Text);
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
                string stringXml = "<voucher><voucherentry itemid=" + '"' + itemid + '"' + "/></voucher>";
                int CheckDuplicate = 1;/* checkXmlItemData(itemid);
*/
                if (CheckDuplicate == 1)
                {
                    DataTable dt1 = new DataTable();
                    try { File.Delete(filePathForXML); } catch { };
                    if (Session["indentItems"] != null)
                    {
                        dt1 = (DataTable) Session["indentItems"];
                    }
                    dt = objPo.GetPoData(4, stringXml, intWh, indentNo, DateTime.Now, Enroll);// Indent Detalis
                    dt1.Merge(dt);
                    dgvIndentDet.Loads(dt1);
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    string indentId = dt.Rows[i]["indentId"].ToString();
                    //    string itemId = dt.Rows[i]["ItemId"].ToString();
                    //    string strItem = dt.Rows[i]["strItem"].ToString();
                    //    string strUom = dt.Rows[i]["strUom"].ToString();
                    //    string strHsCode = dt.Rows[i]["strHsCode"].ToString();
                    //    string strDesc = dt.Rows[i]["strDesc"].ToString();
                    //    string numCurStock = dt.Rows[i]["numCurStock"].ToString();
                    //    string numSafetyStock = dt.Rows[i]["numSafetyStock"].ToString();
                    //    string numIndentQty = dt.Rows[i]["numIndentQty"].ToString();
                    //    string numPoIssued = dt.Rows[i]["numPoIssued"].ToString();
                    //    string numRemain = dt.Rows[i]["numRemain"].ToString();
                    //    string numNewPo = dt.Rows[i]["numNewPo"].ToString();
                    //    string strSpecification = dt.Rows[i]["strSpecification"].ToString();
                    //    string monPreviousRate = dt.Rows[i]["monPreviousRate"].ToString();
                    //    CreateXml(indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                    //}

                    ////============================
                    //if (dgvIndentDet.Rows.Count > 0)
                    //{
                    //    for (int index = 0; index < dgvIndentDet.Rows.Count; index++)
                    //    {
                    //        string indentId = ((Label)dgvIndentDet.Rows[index].FindControl("lblIndentId")).Text;
                    //        string itemId = ((Label)dgvIndentDet.Rows[index].FindControl("lblItemId")).Text;
                    //        string strItem = ((Label)dgvIndentDet.Rows[index].FindControl("lblItemName")).Text;
                    //        string strUom = ((Label)dgvIndentDet.Rows[index].FindControl("lblUom")).Text;
                    //        string strHsCode = ((Label)dgvIndentDet.Rows[index].FindControl("lblHsCode")).Text;
                    //        string strDesc = ((Label)dgvIndentDet.Rows[index].FindControl("lblPurpose")).Text;// lblPurpose
                    //        string numCurStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblCurrentStock")).Text;
                    //        string numSafetyStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblSaftyStock")).Text;
                    //        string numIndentQty = ((Label)dgvIndentDet.Rows[index].FindControl("lblIndentQty")).Text;
                    //        string numPoIssued = ((Label)dgvIndentDet.Rows[index].FindControl("lblPoIssue")).Text;
                    //        string numRemain = ((Label)dgvIndentDet.Rows[index].FindControl("lblRemaining")).Text;
                    //        string numNewPo = ((TextBox)dgvIndentDet.Rows[index].FindControl("TxtNewPO")).Text;
                    //        string strSpecification = ((TextBox)dgvIndentDet.Rows[index].FindControl("txtSpecification")).Text; //lblSpecification as TextBox --
                    //        string monPreviousRate = ((Label)dgvIndentDet.Rows[index].FindControl("lblPreviousAvg")).Text;

                    //        CreateXml(indentId, itemId, strItem, strUom, strHsCode, strDesc, numCurStock, numSafetyStock, numIndentQty, numPoIssued, numRemain, numNewPo, strSpecification, monPreviousRate);
                    //    }
                    //}
                    //LoadGridwithXml();
                    //========================================
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        private int checkXmlItemData(string itemid)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(filePathForXML);
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (itemid == (ds.Tables[0].Rows[i].ItemArray[1].ToString()))
                {
                    CheckItem = 0;

                    break;
                }
                else
                {
                    CheckItem = 1;
                }
            }
            return CheckItem;
        }
        #endregion


        protected void dgvIndentDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataSet dsGrid = (DataSet) dgvIndentDet.DataSource;
                dsGrid.Tables[0].Rows[dgvIndentDet.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet) dgvIndentDet.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvIndentDet.DataSource = "";
                    dgvIndentDet.DataBind();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }
    }
}