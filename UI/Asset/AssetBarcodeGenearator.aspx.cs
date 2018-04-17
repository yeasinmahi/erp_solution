using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using System.IO;
using UI.ClassFiles;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace UI.Asset
{
    public partial class AssetBarcodeGenearator : System.Web.UI.Page
    {
        AssetMaintenance configure = new AssetMaintenance();
        DataTable dt = new DataTable();
        static int i = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = new DataTable();
                dt = configure.CheckCorporate(intenroll);
                if (dt.Rows.Count > 0)
                {
                    dt = new DataTable();
                    dt = configure.UnitName();
                    DdlBillUnit.DataSource = dt;
                    DdlBillUnit.DataTextField = "Name";
                    DdlBillUnit.DataValueField = "ID";
                    DdlBillUnit.DataBind();
                    dt = new DataTable();
                    Int32 unit = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
                    dt = configure.UitbyJobstation(unit);
                    DdlJobstation.DataSource = dt;
                    DdlJobstation.DataTextField = "Name";
                    DdlJobstation.DataValueField = "ID";
                    DdlJobstation.DataBind();
                    // DdlJobstation.Items.Insert(0, new ListItem("All", "0"));
                }

                else
                {
                    Int32 unit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    Int32 jobstation = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = new DataTable();
                    dt = configure.UserUnitName(unit);
                    DdlBillUnit.DataSource = dt;
                    DdlBillUnit.DataTextField = "Name";
                    DdlBillUnit.DataValueField = "ID";
                    DdlBillUnit.DataBind();
                    dt = new DataTable();

                    dt = configure.UserJobstation(jobstation);
                    DdlJobstation.DataSource = dt;
                    DdlJobstation.DataTextField = "Name";
                    DdlJobstation.DataValueField = "ID";
                    DdlJobstation.DataBind();

                }


                dt = new DataTable();
                dt = configure.AssetType();
                ddlType.DataSource = dt;
                ddlType.DataTextField = "strAssetTypeName";
                ddlType.DataValueField = "intAssetTypeID";
                ddlType.DataBind();

                ddlType.Items.Insert(0, new ListItem("All", "0"));

                pnlUpperControl.DataBind();








            }
        }

     
        protected void BtnView_Click(object sender, EventArgs e)
        {

            this.BindGrid();

        }

        private void BindGrid()
        {
            dt = new DataTable();
            DateTime sdate = DateTime.Parse("2016-01-01".ToString());
            DateTime edate = DateTime.Parse("2016-01-01".ToString());
            int jobid = int.Parse(DdlJobstation.SelectedValue.ToString());
            string unit = DdlBillUnit.SelectedValue.ToString();
            string xmlunit = "<voucher><voucherentry UnitID=" + '"' + unit + '"' + "/></voucher>".ToString();
            int assetid = int.Parse(ddlType.SelectedValue.ToString());
            dt = configure.AssetViewforGlobalCOA(4, xmlunit, sdate, edate, jobid, assetid);
            dgvGridView.DataSource = dt;
            dgvGridView.DataBind();
        }
       
        protected void DdlBillUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
            dt = new DataTable();
            try
            {
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
            catch { };
            dt = new DataTable();
            dt = configure.UitbyJobstation(unit);
            DdlJobstation.DataSource = dt;
            DdlJobstation.DataTextField = "Name";
            DdlJobstation.DataValueField = "ID";
            DdlJobstation.DataBind();


        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
            catch { };
        }

        protected void DdlJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
            catch { };
        }

        protected void btnBarcodeGenerator_Click(object sender, EventArgs e)
        {
            if (dgvGridView.Rows.Count > 0 )
            {

                for (int index = 0; index < dgvGridView.Rows.Count; index++)
                {
                    if (((CheckBox)dgvGridView.Rows[index].FindControl("chkRow")).Checked == true)
                    {

                        string assetid = ((Label)dgvGridView.Rows[index].FindControl("lblAutoID")).Text.ToString();   

                        string code = assetid.ToString();
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        //imgBarCode.Height = 150;
                        //imgBarCode.Width = 150;
                        imgBarCode.Height = 113;
                        imgBarCode.Width = 113;
                      //  imgBarCode.BorderWidth = 70;
                       // imgBarCode.BorderColor = Color.White;
                   


                        imgBarCode.ID = "Q" + index.ToString();
                        //Bitmap bmp = new Bitmap(400, 400);
                        //using (Graphics graph = Graphics.FromImage(bmp))
                        //{
                        //    Rectangle ImageSize = new Rectangle(0, 0, 400, 400);
                        //    //Pen pen = new Pen(Color.White, 2);
                        //    //graph.DrawRectangle(pen, 0,0, 400, 400);


                        //    //graph.Clear(Color.White);
                        //    //graph.FillRectangle(Brushes.White, ImageSize);
                        //}
                        
                        using (System.Drawing.Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            
                            //int left = (bitMap.Width / 2);
                            // int top = (bitMap.Height / 2);
                            // Bitmap result = new Bitmap(100, 100);
                            //using (Graphics g = Graphics.FromImage(bmp))
                              //  g.DrawImage(bitMap, -10, -10, 113,113);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Graphics g = Graphics.FromImage(bmp);
                                // g.DrawImage(bitMap, new Point(0, 0));


                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                
                                byte[] byteImage = ms.ToArray();
                                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage) ;

                                System.Drawing.Image i = System.Drawing.Image.FromStream(ms);


                            }
                          
                        }
                        Placeholder5.Controls.Add(imgBarCode); 
                        //lblTitle.Text =DdlJobstation.SelectedItem.ToString() + "Asset Type: "+ddlType.SelectedItem.ToString();

                        //System.Web.UI.WebControls.Image g = new System.Web.UI.WebControls.Image();
                        //using (System.Drawing.Bitmap bitMap = new System.Drawing.Bitmap(assetid.Length * 40, 150))
                        //{
                        //    using (Graphics graphics = Graphics.FromImage(bitMap))
                        //    {
                        //        Font oFont = new Font("IDAutomationHC39M", 16);
                        //        PointF point = new PointF(2f, 2f);
                        //        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        //        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        //        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        //        graphics.DrawString("*" + assetid + "*", oFont, blackBrush, point);
                        //    }
                        //    using (MemoryStream ms = new MemoryStream())
                        //    {
                        //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        //        byte[] byteImage = ms.ToArray();

                        //        Convert.ToBase64String(byteImage);
                        //        g.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        //    }
                        //    Placeholder5.Controls.Add(g);


                        //}
                    }


                }
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
        }
    }
}