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
    public partial class PoRegisterReport :BasePage
    {
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        DataTable dt = new DataTable();
        int intWH, type, enroll;
        int intID=0;
        int intNewType;
        DateTime fDate, tDate;
        //int indent = 0, po = 0, mrr = 0;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            intWH = int.Parse(ddlWH.SelectedValue);
            fDate = DateTime.Parse(txtDteFrom.Text.ToString());
            tDate = DateTime.Parse(txtdteTo.Text.ToString());
            type = int.Parse(ddlType.SelectedValue);
            dept = ddlDept.SelectedItem.ToString();
            
            if (txtIndent.Text != "")
            {
                intNewType = 1;
                intID = Convert.ToInt32(txtIndent.Text);
            }
            else if(txtPO.Text != "")
            {
                intNewType = 2;
                intID = int.Parse(txtPO.Text);
            }
            else if(txtMrr.Text != "")
            {
                intNewType = 3;
                intID = int.Parse(txtMrr.Text);
            }
            dt = objPo.PoRegisterDataList(fDate, tDate, dept, 0, intNewType, intID, 1);
            dgvStatement.DataSource = dt;
            dgvStatement.DataBind();
        }

       

        string dept;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objPo.GetPoData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
            }
            else { }

        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStatement.DataSource = "";
                dgvStatement.DataBind();
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                fDate = DateTime.Parse(txtDteFrom.Text.ToString());
                tDate = DateTime.Parse(txtdteTo.Text.ToString());
                type = int.Parse(ddlType.SelectedValue);
                dept = ddlDept.SelectedItem.ToString();

                if(type==4 || type==5)
                {
                    dt = objPo.PoRegisterDataList(fDate, tDate, dept, intWH, 1, null, intNewType);
                }
                else
                {
                    dt = objPo.PoRegisterDataList(fDate, tDate, dept, intWH, type, null, null);
                }
              
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();

            }
            catch { }
        }
    }
}