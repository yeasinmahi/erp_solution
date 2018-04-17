using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using HR_BLL.Global;
using Dairy_BLL;
using HR_BLL.Dispatch;

namespace UI.HR.Dispatch
{
    public partial class rptDispatchReportForExcel : BasePage
    {
        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML, xmlString = "", xml;
        int intPart, intEnroll;
        string itemid, itemname, qty, remarks;
        
        int intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/HR/Dispatch/Data/AddDispatch_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {   
                     
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            intPart = 13;
            intEnroll = int.Parse(hdnEnroll.Value);
            dt = new DataTable();
            dt = obj.GetDispatchReport(intPart, intEnroll);
            dgvReportForExcel.DataSource = dt;
            dgvReportForExcel.DataBind();
        }

        #region ===== Export To Excel ====================================================
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string html = HdnValue.Value;
            ExportToExcel(ref html, "MyReport");
        }
        public void ExportToExcel(ref string html, string fileName)
        {
            html = html.Replace("&gt;", ">");
            html = html.Replace("&lt;", "<");
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xls");
            HttpContext.Current.Response.ContentType = "application/xls";
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();            
        }
        #endregion =======================================================================














    }
}