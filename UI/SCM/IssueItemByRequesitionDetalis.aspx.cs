using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL.DropDown;
using BLL.Inventory;
using UI.ClassFiles;
using Utility;
using Model;

namespace UI.SCM
{
    public partial class IssueItemByRequesitionDetalis : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private CostCenterBll CostCenterBll = new CostCenterBll();
        private Location_BLL objOperation = new Location_BLL();
        private DataTable dt = new DataTable();
        private int intwh;
        private string filePathForXML, xmlString = "";
        private string filePathForText;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IssueItemByRequesitionDetalis";
        private string stop = "stopping SCM\\IssueItemByRequesitionDetalis";
        private string perform = "Performance on SCM\\IssueItemByRequesitionDetalis";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForText = Server.MapPath("~/SCM/Data/");
            filePathForXML = Server.MapPath("~/SCM/Data/sIn__" + HttpContext.Current.Session[SessionParams.USER_ID] + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                }
                string ReqCode = Request.QueryString["ReqCode"];
                DateTime dteReqDate = DateTime.Parse(Request.QueryString["dteReqDate"]);
                string strDepartmentName = Request.QueryString["strDepartmentName"];
                string strReqBy = Request.QueryString["strReqBy"];
                string strApproveBy = Request.QueryString["strApproveBy"];
                //string DeptId = Request.QueryString["DeptId"];
                //string SectionID = Request.QueryString["SectionID"];
                string SectionName = Request.QueryString["SectionName"];
                intwh = int.Parse(Request.QueryString["intwh"]);

                lblReqCode.Text = ReqCode;
                lblReqDate.Text = dteReqDate.ToString("dd-MM-yyyy");
                lblReqDept.Text = strDepartmentName;
                lblReqBy.Text = strReqBy;
                lblApproved.Text = strApproveBy;
                lblSection.Text = SectionName;

                LoadCostCenter(intwh);

