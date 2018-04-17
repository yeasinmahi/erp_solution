using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using SCM_BLL;
using System.Data;
using SAD_BLL.AutoChallan;
using UI.ClassFiles;
using System.Xml;
using System.IO;

namespace UI.SCM.Transfer
{
    public partial class rptTransferReport : System.Web.UI.Page
    {      
        int intShipid,intLocationid,intOutWHid,intWHID,intVid,intUomid, vid, enroll, itemid, intReff = 0,inttTransferTypeid;
        decimal Qty,Values,Stock;string xmlpath = "", xmlString,ItemName,UOM,msg,Remarks;
        DataTable dt;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        TransferBLLNew TBLL = new TransferBLLNew();
        ExcelDataBLL objExcel = new ExcelDataBLL();
        bool ysnSumByProduct;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SCM/Data/TOrder_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                hdnEnroll.Value = "1";
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = TBLL.getWhbyuser(int.Parse(Session[SessionParams.USER_ID].ToString()));
                ddlshippoint.DataTextField = "strDescription";
                ddlshippoint.DataValueField = "intWHID";
                ddlshippoint.DataSource = dt;
                ddlshippoint.DataBind();
                dt.Clear();
                getShippointTo();
              
               
            }
            else {  }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                arrayKeyItem = txtItemName.Text.Split(delimiterCharss);
                if (arrayKeyItem.Length > 0)
                { itemid = Int32.Parse(arrayKeyItem[1].ToString()); }
            }
            else { itemid = 0; }
            if(ddlFromWH.SelectedItem.ToString()=="")
            {
                intWHID = 0;
            }
            else { intWHID = int.Parse(ddlFromWH.SelectedValue); }
            if (ddlToWH.SelectedItem.ToString() == "")
            {
                intOutWHid = 0;
            }
            else {intOutWHid= int.Parse(ddlToWH.SelectedValue); }
            if(CheckBox1.Checked==true)
            {
                dt = TBLL.getRpt(intWHID, intOutWHid, txtFrom.Text, txtTo.Text, ysnSumByProduct = true);
                dgvRptProductTotal.DataSource = dt;
                dgvRptProductTotal.DataBind();
                dgvRptProductTotal.Visible = true;
                dgvDetails.Visible = false;
            }
            else { dt = TBLL.getRpt(intWHID, intOutWHid, txtFrom.Text, txtTo.Text, ysnSumByProduct = false);
                dgvDetails.DataSource = dt;
                dgvDetails.DataBind();
                dgvDetails.Visible = true;
                dgvRptProductTotal.Visible = false;
               
            }
           
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
           
        }
       
        protected void ddlShipPointTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void getShippointTo()
        {
            dt = TBLL.getRWH(int.Parse(ddlshippoint.SelectedValue));
            ddlFromWH.DataTextField = "strWareHoseName";
            ddlFromWH.DataValueField = "intInWHID";
            ddlFromWH.DataSource = dt;
            ddlFromWH.DataBind();
            ddlToWH.Items.Add(new ListItem("", "0"));
            ddlToWH.DataTextField = "strWareHoseName";
            ddlToWH.DataValueField = "intInWHID";
            ddlToWH.DataSource = dt;
            ddlToWH.DataBind();
        }

        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            int typeid;
            DataTable dt;
            dt=  DataClass.GetItemType(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()));
            typeid = int.Parse(dt.Rows[0]["intID"].ToString());
            TransferBLLNew objAutoSearch_BLL = new TransferBLLNew();
            return objAutoSearch_BLL.GetItemlistInv( int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), prefixText);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] VehicleSearch(string prefixText)
        {
            ExcelDataBLL objAutoSearch_BLL = new ExcelDataBLL();
            return objAutoSearch_BLL.GetVehicle(prefixText);
        }
       

        #endregion *********** Search ***************** 
    }
   

}
public class DataClassNewrptTransferReport
{
    public static TransferBLLNew TBLL = new TransferBLLNew();
    public static DataTable dt;
 
    internal static DataTable GetItemType(int unitid)
    {     
            dt = TBLL.Itemtype(unitid);
            return dt;      
    }

    internal static DataTable getShipPointList(int unitid)
    {
        dt = TBLL.getShippontList(unitid);
        return dt;
    }

    internal static DataTable getToOffice(int Officeid)
    {
        dt = TBLL.getToOffice(Officeid);
        return dt;
    }

    internal static DataTable GetUomList(int Unitid)
    {
        dt = TBLL.getUOMlist(Unitid);
        return dt;
    }
}