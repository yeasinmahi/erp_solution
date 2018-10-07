using HR_BLL.Global;
using SAD_BLL.Transport;
using HR_BLL.Settlement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Xml;
using System.IO;
using System.Web.Script.Services;
using Dairy_BLL;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Insurance
{
    public partial class InsuranceInfoOfEmployee : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Insurance/InsuranceInfoOfEmployee.aspx";
        string stop = "stopping HR/Insurance/InsuranceInfoOfEmployee.aspx";

        HRClass objhr = new HRClass();
        GlobalClass objG = new GlobalClass();
        SelfClass obj = new SelfClass();
        DataTable dt;
        InternalTransportBLL obju = new InternalTransportBLL();

        string filePathForXMLDTFareCash; string xmlStringDTFareCash = ""; string xmlDtFareCash;
        int insurtype;
        int intEnroll; 
        string dependantn; string relation; string dateofbirthd; int intUnitid; int intJobStationid; int intInsertBy;
        string strinstype,mdctype,medicaltyp;
        DateTime dteDBirth;

        string strEmpCode; string strKey, Unitid;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;
        bool ysnGroup, ysnMedical;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Insurance/InsuranceInfoOfEmployee.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnrollUnit.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXMLDTFareCash = Server.MapPath("~/HR/Settlement/Uploads/InsuranceInfo_" + hdnEnrollUnit.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXMLDTFareCash); dgvDependant.DataSource = ""; dgvDependant.DataBind();
                pnlUpperControl.DataBind(); txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");

                Unitid = Session[SessionParams.UNIT_ID].ToString();
                HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();
                chkGroup.Checked = true;
                drdlInsuranceType2.Visible = false;
                chkMedical.Enabled = false;
                drdlInsuranceType.Visible = true;                
            }
            else
            {
                

            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }

        protected void txtEmployeeSearch_TextChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "txtEmployeeSearch_TextChanged", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Insurance/InsuranceInfoOfEmployee.aspx txtEmployeeSearch_TextChanged", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtEmployeeSearch.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            try
            {
               
                    HttpContext.Current.Session["intEnroll"] = intEnroll.ToString();

                    dt = new DataTable();
                    dt = obj.GetEmpInfoForSeltResign(intEnroll);
                    if (dt.Rows.Count > 0)
                    {
                        txtSupervisorName.Text = dt.Rows[0]["strSuperviserName"].ToString();
                        //txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                        txtEmpCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                        txtEmpEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                        txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                        txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                        txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                        txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
                        //txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                        //txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                        txtJoiningDate.Text = dt.Rows[0]["dteJoiningDate"].ToString();
                        //txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                        txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                        txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                        txtDateOfB.Text = dt.Rows[0]["dteBirth"].ToString();
                        txtContact.Text = dt.Rows[0]["strContactNo1"].ToString();
                    }
                    else
                    {
                        txtSupervisorName.Text = "";
                        //txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                        txtEmpCode.Text = "";
                        txtEmpEnroll.Text = "";
                        txtName.Text = "";
                        txtDesignation.Text = "";
                        txtDept.Text = "";
                        txtJobType.Text = "";
                        //txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                        //txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                        txtJoiningDate.Text = "";
                        //txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                        txtUnit.Text = "";
                        txtJobStation.Text = "";
                        txtDateOfB.Text = "";
                        txtContact.Text = "";

                        chkGroup.Checked = true;
                        drdlInsuranceType2.Visible = false;
                        chkMedical.Enabled = false;
                        drdlInsuranceType.Visible = true;
                    }
                    dt = new DataTable();
                    dt = objG.GetMedicalType(intEnroll);
                    if (dt.Rows.Count > 0)
                    {
                        drdlInsuranceType2.SelectedItem.Text = dt.Rows[0]["strMedicalType"].ToString();
                    }
                    else
                    {
                        drdlInsuranceType2.SelectedItem.Text = "0 k";
                    }

                File.Delete(filePathForXMLDTFareCash); dgvDependant.DataSource = ""; dgvDependant.DataBind();
                    Load();
                    

                medicaltyp = "";
                objG.Getmedicaltype(intEnroll, ref medicaltyp);
                if(medicaltyp== "Yes") {
                    chkMedical.Checked = true;
                    drdlInsuranceType2.Visible = true;
                    drdlInsuranceType.Visible = false;
                }
                else
                {
                    chkMedical.Checked = false;
                    drdlInsuranceType2.Visible = false;
                    drdlInsuranceType.Visible = true;
                }
                

                ////}
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "txtEmployeeSearch_TextChanged", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "txtEmployeeSearch_TextChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(0, 0, strSearchKey);
            //int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session["jobstationid"].ToString()), strSearchKey);
            return result;
        }
        private void GetSearchResult(string empCode)
        {
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    strEmpCode = empCode;

                    dt = new DataTable();
                    dt = objhr.GetEnrollByEmpCode(strEmpCode);

                    intEnroll = int.Parse(dt.Rows[0]["intEmployeeID"].ToString());
                    HttpContext.Current.Session["intEnroll"] = intEnroll.ToString();
                    
                    if (dt.Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = obj.GetEmpInfoForSeltResign(intEnroll);

                        txtSupervisorName.Text = dt.Rows[0]["strSuperviserName"].ToString();
                        //txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                        txtEmpCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                        txtEmpEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                        txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                        txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                        txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                        txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
                        //txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                        //txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                        txtJoiningDate.Text = dt.Rows[0]["dteJoiningDate"].ToString();
                        //txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                        txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                        txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                        txtDateOfB.Text = dt.Rows[0]["dteBirth"].ToString();
                        txtContact.Text = dt.Rows[0]["strContactNo1"].ToString();
                    }
                    else
                    {
                        txtSupervisorName.Text = "";
                        //txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                        txtEmpCode.Text = "";
                        txtEmpEnroll.Text = "";
                        txtName.Text = "";
                        txtDesignation.Text = "";
                        txtDept.Text = "";
                        txtJobType.Text = "";
                        //txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                        //txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                        txtJoiningDate.Text = "";
                        //txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                        txtUnit.Text = "";
                        txtJobStation.Text = "";
                        txtDateOfB.Text = "";
                        txtContact.Text = "";
                    }

                    dt = new DataTable();
                    dt = objG.GetMedicalType(intEnroll);
                    if (dt.Rows.Count > 0)
                    {
                        drdlInsuranceType2.Text = dt.Rows[0]["strMedicalType"].ToString();
                    }

                    File.Delete(filePathForXMLDTFareCash); dgvDependant.DataSource = ""; dgvDependant.DataBind();
                    Load();
                }
            }
            catch { }
        }

      
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Add();
        }

        protected void Load()
        {
            dt = new DataTable();
            dt = objG.GetDependantListByEnroll(int.Parse(HttpContext.Current.Session["intEnroll"].ToString()));

            if (dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    dependantn = dt.Rows[index]["strDependanceName"].ToString();
                    relation = dt.Rows[index]["strRelation"].ToString();
                    dateofbirthd = dt.Rows[index]["dteDateOfBirthD"].ToString();
                    //mdctype = dt.Rows[index]["medicaltyepe"].ToString();
                    CreateVoucherXmlDTFareCash(dependantn, relation, dateofbirthd);    
                }
            }
        }

        protected void Add()
        {
            dependantn = txtDependantName.Text;
            relation = ddlRelationType.SelectedItem.ToString();
            dateofbirthd = txtDateOfBirthD.Text;
           
            //bool ysnmedicaltype = chkMedical.Checked;

            //if (ysnmedicaltype == true)
            //{
            //    //drdlInsuranceType.DataBind();
            //    insurtype = int.Parse(drdlInsuranceType.SelectedValue.ToString());
            //    strinstype = drdlInsuranceType.SelectedItem.Text;
            //}
            //else
            //{


            //    /*drdlInsuranceType.Visible = false;*/
            //    insurtype = 0;
            //    strinstype = "No";
            //}
            try
            {
                DateTime dteD = DateTime.Parse(txtDateOfBirthD.Text);
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Date Format not incurrect. Please select calendar date.');", true); return; }

            if (dependantn != "" && relation != "" && dateofbirthd != "")
            {
                CreateVoucherXmlDTFareCash(dependantn, relation, dateofbirthd);
                txtDependantName.Text = "";
                txtDateOfBirthD.Text = "";
            }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Dependant Name.');", true); return; }

        }
        private void CreateVoucherXmlDTFareCash(string dependantn, string relation, string dateofbirthd)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDTFareCash))
            {
                doc.Load(filePathForXMLDTFareCash);
                XmlNode rootNode = doc.SelectSingleNode("DTFareCash");
                XmlNode addItem = CreateItemNodeDTFareCash(doc, dependantn, relation, dateofbirthd);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DTFareCash");
                XmlNode addItem = CreateItemNodeDTFareCash(doc, dependantn, relation, dateofbirthd);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDTFareCash);
            LoadGridwithXmlDTFareCash();
            //Clear();
        }
        private void LoadGridwithXmlDTFareCash()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDTFareCash);
            XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
            xmlStringDTFareCash = dSftTm.InnerXml;
            xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
            StringReader sr = new StringReader(xmlStringDTFareCash);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDependant.DataSource = ds; }
            else { dgvDependant.DataSource = ""; }
            dgvDependant.DataBind();
            //hdnDTFCountCash.Value = dgvDependant.Rows.Count.ToString();
            ///ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);

        }
        private XmlNode CreateItemNodeDTFareCash(XmlDocument doc, string dependantn, string relation, string dateofbirthd)
        {
            XmlNode node = doc.CreateElement("DTFareCash");

            XmlAttribute Dependantn = doc.CreateAttribute("dependantn");
            Dependantn.Value = dependantn;
            XmlAttribute Relation = doc.CreateAttribute("relation");
            Relation.Value = relation;
            XmlAttribute Dateofbirthd = doc.CreateAttribute("dateofbirthd");
            Dateofbirthd.Value = dateofbirthd;
            //XmlAttribute Medicaltyepe = doc.CreateAttribute("medicaltyepe");
            //Medicaltyepe.Value = medicaltyepe;


            node.Attributes.Append(Dependantn);
            node.Attributes.Append(Relation);
            node.Attributes.Append(Dateofbirthd);
            //node.Attributes.Append(Medicaltyepe);
            return node;
        }
        
        protected void chkMedical_CheckedChanged(object sender, EventArgs e)
        {
            bool chked = chkMedical.Checked;
            if (chked == true)
            {
                drdlInsuranceType.EnableViewState = true;
                chkGroup.EnableViewState = true;
                chkGroup.Checked = true;
                drdlInsuranceType2.Visible = true;
                drdlInsuranceType.Visible = false;
            }
            else {
                drdlInsuranceType2.Visible = false;
                drdlInsuranceType.Visible = true;
                chkGroup.Checked = true;
            }
            //chkGroup.Checked = true;
        }

        protected void chkGroup_CheckedChanged(object sender, EventArgs e)
        {
            bool chkedgroup = chkGroup.Checked;
            if (chkedgroup == true)
            {
                chkGroup.Enabled = true;
                chkMedical.Checked = false;
                chkMedical.Enabled = false;
                drdlInsuranceType.Enabled = false;

                drdlInsuranceType.Visible = true;
                drdlInsuranceType2.Visible = false;

            }
            else
            {
                drdlInsuranceType.Visible = false;
                drdlInsuranceType2.Visible = true;
                chkMedical.Enabled = true;
                drdlInsuranceType.Enabled = true;
            }
        }

        protected void dgvDTFareCash_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDTFareCash);
                XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
                xmlStringDTFareCash = dSftTm.InnerXml;
                xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
                StringReader sr = new StringReader(xmlStringDTFareCash);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDependant.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDependant.DataSource;
                //hdndgvDTFCash.Value = grandtotaldtfarecash.ToString();
                dsGrid.Tables[0].Rows[dgvDependant.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDTFareCash);
                DataSet dsGridAfterDelete = (DataSet)dgvDependant.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDTFareCash); dgvDependant.DataSource = ""; dgvDependant.DataBind();
                    //hdnDTFCountCash.Value = dgvDTFareCash.Rows.Count.ToString();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                else { LoadGridwithXmlDTFareCash(); }
            }
            catch { }

        }  
      
        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnUpdate_Click1", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Insurance/InsuranceInfoOfEmployee.aspx btnUpdate_Click1", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intEnroll = int.Parse(HttpContext.Current.Session["intEnroll"].ToString());
                    if (intEnroll == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Employee Select.');", true); return; }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Employee Select.');", true); return; }

                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                intUnitid = 0;// int.Parse(ddlUnit.SelectedValue.ToString());
                intJobStationid = 0; // int.Parse(ddlJobStation.SelectedValue.ToString());
                bool  ysnmedicaltype = chkMedical.Checked;
                if (ysnmedicaltype == true)
                {
                    //drdlInsuranceType.DataBind();
                    insurtype = int.Parse(drdlInsuranceType2.SelectedValue.ToString());
                    mdctype = drdlInsuranceType2.SelectedItem.Text;
                }
                else
                {

                    insurtype = int.Parse(drdlInsuranceType.SelectedValue.ToString());
                    mdctype = drdlInsuranceType.SelectedItem.Text;


                }

                //mdctype = drdlInsuranceType.SelectedItem.Text;

                ysnGroup = chkGroup.Checked;


                try
                {
                    dteDBirth = DateTime.Parse(txtDateOfB.Text);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Date Of Birth.');", true); return; }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLDTFareCash);
                    XmlNode dSftTm = doc.SelectSingleNode("DTFareCash");
                    xmlStringDTFareCash = dSftTm.InnerXml;
                    xmlStringDTFareCash = "<DTFareCash>" + xmlStringDTFareCash + "</DTFareCash>";
                    xmlDtFareCash = xmlStringDTFareCash;
                }
                catch { }

                //if (xmlDtFareCash == null)
                //{ ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); return; }

                string message = objG.InsertInsuranceInfoEntry(intEnroll, intInsertBy, intUnitid, intJobStationid, ysnGroup, ysnMedical, xmlDtFareCash, dteDBirth, mdctype);
                //HttpContext.Current.Session["intEnroll"] = "0";
                hdnconfirm.Value = "0";

                if (filePathForXMLDTFareCash != null)
                { File.Delete(filePathForXMLDTFareCash); } dgvDependant.DataSource = ""; dgvDependant.DataBind();

                txtSupervisorName.Text = "";
                //txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                txtEmpCode.Text = "";
                txtEmpEnroll.Text = "";
                txtName.Text = "";
                txtDesignation.Text = "";
                txtDept.Text = "";
                txtJobType.Text = "";
                //txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                //txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                txtJoiningDate.Text = "";
                //txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                txtUnit.Text = "";
                txtJobStation.Text = "";
                txtDateOfB.Text = "";
                txtContact.Text = "";
                txtEmployeeSearch.Text = "";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                chkGroup.Checked = true;
                chkMedical.Enabled = false;
                chkMedical.Checked = false;
                drdlInsuranceType2.Visible = false;
                drdlInsuranceType.Visible = true;
                //chkGroup.Checked = true;
                //drdlInsuranceType2.Visible = false;
                //chkMedical.Enabled = false;
                //drdlInsuranceType.Enabled = true;

                drdlInsuranceType.SelectedItem.Selected = true;
                drdlInsuranceType.SelectedIndex = 0;
            }

            fd = log.GetFlogDetail(stop, location, "btnUpdate_Click1", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        //** Gridview Down Trip Fare Cash Add End 
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnCancel_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Insurance/InsuranceInfoOfEmployee.aspx btnCancel_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    try
                    {
                        intEnroll = int.Parse(HttpContext.Current.Session["intEnroll"].ToString());
                        if (intEnroll == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Employee Select.');", true); return; }
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Employee Select.');", true); return; }

                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    dt = new DataTable();
                    dt = objG.CancelInsurance(intInsertBy, intEnroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Cancel Successfully.');", true);
                    txtSupervisorName.Text = "";
                    //txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                    txtEmpCode.Text = "";
                    txtEmpEnroll.Text = "";
                    txtName.Text = "";
                    txtDesignation.Text = "";
                    txtDept.Text = "";
                    txtJobType.Text = "";
                    //txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                    //txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                    txtJoiningDate.Text = "";
                    //txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                    txtUnit.Text = "";
                    txtJobStation.Text = "";
                    txtDateOfB.Text = "";
                    txtContact.Text = "";
                    chkMedical.Checked = false;
                    drdlInsuranceType2.Visible = false;
                    drdlInsuranceType.Visible = true;
                    if (filePathForXMLDTFareCash != null)
                    { File.Delete(filePathForXMLDTFareCash); }
                    dgvDependant.DataSource = ""; dgvDependant.DataBind();
                    txtEmployeeSearch.Text = "";
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "btnCancel_Click", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "btnCancel_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
















    }
}