using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Budget_BLL;
using Budget_BLL.Budget;
using System.Web.Services;
using System.Web.Script.Services;

namespace UI.BudgetPlan
{
    public partial class BudgetDetalis_UI : System.Web.UI.Page

    {
        BudgetOperation_BLL objDetalis = new BudgetOperation_BLL();

        DataTable dt = new DataTable();

        string filePathForXMLSuppliyes;

        string xmlStringSuppliyes = "";
        string filePathForXMLEmployee;
        string xmlStringEmployee = "";
        string filePathForXMLTools;

        string xmlStringTools = "";
        string filePathForXMLExpance;
        string xmlStringExpance = "";
        string optype, opex, existing, type; int item; string empid, suppid, supname, empname, tname, tnameid;
        string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
        string[] arrayKeyEmp; string[] arrayKeyTools;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMLSuppliyes = Server.MapPath("~/BudgetPlan/Data/Supp_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLEmployee = Server.MapPath("~/BudgetPlan/Data/Emp_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLTools = Server.MapPath("~/BudgetPlan/Data/Tools_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLExpance = Server.MapPath("~/BudgetPlan/Data/Exp_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
        
            if(!IsPostBack)
            {
                int OperationID = Int32.Parse(Session["intID"].ToString());
                  try {  File.Delete(filePathForXMLSuppliyes); File.Delete(filePathForXMLEmployee); File.Delete(filePathForXMLTools);
                  File.Delete(filePathForXMLExpance);
                  }
                  catch { }
                  pnlUpperControl.DataBind();
                  Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                  Int32 intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());

                  Session["IntUitID"] = intunit;
                  if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
                  {
                      hdntp.Value = "1";

                  }
                  else
                  {
                      hdntp.Value = "0";

                  }

               
               
                
            }
        }

        protected void DdlWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = DdlWareHouse.SelectedValue.ToString();

