using System;

namespace UI.SCM
{
    public partial class PO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SetDefaultView();
            }
        }

        //private void SetDefaultView()
        //{
        //    MultiView1.ActiveViewIndex = 0;
        //}

        //protected void lnkTab1_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 0;
        //}
        //protected void lnkTab2_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 1;
        //}
        //protected void lnkTab3_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 2;
        //}
    }
}