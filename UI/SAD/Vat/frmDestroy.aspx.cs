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
    public partial class frmDestroy : BasePage
    {
        string  vno, stritem, remarks,msg;
        int intItemid, intVatItemid, ProductionId,intBandrollid, intType;
        DataTable dt;decimal qty,Value,sd,vat, bandrollQty; DateTime dtedate,dtefdate,dtetdate;

        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemVat.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());
            stritem = (arrayKeyItem[1].ToString());
            qty =decimal.Parse(txtQty.Text);
            Value= qty* decimal.Parse(txtsdcharge.Text);
            sd = decimal.Parse(txtsd.Text);
            vat = decimal.Parse(txtvat.Text);
            if (txtremarks.Text == "") { remarks = "0"; } else { remarks = txtremarks.Text; }
           
            msg= objMush.getDestroy(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), hdnysnFactory.Value, int.Parse(Session[SessionParams.USER_ID].ToString()), intItemid, stritem, qty, Value, sd, vat, remarks,1);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ msg + "');", true);
            txtvat.Text = "";
            txtQty.Text = "";
            txtsd.Text = "";
            txtsdcharge.Text = "";
            txtItemVat.Text = "";

        }

        protected void btnMaterialSave_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtMaterial.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());
            stritem = (arrayKeyItem[1].ToString());
            qty = decimal.Parse(txtQuantityMat.Text);
            Value = qty * decimal.Parse(txtsdChargeMat.Text);
            sd = decimal.Parse(txtSDMat.Text);
            vat = decimal.Parse(txtVatmat.Text);
            if (txtRemarksmat.Text == "") { remarks = "0"; } else { remarks = txtRemarksmat.Text; }
            msg = objMush.getDestroy(int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(hdnAccno.Value), hdnysnFactory.Value, int.Parse(Session[SessionParams.USER_ID].ToString()), intItemid, stritem, qty, Value, sd, vat, remarks,2);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            txtMaterial.Text = "";
            txtsdChargeMat.Text = "";
            txtSDMat.Text = "";
            txtVatmat.Text = "";
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
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearchMatrial(string prefixText)
        {
            int accid = int.Parse(HttpContext.Current.Session["VatAccid"].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getMatrialItemList(prefixText, accid);

        }
        #endregion * ********** End search **********

    }
}