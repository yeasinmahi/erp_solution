using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using LOGIS_BLL.GetInOut;
using UI.ClassFiles;
using System.Text.RegularExpressions;
using System.Web.Services;

//BasePage

namespace UI.GetInOut
{
    public partial class MatarialsIn : BasePage
    {
        vehicleGetInOut inout = new vehicleGetInOut();
        DataTable viewdata = new DataTable();
        DataTable vehicleout = new DataTable();
        DataTable Dtlogin = new DataTable();
        DataTable dtuom = new DataTable();
        DataTable dt = new DataTable();
        DataTable vehiclelist = new DataTable();
        DataTable Unitname = new DataTable();

        string filePathForXML;
        string filePathForXMLPo;
        string xmlString = "";
        //string xmlStringPo;
        //string vehicleno;
        //string vehicle;

        vehicleGetInOut rpt = new vehicleGetInOut();
        //Int32 permissionnumber; 

      


        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());


            filePathForXML = Server.MapPath("student" + strEnroll + ".xml");
            filePathForXMLPo = Server.MapPath("ponumber" + strEnroll + ".xml");

            

            if (!IsPostBack)
            {
                //hdnstation.Value = Session[SessionParams.UNIT_ID].ToString();
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //Int32 intenroll = int.Parse("32897".ToString());

                txtEmployeeSearchp.Attributes.Add("onkeyUp", "SearchText();");
                Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());

                try { File.Delete(filePathForXML); }
                catch { }
                try { File.Delete(filePathForXMLPo); }
                catch { }

                Showdata();

                dtuom = inout.UnitOgMesurement(intunitid);
                DdlUome.DataTextField = "struom";
                DdlUome.DataSource = dtuom;
                DdlUome.DataBind();

