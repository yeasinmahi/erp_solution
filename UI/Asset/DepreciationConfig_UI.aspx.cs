using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Xml;
using UI.ClassFiles;
using System.Drawing;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.Asset
{
    public partial class DepreciationConfig_UI : BasePage
    {
        AssetMaintenance depconfig = new AssetMaintenance();
        AssetMaintenance rpt = new AssetMaintenance();
        DataTable dt = new DataTable();
        string filePathForXMLDEP;
        int intType;
        string XmlStringDEP= "";
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\DepreciationConfig_UI";
        string stop = "stopping Asset\\DepreciationConfig_UI";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMLDEP = Server.MapPath("~/Asset/Data/depc_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
        
            if(!IsPostBack)
            {
                try { File.Delete(filePathForXMLDEP); dgvGridView.DataSource = ""; dgvGridView.DataBind(); }
                catch { }
                dt = new DataTable();
                dt = depconfig.UnitName();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Name";
                ddlUnit.DataValueField = "ID";
                ddlUnit.DataBind();
                pnlUpperControl.DataBind();
                
                
               
            }
        }

       
      
        private void CreateVoucherXml(string coaid, string coacode, string depPercentge)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDEP))
            {
                doc.Load(filePathForXMLDEP);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodedep(doc, coaid, coacode, depPercentge);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodedep(doc, coaid, coacode, depPercentge);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDEP);
           
        }

       

        private XmlNode CreateItemNodedep(XmlDocument doc, string coaid, string coacode, string depPercentge)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Coaid = doc.CreateAttribute("coaid");
            Coaid.Value = coaid;
            XmlAttribute Coacode = doc.CreateAttribute("coacode");
            Coacode.Value = coacode;
            XmlAttribute DepPercentge = doc.CreateAttribute("depPercentge");
            DepPercentge.Value = depPercentge;


            node.Attributes.Append(Coaid);
            node.Attributes.Append(Coacode);
            node.Attributes.Append(DepPercentge);
            
           



            return node;
        }

        protected void BtnSumbit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\DepreciationConfig_UI Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string depPercentge;
            DateTime dtefrom = DateTime.Parse(TxtDteStart.Text.ToString());
            DateTime dteenddate = DateTime.Parse(TxtDteEnd.Text.ToString());
            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
            int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            dt = new DataTable();
            dt = depconfig.CheckDepreciation(5, 0, dtefrom, dteenddate, unitid, enroll);

            if (dt.Rows.Count>0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already Inserted');", true);


            }

            else
            {
                if (dgvGridView.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvGridView.Rows.Count; index++)
                    {


                        string coaid = ((Label)dgvGridView.Rows[index].FindControl("intGlobalCOA")).Text.ToString();
                        string coacode = ((Label)dgvGridView.Rows[index].FindControl("strCOACode")).Text.ToString();

                        depPercentge = ((TextBox)dgvGridView.Rows[index].FindControl("TxtPercentage")).Text.ToString();

                        if (depPercentge == "") { depPercentge = "0".ToString(); }



                        CreateVoucherXml(coaid, coacode, depPercentge);

                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDEP);
                        XmlNode dSftTm = doc.SelectSingleNode("voucher");
                        string XmlStringDEP = dSftTm.InnerXml;
                        XmlStringDEP = "<voucher>" + XmlStringDEP + "</voucher>";



                        intType = 2;
                        dt = new DataTable();
                        dt = depconfig.XmlDepcerationConfig(intType, XmlStringDEP, dtefrom, dteenddate, unitid, enroll);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["measeage"].ToString() + "');", true);

                        File.Delete(filePathForXMLDEP);





                    }


                }
            }

                dt = new DataTable();
                intType = 1;
                dt = depconfig.GlobalCOAView(intType, 0, dtefrom, dteenddate, unitid, 0);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
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
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var tes = (Label)e.Row.FindControl("intGlobalCOA");
               
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (tes.Text == "8888" || tes.Text == "9999")
                    {
                        cell.BackColor = Color.YellowGreen; 

                        if (tes.Text == "8888")
                        {
                           // e.Row.Cells[1].Text = "Administative Assets".ToString();
                            e.Row.Cells[5].Text = "Administative Assets".ToString();
                            //e.Row.Cells[6].Text = "".ToString();
                            //e.Row.Cells[0].Text = "".ToString();
                       
                            //cell.Text = "Administative Assets".ToString();
                        }
                        if (tes.Text == "9999") 
                        {
                           // e.Row.Cells[1].Text = "Manufacturing Assets".ToString();
                            e.Row.Cells[5].Text = "Manufacturing Assets".ToString();
                            //e.Row.Cells[6].Text = "".ToString();
                            //e.Row.Cells[0].Text = "".ToString();
                        }

                        //if (e.Row.Cells[1].Text == "Administative Assets")
                        

                    }
                    else
                    {
                        cell.BackColor = Color.Empty;
                    }
                }
            }


        }
        protected void BtnShow_Click(object sender, EventArgs e)
        {
            DateTime dtestart = DateTime.Parse(TxtDteStart.Text);
            DateTime dtesend = DateTime.Parse(TxtDteEnd.Text);
            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = new DataTable();
            intType = 1;
            dt = depconfig.GlobalCOAView(intType, 0, dtestart, dtesend, unitid, 0);
            dgvGridView.DataSource = dt;
            dgvGridView.DataBind();
        }

        protected void TxtDteStart_TextChanged(object sender, EventArgs e)
        {
            DateTime dtdate = DateTime.Parse(TxtDteStart.Text.ToString());
            DateTime nextdate = dtdate.AddYears(1);
            DateTime nextyear = nextdate.AddDays(-1);
            TxtDteEnd.Text = nextyear.ToString("yyyy-MM-dd");
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGridView.DataSource = "";
            dgvGridView.DataBind();
        }

        
    }
}