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

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class CollectionCommissionWithJV : System.Web.UI.Page
    {
    

        #region Global Variable
        DateTime fdate, tdate,createdate;
        int unitid, salesoffid, rptytypeid,  user, bankid;
        string commissioamount, xmlpath;
        DataTable dt = new DataTable();
        SalesView bll = new SalesView();
        decimal totalcom, selectedtotalcom = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + "_" + "remoteCommission.xml");
            if (!IsPostBack)
            {
                txtFromDate.Text = UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //txtFromDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                //txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
              
            }

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            fdate = Convert.ToDateTime( txtFromDate.Text);
            tdate = Convert.ToDateTime(txtToDate.Text);
            unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            salesoffid = int.Parse(ddlSo.SelectedValue.ToString());
            rptytypeid = int.Parse(drdlSalesview.SelectedValue.ToString());

            dt = bll.CollectionbaseCommission(fdate, tdate, unitid, salesoffid, rptytypeid);
            if (rptytypeid == 1)
            {

                dgrdvRegionalManagerCommission.DataSource = null;
                dgrdvRegionalManagerCommission.DataBind();
                grdvCollectionmoneyCommission.DataSource = dt;
                grdvCollectionmoneyCommission.DataBind();
                grdvCollectionmoneyCommission.FooterRow.Cells[3].Text = "total";
                grdvCollectionmoneyCommission.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                decimal txtTotalCommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("moncommission"));
                decimal totalcollection = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCollection"));
                grdvCollectionmoneyCommission.FooterRow.Cells[4].Text = totalcollection.ToString("N2");
                grdvCollectionmoneyCommission.FooterRow.Cells[5].Text = txtTotalCommission.ToString("N2");
              
                lblComamount.Text = Convert.ToString(txtTotalCommission);

                


            }

            else if (rptytypeid == 2)
            {
                grdvCollectionmoneyCommission.DataSource = null;
                grdvCollectionmoneyCommission.DataBind();
                dgrdvRegionalManagerCommission.DataSource = dt;
                dgrdvRegionalManagerCommission.DataBind();
                
            }

        }

        protected void btnJVCreation_Click(object sender, EventArgs e)
        {

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (grdvCollectionmoneyCommission.Rows.Count > 0)
            {
                for (int index = 0; index < grdvCollectionmoneyCommission.Rows.Count; index++)
                {
                    
                                if (((CheckBox)grdvCollectionmoneyCommission.Rows[index].FindControl("chkRow")).Checked == true)
                                {
                        
                        string employeenrol = ((HiddenField)grdvCollectionmoneyCommission.Rows[index].FindControl("hdnemplenrol")).Value.ToString();
                        string eachempnarration = "NO";
                        string eachemplamount = ((HiddenField)grdvCollectionmoneyCommission.Rows[index].FindControl("hdncommission")).Value.ToString();
                        string empname = ((HiddenField)grdvCollectionmoneyCommission.Rows[index].FindControl("hdnemplname")).Value.ToString();
                        selectedtotalcom = selectedtotalcom + decimal.Parse(eachemplamount);
                        string selectedgrand = Convert.ToString(selectedtotalcom);

                        Createxml(employeenrol, eachempnarration, eachemplamount, empname);
                    }
                }

                #region ------------ Insert into dataBase -----------
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                int bankid = int.Parse(ddlbank.SelectedValue.ToString());
                string unitname = drdlUnitName.SelectedItem.Text.ToString();
                DateTime dtinsdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtInstrumentDate.Text).Value;
                string glblnarration = unitname + " Commission from :" + txtFromDate.Text + "to " + txtToDate.Text;
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                totalcom = selectedtotalcom;

                int outstandingcoa = int.Parse(ddlOutstandingCOA.SelectedValue.ToString());
                int nonoutcoa = int.Parse(ddlcoa.SelectedValue.ToString());
                int sof = 0;
                int rptyp = 0;
               
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("RemoteCommission");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<RemoteCommission>" + xmlString + "</RemoteCommission>";
                dt = bll.insertionsalescommission(xmlString, dtFromDate, dtToDate, enrol, bankid, dtinsdate, unitid, totalcom, outstandingcoa, nonoutcoa, sof, rptyp);
                lblCreatedjvnumber.Text = dt.Rows[0]["creatjv"].ToString()+" "+dt.Rows[0]["createBP"].ToString();
                try { File.Delete(xmlpath); } catch { }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                #endregion ------------ Insertion End ----------------
                grdvCollectionmoneyCommission.DataSource = "";
                grdvCollectionmoneyCommission.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                    }
                }
                catch { File.Delete(xmlpath); }


            }



        }

        #region ================ Generate XML and Others ==========        
        private void Createxml(string emplenrol, string eachemplenarration, string eachemplamount, string emplname)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteCommission");
                XmlNode addItem = CreateNode(doc, emplenrol, eachemplenarration, eachemplamount, emplname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteCommission");
                XmlNode addItem = CreateNode(doc, emplenrol, eachemplenarration, eachemplamount, emplname);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string emplenrol, string eachemplenarration, string eachemplamount, string emplname)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Emplenrol = doc.CreateAttribute("emplenrol"); Emplenrol.Value = emplenrol;
            XmlAttribute Eachemplenarration = doc.CreateAttribute("eachemplenarration"); Eachemplenarration.Value = eachemplenarration;
            XmlAttribute Eachemplamount = doc.CreateAttribute("eachemplamount"); Eachemplamount.Value = eachemplamount;
            XmlAttribute Emplname = doc.CreateAttribute("emplname"); Emplname.Value = emplname;

            node.Attributes.Append(Emplenrol);
            node.Attributes.Append(Eachemplenarration);
            node.Attributes.Append(Eachemplamount);
            node.Attributes.Append(Emplname);

            return node;
        }
        #endregion


        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.UNIT_ID] = drdlUnitName.SelectedValue;
        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        
    }
}