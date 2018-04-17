using SAD_BLL.Customer.Report;
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
    public partial class SalesCommissionwithJVCreation : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        StatementC bll = new StatementC();
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix,glblnarration,rptname,salesofficelike;

        
        decimal totalcom, selectedtotalcom=0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteCommission.xml");
            if (!IsPostBack)
            {
                try
                {
                    try { File.Delete(xmlpath); } catch { }
                    txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                    txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                    //pnlUpperControl.DataBind();
                    hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    hdnemail.Value = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    
                }
                catch { }
            }
        }

        #region =============== Insert Event Here =====================     

        protected void btnJVCreation_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                //try
                //{
                if (grdvCashDOCommission.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvCashDOCommission.Rows.Count; index++)
                    {
                       
                            if (((CheckBox)grdvCashDOCommission.Rows[index].FindControl("chkbx")).Checked == true)
                            {
                            //shopid,  customerid,  custterritoryid,  salesofficeid,  targetqnt
                            string customercoaid = ((HiddenField)grdvCashDOCommission.Rows[index].FindControl("hdncustcoaid")).Value.ToString();
                            string eachcustnarration = ((HiddenField)grdvCashDOCommission.Rows[index].FindControl("hdncustnarrationindividual")).Value.ToString();
                            string eachcustamount = ((HiddenField)grdvCashDOCommission.Rows[index].FindControl("hdncustomercommissionndividual")).Value.ToString();
                            string customername = ((HiddenField)grdvCashDOCommission.Rows[index].FindControl("hdncustname")).Value.ToString();
                            selectedtotalcom = selectedtotalcom + decimal.Parse(eachcustamount);
                            string selectedgrand = Convert.ToString(selectedtotalcom);

                            Createxml(customercoaid, eachcustnarration, eachcustamount, customername);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                    strVcode = "voucherJV";
                    strPrefix = "JV";
                    glblnarration = "ACCL Cash D.O Commission from :" + txtFromDate.Text + "to " + txtToDate.Text;
                    totalcom = selectedtotalcom;
                    //totalcom = Convert.ToDecimal(lbltotalcomamount.Text);
                    
                   enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intmainheadcoaid = 33855;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteCommission");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteCommission>" + xmlString + "</RemoteCommission>";
                    dt = bll.insertdataforsalescommissionjv(xmlString, unitid, strVcode, strPrefix, glblnarration, totalcom, enrol, intmainheadcoaid);
                    lblCreatedjvnumber.Text = dt.Rows[0]["creatjv"].ToString();
                    try { File.Delete(xmlpath); } catch { }
                  
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                    #endregion ------------ Insertion End ----------------
                    grdvCashDOCommission.DataSource = "";
                    grdvCashDOCommission.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                //}
                //catch { File.Delete(xmlpath); }


            }

        }

      
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                salesofficelike = drdlSalesOfficeType.SelectedItem.Text.ToString();
                rptname = drdlSalesview.SelectedItem.Text.ToString();

                dt = bll.getdataCashDOCommissionjv(dtFromDate, dtToDate, salesofficelike, rptname);
                if (dt.Rows.Count > 0)
                {
                    grdvCashDOCommission.DataSource = dt;
                    grdvCashDOCommission.DataBind();
                    decimal txtTotalCommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCashCommission1"));
                    decimal totaldelvqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decTotalDelv1"));
                    decimal totalcashdoqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decOnlyCashDOQnt1"));
                    lblTotalcom.Visible = true;
                    lbltotalcomamount.Text = Convert.ToString(txtTotalCommission);
                    lblTotalcashdoqnt.Visible = true;
                    lblcashdoqnt.Text = Convert.ToString(totalcashdoqnt);
                  

                    //txtTotalCommission = 

                    //grdvCashDOCommission.FooterRow.Cells[1].Text = "total";
                    //grdvCashDOCommission.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    //grdvCashDOCommission.FooterRow.Cells[5].Text = totalcashcom.ToString("N2");
                    //grdvCashDOCommission.FooterRow.Cells[4].Text = totaldelvqnt.ToString("N2");
                    //grdvCashDOCommission.FooterRow.Cells[3].Text = totalcashdoqnt.ToString("N2");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }
        }
        #endregion

        #region ================ Generate XML and Others ==========        
        private void Createxml(string customercoaid, string eachcustnarration, string eachcustamount, string customername)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteCommission");
                XmlNode addItem = CreateNode(doc, customercoaid,  eachcustnarration,  eachcustamount,  customername);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteCommission");
                XmlNode addItem = CreateNode(doc, customercoaid, eachcustnarration, eachcustamount, customername);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string customercoaid, string eachcustnarration, string eachcustamount, string customername)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Customercoaid = doc.CreateAttribute("customercoaid"); Customercoaid.Value = customercoaid;
            XmlAttribute Eachcustnarration = doc.CreateAttribute("eachcustnarration"); Eachcustnarration.Value = eachcustnarration;
            XmlAttribute Eachcustamount = doc.CreateAttribute("eachcustamount"); Eachcustamount.Value = eachcustamount;
            XmlAttribute Customername = doc.CreateAttribute("customername"); Customername.Value = customername;
           
            node.Attributes.Append(Customercoaid);
            node.Attributes.Append(Eachcustnarration);
            node.Attributes.Append(Eachcustamount);
            node.Attributes.Append(Customername);

            return node;
        }
        #endregion
     

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int unid = int.Parse(drdlUnitName.SelectedValue.ToString());
            dt = bll.getdataBrandMktProgramName(unid);
            drdlCommissionCatg.DataSource = dt;
            drdlCommissionCatg.DataTextField = "strProgramName";
            drdlCommissionCatg.DataValueField = "intProgramID";
            drdlCommissionCatg.DataBind();

        }

    

       

        protected void grdvCashDOCommission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvCashDOCommission_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void drdlUnitName_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

    }
}