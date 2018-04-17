using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class TADAEntryByAnotherRpt : System.Web.UI.Page
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        string strSearchKey, code, strCustname;
        int enrol;
        DataTable dt = new DataTable();

        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        //SalesView bll = new SalesView();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFullName.Attributes.Add("onkeyUp", "SearchText();");

            }
        }
        [WebMethod]

        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            SalesView bll = new SalesView();
            List<string> result = new List<string>();
            result = bll.AutoSearchTADAEmploye(strSearchKey);
            return result;
        }
        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadgrid()
        {
            int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
            int userTypeid = 1;

             if (rptTypeid == 1 && userTypeid == 1)               //Detaills report Bike car user  
            {

                //try
                //{
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    int unit = int.Parse(drdlUnit.SelectedValue.ToString());
                


                    dt = bll.getRptTADABikeAndCarUserDetaillsGB(dteFromDate, dteToDate, enrol, unit, rptTypeid);

                //}

                //catch
                //{

                //}

                if (dt.Rows.Count > 0)
                {


                    grdvBikeCarUserDetaills.DataSource = dt;
                    grdvBikeCarUserDetaills.DataBind();



                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

           

        }



        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void grdvBikeCarUserDetaills_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvBikeCarUserDetaills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

       
    }
}