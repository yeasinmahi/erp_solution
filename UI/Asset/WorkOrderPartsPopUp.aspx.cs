using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using Purchase_BLL.Asset;

using System.Web.Services;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using UI.ClassFiles;
using System.Web.Script.Services;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class WorkOrderPartsPopUp :BasePage
    {
        AssetMaintenance objWorkorderParts = new AssetMaintenance();
        DataTable wt = new DataTable();

        int intItem; int ysnTecnichin; int intjobid;

        SeriLog log = new SeriLog();
        string location = "ASSET";
        string start = "starting ASSET\\WorkOrderPartsPopUp";
        string stop = "stopping ASSET\\WorkOrderPartsPopUp";
        string perform = "Performance on ASSET\\WorkOrderPartsPopUp";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);

            try
            {
                if (!IsPostBack)
                {
                    //btnSubService.Visible = false;
                    //txtServiceCost.Visible = false;
                    //lblSubServiceCost.Visible = false;
                    //txtService.Visible = false;
                    //lblSubService.Visible = false;
                    //dgvSubService.Visible = false;


                    //btnSubService.Visible = true;
                    //txtServiceCost.Visible = true;
                    //lblSubServiceCost.Visible = true;
                    //txtService.Visible = true;
                    //lblSubService.Visible = true;
                    //dgvSubService.Visible = true;


                    hdnField.Value = "0";
                    TxtTechnichinSearch.Attributes.Add("onkeyUp", "SearchTextVendor();");
                    SearchToolsBox.Attributes.Add("onkeyUp", "SearchTextTools();");
                    wt = new DataTable();
                    TxtTCost.Visible = false;
                    TxtTCost.Visible = false;
                    TxtLabor.Visible = false;
                    pnlUpperControl.DataBind();
                    Int32 Mnumber = Convert.ToInt32(Session["intID"].ToString());
                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                    wt = objWorkorderParts.SubServiceView(Mnumber);
                    dgvSubService.DataSource = wt;
                    dgvSubService.DataBind();
                    try
                    {
                        decimal total1 = wt.AsEnumerable().Sum(row => row.Field<decimal>("monService"));
                        dgvSubService.FooterRow.Cells[1].Text = "Total".ToString();
                        dgvSubService.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                        dgvSubService.FooterRow.Cells[2].Text = total1.ToString("N2");
                    }
                    catch { }


                    if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
                    {
                        hdntp.Value = "1";

                    }
                    else
                    {
                        hdntp.Value = "0";

                    } 
                    showdata(); 
                }
                else
                {
                    if (hdnField.Value != "0")
                    {
                        btndocSave_Click();
                        
                    }
                }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void showdata()
        {
            var fd = log.GetFlogDetail(start, location, "showdata", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "showdata", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int Mnumber =int.Parse(Session["intID"].ToString());
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                wt = new DataTable();

                intItem = 2;
                if (intItem == 2)
                {
                    wt = objWorkorderParts.WOsparePartsView(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvParts.DataSource = wt;
                    dgvParts.DataBind();


                }
                intItem = 3;
                if (intItem == 3)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.WOLaborcostShow(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvLabor.DataSource = wt;
                    dgvLabor.DataBind();
                }
                intItem = 5;
                if (intItem == 5)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.WOdocview(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvDoc.DataSource = wt;
                    dgvDoc.DataBind();
                }
                intItem = 18;
                if (intItem == 18)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.Sareparts(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvwoParts.DataSource = wt;
                    dgvwoParts.DataBind();
                }
                intItem = 19;
                if (intItem == 19)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.labor(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvWolabor.DataSource = wt;
                    dgvWolabor.DataBind();
                }
                intItem = 20;
                if (intItem == 20)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.documnetview(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvWodoc.DataSource = wt;
                    dgvWodoc.DataBind();
                }
                intItem = 48;
                if (intItem == 48)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.MaintenanceToolsView(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvWOTools.DataSource = wt;
                    dgvWOTools.DataBind();

                }
                intItem = 50;
                if (intItem == 50)
                {
                    wt = new DataTable();
                    wt = objWorkorderParts.PMToolsWOView(intItem, Mnumber, intenroll, intjobid, intdept);
                    dgvPMTools.DataSource = wt;
                    dgvPMTools.DataBind();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "ShowData", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "ShowData", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }       

        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {
            Int32 WHID = Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.AutoSearchWHIDParts(WHID.ToString(), prefixText);
        }


        [WebMethod]
        public static List<string> GetAutoCompleteDataemp(string strSearchKeyemp)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
            {
                List<string> result2 = new List<string>();
                result2 = objAutoSearch_BLL.AutoSearchCorporateEmployee(strSearchKeyemp);
                return result2;
            }
            else
            {
                
                List<string> result = new List<string>();
                result = objAutoSearch_BLL.AutoSearchEmployee(strSearchKeyemp, intjobid);
                return result;
            }

        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataVendor(string strSearchKeyVendor)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
            {
                List<string> result2 = new List<string>();
                result2 = objAutoSearch_BLL.AutoSearchCorporateVendor(strSearchKeyVendor);
                return result2;
            }
            else
            {

                List<string> result = new List<string>();
                result = objAutoSearch_BLL.AutoSearchFactoryVendor(strSearchKeyVendor, intjobid);
                return result;
            }

        }

        [WebMethod]
        public static List<string>GetAutoCompleteDataTools(string strSearchTextTools)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

           
                List<string> resultTools = new List<string>();
                resultTools = objAutoSearch_BLL.AutoSearchAssetrToolsAndEquipment(strSearchTextTools);
                return resultTools;
    
        }



        private void GetSearchResult(string empCode)
        {
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    string strEmpCode = empCode;

                    wt = new DataTable();
                    //dt = objhr.GetEnrollByEmpCode(strEmpCode);

                    int intEnroll = int.Parse(wt.Rows[0]["intEmployeeID"].ToString());
                    HttpContext.Current.Session["intEnroll"] = intEnroll.ToString();


                }
            }
            catch { }
        }


        private void btndocSave_Click()
        {
            var fd = log.GetFlogDetail(start, location, "btndocSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btndocSave_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int Reffno =int.Parse(Session["intID"].ToString());
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                string docdesc = TxtDocDescription.Text.ToString();
                //******** Document Uplaod**********************//
                string dfile = Reffno + "_" + Path.GetFileName(DUpload.PostedFile.FileName);
                decimal length = dfile.Length;
                string path = "/test/" + dfile;


                DUpload.PostedFile.SaveAs(Server.MapPath("~/Asset/Uploads/") + dfile);
                FileUploadFTP(Server.MapPath("~/Asset/Uploads/"), dfile, "ftp://ftp.akij.net/test/", "erp@akij.net", "erp123");
                File.Delete(Server.MapPath("~/Asset/Uploads/") + dfile);
                objWorkorderParts.WODocUpload(Reffno, path, docdesc, intenroll, intjobid, intdept);
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Document Upload');", true);
                showdata();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btndocSave_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btndocSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

            FileInfo fileInfo = new FileInfo(localPath + fileName);
            FileStream fileStream = fileInfo.OpenRead();

            int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];

            Stream uploadStream = requestFTPUploader.GetRequestStream();
            int contentLength = fileStream.Read(buffer, 0, bufferLength);

            while (contentLength != 0)
            {
                uploadStream.Write(buffer, 0, contentLength);
                contentLength = fileStream.Read(buffer, 0, bufferLength);
            }

            uploadStream.Close();
            fileStream.Close();

            requestFTPUploader = null;

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "BtnSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "BtnSave_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int Mnumber = int.Parse(Session["intID"].ToString());
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                intItem = 26;
                if (intItem == 26)
                {
                    objWorkorderParts.WPMSDataInsert(intItem, Mnumber, intenroll, intjobid, intdept);

                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);

                showdata();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btndocSave_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btndocSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            
            tracker.Stop();
             
        }

        protected void BtnLabor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TxtTechnichinSearch.Text))
                {
                    
                    string strSearchKey = TxtTechnichinSearch.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    HdfTechnicinCode.Value = searchKey[1];
                    Int32 technichin = Int32.Parse(HdfTechnicinCode.Value.ToString());


                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    Int32 Reffno = Convert.ToInt32(Session["intID"].ToString());
                    if (hdnR.Value =="0")
                    {
                        ysnTecnichin = Int32.Parse(0.ToString());
                    }
                    if (hdnR.Value =="1")
                    {

                        ysnTecnichin = Int32.Parse(1.ToString());
                    }
                 
                    string description = TxtDescription.Text.ToString();
                  
                    decimal hour = decimal.Parse(TxtHour.Text.ToString());

                    objWorkorderParts.WOLaborCost(Reffno, technichin, description, hour, intenroll, intjobid, intdept, ysnTecnichin);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);
                    showdata();
                }
            }
            catch { }
        }

        protected void BtnParts_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "BtnParts_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "BtnParts_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (!String.IsNullOrEmpty(txtPartsSearch.Text))
                {
                    string strSearchKey = txtPartsSearch.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    hdfEmpCode.Value = searchKey[1];
                    Int32 parts = Int32.Parse(hdfEmpCode.Value.ToString());



                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                    Int32 intwh = Int32.Parse(DdlWareHouse.SelectedValue.ToString());
                    Int32 Reffno = Convert.ToInt32(Session["intID"].ToString());


                    Decimal pqty = Decimal.Parse(TxtPqty.Text.ToString());
                    string remarks = TxtRemarks.Text.ToString();
                    Int32 Mnumber = Convert.ToInt32(Session["intID"].ToString());
                    wt = new DataTable();
                    intjobid = Int32.Parse(hdfEmpCode.Value.ToString());

                    intItem = 55;
                    wt = objWorkorderParts.CheckPartsItemNumber(intItem, Mnumber, intenroll, intjobid, intdept);
                    if (wt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Item allready inserted please store requesition or delete then try again and set actual quantity');", true);
                    }
                    else
                    {
                        intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                        objWorkorderParts.WOSpareParts(Reffno, parts, pqty, intenroll, intjobid, intdept, intwh, remarks);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);

                    }



                    showdata();


                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "BtnParts_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "BtnParts_Click", null);
            Flogger.WriteDiagnostic(fd);

            tracker.Stop();


        }

        protected void dgvwoParts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvwoParts_RowDeleting", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "dgvwoParts_RowDeleting", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intIdParts =int.Parse(((Label)dgvwoParts.Rows[e.RowIndex].FindControl("Label21")).Text.ToString());

                objWorkorderParts.dgvPartsdelete(intIdParts, intjobid, intdept);
                showdata();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "dgvwoParts_RowDeleting", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "dgvwoParts_RowDeleting", null);
            Flogger.WriteDiagnostic(fd);

            tracker.Stop();
        }

        protected void dgvWolabor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            Int32 intIdLabor = Convert.ToInt32(((Label)dgvWolabor.Rows[e.RowIndex].FindControl("Label20")).Text.ToString());
            objWorkorderParts.dgvLabordelete(intIdLabor, intjobid, intdept);
            showdata();
        }


        protected void DdlWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = DdlWareHouse.SelectedValue.ToString();

                Session["WareID"] = hdnwh.Value;
            }
            catch { }
        }

        protected void DdlWareHouse_DataBound(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = DdlWareHouse.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
        }

        protected void BtnTools_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "BtnTools_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "BtnTools_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (!String.IsNullOrEmpty(SearchToolsBox.Text))
                {
                    string strSearchKey = SearchToolsBox.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    HiddenToolsCode.Value = searchKey[1];
                    string ToolsID = HiddenToolsCode.Value.ToString();


                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int Reffno =int.Parse(Session["intID"].ToString()); 
                    string description = TxtTollsDescription.Text.ToString(); 
                    Decimal hour =Decimal.Parse(txtToolsHour.Text.ToString()); 
                    objWorkorderParts.WOTollsCost(Reffno, ToolsID, description, hour, intenroll, intjobid, intdept);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);
                    showdata();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "BtnTools_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "BtnTools_Click", null);
            Flogger.WriteDiagnostic(fd);

            tracker.Stop();
        }

        protected void dgvWOTools_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvWOTools_RowDeleting", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "dgvWOTools_RowDeleting", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                int intIdParts =int.Parse(((Label)dgvWOTools.Rows[e.RowIndex].FindControl("Label22")).Text.ToString());

                objWorkorderParts.dgvToolsdelete(intIdParts, intjobid, intdept);
                showdata();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "dgvWOTools_RowDeleting", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "dgvWOTools_RowDeleting", null);
            Flogger.WriteDiagnostic(fd);

            tracker.Stop();
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
           

            Response.Redirect("MaintenanceWorkOrderPopUp.aspx", true);

        }

        protected void Perform_CheckedChanged(object sender, EventArgs e)
        {
           

            if (RadioEmployee.Checked == true)
            {
                hdnR.Value = 0.ToString();
               
                TxtTechnichinSearch.Text = "";
                TxtTechnichinSearch.Attributes.Add("onkeyUp", "SearchTextemp();");
            }

            if (RadioVendor.Checked == true)
            {
                hdnR.Value = 1.ToString(); ;
                TxtTechnichinSearch.Text = "";
                //TxtSearchVendor.Attributes.Add("onkeyUp", "SearchTextVendor();");
                TxtTechnichinSearch.Attributes.Add("onkeyUp", "SearchTextVendor();");
            }
        }

        protected void btnSubService_Click(object sender, EventArgs e)
        {
            try
            {
                string service = txtService.Text.ToString();
                decimal cost = decimal.Parse(txtServiceCost.Text.ToString());
                int Reffno = int.Parse(Session["intID"].ToString());
                if (txtService.Text.Length>1 && cost>0)
                {
                    wt = objWorkorderParts.CheckSubServiceView(Reffno, service);
                    if (wt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Service Name Already Added');", true);
                    }
                    else
                    {
                        objWorkorderParts.SubServiceCost(Reffno, service, cost);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);

                        wt = objWorkorderParts.SubServiceView(Reffno);
                        dgvSubService.DataSource = wt;
                        dgvSubService.DataBind();
                        try
                        {
                            decimal total1 = wt.AsEnumerable().Sum(row => row.Field<decimal>("monService"));
                            dgvSubService.FooterRow.Cells[1].Text = "Total".ToString();
                            dgvSubService.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                            dgvSubService.FooterRow.Cells[2].Text = total1.ToString("N2");
                        }
                        catch { }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Service Name and  Service Cost greater than 0');", true);
                }
               
                

            }
            catch { }
        }

        protected void dgvSubService_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int intId = int.Parse(((Label)dgvSubService.Rows[e.RowIndex].FindControl("lblServiceId")).Text.ToString());
                int Reffno = int.Parse(Session["intID"].ToString());
                objWorkorderParts.dgvServiceDelete(intId);

                wt = objWorkorderParts.SubServiceView(Reffno);
                dgvSubService.DataSource = wt;
                dgvSubService.DataBind();
                try
                {
                    decimal total1 = wt.AsEnumerable().Sum(row => row.Field<decimal>("monService"));
                    dgvSubService.FooterRow.Cells[1].Text = "Total".ToString();
                    dgvSubService.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    dgvSubService.FooterRow.Cells[2].Text = total1.ToString("N2");
                }
                catch { }

            }
            catch { }
           
        }
    }
    }
