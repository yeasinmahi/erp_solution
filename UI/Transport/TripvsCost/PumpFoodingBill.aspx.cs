using HR_BLL.Employee;
using HR_BLL.Global;
using HR_BLL.TourPlan;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SAD_BLL.Consumer;
using UI.ClassFiles;
using Utility;

namespace UI.Transport.TripvsCost
{
    public partial class PumpFoodingBill : Page
    {
        private readonly TourPlanning _bll = new TourPlanning();
        private readonly SalesOrder _blso = new SalesOrder();
        private readonly StarConsumerEntryBll _consumerEntryBll = new StarConsumerEntryBll();
        private string _filePathForXml;
        protected decimal Grndothercost = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SAD/Order/Data/" + HttpContext.Current.Session[SessionParams.USER_ID] + "_" + "pumpFoodEntry.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                txtFullName.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";

                //SetUnitName(Int32.Parse(Session[SessionParams.USER_ID].ToString()));
                LoadUnitDropDown(Int32.Parse(Session[SessionParams.USER_ID].ToString()));
                LoadJobStationDropDown(GetUnitId(Int32.Parse(Session[SessionParams.USER_ID].ToString())));

                ////---------xml----------
                try { File.Delete(_filePathForXml); }
                catch
                {
                    // ignored
                }
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
                    var objDt = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDt.Rows.Count > 0)
                    {
                        textEnrol.Text = empCode;
                        txtDesignation.Text = objDt.Rows[0]["strDesignation"].ToString();
                        txtAplicnEnrol.Text = objDt.Rows[0]["intEmployeeID"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            txtFullName.AutoPostBack = false;
        }
        
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearchBll = new AutoSearch_BLL();
            var result = objAutoSearchBll.AutoSearchEmployeesData(//1399, 12, strSearchKey);
                int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session["jobStationId"].ToString()), strSearchKey);
            return result;
        }
        protected void btnAddBikeCarUser_Click(object sender, EventArgs e)
        {
            if (grdvOvertimeEntry.Rows.Count < 1)
            {
                string inTime = txtstrt.Text;
                string outTime = txtend.Text;

                TimeSpan inTimeSpan = TimeSpan.Parse(inTime);
                TimeSpan outTimeSpan = TimeSpan.Parse(outTime);
                TimeSpan diffTimeSpan = outTimeSpan.Subtract(inTimeSpan);

                string billDate = txtFromDate.Text;
                DateTime actionDateTime = DateTimeConverter.StringToDateTime(billDate, "yyyy-MM-dd");
                DateTime inDateTime = actionDateTime.Add(inTimeSpan);
                DateTime outDateTime = actionDateTime.Add(outTimeSpan);


                if (String.IsNullOrWhiteSpace(billDate))
                {

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                }
                else
                {
                    string cureentdate = DateTime.Now.ToString("yyyy-MM-dd");
                    DateTime today = Convert.ToDateTime(billDate);
                    DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)).AddDays(6);
                    DateTime dt3 = Convert.ToDateTime(endOfMonth);
                    DateTime dt4 = Convert.ToDateTime(cureentdate);
                    int diffbEomtodate = (dt3 - dt4).Days;

                    if (diffbEomtodate > 0)
                    {

                        if (billDate == string.Empty || billDate == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                        }
                        try
                        {
                            int enroll = Convert.ToInt32(txtAplicnEnrol.Text);
                            string tripNo = txttrip.Text;
                            string name = txtFullName.Text;
                            string address = lblSiteadr.Text;
                            string designation = txtDesignation.Text;
                            string totalBill = txtTotalBill.Text;

                            string message;
                            dynamic obj = new
                            {
                                intEnroll = enroll,
                                TripNo = tripNo,
                                strName = name,
                                strAddress = address,
                                strDesignation = designation,
                                monTotalBill = totalBill,
                                dteOutDate = outDateTime,
                                dteInDate = inDateTime,
                                dteStartTime = inTime,
                                dteEndTime = outTime,
                                dteTotalTime = diffTimeSpan

                            };

                            if (XmlParser.CreateXml("RemoteProgramBill", "items", obj, _filePathForXml, out message))
                            {
                                //nothing
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('XmlFile-- " + message + "');", true);
                            }
                        }
                        catch (Exception exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('insert all input properly. "+exception.Message+"');", true);
                        }
                        
                        LoadGridwithXml();
                        
                        //CreateVoucherXml(aplenrol,tripNo, name,address,designation,totalBill, strBillDate, strstar, strendt, tmDifferencehms);
                        
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' You can not add more than one row');", true);
            }


        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_filePathForXml);
                StringReader sr = new StringReader(doc.OuterXml);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdvOvertimeEntry.DataSource = ds;
                }
                else
                {
                    grdvOvertimeEntry.DataSource = "";
                }
                grdvOvertimeEntry.DataBind();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Error. "+ex.Message+"');", true);
            }
        }
        private void TotalBillCalculate()
        {
            string type = "Helper";

            if (type.Equals("helper"))
            {
                
            }
        }
        protected void btnSubmitBikeCar_Click(object sender, EventArgs e)
        {
            if (grdvOvertimeEntry.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------
                hdnApplicantEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                HiddenUnit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                int insertBy = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int unitId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                string billDate = txtFromDate.Text;
                DateTime billDateTime = Convert.ToDateTime(billDate);
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_filePathForXml);
                    _consumerEntryBll.FoodBiilingInfo(0, enroll, doc.OuterXml, billDateTime, billDateTime, unitId, insertBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Insert Successful');", true);
                }
                catch(Exception ex)
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Error. "+ex.Message+"');", true);
                }
                #endregion ------------ Insertion End ----------------

                //////////
            }
            grdvOvertimeEntry.DataBind();
            File.Delete(_filePathForXml);
            grdvOvertimeEntry.DataSource = "";
            grdvOvertimeEntry.DataBind();
        }
        
        protected void grdvOvertimeEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvOvertimeEntry.DataSource;
                dsGrid.Tables[0].Rows[grdvOvertimeEntry.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(_filePathForXml);
                DataSet dsGridAfterDelete = (DataSet)grdvOvertimeEntry.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(_filePathForXml); grdvOvertimeEntry.DataSource = ""; grdvOvertimeEntry.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Error. " + ex.Message + "');", true);
            }
        }
        
        //public void SetUnitName(int enrol)
        //{
        //    //bll.getUnitNamebyEnrol(369116).Rows[0][""].ToString();
        //    lblUnitName.Text = bll.GetUnitName(enrol).Rows[0]["strUnit"].ToString();
        //    hdUnitId.Value = bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString();
        //}
        public int GetUnitId(int enrol)
        {
            return Int32.Parse(_bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }
        public void LoadJobStationDropDown(int unitId)
        {
            ddlJobStation.DataSource = _bll.GetJobStation(unitId);
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataBind();
        }
        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.DataSource = _bll.GetUnitName(enrol);
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int unitId = Convert.ToInt32((sender as DropDownList)?.SelectedValue);
            LoadJobStationDropDown(unitId);
            ddlJobStation_SelectedIndexChanged(ddlJobStation, null);
        }

        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["jobStationId"] = (sender as DropDownList)?.SelectedValue;
        }
        //
        protected void txttrip_TextChanged(object sender, EventArgs e)
        {
            string tripcode = txttrip.Text;
            DataTable dt = _blso.getTripInfo(tripcode);
            lblSiteadr.Text = dt.Rows[0]["strAddress"].ToString();
            lblquntity.Text = dt.Rows[0]["strNarration"].ToString();

        }
    }
}