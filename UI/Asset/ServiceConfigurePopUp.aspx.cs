using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Purchase_BLL.Asset;
using System.Web.Services;
using System.IO;
using System.Net;
using UI.ClassFiles;
using System.Web.Script.Services;


namespace UI.Asset
{
    public partial class ServiceConfigurePopUp :BasePage
    {

        AssetMaintenance objPMSpareParts = new AssetMaintenance();
        DataTable dt = new DataTable();
        DataTable service = new DataTable();
  
        DataTable taskshow = new DataTable();
        DataTable spareparts = new DataTable();
        DataTable labor = new DataTable();
        DataTable docview = new DataTable();
        DataTable IssueDate = new DataTable();
        DataTable preventive = new DataTable();
        DataTable repair = new DataTable();
        DataTable assetcode = new DataTable();
        DataTable warehouse = new DataTable();
        DataTable PMTools = new DataTable();

        int intPart;
        int intItem;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnField.Value = "0";

               
                TxtTechnichinSearch.Attributes.Add("onkeyUp", "SearchTextemp();");
                SearchToolsBox.Attributes.Add("onkeyUp", "SearchTextTools();");
               
                TxtTCost.Visible = false;
                TxtTCost.Visible = false;
                TxtLabor.Visible = false;
                pnlUpperControl.DataBind();
                 Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                 Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                 if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
                 {
                     hdntp.Value = "1";
                     //Int32 type = int.Parse("1".ToString());
                     //warehouse = objWorkorderParts.warehousename(enroll, type);
                     //DdlWareHouse.DataSource = warehouse;
                     //DdlWareHouse.DataTextField = "WH";
                     //DdlWareHouse.DataValueField = "intWHID";
                     //DdlWareHouse.DataBind();
                 }
                 else
                 {
                     hdntp.Value = "0";
                     //Int32 type = int.Parse("0".ToString());
                     //warehouse = objWorkorderParts.warehousename(enroll, type);
                     //DdlWareHouse.DataSource = warehouse;
                     //DdlWareHouse.DataTextField = "WH";
                     //DdlWareHouse.DataValueField = "intWHID";
                     //DdlWareHouse.DataBind();
                 }  
            }
            else
            {
                if (hdnField.Value != "0")
                {
                    btndocSave_Click();
                    //lbldoc.Text = message;
                }
            }

            showdata();
        }

        private void showdata()
        {
            Int32 Mnumber = Convert.ToInt32(Session["intID"].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


            intItem = 15;
            if (intItem == 15)
            {
                spareparts = objPMSpareParts.PMSsparePartsView(intItem, Mnumber, intenroll, intjobid, intdept);
                GridViewParts.DataSource = spareparts;
                GridViewParts.DataBind();
            }

            intItem = 16;
            if (intItem == 16)
            {
                labor = objPMSpareParts.PMSLaborcostShow(intItem, Mnumber, intenroll, intjobid, intdept);
                GridViewLabor.DataSource = labor;
                GridViewLabor.DataBind();
            }
            intItem = 17;
            if (intItem == 17)
            {
                docview = objPMSpareParts.PMSdocview(intItem, Mnumber, intenroll, intjobid, intdept);
                GridViewDoc.DataSource = docview;
                GridViewDoc.DataBind();
            }
            intItem = 49;
            if (intItem == 49)
            {
                PMTools = objPMSpareParts.PMToolsView(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvPMTools.DataSource = PMTools;
                dgvPMTools.DataBind();

            }
        }

        private void btndocSave_Click()
        {
            Int32 Reffno = Convert.ToInt32(Session["intID"].ToString());
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            string docdesc = TxtDocDescription.Text.ToString();
            //******** Document Uplaod**********************//
            string dfile = Reffno + "_" + Path.GetFileName(DUpload.PostedFile.FileName);
            decimal length = dfile.Length;
            string path = "/test/" + dfile;


            DUpload.PostedFile.SaveAs(Server.MapPath("~/Asset/Uploads/") + dfile);
            FileUploadFTP(Server.MapPath("~/Asset/Uploads/"), dfile, "ftp://ftp.akij.net/test/", "erp@akij.net", "erp123");
            File.Delete(Server.MapPath("~/Asset/Uploads/") + dfile);
            objPMSpareParts.PMSDocUpload(Reffno, path, docdesc, intenroll, intjobid, intdept);
            GridViewDoc.DataBind();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Document Upload');", true);

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

        

        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {


            Int32 WHID = Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString()); ;

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.AutoSearchWHIDParts(WHID.ToString(), prefixText);
        }




        [WebMethod]
        public static List<string> GetAutoCompleteDataemp(string strSearchKeyemp)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 ||intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
            {
                List<string> result2 = new List<string>();
                result2= objAutoSearch_BLL.AutoSearchCorporateEmployee(strSearchKeyemp);
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
        public static List<string> GetAutoCompleteDataTools(string strSearchTextTools)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());


            List<string> resultTools = new List<string>();
            resultTools = objAutoSearch_BLL.AutoSearchAssetrToolsAndEquipment(strSearchTextTools);
            return resultTools;

        }


        protected void BtnParts_Click(object sender, EventArgs e)
        {
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
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                    Int32 Reffno = Convert.ToInt32(Session["intID"].ToString());
                    Int32 intwh = Int32.Parse(DdlWareHouse.SelectedValue.ToString());
                    string remarks = TxtRemarks.Text.ToString();
                    Decimal pqty = Decimal.Parse(TxtPqty.Text.ToString());
                   


                    objPMSpareParts.PMSpareParts(Reffno, parts, pqty, intenroll, intjobid, intdept, intwh, remarks);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);
                    GridViewParts.DataBind();

                   
                    showdata();
                }
            }
            catch { }
        }

        protected void BtnLabor_Click(object sender, EventArgs e)
        {
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
                    //Int32 technichin = Int32.Parse(TxtTechnichinSearch.Text.ToString());
                    string description = TxtDescription.Text.ToString();
                    //Decimal laborrate = Decimal.Parse(TxtLabor.Text.ToString());
                    string hour = TxtHour.Text.ToString();
                    // Decimal Tcost = Decimal.Parse(TxtTCost.Text.ToString());
                    objPMSpareParts.PMSLaborCost(Reffno, technichin, description, hour, intenroll, intjobid, intdept);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);

                    showdata();
                }}
                catch { }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 

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
            try
            {
                if (!String.IsNullOrEmpty(SearchToolsBox.Text))
                {
                    string strSearchKey = SearchToolsBox.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    HiddenToolsCode.Value = searchKey[1];
                    string ToolsID = HiddenToolsCode.Value.ToString();


                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    Int32 Reffno = Convert.ToInt32(Session["intID"].ToString());
                    // string technichin = TxtTechnichinSearch.Text.ToString();
                    string description = TxtTollsDescription.Text.ToString();
                    // Decimal laborrate = Decimal.Parse(TxtLabor.Text.ToString());
                    Decimal hour = Decimal.Parse(txtToolsHour.Text.ToString());
                    // Decimal Tcost = Decimal.Parse(TxtTCost.Text.ToString());
                    objPMSpareParts.PmTollsCostinsert(Reffno, ToolsID, description, hour, intenroll, intjobid, intdept);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);
                    showdata();
                }
            }
            catch { }
        }

        protected void dgvPMTools_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}