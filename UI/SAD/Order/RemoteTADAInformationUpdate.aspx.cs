using Flogging.Core;
using GLOBAL_BLL;
using HR_BLL.Global;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTADAInformationUpdate : BasePage
    {
        DeliverySupport objDeliverySupportBLL = new DeliverySupport();
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        decimal petrolcost = 0; decimal octencost = 0; decimal cngcost = 0; decimal lubriantcost = 0;
        decimal busfare = 0; decimal Rickfare = 0; decimal cngfare = 0; decimal trainfare = 0; decimal airplance = 0; decimal othervhfare = 0;
        decimal mntcost = 0; decimal ferrytol = 0;

        decimal ownda = 0; decimal driverda = 0; decimal ownhotel = 0; decimal driverhotel = 0;
        decimal photocopy = 0; decimal courier = 0; decimal othercost = 0; decimal totalcost = 0;
        int RowIndex;

        string filePathForXML; string alermessageUpdate;

        string xmlString = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        DataTable dt = new DataTable();
        int intTSOEnroll; DateTime dtForm; decimal StartMilage, EndMilage, ConsumedKM; string strRemarks;
        decimal QntPetrol, CostPetrol, QntOcten, CostOcten, QntCarBonNitr, CostCarbonNit, QntLubricant, CostLubricant, BusFareTaka, RickFare, CNGFare, OtherVhFare
            , MntCost, FerryTol, OwnDA, OtherDA, OwnHotel, DriverHotel, Photocopy, Courier, OtherCost, RowTotal;
        int paymentType; int updatecngCreditsupplier1ID; decimal cngCredit1Amount; string cngCredit1Name; int updatecngCredits2id; decimal cngCredit2Amount; string cngCredit2Name; int updateoilCreditsupplier3ID; decimal OilCreditAmount;
        string oilCreditStationName; decimal PersonalMilaqnt, PersonalRate, PersonMlgTotal; int updateby;


        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADAInformationUpdate";
        string stop = "stopping SAD\\Order\\RemoteTADAInformationUpdate";
        protected void Page_Load(object sender, EventArgs e)
        {



            filePathForXML = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteTADAInformationUpdate.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                HiddenUnit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//


            }
            


        }


        
         [WebMethod]
        public static List<string> getemplontadasupervisor(string strSearchKey)
        {
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            List<string> result = new List<string>();
            result = bll.getemployeebaseTADASupervisor(
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), strSearchKey);
            return result;
        }        



        private void showDataForUpdate()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAInformationUpdate TADA Information Update", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    int deptid=  int.Parse( HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                    if (rdbUserOption.SelectedItem.Text == "Own")
                    {
                        int intTSOEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        dt = bll.getTADAApplicantDataForUpdate(dtFromDate, dtToDate, intTSOEnroll);

                        if (dt.Rows.Count > 0)
                        {

                            grdvForUpdateTADABikeCarUser.DataSource = dt;
                            grdvForUpdateTADABikeCarUser.DataBind();

                        }
                        else
                        {


                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                        }
                    }
                    else if (rdbUserOption.SelectedItem.Text == "Other"  )
                    {
                    //if (deptid == 14 || deptid == 3 || deptid == 55 || deptid == 21 || deptid == 234)
                    if (CheckUserByDepartmentId(deptid))
                    {

                            string strSearchKey = txtEmployeeSearch.Text;
                        arrayKey = strSearchKey.Split(delimiterChars);
                        string code = arrayKey[1].ToString();

                        string TSOName = strSearchKey;
                         intTSOEnroll = int.Parse(code);
                         Session["intTSOEnroll"] = intTSOEnroll;

                        dt = bll.getTADAApplicantDataForUpdate(dtFromDate, dtToDate, intTSOEnroll);

                        if (dt.Rows.Count > 0)
                        {

                            grdvForUpdateTADABikeCarUser.DataSource = dt;
                            grdvForUpdateTADABikeCarUser.DataBind();

                        }
                        else
                        {


                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);

                        }
                    }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! You are not permitted');", true); }
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

        private bool CheckUserByDepartmentId(int deptId)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            try
            {
                dt = objDeliverySupportBLL.checkAllowDepatmentForUpdate(deptId);
                if (dt.Rows.Count > 0)
                    flag = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.Message.ToString() + "');", true);
            }
            return flag;
        }

        protected void btnApprTADAFoBikeCarUser_Click(object sender, EventArgs e)
        {
            showDataForUpdate();
        }



        private void calculateRowTotal(int RowIndex)
        {
            string strpetrolcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostPetrolT")).Text;
            if (strpetrolcost == "") { petrolcost = 0; }
            else
                petrolcost = decimal.Parse(strpetrolcost);
            if (petrolcost <= 0)
            {
                petrolcost = 0;
            }
            string stroctencost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostOctenT")).Text;
            if (stroctencost == "") { octencost = 0; }
            else

                octencost = decimal.Parse(stroctencost);
            if (octencost <= 0)
            {
                octencost = 0;
            }

            string strcngcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasT")).Text;
            if (strcngcost == "") { cngcost = 0; }
            else
                cngcost = decimal.Parse(strcngcost);
            if (cngcost <= 0)
            {
                cngcost = 0;
            }

            string strlubriantcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostLubricant")).Text;
            if (strlubriantcost == "") { lubriantcost = 0; }
            else
                lubriantcost = decimal.Parse(strlubriantcost);
            if (lubriantcost <= 0)
            {
                lubriantcost = 0;
            }

            string strbusfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareBusAmountT")).Text;
            if (strbusfare == "") { busfare = 0; }
            else

                busfare = decimal.Parse(strbusfare);
            if (busfare <= 0)
            {
                busfare = 0;
            }

            string strRickfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareRickshawAmountT")).Text;
            if (strRickfare == "") { Rickfare = 0; }
            else
                Rickfare = decimal.Parse(strRickfare);
            if (Rickfare <= 0)
            {
                Rickfare = 0;
            }

            string strcngfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareCNGAmountT")).Text;
            if (strcngfare == "") { cngfare = 0; }
            else
                cngfare = decimal.Parse(strcngfare);
            if (cngfare <= 0)
            {
                cngfare = 0;
            }
            
           

            string strothervhfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountT")).Text;
            if (strothervhfare == "") { othervhfare = 0; }
            else

                othervhfare = decimal.Parse(strothervhfare);
            if (othervhfare <= 0)
            {
                othervhfare = 0;
            }

            string strmntcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceT")).Text;
            if (strmntcost == "") { mntcost = 0; }
            else
                mntcost = decimal.Parse(strmntcost);
            if (mntcost <= 0)
            {
                mntcost = 0;
            }
            string strferrytol = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFeryTollCostT")).Text;
            if (strferrytol == "") { ferrytol = 0; }
            else

                ferrytol = decimal.Parse(strferrytol);
            if (ferrytol <= 0)
            {
                ferrytol = 0;
            }

            string strownda = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDAAmountT")).Text;
            if (strownda == "") { ownda = 0; }
            else
                ownda = decimal.Parse(strownda);
            if (ownda <= 0)
            {
                ownda = 0;
            }

            string strdriverda = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverDACostT")).Text;
            if (strdriverda == "") { driverda = 0; }
            else

                driverda = decimal.Parse(strdriverda);
            if (driverda <= 0)
            {
                driverda = 0;
            }
            string strownhotel = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecHotelBillAmountT")).Text;
            if (strownhotel == "") { ownhotel = 0; }
            else

                ownhotel = decimal.Parse(strownhotel);
            if (ownhotel <= 0)
            {
                ownhotel = 0;
            }

            string strdriverhotel = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountT")).Text;
            if (strdriverhotel == "") { driverhotel = 0; }
            else



                driverhotel = decimal.Parse(strdriverhotel);
            if (driverhotel <= 0)
            {
                driverhotel = 0;
            }

            string strphotocopy = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecPhotoCopyCostT")).Text;
            if (strphotocopy == "") { photocopy = 0; }
            else

                photocopy = decimal.Parse(strphotocopy);
            if (photocopy <= 0)
            {
                photocopy = 0;
            }



            string strc = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCourierCostT")).Text;
            if (strc == "") { courier = 0; }
            else
            {
                courier = decimal.Parse(strc);
                if (courier <= 0)
                { courier = 0; }
            }
            string strOthBill = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecOtherBillAmountT")).Text;
            if
                (strOthBill == "") { othercost = 0; }

            else

                othercost = decimal.Parse(strOthBill);
            if (othercost <= 0)
            {
                othercost = 0;
            }

            string strtotalcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text;
            if (strtotalcost == "") { totalcost = 0; }
            else



                totalcost = decimal.Parse(strtotalcost);
            if (totalcost <= 0)
            {
                totalcost = 0;
            }

            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text =

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


            int cnt = grdvForUpdateTADABikeCarUser.Rows.Count;
            for (int RowIndex = 0; RowIndex < cnt - 1; RowIndex++)
            {

                string strpetrolcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostPetrolT")).Text;
                if (strpetrolcost == "") { petrolcost = 0; }
                else
                    petrolcost = petrolcost + decimal.Parse(strpetrolcost);

                string stroctencost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostOctenT")).Text;
                if (stroctencost == "") { octencost = 0; }
                else
                    octencost = octencost + decimal.Parse(stroctencost);

                string strcngcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostCarbonNitGasT")).Text;
                if (strcngcost == "") { cngcost = 0; }
                else
                    cngcost = cngcost + decimal.Parse(strcngcost);

                string strlubriantcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostLubricant")).Text;
                if (strlubriantcost == "") { lubriantcost = 0; }
                else
                    lubriantcost = lubriantcost + decimal.Parse(strlubriantcost);

                string strbusfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareBusAmountT")).Text;
                if (strbusfare == "") { busfare = 0; }
                else
                    busfare = busfare + decimal.Parse(strbusfare);

                string strRickfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareRickshawAmountT")).Text;
                if (strRickfare == "") { Rickfare = 0; }
                Rickfare = Rickfare + decimal.Parse(strRickfare);

                string strcngfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareCNGAmountT")).Text;
                if (strcngfare == "") { cngfare = 0; }
                else
                    cngfare = cngfare + decimal.Parse(strcngfare);

               

                string strothervhfare = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFareOtherVheicleAmountT")).Text;
                if (strothervhfare == "") { othervhfare = 0; }
                else
                    othervhfare = othervhfare + decimal.Parse(strothervhfare);


                string strmntcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCostAmountMaintenaceT")).Text;
                if (strmntcost == "") { mntcost = 0; }
                else
                    mntcost = mntcost + decimal.Parse(strmntcost);

                string strferrytol = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecFeryTollCostT")).Text;
                if (strferrytol == "") { ferrytol = 0; }
                else

                    ferrytol = ferrytol + decimal.Parse(strferrytol);

                string strownda = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDAAmountT")).Text;
                if (strownda == "") { ownda = 0; }
                else
                    ownda = ownda + decimal.Parse(strownda);

                string strdriverda = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverDACostT")).Text;
                if (strdriverda == "") { driverda = 0; }
                else
                    driverda = driverda + decimal.Parse(strdriverda);

                string strownhotel = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecHotelBillAmountT")).Text;
                if (strownhotel == "") { ownhotel = 0; }
                else

                    ownhotel = ownhotel + decimal.Parse(strownhotel);

                string strdriverhotel = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecDriverHotelBillAmountT")).Text;
                if (strdriverhotel == "") { driverhotel = 0; }
                else
                    driverhotel = driverhotel + decimal.Parse(strdriverhotel);

                string strphotocopy = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecPhotoCopyCostT")).Text;
                if (strphotocopy == "") { photocopy = 0; }
                else
                    photocopy = photocopy + decimal.Parse(strphotocopy);

                string strcourier = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecCourierCostT")).Text;
                if (strcourier == "") { courier = 0; }

                courier = courier + decimal.Parse(strcourier);

                string strothercost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecOtherBillAmountT")).Text;
                if (strothercost == "") { othercost = 0; }
                else
                    othercost = othercost + decimal.Parse(strothercost);

                string strtotalcost = ((TextBox)grdvForUpdateTADABikeCarUser.Rows[RowIndex].FindControl("txtdecRowTotalT")).Text;
                if (strtotalcost == "") { totalcost = 0; }
                else
                    totalcost = totalcost + decimal.Parse(strtotalcost);
            }
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostPetrolT")).Text = petrolcost.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostOctenT")).Text = octencost.ToString();

            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostCarbonNitGasT")).Text = cngcost.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostLubricant")).Text = lubriantcost.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareBusAmountT")).Text = busfare.ToString();

            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareRickshawAmountT")).Text = Rickfare.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareCNGAmountT")).Text = cngfare.ToString();
            
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFareOtherVheicleAmountT")).Text = othervhfare.ToString();

            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCostAmountMaintenaceT")).Text = mntcost.ToString();


            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecFeryTollCostT")).Text = ferrytol.ToString();

            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecDAAmountT")).Text = ownda.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecDriverDACostT")).Text = driverda.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecHotelBillAmountT")).Text = ownhotel.ToString();

            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecDriverHotelBillAmountT")).Text = driverhotel.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecPhotoCopyCostT")).Text = photocopy.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecCourierCostT")).Text = courier.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecOtherBillAmountT")).Text = othercost.ToString();
            ((TextBox)grdvForUpdateTADABikeCarUser.Rows[cnt - 1].FindControl("txtdecRowTotalT")).Text = totalcost.ToString();



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

        protected void txtdecCostLubricant_TextChanged(object sender, EventArgs e)
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



        protected void rdbUserOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvForUpdateTADABikeCarUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                dt = bll.getTADAFuelStationlistforUpdate(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()));
                var ddlCreditFuelStation1 = (DropDownList)e.Row.FindControl("ddlCreditFuelStation1List");
                ddlCreditFuelStation1.DataSource = dt;
                ddlCreditFuelStation1.DataTextField = "strFuelStationName";
                ddlCreditFuelStation1.DataValueField = "intFuelStationID";
                ddlCreditFuelStation1.DataBind();
                ddlCreditFuelStation1.Items.Insert(0, new ListItem("--Select Gas Station 1--", "0"));

                var ddlCreditFuelStation2 = (DropDownList)e.Row.FindControl("ddlCreditFuelStation2List");
                ddlCreditFuelStation2.DataSource = dt;
                ddlCreditFuelStation2.DataTextField = "strFuelStationName";
                ddlCreditFuelStation2.DataValueField = "intFuelStationID";
                ddlCreditFuelStation2.DataBind();
                ddlCreditFuelStation2.Items.Insert(0, new ListItem("--Select Gas Station 2--", "0"));

                var ddlCreditFuelStation3 = (DropDownList)e.Row.FindControl("ddlCreditFuelStation3List");
                ddlCreditFuelStation3.DataSource = dt;
                ddlCreditFuelStation3.DataTextField = "strFuelStationName";
                ddlCreditFuelStation3.DataValueField = "intFuelStationID";
                ddlCreditFuelStation3.DataBind();
                ddlCreditFuelStation3.Items.Insert(0, new ListItem("--Select Gas Station 3--", "0"));

            }

        }



        protected void btnUpdateinf_Click1(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAInformationUpdate TADA Information Update", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                char[] delimiterChars = { ',' };
            string temp = ((Button)sender).CommandArgument.ToString();
            string[] searchKey = temp.Split(delimiterChars);
            string intRowSl = searchKey[0].ToString();
            int rowsl = int.Parse(intRowSl);

            string intPKIDtbl = searchKey[1].ToString();
            int intID = int.Parse(intPKIDtbl);

            if (rdbUserOption.SelectedItem.Text == "Own")
            { intTSOEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()); }
            else
            {
                intTSOEnroll = int.Parse(Session["intTSOEnroll"].ToString());
            }

            //intTSOEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int totalCount = grdvForUpdateTADABikeCarUser.Rows.Cast<GridViewRow>()
                 .Count(r => ((CheckBox)r.FindControl("chkbx")).Checked);
            if (totalCount > 0)
            {
                if (totalCount < 2)
                {
                    for (int rowIndex = 0; rowIndex < grdvForUpdateTADABikeCarUser.Rows.Count; rowIndex++)
                    {
                        bool ysnChecked = ((CheckBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[0].Controls[0]).Checked;
                        if (ysnChecked)
                        {
                            try
                            {

                                TextBox txtintid = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[1].FindControl("txtPkID");
                                TextBox txtdteFromdateNoBikeDet = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[2].FindControl("dteFromdateNoBikeDet");
                                TextBox txtstrNameT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[3].FindControl("strNamNoBikeDet");
                                TextBox txtdecStartMilageT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[4].FindControl("txtdecStartMilageT");
                                TextBox txtdecEndMilageT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[5].FindControl("txtdecEndMilageT");
                                TextBox txtdecConsumedKmT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[6].FindControl("txtdecConsumedKmT");
                                TextBox txtstrSupportingNoT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[7].FindControl("txtstrSupportingNoT");
                                TextBox txtdecQntPetrolT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[8].FindControl("txtdecQntPetrolT");
                                TextBox txtdecCostPetrolT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[9].FindControl("txtdecCostPetrolT");
                                TextBox txtdecQntOctenT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[10].FindControl("txtdecQntOctenT");
                                TextBox txtdecCostOctenT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[11].FindControl("txtdecCostOctenT");
                                TextBox txtdecQntCarbonNitGasT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[12].FindControl("txtdecQntCarbonNitGasT");
                                TextBox txtdecCostCarbonNitGasT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[13].FindControl("txtdecCostCarbonNitGasT");
                                TextBox txtdecQntLubricant = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[14].FindControl("txtdecQntLubricant");
                                TextBox txtdecCostLubricant = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[15].FindControl("txtdecCostLubricant");
                                TextBox txtdecFareBusAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[16].FindControl("txtdecFareBusAmountT");
                                TextBox txtdecFareRickshawAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[17].FindControl("txtdecFareRickshawAmountT");
                                TextBox txtdecFareCNGAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[18].FindControl("txtdecFareCNGAmountT");
                                TextBox txtdecFareOtherVheicleAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[19].FindControl("txtdecFareOtherVheicleAmountT");
                                TextBox txtdecCostAmountMaintenaceT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[20].FindControl("txtdecCostAmountMaintenaceT");
                                TextBox txtdecFeryTollCostT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[21].FindControl("txtdecFeryTollCostT");
                                TextBox txtdecDAAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[22].FindControl("txtdecDAAmountT");
                                TextBox txtdecDriverDACostT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[23].FindControl("txtdecDriverDACostT");
                                TextBox txtdecHotelBillAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[24].FindControl("txtdecHotelBillAmountT");
                                TextBox txtdecDriverHotelBillAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[25].FindControl("txtdecDriverHotelBillAmountT");
                                TextBox txtdecPhotoCopyCostT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[26].FindControl("txtdecPhotoCopyCostT");
                                TextBox txtdecCourierCostT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[27].FindControl("txtdecCourierCostT");
                                TextBox txtdecOtherBillAmountT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[28].FindControl("txtdecOtherBillAmountT");
                                TextBox txtdecRowTotalT = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[29].FindControl("txtdecRowTotalT");
                                TextBox txtSl = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[30].FindControl("txtRowSl");
                                TextBox txtdecCNGCredit1Amount = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[31].FindControl("txtdecSupplierCNG");
                                string txtstrCreditSupplier1nAME = ((DropDownList)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[32].FindControl("ddlCreditFuelStation1List")).SelectedItem.Text.ToString();
                                string updatecngCreditsupplierONEID = ((DropDownList)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[32].FindControl("ddlCreditFuelStation1List")).SelectedValue.ToString();
                                TextBox txtdecCNGCredit2Amount = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[34].FindControl("txtCNGCredit2AMNT");
                                string txtstrCreditSupplier2nAME = ((DropDownList)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[35].FindControl("ddlCreditFuelStation2List")).SelectedItem.Text.ToString();
                                string updatecngCreditsupplierTWOID = ((DropDownList)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[35].FindControl("ddlCreditFuelStation2List")).SelectedValue.ToString();
                                TextBox txtdecOilCreditAmount = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[37].FindControl("txtOilCreditAmnt");
                                string txtdecOilCreditStation = ((DropDownList)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[38].FindControl("ddlCreditFuelStation3List")).SelectedItem.Text.ToString();
                                string updateOilCreditsupplier3ID = ((DropDownList)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[38].FindControl("ddlCreditFuelStation3List")).SelectedValue.ToString();
                                TextBox txtdecPersonalMilage = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[40].FindControl("txtdecPersonalMilage");
                                TextBox txtdecMlgRate = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[41].FindControl("txtdecMlgRate");
                                TextBox txtdecPersonalTotalcost = (TextBox)grdvForUpdateTADABikeCarUser.Rows[rowIndex].Cells[42].FindControl("txtdecPersonalTotalcost");
                                //intTSOEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                                string strBillDate = txtdteFromdateNoBikeDet.Text;
                                dtForm = DateTime.Parse(strBillDate.ToString());
                                StartMilage = decimal.Parse(txtdecStartMilageT.Text);
                                EndMilage = decimal.Parse(txtdecEndMilageT.Text);
                                ConsumedKM = decimal.Parse(txtdecConsumedKmT.Text);
                                strRemarks = txtstrSupportingNoT.Text;
                                QntPetrol = decimal.Parse(txtdecQntPetrolT.Text);
                                CostPetrol = decimal.Parse(txtdecCostPetrolT.Text);
                                QntOcten = decimal.Parse(txtdecQntOctenT.Text);
                                CostOcten = decimal.Parse(txtdecCostOctenT.Text);
                                QntCarBonNitr = decimal.Parse(txtdecQntCarbonNitGasT.Text);
                                CostCarbonNit = decimal.Parse(txtdecCostCarbonNitGasT.Text);
                                QntLubricant = decimal.Parse(txtdecQntLubricant.Text);
                                CostLubricant = decimal.Parse(txtdecCostLubricant.Text);
                                BusFareTaka = decimal.Parse(txtdecFareBusAmountT.Text);
                                RickFare = decimal.Parse(txtdecFareRickshawAmountT.Text);
                                CNGFare = decimal.Parse(txtdecFareCNGAmountT.Text);
                                OtherVhFare = decimal.Parse(txtdecFareOtherVheicleAmountT.Text);
                                MntCost = decimal.Parse(txtdecCostAmountMaintenaceT.Text);
                                FerryTol = decimal.Parse(txtdecFeryTollCostT.Text);
                                OwnDA = decimal.Parse(txtdecDAAmountT.Text);
                                OtherDA = decimal.Parse(txtdecDriverDACostT.Text);
                                OwnHotel = decimal.Parse(txtdecHotelBillAmountT.Text);
                                DriverHotel = decimal.Parse(txtdecDriverHotelBillAmountT.Text);
                                Photocopy = decimal.Parse(txtdecPhotoCopyCostT.Text);
                                Courier = decimal.Parse(txtdecCourierCostT.Text);
                                OtherCost = decimal.Parse(txtdecOtherBillAmountT.Text);
                                RowTotal = decimal.Parse(txtdecRowTotalT.Text);
                                paymentType = int.Parse("0");
                                cngCredit1Amount = decimal.Parse(txtdecCNGCredit1Amount.Text);
                                cngCredit1Name = txtstrCreditSupplier1nAME;
                                updatecngCreditsupplier1ID = int.Parse(updatecngCreditsupplierONEID.ToString());
                                cngCredit2Amount = decimal.Parse(txtdecCNGCredit2Amount.Text);
                                cngCredit2Name = txtstrCreditSupplier2nAME;
                                updatecngCredits2id = int.Parse(updatecngCreditsupplierTWOID.ToString());
                                OilCreditAmount = decimal.Parse(txtdecOilCreditAmount.Text);

                                oilCreditStationName = txtdecOilCreditStation;
                                updateoilCreditsupplier3ID = int.Parse(updateOilCreditsupplier3ID.ToString());

                                PersonalMilaqnt = decimal.Parse(txtdecPersonalMilage.Text);
                                PersonalRate = decimal.Parse(txtdecMlgRate.Text);
                                PersonMlgTotal = decimal.Parse(txtdecPersonalTotalcost.Text);
                                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                                updateby = int.Parse(hdnAreamanagerEnrol.Value.ToString());

                                alermessageUpdate = bll.updateRemoteTADAInfo(intID, intTSOEnroll, dtForm, StartMilage, EndMilage, ConsumedKM, strRemarks, QntPetrol
                                 , CostPetrol, QntOcten, CostOcten, QntCarBonNitr, CostCarbonNit, QntLubricant, CostLubricant, BusFareTaka, RickFare, CNGFare, OtherVhFare
                                 , MntCost, FerryTol, OwnDA, OtherDA, OwnHotel, DriverHotel, Photocopy, Courier, OtherCost, RowTotal, rowsl, paymentType
                                 , updatecngCreditsupplier1ID, cngCredit1Amount, cngCredit1Name, updatecngCredits2id, cngCredit2Amount, cngCredit2Name, updateoilCreditsupplier3ID, OilCreditAmount, oilCreditStationName
                                 , PersonalMilaqnt, PersonalRate, PersonMlgTotal, updateby);

                                //showDataForUpdate();
                                break;


                            }


                            catch
                            {

                            }
                        }

                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully update your information ');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('only check one row ');", true);
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('For Bill Update You must seleck one check box at left side of the row. ');", true);
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
    }

   }


                                
       

        


    
