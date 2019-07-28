using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SCM_BLL;
using System.Data;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;
using Utility;

namespace UI.PaymentModule
{
    public partial class ExchangeRate : System.Web.UI.Page
    {
        DateTime dteFDate; DateTime dteTDate;
        private readonly ImportAdviceBll _bll = new ImportAdviceBll();
        DataTable dt; string msg;


        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();

            txtFrom.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
        private void LoadGrid()
        {



            //dteTDate = DateTime.Parse(txtFrom.Text.ToString()).ToString("yyyy-MM-dd");

            string dteFDate = txtFrom.Text;
            string dteTDate = txtFrom.Text;
            dteFDate = DateTime.Parse(txtFrom.Text).ToString("yyyy-MM-dd");
            dteTDate = DateTime.Parse(txtFrom.Text).ToString("yyyy-MM-dd");

            // dteTDate =CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;




            dt = _bll.GetExchangeRate(dteFDate, dteTDate);
                if (dt.Rows.Count > 0)
                {

                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                }
                else
                {
                    //Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                    dgvReport.UnLoad();
                }

            

        }

        protected void btnPrepareAllVoucher_Click(object sender, EventArgs e)
        {
           
            if (dgvReport.Rows.Count > 0)
            {

                for (int index = 0; index < dgvReport.Rows.Count; index++)
                {
                    if (((CheckBox)dgvReport.Rows[index].FindControl("chkRow")).Checked == true)
                    {
                        int lblAutoID =int.Parse(((Label)dgvReport.Rows[index].FindControl("lblAutoID")).Text.ToString());
                        decimal txtActualRate =decimal.Parse(((TextBox)dgvReport.Rows[index].FindControl("txtActualRate")).Text.ToString());

                          msg = _bll.UpdateExchangeRate(txtActualRate,int.Parse(SessionParams.USER_ID.ToString()), lblAutoID);
                    

                    }
                }
              
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

               
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Available');", true);
            }
        }
    }
 }