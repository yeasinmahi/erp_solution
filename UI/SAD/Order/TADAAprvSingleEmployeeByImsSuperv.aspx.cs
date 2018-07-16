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
    public partial class TADAAprvSingleEmployeeByImsSuperv : BasePage
    {


         DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        string strDate; string strTodate; string enrol1; string UNITS; string ReportType;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        decimal petrolcost = 0; decimal octencost = 0; decimal cngcost = 0; decimal lubriantcost = 0;
        decimal busfare = 0; decimal Rickfare = 0; decimal cngfare = 0; decimal trainfare = 0; decimal airplance = 0; decimal othervhfare = 0;
        decimal mntcost = 0; decimal ferrytol = 0; decimal boatfare=0;

        decimal ownda = 0; decimal driverda = 0; decimal ownhotel = 0; decimal driverhotel = 0;
        decimal photocopy = 0; decimal courier = 0; decimal othercost = 0; decimal totalcost = 0; decimal personalMlgqnt = 0; decimal personalTotalCost = 0;
        int RowIndex;

        string filePathForXML;

        string xmlString = "";
  


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strDate = Session["Date"].ToString();
                DateTime dtfrom = Convert.ToDateTime(strDate);
                strTodate = Session["DateTodate"].ToString();
                DateTime dtTo = Convert.ToDateTime(strTodate);
                enrol1 = Session["enrol1"].ToString();
                int enrol = int.Parse(enrol1);

                filePathForXML = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaApproveBikeCarUserGb.xml");
                if (!IsPostBack)
                {
                    //pnlUpperControl.DataBind();
                    ////---------xml----------
                    try { File.Delete(filePathForXML); }
                    catch { File.Delete(filePathForXML); }
                    ////-----**----------//

                    loadgrid();
                }


               

                //int reporTBasic = 1;
                DataTable dtBasicinfo = new DataTable();
                dtBasicinfo = bll.getTADABasicInfo(dtfrom, dtTo,enrol);

            
                
                 if (dtBasicinfo.Rows.Count > 0)
                {
                    txtName.Text = dtBasicinfo.Rows[0][2].ToString();
                    textDesg.Text = dtBasicinfo.Rows[0][4].ToString();
                    txtDept.Text = dtBasicinfo.Rows[0][5].ToString();
                    txtLMbILL.Text = dtBasicinfo.Rows[0][6].ToString();
                    txtcmbill.Text = dtBasicinfo.Rows[0][8].ToString();
                    txtIdealMilage.Text = dtBasicinfo.Rows[0][9].ToString();
                    txtConsMilage.Text = dtBasicinfo.Rows[0][10].ToString();
                    txtQnt.Text = dtBasicinfo.Rows[0][11].ToString();
                    txtRation.Text = dtBasicinfo.Rows[0][12].ToString();
                    txtPresent.Text = dtBasicinfo.Rows[0][14].ToString();
                    txtBillday.Text = dtBasicinfo.Rows[0][15].ToString();
                    txtEnrol.Text = dtBasicinfo.Rows[0][1].ToString();
                    txtJobstation.Text = dtBasicinfo.Rows[0][33].ToString();
                    txtUnitID.Text = dtBasicinfo.Rows[0][34].ToString();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
               
            }
            catch
            {
                File.Delete(filePathForXML);

            }
            

            


        }

        private void loadgrid()
        {
            try
            {
                strDate = Session["Date"].ToString();
                DateTime dtfrom = Convert.ToDateTime(strDate);
                strTodate = Session["DateTodate"].ToString();
                DateTime dtTo = Convert.ToDateTime(strTodate);
                enrol1 = Session["enrol1"].ToString();
                int enrol = int.Parse(enrol1);
                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                dt = bll.getTADARptforSUpervisorAproveV2(dtfrom, dtTo, enrol);

                if (dt.Rows.Count > 0)
                {

                    grdvForApproveTADAByImmdediatesupervisor.DataSource = dt;
                    grdvForApproveTADAByImmdediatesupervisor.DataBind();
                }

            }

            catch
            {
            }


        }



        //private void calculateRowTotal(int RowIndex)
        //{
        //    string strpetrolcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostPetrolT")).Text;
        //    if (strpetrolcost == "") { petrolcost = 0; }
        //    else
        //        petrolcost = decimal.Parse(strpetrolcost);
        //    if (petrolcost <= 0)
        //    {
        //        petrolcost = 0;
        //    }
        //    string stroctencost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostOctenT")).Text;
        //    if (stroctencost == "") { octencost = 0; }
        //    else

        //        octencost = decimal.Parse(stroctencost);
        //    if (octencost <= 0)
        //    {
        //        octencost = 0;
        //    }

        //    string strcngcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasT")).Text;
        //    if (strcngcost == "") { cngcost = 0; }
        //    else
        //        cngcost = decimal.Parse(strcngcost);
        //    if (cngcost <= 0)
        //    {
        //        cngcost = 0;
        //    }

        //    string strlubriantcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtlubricantcost")).Text;
        //    if (strlubriantcost == "") { lubriantcost = 0; }
        //    else
        //        lubriantcost = decimal.Parse(strlubriantcost);
        //    if (lubriantcost <= 0)
        //    {
        //        lubriantcost = 0;
        //    }

        //    string strbusfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareBusAmountT")).Text;
        //    if (strbusfare == "") { busfare = 0; }
        //    else

        //        busfare = decimal.Parse(strbusfare);
        //    if (busfare <= 0)
        //    {
        //        busfare = 0;
        //    }

        //    string strRickfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareRickshawAmountT")).Text;
        //    if (strRickfare == "") { Rickfare = 0; }
        //    else
        //        Rickfare = decimal.Parse(strRickfare);
        //    if (Rickfare <= 0)
        //    {
        //        Rickfare = 0;
        //    }

        //    string strcngfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareCNGAmountT")).Text;
        //    if (strcngfare == "") { cngfare = 0; }
        //    else
        //        cngfare = decimal.Parse(strcngfare);
        //    if (cngfare <= 0)
        //    {
        //        cngfare = 0;
        //    }
        //    string strtrainfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareTrainAmountT")).Text;
        //    if (strtrainfare == "") { trainfare = 0; }
        //    else

        //        trainfare = decimal.Parse(strtrainfare);
        //    if (trainfare <= 0)
        //    {
        //        trainfare = 0;
        //    }

        //    string strBoatfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareBoatT")).Text;
        //    if (strBoatfare == "") { boatfare = 0; }
        //    else

        //        boatfare = decimal.Parse(strBoatfare);
        //    if (trainfare <= 0)
        //    {
        //        boatfare = 0;
        //    }



        //    string strairplance = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareAirPlaneT")).Text;
        //    if (strairplance == "") { airplance = 0; }
        //    else

        //        airplance = decimal.Parse(strairplance);
        //    if (airplance <= 0)
        //    {
        //        airplance = 0;
        //    }

        //    string strothervhfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountT")).Text;
        //    if (strothervhfare == "") { othervhfare = 0; }
        //    else

        //        othervhfare = decimal.Parse(strothervhfare);
        //    if (othervhfare <= 0)
        //    {
        //        othervhfare = 0;
        //    }

        //    string strmntcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceT")).Text;
        //    if (strmntcost == "") { mntcost = 0; }
        //    else
        //        mntcost = decimal.Parse(strmntcost);
        //    if (mntcost <= 0)
        //    {
        //        mntcost = 0;
        //    }
        //    string strferrytol = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFeryTollCostT")).Text;
        //    if (strferrytol == "") { ferrytol = 0; }
        //    else

        //        ferrytol = decimal.Parse(strferrytol);
        //    if (ferrytol <= 0)
        //    {
        //        ferrytol = 0;
        //    }

        //    string strownda = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecDAAmountT")).Text;
        //    if (strownda == "") { ownda = 0; }
        //    else
        //        ownda = decimal.Parse(strownda);
        //    if (ownda <= 0)
        //    {
        //        ownda = 0;
        //    }

        //    string strdriverda = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecDriverDACostT")).Text;
        //    if (strdriverda == "") { driverda = 0; }
        //    else

        //        driverda = decimal.Parse(strdriverda);
        //    if (driverda <= 0)
        //    {
        //        driverda = 0;
        //    }
        //    string strownhotel = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecHotelBillAmountT")).Text;
        //    if (strownhotel == "") { ownhotel = 0; }
        //    else

        //        ownhotel = decimal.Parse(strownhotel);
        //    if (ownhotel <= 0)
        //    {
        //        ownhotel = 0;
        //    }

        //    string strdriverhotel = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountT")).Text;
        //    if (strdriverhotel == "") { driverhotel = 0; }
        //    else



        //        driverhotel = decimal.Parse(strdriverhotel);
        //    if (driverhotel <= 0)
        //    {
        //        driverhotel = 0;
        //    }

        //    string strphotocopy = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecPhotoCopyCostT")).Text;
        //    if (strphotocopy == "") { photocopy = 0; }
        //    else

        //        photocopy = decimal.Parse(strphotocopy);
        //    if (photocopy <= 0)
        //    {
        //        photocopy = 0;
        //    }



        //    string strc = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCourierCostT")).Text;
        //    if (strc == "") { courier = 0; }
        //    else
        //    {
        //        courier = decimal.Parse(strc);
        //        if (courier <= 0)
        //        { courier = 0; }
        //    }
        //    string strOthBill = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecOtherBillAmountT")).Text;
        //    if
        //        (strOthBill == "") { othercost = 0; }

        //    else

        //        othercost = decimal.Parse(strOthBill);
        //    if (othercost <= 0)
        //    {
        //        othercost = 0;
        //    }

        //    string strtotalcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text;
        //    if (strtotalcost == "") { totalcost = 0; }
        //    else



        //        totalcost = decimal.Parse(strtotalcost);
        //    if (totalcost <= 0)
        //    {
        //        totalcost = 0;
        //    }

        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text =

        //  (petrolcost + octencost + cngcost + lubriantcost + busfare + Rickfare + cngfare + trainfare + boatfare + airplance + othervhfare + mntcost
        //  + ferrytol + ownda + driverda + ownhotel + driverhotel + photocopy + courier + othercost).ToString();


        //}

        //private void CalculateGrandTotal()
        //{
        //    petrolcost = 0; octencost = 0; cngcost = 0; lubriantcost = 0;
        //    busfare = 0; Rickfare = 0; cngfare = 0; trainfare = 0; boatfare = 0; airplance = 0; othervhfare = 0;
        //    mntcost = 0; ferrytol = 0;

        //    ownda = 0; driverda = 0; ownhotel = 0; driverhotel = 0;
        //    photocopy = 0; courier = 0; othercost = 0; totalcost = 0;


        //    int cnt = grdvForApproveTADAByImmdediatesupervisor.Rows.Count;
        //    for (int RowIndex = 0; RowIndex < cnt - 1; RowIndex++)
        //    {

        //        string strpetrolcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostPetrolT")).Text;
        //        if (strpetrolcost == "") { petrolcost = 0; }
        //        else
        //            petrolcost = petrolcost + decimal.Parse(strpetrolcost);

        //        string stroctencost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostOctenT")).Text;
        //        if (stroctencost == "") { octencost = 0; }
        //        else
        //            octencost = octencost + decimal.Parse(stroctencost);

        //        string strcngcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasT")).Text;
        //        if (strcngcost == "") { cngcost = 0; }
        //        else
        //            cngcost = cngcost + decimal.Parse(strcngcost);

        //        string strlubriantcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtlubricantcost")).Text;
        //        if (strlubriantcost == "") { lubriantcost = 0; }
        //        else
        //            lubriantcost = lubriantcost + decimal.Parse(strlubriantcost);

        //        string strbusfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareBusAmountT")).Text;
        //        if (strbusfare == "") { busfare = 0; }
        //        else
        //            busfare = busfare + decimal.Parse(strbusfare);

        //        string strRickfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareRickshawAmountT")).Text;
        //        if (strRickfare == "") { Rickfare = 0; }
        //        Rickfare = Rickfare + decimal.Parse(strRickfare);

        //        string strcngfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareCNGAmountT")).Text;
        //        if (strcngfare == "") { cngfare = 0; }
        //        else
        //            cngfare = cngfare + decimal.Parse(strcngfare);

        //        string strtrainfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareTrainAmountT")).Text;
        //        if (strtrainfare == "") { trainfare = 0; }
        //        else
        //            trainfare = trainfare + decimal.Parse(strtrainfare);


        //        string strboatfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareBoatT")).Text;
        //        if (strboatfare == "") { boatfare = 0; }
        //        else
        //            boatfare = boatfare + decimal.Parse(strboatfare);


        //        string strairplance = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareAirPlaneT")).Text;
        //        if (strairplance == "") { airplance = 0; }
        //        else
        //            airplance = airplance + decimal.Parse(strairplance);

        //        string strothervhfare = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountT")).Text;
        //        if (strothervhfare == "") { othervhfare = 0; }
        //        else
        //            othervhfare = othervhfare + decimal.Parse(strothervhfare);


        //        string strmntcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceT")).Text;
        //        if (strmntcost == "") { mntcost = 0; }
        //        else
        //            mntcost = mntcost + decimal.Parse(strmntcost);

        //        string strferrytol = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecFeryTollCostT")).Text;
        //        if (strferrytol == "") { ferrytol = 0; }
        //        else

        //            ferrytol = ferrytol + decimal.Parse(strferrytol);

        //        string strownda = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecDAAmountT")).Text;
        //        if (strownda == "") { ownda = 0; }
        //        else
        //            ownda = ownda + decimal.Parse(strownda);

        //        string strdriverda = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecDriverDACostT")).Text;
        //        if (strdriverda == "") { driverda = 0; }
        //        else
        //            driverda = driverda + decimal.Parse(strdriverda);

        //        string strownhotel = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecHotelBillAmountT")).Text;
        //        if (strownhotel == "") { ownhotel = 0; }
        //        else

        //            ownhotel = ownhotel + decimal.Parse(strownhotel);

        //        string strdriverhotel = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountT")).Text;
        //        if (strdriverhotel == "") { driverhotel = 0; }
        //        else
        //            driverhotel = driverhotel + decimal.Parse(strdriverhotel);

        //        string strphotocopy = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecPhotoCopyCostT")).Text;
        //        if (strphotocopy == "") { photocopy = 0; }
        //        else
        //            photocopy = photocopy + decimal.Parse(strphotocopy);

        //        string strcourier = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecCourierCostT")).Text;
        //        if (strcourier == "") { courier = 0; }

        //        courier = courier + decimal.Parse(strcourier);

        //        string strothercost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecOtherBillAmountT")).Text;
        //        if (strothercost == "") { othercost = 0; }
        //        else
        //            othercost = othercost + decimal.Parse(strothercost);

        //        string strtotalcost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text;
        //        if (strtotalcost == "") { totalcost = 0; }
        //        else
        //            totalcost = totalcost + decimal.Parse(strtotalcost);

        //        string strPersonalqnt = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecPersonalMilage")).Text;
        //        if (strPersonalqnt == "") { personalMlgqnt = 0; }
        //        else
        //            personalMlgqnt = personalMlgqnt + decimal.Parse(strPersonalqnt);

        //        string strPersonalMlgTCost = ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[RowIndex].FindControl("txtdecPersonalTotalcost")).Text;
        //        if (strPersonalMlgTCost == "") { personalTotalCost = 0; }
        //        else
        //            personalTotalCost = personalTotalCost + decimal.Parse(strPersonalMlgTCost);
        //    }
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecCostPetrolT")).Text = petrolcost.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecCostOctenT")).Text = octencost.ToString();

        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecCostCarbonNitGasT")).Text = cngcost.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtlubricantcost")).Text = lubriantcost.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareBusAmountT")).Text = busfare.ToString();

        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareRickshawAmountT")).Text = Rickfare.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareCNGAmountT")).Text = cngfare.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareTrainAmountT")).Text = trainfare.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareBoatT")).Text = boatfare.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareAirPlaneT")).Text = airplance.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFareOtherVheicleAmountT")).Text = othervhfare.ToString();

        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecCostAmountMaintenaceT")).Text = mntcost.ToString();


        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecFeryTollCostT")).Text = ferrytol.ToString();

        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecDAAmountT")).Text = ownda.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecDriverDACostT")).Text = driverda.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecHotelBillAmountT")).Text = ownhotel.ToString();

        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecDriverHotelBillAmountT")).Text = driverhotel.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecPhotoCopyCostT")).Text = photocopy.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecCourierCostT")).Text = courier.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecOtherBillAmountT")).Text = othercost.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecRowTotalT")).Text = totalcost.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecPersonalMilage")).Text = personalMlgqnt.ToString();
        //    ((TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[cnt - 1].FindControl("txtdecPersonalTotalcost")).Text = personalTotalCost.ToString();

        //}



        //protected void txtdecCostPetrolT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecCostOctenT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecCostCarbonNitGasT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtlubricantcost_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareBusAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareRickshawAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareCNGAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareTrainAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareBoatT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareAirPlaneT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFareOtherVheicleAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecCostAmountMaintenaceT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecFeryTollCostT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecDAAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecDriverDACostT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecHotelBillAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecDriverHotelBillAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecPhotoCopyCostT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecCourierCostT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecOtherBillAmountT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        //protected void txtdecRowTotalT_TextChanged(object sender, EventArgs e)
        //{
        //    //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
        //    //calculateRowTotal(RowIndex);
        //    //CalculateGrandTotal();
        //}

        protected void txtdecSupplierCNG_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecSupplierGas_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecPersonalMilage_TextChanged(object sender, EventArgs e)
        {
            //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            //calculateRowTotal(RowIndex);
            //CalculateGrandTotal();
        }

        protected void txtdecMlgRate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdecPersonalTotalcost_TextChanged(object sender, EventArgs e)
        {
            //RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            //calculateRowTotal(RowIndex);
            //CalculateGrandTotal();
        }

        protected void txtPaymentType_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtstrFuelStationaname_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmitSingleEmployee_Click(object sender, EventArgs e)
        {

         

            int rptTypeid = 1;
            //try
            //{
                if (hdnconfirm.Value == "1")
                {

                    if (rptTypeid == 1)
                    {

                        if (grdvForApproveTADAByImmdediatesupervisor.Rows.Count > 0)
                        {
                            for (int rowIndex = 0; rowIndex < grdvForApproveTADAByImmdediatesupervisor.Rows.Count - 1; rowIndex++)
                            {


                                TextBox txtdteFromdateNoBikeDet = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[1].FindControl("dteFromdateNoBikeDet");
                                TextBox TextdteInsdateNoBikeDet = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[2].FindControl("dteInsdateNoBikeDet");

                                TextBox txtstrNamNoBikeDet = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[3].FindControl("strNamNoBikeDet");
                                TextBox txtStarTime = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[4].FindControl("txtStarTime");

                                TextBox txtdecEndHourT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[5].FindControl("txtdecEndHourT");
                                TextBox txtdecmovdur = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[6].FindControl("txtdecmovdur");



                                TextBox txtstrFromAddressT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[7].FindControl("txtstrFromAddressT");
                                TextBox txtstrMovementAreaT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[8].FindControl("txtstrMovementAreaT");
                                TextBox txtstrToAddressT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[9].FindControl("txtstrToAddressT");


                                TextBox txtstrNightStayT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[10].FindControl("txtstrNightStayT");
                                TextBox txtdecStartMilageT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[11].FindControl("txtdecStartMilageT");
                                TextBox txtdecEndMilageT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[12].FindControl("txtdecEndMilageT");
                                TextBox txtdecConsumedKmT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[13].FindControl("txtdecConsumedKmT");
                                TextBox txtstrSupportingNoT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[14].FindControl("txtstrSupportingNoT");


                                TextBox txtdecQntPetrolT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[15].FindControl("txtdecQntPetrolT");
                                TextBox txtdecCostPetrolT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[16].FindControl("txtdecCostPetrolT");


                                TextBox txtdecQntOctenT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[17].FindControl("txtdecQntOctenT");
                                TextBox txtdecCostOctenT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[18].FindControl("txtdecCostOctenT");
                                TextBox txtdecQntCarbonNitGasT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[19].FindControl("txtdecQntCarbonNitGasT");
                                TextBox txtdecCostCarbonNitGasT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[20].FindControl("txtdecCostCarbonNitGasT");


                                TextBox txtdecQntLubricant = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[21].FindControl("txtdecQntLubricant");
                                TextBox txtlubricantcost = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[22].FindControl("txtlubricantcost");


                                TextBox txtdecFareBusAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[23].FindControl("txtdecFareBusAmountT");
                                TextBox txtdecFareRickshawAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[24].FindControl("txtdecFareRickshawAmountT");
                                TextBox txtdecFareCNGAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[25].FindControl("txtdecFareCNGAmountT");
                                TextBox txtdecFareTrainAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[26].FindControl("txtdecFareTrainAmountT");
                                TextBox txtdecFareBoatT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[27].FindControl("txtdecFareBoatT");
                                TextBox txtdecFareAirPlaneT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[28].FindControl("txtdecFareAirPlaneT");
                                TextBox txtdecFareOtherVheicleAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[29].FindControl("txtdecFareOtherVheicleAmountT");

                                TextBox txtdecCostAmountMaintenaceT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[30].FindControl("txtdecCostAmountMaintenaceT");
                                TextBox txtdecFeryTollCostT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[31].FindControl("txtdecFeryTollCostT");


                                TextBox txtdecDAAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[32].FindControl("txtdecDAAmountT");
                                TextBox txtdecDriverDACostT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[33].FindControl("txtdecDriverDACostT");
                                TextBox txtdecHotelBillAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[34].FindControl("txtdecHotelBillAmountT");
                                TextBox txtdecDriverHotelBillAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[35].FindControl("txtdecDriverHotelBillAmountT");

                                TextBox txtdecPhotoCopyCostT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[36].FindControl("txtdecPhotoCopyCostT");
                                TextBox txtdecCourierCostT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[37].FindControl("txtdecCourierCostT");


                                TextBox txtdecOtherBillAmountT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[38].FindControl("txtdecOtherBillAmountT");
                                TextBox txtdecRowTotalT = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[39].FindControl("txtdecRowTotalT");

                                TextBox txtdecSupplierCNG = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[40].FindControl("txtdecSupplierCNG");
                                TextBox txtdecSupplierGas = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[41].FindControl("txtdecSupplierGas");
                                TextBox txtdecPersonalMilage = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[42].FindControl("txtdecPersonalMilage");
                                TextBox txtdecMlgRate = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[43].FindControl("txtdecMlgRate");
                                TextBox txtdecPersonalTotalcost = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[44].FindControl("txtdecPersonalTotalcost");
                                TextBox txtPaymentType = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[45].FindControl("txtPaymentType");
                                TextBox txtstrFuelStationaname = (TextBox)grdvForApproveTADAByImmdediatesupervisor.Rows[rowIndex].Cells[48].FindControl("txtstrFuelStationaname");


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
                                string strCostLubricant = txtlubricantcost.Text;

                                string strBusFareTaka = txtdecFareBusAmountT.Text;
                                string strRickFare = txtdecFareRickshawAmountT.Text;
                                string strCNGFare = txtdecFareCNGAmountT.Text;
                                string strTrainFare = txtdecFareTrainAmountT.Text;
                                string strBoatFare = txtdecFareBoatT.Text;
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
                                    , strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare
                                    , strAirplane, strOtherVhFare, strMntCost, strFerryTol, strOwnDA, strOtherDA, strOwnHotel
                                    , strDriverHotel, strPhotocopy, strCourier, strOtherCost, strRowTotal
                                    , strSupCNGBill, strSupplGasBill, strPersonalMilaqnt, srPersonalRate, strPersonMlgTotal, strPaymentType, strFuelSupplierName


                                    );


                            }
                            #region ------------ Insert into dataBase -----------
                            strDate = Session["Date"].ToString();
                            DateTime dteFromDate = Convert.ToDateTime(strDate);
                            strTodate = Session["DateTodate"].ToString();
                            DateTime dteTodate = Convert.ToDateTime(strTodate);


                            int intEnrol = int.Parse(txtEnrol.Text);
                            int jobstationid = int.Parse(txtJobstation.Text);
                            int unitid = int.Parse(txtUnitID.Text);
                            int AreamanagerEnrol = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());

                            Int32 Approverenroll = Convert.ToInt32(AreamanagerEnrol);
                            int Jobstation = jobstationid;
                            int unit = unitid;
                            int intTADAApplicantEnrol = intEnrol;
                            int intApplicantCatge = 1;
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("RemotetadaApproveBikeCarUserGb");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<RemotetadaApproveBikeCarUserGb>" + xmlString + "</RemotetadaApproveBikeCarUserGb>";
                            File.Delete(filePathForXML);
                            string message = bll.tadainsertAfterApproveForBikeAndCarUserGB(xmlString, Approverenroll, intTADAApplicantEnrol, dteFromDate, unit, intApplicantCatge, Jobstation);
                            File.Delete(filePathForXML);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);



                            #endregion ------------ Insertion End ----------------

                        }



                        grdvForApproveTADAByImmdediatesupervisor.DataSource = "";
                        grdvForApproveTADAByImmdediatesupervisor.DataBind();


                    }
                }
                //when user select Detaills from dropdown
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Topsheet then click Approve');", true);
                }

            //}
            //catch { File.Delete(filePathForXML); }

        }

        private void CreateSalesXml(string strBillDate, string strBilSubmitteddate, string strName, string strstart, string strEndTime, string strMovDuration, string strFromAdress
           , string strMoveArea, string strToAddress, string strNighstay, string strStartMilage, string strEndMilage, string strConsumedKM, string strRemarks
            , string strQntPetrol, string strCostPetrol, string strQntOcten, string strCostOcten, string strQntCarBonNitr, string strCostCarbonNit, string strQntLubricant
            , string strCostLubricant, string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strBoatFare, string strAirplane, string strOtherVhFare
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
                                , strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare
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
                                , strBusFareTaka, strRickFare, strCNGFare, strTrainFare, strBoatFare
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
                                , string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, string strBoatFare
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
            XmlAttribute STRBOATFARE = doc.CreateAttribute("strBoatFare");
            STRBOATFARE.Value = strBoatFare;


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
            node.Attributes.Append(STRBOATFARE);



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

        protected void CompleteAttachment_Click(object sender, EventArgs e)
        {
            try
            {

                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                string intEnrol = searchKey[0].ToString();
                int enrol1 = int.Parse(intEnrol);
                Session["enrol1"] = enrol1;
                string dteDate = searchKey[1].ToString();
                DateTime strDate = DateTime.Parse(dteDate.ToString());
                Session["Date"] = strDate;
                string strunit = searchKey[2].ToString();
                int unit = int.Parse(strunit);
                Session["UNIT"] = unit;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('AttachmentCheckingBySupervisor.aspx');", true);
            }

            catch
            {


            }
        }

        protected void grdvForApproveTADAByImmdediatesupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    bool CellValueattach = Convert.ToBoolean(e.Row.Cells[51].Text);




            //    if (CellValueattach == true)
            //    {
            //        e.Row.Cells[1].BackColor = System.Drawing.Color.Green;
            //    }

            //    else { e.Row.Cells[1].BackColor = System.Drawing.Color.Red; }


            //}
        }

        protected void grdvForApproveTADAByImmdediatesupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}