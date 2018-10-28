using System;

namespace UI.Import
{
    public partial class ImportFileManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
        }
    }
}