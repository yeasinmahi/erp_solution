using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL;
using SAD_BLL.AutoChallan;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;

namespace UI.SAD.Vat
{
    public partial class frmProductionEntry : BasePage
    {
        string  vno;
        int intItemid, intVatItemid, ProductionId,intBandrollid, intType;
        DataTable dt;decimal qty, bandrollQty; DateTime dtedate,dtefdate,dtetdate;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                txtFrom.Text = DateTime.Now.ToString("yyyy-MMM-dd");
                txtfdate.Text = DateTime.Now.ToString("yyyy-MMM-dd");
                txttdate.Text = DateTime.Now.ToString("yyyy-MMM-dd");
                dt = objMush.getMType();
                if (dt.Rows.Count > 0)
                {
                    ddlMType.DataTextField = "strName";
                    ddlMType.DataValueField = "intMusokTypeID";
                    ddlMType.DataSource = dt;
                    ddlMType.DataBind();
                    dt.Clear();
                }
                
                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());
            qty =decimal.Parse(txtQty.Text);
            vno= arrayKeyItem[0].ToString();
            dtedate =DateTime.Parse(txtFrom.Text);
            intBandrollid = int.Parse(ddlBanroll.SelectedValue);
            intType = int.Parse(ddlMType.SelectedValue);
            if (txtWastage.Text == "")
            {
                bandrollQty = 0;
            }
            else
            {
                bandrollQty = decimal.Parse(txtWastage.Text);
            }
            objMush.getProductentry(intVatItemid,qty,dtedate, int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.USER_ID].ToString()),intType,intBandrollid,bandrollQty);           
        }

        protected void ddlMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());
            dt = objMush.getBandrollcount(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), intVatItemid);
            if (dt.Rows.Count > 0)
            {
                if ((int.Parse(dt.Rows[0]["intBandrollCount"].ToString())>0)&&(int.Parse(ddlMType.SelectedValue)==4))

                {
                    ddlBanroll.Visible = true;
                    txtWastage.Visible = false;
                    txtWastage.Text = "";
                    dt = objMush.getMushokList(intVatItemid);
                    ddlBanroll.DataTextField = "strBandrollName";
                    ddlBanroll.DataValueField = "intBandrollID";
                    ddlBanroll.DataSource = dt;
                    ddlBanroll.DataBind();
                }
            }
           
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            dtefdate =DateTime.Parse(txtfdate.Text);
            dtetdate = DateTime.Parse(txtfdate.Text);
            
            dt= objMush.getProductReport(int.Parse(Session[SessionParams.UNIT_ID].ToString()), dtefdate, dtetdate, int.Parse(hdnAccno.Value),int.Parse(ddlShorby.SelectedValue));
            dgvProductRpt.DataSource = dt;
            dgvProductRpt.DataBind();
        }
        protected double TotalQty = 0; protected double TotalValue = 0;
        protected void dgvProductRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[4].FindControl("lblQty")).Text == "")
                {
                    TotalQty += 0;
                }
                else
                {
                    TotalQty += double.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                }
                if (((Label)e.Row.Cells[5].FindControl("lblAmount")).Text == "")
                {
                    TotalValue += 0;
                }
                else
                {
                    TotalValue += double.Parse(((Label)e.Row.Cells[5].FindControl("lblAmount")).Text);
                }
            }

        }
        protected void btnDelete(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                ProductionId = int.Parse(searchKey[0].ToString());
                objMush.getProductDelete(ProductionId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);

            }
            catch { }
        }
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            int accid=  int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();   
            return objAutoSearch_BLL.getVatItemList(prefixText, accid);
        }
      
        #endregion * ********** End search **********

    }
}