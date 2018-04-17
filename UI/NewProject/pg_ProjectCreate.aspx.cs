using HR_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.BulkSMS;
using System.Web.Services;
using System.Web.Script.Services;
using System.Xml;
using System.IO;
using UI.ClassFiles;

namespace UI.NewProject
{
    public partial class pg_ProjectCreate : System.Web.UI.Page
    {
        DataTable dtglobal;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        int part, intunitid, intCCID, intEmpId, intPCode;
        string xmlpath, xmlpath1, xmlpathfund, xmlpathemp, strUname, strCCName, strlocation, strAddress, xmlString, xmlString1, xmlStringfund, xmlStringemp, emplName, msg, remarks,buttonname,
        pName, Ptype, Obj, pcode;
        DateTime pFromdate, Ptodate, efromdate, etodate;
        BulkSMSBLL objnewboject = new BulkSMSBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //xmlpath = Server.MapPath("~/HR/New_Project/Data/Order_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            xmlpath = Server.MapPath("~/New_Project/Data/Order_" + "1355" + ".xml");
            xmlpath1 = Server.MapPath("~/New_Project/Data/Item_" + "1355" + ".xml");
            xmlpathfund = Server.MapPath("~/New_Project/Data/Fund_" + "1355" + ".xml");
            xmlpathemp = Server.MapPath("~/New_Project/Data/emp_" + "1355" + ".xml");


            if (!IsPostBack)
            {
                try { File.Delete(xmlpath); File.Delete(xmlpath1); File.Delete(xmlpathfund); File.Delete(xmlpathemp); }
                catch { }
                try
                {
                    dtglobal = objnewboject.getUnitList();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dtglobal;
                    ddlUnit.DataBind();
                    ddlSource.DataTextField = "strUnit";
                    ddlSource.DataValueField = "intUnitID";
                    ddlSource.DataSource = dtglobal;
                    ddlSource.DataBind();
                    getCostCenter();
                    hdnupdate.Value = "0";
                }
                catch { }

                getPcodeRptshow();

                //DataTable dt = new DataTable();
                //dt.Columns.Add("unit");
                //dt.Columns.Add("CostCenter");
                //dt.Columns.Add("addresss");
                //dt.Columns.Add("Location");


                //var dr = dt.NewRow();
                //var drs = dt.NewRow();
                //dr["unit"] = "AFBL";
                //dr["CostCenter"] = "Cost Center";
                //dr["addresss"] = "Address";
                //dr["Location"] = "Location";
                //dt.Rows.Add(dr);

                //drs["unit"] = "AFBL";
                //drs["CostCenter"] = "Dhaka Center";
                //drs["addresss"] = "pantopath";
                //drs["Location"] = "Pantopath";
                //dt.Rows.Add(drs);
                //dgvlist.DataSource = dt;
                //dgvlist.DataBind();





            }
        }



