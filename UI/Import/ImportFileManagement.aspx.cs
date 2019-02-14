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
    public partial class ImportFileManagement : BasePage
    {
        private readonly Import_BLL _bll = new Import_BLL();
        private DataTable dt = new DataTable();
        readonly string ftp = "ftp://ftp.akij.net/";
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager?.RegisterPostBackControl(this.gridView);

            Page.Form.Attributes.Add("enctype", "multipart/form-data");
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
            GridViewUtil.UnLoadGridView(gridView);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hidePanel", "hidePanel()", true);
            string poNumber = txtPoNumber.Text;
            string lcNumber = txtLcNumber.Text;
            int po = 0;
            if (string.IsNullOrWhiteSpace(poNumber) && string.IsNullOrWhiteSpace(lcNumber))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "ShowNotification('You have to input PO or LC number','Import File Management','warning')", true);
                return;
            }
            if (!string.IsNullOrWhiteSpace(lcNumber))
            {
                dt = _bll.GetPoByLcNumber(lcNumber);
                if (dt.Rows.Count > 0)
                {
                    int.TryParse(dt.Rows[0]["intPOID"].ToString(), out po);
                    if (po == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "ShowNotification('Somthing error in PO conversion','Import File Management','error')", true);
                        txtLcNumber.Text = String.Empty;
                        return;
                    }
                    txtPoNumber.Text = po.ToString();
                    poNumber = po.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "ShowNotification('We can not found this lc number in our system','Import File Management','error')", true);
                    txtLcNumber.Text = String.Empty;
                    return;
                }

            }
            if (!string.IsNullOrWhiteSpace(poNumber))
            {
                int.TryParse(poNumber, out po);
                if (po == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", 
                    "ShowNotification('Input po number properly','Import File Management','warning')", true);
                    return;
                }
                dt = _bll.GetLcIdbyPoId(po);
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
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "ShowNotification('No data found aginest this PO number','Import File Management','warning')", true);
                }
            }
            
        }

        private void LoadShipmentSl(long LcId)
        {
            int fileGroupId = Convert.ToInt32(ddlFileGroup.SelectedItem.Value);
            if (fileGroupId == 1)
            {
                ddlShipment.DataSource = null;
                ddlShipment.DataBind();
            }
            else
            {
                ddlShipment.DataSource = _bll.GetShipmentInfo(LcId);
                ddlShipment.DataTextField = "intShipmentSL";
                ddlShipment.DataValueField = "intShipmentID";
                ddlShipment.DataBind();
            }

            
        }
        private void LoadFileGroup()
        {
            ddlFileGroup.DataSource = _bll.GetFileFroup();
            ddlFileGroup.DataTextField = "strFileName";
            ddlFileGroup.DataValueField = "intFileTypeID";
            ddlFileGroup.DataBind();
        }
        
        protected void btnAddNewFile_OnClick(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string filename = ddlFileGroup.SelectedItem.Value+"_"+ Enroll +"_"+ Path.GetFileName(fileUpload.FileName);
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
                            "ShowNotification('Sucessfully Uploaded.','Import File Management','success')", true);
                            LoadGridView();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "ShowNotification('Insert into database problem.','Import File Management','error')", true);
                        }
                       
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        "ShowNotification('Upload problem...','Import File Management','error')", true);
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "ShowNotification('" + ex.Message + "','Import File Management','error')", true);
                }
                localPath.DeleteFile();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                "ShowNotification('Please select a file.','Import File Management','warning')", true);
                //return;
            }
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "showPanel", "showPanel()", true);

        }

        private bool InsertData(string strFilePath)
        {
            int fileTypeId = Convert.ToInt32(ddlFileGroup.SelectedItem.Value);
            int intShipmentID = 0;
            if (fileTypeId != 1)
            {
                intShipmentID = Convert.ToInt32(ddlShipment.SelectedItem.Value);
            }
            int intLcID = Convert.ToInt32(hdLcId.Value);
            int intUnit = Convert.ToInt32(ddlUnitName.SelectedItem.Value);
            string strRemarks = txtNote.Text;
            dt = _bll.InsertImportFileUploadDetails(fileTypeId, strFilePath, intLcID, intShipmentID, Enroll, intUnit,
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
            int lcId = Convert.ToInt32(hdLcId.Value);
            if (fileGroupId == 1)
            {
                dt = _bll.GetImportFileUploadDetail(fileGroupId, lcId);
            }
            else
            {
                int shipmentId = Convert.ToInt32(ddlShipment.SelectedItem.Value);
                dt = _bll.GetImportFileUploadDetail(fileGroupId, lcId, shipmentId);
            }
            
            gridView.DataSource = dt;
            gridView.DataBind();
        }

        private void LoadUnit()
        {
            ddlUnitName.Items.Add(new ListItem(UnitName,UnitId.ToString()));
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
                Session["src"] = ftp + strPath;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup",
                    "popup('../Other/DocumentView.aspx','Document View');", true);
            }
            else if (e.CommandName == "Download")
            {
                byte[] bytes = (ftp + strPath).DownloadFromFtp();
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
            LoadGridView();
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

        protected void ddlFileGroup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnShow_Click(null, null);
        }
    }
}