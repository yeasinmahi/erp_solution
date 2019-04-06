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

namespace UI.SAD.Setup
{
    public partial class GeoMarketSetup : BasePage
    {
        HR_BLL.Global.Unit objunit = new HR_BLL.Global.Unit();
        SetupBLL objsetup = new SetupBLL();
        DataTable dt; int id; 
        string email,contact,msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objunit.GetUnits((Session[SessionParams.USER_ID].ToString()));
                ddlunit.DataTextField = "strunit";
                ddlunit.DataValueField = "intUnitID";
                ddlunit.DataSource = dt;
                ddlunit.DataBind();

                GetBind(true,"");
                txtRegion.Enabled = true;
                txtArea.Enabled = true;
                txtTerritory.Enabled = true;
                btnAddRegion.Enabled = true;
                btnAddArea.Enabled = true;
                btnAddTerritory.Enabled = true;
                btnSave.Enabled = true;
                btnupdate.Enabled = false;
                rtnemployee.Checked = false;
                rtnmarket.Checked = true;

            }
        }

        private void GetBind(bool active, string type)
        {
            if(active==true)
            {
               
                dt = objsetup.getRegionlist(int.Parse(ddlunit.SelectedValue.ToString()));
                ddlRegion.DataTextField = "strText";
                ddlRegion.DataValueField = "intID";
                ddlRegion.DataSource = dt;
                ddlRegion.DataBind();

                dt.Clear();
                dt = objsetup.getAreaList(int.Parse(ddlunit.SelectedValue.ToString()), int.Parse(ddlRegion.SelectedValue.ToString()));
                ddlArea.DataTextField = "strText";
                ddlArea.DataValueField = "intID";
                ddlArea.DataSource = dt;
                ddlArea.DataBind();
                dt.Clear();
                dt = objsetup.getAreaList(int.Parse(ddlunit.SelectedValue.ToString()), int.Parse(ddlArea.SelectedValue.ToString()));
                ddlTerritory.DataTextField = "strText";
                ddlTerritory.DataValueField = "intID";
                ddlTerritory.DataSource = dt;
                ddlTerritory.DataBind();

            }
            else if ((active == false)&&(type=="R"))
            {

                dt = objsetup.getAreaList(int.Parse(ddlunit.SelectedValue.ToString()), int.Parse(ddlRegion.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    ddlArea.DataTextField = "strText";
                    ddlArea.DataValueField = "intID";
                    ddlArea.DataSource = dt;
                    ddlArea.DataBind();
                }
                dt.Clear();
                dt = objsetup.getAreaList(int.Parse(ddlunit.SelectedValue.ToString()), int.Parse(ddlArea.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    ddlTerritory.DataTextField = "strText";
                    ddlTerritory.DataValueField = "intID";
                    ddlTerritory.DataSource = dt;
                    ddlTerritory.DataBind();
                    dt.Clear();
                }


            }
            else if ((active == false) && (type == "A"))
            {
               
                dt = objsetup.getAreaList(int.Parse(ddlunit.SelectedValue.ToString()), int.Parse(ddlArea.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    ddlTerritory.DataTextField = "strText";
                    ddlTerritory.DataValueField = "intID";
                    ddlTerritory.DataSource = dt;
                    ddlTerritory.DataBind();
                    dt.Clear();
                }
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
                msg = objsetup.getEntryforSetup(int.Parse("0".ToString()), 1, txtRegion.Text, int.Parse(ddlunit.SelectedValue.ToString()), txtRegion.Text, email, 0, contact);
                txtRegion.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

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


                msg = objsetup.getEntryforSetup(int.Parse(ddlRegion.SelectedValue.ToString()), 2, txtArea.Text, int.Parse(ddlunit.SelectedValue.ToString()), txtArea.Text, email, 0, contact);
                txtArea.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
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
                msg = objsetup.getEntryforSetup(int.Parse(ddlArea.SelectedValue.ToString()), 3, txtTerritory.Text, int.Parse(ddlunit.SelectedValue.ToString()), txtTerritory.Text, email, 0, contact);
                txtTerritory.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(false, "R");
            hdnid.Value = ddlRegion.SelectedValue.ToString();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(false, "A");
            hdnid.Value = ddlArea.SelectedValue.ToString();
        }

        protected void ddlTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBind(false, "T");
            hdnid.Value = ddlTerritory.SelectedValue.ToString();
        }

        protected void rtnmarket_CheckedChanged(object sender, EventArgs e)
        {
            txtRegion.Enabled = true;
            txtArea.Enabled = true;
            txtTerritory.Enabled = true;
            btnAddRegion.Enabled = true;
            btnAddArea.Enabled = true;
            btnAddTerritory.Enabled = true;
            btnSave.Enabled = true;
            btnupdate.Enabled = false;
        }

        protected void rtnemployee_CheckedChanged(object sender, EventArgs e)
        {
            txtRegion.Enabled = false;
            txtArea.Enabled = false;
            txtTerritory.Enabled = false;
            btnAddRegion.Enabled = false;
            btnAddArea.Enabled = false;
            btnAddTerritory.Enabled = false;
            btnSave.Enabled = false;
            btnupdate.Enabled = true;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int geoid;
            string contact;
           
            if(ddlType.SelectedValue.ToString()=="1")
            {
                geoid =int.Parse(ddlRegion.SelectedValue.ToString());
                if((txtContact.Text!="")||(txtContact.Text=="0"))
                {
                    msg= objsetup.getContact(txtContact.Text,int.Parse(ddlType.SelectedValue.ToString()),geoid,int.Parse(ddlunit.SelectedValue.ToString()), 1);

                }
                if ((txtEmail.Text != "") || (txtEmail.Text == "0"))
                {
                    msg = objsetup.getContact(txtEmail.Text, int.Parse(ddlType.SelectedValue.ToString()), geoid, int.Parse(ddlunit.SelectedValue.ToString()), 2);
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

            }
            else if (ddlType.SelectedValue.ToString() == "2")
            {
                geoid = int.Parse(ddlArea.SelectedValue.ToString());
                if ((txtContact.Text != "") || (txtContact.Text == "0"))
                {
                    msg = objsetup.getContact(txtContact.Text, int.Parse(ddlType.SelectedValue.ToString()), geoid, int.Parse(ddlunit.SelectedValue.ToString()), 1);

                }
                if ((txtEmail.Text != "") || (txtEmail.Text == "0"))
                {
                    msg = objsetup.getContact(txtEmail.Text, int.Parse(ddlType.SelectedValue.ToString()), geoid, int.Parse(ddlunit.SelectedValue.ToString()), 2);
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

            }
            else if (ddlType.SelectedValue.ToString() == "3")
            {
                geoid = int.Parse(ddlTerritory.SelectedValue.ToString());
                if ((txtContact.Text != "") || (txtContact.Text == "0"))
                {
                    msg = objsetup.getContact(txtContact.Text, int.Parse(ddlType.SelectedValue.ToString()), geoid, int.Parse(ddlunit.SelectedValue.ToString()), 1);

                }
                if ((txtEmail.Text != "") || (txtEmail.Text == "0"))
                {
                    msg = objsetup.getContact(txtEmail.Text, int.Parse(ddlType.SelectedValue.ToString()), geoid, int.Parse(ddlunit.SelectedValue.ToString()), 2);
                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
            txtContact.Text = "";
            txtEmail.Text = "";

        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            dt = objsetup.getinfoShow(int.Parse(ddlType.SelectedValue.ToString()),int.Parse(ddlunit.SelectedValue.ToString()));
            GridView2.DataSource = dt;
            GridView2.DataBind();

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
                    id = int.Parse(ddlRegion.SelectedValue.ToString());
                }
                else if (ddlType.SelectedValue.ToString() == "2")
                {
                    id = int.Parse(ddlArea.SelectedValue.ToString());
                }
                else if (ddlType.SelectedValue.ToString() == "3")
                {
                    id = int.Parse(ddlTerritory.SelectedValue.ToString());
                }
                msg = objsetup.getEmailupdate(txtEmail.Text, txtContact.Text, id);
                txtEmail.Text = ""; txtContact.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }
    }
}