using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class ProfitCenter : System.Web.UI.Page
    {
        AssetMaintenance objWorkorderParts = new AssetMaintenance();
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "", xmlstring2 = "";

        int check;
        string pID, pIDName, accountName, LocationData, Location;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomR__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvRoute.DataSource = ""; dgvRoute.DataBind(); }
                catch { }

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    ddlWh.DataSource = dt;
                    ddlWh.DataTextField = "strName";
                    ddlWh.DataValueField = "Id";
                    ddlWh.DataBind();
                }

                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getBomRouting(4, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value.ToString();
                }
              

                dt = objBom.getWorkstationParent();
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                try
                {
                    pID = ListBox1.SelectedValue.ToString();
                    pIDName = ListBox1.SelectedItem.ToString();
                    hdnOpID.Value = pID;
                    hdnOpName.Value = pIDName;
                }
                catch { }
                 
                pnlUpperControl.DataBind();

            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();

            return objBoms.AutoSearchBomId(HttpContext.Current.Session["unit"].ToString(), prefixText,1);

        }
        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                intwh = int.Parse(ddlWh.SelectedValue);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.getBomRouting(4, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value.ToString();
                }

                txtFgItem.Text = "";
                dt = objBom.getWorkstationParent();
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                pID = ListBox1.SelectedValue.ToString();
                pIDName = ListBox1.SelectedItem.ToString();
                hdnOpID.Value = pID;
                hdnOpName.Value = pIDName;

                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
            }
            catch { }
        }
        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try { 
            //{
            //    LoadGridwithXml();
            //    DataSet dsGrid = (DataSet)dgvRoute.DataSource;
            //    dsGrid.Tables[0].Rows[dgvRoute.Rows[e.RowIndex].DataItemIndex].Delete();
            //    dsGrid.WriteXml(filePathForXML);
            //    DataSet dsGridAfterDelete = (DataSet)dgvRoute.DataSource;
            //    if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            //    { File.Delete(filePathForXML); dgvRoute.DataSource = ""; dgvRoute.DataBind(); }
            //    else { LoadGridwithXml(); }


            }

            catch { }
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

                intwh = int.Parse(ddlWh.SelectedValue);
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


            }
            catch { }
        }

        #region==================Link Button Chaild View======================
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getWorkstationParent();
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();


                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
               // checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
               // checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
              //  checkParent();
            }
            catch { }

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn3.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton4.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
              //  checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
               // checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
              //  checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
              //  checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
               // checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton10.Text = string.Empty;
              //  checkParent();
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
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
               // checkParent();
            }
            catch { }

        }

        #endregion=================Close================================================
    }
}