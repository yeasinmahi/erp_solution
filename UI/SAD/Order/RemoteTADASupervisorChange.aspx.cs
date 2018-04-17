using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTADASupervisorChange : BasePage
    {
        string[] arrayKey; int RowIndex = 0; int reportType; int enrol; int supvenrol; char[] delimiter = { '[', ']' };
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtEnrol.Visible = false;
                lblEmplyeEnrol.Visible = false;
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
                txtEnrol.Attributes.Add("onkeyUp", "SearchBox();");
                Loadgrid();
                hdnAction.Value = "0";
            }
            else
            {

            }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.AutoSearchEmployeesDataTADA(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
            
           
        }

        private void Loadgrid()
        {
           

            try
            {
                DataTable dt = new DataTable();
                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                int Deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                int jobstationid;
                int unit;
                if (rdbUpdateType.SelectedItem.Text == "Multiple User update" && Deptid!=14)
                {
                    txtEnrol.Visible = false; lblEmplyeEnrol.Visible = false;
                    reportType = 2;
                    int enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    unit = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    jobstationid = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = bll.getTADASuperviorinfUpdateData(unit, jobstationid, reportType, enrol,0,0);
                    if (dt.Rows.Count > 0)
                    {
                        grdvForTADASupervisorUPdate.DataSource = dt;
                        grdvForTADASupervisorUPdate.DataBind();
                        grdvForSpervisorInsertion.DataSource = "";
                        grdvForSpervisorInsertion.DataBind();
                    }
                    else
                    {
                        grdvForTADASupervisorUPdate.DataSource = "";
                        grdvForTADASupervisorUPdate.DataBind();
                    }
                   
                }

                else if (rdbUpdateType.SelectedItem.Text == "Multiple User update" && Deptid == 14)
                {

                    reportType = 3;
                    unit = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    jobstationid = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = bll.getTADASuperviorinfUpdateData(unit, jobstationid, reportType, enrol,0,0);
                    if (dt.Rows.Count > 0)
                    {
                        grdvForTADASupervisorUPdate.DataSource = dt;
                        grdvForTADASupervisorUPdate.DataBind();
                        grdvForSpervisorInsertion.DataSource = "";
                        grdvForSpervisorInsertion.DataBind();
                    }
                    else
                    {
                        grdvForTADASupervisorUPdate.DataSource = "";
                        grdvForTADASupervisorUPdate.DataBind();
                    }
                  


                }

                else if (rdbUpdateType.SelectedItem.Text == "Single User update" && Deptid == 14)
                {
                    int enrol = int.Parse(txtEnrol.Text.ToString());
                     Deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                    reportType = 1;

                    unit = int.Parse(drdlUnit.SelectedValue.ToString());
                    jobstationid = int.Parse(drdlJobstation.SelectedValue.ToString());

                        dt = bll.getTADASuperviorinfUpdateData(unit, jobstationid, reportType, enrol,0,0);
                        if (dt.Rows.Count > 0)
                        {
                            grdvForTADASupervisorUPdate.DataSource = dt;
                            grdvForTADASupervisorUPdate.DataBind();
                            grdvForSpervisorInsertion.DataSource = "";
                            grdvForSpervisorInsertion.DataBind();
                        }
                        else
                        {
                            grdvForTADASupervisorUPdate.DataSource = "";
                            grdvForTADASupervisorUPdate.DataBind();
                        }
                     


                    }

                else if (rdbUpdateType.SelectedItem.Text == "Single User update" && Deptid != 14)
                {
                    int enrol = int.Parse(txtEnrol.Text.ToString());
                    Deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                    int insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    reportType = 1;
                    unit = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    jobstationid = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = bll.getTADASuperviorinfUpdateData(unit, jobstationid, reportType, enrol, 0, insertby);
                    if (dt.Rows.Count > 0)
                    {
                      
                        grdvForTADASupervisorUPdate.DataSource = dt;
                        grdvForTADASupervisorUPdate.DataBind();
                        grdvForSpervisorInsertion.DataSource = "";
                        grdvForSpervisorInsertion.DataBind();


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already set supervisor for this employee');", true);
                    }
              }

                else if (rdbUpdateType.SelectedItem.Text == "Single user Insertion")
                {
                    int enrol = int.Parse(txtEnrol.Text.ToString());
                    Deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                    int insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string strSearch = txtFullName.Text;
                    arrayKey = strSearch.Split(delimiter);
                    string supvenrollin = arrayKey[1].ToString();
                    int supvenr = int.Parse(supvenrollin);
                    if (supvenr > 0) { reportType = 3; }
                    else { reportType = 1; }
                    unit = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    jobstationid = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = bll.getTADASuperviorinfUpdateData(unit, jobstationid, reportType, enrol, supvenr, insertby);
                    if (dt.Rows.Count > 0)
                    {
                        grdvForSpervisorInsertion.DataSource = dt;
                        grdvForSpervisorInsertion.DataBind();
                        grdvForTADASupervisorUPdate.DataSource = "";
                        grdvForTADASupervisorUPdate.DataBind();


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already set supervisor for this employee');", true);
                    }
                }
          }

            catch
            { }

        }



        protected void btnSupervisorUpdate_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intIDtbl = searchKey[0].ToString();
            int id = int.Parse(intIDtbl);
            string intEmplEnrol = searchKey[1].ToString();
            int emplenrol = int.Parse(intEmplEnrol);
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            int insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int jobstationid = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            int typeid = 1;
                if (grdvForTADASupervisorUPdate.Rows.Count > 0)
                {
                     for (int rowIndex = 0; rowIndex < grdvForTADASupervisorUPdate.Rows.Count; rowIndex++)
                        {

                            try
                             {
                            TextBox TextBoxName = (TextBox)grdvForTADASupervisorUPdate.Rows[rowIndex].Cells[9].FindControl("txtSearch");
                        
                            string strSearchKey = TextBoxName.Text;

                            arrayKey = strSearchKey.Split(delimiter);
                            string supervisorcode = arrayKey[1].ToString();
                            int updatesupervisorenrol = int.Parse(supervisorcode);
                           
                            bll.UpdateTADASupervisor(emplenrol, updatesupervisorenrol, jobstationid, insertby, id, typeid);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully update Supervisor information');", true);
                            Loadgrid();
                            break;
                            }

                         catch
                          {
                              
                          }
                     }
                 }

                else { }
                }
            

          
        

        protected void grdvForTADASupervisorUPdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvForTADASupervisorUPdate.PageIndex = e.NewPageIndex;
            Loadgrid();
        }

        protected void grdvForTADASupervisorUPdate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string  supervisor = (e.Row.Cells[5].Text);
        
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            }
        }

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void rdbUpdateType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            if (rdbUpdateType.SelectedItem.Text == "Single User update")
             {
                 //RedirectSamepage("");
                txtEnrol.Visible = true;
                 lblEmplyeEnrol.Visible = true;
                 txtFullName.Visible = false;
                 lblSupervisorEnrol.Visible = false;
                 grdvForTADASupervisorUPdate.DataSource = "";
                 grdvForTADASupervisorUPdate.DataBind();
                
             }
            else if (rdbUpdateType.SelectedItem.Text == "Multiple User update")
             {
                 txtEnrol.Visible = false;
                 lblEmplyeEnrol.Visible = false;
                 txtFullName.Visible = false;
                 lblSupervisorEnrol.Visible = false;

                 grdvForTADASupervisorUPdate.DataSource = "";
                 grdvForTADASupervisorUPdate.DataBind();
             }

            else if (rdbUpdateType.SelectedItem.Text == "Single user Insertion")
            {
                //RedirectSamepage("");
                txtEnrol.Visible = true;
                lblEmplyeEnrol.Visible = true;
                txtFullName.Visible = true;
                lblSupervisorEnrol.Visible = true;
                grdvForTADASupervisorUPdate.DataSource = "";
                grdvForTADASupervisorUPdate.DataBind();
            }
        }

       private void RedirectSamepage(string message)
        {
            string url = "RemoteTADASupervisorChange.aspx";
            string script = "window.onload = function(){ ";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }

       protected void grdvForSpervisorInsertion_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {

       }

       protected void grdvForSpervisorInsertion_RowDataBound(object sender, GridViewRowEventArgs e)
       {

       }

       protected void btnsupervisorInsert_Click(object sender, EventArgs e)
       {
           
            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intEmplEnrol = searchKey[0].ToString();
            int emplenrol = int.Parse(intEmplEnrol);
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            int insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int jobstationid = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            string strSearchKey = txtFullName.Text;
            arrayKey = strSearchKey.Split(delimiter);
            string supervcode = arrayKey[1].ToString();
            int updatesupvenrolins = int.Parse(supervcode);
            bll.UpdateTADASupervisor(emplenrol, updatesupvenrolins, jobstationid, insertby, 0, 2);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully insert Supervisor information');", true);
           
         }

             
            
       }



    }
