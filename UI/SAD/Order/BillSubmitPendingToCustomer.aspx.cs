using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class BillSubmitPendingToCustomer : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int unitid, teritoryid, areaid, regionid, shippoint, salesoffice, rpttypes, intsertby;
        decimal gtotaldoqnt, gtotaldoamount, gtotalchlqnt, gtotalchamount, gpendingqnt, gpendingamount;
        DateTime fromdate, todate;

     

        SalesView bll = new SalesView();
        DataTable dt = new DataTable();
        string xmlpath, email, strSearchKey, code, strCustname;



        #endregion


        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\BillSubmitPendingToCustomer";
        string stop = "stopping SAD\\Order\\BillSubmitPendingToCustomer";


        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "customerreturnqnt.xml");
            if (!IsPostBack)
            {

            }
        }

        #region click event
        protected void btncustomertarget_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }
        private void Loadgrid()
        {
            ////---------xml----------
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\BillSubmitPendingToCustomer Bill Submit Pending To Customer", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                fromdate = DateTime.Parse(txtFromDate.Text);
                todate = DateTime.Parse(txtToDate.Text);

                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                rpttypes = int.Parse(drdlrpttype.SelectedValue.ToString());
                intsertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (rpttypes == 1)
                {
                    //reporttype,  unitid,  dtf,  dtto,  sof,  custid,  xml,  id
                    dt = bll.GetdataforBillSubmission(rpttypes, unitid, fromdate, todate, salesoffice, 0, "", 0);
                    if (dt.Rows.Count > 0)
                    {

                        dgvCustomervsReturnqnt.DataSource = dt;
                        dgvCustomervsReturnqnt.DataBind();

                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }



            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\BillSubmitPendingToCustomer Bill Submit", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    fromdate = DateTime.Parse(txtFromDate.Text);
                    todate = DateTime.Parse(txtToDate.Text);
                    teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                    areaid = int.Parse(drdlArea.SelectedValue.ToString());
                    regionid = int.Parse(drdlRegionName.SelectedValue.ToString());
                    unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                    salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                    rpttypes = int.Parse(drdlrpttype.SelectedValue.ToString());
                    intsertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    //try
                    //{
                    if (dgvCustomervsReturnqnt.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvCustomervsReturnqnt.Rows.Count; index++)
                        {
                            if (((CheckBox)dgvCustomervsReturnqnt.Rows[index].FindControl("chkbx")).Checked == true)
                            {
                                //territoryid, custname, custid, targetqnt, areaid, salesofficeid

                                string custid = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdnCustomerID")).Value.ToString();
                                string donum = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdndonum")).Value.ToString();
                                string chnum = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdnchallan")).Value.ToString();
                                string prmchqnt = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdnprimarychallanq")).Value.ToString();
                                TextBox txtreturnqnt = (TextBox)dgvCustomervsReturnqnt.Rows[index].Cells[4].FindControl("txtretqnt");
                                string txtretq = txtreturnqnt.Text;
                                string sofid = salesoffice.ToString();
                                Createxml(custid, donum, chnum, prmchqnt, txtretq, sofid);
                            }
                        }

                        #region ------------ Insert into dataBase -----------
                        email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                        DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlpath);
                        XmlNode dSftTm = doc.SelectSingleNode("Customerreturnqnt");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<Customerreturnqnt>" + xmlString + "</Customerreturnqnt>";
                        dt = bll.GetdataforBillSubmission(2, unitid, fromdate, todate, salesoffice, 0, xmlString, intsertby);
                        try { File.Delete(xmlpath); } catch { }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                        #endregion ------------ Insertion End ----------------
                        dgvCustomervsReturnqnt.DataSource = "";
                        dgvCustomervsReturnqnt.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                    }
                    //}
                    //catch { File.Delete(xmlpath); }



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
        //intSOID,strName,intCustomerID,intTarget,dteFormdate,dteTodate,dteActiondate,intParent

        #region ================ Generate XML and Others ==========        
        private void Createxml(string CustID, string DONumber, string Challan, string PrimaryChallanQnt, string RtnQnt, string salesoffice)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Customerreturnqnt");
                XmlNode addItem = CreateNode(doc, CustID, DONumber, Challan, PrimaryChallanQnt, RtnQnt, salesoffice);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Customerreturnqnt");
                XmlNode addItem = CreateNode(doc,CustID, DONumber, Challan, PrimaryChallanQnt, RtnQnt, salesoffice);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string CustID, string DONumber, string Challan, string PrimaryChallanQnt, string RtnQnt, string salesoffice)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute CCustID = doc.CreateAttribute("CustID"); CCustID.Value = CustID;
            XmlAttribute DDONumber = doc.CreateAttribute("DONumber"); DDONumber.Value = DONumber;
            XmlAttribute CChallan = doc.CreateAttribute("Challan"); CChallan.Value = Challan;
            XmlAttribute PPrimaryChallanQnt = doc.CreateAttribute("PrimaryChallanQnt"); PPrimaryChallanQnt.Value = PrimaryChallanQnt;
            XmlAttribute RRtnQnt = doc.CreateAttribute("RtnQnt"); RRtnQnt.Value = RtnQnt;
            XmlAttribute Salesofficeid = doc.CreateAttribute("salesoffice"); Salesofficeid.Value = salesoffice;
            node.Attributes.Append(CCustID);
            node.Attributes.Append(DDONumber);
            node.Attributes.Append(CChallan);
            node.Attributes.Append(PPrimaryChallanQnt);
            node.Attributes.Append(RRtnQnt);
            node.Attributes.Append(Salesofficeid);
            return node;
        }
        #endregion


        #endregion
        #region change event
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
     
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
  

        protected void dgvCustomervsReturnqnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        #endregion

    }
}