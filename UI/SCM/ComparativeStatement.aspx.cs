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
        private readonly PoGenerate_BLL _objPo = new PoGenerate_BLL();
        private readonly Supplier supplier = new Supplier();
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
        
        #region Tab Click

        private void SetTabClickCss(object sender)
        {
            try
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                ((Button) sender).CssClass = "Clicked";
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void Tab1_Click(object sender, EventArgs e)
        {
            SetTabClickCss(sender);
            MainView.ActiveViewIndex = 0;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            SetTabClickCss(sender);
            MainView.ActiveViewIndex = 1;
        }
        protected void Tab3_OnClick(object sender, EventArgs e)
        {
            SetTabClickCss(sender);
            MainView.ActiveViewIndex = 2;
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
            dt = _objPo.GetPoData(1, "", 0, 0, DateTime.Now, Enroll);
            ddlWH.Loads(dt, "Id", "strName");
            dt.Clear();
        }

        private void LoadDepartment()
        {
            dt = _objPo.GetPoData(21, "", 0, 0, DateTime.Now, Enroll);
            ddlDepts.Loads(dt, "Id", "strName");
            dt.Clear();
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvIndent.UnLoad();
            dgvIndentDet.UnLoad();

            dt = _objPo.GetUnitID(ddlWH.SelectedValue());
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
                dt = _objPo.GetPoData(2, xmlData, intWh, indentId, dteFrom, Enroll);
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
                dt = _objPo.GetPoData(2, xmlData, intWh, 0, dteFrom, Enroll);
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
                dt = _objPo.GetPoData(3, "", intWh, indent, DateTime.Now, Enroll);
                
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

                dt = _objPo.GetPoData(4, "", intWh, indent, DateTime.Now, Enroll); // Indent Detalis
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
                if (!Validation.CheckTextBox(txtIndentNoDet, "Indent No", out indentNo, out string message))
                {
                    Toaster(message,Common.TosterType.Warning);
                    return;
                }
                string dept = ddlDepts.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + "2018-01-01" + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";

                dt = _objPo.GetPoData(11, xmlData, int.Parse(hdnWHId.Value), indentNo, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    ddlItem.Loads(dt, "Id", "strName");
                    dt.Clear();
                }
                else
                {
                    Toaster("This is not valid againest.'" + hdnWHName.Value + "'",Common.TosterType.Warning);
                }

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
                int itemid = ddlItem.SelectedValue();
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
                DataTable dt1 = new DataTable();
                if (Session["indentItems"] != null)
                {
                    dt1 = (DataTable)Session["indentItems"];
                }
                bool isExist = dt1.IsExist<int>("ItemId", itemid);
                if (!isExist)
                {
                    dt = _objPo.GetPoData(4, stringXml, intWh, indentNo, DateTime.Now, Enroll); // Indent Detalis
                    dt1.Merge(dt);
                    dgvIndentDet.Loads(dt1);
                }
                else
                {
                    Toaster(Message.AlreadyAdded.ToFriendlyString(),Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        protected void dgvIndentDet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int itemId = Convert.ToInt32((dgvIndentDet.Rows[e.RowIndex].FindControl("lblItemId") as Label)?.Text);
                if (Session["indentItems"] != null)
                {
                    dt = (DataTable)Session["indentItems"];
                    dt.RemoveRow("ItemId", itemId);
                    dgvIndentDet.Loads(dt);
                }
                else
                {
                    Toaster("There are no existing Data", Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnPrepareRfq_OnClick(object sender, EventArgs e)
        {
            //hdnUnitId.Value;
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            MainView.ActiveViewIndex = 2;
            dt = supplier.GetSupplierInfo(1, Convert.ToInt32(hdnUnitId.Value), out string message);
            if (dt.Rows.Count > 0)
            {
                ddlSupplier.Loads(dt, "intSupplierID", "strSupplierName");
            }
            else
            {
                Toaster(message,Common.TosterType.Error);
            }

        }

        #endregion


       

        
    }
}