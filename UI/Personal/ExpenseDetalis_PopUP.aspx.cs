using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using UI.ClassFiles;
using System.Drawing;

namespace UI.Personal
{
    public partial class ExpenseDetalis_PopUP : BasePage
    {
        Expance_BLL objExpance = new Expance_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                UIdesign();
            ExpanceDetalisReport();

                
            }

        }

        private void UIdesign()
        {
            int yeart; string year;
          //  string currentYear = DdlYear.SelectedItem.ToString().Substring(2, 2);
            string currentYear = DateTime.Now.Year.ToString().Substring(2, 2); 
            int dtyear = int.Parse(currentYear.ToString());
            //string retString = currentYear.Substring(8, 9);
            yeart = dtyear + 1;
            year = yeart.ToString();

            lblJul.Visible = true; lblAug.Visible = true; lblAug.Visible = true; LblSep.Visible = true; lblOct.Visible = true;
            LblNov.Visible = true; lblDec.Visible = true; lblJan.Visible = true; lblFeb.Visible = true; lblMar.Visible = true;
            lblApr.Visible = true; lblMay.Visible = true; lblJun.Visible = true;
        

            lblJul.Text = Convert.ToDateTime(7.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            lblAug.Text = Convert.ToDateTime(8.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            LblSep.Text = Convert.ToDateTime(9.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            lblOct.Text = Convert.ToDateTime(10.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            LblNov.Text = Convert.ToDateTime(11.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            lblDec.Text = Convert.ToDateTime(12.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            lblJan.Text = Convert.ToDateTime(1.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            lblFeb.Text = Convert.ToDateTime(2.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            lblMar.Text = Convert.ToDateTime(3.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            lblApr.Text = Convert.ToDateTime(4.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            lblMay.Text = Convert.ToDateTime(5.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            lblJun.Text = Convert.ToDateTime(6.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        }

        private void ExpanceDetalisReport()
        {
            try
            {
                int cosid = int.Parse(Request.QueryString["costid"].ToString());
                string cosname = Request.QueryString["strName"].ToString();
                string strYear = Request.QueryString["stryear"].ToString();
                int intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());

                int intEmployeeID = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = new DataTable();
                dt = objExpance.viewdetalis(intUnit, strYear, cosid, intEmployeeID);
                DgvExpance.DataSource = dt;
                DgvExpance.DataBind();
                Label2.Text = cosname.ToString();
                Label2.ForeColor = System.Drawing.Color.Green;
            }
            catch { }


        }
       

           


        protected void ExpanceDataBound(object sender, GridViewRowEventArgs e)
        {
            Int32 yeart; string year;
            string currentYear = Request.QueryString["stryear"].ToString().Substring(2, 2); 
            //string currentYear = DateTime.Now.Year.ToString().Substring(2, 2); 
            int dtyear = int.Parse(currentYear.ToString());
            //string retString = currentYear.Substring(8, 9);
            yeart = dtyear + 1;
            year = yeart.ToString();

            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    string currentMonth = Convert.ToDateTime(6.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;

            //    e.Row.Cells[4].Text = Convert.ToDateTime(7.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            //    e.Row.Cells[5].Text = Convert.ToDateTime(8.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            //    e.Row.Cells[6].Text = Convert.ToDateTime(9.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            //    e.Row.Cells[7].Text = Convert.ToDateTime(10.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            //    e.Row.Cells[8].Text = Convert.ToDateTime(11.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            //    e.Row.Cells[9].Text = Convert.ToDateTime(12.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
            //    e.Row.Cells[10].Text = Convert.ToDateTime(1.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            //    e.Row.Cells[11].Text = Convert.ToDateTime(2.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            //    e.Row.Cells[12].Text = Convert.ToDateTime(3.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            //    e.Row.Cells[13].Text = Convert.ToDateTime(4.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            //    e.Row.Cells[14].Text = Convert.ToDateTime(5.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
            //    e.Row.Cells[15].Text = Convert.ToDateTime(6.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;

            //}





        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int intcoa = int.Parse(searchKey[0].ToString());
                Int32 cosid = Int32.Parse(Request.QueryString["costid"].ToString());               
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                dt = objExpance.viewdetaliswithCOA(intcoa, cosid);
                dgvDetalisdiv.DataSource = dt;
                dgvDetalisdiv.DataBind();

                DgvExpance.DataSource = "";
                DgvExpance.DataBind();
            }
            catch { }

        }
        protected void btnDivClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
            ExpanceDetalisReport();
        }
    }
}