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
    public partial class frmItemAndMatrialsAdd : BasePage
    {
        string strHscode, vno;bool ysntxt;
        int intItemid, intVatItemid, empid;
        DataTable dt;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        ExcelDataBLL objExcel = new ExcelDataBLL();
        Mushok11 objMush = new Mushok11();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = objMush.getUOM(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
                
                ddlUOMMatrial.DataTextField = "strUOM";
                ddlUOMMatrial.DataValueField = "strUOM";
                ddlUOMMatrial.DataSource = dt;
                ddlUOMMatrial.DataBind();
                dt.Clear();
                dt = objMush.getUomSad(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
                ddlUom.DataTextField = "strUOM";
                ddlUom.DataValueField = "intid";
                ddlUom.DataSource = dt;
                ddlUom.DataBind();
                dt.Clear();
                dt = objMush.getMatriltype();
                ddlMatrialType.DataTextField = "strTypeName";
                ddlMatrialType.DataValueField = "intMatTypeID";
                ddlMatrialType.DataSource = dt;
                ddlMatrialType.DataBind();
                dt.Clear();
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
       

        protected void btnVatItemBridge_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtSADItem.Text.Split(delimiterCharss);
            intItemid = int.Parse(arrayKeyItem[1].ToString());
            arrayKeyItem = txtVatItem.Text.Split(delimiterCharss);
            intVatItemid = int.Parse(arrayKeyItem[1].ToString());

            objMush.getItemBridge(intItemid, intVatItemid, int.Parse(hdnAccno.Value), int.Parse(Session[SessionParams.USER_ID].ToString()));
        }

        protected void btnMatrialCreate_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
            empid = int.Parse(arrayKeyItem[1].ToString());

            vno = arrayKeyItem[0].ToString();
            if (cbTax.Checked == true)
            { ysntxt = true; }
            else { ysntxt = false; }
          
            objMush.GetMatrialCreate(txtVatMatrialname.Text, ddlUOMMatrial.SelectedItem.ToString(), int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(ddlMatrialType.SelectedValue),   int.Parse(hdnAccno.Value), ysntxt);

        }
      
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
            intItemid = int.Parse(arrayKeyItem[1].ToString());

            objMush.getuomupdate(ddlUom.SelectedItem.ToString(), int.Parse(ddlUom.SelectedValue),int.Parse(Session[SessionParams.UNIT_ID].ToString()),int.Parse(hdnAccno.Value), intItemid);

        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemMatrial.Text.Split(delimiterCharss);
            empid = int.Parse(arrayKeyItem[1].ToString());
           
            vno= arrayKeyItem[0].ToString();
            if (cbTax.Checked == true)
            { ysntxt = true; }
            else { ysntxt = false; }
            strHscode = txtHScode.Text;
            objMush.getVatitemcreate(int.Parse(Session[SessionParams.UNIT_ID].ToString()),txtItemMatrial.Text, int.Parse(Session[SessionParams.USER_ID].ToString()),int.Parse(ddlUOMMatrial.SelectedValue), ddlUOMMatrial.SelectedItem.ToString(),strHscode,ysntxt,int.Parse(hdnAccno.Value));
           
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
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearchSAD(string prefixText)
        {
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            Mushok11 objAutoSearch_BLL = new Mushok11();
            return objAutoSearch_BLL.getSadItem(prefixText, unitid);

        }
        #endregion * ********** End search **********

    }
}