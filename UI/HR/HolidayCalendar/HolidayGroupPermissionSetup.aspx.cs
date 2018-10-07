using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using HR_BLL.HolidayCalendar;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.HR.HolidayCalendar
{
    public partial class HolidayGroupPermissionSetup : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/HolidayCalendar/HolidayGroupPermissionSetup.aspx";
        string stop = "stopping HR/HolidayCalendar/HolidayGroupPermissionSetup.aspx";

        #region Declare Variable
        HolidayGroupPermission objHolidayGroupPermission;
        bool flag = false;//flag is uesed to define xml is empty or not and it's value will be changed due to create xml 
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/HolidayCalendar/HolidayGroupPermissionSetup.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            //Summary    :   THIS FUNCTION IS USED FOR SET PRIMARY ATTRIBUTE FOR THE CONTROLS AND LOAD INITIAL VALUES
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   GET USER ID FROM SESSION 

            if (!IsPostBack)
            {
                hdnUserId.Value = "1056";//Session[SessionParams.USER_ID].ToString();
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();
                pnlUpperControl.DataBind();
                btnAdd.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnAdd).ToString());
                btnEdit.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnEdit).ToString());
                LinkButton1.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(LinkButton1).ToString());
                LinkButton1.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='RoyalBlue';");
                LinkButton1.Attributes.Add("onmouseout", "this.style.textDecoration='none';this.style.color='white';");
                LinkButton1.Style.Add("cursor", "pointer");
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert Holiday data
            //Created    :   Md. Yeasir Arafat / May-14-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,holidayPermission as xml ,and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdnUserId.Value.ToString()))
                {
                    string strXmlData = ConstructXmlData();
                    if (flag)
                    {
                        objHolidayGroupPermission = new HolidayGroupPermission();
                        string insertStatus = objHolidayGroupPermission.InsertHolidayGroupPermission(int.Parse(hdnUserId.Value), strXmlData);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                        RefreshPage(sender, e);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO REDIRECT THE CURRENT FORM TO THE HOLIDAY UPDATE PAGE
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            Response.Redirect("~/HR/HolidayCalendar/HolidayGroupPermissionUpdate.aspx");
            //Server.Transfer("~/HR/HolidayCalendar/HolidayGroupPermissionUpdate.aspx");
        }

        protected void dgvHolliday_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / May-14-2012
            //Modified   :   
            //Parameters : 
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvHolliday, "Select$" + e.Row.RowIndex);
                    e.Row.Style.Add("cursor", "pointer");
                }
            }
            catch { }
        }

        private void RefreshPage(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO REFREASH ALL THE WEB CONTROLLS LIKE FIRST TIME LOAD
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            try
            {
                dgvHolliday.DataBind();

                if (ddlHolidayName.Items.Count > 0) ddlHolidayName.SelectedIndex = 0;
                txtFromDate.Text = DateTime.Now.ToShortDateString();
                txtToDate.Text = DateTime.Now.ToShortDateString();

                //hdnReligionID.Value = "";
                //hdnJobstationID.Value = "";
                //hdnHolidayId.Value = "";
                //hdnGroupID.Value = "";

                chkAllGroup.Checked = false;
                chkAllJobstation.Checked = false;
                chkAllReligion.Checked = false;
                chkAllJobType.Checked = false;

                chkAllGroup_CheckedChanged(sender, e);
                chkAllJobstation_CheckedChanged(sender, e);
                chkAllReligion_CheckedChanged(sender, e);
                chkAllJobType_CheckedChanged(sender, e);
            }
            catch { }
        }

        private string ConstructXmlData()
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CREATE XML DATA ACORDING TO THE SELECTION
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   RETURN XML STRING


            StringWriter stringWriter = null;
            XmlTextWriter writer = null;
            //XmlWriter writer = XmlWriter.Create("holiday.xml");
            try
            {

                stringWriter = new StringWriter(new StringBuilder());
                writer = new XmlTextWriter(stringWriter);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteComment("Holiday Info");

                writer.WriteStartElement("holidayInfo", "");
                #region Start Count number Of group
                int numberOfGroup = 0;
                if (chkAllGroup.Checked)
                {
                    numberOfGroup = chkGroupList.Items.Count;
                }
                else
                {
                    foreach (ListItem listitem in chkGroupList.Items)
                    {
                        if (listitem.Selected)
                        {
                            numberOfGroup++;
                        }
                    }
                }

                #endregion
                #region Start Count number Of Religion
                int numberOfReligion = 0;
                if (chkAllReligion.Checked)
                {
                    numberOfReligion = chkReligionList.Items.Count;
                }
                else
                {
                    foreach (ListItem listitem in chkReligionList.Items)
                    {
                        if (listitem.Selected)
                        {
                            numberOfReligion++;
                        }
                    }
                }
                #endregion

                #region Start Count number Of Selected JobType
                int numberOfJobTypeSelected = 0;
                if (chkAllJobType.Checked)
                {
                    numberOfJobTypeSelected = chkJobtypeList.Items.Count;
                }
                else
                {
                    foreach (ListItem listitem in chkJobtypeList.Items)
                    {
                        if (listitem.Selected)
                        {
                            numberOfJobTypeSelected++;
                        }
                    }
                }
                #endregion
                #region Start Count number Of JobStation
                int numberOfJobStation = 0;
                if (chkAllJobstation.Checked)
                {
                    numberOfJobStation = chkJobStationList.Items.Count;
                }
                else
                {
                    foreach (ListItem listitem in chkJobStationList.Items)
                    {
                        if (listitem.Selected)
                        {
                            numberOfJobStation++;
                        }
                    }
                }
                #endregion
                #region Create Xml
                for (int groupIndex = 0; groupIndex < numberOfGroup; groupIndex++)
                {
                    for (int religionIndex = 0; religionIndex < numberOfReligion; religionIndex++)
                    {
                        for (int jobTypeIndex = 0; jobTypeIndex < numberOfJobTypeSelected; jobTypeIndex++)
                        {
                            for (int jobStationIndex = 0; jobStationIndex < numberOfJobStation; jobStationIndex++)
                            {
                                writer.WriteStartElement("HOLIDAY", "");
                                writer.WriteAttributeString("intGroupID", chkGroupList.Items[groupIndex].Value.ToString());
                                writer.WriteAttributeString("intJobTypeId", chkJobtypeList.Items[jobTypeIndex].Value.ToString());
                                writer.WriteAttributeString("intJobStationID", chkJobStationList.Items[jobStationIndex].Value.ToString());
                                writer.WriteAttributeString("intHolidayID", ddlHolidayName.SelectedValue.ToString());
                                writer.WriteAttributeString("dtePermitedDate", DateTime.Now.ToShortDateString());
                                writer.WriteAttributeString("intReligionId", chkReligionList.Items[religionIndex].Value.ToString());
                                writer.WriteAttributeString("dteFromDate", txtFromDate.Text);
                                writer.WriteAttributeString("dteToDate", txtToDate.Text);
                                writer.WriteEndElement();

                                flag = true;
                            }
                        }
                    }

                }
                #endregion

                writer.WriteEndElement();
                writer.WriteEndDocument();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(stringWriter.GetStringBuilder().ToString());
                doc.CreateXmlDeclaration("1.0", "", "");

                return doc.InnerXml;
            }
            finally
            {
                if (writer != null) writer.Close();
                if (stringWriter != null) stringWriter.Close();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO REBIND HOLIDAY DROPDOWN LIST AFTER NEW HOLIDAY SETUP
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   WHEN HOLIDAY SETUP POPUP PAGE WILL BE CLOSED HOLIDAY DROPDOWNLIST WILL BE REBIND

            ddlHolidayName.DataBind();
        }
        #region INTERNAL CHECKING METHOD
        protected void chkAllGroup_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECK GROUP LIST CHECKBOX DEPANDS ON chkAllGroup
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkGroupList.Items)
            {
                listitem.Selected = chkAllGroup.Checked;
            }
        }
        protected void chkAllJobstation_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECK JOBSTATION LIST CHECKBOX DEPANDS ON chkAllJobstation
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkJobStationList.Items)
            {
                listitem.Selected = chkAllJobstation.Checked;
            }
        }
        protected void chkAllReligion_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECK RELIGION LIST CHECKBOX DEPANDS ON chkAllReligion
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkReligionList.Items)
            {
                listitem.Selected = chkAllReligion.Checked;
            }
        }
        protected void chkAllJobType_CheckedChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECK RELIGION LIST CHECKBOX DEPANDS ON chkAllReligion
            //Created    :   MD. YEASIR ARAFAT / Oct-23-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkJobtypeList.Items)
            {
                listitem.Selected = chkAllJobType.Checked;
            }
        }

        protected void chkGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECKED chkAllGroup.Checked = true; IF ALL OF THE ITEMS OF THE  chkGroupList IS SELECT 
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkGroupList.Items)
            {
                if (!listitem.Selected)
                {
                    chkAllGroup.Checked = false;
                    break;
                }
                else
                {
                    chkAllGroup.Checked = true;
                }

            }
        }
        protected void chkJobStationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECKED chkAllJobstation.Checked = true; IF ALL OF THE ITEMS OF THE  chkJobStationList IS SELECT 
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkJobStationList.Items)
            {
                if (!listitem.Selected)
                {
                    chkAllJobstation.Checked = false;
                    break;
                }
                else
                {
                    chkAllJobstation.Checked = true;
                }

            }
        }
        protected void chkReligionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECKED chkAllReligion.Checked = true; IF ALL OF THE ITEMS OF THE  chkReligionList IS SELECT 
            //Created    :   MD. YEASIR ARAFAT / May-14-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkReligionList.Items)
            {
                if (!listitem.Selected)
                {
                    chkAllReligion.Checked = false;
                    break;
                }
                else
                {
                    chkAllReligion.Checked = true;
                }

            }
        }
        protected void chkJobtypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   THIS FUNCTION WILL BE USED TO CHECKED chkAllJobType.Checked = true; IF ALL OF THE ITEMS OF THE  chkJobtypeList IS SELECT 
            //Created    :   MD. YEASIR ARAFAT / Oct-23-2012
            //Modified   :   
            //Parameters :   

            foreach (ListItem listitem in chkJobtypeList.Items)
            {
                if (!listitem.Selected)
                {
                    chkAllJobType.Checked = false;
                    break;
                }
                else
                {
                    chkAllJobType.Checked = true;
                }

            }
        }

        #endregion

    }
}