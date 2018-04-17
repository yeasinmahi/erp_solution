using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RemoteProductDelivery : BasePage
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            }
            else
            {
               
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

       

       
       


       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

       





        private void showProductDelv()
        {
            DataTable oDTReportData = new DataTable();
           
            

            SAD_BLL.Customer.Report.StatementC st = new SAD_BLL.Customer.Report.StatementC();

            try
            {

                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                   string strSearchKey = txtFullName.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();
                  string strCustname = strSearchKey;
                    int intcustid = int.Parse(code);

                        oDTReportData = st.bllRmtProductDelivery(dtFromDate, dtToDate, intcustid);
                

            }
            catch
            {

            }



            
            if (oDTReportData.Rows.Count > 0)
            {
                GridView1.DataSource = oDTReportData;
                GridView1.DataBind();
            }


            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }





        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showProductDelv();
        }

        protected void btnShowDelvRepot_Click(object sender, EventArgs e)
        {
            showProductDelv();
        }



    }
}