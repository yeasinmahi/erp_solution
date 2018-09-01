using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using HR_BLL.TourPlan;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{
    public partial class CustomerBankGauranteeReport : BasePage
    {
        CustBankGauranteeBLL objbankGauranteeBLL = new CustBankGauranteeBLL();
        DataTable dt = new DataTable();
        string xmlpath, xmlString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/HR/TourPlan/Data/CustomerListUpdateDelete_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                GVList.DataSource = null;
                GVList.DataBind();
                GVUpdate.DataSource = null;
                GVUpdate.DataBind();
                GVDelete.DataSource = null;
                GVDelete.DataBind();

            }
         
            //lbltitle.Visible = false;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            DateTime fdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime tdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int InsertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            int category = int.Parse(DdlReport.SelectedItem.Value);
            if (category == 1)  // for report
            {
                dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 4, 0); //type = 1 when showing all data
                if (dt.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                }
                else
                {
                    GVUpdate.DataSource = null;
                    GVUpdate.DataBind();
                    GVList.DataSource = dt;
                    GVList.DataBind();
                    GVDelete.DataSource = null;
                    GVDelete.DataBind();
                    lbltitle.Visible = true;
                }
            }
            else if (category == 2) // for update
            {
                dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 4, 0); //type = 1 when showing all data
                if (dt.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                }
                else
                {
                    GVList.DataSource = null;
                    GVList.DataBind();               
                    GVUpdate.DataSource = dt;
                    GVUpdate.DataBind();
                    GVDelete.DataSource = null;
                    GVDelete.DataBind();
                    lbltitle.Visible = true;
                }
            }
            else if (category == 3)  // for delete
            {
                dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 4, 0); //type = 1 when showing all data
                if (dt.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data not found');", true);
                }
                else
                {
                    GVList.DataSource = null;
                    GVList.DataBind();
                    GVUpdate.DataSource = null;
                    GVUpdate.DataBind();
                    GVDelete.DataSource = dt;
                    GVDelete.DataBind();
                    lbltitle.Visible = true;
                }
            }


        }

        #region========gridview row updating==========
        protected void GVUpdate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            int InsertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            DateTime fdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime tdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            GVUpdate.EditIndex = -1;
            dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 4, 0); //type = 1 when showing all data
            GVUpdate.DataSource = dt;
            GVUpdate.DataBind();
        }

        protected void GVUpdate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int InsertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            GVUpdate.EditIndex = e.NewEditIndex;
            DateTime fdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime tdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 4, 0); //type = 1 when showing all data
            GVUpdate.DataSource = dt;
            GVUpdate.DataBind();
            
        }

        protected void GVUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DateTime fdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime tdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;           
            string Id = GVUpdate.DataKeys[e.RowIndex].Value.ToString();
            TextBox strcustname = GVUpdate.Rows[e.RowIndex].FindControl("txtstrcustname") as TextBox;
            TextBox BankName = GVUpdate.Rows[e.RowIndex].FindControl("txtBankName") as TextBox;
            TextBox branchname = GVUpdate.Rows[e.RowIndex].FindControl("txtbranchname") as TextBox;
            TextBox lienno = GVUpdate.Rows[e.RowIndex].FindControl("txtlienno") as TextBox;
            TextBox bgamount = GVUpdate.Rows[e.RowIndex].FindControl("txtbgamount") as TextBox;
            TextBox bgstartdate = GVUpdate.Rows[e.RowIndex].FindControl("txtbgstartdate") as TextBox;
            TextBox bgenddate = GVUpdate.Rows[e.RowIndex].FindControl("txtbgenddate") as TextBox;
            int InsertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            CreateXml(Id, strcustname.Text, BankName.Text, branchname.Text, lienno.Text, bgamount.Text, bgstartdate.Text, bgenddate.Text);
            
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode xmls;
                    if (File.Exists(xmlpath))
                    {
                        doc.Load(xmlpath);
                        xmls = doc.SelectSingleNode("RemoteProgramBill");
                        xmlString = xmls.InnerXml;
                        xmlString = "<RemoteProgramBill>" + xmlString + "</RemoteProgramBill>";
                        objbankGauranteeBLL.GetCustomerBGauranteeList(2,InsertBy,xmlString,fdate,tdate,1,0); //type = 2 when update action works
                    GVUpdate.EditIndex = -1;
                    dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 1, 0); //type = 1 when showing all data
                    GVUpdate.DataSource = dt;
                    GVUpdate.DataBind();
                    try { File.Delete(xmlpath); }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                        }
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your Request is Successfully Updated...');", true);

                }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
           
        }

        #endregion======gridview row updating end==========

        #region=====girdview row delete========
        protected void GVDelete_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DateTime fdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime tdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            Label strcustname = GVDelete.Rows[e.RowIndex].FindControl("lblstrcustname") as Label;
            Label BankName = GVDelete.Rows[e.RowIndex].FindControl("lblbankname") as Label;
            Label branchname = GVDelete.Rows[e.RowIndex].FindControl("lblbranchname") as Label;
            Label lienno = GVDelete.Rows[e.RowIndex].FindControl("lbllienno") as Label;
            Label bgamount = GVDelete.Rows[e.RowIndex].FindControl("lblbgamount") as Label;
            Label bgstartdate = GVDelete.Rows[e.RowIndex].FindControl("lblbgstartdate") as Label;
            Label bgenddate = GVDelete.Rows[e.RowIndex].FindControl("lblbgenddate") as Label;
            string Id = GVDelete.DataKeys[e.RowIndex].Value.ToString();
            int InsertBy = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            CreateXml(Id, strcustname.Text, BankName.Text, branchname.Text, lienno.Text, bgamount.Text, bgstartdate.Text, bgenddate.Text);
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode xmls;
                if (File.Exists(xmlpath))
                {
                    doc.Load(xmlpath);
                    xmls = doc.SelectSingleNode("RemoteProgramBill");
                    xmlString = xmls.InnerXml;
                    xmlString = "<RemoteProgramBill>" + xmlString + "</RemoteProgramBill>";
                    objbankGauranteeBLL.GetCustomerBGauranteeList(3, InsertBy, xmlString, fdate, tdate, 1, 0); // type = 3 when delete action works
                    GVDelete.EditIndex = -1;
                    dt = objbankGauranteeBLL.GetCustomerBGauranteeList(1, InsertBy, "", fdate, tdate, 1, 0);  //type = 1 when showing all data
                    GVDelete.DataSource = dt;
                    GVDelete.DataBind();
                    try { File.Delete(xmlpath); }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                    }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Deleted...');", true);

                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

        }

        #endregion=======gridview row delete end==========

        #region====== create xml===========
        private void CreateXml(string pkid,string custName, string bankName, string branchName, string lienNo, string Amount, string fromdate, string todate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteProgramBill");
                XmlNode addItem = CreateNode(doc, pkid,custName, bankName, branchName, lienNo, Amount, fromdate, todate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclarationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclarationNode);
                XmlNode rootNode = doc.CreateElement("RemoteProgramBill");
                XmlNode addItem = CreateNode(doc, pkid, custName, bankName, branchName, lienNo, Amount, fromdate, todate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadXml();
        }

        private XmlNode CreateNode(XmlDocument doc,string pkid, string custName, string bankName, string branchName, string lienNo, string Amount, string fromdate, string todate)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Pkid = doc.CreateAttribute("pkid");
            Pkid.Value = pkid;
            XmlAttribute CustName = doc.CreateAttribute("custmname");
            CustName.Value = custName;
            XmlAttribute BankName = doc.CreateAttribute("bankname");
            BankName.Value = bankName;
            XmlAttribute BranchName = doc.CreateAttribute("branchname");
            BranchName.Value = branchName;
            XmlAttribute LienNo = doc.CreateAttribute("lienno");
            LienNo.Value = lienNo;
            XmlAttribute amount = doc.CreateAttribute("bgamount");
            amount.Value = Amount;
            XmlAttribute Fromdate = doc.CreateAttribute("bgstartdate");
            Fromdate.Value = fromdate;
            XmlAttribute Todate = doc.CreateAttribute("bgenddate");
            Todate.Value = todate;

            node.Attributes.Append(Pkid);
            node.Attributes.Append(CustName);
            node.Attributes.Append(BankName);
            node.Attributes.Append(BranchName);
            node.Attributes.Append(LienNo);
            node.Attributes.Append(amount);
            node.Attributes.Append(Fromdate);
            node.Attributes.Append(Todate);

            return node;
        }

        

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("RemoteProgramBill");
                xmlString = xlnd.InnerXml;
                xmlString = "<RemoteProgramBill>" + xmlString + "</RemoteProgramBill>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GVUpdate.DataSource = ds;
                }
                else
                {
                    GVUpdate.DataSource = "";
                }
                GVUpdate.DataBind();
               
            }
            catch
            {
                GVUpdate.DataSource = "";
                GVUpdate.DataBind();
            }

        }

        #endregion==========end creating xml=========







    }
}