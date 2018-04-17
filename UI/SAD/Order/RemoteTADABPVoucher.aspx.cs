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
    public partial class RemoteTADABPVoucher : BasePage
    {
        DataTable dt = new DataTable(); 
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        string totaltadabill; int bankid; int bankidinsteadofEmployeeid; int travelconveyid; int travelconveyididinsteadofemplid;

        string filepathforJVandBP; int reporttype; int rpttypeidinsteadofemplid;
        protected void Page_Load(object sender, EventArgs e)
        {
            filepathforJVandBP = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "createJVandBPForTADA.xml");

            if (!IsPostBack)
            {
                txtFromDate.Text = UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //txtFromDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                //txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnDepartment.Value = HttpContext.Current.Session[SessionParams.DEPT_ID].ToString();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                 int intDeptid=int.Parse( HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                 bankid = int.Parse(ddlPaymentFor.SelectedValue.ToString());
                 reporttype = int.Parse(ddlAccountReportType.SelectedValue.ToString());
                 travelconveyid = int.Parse(drdlTravelandconvey.SelectedValue.ToString());
                 
                int enr = int.Parse(hdnenrol);
                //if (intDeptid == 3 || intDeptid == 14 || intDeptid == 21 || intDeptid == 8 || intDeptid == 5)
                //{
                    //try
                    //{
                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                       
                        string Unit = (drdlUnit.SelectedValue.ToString());
                        int unit = int.Parse(Unit);
            

                        dt = bll.getrptforjvandbp(dteFromDate, dteToDate,travelconveyid , unit,reporttype );

                    //}

                    //catch
                    //{

                    //}

                    if (dt.Rows.Count > 0)
                    {

                       
                        grdvBPReport.DataSource = dt;
                        grdvBPReport.DataBind();
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

                //else
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                //}


            //}

        private void CreatexmlforJVAndBP( string strRowTotal, string strApplicantEnrolid)

        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            if (System.IO.File.Exists(filepathforJVandBP))
            {
                doc.Load(filepathforJVandBP);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("CreateJVandBPForTADA");
                XmlNode addItem = CreateItemNodeAuditTopSheetApprove(doc, strRowTotal, strApplicantEnrolid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CreateJVandBPForTADA");
                XmlNode addItem = CreateItemNodeAuditTopSheetApprove(doc, strRowTotal, strApplicantEnrolid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filepathforJVandBP);
        }


        private XmlNode CreateItemNodeAuditTopSheetApprove(XmlDocument doc, string strRowTotal, string strApplicantEnrolid)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute TOTALCOST = doc.CreateAttribute("strRowTotal");
            TOTALCOST.Value = strRowTotal;
            XmlAttribute APPLICANTENROL = doc.CreateAttribute("strApplicantEnrolid");
            APPLICANTENROL.Value = strApplicantEnrolid;
          
            node.Attributes.Append(TOTALCOST);
            node.Attributes.Append(APPLICANTENROL);
            return node;


        }






        protected void btnVoucherCreateallEmployee_Click(object sender, EventArgs e)
        {
            //string totalb = Convert.ToString(Session["ht"].ToString());


            decimal montotalbill = decimal.Parse(hdntotalAudit.Value)/2;
            decimal monBPAmount = decimal.Parse(hdntotalBP.Value)/2;
            string b = "1";
            bool ysnChecked; int rptTypeid;
            rptTypeid = 1;
            if (rptTypeid == 1)
            {

                if (grdvBPReport.Rows.Count > 0)
                {
                    
                    #region ------------ Insert into dataBase -----------


                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    DateTime dteinstrumentdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtInstrumentDate.Text).Value;
                    hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();

                    Int32 Approverenroll = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                    int bankid = int.Parse(ddlPaymentFor.SelectedValue.ToString());
                    int unit = int.Parse(drdlUnit.SelectedValue.ToString());
                    int travelconveycoaid = int.Parse(drdlTravelandconvey.SelectedValue.ToString());
                    decimal advancetotal = decimal.Parse(hdnadvancetotal.Value)/2;
                    decimal adjustableadv= decimal.Parse(hdnAdjustableadv.Value) / 2;
                    
                    string message = bll.InsertTADABPVoucher(dteFromDate, dteTodate, Approverenroll, bankid, dteinstrumentdate, unit, montotalbill, travelconveycoaid, adjustableadv);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    File.Delete(filepathforJVandBP);
                    #endregion ------------ Insertion End ----------------

                }
            
                grdvBPReport.DataBind();
         
            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
            }

        }

        protected void grdvBPReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected decimal totalCMAudit = 0, totalBPAmount = 0, totalAdvanceAmount=0,totaldecadjustableadvance=0;
        protected void grdvBPReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.Cells[4].FindControl("lblCMAuditt")).Text == "")
                { totalCMAudit += 0; }
                else { totalCMAudit += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblCMAuditt")).Text); }
                hdntotalAudit.Value = totalCMAudit.ToString();

                if (((Label)e.Row.Cells[6].FindControl("lbldecAdvanceAmount")).Text == "")
                { totalAdvanceAmount += 0; }
                else { totalAdvanceAmount += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lbldecAdvanceAmount")).Text); }
                hdnadvancetotal.Value = totalAdvanceAmount.ToString();

                if (((Label)e.Row.Cells[7].FindControl("lblBPAmount")).Text == "")
                { totalBPAmount += 0; }
                else { totalBPAmount += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblBPAmount")).Text); }
                hdntotalBP.Value = totalBPAmount.ToString();

                if (((Label)e.Row.Cells[8].FindControl("lbldecadjustableadvance")).Text == "")
                { totaldecadjustableadvance += 0; }
                else { totaldecadjustableadvance += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lbldecadjustableadvance")).Text); }
                hdnAdjustableadv.Value = totaldecadjustableadvance.ToString();
            }

        }

        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}