                Session["WareID"] = hdnwh.Value;
            }
            catch { }
        }

        protected void DdlWareHouse_DataBound(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = DdlWareHouse.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemsName(string prefixText, int count)
        {

            string exixting = Convert.ToString(HttpContext.Current.Session["Itemsearch"].ToString());
            Int32 WHID = Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString());
               
                AutoSearchBudget_BLL objAutoSearch_BLL = new AutoSearchBudget_BLL();

                return objAutoSearch_BLL.GetItemsNmaes(WHID.ToString(), exixting, prefixText);
            

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmployeeName(string prefixText, int count)
        {

            string exixting = Convert.ToString(HttpContext.Current.Session["Empsearch"].ToString());

            Int32 unit = Convert.ToInt32(HttpContext.Current.Session["IntUitID"].ToString());
                AutoSearchBudget_BLL objAutoSearch_BLL = new AutoSearchBudget_BLL();

                return objAutoSearch_BLL.GetEmployeeNames(unit.ToString(),exixting, prefixText);
            

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetToolsName(string prefixText, int count)
        {

            string exixting = Convert.ToString(HttpContext.Current.Session["Toolssearch"].ToString());
            Int32 unit = Convert.ToInt32(HttpContext.Current.Session["IntUitID"].ToString());
            AutoSearchBudget_BLL objAutoSearch_BLL = new AutoSearchBudget_BLL();

           
            return objAutoSearch_BLL.GetToolsEquipments(unit.ToString(),exixting, prefixText);

        }
        protected void BtnEmp_Click(object sender, EventArgs e)
        {
      
             
          
            string remarks = TxtDescription.Text.ToString();
            if (EmployeeNew.Checked == true) { type = 0.ToString(); empid = 0.ToString(); empname = TxtEmpSearch.Text.ToString(); }
            if (EmployeeExix.Checked == true)
            { 
                type = 1.ToString(); empid = 0.ToString();

                arrayKeyEmp = TxtEmpSearch.Text.Split(delimiterChars);
                empname = arrayKeyEmp[0].ToString();
                empid = arrayKeyEmp[1].ToString();
            
            }

            CreateEmpXml(empname, empid, type,remarks);

        }

        private void CreateEmpXml(string empname, string empid,string type, string remarks)
        {
            XmlDocument doc= new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLEmployee))
            {
                doc.Load(filePathForXMLEmployee);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeEmp(doc, empname, empid,type, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeEmp(doc, empname, empid,type, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLEmployee);
            LoadGridwithEmployee();
        }

        private void LoadGridwithEmployee()
        {
            try
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(filePathForXMLEmployee);
                XmlNode dSftTms = doc2.SelectSingleNode("voucher");
                xmlStringEmployee = dSftTms.InnerXml;
                xmlStringEmployee = "<voucher>" + xmlStringEmployee + "</voucher>";
                StringReader srs = new StringReader(xmlStringEmployee);
                DataSet dss = new DataSet();
                dss.ReadXml(srs);
                if (dss.Tables[0].Rows.Count > 0)
                { dgvEmp.DataSource = dss; }

                else { dgvSupplies.DataSource = ""; }
                dgvEmp.DataBind();
            }
            catch { }
        }
        private XmlNode CreateItemNodeEmp(XmlDocument doc, string empname, string empid,string type, string remarks)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Empname = doc.CreateAttribute("empname");
            Empname.Value = empname;
            XmlAttribute Empid = doc.CreateAttribute("empid");
            Empid.Value = empid;
            XmlAttribute Type = doc.CreateAttribute("type");
            Type.Value = type;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;





            node.Attributes.Append(Empname);
            node.Attributes.Append(Empid);
            node.Attributes.Append(Type);
            node.Attributes.Append(Remarks);

            return node;
        }
        protected void Btnsupplies_Click(object sender, EventArgs e)
        {
           
            string remarks = TxtRemarks.Text.ToString();
           suppid = txtSupplies.Text.ToString();
           string qty = TxtPqty.Text.ToString();
           if (SNew.Checked == true) { type = 0.ToString(); suppid = "0".ToString();supname = txtSupplies.Text.ToString(); }
           if (SExis.Checked == true) 
           { 
               type = 1.ToString();
               arrayKeyItem = txtSupplies.Text.Split(delimiterChars);
               supname = arrayKeyItem[0].ToString();
               suppid = arrayKeyItem[1].ToString();
           }

            CreateSuppliesXml(supname, suppid,type, remarks); 
        }

        private void CreateSuppliesXml(string supname, string suppid,string type, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLSuppliyes))
            {
                doc.Load(filePathForXMLSuppliyes);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeSupplies(doc, supname, suppid,type, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeSupplies(doc, supname, suppid,type, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLSuppliyes);
            LoadGridwithSupplies();
        }

        private void LoadGridwithSupplies()
        {
            try
            {
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(filePathForXMLSuppliyes);
                XmlNode dSftTms = doc1.SelectSingleNode("voucher");
                xmlStringSuppliyes = dSftTms.InnerXml;
                xmlStringSuppliyes = "<voucher>" + xmlStringSuppliyes + "</voucher>";
                StringReader srs = new StringReader(xmlStringSuppliyes);
                DataSet dss = new DataSet();
                dss.ReadXml(srs);
                if (dss.Tables[0].Rows.Count > 0)
                { dgvSupplies.DataSource = dss; }

                else { dgvSupplies.DataSource = ""; }
                dgvSupplies.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeSupplies(XmlDocument doc, string supname, string suppid,string type, string remarks)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Supname = doc.CreateAttribute("supname");
            Supname.Value = supname;
            XmlAttribute Suppid = doc.CreateAttribute("suppid");
            Suppid.Value = suppid;
            XmlAttribute Type = doc.CreateAttribute("type");
            Type.Value = type;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;





            node.Attributes.Append(Supname);
            node.Attributes.Append(Suppid);
            node.Attributes.Append(Type);
            node.Attributes.Append(Remarks);
           
            return node;
        }

        protected void dgvSupplies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithSupplies();
                DataSet dsGrid = (DataSet)dgvSupplies.DataSource;
                dsGrid.Tables[0].Rows[dgvSupplies.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLSuppliyes);
                DataSet dsGridAfterDelete = (DataSet)dgvSupplies.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLSuppliyes); dgvSupplies.DataSource = ""; dgvSupplies.DataBind(); }
                else { LoadGridwithSupplies(); }
            }

            catch { }
        }

        protected void dgvEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithEmployee();
                DataSet dsGrid = (DataSet)dgvEmp.DataSource;
                dsGrid.Tables[0].Rows[dgvEmp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLEmployee);
                DataSet dsGridAfterDelete = (DataSet)dgvEmp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLEmployee); dgvEmp.DataSource = ""; dgvEmp.DataBind(); }
                else { LoadGridwithEmployee(); }
            }

            catch { }
        }

        protected void BtnTools_Click(object sender, EventArgs e)
        {
           
            string tqty = txtToolqty.Text.ToString();
            string tdec = TxtTollsDescription.Text.ToString();
            if (ETNew.Checked == true) { type = 0.ToString(); tnameid = 0.ToString(); tname = txtTools.Text.ToString(); }
            if (ETExis.Checked == true)
            {
                type = 1.ToString();
                arrayKeyTools = txtTools.Text.Split(delimiterChars);
                tname = arrayKeyTools[0].ToString();
                tnameid = arrayKeyTools[1].ToString();
            }

            CreateToolsXml(tname, tnameid,type, tqty, tdec);
        }

        private void CreateToolsXml(string tname, string tnameid,string type, string tqty, string tdec)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLTools))
            {
                doc.Load(filePathForXMLTools);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeTools(doc, tname, tnameid,type, tqty, tdec);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeTools(doc, tname, tnameid,type, tqty, tdec);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLTools);
            LoadGridwithTools();
        }

        private XmlNode CreateItemNodeTools(XmlDocument doc, string tname, string tnameid, string type,string tqty, string tdec)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Tname = doc.CreateAttribute("tname");
            Tname.Value = tname;
            XmlAttribute Tnameid = doc.CreateAttribute("tnameid");
            Tnameid.Value = tnameid;
            XmlAttribute Type = doc.CreateAttribute("type");
            Type.Value = type;
            XmlAttribute Tqty = doc.CreateAttribute("tqty");
            Tqty.Value = tqty;
            XmlAttribute Tdec = doc.CreateAttribute("tdec");
            Tdec.Value = tdec;





            node.Attributes.Append(Tname);
            node.Attributes.Append(Tnameid);
            node.Attributes.Append(Type);
            node.Attributes.Append(Tqty);
            node.Attributes.Append(Tdec);

            return node;
        }

        private void LoadGridwithTools()
        {
            try
            {
                XmlDocument doc3 = new XmlDocument();
                doc3.Load(filePathForXMLTools);
                XmlNode dSftTms = doc3.SelectSingleNode("voucher");
                xmlStringTools = dSftTms.InnerXml;
                xmlStringTools = "<voucher>" + xmlStringTools + "</voucher>";
                StringReader srs = new StringReader(xmlStringTools);
                DataSet dss = new DataSet();
                dss.ReadXml(srs);
                if (dss.Tables[0].Rows.Count > 0)
                { dgvTools.DataSource = dss; }

                else { dgvTools.DataSource = ""; }
                dgvTools.DataBind();
            }
            catch { }
        }

        protected void dgvTools_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithTools();
                DataSet dsGrid = (DataSet)dgvTools.DataSource;
                dsGrid.Tables[0].Rows[dgvTools.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLTools);
                DataSet dsGridAfterDelete = (DataSet)dgvTools.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLTools); dgvTools.DataSource = ""; dgvTools.DataBind(); }
                else { LoadGridwithTools(); }
            }

            catch { }
        }

        protected void btnExpance_Click(object sender, EventArgs e)
        {
            string exname = TxtExpance.Text.ToString();
            string exdec = TxtDec.Text.ToString();
            string amount = TxtAmount.Text.ToString();
            
            CreateExpanceXml(exname, exdec, amount);


        }

        private void CreateExpanceXml(string exname, string exdec, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLExpance))
            {
                doc.Load(filePathForXMLExpance);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeExpance(doc, exname, exdec, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeExpance(doc, exname, exdec, amount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLExpance);
            LoadGridwithExpance();
        }
        private XmlNode CreateItemNodeExpance(XmlDocument doc, string exname, string exdec, string amount)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Exname = doc.CreateAttribute("exname");
            Exname.Value = exname;
            XmlAttribute Exdec = doc.CreateAttribute("exdec");
            Exdec.Value = exdec;
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;





            node.Attributes.Append(Exname);
            node.Attributes.Append(Exdec);
            node.Attributes.Append(Amount);
        

            return node;
        }
        private void LoadGridwithExpance()
        {
            try
            {
                XmlDocument doc4 = new XmlDocument();
                doc4.Load(filePathForXMLExpance);
                XmlNode dSftTms = doc4.SelectSingleNode("voucher");
                xmlStringExpance = dSftTms.InnerXml;
                xmlStringExpance = "<voucher>" + xmlStringExpance + "</voucher>";
                StringReader srs = new StringReader(xmlStringExpance);
                DataSet dss = new DataSet();
                dss.ReadXml(srs);
                if (dss.Tables[0].Rows.Count > 0)
                { dgvExpance.DataSource = dss; }

                else { dgvExpance.DataSource = ""; }
                dgvExpance.DataBind();
            }
            catch { }
        }

        protected void dgvExpance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithExpance();
                DataSet dsGrid = (DataSet)dgvExpance.DataSource;
                dsGrid.Tables[0].Rows[dgvExpance.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLExpance);
                DataSet dsGridAfterDelete = (DataSet)dgvExpance.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLExpance); dgvExpance.DataSource = ""; dgvExpance.DataBind(); }
                else { LoadGridwithExpance(); }
            }

            catch { }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {


            try
            {
                dt = new DataTable();
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(filePathForXMLSuppliyes);
                XmlNode vouchers = doc1.SelectSingleNode("voucher");
                xmlStringSuppliyes = vouchers.InnerXml;
                xmlStringSuppliyes = "<voucher>" + xmlStringSuppliyes + "</voucher>";
            }
            catch { xmlStringSuppliyes = ""; }

            try
            {
                dt = new DataTable();
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(filePathForXMLEmployee);
                XmlNode vouchers2 = doc2.SelectSingleNode("voucher");
                xmlStringEmployee = vouchers2.InnerXml;
                xmlStringEmployee = "<voucher>" + xmlStringEmployee + "</voucher>";
            }
            catch { xmlStringEmployee = ""; }
            try
            {
                dt = new DataTable();
                XmlDocument doc3 = new XmlDocument();
                doc3.Load(filePathForXMLTools);
                XmlNode vouchers3 = doc3.SelectSingleNode("voucher");
                xmlStringTools = vouchers3.InnerXml;
                xmlStringTools = "<voucher>" + xmlStringTools + "</voucher>";
            }
            catch { xmlStringTools = ""; }


            try
            {
                dt = new DataTable();
                XmlDocument doc4 = new XmlDocument();
                doc4.Load(filePathForXMLExpance);
                XmlNode vouchers4 = doc4.SelectSingleNode("voucher");
                xmlStringExpance = vouchers4.InnerXml;
                xmlStringExpance = "<voucher>" + xmlStringExpance + "</voucher>";
            }
            catch { xmlStringExpance = ""; }
                
                   dt = new DataTable();
                   item = Int32.Parse(3.ToString());
                   int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    int OperationID = Int32.Parse(Session["intID"].ToString());



                    dt = objDetalis.OperationDetalisXmlInsert(item, 0, 0, xmlStringSuppliyes, xmlStringEmployee, xmlStringTools, xmlStringExpance, 0, OperationID, intjobid, intunit, intdept);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submit');", true);
            try { 
                File.Delete(filePathForXMLSuppliyes); dgvSupplies.DataSource = ""; dgvSupplies.DataBind();
                File.Delete(filePathForXMLEmployee); dgvEmp.DataSource = ""; dgvEmp.DataBind();
                File.Delete(filePathForXMLTools); dgvTools.DataSource = ""; dgvTools.DataBind();
                File.Delete(filePathForXMLExpance); dgvExpance.DataSource = ""; dgvExpance.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

                Response.Redirect("BudgetPlanning_Requesition.aspx", true);
                }
                
           catch { }
               
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("BudgetPlanning_Requesition.aspx", true);
        }

        protected void SExis_CheckedChanged(object sender, EventArgs e)
        {
            if(SExis.Checked==true)
            {
                Session["Itemsearch"] = 1.ToString();
                      
            }

        }

        protected void EmployeeExix_CheckedChanged(object sender, EventArgs e)
        {
            if (EmployeeExix.Checked == true)
            {
                Session["Empsearch"] = 2.ToString();

            }
        }

        protected void ETExis_CheckedChanged(object sender, EventArgs e)
        {
            if (ETExis.Checked == true)
            {
                Session["Toolssearch"] = 3.ToString();

            }
        }

        protected void SNew_CheckedChanged(object sender, EventArgs e)
        {
            if (SNew.Checked == true)
            {
                Session["Itemsearch"] = 100.ToString();

            }
        }

        protected void EmployeeNew_CheckedChanged(object sender, EventArgs e)
        {
            if (EmployeeNew.Checked == true)
            {
                Session["Empsearch"] = 200.ToString();

            }
        }

        protected void ETNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ETNew.Checked == true)
            {
                Session["Toolssearch"] = 300.ToString();

            }
        }

        
       
    }
}