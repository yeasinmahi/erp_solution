using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using UI.ClassFiles;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Microsoft.Office.Interop.Outlook;
using Document = iTextSharp.text.Document;
using Exception = System.Exception;

namespace UI.SCM
{
    public partial class PoDetalisView : Page
    {
        int PoNo, enroll, intunit;
        DataTable dt = new DataTable(); string filePathForXML;

        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\PoDetalisView";
        string stop = "stopping SCM\\PoDetalisView";
        string perform = "Performance on SCM\\PoDetalisView";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PoNo = int.Parse(Session["pono"].ToString());

                PoViewDataBind(PoNo);
            }
            else
            {

            }
        }

        private void PoViewDataBind(int PoNo)
        {
            var fd = log.GetFlogDetail(start, location, "PoViewDataBind", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "PoViewDataBind", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = DataTableLoad.GetPoViewDetalisDataTable(PoNo, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblpoNo.Text = PoNo.ToString();
                    DateTime dtePo = DateTime.Parse(dt.Rows[0]["dtePODate"].ToString());
                    lblPoDate.Text = "  Date:" + dtePo.ToString("dd-MM-yyyy");
                    intunit = int.Parse(dt.Rows[0]["intUnitID"].ToString());
                    lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                    lblSuppliyers.Text = dt.Rows[0]["strSupplierName"].ToString();
                    lblAtten.Text = "Attn: " + dt.Rows[0]["strReprName"].ToString();
                    lblPhone.Text = "Phone: " + dt.Rows[0]["strOrgContactNo"].ToString();
                    lblSupEmail.Text = "Email:" + dt.Rows[0]["strOrgMail"].ToString();
                    lblSuppAddress.Text = "Address:" + dt.Rows[0]["strOrgAddress"].ToString();
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
                    imgUnit.ImageUrl = "/Content/images/img/" + intunit.ToString() + ".png".ToString();


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
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PoViewDataBind", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "PoViewDataBind", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ExportToImage(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (lblSupEmail.Text.Length > 6)
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
            var fd = log.GetFlogDetail(start, location, "btnDownload_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnDownload_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);

            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                PoNo = int.Parse(Session["pono"].ToString());
                //
                string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64);
                //System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                Response.Clear();
                //
                Response.ContentType = "image/jpeg";
                Response.ContentType = "image/jpeg";
                Response.AddHeader("Content-Disposition", "attachment; filename=PO.jpg");
                Response.Buffer = true;
                //  string filename = "d.jpeg".ToString();
                //  string path = @"\\ENHANCESQL2\FileAttached\" + enroll.ToString() + PoNo.ToString() + ".jpeg";
                //  File.WriteAllBytes(@"\\ENHANCESQL2\FileAttached\" + enroll.ToString() + PoNo.ToString() + ".jpeg", bytes);
                // string stringXml = "<voucher><voucherentry filePath=" + '"' + path + '"' + "/></voucher>".ToString(); 
                //try
                //{
                //    string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
                //    byte[] imagebytes = Convert.FromBase64String(base64);
                //    //string dd = "data:image/jpeg;base64," + Convert.ToBase64String(imagebytes); 
                //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagebytes); 

                //    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                //    {

                //        Document document = new Document(PageSize.A3, 0f, 0f, 0f, 0f);
                //        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //        image.SetDpi(1920, 1920);
                //        document.Open();

                //        document.Add(image);
                //        document.Close();
                //        byte[] bytes = memoryStream.ToArray();
                //        memoryStream.Close();

                //        Response.Clear();
                //        Response.AddHeader("Content-Disposition", "attachment; filename=" + PoNo.ToString()+ ".pdf");
                //        Response.ContentType = "application/pdf";
                //        Response.Buffer = true;
                //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //        Response.BinaryWrite(bytes);
                //        Response.End();
                //    }
                //}
                //catch { }
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);

                Response.End();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDownload_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDownload_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
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
        [WebMethod]
        public static Byte[] DownloadPdf()
        {
            string html = "i am yeasin ";
            Byte[] res = null;

            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            //return File(pdf, "application/pdf");
            File.WriteAllBytes("F:/hello.pdf", res);
            return res;

        }

        protected void btnPDF_OnClick(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PurchaseVouchar.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Document pdfDoc = CreatePdf();
            
            Response.Write(pdfDoc);
            Response.Flush();
            Response.End();
        }

        private Document CreatePdf()
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            return pdfDoc;
        }
        protected void btnEmail_OnClick(object sender, EventArgs e)
        {
            Application mApp = new Application();
            //Document pdfDoc = CreatePdf();
            MailItem mEmail = null;
            mEmail = (MailItem)mApp.CreateItem(OlItemType.olMailItem);
            string email = lblSupEmail.Text;
            mEmail.To = "";
            if (!String.IsNullOrWhiteSpace(email))
            {
                email = email.Substring(6);
                if (!String.IsNullOrWhiteSpace(email))
                {
                    mEmail.To = email;
                }
            }
            mEmail.Subject = "Purchase Order: " + lblpoNo.Text;
            mEmail.Body = "Dear " + lblSuppliyers.Text + ",\nYour Purchase Order Number is " + lblpoNo.Text + ". ";
            //mEmail.Attachments.Add("F:/hello.pdf", OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            mEmail.Display();
        }
    }
}