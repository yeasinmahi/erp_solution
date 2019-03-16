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
    public partial class VehicleInfoUpdate : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Transport";
        string start = "starting Transport/InternalTransportRouteExpIn.aspx";
        string stop = "stopping Transport/InternalTransportRouteExpIn.aspx";

        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intUnitID;
        //int intShipPointID;
        //int intReffID;
        int intInsertBy;
        string xml;
        string filePathForXMLCustWiseCost;
        string xmlStringCustWiseCost = "";

        string id; string RegNo; string Type; string TypeId; string DriverEnroll; string EmployeeName;
        string driverDA; string helper; string helperDA; string TripBonus; string DieselPerKM; string DieselPerKMOutStation;
        string CNGPerKM; string CNGPerKMOutStation; string DownTripDA; string CNGAllowance; string MillageAllow100KM;
        string MillageAllow100KMAbove; string MillageAllowanceLocal; string MillageAllowanceOutStation; 

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

                    CustomerWiseRouteCost();
                    
                }
                catch
                {

                }
            }
            else
            {

            }
            filePathForXMLCustWiseCost = Server.MapPath("~/Transport/Data/CustWiseCost_" + hdnEnroll.Value + ".xml");

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerWiseRouteCost();
        }
        private void CustomerWiseRouteCost()
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = new DataTable();
            dt = obj.GetVechicleInfoupdate(intUnitID);
            dgvTripWiseCustomer.DataSource = dt;
            dgvTripWiseCustomer.DataBind();
            

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

                        id = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblid")).Text.ToString();
                        RegNo = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblRegNo")).Text.ToString();
                        Type = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblType")).Text.ToString();
                        TypeId = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblTypeId")).Text.ToString();
                        DriverEnroll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtDriverEnroll")).Text.ToString();
                        EmployeeName = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtEmployeeName")).Text.ToString();
                        driverDA = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtdriverDA")).Text.ToString();
                        helper = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txthelper")).Text.ToString();
                        helperDA = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txthelperDA")).Text.ToString();
                        TripBonus = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTripBonus")).Text.ToString();
                        DieselPerKM = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtDieselPerKM")).Text.ToString();
                        DieselPerKMOutStation = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtDieselPerKMOutStation")).Text.ToString();
                        CNGPerKM = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtCNGPerKM")).Text.ToString();
                        CNGPerKMOutStation = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtCNGPerKMOutStation")).Text.ToString();
                        DownTripDA = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtDownTripDA")).Text.ToString();
                        CNGAllowance = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtCNGAllowance")).Text.ToString();
                        MillageAllow100KM = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageAllow100KM")).Text.ToString();
                        MillageAllow100KMAbove = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageAllow100KMAbove")).Text.ToString();
                        MillageAllowanceLocal = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageAllowanceLocal")).Text.ToString();
                   
                        CreateVoucherXmlCustWiseCost(id, RegNo, Type, TypeId, DriverEnroll, EmployeeName, driverDA, helper, helperDA, TripBonus, DieselPerKM, DieselPerKMOutStation, CNGPerKM, CNGPerKMOutStation, DownTripDA, CNGAllowance, MillageAllow100KM, MillageAllow100KMAbove, MillageAllowanceLocal, MillageAllowanceOutStation);
                       

                    }

                    if (dgvTripWiseCustomer.Rows.Count > 0)
                    {
                        try
                        {
                            
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

                    //intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //Final Update
                    string msg = obj.UpdateVehicleInfoData(intUnitID, intInsertBy, xml);

                    if (filePathForXMLCustWiseCost != null)
                    { File.Delete(filePathForXMLCustWiseCost); }
                    dgvTripWiseCustomer.DataSource = "";
                    dgvTripWiseCustomer.DataBind();

                    CustomerWiseRouteCost();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    //Show Report By Trip Sl End

                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void CreateVoucherXmlCustWiseCost(string id, string regNo, string type, string TypeId, string driverEnroll, string employeeName, string driverDA, string helper, string helperDA, string tripBonus, string dieselPerKM, string dieselPerKMOutStation, string cNGPerKM, string cNGPerKMOutStation, string downTripDA, string cNGAllowance, string millageAllow100KM, string millageAllow100KMAbove, string millageAllowanceLocal, string millageAllowanceOutStation)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLCustWiseCost))
            {
                doc.Load(filePathForXMLCustWiseCost);
                XmlNode rootNode = doc.SelectSingleNode("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, id, RegNo, Type, TypeId, DriverEnroll, EmployeeName, driverDA, helper, helperDA, TripBonus, DieselPerKM, DieselPerKMOutStation, CNGPerKM, CNGPerKMOutStation, DownTripDA, CNGAllowance, MillageAllow100KM, MillageAllow100KMAbove, MillageAllowanceLocal, MillageAllowanceOutStation);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, id, RegNo, Type, TypeId, DriverEnroll, EmployeeName, driverDA, helper, helperDA, TripBonus, DieselPerKM, DieselPerKMOutStation, CNGPerKM, CNGPerKMOutStation, DownTripDA, CNGAllowance, MillageAllow100KM, MillageAllow100KMAbove, MillageAllowanceLocal, MillageAllowanceOutStation);
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

        private XmlNode CreateItemNodeCustWiseCost(XmlDocument doc, string Id, string regNo, string type, string typeId, string driverEnroll, string employeeName, string driverda, string Helper, string helperda, 
            string tripBonus, string dieselPerKM, string dieselPerKMOutStation, string cNGPerKM, string cNGPerKMOutStation, string downTripDA, string cNGAllowance, string millageAllow100KM, 
            string millageAllow100KMAbove, string millageAllowanceLocal, string millageAllowanceOutStation)
        {
            XmlNode node = doc.CreateElement("CustWiseCost");

       
            XmlAttribute id = doc.CreateAttribute("id"); id.Value = Id;
            XmlAttribute RegNo = doc.CreateAttribute("regno"); RegNo.Value = regNo;
            XmlAttribute Type = doc.CreateAttribute("type"); Type.Value = type;
            XmlAttribute TypeId = doc.CreateAttribute("typeid"); TypeId.Value = typeId;
            XmlAttribute DriverEnroll = doc.CreateAttribute("DriverEnroll"); DriverEnroll.Value = driverEnroll;
            XmlAttribute EmployeeName = doc.CreateAttribute("EmployeeName"); EmployeeName.Value = employeeName;
            XmlAttribute driverDA = doc.CreateAttribute("driverDA"); driverDA.Value = driverda;
            XmlAttribute helper = doc.CreateAttribute("helper"); helper.Value = Helper;
            XmlAttribute helperDA = doc.CreateAttribute("helperDA"); helperDA.Value = helperda;
            XmlAttribute TripBonus = doc.CreateAttribute("monTripBonus"); TripBonus.Value = tripBonus;
            XmlAttribute DieselPerKM = doc.CreateAttribute("monDieselPerKM"); DieselPerKM.Value = dieselPerKM;
            XmlAttribute DieselPerKMOutStation = doc.CreateAttribute("monDieselPerKMOutStation"); DieselPerKMOutStation.Value = dieselPerKMOutStation;
            XmlAttribute CNGPerKM = doc.CreateAttribute("monCNGPerKM"); CNGPerKM.Value = cNGPerKM;
            XmlAttribute CNGPerKMOutStation = doc.CreateAttribute("monCNGPerKMOutStation"); CNGPerKMOutStation.Value = cNGPerKMOutStation;
            XmlAttribute DownTripDA = doc.CreateAttribute("DownTripDA"); DownTripDA.Value = downTripDA;
            XmlAttribute CNGAllowance = doc.CreateAttribute("monCNGAllowance"); CNGAllowance.Value = cNGAllowance;
            XmlAttribute MillageAllow100KM = doc.CreateAttribute("monMillageAllow100KM"); MillageAllow100KM.Value = millageAllow100KM;
            XmlAttribute MillageAllow100KMAbove = doc.CreateAttribute("monMillageAllow100KMAbove"); MillageAllow100KMAbove.Value = millageAllow100KMAbove;
            XmlAttribute MillageAllowanceLocal = doc.CreateAttribute("monMillageAllowanceLocal"); MillageAllowanceLocal.Value = millageAllowanceLocal;
            XmlAttribute MillageAllowanceOutStation = doc.CreateAttribute("monMillageAllowanceOutStation"); MillageAllowanceOutStation.Value = millageAllowanceOutStation;


            node.Attributes.Append(id);
            node.Attributes.Append(RegNo);
            node.Attributes.Append(Type);
            node.Attributes.Append(TypeId);
            node.Attributes.Append(DriverEnroll);
            node.Attributes.Append(EmployeeName);
            node.Attributes.Append(driverDA);
            node.Attributes.Append(helper);
            node.Attributes.Append(helperDA);
            node.Attributes.Append(DieselPerKM);
            node.Attributes.Append(DieselPerKMOutStation);
            node.Attributes.Append(CNGPerKM);
            node.Attributes.Append(CNGPerKMOutStation);
            node.Attributes.Append(DownTripDA);
            node.Attributes.Append(CNGAllowance);
            node.Attributes.Append(MillageAllow100KM);
            node.Attributes.Append(MillageAllow100KMAbove);
            node.Attributes.Append(MillageAllowanceLocal);
            node.Attributes.Append(MillageAllowanceOutStation);
            return node;
        }

    }
}