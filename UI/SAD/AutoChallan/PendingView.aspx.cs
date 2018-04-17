using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using SAD_BLL.AutoChallanBll;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
namespace UI.SAD.AutoChallan
{
    public partial class PendingView : BasePage
    {
        DataTable dtProductPending = new DataTable();
        challanandPending Report = new challanandPending();
        string filePathForXML; int driverenroll; string drivermobile;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());
           // string strEnroll = Convert.ToString("1355".ToString());
            filePathForXML = Server.MapPath("Pendinginputform" + strEnroll + ".xml");

            // filePathForXML = Server.MapPath("orderinputform.xml");
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                txtVehicleno.Attributes.Add("onkeyUp", "SearchText();");
                txtdrivername.Attributes.Add("onkeyUp", "SearchTexts();");
                //txtDriverName.Attributes.Add("onkeyUp", "SearchTextempnew();");
                hdncustid.Value = Session["Custid"].ToString();

                int shipid = int.Parse(Session["Shippointid"].ToString());
                if (shipid == 18)
                {
                    Company.Visible = false;
                    suplier.Visible = false;
                }
                else
                {
                    Company.Visible = true;
                    suplier.Visible = true;
                }
                LoadGrid();
            }
            else { GetRowData();
            //driverResult();
            }





        }
       

        protected Double totalqtytotal = 0;

        private void GetRowData()
        {
            try
            {
                if (dgvPending.Rows.Count > 0)
                {
                    string FreeQty; 
                    for (int index = 0; index < dgvPending.Rows.Count; index++)
                    {
                        string itmid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                        string quantity = ((TextBox)dgvPending.Rows[index].FindControl("Quantity1")).Text.ToString();
                        string pakagesize = ((Label)dgvPending.Rows[index].FindControl("lbluomqty")).Text.ToString();
                        string free = ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text.ToString();
                        string hdnfree = ((HiddenField)dgvPending.Rows[index].FindControl("hdnFreeQty")).Value.ToString();
                       
                        decimal qty = decimal.Parse(quantity.ToString());
                        decimal freeq = decimal.Parse(hdnfree.ToString());
                        decimal uom = decimal.Parse(pakagesize.ToString());
                        decimal totalfree = ((freeq / uom) * qty * uom) / uom;
                        totalfree = Math.Round(totalfree, 2);
                        string finalfree = Convert.ToString(totalfree);
                       

                        decimal totalqty=decimal.Parse(qty.ToString())+decimal.Parse(totalfree.ToString());
                        totalqty = Math.Round(totalqty,2);

                        string finalTotalqty = Convert.ToString(totalqty.ToString());


                        ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text = finalfree;
                        ((Label)dgvPending.Rows[index].FindControl("lblTotalQty")).Text = finalTotalqty;




                      
                    }
                }
            }
            catch { }
        }


        private void LoadGrid()
        {
            try
            {
                int shippointid = int.Parse(Session["Shippointid"].ToString());
                int Custid = int.Parse(hdncustid.Value.ToString());
                dtProductPending = Report.getPendingProductWiseReport(Custid,shippointid);
                dgvPending.DataSource = dtProductPending;
                dgvPending.DataBind();

                string strvehicleno = Convert.ToString(dtProductPending.Rows[0]["StrVehicleno"].ToString());
                string strDrivername = Convert.ToString(dtProductPending.Rows[0]["strDrivername"].ToString());
                string strmobileno = Convert.ToString(dtProductPending.Rows[0]["strmobileno"].ToString());
                int Vehicleid = int.Parse(dtProductPending.Rows[0]["intVehicleid"].ToString());
                string suplier =Convert.ToString(dtProductPending.Rows[0]["vehiclebycompany"].ToString());
                txtVehicleno.Text = strvehicleno;
                txtdrivername.Text = strDrivername;
                txtmobileno.Text = strmobileno;
                txtsupplierName.Text = suplier;
                Session["Vehicleid"] = Vehicleid;
                Session["suplier"] = suplier;

            }
            catch { }
        }
        protected double PendingQtytotal = 0;
        protected void dgvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (dgvPending.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvPending.Rows.Count; index++)
                    {


                        string itmid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                        string quantity = ((TextBox)dgvPending.Rows[index].FindControl("Quantity1")).Text.ToString();
                        string FreeQty = ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text.ToString();

                        ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text = FreeQty;
                    }
                   
                }
            }

            
        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataemp(string strSearchKeyemp)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            //Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            result = objAutoSearch_BLL.AutoSearchItemData(strSearchKeyemp);
            return result;

        }
        [WebMethod]
        public static List<string> GetAutoCompleteDataempnew(string strSearchKeyempnew)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> results = new List<string>();
            results = objAutoSearch_BLL.AutoSearchItemDataDriver(strSearchKeyempnew);
            return results;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dtDriverMobile = new DataTable();
            string drivername = txtdrivername.Text.ToString();
            string mobileno = Convert.ToString(txtmobileno.Text.ToString());
            int intshipid=int.Parse(Session["Shippointid"].ToString());
            DataTable dtSlip = new DataTable();
            dtSlip = Report.getslipno(intshipid);

            string slipno = dtSlip.Rows[0]["slipno"].ToString();

            hdnsession.Value =Convert.ToString(Session["Vehicleid"]);


            Int32 vehicleids;
            int driverenrolls;
           


            if (hdnsession.Value == "")
            {
                string strSearchKey = txtdrivername.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                HdfTechnicinCode.Value = searchKey[1];
                Int32 technichin = Int32.Parse(HdfTechnicinCode.Value.ToString());
                driverenrolls = Convert.ToInt32(technichin.ToString());
                Session["driverenroll"] = driverenrolls;
            }
            else
            {
                 driverenroll = int.Parse("0".ToString());
                 Session["driverenroll"] = driverenroll;
            }
          


            string vehicleno = txtVehicleno.Text;
            string Vehicleno = vehicleno;

            if (hdnsession.Value == "")
            {
                int Vehicleidss;
                string strSearchKey = txtVehicleno.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                hdnvehicle.Value = searchKey[1];
                Int32 technichin = Int32.Parse(hdnvehicle.Value.ToString());
                Vehicleidss = Convert.ToInt32(technichin.ToString());

                Session["vid"] = Vehicleidss;
                vehicleids = int.Parse(Session["vid"].ToString());

            }
            else
            {
                vehicleids = int.Parse(Session["Vehicleid"].ToString());
            }

            driverenroll =int.Parse(Session["driverenroll"].ToString());
            dtDriverMobile = Report.getDriverMobile(driverenroll);
            
            try
            {
                 drivermobile = Convert.ToString(dtDriverMobile.Rows[0]["strContactNo1"].ToString());
            }
            catch { drivermobile = "0"; }

            int custid = int.Parse(Session["Custid"].ToString());
            string Custid =Convert.ToString(custid.ToString());
            Int32 Vehicleid = int.Parse(vehicleids.ToString());
            string mobibleno = drivermobile.ToString();
            string suppliername;
            if (hdncompany.Value == "Company")
            {
                suppliername = hdncompany.Value;

            }
            else
            {
                suppliername = Convert.ToString(txtsupplierName.Text.ToString());
            }

            Int32 shippointid = int.Parse(intshipid.ToString());
            //string supliername =txtsupplierName.ToString();
            string supliername = suppliername.ToString();
            if (hdnsession.Value==Convert.ToString("".ToString()))
            {
                Report.insertVehicle(Custid, Vehicleno, Vehicleid, drivername, mobibleno, shippointid, supliername);
            }

                if (dgvPending.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvPending.Rows.Count; index++)
                    {

                        string itmid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                        string quantity = ((TextBox)dgvPending.Rows[index].FindControl("Quantity1")).Text.ToString();
                        string FreeQty = ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text.ToString();
                        string uomqty = ((Label)dgvPending.Rows[index].FindControl("lbluomqty")).Text.ToString();
                        string justFreeQty = ((HiddenField)dgvPending.Rows[index].FindControl("hdnFreeQty")).Value.ToString();
                      
                        if (quantity == "") { quantity = "0"; }
                     
                        decimal uom = Convert.ToDecimal(uomqty.ToString());
                        decimal qty = Convert.ToDecimal(quantity.ToString());
                        decimal free = Convert.ToDecimal(justFreeQty.ToString());
                        decimal FFreeQty = ((Convert.ToDecimal(free.ToString()) / Convert.ToDecimal(uom.ToString())) * qty * uom) / uom;
                        decimal tqty = qty + FFreeQty;
                        string TotalFreeqty = Convert.ToString(FFreeQty);
                        string totalqty=Convert.ToString(tqty.ToString());

                        if (quantity != "0")
                        {
                            if (quantity != "0.0000" || quantity != "0.0000")
                            {
                                CreateSalesXml(itmid, quantity, FreeQty, TotalFreeqty, totalqty);

                            }
                            #region ------------ Insert into dataBase -----------


                            string txtDate = "2015-5-7";

                            DateTime date = DateTime.Parse(txtDate);
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("Order");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<Order>" + xmlString + "</Order>";
                            string message = Report.InsertPendingform(xmlString, custid, vehicleno, vehicleids, slipno, intshipid, drivername, mobileno, suppliername);
                            File.Delete(filePathForXML);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                            #endregion ------------ Insertion End ----------------
                        }

                    }
                    dgvPending.DataBind();
               
                }


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);     
        }

        protected void dgvPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvPending.Rows.Count > 0)
            {

                for (int index = 0; index < dgvPending.Rows.Count; index++)
                {


                    string itmid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                    string quantity = ((TextBox)dgvPending.Rows[index].FindControl("Quantity1")).Text.ToString();
                    string FreeQty = ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text.ToString();


                    ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text = FreeQty;




                }
            }
           
        }

        protected void Quantity1_TextChanged(object sender, EventArgs e)
        {
           
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchPartsData(strSearchKey);
            return result;

        }
        [WebMethod]
        public static List<string> GetAutoCompleteDatas(string strSearchKey)
        {
            challanandPending objAutoSearch_BLL = new challanandPending();

            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchDriverName(strSearchKey);
            return result;

        }

        protected void dgvPending_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (dgvPending.Rows.Count > 0)
            {

                for (int index = 0; index < dgvPending.Rows.Count; index++)
                {


                    string itmid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                    string quantity = ((TextBox)dgvPending.Rows[index].FindControl("Quantity1")).Text.ToString();
                    string FreeQty = ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text.ToString();

                    ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text = FreeQty;




                }
                
            }
        }
        private void CreateSalesXml(string itemid, string quantity, string FreeQty, string TotalFreeqty, string totalqty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Order");
                XmlNode addItem = CreateItemNode(doc, itemid, quantity, FreeQty, TotalFreeqty, totalqty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Order");
                XmlNode addItem = CreateItemNode(doc, itemid, quantity, FreeQty, TotalFreeqty, totalqty);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }




        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string quantity, string FreeQty, string TotalFreeqty, string totalqty)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;    
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute freeQty = doc.CreateAttribute("FreeQty");
            freeQty.Value = FreeQty;
            XmlAttribute totalFreeqty = doc.CreateAttribute("TotalFreeqty");
            totalFreeqty.Value = TotalFreeqty;
            XmlAttribute Totalqty = doc.CreateAttribute("totalqty");
            Totalqty.Value = totalqty;


            node.Attributes.Append(Itemid);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(freeQty);
            node.Attributes.Append(totalFreeqty);
            node.Attributes.Append(Totalqty);
           
            return node;
        }

        protected void dgvPending_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (dgvPending.Rows.Count > 0)
            {

                for (int index = 0; index < dgvPending.Rows.Count; index++)
                {


                    string itmid = ((Label)dgvPending.Rows[index].FindControl("lblProductid")).Text.ToString();
                    string quantity = ((TextBox)dgvPending.Rows[index].FindControl("Quantity1")).Text.ToString();
                    string FreeQty = ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text.ToString();


                    ((Label)dgvPending.Rows[index].FindControl("lblFreeQty")).Text = FreeQty;




                }
            }
        }

        protected void txtVehicle1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Company_CheckedChanged(object sender, EventArgs e)
        {
            txtsupplierName.Visible = false;

            hdncompany.Value = "Company";
        }

        protected void thardparty_CheckedChanged(object sender, EventArgs e)
        {
            txtsupplierName.Visible = true;
            hdncompany.Value = "3rdparty";
        }
    }
}