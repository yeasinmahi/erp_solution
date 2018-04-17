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
using System.Collections;

namespace UI.BudgetPlan
{
    public partial class BudgetPlanning_Requesition : System.Web.UI.Page
    {
        BudgetOperation_BLL objOperation = new BudgetOperation_BLL();
        DataTable dt = new DataTable();

        int parentID;
        int unitID;
        string filePathForXMLOperation;

        string xmlStringOperation= "";
        string filePathForXMLAssetAccoA;

        string xmlStringAssetAccoA = "";
        string optype, opex; int item; string hdn; string data; int check; string h = ""; ArrayList arr;
        public string jsString = ""; string pID,pIDName, k, accountName, ysnEnable, ysnhasModule, gridNum;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMLAssetAccoA = Server.MapPath("~/BudgetPlan/Data/AssetAccoIA_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLOperation = Server.MapPath("~/BudgetPlan/Data/Operation_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
         
            if(!IsPostBack)
            {
             
                try { File.Delete(filePathForXMLAssetAccoA); File.Delete(filePathForXMLOperation); }
                catch { }
                dgvlist.Visible = true; dgvUser.Visible = true;
                int intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objOperation.CostCenterName(intunit);
                DdlCostCenter.DataSource = dt;
                DdlCostCenter.DataTextField = "Name";
                DdlCostCenter.DataValueField = "ID";
                DdlCostCenter.DataBind();
               
                dt = new DataTable();
                dt = objOperation.OperationUserView(enroll);
                dgvUser.DataSource = dt;
                dgvUser.DataBind();

                dt = new DataTable();
                dt = objOperation.userdetalisview(enroll);
                dgvlist.DataSource = dt;
                dgvlist.DataBind();

       


                dt = new DataTable();
                dt = objOperation.ProjectParent(intunit);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strAccName";
                ListBox1.DataValueField = "intAccID";
                ListBox1.DataBind();

                pnlUpperControl.DataBind();

               
               
                

                //try
                //{
                //    Ping myPing = new Ping();
                //    String host = "erp.akij.net";
                //    byte[] buffer = new byte[32];
                //    int timeout = 1;
                //    PingOptions pingOptions = new PingOptions();
                //    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                //    if (reply.Status == IPStatus.Success)
                //    {

                //        Label5.Text = "Network:||||||".ToString();
                //        Label5.ForeColor = System.Drawing.Color.Green;
                //    }
                   
                //}
                //catch (Exception)
                //{
                //    Label5.Text = "Network:-----!".ToString();
                //    Label5.ForeColor = System.Drawing.Color.Red;
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please contact with IT Department');", true);
                //}
            }
        }

        protected void OperationID_CheckedChanged(object sender, EventArgs e)
        {
            NonOperationID.Checked = false;
            OperationID.Checked = true;
            dgvlist.Visible = true; dgvUser.Visible = true;
            try { File.Delete(filePathForXMLAssetAccoA); dgvnonOperation.DataSource = ""; dgvnonOperation.DataBind(); }
            catch { }
            dgvbudget.DataSource = ""; dgvbudget.DataBind(); 
          
        }

        protected void NonOperationID_CheckedChanged(object sender, EventArgs e)
        {
            OperationID.Checked = false;

            NonOperationID.Checked = true;

            dgvlist.Visible = true; dgvUser.Visible = true;
            try { File.Delete(filePathForXMLOperation); dgvbudget.DataSource = ""; dgvbudget.DataBind(); }
            catch { }

        }

        protected void OpexID_CheckedChanged(object sender, EventArgs e)
        {
            OpexID.Checked = true;

            CapexID.Checked = false;
        }

        protected void CapexID_CheckedChanged(object sender, EventArgs e)
        {
            CapexID.Checked = true;

            OpexID.Checked = false;

        }

       

        

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string amount;
                string costcenter = DdlCostCenter.SelectedItem.ToString();
                string costid = DdlCostCenter.SelectedValue.ToString();
                string opname = hdnOpName.Value.ToString();
                string opnameid =   hdnOpID.Value.ToString();
             
               

                

