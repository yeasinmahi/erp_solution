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

namespace UI.SAD.ExcelChallan
{
    public partial class frmVehicleSetbyTransport : BasePage
    {
        string Phoneno,vno,VSupplierName;
        int intshipid,vid, Custid, empid;
        DataTable dt;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        ExcelDataBLL objExcel = new ExcelDataBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = objExcel.getShippoint(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(Session[SessionParams.UNIT_ID].ToString()), true);
                ddlshippoint.DataTextField = "strName";
                ddlshippoint.DataValueField = "intShipPointId";
                ddlshippoint.DataSource = dt;
                ddlshippoint.DataBind();
                dt.Clear();
                dt = objExcel.getOffice(int.Parse(Session[SessionParams.USER_ID].ToString()), int.Parse(Session[SessionParams.UNIT_ID].ToString()), true);
                ddlOfficeName.DataTextField = "strName";
                ddlOfficeName.DataValueField = "intSalesOffId";
                ddlOfficeName.DataSource = dt;
                ddlOfficeName.DataBind();
                dt.Clear();
            }
        }
        protected void btnReport_Click(object sender, EventArgs e)
        {
            
            dt = objExcel.UploadData(int.Parse(ddlshippoint.SelectedValue));
            dgvExcelOrder.DataSource = dt;
            dgvExcelOrder.DataBind();
            dgvExcelOrder.Visible = true;
            dgvVehicle.Visible = false;
            dgvVehicle.DataBind();
        }
        protected double Pendingtotal = 0;
        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            getMobileno();
        }
        private void getMobileno()
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtEmployee.Text.Split(delimiterCharss);
            empid = Int32.Parse(arrayKeyItem[1].ToString());
            dt= objExcel.getEmpinfo(empid);
            if (dt.Rows.Count > 0)
            {
                txtphone.Text = dt.Rows[0]["phoneno"].ToString();
            }

        }
        protected void btnFinalRpt_Click(object sender, EventArgs e)
        {
            getVhileFinalReport();

        }
        private void getVhileFinalReport()
        {
            dt = objExcel.getVehilceReport(int.Parse(ddlshippoint.SelectedValue));
            dgvVehicle.DataSource = dt;
            dgvVehicle.DataBind();
            dgvVehicle.Visible = true;
            dgvExcelOrder.Visible = false;
            dgvExcelOrder.DataBind();
        }
        #region ******************* Total ***********
        protected double TotalQtytotal = 0;
        protected void dgvExcelOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[7].FindControl("lblqty")).Text == "")
                {
                    Pendingtotal += 0;
                }
                else
                {
                    Pendingtotal += double.Parse(((Label)e.Row.Cells[7].FindControl("lblqty")).Text);
                }
            }

        }

        #endregion *********** end ***************88
        protected void btnDelete(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'"," ");
                string[] searchKey = temp.Split(delimiterChars);            
                Custid = int.Parse(searchKey[0].ToString());
                vid = int.Parse(searchKey[1].ToString());
                objExcel.getVdelete(Custid, vid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Delete!');", true);
                getVhileFinalReport();
            }
            catch { }
        }
        protected void btnCompany_CheckedChanged(object sender, EventArgs e)
        {
            txtSuppliername.Text = "Company";
        }
        protected void btnSupp_CheckedChanged(object sender, EventArgs e)
        {
            txtSuppliername.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtEmployee.Text.Split(delimiterCharss);
            empid = int.Parse(arrayKeyItem[1].ToString());
            arrayKeyItem = txtVehicle.Text.Split(delimiterCharss);     
            vid = int.Parse(arrayKeyItem[1].ToString());
            vno= arrayKeyItem[0].ToString();
            if(txtSuppliername.Text=="") { VSupplierName = "0"; }
            else { VSupplierName = txtSuppliername.Text; }           
            intshipid = int.Parse(ddlshippoint.SelectedValue);
            Phoneno = (txtphone.Text);

            if (dgvExcelOrder.Rows.Count > 0)
            {

                for (int index = 0; index < dgvExcelOrder.Rows.Count; index++)
                {
                    if (((CheckBox)dgvExcelOrder.Rows[index].Cells[0].Controls[0]).Checked)
                    {
                         Custid =int.Parse(((Label)dgvExcelOrder.Rows[index].FindControl("lblCustid")).Text.ToString());
                         objExcel.Insertvehicle(Custid, intshipid, vid, vno, empid, VSupplierName); 
                    }
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save!');", true);
                dgvExcelOrder.DataBind();
            }
        }
        #region ******* search **********
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            ExcelDataBLL objAutoSearch_BLL = new ExcelDataBLL();   
            return objAutoSearch_BLL.GetVehicle(prefixText);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] EmployeeSearch(string prefixText, int count = 0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetEmployeeSearch(prefixText);

        }
        #endregion * ********** End search **********

    }
}