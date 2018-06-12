using SAD_BLL.Customer;
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

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class AreaBaseCustomerTarget : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int unitid, teritoryid, areaid, regionid, shippoint, salesoffice, rpttype,intsertby;
        decimal gtotaldoqnt, gtotaldoamount, gtotalchlqnt, gtotalchamount, gpendingqnt, gpendingamount;

        

        DateTime fromdate, todate;

       

        CustomerInfo bll = new CustomerInfo();
        DataTable dt = new DataTable();
        string xmlpath, email, strSearchKey, code, strCustname;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "customertarget.xml");
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
            try
            {
                fromdate = DateTime.Parse(txtFromDate.Text);
                todate = DateTime.Parse(txtToDate.Text);
                teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                areaid = int.Parse(drdlArea.SelectedValue.ToString());
                regionid = int.Parse(drdlRegionName.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                salesoffice= int.Parse(ddlSo.SelectedValue.ToString());
                rpttype = int.Parse(drdlrpttype.SelectedValue.ToString());
                intsertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (rpttype ==1)
                {
                    dt = bll.getdataCustomerMonthlyTarget(unitid, areaid, fromdate, todate, rpttype, salesoffice, "", intsertby);
                    if (dt.Rows.Count > 0)
                    {
                        grdvTargetinserted.DataSource = null;
                        grdvTargetinserted.DataBind();
                        grdvCustomerTarget.DataSource = dt;
                        grdvCustomerTarget.DataBind();
                        
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }

              else  if (rpttype == 3)
                {
                    dt = bll.getdataCustomerMonthlyTarget(unitid, areaid, fromdate, todate, rpttype, salesoffice, "", intsertby);
                    if (dt.Rows.Count > 0)
                    {
                        grdvCustomerTarget.DataSource = null;
                        grdvCustomerTarget.DataBind();
                        grdvTargetinserted.DataSource = dt;
                        grdvTargetinserted.DataBind();

                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }

            }
            catch (Exception ex)
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                fromdate = DateTime.Parse(txtFromDate.Text);
                todate = DateTime.Parse(txtToDate.Text);
                teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                areaid = int.Parse(drdlArea.SelectedValue.ToString());
                regionid = int.Parse(drdlRegionName.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                rpttype = int.Parse(drdlrpttype.SelectedValue.ToString());
                intsertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                //try
                //{
                if (grdvCustomerTarget.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvCustomerTarget.Rows.Count; index++)
                    {
                        if (((CheckBox)grdvCustomerTarget.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            //territoryid, custname, custid, targetqnt, areaid, salesofficeid
                            string territoryid = ((HiddenField)grdvCustomerTarget.Rows[index].FindControl("hdnTerritoryid")).Value.ToString();
                            string custname = ((HiddenField)grdvCustomerTarget.Rows[index].FindControl("hdncustname")).Value.ToString();
                            string custid = ((HiddenField)grdvCustomerTarget.Rows[index].FindControl("hdnCustomerID")).Value.ToString();
                            string areaid = ((HiddenField)grdvCustomerTarget.Rows[index].FindControl("hdnAreaid")).Value.ToString();
                            string salesofficeid = ((HiddenField)grdvCustomerTarget.Rows[index].FindControl("hdnSalesoffid")).Value.ToString();
                            TextBox txttarget = (TextBox)grdvCustomerTarget.Rows[index].Cells[4].FindControl("txtdecTarget");
                            string targetqnt = txttarget.Text;
                            Createxml(territoryid, custname, custid, targetqnt, areaid, salesofficeid);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                    email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("Customertarget");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<Customertarget>" + xmlString + "</Customertarget>";
                    dt = bll.getdataCustomerMonthlyTarget(unitid, areaid, fromdate, todate, rpttype, salesoffice, xmlString, intsertby);
                    try { File.Delete(xmlpath); } catch { }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                    #endregion ------------ Insertion End ----------------
                    grdvCustomerTarget.DataSource = "";
                    grdvCustomerTarget.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                //}
                //catch { File.Delete(xmlpath); }


            }
        }
        //intSOID,strName,intCustomerID,intTarget,dteFormdate,dteTodate,dteActiondate,intParent

        #region ================ Generate XML and Others ==========        
        private void Createxml(string territoryid, string custname, string custid, string targetqnt, string areaid, string salesofficeid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Customertarget");
                XmlNode addItem = CreateNode(doc, territoryid, custname, custid, targetqnt, areaid, salesofficeid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Customertarget");
                XmlNode addItem = CreateNode(doc, territoryid, custname, custid, targetqnt, areaid, salesofficeid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string territoryid, string custname, string custid, string targetqnt, string areaid,string salesofficeid)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Territoryid = doc.CreateAttribute("territoryid");Territoryid.Value = territoryid;
            XmlAttribute Custname = doc.CreateAttribute("custname"); Custname.Value = custname;
            XmlAttribute Custid = doc.CreateAttribute("custid"); Custid.Value = custid;
            
            XmlAttribute Targetqnt = doc.CreateAttribute("targetqnt"); Targetqnt.Value = targetqnt;
            XmlAttribute Areaid = doc.CreateAttribute("areaid"); Areaid.Value = areaid;
            XmlAttribute Salesofficeid = doc.CreateAttribute("salesofficeid"); Salesofficeid.Value = salesofficeid;
            node.Attributes.Append(Territoryid);
            node.Attributes.Append(Custname);
            node.Attributes.Append(Custid);
            
            node.Attributes.Append(Targetqnt);
            node.Attributes.Append(Areaid);
            node.Attributes.Append(Salesofficeid);
            
            return node;
        }
        #endregion

        #endregion
        #region change event
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdvCustomerTarget_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdvTargetinserted_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        #endregion
    }
}