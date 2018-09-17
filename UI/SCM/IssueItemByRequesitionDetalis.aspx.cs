using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;




namespace UI.SCM
{
    public partial class IssueItemByRequesitionDetalis :BasePage
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();
        Location_BLL objOperation = new Location_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh;
        string filePathForXML,  xmlString = "";
        private string filePathForText;

        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\IssueItemByRequesitionDetalis";
        string stop = "stopping SCM\\IssueItemByRequesitionDetalis";
        string perform = "Performance on SCM\\IssueItemByRequesitionDetalis";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            filePathForText = Server.MapPath("~/SCM/Data/");
            filePathForXML = Server.MapPath("~/SCM/Data/sIn__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                int ReqId = int.Parse(Request.QueryString["ReqId"].ToString());
                string ReqCode = Request.QueryString["ReqCode"].ToString();
                DateTime dteReqDate = DateTime.Parse(Request.QueryString["dteReqDate"].ToString());
                string strDepartmentName = Request.QueryString["strDepartmentName"].ToString();
                string strReqBy = Request.QueryString["strReqBy"].ToString();
                string strApproveBy = Request.QueryString["strApproveBy"].ToString();
                string DeptId= Request.QueryString["DeptId"].ToString();
                string SectionID= Request.QueryString["SectionID"].ToString();
                string SectionName = Request.QueryString["SectionName"].ToString();
                intwh = int.Parse(Request.QueryString["intwh"].ToString());
                
                lblReqCode.Text = ReqCode;
                lblReqDate.Text = dteReqDate.ToString("dd-MM-yyyy");
                lblReqDept.Text = strDepartmentName;
                lblReqBy.Text = strReqBy;
                lblApproved.Text = strApproveBy;
                lblSection.Text = SectionName;

                dt = objIssue.GetViewData(4, "", intwh, ReqId, DateTime.Now, enroll);
                ddlCost.DataSource = dt;
                ddlCost.DataTextField = "strName";
                ddlCost.DataValueField = "Id";
                ddlCost.DataBind(); 

                dt = objIssue.GetViewData(3, "", intwh, ReqId, DateTime.Now, enroll);
                dgvDetalis.DataSource = dt;
                dgvDetalis.DataBind();
            }
            else { }

           
            
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnIssue_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btnIssue_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (dgvDetalis.Rows.Count > 0 && hdnConfirm.Value.ToString() == "1")
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    try { File.Delete(filePathForXML); File.Delete(filePathForText); } catch { }

                    string receiveBy = txtReceiveBy.Text.ToString();
                    string reqId=Request.QueryString["ReqId"].ToString();
                    string reqCode = lblReqCode.Text.ToString();
                    string deptId= Request.QueryString["DeptId"].ToString();
                    string strSection = lblSection.Text;
                    string reqBy = lblReqBy.Text.ToString();
                    intwh=int.Parse(Request.QueryString["intwh"].ToString());