                pnlUpperControl.DataBind();
               
               
            }
         
            LoadGridwithXml();
            GetDriverInfo();
       
        }



        private void GetDriverInfo()
        {
            if (!String.IsNullOrEmpty(txtEmployeeSearchp.Text))
            {

                string vehiclenumber = txtEmployeeSearchp.Text.ToString();
                vehiclelist = inout.vehiclenumberTxtInformation(vehiclenumber);
                if (vehiclelist.Rows.Count > 0)
                {

                    Txtdrivername.Text = vehiclelist.Rows[0]["strDriverName"].ToString();
                    Txtcomtact.Text = vehiclelist.Rows[0]["strDriverContact"].ToString();

                }


            }
        }


        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchVehicle(strSearchKey);
            return result;

        }
        protected void Showdata()
        {
            GridView1.Visible = true;
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            //Int32 intunitid = int.Parse("10".ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            viewdata = inout.getinformation(intunitid, intjobid);
            GridView1.DataSource = viewdata;
            GridView1.DataBind();

          
           
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
                { dgv.DataSource = ds; }

                else { dgv.DataSource = ""; }
                dgv.DataBind();
            }
            catch { }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {


            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            string ponumber = Txtponumber.Text.ToString();

            string challanno = Txtchallanno.Text.ToString();
            string drivername = Txtdrivername.Text.ToString();
            string vehicle = txtEmployeeSearchp.Text.ToString();
            string contact = Txtcomtact.Text.ToString();
            string supplier = Txtsupplier.Text.ToString();
            string location = Txtslocation.Text.ToString();
            string qty = Txtqty.Text.ToString();
            string scaleid = Txtscaleid.Text.ToString();
            string grossweight = txtgrossweight.Text.ToString();
            string netweight = Txtnetweight.Text.ToString();
            string matarials = Txtmatarials.Text.ToString();
           
            string uomdata = DdlUome.SelectedItem.ToString();


            if (dgv.Rows.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode vouchers = doc.SelectSingleNode("voucher");
                xmlString = vouchers.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                string msg = rpt.GetInOutxmlinsert(xmlString, intenroll, intunitid, intjobid);
                File.Delete(filePathForXML); dgv.DataSource = ""; dgv.DataBind(); LoadGridwithXml();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);


            }

            GridView1.Visible = true;
            viewdata = inout.getinformation(intunitid,intjobid);
            GridView1.DataSource = viewdata;
            GridView1.DataBind();
            

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            DataRow dr;
            Txtqty.ReadOnly = false;
            Txtmatarials.ReadOnly = false;
            

            string ponumber = Txtponumber.Text.ToString();

            string challanno = Txtchallanno.Text.ToString();
            string drivername = Txtdrivername.Text.ToString();
            string vehicle = txtEmployeeSearchp.Text.ToString();
            string contact = Txtcomtact.Text.ToString();
            string supplier = Txtsupplier.Text.ToString();
            string location = Txtslocation.Text.ToString();
            string qty = Txtqty.Text.ToString();
            string scaleid = Txtscaleid.Text.ToString();
            string grossweight = txtgrossweight.Text.ToString();
            string netweight = Txtnetweight.Text.ToString();
            string matarials = Txtmatarials.Text.ToString();
           
            string uomdata = DdlUome.SelectedItem.ToString();

            GridView1.Visible = false;
            GridView2.Visible = false;

            CreateVoucherXml( ponumber,challanno, drivername, vehicle, contact, supplier, location, qty, scaleid, grossweight, netweight, matarials, uomdata);


        }

        private void CreateVoucherXml( string ponumber,string challanno, string drivername, string vehicle, string contact, string supplier, string location, string qty, string scaleid, string grossweight, string netweight, string matarials, string uomdata)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc,ponumber,challanno, drivername, vehicle, contact, supplier, location, qty, scaleid, grossweight, netweight, matarials, uomdata);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, ponumber, challanno, drivername, vehicle, contact, supplier, location, qty, scaleid, grossweight, netweight, matarials, uomdata);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
       
            Txtponumber.Text = "";
            Txtchallanno.Text = "";
            Txtdrivername.Text = "";
           
            Txtcomtact.Text = "";
            Txtsupplier.Text = "";
            Txtslocation.Text = "";
            Txtqty.Text = "";
            Txtscaleid.Text = "";
            txtgrossweight.Text = "";
            Txtnetweight.Text = "";
            Txtmatarials.Text = "";
            //TxtOthersVehicle.Text = "";
          

        }

        private XmlNode CreateItemNode(XmlDocument doc, string ponumber, string challanno, string drivername, string vehicle, string contact, string supplier, string location, string qty, string scaleid, string grossweight, string netweight, string matarials, string uomdata)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Ponumber= doc.CreateAttribute("ponumber");
            Ponumber.Value =ponumber;
            XmlAttribute Challanno = doc.CreateAttribute("challanno");
            Challanno.Value = challanno;
            XmlAttribute Drivername = doc.CreateAttribute("drivername");
            Drivername.Value = drivername;
            XmlAttribute Vehicle = doc.CreateAttribute("vehicle");
            Vehicle.Value = vehicle;
            XmlAttribute Contact = doc.CreateAttribute("contact");
            Contact.Value = contact;
            XmlAttribute Supplier = doc.CreateAttribute("supplier");
            Supplier.Value = supplier;
            XmlAttribute Location = doc.CreateAttribute("location");
            Location.Value = location;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Scaleid = doc.CreateAttribute("scaleid");
            Scaleid.Value = scaleid;
            XmlAttribute Grossweight = doc.CreateAttribute("grossweight");
            Grossweight.Value = grossweight;
            XmlAttribute Netweight = doc.CreateAttribute("netweight");
            Netweight.Value = netweight;
            XmlAttribute Matarials = doc.CreateAttribute("matarials");
            Matarials.Value = matarials;
           
            XmlAttribute Uomdata = doc.CreateAttribute("uomdata");
            Uomdata.Value = uomdata;


            node.Attributes.Append(Ponumber);

            node.Attributes.Append(Challanno);
            node.Attributes.Append(Drivername);
            node.Attributes.Append(Vehicle);
            node.Attributes.Append(Contact);
            node.Attributes.Append(Supplier);
            node.Attributes.Append(Location);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Scaleid);
            node.Attributes.Append(Grossweight);
            node.Attributes.Append(Netweight);
            node.Attributes.Append(Matarials);
        
            node.Attributes.Append(Uomdata);


            return node;

        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgv.DataSource;
                dsGrid.Tables[0].Rows[dgv.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgv.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgv.DataSource = ""; dgv.DataBind(); }
                else { LoadGridwithXml(); }
            }

            catch { }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            //Int32 intId = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text.ToString());
            string vehicle=((Label)GridView1.Rows[e.RowIndex].FindControl("Label3")).Text;

            inout.Vehicleoutinformation(vehicle, intjobid);

          
            Showdata();

        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Showdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Showdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            String scaleid = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text;
            decimal grossweight = Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox2")).Text.ToString());
            decimal netweight = Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text.ToString());
            string vehicleno = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label3")).Text;
            inout.updateWeight(scaleid, grossweight, netweight, vehicleno);

            GridView1.EditIndex = -1;

            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
           
            Showdata();
        }

        //PO Number Show //
        protected void Txtponumber_TextChanged(object sender, EventArgs e)
        {

            Int32 PO = Int32.Parse(Txtponumber.Text.ToString());
            dt = inout.showPONumber(PO);
            GridView2.Visible = true;
            if (dt.Rows.Count > 0)
            {
           
           

               
                Txtponumber.Text = dt.Rows[0]["intPOID"].ToString();
                Txtsupplier.Text = dt.Rows[0]["strSupplierName"].ToString();
                Txtslocation.Text = dt.Rows[0]["strOrgAddress"].ToString();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                Txtqty.ReadOnly = true;
                Txtmatarials.ReadOnly =true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true);
                GridView2.Visible = false;
                Txtqty.ReadOnly = false;
                Txtmatarials.ReadOnly = false;
            }
        }

        //protected void txtEmployeeSearchp_TextChanged(object sender, EventArgs e)
        //{
        //    string vehiclenumber = txtEmployeeSearchp.Text.ToString();
        //    vehiclelist = inout.vehiclenumberTxtInformation(vehiclenumber);
        //    if (vehiclelist.Rows.Count > 0)
        //    {

        //        Txtdrivername.Text = vehiclelist.Rows[0]["strDriverName"].ToString();
        //        Txtcomtact.Text = vehiclelist.Rows[0]["strDriverContact"].ToString();
                
        //    }

        //}

       

     



        }





    }
