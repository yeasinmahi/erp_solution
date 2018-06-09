using HR_BLL.CreativeSupport;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Dairy_BLL;
using SAD_BLL.Transport;
using System.Text;
using System.Text.RegularExpressions;

namespace UI.CreativeSupportModule
{
    public partial class ItemCreateAndPointSet : System.Web.UI.Page
    {
        CreativeS_BLL objcr = new CreativeS_BLL();
        DataTable dt;

        int intPart, intPoint, intID; string strItemName;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            if (!IsPostBack)
            {
                ItemDDLLoad();
            }
        }
        private void ItemDDLLoad()
        {
            try
            {
                dt = new DataTable();
                dt = objcr.GetCreativeItemListForDDL();
                ddlItem.DataTextField = "strCreativeItemName";
                ddlItem.DataValueField = "intCreativeItemID";
                ddlItem.DataSource = dt;
                ddlItem.DataBind();
                
                ddlItemForUpdate.DataTextField = "strCreativeItemName";
                ddlItemForUpdate.DataValueField = "intCreativeItemID";
                ddlItemForUpdate.DataSource = dt;
                ddlItemForUpdate.DataBind();                
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 1;
                    strItemName = txtItem.Text;
                    intPoint = int.Parse(txtPoint.Text);
                    intID = 0;

                    //Final In Insert
                    string message = objcr.ItemCreateAndPointSet(intPart, strItemName, intPoint, intID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtItem.Text = "";
                    txtPoint.Text = "";
                    ItemDDLLoad();
                }
            }
            catch { }

        }
        protected void btnPointUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 3;
                    strItemName = "";
                    intPoint = int.Parse(txtPointUpdate.Text);
                    intID = int.Parse(ddlItem.SelectedValue.ToString());

                    //Final In Insert
                    string message = objcr.ItemCreateAndPointSet(intPart, strItemName, intPoint, intID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);                    
                    ItemDDLLoad();
                }
            }
            catch { }
        }

        protected void btnItemNameUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 2;
                    strItemName = txtNewItemName.Text;
                    intPoint = 0;
                    intID = int.Parse(ddlItemForUpdate.SelectedValue.ToString());

                    //Final In Insert
                    string message = objcr.ItemCreateAndPointSet(intPart, strItemName, intPoint, intID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ItemDDLLoad();
                }
            }
            catch { }
        }











    }
}