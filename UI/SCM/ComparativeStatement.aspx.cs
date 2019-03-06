using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.DropDown;
using EmailService;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ComparativeStatement : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly PoGenerate_BLL _objPo = new PoGenerate_BLL();
        private readonly SupplierBll _supplier = new SupplierBll();
        private readonly ComparativeStatementBll _bll = new ComparativeStatementBll();
        private readonly Currency _currency = new Currency();
        private int _intWh, _indentNo;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["indentItems"] = null;
                InitLoad();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        #region Tab Click

        private void Clear()
        {
            List<Control> excepControlses = new List<Control> { txtDteTo, txtDtefroms };
            UpdatePanel0.Controls.Clear(excepControlses);


        }
        private void SetTabClickCss(object sender,int index)
        {
            try
            {
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                ((Button)sender).CssClass = "Clicked";

                MainView.ActiveViewIndex = index;
                Clear();

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, "Indent", Common.TosterType.Error);
            }
        }
        protected void Tab1_Click(object sender, EventArgs e)
        {
            SetTabClickCss(sender,0);
            
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            SetTabClickCss(sender,1);
        }
        protected void Tab3_OnClick(object sender, EventArgs e)
        {
            SetTabClickCss(sender,2);
        }
        protected void Tab4_OnClick(object sender, EventArgs e)
        {
            SetTabClickCss(sender,3);
        }
        protected void Tab5_OnClick(object sender, EventArgs e)
        {
            SetTabClickCss(sender,4);
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
            _dt = _objPo.GetPoData(1, "", 0, 0, DateTime.Now, Enroll);
            ddlWH.Loads(_dt, "Id", "strName");
            _dt.Clear();
        }

        private void LoadDepartment()
        {
            _dt = _objPo.GetPoData(21, "", 0, 0, DateTime.Now, Enroll);
            ddlDepts.Loads(_dt, "Id", "strName");
            _dt.Clear();
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvIndent.UnLoad();
            gvIndentDetails.UnLoad();

            _dt = _objPo.GetUnitID(ddlWH.SelectedValue());
            if (_dt.Rows.Count > 0)
            {
                hdnUnitId.Value = _dt.Rows[0]["intUnitId"].ToString();
                Session["untid"] = hdnUnitId.Value;
            }
            else
            {
                hdnUnitId.Value = "0";
            }
            hdnWHId.Value = ddlWH.SelectedValue().ToString();
            hdnWHName.Value = ddlWH.SelectedItem.ToString();
        }

        protected void btnSearchIndent_Click(object sender, EventArgs e)
        {
            try
            {
                gvIndent.UnLoad();

                _intWh = ddlWH.SelectedValue();
                hdnWHId.Value = _intWh.ToString();
                hdnWHName.Value = ddlWH.SelectedItem.ToString();
                DateTime dteFrom = DateTime.Parse(txtDtefroms.Text);
                DateTime dteTo = DateTime.Parse(txtDteTo.Text);
                string dept = ddlDepts.SelectedItem.ToString();
                int indentId = int.Parse(txtIndentNo.Text);
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";
                _dt = _objPo.GetPoData(2, xmlData, _intWh, indentId, dteFrom, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    hdnWHId.Value = _dt.Rows[0]["intWHID"].ToString();
                    hdnWHName.Value = _dt.Rows[0]["strWareHoseName"].ToString();
                    string type = _dt.Rows[0]["strIndentType"].ToString();

                    ddlWH.SetSelectedValue(hdnWHId.Value);
                    ddlDepts.SetSelectedText(type);

                    gvIndent.DataSource = _dt;
                    gvIndent.DataBind();
                    _dt.Clear();
                }
                else
                {
                    gvIndent.UnLoad();
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
                gvIndent.UnLoad();
                gvIndent.DataBind();

                _intWh = ddlWH.SelectedValue();
                hdnWHId.Value = _intWh.ToString();
                hdnWHName.Value = ddlWH.SelectedItem.ToString();

                DateTime dteFrom = DateTime.Parse(txtDtefroms.Text);
                string dept = ddlDepts.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + txtDteTo.Text + '"' + " dept=" +
                                 '"' + dept + '"' + " dteFrom=" + '"' + txtDtefroms.Text + '"' +
                                 "/></voucher>";
                _dt = _objPo.GetPoData(2, xmlData, _intWh, 0, dteFrom, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    gvIndent.DataSource = _dt;
                    gvIndent.DataBind();
                    _dt.Clear();
                }
                else
                {
                    gvIndent.UnLoad();
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

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblIndent = row.FindControl("lblIndent") as Label;
                if (lblIndent != null)
                {
                    int indent = int.Parse(lblIndent.Text);
                    _intWh = int.Parse(hdnWHId.Value);
                    lblIndentType.Text = ddlDepts.SelectedItem.ToString();
                    _dt = _objPo.GetPoData(3, "", _intWh, indent, DateTime.Now, Enroll);

                    if (_dt.Rows.Count > 0)
                    {
                        lblIndentDetUnit.Text = _dt.Rows[0]["strDescription"].ToString();
                        hdnUnitId.Value = _dt.Rows[0]["intUnitID"].ToString();

                        Session["unitId"] = hdnUnitId.Value;

                        lblIndentDetWH.Text = _dt.Rows[0]["strWareHoseName"].ToString();
                        lblIndentDate.Text = DateTime.Parse(_dt.Rows[0]["dteIndentDate"].ToString()).ToString("dd-MM-yyyy");
                        lblindentApproveDate.Text =
                            DateTime.Parse(_dt.Rows[0]["dteApproveDate"].ToString()).ToString("dd-MM-yyyy");
                        lblInDueDate.Text = DateTime.Parse(_dt.Rows[0]["dteDueDate"].ToString()).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        Toaster("Can not Load Indent Summery", Common.TosterType.Error);
                        return;
                    }

                    _dt = _objPo.GetPoData(4, "", _intWh, indent, DateTime.Now, Enroll); // Indent Detalis
                }
                if (_dt.Rows.Count > 0)
                {
                    Tab1.CssClass = "Initial";
                    Tab2.CssClass = "Clicked";
                    MainView.ActiveViewIndex = 1;
                    gvIndentDetails.Loads(_dt);
                    Session["indentItems"] = _dt;
                }
                else
                {
                    txtIndentNoDet.Text = "";
                    ddlItem.UnLoad();
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
                Session["unitId"] = "0";
            }
        }
        protected void dgvIndentDet_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                string remainQty = ((Label)e.Row.FindControl("lblRemaining")).Text;
                ((TextBox)e.Row.FindControl("txtRfqQty")).Text = remainQty;
            }

        }
        #endregion


        #region Indent Details

        protected void btnIndentDetShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation.CheckTextBox(txtIndentNoDet, "Indent No", out _indentNo, out string message))
                {
                    Toaster(message, Common.TosterType.Warning);
                    return;
                }
                string dept = ddlDepts.SelectedItem.ToString();
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + "2018-01-01" + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";

                _dt = _objPo.GetPoData(11, xmlData, int.Parse(hdnWHId.Value), _indentNo, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    ddlItem.Loads(_dt, "Id", "strName");
                    _dt.Clear();
                }
                else
                {
                    Toaster("This is not valid againest.'" + hdnWHName.Value + "'", Common.TosterType.Warning);
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
                _intWh = int.Parse(hdnWHId.Value);
                try
                {
                    _indentNo = int.Parse(txtIndentNoDet.Text);
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
                bool isExist = dt1.IsExist("ItemId", itemid);
                if (!isExist)
                {
                    _dt = _objPo.GetPoData(4, stringXml, _intWh, _indentNo, DateTime.Now, Enroll); // Indent Detalis
                    dt1.Merge(_dt);
                    gvIndentDetails.Loads(dt1);
                }
                else
                {
                    Toaster(Message.AlreadyAdded.ToFriendlyString(), Common.TosterType.Warning);
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
                int itemId = Convert.ToInt32((gvIndentDetails.Rows[e.RowIndex].FindControl("lblItemId") as Label)?.Text);
                if (Session["indentItems"] != null)
                {
                    _dt = (DataTable)Session["indentItems"];
                    _dt.RemoveRow("ItemId", itemId);
                    gvIndentDetails.Loads(_dt);
                }
                else
                {
                    Toaster("Session out, Please go from begining", Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnPrepareRfq_OnClick(object sender, EventArgs e)
        {
            InsertRfq();
        }

        public void LoadRfqView()
        {
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            MainView.ActiveViewIndex = 2;

            //lblUnitName.Text = hdnUnitName.Value;
            lblWH.Text = hdnWHName.Value;
            lblRfqBy.Text = UserEmail;

            if (JobStationId == 28)
            {
                imgUnit.ImageUrl = "/Content/images/img/" + "ag" + ".png";
            }
            else
            {
                imgUnit.ImageUrl = "/Content/images/img/" + hdnUnitId.Value + ".png";
            }
        }
        public void InsertRfq()
        {
            List<object> objects = GetGridViewData();
            if (objects.Count > 0)
            {
                string xml = XmlParser.GetXml("RFQ", "Item", objects, out string _);
                DataTable dt = _bll.InsertRfq(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(hdnWHId.Value), xml, Enroll, out string msg);
                if (msg.ToLower().Contains("success"))
                {
                    LoadRfqView();
                    LoadSupplier();
                    if (dt.Rows.Count > 0)
                    {
                        gvRfq.Loads(dt);
                        lblRfqNo.Text = dt.Rows[0]["intRfqId"].ToString();
                        lblRfqDate.Text = dt.Rows[0]["dteRfqDate"].ToString();
                        lblRfqBy.Text = dt.Rows[0]["strInsertBy"].ToString();
                        Toaster(msg, Common.TosterType.Success);
                    }
                    else
                    {
                        Toaster("RFQ Item Load Problem", Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster(msg, Common.TosterType.Error);
                }
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
            }
        }

        public List<object> GetGridViewData()
        {
            List<object> objects = new List<object>();
            foreach (GridViewRow row in gvIndentDetails.Rows)
            {
                string indentId = ((Label)row.FindControl("lblIndentId")).Text;
                string itemId = ((Label)row.FindControl("lblItemId")).Text;
                string indentQty = ((Label)row.FindControl("lblIndentQty")).Text;
                string numRfqQty = ((TextBox)row.FindControl("txtRfqQty")).Text;
                string remarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                if (string.IsNullOrWhiteSpace(numRfqQty))
                {
                    continue;
                }
                if (double.TryParse(numRfqQty, out double _))
                {
                    dynamic obj = new
                    {
                        indentId,
                        itemId,
                        indentQty,
                        numRfqQty,
                        remarks
                    };
                    objects.Add(obj);
                }
                else
                {
                    return objects;
                }

            }
            return objects;
        }
        public void LoadSupplier()
        {
            _dt = _supplier.GetSupplierInfo(1, Convert.ToInt32(hdnUnitId.Value), out string message);
            if (_dt.Rows.Count > 0)
            {
                ddlSupplier.LoadWithSelect(_dt, "intSupplierID", "strSupplierName");
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }

        #endregion

        #region RFQ

        protected void ddlSupplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierId = ddlSupplier.SelectedValue();
            if (supplierId != 0)
            {
                _dt = _supplier.GetSupplierInfo(2, supplierId, out string message);
                if (_dt.Rows.Count > 0)
                {
                    lblSupplierName.Text = _dt.Rows[0]["strSupplierName"].ToString();
                    lblSupplierAddress.Text = _dt.Rows[0]["strOrgAddress"].ToString();
                    lblSupplierContact.Text = _dt.Rows[0]["strOrgContactNo"].ToString();
                    lblSupplierEmail.Text = _dt.Rows[0]["strOrgMail"].ToString();
                }
                else
                {
                    Toaster(message, Common.TosterType.Error);
                }
            }
            else
            {
                lblSupplierName.Text = string.Empty;
                lblSupplierAddress.Text = string.Empty;
                lblSupplierContact.Text = string.Empty;
                lblSupplierEmail.Text = string.Empty;
            }
            
        }
        protected void btnEmail_OnClick(object sender, EventArgs e)
        {
            if (ddlSupplier.SelectedValue() < 1)
            {
                Toaster("Please Select Supplier", Common.TosterType.Warning);
                return;
            }
            string email = lblSupplierEmail.Text;
            email = "arafat.corp@akij.net";
            if (!string.IsNullOrWhiteSpace(email))
            {

                string lblRfqId = lblRfqNo.Text;
                if (!string.IsNullOrWhiteSpace(lblRfqId))
                {
                    if (int.TryParse(lblRfqId, out int rfqId))
                    {
                        int suppliertId = ddlSupplier.SelectedValue();
                        _bll.InsertRfqSentEmail(rfqId, suppliertId, Enroll, out string message);
                        if (message.ToLower().Contains("success"))
                        {
                            var sb = new StringBuilder();
                            dvTable.RenderControl(new HtmlTextWriter(new StringWriter(sb)));

                            EmailOptions options = new EmailOptions
                            {
                                Attachments = null,
                                BccAddress = null,
                                CcAddress = null,
                                Body = "Dear " + lblSupplierName.Text + " ,\nPlease give me the Price Qutation of following items.\n" + sb,
                                Subject = "Request For Qutation",
                                ToAddress = new List<string> { email },
                                ToAddressDisplayName = "Akij Procurement Department"
                            };
                            if (Email.SendEmail(options))
                            {
                                if (_bll.UpdateRfqEmailToSupplier(rfqId, suppliertId))
                                {
                                    Toaster(message, Common.TosterType.Success);
                                }
                                else
                                {
                                    Toaster("Email Sent Successfully but can not update email sent status.", Common.TosterType.Warning);
                                }

                            }
                            else
                            {
                                Toaster(options.Exceptions.Message, Common.TosterType.Error);
                            }


                        }
                        else
                        {
                            Toaster(message, Common.TosterType.Error);
                        }
                    }
                    else
                    {
                        Toaster("RFQ id not in correct format", Common.TosterType.Warning);
                    }

                }
                else
                {
                    Toaster("No RFQ Id Found", Common.TosterType.Warning);
                }

            }
            else
            {
                Toaster("This supplier have no email address to send", Common.TosterType.Warning);
            }
        }
        protected void btnRFQ_OnClick(object sender, EventArgs e)
        {
            string rfq = txtRfq.Text;
            if (string.IsNullOrWhiteSpace(rfq))
            {
                Toaster("RFQ id can not be blank", Common.TosterType.Warning);
                return;
            }
            if (int.TryParse(rfq, out int rfqId))
            {
                LoadSupplier();
            }
            else
            {
                Toaster("Enter Rfq Id properly", Common.TosterType.Warning);
            }
        }
        #endregion


        #region Quotation

        protected void ddlSupplierQ_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierId = ddlSupplierQ.SelectedValue();
            if (supplierId != 0)
            {
                _dt = _supplier.GetSupplierInfo(2, supplierId, out string message);
                if (_dt.Rows.Count > 0)
                {
                    lblSupplierNameQ.Text = _dt.Rows[0]["strSupplierName"].ToString();
                    lblSupplierAddressQ.Text = _dt.Rows[0]["strOrgAddress"].ToString();
                    lblSupplierContactQ.Text = _dt.Rows[0]["strOrgContactNo"].ToString();
                    lblSupplierEmailQ.Text = _dt.Rows[0]["strOrgMail"].ToString();
                }
                else
                {
                    Toaster(message, Common.TosterType.Error);
                }
            }
            else
            {
                lblSupplierNameQ.Text = string.Empty;
                lblSupplierAddressQ.Text = string.Empty;
                lblSupplierContactQ.Text = string.Empty;
                lblSupplierEmailQ.Text = string.Empty;
            }
            
        }

        protected void btnShowRFQQuotation_OnClick(object sender, EventArgs e)
        {
            string rfq = txtRfqQuotation.Text;
            if (string.IsNullOrWhiteSpace(rfq))
            {
                Toaster("RFQ id can not be blank",Common.TosterType.Warning);
                return;
            }
            if (int.TryParse(rfq, out int rfqId))
            {
                LoadSupplierQuotation(rfqId);
                LoadCurrencyQuotation();
            }
            else
            {
                Toaster("Enter Rfq Id properly",Common.TosterType.Warning);
            }

        }
        public void LoadCurrencyQuotation()
        {
            ddlCurrencyQ.LoadWithSelect(_currency.GetCurrency(), "id", "strName");
            ddlCurrencyQ.SetSelectedValue("1");
        }
        public void LoadRfqData(int rfqId)
        {
            DataTable dt = _bll.GetRfq(rfqId);
            if (dt.Rows.Count > 0)
            {
                gvQuotation.Loads(dt);
                lblRfqNoQ.Text = dt.Rows[0]["intRfqId"].ToString();
                lblRfqDateQ.Text = dt.Rows[0]["dteRfqDate"].ToString();
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
            }
        }

        public void LoadSupplierQuotation(int rfqId)
        {
            _dt = _supplier.GetSupplierInfo(3, rfqId, out string message);
            if (_dt.Rows.Count > 0)
            {
                ddlSupplierQ.LoadWithSelect(_dt, "intSupplierID", "strSupplierName");
                LoadRfqData(rfqId);
            }
            else
            {
                Toaster(message, Common.TosterType.Error);
            }
        }
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string rfq = lblRfqNoQ.Text;
            if (string.IsNullOrWhiteSpace(rfq))
            {
                Toaster("RFQ id can not be blank", Common.TosterType.Warning);
                return;
            }
            if (int.TryParse(rfq, out int rfqId))
            {
                int supplierId = ddlSupplierQ.SelectedValue();
                if (supplierId<1)
                {
                    Toaster("You have to select Supplier First",Common.TosterType.Warning);
                    return;
                }
                int currencyId = ddlCurrencyQ.SelectedValue();
                if (currencyId < 1)
                {
                    Toaster("You have to select Currency First", Common.TosterType.Warning);
                    return;
                }
                string quotation = txtQutationNo.Text;
                List<object> objects = GetQutationGridViewData();
                if (objects.Count > 0)
                {
                    string xml = XmlParser.GetXml("Quotation", "Item", objects, out string _);
                    string msg = _bll.InsertQuotation(quotation, rfqId, supplierId, currencyId, xml, Enroll);
                    if (msg.ToLower().Contains("success"))
                    {
                        Toaster(msg, Common.TosterType.Success);
                    }
                    else
                    {
                        Toaster(msg, Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster("Please Input All Quantity Properly",Common.TosterType.Warning);
                }

                
            }
            else
            {
                Toaster("Enter Rfq Id properly", Common.TosterType.Warning);
            }
        }

        public List<object> GetQutationGridViewData()
        {
            List<object> objects = new List<object>();
            foreach (GridViewRow row in gvQuotation.Rows)
            {
                string itemId = ((Label)row.FindControl("lblItemId")).Text;
                string numRfqQty = ((Label)row.FindControl("lblRfqQuantity")).Text;
                string numRate = ((TextBox)row.FindControl("rate")).Text;
                string numTotal = ((TextBox)row.FindControl("total")).Text;
                if (string.IsNullOrWhiteSpace(numRfqQty))
                {
                    continue;
                }
                if (double.TryParse(numRfqQty, out double _))
                {
                    dynamic obj = new
                    {
                        itemId,
                        numRfqQty,
                        numRate,
                        numTotal
                    };
                    objects.Add(obj);
                }
                else
                {
                    return objects;
                }

            }
            return objects;
        }

        #endregion

        #region Comparative Statement

        protected void btnShowCs_OnClick(object sender, EventArgs e)
        {
            DataTable dt = _bll.GetComperativeStatement(1755);
            string table = ToHtmlTable(dt);
            csTd.InnerHtml = table;
        }
        public string ToHtmlTable(DataTable dt)
        {
            string html = "<table style='border:1px solid black;'>";
            int prefixColumn = 4;
            int countColumn = dt.Columns.Count;
            int countRow = dt.Rows.Count;
            int countSupplier = (countColumn - prefixColumn) / 2;
            //add header row
            html += "<tr style='border:1px solid black; font-weight:bold; background-color:black; color:white'>";
            html += "<td style='border:1px solid grey;'>SN</td>";
            html += "<td style='border:1px solid grey;'>Item Id</td>";
            html += "<td style='border:1px solid grey;'>Item Name</td>";
            html += "<td style='border:1px solid grey;'>UoM</td>";
            html += "<td style='border:1px solid grey;'>RFQ Quantity</td>";
            for (int i = prefixColumn; i < countColumn- countSupplier; i++)
                html += "<td colspan=2 style='border:1px solid grey;'>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < countRow; i++)
            {
                html += "<tr style='border:1px solid black;'> ";
                html += "<td style='border:1px solid grey;'>"+(i+1)+"</td>";
                for (int j = 0; j < countColumn - countSupplier; j++)
                {
                    html += "<td style='border:1px solid black;'>" + dt.Rows[i][j] + "</td>";
                    if(j>= prefixColumn)
                    html += "<td style='border:1px solid black;'>" + dt.Rows[i][j+ countSupplier] + "</td>";
                }
                    
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

        #endregion

    }
}