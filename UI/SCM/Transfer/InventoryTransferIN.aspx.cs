using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.Transfer
{
    public partial class InventoryTransferIN : BasePage
    {
        InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        DataTable dt = new DataTable();string xmlString;int Id;
        int enroll, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlWh.DataSource = dt ;
                ddlWh.DataTextField = "strName";
                ddlWh.DataValueField = "Id"; 
                ddlWh.DataBind();
                ddlWh.Items.Insert(0, new ListItem("Select", "0"));
                dt = objTransfer.GetTtransferDatas(2, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlTransferItem.DataSource = dt;
                ddlTransferItem.DataTextField = "strName";
                ddlTransferItem.DataValueField = "Id";
                ddlTransferItem.DataBind();
                ddlTransferItem.Items.Insert(0, new ListItem("Select", "0"));



            }
        }

        #region========================Auto Search============================ 
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);

        }

        #endregion====================Close====================================== 
        protected void ddlTransferItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(ddlTransferItem.SelectedValue);
                Session["WareID"] = intWh;
                dt = objTransfer.GetTtransferDatas(3, xmlString, intWh, Id, DateTime.Now, enroll);
                if(dt.Rows.Count>0)
                {
                    string trasferId = dt.Rows[0]["intTransferID"].ToString();
                    string strItem = dt.Rows[0]["strItem"].ToString();
                    string intItemId = dt.Rows[0]["intItemID"].ToString();
                    string outWhid = dt.Rows[0]["intOutWHID"].ToString();
                    string strWareHoseName = dt.Rows[0]["strWareHoseName"].ToString();
                    string monQty = dt.Rows[0]["monQty"].ToString();
                    hdnInQty.Value = monQty.ToString();
                    string monValue = dt.Rows[0]["monValue"].ToString(); 
                    string strUoM= dt.Rows[0]["strUoM"].ToString();
                    DateTime dteTransactionDate=DateTime.Parse(dt.Rows[0]["dteTransactionDate"].ToString());
                    int intUnitOUT = int.Parse( dt.Rows[0]["intUnitID"].ToString()); 
                    int  InUnitID = int.Parse(dt.Rows[0]["InUnitId"].ToString());

                    string detalis = "From: " + strWareHoseName + " Qty: " + monQty + strUoM+ " Date: " + dteTransactionDate.ToString("dd-MM-yyyy");
                    lblFrom.Text = detalis;
                   

                    if(intUnitOUT == InUnitID)
                    {
                        dt = objTransfer.GetTtransferDatas(4, xmlString, intWh, Id, DateTime.Now, enroll);
                        ddlLcation.DataSource = dt;
                        ddlLcation.DataTextField = "strName";
                        ddlLcation.DataValueField = "Id";
                        ddlLcation.DataBind();
                        ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                        txtItem.Text = strItem + "["+ intItemId + "]"+ "[Stock:" + monQty + strUoM+"]";//[]; RAM[512621][Stock: 0.0000 PCS]
                        dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, enroll);
                        if (dt.Rows.Count > 0)
                        {

                            string strItems = dt.Rows[0]["strItem"].ToString();
                            string intItem = dt.Rows[0]["intItem"].ToString();
                            string strUom = dt.Rows[0]["strUom"].ToString();
                            string intLocation = dt.Rows[0]["intLocation"].ToString();
                            string strLocation = dt.Rows[0]["strLocation"].ToString();
                            string monStock = dt.Rows[0]["monStock"].ToString();
                            string monValues = dt.Rows[0]["monValue"].ToString();

                            string detaliss = strItems + "  Stock: " + monStock + " Value: " + monValue + strUom + " Id: " + intItem;
                            lblDetalis.Text = detaliss;
                        }
                        else { lblDetalis.Text = ""; }
                    }
                    else { txtItem.Text = ""; }
                 
                } else { lblFrom.Text = ""; }
            }
            catch { }
          

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid = arrayKey[1].ToString(); }

                lblDetalis.Text = item + ", " + itemid + "," + uom;
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(itemid.ToString());

                //dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, enroll);
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

                dt = objTransfer.GetTtransferDatas(4, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlLcation.DataSource = dt;
                ddlLcation.DataTextField = "strName";
                ddlLcation.DataValueField = "Id";
                ddlLcation.DataBind();
                ddlLcation.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch { }
          

        }

        protected void btnSaveIn_Click(object sender, EventArgs e)
        {
            try
            {
                if(hdnPreConfirm.Value=="1")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid =arrayKey[1].ToString(); }
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intWh = int.Parse(ddlWh.SelectedValue);
                    Id = int.Parse(ddlTransferItem.SelectedValue);
                    int location = int.Parse(ddlLcation.SelectedValue);
                    double monTransQty = double.Parse(txtQty.Text.ToString());
                    string strRemarks = txtRemarsk.Text.ToString(); 
                    xmlString = "<voucher><voucherentry monTransQty=" + '"' + monTransQty + '"' + " strRemarks=" + '"' + strRemarks + '"' + " location=" + '"' + location + '"'+ " itemid=" + '"' + itemid + '"' + "/></voucher>".ToString();
                    if (int.Parse(itemid) > 1 && double.Parse(hdnInQty.Value.ToString())<= monTransQty)
                    {

                        string msg = objTransfer.PostTransfer(6, xmlString, intWh, Id, DateTime.Now, enroll);
                        if (msg.Length > 23)
                        {
                            dt = objTransfer.GetTtransferDatas(2, xmlString, intWh, Id, DateTime.Now, enroll);
                            ddlTransferItem.DataSource = dt;
                            ddlTransferItem.DataTextField = "strName";
                            ddlTransferItem.DataValueField = "Id";
                            ddlTransferItem.DataBind();
                            ddlTransferItem.Items.Insert(0, new ListItem("Select", "0"));
                            txtItem.Text = "";
                            ddlLcation.DataSource = "";
                            ddlLcation.DataBind();
                            txtQty.Text = "";
                            txtRemarsk.Text = "";
                            lblFrom.Text = "";
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                       
                       
                    }
                  
                }
               
            }
            catch { }
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWh.SelectedValue);
                Session["WareID"] = intWh;
                dt = objTransfer.GetTtransferDatas(2, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlTransferItem.DataSource = dt;
                ddlTransferItem.DataTextField = "strName";
                ddlTransferItem.DataValueField = "Id"; 
                ddlTransferItem.DataBind();
                ddlTransferItem.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch { }
           
        }
    }
}