using Flogging.Core;
using GLOBAL_BLL;
using HR_BLL.TourPlan;
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
    public partial class RemoteTADAAprvByHR : BasePage
    {
        char[] delimiterChars = { '[', ']' }; 
        int RowIndex; decimal busfare = 0; decimal Rickfare = 0; decimal cngfare = 0; decimal trainfare = 0; decimal boatfare = 0; decimal othervhfare = 0;
        decimal ownda = 0; decimal otherda = 0; decimal hotel = 0; decimal othercost = 0; decimal rowTotal = 0; decimal movDuration = 0;
        string filePathForXML;
        //Bike Car User HR Lebel Approve
        decimal petrolcostBikeCar = 0; decimal octencostBikeCar = 0; decimal cngcostBikeCar = 0; decimal lubriantcostBikeCar = 0; decimal busfareBikeCar = 0; decimal RickfareBikeCar = 0; decimal cngfareBikeCar = 0; decimal trainfareBikeCar = 0; decimal airplanceBikeCar = 0; decimal othervhfareBikeCar = 0;
        decimal mntcostBikeCar = 0; decimal ferrytolBikeCar = 0; decimal owndaBikeCar = 0; decimal driverdaBikeCar = 0; decimal ownhotelBikeCar = 0; decimal driverhotelBikeCar = 0; decimal photocopyBikeCar = 0; decimal courierBikeCar = 0; decimal othercostBikeCar = 0;
        decimal totalcostBikeCar = 0; decimal boatbikecare = 0;
        string filePathForXMLHRBIKECAR;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        DataTable dt = new DataTable();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADAAprvByHR";
        string stop = "stopping SAD\\Order\\RemoteTADAAprvByHR";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            HiddenUnit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

            filePathForXML = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaApproveNoneBikeHR.xml");
            filePathForXMLHRBIKECAR = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaApproveBikeCarHR.xml");


            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                ////---------xml----------
                try
                {
                    File.Delete(filePathForXML);
                    File.Delete(filePathForXMLHRBIKECAR);

                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch { }
                ////-----**----------//
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            showNoneBikeHRLebTopsheet();
        }

        private void showNoneBikeHRLebTopsheet()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAAprvByHR TaDa approve Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
            int userTypeid = int.Parse(ddlUserType.SelectedValue.ToString());
            int Areaid = int.Parse(drdlArea.SelectedValue.ToString());
            
            DataTable dt = new DataTable();

            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
           int unit = int.Parse(drdlUnit.SelectedValue.ToString());
          
            if (rptTypeid == 2 && userTypeid >1)
            {
                try
                {

                    dt = bll.getTADARptNoneBikeHRLeb(dtFromDate, dtToDate, Areaid, unit, rptTypeid, userTypeid);


                }
                catch
                {

                }
                if (dt.Rows.Count > 0)
                {
                    GridviewTADADetaillHrlEBL.DataSource = null;
                    GridviewTADADetaillHrlEBL.DataBind();
                    grdVTopSheetBikeCarHRLebel.DataSource = null;
                    grdVTopSheetBikeCarHRLebel.DataBind();
                    grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                    grdvBikeCarUserDetaillsHRLabel.DataBind();
                    grdvTADAHRUnitTopsheetPrint.DataSource = null;
                    grdvTADAHRUnitTopsheetPrint.DataBind();
                    grdvBillMonitoringStatusHREND.DataSource = null;
                    grdvBillMonitoringStatusHREND.DataBind();
                    grdvTopShNoneBike.DataSource = dt;
                    grdvTopShNoneBike.DataBind();

                }
                else
                {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                }

           }
            else if (rptTypeid == 1 && userTypeid> 1)
            {
                try
                {
                    dt = bll.getTADARptNoneBikeHRLeb(dtFromDate, dtToDate, Areaid, unit, rptTypeid, userTypeid);

                }
                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    grdvTopShNoneBike.DataSource = null;
                    grdvTopShNoneBike.DataBind();
                    grdVTopSheetBikeCarHRLebel.DataSource = null;
                    grdVTopSheetBikeCarHRLebel.DataBind();
                    grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                    grdvBikeCarUserDetaillsHRLabel.DataBind();
                    grdvTADAHRUnitTopsheetPrint.DataSource = null;
                    grdvTADAHRUnitTopsheetPrint.DataBind();
                    grdvBillMonitoringStatusHREND.DataSource = null;
                    grdvBillMonitoringStatusHREND.DataBind();
                    GridviewTADADetaillHrlEBL.DataSource = dt;
                    GridviewTADADetaillHrlEBL.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true); }
            }
            else if (rptTypeid == 2 && userTypeid == 1)
            {
                try { dt = bll.getRptTADABikeCarHRLeb(dtFromDate, dtToDate, Areaid, unit, rptTypeid, userTypeid); }
                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvTopShNoneBike.DataSource = null;
                    grdvTopShNoneBike.DataBind();
                    GridviewTADADetaillHrlEBL.DataSource = null;
                    GridviewTADADetaillHrlEBL.DataBind();
                    grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                    grdvBikeCarUserDetaillsHRLabel.DataBind();
                    grdvTADAHRUnitTopsheetPrint.DataSource = null;
                    grdvTADAHRUnitTopsheetPrint.DataBind();
                    grdvBillMonitoringStatusHREND.DataSource = null;
                    grdvBillMonitoringStatusHREND.DataBind();
                    grdVTopSheetBikeCarHRLebel.DataSource = dt;
                    grdVTopSheetBikeCarHRLebel.DataBind();
                }

                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true); }
            }

            else if (rptTypeid == 1 && userTypeid == 1)
            {
                try { dt = bll.getRptTADABikeCarHRLeb(dtFromDate, dtToDate, Areaid, unit, rptTypeid, userTypeid); }
                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvTopShNoneBike.DataSource = null;
                    grdvTopShNoneBike.DataBind();
                    GridviewTADADetaillHrlEBL.DataSource = null;
                    GridviewTADADetaillHrlEBL.DataBind();
                    grdVTopSheetBikeCarHRLebel.DataSource = null;
                    grdVTopSheetBikeCarHRLebel.DataBind();
                    grdvTADAHRUnitTopsheetPrint.DataSource = null;
                    grdvTADAHRUnitTopsheetPrint.DataBind();
                    grdvBillMonitoringStatusHREND.DataSource = null;
                    grdvBillMonitoringStatusHREND.DataBind();
                    grdvBikeCarUserDetaillsHRLabel.DataSource = dt;
                    grdvBikeCarUserDetaillsHRLabel.DataBind();
                }

                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true); }

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
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAAprvByHR TaDa approve HR", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
            int intBillApplicantTypeid = int.Parse(ddlUserType.SelectedValue.ToString());
          
                if (rptTypeid == 1 && intBillApplicantTypeid > 1)
                {

                    if (GridviewTADADetaillHrlEBL.Rows.Count > 0)
                    {
                        if (hdnconfirm.Value == "1")
                        {


                        for (int rowIndex = 0; rowIndex < GridviewTADADetaillHrlEBL.Rows.Count - 1; rowIndex++)
                        {
                            TextBox TextBoxDate = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[0].FindControl("dteFromdateNoBikeDet");
                            TextBox TextBoxBillPName = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[1].FindControl("strNamNoBikeDet");
                            TextBox TextBoxDeisgnation = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[2].FindControl("strDesgNoBikeDet");
                            TextBox TextBoxFromAdres = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[3].FindControl("strFromaddrNoBikeDet");
                            TextBox TextBoxToAdress = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[4].FindControl("strToadrNoBikeDet");
                            TextBox TextBoxMovementAreaAdress = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[5].FindControl("strMovemetspotNonebikeuser");
                            TextBox TextBoxMoveDuration = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[6].FindControl("txtdecmovdur");
                            TextBox TextBoxBusFare = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[7].FindControl("txtfareNoBikeDet");
                            TextBox TextBoxRickFare = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[8].FindControl("txtdecrick");
                            TextBox TextBoxCNGFare = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[9].FindControl("txtcng");
                            TextBox TextBoxTrainFare = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[10].FindControl("txttrain");
                            TextBox TextBoxBoatFare = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[11].FindControl("txtboat");
                            TextBox TextBoxOtherVhFare = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[12].FindControl("txtothevh");
                            TextBox TextBoxRemarks = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[13].FindControl("txtstrsuppor");
                            TextBox TextBoxOwnDA = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[14].FindControl("txtdecownda");
                            TextBox TextBoxOtherDA = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[15].FindControl("txtdecOtherda");
                            TextBox TextBoxHotel = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[16].FindControl("txtdechotel");
                            TextBox TextBoxOtherCost = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[17].FindControl("txthddecOtherCostAmount");
                            TextBox TextBoxRowTotal = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[18].FindControl("txtdecrowtotal");
                            TextBox TextBoxContactPerson = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[19].FindControl("txtstrContac");
                            TextBox TextBoxPhone = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[20].FindControl("txtstrphone");
                            TextBox TextVisitedorg = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[21].FindControl("txtstrVisitorg");
                            TextBox TextBoxUnit = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[22].FindControl("txtUnitid");
                            TextBox TextJobstation = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[23].FindControl("txtJobstation");
                            TextBox TextAreaId = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[24].FindControl("txtAreaID");
                            TextBox txtApplicantEnrol = (TextBox)GridviewTADADetaillHrlEBL.Rows[rowIndex].Cells[25].FindControl("txtEnrol");
                            if (TextBoxDate.Text == string.Empty || (TextBoxDate.Text) == "") { TextBoxDate.Text = "NA"; }
                            if (TextBoxBillPName.Text == string.Empty || (TextBoxBillPName.Text) == "") { TextBoxBillPName.Text = "No Applicant"; }
                            if (TextBoxDeisgnation.Text == string.Empty || (TextBoxDeisgnation.Text) == "") { TextBoxDeisgnation.Text = "No Designation"; }
                            if (TextBoxFromAdres.Text == string.Empty || (TextBoxFromAdres.Text) == "") { TextBoxFromAdres.Text = "NA"; }
                            if (TextBoxToAdress.Text == string.Empty || (TextBoxToAdress.Text) == "") { TextBoxToAdress.Text = "No Applicant"; }
                            if (TextBoxMovementAreaAdress.Text == string.Empty || (TextBoxMovementAreaAdress.Text) == "") { TextBoxMovementAreaAdress.Text = "NA"; }
                            if (TextBoxMoveDuration.Text == string.Empty || (TextBoxMoveDuration.Text) == "") { TextBoxMoveDuration.Text = "0"; }
                            if (TextBoxBusFare.Text == string.Empty || (TextBoxBusFare.Text) == "") { TextBoxBusFare.Text = "0"; }
                            if (TextBoxRickFare.Text == string.Empty || (TextBoxRickFare.Text) == "") { TextBoxRickFare.Text = "0"; }
                            if (TextBoxCNGFare.Text == string.Empty || (TextBoxCNGFare.Text) == "") { TextBoxCNGFare.Text = "NA"; }
                            if (TextBoxTrainFare.Text == string.Empty || (TextBoxTrainFare.Text) == "") { TextBoxTrainFare.Text = "0"; }
                            if (TextBoxBoatFare.Text == string.Empty || (TextBoxBoatFare.Text) == "") { TextBoxBoatFare.Text = "0"; }
                            if (TextBoxOtherVhFare.Text == string.Empty || (TextBoxOtherVhFare.Text) == "") { TextBoxOtherVhFare.Text = "0"; }
                            if (TextBoxRemarks.Text == string.Empty || (TextBoxRemarks.Text) == "") { TextBoxRemarks.Text = "No supporting"; }
                            if (TextBoxOwnDA.Text == string.Empty || (TextBoxOwnDA.Text) == "") { TextBoxOwnDA.Text = "0"; }
                            if (TextBoxOtherDA.Text == string.Empty || (TextBoxOtherDA.Text) == "") { TextBoxOtherDA.Text = "0"; }
                            if (TextBoxHotel.Text == string.Empty || (TextBoxHotel.Text) == "") { TextBoxHotel.Text = "0"; }
                            if (TextBoxOtherCost.Text == string.Empty || (TextBoxOtherCost.Text) == "") { TextBoxOtherCost.Text = "0"; }
                            if (TextBoxRowTotal.Text == string.Empty || (TextBoxRowTotal.Text) == "") { TextBoxRowTotal.Text = "0"; }
                            if (TextBoxContactPerson.Text == string.Empty || (TextBoxContactPerson.Text) == "") { TextBoxContactPerson.Text = "No Applicant"; }
                            if (TextBoxPhone.Text == string.Empty || (TextBoxPhone.Text) == "") { TextBoxPhone.Text = "0"; }
                            if (TextVisitedorg.Text == string.Empty || (TextVisitedorg.Text) == "") { TextVisitedorg.Text = "No vistorg"; }

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
                            string strunit = TextBoxUnit.Text;
                            string strjobstation = TextJobstation.Text;
                            string strAreaid = TextAreaId.Text;
                            string strEnrol = txtApplicantEnrol.Text;
                            if (strBusFareTaka.All(c => char.IsNumber(c)) && strRickFare.All(c => char.IsNumber(c)) && strCNGFare.All(c => char.IsNumber(c)) && strTrainFare.All(c => char.IsNumber(c)) && strBoatFare.All(c => char.IsNumber(c)) && strOtherVhFare.All(c => char.IsNumber(c)) && strOwnDA.All(c => char.IsNumber(c)) && strOtherDA.All(c => char.IsNumber(c)) && strHotel.All(c => char.IsNumber(c)) && strOtherCost.All(c => char.IsNumber(c)) && strRowTotal.All(c => char.IsNumber(c)))
                            { CreateSalesXml(strBillDate, strBillPerson, strBillPersonDesignation, strFromAdress, strToAddress, strMoveArea, strMovDuration, strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare, strOtherVhFare, strRemarks, strOwnDA, strOtherDA, strHotel, strOtherCost, strRowTotal, strContactPerson, strPhone, strVisitedorg, strunit, strjobstation, strAreaid, strEnrol); }
                        }
                        #region ------------ Insert into dataBase -----------


                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                        hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();

                        Int32 Approverenroll = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                        int intApplcTypeid = int.Parse(ddlUserType.SelectedValue.ToString());
                        //int intApplcTypeid = Convert.ToInt32("2");

                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("RemotetadaApproveNoneBikeHR");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<RemotetadaApproveNoneBikeHR>" + xmlString + "</RemotetadaApproveNoneBikeHR>";

                        string message = bll.tadaInsertByHRTESTING(xmlString, Approverenroll, dteFromDate, dteTodate, intApplcTypeid);
                        File.Delete(filePathForXML);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                        #endregion ------------ Insertion End ----------------
                    }
                    GridviewTADADetaillHrlEBL.DataSource = "";
                    GridviewTADADetaillHrlEBL.DataBind();
                    //File.Delete(filePathForXML);
                }
            }
                else if (rptTypeid == 1 && intBillApplicantTypeid == 1)
                {



                    if (grdvBikeCarUserDetaillsHRLabel.Rows.Count > 0)
                    {
                        if (hdnconfirm.Value == "1")
                        {
                            for (int rowIndex = 0; rowIndex < grdvBikeCarUserDetaillsHRLabel.Rows.Count - 1; rowIndex++)
                            {
                                TextBox txtdteFromdateNoBikeDet = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[1].FindControl("dteFromdateNoBikeDet");
                                TextBox TextdteInsdateNoBikeDet = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[2].FindControl("dteInsdateNoBikeDet");
                                TextBox txtstrNamNoBikeDet = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[3].FindControl("strNamNoBikeDet");
                                TextBox txtStarTime = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[5].FindControl("txtStarTime");
                                TextBox txtdecEndHourT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[6].FindControl("txtdecEndHourT");
                                TextBox txtdecmovdur = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[7].FindControl("txtdecmovdur");
                                TextBox txtstrFromAddressT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[8].FindControl("txtstrFromAddressT");
                                TextBox txtstrMovementAreaT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[9].FindControl("txtstrMovementAreaT");
                                TextBox txtstrToAddressT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[10].FindControl("txtstrToAddressT");
                                TextBox txtstrNightStayT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[11].FindControl("txtstrNightStayT");
                                TextBox txtdecStartMilageT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[12].FindControl("txtdecStartMilageT");
                                TextBox txtdecEndMilageT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[13].FindControl("txtdecEndMilageT");
                                TextBox txtdecConsumedKmT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[14].FindControl("txtdecConsumedKmTBikeCar");
                                TextBox txtstrSupportingNoT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[15].FindControl("txtstrSupportingNoTBikeCar");
                                TextBox txtdecQntPetrolT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[16].FindControl("txtdecQntPetrolTBikeCar");
                                TextBox txtdecCostPetrolT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[17].FindControl("txtdecCostPetrolTBikeCar");
                                TextBox txtdecQntOctenT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[18].FindControl("txtdecQntOctenTBikeCar");
                                TextBox txtdecCostOctenT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[19].FindControl("txtdecCostOctenTBikeCar");
                                TextBox txtdecQntCarbonNitGasT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[20].FindControl("txtdecQntCarbonNitGasTBikeCar");
                                TextBox txtdecCostCarbonNitGasT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[21].FindControl("txtdecCostCarbonNitGasTBikeCar");
                                TextBox txtdecQntLubricant = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[22].FindControl("txtdecQntLubricantBikeCar");
                                TextBox txtdecCostLubricant = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[23].FindControl("txtdecCostLubricantBikeCar");
                                TextBox txtdecFareBusAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[24].FindControl("txtdecFareBusAmountTBikeCar");
                                TextBox txtdecFareRickshawAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[25].FindControl("txtdecFareRickshawAmountTBikeCar");
                                TextBox txtdecFareCNGAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[26].FindControl("txtdecFareCNGAmountTBikeCar");
                                TextBox txtdecFareTrainAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[27].FindControl("txtdecFareTrainAmountTBikeCar");
                                TextBox txtdecFareBoat = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[27].FindControl("txtdecFareBoatAmountT");
                                TextBox txtdecFareAirPlaneT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[28].FindControl("txtdecFareAirPlaneTBikeCar");
                                TextBox txtdecFareOtherVheicleAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[29].FindControl("txtdecFareOtherVheicleAmountTBikeCar");
                                TextBox txtdecCostAmountMaintenaceT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[30].FindControl("txtdecCostAmountMaintenaceTBikeCar");
                                TextBox txtdecFeryTollCostT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[31].FindControl("txtdecFeryTollCostTBikeCar");
                                TextBox txtdecDAAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[32].FindControl("txtdecDAAmountTBikeCar");
                                TextBox txtdecDriverDACostT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[33].FindControl("txtdecDriverDACostTBikeCar");
                                TextBox txtdecHotelBillAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[34].FindControl("txtdecHotelBillAmountTBikeCar");
                                TextBox txtdecDriverHotelBillAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[35].FindControl("txtdecDriverHotelBillAmountTBikeCar");
                                TextBox txtdecPhotoCopyCostT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[36].FindControl("txtdecPhotoCopyCostTBikeCar");
                                TextBox txtdecCourierCostT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[37].FindControl("txtdecCourierCostTBikeCar");
                                TextBox txtdecOtherBillAmountT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[38].FindControl("txtdecOtherBillAmountTBikeCar");
                                TextBox txtdecRowTotalT = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[39].FindControl("txtdecRowTotalTBikeCar");

                                TextBox txtdecSupplierCNG = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[40].FindControl("txtdecSupplierCNG");
                                TextBox txtdecSupplierGas = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[41].FindControl("txtdecSupplierGas");
                                TextBox txtdecPersonalMilage = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[42].FindControl("txtdecPersonalMilage");
                                TextBox txtdecMlgRate = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[43].FindControl("txtdecMlgRate");
                                TextBox txtdecPersonalTotalcost = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[44].FindControl("txtdecPersonalTotalcost");
                                TextBox txtPaymentType = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[45].FindControl("txtPaymentType");
                                TextBox txtstrFuelStationaname = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[46].FindControl("txtstrFuelStationaname");
                                TextBox txtintUnit = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[48].FindControl("txtUnitBikeCar");
                                TextBox txtintJobstation = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[49].FindControl("txtJobstatBikeCar");
                                TextBox txtintAreaID = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[50].FindControl("txtAreaID");
                                TextBox txtApplicantEnrol = (TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[rowIndex].Cells[47].FindControl("txtAplEnrolBikeCar");

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
                                string strBoatFare = txtdecFareBoat.Text;
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

                                string strunit = txtintUnit.Text;
                                string strjobstation = txtintJobstation.Text;
                                string strAreaid = txtintAreaID.Text;
                                string strApplicantEnrolid = txtApplicantEnrol.Text;

                                CreateSalesXmlHRBIKECAR(strBillDate, strBilSubmitteddate, strName, strstart, strEndTime, strMovDuration, strFromAdress
                                    , strMoveArea, strToAddress, strNighstay, strStartMilage, strEndMilage, strConsumedKM, strRemarks, strQntPetrol
                                    , strCostPetrol, strQntOcten, strCostOcten, strQntCarBonNitr, strCostCarbonNit, strQntLubricant, strCostLubricant
                                    , strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare
                                    , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                                    , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal
                                   , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName
                                   , strunit, strjobstation, strAreaid, strApplicantEnrolid);


                            }
                            #region ------------ Insert into dataBase -----------


                            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                            hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                            HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                            Int32 Approverenroll = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                            int Jobstation = Convert.ToInt32(hdnstation.Value);
                            int unit = Convert.ToInt32(HiddenUnit.Value);
                            int intApplicantCatge = 1;
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLHRBIKECAR);
                            XmlNode dSftTm = doc.SelectSingleNode("RemotetadaApproveBikeCarHR");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<RemotetadaApproveBikeCarHR>" + xmlString + "</RemotetadaApproveBikeCarHR>";
                            string message = bll.tadaInsertByHRBikeCarUser(xmlString, Approverenroll, dteFromDate, dteTodate, intApplicantCatge);
                            File.Delete(filePathForXMLHRBIKECAR);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            #endregion ------------ Insertion End ----------------

                        }
                        grdvBikeCarUserDetaillsHRLabel.DataSource = "";
                        grdvBikeCarUserDetaillsHRLabel.DataBind();
                        //File.Delete(filePathForXMLHRBIKECAR);
                    }

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
        

        protected void grdvTopShNoneBike_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridviewTADADetaillHrlEBL_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        private void Calcutale(int RowIndex)
        {
            busfare = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtfareNoBikeDet")).Text);
            Rickfare = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtdecrick")).Text);
            cngfare = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtcng")).Text);
            trainfare = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txttrain")).Text);
            boatfare = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtboat")).Text);
            othervhfare = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtothevh")).Text);
            ownda = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtdecownda")).Text);
            otherda = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtdecOtherda")).Text);
            hotel = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtdechotel")).Text);
            othercost = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txthddecOtherCostAmount")).Text);
           ((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtdecrowtotal")).Text = (busfare + Rickfare + cngfare + trainfare + boatfare + othervhfare + ownda + otherda + hotel + othercost).ToString();
       }

        private void CalculateGrandTotal()
        {
            //---------------- Calculate Grand Total  Column ----------------------
            //busfare Rickfare   cngfare   trainfare   boatfare   othervhfare ownda   otherda   hotel   othercost 

            busfare = 0; Rickfare = 0; cngfare = 0; trainfare = 0; boatfare = 0; othervhfare = 0; ownda = 0; otherda = 0; hotel = 0; othercost = 0; int cnt = GridviewTADADetaillHrlEBL.Rows.Count;
            for (int r = 0; r < cnt - 1; r++)
            {
                busfare = busfare + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtfareNoBikeDet")).Text);
                Rickfare = Rickfare + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtdecrick")).Text);
                cngfare = cngfare + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtcng")).Text);
                trainfare = trainfare + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txttrain")).Text);

                boatfare = boatfare + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtboat")).Text);
                othervhfare = othervhfare + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtothevh")).Text);
                ownda = ownda + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtdecownda")).Text);
                otherda = otherda + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtdecOtherda")).Text);


                hotel = hotel + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtdechotel")).Text);
                othercost = othercost + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txthddecOtherCostAmount")).Text);

                //movDuration = decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[RowIndex].FindControl("txtdecmovdur")).Text);

                rowTotal = rowTotal + decimal.Parse(((TextBox)GridviewTADADetaillHrlEBL.Rows[r].FindControl("txtdecrowtotal")).Text);

            }
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtfareNoBikeDet")).Text = busfare.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtdecrick")).Text = Rickfare.ToString();

            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtcng")).Text = cngfare.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txttrain")).Text = trainfare.ToString();

            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtboat")).Text = boatfare.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtothevh")).Text = othervhfare.ToString();

            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtdecownda")).Text = ownda.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtdecOtherda")).Text = otherda.ToString();

            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtdechotel")).Text = hotel.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txthddecOtherCostAmount")).Text = othercost.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtdecmovdur")).Text = movDuration.ToString();
            ((TextBox)GridviewTADADetaillHrlEBL.Rows[cnt - 1].FindControl("txtdecrowtotal")).Text = rowTotal.ToString();

     }



        protected void txtfareNoBikeDet_TextChanged(object sender, EventArgs e)
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

        protected void txtcng_TextChanged(object sender, EventArgs e)
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

        protected void txtboat_TextChanged(object sender, EventArgs e)
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

        protected void txtdecownda_TextChanged(object sender, EventArgs e)
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

        protected void txtdechotel_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            Calcutale(RowIndex);
            CalculateGrandTotal();
        }

        protected void txthddecOtherCostAmount_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            Calcutale(RowIndex);
            CalculateGrandTotal();
        }


        private void CreateSalesXml(string strBillDate, string strBillPerson, string strBillPersonDesignation, string strFromAdress, string strToAddress, string strMoveArea, string strMovDuration, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strBoatFare, string strOtherVhFare, string strRemarks, string strOwnDA, string strOtherDA, string strHotel, string strOtherCost, string strRowTotal, string strContactPerson, string strPhone, string strVisitedorg, string strunit, string strjobstation, string strAreaid, string enrol)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemotetadaApproveNoneBikeHR");
                XmlNode addItem = CreateItemNode(doc, strBillDate, strBillPerson, strBillPersonDesignation, strFromAdress, strToAddress, strMoveArea, strMovDuration, strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare, strOtherVhFare, strRemarks, strOwnDA, strOtherDA, strHotel, strOtherCost, strRowTotal, strContactPerson, strPhone, strVisitedorg, strunit, strjobstation, strAreaid, enrol);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaApproveNoneBikeHR");
                XmlNode addItem = CreateItemNode(doc, strBillDate, strBillPerson, strBillPersonDesignation, strFromAdress, strToAddress, strMoveArea, strMovDuration, strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare, strOtherVhFare, strRemarks, strOwnDA, strOtherDA, strHotel, strOtherCost, strRowTotal, strContactPerson, strPhone, strVisitedorg, strunit, strjobstation, strAreaid, enrol);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }


        private XmlNode CreateItemNode(XmlDocument doc, string strBillDate, string strBillPerson, string strBillPersonDesignation, string strFromAdress, string strToAddress
           , string strMoveArea, string strMovDuration, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare
           , string strBoatFare, string strOtherVhFare, string strRemarks, string strOwnDA, string strOtherDA, string strHotel, string strOtherCost, string strRowTotal, string strContactPerson, string strPhone, string strVisitedorg, string strunit, string strjobstation, string strAreaid, string enrol)
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
            XmlAttribute STRUNIT = doc.CreateAttribute("strunit");
            STRUNIT.Value = strunit;
            XmlAttribute STRJOBSTATION = doc.CreateAttribute("strjobstation");
            STRJOBSTATION.Value = strjobstation;
            XmlAttribute STRAREAID = doc.CreateAttribute("strAreaid");
            STRAREAID.Value = strAreaid;
            XmlAttribute STRENROL = doc.CreateAttribute("enrol");
            STRENROL.Value = enrol;


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
            node.Attributes.Append(STRUNIT);
            node.Attributes.Append(STRJOBSTATION);
            node.Attributes.Append(STRAREAID);
            node.Attributes.Append(STRENROL);
            return node;



        }

        protected void txtdecOtherBillAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                calculateRowTotalBikeCar(RowIndex);
                calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecCourierCostTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecPhotoCopyCostTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecDriverHotelBillAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecHotelBillAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecDriverDACostTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecDAAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFeryTollCostTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecCostAmountMaintenaceTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFareOtherVheicleAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFareAirPlaneTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFareBoatAmountT_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }



        protected void txtdecFareTrainAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFareCNGAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFareRickshawAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecFareBusAmountTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecCostLubricantBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecCostCarbonNitGasTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecCostOctenTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }

        protected void txtdecCostPetrolTBikeCar_TextChanged(object sender, EventArgs e)
        {
            try { 
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotalBikeCar(RowIndex);
            calculateGrnadTotalBikeCar();
            }
            catch { }
        }


        private void calculateRowTotalBikeCar(int RowIndex)
        {
            string strpetrolcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostPetrolTBikeCar")).Text;
            if (strpetrolcost == "") { petrolcostBikeCar = 0; }
            else
            { petrolcostBikeCar = decimal.Parse(strpetrolcost); }
               
            if (petrolcostBikeCar <= 0)
            {
                petrolcostBikeCar = 0;
            }
            string stroctencost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostOctenTBikeCar")).Text;
            if (stroctencost == "") { octencostBikeCar = 0; }
            else { octencostBikeCar = decimal.Parse(stroctencost); }

              
            if (octencostBikeCar <= 0)
            {
                octencostBikeCar = 0;
            }

            string strcngcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasTBikeCar")).Text;
            if (strcngcost == "") { cngcostBikeCar = 0; }
            else { cngcostBikeCar = decimal.Parse(strcngcost); }
               
            if (cngcostBikeCar <= 0)
            {
                cngcostBikeCar = 0;
            }

            string strlubriantcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostLubricantBikeCar")).Text;
            if (strlubriantcost == "") { lubriantcostBikeCar = 0; }
            else { lubriantcostBikeCar = decimal.Parse(strlubriantcost); }
                
            if (lubriantcostBikeCar <= 0)
            {
                lubriantcostBikeCar = 0;
            }

            string strbusfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareBusAmountTBikeCar")).Text;
            if (strbusfare == "") { busfareBikeCar = 0; }
            else { busfareBikeCar = decimal.Parse(strbusfare); }

               
            if (busfareBikeCar <= 0)
            {
                busfareBikeCar = 0;
            }

            string strRickfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareRickshawAmountTBikeCar")).Text;
            if (strRickfare == "") { RickfareBikeCar = 0; }
            else { RickfareBikeCar = decimal.Parse(strRickfare); }
                
            if (RickfareBikeCar <= 0)
            {
                RickfareBikeCar = 0;
            }

            string strcngfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareCNGAmountTBikeCar")).Text;
            if (strcngfare == "") { cngfareBikeCar = 0; }
            else { cngfareBikeCar = decimal.Parse(strcngfare); }
              
            if (cngfareBikeCar <= 0)
            {
                cngfareBikeCar = 0;
            }
            string strtrainfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareTrainAmountTBikeCar")).Text;
            if (strtrainfare == "") { trainfareBikeCar = 0; }
            else { trainfareBikeCar = decimal.Parse(strtrainfare); }

             
            if (trainfareBikeCar <= 0)
            {
                trainfareBikeCar = 0;
            }

            string strBoatfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareBoatAmountT")).Text;
            if (strBoatfare == "") { boatbikecare = 0; }
            else { boatbikecare = decimal.Parse(strBoatfare); }

                
            if (boatbikecare <= 0)
            {
                boatbikecare = 0;
            }
            


            string strairplance = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareAirPlaneTBikeCar")).Text;
            if (strairplance == "") { airplanceBikeCar = 0; }
            else { airplanceBikeCar = decimal.Parse(strairplance); }

               
            if (airplanceBikeCar <= 0)
            {
                airplanceBikeCar = 0;
            }

            string strothervhfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountTBikeCar")).Text;
            if (strothervhfare == "") { othervhfareBikeCar = 0; }
            else { othervhfareBikeCar = decimal.Parse(strothervhfare); }

             
            if (othervhfareBikeCar <= 0)
            {
                othervhfareBikeCar = 0;
            }

            string strmntcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceTBikeCar")).Text;
            if (strmntcost == "") { mntcostBikeCar = 0; }
            else { mntcostBikeCar = decimal.Parse(strmntcost); }
               
            if (mntcostBikeCar <= 0)
            {
                mntcostBikeCar = 0;
            }
            string strferrytol = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFeryTollCostTBikeCar")).Text;
            if (strferrytol == "") { ferrytolBikeCar = 0; }
            else { ferrytolBikeCar = decimal.Parse(strferrytol); }

                
            if (ferrytolBikeCar <= 0)
            {
                ferrytolBikeCar = 0;
            }

            string strownda = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecDAAmountTBikeCar")).Text;
            if (strownda == "") { owndaBikeCar = 0; }
            else { owndaBikeCar = decimal.Parse(strownda); }
              
            if (owndaBikeCar <= 0)
            {
                owndaBikeCar = 0;
            }

            string strdriverda = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecDriverDACostTBikeCar")).Text;
            if (strdriverda == "") { driverdaBikeCar = 0; }
            else { driverdaBikeCar = decimal.Parse(strdriverda); }

              
            if (driverdaBikeCar <= 0)
            {
                driverdaBikeCar = 0;
            }
            string strownhotel = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecHotelBillAmountTBikeCar")).Text;
            if (strownhotel == "") { ownhotelBikeCar = 0; }
            else { ownhotelBikeCar = decimal.Parse(strownhotel); }

               
            if (ownhotelBikeCar <= 0)
            {
                ownhotelBikeCar = 0;
            }

            string strdriverhotel = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountTBikeCar")).Text;
            if (strdriverhotel == "") { driverhotelBikeCar = 0; }
            else { driverhotelBikeCar = decimal.Parse(strdriverhotel); }



              
            if (driverhotelBikeCar <= 0)
            {
                driverhotelBikeCar = 0;
            }

            string strphotocopy = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecPhotoCopyCostTBikeCar")).Text;
            if (strphotocopy == "") { photocopyBikeCar = 0; }
            else { photocopyBikeCar = decimal.Parse(strphotocopy); }

              
            if (photocopyBikeCar <= 0)
            {
                photocopyBikeCar = 0;
            }



            string strc = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCourierCostTBikeCar")).Text;
            if (strc == "") { courierBikeCar = 0; }
            else
            {
                courierBikeCar = decimal.Parse(strc);
                if (courierBikeCar <= 0)
                { courierBikeCar = 0; }
            }
            string strOthBill = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecOtherBillAmountTBikeCar")).Text;
            if
                (strOthBill == "") { othercostBikeCar = 0; }

            else { othercostBikeCar = decimal.Parse(strOthBill); }

              
            if (othercostBikeCar <= 0)
            {
                othercostBikeCar = 0;
            }

            string strtotalcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecRowTotalTBikeCar")).Text;
            if (strtotalcost == "") { totalcostBikeCar = 0; }
            else { totalcostBikeCar = decimal.Parse(strtotalcost); }



              
            if (totalcostBikeCar <= 0)
            {
                totalcostBikeCar = 0;
            }

            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecRowTotalTBikeCar")).Text =

          (petrolcostBikeCar + octencostBikeCar + cngcostBikeCar + lubriantcostBikeCar + busfareBikeCar + RickfareBikeCar + cngfareBikeCar + trainfareBikeCar + boatbikecare + airplanceBikeCar + othervhfareBikeCar + mntcostBikeCar
          + ferrytolBikeCar + owndaBikeCar + driverdaBikeCar + ownhotelBikeCar + driverhotelBikeCar + photocopyBikeCar + courierBikeCar + othercostBikeCar).ToString();


        }


        private void calculateGrnadTotalBikeCar()
        {
            petrolcostBikeCar = 0; octencostBikeCar = 0; cngcostBikeCar = 0; lubriantcostBikeCar = 0; busfareBikeCar = 0; RickfareBikeCar = 0; cngfareBikeCar = 0; trainfareBikeCar = 0; airplanceBikeCar = 0; othervhfareBikeCar = 0;
            mntcostBikeCar = 0; ferrytolBikeCar = 0; owndaBikeCar = 0; driverdaBikeCar = 0; ownhotelBikeCar = 0; driverhotelBikeCar = 0; photocopyBikeCar = 0; courierBikeCar = 0; othercostBikeCar = 0;
            totalcostBikeCar = 0; boatbikecare = 0;

            int cnt = grdvBikeCarUserDetaillsHRLabel.Rows.Count;

            for (int RowIndex = 0; RowIndex < cnt - 1; RowIndex++)
            {

                string strpetrolcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostPetrolTBikeCar")).Text;
                if (strpetrolcost == "") { petrolcostBikeCar = 0; }
                else
                    petrolcostBikeCar = petrolcostBikeCar + decimal.Parse(strpetrolcost);

                string stroctencost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostOctenTBikeCar")).Text;
                if (stroctencost == "") { octencostBikeCar = 0; }
                else
                    octencostBikeCar = octencostBikeCar + decimal.Parse(stroctencost);

                string strcngcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasTBikeCar")).Text;
                if (strcngcost == "") { cngcostBikeCar = 0; }
                else
                    cngcostBikeCar = cngcostBikeCar + decimal.Parse(strcngcost);

                string strlubriantcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostLubricantBikeCar")).Text;
                if (strlubriantcost == "") { lubriantcostBikeCar = 0; }
                else
                    lubriantcostBikeCar = lubriantcostBikeCar + decimal.Parse(strlubriantcost);

                string strbusfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareBusAmountTBikeCar")).Text;
                if (strbusfare == "") { busfareBikeCar = 0; }
                else
                    busfareBikeCar = busfareBikeCar + decimal.Parse(strbusfare);

                string strRickfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareRickshawAmountTBikeCar")).Text;
                if (strRickfare == "") { RickfareBikeCar = 0; }
                RickfareBikeCar = RickfareBikeCar + decimal.Parse(strRickfare);

                string strcngfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareCNGAmountTBikeCar")).Text;
                if (strcngfare == "") { cngfareBikeCar = 0; }
                else
                    cngfareBikeCar = cngfareBikeCar + decimal.Parse(strcngfare);

                string strtrainfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareTrainAmountTBikeCar")).Text;
                if (strtrainfare == "") { trainfareBikeCar = 0; }
                else
                    trainfareBikeCar = trainfareBikeCar + decimal.Parse(strtrainfare);


                string strBoatfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareBoatAmountT")).Text;
                if (strBoatfare == "") { boatbikecare = 0; }
                else
                    boatbikecare = boatbikecare + decimal.Parse(strBoatfare);


                string strairplance = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareAirPlaneTBikeCar")).Text;
                if (strairplance == "") { airplanceBikeCar = 0; }
                else
                    airplanceBikeCar = airplanceBikeCar + decimal.Parse(strairplance);

                string strothervhfare = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountTBikeCar")).Text;
                if (strothervhfare == "") { othervhfareBikeCar = 0; }
                else
                    othervhfareBikeCar = othervhfareBikeCar + decimal.Parse(strothervhfare);


                string strmntcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceTBikeCar")).Text;
                if (strmntcost == "") { mntcostBikeCar = 0; }
                else
                    mntcostBikeCar = mntcostBikeCar + decimal.Parse(strmntcost);

                string strferrytol = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecFeryTollCostTBikeCar")).Text;
                if (strferrytol == "") { ferrytolBikeCar = 0; }
                else

                    ferrytolBikeCar = ferrytolBikeCar + decimal.Parse(strferrytol);

                string strownda = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecDAAmountTBikeCar")).Text;
                if (strownda == "") { owndaBikeCar = 0; }
                else
                    owndaBikeCar = owndaBikeCar + decimal.Parse(strownda);

                string strdriverda = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecDriverDACostTBikeCar")).Text;
                if (strdriverda == "") { driverdaBikeCar = 0; }
                else
                    driverdaBikeCar = driverdaBikeCar + decimal.Parse(strdriverda);

                string strownhotel = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecHotelBillAmountTBikeCar")).Text;
                if (strownhotel == "") { ownhotelBikeCar = 0; }
                else

                    ownhotelBikeCar = ownhotelBikeCar + decimal.Parse(strownhotel);

                string strdriverhotel = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountTBikeCar")).Text;
                if (strdriverhotel == "") { driverhotelBikeCar = 0; }
                else
                    driverhotelBikeCar = driverhotelBikeCar + decimal.Parse(strdriverhotel);

                string strphotocopy = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecPhotoCopyCostTBikeCar")).Text;
                if (strphotocopy == "") { photocopyBikeCar = 0; }
                else
                    photocopyBikeCar = photocopyBikeCar + decimal.Parse(strphotocopy);

                string strcourier = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecCourierCostTBikeCar")).Text;
                if (strcourier == "") { courierBikeCar = 0; }

                courierBikeCar = courierBikeCar + decimal.Parse(strcourier);

                string strothercost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecOtherBillAmountTBikeCar")).Text;
                if (strothercost == "") { othercostBikeCar = 0; }
                else
                    othercostBikeCar = othercostBikeCar + decimal.Parse(strothercost);

                string strtotalcost = ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[RowIndex].FindControl("txtdecRowTotalTBikeCar")).Text;
                if (strtotalcost == "") { totalcostBikeCar = 0; }
                else
                    totalcostBikeCar = totalcostBikeCar + decimal.Parse(strtotalcost);
            }
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecCostPetrolTBikeCar")).Text = petrolcostBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecCostOctenTBikeCar")).Text = octencostBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecCostCarbonNitGasTBikeCar")).Text = cngcostBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecCostLubricantBikeCar")).Text = lubriantcostBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareBusAmountTBikeCar")).Text = busfareBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareRickshawAmountTBikeCar")).Text = RickfareBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareCNGAmountTBikeCar")).Text = cngfareBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareTrainAmountTBikeCar")).Text = trainfareBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareBoatAmountT")).Text = boatbikecare.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareAirPlaneTBikeCar")).Text = airplanceBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFareOtherVheicleAmountTBikeCar")).Text = othervhfareBikeCar.ToString();
           ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecCostAmountMaintenaceTBikeCar")).Text = mntcostBikeCar.ToString();
           ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecFeryTollCostTBikeCar")).Text = ferrytolBikeCar.ToString();
           ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecDAAmountTBikeCar")).Text = owndaBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecDriverDACostTBikeCar")).Text = driverdaBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecHotelBillAmountTBikeCar")).Text = ownhotelBikeCar.ToString();

            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecDriverHotelBillAmountTBikeCar")).Text = driverhotelBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecPhotoCopyCostTBikeCar")).Text = photocopyBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecCourierCostTBikeCar")).Text = courierBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecOtherBillAmountTBikeCar")).Text = othercostBikeCar.ToString();
            ((TextBox)grdvBikeCarUserDetaillsHRLabel.Rows[cnt - 1].FindControl("txtdecRowTotalTBikeCar")).Text = totalcostBikeCar.ToString();



        }
           private void CreateSalesXmlHRBIKECAR(string strBillDate, string strBilSubmitteddate, string strName, string strstart, string strEndTime, string strMovDuration, string strFromAdress
          , string strMoveArea, string strToAddress, string strNighstay, string strStartMilage, string strEndMilage, string strConsumedKM, string strRemarks
           , string strQntPetrol, string strCostPetrol, string strQntOcten, string strCostOcten, string strQntCarBonNitr, string strCostCarbonNit, string strQntLubricant
           , string strCostLubricant, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strBoat, string strAirplane, string strOtherVhFare
           , string strMntCost, string strFerryTol, string strOwnDA, string strOtherDA, string strOwnHotel, string strDriverHotel, string strPhotocopy
           , string strCourier, string strOtherCost, string strRowTotal
           , string strSupCNGBill, string strSupplGasBill, string strPersonalMilaqnt, string srPersonalRate, string strPersonMlgTotal, string strPaymentType, string strFuelSupplierName


           , string strunit, string strjobstation, string strAreaid, string strApplicantEnrolid
            )
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLHRBIKECAR))
            {
                doc.Load(filePathForXMLHRBIKECAR);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemotetadaApproveBikeCarHR");
                XmlNode addItem = CreateItemNodeHRBIKECAR(doc, strBillDate, strBilSubmitteddate, strName, strstart, strEndTime, strMovDuration, strFromAdress
                                , strMoveArea, strToAddress, strNighstay, strStartMilage, strEndMilage, strConsumedKM, strRemarks, strQntPetrol
                                , strCostPetrol, strQntOcten, strCostOcten, strQntCarBonNitr, strCostCarbonNit, strQntLubricant, strCostLubricant
                                , strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoat
                                , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                                , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal
                                   , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName
                                
                                
                                , strunit, strjobstation, strAreaid, strApplicantEnrolid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaApproveBikeCarHR");
                XmlNode addItem = CreateItemNodeHRBIKECAR(doc, strBillDate, strBilSubmitteddate, strName, strstart, strEndTime, strMovDuration, strFromAdress
                                , strMoveArea, strToAddress, strNighstay, strStartMilage, strEndMilage, strConsumedKM, strRemarks, strQntPetrol
                                , strCostPetrol, strQntOcten, strCostOcten, strQntCarBonNitr, strCostCarbonNit, strQntLubricant, strCostLubricant
                                , strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoat
                                , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                                , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal

                                   , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName
                                
                                , strunit, strjobstation, strAreaid, strApplicantEnrolid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLHRBIKECAR);
        }


        private XmlNode CreateItemNodeHRBIKECAR(XmlDocument doc, string strBillDate, string strBilSubmitteddate, string strName, string strstart, string strEndTime, string strMovDuration, string strFromAdress
                               , string strMoveArea, string strToAddress, string strNighstay, string strStartMilage, string strEndMilage, string strConsumedKM, string strRemarks, string strQntPetrol
                               , string strCostPetrol, string strQntOcten, string strCostOcten, string strQntCarBonNitr, string strCostCarbonNit, string strQntLubricant, string strCostLubricant
                               , string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strBoat
                               , string strAirplane, string strOtherVhFare, string strMntCost, string strFerryTol, string strOwnDA, string strOtherDA, string strOwnHotel
                               , string strDriverHotel, string strPhotocopy, string strCourier, string strOtherCost, string strRowTotal

                                 , string strSupCNGBill, string strSupplGasBill, string strPersonalMilaqnt, string srPersonalRate, string strPersonMlgTotal, string strPaymentType, string strFuelSupplierName
            
                                 , string strunit, string strjobstation, string strAreaid, string strApplicantEnrolid
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
            XmlAttribute STRBOAT = doc.CreateAttribute("strBoat");
            STRBOAT.Value = strBoat;
            
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
            XmlAttribute UNIT = doc.CreateAttribute("strunit");
            UNIT.Value = strunit;
            XmlAttribute JOBSTATION = doc.CreateAttribute("strjobstation");
            JOBSTATION.Value = strjobstation;
            XmlAttribute AREAID = doc.CreateAttribute("strAreaid");
            AREAID.Value = strAreaid;
            XmlAttribute APPLICANTENROL = doc.CreateAttribute("strApplicantEnrolid");
            APPLICANTENROL.Value = strApplicantEnrolid;




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
            node.Attributes.Append(STRBOAT);
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
            node.Attributes.Append(UNIT);
            node.Attributes.Append(JOBSTATION);
            node.Attributes.Append(AREAID);
            node.Attributes.Append(APPLICANTENROL);


            return node;


        }

        protected void grdvBikeCarUserDetaillsHRLabel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvBikeCarUserDetaillsHRLabel.PageIndex = e.NewPageIndex;
            showNoneBikeHRLebTopsheet();

        }

        protected void btnStorePrint_Click(object sender, EventArgs e)
        {
            tadaTopsheetUnitBasisforBothTypeuser();
        }



        protected void grdvTADAHRUnitTopsheetPrint_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvTADAHRUnitTopsheetPrint.PageIndex = e.NewPageIndex;

        }

        private void tadaTopsheetUnitBasisforBothTypeuser()
        {



            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAapprbyHR TADA Top Sheet Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int rptType = int.Parse(drdlReportType.SelectedValue.ToString());
            int Areaid = int.Parse(drdlArea.SelectedValue.ToString());
            int unit = int.Parse(drdlUnit.SelectedValue.ToString());
            DataTable dt = new DataTable();
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

             if (rptType == 5)               //all employee of selected unit
            {

                
                dt = bll.getsprTADABillStatusForAllunits(dteFromDate, dteToDate, unit, rptType, Areaid);
                 if (dt.Rows.Count > 0)
                {
                    grdvTopShNoneBike.DataSource = null;
                    grdvTopShNoneBike.DataBind();

                    GridviewTADADetaillHrlEBL.DataSource = null;
                    GridviewTADADetaillHrlEBL.DataBind();
                    grdVTopSheetBikeCarHRLebel.DataSource = null;
                    grdVTopSheetBikeCarHRLebel.DataBind();
                    grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                    grdvBikeCarUserDetaillsHRLabel.DataBind();
                    grdvTADAHRUnitTopsheetPrint.DataSource = null;
                    grdvTADAHRUnitTopsheetPrint.DataBind();

                    grdvAreaTopsheetHR.DataSource = null;
                    grdvAreaTopsheetHR.DataBind();

                    grdvTopareaspecific.DataSource = null;
                    grdvTopareaspecific.DataBind();
                    grdvCostAnalysis.DataSource = null;
                    grdvCostAnalysis.DataBind();
                    grdvAdvanceSTATUSHR.DataSource = null;
                    grdvAdvanceSTATUSHR.DataBind();
                    grdvBillMonitoring.DataSource = null;
                    grdvBillMonitoring.DataBind();
                    grdvHRApproveMonitoring.DataSource = null;
                    grdvHRApproveMonitoring.DataBind();
                    grdvBillMonitoringStatusHREND.DataSource = dt;
                    grdvBillMonitoringStatusHREND.DataBind();

                   

                }

                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                 }

            }


            else if (rptType == 6)               //all employee of selected Area
             {

                 
                     
                     string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                     int enr = int.Parse(hdnenrol);
                     dt = bll.getsprTADABillStatusForAllunits(dteFromDate, dteToDate, unit, rptType, Areaid);
                 

                 if (dt.Rows.Count > 0)
                 {
                     grdvTopShNoneBike.DataSource = null;
                     grdvTopShNoneBike.DataBind();

                     GridviewTADADetaillHrlEBL.DataSource = null;
                     GridviewTADADetaillHrlEBL.DataBind();
                     grdVTopSheetBikeCarHRLebel.DataSource = null;
                     grdVTopSheetBikeCarHRLebel.DataBind();
                     grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                     grdvBikeCarUserDetaillsHRLabel.DataBind();
                     grdvTADAHRUnitTopsheetPrint.DataSource = null;
                     grdvTADAHRUnitTopsheetPrint.DataBind();

                     grdvAreaTopsheetHR.DataSource = null;
                     grdvAreaTopsheetHR.DataBind();
                     
                     grdvBillMonitoringStatusHREND.DataSource = null;
                     grdvBillMonitoringStatusHREND.DataBind();
                     grdvCostAnalysis.DataSource = null;
                     grdvCostAnalysis.DataBind();
                     grdvAdvanceSTATUSHR.DataSource = null;
                     grdvAdvanceSTATUSHR.DataBind();
                     grdvBillMonitoring.DataSource = null;
                     grdvBillMonitoring.DataBind();
                     grdvHRApproveMonitoring.DataSource = null;
                     grdvHRApproveMonitoring.DataBind();
                     grdvTopareaspecific.DataSource = dt;
                     grdvTopareaspecific.DataBind();

                 }

                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                 }

             }


            else if (rptType == 2)               //all employee of selected unit
            {

                try
                {
                    //DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    //DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);

                    //dt = bll.getSupervisorvsEmployeeWithBillStatus(dteFromDate, dteToDate, unit, rptType, enr);

                    dt = bll.getTADAAreaTopsheet(dteFromDate, dteToDate,  Areaid,unit, rptType);



                }

                catch
                {
                    //
                }

                if (dt.Rows.Count > 0)
                {
                    grdvTopShNoneBike.DataSource = null;
                    grdvTopShNoneBike.DataBind();

                    GridviewTADADetaillHrlEBL.DataSource = null;
                    GridviewTADADetaillHrlEBL.DataBind();
                    grdVTopSheetBikeCarHRLebel.DataSource = null;
                    grdVTopSheetBikeCarHRLebel.DataBind();
                    grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                    grdvBikeCarUserDetaillsHRLabel.DataBind();
                    grdvTADAHRUnitTopsheetPrint.DataSource = null;
                    grdvTADAHRUnitTopsheetPrint.DataBind();

                    grdvBillMonitoringStatusHREND.DataSource = null;
                    grdvBillMonitoringStatusHREND.DataBind();
                    grdvTopareaspecific.DataSource = null;
                    grdvTopareaspecific.DataBind();
                    grdvCostAnalysis.DataSource = null;
                    grdvCostAnalysis.DataBind();
                    grdvAdvanceSTATUSHR.DataSource = null;
                    grdvAdvanceSTATUSHR.DataBind();
                    grdvBillMonitoring.DataSource = null;
                    grdvBillMonitoring.DataBind();
                    grdvHRApproveMonitoring.DataSource = null;
                    grdvHRApproveMonitoring.DataBind();
                    grdvAreaTopsheetHR.DataSource = dt;
                    grdvAreaTopsheetHR.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                }

            }

             else if (rptType == 1015) //All Area Bill
             {
                 try
                 { dt = bll.getReportTADAHRpRINT(dtFromDate, dtToDate, unit, rptType); }
                 catch
                 { }
                 if (dt.Rows.Count > 0)
                 {
                     grdvTopShNoneBike.DataSource = null;
                     grdvTopShNoneBike.DataBind();

                     GridviewTADADetaillHrlEBL.DataSource = null;
                     GridviewTADADetaillHrlEBL.DataBind();
                     grdVTopSheetBikeCarHRLebel.DataSource = null;
                     grdVTopSheetBikeCarHRLebel.DataBind();
                     grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                     grdvBikeCarUserDetaillsHRLabel.DataBind();
                     grdvBillMonitoringStatusHREND.DataSource = null;
                     grdvBillMonitoringStatusHREND.DataBind();
                     grdvTopareaspecific.DataSource = null;
                     grdvTopareaspecific.DataBind();
                     grdvCostAnalysis.DataSource = null;
                     grdvCostAnalysis.DataBind();
                     grdvAdvanceSTATUSHR.DataSource = null;
                     grdvAdvanceSTATUSHR.DataBind();
                     grdvBillMonitoring.DataSource = null;
                     grdvBillMonitoring.DataBind();
                     grdvHRApproveMonitoring.DataSource = null;
                     grdvHRApproveMonitoring.DataBind();
                     grdvTADAHRUnitTopsheetPrint.DataSource = dt;
                     grdvTADAHRUnitTopsheetPrint.DataBind();


                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                 }
             }

             else if (rptType == 1016)               //Cost Analysis for Helal sir format
             {
                dt = bll.getRptTADACostAnalysis(dteFromDate, dteToDate, unit, rptType, Areaid);
                if (dt.Rows.Count > 0)
                 {
                     grdvTopShNoneBike.DataSource = null;
                     grdvTopShNoneBike.DataBind();

                     GridviewTADADetaillHrlEBL.DataSource = null;
                     GridviewTADADetaillHrlEBL.DataBind();
                     grdVTopSheetBikeCarHRLebel.DataSource = null;
                     grdVTopSheetBikeCarHRLebel.DataBind();
                     grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                     grdvBikeCarUserDetaillsHRLabel.DataBind();
                     grdvTADAHRUnitTopsheetPrint.DataSource = null;
                     grdvTADAHRUnitTopsheetPrint.DataBind();

                     grdvAreaTopsheetHR.DataSource = null;
                     grdvAreaTopsheetHR.DataBind();

                     grdvBillMonitoringStatusHREND.DataSource = null;
                     grdvBillMonitoringStatusHREND.DataBind();

                     grdvTopareaspecific.DataSource = null;
                     grdvTopareaspecific.DataBind();
                     grdvAdvanceSTATUSHR.DataSource = null;
                     grdvAdvanceSTATUSHR.DataBind();
                     grdvBillMonitoring.DataSource = null;
                     grdvBillMonitoring.DataBind();
                     grdvHRApproveMonitoring.DataSource = null;
                     grdvHRApproveMonitoring.DataBind();
                     grdvCostAnalysis.DataSource = dt;
                     grdvCostAnalysis.DataBind();
                 }

                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                 }

             }

             else if (rptType == 1018)               //TA DA ADVANCE WHOLE UNIT
             {
                 int reportTypenow = 2;
                 dt = bll.getRptTADAAdvanceAprvStatus(0, 0, unit, reportTypenow, dteFromDate, dteToDate);
                 if (dt.Rows.Count > 0)
                 {
                     grdvTopShNoneBike.DataSource = null;
                     grdvTopShNoneBike.DataBind();

                     GridviewTADADetaillHrlEBL.DataSource = null;
                     GridviewTADADetaillHrlEBL.DataBind();
                     grdVTopSheetBikeCarHRLebel.DataSource = null;
                     grdVTopSheetBikeCarHRLebel.DataBind();
                     grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                     grdvBikeCarUserDetaillsHRLabel.DataBind();
                     grdvTADAHRUnitTopsheetPrint.DataSource = null;
                     grdvTADAHRUnitTopsheetPrint.DataBind();

                     grdvAreaTopsheetHR.DataSource = null;
                     grdvAreaTopsheetHR.DataBind();

                     grdvBillMonitoringStatusHREND.DataSource = null;
                     grdvBillMonitoringStatusHREND.DataBind();

                     grdvTopareaspecific.DataSource = null;
                     grdvTopareaspecific.DataBind();
                     
                     grdvCostAnalysis.DataSource = null;
                     grdvCostAnalysis.DataBind();
                     grdvBillMonitoring.DataSource = null;
                     grdvBillMonitoring.DataBind();
                     grdvHRApproveMonitoring.DataSource = null;
                     grdvHRApproveMonitoring.DataBind();
                     grdvAdvanceSTATUSHR.DataSource = dt;
                     grdvAdvanceSTATUSHR.DataBind();
                 }

                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                 }

             }

             else if (rptType == 1022)               //TA DA Supervisor Approve Pending Monitoring
             {
                 int reportTypenow = 1;
                 DataTable dtinv = new DataTable();
                 TourPlanning bllinv = new TourPlanning();
                 dtinv = bllinv.GetTADASupervisroApproveMonitoring(dteFromDate, dteToDate, 0, unit, reportTypenow);
                 if (dtinv.Rows.Count > 0)
                 {
                     grdvTopShNoneBike.DataSource = null;
                     grdvTopShNoneBike.DataBind();
                     GridviewTADADetaillHrlEBL.DataSource = null;
                     GridviewTADADetaillHrlEBL.DataBind();
                     grdVTopSheetBikeCarHRLebel.DataSource = null;
                     grdVTopSheetBikeCarHRLebel.DataBind();
                     grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                     grdvBikeCarUserDetaillsHRLabel.DataBind();
                     grdvTADAHRUnitTopsheetPrint.DataSource = null;
                     grdvTADAHRUnitTopsheetPrint.DataBind();
                     grdvAreaTopsheetHR.DataSource = null;
                     grdvAreaTopsheetHR.DataBind();
                     grdvBillMonitoringStatusHREND.DataSource = null;
                     grdvBillMonitoringStatusHREND.DataBind();
                     grdvTopareaspecific.DataSource = null;
                     grdvTopareaspecific.DataBind();
                     grdvCostAnalysis.DataSource = null;
                     grdvCostAnalysis.DataBind();
                     grdvAdvanceSTATUSHR.DataSource = null;
                     grdvAdvanceSTATUSHR.DataBind();
                     grdvHRApproveMonitoring.DataSource = null;
                     grdvHRApproveMonitoring.DataBind();
                     grdvBillMonitoring.DataSource = dtinv;
                     grdvBillMonitoring.DataBind();
                 }

                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
                 }

             }

             else if (rptType == 1023)               //TA DA HR Approve Pending Monitoring
             {
                 int reportTypenow = 2;
                 DataTable dtinv = new DataTable();
                
                 dtinv = bll.getTADAHRApproveMonitoringData(dteFromDate, dteToDate, 0, unit, reportTypenow,0);
                 if (dtinv.Rows.Count > 0)
                 {
                     grdvTopShNoneBike.DataSource = null;
                     grdvTopShNoneBike.DataBind();
                     GridviewTADADetaillHrlEBL.DataSource = null;
                     GridviewTADADetaillHrlEBL.DataBind();
                     grdVTopSheetBikeCarHRLebel.DataSource = null;
                     grdVTopSheetBikeCarHRLebel.DataBind();
                     grdvBikeCarUserDetaillsHRLabel.DataSource = null;
                     grdvBikeCarUserDetaillsHRLabel.DataBind();
                     grdvTADAHRUnitTopsheetPrint.DataSource = null;
                     grdvTADAHRUnitTopsheetPrint.DataBind();
                     grdvAreaTopsheetHR.DataSource = null;
                     grdvAreaTopsheetHR.DataBind();
                     grdvBillMonitoringStatusHREND.DataSource = null;
                     grdvBillMonitoringStatusHREND.DataBind();
                     grdvTopareaspecific.DataSource = null;
                     grdvTopareaspecific.DataBind();
                     grdvCostAnalysis.DataSource = null;
                     grdvCostAnalysis.DataBind();
                     grdvAdvanceSTATUSHR.DataSource = null;
                     grdvAdvanceSTATUSHR.DataBind();
                     grdvBillMonitoring.DataSource = null;
                     grdvBillMonitoring.DataBind();
                     grdvHRApproveMonitoring.DataSource = dtinv;
                     grdvHRApproveMonitoring.DataBind();
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



        protected void btnExpToExcel_Click(object sender, EventArgs e)
        {
            string data = hdnData.Value;
            data = HttpUtility.UrlDecode(data);
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ExcelData.xls");
            Response.Charset = "";
            Response.ContentType = "application/excel";
            HttpContext.Current.Response.Write(data);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }



        protected void grdvBillMonitoringStatusHREND_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValueaudit = Convert.ToDecimal(e.Row.Cells[5].Text);
                Decimal CellValueApplicant = Convert.ToDecimal(e.Row.Cells[6].Text);
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValueaudit > CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                }
                else if (CellValueaudit < CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;

                }
                else
                    e.Row.Cells[7].BackColor = System.Drawing.Color.GreenYellow;

            }
        }

        protected void grdvBillMonitoringStatusHREND_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void txtdecSupplierCNG_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecSupplierGas_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecPersonalMilage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecMlgRate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecPersonalTotalcost_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPaymentType_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtstrFuelStationaname_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvAreaTopsheetHR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvAreaTopsheetHR_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvTopareaspecific_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvTopareaspecific_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValueaudit = Convert.ToDecimal(e.Row.Cells[5].Text);
                Decimal CellValueApplicant = Convert.ToDecimal(e.Row.Cells[6].Text);
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValueaudit > CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                }
                else if (CellValueaudit < CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;

                }
                else
                    e.Row.Cells[7].BackColor = System.Drawing.Color.GreenYellow;

            }
        }

        protected void grdvAdvanceSTATUSHR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvAdvanceSTATUSHR_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvBillMonitoring_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvBillMonitoring_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvHRApproveMonitoring_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvHRApproveMonitoring_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

       


    }
}