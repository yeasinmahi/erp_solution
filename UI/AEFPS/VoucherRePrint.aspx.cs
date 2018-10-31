using System;
using System.Web;
using System.Web.UI;
using SAD_BLL.AEFPS;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class VoucherRePrint : Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();
        int _intEnroll;

        protected void Page_Load(object sender, EventArgs e)
        {
            _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            LoadWh();
        }

        protected void btnRePrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
                string voucharNumber = "SV" + txtVoucherName.Text;
                _bll.RePrintVoucher(whId, voucharNumber);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your desired data is printing...');", true);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something is error');", true);
            }
            
        }

        private void LoadWh()
        {
            
            ddlWh.DataSource = _bll.DataView(1, "", 0, 0, DateTime.Now, _intEnroll);
            ddlWh.DataTextField = "strName";
            ddlWh.DataValueField = "Id";
            ddlWh.DataBind();
        }

        protected void btnClearPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
                _bll.ClearPrinter(whId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully Cleared');", true);
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Cleaning Problem');", true);
            }
            
        }
    }
}