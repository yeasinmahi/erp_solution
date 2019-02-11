using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using SAD_BLL.Global;
using UI.ClassFiles;
using SAD_BLL.Transport;

namespace UI.Transport
{
    public partial class NewVehicleEntry : BasePage
    {
        HR_BLL.Global.Unit objunit = new HR_BLL.Global.Unit();
        SetupBLL objsetup = new SetupBLL();
        DataTable dt; int id; 
        string email,contact,msg;
        NewVehicleBLL objVehicle = new NewVehicleBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objunit.GetUnits("37426");
                ddlunit.DataTextField = "strunit";
                ddlunit.DataValueField = "intUnitID";
                ddlunit.DataSource = dt;
                ddlunit.DataBind();

                GetBind(true,"");
                
            }
        }

        private void GetBind(bool active, string type)
        {
            if(active==true)
            {
              //  objVehicle.getVehicle(txtVehicleNo.Text);
               

            }
            else if ((active == false)&&(type=="R"))
            {

               


            }
            else if ((active == false) && (type == "A"))
            {
              
            }
        }

        protected void btnAddRegion_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (txtEmail.Text == "")
                {
                    email = "";
                }
                else
                {
                    email = txtEmail.Text;
                }
                if (txtContact.Text == "")
                {
                    contact = "";
                }
                else
                {
                    contact = txtContact.Text;
                }
               // msg = objsetup.getEntryforSetup(int.Parse("0".ToString()), 1, txtRegion.Text, int.Parse(ddlunit.SelectedValue.ToString()), txtRegion.Text, email, 0, contact);
                //txtRegion.Text = "";
               // ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

            }
        }

        protected void btnAddArea_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (txtEmail.Text == "")
                {
                    email = "";
                }
                else
                {
                    email = txtEmail.Text;
                }
                if (txtContact.Text == "")
                {
                    contact = "";
                }
                else
                {
                    contact = txtContact.Text;
                }


              //  msg = objsetup.getEntryforSetup(int.Parse(ddlRegion.SelectedValue.ToString()), 2, txtArea.Text, int.Parse(ddlunit.SelectedValue.ToString()), txtArea.Text, email, 0, contact);
              //  txtArea.Text = "";
              //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        protected void btnAddTerritory_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (txtEmail.Text == "")
                {
                    email = "";
                }
                else
                {
                    email = txtEmail.Text;
                }
                if (txtContact.Text == "")
                {
                    contact = "";
                }
                else
                {
                    contact = txtContact.Text;
                }
            //    msg = objsetup.getEntryforSetup(int.Parse(ddlArea.SelectedValue.ToString()), 3, txtTerritory.Text, int.Parse(ddlunit.SelectedValue.ToString()), txtTerritory.Text, email, 0, contact);
             //   txtTerritory.Text = "";
             //   ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(false, "R");
            //hdnid.Value = ddlRegion.SelectedValue.ToString();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(false, "A");
          //  hdnid.Value = ddlArea.SelectedValue.ToString();
        }

        protected void ddlTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(false, "T");
           // hdnid.Value = ddlTerritory.SelectedValue.ToString();
        }

        protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(true, "");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (ddlType.SelectedValue.ToString() == "1")
                {
                 //   id = int.Parse(ddlRegion.SelectedValue.ToString());
                }
                else if (ddlType.SelectedValue.ToString() == "2")
                {
                 //id = int.Parse(ddlArea.SelectedValue.ToString());
                }
                else if (ddlType.SelectedValue.ToString() == "3")
                {
                //    id = int.Parse(ddlTerritory.SelectedValue.ToString());
                }
             //   msg = objsetup.getEmailupdate(txtEmail.Text, txtContact.Text, id);
              //  txtEmail.Text = ""; txtContact.Text = "";
              //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }
    }
}