                    for (int index = 0; index < dgvDetalis.Rows.Count; index++)
                    { 
                        string itemId = ((Label)dgvDetalis.Rows[index].FindControl("lblItemId")).Text.ToString(); 
                        string itemName = ((Label)dgvDetalis.Rows[index].FindControl("lblItem")).Text.ToString(); 
                        string itemUnit = ((Label)dgvDetalis.Rows[index].FindControl("lblUom")).Text.ToString(); 
                        string issueQty= ((TextBox)dgvDetalis.Rows[index].FindControl("txtIssue")).Text.ToString();

                        string stockVlaue = ((Label)dgvDetalis.Rows[index].FindControl("lblValue")).Text.ToString();
                        string locationId = ((DropDownList)dgvDetalis.Rows[index].FindControl("ddlStoreLocation")).SelectedValue.ToString();

                        string stockQty = ((Label)dgvDetalis.Rows[index].FindControl("lblStock")).Text.ToString(); 
                       
                        
                        if (decimal.Parse(issueQty) > 0)
                        {

                           CreateXmlIssue( itemId,issueQty,stockVlaue,locationId,stockQty,reqId,reqCode,deptId,strSection,reqBy,receiveBy);
                        }

                       
                    }
                    

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("issue");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<issue>" + xmlString + "</issue>";
                    try { File.Delete(filePathForXML); } catch { }
                    string msg = objIssue.StoreIssue(5, xmlString, intwh, int.Parse(reqId), DateTime.Now, enroll);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);


                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
        
            tracker.Stop();
        }

        //private bool CopyTextFile(Common.ModulaFileName fileName)
        //{
        //    return Common.CopyFile(Common.GetModulaFullPath(ProjectConfig.Instance.MudulaLocalFileBasePath, fileName), Common.GetModulaFullPath(ProjectConfig.Instance.MudulaRemoteFileBasePath, fileName));
        //}
        //private ModularItem GetModularItem(string itemCode, string itemName, string itemUnit)
        //{
        //    return new ModularItem
        //    {
        //        ItemCode = itemCode,
        //        ItemName = itemName,
        //        Unit = itemUnit
        //    };
        //}
        //private ModularOrder GetModularOrder(string orderNumbner, string orderDescription, string OprationType)
        //{
        //    return new ModularOrder
        //    {
        //        OrderNumber = orderNumbner,
        //        OrderDescription = orderDescription,
        //        OperationType = OprationType
        //    };
        //}
        //private ModularOrderLine GetModularOrderLine(string orderNumbner, string itemCode, string quantity)
        //{
        //    return new ModularOrderLine
        //    {
        //        OrderNumber = orderNumbner,
        //        ItemCode = itemCode,
        //        Quantity = quantity
        //    };
        //}
        //private ModularStockUpdate GetModularStockUpdate(string itemCode, string quantity)
        //{
        //    return new ModularStockUpdate
        //    {
        //        ItemCode = itemCode,
        //        Quantity = quantity
        //    };
        //}

        private void CreateXmlIssue(string itemId, string issueQty, string stockVlaue, string locationId, string stockQty, string reqId, string reqCode, string deptId, string strSection, string reqBy, string receiveBy)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNode(doc, itemId, issueQty, stockVlaue, locationId, stockQty, reqId, reqCode, deptId, strSection, reqBy, receiveBy);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNode(doc, itemId, issueQty, stockVlaue, locationId, stockQty, reqId, reqCode, deptId, strSection, reqBy, receiveBy);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string issueQty, string stockVlaue, string locationId, string stockQty, string reqId, string reqCode, string deptId, string strSection, string reqBy, string receiveBy)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute IssueQty = doc.CreateAttribute("issueQty");
            IssueQty.Value = issueQty;
            XmlAttribute StockVlaue = doc.CreateAttribute("stockVlaue");
            StockVlaue.Value = stockVlaue;
            XmlAttribute LocationId = doc.CreateAttribute("locationId");
            LocationId.Value = locationId;

            XmlAttribute StockQty = doc.CreateAttribute("stockQty");
            StockQty.Value = stockQty;
            XmlAttribute ReqId = doc.CreateAttribute("reqId");
            ReqId.Value = reqId;
            XmlAttribute ReqCode = doc.CreateAttribute("reqCode");
            ReqCode.Value = reqCode;
            XmlAttribute DeptId = doc.CreateAttribute("deptId");
            DeptId.Value = deptId;
            XmlAttribute StrSection = doc.CreateAttribute("strSection");
            StrSection.Value = strSection;
            XmlAttribute ReqBy = doc.CreateAttribute("reqBy");
            ReqBy.Value = reqBy;
            XmlAttribute ReceiveBy = doc.CreateAttribute("receiveBy");
            ReceiveBy.Value = receiveBy; 

            node.Attributes.Append(ItemId);
            node.Attributes.Append(IssueQty);
            node.Attributes.Append(StockVlaue);
            node.Attributes.Append(LocationId); 
            node.Attributes.Append(StockQty);
            node.Attributes.Append(ReqId);
            node.Attributes.Append(ReqCode);
            node.Attributes.Append(DeptId);
            node.Attributes.Append(StrSection);
            node.Attributes.Append(ReqBy);

            node.Attributes.Append(ReceiveBy); 
            return node;
        }

        protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // your code to get data 
                // I assumed you are getting data in dataset using some query

                Label lblItem = (Label)e.Row.FindControl("lblItemId");
                int Item = int.Parse(lblItem.Text);

                intwh = int.Parse(Request.QueryString["intwh"].ToString());
                dt = objOperation.WhDataView(8, "", intwh, Item, 1);
                DropDownList ddlLocation = (e.Row.FindControl("ddlStoreLocation") as DropDownList);
                ddlLocation.DataSource = dt;
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataBind();
            }
        }
    }
}