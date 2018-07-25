using BLL.Accounts.Advice;
using Purchase_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class BankStatementUpload : BasePage
    {
        DataTable dt; AdviceBLL bll = new AdviceBLL(); Media obj = new Media();
        int intUnitID, intEnroll, intAccountID;
        DateTime dteStartDateTime, dteEndDateTime;
        string dteDate, strParticulars, strInstrumentNo;
        decimal monDebit, monCredit, monBalance;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = obj.GetUnit(intEnroll);
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();

                    LoadAccountNo();
                    LoadLastCollectDate();
                }
                catch
                { }
            }
        }

        

        private void LoadAccountNo()
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = new DataTable();
                dt = bll.GetAccountList(intUnitID);
                ddlAccountNo.DataSource = dt;
                ddlAccountNo.DataTextField = "strAccountNo";
                ddlAccountNo.DataValueField = "intAccountID";
                ddlAccountNo.DataBind();

                txtAGAccount.Text = ddlAccountNo.SelectedValue.ToString();
            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadAccountNo();
                LoadLastCollectDate();
                gvExcelFile.DataSource = "";
                gvExcelFile.DataBind();
            }
            catch { }
        }
        protected void ddlAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLastCollectDate();
            txtAGAccount.Text = ddlAccountNo.SelectedValue.ToString();

            gvExcelFile.DataSource = "";
            gvExcelFile.DataBind();
        }

        private void LoadLastCollectDate()
        {
            try
            {
                intAccountID = int.Parse(ddlAccountNo.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetLastCollectDate(intAccountID);
                if (dt.Rows.Count > 0)
                {
                    txtLastCollect.Text = dt.Rows[0]["dteDate"].ToString();
                }
                else
                {
                    txtLastCollect.Text = "N/A";
                }
            }
            catch { }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            gvExcelFile.DataSource = "";
            gvExcelFile.DataBind();
            DeleteData();
            uploadfile();

            //gvExcelFile.DataSource = "";
            //gvExcelFile.DataBind();
        }

        private void DeleteData()
        {
            try
            {
                intEnroll = int.Parse(hdnEnroll.Value);
                bll.DeleteStatement(intEnroll);
            }
            catch { }
        }

        private void uploadfile()
        {
            //try
            {
                string ConStr = "";

                string strDocUploadPath = Path.GetFileName(FileUpload1.FileName);
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                string path = Server.MapPath("~/Accounts/Advice/Data/" + FileUpload1.FileName);
                if (FileUpload1.HasFile.ToString() != null)
                {
                    FileUpload1.SaveAs(path);
                    if (ext.Trim() == ".xls")
                    {
                        ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (ext.Trim() == ".xlsx")
                    {
                        ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    string query = "SELECT * FROM [StatementFomat$]";
                    OleDbConnection conn = new OleDbConnection(ConStr);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    gvExcelFile.DataSource = ds.Tables[0];
                    gvExcelFile.DataBind();
                    conn.Close();

                    DataTable dtTable = new DataTable();
                    dtTable = (DataTable)ds.Tables[0];
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intEnroll = int.Parse(hdnEnroll.Value.ToString());
                    intAccountID = int.Parse(ddlAccountNo.SelectedValue.ToString());

                    #region ********* Excel Data Get *************
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {

                        dteDate = dtTable.Rows[i][0].ToString();
                        strParticulars = dtTable.Rows[i][1].ToString();
                        strInstrumentNo = dtTable.Rows[i][2].ToString();
                        try { monDebit = decimal.Parse(dtTable.Rows[i][3].ToString()); } catch { monDebit = 0; }
                        try { monCredit = decimal.Parse(dtTable.Rows[i][4].ToString()); } catch { monCredit = 0; }
                        try { monBalance = decimal.Parse(dtTable.Rows[i][5].ToString()); } catch { monBalance = 0; }

                        bll.InsertTempData(intAccountID, dteDate, strParticulars, strInstrumentNo, monDebit, monCredit, monBalance, intEnroll);
                    }

                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Report Inserted.');", true);

                    #endregion **************** End Excel data get **************
                }
                File.Delete(path);
            }
            //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Error in statement.');", true); }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intEnroll = int.Parse(hdnEnroll.Value);
                intAccountID = int.Parse(ddlAccountNo.SelectedValue.ToString());

                dt = new DataTable();
                dt = bll.InsertStatement(intAccountID, intEnroll);
                string strMsg = dt.Rows[0]["strMsg"].ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ strMsg +"');", true);
                gvExcelFile.DataSource = "";
                gvExcelFile.DataBind();
            }
            catch { }
        }
    }
}