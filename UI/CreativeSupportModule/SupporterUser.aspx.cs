using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.CreativeSupport;
using UI.ClassFiles;

namespace UI.CreativeSupportModule
{
    public partial class SupporterUser : Page
    {
        private int _insertBy = 0;
        private readonly CreativeSBll _bll = new CreativeSBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadGrid();
            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            int enroll = 0;
            _insertBy = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            if (!string.IsNullOrWhiteSpace(txtEnroll.Text))
            {
                if (!int.TryParse(txtEnroll.Text, out enroll))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please type enroll properly');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please insert an enroll');", true);
                return;
            }
            if (_bll.InsertSupportUser(enroll, _insertBy))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Insert support user successfully');", true);
                LoadGrid();
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Someting is error');", true);
        }

        private void LoadGrid()
        {
            gridView.DataSource = _bll.GetSupportUsers();
            gridView.DataBind();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            HiddenField hdnDataId = (HiddenField)row.FindControl("supportUserId");
            int supportUserId = int.Parse(hdnDataId.Value);

            if (_bll.UpdateSupporterUser(supportUserId))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Removed');", true);
                LoadGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Someting is error');", true);

            }
        }
    }
}