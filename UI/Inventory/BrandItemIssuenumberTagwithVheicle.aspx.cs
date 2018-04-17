using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class BrandItemIssuenumberTagwithVheicle : BasePage
    {

        int rptTypeid;
        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
               
                ////---------xml----------

                ////-----**----------//
            }
        }

        protected void btnShowDelvRepot_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                int enr = int.Parse(hdnenrol);
                string Unit = (drdlUnitName.SelectedValue.ToString());
                int unit = int.Parse(Unit);
                string whid = (drdlGhat.SelectedValue.ToString());
                int whidd = int.Parse(whid);

                string tst = rdbTaggingCompletestatus.SelectedValue.ToString();
                int tstvl = Convert.ToInt32(tst);
                if (tstvl == 0) 
                { dt = bll.GetBrandItemREPORT(2, enr, unit, whidd, dteFromDate, dteToDate); 
                 if (dt.Rows.Count > 0)
                 {
                     grdvissunumbertagcomplted.DataSource = null;
                     grdvissunumbertagcomplted.DataBind();
                grdvDeliveryRptwithVheicleNAME.DataSource = dt;
                grdvDeliveryRptwithVheicleNAME.DataBind();
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                 }
                
                }
                else { dt = bll.GetBrandItemREPORT(4, enr, unit, whidd, dteFromDate, dteToDate);
                
                
                 if (dt.Rows.Count > 0)
                  {

                      grdvDeliveryRptwithVheicleNAME.DataSource = null;
                      grdvDeliveryRptwithVheicleNAME.DataBind();
                      grdvissunumbertagcomplted.DataSource = dt;
                      grdvissunumbertagcomplted.DataBind();
                  }
                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                 }
                
                }
                

            }

            catch { }

            //if (dt.Rows.Count > 0)
            //{
            //    grdvDeliveryRptwithVheicleNAME.DataSource = dt;
            //    grdvDeliveryRptwithVheicleNAME.DataBind();
            //}

           

        }

        private void loadgridafterupdateisssunumber()
        {
            try
            {
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                int enr = int.Parse(hdnenrol);
                string Unit = (drdlUnitName.SelectedValue.ToString());
                int unit = int.Parse(Unit);
                string whid = (drdlGhat.SelectedValue.ToString());
                int whidd = int.Parse(whid);
                dt = bll.GetBrandItemREPORT(4, enr, unit, whidd, dteFromDate, dteToDate);

            }

            catch { }

            if (dt.Rows.Count > 0)
            {
                grdvDeliveryRptwithVheicleNAME.DataSource = dt;
                grdvDeliveryRptwithVheicleNAME.DataBind();
            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }


        }


        protected void grdvDeliveryRptwithVheicleNAME_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        

        protected void btnIssueNumberTag_Click(object sender, EventArgs e)
        {
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

            string Unit = (drdlUnitName.SelectedValue.ToString());
            int unit = int.Parse(Unit);
            string whid = (drdlGhat.SelectedValue.ToString());
            int whidd = int.Parse(whid);
            char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intID = searchKey[0].ToString();
            int idinstedofwhid = int.Parse(intID);

            string date = searchKey[1].ToString();

             
            if (grdvDeliveryRptwithVheicleNAME.Rows.Count>0)
            {
                for (int rowIndex = 0; rowIndex < grdvDeliveryRptwithVheicleNAME.Rows.Count; rowIndex++)
                {

                    try
                    {
                        TextBox TextBoxName = (TextBox)grdvDeliveryRptwithVheicleNAME.Rows[rowIndex].Cells[11].FindControl("txtSearch");
                        string strIssunumber = TextBoxName.Text;
                        int issunumberbitem = Convert.ToInt32(strIssunumber);
                        bll.GetBrandItemREPORT(3, issunumberbitem, unit, idinstedofwhid, dteFromDate, dteToDate);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully update BrandIssue Number');", true);
                        loadgridafterupdateisssunumber();
                        break;
                      
                    }
                    catch { }
                }

               
            }
            


        }

   

  

        protected void drdlGhat_DataBound(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = drdlGhat.SelectedValue.ToString();
                Session["Warehouseid"] = hdnwh.Value;
            }
            catch { }
        }

        protected void drdlGhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = drdlGhat.SelectedValue.ToString();
                Session["Warehouseid"] = hdnwh.Value;
            }
            catch { }
        }

        protected void rdbTaggingCompletestatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    
      

        
    }
}