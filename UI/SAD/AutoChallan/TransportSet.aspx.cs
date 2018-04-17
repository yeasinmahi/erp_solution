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
using System.IO;
using System.Xml;

namespace UI.SAD.AutoChallan
{
    public partial class TransportSet : BasePage
    {
        DataTable dtShipingPoint = new DataTable();
        challanandPending Report = new challanandPending();
        DataTable dtSalesOfficeid = new DataTable();
        DataTable dtPendingReport = new DataTable();
        string filePathForXML;
        string rpt;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                txtVehicleno.Attributes.Add("onkeyUp", "SearchText();");
                txtdrivername.Attributes.Add("onkeyUp", "SearchTexts();");
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



        protected void Button1_Click1(object sender, EventArgs e)
        {

            if (txtFrom.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Date !');", true);
            }
            else
            {
                DataTable dtSlipReport = new DataTable();
                DataTable dtvehicleprogram = new DataTable();
                int shippointid = int.Parse(ddlShip.SelectedValue.ToString());
                int salesofficeid = int.Parse(ddlSo.SelectedValue.ToString());
                string depotname = Convert.ToString(Session["depotnames"].ToString());

                int Id = int.Parse(hdnFrom.Value);
                if (Id == 1)
                {

                    dtPendingReport = Report.getPendingReportVehicle(depotname, shippointid);
                    GridView1.DataSource = dtPendingReport;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                }
                else
                {
                    dtvehicleprogram = Report.getVehicleProgramReport(shippointid);
                    GridView2.DataSource = dtvehicleprogram;
                    GridView2.DataBind();
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                }
            }
          
            
        }
        protected double Pendingtotal = 0; protected double TotalQtytotal = 0;
       
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
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PendingView.aspx');", true);


            }
            catch { }


        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchPartsData(strSearchKey);
            return result;

        }
        [WebMethod]
        public static List<string> GetAutoCompleteDatas(string strSearchKey)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchDriverName(strSearchKey);
            return result;

        }
        protected void Updates(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno = Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('LoadingSlip.aspx');", true);




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
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("VehicleSet.aspx");
        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {

        }
        protected double Pendingtotals = 0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Mlqctotal += int.Parse(((Label)e.Row.Cells[1].FindControl("lblMlqc")).Text);

                if (((Label)e.Row.Cells[7].FindControl("lblPending")).Text == "")
                {
                    Pendingtotals += 0;
                }
                else
                {
                    Pendingtotals += double.Parse(((Label)e.Row.Cells[7].FindControl("lblPending")).Text);
                }


            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            


            DataTable dtDriverMobile = new DataTable();
            DataTable dtDriverName = new DataTable();

            Int32 driverenroll; int Vehicleid; string supliername;
            if (!String.IsNullOrEmpty(txtVehicleno.Text))
            {
                string strSearchKey = txtVehicleno.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                hdnvehicle.Value = searchKey[1];
                Int32 technichin = Int32.Parse(hdnvehicle.Value.ToString());
                Vehicleid = Convert.ToInt32(technichin.ToString());
            }
            else
            {
                Vehicleid = int.Parse("0");
            }
          
            if (!String.IsNullOrEmpty(txtdrivername.Text))
            {
                string strSearchKey = txtdrivername.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                HdfTechnicinCode.Value = searchKey[1];
                Int32 technichin = Int32.Parse(HdfTechnicinCode.Value.ToString());
                 driverenroll = Convert.ToInt32(technichin.ToString());
            }
            else
            {
                driverenroll = int.Parse("0");
            }
            if (hdnsuplier.Value ==Convert.ToString(1))
            {
                supliername = "Company";
            }
            else
            {
                supliername = txtVehicleSuplier.Text;
            }
           
            dtDriverMobile=Report.getDriverMobile(driverenroll);
            string  drivermobile=Convert.ToString(dtDriverMobile.Rows[0]["strContactNo1"].ToString());

            txtmobileno.Text=drivermobile;
            int shippointid = int.Parse(ddlShip.SelectedValue.ToString());
            string mobibleno=Convert.ToString(txtmobileno.Text);
             string drivername=Convert.ToString(txtdrivername.Text);
            string Vehicleno=Convert.ToString(txtVehicleno.Text);
           // int Vehicleid=int.Parse("1");
            if (GridView1.Rows.Count > 0)
            {

                for (int index = 0; index < GridView1.Rows.Count; index++)
                {

                 if (((CheckBox)GridView1.Rows[index].FindControl("chkSelect")).Checked == true)
                    {

                        string Custid = ((Label)GridView1.Rows[index].FindControl("lblCustid")).Text.ToString();
                        Report.insertVehicle(Custid, Vehicleno, Vehicleid, drivername, mobibleno, shippointid,supliername);
                        
                    }

                  }

               }
             
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);
          }
        protected void Updates1(object sender, EventArgs e)
        {
            DataTable dtvehicleprogram = new DataTable();
           
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                int Custid = Convert.ToInt32(searchKey[0].ToString());
                Session["slipno"] = Custid;

                Report.GetChancelChallanVehicle(Custid);
                int shippointid = int.Parse(ddlShip.SelectedValue.ToString());

                dtvehicleprogram = Report.getVehicleProgramReport(shippointid);
                GridView2.DataSource = dtvehicleprogram;
                GridView2.DataBind();
                GridView1.Visible = false;
                GridView2.Visible = true;
            }
            catch { }


        }
        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {
            hdnFrom.Value = "1";
        }

        protected void RadioButton2_CheckedChanged1(object sender, EventArgs e)
        {
            hdnFrom.Value = "2";
        }

       

        protected void txtVehicle1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            hdnsuplier.Value = "1";
            txtVehicleSuplier.Visible = false;
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            hdnsuplier.Value = "2";
            txtVehicleSuplier.Visible = true;
        }
        
        
       
    }
}