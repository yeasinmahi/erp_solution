using SAD_BLL.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

using System.Web.Script.Services;
using System.Web.Services;

using HR_BLL.Employee;

namespace UI.HR.Employee
{
    public partial class EmployeeCostCenterUpdate : Page
    {
        DataTable dt = new DataTable();
        CustomerGeo obj = new CustomerGeo();
        int LineId, RegionId, AreaId, TerritoryId, PointId, ProductId, ProductUOM,unitid,enroll,costid;
        EmpCostCenterBLL objCost = new EmpCostCenterBLL();
        decimal Qtypcs, Qty;
        DateTime Date;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetunitList();

                Session["UnitID"] = ddlunit.SelectedValue.ToString();
            }
        }

        private void GetunitList()
        {
            dt = objCost.GetUnitListe();
            ddlunit.DataTextField = "strUnit";
            ddlunit.DataValueField = "intUnitID";
            ddlunit.DataSource = dt;
            ddlunit.DataBind();


        }

        #region========Load DropDown List=====
      
       
        protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["UnitID"] = ddlunit.SelectedValue.ToString();
        }

        protected void btnupdate_Click1(object sender, EventArgs e)
        {
            if (gridView.Rows.Count > 0)
            {
                string text;
                for (int index = 0; index < gridView.Rows.Count; index++)
                {
                    

                        enroll = int.Parse(((Label)gridView.Rows[index].FindControl("lblintEmployeeID")).Text.ToString());
                        text = (((TextBox)gridView.Rows[index].FindControl("txtCustomer")).Text.ToString());
                        char[] delimiterCharss = { '[', ']' };
                        if (text != "")
                        {

                            arrayKeyItem = text.Split(delimiterCharss);
                            costid = int.Parse(arrayKeyItem[1].ToString());
                        objCost.getupdate(costid, enroll);
                    }
                        else { costid = int.Parse("0"); }

                   
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save!');", true);
             
            }
        }

      
        #endregion =======End Dropdown========

        #region========Button Operations=====

        protected void btnShow_Click(object sender, EventArgs e)
        {
            unitid = Convert.ToInt32(ddlunit.SelectedValue);
           

            dt = objCost.getEmpbyunit(unitid);

            if(dt.Rows.Count>0)
            {
                gridView.Loads(dt);
            }
           

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string ProductId = gridView.DataKeys[row.RowIndex]?.Value.ToString();


            TextBox QTY = row.FindControl("lblmontargetconvqty") as TextBox;
            Label UOM = row.FindControl("lblpackqty") as Label;

            string strqty = QTY.Text;
            string strUOM = UOM.Text;

            decimal pcs = Convert.ToDecimal(strqty) * Convert.ToDecimal(strUOM);

            Label QTYPCS = row.FindControl("lblQTYPcs") as Label;

            QTYPCS.Text = pcs.ToString();

           
        }

        #endregion =======End Button========

        #region========Load Grid Operations=====



        #endregion =======End Grid========


        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {

            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session["UnitID"].ToString(), prefixText);

        }
    }
}