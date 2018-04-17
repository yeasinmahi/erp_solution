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
    public partial class RemoteTADAApproveForBikeCarUser : BasePage
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        decimal petrolcost = 0; decimal octencost = 0; decimal cngcost = 0; decimal lubriantcost = 0;
        decimal busfare = 0; decimal Rickfare = 0; decimal cngfare = 0; decimal trainfare = 0; decimal airplance = 0; decimal othervhfare = 0;
        decimal mntcost = 0; decimal ferrytol = 0;

        decimal ownda = 0; decimal driverda = 0; decimal ownhotel = 0; decimal driverhotel = 0;
        decimal photocopy = 0; decimal courier = 0; decimal othercost = 0; decimal totalcost = 0;
        int RowIndex;

        string filePathForXML;

        string xmlString = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();





        protected void Page_Load(object sender, EventArgs e)
        {

            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            hdnUnitid.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

            filePathForXML = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaApproveBikeCarUserGb.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//


            }




        }

        protected void btnApprTADAFoBikeCarUser_Click(object sender, EventArgs e)
        {
            showDataForApprove();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rptTypeid == 1)
            {

                if (grdvForApproveTADABikeCarUser.Rows.Count > 0)
                {
                    for (int rowIndex = 0; rowIndex < grdvForApproveTADABikeCarUser.Rows.Count - 1; rowIndex++)
                    {


                        TextBox txtdteFromdateNoBikeDet = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[1].FindControl("dteFromdateNoBikeDet");
                        TextBox TextdteInsdateNoBikeDet = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[2].FindControl("dteInsdateNoBikeDet");

                        TextBox txtstrNamNoBikeDet = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[3].FindControl("strNamNoBikeDet");
                        TextBox txtStarTime = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[4].FindControl("txtStarTime");

                        TextBox txtdecEndHourT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[5].FindControl("txtdecEndHourT");
                        TextBox txtdecmovdur = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[6].FindControl("txtdecmovdur");



                        TextBox txtstrFromAddressT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[7].FindControl("txtstrFromAddressT");
                        TextBox txtstrMovementAreaT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[8].FindControl("txtstrMovementAreaT");
                        TextBox txtstrToAddressT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[9].FindControl("txtstrToAddressT");


                        TextBox txtstrNightStayT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[10].FindControl("txtstrNightStayT");
                        TextBox txtdecStartMilageT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[11].FindControl("txtdecStartMilageT");
                        TextBox txtdecEndMilageT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[12].FindControl("txtdecEndMilageT");
                        TextBox txtdecConsumedKmT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[13].FindControl("txtdecConsumedKmT");
                        TextBox txtstrSupportingNoT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[14].FindControl("txtstrSupportingNoT");


                        TextBox txtdecQntPetrolT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[15].FindControl("txtdecQntPetrolT");
                        TextBox txtdecCostPetrolT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[16].FindControl("txtdecCostPetrolT");


                        TextBox txtdecQntOctenT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[17].FindControl("txtdecQntOctenT");
                        TextBox txtdecCostOctenT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[18].FindControl("txtdecCostOctenT");
                        TextBox txtdecQntCarbonNitGasT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[19].FindControl("txtdecQntCarbonNitGasT");
                        TextBox txtdecCostCarbonNitGasT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[20].FindControl("txtdecCostCarbonNitGasT");


                        TextBox txtdecQntLubricant = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[21].FindControl("txtdecQntLubricant");
                        TextBox txtdecCostLubricant = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[22].FindControl("txtdecCostLubricant");


                        TextBox txtdecFareBusAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[23].FindControl("txtdecFareBusAmountT");
                        TextBox txtdecFareRickshawAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[24].FindControl("txtdecFareRickshawAmountT");
                        TextBox txtdecFareCNGAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[25].FindControl("txtdecFareCNGAmountT");
                        TextBox txtdecFareTrainAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[26].FindControl("txtdecFareTrainAmountT");
                        TextBox txtdecFareAirPlaneT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[27].FindControl("txtdecFareAirPlaneT");
                        TextBox txtdecFareOtherVheicleAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[28].FindControl("txtdecFareOtherVheicleAmountT");

                        TextBox txtdecCostAmountMaintenaceT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[29].FindControl("txtdecCostAmountMaintenaceT");
                        TextBox txtdecFeryTollCostT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[30].FindControl("txtdecFeryTollCostT");


                        TextBox txtdecDAAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[31].FindControl("txtdecDAAmountT");
                        TextBox txtdecDriverDACostT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[32].FindControl("txtdecDriverDACostT");
                        TextBox txtdecHotelBillAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[33].FindControl("txtdecHotelBillAmountT");
                        TextBox txtdecDriverHotelBillAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[34].FindControl("txtdecDriverHotelBillAmountT");

                        TextBox txtdecPhotoCopyCostT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[35].FindControl("txtdecPhotoCopyCostT");
                        TextBox txtdecCourierCostT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[36].FindControl("txtdecCourierCostT");


                        TextBox txtdecOtherBillAmountT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[37].FindControl("txtdecOtherBillAmountT");
                        TextBox txtdecRowTotalT = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[38].FindControl("txtdecRowTotalT");

                        TextBox txtdecSupplierCNG = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[39].FindControl("txtdecSupplierCNG");
                        TextBox txtdecSupplierGas = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[40].FindControl("txtdecSupplierGas");
                        TextBox txtdecPersonalMilage = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[41].FindControl("txtdecPersonalMilage");
                        TextBox txtdecMlgRate = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[42].FindControl("txtdecMlgRate");
                        TextBox txtdecPersonalTotalcost = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[43].FindControl("txtdecPersonalTotalcost");
                        TextBox txtPaymentType = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[44].FindControl("txtPaymentType");
                        TextBox txtstrFuelStationaname = (TextBox)grdvForApproveTADABikeCarUser.Rows[rowIndex].Cells[45].FindControl("txtstrFuelStationaname");


                        string strBillDate = txtdteFromdateNoBikeDet.Text;
                        string strBilSubmitteddate = TextdteInsdateNoBikeDet.Text;
                        string strName = txtstrNamNoBikeDet.Text;

                        string strstart = txtStarTime.Text;
                        string strEndTime = txtdecEndHourT.Text;
                        string strMovDuration = txtdecmovdur.Text;
                        string strFromAdress = txtstrFromAddressT.Text;
                        string strMoveArea = txtstrMovementAreaT.Text;
                        string strToAddress = txtstrToAddressT.Text;
                        string strNighstay = txtstrNightStayT.Text;

                        string strStartMilage = txtdecStartMilageT.Text;
                        string strEndMilage = txtdecEndMilageT.Text;
                        string strConsumedKM = txtdecConsumedKmT.Text;

                        string strRemarks = txtstrSupportingNoT.Text;
                        string strQntPetrol = txtdecQntPetrolT.Text;
                        string strCostPetrol = txtdecCostPetrolT.Text;
                        string strQntOcten = txtdecQntOctenT.Text;
                        string strCostOcten = txtdecCostOctenT.Text;
                        string strQntCarBonNitr = txtdecQntCarbonNitGasT.Text;
                        string strCostCarbonNit = txtdecCostCarbonNitGasT.Text;
                        string strQntLubricant = txtdecQntLubricant.Text;
                        string strCostLubricant = txtdecCostLubricant.Text;

                        string strBusFareTaka = txtdecFareBusAmountT.Text;
                        string strRickFare = txtdecFareRickshawAmountT.Text;
                        string strCNGFare = txtdecFareCNGAmountT.Text;
                        string strTrainFare = txtdecFareTrainAmountT.Text;
                        string strAirplane = txtdecFareAirPlaneT.Text;
                        string strOtherVhFare = txtdecFareOtherVheicleAmountT.Text;

                        string strMntCost = txtdecCostAmountMaintenaceT.Text;
                        string strFerryTol = txtdecFeryTollCostT.Text;

                        string strOwnDA = txtdecDAAmountT.Text;
                        string strOtherDA = txtdecDriverDACostT.Text;
                        string strOwnHotel = txtdecHotelBillAmountT.Text;
                        string strDriverHotel = txtdecDriverHotelBillAmountT.Text;

                        string strPhotocopy = txtdecPhotoCopyCostT.Text;
                        string strCourier = txtdecCourierCostT.Text;

                        string strOtherCost = txtdecOtherBillAmountT.Text;
                        string strRowTotal = txtdecRowTotalT.Text;
                        string strSupCNGBill = txtdecSupplierCNG.Text;
                        string strSupplGasBill = txtdecSupplierGas.Text;
                        string strPersonalMilaqnt = txtdecPersonalMilage.Text;
                        string srPersonalRate = txtdecMlgRate.Text;
                        string strPersonMlgTotal = txtdecPersonalTotalcost.Text;
                        string strPaymentType = txtPaymentType.Text;
                        string strFuelSupplierName = txtstrFuelStationaname.Text;



                        CreateSalesXml(strBillDate, strBilSubmitteddate, strName, strstart, strEndTime, strMovDuration, strFromAdress
                            , strMoveArea, strToAddress, strNighstay, strStartMilage, strEndMilage, strConsumedKM, strRemarks, strQntPetrol
                            , strCostPetrol, strQntOcten, strCostOcten, strQntCarBonNitr, strCostCarbonNit, strQntLubricant, strCostLubricant
                            , strBusFareTaka, strRickFare, strCNGFare, strTrainFare
                            , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                            , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal
                            , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName


                            );


                    }
                    #region ------------ Insert into dataBase -----------


                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    hdnUnitid.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                    Int32 Approverenroll = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                    int Jobstation = Convert.ToInt32(hdnstation.Value);
                    int unit = Convert.ToInt32(hdnUnitid.Value);
                    string strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();

                    string TSOName = strSearchKey;
                    int intTADAApplicantEnrol = int.Parse(code);

                    int intApplicantCatge = 1;


                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("RemotetadaApproveBikeCarUserGb");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemotetadaApproveBikeCarUserGb>" + xmlString + "</RemotetadaApproveBikeCarUserGb>";
                    string message = bll.tadainsertAfterApproveForBikeAndCarUserGB(xmlString, Approverenroll, intTADAApplicantEnrol, dteFromDate, unit, intApplicantCatge, Jobstation);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);



                    #endregion ------------ Insertion End ----------------

                }

                grdvForApproveTADABikeCarUser.DataBind();
                File.Delete(filePathForXML);



            }
            //when user select Detaills from dropdown
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Topsheet then click Approve');", true);
            }

        }


        private void CreateSalesXml(string strBillDate, string strBilSubmitteddate, string strName, string strstart, string strEndTime, string strMovDuration, string strFromAdress
           , string strMoveArea, string strToAddress, string strNighstay, string strStartMilage, string strEndMilage, string strConsumedKM, string strRemarks
            , string strQntPetrol, string strCostPetrol, string strQntOcten, string strCostOcten, string strQntCarBonNitr, string strCostCarbonNit, string strQntLubricant
            , string strCostLubricant, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strAirplane, string strOtherVhFare
            , string strMntCost, string strFerryTol, string strOwnDA, string strOtherDA, string strOwnHotel, string strDriverHotel, string strPhotocopy
            , string strCourier, string strOtherCost, string strRowTotal
            , string strSupCNGBill, string strSupplGasBill, string strPersonalMilaqnt, string srPersonalRate, string strPersonMlgTotal, string strPaymentType, string strFuelSupplierName


            )
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemotetadaApproveBikeCarUserGb");
                XmlNode addItem = CreateItemNode(doc, strBillDate, strBilSubmitteddate, strName, strstart, strEndTime, strMovDuration, strFromAdress
                                , strMoveArea, strToAddress, strNighstay, strStartMilage, strEndMilage, strConsumedKM, strRemarks, strQntPetrol
                                , strCostPetrol, strQntOcten, strCostOcten, strQntCarBonNitr, strCostCarbonNit, strQntLubricant, strCostLubricant
                                , strBusFareTaka, strRickFare, strCNGFare, strTrainFare
                                , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                                , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal
                                 , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName

                                );
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaApproveBikeCarUserGb");
                XmlNode addItem = CreateItemNode(doc, strBillDate, strBilSubmitteddate, strName, strstart, strEndTime, strMovDuration, strFromAdress
                                , strMoveArea, strToAddress, strNighstay, strStartMilage, strEndMilage, strConsumedKM, strRemarks, strQntPetrol
                                , strCostPetrol, strQntOcten, strCostOcten, strQntCarBonNitr, strCostCarbonNit, strQntLubricant, strCostLubricant
                                , strBusFareTaka, strRickFare, strCNGFare, strTrainFare
                                , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                                , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal
                                 , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName

                                );
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }


        private XmlNode CreateItemNode(XmlDocument doc, string strBillDate, string strBilSubmitteddate, string strName, string strstart, string strEndTime, string strMovDuration, string strFromAdress
                                , string strMoveArea, string strToAddress, string strNighstay, string strStartMilage, string strEndMilage, string strConsumedKM, string strRemarks, string strQntPetrol
                                , string strCostPetrol, string strQntOcten, string strCostOcten, string strQntCarBonNitr, string strCostCarbonNit, string strQntLubricant, string strCostLubricant
                                , string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare
                                , string strAirplane, string strOtherVhFare, string strMntCost, string strFerryTol, string strOwnDA, string strOtherDA, string strOwnHotel
                                , string strDriverHotel, string strPhotocopy, string strCourier, string strOtherCost, string strRowTotal
                                , string strSupCNGBill, string strSupplGasBill, string strPersonalMilaqnt, string srPersonalRate, string strPersonMlgTotal, string strPaymentType, string strFuelSupplierName
                                  )
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute STRBILLDATE = doc.CreateAttribute("strBillDate");
            STRBILLDATE.Value = strBillDate;
            XmlAttribute STRBILLSubMitDate = doc.CreateAttribute("strBilSubmitteddate");
            STRBILLSubMitDate.Value = strBilSubmitteddate;
            XmlAttribute STRNAME = doc.CreateAttribute("strName");
            STRNAME.Value = strName;
            XmlAttribute STRSTART = doc.CreateAttribute("strstart");
            STRSTART.Value = strstart;
            XmlAttribute STRENDTIME = doc.CreateAttribute("strEndTime");
            STRENDTIME.Value = strEndTime;


            XmlAttribute STRMOVDURATION = doc.CreateAttribute("strMovDuration");
            STRMOVDURATION.Value = strMovDuration;
            XmlAttribute FRMADDR = doc.CreateAttribute("strFromAdress");
            FRMADDR.Value = strFromAdress;
            XmlAttribute MOVADDR = doc.CreateAttribute("strMoveArea");
            MOVADDR.Value = strMoveArea;
            XmlAttribute TOADDR = doc.CreateAttribute("strToAddress");
            TOADDR.Value = strToAddress;


            XmlAttribute STRNIGHTSTAY = doc.CreateAttribute("strNighstay");
            STRNIGHTSTAY.Value = strNighstay;
            XmlAttribute STRSTARTMILAGE = doc.CreateAttribute("strStartMilage");
            STRSTARTMILAGE.Value = strStartMilage;
            XmlAttribute STRENDMILAGE = doc.CreateAttribute("strEndMilage");
            STRENDMILAGE.Value = strEndMilage;
            XmlAttribute STRCONSUMEDKM = doc.CreateAttribute("strConsumedKM");
            STRCONSUMEDKM.Value = strConsumedKM;
            XmlAttribute STRREMARKS = doc.CreateAttribute("strRemarks");
            STRREMARKS.Value = strRemarks;


            XmlAttribute STRQNTPETROL = doc.CreateAttribute("strQntPetrol");
            STRQNTPETROL.Value = strQntPetrol;
            XmlAttribute STRCOSTPETROL = doc.CreateAttribute("strCostPetrol");
            STRCOSTPETROL.Value = strCostPetrol;
            XmlAttribute STRQNTOCTEN = doc.CreateAttribute("strQntOcten");
            STRQNTOCTEN.Value = strQntOcten;
            XmlAttribute STRCOSTOCTEN = doc.CreateAttribute("strCostOcten");
            STRCOSTOCTEN.Value = strCostOcten;

            XmlAttribute STRQNTCARBONNIT = doc.CreateAttribute("strQntCarBonNitr");
            STRQNTCARBONNIT.Value = strQntCarBonNitr;
            XmlAttribute STRCOSTCARBONNIT = doc.CreateAttribute("strCostCarbonNit");
            STRCOSTCARBONNIT.Value = strCostCarbonNit;


            XmlAttribute STRQNTLUBRICANT = doc.CreateAttribute("strQntLubricant");
            STRQNTLUBRICANT.Value = strQntLubricant;
            XmlAttribute STRCOSTLUBRICANT = doc.CreateAttribute("strCostLubricant");
            STRCOSTLUBRICANT.Value = strCostLubricant;

            XmlAttribute STRBUSFARI = doc.CreateAttribute("strBusFareTaka");
            STRBUSFARI.Value = strBusFareTaka;
            XmlAttribute STRRICKFAIR = doc.CreateAttribute("strRickFare");
            STRRICKFAIR.Value = strRickFare;
            XmlAttribute STRCNGFARE = doc.CreateAttribute("strCNGFare");
            STRCNGFARE.Value = strCNGFare;
            XmlAttribute STRTRAINFARE = doc.CreateAttribute("strTrainFare");
            STRTRAINFARE.Value = strTrainFare;
            XmlAttribute STRAIRPLANCE = doc.CreateAttribute("strAirplane");
            STRAIRPLANCE.Value = strAirplane;

            XmlAttribute OTHVHF = doc.CreateAttribute("strOtherVhFare");
            OTHVHF.Value = strOtherVhFare;
            XmlAttribute STRMNT = doc.CreateAttribute("strMntCost");
            STRMNT.Value = strMntCost;


            XmlAttribute STRFERRY = doc.CreateAttribute("strFerryTol");
            STRFERRY.Value = strFerryTol;
            XmlAttribute OWNDA = doc.CreateAttribute("strOwnDA");
            OWNDA.Value = strOwnDA;

            XmlAttribute OTHEPDA = doc.CreateAttribute("strOtherDA");
            OTHEPDA.Value = strOtherDA;
            XmlAttribute STROWNHOTEL = doc.CreateAttribute("strOwnHotel");
            STROWNHOTEL.Value = strOwnHotel;
            XmlAttribute STRDRIVERHOTEL = doc.CreateAttribute("strDriverHotel");
            STRDRIVERHOTEL.Value = strDriverHotel;
            XmlAttribute STRPHOTOCOPY = doc.CreateAttribute("strPhotocopy");
            STRPHOTOCOPY.Value = strPhotocopy;
            XmlAttribute STRCOURIER = doc.CreateAttribute("strCourier");
            STRCOURIER.Value = strCourier;
            XmlAttribute OTHCOST = doc.CreateAttribute("strOtherCost");
            OTHCOST.Value = strOtherCost;
            XmlAttribute TOTALCOST = doc.CreateAttribute("strRowTotal");
            TOTALCOST.Value = strRowTotal;

            XmlAttribute STRSUPLCNGBILL = doc.CreateAttribute("strSupCNGBill");
            STRSUPLCNGBILL.Value = strSupCNGBill;
            XmlAttribute STRSUPGASBILL = doc.CreateAttribute("strSupplGasBill");
            STRSUPGASBILL.Value = strSupplGasBill;
            XmlAttribute STRPERSONMILAGEQNT = doc.CreateAttribute("strPersonalMilaqnt");
            STRPERSONMILAGEQNT.Value = strPersonalMilaqnt;
            XmlAttribute STRPERSONALRATE = doc.CreateAttribute("srPersonalRate");
            STRPERSONALRATE.Value = srPersonalRate;
            XmlAttribute STRPERSONAMlgTot = doc.CreateAttribute("strPersonMlgTotal");
            STRPERSONAMlgTot.Value = strPersonMlgTotal;
            XmlAttribute STRPAYMENTTYPE = doc.CreateAttribute("strPaymentType");
            STRPAYMENTTYPE.Value = strPaymentType;
            XmlAttribute STRFUELSUPPLNAME = doc.CreateAttribute("strFuelSupplierName");
            STRFUELSUPPLNAME.Value = strFuelSupplierName;







            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(STRBILLSubMitDate);
            node.Attributes.Append(STRNAME);
            node.Attributes.Append(STRSTART);
            node.Attributes.Append(STRENDTIME);

            node.Attributes.Append(STRMOVDURATION);
            node.Attributes.Append(FRMADDR);
            node.Attributes.Append(TOADDR);
            node.Attributes.Append(MOVADDR);
            node.Attributes.Append(STRNIGHTSTAY);
            node.Attributes.Append(STRSTARTMILAGE);

            node.Attributes.Append(STRENDMILAGE);
            node.Attributes.Append(STRCONSUMEDKM);
            node.Attributes.Append(STRREMARKS);
            node.Attributes.Append(STRQNTPETROL);
            node.Attributes.Append(STRCOSTPETROL);
            node.Attributes.Append(STRQNTOCTEN);


            node.Attributes.Append(STRCOSTOCTEN);
            node.Attributes.Append(STRQNTCARBONNIT);
            node.Attributes.Append(STRCOSTCARBONNIT);
            node.Attributes.Append(STRQNTLUBRICANT);
            node.Attributes.Append(STRCOSTLUBRICANT);
            node.Attributes.Append(STRBUSFARI);

            node.Attributes.Append(STRRICKFAIR);
            node.Attributes.Append(STRCNGFARE);
            node.Attributes.Append(STRTRAINFARE);




            node.Attributes.Append(STRAIRPLANCE);
            node.Attributes.Append(OTHVHF);
            node.Attributes.Append(STRMNT);


            node.Attributes.Append(STRFERRY);
            node.Attributes.Append(OWNDA);
            node.Attributes.Append(OTHEPDA);
            node.Attributes.Append(STROWNHOTEL);
            node.Attributes.Append(STRDRIVERHOTEL);
            node.Attributes.Append(STRPHOTOCOPY);
            node.Attributes.Append(STRCOURIER);
            node.Attributes.Append(OTHCOST);
            node.Attributes.Append(TOTALCOST);

            node.Attributes.Append(STRSUPLCNGBILL);
            node.Attributes.Append(STRSUPGASBILL);
            node.Attributes.Append(STRPERSONMILAGEQNT);
            node.Attributes.Append(STRPERSONALRATE);
            node.Attributes.Append(STRPERSONAMlgTot);
            node.Attributes.Append(STRPAYMENTTYPE);
            node.Attributes.Append(STRFUELSUPPLNAME);



            return node;


        }




        private void showDataForApprove()
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());

            DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            if (rptTypeid == 1)
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

                    string Unit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                    int unit = int.Parse(Unit);
                    dt = bll.getRptTADABikeAndCarUserDetaillsGB(dtFromDate, dtToDate, intTSOEnroll, unit, rptTypeid);
                }


                catch
                {

                }


                if (dt.Rows.Count > 0)
                {

                    grdvForApproveTADABikeCarUser.DataSource = dt;
                    grdvForApproveTADABikeCarUser.DataBind();

                }
                else
                {


                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                }
            }
        }













        private void calculateRowTotal(int RowIndex)
        {
            string strpetrolcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostPetrolT")).Text;
            if (strpetrolcost == "") { petrolcost = 0; }
            else
                petrolcost = decimal.Parse(strpetrolcost);
            if (petrolcost <= 0)
            {
                petrolcost = 0;
            }
            string stroctencost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostOctenT")).Text;
            if (stroctencost == "") { octencost = 0; }
            else

                octencost = decimal.Parse(stroctencost);
            if (octencost <= 0)
            {
                octencost = 0;
            }

            string strcngcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasT")).Text;
            if (strcngcost == "") { cngcost = 0; }
            else
                cngcost = decimal.Parse(strcngcost);
            if (cngcost <= 0)
            {
                cngcost = 0;
            }

            string strlubriantcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostLubricant")).Text;
            if (strlubriantcost == "") { lubriantcost = 0; }
            else
                lubriantcost = decimal.Parse(strlubriantcost);
            if (lubriantcost <= 0)
            {
                lubriantcost = 0;
            }

            string strbusfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareBusAmountT")).Text;
            if (strbusfare == "") { busfare = 0; }
            else

                busfare = decimal.Parse(strbusfare);
            if (busfare <= 0)
            {
                busfare = 0;
            }

            string strRickfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareRickshawAmountT")).Text;
            if (strRickfare == "") { Rickfare = 0; }
            else
                Rickfare = decimal.Parse(strRickfare);
            if (Rickfare <= 0)
            {
                Rickfare = 0;
            }

            string strcngfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareCNGAmountT")).Text;
            if (strcngfare == "") { cngfare = 0; }
            else
                cngfare = decimal.Parse(strcngfare);
            if (cngfare <= 0)
            {
                cngfare = 0;
            }
            string strtrainfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareTrainAmountT")).Text;
            if (strtrainfare == "") { trainfare = 0; }
            else

                trainfare = decimal.Parse(strtrainfare);
            if (trainfare <= 0)
            {
                trainfare = 0;
            }
            string strairplance = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareAirPlaneT")).Text;
            if (strairplance == "") { airplance = 0; }
            else

                airplance = decimal.Parse(strairplance);
            if (airplance <= 0)
            {
                airplance = 0;
            }

            string strothervhfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountT")).Text;
            if (strothervhfare == "") { othervhfare = 0; }
            else

                othervhfare = decimal.Parse(strothervhfare);
            if (othervhfare <= 0)
            {
                othervhfare = 0;
            }

            string strmntcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceT")).Text;
            if (strmntcost == "") { mntcost = 0; }
            else
                mntcost = decimal.Parse(strmntcost);
            if (mntcost <= 0)
            {
                mntcost = 0;
            }
            string strferrytol = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFeryTollCostT")).Text;
            if (strferrytol == "") { ferrytol = 0; }
            else

                ferrytol = decimal.Parse(strferrytol);
            if (ferrytol <= 0)
            {
                ferrytol = 0;
            }

            string strownda = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDAAmountT")).Text;
            if (strownda == "") { ownda = 0; }
            else
                ownda = decimal.Parse(strownda);
            if (ownda <= 0)
            {
                ownda = 0;
            }

            string strdriverda = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverDACostT")).Text;
            if (strdriverda == "") { driverda = 0; }
            else

                driverda = decimal.Parse(strdriverda);
            if (driverda <= 0)
            {
                driverda = 0;
            }
            string strownhotel = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecHotelBillAmountT")).Text;
            if (strownhotel == "") { ownhotel = 0; }
            else

                ownhotel = decimal.Parse(strownhotel);
            if (ownhotel <= 0)
            {
                ownhotel = 0;
            }

            string strdriverhotel = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountT")).Text;
            if (strdriverhotel == "") { driverhotel = 0; }
            else



                driverhotel = decimal.Parse(strdriverhotel);
            if (driverhotel <= 0)
            {
                driverhotel = 0;
            }

            string strphotocopy = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecPhotoCopyCostT")).Text;
            if (strphotocopy == "") { photocopy = 0; }
            else

                photocopy = decimal.Parse(strphotocopy);
            if (photocopy <= 0)
            {
                photocopy = 0;
            }



            string strc = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCourierCostT")).Text;
            if (strc == "") { courier = 0; }
            else
            {
                courier = decimal.Parse(strc);
                if (courier <= 0)
                { courier = 0; }
            }
            string strOthBill = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecOtherBillAmountT")).Text;
            if
                (strOthBill == "") { othercost = 0; }

            else

                othercost = decimal.Parse(strOthBill);
            if (othercost <= 0)
            {
                othercost = 0;
            }

            string strtotalcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text;
            if (strtotalcost == "") { totalcost = 0; }
            else



                totalcost = decimal.Parse(strtotalcost);
            if (totalcost <= 0)
            {
                totalcost = 0;
            }

            ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text =

          (petrolcost + octencost + cngcost + lubriantcost + busfare + Rickfare + cngfare + trainfare + airplance + othervhfare + mntcost
          + ferrytol + ownda + driverda + ownhotel + driverhotel + photocopy + courier + othercost).ToString();


        }

        private void CalculateGrandTotal()
        {
            petrolcost = 0; octencost = 0; cngcost = 0; lubriantcost = 0;
            busfare = 0; Rickfare = 0; cngfare = 0; trainfare = 0; airplance = 0; othervhfare = 0;
            mntcost = 0; ferrytol = 0;

            ownda = 0; driverda = 0; ownhotel = 0; driverhotel = 0;
            photocopy = 0; courier = 0; othercost = 0; totalcost = 0;


            int cnt = grdvForApproveTADABikeCarUser.Rows.Count;
            for (int RowIndex = 0; RowIndex < cnt - 1; RowIndex++)
            {

                string strpetrolcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostPetrolT")).Text;
                if (strpetrolcost == "") { petrolcost = 0; }
                else
                    petrolcost = petrolcost + decimal.Parse(strpetrolcost);

                string stroctencost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostOctenT")).Text;
                if (stroctencost == "") { octencost = 0; }
                else
                    octencost = octencost + decimal.Parse(stroctencost);

                string strcngcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasT")).Text;
                if (strcngcost == "") { cngcost = 0; }
                else
                    cngcost = cngcost + decimal.Parse(strcngcost);

                string strlubriantcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostLubricant")).Text;
                if (strlubriantcost == "") { lubriantcost = 0; }
                else
                    lubriantcost = lubriantcost + decimal.Parse(strlubriantcost);

                string strbusfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareBusAmountT")).Text;
                if (strbusfare == "") { busfare = 0; }
                else
                    busfare = busfare + decimal.Parse(strbusfare);

                string strRickfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareRickshawAmountT")).Text;
                if (strRickfare == "") { Rickfare = 0; }
                Rickfare = Rickfare + decimal.Parse(strRickfare);

                string strcngfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareCNGAmountT")).Text;
                if (strcngfare == "") { cngfare = 0; }
                else
                    cngfare = cngfare + decimal.Parse(strcngfare);

                string strtrainfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareTrainAmountT")).Text;
                if (strtrainfare == "") { trainfare = 0; }
                else
                    trainfare = trainfare + decimal.Parse(strtrainfare);



                string strairplance = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareAirPlaneT")).Text;
                if (strairplance == "") { airplance = 0; }
                else
                    airplance = airplance + decimal.Parse(strairplance);

                string strothervhfare = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountT")).Text;
                if (strothervhfare == "") { othervhfare = 0; }
                else
                    othervhfare = othervhfare + decimal.Parse(strothervhfare);


                string strmntcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceT")).Text;
                if (strmntcost == "") { mntcost = 0; }
                else
                    mntcost = mntcost + decimal.Parse(strmntcost);

                string strferrytol = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFeryTollCostT")).Text;
                if (strferrytol == "") { ferrytol = 0; }
                else

                    ferrytol = ferrytol + decimal.Parse(strferrytol);

                string strownda = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDAAmountT")).Text;
                if (strownda == "") { ownda = 0; }
                else
                    ownda = ownda + decimal.Parse(strownda);

                string strdriverda = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverDACostT")).Text;
                if (strdriverda == "") { driverda = 0; }
                else
                    driverda = driverda + decimal.Parse(strdriverda);

                string strownhotel = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecHotelBillAmountT")).Text;
                if (strownhotel == "") { ownhotel = 0; }
                else

                    ownhotel = ownhotel + decimal.Parse(strownhotel);

                string strdriverhotel = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountT")).Text;
                if (strdriverhotel == "") { driverhotel = 0; }
                else
                    driverhotel = driverhotel + decimal.Parse(strdriverhotel);

                string strphotocopy = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecPhotoCopyCostT")).Text;
                if (strphotocopy == "") { photocopy = 0; }
                else
                    photocopy = photocopy + decimal.Parse(strphotocopy);

                string strcourier = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCourierCostT")).Text;
                if (strcourier == "") { courier = 0; }

                courier = courier + decimal.Parse(strcourier);

                string strothercost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecOtherBillAmountT")).Text;
                if (strothercost == "") { othercost = 0; }
                else
                    othercost = othercost + decimal.Parse(strothercost);

                string strtotalcost = ((TextBox)grdvForApproveTADABikeCarUser.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text;
                if (strtotalcost == "") { totalcost = 0; }
                else
                    totalcost = totalcost + decimal.Parse(strtotalcost);
            }
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostPetrolT")).Text = petrolcost.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostOctenT")).Text = octencost.ToString();

            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostCarbonNitGasT")).Text = cngcost.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostLubricant")).Text = lubriantcost.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareBusAmountT")).Text = busfare.ToString();

            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareRickshawAmountT")).Text = Rickfare.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareCNGAmountT")).Text = cngfare.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareTrainAmountT")).Text = trainfare.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareAirPlaneT")).Text = airplance.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareOtherVheicleAmountT")).Text = othervhfare.ToString();

            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostAmountMaintenaceT")).Text = mntcost.ToString();


            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFeryTollCostT")).Text = ferrytol.ToString();

            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecDAAmountT")).Text = ownda.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecDriverDACostT")).Text = driverda.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecHotelBillAmountT")).Text = ownhotel.ToString();

            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecDriverHotelBillAmountT")).Text = driverhotel.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecPhotoCopyCostT")).Text = photocopy.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCourierCostT")).Text = courier.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecOtherBillAmountT")).Text = othercost.ToString();
            ((TextBox)grdvForApproveTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecRowTotalT")).Text = totalcost.ToString();



        }


        protected void decRowtotal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecCostPetrolT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecCostOctenT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecCostCarbonNitGasT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFareBusAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFareRickshawAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFareCNGAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFareTrainAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFareAirPlaneT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFareOtherVheicleAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecCostAmountMaintenaceT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecFeryTollCostT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecDAAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecDriverDACostT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecHotelBillAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecDriverHotelBillAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecPhotoCopyCostT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecCourierCostT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecOtherBillAmountT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecRowTotalT_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecCostLubricant_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecSupplierCNG_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecSupplierGas_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecPersonalMilage_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecMlgRate_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtdecPersonalTotalcost_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtPaymentType_TextChanged(object sender, EventArgs e)
        {
            //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            //calculateRowTotal(RowIndex);
            //CalculateGrandTotal();
        }

        protected void txtstrFuelStationaname_TextChanged(object sender, EventArgs e)
        {

        }

    }





}