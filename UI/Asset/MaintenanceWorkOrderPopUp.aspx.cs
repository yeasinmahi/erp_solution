using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace UI.Asset
{
    public partial class MaintenanceWorkOrderPopUp :BasePage
    {

        AssetMaintenance objMaintenance = new AssetMaintenance();
        DataTable dt = new DataTable();
        DataTable service = new DataTable();
        DataTable taskshow = new DataTable();
        DataTable IssueDate = new DataTable();
        DataTable preventive = new DataTable();
        DataTable repair = new DataTable();
        DataTable center = new DataTable();
        string filePathForXML; string xmlString = "";
        int intItem; int IntUnitID; string hdn; int intjobid;
        string vehicleNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
            filePathForXML = Server.MapPath("~/Asset/Data/SIndent_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
              
                Int32 data = Convert.ToInt32(Session["intMaintenanceNo"].ToString());
                string Po=Session["provideType"].ToString();

                TxtAssign.Attributes.Add("onkeyUp", "SearchTextemp();");

                TxtPresentMilege.Visible =false;
                TxtNextMilege.Visible = false;
                DdlHevvyVehicle.Visible = false;
                lbHevvy.Visible = false;
              

                RadioPreventive.Visible = false;
                TxtCost.ReadOnly = true;
               

               
                
                TxtOrder.Text = data.ToString();
                if (Po == "1")
                {
                    TxtTechnichinSearch.Attributes.Add("onkeyUp", "SearchTextempIndent();");
                    SearchItem.Attributes.Add("onkeyUp", "SearchTextItem();");
                    
                    dt = new DataTable();
                    Int32 intEnroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objMaintenance.IndentWareHouse(intEnroll);
                    DdlUnitName.DataSource = dt;
                    DdlUnitName.DataTextField = "WHName";
                    DdlUnitName.DataValueField = "ID";
                    DdlUnitName.DataBind();
                    Int32 IntUnitID = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    //Int32 IntUnitID = Int32.Parse(DdlUnitName.SelectedValue.ToString());
                    HdnUnit.Value = IntUnitID.ToString();

                    BtnSubmitIn.Visible = true; BtnAddIndent.Visible = true; TxtPurpose.Visible = true; LblPurpose.Visible = true;
                    Txtdte.Visible = true; LblDueDate.Visible = true; TxtTechnichinSearch.Visible = true;
                    LblQcperson.Visible = true; DdlIType.Visible = true; LblIType.Visible = true; TxtQty.Visible = true; LblQty.Visible = true; SearchItem.Visible = true; LblSearchI.Visible = true; DdlUnitName.Visible = true;
                    LblUnitW.Visible = true;
                }
                else
                {
                    BtnSubmitIn.Visible = false; BtnAddIndent.Visible = false; TxtPurpose.Visible = false; LblPurpose.Visible = false;
                    Txtdte.Visible = false; LblDueDate.Visible = false; TxtTechnichinSearch.Visible = false;
                    LblQcperson.Visible = false; DdlIType.Visible = false; LblIType.Visible = false; TxtQty.Visible = false; LblQty.Visible = false; SearchItem.Visible = false; LblSearchI.Visible = false; DdlUnitName.Visible = false;
                    LblUnitW.Visible = false;
                    CheckBoxIndent.Visible = false;
                }
                
               
              
                pnlUpperControl.DataBind();
                showdata();

            }
           

        }

        private void showdata()
        {
                int Mnumber =int.Parse(Session["intMaintenanceNo"].ToString()); 
           
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                IssueDate = objMaintenance.issuedateshow(7, Mnumber, intenroll, intjobid, intdept);
                if (IssueDate.Rows.Count > 0)
                {
                //TxtdteIssue.Text = IssueDate.Rows[0]["issue"].ToString();
                TxtdteStarted.Text = IssueDate.Rows[0]["start"].ToString();
                //TxtdteEnd.Text = IssueDate.Rows[0]["enddate"].ToString();
                TxtAssign.Text = IssueDate.Rows[0]["strAssignTo"].ToString();
                TxtNotes.Text = IssueDate.Rows[0]["strNotes"].ToString();
                DdlPriority.Text = IssueDate.Rows[0]["strPriority"].ToString();
                DdlReType.SelectedItem.Text = IssueDate.Rows[0]["YsnServieType"].ToString();
                TxtPresentMilege.Text = IssueDate.Rows[0]["strVNextMilege"].ToString();
                HdnAssetid.Value = IssueDate.Rows[0]["strAssetCode"].ToString();
                 
                vehicleNumber = HdnAssetid.Value.ToString();  
                dt = new DataTable();
                dt = objMaintenance.MilegeViewTextbox(vehicleNumber);
                if (dt.Rows.Count > 0)
                {
                TxtPresentMilege.Visible = true;
                TxtNextMilege.Visible = true;
                DdlHevvyVehicle.Visible = true;
                lbHevvy.Visible = true;
                } 

                taskshow = objMaintenance.dtashgridview(1, Mnumber);
                dgvTask.DataSource = taskshow;
                dgvTask.DataBind();
               
                
                intjobid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                center = objMaintenance.CostcenterShow(27, Mnumber, intenroll, intjobid, intdept);
                DdlCostCenter.DataSource = center;
                DdlCostCenter.DataTextField = "strCCName";
                DdlCostCenter.DataValueField = "intCostCenterID";
                DdlCostCenter.DataBind(); 
              
                
                dt = objMaintenance.Indentview(54, Mnumber, intenroll, intjobid, intdept);
                dgvSrviceIndentView.DataSource = dt; 
                dgvSrviceIndentView.DataBind(); 

            }
        }


        [WebMethod]
        public static List<string> GetAutoCompleteDataemp(string strSearchKeyemp)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
            {
                List<string> result2 = new List<string>();
                result2 = objAutoSearch_BLL.AutoSearchCorporateEmployee(strSearchKeyemp);
                return result2;
            }
            else
            {

                List<string> result = new List<string>();
                result = objAutoSearch_BLL.AutoSearchEmployee(strSearchKeyemp, intjobid);
                return result;
            }

        }

        [WebMethod]
        public static List<string> GetAutoCompleteDataempstIndent(string strSearchKeyemp)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 90 || intjobid == 93 || intjobid == 94 || intjobid == 95 || intjobid == 125 || intjobid == 131 || intjobid == 460 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 1261)
            {
                List<string> result2 = new List<string>();
                result2 = objAutoSearch_BLL.AutoSearchCorporateEmployee(strSearchKeyemp);
                return result2;
            }
            else
            {

                List<string> result = new List<string>();
                result = objAutoSearch_BLL.AutoSearchEmployee(strSearchKeyemp, intjobid);
                return result;
            }

        }
           
        [WebMethod]
        public static List<string> GetAutoCompleteDataItem(int Uid, string strSearchKeyItem)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
           
             List<string> result2 = new List<string>();
             if (strSearchKeyItem.Trim().Length >= 3)
             {
                 result2 = objAutoSearch_BLL.AutoSearchIndentServiceList(Uid, strSearchKeyItem);
             }
                return result2;
            
           

        }
        protected void BtnMTask_Click(object sender, EventArgs e)
        {
           
                    //if (RadioPreventive.Checked == true)
                    //{

                    //    Int32 service = Int32.Parse(DdlService.SelectedValue.ToString());
                    //    string type = DdlType.SelectedItem.ToString();
                    //    Decimal cost = Decimal.Parse(TxtCost.Text.ToString());
                    //    Int32 Mnumber = Int32.Parse(TxtOrder.Text.ToString());


                    //    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    //    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

                    //    objMaintenance.MaitenanceTask(Mnumber, service, type, cost, intenroll, intjobid, intdept);

                    //}
                  decimal cost;
                    int service = int.Parse(DdlService.SelectedValue.ToString());
                    string serviceName = DdlService.SelectedItem.ToString();
                    string type = DdlType.SelectedItem.ToString();
                    try {  cost = decimal.Parse(TxtCost.Text.ToString()); }
                    catch {  cost = decimal.Parse(0.ToString()); }
                    int Mnumber = Int32.Parse(TxtOrder.Text.ToString());
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());



                    objMaintenance.RepairMaintenenceTaskInsert(Mnumber, service,serviceName,cost, type, intenroll, intjobid, intdept);

                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);
                    showdata();

               
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TxtAssign.Text))
                {
                    string strSearchKey = TxtAssign.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    HdfTechnicinCode.Value = searchKey[1];
                    int technichin = int.Parse(HdfTechnicinCode.Value.ToString());



                    int Mnumber = int.Parse(TxtOrder.Text.ToString());
                    string status = DdlStatus.SelectedItem.ToString();
                    //string ReparingType = DdlReType.SelectedItem.ToString();
                    // DateTime dteIssue = DateTime.Parse(TxtdteIssue.Text);
                    DateTime dteStart = DateTime.Parse(TxtdteStarted.Text);
                    //DateTime dteEnd = DateTime.Parse(TxtdteEnd.Text);
                    String priority = DdlPriority.SelectedItem.ToString();
                    string costcenter = DdlCostCenter.SelectedItem.ToString();
                    int intcostcenter = int.Parse(DdlCostCenter.SelectedValue.ToString());
                    string assign = TxtAssign.Text.ToString();
                    string notes = TxtNotes.Text.ToString();
                    string presentM = TxtPresentMilege.Text.ToString();
                    string nextM = TxtNextMilege.Text.ToString();
                    int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    vehicleNumber = HdnAssetid.Value.ToString();
                    int Heavy = int.Parse(DdlHevvyVehicle.SelectedValue.ToString());
                    objMaintenance.UpdateStatus(status, dteStart, priority, costcenter, assign, notes, intcostcenter, technichin, presentM, nextM,Heavy, Mnumber);
                     
                    if ( DdlStatus.SelectedItem.ToString() == "Close")
                    { 
                        objMaintenance.MaintenanceComplete(6, Mnumber, intenroll, intjobid, intdept);
                        objMaintenance.UpdateMilege(presentM, nextM, vehicleNumber);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Save');", true);

                    }
                  
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                   //     
                    //Response.Redirect("Maintenance.aspx", true);
                  }    
                 }
                catch{}
            
        }

        protected void RadioPreventive_CheckedChanged(object sender, EventArgs e)
        {
            int Mnumber = int.Parse(TxtOrder.Text.ToString());

            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString()); 

                    preventive = objMaintenance.PreventiveRepairsList(10, Mnumber, intenroll, intjobid, intdept);
                    DdlService.DataSource = preventive;
                    DdlService.DataTextField = "strServiceName";
                    DdlService.DataValueField = "intID";
                    DdlService.DataBind();
                    RadioRepair.Checked = false; 
        }

        protected void RadioRepair_CheckedChanged(object sender, EventArgs e)
        {
            //Int32 Mnumber= Convert.ToInt32(Session["intMaintenanceNo"].ToString());
            int Mnumber = int.Parse(TxtOrder.Text.ToString());
            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString()); 
          
                RadioPreventive.Checked = false;

             
                repair = objMaintenance.RepairsCommonList(11, Mnumber, intenroll, intjobid, intdept);
                DdlService.DataSource = repair;
                DdlService.DataTextField = "strRepairs";
                DdlService.DataValueField = "intID";
                DdlService.DataBind();
                RadioPreventive.Checked = false;

                int serviceiD = int.Parse(DdlService.SelectedValue.ToString());
                dt = new DataTable();
                dt = objMaintenance.CommonServiceCostView(serviceiD);
                if (dt.Rows.Count > 0)
                {
                    TxtCost.Text = dt.Rows[0]["monServiceCharge"].ToString();

                }
           
              
        }

        protected void BtnService_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('WorkOrderPartsPopUp.aspx');", true);

                }
                catch { }
            }
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maintenance.aspx", true);
        }

       

        protected void BtnAddIndent_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(TxtTechnichinSearch.Text) && !String.IsNullOrEmpty(SearchItem.Text))
            {
                string strSearchKey = TxtTechnichinSearch.Text;
                string[] searchKey = Regex.Split(strSearchKey, ";");
                HdfTechnicinCode.Value = searchKey[1];
                string qcpersonvalue = HdfTechnicinCode.Value.ToString();
                string qcpersonName = TxtTechnichinSearch.Text.ToString();

                string strSearchKeyItem = SearchItem.Text;
                string[] searchKeyItem = Regex.Split(strSearchKeyItem, ";");
                HiddenItemcode.Value = searchKeyItem[1];
                string itemvalue = HiddenItemcode.Value.ToString();
                string itemName = SearchItem.Text.ToString();

                dgvSrviceIndentView.Visible = false;

                string type = DdlIType.SelectedItem.ToString();
                string qty = TxtQty.Text.ToString();
                string dtedate = Txtdte.Text.ToString();
                string purpose = TxtPurpose.Text.ToString();
                hdn = "0".ToString();
              
                

                    for (int index =0; index < dgvservice.Rows.Count; index++)
                    {

                        string check = HiddenItemcode.Value.ToString();

                        if (((Label)dgvservice.Rows[index].FindControl("LblItemValue")).Text.ToString() == check)
                        {

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('All ready Insert');", true);
                            hdn="1".ToString();
                            //String intID = Convert.ToString(((Label)dgvservice.Rows[index].FindControl("LblItemValue")).Text.ToString());

                        }

                       

                    }
                    if (hdn != "1")
                    {
                        CreateVoucherXml(itemvalue, itemName, qty, type, qcpersonvalue, qcpersonName, dtedate, purpose);
                        hdn = "0".ToString();
                    }
                   
                   
               
            }
        }

        private void CreateVoucherXml(string itemvalue, string itemName, string qty, string type, string qcpersonvalue, string qcpersonName, string dtedate, string purpose)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemvalue, itemName, qty, type, qcpersonvalue, qcpersonName, dtedate, purpose);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemvalue, itemName, qty, type, qcpersonvalue, qcpersonName, dtedate, purpose);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvservice.DataSource = ds; }

                else { dgvservice.DataSource = ""; }
                dgvservice.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemvalue, string itemName, string qty, string type, string qcpersonvalue, string qcpersonName, string dtedate, string purpose)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Itemvalue = doc.CreateAttribute("itemvalue");
            Itemvalue.Value = itemvalue;
            XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;

            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Type = doc.CreateAttribute("type");
            Type.Value = type;
            XmlAttribute Qcpersonvalue = doc.CreateAttribute("qcpersonvalue");
            Qcpersonvalue.Value = qcpersonvalue;
            XmlAttribute QcpersonName = doc.CreateAttribute("qcpersonName");
            QcpersonName.Value = qcpersonName;
            XmlAttribute Dtedate = doc.CreateAttribute("dtedate");
            Dtedate.Value = dtedate;

            XmlAttribute Purpose = doc.CreateAttribute("purpose");
            Purpose.Value = purpose;

            node.Attributes.Append(Itemvalue);

            node.Attributes.Append(ItemName);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Type);
            node.Attributes.Append(Qcpersonvalue);
            node.Attributes.Append(QcpersonName);
            node.Attributes.Append(Dtedate);
            node.Attributes.Append(Purpose);

            return node;
        }

        protected void dgvservice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvservice.DataSource;
                dsGrid.Tables[0].Rows[dgvservice.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvservice.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvservice.DataSource = ""; dgvservice.DataBind(); }
                else { LoadGridwithXml(); }
            }

            catch { }
        }

        protected void BtnSubmitIn_Click(object sender, EventArgs e)
        {

            int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            int intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            int dept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
            //string Indenttype = DdlIType.SelectedItem.ToString();
            int whid = Int32.Parse(DdlUnitName.SelectedValue.ToString());
            int Mnumber = Int32.Parse(TxtOrder.Text.ToString());
            if (dgvservice.Rows.Count > 0)
            {
                dt = new DataTable();
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode vouchers = doc.SelectSingleNode("voucher");
                xmlString = vouchers.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                string msg = objMaintenance.PoServiceIndent(xmlString, Mnumber, whid, intenroll, intunitid, intjobid, dept);
                File.Delete(filePathForXML); dgvservice.DataSource = ""; dgvservice.DataBind(); LoadGridwithXml();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                dgvSrviceIndentView.Visible = true;
                showdata();

            }

        }

        protected void DdlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            int serviceiD = int.Parse(DdlService.SelectedValue.ToString());
            dt = new DataTable();
            dt = objMaintenance.CommonServiceCostView(serviceiD);
            if(dt.Rows.Count>0)
            {
                TxtCost.Text = dt.Rows[0]["monServiceCharge"].ToString();

            }
        }

        protected void btnServiceCharge_Click(object sender, EventArgs e)
        {
            try
            {
                if(hdnConfirm.Value=="1")
                {
                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    TextBox txtServiceCost = row.FindControl("txtServiceCharge") as TextBox;
                    Label lblServiceID = row.FindControl("lblServiceID") as Label;
                    int serviceId = int.Parse(lblServiceID.Text.ToString());
                    decimal serviceCost = decimal.Parse(txtServiceCost.Text.ToString());
                    objMaintenance.ServiceChargeUpdate(serviceId, serviceCost);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Service Charge Updated');", true);
                }
                
               

            }
            catch { }
        }
    }
}