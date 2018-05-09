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
using GLOBAL_BLL;

namespace UI.SAD.Vat
{
    public partial class rptSalesSummary : BasePage
    {
 
        DataTable dt;
        DateTime  dtedate,dtetodate;
        char[] delimiterChars = { '[', ']' }; string[] arrayKeyItem;
        Mushok11 objMush = new Mushok11();bool ysnDay, ysnMaterial, ysnChallan;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
               
               
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (int.Parse(ddlShorby.SelectedValue) == 1)
            {
                ysnDay = true;
                ysnMaterial = false;
                ysnChallan = false;
            }else if (int.Parse(ddlShorby.SelectedValue) == 2)
            {
                ysnDay = false;
                ysnMaterial = true;
                ysnChallan = false;
            }
            else if (int.Parse(ddlShorby.SelectedValue) == 3)
            {
                ysnDay = false;
                ysnMaterial = false;
                ysnChallan = true;
            }
           
            dtedate = DateFormat.GetDateAtSQLDateFormat(txtdtefdate.Text).Value;
            dtetodate = DateFormat.GetDateAtSQLDateFormat(txttodate.Text).Value;
            //Session[SessionParams.UNIT_ID].ToString()
            dt = objMush.GetSalesSummary(int.Parse("16"), int.Parse(Session["VatAccid"].ToString()), dtedate, dtetodate, ysnDay,ysnMaterial,ysnChallan);
            if (dt.Rows.Count > 0)
            {
                dgvPurChaseRpt.DataSource = dt;
                dgvPurChaseRpt.DataBind();
            }
        }
       
        protected double TotalQty = 0, TotalSDVat = 0, TotalSD = 0, TotalVAT=0, TotalTotal=0;
        protected void dgvProductRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[4].FindControl("lblQuantity")).Text == "")
                {
                    TotalQty += 0;
                }
                else
                {
                    TotalQty += double.Parse(((Label)e.Row.Cells[4].FindControl("lblQuantity")).Text);
                }
                if (((Label)e.Row.Cells[5].FindControl("lblWithout")).Text == "")
                {
                    TotalSDVat += 0;
                }
                else
                {
                    TotalSDVat += double.Parse(((Label)e.Row.Cells[5].FindControl("lblWithout")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblSD")).Text == "")
                {
                    TotalSD += 0;
                }
                else
                {
                    TotalSD += double.Parse(((Label)e.Row.Cells[6].FindControl("lblSD")).Text);
                }
                if (((Label)e.Row.Cells[7].FindControl("lblVAT")).Text == "")
                {
                    TotalVAT += 0;
                }
                else
                {
                    TotalVAT += double.Parse(((Label)e.Row.Cells[7].FindControl("lblVAT")).Text);
                }
                if (((Label)e.Row.Cells[8].FindControl("lblTotal")).Text == "")
                {
                    TotalTotal += 0;
                }
                else
                {
                    TotalTotal += double.Parse(((Label)e.Row.Cells[8].FindControl("lblTotal")).Text);
                }

            }

        }
     
              
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearchMatrial(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getMatrialItemList(prefixText, accid);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] SupplierSearch(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getSupplierList(prefixText, unitid);
        }

        #endregion * ********** End search **********

    }
}