        private void getPcodeRptshow()
        {
            dtglobal = objnewboject.getPCodeRpt();
            txtProjectCode.Text = dtglobal.Rows[0]["Slipno"].ToString();
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {

        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCostCenter();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            hdnupdate.Value = "1";
            part = 1;
            dtglobal = objnewboject.getProjectRpt(txtProjectCode.Text, part);
            txtProjectName.Text = dtglobal.Rows[0]["strProject_Name"].ToString();
            txtObjective.Text = dtglobal.Rows[0]["strObjective"].ToString();
            txtFrom.Text = dtglobal.Rows[0]["dtePFromdate"].ToString();
            txtto.Text = dtglobal.Rows[0]["dtePTodate"].ToString();
            txtRemarks.Text= dtglobal.Rows[0]["strRemarks"].ToString();
            ddlptype.DataTextField = "strProject_Type";
            ddltype.DataValueField = "strProject_Type";
            ddltype.DataSource = dtglobal;
            ddltype.DataBind();

            part = 2;
            dtglobal = objnewboject.getProjectRpt(txtProjectCode.Text, part);

            intunitid = int.Parse(dtglobal.Rows[0]["intUnit_ID"].ToString());
            strUname= dtglobal.Rows[0]["strUnameName"].ToString();
          
            intCCID = int.Parse(dtglobal.Rows[0]["intCC_ID"].ToString());
            strCCName = dtglobal.Rows[0]["strCCName"].ToString();
            strAddress = dtglobal.Rows[0]["strAddress"].ToString();
            strlocation = dtglobal.Rows[0]["strLocation"].ToString();
            CreateXml(intunitid.ToString(), strUname, intCCID.ToString(), strCCName, strAddress, strlocation);
            part = 3;
            dtglobal = objnewboject.getProjectRpt(txtProjectCode.Text, part);
            CreateXml1(dtglobal.Rows[0]["strType"].ToString(), (dtglobal.Rows[0]["intItemId"].ToString()), dtglobal.Rows[0]["strItemName"].ToString(), dtglobal.Rows[0]["numQty"].ToString(), dtglobal.Rows[0]["monRate"].ToString(), dtglobal.Rows[0]["monAmount"].ToString());
            part = 4;
            dtglobal = objnewboject.getProjectRpt(txtProjectCode.Text, part);
            CreateXmlfund(dtglobal.Rows[0]["intUnitId"].ToString(), dtglobal.Rows[0]["strUnameName"].ToString(), dtglobal.Rows[0]["monAmount"].ToString());

            part = 5;
            dtglobal = objnewboject.getProjectRpt(txtProjectCode.Text, part);
            CreateXmlemp(dtglobal.Rows[0]["intEmpId"].ToString(), dtglobal.Rows[0]["strEmpName"].ToString(), dtglobal.Rows[0]["strResponsibility"].ToString(), dtglobal.Rows[0]["dteRFromDate"].ToString(), dtglobal.Rows[0]["dteRToDate"].ToString());

            if(hdnupdate.Value=="1")
            {
                buttonname = "Update";
            }
            else { buttonname = "Submit"; }

            btnSave.Text = buttonname;
        }

        private void getCostCenter()
        {
            dtglobal = objnewboject.getCostcenter(int.Parse(ddlUnit.SelectedValue.ToString()));
            ddlCostCeneter.DataTextField = "strCCName";
            ddlCostCeneter.DataValueField = "intCostCenterID";
            ddlCostCeneter.DataSource = dtglobal;
            ddlCostCeneter.DataBind();

            dtglobal = objnewboject.getItemlist(int.Parse(ddlUnit.SelectedValue.ToString()), ddltype.SelectedValue);
            ddlItem.DataTextField = "strItemName";
            ddlItem.DataValueField = "intItemID";
            ddlItem.DataSource = dtglobal;
            ddlItem.DataBind();


        }
        protected void ddlCostCeneter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] getEmpname(string prefixText, int count)
        {
            Int32 unit = Convert.ToInt32("2".ToString());
            BulkSMSBLL objAutoSearch_BLL = new BulkSMSBLL();
            return objAutoSearch_BLL.getemployeenameslist(unit.ToString(), prefixText);
        }
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {


            dtglobal = objnewboject.getItemlist(int.Parse(ddlUnit.SelectedValue.ToString()), ddltype.SelectedValue);
            ddlItem.DataTextField = "strItemName";
            ddlItem.DataValueField = "intItemID";
            ddlItem.DataSource = dtglobal;
            ddlItem.DataBind();

        }
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            intunitid = int.Parse(ddlUnit.SelectedValue);
            intCCID = int.Parse(ddlCostCeneter.SelectedValue);
            strUname = ddlUnit.SelectedItem.ToString();
            strCCName = ddlCostCeneter.SelectedItem.ToString();
            strlocation = txtLocation.Text.ToString();
            strAddress = txtAddress.Text.ToString();

