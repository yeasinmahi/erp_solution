using MessagingToolkit.QRCode.Codec;
using QRCoder;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;


namespace UI.AEFPS
{
    public partial class FpsRackItemIssue : System.Web.UI.Page
    {
            Receive_BLL objRec = new Receive_BLL();
            DataTable dt = new DataTable();
            string[] arrayKey; char[] delimiterChars = { '[', ']' };
            int enroll, mrrId, intWh, rack = 1, godown = 2, rackType; string ImagePath = "", rackId = "0";

        

            protected void Page_Load(object sender, EventArgs e)
            {
                //filePathForXML = Server.MapPath("~/Asset/Data/RackIs_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

                if (!IsPostBack)
                {
                 
                    DefaltLoad();
                }
                else
                {

                }
            }

        protected void ddlRack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DefaltLoad()
            {
                try
                {
                    ragodwon.Visible = false;raRack.Visible = false;
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                    dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();

                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    rackType = 1;
                 
                    dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                    ddlRack.DataSource = dt;
                    ddlRack.DataTextField = "strName";
                    ddlRack.DataValueField = "Id";
                    ddlRack.DataBind();

                    dt = objRec.DataView(11, "", intWh, mrrId, DateTime.Now, enroll);
                    dgvReceive.DataSource = dt;
                    dgvReceive.DataBind();

                }
                catch { }

            }

            protected void btnPrintBarcode_Click(object sender, EventArgs e)
            {

                #region===============Print Start=============
               // PrintDocument p = new PrintDocument();
              //  p.PrinterSettings.PrinterName = @"\\print2\Network Printer For AH L03 South Side IP 203.7";
                // PrinterSettings pd = new PrinterSettings();
                //string ast = pd.PrinterName.ToString();
                //int i;
                //string ad= p.PrinterSettings.PrinterName;
                //for (i = 0; PrinterSettings.InstalledPrinters.Count > i; i++)
                //{
                //    string asw = p.PrinterSettings.PrinterName;
                //    string ay = PrinterSettings.InstalledPrinters.ToString();
                //}
                //  p.PrinterSettings.PrinterName = @"\\print2\Network Printer For AH L03 South Side IP 203.7";

                // If the printer supports printing in color, then override the printer's default behavior.
                //if (p.PrinterSettings.SupportsColor)
                //{

                //    // Set the page default's to not print in color.
                //    p.DefaultPageSettings.Color = false;

                //}

                // Provide a friendly name, set the page number, and print the document.





           
                if (ddlRack.SelectedItem.ToString()!="")
                {

                PrintDocument p = new PrintDocument();
                PrinterSettings pd = new PrinterSettings();


                string code = ddlRack.SelectedValue.ToString();
                string RackName = ddlRack.SelectedItem.ToString();


                System.Windows.Forms.PictureBox imageControl = new System.Windows.Forms.PictureBox();
                QRCodeEncoder encoder = new QRCodeEncoder();
                Bitmap qrcode = encoder.Encode(code);
                imageControl.Image = null;
                imageControl.Image = qrcode as System.Drawing.Image;
                //imageControl.Image.Save(ImagePath); 
                p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                            {
                                Bitmap bmpQr = new Bitmap(imageControl.Image);
                                System.Drawing.Image QrImage = bmpQr;
                                //e1.Graphics.DrawString(ddlWH.SelectedItem.ToString(), new Font("Arial", 5, FontStyle.Bold), Brushes.Black, new Point(55, 0));
                                e1.Graphics.DrawImage(QrImage, 60, 1, 65, 70);
                                e1.Graphics.DrawString(RackName, new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(60, 73));
                               // e1.Graphics.DrawString("MRR " + mrrId.ToString() + ",B" + code, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(74, 33));

                                };
                p.Print();

                }
               #endregion=============Close===========

            }

            protected void raRack_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    rackType = 1;
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                    ddlRack.DataSource = dt;
                    ddlRack.DataTextField = "strName";
                    ddlRack.DataValueField = "Id";
                    ddlRack.DataBind();
                }
                catch { }
            }

            protected void ragodwon_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    rackType = 2;
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                    ddlRack.DataSource = dt;
                    ddlRack.DataTextField = "strName";
                    ddlRack.DataValueField = "Id";
                    ddlRack.DataBind();

                }
                catch { }
            }

            protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    rackType = 1; 
                    dt = objRec.DataView(11, "", intWh, mrrId, DateTime.Now, enroll);
                    dgvReceive.DataSource = dt;
                    dgvReceive.DataBind();

                    dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                    ddlRack.DataSource = dt;
                    ddlRack.DataTextField = "strName";
                    ddlRack.DataValueField = "Id";
                    ddlRack.DataBind();
                }
                catch { }
            }

            protected void btnPrint_Click(object sender, EventArgs e)
            {
                try
                {
                    rackId = ddlRack.SelectedValue.ToString();
                    if (int.Parse(hdnConfirm.Value) > 0 && rackId != "")
                    {

                        enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        intWh = int.Parse(ddlWH.SelectedValue.ToString());
                        int intRackId= int.Parse(ddlRack.SelectedValue);
                        // mrrId = int.Parse(ddlMrrNo.SelectedValue.ToString());

                        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    
                   
                        TextBox txtIssueQty = row.FindControl("txtIssueQty") as TextBox;
                        Label lblSalesPrice = row.FindControl("lblSalesPrice") as Label;
                        Label lblGodownQty = row.FindControl("lblGodownQty") as Label;
                    
                        Label lblItemId = row.FindControl("lblItemId") as Label;
                        Label lblMrrID = row.FindControl("lblMrrId") as Label;
                        Label lblRackId = row.FindControl("lblRackId") as Label;
                        string IssueQty = txtIssueQty.Text.ToString();
                        string SalesPrice = lblSalesPrice.Text.ToString();
                        string godownQty = lblGodownQty.Text.ToString();
                        string ItemId = lblItemId.Text.ToString();
                        string MrrId = lblMrrID.Text.ToString();
                        string RackId = lblRackId.Text.ToString();



                        //string dteDate = txtDteDate.Text.ToString();

                        string xmlunit = "<voucher><voucherentry itemId=" + '"' + ItemId + '"' + " SalesPrice=" + '"' + SalesPrice + '"' + " IssueQty=" + '"' + IssueQty + '"' + " rackId=" + '"' + RackId + '"' + " MrrId=" + '"' + MrrId + '"' + "/></voucher>".ToString();

                     

                        if (decimal.Parse(IssueQty) > 0 && decimal.Parse(godownQty) >= decimal.Parse(IssueQty))
                        {
                            string mrtg = objRec.MrrReceiveInsert(8, xmlunit, intWh, intRackId, DateTime.Now, enroll);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Issue Quantity Grater then Stock Quantity');", true);
                        }

                        dt = objRec.DataView(11, "", intWh, mrrId, DateTime.Now, enroll);
                        dgvReceive.DataSource = dt;
                        dgvReceive.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Rack Type');", true);

                    }
                }
                catch { }

            }

        }
    }