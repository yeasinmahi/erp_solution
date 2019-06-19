
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using System.Web.UI;

/*
 * Author   : Muktadir
 * Date     : 12-June-2019
 * For      : Item Location Update
 * Type     : New Work
 */

namespace UI.SCM
{
    public partial class WHItemLocationUpdate : BasePage
    {
        #region INIT
        private Location_BLL objOperation = new Location_BLL();
        private DataTable dt = new DataTable();
        private int check;
        private int enroll, intWH;
        private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML;
        private string xmlString = "";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ast = new AutoSearch_BLL();
                try
                {
                    File.Delete(filePathForXML);
                    dgvWHLocation.DataSource = "";
                    dgvWHLocation.DataBind();
                }
                catch
                {
                }
                pnlUpperControl.DataBind();


                DefaltLoad(sender);
            }
        }
        #endregion

        #region Event
        protected void Show_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWH = int.Parse(ddlWH.SelectedValue);
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = "";
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString();
                    itemid = arrayKey[1].ToString();
                }
                dt = objOperation.WhDataView(8, "", intWH, int.Parse(itemid), 1);

                

                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();

                //dt = objOperation.WhLocationView(intWH);
                //GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                //DropDownList ddlNewLocation = row.FindControl("lblPo") as DropDownList;
                //ddlNewLocation.DataSource = dt;
                //ddlNewLocation.DataTextField = "strLocationName";
                //ddlNewLocation.DataValueField = "intStoreLocationID";
                //ddlNewLocation.DataBind();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Method
        private void DefaltLoad(object sender)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objOperation.WhDataView(1, "", intWH, 0, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intWH = int.Parse(ddlWH.SelectedValue);
                Session["WareID"] = ddlWH.SelectedValue.ToString();
                ddlLocation.Visible = false;
            }
            catch { }
        }

        static AutoSearch_BLL ast = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSearch(string prefixText, int count)
        {
             return ast.AutoSearchItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            //return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

       
        public DataTable GetWHLocation()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objOperation.WhLocationView(Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString()));
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }
        #endregion




    }
}