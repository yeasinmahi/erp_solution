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
using BLL.Accounts.Voucher;
using BLL.Accounts.SubLedger;
using System.Web.Services;
using System.Web.Script.Services;
using BLL.Accounts.ChartOfAccount;
using BLL.Accounts.Banking;
using BLL.Accounts.Banking.Counter;
using DAL.Accounts.Banking.Counter;
using AkijFTPConnector;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.Banking.Counter
{
    public partial class ChqReceive : BasePage
    {
        protected double totAmount = 0;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\Counter\\ChqReceive";
        string stop = "stopping Accounts\\Banking\\Counter\\ChqReceive";
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCOAList(string prefixText, int count)
        {
            return BankContraChqBearerST.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();

            }
        }
        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {

            RdoTypeChange();
            GridView1.DataBind();
        }

        private void RdoTypeChange()
        {
            switch (rdoType.SelectedValue)
            {
                case "rd":
                    hdnGiven.Value = "false";
                    hdnPending.Value = "false";
                    hdnReady.Value = "true";
                    pnlDate.Visible = false;
                    break;
                case "pn":
                    hdnGiven.Value = "false";
                    hdnPending.Value = "true";
                    hdnReady.Value = "false";
                    pnlDate.Visible = false;
                    break;
                case "gv":
                    hdnGiven.Value = "true";
                    hdnPending.Value = "false";
                    hdnReady.Value = "false";
                    pnlDate.Visible = true;
                    break;
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            hdnFrm.Value = txtFrom.Text;
            hdnTo.Value = txtTo.Text;
            if (txtCode.Text.Trim() != "")
            {
                txtCOA.Text = "";
                hdnCus.Value = "";
            }

            GridView1.DataBind();
        }

        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Complete", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\Counter\\ChqReceive   Chq Complete ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                char[] ch = { '#' };
            string[] temp = ((Button)sender).CommandArgument.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            string err = "";

            if (hdnSid.Value != "")
            {
                BoothSign cd = new BoothSign();
                BoothSignTDS.TblBoothSignDataDataTable table = new BoothSignTDS.TblBoothSignDataDataTable();

                table = cd.GetDataById(hdnSid.Value);
                if (table.Rows.Count > 0)
                {
                    FTP f = new FTP();
                    f.FtpHost = "ftp.akij.net";
                    f.UserName = "ftp@akij.net";
                    f.Password = "ftp@123";
                    f.Port = "21";
                    f.Login();

                    string dir = "Booth/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
                    string fDir = "ChqDelivery_" + hdnSid.Value + ".png";

                    byte[] GifImgData = table[0].IsimgSignatureNull() ? null : table[0].imgSignature;

                    if (GifImgData != null)
                    {
                        //store byte array to memory stream
                        System.IO.MemoryStream mems = new System.IO.MemoryStream(GifImgData);


                        if (!f.ChangeDirectory("Booth"))
                        {
                            try { f.MakeDirectory("Booth"); }
                            catch { }
                            f.ChangeDirectory("Booth");
                        }


                        if (!f.ChangeDirectory(DateTime.Now.Year.ToString()))
                        {
                            try { f.MakeDirectory(DateTime.Now.Year.ToString()); }
                            catch { }
                            f.ChangeDirectory(DateTime.Now.Year.ToString());
                        }


                        if (!f.ChangeDirectory(DateTime.Now.Month.ToString()))
                        {
                            try { f.MakeDirectory(DateTime.Now.Month.ToString()); }
                            catch { }
                            f.ChangeDirectory(DateTime.Now.Month.ToString());
                        }

                        f.UploadFileToServerForWeb(mems, fDir);
                        mems.Close();

                        imgSig.ImageUrl = "~/Images/white.png";
                        ChqDelivery dd = new ChqDelivery();
                        dd.ChequeIssued(temp[1], temp[0], ddlBooth.SelectedValue, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), hdnSid.Value, (dir + "/" + fDir), ref err);
                    }
                    else
                    {
                        err = "No Signature found";
                    }
                }

                lblMsg.Text = err;
            }

            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Complete", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Complete", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnTakeSign_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Takesign", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\Counter\\ChqReceive   Takesign ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                char[] ch = { '#' };
            string[] temp = ((Button)sender).CommandArgument.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            ChqDelivery cd = new ChqDelivery();
            string bs = "", err = "";
            cd.TakeSign(temp[1], temp[0], ddlBooth.SelectedValue, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), ref bs, ref err);

            hdnVid.Value = temp[1];
            hdnSid.Value = bs;

            if (err == "")
            {
                lblMsg.Text = "";
            }
            else
            {
                lblMsg.Text = err;
            }
            ChqReceiveST.ReloadBoothsDataForSIgnature(ddlBooth.SelectedValue);
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Takesign", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Takesign", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        protected void btnCancelSign_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Cancelsign", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\Counter\\ChqReceive   Cancelsign ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] ch = { '#' };
            string[] temp = ((Button)sender).CommandArgument.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            if (hdnSid.Value != "")
            {
                BoothSign cd = new BoothSign();
                cd.CancelData(Session[SessionParams.USER_ID].ToString(), hdnSid.Value);
                hdnSid.Value = "";
                hdnVid.Value = "";
                lblMsg.Text = "";
            }
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Cancelsign", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Cancelsign", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void txtCOA_TextChanged(object sender, EventArgs e)
        {
            txtCode.Text = "";
            hdnCus.Value = txtCOA.Text.Trim();
            GridView1.DataBind();
        }

        protected void btnShowImage_Click(object sender, EventArgs e)
        {
            if (hdnSid.Value != "")
            {
                imgSig.ImageUrl = "SIgnBoothImgShow.ashx?id=" + hdnSid.Value;
                imgSig.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool isVisible = true;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string txtChqP = ((Label)e.Row.Cells[12].Controls[1]).Text;
                string txtChqI = ((Label)e.Row.Cells[11].Controls[1]).Text;

                if (txtChqP != "")//chq print
                {
                    isVisible = true;
                }

                if (txtChqI != "")//chq issued
                {
                    isVisible = false;
                }

                if (txtChqP == "" && txtChqI == "")
                {
                    isVisible = false;
                }

                if (hdnVid.Value.ToString() == e.Row.Cells[1].Text)
                {
                    if (isVisible)
                    {

                        ((Button)e.Row.Cells[14].Controls[1]).Enabled = false;
                        ((Button)e.Row.Cells[15].Controls[1]).Enabled = true;
                        ((Button)e.Row.Cells[13].Controls[1]).Enabled = true;

                    }
                    else
                    {

                        ((Button)e.Row.Cells[14].Controls[1]).Enabled = false;
                        ((Button)e.Row.Cells[15].Controls[1]).Enabled = true;
                        ((Button)e.Row.Cells[13].Controls[1]).Enabled = true;

                    }
                }
                else
                {
                    if (isVisible)
                    {
                        ((Button)e.Row.Cells[14].Controls[1]).Enabled = true;
                        ((Button)e.Row.Cells[15].Controls[1]).Enabled = false;
                        ((Button)e.Row.Cells[13].Controls[1]).Enabled = false;
                    }
                    else
                    {
                        ((Button)e.Row.Cells[14].Controls[1]).Enabled = false;
                        ((Button)e.Row.Cells[15].Controls[1]).Enabled = false;
                        ((Button)e.Row.Cells[13].Controls[1]).Enabled = false;
                    }
                }
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //bool isVisible = true;

            if (GridView1.Rows.Count == 1 && txtCode.Text.Trim() != "")
            {
                if (GridView1.Rows[0].RowType == DataControlRowType.DataRow)
                {

                    string txtChqP = ((Label)GridView1.Rows[0].Cells[12].Controls[1]).Text;
                    string txtChqI = ((Label)GridView1.Rows[0].Cells[11].Controls[1]).Text;

                    if (txtChqP != "")//chq print
                    {
                        rdoType.SelectedIndex = 0;
                    }

                    if (txtChqI != "")//chq issued
                    {
                        rdoType.SelectedIndex = 2;
                    }

                    if (txtChqP == "" && txtChqI == "")
                    {
                        rdoType.SelectedIndex = 1;
                    }
                }
            }

            RdoTypeChange();
        }

    }
}
