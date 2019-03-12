using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Purchase_BLL.Commercial;
using UI.ClassFiles;
using Purchase_BLL.SupplyChain;

namespace UI.Inventory
{
    public partial class IndentDetail : Page
    {
        DataTable dt = new DataTable();
        CSM Suppliereport = new CSM();
        CSM report = new CSM();

    
        
        protected void Page_Load(object sender, EventArgs e)
        {
          int intIndentid; int intWhid;

            intIndentid=Convert.ToInt32( Session["Indentid"].ToString());
            HttpContext.Current.Session["Indentid"] = intIndentid.ToString();
            //HttpContext.Current.Session["intItemid"] = Convert.ToInt32(Session["intItemid"].ToString());
            intWhid = int.Parse(Session["whid"].ToString());
            string whnm =Convert.ToString(Session["whname"]);
            Label1.Text = whnm;



            dt = report.getindentsdetails(intWhid,intIndentid);
            dgvDetailIndent.DataSource = dt;
            dgvDetailIndent.DataBind();



            //int intIndentid = int.Parse(txtBankId
            //intWhid = int.Parse(ddlWNName.Text);
            //int intRequestSupID = int.Parse(strRequestSupID.ToString());

            //txtSuppliername.Text = dt.Rows[0]["strSuppMasterName"].ToString();             


            //strIndent = Request.QueryString["intIndent"];
            //intIndent=int.Parse(strIndent.ToString());

            //dt = report.GetIndentDetail(int intWhid, int intIndentid);
            //dgvDetailIndent.DataSource = dt;
            //dgvDetailIndent.DataBind();
        }



        protected void submitApprove_Click(object sender, EventArgs e)
        {
            
         
            if (dgvDetailIndent.Rows.Count > 0)
            {

                for (int index = 0; index < dgvDetailIndent.Rows.Count; index++)
                {


                    string itmid = ((Label)dgvDetailIndent.Rows[index].FindControl("itemid")).Text.ToString();

                    int intItemid;
                    int intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intindentid = int.Parse(HttpContext.Current.Session["Indentid"].ToString());
                    intItemid = int.Parse(itmid.ToString());

                    report.UpdateIndentApprovrd(intRequestBy, intindentid);

                    report.UpdateIndentApproval2(intRequestBy, intindentid, intItemid);


                }
            }

        }

        protected void submitClear_Click(object sender, EventArgs e)
        {
            //int intItemid;
            //int intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
            //int intindentid = int.Parse(HttpContext.Current.Session["Indentid"].ToString());
            //intItemid = Convert.ToInt32(Session["intItemid"].ToString());

            //dt = report.UpdateIndentApprovrd(intRequestBy, intindentid);
            //dgvDetailIndent.DataSource = dt;
            //dgvDetailIndent.DataBind();
        }

        protected void submitReject_Click(object sender, EventArgs e)
        {

        }

        //protected void dgvDetailIndent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    dt = report.GetIndentList(intWHID, dteFromDate, dteToDate, Number);
        //    dgvReport.DataSource = dt;
        //    dgvReport.DataBind();
        //}

       

        protected void dgvDetailIndent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgvDetailIndent.DeleteRow(e.RowIndex);
            dgvDetailIndent.DataBind();


            //try
            //{

            //    int index = Convert.ToInt32(e.RowIndex);
            //    dgvDetailIndent.DeleteRow(index);

            //    TableCell cell = dgvDetailIndent.Rows[e.RowIndex].Cells[2]; {e.Cancel = true;} 

            //    //DataSet dsGrid = (DataSet)dgvDetailIndent.DataSource;
            //    //dsGrid.Tables[0].Rows[dgvDetailIndent.Rows[e.RowIndex].DataItemIndex].Delete();
            //    ////dsGrid.WriteXml(filePathForXML);
            //    //DataSet dsGridAfterDelete = (DataSet)dgvDetailIndent.DataSource;
            //    //if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            //    //{ Delete(dsGrid); dgvDetailIndent.DataSource = ""; dgvDetailIndent.DataBind(); }
            //    //else {  }

            //}

            //catch { } 

        }

       
       
    }
}