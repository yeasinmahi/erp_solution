using Purchase_BLL.VehicleRegRenewal_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class TransportYearlyCostDetaills : BasePage
    {
        DataTable dt = new DataTable();

        RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
        int unitid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtVheicleNumber.Attributes.Add("onkeyUp", "SearchText();");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtVheicleNumber.Text))
                {
                    string strvheiclename = txtVheicleNumber.Text;
                    LoadFieldValue(strvheiclename);

                }
                else
                {
                    //ClearControls();
                }
            }
        }
        private void LoadFieldValue(string vhclname)
        {
            try
            {
                string strvheiclename = txtVheicleNumber.Text;
                RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();


            DataTable objDT = new DataTable();
                objDT = bll.RouteTransportCostDetAssetidbase(strvheiclename);
                if (objDT.Rows.Count >= 0)
                {
                  
                    txtVheicleCatg.Text = objDT.Rows[0]["strvheiclecatg"].ToString();
                    txtAssetCode.Text = objDT.Rows[0]["strassetid"].ToString();
                    txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                }

            }
            catch { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data to Show...');", true); }
            //catch (Exception ex) { throw ex; }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {

            try
            {
                string strvheiclename = txtVheicleNumber.Text;
                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                int enr = int.Parse(hdnenrol);
                dt = bll.RouteTransportCostDetAssetidbase(strvheiclename);
            }
            catch
            {
                //
            }

            if (dt.Rows.Count > 0)
                {
                grdvForRouteTransportcostDet.DataSource = dt;
                grdvForRouteTransportcostDet.DataBind();
                }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
            }

        }
        [WebMethod]
        public static List<string> GetAutoserachingAssetName( string strSearchKey)
        {
            RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
          
            List<string> result = new List<string>();
            result = bll.AutoSearchAssetName(strSearchKey);
            return result;
        }
        protected void grdvForRouteTransportcostDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvForRouteTransportcostDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            

            for (int i = 0; i <= grdvForRouteTransportcostDet.Rows.Count - 1; i++)
            {
                Label lblparent78 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label78");

                if (lblparent78.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[8].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[8].BackColor = Color.Red;
                }

                Label lblparent79 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label79");

                if (lblparent79.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[13].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[13].BackColor = Color.Red;
                }

                Label lblparent80 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label80");

                if (lblparent80.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[18].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[18].BackColor = Color.Red;
                }
                Label lblparent81 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label81");

                if (lblparent81.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[23].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[23].BackColor = Color.Red;
                }
                Label lblparent82 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label82");

                if (lblparent82.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[28].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[28].BackColor = Color.Red;
                }

                Label lblparent83 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label83");

                if (lblparent83.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[33].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[33].BackColor = Color.Red;
                }
                Label lblparent108 = (Label)grdvForRouteTransportcostDet.Rows[i].FindControl("Label108");

                if (lblparent108.Text == "Approved")
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[38].BackColor = Color.Yellow;
                }
                else
                {
                    grdvForRouteTransportcostDet.Rows[i].Cells[38].BackColor = Color.Red;
                }
            }

        }
           


        

        protected void btnDetRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration();", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('Detalis_Registration_UI.aspx');", true);
            }
            catch { }


        }

        protected void btnDetTaxToken_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TaxToken();", true);
            }
            catch { }
        }

        protected void btnDetFitness_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Fitness();", true);
            }
            catch { }
        }

        protected void btnDetRoutePermit_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "RoutePermit();", true);
            }
            catch { }
        }

        protected void btnDetInsurance_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Insurance();", true);
            }
            catch { }
        }

        protected void btnDetNamePlate_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "NamePlate();", true);
            }
            catch { }
        }

        protected void btnDRC_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 AutoID = int.Parse(searchKey[0].ToString());
                Session["AutoID"] = AutoID;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DRC();", true);
            }
            catch { }
        }

       
    }
}