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
    public partial class IndentStatusDetalis : System.Web.UI.Page
    {
        Indents_BLL objIndent = new Indents_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh, indentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    string dteIndent = Request.QueryString["dteIndent"].ToString();
                    string dteDue = Request.QueryString["dteDue"].ToString();
                    string indentID = Request.QueryString["indentID"].ToString();
                    string dept = Request.QueryString["dept"].ToString();
                    string whname = Request.QueryString["whname"].ToString();
                    lblWH.Text = whname;
                    lblIndent.Text = indentID;
                    lbldteDue.Text = dteDue;
                    lbldteIndent.Text = dteIndent;
                    lblType.Text = dept;


                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objIndent.DataView(14, "", 0, int.Parse(indentID), DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblUnitName.Text = dt.Rows[0]["strUnit"].ToString();
                        lblIndentBY.Text = dt.Rows[0]["indentBy"].ToString();
                        lblApproveBy.Text = dt.Rows[0]["ApproveBY"].ToString();
                        string unit = dt.Rows[0]["intUnit"].ToString();
                        int job = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                        if (job == 28)
                        {
                              imgUnit.ImageUrl = "/Content/images/img/" + "ag" + ".png".ToString();
                        }
                        else { imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString(); }

                         
                    }
                    dgvIndentsDetalis.DataSource = dt;
                    dgvIndentsDetalis.DataBind();
                }
                catch { }
               
               


            }
            else
            { }
        }
    }
}