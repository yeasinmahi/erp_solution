using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Data;

namespace UI.SCM
{
    public partial class SupplierReport : BasePage
    {
        Billing_BLL objbilling_BLL = new Billing_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {            
            int intunit =Convert.ToInt32( ddlUnit.SelectedItem.Value);
            string supType = ddlsupplier.SelectedItem.Text;
            dt = objbilling_BLL.GetSupplierData(1,intunit, supType,"","",0);
           
            if(dt.Rows.Count<=0)
            {
                GVList.DataSource = "";
                GVList.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                
            }
            else
            {
                GVList.DataSource = dt;
                GVList.DataBind();
            }

        }

        protected void GVList_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int intunit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            string supplierType = ddlsupplier.SelectedItem.Text;            
            GVList.EditIndex = e.NewEditIndex;
            dt = objbilling_BLL.GetSupplierData(1, intunit, supplierType, "", "", 0);
            GVList.DataSource = dt;
            GVList.DataBind();
        }

        protected void GVList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int intunit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            string supplierType = ddlsupplier.SelectedItem.Text;
            int supplierId = Convert.ToInt32( GVList.DataKeys[e.RowIndex].Value.ToString());
            TextBox personName = GVList.Rows[e.RowIndex].FindControl("txtstrReprName") as TextBox;
            TextBox contactNo = GVList.Rows[e.RowIndex].FindControl("txtstrReprContactNo") as TextBox;
            GVList.EditIndex = -1;
            try
            {
                dt = objbilling_BLL.GetSupplierData(2, intunit, supplierType, personName.Text, contactNo.Text, supplierId);
                GVList.DataSource = dt;
                GVList.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your Request is Successfully Updated...');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }

        }

        protected void GVList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVList.EditIndex = -1;
            int intunit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            string supplierType = ddlsupplier.SelectedItem.Text;
            dt = objbilling_BLL.GetSupplierData(1, intunit, supplierType, "", "", 0);
            GVList.DataSource = dt;
            GVList.DataBind();
        }
    }
}