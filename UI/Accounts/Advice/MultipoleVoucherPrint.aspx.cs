using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class MultipoleVoucherPrint : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {  
                string userID = "" + Session[SessionParams.USER_ID];

                string htmlString = ""; 
                htmlString = HttpContext.Current.Session["htmlString"].ToString();
                Session["htmlString"] = "";
                lblhtml.Text = htmlString;
                     
                
            }
            catch (Exception ex)
            {
                 
            }
             
    }

      
    }
}