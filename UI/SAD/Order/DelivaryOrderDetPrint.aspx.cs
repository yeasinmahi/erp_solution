using GLOBAL_BLL;
using QRCoder;
using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;


namespace UI.SAD.Order
{

   
    public partial class DelivaryOrderDetPrint : BasePage
    {

        StatementC bll = new StatementC();
        DataTable dt = new DataTable();
        //SAD_BLL.Customer.Report.DeliverySupport ds = new SAD_BLL.Customer.Report.DeliverySupport();
        //intsl, strunit ,strUnitAddress  ,intCustomerId  ,strName  ,strAddress  ,donumer ,strPhone  ,strProductName  ,Quantity,datet-
        string donum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                donum = Session["donumber"].ToString();
                dt = bll.getdataforDOPrint(donum);
                if (dt.Rows.Count > 0){
                    dgvdodtls.DataSource = dt; dgvdodtls.DataBind();
                 
                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Quantity"));
                    decimal totalqntton = dt.AsEnumerable().Sum(row => row.Field<decimal>("decwgtton"));
                    dgvdodtls.FooterRow.Cells[3].Text = "Total";
                    dgvdodtls.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    dgvdodtls.FooterRow.Cells[4].Text = total.ToString("N2");
                    dgvdodtls.FooterRow.Cells[5].Text = totalqntton.ToString("N2");
                    dgvdodtls.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                    dgvdodtls.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    decimal totalHO = dt.AsEnumerable().Sum(row => row.Field<decimal>("Quantity"));
                    decimal totalqnttonho = dt.AsEnumerable().Sum(row => row.Field<decimal>("decwgtton"));
                    


                    for (int index = 0; index < dgvdodtls.Rows.Count; index++)
                    {
                        string hallogramnmb = ((HiddenField)dgvdodtls.Rows[index].FindControl("hdnhollogramnumber")).Value.ToString();
                        string code = donum.ToString()+ hallogramnmb.ToString();
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
                            }

                        }
                        Placeholder1.Controls.Add(imgBarCode);
                    }

                    
                }
               
                lblUnitName.Text = dt.Rows[0][1].ToString().ToUpper();
                lblUnitAddr.Text = dt.Rows[0][2].ToString();
                CheckDigit chk = new CheckDigit();
                string xcd = chk.Encode(dt.Rows[0][3].ToString());
                lblCustid.Text = xcd;
                lblCusName.Text = dt.Rows[0][4].ToString();
                var date = dt.Rows[0][10].ToString();
                DateTime dates = Convert.ToDateTime(date);
                lblDODate.Text = CommonClass.GetShortDateAtLocalDateFormat(dates);
                lblCusAddr.Text = dt.Rows[0][5].ToString();
                lblDONumber.Text = dt.Rows[0][6].ToString();
                lblCustmobile.Text = dt.Rows[0][7].ToString();
                lblFactory.Text = dt.Rows[0][14].ToString();
                lbldataQuantity.Text= dt.Rows[0][15].ToString();
                var datho = dt.Rows[0][10].ToString();
                DateTime dathot = Convert.ToDateTime(datho);
                lblunitid.Text= dt.Rows[0][11].ToString();
                int unitid = int.Parse(lblunitid.Text.ToString());
                dt = bll.getdataFactoryAddressDet(unitid);
                lblFax.Text= dt.Rows[0][4].ToString();
                lblweb.Text= dt.Rows[0][3].ToString();
                lblEmail.Text = dt.Rows[0][2].ToString()+ "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                lblDelvpoint.Text = dt.Rows[0][0].ToString();
              
               

            }

        }
        
        protected void dgvdodtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvdodtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void grdvOfficeCopy_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvOfficeCopy_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
    }
