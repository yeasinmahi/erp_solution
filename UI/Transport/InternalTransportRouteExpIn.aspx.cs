using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Transport
{
    public partial class InternalTransportRouteExpIn : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intUnitID; int intShipPointID; int intWork; string strTripSLNo; int intCheck; int ysnWonVehicle;
        int intVT; string strVTCom; int intReffID; int intInsertBy; string xml;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try { LoadGrid();

                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                //hdnEnroll.Value = "89736";
                //hdnUnit.Value = "4";
                pnlUpperControl.DataBind();

                dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitID";
                ddlUnit.DataSource = dt;
                ddlUnit.DataBind();

                intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
                intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());
                //intCheck = int.Parse(HttpContext.Current.Session["intCheck"].ToString());
                
                dt = obj.GetShipPointList(intUnitID);
                ddlShipPoint.DataTextField = "strName";
                ddlShipPoint.DataValueField = "intId";
                ddlShipPoint.DataSource = dt;
                ddlShipPoint.DataBind();

                //intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
                //intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());

                if (strVTCom == "1")
                {
                    rdoWon.Checked = false;
                    rdoRented.Checked = true;
                }
                else
                {
                    rdoWon.Checked = true;
                    rdoRented.Checked = false;
                }
                    
                ddlUnit.SelectedValue = intUnitID.ToString();
                ddlShipPoint.SelectedValue = intShipPointID.ToString();
                intCheck = int.Parse(HttpContext.Current.Session["intCheck"].ToString());
                ddlReportType.SelectedValue = intCheck.ToString();                    

                txtSearchTripSLNo.Text = "";

                ysnWonVehicle = 1;
                intWork = 1;
                strTripSLNo = "";

                dt = new DataTable();
                dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);
                if (dt.Rows.Count > 0)
                {
                    txtSearchTripSLNo.Text = dt.Rows[0]["Code"].ToString();
                }
                
                } 
                catch {

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    pnlUpperControl.DataBind();
                    
                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
                    intCheck = int.Parse(ddlReportType.SelectedValue.ToString());

                    ///if (rdoWon.Checked == true) { intVT = 1; } else { ysnWonVehicle = 0; intVT = 2; }

                    HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
                    HttpContext.Current.Session["intShipPointID"] = intShipPointID.ToString();
                    HttpContext.Current.Session["intCheck"] = intCheck.ToString();

                    txtSearchTripSLNo.Text = "";

                    ysnWonVehicle = 1;
                    intWork = 1;
                    strTripSLNo = "";
                    dt = new DataTable();
                    dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchTripSLNo.Text = dt.Rows[0]["Code"].ToString();
                    }
                }                               
            }
            else {

                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intCheck = int.Parse(ddlReportType.SelectedValue.ToString());

                HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
                HttpContext.Current.Session["intShipPointID"] = intShipPointID.ToString();
                HttpContext.Current.Session["intCheck"] = intCheck.ToString();
            }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();

            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());

            //intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
            //intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());

            txtSearchTripSLNo.Text = "";
            ysnWonVehicle = 1;
            intWork = 1;
            strTripSLNo = "";
            dt = new DataTable();
            dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);
            if (dt.Rows.Count > 0)
            {
                txtSearchTripSLNo.Text = dt.Rows[0]["Code"].ToString();
            }

            dgvReport.DataSource = "";
            dgvReport.DataBind();

        }
        protected void btnSearchTripList_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["RealoadFromVTComplete"] = "0";
            LoadGrid();
        }
        private void LoadGrid()
        {
            intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
            intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());
            
            strVTCom = HttpContext.Current.Session["RealoadFromVTComplete"].ToString();
            if (strVTCom == "1")
            {
                rdoWon.Checked = false;
                rdoRented.Checked = true;
            }

            //if (rdoWon.Checked == true) { intVT = 1; } else { intVT = 2; }
            //intVT = int.Parse(HttpContext.Current.Session["intVT"].ToString());
            //if (intVT == 2) { rdoRented.Checked = true; rdoWon.Checked = false; }

            intCheck = int.Parse(HttpContext.Current.Session["intCheck"].ToString());
            if (intCheck == 1) 
            { intWork = 2; dgvReport.Columns[9].Visible = true;}
            else if (intCheck == 2) { intWork = 4; dgvReport.Columns[10].Visible = true; }

            if (rdoWon.Checked == true) { ysnWonVehicle = 1; intVT = 1; } else { ysnWonVehicle = 0; intVT = 2; }
            HttpContext.Current.Session["intVT"] = intVT.ToString();
            
            strTripSLNo = "";
            dt = new DataTable();           
            dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();

            dgvReport.Columns[10].Visible = false;
            dgvReport.Columns[11].Visible = false;
            dgvReport.Columns[12].Visible = false;
            dgvReport.Columns[13].Visible = false;
            //if (intCheck == 1) { dgvReport.Columns[10].Visible = true; }
            //else if (intCheck == 2) { dgvReport.Columns[11].Visible = true; }

            //if (intVT == 1) { dgvReport.Columns[12].Visible = false; } 
            //else { dgvReport.Columns[12].Visible = true; dgvReport.Columns[10].Visible = false; }

            if (intCheck == 1) 
            {
                if (intVT == 1)
                {
                    dgvReport.Columns[10].Visible = true;                    
                }
                else { dgvReport.Columns[10].Visible = false; dgvReport.Columns[12].Visible = true; }
            }
            else 
            {
                if (intVT == 1)
                {
                    dgvReport.Columns[11].Visible = true;
                }
                else { dgvReport.Columns[11].Visible = false; dgvReport.Columns[13].Visible = true; }
            }
        }
        protected void Action_Click(object sender, EventArgs e)
        {
            //try
            //{
                string senderdata = ((Button)sender).CommandArgument.ToString();
                //dt = objPI.GetPIType(int.Parse(senderdata.ToString()));
                //string PIType = dt.Rows[0]["strPIType"].ToString();

            //    if (PIType == "PI")
            //    {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "InEntry('" + senderdata + "');", true);
            //    }
            //    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ContractItemDetails('" + senderdata + "');", true); }
            //}
            //catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }     
        protected void TripDetails_Click(object sender, EventArgs e) 
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TripDetails('" + senderdata + "');", true);
        }    
        protected void btnActionFuelC_Click(object sender, EventArgs e) 
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();

            dt = obj.GetCheckExpEntry(int.Parse(senderdata.ToString()));
            string CheckExp = dt.Rows[0]["ExpEntry"].ToString();

            if (CheckExp == "False")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "FuelCostOut('" + senderdata + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('ALREADY ESTIMATED EXPENSE SUBMITED.');", true);
            }
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
            //intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());

            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
            
            txtSearchTripSLNo.Text = "";

            ysnWonVehicle = 1;
            intWork = 1;
            strTripSLNo = "";
            dt = new DataTable();
            dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);
            if (dt.Rows.Count > 0)
            {
                txtSearchTripSLNo.Text = dt.Rows[0]["Code"].ToString();
            }

            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void btnSearchTripWise_Click(object sender, EventArgs e)
        {
            intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
            intShipPointID = int.Parse(HttpContext.Current.Session["intShipPointID"].ToString());

            //HttpContext.Current.Session["RealoadFromVTComplete"] = "0";

            intCheck = int.Parse(ddlReportType.SelectedValue.ToString());
            if (intCheck == 1) { intWork = 3; } else if (intCheck == 2) { intWork = 5; }

            if (rdoWon.Checked == true) { ysnWonVehicle = 1; } else { ysnWonVehicle = 0; }
            
            strTripSLNo = txtSearchTripSLNo.Text;
            dt = new DataTable();
            //dt = obj.GetTripReportForInEntry(intUnitID, intShipPointID);
            dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
        }
        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            intCheck = int.Parse(ddlReportType.SelectedValue.ToString());
            HttpContext.Current.Session["intCheck"] = intCheck.ToString();

            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        
        //rdoWon.Checked = true;
        //rdoRented.Checked = false;
        protected void rdoWon_CheckedChanged(object sender, EventArgs e) 
        {
            if (rdoWon.Checked == true) { rdoRented.Checked = false;} else { rdoWon.Checked = true; }
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void rdoRented_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRented.Checked == true) { rdoWon.Checked = false; } else { rdoRented.Checked = true; }
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void btnVendorV_Click(object sender, EventArgs e) 
        {
            if (hdnconfirm.Value == "1")
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();

                intWork = 6;
                intUnitID = int.Parse(Session[SessionParams.USER_ID].ToString());
                intShipPointID = 0;
                strTripSLNo = "0";
                ysnWonVehicle = int.Parse(senderdata.ToString());
                //Update Trip Close Of Vendors Transport
                dt = obj.GetTripInfoReport(intWork, intUnitID, intShipPointID, strTripSLNo, ysnWonVehicle);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Trip Close Successfully.');", true);

                LoadGrid();
            }
        }
        protected void btnVTripComplete_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();

            if (rdoWon.Checked == true) { intVT = 1; } else { intVT = 2; }
            HttpContext.Current.Session["intVT"] = intVT.ToString();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TripComplete('" + senderdata + "');", true);           
        }

        protected void btnCustBridge_Click(object sender, EventArgs e)  
        {
            if (hdnconfirm.Value == "1")
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();

                intWork = 2;              
                intReffID = int.Parse(senderdata.ToString());
                intInsertBy = 0;
                
                string message = obj.InsertAndUpdateCustInfoBridge(intWork, intReffID, intInsertBy, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
        }
        
        
    







    }
}