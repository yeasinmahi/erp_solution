using HR_BLL.HolidayCalendar;
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

namespace UI.HR.OfficialMovement
{
    public partial class HolyDaySet : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        HolidaySetup bll = new HolidaySetup();
        bool ysnChecked;

      
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;

       

        decimal totalcom, selectedtotalcom = 0;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/HR/HolidayCalendar/Holiday/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + "_" + "holydayalljobs.xml");
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
               
                int unitid = Convert.ToInt32(ddlUnit.SelectedValue.ToString());
                dt = bll.getHolyDayAllJobs( unitid);
                if (dt.Rows.Count > 0)
                {
                    grdvHolyDayAllJobstation.DataSource = dt;
                    grdvHolyDayAllJobstation.DataBind();
                   

                  


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch (Exception ex) { }





        }

        #region ================ Generate XML and Others ==========        
        private void Createxml(string intReligionId, string intGroupID , string intJobTypeId , string intJobStationID)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Holydayalljobs");
                XmlNode addItem = CreateNode(doc, intReligionId,  intGroupID,  intJobTypeId,  intJobStationID);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Holydayalljobs");
                XmlNode addItem = CreateNode(doc, intReligionId, intGroupID, intJobTypeId, intJobStationID);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string intReligionId, string intGroupID, string intJobTypeId, string intJobStationID)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute IntReligionId = doc.CreateAttribute("intReligionId"); IntReligionId.Value = intReligionId;
            XmlAttribute IntGroupID = doc.CreateAttribute("intGroupID"); IntGroupID.Value = intGroupID;
            XmlAttribute IntJobTypeId = doc.CreateAttribute("intJobTypeId"); IntJobTypeId.Value = intJobTypeId;
            XmlAttribute IntJobStationID = doc.CreateAttribute("intJobStationID"); IntJobStationID.Value = intJobStationID;

            node.Attributes.Append(IntReligionId);
            node.Attributes.Append(IntGroupID);
            node.Attributes.Append(IntJobTypeId);
            node.Attributes.Append(IntJobStationID);

            return node;
        }
        #endregion

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvHolyDayAllJobstation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvHolyDayAllJobstation_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (grdvHolyDayAllJobstation.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvHolyDayAllJobstation.Rows.Count; index++)
                    {
                        if (((CheckBox)grdvHolyDayAllJobstation.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            
                            string intReligionId = ((HiddenField)grdvHolyDayAllJobstation.Rows[index].FindControl("hdnintReligionId")).Value.ToString();
                            string intGroupID = ((HiddenField)grdvHolyDayAllJobstation.Rows[index].FindControl("hdnintGroupID")).Value.ToString();
                            string intJobTypeId = ((HiddenField)grdvHolyDayAllJobstation.Rows[index].FindControl("hdnintJobTypeId")).Value.ToString();
                            string intJobStationID = ((HiddenField)grdvHolyDayAllJobstation.Rows[index].FindControl("hdnintJobStationID")).Value.ToString();
                           

                            Createxml(intReligionId, intGroupID, intJobTypeId, intJobStationID);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    enrol =int.Parse( HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                    int holydayid = int.Parse(ddlHoliday.SelectedValue.ToString());

                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("Holydayalljobs");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<Holydayalljobs>" + xmlString + "</Holydayalljobs>";
                    
                    string msg = bll.InsertAllJobInfo(xmlString, holydayid, enrol, dtFromDate, dtToDate);

                    try { File.Delete(xmlpath); } catch { }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);


                    #endregion ------------ Insertion End ----------------
                    grdvHolyDayAllJobstation.DataSource = "";
                    grdvHolyDayAllJobstation.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                }
                catch { File.Delete(xmlpath); }


            }
        }
    }
}