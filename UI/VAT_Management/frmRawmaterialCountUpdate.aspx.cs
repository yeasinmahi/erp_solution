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

namespace UI.VAT_Management
{
    public partial class frmRawmaterialCountUpdate : BasePage
    {
        VAT_BLL objvat = new VAT_BLL();
        string[] arrayKeyItem;
        CreditNoteBLL objCreditBll = new CreditNoteBLL();
        SAD_BLL.Vat.Mushok11 objmushak11 = new SAD_BLL.Vat.Mushok11();
        DataTable dt;
        string ItemName;
        int intitemid;

        DateTime strM11DateChallan, dtedate;
        char[] delimiterChars = { '[', ']' };bool ysnFactory;
        Mushok11 objMush = new Mushok11();
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
                dt.Clear();
                dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
               
               // hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();
                dt.Clear();
            }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtVatItemList.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            ItemName = (arrayKeyItem[0].ToString());
            intitemid = Int32.Parse(arrayKeyItem[1].ToString());
            objmushak11.getmaterialupdate(intitemid, int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Update');", true);
            txtVatItemList.Text = "";


        }
   
     
       
        protected void txtVatItemList_TextChanged(object sender, EventArgs e)
        {
           

        }


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
        public static string[] ItemMatrial(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getItemList(prefixText, unitid);

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
           
        }
     
        protected double TotalValue = 0;
        protected void dgvTresuryRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
      
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getVatItemList(prefixText, accid);
        }
        //[WebMethod]
        //[ScriptMethod]
        //public static string[] ItemnameSearchMatrial(string prefixText)
        //{
        //    int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
        //    Mushok11 objAutoSearch_BLL = new Mushok11();
        //    return objAutoSearch_BLL.getMatrialItemList(prefixText, accid);

        //}
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