            CreateXml(intunitid.ToString(), strUname, intCCID.ToString(), strCCName, strAddress, strlocation);
            txtAddress.Text = ""; txtLocation.Text = "";
        }
        private void CreateXml(string intunitid, string strUname, string intCCID, string strCCName, string strAddress, string strlocation)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, intunitid, strUname, intCCID, strCCName, strAddress, strlocation);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, intunitid, strUname, intCCID, strCCName, strAddress, strlocation);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string intunitid, string strUname, string intCCID, string strCCName, string strAddress, string strlocation)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Intunitid = doc.CreateAttribute("intunitid");
            Intunitid.Value = intunitid;
            XmlAttribute StrUname = doc.CreateAttribute("strUname");
            StrUname.Value = strUname;
            XmlAttribute IntCCID = doc.CreateAttribute("intCCID");
            IntCCID.Value = intCCID;
            XmlAttribute StrCCName = doc.CreateAttribute("strCCName");
            StrCCName.Value = strCCName;
            XmlAttribute StrAddress = doc.CreateAttribute("strAddress");
            StrAddress.Value = strAddress;
            XmlAttribute Strlocation = doc.CreateAttribute("strlocation");
            Strlocation.Value = strlocation;

            node.Attributes.Append(Intunitid);
            node.Attributes.Append(StrUname);
            node.Attributes.Append(IntCCID);
            node.Attributes.Append(StrCCName);
            node.Attributes.Append(StrAddress);
            node.Attributes.Append(Strlocation);
            return node;
        }
        private void LoadXml()
        {
            //try
            //{
            XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
            XmlNode xlnd = doc.SelectSingleNode("Requisition");
            xmlString = xlnd.InnerXml;
            xmlString = "<Requisition>" + xmlString + "</Requisition>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet(); ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvlist.DataSource = ds; } else { dgvlist.DataSource = ""; }
            dgvlist.DataBind();

            //}
            //catch { dgvlist.DataSource = ""; dgvlist.DataBind(); }
        }
        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            decimal qtys, rates;
            if (txtqty.Text == "") { qtys = 0; } else { qtys = decimal.Parse(txtqty.Text.ToString()); }
            if (txtRate.Text == "") { rates = 0; } else { rates = decimal.Parse(txtRate.Text.ToString()); }
            decimal amt = qtys * rates;

            CreateXml1(ddltype.SelectedItem.ToString(), ddlItem.SelectedValue.ToString(), ddlItem.SelectedItem.ToString(), txtqty.Text.ToString(), txtRate.Text.ToString(), amt.ToString());
            txtqty.Text = ""; txtRate.Text = "";
        }
        private void CreateXml1(string itemtype, string itemid, string itemname, string qty, string rate, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath1))
            {
                doc.Load(xmlpath1);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode1(doc, itemtype, itemid, itemname, qty, rate, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode1(doc, itemtype, itemid, itemname, qty, rate, amount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath1); LoadXmlItem();
        }
        private XmlNode CreateNode1(XmlDocument doc, string itemtype, string itemid, string itemname, string qty, string rate, string amount)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Itemtype = doc.CreateAttribute("itemtype");
            Itemtype.Value = itemtype;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            node.Attributes.Append(Itemtype);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Amount);
            return node;
        }
        private void LoadXmlItem()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath1);
                XmlNode xlnd = doc.SelectSingleNode("Requisition");
                xmlString1 = xlnd.InnerXml;
                xmlString1 = "<Requisition>" + xmlString1 + "</Requisition>";
                StringReader sr = new StringReader(xmlString1);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvitem.DataSource = ds; } else { dgvitem.DataSource = ""; }
                dgvitem.DataBind();

            }
            catch { dgvitem.DataSource = ""; dgvitem.DataBind(); }
        }
        protected void btnfundAdd_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (txtAmount.Text == "") { amount = 0; } else { amount = decimal.Parse(txtAmount.Text.ToString()); }
            CreateXmlfund(ddlSource.SelectedValue.ToString(), ddlSource.SelectedItem.ToString(), amount.ToString());
            txtAmount.Text = "";

        }
        private void CreateXmlfund(string unitid, string unitname, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpathfund))
            {
                doc.Load(xmlpathfund);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNodefund(doc, unitid, unitname, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNodefund(doc, unitid, unitname, amount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpathfund); LoadXmlfund();
        }
        private XmlNode CreateNodefund(XmlDocument doc, string unitid, string unitname, string amount)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Unitid = doc.CreateAttribute("unitid");
            Unitid.Value = unitid;
            XmlAttribute Unitname = doc.CreateAttribute("unitname");
            Unitname.Value = unitname;
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            node.Attributes.Append(Unitid);
            node.Attributes.Append(Unitname);
            node.Attributes.Append(Amount);
            return node;
        }
        private void LoadXmlfund()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpathfund);
                XmlNode xlnd = doc.SelectSingleNode("Requisition");
                xmlStringfund = xlnd.InnerXml;
                xmlStringfund = "<Requisition>" + xmlStringfund + "</Requisition>";
                StringReader sr = new StringReader(xmlStringfund);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvfund.DataSource = ds; } else { dgvfund.DataSource = ""; }
                dgvfund.DataBind();

            }
            catch { dgvfund.DataSource = ""; dgvfund.DataBind(); }
        }
        protected void btnResponsible_Click(object sender, EventArgs e)
        {
            arrayKeyItem = txtResposible.Text.Split(delimiterChars);

            efromdate = CommonClass.GetDateAtSQLDateFormat(txteFrom.Text).Date;
            etodate = CommonClass.GetDateAtSQLDateFormat(txteTo.Text).Date;
            if (arrayKeyItem.Length > 0)
            {
                emplName = arrayKeyItem[0].ToString();
                intEmpId = int.Parse(arrayKeyItem[1].ToString());
                CreateXmlemp(intEmpId.ToString(), emplName.ToString(), txtResponsibility.Text.ToString(), efromdate.ToString(), etodate.ToString());
                txtResposible.Text = ""; txtResponsibility.Text = "";// txteFrom.Text = ""; txteTo.Text = "";
            }

        }
        private void CreateXmlemp(string empid, string empname, string responsibility, string fdate, string tdate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpathemp))
            {
                doc.Load(xmlpathemp);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNodeemp(doc, empid, empname, responsibility, fdate, tdate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNodeemp(doc, empid, empname, responsibility, fdate, tdate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpathemp); LoadXmlemp();
        }
        private XmlNode CreateNodeemp(XmlDocument doc, string empid, string empname, string responsibility, string fdate, string tdate)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Empid = doc.CreateAttribute("empid");
            Empid.Value = empid;
            XmlAttribute Empname = doc.CreateAttribute("empname");
            Empname.Value = empname;
            XmlAttribute Responsibility = doc.CreateAttribute("responsibility");
            Responsibility.Value = responsibility;
            XmlAttribute Fdate = doc.CreateAttribute("fdate");
            Fdate.Value = fdate;
            XmlAttribute Tdate = doc.CreateAttribute("tdate");
            Tdate.Value = tdate;

            node.Attributes.Append(Empid);
            node.Attributes.Append(Empname);
            node.Attributes.Append(Responsibility);
            node.Attributes.Append(Fdate);
            node.Attributes.Append(Tdate);
            return node;
        }
        private void LoadXmlemp()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpathemp);
                XmlNode xlnd = doc.SelectSingleNode("Requisition");
                xmlStringemp = xlnd.InnerXml;
                xmlStringemp = "<Requisition>" + xmlStringemp + "</Requisition>";
                StringReader sr = new StringReader(xmlStringemp);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvemployee.DataSource = ds; } else { dgvemployee.DataSource = ""; }
                dgvemployee.DataBind();

            }
            catch { dgvemployee.DataSource = ""; dgvemployee.DataBind(); }
        }
        protected void dgvlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)dgvlist.DataSource;
                dsGrid.Tables[0].Rows[dgvlist.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgvlist.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(xmlpath); dgvlist.DataSource = ""; dgvlist.DataBind(); }
                else { LoadXml(); }

            }

            catch { }
        }
        protected void dgvitem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXmlItem();
                DataSet dsGrid = (DataSet)dgvitem.DataSource;
                dsGrid.Tables[0].Rows[dgvitem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath1);
                DataSet dsGridAfterDeletes = (DataSet)dgvitem.DataSource;
                if (dsGridAfterDeletes.Tables[0].Rows.Count <= 0)
                { File.Delete(xmlpath1); dgvitem.DataSource = ""; dgvitem.DataBind(); }
                else { LoadXmlItem(); }

            }

            catch { }
        }
        protected void dgvfund_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXmlfund();
                DataSet dsGrid = (DataSet)dgvfund.DataSource;
                dsGrid.Tables[0].Rows[dgvfund.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpathfund);
                DataSet dsGridAfterDeletess = (DataSet)dgvfund.DataSource;
                if (dsGridAfterDeletess.Tables[0].Rows.Count <= 0)
                { File.Delete(xmlpathfund); dgvfund.DataSource = ""; dgvfund.DataBind(); }
                else { LoadXmlfund(); }

            }

            catch { }
        }
        protected void dgvemployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXmlemp();
                DataSet dsGrid = (DataSet)dgvemployee.DataSource;
                dsGrid.Tables[0].Rows[dgvemployee.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpathemp);
                DataSet dsGridAfterDeletess = (DataSet)dgvemployee.DataSource;
                if (dsGridAfterDeletess.Tables[0].Rows.Count <= 0)
                { File.Delete(xmlpathemp); dgvemployee.DataSource = ""; dgvemployee.DataBind(); }
                else { LoadXmlemp(); }

            }

            catch { }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtFrom.Text == "") || (txtto.Text == ""))
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Date Select !');", true); }
            else
            {
                if ((txtProjectName.Text == "") || (txtProjectCode.Text == ""))
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Entry All Information !');", true); }
                else
                {
                    pFromdate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
                    Ptodate = CommonClass.GetDateAtSQLDateFormat(txtto.Text).Date;
                    pName = txtProjectName.Text.ToString();
                    pcode = txtProjectCode.Text.ToString();
                    Obj = txtObjective.Text.ToString();
                    Ptype = ddlptype.SelectedItem.ToString();
                    remarks = txtRemarks.Text.ToString();

                    if (File.Exists(xmlpath))
                    {
                        XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                        XmlNode xlnd = doc.SelectSingleNode("Requisition");
                        xmlString = xlnd.InnerXml;
                        xmlString = "<Requisition>" + xmlString + "</Requisition>";
                    }
                    if (File.Exists(xmlpath1))
                    {
                        XmlDocument doc1 = new XmlDocument(); doc1.Load(xmlpath1);
                        XmlNode xlnd1 = doc1.SelectSingleNode("Requisition");
                        xmlString1 = xlnd1.InnerXml;
                        xmlString1 = "<Requisition>" + xmlString1 + "</Requisition>";
                    }
                    if (File.Exists(xmlpathfund))
                    {
                        XmlDocument docfund = new XmlDocument(); docfund.Load(xmlpathfund);
                        XmlNode xlndfund = docfund.SelectSingleNode("Requisition");
                        xmlStringfund = xlndfund.InnerXml;
                        xmlStringfund = "<Requisition>" + xmlStringfund + "</Requisition>";
                    }
                    if (File.Exists(xmlpathemp))
                    {
                        XmlDocument docemp = new XmlDocument(); docemp.Load(xmlpathemp);
                        XmlNode xlndemp = docemp.SelectSingleNode("Requisition");
                        xmlStringemp = xlndemp.InnerXml;
                        xmlStringemp = "<Requisition>" + xmlStringemp + "</Requisition>";
                    }

                    int enroll = 1355;
                    msg = objnewboject.getCreateNewProject(xmlString, xmlString1, xmlStringfund, xmlStringemp, pName, Ptype, pcode, Obj, pFromdate, Ptodate, enroll, remarks);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    if (hdnupdate.Value == "1")
                    {
                        intPCode = 100;
                        dtglobal = objnewboject.getprojectcode(intPCode);
                        txtProjectCode.Text = dtglobal.Rows[0]["Slipno"].ToString();
                    }

                    File.Delete(xmlpath); File.Delete(xmlpath1); File.Delete(xmlpathfund); File.Delete(xmlpathemp);
                    dgvlist.DataSource = ""; dgvlist.DataBind();
                    dgvfund.DataSource = ""; dgvfund.DataBind();
                    dgvitem.DataSource = ""; dgvitem.DataBind();
                    dgvemployee.DataSource = ""; dgvemployee.DataBind();

                    Ptype = ddlptype.SelectedItem.ToString();
                    txtFrom.Text = ""; txtto.Text = ""; txtProjectName.Text = ""; txtObjective.Text = ""; txtRemarks.Text = "";
                }
            }

        }


    }
}