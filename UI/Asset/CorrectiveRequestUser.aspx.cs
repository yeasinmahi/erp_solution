using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text.RegularExpressions;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class CorrectiveRequestUser : BasePage
    {
        AssetMaintenance objrequest = new AssetMaintenance(); 
        DataTable dt = new DataTable();
        DataTable asset = new DataTable();
        int intItem, intjobid, intenroll, intdept, intAssetAutoId; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\CorrectiveRequestUser";
        string stop = "stopping Asset\\CorrectiveRequestUser";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                  intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                  int Mnumber = int.Parse("0".ToString());
                  intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                  intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                dt = objrequest.MaintenaceJobstation();
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "strName";
                ddlLocation.DataValueField = "Id";
                ddlLocation.DataBind();

                dt = objrequest.NatureOfMaintenace();
                ddlType.DataSource = dt;
                ddlType.DataTextField = "strName";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();

                int location = int.Parse(ddlLocation.SelectedValue);
                getDepartment(location);
                ClearandBind(intenroll);
                dt.Clear();
                pnlUpperControl.DataBind();
               

                //if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
                //{
                //    depertmnet = objrequest.DepartmentbyCorporate();
                //    DdlDept.DataSource = depertmnet;
                //    DdlDept.DataTextField = "strDepatrment";
                //    DdlDept.DataValueField = "intDepartmentID";
                //    DdlDept.DataBind();
                //} 
                //else
                //{

                //    depertmnet = objrequest.DepartmentbyJobstation(intjobid);
                //    DdlDept.DataSource = depertmnet;
                //    DdlDept.DataTextField = "strDepatrment";
                //    DdlDept.DataValueField = "intDepartmentID";
                //    DdlDept.DataBind();
                //}

              

            }
        }

        private void getDepartment(int location)
        {
            try
            {
              
                if(location==0)
                {
                    dt = objrequest.DepartmentbyCorporate();
                    DdlDept.DataSource = dt;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();

                }
                else
                {
                    dt = objrequest.DepartmentbyJobstation(location);
                    DdlDept.DataSource = dt;
                    DdlDept.DataTextField = "strDepatrment";
                    DdlDept.DataValueField = "intDepartmentID";
                    DdlDept.DataBind();
                }
                dt.Clear();
            }
            catch { }
        }

        protected void BtnRequest_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\CorrectiveRequestUser BtnRequest_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                arrayKey = TxtAsset.Text.Split(delimiterChars);
                string assetId = ""; string assetName = ""; string type = ""; 
                if (arrayKey.Length > 0)
                { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); intAssetAutoId = int.Parse(arrayKey[3].ToString()); type = arrayKey[5].ToString(); }
               
                if (hdnConfirm.Value.ToString()=="1")
                {
                    string problem = TxtProblem.Text.ToString();
                    string priority = DdlREPriotiy.SelectedItem.ToString(); 
                    string location = ddlLocation.SelectedItem.ToString();
                    string urgent = txtUrgent.Text.ToString();
                    int intType = int.Parse(ddlType.SelectedValue);
                    int requestToLocation = int.Parse(ddlLocation.SelectedValue);
                    int dept = int.Parse(DdlDept.SelectedValue);
                    int intUserjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                     
                    if (requestToLocation == 0)
                    {
                        objrequest.UserRequestMaintenance(assetId, intAssetAutoId, priority, problem, intenroll, 15, location, dept, urgent,intType);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);
                    }
                    else
                    {
                        objrequest.UserRequestMaintenance(assetId, intAssetAutoId,priority, problem, intenroll, requestToLocation, location, dept, urgent, intType);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submitted Request');", true);
                    }
                    ClearandBind(intenroll);
                   
                }
                else { }


            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void ClearandBind(int enroll)
        {
            TxtAsset.Text = "";
            TxtName.Text = "";
            TxtProblem.Text = "";
            txtUrgent.Text = "";
            lblDetalis.Text = "";
            lblDetalis.Visible = false;
            if (DdlREPriotiy.SelectedItem.ToString() == "High")
            {
                lblUrgent.Visible = true;
                txtUrgent.Visible = true;
            }
            else {
                lblUrgent.Visible = false;
                txtUrgent.Visible = false;
            }
           
            lblValidity.Visible = false;
            dt = objrequest.GriedViewUserRequestData(36, 0, enroll, 0, 0);
            dgvView.DataSource = dt;
            dgvView.DataBind();
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetData(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            return objAutoSearch_BLL.GetAssetItem(Active, prefixText);

        }

        protected void DdlREPriotiy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlREPriotiy.SelectedValue.ToString() == "High")
                {
                    lblUrgent.Visible = true; txtUrgent.Visible = true;
                }
                else { txtUrgent.Visible = false; lblUrgent.Visible = false; }
            }
            catch { }
        }

        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = TxtAsset.Text.Split(delimiterChars);
                string assetId = ""; string assetName = ""; string assetType = "";int assetAutoId = 0;
                if (arrayKey.Length > 0)
                { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); assetAutoId =int.Parse(arrayKey[3].ToString()); assetType = arrayKey[5].ToString(); }
                asset = objrequest.showassetData(assetId);
                if (asset.Rows.Count > 0)
                {
                    TxtName.Text = asset.Rows[0]["strNameOfAsset"].ToString();
                    TxtUnit.Text = asset.Rows[0]["strUnit"].ToString();
                    TxtStation.Text = asset.Rows[0]["strJobStationName"].ToString();
                    if (assetType == "8")
                    {
                        lblDetalis.Visible = true;
                        lblValidity.Visible = true;
                        dt = objrequest.getVehicleInformation(assetId);
                        DateTime dteTaxtoken = DateTime.Parse(dt.Rows[0]["taxtoken"].ToString());
                        DateTime dteFitness = DateTime.Parse(dt.Rows[0]["Fitness"].ToString());
                        DateTime dteRoutePermit = DateTime.Parse(dt.Rows[0]["RoutePermit"].ToString());
                        lblDetalis.Text = "Tax Token:" + dteTaxtoken.ToString("dd-MM-yyyy") + "  Fitness:" + dteFitness.ToString("dd-MM-yyyy") + "  Rute Permit:" + dteRoutePermit.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        lblDetalis.Visible = false;
                        lblValidity.Visible = false;

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                }
            }
            catch { }
            
        }

        protected void BtnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars); 
                int id = int.Parse(searchKey[0].ToString());
                // Response.Write(ordernumber);  
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + id + "');", true);
                 
            }
            catch { }
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               int  location = int.Parse(ddlLocation.SelectedValue);
                getDepartment(location);
                 
            }
            catch { }
        }
    }
}