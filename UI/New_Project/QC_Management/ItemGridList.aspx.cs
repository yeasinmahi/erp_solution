using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using Purchase_BLL.Qc_Management;

namespace UI.QC_Management
{
    public partial class ItemGridList : BasePage
    {
        DataTable dtitemlist = new DataTable();
        DataTable dtUnitname = new DataTable();
        QcBllManagement Report = new QcBllManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                int enroll = int.Parse((Session[SessionParams.USER_ID].ToString()));
                dtUnitname = Report.getUnitname(enroll);
                string unitname = dtUnitname.Rows[0]["strUnit"].ToString();
                int intUnitID = int.Parse(dtUnitname.Rows[0]["intUnitID"].ToString());
                Session["intUnitID"] = intUnitID;

                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataSource = dtUnitname;
                ddlUnit.DataBind();

            }
        }

        protected void ddlcatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Categoryid= int.Parse(ddlcatagory.SelectedValue.ToString());
            int unitid = int.Parse(Session["intUnitID"].ToString());
            dtitemlist = Report.gridviewList(Categoryid, unitid);
            GridView1.DataSource = dtitemlist;
            GridView1.DataBind();
            

        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 itemid = int.Parse(searchKey[0].ToString());
                Session["itemid"] = itemid;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ItemAttributeAdd.aspx');", true);


            }
            catch { }


        }
    }
}