using HR_BLL.Employee;
using HR_BLL.Global;
using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class OvertimeUpdate : BasePage
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();
        string filePathForXML;
        string xmlString = "";
        int intCOAid; int RowIndex;
        protected decimal grandtotal = 0; protected decimal Grndothercost = 0;

        int enr;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Order/Data/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "overtimeUpdate.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";

                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }

            else
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    LoadFieldValue(searchKey[1]);
                    hdfSearchBoxTextChange.Value = "false";
                }
                else
                {
                    //ClearControls();
                }
            }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        private void LoadFieldValue(string empCode)
        {
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDT.Rows.Count > 0)
                    {
                        textEnrol.Text = empCode;
                        txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                        txtAplicnEnrol.Text = objDT.Rows[0]["intEmployeeID"].ToString();

                    }
                }
            }
            catch (Exception ex) { throw ex; }

            txtFullName.AutoPostBack = false;
        }

        private void loaddreport()
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = dteFromDate;
                    int enrol = int.Parse(txtAplicnEnrol.Text);
                    dt = bll.getRptOverTime(13, enrol, "", 0, dteFromDate, dteToDate, 0, 0);
                }

                catch { }

                if (dt.Rows.Count > 0)
                {

                    grdvOvertimePreviousData.DataSource = dt;
                    grdvOvertimePreviousData.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            loaddreport();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (hdnconfirm.Value == "1")
            //{
                string start = txtstrt.Text;
                string endt = txtend.Text;
                string durt = txtMovDuration.Text;
                double twentyfourhours = 24;
                TimeSpan interval = TimeSpan.FromHours(twentyfourhours);

                TimeSpan tmstart1 = TimeSpan.Parse(start.ToString());
                TimeSpan tmend1 = TimeSpan.Parse(endt.ToString());
                TimeSpan tmdur = TimeSpan.Parse(durt.ToString());



                int starthours = tmstart1.Hours;
                int endhours = tmend1.Hours;
                string starttime = starthours.ToString();
                string endtime = endhours.ToString();
                string starttime1 = Convert.ToString(tmstart1.ToString());
                string endtime1 = Convert.ToString(tmend1.ToString());
                DateTime dt1 = DateTime.ParseExact(starttime1, "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime dt2 = DateTime.ParseExact(endtime1, "HH:mm:ss", CultureInfo.InvariantCulture);
                string strBillDate = DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd");

                string strstarttime = (tmstart1.ToString());
                string strendtime = (tmend1.ToString());
                string strstar = starthours.ToString();
                string strendt = endhours.ToString();


                starttime1 = Convert.ToString(strstarttime.ToString());
                endtime1 = Convert.ToString(strendtime.ToString());
                DateTime dt11 = DateTime.ParseExact(starttime1, "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime dt12 = DateTime.ParseExact(endtime1, "HH:mm:ss", CultureInfo.InvariantCulture);


                DateTime dts = Convert.ToDateTime(dt11);
                DateTime dte = Convert.ToDateTime(dt12);
                TimeSpan diff;
                TimeSpan difff;
              
                if (endhours > starthours)
                {

                    diff = (Convert.ToDateTime(dte) - Convert.ToDateTime(dts));
                    string df = Convert.ToString(diff.ToString());
                    string tmDifferencehms = txtMovDuration.Text;
                    string tmDifferencehmswith = tmdur.ToString();
                    string aplenrol = txtAplicnEnrol.Text;
                    CreateVoucherXml(strBillDate, strstar, strendt, tmDifferencehms, strstarttime, strendtime, df, aplenrol);

                    #region ------------ Insert into dataBase -----------
                   

                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                    int BikeCarUserTypeid = 1;
                    HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                    int unit = Convert.ToInt32(HiddenUnit.Value);
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    int jobstation = Convert.ToInt32(hdnstation.Value);
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        //@type int, @actionby int, @xml xml, @id int, @dteOTDate date, @to date,@intjs int,@intUnit int
                    doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("OvertimeUpdate");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<OvertimeUpdate>" + xmlString + "</OvertimeUpdate>";
                        string message = bll.overtimeUpdation(xmlString, dteFromDate, enroll); ;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        loaddreport();
                    }
                    catch
                    {

                    }
                    #endregion ------------ Insertion End ----------------
                }
                else
                {
                    diff = Convert.ToDateTime(dts) - Convert.ToDateTime(dte);
                    difff = interval - diff;
                    string df = Convert.ToString(difff.ToString());
                    string tmDifferencehms = txtMovDuration.Text;
                    string tmDifferencehmswith = tmdur.ToString();
                     string aplenrol = txtAplicnEnrol.Text;
                     CreateVoucherXml(strBillDate, strstar, strendt, tmDifferencehms,  strstarttime, strendtime, df, aplenrol);

                     #region ------------ Insert into dataBase -----------


                     DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                     hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                     Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                     int BikeCarUserTypeid = 1;
                     HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                     int unit = Convert.ToInt32(HiddenUnit.Value);
                     hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                     int jobstation = Convert.ToInt32(hdnstation.Value);
                    
                    XmlDocument doc = new XmlDocument();
                     try
                     {

                         doc.Load(filePathForXML);
                         XmlNode dSftTm = doc.SelectSingleNode("OvertimeUpdate");
                         string xmlString = dSftTm.InnerXml;
                         xmlString = "<OvertimeUpdate>" + xmlString + "</OvertimeUpdate>";
                         string message = bll.overtimeUpdation(xmlString, dteFromDate, enroll); ;
                         ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                         loaddreport();
                     }
                     catch
                     {

                     }

                     #endregion ------------ Insertion End ----------------
                }

            }

        //}
        private void CreateVoucherXml(string BillDate, string starttime, string endtime, string MovDuration,  string txtstrtwihtHMS, string tmendwithHMS, string tmdifferencewithHMS,  string applicantenrol)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("OvertimeUpdate");
                XmlNode addItem = CreateItemNode(doc, BillDate, starttime, endtime, MovDuration,  txtstrtwihtHMS, tmendwithHMS, tmdifferencewithHMS,  applicantenrol);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("OvertimeUpdate");
                XmlNode addItem = CreateItemNode(doc, BillDate, starttime, endtime, MovDuration, txtstrtwihtHMS, tmendwithHMS, tmdifferencewithHMS, applicantenrol);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            //LoadGridwithXml();
            //Clear();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string BillDate, string starttime, string endtime, string MovDuration, string txtstrtwihtHMS, string tmendwithHMS, string tmdifferencewithHMS,  string applicantenrol)
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRBILLDATE = doc.CreateAttribute("BillDate");
            STRBILLDATE.Value = BillDate;

            XmlAttribute STARTTIME = doc.CreateAttribute("starttime");
            STARTTIME.Value = starttime;
            XmlAttribute ENDTIME = doc.CreateAttribute("endtime");
            ENDTIME.Value = endtime;
            XmlAttribute MOVDURATION = doc.CreateAttribute("MovDuration");
            MOVDURATION.Value = MovDuration;

           

            XmlAttribute txtstrtWITHHMS = doc.CreateAttribute("txtstrtwihtHMS");
            txtstrtWITHHMS.Value = txtstrtwihtHMS;

            XmlAttribute TMENDWITHHMS = doc.CreateAttribute("tmendwithHMS");
            TMENDWITHHMS.Value = tmendwithHMS;
            XmlAttribute TMDIFFERENCEWITHHMS = doc.CreateAttribute("tmdifferencewithHMS");
            TMDIFFERENCEWITHHMS.Value = tmdifferencewithHMS;

            
            XmlAttribute APPLICANTENROL = doc.CreateAttribute("applicantenrol");
            APPLICANTENROL.Value = applicantenrol;



            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(STARTTIME);
            node.Attributes.Append(ENDTIME);
            node.Attributes.Append(MOVDURATION);

           
            node.Attributes.Append(txtstrtWITHHMS);
            node.Attributes.Append(TMENDWITHHMS);
            node.Attributes.Append(TMDIFFERENCEWITHHMS);
            

            node.Attributes.Append(APPLICANTENROL);

            return node;
        }

        protected void grdvOvertimePreviousData_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOvertimePreviousData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

       
    }
}