                if (OperationID.Checked == true) { optype = "Operation".ToString(); }
                if (NonOperationID.Checked == true) { optype = "nonOperation".ToString(); }
                string nmaetype = DdlOpName.SelectedItem.ToString();
                string nametypeid = DdlOpName.SelectedValue.ToString();
                if (OpexID.Checked == true) { opex = "Opex".ToString(); }
                if (CapexID.Checked == true) { opex = "Capex".ToString(); }

                hdn = "0".ToString();
                 amount = TxtAmount.Text.ToString();

                 dgvlist.Visible = false; dgvUser.Visible = false;
                 if (OperationID.Checked == true && (CapexID.Checked==true||OpexID.Checked==true))
                {
                    for (int index = 0; index < dgvbudget.Rows.Count; index++)
                    {

                        string check = DdlOpName.SelectedValue.ToString();

                        if (((Label)dgvbudget.Rows[index].FindControl("LblnmaetypeID")).Text.ToString() == check)
                        {

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('All ready Insert');", true);
                             hdn = "1".ToString();
                            //String intID = Convert.ToString(((Label)dgvservice.Rows[index].FindControl("LblItemValue")).Text.ToString());

                        }
                       
                    }
                    if(hdn!="1")
                        {
                            string currentYear = DateTime.Now.Year.ToString();
                            Int32 year = Int32.Parse(currentYear.ToString()) + 1;
                            lblCaption.Text = "Financial Budget Year " + currentYear + "-" + year.ToString();
                            decimal decamount = decimal.Parse(amount.ToString()) / 12;
                            string amountF = decamount.ToString("N2");
                            string fyear = currentYear.ToString(); string toyear = year.ToString();

                            string july = amountF.ToString(); string agust = amountF.ToString(); string sep = amountF.ToString(); string oct = amountF.ToString();
                            string nov = amountF.ToString(); string dec = amountF.ToString(); string jan = amountF.ToString(); string feb = amountF.ToString();
                            string march = amountF.ToString(); string april = amountF.ToString(); string may = amountF.ToString(); string jun = amountF.ToString();
                            dgvnonOperation.Visible = false;
                            dgvbudget.Visible = true;
                            CreateOperationXml(costcenter, costid, opname, opnameid, optype, nmaetype, nametypeid,opex, amount, fyear, toyear, july, agust, sep, oct, nov, dec, jan, feb, march, april, may, jun);
                            hdn = "0".ToString();    
                    }
                }
                 else if (NonOperationID.Checked == true && (CapexID.Checked == true || OpexID.Checked == true))
                {
                    for (int index = 0; index < dgvnonOperation.Rows.Count; index++)
                    {

                        string check = DdlOpName.SelectedValue.ToString();

                        if (((Label)dgvnonOperation.Rows[index].FindControl("LblnmaetypeID")).Text.ToString() == check)
                        {

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('All ready Insert');", true);
                             hdn = "1".ToString();
                            

                        }
                       
                    }
                    if(hdn!="1")
                        {
                            string currentYear = DateTime.Now.Year.ToString();
                            Int32 year = Int32.Parse(currentYear.ToString()) + 1;
                            lblCaption.Text = "Financial Budget Year " + currentYear + "-" + year.ToString();
                            decimal decamount = decimal.Parse(amount.ToString()) / 12;
                            string amountF = decamount.ToString("N2");
                            string fyear = currentYear.ToString(); string toyear = year.ToString();


                            dgvnonOperation.Visible = true;
                            dgvbudget.Visible = false;
                            CreateVoucherXml(costcenter, costid, opname, opnameid, optype, nmaetype, nametypeid, opex, amount, fyear, toyear);
                            hdn = "0".ToString();
                    }
                }
            }
            catch { }
        }

        private void CreateOperationXml(string costcenter,string costid, string opname,string opnameid, string optype, string nmaetype,string nametypeid, string opex,string amount,string fyear,string toyear, string july, string agust, string sep, string oct, string nov, string dec, string jan, string feb, string march,  string april, string may, string jun)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLOperation))
            {
                doc.Load(filePathForXMLOperation);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeOperation(doc, costcenter, costid, opname, opnameid,  optype, nmaetype,nametypeid, opex, amount, fyear, toyear, july, agust, sep, oct, nov, dec, jan, feb, march, april, may, jun);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeOperation(doc, costcenter, costid, opname, opnameid, optype, nmaetype,nametypeid, opex, amount, fyear, toyear, july, agust, sep, oct, nov, dec, jan, feb, march, april, may, jun);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLOperation);
            LoadGridwithOperationXml();
        }

        private void LoadGridwithOperationXml()
        {
            try
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(filePathForXMLOperation);
                XmlNode dSftTms = doc2.SelectSingleNode("voucher");
                xmlStringOperation = dSftTms.InnerXml;
                xmlStringOperation = "<voucher>" + xmlStringOperation + "</voucher>";
                StringReader srs = new StringReader(xmlStringOperation);
                DataSet dss = new DataSet();
                dss.ReadXml(srs);
                if (dss.Tables[0].Rows.Count > 0)
                { dgvbudget.DataSource = dss; }

                else { dgvbudget.DataSource = ""; }
                dgvbudget.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeOperation(XmlDocument doc, string costcenter, string costid, string opname,string opnameid, string optype, string nmaetype,string nametypeid, string opex, string amount, string fyear,string  toyear,string july, string agust, string sep, string oct, string nov, string dec, string jan, string feb, string march, string april, string may, string jun)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Costcenter = doc.CreateAttribute("costcenter");
            Costcenter.Value = costcenter;
            XmlAttribute Costid = doc.CreateAttribute("costid");
            Costid.Value = costid;
            XmlAttribute Opname = doc.CreateAttribute("opname");
            Opname.Value = opname;
            XmlAttribute Opnameid = doc.CreateAttribute("opnameid");
            Opnameid.Value = opnameid;
          
            XmlAttribute Optype = doc.CreateAttribute("optype");
            Optype.Value = optype;
            XmlAttribute Nmaetype = doc.CreateAttribute("nmaetype");
            Nmaetype.Value = nmaetype;
            XmlAttribute Nametypeid = doc.CreateAttribute("nametypeid");
            Nametypeid.Value = nametypeid;
            XmlAttribute Opex = doc.CreateAttribute("opex");
            Opex.Value = opex;
          
          
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            XmlAttribute Fyear = doc.CreateAttribute("fyear");
            Fyear.Value = fyear;
            XmlAttribute Toyear = doc.CreateAttribute("toyear");
            Toyear.Value = toyear;
            XmlAttribute July = doc.CreateAttribute("july");
            July.Value = july;
            XmlAttribute Agust = doc.CreateAttribute("agust");
            Agust.Value = agust;
            XmlAttribute Sep = doc.CreateAttribute("sep");
            Sep.Value = sep;
            XmlAttribute Oct = doc.CreateAttribute("oct");
            Oct.Value = oct;
            XmlAttribute Nov = doc.CreateAttribute("nov");
            Nov.Value = nov;
            XmlAttribute Dec = doc.CreateAttribute("dec");
            Dec.Value = dec;
            XmlAttribute Jan = doc.CreateAttribute("jan");
            Jan.Value = jan;
            XmlAttribute Feb = doc.CreateAttribute("feb");
            Feb.Value = feb;
            XmlAttribute March = doc.CreateAttribute("march");
            March.Value = march;

            XmlAttribute April = doc.CreateAttribute("april");
            April.Value = jan;
            XmlAttribute May = doc.CreateAttribute("may");
            May.Value = may;
            XmlAttribute Jun = doc.CreateAttribute("jun");
            Jun.Value = jun;



            node.Attributes.Append(Costcenter);
            node.Attributes.Append(Costid);
            node.Attributes.Append(Opname);

            node.Attributes.Append(Opnameid);
          
            node.Attributes.Append(Optype);
            node.Attributes.Append(Nmaetype);
            node.Attributes.Append(Nametypeid);
            node.Attributes.Append(Opex);
        
           
           
            node.Attributes.Append(Amount);
            node.Attributes.Append(Fyear);
            node.Attributes.Append(Toyear);

            node.Attributes.Append(July);
            node.Attributes.Append(Agust);
            node.Attributes.Append(Sep);
            node.Attributes.Append(Oct);
            node.Attributes.Append(Nov);
            node.Attributes.Append(Dec);
            node.Attributes.Append(Jan);
            node.Attributes.Append(Feb);
            node.Attributes.Append(March);
            node.Attributes.Append(April);
            node.Attributes.Append(May);
            node.Attributes.Append(Jun);




            return node;
        }

        private void CreateVoucherXml(string costcenter, string costid,string opname,string opnameid,string optype, string nmaetype,string nametypeid, string opex,  string amount,string fyear, string toyear)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAssetAccoA))
            {
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeNonOperation(doc, costcenter, costid, opname, opnameid, optype, nmaetype, nametypeid, opex, amount, fyear, toyear);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeNonOperation(doc, costcenter, costid, opname, opnameid, optype, nmaetype, nametypeid, opex, amount, fyear, toyear);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAssetAccoA);
            LoadGridwithXml();
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlStringAssetAccoA = dSftTm.InnerXml;
                xmlStringAssetAccoA = "<voucher>" + xmlStringAssetAccoA + "</voucher>";
                StringReader sr = new StringReader(xmlStringAssetAccoA);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvnonOperation.DataSource = ds; }

                else { dgvnonOperation.DataSource = ""; }
                dgvnonOperation.DataBind();
            }
            catch { }
        }


        private XmlNode CreateItemNodeNonOperation(XmlDocument doc, string costcenter,string costid, string opname, string opnameid,  string optype, string nmaetype, string nametypeid, string opex, string amount,string fyear,string  toyear)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Costcenter = doc.CreateAttribute("costcenter");
            Costcenter.Value = costcenter;

            XmlAttribute Costid = doc.CreateAttribute("costid");
            Costid.Value = costid;
            XmlAttribute Opname = doc.CreateAttribute("opname");
            Opname.Value = opname;
            XmlAttribute Opnameid = doc.CreateAttribute("opnameid");
            Opnameid.Value = opnameid;
           

            XmlAttribute Optype = doc.CreateAttribute("optype");
            Optype.Value = optype;
            XmlAttribute Nmaetype = doc.CreateAttribute("nmaetype");
            Nmaetype.Value = nmaetype;
            XmlAttribute Nametypeid = doc.CreateAttribute("nametypeid");
            Nametypeid.Value = nametypeid;
            XmlAttribute Opex = doc.CreateAttribute("opex");
            Opex.Value = opex;
           
           
           
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

              XmlAttribute Fyear = doc.CreateAttribute("fyear");
            Fyear.Value = fyear;
              XmlAttribute Toyear = doc.CreateAttribute("toyear");
            Toyear.Value = toyear;




            node.Attributes.Append(Costcenter);
            node.Attributes.Append(Costid);
            node.Attributes.Append(Opname);

            node.Attributes.Append(Opnameid);
           
            node.Attributes.Append(Optype);
            node.Attributes.Append(Nmaetype);
            node.Attributes.Append(Nametypeid);
            node.Attributes.Append(Opex);
            
           
           
            node.Attributes.Append(Amount);
            node.Attributes.Append(Fyear);
            node.Attributes.Append(Toyear);
          



            return node;
        }

        protected void dgvbudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithOperationXml();
                DataSet dsGrid = (DataSet)dgvbudget.DataSource;
                dsGrid.Tables[0].Rows[dgvbudget.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLOperation);
                DataSet dsGridAfterDelete = (DataSet)dgvbudget.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLOperation); dgvbudget.DataSource = ""; dgvbudget.DataBind(); }
                else {  LoadGridwithOperationXml(); }
            }

            catch { }
        }

        protected void dgvbudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvbudget.EditIndex = e.NewEditIndex;
            LoadGridwithOperationXml();
        }

        protected void dgvbudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = dgvbudget.Rows[e.RowIndex].DataItemIndex;
            string jul = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[0].FindControl("txtjuly")).Text;
            string aug = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[1].FindControl("txtaug")).Text;
            string sep = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[2].FindControl("txtsep")).Text;
            string oct = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[3].FindControl("txtoct")).Text;
            string nov = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[0].FindControl("txtnov")).Text;
            string dec = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[1].FindControl("txtdec")).Text;
            string jan = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[2].FindControl("txtjan")).Text;
            string feb = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[3].FindControl("txtfeb")).Text;
            string mar = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[0].FindControl("txtmar")).Text;
            string apr = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[1].FindControl("txtapril")).Text;
            string may = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[2].FindControl("txtmay")).Text;
            string jun = ((TextBox)dgvbudget.Rows[e.RowIndex].Cells[3].FindControl("txtjun")).Text;
            dgvbudget.EditIndex = -1;
            LoadGridwithOperationXml();
            DataSet dsUpdate = (DataSet)dgvbudget.DataSource;
            dsUpdate.Tables[0].Rows[index]["july"] = jul;
            dsUpdate.Tables[0].Rows[index]["agust"] = aug;
            dsUpdate.Tables[0].Rows[index]["sep"] = sep;
            dsUpdate.Tables[0].Rows[index]["oct"] = oct;

            dsUpdate.Tables[0].Rows[index]["nov"] = nov;
            dsUpdate.Tables[0].Rows[index]["dec"] = dec;
            dsUpdate.Tables[0].Rows[index]["jan"] = jan;
            dsUpdate.Tables[0].Rows[index]["feb"] = feb;

            dsUpdate.Tables[0].Rows[index]["march"] = mar;
            dsUpdate.Tables[0].Rows[index]["april"] = apr;
            dsUpdate.Tables[0].Rows[index]["may"] = may;
            dsUpdate.Tables[0].Rows[index]["jun"] = jun;
            dsUpdate.WriteXml(filePathForXMLOperation);
            LoadGridwithOperationXml();
            
        }

        protected void dgvbudget_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvbudget.EditIndex = -1;
            LoadGridwithOperationXml();
         
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            
                try
                {

                    int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    int intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());

                    if (OperationID.Checked == true)
                    {
                        if (dgvbudget.Rows.Count > 0)
                        {
                            dt = new DataTable();
                            XmlDocument doc2 = new XmlDocument();
                            doc2.Load(filePathForXMLOperation);
                            XmlNode vouchers = doc2.SelectSingleNode("voucher");
                            xmlStringOperation = vouchers.InnerXml;
                            xmlStringOperation = "<voucher>" + xmlStringOperation + "</voucher>";
                            dt = new DataTable();
                            item = Int32.Parse(1.ToString());
                            dt = objOperation.OperationXmlInsert(item, xmlStringOperation, 0, 0, 0, 0, 0, 0, enroll, intjobid, intunit, intdept);
                            if (dt.Rows.Count > 0)
                            {
                                data = dt.Rows[0]["reqno"].ToString();
                            }
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + data + "');", true);
                            try { File.Delete(filePathForXMLOperation); dgvbudget.DataSource = ""; dgvbudget.DataBind(); }
                            catch { }
                        }
                    }


                    else
                    {



                        if (dgvnonOperation.Rows.Count > 0)
                        {
                            dt = new DataTable();
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLAssetAccoA);
                            XmlNode vouchers = doc.SelectSingleNode("voucher");
                            xmlStringAssetAccoA = vouchers.InnerXml;
                            xmlStringAssetAccoA = "<voucher>" + xmlStringAssetAccoA + "</voucher>";
                            dt = new DataTable();
                            item = Int32.Parse(2.ToString());
                            dt = objOperation.NonOperationXmlInsert(item, 0, xmlStringAssetAccoA, 0, 0, 0, 0, 0, enroll, intjobid, intunit, intdept);
                            if (dt.Rows.Count > 0)
                            {
                                data = dt.Rows[0]["reqno"].ToString();
                            }
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + data + "');", true);
                           
                            try { File.Delete(filePathForXMLAssetAccoA); dgvnonOperation.DataSource = ""; dgvnonOperation.DataBind(); }
                            catch { }
                        }
                    }
                    dgvlist.Visible = true; dgvUser.Visible = true;
                    dt = new DataTable();
                    dt = objOperation.OperationUserView(enroll);
                    dgvUser.DataSource = dt;
                    dgvUser.DataBind();

                    dt = new DataTable();
                    dt = objOperation.userdetalisview(enroll);
                    dgvlist.DataSource = dt;
                    dgvlist.DataBind();
                }
                catch { }
            
        }

        private void Clearcontrols()
        {
            dgvbudget.DataSource = ""; dgvbudget.DataBind(); 
        }
           
       

        protected void dgvnonOperation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvnonOperation.DataSource;
                dsGrid.Tables[0].Rows[dgvnonOperation.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLAssetAccoA);
                DataSet dsGridAfterDelete = (DataSet)dgvnonOperation.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLAssetAccoA); dgvnonOperation.DataSource = ""; dgvnonOperation.DataBind(); }
                else { LoadGridwithXml(); }
            }

            catch { }
        }

        

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
               
                Session["intID"] = ordernumber1;
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DetalisView('BudgetDetalis_UI.aspx');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('BudgetDetalis_UI.aspx');", true);

            }
            catch { }
        }

        protected void btnUserDetails_Click(object sender, EventArgs e)
        {
            try
            {
                
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
                Int32 OperationID=Int32.Parse(ordernumber1.ToString());
                dt = new DataTable();
                dt = objOperation.GetOperationType(OperationID);
                if (dt.Rows.Count > 0) {check=Int32.Parse(dt.Rows[0]["intOperationType"].ToString()); }
                Session["intID"] = ordernumber1;
                if (check == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Userview('BudgetStatusViewDetalis.aspx');", true);
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DetalisView('BudgetDetalis_UI.aspx');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "nonoperation('BudgetNonOperatonStatusDetalis.aspx');", true);
                }
            }
            catch { }
        }





        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int data = Int32.Parse(ListBox1.SelectedValue.ToString());
            dt = new DataTable();
            accountName =">" + ListBox1.SelectedItem.ToString();
            pID = ListBox1.SelectedValue.ToString();
            pIDName = ListBox1.SelectedItem.ToString();
            hdnOpID.Value = pID;
            hdnOpName.Value = pIDName;


            dt = objOperation.Childview(Convert.ToInt32(pID));
            ListBox1.DataSource = dt;
            ListBox1.DataTextField = "strAccName";
            ListBox1.DataValueField = "intAccID";
            ListBox1.DataBind();

            dt = new DataTable();
            ddlOperation.DataSource = dt;
            ddlOperation.DataBind();
            ddlOperation.Items.Insert(0, new ListItem(pIDName, pID));

            string ds = ddlOperation.SelectedValue.ToString();
                

            if (LinkButton2.Text == "") { LinkButton2.Text = accountName.ToString(); hdn1.Value = pID; }
            else if (LinkButton3.Text == "") { LinkButton3.Text = accountName.ToString(); hdn2.Value = pID; }
            else if (LinkButton4.Text == "") { LinkButton4.Text = accountName.ToString(); hdn3.Value = pID; }
            else if (LinkButton5.Text == "") { LinkButton5.Text = accountName.ToString(); hdn4.Value = pID; }
            else if (LinkButton6.Text == "") { LinkButton6.Text = accountName.ToString(); hdn5.Value = pID; }
            else if (LinkButton7.Text == "") { LinkButton7.Text = accountName.ToString(); hdn6.Value = pID; }
            else if (LinkButton8.Text == "") { LinkButton8.Text = accountName.ToString(); hdn7.Value = pID; }
            else if (LinkButton9.Text == "") { LinkButton9.Text = accountName.ToString(); hdn8.Value = pID; }
            else if (LinkButton10.Text == "") { LinkButton10.Text = accountName.ToString(); hdn9.Value = pID; }
           


        }

