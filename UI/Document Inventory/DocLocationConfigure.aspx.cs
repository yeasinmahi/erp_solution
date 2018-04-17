using HR_BLL.Document_Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Document_Inventory
{
    public partial class DocLocationConfigure : System.Web.UI.Page
    {
        docLocationConfig_BLL objDoc = new docLocationConfig_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadViewData();
            }
        }

        private void LoadViewData()
        {
            int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());


            dt = objDoc.DocQrCodeDetalis(1, 0, 0, 0, "", enroll);
            ddlLocation.DataSource = dt;
            ddlLocation.DataTextField = "Names";
            ddlLocation.DataValueField = "Id";
            ddlLocation.DataBind();

            dt = objDoc.DocQrCodeDetalis(2, 0, 0, 0, "", enroll);
            ddlFile.DataSource = dt;
            ddlFile.DataTextField = "Names";
            ddlFile.DataValueField = "Id";
            ddlFile.DataBind();
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1" && hdnCheck.Value == "1")
                {
                    int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int locationId = int.Parse(ddlLocation.SelectedValue);
                    int fileId = int.Parse(ddlFile.SelectedValue);
                    int docId = int.Parse(txtDocID.Text.ToString());
                    string naration = TxtStation.Text.ToString();
                    dt = objDoc.DocQrCodeDetalis(3, 0, 0, docId, "", enroll);
                    
                    if (docId > 0 && txtDocID.Text != "" )
                    {
                        string strmessage = objDoc.DocConfigSubmit(4, locationId, fileId, docId, naration, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strmessage + "');", true);
                        txtDocID.Text = ""; lblDoc.Text = ""; docName.Text = "";
                        TxtStation.Text = "";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PLease Scan Your Document QRCode');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                }
            }
            catch { }
           

        }

        protected void txtDocID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int docId = int.Parse(txtDocID.Text.ToString());

                dt = objDoc.DocQrCodeDetalis(3, 0, 0, docId, "", enroll);
                if (dt.Rows.Count > 0)
                {
                    lblDoc.Text = "Document Name:";
                    docName.Text = dt.Rows[0]["Names"].ToString();
                    hdnCheck.Value = "1";
                }
                else
                {
                    hdnCheck.Value = "0";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                }

            }
            catch { }
           
        }
    }
}