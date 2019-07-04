using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.HR.Employee
{
    public partial class EmployeeCardUpdate : System.Web.UI.Page
    {
        // Development Stoped DUE To Requirement Change

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string vMsg = string.Empty;
            vMsg = validationForUpdate();
            if (string.IsNullOrEmpty(vMsg))
                updateEmployeeCard();
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ vMsg + "');", true);
        }
               

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        private string validationForUpdate()
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(txtEnroll.Text.Trim()))
                msg = "Provide Enroll No.";
            else if (string.IsNullOrEmpty(lblEmpCard.Text.Trim()))
                msg = "Provide Employeed Card.";
            return msg;
        }

        private void updateEmployeeCard()
        {
            throw new NotImplementedException();
        }
    }
}