using System;
using System.Web;
using System.Web.UI;
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
            //gridView.DataSource = _bll.GetSupportUsers();
            //gridView.DataBind();
        }
    }
}