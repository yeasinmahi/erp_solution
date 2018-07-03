using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UI.ClassFiles;
using Purchase_BLL;
using Purchase_BLL.SupplyChain;
using System.IO;
using System.Xml;
using System.Web.Services;
using HR_BLL.Global;

namespace UI.Inventory
{
    public partial class ItemEnlistment : BasePage
    {
        DataTable dt = new DataTable();
        CSM InsertSupplier = new CSM();
        CSM Enlist = new CSM();
        CSM bankcheck = new CSM();
        CSM report = new CSM();
        int enroll; int intClusterid;  int intCommodityId; int intCategoryId;  string strName; string strDescription; string strPartNo; string strBrand; string strUoM; int intLastActionBy;
        //string filePathForXML; string xmlString = ""; string xml;

        protected void Page_Load(object sender, EventArgs e)
        {
            enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            //filePathForXML = Server.MapPath("~/Inventory/Data/ItemEnlistment_" + enroll.ToString() + ".xml");

            if (!IsPostBack)
            {
                txtItemName.Attributes.Add("onkeyUp", "SearchTextemp();");

                DataTable dtcount = new DataTable();
                
                txtItemName.Text = "";
                txtDescription.Text = "";
                txtPartNo.Text = "";
                txtstrBrand.Text = "";

                dt = Enlist.GetDataCluster();
                ddlCluster.DataTextField = "strCluster";
                ddlCluster.DataValueField = "intCluster";
                ddlCluster.DataSource = dt;
                ddlCluster.DataBind();

                intClusterid = int.Parse(ddlCluster.SelectedValue.ToString());

                dt = Enlist.GetDataCommodity(intClusterid);
                ddlCommodity.DataTextField = "strComGroupName";
                ddlCommodity.DataValueField = "intComGroup";
                ddlCommodity.DataSource = dt;
                ddlCommodity.DataBind();

                if (intClusterid != 0)
                {
                    intCommodityId = int.Parse(ddlCommodity.SelectedValue.ToString());

                    dt = Enlist.GetDataCategory(intCommodityId);
                    ddlCategory.DataTextField = "strCategory";
                    ddlCategory.DataValueField = "intCategory";
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataBind();
                }

                dt = Enlist.GetDataUoM();
                ddlUoM.DataTextField = "strUoM";
                ddlUoM.DataValueField = "intUoM";
                ddlUoM.DataSource = dt;
                ddlUoM.DataBind();

            }
            
        }


        [WebMethod]
        public static List<string> GetAutoCompleteDataemp(string strSearchKeyemp)
        {
            CSM objAutoSearch_BLL = new CSM();

            List<string> result = new List<string>();
            //Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            result = objAutoSearch_BLL.AutoSearchItemData(strSearchKeyemp);
            return result;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            strName = txtItemName.Text;
            strDescription = txtDescription.Text;
            strPartNo = txtPartNo.Text;
            strBrand = txtstrBrand.Text;
            strUoM = ddlUoM.SelectedItem.ToString();
            int intCategoryId;

            int intClusterId = int.Parse(ddlCluster.SelectedValue.ToString());
            int intCommodityId = int.Parse(ddlCommodity.SelectedValue.ToString());
            if (intCommodityId == 0)
            { intCategoryId = 0; }
            else  { intCategoryId = int.Parse(ddlCategory.SelectedValue.ToString()); }

            intLastActionBy = int.Parse(Session[SessionParams.USER_ID].ToString());
            string UoM;
            string Ittem =txtItemName.Text;
            //string Cluster = ddlCluster.SelectedItem.ToString();
            //string Commodity = ddlCommodity.SelectedItem.ToString();
            //string Category = ddlCategory.SelectedItem.ToString();
            if (ddlUoM.SelectedItem.ToString() == null || ddlUoM.SelectedItem.ToString() == "") 
            {UoM="";}
            else{UoM=ddlUoM.SelectedItem.ToString();}

            if (Ittem == null || Ittem == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Item Base Name.');", true);}
            else if (ddlCluster.SelectedItem.ToString() == null || ddlCluster.SelectedItem.ToString() == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Cluster.');", true); }
            else if (ddlCommodity.SelectedItem.ToString() == null || ddlCommodity.SelectedItem.ToString() == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Commodity.');", true); }
            else if (ddlCategory.SelectedItem.ToString() == null || ddlCategory.SelectedItem.ToString() == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Category.');", true); }
            else if (UoM == null || UoM == "") {ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select UoM.');", true);}
            else
            {
               // Enlist.INSERTMasterItemlist(strName, strDescription, strPartNo, strBrand, intClusterId, intCommodityId, intCategoryId, strUoM,enroll);

                Enlist.INSERTMasterItemlistCreate(strName, strDescription, strPartNo, strBrand, intClusterId, intCommodityId, intCategoryId, strUoM, enroll);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item Added Successfully');", true);
            }                   
        }


        protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            intClusterid = int.Parse(ddlCluster.SelectedValue.ToString());

            dt = Enlist.GetDataCommodity(intClusterid);
            ddlCommodity.DataTextField = "strComGroupName";
            ddlCommodity.DataValueField = "intComGroup";
            ddlCommodity.DataSource = dt;
            ddlCommodity.DataBind();

            intCommodityId = int.Parse(ddlCommodity.SelectedValue.ToString());

            dt = Enlist.GetDataCategory(intCommodityId);
            ddlCategory.DataTextField = "strCategory";
            ddlCategory.DataValueField = "intCategory";
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();

        }


        protected void ddlCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            intCommodityId = int.Parse(ddlCommodity.SelectedValue.ToString());

            if (intCommodityId != 0)
            {
                dt = Enlist.GetDataCategory(intCommodityId);
                ddlCategory.DataTextField = "strCategory";
                ddlCategory.DataValueField = "intCategory";
                ddlCategory.DataSource = dt;
                ddlCategory.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch;
            strSearch = txtSearch.Text;

            dt = Enlist.GetItemAutoSearch(strSearch);
            ListBox1.DataSource = dt;
            ListBox1.DataTextField = "strItemMasterName";
            ListBox1.DataValueField = "intItemMasterID";
            ListBox1.DataBind();
                
        }

        protected void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
               
    }
}
