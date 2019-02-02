using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.Transfer
{
    public partial class InventoryTransferIN : BasePage
    {
        private readonly InventoryTransfer_BLL _bll = new InventoryTransfer_BLL();
        private DataTable _dt = new DataTable();
        private string xmlString;
        private int Id;
        private int intWh;
        private string[] arrayKey;
        private readonly char[] _delimiterChars = { '[', ']' };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                _dt = _bll.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, Enroll);
                Common.LoadDropDownWithSelect(ddlWh, _dt, "Id", "strName");
                _dt = _bll.GetTtransferDatas(2, xmlString, intWh, Id, DateTime.Now, Enroll);
                Common.LoadDropDownWithSelect(ddlTransferItem, _dt, "Id", "strName");
                Common.LoadDropDownWithSelect(ddlLcation, new DataTable(), "", "");
            }
        }

        #region========================Auto Search============================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            AutoSearch_BLL ast = new AutoSearch_BLL();
            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        #endregion====================Close======================================

        protected void ddlTransferItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(ddlTransferItem.SelectedValue);
                Session["WareID"] = intWh;
                _dt = _bll.GetTtransferDatas(3, xmlString, intWh, Id, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    string trasferId = _dt.Rows[0]["intTransferID"].ToString();
                    string strItem = _dt.Rows[0]["strItem"].ToString();
                    string intItemId = _dt.Rows[0]["intItemID"].ToString();
                    string outWhid = _dt.Rows[0]["intOutWHID"].ToString();
                    string strWareHoseName = _dt.Rows[0]["strWareHoseName"].ToString();
                    string monQty = _dt.Rows[0]["monQty"].ToString();
                    hdnInQty.Value = monQty;
                    string monValue = _dt.Rows[0]["monValue"].ToString();
                    string strUoM = _dt.Rows[0]["strUoM"].ToString();
                    DateTime dteTransactionDate = DateTime.Parse(_dt.Rows[0]["dteTransactionDate"].ToString());
                    int intUnitOUT = int.Parse(_dt.Rows[0]["intUnitID"].ToString());
                    int InUnitID = int.Parse(_dt.Rows[0]["InUnitId"].ToString());

                    string detalis = "From: " + strWareHoseName + " Qty: " + monQty + strUoM + " Date: " +
                                     dteTransactionDate.ToString("dd-MM-yyyy");
                    lblFrom.Text = detalis;

                    if (intUnitOUT == InUnitID)
                    {
                        _dt = _bll.GetTtransferDatas(4, xmlString, intWh, Id, DateTime.Now, Enroll);
                        Common.LoadDropDownWithSelect(ddlLcation, _dt, "Id", "strName");

                        txtItem.Text =
                            strItem + "[" + intItemId + "]" + "[Stock:" + monQty + strUoM +
                            "]"; //[]; RAM[512621][Stock: 0.0000 PCS]
                        _dt = _bll.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, Enroll);
                        if (_dt.Rows.Count > 0)
                        {
                            string strItems = _dt.Rows[0]["strItem"].ToString();
                            string intItem = _dt.Rows[0]["intItem"].ToString();
                            string strUom = _dt.Rows[0]["strUom"].ToString();
                            string intLocation = _dt.Rows[0]["intLocation"].ToString();
                            string strLocation = _dt.Rows[0]["strLocation"].ToString();
                            string monStock = _dt.Rows[0]["monStock"].ToString();
                            string monValues = _dt.Rows[0]["monValue"].ToString();

                            string detaliss = strItems + "  Stock: " + monStock + " Value: " + monValue + strUom +
                                              " Id: " + intItem;
                            lblDetalis.Text = detaliss;
                        }
                        else
                        {
                            lblDetalis.Text = "";
                        }
                    }
                    else
                    {
                        txtItem.Text = "";
                    }
                }
                else
                {
                    lblFrom.Text = "";
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(_delimiterChars);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0]; uom = arrayKey[3]; itemid = arrayKey[1]; }

                lblDetalis.Text = item + ", " + itemid + "," + uom;
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(itemid);

                //dt = _bll.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, Enroll);
                //if (dt.Rows.Count > 0)
                //{
                //    string strItem = dt.Rows[0]["strItem"].ToString();
                //    string intItem = dt.Rows[0]["intItem"].ToString();
                //    string strUom = dt.Rows[0]["strUom"].ToString();
                //    string intLocation = dt.Rows[0]["intLocation"].ToString();
                //    string strLocation = dt.Rows[0]["strLocation"].ToString();
                //    string monStock = dt.Rows[0]["monStock"].ToString();
                //    string monValue = dt.Rows[0]["monValue"].ToString();

                //    string detalis = "Stock: " + monStock + " Value: " + monValue + strUom + " Id: " + intItem;
                //    //lblFrom.Text = detalis;
                //}

                _dt = _bll.GetTtransferDatas(4, xmlString, intWh, Id, DateTime.Now, Enroll);
                Common.LoadDropDownWithSelect(ddlLcation, _dt, "Id", "strName");
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnSaveIn_Click(object sender, EventArgs e)
        {
            try
            {

                arrayKey = txtItem.Text.Split(_delimiterChars);
                string item = "";
                string itemid = "";
                string uom = "";
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0];
                    uom = arrayKey[3];
                    itemid = arrayKey[1];
                }
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(ddlTransferItem.SelectedValue);
                int location = int.Parse(ddlLcation.SelectedValue);
                double monTransQty = double.Parse(txtQty.Text);
                string strRemarks = txtRemarsk.Text;
                xmlString = "<voucher><voucherentry monTransQty=" + '"' + monTransQty + '"' + " strRemarks=" + '"' + strRemarks + '"' + " location=" + '"' + location + '"' + " itemid=" + '"' + itemid + '"' + "/></voucher>";
                if (int.Parse(itemid) > 1 && double.Parse(hdnInQty.Value) <= monTransQty)
                {
                    txtItem.Text = "";
                    txtQty.Text = "";
                    txtRemarsk.Text = "";
                    lblFrom.Text = "";
                    xmlString = "";
                    string msg = _bll.PostTransfer(6, xmlString, intWh, Id, DateTime.Now, Enroll);
                    if (msg.ToLower().Contains("success"))
                    {
                        _dt = _bll.GetTtransferDatas(2, xmlString, intWh, Id, DateTime.Now, Enroll);
                        Common.LoadDropDownWithSelect(ddlTransferItem, _dt, "Id", "strName");
                        Common.UnLoadDropDown(ddlLcation);
                        Toaster(msg, Common.TosterType.Success);
                    }
                    else
                    {
                        Toaster(msg, Common.TosterType.Error);
                    }
                }
                else
                {
                    Toaster("Check Item and stock properly", Common.TosterType.Warning);
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWh = Common.GetDdlSelectedValue(ddlWh);
                Session["WareID"] = intWh;
                if (intWh > 0)
                {
                    _dt = _bll.GetTtransferDatas(2, xmlString, intWh, Id, DateTime.Now, Enroll);
                    Common.LoadDropDownWithSelect(ddlTransferItem, _dt, "Id", "strName");
                }
                else
                {
                    Common.UnLoadDropDownWithSelect(ddlTransferItem);
                    Common.Clear(UpdatePanel0.Controls,null);
                    lblFrom.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

    }
}