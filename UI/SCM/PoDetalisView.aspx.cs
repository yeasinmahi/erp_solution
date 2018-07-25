using GLOBAL_BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
 

namespace UI.SCM
{
    public partial class PoDetalisView : System.Web.UI.Page
    {
        int PoNo, enroll,intunit;
        DataTable dt = new DataTable(); string filePathForXML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                PoNo =int.Parse(Session["pono"].ToString());
               
                PoViewDataBind(PoNo);
            }
            else
            {

            }
        }

        private void PoViewDataBind(int PoNo)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
             
                dt = DataTableLoad.GetPoViewDetalisDataTable(PoNo, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblpoNo.Text = PoNo.ToString();
                    DateTime dtePo = DateTime.Parse(dt.Rows[0]["dtePODate"].ToString()); 
                    lblPoDate.Text="  Date:"+ dtePo.ToString("dd-MM-yyyy"); 
                    intunit =int.Parse(dt.Rows[0]["intUnitID"].ToString());
                    lblUnitName.Text= dt.Rows[0]["strDescription"].ToString(); 
                    lblSuppliyers.Text = dt.Rows[0]["strSupplierName"].ToString();
                    lblAtten.Text ="Attn: "+dt.Rows[0]["strReprName"].ToString();
                    lblPhone.Text = "Phone: "+dt.Rows[0]["strOrgContactNo"].ToString();
                    lblSupEmail.Text ="Email:"+ dt.Rows[0]["strOrgMail"].ToString();
                    lblSuppAddress.Text ="Address:"+dt.Rows[0]["strOrgAddress"].ToString();
                    lblBillTo.Text = dt.Rows[0]["strDescription"].ToString();
                    lblShipTo.Text = dt.Rows[0]["strDeliveryAddress"].ToString();

                    lblPartialShip.Text = dt.Rows[0]["ysnPartialShip"].ToString();
                    lblNoShipment.Text = dt.Rows[0]["intShipment"].ToString();
                    DateTime dteLastship = DateTime.Parse(dt.Rows[0]["dteLastShipmentDate"].ToString());

                    lbllastShipmentDate.Text = dteLastship.ToString("dd-MM-yyyy");
                    lblPaymentTrems.Text = dt.Rows[0]["strPayTerm"].ToString();
                    lblPaymentDaysMrr.Text = dt.Rows[0]["intCreditDays"].ToString();
                    lblNoOfInstallment.Text = dt.Rows[0]["intInstallmentNo"].ToString();
                    lblIntervelDay.Text = dt.Rows[0]["intInstallmentInterval"].ToString();
                    lblDeliveryMonth.Text = dt.Rows[0]["intWarrantyMonth"].ToString();

                    lblTransportCharge.Text = dt.Rows[0]["monFreight"].ToString();
                    lblOthersCharge.Text = dt.Rows[0]["monPacking"].ToString();
                    lblGrossDis.Text = dt.Rows[0]["monDiscount"].ToString();
                    lblComission.Text = dt.Rows[0]["monCommission"].ToString();
                    lblPrepareBy.Text = "Prepared By: " + dt.Rows[0]["strEmployeeName"].ToString() + "," + dt.Rows[0]["strIssuerDesign"].ToString() + "," + dt.Rows[0]["strIssuerDept"].ToString();
                    lblApprovedBy.Text = "e-Approved By: " + dt.Rows[0]["strApproveBy"].ToString() + "," + dt.Rows[0]["strApprDesign"].ToString() + "," + dt.Rows[0]["strApprDept"].ToString();

                    //decimal grandtotal = decimal.Parse(dt.Rows[0]["monTotal"].ToString()) 
                    //    + decimal.Parse(dt.Rows[0]["monFreight"].ToString()) + decimal.Parse(dt.Rows[0]["monPacking"].ToString()) +
                    // decimal.Parse(dt.Rows[0]["monCommission"].ToString());

                    lblGrandTotal.Text = dt.Rows[0]["monTotal"].ToString();//string.Format("{0:F4}", grandtotal);
                    lblOthersterms.Text = dt.Rows[0]["strOtherTerms"].ToString(); 
                    //imgUnit.ImageUrl = "/Content/images/img/<%# Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString() %>.png".ToString();
                   imgUnit.ImageUrl= "/Content/images/img/" + intunit.ToString() + ".png".ToString();

                    
                }
                else
                {
                    lblpoNo.Text = "";
                    lblUnitName.Text = "".ToString();
                    lblSuppliyers.Text = "".ToString();
                    lblAtten.Text = "".ToString();
                    lblPhone.Text = "".ToString();
                    lblSupEmail.Text = "".ToString();
                    lblSuppAddress.Text = "".ToString();
                    lblBillTo.Text = "".ToString();
                    lblShipTo.Text = "".ToString();

                    lblPartialShip.Text = "".ToString();
                    lblNoShipment.Text = "".ToString();
                  
                    lbllastShipmentDate.Text = "".ToString();
                    lblPaymentTrems.Text = "".ToString();
                    lblPaymentDaysMrr.Text = "".ToString();
                    lblNoOfInstallment.Text = "".ToString();
                    lblIntervelDay.Text = "".ToString();
                    lblDeliveryMonth.Text = "".ToString();

                    lblTransportCharge.Text = "".ToString();
                    lblOthersCharge.Text = "".ToString();
                    lblGrossDis.Text = "".ToString();
                    lblComission.Text = "".ToString();
                    lblPrepareBy.Text = "".ToString();
                    lblApprovedBy.Text = "".ToString();
                    lblGrandTotal.Text = "".ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO  not found');", true);

                }

                dt = DataTableLoad.GetPoViewItemWaiseDetalisDataTable(PoNo, enroll);
                if (dt.Rows.Count > 0)
                {
                    dgvPoDetalis.DataSource = dt;
                    dgvPoDetalis.DataBind();
                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("monAmount"));
                    dgvPoDetalis.FooterRow.Cells[8].Text = "Total";
                    dgvPoDetalis.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                    dgvPoDetalis.FooterRow.Cells[9].Text = total.ToString("N2");

                    AmountFormat formatAmount = new AmountFormat();
                    string totalAmountInWord = formatAmount.GetTakaInWords(total, "", "Only");
                    lblInWard.Text = "In Word: " + totalAmountInWord.ToString();
                }
                else
                {
                    dgvPoDetalis.DataSource = "";
                    dgvPoDetalis.DataBind();
                }


                dt.Clear();
            }
            catch { }
        }

        protected void ExportToImage(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if(lblSupEmail.Text.Length>6)
                {
                    PoNo = int.Parse(Session["pono"].ToString());

                    string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
                    byte[] bytes = Convert.FromBase64String(base64);
                    //Response.Clear();
                    //Response.ContentType = "image/jpeg";
                    // Response.AddHeader("Content-Disposition", "attachment; filename=PO.png");
                    // Response.Buffer = true;
                    string filename = "d.jpeg".ToString();
                  //  string path = @"\\ENHANCESQL2\FileAttached\" + enroll.ToString() + PoNo.ToString() + ".jpeg";
                  //  File.WriteAllBytes(@"\\ENHANCESQL2\FileAttached\" + enroll.ToString() + PoNo.ToString() + ".jpeg", bytes);
                //    string stringXml = "<voucher><voucherentry filePath=" + '"' + path + '"' + "/></voucher>".ToString();
                  //  string msg = DataTableLoad.POApproval(20, stringXml, PoNo, enroll);
                  //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ msg + "');", true);

                    //using (MailMessage mm = new MailMessage("erpreply@akij.net", "bappisarker9@gmail.com"))
                    //{
                    //    mm.Subject = "Bappi";
                    //    mm.Body = "Bappi";
                    //    mm.Attachments.Add(new Attachment(filePath + "a.jpeg"));
                    //    string d = filePath + "a.jpeg";
                    //    LinkedResource LinkedImage = new LinkedResource(d);
                    //    LinkedImage.ContentId = "MyPic";
                    //    //Added the patch for Thunderbird as suggested by Jorge
                    //    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                    //    AlternateView htmlView = AlternateView.CreateAlternateViewFromString("You should see image next to this line. <img src=cid:MyPic>", null, "text/html");
                    //    htmlView.LinkedResources.Add(LinkedImage);
                    //    mm.AlternateViews.Add(htmlView);

                    //    mm.IsBodyHtml = true;
                    //    SmtpClient smtp = new SmtpClient();
                    //    smtp.Host = "ex.akij.net";
                    //    smtp.EnableSsl = true;
                    //    NetworkCredential NetworkCred = new NetworkCredential("erpreply@akij.net", "rep@123");
                    //    // smtp.UseDefaultCredentials = true;
                    //    smtp.Credentials = NetworkCred;

                    //    //smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
                    //    smtp.Port = 25;
                    //    smtp.Send(mm);
                    //}

                    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    //Response.BinaryWrite(bytes);

                    //Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Email Address not found');", true);
                }

            }
            catch { }
            

            
        }

        protected void btnPoShowByView_Click(object sender, EventArgs e)
        {
            try
            {
                PoViewDataBind(int.Parse(txtPoNumbers.Text.ToString()));
            }
            catch { } 
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
               // enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                //PoNo = int.Parse(Session["pono"].ToString());
                //
                //string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
                //byte[] bytes = Convert.FromBase64String(base64);
                //System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                //Response.Clear();
                //
               // Response.ContentType = "image/jpeg";
                // Response.ContentType = "image/jpeg";
               // Response.AddHeader("Content-Disposition", "attachment; filename=PO.jpg");
                //Response.Buffer = true;
                //  string filename = "d.jpeg".ToString();
                //  string path = @"\\ENHANCESQL2\FileAttached\" + enroll.ToString() + PoNo.ToString() + ".jpeg";
                //  File.WriteAllBytes(@"\\ENHANCESQL2\FileAttached\" + enroll.ToString() + PoNo.ToString() + ".jpeg", bytes);
                // string stringXml = "<voucher><voucherentry filePath=" + '"' + path + '"' + "/></voucher>".ToString(); 
                try
                {
                    string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
                    byte[] imagebytes = Convert.FromBase64String(base64);
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagebytes);
                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                         
                        Document document = new Document(PageSize.A3, 0f, 0f, 0f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                        document.Open();
                         
                        document.Add(image);
                        document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + PoNo.ToString()+ ".pdf");
                        Response.ContentType = "application/pdf";
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();
                    }
                }
                catch { }
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(bytes);

                //Response.End();
            }
            catch { }
        }

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {




            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

            //UploadFile;
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
    }
}