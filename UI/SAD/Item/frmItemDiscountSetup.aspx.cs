using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Item;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Item
{
    public partial class frmItemDiscountSetup : BasePage
    {
        DataTable dt;int Custid, intUnitId, intActive,rptTYpe,intLineid,intGroupid,PUomId, ItemidSales,ItemidPromotion,Groupid, Rid, Aid,part,intUomid;        
        ItemPromotion objPromotion = new ItemPromotion();
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };  string ItemName,batchno, PromotionName, msg;
        DateTime dteFdate, dteTdate;


        decimal SalesQty, PromotionQty,monAdjustmentAmount;

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Item\\frmItemPromotion";
        string stop = "stopping SAD\\Item\\frmItemPromotion";
        SAD_BLL.Global.SalesOffice objsalesoffice = new SAD_BLL.Global.SalesOffice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Datainitialization();
                ProductGrup();

                
                    txtSalesItem.Visible = true;
                    ddlPGroupList.Visible = false;
                    lblproductGroup.Text = "Product Name";

            }
        }

        protected void ddlGroupProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGroupOrProduct.SelectedValue == "1")
            {
                txtSalesItem.Visible = true;
                ddlPGroupList.Visible = false;
                lblproductGroup.Text = "Product Name";
            }
            else
            {
                txtSalesItem.Visible = false;
                ddlPGroupList.Visible = true;
                lblproductGroup.Text = "Group Name";
            }

        }

        private void ProductGrup()
        {
            dt = objPromotion.getGroupProductList(Session[SessionParams.UNIT_ID].ToString());
            ddlPGroupList.DataTextField = "strText";
            ddlPGroupList.DataValueField = "intID";
            ddlPGroupList.DataSource = dt;
            ddlPGroupList.DataBind();
        }

        protected void ddlPGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Datainitialization()
        {

            dt = new DataTable();
            dt= objsalesoffice.GetSalesOffice(Session[SessionParams.UNIT_ID].ToString());
            ddloffice.DataTextField = "strName";
            ddloffice.DataValueField = "intid";
            ddloffice.DataSource = dt;
            ddloffice.DataBind();
            dt = new DataTable();
            dt = objPromotion.getUom(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlUom.DataTextField = "struom";
            ddlUom.DataValueField = "intid";
            ddlUom.DataSource = dt;
            ddlUom.DataBind();
          

      

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText)
        {
            ItemPromotion objPromotion = new ItemPromotion();
            return objPromotion.GetItem(prefixText);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] CustomerSearch(string prefixText, int count = 0)
        {
            
            ItemPromotion objPromotion = new ItemPromotion();
            return objPromotion.GetCstomer(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString(), prefixText);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            return ItemSt.GetProductDataForAutoFillAPL(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString(), prefixText);
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Arealist();
        }
        private void Arealist()
        {
            //dt = objPromotion.GetareaName(int.Parse(ddlRegion.SelectedValue),int.Parse(ddlLine.SelectedValue));
          
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\frmItemPromotion  Item Promotion Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

            if (txtPromotionName.Text != "")
            {
                    if (ddlGroupOrProduct.SelectedValue.ToString() == "1")
                    {
                        char[] delimiterCharss = { '[', ']' };
                        if (txtCustomer.Text != "")
                        {

                            arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                            Custid = int.Parse(arrayKeyItem[1].ToString());
                        }
                        else { Custid = int.Parse("0"); }
                        arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                        ItemidSales = int.Parse(arrayKeyItem[1].ToString());


                        intUomid = int.Parse(ddlUom.SelectedValue);
                        intUnitId = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());

                        Groupid = int.Parse(ddlDGroup.SelectedValue);
                        dteFdate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
                        if (txtTo.Text == "")
                        { dteTdate = DateTime.Parse("2009-1-1"); }
                        else
                        {
                            dteTdate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text).Date;
                        }

                        monAdjustmentAmount = decimal.Parse(txtDiscountAmount.Text);
                        SalesQty = decimal.Parse(txtSalesQty.Text);

                        part = int.Parse(ddlDGroup.SelectedValue);
                        PromotionName = txtPromotionName.Text;
                        if (part == 1)
                        {
                            if (txtTo.Text != "")
                            {
                                msg = objPromotion.GetDiscount(int.Parse(ddlcalcuationtype.SelectedValue.ToString()), 1, intUnitId, Custid, PromotionName, ItemidSales, monAdjustmentAmount, SalesQty, intUomid, SalesQty, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll);
                            }
                            else
                            {
                                msg = objPromotion.GetDiscount(int.Parse(ddlcalcuationtype.SelectedValue.ToString()), 2, intUnitId, Custid, PromotionName, ItemidSales, monAdjustmentAmount, SalesQty, intUomid, SalesQty, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll);
                            }
                        }
                        else if (part == 2)
                        {
                            if (txtTo.Text != "")
                            {
                                msg = objPromotion.GetDiscountbyOffice(int.Parse(ddlcalcuationtype.SelectedValue.ToString()), 1, intUnitId, int.Parse(ddloffice.SelectedValue.ToString()), PromotionName, ItemidSales, monAdjustmentAmount, SalesQty, intUomid, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll);
                            }
                            else
                            {
                                msg = objPromotion.GetDiscountbyOffice(int.Parse(ddlcalcuationtype.SelectedValue.ToString()), 2, intUnitId, int.Parse(ddloffice.SelectedValue.ToString()), PromotionName, ItemidSales, monAdjustmentAmount, SalesQty, intUomid, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll);

                            }
                        }
                        else if (part == 3)
                        {
                            if (txtTo.Text != "")
                            {
                                msg = objPromotion.GetDiscountbyNational(int.Parse(ddlcalcuationtype.SelectedValue.ToString()), 1, intUnitId, PromotionName, ItemidSales, monAdjustmentAmount, SalesQty, intUomid, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll);
                            }
                            else
                            {
                                msg = objPromotion.GetDiscountbyNational(int.Parse(ddlcalcuationtype.SelectedValue.ToString()), 2, intUnitId, PromotionName, ItemidSales, monAdjustmentAmount, SalesQty, intUomid, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll);

                            }
                        }

                    }
                    else
                    {
                        char[] delimiterCharss = { '[', ']' };
                        if (txtCustomer.Text != "")
                        {

                            arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                            Custid = int.Parse(arrayKeyItem[1].ToString());
                        }
                        else { Custid = int.Parse("0"); }
                       
                        ItemidSales = int.Parse("0");


                        intUomid = int.Parse(ddlUom.SelectedValue);
                        intUnitId = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());

                        Groupid = int.Parse(ddlDGroup.SelectedValue);
                        dteFdate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
                        if (txtTo.Text == "")
                        { dteTdate = DateTime.Parse("2009-1-1"); }
                        else
                        {
                            dteTdate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text).Date;
                        }

                        monAdjustmentAmount = decimal.Parse(txtDiscountAmount.Text);
                        SalesQty = decimal.Parse(txtSalesQty.Text);

                        part = int.Parse(ddlDGroup.SelectedValue);
                        PromotionName = txtPromotionName.Text;

                      msg = objPromotion.GetDiscountGroup(part, int.Parse(ddlcalcuationtype.SelectedValue.ToString()), intUnitId,Custid, PromotionName, monAdjustmentAmount, SalesQty, intUomid, int.Parse(ddlAdjustmenttype.SelectedValue.ToString()), dteFdate, dteTdate, Enroll, int.Parse(ddloffice.SelectedValue.ToString()),int.Parse(ddlPGroupList.SelectedValue.ToString()));

                    }



                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                txtCustomer.Text = "";
               
                txtSalesItem.Text = "";
                txtSalesQty.Text = "";
              
                txtPromotionName.Text = "";
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Entry Promotion Name');", true); }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnReport_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\frmItemPromotion  Item Promotion Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterCharss = { '[', ']' };
            
                if (txtSalesItem.Text != "")
                {
                    arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                    ItemidSales = int.Parse(arrayKeyItem[1].ToString());
                }
                else { ItemidSales = 0; }
                if (ddlReportBy.SelectedValue.ToString() == "1")
                {
                    
                    if (txtCustomer.Text != "")
                    {

                        arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                        Custid = int.Parse(arrayKeyItem[1].ToString());
                    }
                    else { Custid = int.Parse("0"); }
                }
                else if (ddlReportBy.SelectedValue.ToString() == "1")
                {
                    Custid = int.Parse(ddloffice.SelectedValue.ToString());
                }
                else if (ddlReportBy.SelectedValue.ToString() == "1")
                {
                    Custid = int.Parse("0");
                }
                intActive = int.Parse(ddlReporType.SelectedValue);
                dt = objPromotion.getDiscountList(intActive, int.Parse(ddlReportBy.SelectedValue.ToString()), Custid, ItemidSales);
          
            dgvPromotionReport.DataSource = dt;
            dgvPromotionReport.DataBind();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Item\\frmItemPromotion  Item Promotion Cancel", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (txtPromotionName.Text != "")
            {
                char[] delimiterCharss = { '[', ']' };
                if (txtCustomer.Text != "")
                {
                    arrayKeyItem = txtCustomer.Text.Split(delimiterCharss);
                    Custid = int.Parse(arrayKeyItem[1].ToString());
                }
                else { Custid = int.Parse("0"); }
                arrayKeyItem = txtSalesItem.Text.Split(delimiterCharss);
                ItemidSales = int.Parse(arrayKeyItem[1].ToString());
            }
            dteTdate =DateTime.Parse(txtTo.Text);
            batchno = txtPromotionName.Text;
            part =int.Parse(ddlCancelType.SelectedValue);
 

            objPromotion.getNationalPINactiveEnd(dteTdate, ItemidSales, batchno, Custid, part);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}