using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;
using System.IO;
using System.Xml;


namespace UI.Transport
{
    public partial class InternalTRouteCostUpdate : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Transport";
        string start = "starting Transport/InternalTransportRouteExpIn.aspx";
        string stop = "stopping Transport/InternalTransportRouteExpIn.aspx";

        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intUnitID; int intShipPointID; int intWork; string strTripSLNo; int intCheck; int ysnWonVehicle, intID;
        int intVT; string strVTCom; int intReffID; int intInsertBy; string xml;

        string filePathForXMLCustWiseCost; string xmlStringCustWiseCost = ""; string xmlCustWiseCost;

        string reffid; string custid; string custname; string millage; string tripfare; string tfopentruck;
        string tfcoveredvan; string tfpickup; string tf7ton; string tf5ton; string tf3ton; string tf1andhalfton;
        string bridgetoll; string bnrtoll20ton; string bnrtoll10ton; string bnrtoll7ton; string bnrtoll5ton;
        string bnrtoll3ton; string bnrtoll2ton; string bnrtoll1andhalfton; string ferrytoll; string ft20ton;
        string ft7ton; string ft5ton; string ft3ton; string ft1andhalfton; string tf10ton;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                try
                {
                    //LoadGrid();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    //hdnEnroll.Value = "89736";
                    //hdnUnit.Value = "4";
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();

                    CustomerWiseRouteCost();

                }
                catch
                {
            
                }
            }
            else
            {
              
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();

            CustomerWiseRouteCost();
        }
        private void CustomerWiseRouteCost()
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
            dt = new DataTable();
            dt = obj.GetDataForRouteCostUpdate(intUnitID, intShipPointID);
            dgvTripWiseCustomer.DataSource = dt;
            dgvTripWiseCustomer.DataBind();
           
            dgvTripWiseCustomer.Columns[5].Visible = false;
            dgvTripWiseCustomer.Columns[6].Visible = false;
            dgvTripWiseCustomer.Columns[7].Visible = false;
            dgvTripWiseCustomer.Columns[8].Visible = false;
            dgvTripWiseCustomer.Columns[9].Visible = false;
            dgvTripWiseCustomer.Columns[10].Visible = false;
            dgvTripWiseCustomer.Columns[11].Visible = false;
            dgvTripWiseCustomer.Columns[12].Visible = false;
            dgvTripWiseCustomer.Columns[13].Visible = false;
            dgvTripWiseCustomer.Columns[14].Visible = false;
            dgvTripWiseCustomer.Columns[15].Visible = false;
            dgvTripWiseCustomer.Columns[16].Visible = false;
            dgvTripWiseCustomer.Columns[17].Visible = false;
            dgvTripWiseCustomer.Columns[18].Visible = false;
            dgvTripWiseCustomer.Columns[19].Visible = false;
            dgvTripWiseCustomer.Columns[20].Visible = false;
            dgvTripWiseCustomer.Columns[21].Visible = false;
            dgvTripWiseCustomer.Columns[22].Visible = false;
            dgvTripWiseCustomer.Columns[23].Visible = false;
            dgvTripWiseCustomer.Columns[24].Visible = false;
            dgvTripWiseCustomer.Columns[25].Visible = false;
            dgvTripWiseCustomer.Columns[26].Visible = false;
            dgvTripWiseCustomer.Columns[27].Visible = false;

            //intUnitID = 16;

            if (intUnitID == 1)
            {
                dgvTripWiseCustomer.Columns[6].Visible = true;
                dgvTripWiseCustomer.Columns[7].Visible = true;
                dgvTripWiseCustomer.Columns[8].Visible = true;
                dgvTripWiseCustomer.Columns[14].Visible = true;
                dgvTripWiseCustomer.Columns[22].Visible = true;
            }
            else if (intUnitID == 2)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;
                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
                dgvTripWiseCustomer.Columns[24].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;
                dgvTripWiseCustomer.Columns[26].Visible = true;
                dgvTripWiseCustomer.Columns[27].Visible = true;
            }
            else if (intUnitID == 4 || intUnitID == 8)
            {
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[15].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[23].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;

            }
            else if (intUnitID == 16 || intUnitID == 105)
            {
                //dgvTripWiseCustomer.Columns[5].Visible = true;

                dgvTripWiseCustomer.Columns[9].Visible = true;
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;

                dgvTripWiseCustomer.Columns[16].Visible = true;
                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[20].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
                dgvTripWiseCustomer.Columns[24].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;
                dgvTripWiseCustomer.Columns[26].Visible = true;
                dgvTripWiseCustomer.Columns[27].Visible = true;
            }
            else if (intUnitID == 10)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;
                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
                dgvTripWiseCustomer.Columns[24].Visible = true;
                dgvTripWiseCustomer.Columns[25].Visible = true;
            }
            else if (intUnitID == 90)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;

                dgvTripWiseCustomer.Columns[17].Visible = true;
                dgvTripWiseCustomer.Columns[18].Visible = true;
                dgvTripWiseCustomer.Columns[19].Visible = true;
                dgvTripWiseCustomer.Columns[21].Visible = true;
            }
            else
            {
                dgvTripWiseCustomer.Columns[5].Visible = true;
                dgvTripWiseCustomer.Columns[14].Visible = true;
                dgvTripWiseCustomer.Columns[22].Visible = true;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
                        
            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                if (dgvTripWiseCustomer.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvTripWiseCustomer.Rows.Count; index++)
                    {
                        reffid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblReffIDG")).Text.ToString();
                        custid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustIDG")).Text.ToString();
                        custname = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustNameG")).Text.ToString();
                        millage = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageG")).Text.ToString();
                        tripfare = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTripFareG")).Text.ToString();
                        tfopentruck = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFOpentruckG")).Text.ToString();
                        tfcoveredvan = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFCoveredVanG")).Text.ToString();
                        tfpickup = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFPickupG")).Text.ToString();
                        tf10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF10TonG")).Text.ToString();
                        tf7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF7TonG")).Text.ToString();
                        tf5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF5TonG")).Text.ToString();
                        tf3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF3TonG")).Text.ToString();
                        tf1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF1AndHalfTonG")).Text.ToString();
                        bridgetoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBridgeTollG")).Text.ToString();
                        bnrtoll20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll20TonG")).Text.ToString();
                        bnrtoll10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll10TonG")).Text.ToString();
                        bnrtoll7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll7TonG")).Text.ToString();
                        bnrtoll5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll5TonG")).Text.ToString();
                        bnrtoll3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll3TonG")).Text.ToString();
                        bnrtoll2ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll2TonG")).Text.ToString();
                        bnrtoll1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll1AndHalfTonG")).Text.ToString();
                        ferrytoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFerryTollG")).Text.ToString();
                        ft20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT20TonG")).Text.ToString();
                        ft7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT7TonG")).Text.ToString();
                        ft5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT5TonG")).Text.ToString();
                        ft3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT3TonG")).Text.ToString();
                        ft1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT1AndHalfTonG")).Text.ToString();

                        CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);

                    }

                    if (dgvTripWiseCustomer.Rows.Count > 0)
                    {
                        try
                        {
                            //filePathForXMLCustWiseCost = Server.MapPath("~/Transport/Data/CustWiseCost_" + hdnEnroll.Value + ".xml");
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLCustWiseCost);
                            XmlNode dSftTm = doc.SelectSingleNode("CustWiseCost");
                            string xmlStringCustWiseCost = dSftTm.InnerXml;
                            xmlStringCustWiseCost = "<CustWiseCost>" + xmlStringCustWiseCost + "</CustWiseCost>";
                            xml = xmlStringCustWiseCost;
                        }
                        catch { }
                        if (xml == "") { return; }
                    }

                    intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //Final Update
                    string message = obj.UpdateRouteCostUpdateByAdminUser(intUnitID, intInsertBy, xml);

                    if (filePathForXMLCustWiseCost != null)
                    { File.Delete(filePathForXMLCustWiseCost); }
                    dgvTripWiseCustomer.DataSource = ""; dgvTripWiseCustomer.DataBind();
                    
                    CustomerWiseRouteCost();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    //Show Report By Trip Sl End

                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void CreateVoucherXmlCustWiseCost(string reffid, string custid, string custname, string millage, string tripfare, string tfopentruck, string tfcoveredvan, string tfpickup, string tf10ton, string tf7ton, string tf5ton, string tf3ton, string tf1andhalfton, string bridgetoll, string bnrtoll20ton, string bnrtoll10ton, string bnrtoll7ton, string bnrtoll5ton, string bnrtoll3ton, string bnrtoll2ton, string bnrtoll1andhalfton, string ferrytoll, string ft20ton, string ft7ton, string ft5ton, string ft3ton, string ft1andhalfton)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLCustWiseCost))
            {
                doc.Load(filePathForXMLCustWiseCost);
                XmlNode rootNode = doc.SelectSingleNode("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLCustWiseCost);
            LoadGridwithXmlCustWiseCost();
            //Clear();
        }
        private void LoadGridwithXmlCustWiseCost()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLCustWiseCost);
            XmlNode dSftTm = doc.SelectSingleNode("CustWiseCost");
            xmlStringCustWiseCost = dSftTm.InnerXml;
            xmlStringCustWiseCost = "<CustWiseCost>" + xmlStringCustWiseCost + "</CustWiseCost>";
            StringReader sr = new StringReader(xmlStringCustWiseCost);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvTripWiseCustomer.DataSource = ds; }
            else { dgvTripWiseCustomer.DataSource = ""; } //dgvTripWiseCustomer.DataBind();
        }
        
        private XmlNode CreateItemNodeCustWiseCost(XmlDocument doc, string reffid, string custid, string custname, string millage, string tripfare, string tfopentruck, string tfcoveredvan, string tfpickup, string tf10ton, string tf7ton, string tf5ton, string tf3ton, string tf1andhalfton, string bridgetoll, string bnrtoll20ton, string bnrtoll10ton, string bnrtoll7ton, string bnrtoll5ton, string bnrtoll3ton, string bnrtoll2ton, string bnrtoll1andhalfton, string ferrytoll, string ft20ton, string ft7ton, string ft5ton, string ft3ton, string ft1andhalfton)
        {
            XmlNode node = doc.CreateElement("CustWiseCost");

            XmlAttribute Reffid = doc.CreateAttribute("reffid"); Reffid.Value = reffid;
            XmlAttribute Custid = doc.CreateAttribute("custid"); Custid.Value = custid;
            XmlAttribute Custname = doc.CreateAttribute("custname"); Custname.Value = custname;
            XmlAttribute Millage = doc.CreateAttribute("millage"); Millage.Value = millage;
            XmlAttribute Tripfare = doc.CreateAttribute("tripfare"); Tripfare.Value = tripfare;
            XmlAttribute Tfopentruck = doc.CreateAttribute("tfopentruck"); Tfopentruck.Value = tfopentruck;
            XmlAttribute Tfcoveredvan = doc.CreateAttribute("tfcoveredvan"); Tfcoveredvan.Value = tfcoveredvan;
            XmlAttribute Tfpickup = doc.CreateAttribute("tfpickup"); Tfpickup.Value = tfpickup;
            XmlAttribute Tf10ton = doc.CreateAttribute("tf10ton"); Tf10ton.Value = tf10ton;
            XmlAttribute Tf7ton = doc.CreateAttribute("tf7ton"); Tf7ton.Value = tf7ton;
            XmlAttribute Tf5ton = doc.CreateAttribute("tf5ton"); Tf5ton.Value = tf5ton;
            XmlAttribute Tf3ton = doc.CreateAttribute("tf3ton"); Tf3ton.Value = tf3ton;
            XmlAttribute Tf1andhalfton = doc.CreateAttribute("tf1andhalfton"); Tf1andhalfton.Value = tf1andhalfton;
            XmlAttribute Bridgetoll = doc.CreateAttribute("bridgetoll"); Bridgetoll.Value = bridgetoll;
            XmlAttribute Bnrtoll20ton = doc.CreateAttribute("bnrtoll20ton"); Bnrtoll20ton.Value = bnrtoll20ton;
            XmlAttribute Bnrtoll10ton = doc.CreateAttribute("bnrtoll10ton"); Bnrtoll10ton.Value = bnrtoll10ton;
            XmlAttribute Bnrtoll7ton = doc.CreateAttribute("bnrtoll7ton"); Bnrtoll7ton.Value = bnrtoll7ton;
            XmlAttribute Bnrtoll5ton = doc.CreateAttribute("bnrtoll5ton"); Bnrtoll5ton.Value = bnrtoll5ton;
            XmlAttribute Bnrtoll3ton = doc.CreateAttribute("bnrtoll3ton"); Bnrtoll3ton.Value = bnrtoll3ton;
            XmlAttribute Bnrtoll2ton = doc.CreateAttribute("bnrtoll2ton"); Bnrtoll2ton.Value = bnrtoll2ton;
            XmlAttribute Bnrtoll1andhalfton = doc.CreateAttribute("bnrtoll1andhalfton"); Bnrtoll1andhalfton.Value = bnrtoll1andhalfton;
            XmlAttribute Ferrytoll = doc.CreateAttribute("ferrytoll"); Ferrytoll.Value = ferrytoll;
            XmlAttribute Ft20ton = doc.CreateAttribute("ft20ton"); Ft20ton.Value = ft20ton;
            XmlAttribute Ft7ton = doc.CreateAttribute("ft7ton"); Ft7ton.Value = ft7ton;
            XmlAttribute Ft5ton = doc.CreateAttribute("ft5ton"); Ft5ton.Value = ft5ton;
            XmlAttribute Ft3ton = doc.CreateAttribute("ft3ton"); Ft3ton.Value = ft3ton;
            XmlAttribute Ft1andhalfton = doc.CreateAttribute("ft1andhalfton"); Ft1andhalfton.Value = ft1andhalfton;

            node.Attributes.Append(Reffid);
            node.Attributes.Append(Custid);
            node.Attributes.Append(Custname);
            node.Attributes.Append(Millage);
            node.Attributes.Append(Tripfare);
            node.Attributes.Append(Tfopentruck);
            node.Attributes.Append(Tfcoveredvan);
            node.Attributes.Append(Tfpickup);
            node.Attributes.Append(Tf10ton);
            node.Attributes.Append(Tf7ton);
            node.Attributes.Append(Tf5ton);
            node.Attributes.Append(Tf3ton);
            node.Attributes.Append(Tf1andhalfton);
            node.Attributes.Append(Bridgetoll);
            node.Attributes.Append(Bnrtoll20ton);
            node.Attributes.Append(Bnrtoll10ton);
            node.Attributes.Append(Bnrtoll7ton);
            node.Attributes.Append(Bnrtoll5ton);
            node.Attributes.Append(Bnrtoll3ton);
            node.Attributes.Append(Bnrtoll2ton);
            node.Attributes.Append(Bnrtoll1andhalfton);
            node.Attributes.Append(Ferrytoll);
            node.Attributes.Append(Ft20ton);
            node.Attributes.Append(Ft7ton);
            node.Attributes.Append(Ft5ton);
            node.Attributes.Append(Ft3ton);
            node.Attributes.Append(Ft1andhalfton);
            return node;
        }















    }
}