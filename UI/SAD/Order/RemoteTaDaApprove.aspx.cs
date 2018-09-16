using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{

    public partial class RemoteTaDaApprove : BasePage
    {
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int RowIndex; decimal busfare = 0; decimal Rickfare = 0; decimal cngfare = 0; decimal trainfare = 0; decimal boatfare = 0; decimal othervhfare = 0;
        decimal ownda = 0; decimal otherda = 0; decimal hotel = 0; decimal othercost = 0; decimal rowTotal = 0; decimal movDuration = 0;
        string filePathForXML;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTaDaApprove";
        string stop = "stopping SAD\\Order\\RemoteTaDaApprove";

        protected void Page_Load(object sender, EventArgs e)
        {

            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

            filePathForXML = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaApprove.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//


            }






        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            showTSOTopsheet();
        }

        private void showTSOTopsheet()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTaDaApprove Challan Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            int userTypeid = int.Parse(drdlEmlployeetype.SelectedValue.ToString());
            int unitid = int.Parse(drdlUnitList.SelectedValue.ToString());
            DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

            if (rptTypeid == 2)
            {

                try
                {
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string TSOName = strSearchKey;
                    int intTSOEnroll = int.Parse(code);
                    dt = bll.getRptTADANoneCarUserTopSheet(dtFromDate, dtToDate, intTSOEnroll, unitid, userTypeid);
                }
                catch
                {

                }
                if (dt.Rows.Count > 0)
                {
                    GridviewTADADetaill.DataSource = null;
                    GridviewTADADetaill.DataBind();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                else
                {


                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                }




            }

            else           //For Approve Detaills
            {
                try
                {
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();

                    string TSOName = strSearchKey;
                    int Approverenrol = int.Parse(code);

                    dt = bll.getRmtRptTaDaNonCarUser(dtFromDate, dtToDate, Approverenrol, unitid, userTypeid);

                }
                catch
                {

                }
                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    GridviewTADADetaill.DataSource = dt;
                    GridviewTADADetaill.DataBind();

                }
                else
                {


                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                }



            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTaDaApprove Approve Tada ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rptTypeid == 1)
            {

                if (GridviewTADADetaill.Rows.Count > 0)
                {
                    for (int rowIndex = 0; rowIndex < GridviewTADADetaill.Rows.Count - 1; rowIndex++)
                    {

                        TextBox TextBoxDate = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[0].FindControl("dteFromdateNoBikeDet");
                        TextBox TextBoxBillPName = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[1].FindControl("strNamNoBikeDet");
                        TextBox TextBoxDeisgnation = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[2].FindControl("strDesgNoBikeDet");

                        TextBox TextBoxFromAdres = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[3].FindControl("strFromaddrNoBikeDet");
                        TextBox TextBoxToAdress = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[4].FindControl("strToadrNoBikeDet");
                        TextBox TextBoxMovementAreaAdress = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[5].FindControl("strMovemetspotNonebikeuser");

                        TextBox TextBoxMoveDuration = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[6].FindControl("txtdecmovdur");
                        TextBox TextBoxBusFare = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[7].FindControl("txtfareNoBikeDet");
                        TextBox TextBoxRickFare = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[8].FindControl("txtdecrick");
                        TextBox TextBoxCNGFare = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[9].FindControl("txtcng");
                        TextBox TextBoxTrainFare = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[10].FindControl("txttrain");
                        TextBox TextBoxBoatFare = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[11].FindControl("txtboat");
                        TextBox TextBoxOtherVhFare = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[12].FindControl("txtothevh");

                        TextBox TextBoxRemarks = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[13].FindControl("txtstrsuppor");

                        TextBox TextBoxOwnDA = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[14].FindControl("txtdecownda");
                        TextBox TextBoxOtherDA = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[15].FindControl("txtdecOtherda");
                        TextBox TextBoxHotel = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[16].FindControl("txtdechotel");

                        TextBox TextBoxOtherCost = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[17].FindControl("txthddecOtherCostAmount");
                        TextBox TextBoxRowTotal = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[18].FindControl("txtdecrowtotal");
                        TextBox TextBoxContactPerson = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[19].FindControl("txtstrContac");
                        TextBox TextBoxPhone = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[20].FindControl("txtstrphone");
                        TextBox TextVisitedorg = (TextBox)GridviewTADADetaill.Rows[rowIndex].Cells[21].FindControl("txtstrVisitorg");

                        if (TextBoxDate.Text == string.Empty || (TextBoxDate.Text) == "")
                        {
                            TextBoxDate.Text = "NA";
                        }

                        if (TextBoxBillPName.Text == string.Empty || (TextBoxBillPName.Text) == "")
                        {
                            TextBoxBillPName.Text = "No Applicant";
                        }

                        if (TextBoxDeisgnation.Text == string.Empty || (TextBoxDeisgnation.Text) == "")
                        {
                            TextBoxDeisgnation.Text = "No Designation";
                        }


                        if (TextBoxFromAdres.Text == string.Empty || (TextBoxFromAdres.Text) == "")
                        {
                            TextBoxFromAdres.Text = "NA";
                        }

                        if (TextBoxToAdress.Text == string.Empty || (TextBoxToAdress.Text) == "")
                        {
                            TextBoxToAdress.Text = "No Applicant";
                        }

                        if (TextBoxMovementAreaAdress.Text == string.Empty || (TextBoxMovementAreaAdress.Text) == "")
                        {
                            TextBoxMovementAreaAdress.Text = "No Designation";
                        }
                        if (TextBoxMoveDuration.Text == string.Empty || (TextBoxMoveDuration.Text) == "")
                        {
                            TextBoxMoveDuration.Text = "0";
                        }

                        if (TextBoxBusFare.Text == string.Empty || (TextBoxBusFare.Text) == "")
                        {
                            TextBoxBusFare.Text = "0";
                        }

                        if (TextBoxRickFare.Text == string.Empty || (TextBoxRickFare.Text) == "")
                        {
                            TextBoxRickFare.Text = "0";
                        }
                        if (TextBoxCNGFare.Text == string.Empty || (TextBoxCNGFare.Text) == "")
                        {
                            TextBoxCNGFare.Text = "NA";
                        }

                        if (TextBoxTrainFare.Text == string.Empty || (TextBoxTrainFare.Text) == "")
                        {
                            TextBoxTrainFare.Text = "0";
                        }

                        if (TextBoxBoatFare.Text == string.Empty || (TextBoxBoatFare.Text) == "")
                        {
                            TextBoxBoatFare.Text = "0";
                        }


                        if (TextBoxOtherVhFare.Text == string.Empty || (TextBoxOtherVhFare.Text) == "")
                        {
                            TextBoxOtherVhFare.Text = "0";
                        }

                        if (TextBoxRemarks.Text == string.Empty || (TextBoxRemarks.Text) == "")
                        {
                            TextBoxRemarks.Text = "No supporting";
                        }

                        if (TextBoxOwnDA.Text == string.Empty || (TextBoxOwnDA.Text) == "")
                        {
                            TextBoxOwnDA.Text = "0";
                        }


                        if (TextBoxOtherDA.Text == string.Empty || (TextBoxOtherDA.Text) == "")
                        {
                            TextBoxOtherDA.Text = "0";
                        }

                        if (TextBoxHotel.Text == string.Empty || (TextBoxHotel.Text) == "")
                        {
                            TextBoxHotel.Text = "0";
                        }

                        if (TextBoxOtherCost.Text == string.Empty || (TextBoxOtherCost.Text) == "")
                        {
                            TextBoxOtherCost.Text = "0";
                        }
                        if (TextBoxRowTotal.Text == string.Empty || (TextBoxRowTotal.Text) == "")
                        {
                            TextBoxRowTotal.Text = "0";
                        }

                        if (TextBoxContactPerson.Text == string.Empty || (TextBoxContactPerson.Text) == "")
                        {
                            TextBoxContactPerson.Text = "No Applicant";
                        }

                        if (TextBoxPhone.Text == string.Empty || (TextBoxPhone.Text) == "")
                        {
                            TextBoxPhone.Text = "0";
                        }
                        if (TextVisitedorg.Text == string.Empty || (TextVisitedorg.Text) == "")
                        {
                            TextVisitedorg.Text = "No vistorg";
                        }

                        string strBillDate = TextBoxDate.Text;
                        string strBillPerson = TextBoxBillPName.Text;
                        string strBillPersonDesignation = TextBoxDeisgnation.Text;
                        string strFromAdress = TextBoxFromAdres.Text;
                        string strToAddress = TextBoxToAdress.Text;
                        string strMoveArea = TextBoxMovementAreaAdress.Text;
                        string strMovDuration = TextBoxMoveDuration.Text;
                        string strBusFareTaka = TextBoxBusFare.Text;
                        string strRickFare = TextBoxRickFare.Text;
                        string strCNGFare = TextBoxCNGFare.Text;
                        string strTrainFare = TextBoxTrainFare.Text;
                        string strBoatFare = TextBoxBoatFare.Text;
                        string strOtherVhFare = TextBoxOtherVhFare.Text;
                        string strRemarks = TextBoxRemarks.Text;
                        string strOwnDA = TextBoxOwnDA.Text;
                        string strOtherDA = TextBoxOtherDA.Text;
                        string strHotel = TextBoxHotel.Text;
                        string strOtherCost = TextBoxOtherCost.Text;
                        string strRowTotal = TextBoxRowTotal.Text;
                        string strContactPerson = TextBoxContactPerson.Text;
                        string strPhone = TextBoxPhone.Text;
                        string strVisitedorg = TextVisitedorg.Text;

                        if (strBusFareTaka.All(c => char.IsNumber(c)) && strRickFare.All(c => char.IsNumber(c)) && strCNGFare.All(c => char.IsNumber(c)) && strTrainFare.All(c => char.IsNumber(c)) && strBoatFare.All(c => char.IsNumber(c)) && strOtherVhFare.All(c => char.IsNumber(c)) && strOwnDA.All(c => char.IsNumber(c)) && strOtherDA.All(c => char.IsNumber(c)) && strHotel.All(c => char.IsNumber(c)) && strOtherCost.All(c => char.IsNumber(c)) && strRowTotal.All(c => char.IsNumber(c)))
                        {
                            CreateSalesXml(strBillDate, strBillPerson, strBillPersonDesignation, strFromAdress, strToAddress, strMoveArea, strMovDuration, strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare, strOtherVhFare, strRemarks, strOwnDA, strOtherDA, strHotel, strOtherCost, strRowTotal, strContactPerson, strPhone, strVisitedorg);
                        }
                    }
                    #region ------------ Insert into dataBase -----------


                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    Int32 Approverenroll = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string TSOName = strSearchKey;
                    int intTADAApplicantEnrol = int.Parse(code);
                    int unitid = int.Parse(drdlUnitList.SelectedValue.ToString());
                    int intUnitid = unitid;
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    Int32 intJobStation = Convert.ToInt32(hdnstation.Value);
                    int userTypeid = int.Parse(drdlEmlployeetype.SelectedValue.ToString());
                    int intApplcTypeid = Convert.ToInt32(userTypeid);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteTaDaApprove");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteTaDaApprove>" + xmlString + "</RemoteTaDaApprove>";
                    string message = bll.tadainsertNoneBikeUserAfterApprove(xmlString, Approverenroll, intTADAApplicantEnrol, dteFromDate, dteTodate, intUnitid, intApplcTypeid, intJobStation);

                    //File.Delete(filePathForXML);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                    #endregion ------------ Insertion End ----------------
                }



                GridviewTADADetaill.DataBind();
                File.Delete(filePathForXML);



            }
            //when user select TopSheet from dropdown
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void CreateSalesXml(string strBillDate, string strBillPerson, string strBillPersonDesignation, string strFromAdress, string strToAddress, string strMoveArea, string strMovDuration, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strBoatFare, string strOtherVhFare, string strRemarks, string strOwnDA, string strOtherDA, string strHotel, string strOtherCost, string strRowTotal, string strContactPerson, string strPhone, string strVisitedorg)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemoteTaDaApprove");
                XmlNode addItem = CreateItemNode(doc, strBillDate, strBillPerson, strBillPersonDesignation, strFromAdress, strToAddress, strMoveArea, strMovDuration, strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare, strOtherVhFare, strRemarks, strOwnDA, strOtherDA, strHotel, strOtherCost, strRowTotal, strContactPerson, strPhone, strVisitedorg);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteTaDaApprove");
                XmlNode addItem = CreateItemNode(doc, strBillDate, strBillPerson, strBillPersonDesignation, strFromAdress, strToAddress, strMoveArea, strMovDuration, strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare, strOtherVhFare, strRemarks, strOwnDA, strOtherDA, strHotel, strOtherCost, strRowTotal, strContactPerson, strPhone, strVisitedorg);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }


        private XmlNode CreateItemNode(XmlDocument doc, string strBillDate, string strBillPerson, string strBillPersonDesignation, string strFromAdress, string strToAddress
            , string strMoveArea, string strMovDuration, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare
            , string strBoatFare, string strOtherVhFare, string strRemarks, string strOwnDA, string strOtherDA, string strHotel, string strOtherCost, string strRowTotal, string strContactPerson, string strPhone, string strVisitedorg)
        {
            XmlNode node = doc.CreateElement("items");





            XmlAttribute STRBILLDATE = doc.CreateAttribute("strBillDate");
            STRBILLDATE.Value = strBillDate;
            XmlAttribute STRBILLPERSON = doc.CreateAttribute("strBillPerson");
            STRBILLPERSON.Value = strBillPerson;
            XmlAttribute STRBILLPERSONDESIGNATION = doc.CreateAttribute("strBillPersonDesignation");
            STRBILLPERSONDESIGNATION.Value = strBillPersonDesignation;


            XmlAttribute STRFROMADDR = doc.CreateAttribute("strFromAdress");
            STRFROMADDR.Value = strFromAdress;

            XmlAttribute STRTOADDR = doc.CreateAttribute("strToAddress");
            STRTOADDR.Value = strToAddress;

            XmlAttribute STRMOVEAREA = doc.CreateAttribute("strMoveArea");
            STRMOVEAREA.Value = strMoveArea;

            XmlAttribute STRMOVDURATION = doc.CreateAttribute("strMovDuration");
            STRMOVDURATION.Value = strMovDuration;



            XmlAttribute STRBUSFARE = doc.CreateAttribute("strBusFareTaka");
            STRBUSFARE.Value = strBusFareTaka;
            XmlAttribute STRRICKFARE = doc.CreateAttribute("strRickFare");
            STRRICKFARE.Value = strRickFare;
            XmlAttribute STRCNGFARE = doc.CreateAttribute("strCNGFare");
            STRCNGFARE.Value = strCNGFare;
            XmlAttribute STRTRAINFARE = doc.CreateAttribute("strTrainFare");
            STRTRAINFARE.Value = strTrainFare;
            XmlAttribute STRBOATFARE = doc.CreateAttribute("strBoatFare");
            STRBOATFARE.Value = strBoatFare;
            XmlAttribute STROTHERVHFARE = doc.CreateAttribute("strOtherVhFare");
            STROTHERVHFARE.Value = strOtherVhFare;

            XmlAttribute STRREMARKS = doc.CreateAttribute("strRemarks");
            STRREMARKS.Value = strRemarks;
            XmlAttribute STROWNDA = doc.CreateAttribute("strOwnDA");
            STROWNDA.Value = strOwnDA;
            XmlAttribute STROTHERDA = doc.CreateAttribute("strOtherDA");
            STROTHERDA.Value = strOtherDA;
            XmlAttribute STRHOTEL = doc.CreateAttribute("strHotel");
            STRHOTEL.Value = strHotel;
            XmlAttribute STROTHERCOST = doc.CreateAttribute("strOtherCost");
            STROTHERCOST.Value = strOtherCost;
            XmlAttribute STRROWTOTAL = doc.CreateAttribute("strRowTotal");
            STRROWTOTAL.Value = strRowTotal;
            XmlAttribute STRCONTACTPERSON = doc.CreateAttribute("strContactPerson");
            STRCONTACTPERSON.Value = strContactPerson;
            XmlAttribute STRPHONE = doc.CreateAttribute("strPhone");
            STRPHONE.Value = strPhone;
            XmlAttribute STRVISITEDORG = doc.CreateAttribute("strVisitedorg");
            STRVISITEDORG.Value = strVisitedorg;





            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(STRBILLPERSON);
            node.Attributes.Append(STRBILLPERSONDESIGNATION);

            node.Attributes.Append(STRFROMADDR);
            node.Attributes.Append(STRTOADDR);
            node.Attributes.Append(STRMOVEAREA);
            node.Attributes.Append(STRMOVDURATION);
            node.Attributes.Append(STRBUSFARE);
            node.Attributes.Append(STRRICKFARE);
            node.Attributes.Append(STRCNGFARE);
            node.Attributes.Append(STRTRAINFARE);
            node.Attributes.Append(STRBOATFARE);
            node.Attributes.Append(STROTHERVHFARE);
            node.Attributes.Append(STRREMARKS);

            node.Attributes.Append(STROWNDA);
            node.Attributes.Append(STROTHERDA);
            node.Attributes.Append(STRHOTEL);
            node.Attributes.Append(STROTHERCOST);
            node.Attributes.Append(STRROWTOTAL);
            node.Attributes.Append(STRCONTACTPERSON);
            node.Attributes.Append(STRPHONE);
            node.Attributes.Append(STRVISITEDORG);


            return node;



        }

        protected void fare_TextChanged(object sender, EventArgs e)
        {




            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            //CalculateGrandTotal(); 
        }

        private void CalculateGrandTotal()
        {
            //---------------- Calculate Grand Total  Column ----------------------
            //busfare Rickfare   cngfare   trainfare   boatfare   othervhfare ownda   otherda   hotel   othercost 

            busfare = 0; Rickfare = 0; cngfare = 0; trainfare = 0; boatfare = 0; othervhfare = 0; ownda = 0; otherda = 0; hotel = 0; othercost = 0; int cnt = GridviewTADADetaill.Rows.Count;
            for (int r = 0; r < cnt - 1; r++)
            {


                busfare = busfare + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtfareNoBikeDet")).Text);
                Rickfare = Rickfare + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtdecrick")).Text);
                cngfare = cngfare + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtcng")).Text);
                trainfare = trainfare + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txttrain")).Text);

                boatfare = boatfare + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtboat")).Text);
                othervhfare = othervhfare + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtothevh")).Text);
                ownda = ownda + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtdecownda")).Text);
                otherda = otherda + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtdecOtherda")).Text);


                hotel = hotel + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtdechotel")).Text);
                othercost = othercost + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txthddecOtherCostAmount")).Text);

                //movDuration = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtdecmovdur")).Text);

                rowTotal = rowTotal + decimal.Parse(((TextBox)GridviewTADADetaill.Rows[r].FindControl("txtdecrowtotal")).Text);

            }
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtfareNoBikeDet")).Text = busfare.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtdecrick")).Text = Rickfare.ToString();

            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtcng")).Text = cngfare.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txttrain")).Text = trainfare.ToString();

            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtboat")).Text = boatfare.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtothevh")).Text = othervhfare.ToString();

            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtdecownda")).Text = ownda.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtdecOtherda")).Text = otherda.ToString();

            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtdechotel")).Text = hotel.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txthddecOtherCostAmount")).Text = othercost.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtdecmovdur")).Text = movDuration.ToString();
            ((TextBox)GridviewTADADetaill.Rows[cnt - 1].FindControl("txtdecrowtotal")).Text = rowTotal.ToString();




        }

        private void Calcutale(int RowIndex)
        {



            busfare = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtfareNoBikeDet")).Text);
            Rickfare = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtdecrick")).Text);
            cngfare = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtcng")).Text);
            trainfare = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txttrain")).Text);

            boatfare = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtboat")).Text);
            othervhfare = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtothevh")).Text);
            ownda = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtdecownda")).Text);
            otherda = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtdecOtherda")).Text);


            hotel = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtdechotel")).Text);
            othercost = decimal.Parse(((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txthddecOtherCostAmount")).Text);

            ((TextBox)GridviewTADADetaill.Rows[RowIndex].FindControl("txtdecrowtotal")).Text = (busfare + Rickfare + cngfare + trainfare + boatfare + othervhfare + ownda + otherda + hotel + othercost).ToString();



        }





        protected void GridviewTADADetaill_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridviewTADADetaill.cells[GridviewTADADetaill.cells.count - 1].Text = Convert.ToInt32(((Label)GridviewTADADetaill.FindControl("lblFare")).Text) *
            //Convert.ToInt32(((Label)GridviewTADADetaill.FindControl("lblDA")).Text);
        }



        protected void da_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void hotel_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            Calcutale(RowIndex);
            CalculateGrandTotal();

        }

        protected void other_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            Calcutale(RowIndex);
            CalculateGrandTotal();
        }




        protected void GridviewTADADetaill_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewTADADetaill.PageIndex = e.NewPageIndex;
            showTSOTopsheet();
        }


        protected void MovemnetNoBikeDet_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            CalculateGrandTotal();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void txthddecOtherCostAmount_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdechotel_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecOtherda_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecownda_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }


        protected void txtothevh_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtboat_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txttrain_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtcng_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecrick_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtfareNoBikeDet_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;

            Calcutale(RowIndex);
            CalculateGrandTotal();
        }


    }



}