using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RmtAttachDelete : System.Web.UI.Page
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string message; string path;
        DateTime dtFromDate, dtToDate;
        int employeeenrol,typeid ,autoid;
        DeliverySupport bll = new DeliverySupport();
        DataTable objDT = new DataTable();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RmtAttachDelete";
        string stop = "stopping SAD\\Order\\RmtAttachDelete";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();

                txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";
                ////---------xml----------
                //try { File.Delete(filePathForXML); }
                //catch { }
                ////-----**----------//


            }
            //    //else
            //    //{
            //    if (hdnField.Value != "0")
            //    {
            //        btnSave_Click();
            //    }
            //}
        }

        [WebMethod]
        public static List<string> getemplontadasupervisor(string strSearchKey)
        {
            DeliverySupport bll = new DeliverySupport();

            List<string> result = new List<string>();
            result = bll.getemployeebaseTADAAttachment(
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), strSearchKey);
            return result;
        }

        private void showData()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAInformationUpdate TADA Information Update", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                 dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDate.Text).Value;
                 dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDelDate.Text).Value;
                int deptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                objDT = bll.getAttachmentDelete(deptid);
                string allow = objDT.Rows[0][1].ToString();
                typeid = 1;
                autoid = 0;
                if (rdbUserOption.SelectedItem.Text == "Own")
                {
                    int intTSOEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    objDT = bll.getAttachmentInfo( intTSOEnroll,dtFromDate, dtToDate, typeid,autoid);

                    if (objDT.Rows.Count > 0)
                    {

                        GridView1.DataSource = objDT;
                        GridView1.DataBind();

                    }
                    else
                    {


                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                    }
                }
                else if (rdbUserOption.SelectedItem.Text == "Other")
                {
                //

                    if (allow=="True")
                    {

                        string strSearchKey = txtEmployeeSearch.Text;
                        arrayKey = strSearchKey.Split(delimiterChars);
                        string code = arrayKey[1].ToString();

                        string TSOName = strSearchKey;
                        employeeenrol = int.Parse(code);


                        objDT = bll.getAttachmentInfo(employeeenrol, dtFromDate, dtToDate,typeid,autoid);

                        if (objDT.Rows.Count > 0)
                        {

                            GridView1.DataSource = objDT;
                            GridView1.DataBind();

                        }
                        else
                        {


                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                        }
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! You are not permitted');", true); }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();



        }
   


        protected void btnShowAttachment_Click(object sender, EventArgs e)
        {
           
            showData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Download", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RmtAttchForNoEmialEmployee Download ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                //int autoid = (sender as LinkButton).CommandArgument;
                 dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDate.Text).Value;
                 dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDelDate.Text).Value;
                typeid = 2;
                int autoid =Convert.ToInt32( (sender as LinkButton).CommandArgument);
                objDT = bll.getAttachmentInfo(employeeenrol, dtFromDate, dtToDate, typeid, autoid);
                message = objDT.Rows[0][4].ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", message, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                showData();
            }
            catch { }
          

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void rdbUserOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}