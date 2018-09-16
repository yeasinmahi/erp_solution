using Flogging.Core;
using GLOBAL_BLL;
using QRCoder;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class DeliveryOrderPendingAmountPrint : System.Web.UI.Page
    {

        #region Global variable
        string customerid,unitids;
        int custmid, unitid;
        SalesView bll = new SalesView();
        DataTable dt = new DataTable();

        #endregion
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DeliveryOrderPendingAmountPrint";
        string stop = "stopping SAD\\Order\\DeliveryOrderPendingAmountPrint";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\DeliveryOrderPendingAmountPrint Challan Prit Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    customerid = Session["intcustmid"].ToString();
                unitids= Session["unitid"].ToString();
                DateTime fromDate = DateTime.Now.Date;
                DateTime toDate = DateTime.Now.Date;
                custmid = int.Parse(customerid);
                unitid = int.Parse(unitids);
                dt = bll.getUndelvqntTopsheetPartybase(10, unitid, fromDate, toDate, 0, 0, 0, 0, 0, custmid);
                if (dt.Rows.Count > 0)
                {
                    dgvCustomerVSPendingQnt.DataSource = dt; dgvCustomerVSPendingQnt.DataBind();

                    decimal pednqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    dgvCustomerVSPendingQnt.FooterRow.Cells[4].Text = pednqnt.ToString("N2");
                    decimal pendvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    dgvCustomerVSPendingQnt.FooterRow.Cells[5].Text = pendvalue.ToString("N2");

                    dgvCustomerVSPendingQnt.FooterRow.Cells[3].Text = "Total";
                    dgvCustomerVSPendingQnt.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    dgvCustomerVSPendingQnt.FooterRow.Cells[4].Text = pednqnt.ToString("N2");
                    dgvCustomerVSPendingQnt.FooterRow.Cells[5].Text = pendvalue.ToString("N2");
                    Session["totalpending"] = pednqnt;
                    Session["totalAmount"] = pendvalue;

                    for (int index = 0; index < dgvCustomerVSPendingQnt.Rows.Count; index++)
                    {

                        string code = unitid.ToString();
                        QRCoder.QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 75;
                        imgBarCode.Width = 75;
                        imgBarCode.ID = "Q" + index.ToString();
                        using (System.Drawing.Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                Placeholder1.Controls.Add(imgBarCode);
                                break;
                            }

                        }
                        
                    }


                }

               
              
                DataTable dtinfo = new DataTable();
                dtinfo = bll.getCustandUnitinfo(custmid);

                lblCusName.Text = dtinfo.Rows[0][0].ToString();
                lblCusAddr.Text = dtinfo.Rows[0][1].ToString();
                lblCustmobile.Text = dtinfo.Rows[0][2].ToString();
                lblpendingqnt.Text = Session["totalpending"].ToString();
                lblPendingAmount.Text = Session["totalAmount"].ToString();
                lblUnitName.Text = dtinfo.Rows[0][3].ToString().ToUpper();
                lblUnitAddr.Text = dtinfo.Rows[0][4].ToString();
                lbldataQuantity.Text = dt.Rows[0][5].ToString();
                CheckDigit chk = new CheckDigit();
                string xcd = chk.Encode(dtinfo.Rows[0][8].ToString());
                lblCustid.Text = xcd;
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
        }
            

        protected void dgvCustomerVSPendingQnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvCustomerVSPendingQnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}