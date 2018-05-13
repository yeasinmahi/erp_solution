using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.Transfer
{
    public partial class InventoryFGReceive : System.Web.UI.Page
    {
        InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL(); 
        DataTable dt = new DataTable(); string xmlString, filePathForXML; int Id;
        int enroll, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        int CheckItem = 1; decimal values;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlWh.DataSource = dt;
                ddlWh.DataTextField = "strName";
                ddlWh.DataValueField = "Id";
                ddlWh.DataBind();
                ddlWh.Items.Insert(0, new ListItem("Select", "0"));
                intWh = int.Parse(ddlWh.SelectedValue);
                dt = objTransfer.GetTtransferDatas(9, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlProductId.DataSource = dt;
                ddlProductId.DataTextField = "Id";
                ddlProductId.DataValueField = "Id";
                ddlProductId.DataBind();
                ddlProductId.Items.Insert(0, new ListItem("Select", "0"));

                dt = objTransfer.GetTtransferDatas(10, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlLcation.DataSource = dt;
                ddlLcation.DataTextField = "strName";
                ddlLcation.DataValueField = "Id";
                ddlLcation.DataBind();
                ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                ddlProduct.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            try
            { if(hdnPreConfirm.Value=="1")
                {
                    int intProdID =int.Parse(ddlProductId.SelectedValue.ToString());
                    string intItemID = ddlProduct.SelectedValue.ToString();
                    string intAutoID = hdnAutoId.Value.ToString();
                    intWh = int.Parse(ddlWh.SelectedValue);
                    string locationId = ddlLcation.SelectedValue.ToString();
                    string quantity = txtReceQty.Text.ToString();
                    if (decimal.Parse(quantity) > 0)
                    {
                        xmlString = "<voucher><voucherentry locationId=" + '"' + locationId + '"' + " quantity=" + '"' + quantity + '"' + " intItemID=" + '"' + intItemID + '"' + " intAutoID=" + '"' + intAutoID + '"' + "/></voucher>".ToString();
                        string   msg = objTransfer.PostTransfer(12, xmlString, intWh, intProdID, DateTime.Now, enroll);

                        lblDetalis.Text = "";
                        lblDate.Text = "";
                        txtReceQty.Text = "";
                        dt = objTransfer.GetTtransferDatas(9, xmlString, intWh, Id, DateTime.Now, enroll);
                        ddlProductId.DataSource = dt;
                        ddlProductId.DataTextField = "Id";
                        ddlProductId.DataValueField = "Id";
                        ddlProductId.DataBind();
                        ddlProductId.Items.Insert(0, new ListItem("Select", "0"));
                        ddlProduct.DataSource = "";
                        ddlProduct.DataBind();
                        ddlProduct.Items.Insert(0, new ListItem("Select", "0"));

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                    }
                }
                else { }
               

               
            }
            catch { }
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {

        }

        protected void ddlProductId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(ddlProductId.SelectedValue);

                dt = objTransfer.GetTtransferDatas(11, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlProduct.DataSource = dt;
                ddlProduct.DataTextField = "strName";
                ddlProduct.DataValueField = "Id";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select", "0"));
                txtReceQty.Text = "";
                lblUom.Text = "";
                lblDate.Text = "";
            }
            catch { }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWh.SelectedValue);
                Id = int.Parse(ddlProductId.SelectedValue);

                dt = objTransfer.GetTtransferDatas(11, xmlString, intWh, Id, DateTime.Now, enroll);
                if(dt.Rows.Count>0)
                {
                    string strItems = dt.Rows[0]["strName"].ToString();
                    string intItemID = dt.Rows[0]["intItemID"].ToString();
                    string strUoM = dt.Rows[0]["strUoM"].ToString();
                    string numSendStoreQty = dt.Rows[0]["numSendStoreQty"].ToString();
                    hdnInQty.Value = dt.Rows[0]["numSendStoreQty"].ToString();
                    string intAutoID = dt.Rows[0]["intAutoID"].ToString();
                    string EntryTime = dt.Rows[0]["EntryTime"].ToString();
                    hdnAutoId.Value = dt.Rows[0]["intAutoID"].ToString();
                    lblUom.Text = strUoM;
                    txtReceQty.Text = numSendStoreQty;
                    lblDate.Text = "Entry: "+EntryTime;
                     
                }
               

            }
            catch { }
        }

        protected void btnInActive_Click(object sender, EventArgs e)
        {

        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWh = int.Parse(ddlWh.SelectedValue);
                dt = objTransfer.GetTtransferDatas(9, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlProductId.DataSource = dt;
                ddlProductId.DataTextField = "Id";
                ddlProductId.DataValueField = "Id";
                ddlProductId.DataBind();
                ddlProductId.Items.Insert(0, new ListItem("Select", "0"));

                dt = objTransfer.GetTtransferDatas(10, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlLcation.DataSource = dt;
                ddlLcation.DataTextField = "strName";
                ddlLcation.DataValueField = "Id";
                ddlLcation.DataBind();
                ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
              

                ddlProduct.DataSource = "";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch { }
        }

        
    }
}