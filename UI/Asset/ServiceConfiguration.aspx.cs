using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;


namespace UI.Asset
{
    public partial class ServiceConfiguration :BasePage
    {
        AssetMaintenance objPMConfigure = new AssetMaintenance();
        DataTable dt = new DataTable();
        DataTable servicec = new DataTable();
        DataTable common = new DataTable();
        DataTable asset = new DataTable();
        DataTable dgview = new DataTable();

        int intItem; int ysnprovide;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            { 
                showdata();
                pnlUpperControl.DataBind();
            }


        }

        private void showdata()
        {
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                int Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                intItem = 9;
                dt = new DataTable();
                dt = objPMConfigure.dgvViewServiceName(intItem, Mnumber, intenroll, intjobid, intdept);
                DdlService.DataSource = dt;
                DdlService.DataTextField = "strServiceName";
                DdlService.DataValueField = "ID";
                DdlService.DataBind();
                Int32 serviceID = Int32.Parse(DdlService.SelectedValue.ToString());
                dt = new DataTable();
                dt = objPMConfigure.ViewServiceData(serviceID);
                if (dt.Rows.Count > 0)
                {

                    HdnServiceCost.Value = dt.Rows[0]["monServiceCharge"].ToString();

                } 
                intItem = 11;
                common = objPMConfigure.RepairsCommonList(intItem, Mnumber, intenroll, intjobid, intdept);
                DdlCommonRepair.DataSource = common;
                DdlCommonRepair.DataTextField = "strRepairs";
                DdlCommonRepair.DataValueField = "intID";
                DdlCommonRepair.DataBind();
                int repairsID = Int32.Parse(DdlCommonRepair.SelectedValue.ToString());
                dt = new DataTable();
                dt = objPMConfigure.commonrepairsView(repairsID);
                if (dt.Rows.Count > 0)
                {

                    hdnRepairsCost.Value = dt.Rows[0]["monServiceCharge"].ToString();
                }
                 

                intItem = 14;
                dgview = objPMConfigure.dgvViewPMService(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvservice.DataSource = dgview;
                dgvservice.DataBind();
            }
            catch { }
           
        
            //intItem = 12;
            //if (intItem == 12)
            //{
            //   // Int32 Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            //   // dt = objPMConfigure.ScheduleNameLoad(intItem, Mnumber, intenroll, intjobid, intdept);
            //    //DdlSchedule.DataSource = dt;
            //    //DdlSchedule.DataTextField = "strScheduleName";
            //    //DdlSchedule.DataValueField = "intID";
            //    //DdlSchedule.DataBind();

            //}
            //intItem = 13;
            //if (intItem == 13)
            //{
            //    intItem = 13;
                
            //    //Int32 Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            //    servicec = objPMConfigure.ServiceDropdown(intItem, Mnumber, intenroll, intjobid, intdept);
            //    DdlService.DataSource = servicec;
            //    DdlService.DataTextField = "strServiceName";
            //    DdlService.DataValueField = "intID";
            //    DdlService.DataBind();

               
            //}

            //intItem = 11;
            //if (intItem == 11)
            //{
            //    //Int32 Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            //    intItem = 11;
            //    common = objPMConfigure.RepairsCommonList(intItem, Mnumber, intenroll, intjobid, intdept);
            //    DdlCommonRepair.DataSource = common;
            //    DdlCommonRepair.DataTextField = "strRepairs";
            //    DdlCommonRepair.DataValueField = "intID";
            //    DdlCommonRepair.DataBind();


            //}
            //intItem = 14;
            //if (intItem == 14)
            //{

            //    //Int32 Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            //    intItem = 14;
            //    dgview = objPMConfigure.dgvViewPMService(intItem, Mnumber, intenroll, intjobid, intdept);
            //    dgvservice.DataSource = dgview;
            //    dgvservice.DataBind();

            //}
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {

                //DdlSchedule.Visible = true;
                DdlService.Visible = true;
                DdlPrePriority.Visible = true;
                TxtdteFixed.Visible = true;
                TxtDayHour.Visible = true;
                RadioButton2.Checked = false;
               // LblSchedule.Visible = true;
                DdlRequred.Visible = true;
                LblHour.Visible = true;
                LblService.Visible = true;
                LblPriority.Visible = true;
                LbldteStart.Visible = true;
                LblRequare.Visible = true;
                btnservice.Visible = true;
               // btnschedule.Visible = true;
                 DdlProvide.Visible = true;
                LblProvide.Visible = true;
                //

                DdlCommonRepair.Visible = false;
                TxtdteRepair.Visible = false;
                DdlREPriotiyyd.Visible = false;
                TxtProblem.Visible = false;
                LblCommonRepair.Visible = false;
                LbldteRepair.Visible = false;
                LblPrioritys.Visible = false;
                LblProblem.Visible = false;
                btnRepair.Visible = false;


            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                DdlCommonRepair.Visible = true;
                TxtdteRepair.Visible = true;
                DdlREPriotiyyd.Visible = true;
                TxtProblem.Visible = true;
                RadioButton1.Checked = false;
                LblCommonRepair.Visible = true;
                LbldteRepair.Visible = true;
                LblPrioritys.Visible = true;
                LblProblem.Visible = true;
                btnRepair.Visible = true;
                DdlRequred.Visible = false;
                LblHour.Visible = false;
                //
                DdlProvide.Visible= true;
                LblProvide.Visible = true;
                //DdlSchedule.Visible = false;
                DdlService.Visible = false;
                DdlPrePriority.Visible = false;
                TxtdteFixed.Visible = false;
                TxtDayHour.Visible = false;

                //LblSchedule.Visible = false;

                LblService.Visible = false;
                LblPriority.Visible = false;
                LbldteStart.Visible = false;
                LblRequare.Visible = false;
                btnservice.Visible = false;
                //btnschedule.Visible = false;
            }
        }

