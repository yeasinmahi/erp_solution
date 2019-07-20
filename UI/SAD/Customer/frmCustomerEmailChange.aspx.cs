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
using Flogging.Core;
using GLOBAL_BLL;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Item;

namespace UI.SAD.Customer
{
    public partial class frmCustomerEmailChange : BasePage
    {     
        DataTable dt; int Custid;
        ExcelDataBLL objExcel = new ExcelDataBLL();
        SeriLog log = new SeriLog();
        string location = "SAD", msg;
        string start = "starting SAD\\ExcelChallan\\frmExcelupload";
        string stop = "stopping SAD\\ExcelChallan\\frmExcelupload";
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
               
              
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] CustomerSearch(string prefixText, int count = 0)
        {
            ItemPromotion objPromotion = new ItemPromotion();
            return objPromotion.GetCstomer("2",prefixText);

        }
        
    }
}