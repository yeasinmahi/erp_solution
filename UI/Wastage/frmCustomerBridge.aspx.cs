using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projects_BLL;
using UI.ClassFiles;
namespace UI.Wastage
{
    public partial class frmCustomerBridge : BasePage
    {
        DataTable dt;
        WastageBLL objWastage = new WastageBLL();
        string ItemName, COAName;
        int? intItemCategoryID, intUOMID, intWorkCount;
        DateTime? dteinsertdate;
        int? intCOAID = null, intItemid = null, intCustid = null, CustTypeid = null,empid=null;
        string custname = null, CustAdd = null, Coaname = null, PhoneNo = null;

      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                dt = objWastage.GetUnitList(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()));              
                ddlUnitCust.DataTextField = "strUnit";
                ddlUnitCust.DataValueField = "intUnitID";
                ddlUnitCust.DataSource = dt;
                ddlUnitCust.DataBind();
                Panel1.Visible = true;

                intWorkCount = 5;
                dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), empid, dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
                ddlCOAName.DataTextField = "strAccName";
                ddlCOAName.DataValueField = "intAccid";
                ddlCOAName.DataSource = dt;
                ddlCOAName.DataBind();

                CustomerList();
            }
        }
        protected void ddlUnitCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerList();
        }
        private void CustomerList()
        {
            dt = objWastage.CustomerList(int.Parse(ddlUnitCust.SelectedValue.ToString()));
            ddlcustlist.DataTextField = "strCustomerName";
            ddlcustlist.DataValueField = "intCustomerID";
            ddlcustlist.DataSource = dt;
            ddlcustlist.DataBind();

            intWorkCount = 5;
            dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(ddlUnitCust.SelectedValue.ToString()), empid, dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
            ddlCOAName.DataTextField = "strAccName";
            ddlCOAName.DataValueField = "intAccid";
            ddlCOAName.DataSource = dt;
            ddlCOAName.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = objWastage.getCheck(int.Parse(ddlCOAName.SelectedValue));
          
            if (int.Parse(dt.Rows[0]["checkcount"].ToString()) == 0)
            {
                intCustid=int.Parse(ddlcustlist.SelectedValue);
                intCOAID = int.Parse(ddlCOAName.SelectedValue);
                COAName =ddlCOAName.SelectedItem.ToString();

                intWorkCount = 7;
                dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, COAName, intCustid);
                dgvCustomerList.DataSource = dt;
                dgvCustomerList.DataBind();

                Panel1.Visible = true;
                Panel2.Visible = true;
            }

        }
        protected void rdnItem_CheckedChanged(object sender, EventArgs e)
        {
          
            Panel1.Visible = false;
            Panel2.Visible = false;
        }

        protected void rdnCust_CheckedChanged(object sender, EventArgs e)
        {
           
            Panel1.Visible = true;
            Panel2.Visible = true;
        }

        protected void btnCustSave_Click(object sender, EventArgs e)
        {
            CustTypeid = 1;
            dteinsertdate = DateTime.Now;
            intWorkCount = 8;
            custname = txtCustName.Text;
            CustAdd = txtCustName.Text;
            PhoneNo = txtPhone.Text;
            Coaname = ddlCOAName.SelectedItem.ToString();
            objWastage.insertAG(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
            txtCustName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

        }

        protected void btnCustReport_Click(object sender, EventArgs e)
        {

            intWorkCount = 6;
            dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), empid, dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
            dgvCustomerList.DataSource = dt;
            dgvCustomerList.DataBind();
        }

    }
}