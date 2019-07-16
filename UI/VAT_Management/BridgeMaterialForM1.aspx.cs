using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using UI.ClassFiles;
using SAD_BLL.Vat;
using System.IO;
using System.Xml;

namespace UI.VAT_Management
{
    public partial class BridgeMaterialForM1 : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;
        string[] arrayKeyItem;
        int intFGID, intVatItemID, intPart, intCountm,intrawmaterialid;
        string filePathForXML, xmlString = "", xml, rmid, rmname;
        char[] delimiterChars = { '[', ']' }; bool ysnFactory;
        Mushok11 objVats = new Mushok11();
        #endregion =====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                filePathForXML = Server.MapPath("~/VAT_Management/Data/RMBridge_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                   
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();
                    Session["VatAccid"]= ddlVatAccount.SelectedValue.ToString();




                }
            }
            catch { }
        }

        protected void btnUpdateBridge_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                
                    char[] delimiterCharss = { '[', ']' };
                    arrayKeyItem = txtVatItemList.Text.Split(delimiterCharss);
                    decimal total = Int32.Parse(0.ToString());                                 
                    intVatItemID = int.Parse(arrayKeyItem[1].ToString());
                    arrayKeyItem = txtRawMatrialList.Text.Split(delimiterCharss);
                    intrawmaterialid= int.Parse(arrayKeyItem[1].ToString());

                    string message = objVats.InsertVATItemAndMaterialBridge( intrawmaterialid, intVatItemID, int.Parse(hdnUnit.Value), int.Parse(hdnEnroll.Value));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtRawMatrialList.Text = "";
                    txtVatItemList.Text = "";
                    
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();            
        }

        #region ===== Add Product =================================================================
       
       
  
    
     
      
        #endregion ================================================================================


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







    }
}