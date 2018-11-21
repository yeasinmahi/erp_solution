using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Imports;
using UI.ClassFiles;
using Utility;

namespace UI.Import
{
    public partial class ImportFileManagement : Page
    {
        private Import_BLL bll = new Import_BLL();
        private DataTable dt = new DataTable();
        private int enroll,unitId;
        private string unitName;
        string ftp = "ftp://ftp.akij.net/";
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager?.RegisterPostBackControl(this.gridView);

            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            unitName = HttpContext.Current.Session[SessionParams.UNIT_NAME].ToString();
            unitId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            if (!IsPostBack)
            {
                LoadFileGroup();
                LoadUnit();
            }
            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(this.gridView);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string poNumber = txtPoNumber.Text;
            //string lcNumber = txtLcNumber.Text;
            int po = 0;
            if (string.IsNullOrWhiteSpace(poNumber))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have to input PO number');", true);
                return;
            }
            //if (!string.IsNullOrWhiteSpace(lcNumber))
            //{
            //    dt = bll.GetPoByLcNumber(lcNumber);
            //    if (dt.Rows.Count > 0)
            //    {
            //        int.TryParse(dt.Rows[0]["intPOID"].ToString(), out po);
            //        if (po == 0)
            //        {
            //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
            //                "alert('Somthing error in PO conversion');", true);
            //            txtLcNumber.Text = String.Empty;
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
            //            "alert('We can not found this lc number in our system');", true);
            //        txtLcNumber.Text = String.Empty;
            //        return;
            //    }
                
            //}
            if (!string.IsNullOrWhiteSpace(poNumber))
            {
                int.TryParse(poNumber, out po);
                if (po == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('input po number properly');", true);
                    return;
                }
                dt = bll.GetLcIdbyPoId(po);
                int lcId;
                if (dt.Rows.Count > 0)
                {
                    if (int.TryParse(dt.Rows[0]["intLCID"].ToString(), out lcId))
                    {
                        txtLcNumber.Text = dt.Rows[0]["strLCNumber"].ToString();
                        LoadShipmentSl(lcId);
                        hdLcId.Value = lcId.ToString();
                        LoadGridView();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "showPanel", "showPanel()", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No data found aginest this PO number');", true);
                }
            }
            
        }

        private void LoadShipmentSl(long LcId)
        {
            ddlShipment.DataSource = bll.GetShipmentInfo(LcId);
            ddlShipment.DataTextField= "intShipmentSL";
            ddlShipment.DataValueField = "intShipmentID";
            ddlShipment.DataBind();
        }
        private void LoadFileGroup()
        {
            ddlFileGroup.DataSource = bll.GetFileFroup();
            ddlFileGroup.DataTextField = "strFileName";
            ddlFileGroup.DataValueField = "intFileTypeID";
            ddlFileGroup.DataBind();
        }
        
        protected void btnAddNewFile_OnClick(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string filename = ddlFileGroup.SelectedItem.Value+"_"+ enroll +"_"+ Path.GetFileName(fileUpload.FileName);
                string localPath = Server.MapPath("~/Import/Data/") + filename;
                try
                {
                    fileUpload.SaveAs(localPath);
                    
                    string strFilePath = "Import_Doc/" + filename;
                    string ftpPath = ftp + strFilePath;

                    if (Downloader.UploadToFtp(ftpPath, localPath))
                    {
                        if (InsertData(strFilePath))
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                                "alert('Sucessfully Uploaded.');", true);
                            LoadGridView();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                                "alert('Insert into database problem.');", true);
                        }
                       
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Upload problem..');", true);
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ex.Message+"');", true);
                }
                FileHelper.DeleteFile(localPath);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a file.');", true);
                //return;
            }
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "showPanel", "showPanel()", true);

        }

        private bool InsertData(string strFilePath)
        {
            int fileTypeId = Convert.ToInt32(ddlFileGroup.SelectedItem.Value);
            int intShipmentID = Convert.ToInt32(ddlShipment.SelectedItem.Value);
            int intLcID = Convert.ToInt32(hdLcId.Value);
            int intInsertBy = enroll;
            int intUnit = Convert.ToInt32(ddlUnitName.SelectedItem.Value);
            string strRemarks = txtNote.Text;
            dt = bll.InsertImportFileUploadDetails(fileTypeId, strFilePath, intLcID, intShipmentID, intInsertBy, intUnit,
                strRemarks);
            if (Convert.ToInt32(dt.Rows[0]["autoId"]) > 0)
            {
                return true;
            }
            return false;

        }
        private void LoadGridView()
        {
            int fileGroupId = Convert.ToInt32(ddlFileGroup.SelectedItem.Value);
            int shipmentId = Convert.ToInt32(ddlShipment.SelectedItem.Value);
            int lcId = Convert.ToInt32(hdLcId.Value);
            dt = bll.GetImportFileUploadDetail(fileGroupId, lcId, shipmentId);
            gridView.DataSource = dt;
            gridView.DataBind();
        }

        private void LoadUnit()
        {
            ddlUnitName.Items.Add(new ListItem(unitName,unitId.ToString()));
            ddlUnitName.DataBind();
        }

        protected void gridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRow(gridView,e);
            string strPath = (row.FindControl("lblFtpPath") as Label)?.Text;
            string fileName = Path.GetFileName(strPath);
            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(this.gridView);
            if (e.CommandName == "View")
            {
                Session["ImageSrc"] = ftp + strPath;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "popup('../Other/ImageViewer.aspx','Image View');", true);
            }
            else if (e.CommandName == "Download")
            {
                byte[] bytes = Downloader.DownloadFromFtp(ftp + strPath);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

                //Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(bytes);
                //Response.Flush();
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "showPanel", "showPanel()", true);
        }

        protected void gridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDownload = e.Row.FindControl("btnDownload") as Button;
                Button btnView = e.Row.FindControl("btnView") as Button;
                ScriptManager.GetCurrent(this)?.RegisterPostBackControl(btnDownload);
                ScriptManager.GetCurrent(this)?.RegisterAsyncPostBackControl(btnView);
            }
                
        }
    }
}