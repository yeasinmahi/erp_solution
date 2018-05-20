using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class WorkStationCreate : BasePage
    {
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "", xmlstring2 = "";

        int check;
        string pID, pIDName, accountName, LocationData, Location;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.getBomRouting(1, xmlString, xmlData, intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intwh = int.Parse(ddlWH.SelectedValue);
               
                dt = objBom.getWorkstationParent(intwh);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                checkParent();

                pnlUpperControl.DataBind();
            }
        }

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
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getWorkstationParent(intwh);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                
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

                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                if (LinkButton2.Text.Length == 0) { LinkButton2.Text = accountName.ToString(); hdn1.Value = pID; }
                else if (LinkButton3.Text.Length == 0) { LinkButton3.Text = accountName.ToString(); hdn2.Value = pID; }
                else if (LinkButton4.Text.Length == 0) { LinkButton4.Text = accountName.ToString(); hdn3.Value = pID; }
                else if (LinkButton5.Text.Length == 0) { LinkButton5.Text = accountName.ToString(); hdn4.Value = pID; }
                else if (LinkButton6.Text.Length == 0) { LinkButton6.Text = accountName.ToString(); hdn5.Value = pID; }
                else if (LinkButton7.Text.Length == 0) { LinkButton7.Text = accountName.ToString(); hdn6.Value = pID; }
                else if (LinkButton8.Text.Length == 0) { LinkButton8.Text = accountName.ToString(); hdn7.Value = pID; }
                else if (LinkButton9.Text.Length == 0) { LinkButton9.Text = accountName.ToString(); hdn8.Value = pID; }
                else if (LinkButton10.Text.Length == 0) { LinkButton10.Text = accountName.ToString(); hdn9.Value = pID; }
                checkParent();

            }
            catch { }
        }

        protected void BtnSaves_Click(object sender, EventArgs e)
        {
            try
            {
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);

                string strName = hdnOpName.Value;
                //string[] strArray = strName.Split('>');
                //foreach (string itm in strArray)
                //{
                //    Location += (itm.ToString());
                //}

                Location =Txtname.Text.ToString();
                int parentID = int.Parse(hdnOpID.Value);

                string xmlString = "<voucher><voucherentry location=" + '"' + Location + '"' + "/></voucher>".ToString();

                string msg = objBom.GetRoutingData(11, xmlString, xmlData, intwh, parentID, DateTime.Now, enroll);

                Txtname.Text = string.Empty;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                pID = hdnOpID.Value;

     
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

              

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
            }
            catch { }

        }

        #region==================Link Button Chaild View======================
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                intwh = int.Parse(ddlWH.SelectedValue); 
                dt = objBom.getWorkstationParent(intwh);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();


                LinkButton2.Text = string.Empty;
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
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
            
                pID = hdn2.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton3.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
                ;
                pID = hdn3.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton4.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
                 
                pID = hdn4.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton5.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
              
                pID = hdn5.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton6.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
            try
            {
                
                pID = hdn6.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton7.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
               
                pID = hdn7.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton8.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
                
                pID = hdn8.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton9.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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
                 
                pID = hdn9.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton10.Text.ToString();
                intwh = int.Parse(ddlWH.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
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