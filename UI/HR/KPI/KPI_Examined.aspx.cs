using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.KPI;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.Drawing;

namespace UI.HR.KPI
{
    public partial class KPI_Examined : BasePage
    {
        KPI_BLL objExamine = new KPI_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                DateTime evdate = DateTime.Parse("2016-01-01".ToString());
                pnlUpperControl.DataBind();
                int intType = 7;
                dt = objExamine.ExaminedView(intType, 0, evdate, enroll, 0, 0);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }

        }

        public string GetJSFunctionString(object intEmployeeID, object EmpStatus)
        {
            string str = "";
            str = intEmployeeID.ToString() + ',' + EmpStatus.ToString();
            return str;
        }
        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string number1 = datas[0].ToString();
                string number2 = datas[1].ToString();
               // string number3 = datas[2].ToString();


                Session["intEmployeeID"] = number1;
                Session["EmpStatus"] = number2;
               
              
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "IssuePopUp('KPI_Examined_Issue.aspx');", true);

            }
            catch { }
        }
    }
}