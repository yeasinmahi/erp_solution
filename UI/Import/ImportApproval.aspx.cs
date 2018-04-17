using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Imports;
using System.Data;
using System.Data.SqlClient;
using UI.ClassFiles;
using System.Net;
using System.IO;

namespace UI.Import
{
    public partial class ImportApproval : BasePage
    {
        Import_BLL objImport = new Import_BLL();
        DataTable dt = new DataTable();
        DataTable dtApp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BtnDownload.Visible = false;
                Int32 RQID = Int32.Parse(Session["strRFIQID"].ToString());
                Int32 number, type;
                DgvApproval.Visible = true;
                DgvReport.Visible = true;
                number = Int32.Parse(RQID.ToString());
                type = Int32.Parse(3.ToString());
                dt = objImport.ViewData(number, type);

                type = Int32.Parse(2.ToString());

                dtApp = objImport.ViewData2(number, type);

                if (dt.Rows.Count > 0 && dtApp.Rows.Count > 0)
                {
                    DgvReport.DataSource = dt;
                    DgvReport.DataBind();
                   
                   
                   
                    DgvApproval.DataSource = dtApp;
                    DgvApproval.DataBind();
                 

                }
                else
                {
                    DgvApproval.Visible = false;
                    DgvReport.Visible = false;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                }
            }
        }


        protected void DgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    int d = e.Row.Cells.Count;
                
              
            //    for (int i = 4; i < d; i++)
            //    {
            //        TableCell cell = e.Row.Cells[i];
                 
            //        cell.BackColor = System.Drawing.Color.Green;
            //        cell.BorderColor = System.Drawing.Color.Blue;

            //    }
            //}
    
       
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    int NumCells = e.Row.Cells.Count;
               
            //    for (int i = 4; i < NumCells ; i++)
            //    {
                  
            //        //e.Row.Cells[i].VerticalAlign = VerticalAlign;
            //        e.Row.Cells[i].CssClass = "verticaltext";
            //       e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;

            //       e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
            //       e.Row.Cells[i].BorderColor = System.Drawing.Color.Red;

            //       e.Row.BackColor = System.Drawing.Color.Blue;

            //    }
            //}




        }
        protected void BtnView_Click(object sender, EventArgs e)
        {
            string strPathurl; BtnDownload.Visible = false;
            try
            {

                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();

               Session["strPath"] = ordernumber1;

                

               //if (ordernumber1 != "")
               //{
               //    BtnDownload.Visible = true;
               //    strPathurl = Uri.EscapeUriString(ordernumber1);
               //    string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + strPathurl;
               //    myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + imageUrl + "'></iframe>"));

               //}
               if (ordernumber1 != "")
               {
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewData('DocViews.aspx');", true);
               }

                else
               {
                   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
               }


            }
            catch { }
           
        }

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            int RQID = int.Parse(Session["strRFIQID"].ToString());
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber3 = searchKey[0].ToString();
                int SuppID = int.Parse(ordernumber3.ToString());
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                TextBox remark = row.FindControl("txtRemarks") as TextBox;
                string remarks = remark.Text.ToString();

                objImport.ApproveIndent(enroll, remarks,RQID, SuppID);
                objImport.ApprovalUpdate2(SuppID, RQID);               // Response.Write(ordernumber); 
               // Session["strPath"] = ordernumber1;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfully Approved');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

                
            }
            catch { }
        }

        
      
    }
}