using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.SupplyChain;
using System.Text.RegularExpressions;
using System.Web.Services;
using HR_BLL.Global;


namespace UI.Inventory
{
    public partial class SupplierProfile : System.Web.UI.Page
    {
        //SCM obj = new SCM(); 
        //DataTable dt;

        CSM obj = new CSM();
        DataTable dt;
    
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    //hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    //hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
              
                    //txtCustomerSearch.Attributes.Add("onkeyUp", "SearchText();"); 
                }
                catch { }
            }
            else
            {
                //hdnUnitIDByddl.Value = ddlUnit.SelectedValue.ToString();
                //hdnBankID.Value = ddlAdvisingBank.SelectedValue.ToString();

                //HttpContext.Current.Session["intunitid"] = ddlUnit.SelectedValue.ToString();

                //if (!String.IsNullOrEmpty(txtCustomerSearch.Text))
                //{
                //    string strSearchKey = txtCustomerSearch.Text;
                //    string[] searchKey = Regex.Split(strSearchKey, ",");
                //    hdfEmpCode.Value = searchKey[1];

               
                //    try
                //    {
                //        if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                //        {
                //            GetSearchResult(searchKey[1]);
                //            hdfSearchBoxTextChange.Value = "false";
                //        }
                //    }
                //    catch { }
                //}
               
            }



        }

        [WebMethod]
        //public static List<string> GetCustomerList(string strSearchKey)
        //{
        //    //AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        //    //List<string> result = new List<string>();
        //    //result = objAutoSearch_BLL.AutoSearchCustomerList( /*strSearchKey, 21);*/
        //    //strSearchKey, int.Parse(HttpContext.Current.Session["intunitid"].ToString()));
        //    //return result;
        //}

        private void GetSearchResult(string custid)
        {
            //intCustID = int.Parse(custid.ToString());
            //dt = objPI.GetPIForSearchPIEntryByCustomer(intCustID);

            //ddlSearchPI.DataTextField = "strReffNo";
            //ddlSearchPI.DataValueField = "intID";
            //ddlSearchPI.DataSource = dt;
            //ddlSearchPI.DataBind();

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string searchkey = txtSupplierSearch.Text;

            if (txtSupplierSearch.Text != "")
            {
                dt = new DataTable();
                dt = obj.GetSupplierProfile(searchkey);
                dgvReport1.DataSource = dt;
                dgvReport1.DataBind();
            }
            else
            {
                dt = new DataTable();
                dt = obj.GetAllSupplierProfile();
                dgvReport1.DataSource = dt;
                dgvReport1.DataBind();
            }


        }

        protected void dgvReport1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FF0000';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            }
        }
    }

}