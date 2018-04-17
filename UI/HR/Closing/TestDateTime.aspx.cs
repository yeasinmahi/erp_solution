using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Closing
{
    public partial class TestDateTime : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                }
            }
            catch { }
        }


        protected void tmStart_PreRender(object sender, EventArgs e)
        {
            TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
            TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
        }

        protected void tmStart_Init(object sender, EventArgs e)
        {
            TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
            TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
        }

        protected void tmStart_DataBinding(object sender, EventArgs e)
        {
            TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
            TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
        }

        protected void tmStart_Disposed(object sender, EventArgs e)
        {

        }

        protected void tmStart_Load(object sender, EventArgs e)
        {

        }

        protected void tmStart_Unload(object sender, EventArgs e)
        {

        }








    }
}