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
    public partial class ExpanceReport_UI :BasePage
    {
        Expance_BLL objExpance = new Expance_BLL();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
                pnlUpperControl.DataBind();
             
               

            }
        }

        
      

        //private void loadheader()
        //{
        //    Int32 yeart; string year;
        //    string currentYear = DdlYear.SelectedItem.ToString().Substring(2, 2);
        //    //string currentYear = DateTime.Now.Year.ToString().Substring(2, 2); 
        //    int dtyear = int.Parse(currentYear.ToString());
        //    //string retString = currentYear.Substring(8, 9);
        //    yeart = dtyear + 1;
        //    year = yeart.ToString();

        //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //    TableHeaderCell cell = new TableHeaderCell();

        //    cell = new TableHeaderCell();
        //    cell.Text = "";
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(7.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(8.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(9.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(10.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(11.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(12.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + currentYear;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(1.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(2.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(3.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(4.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);
        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(5.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.Text = Convert.ToDateTime(6.ToString() + "/1/1900").ToString("MMMM").Substring(0, 3) + '-' + year;
        //    cell.ColumnSpan = 3;
        //    row.Controls.Add(cell);





        //    // row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        //    DgvExpance.HeaderRow.Parent.Controls.AddAt(0, row);
            

        //}

       
        protected void BtnShow_Click(object sender, EventArgs e)
        {
            if (DDlType.SelectedItem.Text == "Monthly")
            {
                Int32 yeart; string year;
                string currentYear = DdlYear.SelectedItem.ToString().Substring(2, 2);
                //string currentYear = DateTime.Now.Year.ToString().Substring(2, 2); 
                int dtyear = int.Parse(currentYear.ToString());
                //string retString = currentYear.Substring(8, 9);
                yeart = dtyear + 1;
                year = yeart.ToString();

                lblJul.Visible = true; lblAug.Visible = true; lblAug.Visible = true; LblSep.Visible = true; lblOct.Visible = true;
                LblNov.Visible = true; lblDec.Visible = true; lblJan.Visible = true; lblFeb.Visible = true; lblMar.Visible = true;
                lblApr.Visible = true; lblMay.Visible = true; lblJun.Visible = true;
                lbl1Q.Visible = false; lbl2Q.Visible = false; lbl3Q.Visible = false; lbl4Q.Visible = false;

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

                LoadGridMonthly();
              
            }

            else
            {
                lbl1Q.Visible = true; lbl2Q.Visible = true; lbl3Q.Visible = true; lbl4Q.Visible = true;

                lbl1Q.Text = "1st Quarter";
                lbl2Q.Text = "2nd Quarter";
                lbl3Q.Text = "3rd Quarter";
                lbl4Q.Text = "4th Quarter";
                lblJul.Visible = false; lblAug.Visible = false; lblAug.Visible = false; LblSep.Visible = false; lblOct.Visible = false;
                LblNov.Visible = false; lblDec.Visible = false; lblJan.Visible = false; lblFeb.Visible = false; lblMar.Visible = false;
                lblApr.Visible = false; lblMay.Visible = false; lblJun.Visible = false;
               
                LoadGridQuetrly();
            }
         
           

        }

        private void LoadGridQuetrly()
        {
            Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            //Int32 intUnit = int.Parse(1.ToString());
            Int32 intEmployeeID = int.Parse(Session[SessionParams.USER_ID].ToString());
           // Int32 intEmployeeID = int.Parse(1392.ToString());
            string stryear = DdlYear.SelectedItem.ToString();
            
            dgvQarter.Visible = true;
            dt = new DataTable();
            dt = objExpance.ExpanceViewData(intUnit, stryear, intEmployeeID);
            dgvQarter.DataSource = dt;
            dgvQarter.DataBind();
            DgvExpance.Visible = false;
        }

        private void LoadGridMonthly()
        {
            Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
           // Int32 intUnit = int.Parse(1.ToString());
            Int32 intEmployeeID = int.Parse(Session[SessionParams.USER_ID].ToString());
            //Int32 intEmployeeID = int.Parse(1392.ToString());
            string stryear = DdlYear.SelectedItem.ToString();
           

          
                DgvExpance.Visible = true;
                dt = new DataTable();
                 dt = objExpance.ExpanceViewData(intUnit, stryear, intEmployeeID);
                DgvExpance.DataSource = dt;
                DgvExpance.DataBind();
                dgvQarter.Visible = false;

          
        }

        public string GetJSFunctionString(object intCostCenter, object strAccountName)
        {
            string str = "";
            str = intCostCenter.ToString() + ',' + strAccountName.ToString();
            return str;
        }
        protected void btnQarterLy_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string ordernumber1 = datas[0].ToString();
                string ordernumber2 = datas[1].ToString();
                string strName = ordernumber2.ToString();
                string costid = ordernumber1.ToString();


                

                string stryear = DdlYear.SelectedItem.ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + costid + "','" + strName.ToString() + "','" + stryear + "');", true);

            }
            catch { }
        }

        protected void btnMonthlyD_Click(object sender, EventArgs e)
        {
            
            try
            {               

                char[] delimiterChars = { ',' };
                string temp =  ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string ordernumber1 = datas[0].ToString();
                string ordernumber2 = datas[1].ToString();
                string strName = ordernumber2.ToString();
                string costid = ordernumber1.ToString();

             

                string stryear = DdlYear.SelectedItem.ToString();



                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + costid + "','" + strName + "','" + stryear + "');", true);
                          

               
            }
            catch
            {
                
            }

        }
    }
}