using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using System.Data;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.Drawing.Printing;
using System.Drawing;

namespace UI.AEFPS
{
    public partial class fpsSubLedger : System.Web.UI.Page
    {
        int empid,intitemid,intEntryid,id,intWID, intpaymenttype, intInsertby;
          string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        string msg, strWHName;
        DataTable dt, dtr;
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtefdate, dtetdate;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtEmployee.Text != "") || (txtfdate.Text != "") || (txttdate.Text != ""))
            {
               
                    dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                    dtetdate = DateTime.Parse(txttdate.Text.ToString());
                    empid = int.Parse(hdnEnroll.Value.ToString());
                   
                 
                    
                    dt = objAEFPS.getSubLedgerEmpAEFPS(dtefdate, dtetdate,empid);
                    dgvRptTemp.DataSource = dt;
                    dgvRptTemp.DataBind();
                   
                  
            }else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Employee Inforation!');", true); }
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {

        }

        string qrcode,uom, ItemName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                
            }
            else
            {
                getResult();
            }
        }

        private void getResult()
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtEmployee.Text.Split(delimiterCharss);
            decimal total = Int32.Parse(0.ToString());
            empid = Int32.Parse(arrayKeyItem[1].ToString());
            dt = objAEFPS.getEmpinfo(empid);
            if (dt.Rows.Count > 0)
            {

               if (dt.Rows.Count > 0)
                {
                 
                    hdnEnroll.Value =  (dt.Rows[0]["intEmployeeID"].ToString());
                    lblsalesAmount.Text = (dt.Rows[0]["strEmployeeName"].ToString());
                }

            }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] EmployeeSearch(string prefixText, int count=0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetEmployeeSearch(prefixText);

        }
        protected double TotalnumQty = 0, TotalAmount = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
            }
        }

     
     
    }
}