                LoadGrid();
            }
        }

        public void LoadGrid()
        {
            intwh = int.Parse(Request.QueryString["intwh"]);
            int ReqId = int.Parse(Request.QueryString["ReqId"]);
            dt = objIssue.GetViewData(3, "", intwh, ReqId, DateTime.Now, Enroll);
            if (dt.Rows.Count > 0)
            {
                dgvDetalis.DataSource = dt;
                dgvDetalis.DataBind();
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
            }
        }

        private void LoadCostCenter(int whId)
        {
            dt = CostCenterBll.GetCostCenter(whId);
            ddlCost.LoadWithSelect(dt, "Id", "strName");
        }
        private readonly object _obj  = new object();
        protected void btnIssue_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnIssue_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btnIssue_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (dgvDetalis.Rows.Count > 0)
                {
                    try { File.Delete(filePathForXML); File.Delete(filePathForText); } catch { }

                    string receiveBy = txtReceiveBy.Text.Trim();
                    string reqId = Request.QueryString["ReqId"];
                    string reqCode = lblReqCode.Text;
                    string deptId = Request.QueryString["DeptId"];
                    string strSection = lblSection.Text;
                    string reqBy = lblReqBy.Text;
                    intwh = int.Parse(Request.QueryString["intwh"]);
                    int costCenterId = ddlCost.SelectedValue();
                    StoreIssue storeIssue = new StoreIssue
                    {
                        ReceiveBy = receiveBy,
                        RequsitionId = Convert.ToInt32(reqId),
                        RequsitionCode = reqCode,
                        DepartmentId = Convert.ToInt32(deptId),
                        CostCenterId = costCenterId,
                        Section = strSection,
                        WhId = intwh,
                        InsertBy = Enroll,
                        RequsitionDate = DateTime.Parse(Request.QueryString["dteReqDate"]).ToString("yyyy/MM/dd")
                    };

                    lock (_obj)
                    {
                        List<object> objects = new List<object>();
                        List<StoreIssueByItem> storeIssueByItems = new List<StoreIssueByItem>();
                        for (int index = 0; index < dgvDetalis.Rows.Count; index++)
                        {
                            string issueQty = ((TextBox)dgvDetalis.Rows[index].FindControl("txtIssue")).Text;
                            if (decimal.Parse(issueQty) > 0)
                            {
                                string itemId = ((Label)dgvDetalis.Rows[index].FindControl("lblItemId")).Text;
                                string stockVlaue = ((Label)dgvDetalis.Rows[index].FindControl("lblValue")).Text;
                                string locationId = ((DropDownList)dgvDetalis.Rows[index].FindControl("ddlStoreLocation")).SelectedValue;
                                string stockQty = ((Label)dgvDetalis.Rows[index].FindControl("lblStock")).Text;
                                string remarks = ((Label)dgvDetalis.Rows[index].FindControl("lblRemarks")).Text.Trim();
                                StoreIssueByItem storeIssueByItem = new StoreIssueByItem()
                                {
                                    IssueQuantity = Convert.ToDecimal(issueQty),
                                    StockQuantity = Convert.ToDecimal(stockQty),
                                    IssueValue = (Convert.ToDecimal(stockVlaue)/ Convert.ToDecimal(stockQty))* Convert.ToDecimal(issueQty),
                                    ItemId = Convert.ToInt32(itemId),
                                    LocationId = Convert.ToInt32(locationId),
                                    
                                    Remarks = remarks
                                };
                                storeIssueByItems.Add(storeIssueByItem);

                                dynamic obj = new
                                {
                                    itemId,
                                    issueQty,
                                    stockVlaue,
                                    locationId,
                                    stockQty,
                                    reqId,
                                    reqCode,
                                    deptId,
                                    strSection,
                                    reqBy,
                                    receiveBy,
                                    remarks,
                                    costCenterId
                                };
                                objects.Add(obj);
                            }
                            else
                            {
                                Toaster("Please input issue quantity", Common.TosterType.Warning);
                            }

                        }
                        
                        if (objects.Count > 0)
                        {
                            if (intwh == 1)
                            {
                                StoreIssueBll bll = new StoreIssueBll();
                                int issueId = bll.StoreIssue(storeIssue, storeIssueByItems);
                                if (issueId > 0)
                                {
                                    Alert("Successfully Issued with issueId:"+issueId);
                                }
                                else
                                {
                                    Alert("Something error in issue.");
                                }
                            }
                            else
                            {
                                xmlString = XmlParser.GetXml("issue", "issueEntry", objects, out string _);
                                string msg = objIssue.StoreIssue(5, xmlString, intwh, int.Parse(reqId), DateTime.Now,
                                    Enroll);
                                Alert(msg);
                            }
                            //xmlString = XmlParser.GetXml("issue", "issueEntry", objects, out string _);
                            //string msg = objIssue.StoreIssue(5, xmlString, intwh, int.Parse(reqId), DateTime.Now,
                            //    Enroll);
                            //Alert(msg);
                            dgvDetalis.UnLoad();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                        }
                        else
                        {
                            Toaster("You have to issue at least 1 item ", Common.TosterType.Warning);
                        }
                    }

                    //XmlDocument doc = new XmlDocument();
                    //doc.Load(filePathForXML);
                    //XmlNode dSftTm = doc.SelectSingleNode("issue");
                    //xmlString = dSftTm.InnerXml;
                    //xmlString = "<issue>" + xmlString + "</issue>";
                    //try { File.Delete(filePathForXML); } catch { }
                    //string msg = objIssue.StoreIssue(5, xmlString, intwh, int.Parse(reqId), DateTime.Now, Enroll);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
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

        private void CreateXmlIssue(string itemId, string issueQty, string stockVlaue, string locationId, string stockQty, string reqId, string reqCode, string deptId, string strSection, string reqBy, string costCenterId,string receiveBy,string Remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNode(doc, itemId, issueQty, stockVlaue, locationId, stockQty, reqId, reqCode, deptId, strSection, reqBy, receiveBy,Remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNode(doc, itemId, issueQty, stockVlaue, locationId, stockQty, reqId, reqCode, deptId, strSection, reqBy, receiveBy, Remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        protected void ddlStoreLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;
                DropDownList ddlLocation = row.FindControl("ddlStoreLocation") as DropDownList;
                int locationId = int.Parse(ddlLocation.SelectedValue);

                Label lblItemId = row.FindControl("lblItemId") as Label;
                Label lblstock = row.FindControl("lblStock") as Label;
                Label lblvalue = row.FindControl("lblValue") as Label;
                TextBox txtIsueQty = row.FindControl("txtIssue") as TextBox;

                int itemid = int.Parse(lblItemId.Text);
               
                intwh = int.Parse(Request.QueryString["intwh"]);
                txtIsueQty.Text = "0";
                dt = objIssue.GetViewData(18, "", intwh, locationId, DateTime.Now, itemid);
                if(dt.Rows.Count>0)
                {
                   lblstock.Text =dt.Rows[0]["monStock"].ToString();
                   lblvalue.Text = dt.Rows[0]["monValue"].ToString();

                }


            }
            catch { }
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string issueQty, string stockVlaue, string locationId, string stockQty, string reqId, string reqCode, string deptId, string strSection, string reqBy, string receiveBy,string Remarks)
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
            XmlAttribute Remark = doc.CreateAttribute("Remarks");
            ReceiveBy.Value = Remarks;

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
            node.Attributes.Append(Remark);
            return node;
        }

        protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // your code to get data
                // I assumed you are getting data in dataset using some query

                Label lblItem = (Label)e.Row.FindControl("lblItemId");
                int Item = int.Parse(lblItem.Text.ToString());
                
                intwh = int.Parse(Request.QueryString["intwh"]);
                //dt = objOperation.WhDataView(8, "", intwh, Item, 1);

                dt = objIssue.GetViewData(19, "", intwh, 0, DateTime.Now, Item);
                if (dt.Rows.Count > 0)
                { 
                    DropDownList ddlLocation = (e.Row.FindControl("ddlStoreLocation") as DropDownList);
                    ddlLocation.DataSource = dt;
                    ddlLocation.DataValueField = "Id";
                    ddlLocation.DataTextField = "strName";
                    ddlLocation.DataBind();

                    try
                    {
                        
                        Label lblstock = (Label)e.Row.FindControl("lblstock");
                        Label lblvalue = (Label)e.Row.FindControl("lblvalue");

                        dt = objIssue.GetViewData(18, "", intwh, int.Parse(ddlLocation.SelectedValue), DateTime.Now, Item);
                        if (dt.Rows.Count > 0)
                        {
                            lblstock.Text = dt.Rows[0]["monStock"].ToString();
                            lblvalue.Text = dt.Rows[0]["monValue"].ToString();

                        }
                        else
                        {

                            lblstock.Text = "0";
                            lblvalue.Text = "0";
                        }
                    }
                    catch { }
                }

              
            }
        }
    }
}