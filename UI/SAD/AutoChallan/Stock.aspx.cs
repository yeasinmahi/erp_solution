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
using System.Globalization;



namespace UI.SAD.AutoChallan
{
    public partial class WebForm1 : BasePage
    {
        challanandPending AutoSearch_BLL = new challanandPending();
        DataTable dtShipingPoint = new DataTable();
        challanandPending Report = new challanandPending();
        DataTable dtSalesOfficeid = new DataTable();
        DataTable dtPendingReport = new DataTable();
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
                ddlShip.DataSource = dtShipingPoint;
                ddlShip.DataBind();

                string strdepot = Convert.ToString(dtShipingPoint.Rows[0]["depot"].ToString());
                HttpContext.Current.Session["Depot"] = strdepot;

               
            }
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchPartsData(strSearchKey);
            return result;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
          DataTable dtStock = new DataTable();
          
          DateTime dtefromdate = DateTime.Parse(txtFrom.Text.ToString());
          string dtto = txtTo.Text.ToString();
          hdntodate.Value = dtto;
          DateTime dtetodate = DateTime.Parse(hdntodate.Value);
          int shippointid = int.Parse(Session["Shippointid"].ToString()) ;
          string depotname =Convert.ToString( Session["depotnames"].ToString());
          int partid = int.Parse("1".ToString());

          dtStock = Report.getDepotStock(depotname, shippointid, partid, dtefromdate, dtetodate);
          GridView1.DataSource = dtStock;
          GridView1.DataBind();
        }

        protected void ddlShip_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int Shippointid = int.Parse(ddlShip.SelectedValue.ToString());
            dtSalesOfficeid = Report.getSalesofficeid(Shippointid);
            string strName = Convert.ToString(dtSalesOfficeid.Rows[0]["strName"].ToString());
            string depotnames = Convert.ToString(dtSalesOfficeid.Rows[0]["depot"].ToString());



            ddlSo.DataTextField = "strName";
            ddlSo.DataValueField = "intofficeid";
            ddlSo.DataSource = dtSalesOfficeid;
            ddlSo.DataBind();
            Session["strName"] = strName;
            Session["depotnames"] = depotnames;
            Session["Shippointid"] = Shippointid;
           
        }

        protected void ddlSo_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTodate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void txtTo_TextChanged1(object sender, EventArgs e)
        {

        }
    }

}