protected void LinkButton1_Click(object sender, EventArgs e)
{
    dt = new DataTable();
    int intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
    dt = objOperation.ProjectParent(intunit);
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();
    LinkButton2.Text = ""; 
    LinkButton3.Text = ""; LinkButton4.Text = ""; LinkButton5.Text = ""; LinkButton6.Text = ""; LinkButton7.Text = ""; LinkButton8.Text = "";
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
protected void LinkButton2_Click(object sender, EventArgs e)
{
    pID = hdn1.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview(Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();
    LinkButton3.Text = ""; LinkButton4.Text = ""; LinkButton5.Text = ""; LinkButton6.Text = ""; LinkButton7.Text = ""; LinkButton8.Text = "";
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
protected void LinkButton3_Click(object sender, EventArgs e)
{
    pID = hdn2.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview(Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();
    LinkButton4.Text = ""; LinkButton5.Text = ""; LinkButton6.Text = ""; LinkButton7.Text = ""; LinkButton8.Text = "";
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
protected void LinkButton4_Click(object sender, EventArgs e)
{
    pID = hdn3.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview(Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();

     LinkButton5.Text = ""; LinkButton6.Text = ""; LinkButton7.Text = ""; LinkButton8.Text = "";
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
protected void LinkButton5_Click(object sender, EventArgs e)
{
    pID = hdn4.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview(Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();


    LinkButton6.Text = ""; LinkButton7.Text = ""; LinkButton8.Text = "";
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
    protected void LinkButton6_Click(object sender, EventArgs e)
   {
       pID = hdn5.Value;
       hdnOpID.Value = pID;
       dt = objOperation.Childview( Convert.ToInt32(pID));
       ListBox1.DataSource = dt;
       ListBox1.DataTextField = "strAccName";
       ListBox1.DataValueField = "intAccID";
       ListBox1.DataBind();

     LinkButton7.Text = ""; LinkButton8.Text = "";
       LinkButton9.Text = ""; LinkButton10.Text = ""; 
    }
  protected void LinkButton7_Click(object sender, EventArgs e)
{
    pID = hdn6.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview(Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();


     LinkButton8.Text = "";
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
 protected void LinkButton8_Click(object sender, EventArgs e)
{
    pID = hdn7.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview( Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();

    
    LinkButton9.Text = ""; LinkButton10.Text = ""; 
}
 protected void LinkButton9_Click(object sender, EventArgs e)
{
    pID = hdn8.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview(Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();
   LinkButton10.Text = ""; 
}
protected void LinkButton10_Click(object sender, EventArgs e)
{
    pID = hdn9.Value;
    hdnOpID.Value = pID;
    dt = objOperation.Childview( Convert.ToInt32(pID));
    ListBox1.DataSource = dt;
    ListBox1.DataTextField = "strAccName";
    ListBox1.DataValueField = "intAccID";
    ListBox1.DataBind();
   

}

protected void BtnAddParent_Click(object sender, EventArgs e)
{
    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
}
protected void BtnSaves_Click(object sender, EventArgs e)
{
    string chartName = Txtname.Text.ToString();
    int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
    int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
    int intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
    int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
    int ParentID = int.Parse(ddlOperation.SelectedValue.ToString());
    item = 6;
    objOperation.InsertCharOfProjectName(item, 0, 0, 0, 0, 0, 0, chartName, enroll, intjobid, intunit, ParentID);
    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Submit');", true);
                 
    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
}
protected void BtnCancel_Click(object sender, EventArgs e)
{
    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
}





}
}





        

       
    


        

  