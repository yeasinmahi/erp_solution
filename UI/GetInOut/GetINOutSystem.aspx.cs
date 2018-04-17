using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LOGIS_BLL.GetInOut;
using UI.ClassFiles;
using System.Xml;
using System.IO;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace UI.GetInOut
{
    public partial class GetINOutSystem : BasePage
    {
        GetInoutstatus objvechileinout = new GetInoutstatus();
        DataTable getpassload = new DataTable();
        DataTable vehiclelist = new DataTable();
        DataTable unitname = new DataTable();
        DataTable getingetpass = new DataTable();
        DataTable jobstation = new DataTable();
        DataTable getpassreceive = new DataTable();
     

        DataTable allGriedload = new DataTable();
        DataTable corporetgetpassin = new DataTable();
        DataTable dt = new DataTable();


        string filePathForXMLGetpassOut;
        int Item;
        string xmlStringGetpassOut="";
        GetInoutstatus rpt = new GetInoutstatus();
        GetInoutstatus rpt1 = new GetInoutstatus();
        string email;

        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());

          
            filePathForXMLGetpassOut = Server.MapPath("GetpassOut.xml)");
        
            if (!IsPostBack)
            {

               
                try { File.Delete(filePathForXMLGetpassOut); }
                catch { }
                TxtTechnichinSearch.Attributes.Add("onkeyUp", "SearchTextemp();");
                
               
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());


           
                Showdata();
                pnlUpperControl.DataBind();

                
            }

        }


        [WebMethod]
        public static List<string> GetAutoCompleteDataemp(string strSearchKeyemp)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 125 || intjobid == 131 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260)
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
       

        private void Showdata()
        {
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
           
            Int32 intRID = Int32.Parse("0".ToString());

            Item = 2;
            if (Item == 2)
            {
                string code = 0.ToString();
                string vehicleno = "0".ToString();
                string driver = "0".ToString();
                Int32 fowardenroll = Int32.Parse("0".ToString());
                getpassreceive = objvechileinout.GetpassreceiveConfirmation(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                dgvGetpassRecieve.DataSource = getpassreceive;
                dgvGetpassRecieve.DataBind();
            
            }
         



            vehiclelist = objvechileinout.gridviewgetpasoutdropdownvechilelist(intjobid);
            DdlVehicle.DataSource = vehiclelist;
            DdlVehicle.DataTextField = "strVechileNo";
            DdlVehicle.DataValueField = "intId";
            DdlVehicle.DataBind();

            if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 125 || intjobid == 131 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260)
            {
                getpassload = objvechileinout.CorporateGetpassOutLoad();
                dgvGetpassOut.DataSource = getpassload;
                dgvGetpassOut.DataBind();

                corporetgetpassin = objvechileinout.CorporeteGetPassInLoad();
                GridView1.DataSource = corporetgetpassin;
                GridView1.DataBind();

            }

            else
            {
                getpassload = objvechileinout.GetpassOutLoad(intuntid, intjobid);
                dgvGetpassOut.DataSource = getpassload;
                dgvGetpassOut.DataBind();

                getingetpass = objvechileinout.getingetpasdatainfo(intjobid);
                GridView1.DataSource = getingetpass;
                GridView1.DataBind();
            }
        }


        protected void dgvGetpassOut_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void dgvGetpassOut_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void dgvGetpassOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
          
            string vehicleno = DdlVehicle.SelectedItem.Text;
            Int32 vehicleID = Int32.Parse(DdlVehicle.SelectedValue.ToString());
          
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
               
            //Int32 intuntid = int.Parse("16".ToString());

            if (dgvGetpassOut.Rows.Count > 0)
            {

                for (int index = 0; index < dgvGetpassOut.Rows.Count; index++)
                {



                    if (((CheckBox)dgvGetpassOut.Rows[index].FindControl("chkSelect")).Checked == true)
                    {

                        String intID = Convert.ToString(((Label)dgvGetpassOut.Rows[index].FindControl("intID")).Text.ToString());
                        string gcode = ((Label)dgvGetpassOut.Rows[index].FindControl("strcode")).Text.ToString();
                        string description = ((Label)dgvGetpassOut.Rows[index].FindControl("strDescription")).Text.ToString();
                        string TAddrress = ((Label)dgvGetpassOut.Rows[index].FindControl("strTAddress")).Text.ToString();
                        Decimal qty = Decimal.Parse(((Label)dgvGetpassOut.Rows[index].FindControl("intQuantity")).Text.ToString());
                        string intdestination = Convert.ToString(((Label)dgvGetpassOut.Rows[index].FindControl("intToID")).Text.ToString());

                          {
                              CreateXmlGetpassOut(intID, gcode, intdestination);

                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLGetpassOut);
                            XmlNode dSftTm = doc.SelectSingleNode("voucher");
                            string xmlStringGetpassOut = dSftTm.InnerXml;
                            xmlStringGetpassOut = "<voucher>" + xmlStringGetpassOut + "</voucher>";
                            string message = rpt1.GetpassOutInsert(xmlStringGetpassOut, vehicleno, intenroll, intunitid, intjobid, vehicleID);
                            File.Delete(filePathForXMLGetpassOut);

                            
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                           

                        }
                    }


                }
                Showdata();
                        
                        

                    }


                }

        private void CreateXmlGetpassOut(string intID, string gcode, string intdestination)
    {
    XmlDocument doc = new XmlDocument();
    if (System.IO.File.Exists(filePathForXMLGetpassOut))
    {
        doc.Load(filePathForXMLGetpassOut);
        XmlNode rootNode = doc.SelectSingleNode("voucher");
        XmlNode addItem = CreateItemNodeGetpassOut(doc, intID, gcode, intdestination);
        rootNode.AppendChild(addItem);
    }
    else
    {
        XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
        doc.AppendChild(xmldeclerationNode);
        XmlNode rootNode = doc.CreateElement("voucher");
        XmlNode addItem = CreateItemNodeGetpassOut(doc, intID, gcode, intdestination);
        rootNode.AppendChild(addItem);
        doc.AppendChild(rootNode);
    }
    doc.Save(filePathForXMLGetpassOut);
        }

        private XmlNode CreateItemNodeGetpassOut(XmlDocument doc, string intID, string gcode, string intdestination)
            {
     XmlNode node = doc.CreateElement("voucherentry");
     XmlAttribute IntID = doc.CreateAttribute("intID");
    IntID.Value = intID;
            XmlAttribute Gcode = doc.CreateAttribute("gcode");
            Gcode.Value =gcode;
            XmlAttribute Intdestination = doc.CreateAttribute("intdestination");
            Intdestination.Value =intdestination;


                 node.Attributes.Append(IntID);
                 node.Attributes.Append(Gcode);
                 node.Attributes.Append(Intdestination);

                 

                 return node;
            }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                //Int32 intuntid = int.Parse("16".ToString());
                string code; string driver;
               

                if (GridView1.Rows.Count > 0)
                {

                    for (int index = 0; index < GridView1.Rows.Count; index++)
                    {
                        if (((CheckBox)GridView1.Rows[index].FindControl("chkSelect2")).Checked == true)
                        {
                            if (!String.IsNullOrEmpty(TxtTechnichinSearch.Text))
                            {
                                string strSearchKey = TxtTechnichinSearch.Text;
                                string[] searchKey = Regex.Split(strSearchKey, ";");
                                HdfTechnicinCode.Value = searchKey[1];
                                Int32 fowardenroll = Int32.Parse(HdfTechnicinCode.Value.ToString());


                                Int32 intRID = Int32.Parse(((Label)GridView1.Rows[index].FindControl("intRID")).Text.ToString());
                               code = ((Label)GridView1.Rows[index].FindControl("strcode")).Text.ToString();
                                string vehicleno = ((Label)GridView1.Rows[index].FindControl("strVechileno")).Text.ToString();
                                 driver = ((Label)GridView1.Rows[index].FindControl("strDrivername")).Text.ToString();

                                //custname = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustNameG")).Text.ToString();

                                try
                                {
                                    //fowardenroll = ((TextBox)GridView1.FindControl("TxtEnroll")).Text.ToString();
                                    //fowardenroll = int.Parse(TxtTechnichinSearch.Text.ToString());
                                   fowardenroll = Int32.Parse(HdfTechnicinCode.Value.ToString());

                                }
                                catch { fowardenroll = 0; }
                                Item = 1;
                                objvechileinout.getpassINinsertinfo(Item,intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('GetPass IN  successfull');", true);
                                Item = 7;
                                dt = new DataTable();
                                dt = objvechileinout.GetMailaddress(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                              
                                if (dt.Rows.Count > 0)
                               {

                                   email = dt.Rows[0]["strOfficeEmail"].ToString();
                                   driver = email.ToString();

                                   try
                                   {
                                       Item = 8;
                                       dt = new DataTable();
                                       objvechileinout.SendMail(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                                   }
                                   catch { };
                               }
                                Showdata();
                            }
                        }
                        


                    }

                }
            }
            catch { }
        }

        protected void DdlJobstation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

                   
        }

        

     
      
    }
}
