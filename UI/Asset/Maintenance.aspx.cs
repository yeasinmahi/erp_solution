using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
namespace UI.Asset
{
    public partial class Maintenance :BasePage
    {
        AssetMaintenance objIssue = new AssetMaintenance();
        DataTable asset = new DataTable();
        DataTable assetGrid = new DataTable();
        DataTable pm = new DataTable();
        DataTable repair = new DataTable();
        DataTable woPreventive = new DataTable();
        DataTable worepair = new DataTable();
        DataTable userreq = new DataTable();
        DataTable userworkorder = new DataTable();
        DataTable requesition = new DataTable();
        DataTable dt = new DataTable();
        int intItem;
        string Corporate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                showdata();
                pnlUpperControl.DataBind();
            }
        }

        private void showdata()
        {
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


            int Mnumber = 0; 
            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
            {
                intItem = 28;
                assetGrid = objIssue.Corporatemaintenancegridviewshow(intItem, Mnumber, intenroll, intjobid, intdept);
                GridView1.DataSource = assetGrid;
                GridView1.DataBind();

                intItem = 29;
                repair = objIssue.CorporateRepairservicerequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvRepair.DataSource = repair;
                dgvRepair.DataBind();
                intItem = 30;
                pm = objIssue.CorporatePMservicerequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvPM.DataSource = pm;
                dgvPM.DataBind();

                intItem = 38;
                userreq = objIssue.CorporateUserRequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvuserRequest.DataSource = userreq;
                dgvuserRequest.DataBind();

                intItem = 52;
                dt = objIssue.CorporateMaintenancePOWorkOrder(intItem, Mnumber, intenroll, intjobid, intdept);
                DgvPoWorkorders.DataSource = dt;
                DgvPoWorkorders.DataBind();

               }
          
                   
              else 
               {
                   intItem = 4;
                   assetGrid = objIssue.maintenancegridviewshow(intItem, Mnumber, intenroll, intjobid, intdept);
                   GridView1.DataSource = assetGrid;
                   GridView1.DataBind();

                   intItem = 21;
                   pm = objIssue.PMservicerequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                   dgvPM.DataSource = pm;
                   dgvPM.DataBind();

                   intItem = 22;
                   repair = objIssue.RepairservicerequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                   dgvRepair.DataSource = repair;
                   dgvRepair.DataBind();
                   intItem =37;
                   userreq = objIssue.UserRequestShow(intItem, Mnumber, intenroll, intjobid, intdept);
                   dgvuserRequest.DataSource = userreq;
                   dgvuserRequest.DataBind();
                   dt = new DataTable();
                   intItem =53;
                   dt = objIssue.FactoryPoWorkMaintenanceView(intItem, Mnumber, intenroll, intjobid, intdept);
                   DgvPoWorkorders.DataSource = dt;
                   DgvPoWorkorders.DataBind();
               
            }
         

            
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.ToolTip = (e.Row.DataItem as DataRowView)["strProblem"].ToString();
                e.Row.Cells[1].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                e.Row.Cells[8].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                e.Row.Cells[9].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());  
            }
        }
        protected void OnDataDgvPoWorkorders(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                e.Row.Cells[1].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                e.Row.Cells[8].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
               
            }
        }

        protected void ondatadgvUserrequest(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                e.Row.Cells[1].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                e.Row.Cells[8].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                
            }
        }

        protected void ondatadgvRepair(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                e.Row.Cells[1].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                e.Row.Cells[8].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                
            }
        }

         protected void OndatadgvPM(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                e.Row.Cells[1].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                e.Row.Cells[8].Attributes.Add("title", (e.Row.DataItem as DataRowView)["StatusView"].ToString());
                
            }
        }
        protected void BtnDetalis_Click(object sender, EventArgs e)
        {
            
                try
                {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
           
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);
                 
                    string ordernumber1 = searchKey[0].ToString();
                    string provideby = "0".ToString();
                    Session["provideType"] = provideby;
                    Session["intMaintenanceNo"] = ordernumber1;
                    int Mnumber = int.Parse(ordernumber1.ToString());
                    intItem = 24;
                    if (intItem==24)
                    {
                        objIssue.insertServiceIdfromServiceConfig(intItem, Mnumber, intenroll, intjobid, intdept);
                    }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('MaintenanceWorkOrderPopUp.aspx');", true);
                    
                }
                catch { }
            

        }

        

     

        protected void BtnWorkorder_Click(object sender, EventArgs e)
        {

           
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intunit = Int32.Parse(Session[SessionParams.UNIT_ID].ToString());
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    
                 
                    Int32 Mnumber = Int32.Parse(ordernumber1.ToString());
                    if (hdnconfirm.Value == "1")
                    {
                        intItem = 23;
                        if (intItem == 23)
                        {
                            woPreventive = objIssue.InserPMtoMainteanceTask(intItem, Mnumber, intenroll, intjobid, intdept);
                            //woPreventive //= objIssue.WorkorderNumberPreventive();
                            if (woPreventive.Rows.Count > 0)
                            {
                                string data;
                                data = woPreventive.Rows[0]["intwo"].ToString();
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Work Order#   '+''+'" + data + "');", true);


                            }

                        }

                        showdata();
                    }
                }
                catch { }
            
        }

        protected void BtnRepWorkorder_Click(object sender, EventArgs e)
        {

            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber2 = searchKey[0].ToString();

                  
                    Int32 Mnumber = Int32.Parse(ordernumber2.ToString());

                    if (hdnconfirm.Value == "1")
                    {

                        intItem = 25;
                        if (intItem == 25)
                        {
                            worepair = objIssue.InserPMReptoMainteanceTask(intItem, Mnumber, intenroll, intjobid, intdept);
                            if (worepair.Rows.Count > 0)
                            {
                                string data;
                                data = worepair.Rows[0]["intworep"].ToString();
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Work Order# '+''+'" + data + "');", true);


                            }

                        }



                        showdata();
                    }
                }
                catch { }
            
        }

        protected void BtnUserRequestWO_Click(object sender, EventArgs e)
        {
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber3 = searchKey[0].ToString();


               
                Int32 Mnumber = Int32.Parse(ordernumber3.ToString());

                if (hdnconfirm.Value == "1")
                {
                    intItem = 39;
                    if (intItem == 39)
                    {
                        userworkorder = objIssue.InsertUserrequestWorklorder(intItem, Mnumber, intenroll, intjobid, intdept);
                        if (userworkorder.Rows.Count > 0)
                        {
                            string data;
                            data = userworkorder.Rows[0]["intUserReq"].ToString();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Work Order# '+''+'" + data + "');", true);


                        }

                    }



                    showdata();
                }
            }
            catch { }
        }

        protected void BtnRequesition_Click(object sender, EventArgs e)
        {
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intUnitID = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);

            string ordernumber3 = searchKey[0].ToString();

            Session["intMaintenanceNo"] = ordernumber3;
            Int32 Mnumber = Int32.Parse(ordernumber3.ToString());

           if ( hdnconfirm.Value=="1")
           {
               requesition =objIssue.RequesitionGenerateNumber(Mnumber, intenroll, intUnitID, intdept);
               if (requesition.Rows.Count > 0)
               {
                   string data;
                   data = requesition.Rows[0]["ReqesitionCode"].ToString();
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Store requisition has been submitted successfully. Requsition Code :'+''+'" + data + "');", true);


               }

               else
               {
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Store requisition has been Allready Submitted:');", true);

               }

           }
          

        }

        protected void BtnPODetalis_Click(object sender, EventArgs e)
        {
            
                try
                {
                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber2 = searchKey[0].ToString();
                    string provideby = "1".ToString();
                    Session["provideType"] = provideby;
                    Session["intMaintenanceNo"] = ordernumber2;
                    Int32 Mnumber = Int32.Parse(ordernumber2.ToString());
                    intItem = 24;
                    if (intItem == 24)
                    {
                        objIssue.insertServiceIdfromServiceConfig(intItem, Mnumber, intenroll, intjobid, intdept);
                    }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('MaintenanceWorkOrderPopUp.aspx');", true);

                }
                catch { }
            
        }

        
    }
}