using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using XPSParser;
using System.Data;
using BLL.Accounts.Banking;
using System.Web.UI.HtmlControls;
using System.Text;
using UI.ClassFiles;

namespace HR.Other
{
    public partial class JbXPS : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlMarque.DataBind();
                btnSubmit.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnSubmit).ToString());
                btnParse.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnParse).ToString());

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isSuccess = true;
            string acc = "";
            int? accId = 0;
            decimal amount = 0;
            BankStatement st = new BankStatement();

            if (GridView1.Rows.Count > 0)
            {

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (acc != GridView1.Rows[i].Cells[6].Text)
                        {
                            acc = GridView1.Rows[i].Cells[6].Text;
                            accId = st.GetAccountIdByKey(acc);
                        }


                        if (accId != null)
                        {
                            isSuccess = st.InsertStatementData(accId.Value
                                , CommonClass.GetDateAtSQLDateFormat(((System.Web.UI.WebControls.Label)GridView1.Rows[i].Cells[0].Controls[1]).Text)
                                , GridView1.Rows[i].Cells[1].Text
                                , GridView1.Rows[i].Cells[2].Text
                                , decimal.Parse(GridView1.Rows[i].Cells[3].Text)
                                , decimal.Parse(GridView1.Rows[i].Cells[4].Text)
                                , decimal.Parse(GridView1.Rows[i].Cells[5].Text));

                            if (!isSuccess) break;
                        }
                    }
                }
            }

            if (isSuccess) lblStat.Text = "Successfully Uploaded";
            else lblStat.Text = "Error In Upload";
            hdnPath.Value = "";
            GridView1.DataBind();
        }

        protected void btnParse_Click(object sender, EventArgs e)
        {
            if (fulJBXPS.FileName.ToLower().Contains(".xps"))
            {
                HttpPostedFile htp = fulJBXPS.PostedFile;
                int len = htp.ContentLength;
                byte[] myData = new byte[len];
                htp.InputStream.Read(myData, 0, len);

                string path = Server.MapPath("") + "/Data/" + Session.SessionID + fulJBXPS.FileName;
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }


                    FileStream newFile = new FileStream(path, FileMode.Create);
                    newFile.Write(myData, 0, myData.Length);
                    newFile.Close();

                }
                catch { }

                hdnPath.Value = path;
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                lblStat.Text = "Data Parsing Completed";
                btnSubmit.Visible = true;
                btnParse.Visible = false;
            }
            else
            {
                btnSubmit.Visible = false;
                btnParse.Visible = true;
            }
        }
    }
}