using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class TA_DA_NoBike_Gb : BasePage
    {

        string filePathForXML; string serial;
        string xmlString = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        int intCOAid; int RowIndex;
        protected decimal busfare = 0; protected decimal Rickfare = 0; protected decimal cngfare = 0; protected decimal trainfare = 0;
        protected decimal boatfare = 0; protected decimal othervhfare = 0;

        protected decimal ownda = 0; protected decimal otherda = 0; protected decimal hotel = 0; protected decimal othercost = 0;
        protected decimal rowTotal = 0; protected decimal movDuration = 0;




        protected void Page_Load(object sender, EventArgs e)
        {

            filePathForXML = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString()+"_" + "remotetadanobike.xml");
            if (!IsPostBack)
            {
            pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }
           
        }

        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("Remotetadanobike");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Remotetadanobike>" + xmlString + "</Remotetadanobike>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { GridView1.DataSource = ds; }
                else { GridView1.DataSource = ""; }
               
                GridView1.DataBind();
               
            }
            catch { }
        }

        private void CreateVoucherXml(string BillDate, string MovDuration, string fromAddress, string movementAddress, string toAddress, string busfair, string Rickfai, string cngfair, string trainfair, string boatfair, string othervhfair, string ownda, string otherpersonda, string hotelfair, string OtherCost, string remarks, string totalcost, string contactperson, string phone, string vistOrganization, string slNo)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Remotetadanobike");
                XmlNode addItem = CreateItemNode(doc, BillDate, MovDuration, fromAddress, movementAddress, toAddress, busfair, Rickfai, cngfair, trainfair, boatfair, othervhfair, ownda, otherpersonda, hotelfair, OtherCost, remarks, totalcost, contactperson, phone, vistOrganization, slNo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Remotetadanobike");
                XmlNode addItem = CreateItemNode(doc, BillDate, MovDuration, fromAddress, movementAddress, toAddress, busfair, Rickfai, cngfair, trainfair, boatfair, othervhfair, ownda, otherpersonda, hotelfair, OtherCost, remarks, totalcost, contactperson, phone, vistOrganization, slNo);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            Clear();
        }
        private void Clear()
        {
            
            txtMovDuration.Text = ""; txtFromAddr.Text = ""; txtMovementArea.Text = ""; txtToaddr.Text = ""; txtBusFair.Text = ""; txtRickshaw.Text = "";
            txtCNG.Text = ""; txtTrain.Text = ""; txtBoat.Text = ""; txtOtherVh.Text = ""; txtOwnDA.Text = ""; txtOtherDA.Text = ""; txtHotel.Text = ""; txtOtherCost.Text = ""; TextBox2.Text = "";
            txtTotal.Text = ""; txtTotal.Text = "";
          
        
        }

        private XmlNode CreateItemNode(XmlDocument doc, string BillDate, string MovDuration, string fromAddress, string movementAddress, string toAddress, string busfair, string Rickfai, string cngfair, string trainfair, string boatfair, string othervhfair, string ownda, string otherpersonda, string hotelfair, string OtherCost, string remarks, string totalcost, string contactperson, string phone, string vistOrganization, string slNo)
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRBILLDATE = doc.CreateAttribute("BillDate");
            STRBILLDATE.Value = BillDate;
            XmlAttribute MOVDURATION = doc.CreateAttribute("MovDuration");
            MOVDURATION.Value = MovDuration;
            XmlAttribute FRMADDR = doc.CreateAttribute("fromAddress");
            FRMADDR.Value = fromAddress;
            XmlAttribute MOVADDR = doc.CreateAttribute("movementAddress");
            MOVADDR.Value = movementAddress;
            XmlAttribute TOADDR = doc.CreateAttribute("toAddress");
            TOADDR.Value = toAddress;


            XmlAttribute BUSF = doc.CreateAttribute("busfair");
            BUSF.Value = busfair;
            XmlAttribute RICKF = doc.CreateAttribute("Rickfai");
            RICKF.Value = Rickfai;
            XmlAttribute CNGF = doc.CreateAttribute("cngfair");
            CNGF.Value = cngfair;
            XmlAttribute TRAINF = doc.CreateAttribute("trainfair");
            TRAINF.Value = trainfair;
            XmlAttribute BOATF = doc.CreateAttribute("boatfair");
            BOATF.Value = boatfair;

            XmlAttribute OTHVHF = doc.CreateAttribute("othervhfair");
            OTHVHF.Value = othervhfair;
            XmlAttribute OWNDA = doc.CreateAttribute("ownda");
            OWNDA.Value = ownda;
            XmlAttribute OTHEPDA = doc.CreateAttribute("otherpersonda");
            OTHEPDA.Value = otherpersonda;
            XmlAttribute HOTELF = doc.CreateAttribute("hotelfair");
            HOTELF.Value = hotelfair;

            XmlAttribute OTHCOST = doc.CreateAttribute("OtherCost");
            OTHCOST.Value = OtherCost;

            XmlAttribute REMARKS = doc.CreateAttribute("remarks");
            REMARKS.Value = remarks;


            XmlAttribute TOTALCOST = doc.CreateAttribute("totalcost");
            TOTALCOST.Value = totalcost;
            XmlAttribute CONTACTP = doc.CreateAttribute("contactperson");
            CONTACTP.Value = contactperson;

            XmlAttribute PHONE = doc.CreateAttribute("phone");
            PHONE.Value = phone;
      
            XmlAttribute VORG = doc.CreateAttribute("vistOrganization");
            VORG.Value = vistOrganization;

            XmlAttribute SL = doc.CreateAttribute("slNo");
            SL.Value = slNo;


            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(MOVDURATION);
            node.Attributes.Append(FRMADDR);
            node.Attributes.Append(MOVADDR);
            node.Attributes.Append(TOADDR);

            node.Attributes.Append(BUSF);
            node.Attributes.Append(RICKF);
            node.Attributes.Append(CNGF);
            node.Attributes.Append(TRAINF);
            node.Attributes.Append(BOATF);
            node.Attributes.Append(OTHVHF);


            node.Attributes.Append(OWNDA);
            node.Attributes.Append(OTHEPDA);
            node.Attributes.Append(HOTELF);
            node.Attributes.Append(OTHCOST);
            node.Attributes.Append(REMARKS);
            node.Attributes.Append(TOTALCOST);

            node.Attributes.Append(CONTACTP);
            node.Attributes.Append(PHONE);
            node.Attributes.Append(VORG);
            node.Attributes.Append(SL);
            return node;
    }







        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {

                string Rickfai = "0", busfair = "0", cngfair = "0", trainfair = "0", boatfair = "0", othervhfair = "0", ownda = "0", otherpersonda = "0", hotelfair = "0", OtherCost = "0";
                string BillDate = txtFromDate.Text;


                string cureentdate = DateTime.Now.ToString("yyyy-MM-dd");
                var now = DateTime.Now;
                var startOfMonth = new DateTime(now.Year, now.Month, 1);
                var DaysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                var lastDay = new DateTime(now.Year, now.Month, DaysInMonth).AddDays(10);
                string lastd = lastDay.ToString("yyyy-MM-dd");
                DateTime today = Convert.ToDateTime(BillDate);
                DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)).AddDays(6);
                DateTime dt3 = Convert.ToDateTime(endOfMonth);
                DateTime dt4 = Convert.ToDateTime(cureentdate);
                int diffbEOMTODATE = (dt3 - dt4).Days;

                string todate = txtToDate.Text;
                string MovDuration = txtMovDuration.Text;
                string fromAddress = txtFromAddr.Text;
                string movementAddress = txtMovementArea.Text;
                string toAddress = txtToaddr.Text;
                if (txtToaddr.Text == "")
                {
                    toAddress = "NA";
                }

                if (toAddress.Length <= 0) { toAddress = "NA"; }
                busfair = txtBusFair.Text;
                if (busfair.Length <= 0) { busfair = "0"; }
                Rickfai = txtRickshaw.Text;
                if (Rickfai.Length <= 0) { Rickfai = "0"; }

                cngfair = txtCNG.Text;
                if (cngfair.Length <= 0) { cngfair = "0"; }
                trainfair = txtTrain.Text;
                if (trainfair.Length <= 0) { trainfair = "0"; }

                boatfair = txtBoat.Text;
                if (boatfair.Length <= 0) { boatfair = "0"; }

                othervhfair = txtOtherVh.Text;
                if (othervhfair.Length <= 0) { othervhfair = "0"; }

                ownda = txtOwnDA.Text;
                if (ownda.Length <= 0) { ownda = "0"; }
                otherpersonda = txtOtherDA.Text;
                if (otherpersonda.Length <= 0) { otherpersonda = "0"; }
                hotelfair = txtHotel.Text;
                if (hotelfair.Length <= 0) { hotelfair = "0"; }
                OtherCost = txtOtherCost.Text;
                if (OtherCost.Length <= 0) { OtherCost = "0"; }


                string remarks = TextBox2.Text;
                string totalcost = txtTotal.Text;
                string contactperson = txtContactPerson.Text;
                string phone = txtPhone.Text;
                string vistOrganization = txtVisitedPlace.Text;





                //if (diffbEOMTODATE < 0)
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You try to back date entry.Plase contact to HR Dept. for detaills')", true);
                //}

                if (diffbEOMTODATE > 0)
                {



                    if (BillDate == string.Empty || BillDate == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                    }
                    else if (todate == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select to date from calender !')", true);
                    }
                    else if (MovDuration == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Movement Duration !')", true);
                    }

                    else if (fromAddress == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select From Address !')", true);
                    }

                    else if (movementAddress == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Move Address !')", true);
                    }

                    else if (toAddress == string.Empty || toAddress == "")
                    {
                        toAddress = "N/A";
                    }




                    else if (totalcost == string.Empty || totalcost == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total Cost Can not be Zerro !')", true);
                    }

                    else if (contactperson == string.Empty || contactperson == "")
                    {
                        contactperson = "N/A";
                    }


                    else if (phone == string.Empty || phone == "")
                    {
                        phone = "N/A";
                    }

                    else if (vistOrganization == string.Empty || vistOrganization == "")
                    {
                        vistOrganization = "N/A";
                    }

                    else
                    {

                        string dteFromDate = DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd");




                        string strMOV = Convert.ToString(txtMovDuration.Text);
                        string strfromAddress = txtFromAddr.Text;
                        string strmovementAddress = txtMovementArea.Text;
                        string strtoAddress = txtToaddr.Text;
                        if (strtoAddress.Length <= 0) { strtoAddress = "NA"; }


                        string strBUSF = Convert.ToString(txtBusFair.Text);
                        if (strBUSF.Length <= 0) { strBUSF = "0"; }
                        string strRICKF = Convert.ToString(txtRickshaw.Text);
                        if (strRICKF.Length <= 0) { strRICKF = "0"; }
                        string strCNGF = Convert.ToString(txtCNG.Text);
                        if (strCNGF.Length <= 0) { strCNGF = "0"; }
                        string strTRAINF = Convert.ToString(txtTrain.Text);
                        if (strTRAINF.Length <= 0) { strTRAINF = "0"; }
                        string strBOATF = Convert.ToString(txtBoat.Text);
                        if (strBOATF.Length <= 0) { strBOATF = "0"; }
                        string strOTHVHF = Convert.ToString(txtOtherVh.Text);
                        if (strOTHVHF.Length <= 0) { strOTHVHF = "0"; }

                        string strOWNDA = Convert.ToString(txtOwnDA.Text);
                        if (strOWNDA.Length <= 0) { strOWNDA = "0"; }
                        string strOTHPDA = Convert.ToString(txtOtherDA.Text);
                        if (strOTHPDA.Length <= 0) { strOTHPDA = "0"; }
                        string strHOTELF = Convert.ToString(txtHotel.Text);
                        if (strHOTELF.Length <= 0) { strHOTELF = "0"; }
                        string strOTHC = Convert.ToString(txtOtherCost.Text);
                        if (strOTHC.Length <= 0) { strOTHC = "0"; }


                        string strremarks = TextBox2.Text;
                        if (strremarks.Length <= 0) { strremarks = "NA"; }


                        string strTOTALC = Convert.ToString(txtTotal.Text);
                        if (strTOTALC.Length <= 0) { strTOTALC = "0"; }

                        string stcontactperson = Convert.ToString(txtContactPerson.Text);
                        if (stcontactperson.Length <= 0) { stcontactperson = "NA"; }



                        string strphone = txtPhone.Text;
                        if (strphone.Length <= 0) { strphone = "0"; }



                        string strvistOrganization = txtVisitedPlace.Text;
                        if (strvistOrganization.Length <= 0) { strvistOrganization = "NA"; }

                        if (GridView1.Rows.Count <= 0)
                        {
                            serial = "1";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 1)
                        {
                            serial = "2";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 2)
                        {
                            serial = "3";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 3)
                        {
                            serial = "4";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 4)
                        {
                            serial = "5";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 5)
                        {
                            serial = "6";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 6)
                        {
                            serial = "7";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 7)
                        {
                            serial = "8";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 8)
                        {
                            serial = "9";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 9)
                        {
                            serial = "10";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 10)
                        {
                            serial = "11";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 11)
                        {
                            serial = "12";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 12)
                        {
                            serial = "13";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 13)
                        {
                            serial = "14";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 14)
                        {
                            serial = "15";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 15)
                        {
                            serial = "16";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 16)
                        {
                            serial = "17";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 17)
                        {
                            serial = "18";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else if (GridView1.Rows.Count == 18)
                        {
                            serial = "19";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 19)
                        {
                            serial = "20";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }

                        else if (GridView1.Rows.Count == 20)
                        {
                            serial = "21";
                            CreateVoucherXml(dteFromDate, strMOV, strfromAddress, strmovementAddress, strtoAddress, strBUSF, strRICKF, strCNGF, strTRAINF,
                          strBOATF, strOTHVHF, strOWNDA, strOTHPDA, strHOTELF, strOTHC, strremarks, strTOTALC, stcontactperson, strphone, strvistOrganization, serial);

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not allow to add more than Twenty  rows !')", true);

                        }


                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You try to back date entry.Plase contact to HR Dept. for detaills. All r request to submit bill within current month.After 5th date of next month. you are not allow for submit Previous month bill')", true);
                }
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {

                if (GridView1.Rows.Count > 0)
                {
                    #region ------------ Insert into dataBase -----------

                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();

                    Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                    int NoneCarUserTypeid = 2;
                    HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();

                    int unit = Convert.ToInt32(HiddenUnit.Value);


                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    int jobstation = Convert.ToInt32(hdnstation.Value);

                    XmlDocument doc = new XmlDocument();

                    try
                    {


                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("Remotetadanobike");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<Remotetadanobike>" + xmlString + "</Remotetadanobike>";
                        string message = bll.tadaInsertByApplicantNoneCarUser(xmlString, dteFromDate, dteTodate, enroll, NoneCarUserTypeid, unit, jobstation);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }

                    catch
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                    }



                    #endregion ------------ Insertion End ----------------


                }
                GridView1.DataBind();
                File.Delete(filePathForXML);
                GridView1.DataSource = "";
                GridView1.DataBind();

            }
        }
      

        protected decimal grandtotal = 0; protected decimal Grndothercost = 0;
        protected decimal hotelfairTotal = 0; protected decimal otherpersondaTotal = 0; protected decimal owndaTotal = 0;
        protected decimal othervhfairTotal = 0; protected decimal boatfairTotal = 0;
        protected decimal trainfairTotal = 0;
        protected decimal cngfairTotal = 0; protected decimal RickfaiTotal = 0; protected decimal busfairTotal = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    grandtotal += decimal.Parse(((Label)e.Row.Cells[16].FindControl("lblGrandTotal")).Text);
                }

               



            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Grndothercost += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblOtherCost")).Text);
                }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    hotelfairTotal += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblhotelfair")).Text);
                }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    otherpersondaTotal += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblotherpersonda")).Text);
                }
            }
            catch { }


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    owndaTotal += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblownda")).Text);
                }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    othervhfairTotal += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblothervhfair")).Text);
                }
            }
            catch { }



            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    boatfairTotal += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblboatfair")).Text);
                }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    trainfairTotal += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lbltrainfair")).Text);
                }
            }
            catch { }


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    cngfairTotal += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblcngfair")).Text);
                }
            }
            catch { }


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    RickfaiTotal += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblRickfai")).Text);
                }
            }
            catch { }


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    busfairTotal += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblbusfair")).Text);
                }
            }
            catch { }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            

            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)GridView1.DataSource;
                dsGrid.Tables[0].Rows[GridView1.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)GridView1.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); GridView1.DataSource = ""; GridView1.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { } 
        }

       
    }

    }