        protected void btnschedule_Click(object sender, EventArgs e)
        {
           
                try
                {
      

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PMSchedule.aspx');", true);

                }
                catch { }
           

        }

        protected void btnservice_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();
                    //Int32 items = Int32.Parse(DdlSchedule.SelectedValue.ToString());

                    // Response.Write(ordernumber); 
                    //Session["intMaintenanceNo"] = ordernumber1;
                    Session["intID"] = ordernumber1;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RegistrationSchedule('PMScheduleServicePopUp.aspx');", true);

                }
                catch { }
            }
        }

        protected void btnRepair_Click(object sender, EventArgs e)
        {
          
                try
                {
                   

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('CommonRepaisListPopUp.aspx');", true);
                }
                catch { }
            
        }

        protected void DdlSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            intItem = 13;
            if (intItem == 13)
            {
                Int32 Mnumber = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                servicec = objPMConfigure.ServiceDropdown(intItem, Mnumber, intenroll, intjobid, intdept);
                DdlService.DataSource = servicec;
                DdlService.DataTextField = "strServiceName";
                DdlService.DataValueField = "intID";
                DdlService.DataBind();
            }
            //showdata();
        }

        protected void DdlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 serviceID = Int32.Parse(DdlService.SelectedValue.ToString());
            dt = new DataTable();
            dt = objPMConfigure.ViewServiceData(serviceID);
            if (dt.Rows.Count > 0)
            {

                HdnServiceCost.Value = dt.Rows[0]["monServiceCharge"].ToString();

            }
        }

        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtAsset.Text))
            {
                string strSearchKey = TxtAsset.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                hdfEmpCode.Value = searchKey[1];
               
                string number = hdfEmpCode.Value.ToString();
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                asset = objPMConfigure.showassetData(number);
                if (asset.Rows.Count > 0)
                {
                    TxtName.Text = asset.Rows[0]["strNameOfAsset"].ToString();
                    TxtUnit.Text = asset.Rows[0]["strUnit"].ToString();
                    TxtStation.Text = asset.Rows[0]["strJobStationName"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                }
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {
          
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 Active = Int32.Parse(1.ToString());
            return objAutoSearch_BLL.GetAssetItem(Active,prefixText);

        }
        protected void BtnIssue_Click(object sender, EventArgs e)
        {
           
            if (!String.IsNullOrEmpty(TxtAsset.Text))
            {
                string strSearchKey = TxtAsset.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                hdfEmpCode.Value = searchKey[1];

                string number = hdfEmpCode.Value.ToString();

                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                
                
                if (RadioButton1.Checked == true)
                {
                    //Int32 schedule = Int32.Parse(DdlSchedule.SelectedValue.ToString());
                    string service = DdlService.SelectedItem.ToString();
                    string priority = DdlPrePriority.SelectedItem.ToString();
                    DateTime dtefixed = DateTime.Parse(TxtdteFixed.Text);
                    Int32 countday = Int32.Parse(TxtDayHour.Text.ToString());

                    string provide = DdlProvide.SelectedItem.Text.ToString();
                    string priode = DdlRequred.SelectedItem.Text.ToString();
                    decimal serviceCost = decimal.Parse(HdnServiceCost.Value.ToString());




                    objPMConfigure.InsertPMServicerequestdata(number, service, priority, dtefixed, countday, intenroll, intjobid, intdept, provide, priode, serviceCost);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Succesfully PM Service Request');", true);

                    showdata();
                }
                else if (RadioButton2.Checked == true)
                {
                    DdlCommonRepair.Visible = true;
                    TxtdteRepair.Visible = true;
                    DdlREPriotiyyd.Visible = true;
                    TxtProblem.Visible = true;
                    RadioButton1.Checked = false;
                    DdlRequred.Visible = false;
                    LblHour.Visible = false;
                    string provide = DdlProvide.SelectedItem.Text.ToString();
                    decimal repairsCost = decimal.Parse(hdnRepairsCost.Value.ToString());
                    //Note Service Provide Type In House=0 and Vendor=1//
                    if (DdlProvide.SelectedItem.Text == "In House")
                    {

                        ysnprovide = Int32.Parse(0.ToString());
                    }
                    if (DdlProvide.SelectedItem.Text == "Vendor")
                    {
                        ysnprovide = Int32.Parse(1.ToString());
                    }

                    string repair = DdlCommonRepair.SelectedItem.ToString();
                    string priority = DdlREPriotiyyd.SelectedItem.ToString();
                    DateTime dteRepair = DateTime.Parse(TxtdteRepair.Text);
                    string problem = TxtProblem.Text.ToString();
                    objPMConfigure.RepairRequestsInsertData(number, repair, priority, dteRepair, problem, intenroll, intjobid, intdept, provide, ysnprovide, repairsCost);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Succesfully Repair Request');", true);
                }


                showdata();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;



                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrationparts('ServiceConfigurePopUp.aspx');", true);

                }
                catch { }
            }



        }

        protected void DdlCommonRepair_SelectedIndexChanged(object sender, EventArgs e)
        {
            int repairsID = Int32.Parse(DdlCommonRepair.SelectedValue.ToString());
            dt = new DataTable();
            dt = objPMConfigure.commonrepairsView(repairsID);
            if (dt.Rows.Count > 0)
            {

                hdnRepairsCost.Value = dt.Rows[0]["monServiceCharge"].ToString();
            }
        }
    }
}