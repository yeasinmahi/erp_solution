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
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using Purchase_BLL.Qc_Management;

namespace UI.QC_Management
{
    public partial class QcResultInput : BasePage
    {
        QcBllManagement Report = new QcBllManagement();
        DataTable dtWH = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                int enroll = int.Parse((Session[SessionParams.USER_ID].ToString()));
              
                dtWH = Report.getWHname(enroll);
                ddlwh.DataTextField = "strWareHoseName";
                ddlwh.DataValueField = "intWHID";
                ddlwh.DataSource = dtWH;
                ddlwh.DataBind();

                ddlpo.Visible = false;
                ddlPOType.Visible = false;
                ddlinvoiceno.Visible = false;
                ddlproductionid.Visible = false;
                
            }
        }

        protected void ddlwh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlPOType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtpotable = new DataTable();
            int WHid = int.Parse(ddlwh.SelectedValue.ToString());
            string WHName = ddlPOType.SelectedItem.ToString();

            dtpotable = Report.getPONO(WHid,WHName);
            ddlpo.DataTextField = "SupplierName";
            ddlpo.DataValueField = "intPOID";
            ddlpo.DataSource = dtpotable;
            ddlpo.DataBind();
        }

        protected void ddlpo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dtshimpointid = new DataTable();
                int pono = int.Parse(ddlpo.SelectedValue.ToString());

                dtshimpointid = Report.getshippointid(pono);


                ddlinvoiceno.DataTextField = "strInvoiceNumber";
                ddlinvoiceno.DataValueField = "intShipmentID";
                ddlinvoiceno.DataSource = dtshimpointid;
                ddlinvoiceno.DataBind();
            }
            catch { }
            int inputpono=int.Parse(ddlpo.SelectedValue.ToString());
            Session["inputpono"] = inputpono;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dtReceivableItemQty = new DataTable();
            DataTable dtProductionInfo = new DataTable();
            int unitid = int.Parse((Session[SessionParams.UNIT_ID].ToString()));
            int qcnum = int.Parse(hdnQC.Value.ToString());

            if (qcnum == 44)
            {
                int productionid = int.Parse(ddlproductionid.SelectedItem.ToString());
                Session["inputpono"] = productionid;
                dtProductionInfo = Report.getProductionInfoByProduction(productionid, qcnum);
             

                GridView1.DataSource = dtProductionInfo;
                GridView1.DataBind();
            
            }
            else if (qcnum == 45)
            {
                int productionid = int.Parse(ddlproductionid.SelectedItem.ToString());
                Session["inputpono"] = productionid;
                dtProductionInfo = Report.getProductionInfoByProduction(productionid, qcnum);
              

                GridView1.DataSource = dtProductionInfo;
                GridView1.DataBind();
            }
            else
            {


                int ponumber = int.Parse(ddlpo.SelectedValue.ToString());
                int shipmentnumber;
                try
                {
                    shipmentnumber = int.Parse(ddlinvoiceno.SelectedValue.ToString());
                }
                catch
                {
                    shipmentnumber = int.Parse("0");
                }
                int ysnpotype = int.Parse(ddlPOType.SelectedValue);
                bool ysnbit;
                if (ysnpotype == 1)
                {
                    ysnbit = bool.Parse(true.ToString());
                }
                else
                {
                    ysnbit = bool.Parse(false.ToString());
                }

                dtReceivableItemQty = Report.getReceiveableProduct(ponumber, shipmentnumber, ysnbit);
                GridView1.DataSource = dtReceivableItemQty;
                GridView1.DataBind();
            }
            //
        }

        protected void ddlinvoiceno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 itemid = int.Parse(searchKey[0].ToString());
                Session["itemid"] = itemid;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('QCResultEntry.aspx');", true);


            }
            catch { }


        }
        protected void Update1(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 itemid = int.Parse(searchKey[0].ToString());
                Session["itemid"] = itemid;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('QCtestentry.aspx');", true);


            }
            catch { }


        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ddlpo.Visible = true;
            ddlPOType.Visible = true;
            ddlinvoiceno.Visible = true;
            ddlproductionid.Visible = false;
            hdnQC.Value = "43";
        }

        protected void Radiobuttoin1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlproductionid_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Radiobuttoin3_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtProduction = new DataTable();
            int unitid = int.Parse((Session[SessionParams.UNIT_ID].ToString()));
            ddlpo.Visible = false;
            ddlPOType.Visible = false;
            ddlinvoiceno.Visible = false;
            ddlproductionid.Visible = true;

            dtProduction = Report.getProductionNo(unitid);

            ddlproductionid.DataTextField = "intProductionID";
            ddlproductionid.DataSource = dtProduction;
            ddlproductionid.DataBind();


            hdnQC.Value = "45";
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtProductions = new DataTable();
            int unitid = int.Parse((Session[SessionParams.UNIT_ID].ToString()));
            ddlpo.Visible = false;
            ddlPOType.Visible = false;
            ddlinvoiceno.Visible = false;
            ddlproductionid.Visible = true;

            dtProductions = Report.getProductionNo(unitid);

            ddlproductionid.DataTextField = "intProductionID";
            ddlproductionid.DataSource = dtProductions;
            ddlproductionid.DataBind();
            hdnQC.Value = "44";
        }
    }
}