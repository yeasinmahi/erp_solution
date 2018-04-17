using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using SAD_BLL.AutoChallanBll;
using System.Text.RegularExpressions;
using SAD_BLL.Corporate_sales;


namespace UI.SAD.Corporate_sales
{
    public partial class Corp_AutoChallan : System.Web.UI.Page
    {
        DataTable dtShipingPoint = new DataTable();
        challanandPending Report = new challanandPending();
        DataTable dtSalesOfficeid = new DataTable();
        DataTable dtPendingReport = new DataTable();
        orderInputClass CorOrderClass = new orderInputClass();
        DataTable dtSlipReport = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
               // pnlUpperControl.DataBind();
               
                dtShipingPoint = Report.GetShiping();
                ddlShip.DataTextField = "strName";
                ddlShip.DataValueField = "intId";
                ddlShip.DataSource=dtShipingPoint;
                ddlShip.DataBind();

                string strdepot = Convert.ToString(dtShipingPoint.Rows[0]["depot"].ToString());
                HttpContext.Current.Session["Depot"] = strdepot;

            }
        }

        protected void btn_ImportCSV_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCusType_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        protected void rdoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged1(object sender, EventArgs e)
        {
          
            int Shippointid = int.Parse(ddlShip.SelectedValue.ToString());
            dtSalesOfficeid = Report.getSalesofficeid(Shippointid);       
            string strName=Convert.ToString(dtSalesOfficeid.Rows[0]["strName"].ToString());
            string depotnames = Convert.ToString(dtSalesOfficeid.Rows[0]["depot"].ToString());
            int officeid = int.Parse(dtSalesOfficeid.Rows[0]["intofficeid"].ToString());


            ddlSo.DataTextField = "strName";
            ddlSo.DataValueField = "intofficeid";
            ddlSo.DataSource = dtSalesOfficeid;
            ddlSo.DataBind();
            Session["strName"] = strName;
            Session["depotnames"] = depotnames;
            Session["Shippointid"] = Shippointid;
            Session["officeid"] = officeid;
           
        }

        protected void ddlSo_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchCustNameData(strSearchKey);
            return result;

        }



    

        protected void Button1_Click1(object sender, EventArgs e)
        {
         
            //if (txtFrom.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select date !');", true);
            //}
            //else
            //{

                int shippointid = int.Parse(ddlShip.SelectedValue.ToString());
                int salesofficeid = int.Parse(ddlSo.SelectedValue.ToString());
                string depotname = Convert.ToString(Session["depotnames"].ToString());
                int unitid = int.Parse("2");
                int Reportnumber = int.Parse(hdnReport.Value);
                if (Reportnumber == 1)
                {

                    dtPendingReport = CorOrderClass.getPendingReportCorp(unitid, shippointid);
                    GridView1.DataSource = dtPendingReport;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                }
                else
                {
                    dtSlipReport = Report.getSlipReport(shippointid);
                    GridView2.DataSource = dtSlipReport;
                    GridView2.DataBind();
                    GridView2.Visible = true;
                    GridView1.Visible = false;


                }
            //}

        }
        protected double Pendingtotal = 0; protected double TotalQtytotal = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[3].FindControl("lblqty")).Text == "")
                {
                    Pendingtotal += 0;
                }
                else
                {
                    Pendingtotal += double.Parse(((Label)e.Row.Cells[3].FindControl("lblqty")).Text);
                }


            }

        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 Custid = int.Parse(searchKey[0].ToString());
                Session["Custid"] = Custid;              
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('CorpPendingView.aspx');", true);


            }
            catch { }


        }
        protected void Updates(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno =Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('CorpLoadingSlip.aspx');", true);
            }
            catch { }


        }
        protected void Updates1(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno = Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;

                Report.GetChancelChallan(slipno);
                int shippointid = int.Parse(ddlShip.SelectedValue.ToString());
                dtSlipReport = Report.getSlipReport(shippointid);
                GridView2.DataSource = dtSlipReport;
                GridView2.DataBind();
                GridView2.Visible = true;
                GridView1.Visible = false;
              
            }
            catch { }


        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hdnReport.Value = "1";
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hdnReport.Value = "2";
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[3].FindControl("lblTotalQty")).Text == "")
                {
                    TotalQtytotal += 0;
                }
                else
                {
                    TotalQtytotal += double.Parse(((Label)e.Row.Cells[3].FindControl("lblTotalQty")).Text);
                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransportSet.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("webform1.aspx");
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            Response.Redirect("TransportSet.aspx");
        }

      
        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Stock.aspx");
        }


    }
}