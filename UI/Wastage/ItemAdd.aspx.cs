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
    public partial class ItemAdd : BasePage
    {
        DataTable dt;
        WastageBLL objWastage = new WastageBLL();
        string ItemName, COAName, CustomerName, CustAddress, Phone;
        int? intItemCategoryID, intUOMID, intWorkCount;
        DateTime? dteinsertdate;
        int? intCOAID = null, intItemid = null, intCustid = null, CustTypeid = null,empid=null;
        string custname = null, CustAdd = null, Coaname = null, PhoneNo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            
                dt = objWastage.GetUnitList(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()));              
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitID";
                ddlUnit.DataSource = dt;
                ddlUnit.DataBind();
                ddlUnitCust.DataTextField = "strUnit";
                ddlUnitCust.DataValueField = "intUnitID";
                ddlUnitCust.DataSource = dt;
                ddlUnitCust.DataBind();
                Panel1.Visible = false;

                //intWorkCount = 5;
                //dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), empid, dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
                //ddlUnitCust.DataTextField = "strUnit";
                //ddlUnitCust.DataValueField = "intUnitID";
                //ddlUnitCust.DataSource = dt;
                //ddlUnitCust.DataBind();

            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            intWorkCount = 2;
            dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), empid, dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
            dgvSOItem.DataSource = dt;
            dgvSOItem.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            intItemCategoryID = 12;
            ItemName = txtItemName.Text;
            intUOMID = int.Parse(ddlUOM.SelectedValue);
            dteinsertdate = DateTime.Now;
            intWorkCount = 1;
            objWastage.insertAG(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
            txtItemName.Text = "";
           
        }

        protected void rdnItem_CheckedChanged(object sender, EventArgs e)
        {
            Panel1st.Visible = true;
            Panel1sts.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = false;
        }

        protected void rdnCust_CheckedChanged(object sender, EventArgs e)
        {
            Panel1st.Visible = false;
            Panel1sts.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = true;
        }

        protected void btnCustSave_Click(object sender, EventArgs e)
        {
            CustTypeid = 1;
            dteinsertdate = DateTime.Now;
            intWorkCount = 3;
            custname = txtCustName.Text;
            CustAdd = txtCustName.Text;
            PhoneNo = txtPhone.Text;
            objWastage.insertAG(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);

            txtCustName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

        }

        protected void btnCustReport_Click(object sender, EventArgs e)
        {

            intWorkCount = 4;
            dt = objWastage.ItemListRpt(ItemName, intItemid, intItemCategoryID, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), dteinsertdate, true, intUOMID, intWorkCount, custname, CustAdd, PhoneNo, CustTypeid, intCOAID, Coaname, intCustid);
            dgvCustomerList.DataSource = dt;
            dgvCustomerList.DataBind();
        }

    }
}