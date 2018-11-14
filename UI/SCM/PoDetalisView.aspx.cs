using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Microsoft.Office.Interop.Outlook;
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
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager?.RegisterPostBackControl(btnDownload);
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

            string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
            byte[] bytes = Convert.FromBase64String(base64);
            string filePath = Server.MapPath("PO.Jpeg");
            MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
            ms.Write(bytes, 0, bytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            mEmail.Subject = "Purchase Order: " + lblpoNo.Text;
            mEmail.Body = "Dear " + lblSuppliyers.Text + ",\nYour Purchase Order Number is " + lblpoNo.Text + ". ";
            mEmail.Attachments.Add(filePath, OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            Utility.FileHelper.DeleteFile(filePath);
            mEmail.Display();
        }
    }
}