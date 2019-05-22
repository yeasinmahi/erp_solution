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
    public partial class RemoteTADAAprvByAuditSecondV : BasePage
    {
        string filePathForXMLHRBIKECAR;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        int enr;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADAAprvByAuditSecondV";
        string stop = "stopping SAD\\Order\\RemoteTADAAprvByAuditSecondV";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            filePathForXMLHRBIKECAR = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaApproveAuditTopsheet.xml");
            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXMLHRBIKECAR); }
                catch { }
                ////-----**----------//


            }


        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAAprvByAuditSecondV TADA Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int rptType = int.Parse(drdlReportType.SelectedValue.ToString());
            int areaid = int.Parse(drdlArea.SelectedValue.ToString());
            int ApplicantCatg = int.Parse(ddlUserType.SelectedValue.ToString());
            int unit = int.Parse(drdlUnit.SelectedValue.ToString());
            if (rptType == 1 || rptType == 14)
            {
                
                try
                {
                  
                   
                    dt = bll.getTADAReportForAuditChkVerson2(dteFromDate, dteToDate, unit, rptType, areaid, ApplicantCatg);
                    if (dt.Rows.Count > 0)
                    {
                       
                        grdvForAuditBillChecking.DataSource = dt;
                        grdvForAuditBillChecking.DataBind();
                    }
                }

                catch
                {
                    //
                }

               
            }

           
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data againist your query');", true);
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
        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdvForAuditBillChecking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void grdvForAuditBillChecking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
               

            }
        }

        decimal petrolcost = 0; decimal octencost = 0; decimal cngcost = 0; decimal lubriantcost = 0;
        decimal busfare = 0; decimal Rickfare = 0; decimal cngfare = 0; decimal trainfare = 0;   decimal boat=0; decimal airplance = 0; decimal othervhfare = 0;
        decimal mntcost = 0; decimal ferrytol = 0;

        decimal ownda = 0; decimal driverda = 0; decimal ownhotel = 0; decimal driverhotel = 0;
        decimal photocopy = 0; decimal courier = 0; decimal othercost = 0; decimal totalcost = 0; decimal cashcnggas = 0;
        decimal personalMlagCost = 0;decimal advanceAmount = 0;
        int RowIndex;

        private void calculateRowTotal(int RowIndex)
        {


           

            string totalfffCheck = "0";
           
                string strbusfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtbusM")).Text;
                if (strbusfare == "") { busfare = 0; }
                else

                    busfare = decimal.Parse(strbusfare);
                if (busfare <= 0)
                {
                    busfare = 0;
                }

                string strRickfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("rickM")).Text;
                if (strRickfare == "") { Rickfare = 0; }
                else
                    Rickfare = decimal.Parse(strRickfare);
                if (Rickfare <= 0)
                {
                    Rickfare = 0;
                }

                string strcngfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtcngM")).Text;
                if (strcngfare == "") { cngfare = 0; }
                else
                    cngfare = decimal.Parse(strcngfare);
                if (cngfare <= 0)
                {
                    cngfare = 0;
                }
                string strtrainfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txttrainM")).Text;
                if (strtrainfare == "") { trainfare = 0; }
                else

                    trainfare = decimal.Parse(strtrainfare);
                if (trainfare <= 0)
                {
                    trainfare = 0;
                }

            string strBoat = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtboatM")).Text;
            if (strBoat == "") { boat = 0; }
            else
                boat = boat + decimal.Parse(strBoat);

            if (boat <= 0)
            {
                boat = 0;
            }


            string strairplance = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtairM")).Text;
                if (strairplance == "") { airplance = 0; }
                else

                    airplance = decimal.Parse(strairplance);
                if (airplance <= 0)
                {
                    airplance = 0;
                }

                string strothervhfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtothvhM")).Text;
                if (strothervhfare == "") { othervhfare = 0; }
                else

                    othervhfare = decimal.Parse(strothervhfare);
                if (othervhfare <= 0)
                {
                    othervhfare = 0;
                }

                string strmntcost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtmntcM")).Text;
                if (strmntcost == "") { mntcost = 0; }
                else
                    mntcost = decimal.Parse(strmntcost);
                if (mntcost <= 0)
                {
                    mntcost = 0;
                }
                string strferrytol = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtferrytM")).Text;
                if (strferrytol == "") { ferrytol = 0; }
                else

                    ferrytol = decimal.Parse(strferrytol);
                if (ferrytol <= 0)
                {
                    ferrytol = 0;
                }

                string strownda = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtowndaM")).Text;
                if (strownda == "") { ownda = 0; }
                else
                    ownda = decimal.Parse(strownda);
                if (ownda <= 0)
                {
                    ownda = 0;
                }

                string strdriverda = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtdrvDAM")).Text;
                if (strdriverda == "") { driverda = 0; }
                else

                    driverda = decimal.Parse(strdriverda);
                if (driverda <= 0)
                {
                    driverda = 0;
                }
                string strownhotel = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtownhotM")).Text;
                if (strownhotel == "") { ownhotel = 0; }
                else

                    ownhotel = decimal.Parse(strownhotel);
                if (ownhotel <= 0)
                {
                    ownhotel = 0;
                }

                string strdriverhotel = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtdrvhotelM")).Text;
                if (strdriverhotel == "") { driverhotel = 0; }
                else



                    driverhotel = decimal.Parse(strdriverhotel);
                if (driverhotel <= 0)
                {
                    driverhotel = 0;
                }

                string strphotocopy = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtphotcoM")).Text;
                if (strphotocopy == "") { photocopy = 0; }
                else

                    photocopy = decimal.Parse(strphotocopy);
                if (photocopy <= 0)
                {
                    photocopy = 0;
                }



                string strc = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtcourM")).Text;
                if (strc == "") { courier = 0; }
                else
                {
                    courier = decimal.Parse(strc);
                    if (courier <= 0)
                    { courier = 0; }
                }
                string strOthBill = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtdecOtherbill")).Text;
                if
                    (strOthBill == "")
                { othercost = 0; }

                else

                    othercost = decimal.Parse(strOthBill);
                if (othercost <= 0)
                {
                    othercost = 0;
                }


                string strGASAndOil=((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtcashOilcng")).Text;
                if (strGASAndOil == "") { cashcnggas = 0; }
                else
                    cashcnggas = decimal.Parse(strGASAndOil);
                if (cashcnggas <= 0)
                {
                    cashcnggas = 0;
                }

            string strPersonalMlgCost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtPersonalMlgCost")).Text;
            if (strPersonalMlgCost == "") { personalMlagCost = 0; }
            else
                personalMlagCost = decimal.Parse(strPersonalMlgCost);
            if (personalMlagCost <= 0)
            {
                personalMlagCost = 0;
            }


            string strAdvanceAmount = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtAdvanceAmount")).Text;
            if (strAdvanceAmount == "") { advanceAmount = 0; }
            else
                advanceAmount = decimal.Parse(strAdvanceAmount);
            if (advanceAmount <= 0)
            {
                advanceAmount = 0;
            }




            ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtCMHR")).Text =

          (petrolcost + octencost + cngcost + lubriantcost + busfare + Rickfare + cngfare + trainfare + boat+ airplance + othervhfare + mntcost
          + ferrytol + ownda + driverda + ownhotel + driverhotel + photocopy + courier + othercost + cashcnggas - personalMlagCost ).ToString();
     }

        private void CalculateGrandTotal()
        {
            petrolcost = 0; octencost = 0; cngcost = 0; lubriantcost = 0;
            busfare = 0; Rickfare = 0; cngfare = 0; trainfare = 0; boat = 0; airplance = 0; othervhfare = 0;
            mntcost = 0; ferrytol = 0;

            ownda = 0; driverda = 0; ownhotel = 0; driverhotel = 0;
            photocopy = 0; courier = 0; othercost = 0; totalcost = 0; cashcnggas = 0;
             personalMlagCost = 0;  advanceAmount = 0;

            int cnt = grdvForAuditBillChecking.Rows.Count;
            for (int RowIndex = 0; RowIndex < cnt - 1; RowIndex++)
            {

                string strpetrolcost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtfuelM")).Text;
                if (strpetrolcost == "") { petrolcost = 0; }
                else
                    petrolcost = petrolcost + decimal.Parse(strpetrolcost);


                string strbusfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtbusM")).Text;
                if (strbusfare == "") { busfare = 0; }
                else
                    busfare = busfare + decimal.Parse(strbusfare);

                string strRickfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("rickM")).Text;
                if (strRickfare == "") { Rickfare = 0; }
                Rickfare = Rickfare + decimal.Parse(strRickfare);

                string strcngfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtcngM")).Text;
                if (strcngfare == "") { cngfare = 0; }
                else
                    cngfare = cngfare + decimal.Parse(strcngfare);

                string strtrainfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txttrainM")).Text;
                if (strtrainfare == "") { trainfare = 0; }
                else
                    trainfare = trainfare + decimal.Parse(strtrainfare);

                string strBoat = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtboatM")).Text;
                if (strBoat == "") { boat = 0; }
                else
                    boat = boat + decimal.Parse(strBoat);

                string strairplance = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtairM")).Text;
                if (strairplance == "") { airplance = 0; }
                else
                    airplance = airplance + decimal.Parse(strairplance);

                string strothervhfare = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtothvhM")).Text;
                if (strothervhfare == "") { othervhfare = 0; }
                else
                    othervhfare = othervhfare + decimal.Parse(strothervhfare);


                string strmntcost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtmntcM")).Text;
                if (strmntcost == "") { mntcost = 0; }
                else
                    mntcost = mntcost + decimal.Parse(strmntcost);

                string strferrytol = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtferrytM")).Text;
                if (strferrytol == "") { ferrytol = 0; }
                else

                    ferrytol = ferrytol + decimal.Parse(strferrytol);

                string strownda = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtowndaM")).Text;
                if (strownda == "") { ownda = 0; }
                else
                    ownda = ownda + decimal.Parse(strownda);

                string strdriverda = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtdrvDAM")).Text;
                if (strdriverda == "") { driverda = 0; }
                else
                    driverda = driverda + decimal.Parse(strdriverda);

                string strownhotel = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtownhotM")).Text;
                if (strownhotel == "") { ownhotel = 0; }
                else

                    ownhotel = ownhotel + decimal.Parse(strownhotel);

                string strdriverhotel = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtdrvhotelM")).Text;
                if (strdriverhotel == "") { driverhotel = 0; }
                else
                    driverhotel = driverhotel + decimal.Parse(strdriverhotel);

                string strphotocopy = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtphotcoM")).Text;
                if (strphotocopy == "") { photocopy = 0; }
                else
                    photocopy = photocopy + decimal.Parse(strphotocopy);

                string strcourier = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtcourM")).Text;
                if (strcourier == "") { courier = 0; }

                courier = courier + decimal.Parse(strcourier);

                string strothercost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtdecOtherbill")).Text;
                if (strothercost == "") { othercost = 0; }
                else
                    othercost = othercost + decimal.Parse(strothercost);


                string strGASAndOil = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtcashOilcng")).Text;
                if (strGASAndOil == "") { cashcnggas = 0; }
                else
                    cashcnggas = cashcnggas+ decimal.Parse(strGASAndOil);


                string strPersonalMlgCost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtPersonalMlgCost")).Text;
                if (strPersonalMlgCost == "") { personalMlagCost = 0; }
                else
                    personalMlagCost = personalMlagCost + decimal.Parse(strPersonalMlgCost);


                string strAdvanceAmount = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtAdvanceAmount")).Text;
                if (strAdvanceAmount == "") { advanceAmount = 0; }
                else
                    advanceAmount = decimal.Parse(strAdvanceAmount);

              



                string strtotalcost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtCMHR")).Text;
                if (strtotalcost == "") { totalcost = 0; }
                else
                { totalcost = totalcost + decimal.Parse(strtotalcost); }
                    
            }
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtfuelM")).Text = petrolcost.ToString();
          
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtbusM")).Text = busfare.ToString();

            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("rickM")).Text = Rickfare.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtcngM")).Text = cngfare.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txttrainM")).Text = trainfare.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtairM")).Text = airplance.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtothvhM")).Text = othervhfare.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtmntcM")).Text = mntcost.ToString();
           ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtferrytM")).Text = ferrytol.ToString();
           ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtowndaM")).Text = ownda.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtdrvDAM")).Text = driverda.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtownhotM")).Text = ownhotel.ToString();
           ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtdrvhotelM")).Text = driverhotel.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtphotcoM")).Text = photocopy.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtcourM")).Text = courier.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtdecOtherbill")).Text = othercost.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtcashOilcng")).Text = cashcnggas.ToString();

            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtPersonalMlgCost")).Text = personalMlagCost.ToString();
            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtAdvanceAmount")).Text = advanceAmount.ToString();

            ((TextBox)grdvForAuditBillChecking.Rows[cnt - 1].FindControl("txtCMHR")).Text = totalcost.ToString();



        }

        protected void txtdecOtherbill_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtferrytM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtmntcM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtcourM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtphotcoM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtothvhM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtdecCostLubricantBikeCar_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtboatM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txttrainM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtcngM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void rickM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtbusM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtdrvhotelM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtownhotM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtdrvDAM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtowndaM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void btnDocDownload_Click(object sender, EventArgs e)
        {

        }
        protected void btnTopsheetforAudit_Click(object sender, EventArgs e)
        {
           
        }

        protected void Complete_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 enrol1 = int.Parse(searchKey[0].ToString());
                Session["enrol1"] = enrol1;
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                string strSearchKey = txtFullName.Text;
                string strDate = dteFromDate.ToString();
                Session["Date"] = strDate;
                DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                string strTodate = dteTodate.ToString();
                Session["DateTodate"] = strTodate;
                int unit = int.Parse(drdlUnit.SelectedValue.ToString());
                Session["UNIT"] = unit;
                int ReportType = int.Parse(drdlReportType.SelectedValue.ToString());
                Session["REPORTTYPE"] = ReportType;
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration();", true);


            }
            catch { }


        }

        protected void txtairM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtCMHR_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtfuelM_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtcashOilcng_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void txtPersonalMlgCost_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }

        protected void txtAdvanceAmount_TextChanged(object sender, EventArgs e)
        {
            RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            calculateRowTotal(RowIndex);
            CalculateGrandTotal();
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADAAprvByAuditSecondV TaDa Approve ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
            int intBillApplicantTypeid = int.Parse(ddlUserType.SelectedValue.ToString());
            int areaid = int.Parse(drdlArea.SelectedValue.ToString());
            int deptid =int.Parse ( HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
            bool ysnChecked;
            if (deptid == 11  || deptid == 270)
            {
                if (rptTypeid == 1)
                {

                    if (grdvForAuditBillChecking.Rows.Count > 0)
                    {
                        for (int rowIndex = 0; rowIndex < grdvForAuditBillChecking.Rows.Count - 1; rowIndex++)
                        {
                            //ysnChecked = ((CheckBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[35].Controls[0]).Checked;
                            ysnChecked = ((CheckBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[0].Controls[0]).Checked;
                            if (ysnChecked)
                            {
                                TextBox txtstrNamNoBikeDet = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[4].FindControl("txtstrEmployeename");
                                TextBox txtLMAudit = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[5].FindControl("txtLMAudit");
                                TextBox txtidealm = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[8].FindControl("txtidealm");
                                TextBox txtConsumeMilage = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[9].FindControl("txtconskmM");
                                TextBox txtqntM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[10].FindControl("txtqntM");
                                TextBox txtfuelM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[11].FindControl("txtfuelM");
                                TextBox txtPrsnt = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[13].FindControl("txtPrsnt");
                                TextBox txtleave = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[14].FindControl("txtleave");
                                TextBox txtowndaM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[15].FindControl("txtowndaM");
                                TextBox txtdrvDAM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[16].FindControl("txtdrvDAM");
                                TextBox txtownhotM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[17].FindControl("txtownhotM");
                                TextBox txtdrvhotelM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[18].FindControl("txtdrvhotelM");
                                TextBox txtbusM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[19].FindControl("txtbusM");
                                TextBox rickM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[20].FindControl("rickM");
                                TextBox txtcngM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[21].FindControl("txtcngM");
                                TextBox txttrainM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[22].FindControl("txttrainM");
                                TextBox txtboatM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[23].FindControl("txtboatM");
                                TextBox txtairM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[24].FindControl("txtairM");
                                TextBox txtothvhM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[25].FindControl("txtothvhM");
                                TextBox txtphotcoM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[26].FindControl("txtphotcoM");
                                TextBox txtcourM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[27].FindControl("txtcourM");
                                TextBox txtmntcM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[28].FindControl("txtmntcM");
                                TextBox txtferrytM = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[29].FindControl("txtferrytM");
                                TextBox txtdecOtherbill = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[30].FindControl("txtdecOtherbill");
                                TextBox txtCMHR = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[7].FindControl("txtCMHR");

                                TextBox txtcashOilcng = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[31].FindControl("txtcashOilcng");
                                TextBox txtPersonalMlgCost = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[32].FindControl("txtPersonalMlgCost");
                                TextBox txtAdvanceAmount = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[33].FindControl("txtAdvanceAmount");



                                TextBox txtApplicantEnrol = (TextBox)grdvForAuditBillChecking.Rows[rowIndex].Cells[2].FindControl("txtintEmployeeid");


                                string strName = txtstrNamNoBikeDet.Text;
                                string lmAudit = txtLMAudit.Text;
                                string idealMilage = txtidealm.Text;
                                string strConsumedKM = txtConsumeMilage.Text;
                                string strFuelQntTotal = txtqntM.Text;
                                string strFuelCostTotal = txtfuelM.Text;
                                string absentday = txtleave.Text;
                                string presentday = txtPrsnt.Text;
                                string strOwnDA = txtowndaM.Text;
                                string strOtherDA = txtdrvDAM.Text;
                                string strOwnHotel = txtownhotM.Text;
                                string strDriverHotel = txtdrvhotelM.Text;
                                string strBusFareTaka = txtbusM.Text;
                                string strRickFare = rickM.Text;
                                string strCNGFare = txtcngM.Text;
                                string strTrainFare = txttrainM.Text;
                                string strAirplane = txtairM.Text;
                                string boat = txtboatM.Text;
                                string strOtherVhFare = txtothvhM.Text;
                                string strPhotocopy = txtphotcoM.Text;
                                string strCourier = txtcourM.Text;
                                string strMntCost = txtmntcM.Text;
                                string strFerryTol = txtferrytM.Text;
                                string strOtherCost = txtdecOtherbill.Text;
                                string strCashOilgas = txtcashOilcng.Text;
                                string strPersonalMlgCost = txtPersonalMlgCost.Text;
                                string strAdvanceAmount = txtAdvanceAmount.Text;



                                string strRowTotal = txtCMHR.Text;
                                string strApplicantEnrolid = txtApplicantEnrol.Text;

                                CreateSalesXmlAuditTopSheetApprove(strName, lmAudit, idealMilage, strConsumedKM,
                                                                   strFuelQntTotal, strFuelCostTotal, presentday, absentday,
                                                                   strOwnDA, strOtherDA, strOwnHotel, strDriverHotel,
                                                                   strBusFareTaka, strRickFare, strCNGFare, strTrainFare,
                                                                   strAirplane, boat, strOtherVhFare, strPhotocopy
                                                                  , strCourier, strMntCost, strFerryTol, strOtherCost
                                                                   , strCashOilgas, strPersonalMlgCost, strAdvanceAmount
                                                                  , strRowTotal, strApplicantEnrolid);
                            }

                        }
                        #region ------------ Insert into dataBase -----------


                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                        hdnAreamanagerEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                        hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                        HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                        Int32 Approverenroll = Convert.ToInt32(hdnAreamanagerEnrol.Value);
                        int area = int.Parse(drdlArea.SelectedValue.ToString());
                        int unit = int.Parse(drdlUnit.SelectedValue.ToString());
                        int intApplicantCatge = int.Parse(ddlUserType.SelectedValue.ToString());
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLHRBIKECAR);
                        XmlNode dSftTm = doc.SelectSingleNode("RemotetadaApproveAuditTopsheet");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<RemotetadaApproveAuditTopsheet>" + xmlString + "</RemotetadaApproveAuditTopsheet>";
                        string message = bll.tadaInsertByAuditFromTopsheetV2(xmlString, Approverenroll, dteFromDate, dteTodate, intApplicantCatge, unit, area);
                        File.Delete(filePathForXMLHRBIKECAR);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        #endregion ------------ Insertion End ----------------

                    }
                    //grdvForAuditBillChecking.DataSource = "";
                    grdvForAuditBillChecking.DataBind();
                    //File.Delete(filePathForXMLHRBIKECAR);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  You are not permitted for Approve');", true);
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
        

        private void CreateSalesXmlAuditTopSheetApprove( string strName,  string lmAudit, string idealMilage, string strConsumedKM, 
                                                         string strFuelQntTotal, string strFuelCostTotal, string presentday, string absentday, 
                                                          string strOwnDA, string strOtherDA, string strOwnHotel, string strDriverHotel,
                                                          string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare, 
                                                          string strAirplane, string boat,string strOtherVhFare , string strPhotocopy
                                                         , string strCourier,   string strMntCost, string strFerryTol,  string strOtherCost
                                                          , string strCashOilgas, string strPersonalMlgCost, string strAdvanceAmount

                                                          ,string strRowTotal  , string strApplicantEnrolid
           )
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLHRBIKECAR))
            {
                doc.Load(filePathForXMLHRBIKECAR);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemotetadaApproveAuditTopsheet");
                XmlNode addItem = CreateItemNodeAuditTopSheetApprove(doc, strName, lmAudit, idealMilage, strConsumedKM,
                                                                     strFuelQntTotal, strFuelCostTotal, presentday, absentday,
                                                                       strOwnDA, strOtherDA, strOwnHotel, strDriverHotel,
                                                                       strBusFareTaka, strRickFare, strCNGFare, strTrainFare,
                                                                       strAirplane, boat, strOtherVhFare, strPhotocopy
                                                                       , strCourier, strMntCost, strFerryTol, strOtherCost
                                                                       , strCashOilgas, strPersonalMlgCost, strAdvanceAmount
                                                                       , strRowTotal
                                                                       , strApplicantEnrolid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemotetadaApproveAuditTopsheet");
                XmlNode addItem = CreateItemNodeAuditTopSheetApprove(doc, strName,lmAudit, idealMilage, strConsumedKM,
                                                                     strFuelQntTotal, strFuelCostTotal, presentday, absentday,
                                                                     strOwnDA, strOtherDA, strOwnHotel, strDriverHotel,
                                                                     strBusFareTaka, strRickFare, strCNGFare, strTrainFare, 
                                                                     strAirplane, boat, strOtherVhFare, strPhotocopy
                                                                    , strCourier, strMntCost, strFerryTol, strOtherCost
                                                                   , strCashOilgas, strPersonalMlgCost, strAdvanceAmount
                                                                    , strRowTotal
                                                                    , strApplicantEnrolid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLHRBIKECAR);
        }


        private XmlNode CreateItemNodeAuditTopSheetApprove(XmlDocument doc,
           string strName, string lmAudit, string idealMilage, string strConsumedKM,
           string strFuelQntTotal, string strFuelCostTotal, string presentday, string absentday,
            string strOwnDA, string strOtherDA, string strOwnHotel, string strDriverHotel,
            string strBusFareTaka, string strRickFare, string strCNGFare, string strTrainFare,
            string strAirplane, string boat, string strOtherVhFare , string strPhotocopy
          , string strCourier, string strMntCost, string strFerryTol, string strOtherCost
          , string strCashOilgas, string strPersonalMlgCost, string strAdvanceAmount
          , string strRowTotal
          , string strApplicantEnrolid
                                  )
        {
            XmlNode node = doc.CreateElement("items");

          
            XmlAttribute STRNAME = doc.CreateAttribute("strName");
            STRNAME.Value = strName;
            XmlAttribute LMAUDIT = doc.CreateAttribute("lmAudit");
            LMAUDIT.Value = lmAudit;
            XmlAttribute IDEALMILAGE = doc.CreateAttribute("idealMilage");
            IDEALMILAGE.Value = idealMilage;
            XmlAttribute CONSUMEKM = doc.CreateAttribute("strConsumedKM");
            CONSUMEKM.Value = strConsumedKM;
            XmlAttribute FUELQNT = doc.CreateAttribute("strFuelQntTotal");
            FUELQNT.Value = strFuelQntTotal;
            XmlAttribute FUELCOSTOTAL = doc.CreateAttribute("strFuelCostTotal");
            FUELCOSTOTAL.Value = strFuelCostTotal;
            XmlAttribute PRESENTDAY = doc.CreateAttribute("presentday");
            PRESENTDAY.Value = presentday;
            XmlAttribute ABSENTDAY = doc.CreateAttribute("absentday");
            ABSENTDAY.Value = absentday;
            XmlAttribute OWNDA = doc.CreateAttribute("strOwnDA");
            OWNDA.Value = strOwnDA;
            XmlAttribute OTHEPDA = doc.CreateAttribute("strOtherDA");
            OTHEPDA.Value = strOtherDA;
            XmlAttribute STROWNHOTEL = doc.CreateAttribute("strOwnHotel");
            STROWNHOTEL.Value = strOwnHotel;
            XmlAttribute STRDRIVERHOTEL = doc.CreateAttribute("strDriverHotel");
            STRDRIVERHOTEL.Value = strDriverHotel;
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
            XmlAttribute BOAT = doc.CreateAttribute("boat");
            BOAT.Value = boat;
            XmlAttribute OTHVHF = doc.CreateAttribute("strOtherVhFare");
            OTHVHF.Value = strOtherVhFare;
            XmlAttribute STRPHOTOCOPY = doc.CreateAttribute("strPhotocopy");
            STRPHOTOCOPY.Value = strPhotocopy;
            XmlAttribute STRCOURIER = doc.CreateAttribute("strCourier");
            STRCOURIER.Value = strCourier;
            XmlAttribute STRMNT = doc.CreateAttribute("strMntCost");
            STRMNT.Value = strMntCost;
            XmlAttribute STRFERRY = doc.CreateAttribute("strFerryTol");
            STRFERRY.Value = strFerryTol;
              XmlAttribute OTHCOST = doc.CreateAttribute("strOtherCost");
            OTHCOST.Value = strOtherCost;

            XmlAttribute STRCASHOIL = doc.CreateAttribute("strCashOilgas");
            STRCASHOIL.Value = strCashOilgas;
            XmlAttribute STRPERSONALMLG = doc.CreateAttribute("strPersonalMlgCost");
            STRPERSONALMLG.Value = strPersonalMlgCost;
            XmlAttribute STRADVANCE = doc.CreateAttribute("strAdvanceAmount");
            STRADVANCE.Value = strAdvanceAmount;

            XmlAttribute TOTALCOST = doc.CreateAttribute("strRowTotal");
            TOTALCOST.Value = strRowTotal;
            XmlAttribute APPLICANTENROL = doc.CreateAttribute("strApplicantEnrolid");
            APPLICANTENROL.Value = strApplicantEnrolid;
            node.Attributes.Append(STRNAME);
            node.Attributes.Append(LMAUDIT);
            node.Attributes.Append(IDEALMILAGE);
            node.Attributes.Append(CONSUMEKM);
            node.Attributes.Append(FUELQNT);
            node.Attributes.Append(FUELCOSTOTAL);
            node.Attributes.Append(PRESENTDAY);
            node.Attributes.Append(ABSENTDAY);
            node.Attributes.Append(OWNDA);
            node.Attributes.Append(OTHEPDA);
            node.Attributes.Append(STROWNHOTEL);
            node.Attributes.Append(STRDRIVERHOTEL);
            node.Attributes.Append(STRBUSFARI);
            node.Attributes.Append(STRRICKFAIR);
            node.Attributes.Append(STRCNGFARE);
            node.Attributes.Append(STRTRAINFARE);
            node.Attributes.Append(STRAIRPLANCE);
            node.Attributes.Append(BOAT);
            node.Attributes.Append(OTHVHF);
            node.Attributes.Append(STRPHOTOCOPY);
            node.Attributes.Append(STRCOURIER);
            node.Attributes.Append(STRMNT);
            node.Attributes.Append(STRFERRY);
            node.Attributes.Append(OTHCOST);
            node.Attributes.Append(STRCASHOIL);
            node.Attributes.Append(STRPERSONALMLG);
            node.Attributes.Append(STRADVANCE);
            node.Attributes.Append(TOTALCOST);
            node.Attributes.Append(APPLICANTENROL);
             return node;


        }

       
        

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            grdvForAuditBillChecking.AllowPaging = false;
            SAD_BLL.Customer.Report.ExportClass.Export("TADADetaills.xls", grdvForAuditBillChecking);
        }
    }
}
    
    
    
