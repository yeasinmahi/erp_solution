using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class WHLocationCreate :BasePage
    {
        Location_BLL objOperation = new Location_BLL();
      
        DataTable dt = new DataTable();  int check;
        string pID, pIDName, accountName, LocationData,  Location; int enroll,intWH;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objOperation.WhDataView(1, "", intWH, 0, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                intWH = int.Parse(ddlWH.SelectedValue);

                dt = new DataTable();
                dt = objOperation.WhDataView(2, "", intWH, 0, enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
 
                dt = objOperation.WhDataView(5, "", intWH, 0, enroll);
                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();

                checkParent();

                pnlUpperControl.DataBind();
            }
        }


        #region===================Action==========================================
            private void checkParent()
            {
                if (LinkButton2.Text == string.Empty)
                {
                    BtnAddParent.Visible = false;
                }
                else
                {
                    BtnAddParent.Visible = true;
                }
           
            }
            protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(2, "", intWH, 0, enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                dt = objOperation.WhDataView(5, "", intWH, 0, enroll);
                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();

                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
            protected void BtnAddParent_Click(object sender, EventArgs e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
            }
            protected void BtnCancel_Click(object sender, EventArgs e)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
            }
            protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    dt = new DataTable();
                    accountName = ">" + ListBox1.SelectedItem.ToString();
                    pID = ListBox1.SelectedValue.ToString();
                    pIDName = ListBox1.SelectedItem.ToString();
                    hdnOpID.Value = pID;
                    hdnOpName.Value = pIDName;

                    intWH = int.Parse(ddlWH.SelectedValue);
                    dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                    ListBox1.DataSource = dt;
                    ListBox1.DataTextField = "strName";
                    ListBox1.DataValueField = "Id";
                    ListBox1.DataBind();

                    if (LinkButton2.Text.Length==0) { LinkButton2.Text = accountName.ToString(); hdn1.Value = pID; }
                    else if (LinkButton3.Text.Length==0) { LinkButton3.Text = accountName.ToString(); hdn2.Value = pID; }
                    else if (LinkButton4.Text.Length==0) { LinkButton4.Text = accountName.ToString(); hdn3.Value = pID; }
                    else if (LinkButton5.Text.Length==0) { LinkButton5.Text = accountName.ToString(); hdn4.Value = pID; }
                    else if (LinkButton6.Text.Length==0) { LinkButton6.Text = accountName.ToString(); hdn5.Value = pID; }
                    else if (LinkButton7.Text.Length==0) { LinkButton7.Text = accountName.ToString(); hdn6.Value = pID; }
                    else if (LinkButton8.Text.Length == 0) { LinkButton8.Text = accountName.ToString(); hdn7.Value = pID; }
                    else if (LinkButton9.Text.Length ==0) { LinkButton9.Text = accountName.ToString(); hdn8.Value = pID; }
                    else if (LinkButton10.Text.Length ==0) { LinkButton10.Text = accountName.ToString(); hdn9.Value = pID; }
                    checkParent();

                }
                catch { } 
            }

            protected void BtnSaves_Click(object sender, EventArgs e)
            {   try
                {
                    int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intWH = int.Parse(ddlWH.SelectedValue);
             
                string strName = hdnOpName.Value; 
                string[] strArray = strName.Split('>');
                foreach (string itm in strArray)
                {
                     Location += (itm.ToString());
                }

                    Location +=" "+Txtname.Text.ToString();
                    int parentID = int.Parse(hdnOpID.Value);
                    string xmlLocation = "<voucher><voucherentry location=" + '"' + Location + '"' + "/></voucher>".ToString();

                    string msg = objOperation.WHLocationCreate(4, xmlLocation, intWH, parentID, enroll);
                    Txtname.Text = string.Empty;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                pID = hdnOpID.Value;
               
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
                }
                catch { }
           
            }


        #endregion==========Close=============================================

        #region==================Link Button Chaild View======================
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(2, "", intWH, 0, enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton2.Text =string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                pID = hdn1.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton2.Text.ToString();
                intWH = int.Parse(ddlWH.SelectedValue);
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
          
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {   
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn2.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton3.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn3.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton4.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
          
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn4.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton5.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();


                LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn5.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton6.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            try {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn6.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton7.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        }
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn7.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton8.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        } 
       
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn8.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton9.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }
           
        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                pID = hdn9.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton10.Text.ToString();
                dt = objOperation.WhDataView(3, "", intWH, int.Parse(pID), enroll);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                checkParent();
            }
            catch { }
            
        }

#endregion=================Close================================================

    }
}