using SAD_BLL.Corporate_sales;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Return
{
    public partial class CorpReturnApp : Page
    {
        DataTable dt, dtproceed = new DataTable(); Bridge obj = new Bridge();
        string custid, challanNo, pk, total; int intEnroll, rollid;

        Boolean ysn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hdnenroll.Value = Session[SessionParams.USER_ID].ToString();
            }
        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void loadGrid()
        {
            intEnroll = int.Parse(hdnenroll.Value);
            try
            {
                dtproceed = Bridge.GetProceedPermissionApp(intEnroll);
                ysn = Boolean.Parse(dtproceed.Rows[0]["bitysnproceed"].ToString());
            }
            catch
            {
                ysn = false;
            }
            dt = obj.GetDataForAppv();
            dgvcorrtnacc.DataSource = dt;
            dgvcorrtnacc.DataBind();
            //if (ysn == true) { dgvcorrtnacc.Columns[7].Visible = true; }
            //else { dgvcorrtnacc.Columns[7].Visible = false; }
        }
  
        //protected void App_Click(object sender, EventArgs e)
        //{
        //    if (hdnconfirm.Value == "1")
        //    {
        //        Button btn = (Button)sender;
        //        string[] CommandArgument = btn.CommandArgument.Split(',');
        //        custid = CommandArgument[0];
        //        challanNo = CommandArgument[1];
        //        pk = CommandArgument[2];
        //        total = CommandArgument[3];
        //        obj.InsertAppv(total,custid, challanNo, pk);
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Success');", true);
              
        //        intEnroll = int.Parse(hdnenroll.Value);
        //        try
        //        {
        //            dtproceed = Bridge.GetProceedPermissionApp(intEnroll);
        //            ysn = Boolean.Parse(dtproceed.Rows[0]["bitysnproceed"].ToString());
        //        }
        //        catch
        //        {
        //            ysn = false;
        //        }
        //        dt = obj.GetDataForAppv();
        //        dgvcorrtnacc.DataSource = dt;
        //        dgvcorrtnacc.DataBind();
        //        if (ysn == true) { dgvcorrtnacc.Columns[7].Visible = true; }
        //        else { dgvcorrtnacc.Columns[7].Visible = false; }
        //    }
        //}


        protected void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                
                string[] CommandArgument = btn.CommandArgument.Split(',');
                HttpContext.Current.Session["CustId"] = CommandArgument[0];
                HttpContext.Current.Session["ChallanNo"] = CommandArgument[1];
                HttpContext.Current.Session["pk"] = CommandArgument[2];
                HttpContext.Current.Session["total"] = CommandArgument[3];
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('CorpReturnWHUpdate.aspx');", true);
                //loadGrid();
            }
            catch { }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    Button btn = (Button)sender;
                    string custID, ChallanNo, fk;
                    string[] CommandArgument = btn.CommandArgument.Split(',');
                    custID = CommandArgument[0];
                    ChallanNo = CommandArgument[1];
                    fk = CommandArgument[2];

                    string msg = obj.DeleteCorpSales(Convert.ToInt32(fk));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    loadGrid();
                }
                catch { }
            }
        }














    }
}