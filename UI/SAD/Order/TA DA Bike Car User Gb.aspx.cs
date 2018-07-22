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
    public partial class TA_DA_Bike_Car_User_Gb : BasePage
    {
        string filePathForXML;
        string xmlString = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        protected void Page_Load(object sender, EventArgs e)
        {

            pnlUpperControl.DataBind();


            filePathForXML = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaBikeCarUser.xml");
            if (!IsPostBack)
            {
                hdnApplicantEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                DataTable dt = new DataTable();
                dt = bll.getEndMilageApplicant(enroll);

                if (dt.Rows.Count > 0) { txtStartMilage.Text = dt.Rows[0][0].ToString(); }
                else { txtStartMilage.Text = "0"; }

                if (dt.Rows.Count > 0) { txtFromAddr.Text = dt.Rows[0][1].ToString(); }
                else { txtFromAddr.Text = ""; }

                if (dt.Rows.Count > 0) { txtToaddr.Text = dt.Rows[0][2].ToString(); }
                else { txtToaddr.Text = ""; }
                //if(dt.Rows.Count>)
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
            }
            LoadGridwithXml();


        }

        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("RemotetadaBikeCarUser");
                xmlString = dSftTm.InnerXml;
                xmlString = "<RemotetadaBikeCarUser>" + xmlString + "</RemotetadaBikeCarUser>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { GridviewBikeCarUserInputInfo.DataSource = ds; }
                else { GridviewBikeCarUserInputInfo.DataSource = ""; }
                GridviewBikeCarUserInputInfo.DataBind();
            }
            catch { }

        }
        private void CreateVoucherXml(string BillDate, string starttime, string endtime, string MovDuration, string fromAddress, string movementAddress
            , string toAddress, string nightstay, string startmilage, string endmilage, string consumed, string remarks
            , string petrolqnt, string petrolcost, string octenqnt, string octencost, string cngqnt, string cngcost
            , string lubricantqnt, string lubricantcost, string busfair, string Rickfai, string cngfair, string trainfair
            , string Airplance, string othervhfair, string mntCost, string ferrytoll, string ownda, string driverda
            , string ownhotelfair, string driverhotel, string photocoly, string courier, string OtherCost, string totalcost
            , string FuelpaymentTypeid
            , string Cngcredit1FuelSupplierstationid, string CNGCredit1AmountcngFuelStationbill, string Cngcredit1FuelSupplierstationName
            , string Cngcredit2FuelSupplierstationid, string CNGCredit2AmountcngFuelStationbill, string Cngcredit2FuelSupplierstationName
            , string OilCredit1Supplierstationid, string oilCredit1Stationbill, string oilCredit1StationName
            , string personalusedMilageQnt, string personalUsedMilRate, string personalusemilageTotcost, string slNo
            )
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("RemotetadaBikeCarUser");
                XmlNode addItem = CreateItemNode(doc, BillDate, starttime, endtime, MovDuration, fromAddress, movementAddress, toAddress, nightstay, startmilage, endmilage, consumed, remarks, petrolqnt, petrolcost, octenqnt, octencost, cngqnt, cngcost, lubricantqnt, lubricantcost, busfair, Rickfai, cngfair, trainfair, Airplance, othervhfair, mntCost, ferrytoll, ownda, driverda, ownhotelfair, driverhotel, photocoly, courier, OtherCost, totalcost, FuelpaymentTypeid,
                   Cngcredit1FuelSupplierstationid, CNGCredit1AmountcngFuelStationbill, Cngcredit1FuelSupplierstationName
                   , Cngcredit2FuelSupplierstationid, CNGCredit2AmountcngFuelStationbill, Cngcredit2FuelSupplierstationName
                   , OilCredit1Supplierstationid, oilCredit1Stationbill, oilCredit1StationName
                   , personalusedMilageQnt, personalUsedMilRate, personalusemilageTotcost, slNo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaBikeCarUser");
                XmlNode addItem = CreateItemNode(doc, BillDate, starttime, endtime, MovDuration, fromAddress, movementAddress, toAddress, nightstay, startmilage, endmilage, consumed, remarks, petrolqnt, petrolcost, octenqnt, octencost, cngqnt, cngcost, lubricantqnt, lubricantcost, busfair, Rickfai, cngfair, trainfair, Airplance, othervhfair, mntCost, ferrytoll, ownda, driverda, ownhotelfair, driverhotel, photocoly, courier, OtherCost, totalcost, FuelpaymentTypeid,
                    Cngcredit1FuelSupplierstationid, CNGCredit1AmountcngFuelStationbill, Cngcredit1FuelSupplierstationName
                   , Cngcredit2FuelSupplierstationid, CNGCredit2AmountcngFuelStationbill, Cngcredit2FuelSupplierstationName
                   , OilCredit1Supplierstationid, oilCredit1Stationbill, oilCredit1StationName
                   , personalusedMilageQnt, personalUsedMilRate, personalusemilageTotcost, slNo);
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
            txtCNG.Text = ""; txtTrain.Text = ""; ; txtOtherVh.Text = ""; txtOwnDA.Text = ""; txtDriverDA.Text = ""; txtOwnHotel.Text = ""; txtOtherCost.Text = ""; txtDriverHotel.Text = "";


            txtStarTime.Text = ""; txtEndTime.Text = "";

            txtNightStay.Text = ""; txtStartMilage.Text = ""; txtEndMilage.Text = ""; txtConsumed.Text = "";
            txtPetrolQnt.Text = ""; txtPetrolCost.Text = "";  txtOcten.Text = ""; txtOctenCost.Text = ""; txtCNGQnt.Text = ""; txtCNGCost.Text = ""; txtMobilQnt.Text = ""; txtMobilCost.Text = "";
            txtAirPlane.Text = ""; txtMntVh.Text = ""; txtSupporting.Text = "";


            txtFerryToll.Text = ""; txtCourier.Text = ""; txtTotal.Text = "";
            txtPersMilage.Text = ""; txtPmilagTotalRate.Text = "";
            //txtPersonalRate.Text = "";
        }

        private XmlNode CreateItemNode(XmlDocument doc, string BillDate, string starttime, string endtime, string MovDuration, string fromAddress, string movementAddress
            , string toAddress, string nightstay, string startmilage, string endmilage, string consumed, string remarks
            , string petrolqnt, string petrolcost, string octenqnt, string octencost, string cngqnt, string cngcost
            , string lubricantqnt, string lubricantcost, string busfair, string Rickfai, string cngfair, string trainfair
            , string Airplance, string othervhfair, string mntCost, string ferrytoll, string ownda, string driverda
            , string ownhotelfair, string driverhotel, string photocoly, string courier, string OtherCost, string totalcost
            , string FuelpaymentTypeid
            , string Cngcredit1FuelSupplierstationid, string CNGCredit1AmountcngFuelStationbill, string Cngcredit1FuelSupplierstationName
            , string Cngcredit2FuelSupplierstationid, string CNGCredit2AmountcngFuelStationbill, string Cngcredit2FuelSupplierstationName
            , string OilCredit1Supplierstationid, string oilCredit1Stationbill, string oilCredit1StationName
            , string personalusedMilageQnt, string personalUsedMilRate, string personalusemilageTotcost, string slNo
            )
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRBILLDATE = doc.CreateAttribute("BillDate");
            STRBILLDATE.Value = BillDate;

            XmlAttribute STARTTIME = doc.CreateAttribute("starttime");
            STARTTIME.Value = starttime;
            XmlAttribute ENDTIME = doc.CreateAttribute("endtime");
            ENDTIME.Value = endtime;
            XmlAttribute MOVDURATION = doc.CreateAttribute("MovDuration");
            MOVDURATION.Value = MovDuration;
            XmlAttribute FRMADDR = doc.CreateAttribute("fromAddress");
            FRMADDR.Value = fromAddress;
            XmlAttribute MOVADDR = doc.CreateAttribute("movementAddress");
            MOVADDR.Value = movementAddress;
            XmlAttribute TOADDR = doc.CreateAttribute("toAddress");
            TOADDR.Value = toAddress;

            XmlAttribute NIGHTSTAY = doc.CreateAttribute("nightstay");
            NIGHTSTAY.Value = nightstay;

            XmlAttribute STARTMILAGE = doc.CreateAttribute("startmilage");
            STARTMILAGE.Value = startmilage;

            XmlAttribute ENDMILAGE = doc.CreateAttribute("endmilage");
            ENDMILAGE.Value = endmilage;

            XmlAttribute CONSUMEDMILAGE = doc.CreateAttribute("consumed");
            CONSUMEDMILAGE.Value = consumed;

            XmlAttribute SUPPORTING = doc.CreateAttribute("remarks");
            SUPPORTING.Value = remarks;

            XmlAttribute PETROLQNT = doc.CreateAttribute("petrolqnt");
            PETROLQNT.Value = petrolqnt;

            XmlAttribute PETROLCOST = doc.CreateAttribute("petrolcost");
            PETROLCOST.Value = petrolcost;
            XmlAttribute OCTQNT = doc.CreateAttribute("octenqnt");
            OCTQNT.Value = octenqnt;
            XmlAttribute OCTCOST = doc.CreateAttribute("octencost");
            OCTCOST.Value = octencost;


            XmlAttribute CNGQNT = doc.CreateAttribute("cngqnt");
            CNGQNT.Value = cngqnt;

            XmlAttribute CNGCOST = doc.CreateAttribute("cngcost");
            CNGCOST.Value = cngcost;
            XmlAttribute LUBRICANTQNT = doc.CreateAttribute("lubricantqnt");
            LUBRICANTQNT.Value = lubricantqnt;
            XmlAttribute LUBRICANTCOST = doc.CreateAttribute("lubricantcost");
            LUBRICANTCOST.Value = lubricantcost;

            XmlAttribute BUSF = doc.CreateAttribute("busfair");
            BUSF.Value = busfair;
            XmlAttribute RICKF = doc.CreateAttribute("Rickfai");
            RICKF.Value = Rickfai;
            XmlAttribute CNGF = doc.CreateAttribute("cngfair");
            CNGF.Value = cngfair;
            XmlAttribute TRAINF = doc.CreateAttribute("trainfair");
            TRAINF.Value = trainfair;
            XmlAttribute AIRPLANCEF = doc.CreateAttribute("Airplance");
            AIRPLANCEF.Value = Airplance;

            XmlAttribute OTHVHF = doc.CreateAttribute("othervhfair");
            OTHVHF.Value = othervhfair;


            XmlAttribute MNTCOST = doc.CreateAttribute("mntCost");
            MNTCOST.Value = mntCost;

            XmlAttribute FERRYTOLL = doc.CreateAttribute("ferrytoll");
            FERRYTOLL.Value = ferrytoll;


            XmlAttribute OWNDA = doc.CreateAttribute("ownda");
            OWNDA.Value = ownda;
            XmlAttribute DRIVERDA = doc.CreateAttribute("driverda");
            DRIVERDA.Value = driverda;
            XmlAttribute OWNHOTELF = doc.CreateAttribute("ownhotelfair");
            OWNHOTELF.Value = ownhotelfair;

            XmlAttribute DRIVERHOTLF = doc.CreateAttribute("driverhotel");
            DRIVERHOTLF.Value = driverhotel;


            XmlAttribute PHOTOCOPY = doc.CreateAttribute("photocoly");
            PHOTOCOPY.Value = photocoly;

            XmlAttribute COURIER = doc.CreateAttribute("courier");
            COURIER.Value = courier;

            XmlAttribute OTHCOST = doc.CreateAttribute("OtherCost");
            OTHCOST.Value = OtherCost;

            XmlAttribute TOTALCOST = doc.CreateAttribute("totalcost");
            TOTALCOST.Value = totalcost;

            XmlAttribute FUELPAYMENTTYPEID = doc.CreateAttribute("FuelpaymentTypeid");
            FUELPAYMENTTYPEID.Value = FuelpaymentTypeid;


            XmlAttribute CNGCREDIT1FUELSUPPLIERSTATIONID = doc.CreateAttribute("Cngcredit1FuelSupplierstationid");
            CNGCREDIT1FUELSUPPLIERSTATIONID.Value = Cngcredit1FuelSupplierstationid;

            XmlAttribute CNGCREDIT1AMOUNTCNGFUELSTATIONBILL = doc.CreateAttribute("CNGCredit1AmountcngFuelStationbill");
            CNGCREDIT1AMOUNTCNGFUELSTATIONBILL.Value = CNGCredit1AmountcngFuelStationbill;

            XmlAttribute CNGCREDIT1FUELSUPPLIERSTATIONNAME = doc.CreateAttribute("Cngcredit1FuelSupplierstationName");
            CNGCREDIT1FUELSUPPLIERSTATIONNAME.Value = Cngcredit1FuelSupplierstationName;


            XmlAttribute CNGCREDIT2FUELSUPPLIERSTATIONID = doc.CreateAttribute("Cngcredit2FuelSupplierstationid");
            CNGCREDIT2FUELSUPPLIERSTATIONID.Value = Cngcredit2FuelSupplierstationid;

            XmlAttribute CNGCREDIT2AMOUNTCNGFUELSTATIONBILL = doc.CreateAttribute("CNGCredit2AmountcngFuelStationbill");
            CNGCREDIT2AMOUNTCNGFUELSTATIONBILL.Value = CNGCredit2AmountcngFuelStationbill;

            XmlAttribute CNGCREDIT2FUELSUPPLIERSTATIONNAME = doc.CreateAttribute("Cngcredit2FuelSupplierstationName");
            CNGCREDIT2FUELSUPPLIERSTATIONNAME.Value = Cngcredit2FuelSupplierstationName;


            XmlAttribute OILCREDIT1SUPPLIERSTATIONID = doc.CreateAttribute("OilCredit1Supplierstationid");
            OILCREDIT1SUPPLIERSTATIONID.Value = OilCredit1Supplierstationid;

            XmlAttribute OILCREDIT1SUPPLIERSTATIONBILL = doc.CreateAttribute("oilCredit1Stationbill");
            OILCREDIT1SUPPLIERSTATIONBILL.Value = oilCredit1Stationbill;

            XmlAttribute OILCREDIT1SUPPLIERSTATIONNAME = doc.CreateAttribute("oilCredit1StationName");
            OILCREDIT1SUPPLIERSTATIONNAME.Value = oilCredit1StationName;



            XmlAttribute PERSONALUSEMILAGEQNT = doc.CreateAttribute("personalusedMilageQnt");
            PERSONALUSEMILAGEQNT.Value = personalusedMilageQnt;

            XmlAttribute PERSONALUSEMILAGERATE = doc.CreateAttribute("personalUsedMilRate");
            PERSONALUSEMILAGERATE.Value = personalUsedMilRate;

            XmlAttribute PERSONALUSEMILAGETOTALCOST = doc.CreateAttribute("personalusemilageTotcost");
            PERSONALUSEMILAGETOTALCOST.Value = personalusemilageTotcost;
            XmlAttribute SLNO = doc.CreateAttribute("slNo");
            SLNO.Value = slNo;

            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(STARTTIME);
            node.Attributes.Append(ENDTIME);
            node.Attributes.Append(MOVDURATION);
            node.Attributes.Append(FRMADDR);
            node.Attributes.Append(MOVADDR);
            node.Attributes.Append(TOADDR);

            node.Attributes.Append(NIGHTSTAY);
            node.Attributes.Append(STARTMILAGE);
            node.Attributes.Append(ENDMILAGE);
            node.Attributes.Append(CONSUMEDMILAGE);
            node.Attributes.Append(SUPPORTING);

            node.Attributes.Append(PETROLQNT);
            node.Attributes.Append(PETROLCOST);
            node.Attributes.Append(OCTQNT);
            node.Attributes.Append(OCTCOST);
            node.Attributes.Append(CNGQNT);
            node.Attributes.Append(CNGCOST);
            node.Attributes.Append(LUBRICANTQNT);
            node.Attributes.Append(LUBRICANTCOST);
            node.Attributes.Append(BUSF);
            node.Attributes.Append(RICKF);
            node.Attributes.Append(CNGF);
            node.Attributes.Append(TRAINF);
            node.Attributes.Append(AIRPLANCEF);
            node.Attributes.Append(OTHVHF);

            node.Attributes.Append(MNTCOST);
            node.Attributes.Append(FERRYTOLL);

            node.Attributes.Append(OWNDA);
            node.Attributes.Append(DRIVERDA);
            node.Attributes.Append(OWNHOTELF);
            node.Attributes.Append(DRIVERHOTLF);

            node.Attributes.Append(PHOTOCOPY);
            node.Attributes.Append(COURIER);

            node.Attributes.Append(OTHCOST);

            node.Attributes.Append(TOTALCOST);

            node.Attributes.Append(FUELPAYMENTTYPEID);


            node.Attributes.Append(CNGCREDIT1FUELSUPPLIERSTATIONID);
            node.Attributes.Append(CNGCREDIT1AMOUNTCNGFUELSTATIONBILL);
            node.Attributes.Append(CNGCREDIT1FUELSUPPLIERSTATIONNAME);
            node.Attributes.Append(CNGCREDIT2FUELSUPPLIERSTATIONID);
            node.Attributes.Append(CNGCREDIT2AMOUNTCNGFUELSTATIONBILL);
            node.Attributes.Append(CNGCREDIT2FUELSUPPLIERSTATIONNAME);

            node.Attributes.Append(OILCREDIT1SUPPLIERSTATIONID);
            node.Attributes.Append(OILCREDIT1SUPPLIERSTATIONBILL);
            node.Attributes.Append(OILCREDIT1SUPPLIERSTATIONNAME);
            node.Attributes.Append(PERSONALUSEMILAGEQNT);
            node.Attributes.Append(PERSONALUSEMILAGERATE);
            node.Attributes.Append(PERSONALUSEMILAGETOTALCOST);
            node.Attributes.Append(SLNO);

            return node;
        }


        protected void btnAddBikeCarUser_Click(object sender, EventArgs e)
        {

            if (hdnconfirm.Value == "1")
            {

                string tst = rdbFuelStationList.SelectedValue.ToString();
                string Serial;
                if (tst == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptMessages", "alert('Please select Fuel station Payment Mode !')", true);
                }
                else
                {





                    tst = rdbFuelStationList.SelectedValue.ToString();
                    string Rickfai = "0", busfair = "0", cngfair = "0", trainfair = "0", Airplance = "0", othervhfair = "0",
                       ownda = "0", driverda = "0", ownhotelfair = "0", OtherCost = "0", starttime = "0", endtime = "0",
                       MovDuration = "0", nightstay = "NA", startmilage = "0", endmilage = "0", consumed = "0",

                     remarks = "NA", petrolqnt = "0", petrolcost = "0", octenqnt = "0", octencost = "0", cngqnt = "0", cngcost = "0",
                     lubricantqnt = "0", lubricantcost = "0", mntCost = "0", ferrytoll = "0", driverhotel = "0", photocoly = "0", courier = "0",
                     CNGCredit1AmountcngFuelStationbill = "0", CNGCredit2AmountcngFuelStationbill = "0", oilCredit1Stationbill = "0";


                    string FuelpaymentTypeid;
                    string Cngcredit1FuelSupplierstationid; string Cngcredit1FuelSupplierstationName;
                    string Cngcredit2FuelSupplierstationid; string Cngcredit2FuelSupplierstationName;
                    string OilCredit1Supplierstationid; string oilCredit1StationName;
                    string personalMilageqnt; string personalMilagerate; string personalMilagetotCost;

                    string BillDate = txtFromDate.Text;

                    starttime = txtStarTime.Text;
                    endtime = txtEndTime.Text;
                    MovDuration = txtMovDuration.Text;
                    string fromAddress = txtFromAddr.Text;
                    string movementAddress = txtMovementArea.Text;
                    string toAddress = txtToaddr.Text;
                    nightstay = txtNightStay.Text;
                    if (nightstay.Length <= 0) { nightstay = "0"; }

                    startmilage = txtStartMilage.Text;
                    if (startmilage.Length <= 0) { startmilage = "0"; }
                    endmilage = txtEndMilage.Text;
                    if (endmilage.Length <= 0) { endmilage = "0"; }
                    consumed = txtConsumed.Text;
                    if (consumed.Length <= 0) { consumed = "0"; }
                    remarks = txtSupporting.Text;
                    if (remarks.Length <= 0) { remarks = "NA"; }
                    if (rdbFuelStationList.SelectedItem.Text == "Cash pay") { FuelpaymentTypeid = "0"; }
                    else FuelpaymentTypeid = "1";

                    if (rdbFuelStationList.SelectedItem.Text == "Cash pay") { Cngcredit1FuelSupplierstationid = "0"; }
                    else Cngcredit1FuelSupplierstationid = (drdlSupplierName.SelectedValue.ToString());

                    if (rdbFuelStationList.SelectedItem.Text == "Cash pay") { Cngcredit2FuelSupplierstationid = "0"; }
                    else Cngcredit2FuelSupplierstationid = (drdlCNGStationNameCredit2.SelectedValue.ToString());

                    if (rdbFuelStationList.SelectedItem.Text == "Cash pay") { OilCredit1Supplierstationid = "0"; }
                    else OilCredit1Supplierstationid = (drdlOilCreditStationName1.SelectedValue.ToString());

                    Cngcredit1FuelSupplierstationName = drdlSupplierName.SelectedItem.Text;
                    Cngcredit2FuelSupplierstationName = drdlCNGStationNameCredit2.SelectedItem.Text;
                    oilCredit1StationName = drdlOilCreditStationName1.SelectedItem.Text;

                    CNGCredit1AmountcngFuelStationbill = txtSupplierCNGCredit1.Text;
                    if (CNGCredit1AmountcngFuelStationbill.Length <= 0) { CNGCredit1AmountcngFuelStationbill = "0"; }
                    CNGCredit2AmountcngFuelStationbill = txtSupplierCNGCredit2.Text;
                    if (CNGCredit2AmountcngFuelStationbill.Length <= 0) { CNGCredit2AmountcngFuelStationbill = "0"; }

                    oilCredit1Stationbill = txtOilCredit.Text;
                    if (oilCredit1Stationbill.Length <= 0) { oilCredit1Stationbill = "0"; }


                    personalMilageqnt = txtPersMilage.Text;
                    if (personalMilageqnt.Length <= 0) { personalMilageqnt = "0"; }

                    string personalMilageRate = "5.50";
                    if (personalMilageRate.Length <= 0) { personalMilageRate = "5.50"; }

                    personalMilagetotCost = txtPmilagTotalRate.Text;
                    if (personalMilagetotCost.Length <= 0) { personalMilagetotCost = "0"; }

                    petrolqnt = txtPetrolQnt.Text;
                    if (petrolqnt.Length <= 0) { petrolqnt = "0"; }
                    petrolcost = txtPetrolCost.Text;
                    if (petrolcost.Length <= 0) { petrolcost = "0"; }
                    octenqnt = txtOcten.Text;
                    if (octenqnt.Length <= 0) { octenqnt = "0"; }
                    octencost = txtOctenCost.Text;
                    if (octencost.Length <= 0) { octencost = "0"; }
                    cngqnt = txtCNGQnt.Text;
                    if (cngqnt.Length <= 0) { cngqnt = "0"; }
                    cngcost = txtCNGCost.Text;
                    if (cngcost.Length <= 0) { cngcost = "0"; }
                    lubricantqnt = txtMobilQnt.Text;
                    if (lubricantqnt.Length <= 0) { lubricantqnt = "0"; }
                    lubricantcost = txtMobilCost.Text;
                    if (lubricantcost.Length <= 0) { lubricantcost = "0"; }
                    busfair = txtBusFair.Text;
                    if (busfair.Length <= 0) { busfair = "0"; }

                    Rickfai = txtRickshaw.Text;
                    if (Rickfai.Length <= 0) { Rickfai = "0"; }

                    cngfair = txtCNG.Text;
                    if (cngfair.Length <= 0) { cngfair = "0"; }

                    trainfair = txtTrain.Text;
                    if (trainfair.Length <= 0) { trainfair = "0"; }

                    Airplance = txtAirPlane.Text;
                    if (Airplance.Length <= 0) { Airplance = "0"; }

                    othervhfair = txtOtherVh.Text;
                    if (othervhfair.Length <= 0) { othervhfair = "0"; }

                    mntCost = txtMntVh.Text;
                    if (mntCost.Length <= 0) { mntCost = "0"; }

                    ferrytoll = txtFerryToll.Text;
                    if (ferrytoll.Length <= 0) { ferrytoll = "0"; }

                    ownda = txtOwnDA.Text;
                    if (ownda.Length <= 0) { ownda = "0"; }

                    driverda = txtDriverDA.Text;
                    if (driverda.Length <= 0) { driverda = "0"; }

                    ownhotelfair = txtOwnHotel.Text;
                    if (ownhotelfair.Length <= 0) { ownhotelfair = "0"; }

                    driverhotel = txtDriverHotel.Text;
                    if (driverhotel.Length <= 0) { driverhotel = "0"; }

                    photocoly = txtCourier.Text;
                    if (photocoly.Length <= 0) { photocoly = "0"; }

                    courier = txtCourier.Text;
                    if (courier.Length <= 0) { courier = "0"; }

                    OtherCost = txtOtherCost.Text;
                    if (OtherCost.Length <= 0) { OtherCost = "0"; }

                    string totalcost = txtTotal.Text;

                    string cureentdate = DateTime.Now.ToString("yyyy-MM-dd");
                    var now = DateTime.Now;
                    var startOfMonth = new DateTime(now.Year, now.Month, 1);
                    var DaysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                    var lastDay = new DateTime(now.Year, now.Month, DaysInMonth).AddDays(06);
                    string lastd = lastDay.ToString("yyyy-MM-dd");
                    DateTime today = Convert.ToDateTime(BillDate);
                    DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)).AddDays(06);
                    DateTime dt3 = Convert.ToDateTime(endOfMonth);
                    DateTime dt4 = Convert.ToDateTime(cureentdate);
                    int diffbEOMTODATE = (dt3 - dt4).Days;




                    if (diffbEOMTODATE > 0)
                    {



                        if (BillDate == string.Empty || BillDate == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select from date from calender !')", true);
                        }

                        else if (MovDuration == string.Empty || MovDuration == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Consumed time can not blank !')", true);
                        }

                        else if (fromAddress == string.Empty || fromAddress == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('From address can not blank !')", true);
                        }

                        else if (movementAddress == string.Empty || movementAddress == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Movement address can not blank !')", true);
                        }




                        else
                        {

                            string strBillDate = DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd");

                            string strstarttime = Convert.ToString(txtStarTime.Text);
                            string strendtime = Convert.ToString(txtEndTime.Text);
                            string strMovDuration = Convert.ToString(txtMovDuration.Text);
                            string strfromAddress = Convert.ToString(txtFromAddr.Text);
                            string strmovementAddress = Convert.ToString(txtMovementArea.Text);
                            string strtoAddress = Convert.ToString(txtToaddr.Text);
                            if (strtoAddress.Length <= 0) { strtoAddress = "NA"; }
                            string strnightstay = Convert.ToString(txtNightStay.Text);
                            if (strnightstay.Length <= 0) { strnightstay = "NA"; }

                            string strstartmilage = txtStartMilage.Text;
                            if (strstartmilage.Length <= 0) { strstartmilage = "0"; }
                            string strendmilage = txtEndMilage.Text;
                            if (strendmilage.Length <= 0) { strendmilage = "0"; }
                            string strconsumed = txtConsumed.Text;
                            if (strconsumed.Length <= 0) { strconsumed = "0"; }
                            string strremarks = txtSupporting.Text;
                            if (strremarks.Length <= 0) { strremarks = "NA"; }

                            if (rdbFuelStationList.SelectedItem.Text == "Credit") { FuelpaymentTypeid = "1"; }
                            else if (rdbFuelStationList.SelectedItem.Text == "Cash") { FuelpaymentTypeid = "0"; }
                            else { FuelpaymentTypeid = "2"; }



                            string strCngcredit1FuelSupplierstationid = (drdlSupplierName.SelectedValue.ToString());
                            if (strCngcredit1FuelSupplierstationid.Length <= 0) { strCngcredit1FuelSupplierstationid = "0"; }
                            string strCNGCredit1AmountcngFuelStationbill = txtSupplierCNGCredit1.Text;
                            if (strCNGCredit1AmountcngFuelStationbill.Length <= 0) { strCNGCredit1AmountcngFuelStationbill = "0"; }
                            string strCngcredit1FuelSupplierstationName = (drdlSupplierName.SelectedItem.Text);
                            if (strCngcredit1FuelSupplierstationName.Length <= 0) { strCngcredit1FuelSupplierstationName = "NA"; }


                            string strCngcredit2FuelSupplierstationid = (drdlCNGStationNameCredit2.SelectedValue.ToString());
                            if (strCngcredit1FuelSupplierstationid.Length <= 0) { strCngcredit1FuelSupplierstationid = "0"; }
                            string strCNGCredit2AmountcngFuelStationbill = txtSupplierCNGCredit2.Text;
                            if (strCNGCredit2AmountcngFuelStationbill.Length <= 0) { strCNGCredit2AmountcngFuelStationbill = "0"; }
                            string strCngcredit2FuelSupplierstationName = (drdlCNGStationNameCredit2.SelectedItem.Text);
                            if (strCngcredit2FuelSupplierstationName.Length <= 0) { strCngcredit2FuelSupplierstationName = "NA"; }

                            string strOilCredit1Supplierstationid = (drdlOilCreditStationName1.SelectedValue.ToString());
                            if (strOilCredit1Supplierstationid.Length <= 0) { strOilCredit1Supplierstationid = "0"; }
                            string stroilCredit1Stationbill = txtOilCredit.Text;
                            if (stroilCredit1Stationbill.Length <= 0) { stroilCredit1Stationbill = "0"; }
                            string stroilCredit1StationName = (drdlOilCreditStationName1.SelectedItem.Text);
                            if (stroilCredit1StationName.Length <= 0) { stroilCredit1StationName = "NA"; }



                            string strpersonalMilageqnt = txtPersMilage.Text;
                            if (strpersonalMilageqnt.Length <= 0) { strpersonalMilageqnt = "0"; }
                            string strpersonalMilagerate = "5.5";
                            if (strpersonalMilagerate.Length <= 0) { strpersonalMilagerate = "5.5"; }
                            string strpersonalMilagetotCost = txtPmilagTotalRate.Text;
                            if (strpersonalMilagetotCost.Length <= 0) { strpersonalMilagetotCost = "0"; }



                            string strpetrolqnt = txtPetrolQnt.Text;
                            if (strpetrolqnt.Length <= 0) { strpetrolqnt = "0"; }
                            string strpetrolcost = txtPetrolCost.Text;
                            if (strpetrolcost.Length <= 0) { strpetrolcost = "0"; }
                            string stroctenqnt = txtOcten.Text;
                            if (stroctenqnt.Length <= 0) { stroctenqnt = "0"; }
                            string stroctencost = txtOctenCost.Text;
                            if (stroctencost.Length <= 0) { stroctencost = "0"; }
                            string strcngqnt = txtCNGQnt.Text;
                            if (strcngqnt.Length <= 0) { strcngqnt = "0"; }
                            string strcngcost = txtCNGCost.Text;
                            if (strcngcost.Length <= 0) { strcngcost = "0"; }

                            string strlubricantqnt = txtMobilQnt.Text;
                            if (strlubricantqnt.Length <= 0) { strlubricantqnt = "0"; }
                            string strlubricantcost = txtMobilCost.Text;
                            if (strlubricantcost.Length <= 0) { strlubricantcost = "0"; }
                            string strbusfair = txtBusFair.Text;
                            if (strbusfair.Length <= 0) { strbusfair = "0"; }

                            string strRickfai = txtRickshaw.Text;
                            if (strRickfai.Length <= 0) { strRickfai = "0"; }

                            string strcngfair = txtCNG.Text;
                            if (strcngfair.Length <= 0) { strcngfair = "0"; }

                            string strtrainfair = txtTrain.Text;
                            if (strtrainfair.Length <= 0) { strtrainfair = "0"; }

                            string strAirplance = txtAirPlane.Text;
                            if (strAirplance.Length <= 0) { strAirplance = "0"; }

                            string strothervhfair = txtOtherVh.Text;
                            if (strothervhfair.Length <= 0) { strothervhfair = "0"; }

                            string strmntCost = txtMntVh.Text;
                            if (strmntCost.Length <= 0) { strmntCost = "0"; }

                            string strferrytoll = txtFerryToll.Text;
                            if (strferrytoll.Length <= 0) { strferrytoll = "0"; }

                            string strownda = txtOwnDA.Text;
                            if (strownda.Length <= 0) { strownda = "0"; }

                            string strdriverda = txtDriverDA.Text;
                            if (strdriverda.Length <= 0) { strdriverda = "0"; }

                            string strownhotelfair = txtOwnHotel.Text;
                            if (strownhotelfair.Length <= 0) { strownhotelfair = "0"; }

                            string strdriverhotel = txtDriverHotel.Text;
                            if (strdriverhotel.Length <= 0) { strdriverhotel = "0"; }

                            string strphotocoly = txtCourier.Text;
                            if (strphotocoly.Length <= 0) { strphotocoly = "0"; }

                            string strcourier = txtCourier.Text;
                            if (strcourier.Length <= 0) { strcourier = "0"; }

                            string strOtherCost = txtOtherCost.Text;
                            if (strOtherCost.Length <= 0) { strOtherCost = "0"; }

                            string strtotalcost = txtTotal.Text;
                            if (strtotalcost.Length <= 0) { strtotalcost = "0"; }


                            if (GridviewBikeCarUserInputInfo.Rows.Count <= 0)
                            {
                                Serial = "1";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 1)
                            {
                                Serial = "2";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 2)
                            {
                                Serial = "3";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 3)
                            {
                                Serial = "4";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 4)
                            {
                                Serial = "5";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 5)
                            {
                                Serial = "6";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 6)
                            {
                                Serial = "7";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 7)
                            {
                                Serial = "8";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 8)
                            {
                                Serial = "9";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 9)
                            {
                                Serial = "10";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 10)
                            {
                                Serial = "11";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }
                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 11)
                            {
                                Serial = "12";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }
                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 12)
                            {
                                Serial = "13";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 13)
                            {
                                Serial = "14";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }
                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 14)
                            {
                                Serial = "15";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }

                            else if (GridviewBikeCarUserInputInfo.Rows.Count == 15)
                            {
                                Serial = "16";
                                CreateVoucherXml(strBillDate, strstarttime, strendtime, strMovDuration, strfromAddress, strmovementAddress, strtoAddress, strnightstay, strstartmilage
                              , strendmilage, strconsumed, strremarks, strpetrolqnt, strpetrolcost, stroctenqnt, stroctencost, strcngqnt, strcngcost, strlubricantqnt, strlubricantcost
                              , strbusfair, strRickfai, strcngfair, strtrainfair, strAirplance, strothervhfair, strmntCost, strferrytoll, strownda
                              , strdriverda, strownhotelfair, strdriverhotel, strphotocoly, strcourier, strOtherCost, strtotalcost
                              , FuelpaymentTypeid
                              , strCngcredit1FuelSupplierstationid, strCNGCredit1AmountcngFuelStationbill, strCngcredit1FuelSupplierstationName
                              , strCngcredit2FuelSupplierstationid, strCNGCredit2AmountcngFuelStationbill, strCngcredit2FuelSupplierstationName
                              , strOilCredit1Supplierstationid, stroilCredit1Stationbill, stroilCredit1StationName
                               , strpersonalMilageqnt, strpersonalMilagerate, strpersonalMilagetotCost, Serial);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not allow to add more than Fifteen rows !')", true);

                            }



                        }
                    }

                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You try to back date entry.Plase contact to HR Dept. for detaills. All r request to submit bill within current month.After 5th date of next month. you are not allow for submit Previous month bill')", true);
                    }

                }

            }

        }


        protected void btnSubmitBikeCar_Click(object sender, EventArgs e)
        {

            if (hdnconfirm.Value == "1")
            {

                if (GridviewBikeCarUserInputInfo.Rows.Count > 0)
                {
                    #region ------------ Insert into dataBase -----------

                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);
                    int BikeCarUserTypeid = 1;
                    HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                    int unit = Convert.ToInt32(HiddenUnit.Value);
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    int jobstation = Convert.ToInt32(hdnstation.Value);
                    XmlDocument doc = new XmlDocument();

                    try
                    {
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("RemotetadaBikeCarUser");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<RemotetadaBikeCarUser>" + xmlString + "</RemotetadaBikeCarUser>";
                        string message = bll.tadaInsertByApplicantBikeAndCarUser(xmlString, dteFromDate, enroll, BikeCarUserTypeid, unit, jobstation);
                        File.Delete(filePathForXML); ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }

                    catch
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                    }



                    #endregion ------------ Insertion End ----------------


                }
                GridviewBikeCarUserInputInfo.DataBind();
                
                GridviewBikeCarUserInputInfo.DataSource = "";
                GridviewBikeCarUserInputInfo.DataBind();

            }
        }
        protected void GridviewBikeCarUserInputInfo_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void GridviewBikeCarUserInputInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)GridviewBikeCarUserInputInfo.DataSource;
                dsGrid.Tables[0].Rows[GridviewBikeCarUserInputInfo.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)GridviewBikeCarUserInputInfo.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); GridviewBikeCarUserInputInfo.DataSource = ""; GridviewBikeCarUserInputInfo.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void rdbFuelStationList_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (rdbFuelStationList.SelectedItem.Text == "Cash")
            {
                drdlSupplierName.Enabled = false;
                txtSupplierCNGCredit1.Enabled = false;
                drdlCNGStationNameCredit2.Enabled = false;
                txtSupplierCNGCredit2.Enabled = false;
                drdlOilCreditStationName1.Enabled = false;
                txtOilCredit.Enabled = false;
                txtPetrolCost.Enabled = true;
                txtOctenCost.Enabled = true;
                txtCNGCost.Enabled = true;
                txtMobilCost.Enabled = true;
            }

            else if (rdbFuelStationList.SelectedItem.Text == "Credit")
            {
                drdlSupplierName.Enabled = true;
                txtSupplierCNGCredit1.Enabled = true;
                drdlCNGStationNameCredit2.Enabled = true;
                txtSupplierCNGCredit2.Enabled = true;
                drdlOilCreditStationName1.Enabled = true;
                txtOilCredit.Enabled = true;
                txtPetrolCost.Enabled = false;
                txtOctenCost.Enabled = false;
                txtCNGCost.Enabled = false;
                txtMobilCost.Enabled = false;
            }

            //else if (rdbFuelStationList.SelectedItem.Text == "Credit")
            //{
            //    drdlSupplierName.Enabled = true;
            //    txtSupplierCNGCredit1.Enabled = true;
            //    drdlCNGStationNameCredit2.Enabled = true;
            //    txtSupplierCNGCredit2.Enabled = true;
            //    drdlOilCreditStationName1.Enabled = true;
            //    txtOilCredit.Enabled = true;
            //    txtPetrolCost.Enabled = false;
            //    txtOctenCost.Enabled = false;
            //    txtCNGCost.Enabled = false;
            //    txtMobilCost.Enabled = false;
            //}




            else
            {

                drdlSupplierName.Enabled = true;
                txtSupplierCNGCredit1.Enabled = true;
                drdlCNGStationNameCredit2.Enabled = true;
                txtSupplierCNGCredit2.Enabled = true;
                drdlOilCreditStationName1.Enabled = true;
                txtOilCredit.Enabled = true;
                txtPetrolCost.Enabled = true;
                txtOctenCost.Enabled = true;
                txtCNGCost.Enabled = true;
                txtMobilCost.Enabled = true;

            }


            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "sum();", true);
        }


    }
}