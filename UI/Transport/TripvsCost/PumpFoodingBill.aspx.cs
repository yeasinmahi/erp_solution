using HR_BLL.Employee;
using HR_BLL.Global;
using HR_BLL.TourPlan;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Transport.TripvsCost
{
    public partial class PumpFoodingBill : System.Web.UI.Page
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;

        TourPlanning bll = new TourPlanning();
        SalesOrder blso = new SalesOrder();
        string filePathForXML;
        string xmlString = "";
        int intCOAid; int RowIndex;
        protected decimal grandtotal = 0; protected decimal Grndothercost = 0;

        int enr;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Order/Data/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "overtimeEntry.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";

                //SetUnitName(Int32.Parse(Session[SessionParams.USER_ID].ToString()));
                LoadUnitDropDown(Int32.Parse(Session[SessionParams.USER_ID].ToString()));
                LoadJobStationDropDown(GetUnitID(Int32.Parse(Session[SessionParams.USER_ID].ToString())));

                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }

            else
            {
                LoadEmployeeInfo();
            }
        }


        public void LoadEmployeeInfo()
        {
            if (!String.IsNullOrEmpty(txtFullName.Text))
            {
                string strSearchKey = txtFullName.Text;
                string[] searchKey = Regex.Split(strSearchKey, ",");
                if (searchKey.Length == 2)
                {
                    LoadFieldValue(searchKey[1]);
                }
                else
                {
                    return;
                }
                hdfSearchBoxTextChange.Value = "false";

            }
            else
            {
                //ClearControls();
            }
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


        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session["jobStationId"].ToString()), strSearchKey);
            return result;
        }


        private void CreateVoucherXml(string BillDate, string starttime, string endtime, string MovDuration, string purpouse, string purpouseid, string slNo, string txtstrtwihtHMS, string tmendwithHMS, string tmdifferencewithHMS, string remarks, string applicantenrol)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("OvertimeEntry");
                XmlNode addItem = CreateItemNode(doc, BillDate, starttime, endtime, MovDuration, purpouse, purpouseid, slNo, txtstrtwihtHMS, tmendwithHMS, tmdifferencewithHMS, remarks, applicantenrol);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("OvertimeEntry");
                XmlNode addItem = CreateItemNode(doc, BillDate, starttime, endtime, MovDuration, purpouse, purpouseid, slNo, txtstrtwihtHMS, tmendwithHMS, tmdifferencewithHMS, remarks, applicantenrol);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            Clear();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string BillDate, string starttime, string endtime, string MovDuration, string purpouse, string purpouseid, string slNo, string txtstrtwihtHMS, string tmendwithHMS, string tmdifferencewithHMS, string remarks, string applicantenrol)
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

            XmlAttribute SLNO = doc.CreateAttribute("slNo");
            SLNO.Value = slNo;
            XmlAttribute PURPOUSE = doc.CreateAttribute("purpouse");
            PURPOUSE.Value = purpouse;

            XmlAttribute PURPOUSEID = doc.CreateAttribute("purpouseid");
            PURPOUSEID.Value = purpouseid;

            XmlAttribute txtstrtWITHHMS = doc.CreateAttribute("txtstrtwihtHMS");
            txtstrtWITHHMS.Value = txtstrtwihtHMS;

            XmlAttribute TMENDWITHHMS = doc.CreateAttribute("tmendwithHMS");
            TMENDWITHHMS.Value = tmendwithHMS;
            XmlAttribute TMDIFFERENCEWITHHMS = doc.CreateAttribute("tmdifferencewithHMS");
            TMDIFFERENCEWITHHMS.Value = tmdifferencewithHMS;

            XmlAttribute REMARKS = doc.CreateAttribute("remarks");
            REMARKS.Value = remarks;
            XmlAttribute APPLICANTENROL = doc.CreateAttribute("applicantenrol");
            APPLICANTENROL.Value = applicantenrol;



            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(STARTTIME);
            node.Attributes.Append(ENDTIME);
            node.Attributes.Append(MOVDURATION);

            node.Attributes.Append(SLNO);
            node.Attributes.Append(PURPOUSE);
            node.Attributes.Append(PURPOUSEID);
            node.Attributes.Append(txtstrtWITHHMS);
            node.Attributes.Append(TMENDWITHHMS);
            node.Attributes.Append(TMDIFFERENCEWITHHMS);
            node.Attributes.Append(REMARKS);

            node.Attributes.Append(APPLICANTENROL);

            return node;
        }

        private void Clear()
        {


            txtMovDuration.Text = "";

        }
        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("OvertimeEntry");
                xmlString = dSftTm.InnerXml;
                xmlString = "<OvertimeEntry>" + xmlString + "</OvertimeEntry>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { grdvOvertimeEntry.DataSource = ds; }
                else { grdvOvertimeEntry.DataSource = ""; }
                grdvOvertimeEntry.DataBind();
            }
            catch { }

        }



        protected void btnAddBikeCarUser_Click(object sender, EventArgs e)
        {
            if (grdvOvertimeEntry.Rows.Count < 1)
            {
                string durt = txtMovDuration.Text;
                string start = txtstrt.Text;
                string endt = txtend.Text;

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



                string MovDuration = txtMovDuration.Text;
                string Serial;
                string BillDate = txtFromDate.Text;


                if (BillDate == string.Empty || BillDate == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                }


                else
                {
                    string cureentdate = DateTime.Now.ToString("yyyy-MM-dd");
                    var now = DateTime.Now;
                    var startOfMonth = new DateTime(now.Year, now.Month, 1);
                    var DaysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                    var lastDay = new DateTime(now.Year, now.Month, DaysInMonth).AddDays(6);
                    string lastd = lastDay.ToString("yyyy-MM-dd");
                    DateTime today = Convert.ToDateTime(BillDate);
                    DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)).AddDays(6);
                    DateTime dt3 = Convert.ToDateTime(endOfMonth);
                    DateTime dt4 = Convert.ToDateTime(cureentdate);
                    int diffbEOMTODATE = (dt3 - dt4).Days;

                    if (diffbEOMTODATE > 0)
                    {

                        if (BillDate == string.Empty || BillDate == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                        }
                        else if (true/*selectvalue == 0*/)
                        {
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
                            string df;
                            if (endhours < starthours)
                            {
                                diff = Convert.ToDateTime(dts) - Convert.ToDateTime(dte);
                                difff = interval - diff;
                                df = Convert.ToString(difff.ToString());
                            }
                            else
                            {
                                diff = (Convert.ToDateTime(dte) - Convert.ToDateTime(dts));
                                df = Convert.ToString(diff.ToString());
                            }


                            string tmDifferencehms = tmdur.ToString();
                            tmDifferencehms = "0";




                            string tmDifferencehmswith = tmdur.ToString();

                            string strpur = drdlPurpouse.SelectedItem.Text;
                            string strpurid = drdlPurpouse.SelectedValue.ToString();
                            string remk = txtRemarks.Text;
                            string aplenrol = txtAplicnEnrol.Text;


                            Serial = "1";

                            CreateVoucherXml(strBillDate, strstar, strendt, tmDifferencehms, strpur, strpurid, Serial, strstarttime, strendtime, df, remk, aplenrol);



                        }



                        else
                        {

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

                                string strpur = drdlPurpouse.SelectedItem.Text;
                                string strpurid = drdlPurpouse.SelectedValue.ToString();
                                string remk = txtRemarks.Text;
                                string aplenrol = txtAplicnEnrol.Text;


                                Serial = "1";

                                CreateVoucherXml(strBillDate, strstar, strendt, tmDifferencehms, strpur, strpurid, Serial, strstarttime, strendtime, df, remk, aplenrol);

                            }
                            else
                            {
                                diff = Convert.ToDateTime(dts) - Convert.ToDateTime(dte);
                                difff = interval - diff;
                                string df = Convert.ToString(difff.ToString());


                                string tmDifferencehms = txtMovDuration.Text;
                                string tmDifferencehmswith = tmdur.ToString();

                                string strpur = drdlPurpouse.SelectedItem.Text;
                                string strpurid = drdlPurpouse.SelectedValue.ToString();
                                string remk = txtRemarks.Text;
                                string aplenrol = txtAplicnEnrol.Text;


                                Serial = "1";

                                CreateVoucherXml(strBillDate, strstar, strendt, tmDifferencehms, strpur, strpurid, Serial, strstarttime, strendtime, df, remk, aplenrol);
                            }


                        }

                    }

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' You can not add more than one row');", true);
            }


        }


       

       
        protected void btnSubmitBikeCar_Click(object sender, EventArgs e)
        {
            if (grdvOvertimeEntry.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------
                string host = Dns.GetHostName();
                IPHostEntry ip = Dns.GetHostEntry(host);
                string ipaddress = (ip.AddressList[1].ToString());

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
                    XmlNode dSftTm = doc.SelectSingleNode("OvertimeEntry");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<OvertimeEntry>" + xmlString + "</OvertimeEntry>";
                    string message = bll.overtimeInsertion(xmlString, dteFromDate, enroll, ipaddress);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }



                #endregion ------------ Insertion End ----------------


            }
            grdvOvertimeEntry.DataBind();
            File.Delete(filePathForXML);
            grdvOvertimeEntry.DataSource = "";
            grdvOvertimeEntry.DataBind();
        }

        protected void grdvOvertimeEntry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvOvertimeEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvOvertimeEntry.DataSource;
                dsGrid.Tables[0].Rows[grdvOvertimeEntry.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)grdvOvertimeEntry.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); grdvOvertimeEntry.DataSource = ""; grdvOvertimeEntry.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void rdbOTType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //public void SetUnitName(int enrol)
        //{
        //    //bll.getUnitNamebyEnrol(369116).Rows[0][""].ToString();
        //    lblUnitName.Text = bll.GetUnitName(enrol).Rows[0]["strUnit"].ToString();
        //    hdUnitId.Value = bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString();
        //}
        public int GetUnitID(int enrol)
        {
            return Int32.Parse(bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }
        public void LoadJobStationDropDown(int unitId)
        {
            ddlJobStation.DataSource = bll.GetJobStation(unitId);
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataBind();
        }
        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.DataSource = bll.GetUnitName(enrol);
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }

        protected void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int unitId = Convert.ToInt32((sender as DropDownList).SelectedValue);
            LoadJobStationDropDown(unitId);
            ddlJobStation_SelectedIndexChanged(ddlJobStation, null);
        }

        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["jobStationId"] = (sender as DropDownList).SelectedValue;
        }

        protected void txttrip_TextChanged(object sender, EventArgs e)
        {
            string tripcode = txttrip.Text.ToString();
            DataTable dt = new DataTable();
            dt = blso.getTripInfo(tripcode);
            lblSiteadr.Text = dt.Rows[0]["strAddress"].ToString();
            lblquntity.Text = dt.Rows[0]["strNarration"].ToString();

        }
    }
}