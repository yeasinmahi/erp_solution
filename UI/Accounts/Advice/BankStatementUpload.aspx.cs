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
        DataTable dt; Media bll = new Media();
        int intCustID, intProgramID, intDuration, intUnitID, intEnroll, intProgramType;
        DateTime dteStartDateTime, dteEndDateTime;



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
                    dt = bll.GetUnit(intEnroll);
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();

                    dt = new DataTable();
                    dt = bll.GetProgramType();
                    ddlProgramType.DataSource = dt;
                    ddlProgramType.DataTextField = "strProgramType";
                    ddlProgramType.DataValueField = "intID";
                    ddlProgramType.DataBind();

                    intProgramType = int.Parse(ddlProgramType.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetSupplier(intProgramType);
                    ddlSupplier.DataSource = dt;
                    ddlSupplier.DataTextField = "strProgramCustName";
                    ddlSupplier.DataValueField = "intID";
                    ddlSupplier.DataBind();
                }
                catch
                { }
            }
        }

        protected void ddlProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intProgramType = int.Parse(ddlProgramType.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetSupplier(intProgramType);
                ddlSupplier.DataSource = dt;
                ddlSupplier.DataTextField = "strProgramCustName";
                ddlSupplier.DataValueField = "intID";
                ddlSupplier.DataBind();
            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            uploadfile();
        }

        private void uploadfile()
        {
            string ConStr = "";

            string strDocUploadPath = Path.GetFileName(FileUpload1.FileName);
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            string path = Server.MapPath("~/MedialManagement/Data/" + FileUpload1.FileName);
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
                string query = "SELECT * FROM [Sheet1$]";
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
                intCustID = int.Parse(ddlSupplier.SelectedValue.ToString());
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                #region ********* Excel Data Get *************
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {

                    intProgramID = int.Parse(dtTable.Rows[i][0].ToString());
                    dteStartDateTime = DateTime.Parse(dtTable.Rows[i][1].ToString());
                    dteEndDateTime = DateTime.Parse(dtTable.Rows[i][2].ToString());
                    intDuration = int.Parse(dtTable.Rows[i][3].ToString());
                    bll.InsertRyansReport(intCustID, intProgramID, dteStartDateTime, dteEndDateTime, intDuration, intUnitID);
                }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Report Inserted.');", true);

                #endregion **************** End Excel data get **************
            }
            File.Delete(path);
        }
        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}