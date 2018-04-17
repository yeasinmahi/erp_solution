using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;
using UI.ClassFiles;


namespace UI.SAD.Order
{
    public partial class RemoteTADACarUser : BasePage
    {
        decimal grandtotal = 0;
         string filePathForXML;
         string xmlString = "";
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();


        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetadaInputBikeCarUser.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
              

            }

        }

        protected void btnShowInputForm_Click(object sender, EventArgs e)
        {
            FirstGridViewRow();
          
        }
        private void FirstGridViewRow()
        {


            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));
            dt.Columns.Add(new DataColumn("Col7", typeof(string)));
            dt.Columns.Add(new DataColumn("Col8", typeof(string)));
            dt.Columns.Add(new DataColumn("Col9", typeof(string)));
            dt.Columns.Add(new DataColumn("Col10", typeof(string)));
            dt.Columns.Add(new DataColumn("Col11", typeof(string)));
            dt.Columns.Add(new DataColumn("Col12", typeof(string)));
            dt.Columns.Add(new DataColumn("Col13", typeof(string)));
            dt.Columns.Add(new DataColumn("Col14", typeof(string)));
            dt.Columns.Add(new DataColumn("Col15", typeof(string)));
            dt.Columns.Add(new DataColumn("Col16", typeof(string)));
            dt.Columns.Add(new DataColumn("Col17", typeof(string)));
            dt.Columns.Add(new DataColumn("Col18", typeof(string)));
            dt.Columns.Add(new DataColumn("Col19", typeof(string)));
            dt.Columns.Add(new DataColumn("Col20", typeof(string)));
            dt.Columns.Add(new DataColumn("Col21", typeof(string)));
            dt.Columns.Add(new DataColumn("Col22", typeof(string)));
            dt.Columns.Add(new DataColumn("Col23", typeof(string)));
            dt.Columns.Add(new DataColumn("Col24", typeof(string)));
            dt.Columns.Add(new DataColumn("Col25", typeof(string)));
            dt.Columns.Add(new DataColumn("Col26", typeof(string)));
            dt.Columns.Add(new DataColumn("Col27", typeof(string)));
            dt.Columns.Add(new DataColumn("Col28", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Col1"] = string.Empty;
            //dr["Col1"] = "2015-02-01".ToString();

            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
            dr["Col5"] = string.Empty;
            dr["Col6"] = string.Empty;

            dr["Col7"] = string.Empty;
            dr["Col8"] = string.Empty;
            dr["Col9"] = string.Empty;
            dr["Col10"] = string.Empty;
            dr["Col11"] = string.Empty;
            dr["Col12"] = string.Empty;
            dr["Col13"] = string.Empty;
            dr["Col14"] = string.Empty;
            dr["Col15"] = string.Empty;
            dr["Col16"] = string.Empty;

            dr["Col17"] = string.Empty;
            dr["Col18"] = string.Empty;
            dr["Col19"] = string.Empty;
            dr["Col20"] = string.Empty;
            dr["Col21"] = string.Empty;
            dr["Col22"] = string.Empty;
            dr["Col23"] = string.Empty;
            dr["Col24"] = string.Empty;
            dr["Col25"] = string.Empty;
            dr["Col26"] = string.Empty;

            dr["Col27"] = string.Empty;
            dr["Col28"] = string.Empty;




            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            grvTADACarBikeUser.DataSource = dt;
            grvTADACarBikeUser.DataBind();
            int rowIndex = 0;
            //TextBox TextBoxBillDate = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[1].FindControl("txtDate");
            //DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            //TextBoxBillDate.Text = dteFromDate.ToString();

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            //if (dtCurrentTable.Rows.Count > 0)
            //{

            //    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            //    {
            //        TextBox TextBoxBillDate = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[1].FindControl("txtDate");
            //        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            //        TextBoxBillDate.Text = dteFromDate.ToString();

            //        drCurrentRow = dtCurrentTable.NewRow();
            //        drCurrentRow["RowNumber"] = i + 1;

            //        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxBillDate.Text;
            //    }
            //    rowIndex++;
            //}
        }



        protected void grvTADACarBikeUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    grandtotal = 0; decimal aftrtotal = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][28].ToString() == "")
                        { aftrtotal = 0; }
                        else
                        {
                            aftrtotal = decimal.Parse(dt.Rows[i][28].ToString());
                        }
                        grandtotal = grandtotal + aftrtotal;
                    }

                    grvTADACarBikeUser.DataSource = dt;
                    grvTADACarBikeUser.DataBind();
                    for (int i = 0; i < grvTADACarBikeUser.Rows.Count - 1; i++)
                    {
                        grvTADACarBikeUser.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    lblGrandTotal.Text = grandtotal.ToString();
                    SetPreviousData();
                }
            }


        }

        protected void grvTADACarBikeUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            
            int rowIndex = 0;
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //TextBox TextBoxFromAddr = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[1].FindControl("txtFromAddress");
                        //TextBox TextBoxToAddr = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[2].FindControl("txtToAddress");
                        TextBox TextBoxBillDate = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[1].FindControl("txtDate");
                        TextBox TextBoxStartTime = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[2].FindControl("txtStartTime");
                        TextBox TextBoxFromAddress = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[3].FindControl("txtFromAddress");
                        TextBox TextBoxMovementSpots = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[4].FindControl("txtMovementSpots");
                        TextBox TextBoxEndTime = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[5].FindControl("txtEndTime");

                        TextBox TextBoxToAddr = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[6].FindControl("txtToAddress");
                        TextBox TextBoxMoDuration = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[7].FindControl("txtDuration");
                        TextBox TextBoxNightStay = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[8].FindControl("txtNightStay");
                        TextBox TextBoxStartMilage = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[9].FindControl("txtStartMilage");
                        TextBox TextBoxEndMilage = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[10].FindControl("txtEndMilage");
                        TextBox TextBoxConsumedKM = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[11].FindControl("txtConsumedkm");
                        DropDownList dldFuelType = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[12].FindControl("drdlFuelType");
                        TextBox TextBoxFuelQnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[13].FindControl("txtFuelQnt");
                        TextBox TextBoxFuelCost = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[14].FindControl("txtFuelCost");
                        DropDownList dldTransportMode = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[15].FindControl("drpTransportMode");



                        TextBox TextBoxFareTaka = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[16].FindControl("txtFare");


                        TextBox TextBoxSupportingNo = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[17].FindControl("txtSupportingNo");
                        TextBox TextBoxPhotocopy = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[18].FindControl("txtPhotoCopy");
                        TextBox TextBoxCourier = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[19].FindControl("txtCourier");
                        DropDownList dldMntCategory = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[20].FindControl("drpMntCategory");
                        TextBox TextBoxMntCost = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[21].FindControl("txtMntCost");
                        TextBox TextBoxFerryToll = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[22].FindControl("txtFerrytoll");


                        TextBox TextBoxOwnDA = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[23].FindControl("txtOwnDA");
                        TextBox TextBoxDriverDA = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[24].FindControl("txtDriverDA");



                        TextBox TextBoxOwnHotelAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[25].FindControl("txtOwnHotel");
                        TextBox TextBoxDriverHotelAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[26].FindControl("txtDriverhotel");

                        TextBox TextBoxOtherAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[27].FindControl("txtOthers");
                        TextBox TextBoxDTotalAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[28].FindControl("txtDTotal");

                        if (TextBoxStartTime.Text == string.Empty || (TextBoxStartTime.Text) == "")
                        {
                            TextBoxStartTime.Text = "0";
                        }

                        string dteStarttime = "9";
                        TextBoxStartTime.Text = dteStarttime.ToString();

                        

                        if (TextBoxMovementSpots.Text == string.Empty || (TextBoxMovementSpots.Text) == "")
                        {
                            TextBoxMovementSpots.Text = "No";
                        }

                        if (TextBoxEndTime.Text == string.Empty || (TextBoxEndTime.Text) == "")
                        {
                            TextBoxEndTime.Text = "0";
                        }
                        string dteOfficeEndtime = "18";
                        TextBoxEndTime.Text = dteOfficeEndtime.ToString();

      
                        if (TextBoxNightStay.Text == string.Empty || (TextBoxNightStay.Text) == "")
                        {
                            TextBoxNightStay.Text = "N/A";
                        }

                        if (TextBoxStartMilage.Text == string.Empty || (TextBoxStartMilage.Text) == "")
                        {
                            TextBoxStartMilage.Text = "0";
                        }

                        if (TextBoxEndMilage.Text == string.Empty || (TextBoxEndMilage.Text) == "")
                        {
                            TextBoxEndMilage.Text = "0";
                        }



                        if (TextBoxFuelQnt.Text == string.Empty || (TextBoxFuelQnt.Text) == "")
                        {
                            TextBoxFuelQnt.Text = "0";
                        }

                        if (TextBoxFuelCost.Text == string.Empty || (TextBoxFuelCost.Text) == "")
                        {
                            TextBoxFuelCost.Text = "0";
                        }


                        if (TextBoxFareTaka.Text == string.Empty || (TextBoxFareTaka.Text) == "")
                        {
                            TextBoxFareTaka.Text = "0";
                        }

                        if (TextBoxPhotocopy.Text == string.Empty || (TextBoxPhotocopy.Text) == "")
                        {
                            TextBoxPhotocopy.Text = "0";
                        }

                        if (TextBoxCourier.Text == string.Empty || (TextBoxCourier.Text) == "")
                        {
                            TextBoxCourier.Text = "0";
                        }

                        if (TextBoxMntCost.Text == string.Empty || (TextBoxMntCost.Text) == "")
                        {
                            TextBoxMntCost.Text = "0";
                        }

                        if (TextBoxFerryToll.Text == string.Empty || (TextBoxFerryToll.Text) == "")
                        {
                            TextBoxFerryToll.Text = "0";
                        }

                        if (TextBoxOwnDA.Text == string.Empty || (TextBoxOwnDA.Text) == "")
                        {
                            TextBoxOwnDA.Text = "0";
                        }

                        if (TextBoxDriverDA.Text == string.Empty || (TextBoxDriverDA.Text) == "")
                        {
                            TextBoxDriverDA.Text = "0";
                        }

                        if (TextBoxOwnHotelAmnt.Text == string.Empty || (TextBoxOwnHotelAmnt.Text) == "")
                        {
                            TextBoxOwnHotelAmnt.Text = "0";
                        }


                        if (TextBoxDriverHotelAmnt.Text == string.Empty || (TextBoxDriverHotelAmnt.Text) == "")
                        {
                            TextBoxDriverHotelAmnt.Text = "0";
                        }

                        if (TextBoxOtherAmnt.Text == string.Empty || (TextBoxOtherAmnt.Text) == "")
                        {
                            TextBoxOtherAmnt.Text = "0";
                        }

                        if (TextBoxSupportingNo.Text == string.Empty || (TextBoxSupportingNo.Text) == "")
                        {
                            TextBoxSupportingNo.Text = "No Supporting";
                        }

                        if (TextBoxMoDuration.Text == string.Empty || (TextBoxMoDuration.Text) == "")
                        {
                            TextBoxMoDuration.Text = "0";
                        }

                        string strBilldate = TextBoxBillDate.Text;
                        string decStartTime = TextBoxStartTime.Text;
                        string strFromAddress = TextBoxFromAddress.Text;
                        string strMovementsspots = TextBoxMovementSpots.Text;
                        string decEndtime = TextBoxEndTime.Text;
                        string strToaddress = TextBoxToAddr.Text;
                        string decMovduration = TextBoxMoDuration.Text;
                        string strNightStay = TextBoxNightStay.Text;
                        string decStartMilage = TextBoxStartMilage.Text;

                        string decEndmilage = TextBoxEndMilage.Text;


                        string decConsumedKM = TextBoxConsumedKM.Text;
                        string strFueltype = dldFuelType.Text;
                        string decFuelQnt = TextBoxFuelQnt.Text;
                        string decFuelCost = TextBoxFuelCost.Text;
                        string strTransportMode = dldTransportMode.Text;
                        string decFare = TextBoxFareTaka.Text;
                        string strSupporting = TextBoxSupportingNo.Text;
                        string decPhotocopy = TextBoxPhotocopy.Text;
                        string decCourier = TextBoxCourier.Text;

                        string strMntCatg = dldMntCategory.Text;

                        string decMntCost = TextBoxMntCost.Text;
                        string decFerrytoll = TextBoxFerryToll.Text;
                        string decOwnDA = TextBoxOwnDA.Text;
                        string decDriverDA = TextBoxDriverDA.Text;
                        string decOwnhotel = TextBoxOwnHotelAmnt.Text;
                        string decDriverHotel = TextBoxDriverHotelAmnt.Text;
                        string decOtherAmnt = TextBoxOtherAmnt.Text;
                        string decTotalAmnt = TextBoxDTotalAmnt.Text;




                        if (decTotalAmnt.All(c => Char.IsNumber(c)) && decOtherAmnt.All(c => Char.IsNumber(c)) && decDriverHotel.All(c => Char.IsNumber(c)) && decOwnhotel.All(c => Char.IsNumber(c)) && decDriverDA.All(c => Char.IsNumber(c)) && decOwnDA.All(c => Char.IsNumber(c)) && decFerrytoll.All(c => Char.IsNumber(c)) && decMntCost.All(c => Char.IsNumber(c)) && decCourier.All(c => Char.IsNumber(c)) && decCourier.All(c => Char.IsNumber(c)) && decPhotocopy.All(c => Char.IsNumber(c)) && decFare.All(c => Char.IsNumber(c)) && decFuelCost.All(c => Char.IsNumber(c)) && decFuelQnt.All(c => Char.IsNumber(c)) && decConsumedKM.All(c => Char.IsNumber(c)) && decEndmilage.All(c => Char.IsNumber(c)) && decStartMilage.All(c => Char.IsNumber(c)) && decMovduration.All(c => Char.IsNumber(c)) && decEndtime.All(c => Char.IsNumber(c)) && decStartTime.All(c => Char.IsNumber(c)))
                        {


                            decimal total = decimal.Parse(TextBoxFuelCost.Text) + decimal.Parse(TextBoxFareTaka.Text) + decimal.Parse(TextBoxPhotocopy.Text) + decimal.Parse(TextBoxCourier.Text) +
                                decimal.Parse(TextBoxMntCost.Text) + decimal.Parse(TextBoxFerryToll.Text) + decimal.Parse(TextBoxOwnDA.Text) + decimal.Parse(TextBoxDriverDA.Text) +
                                decimal.Parse(TextBoxOwnHotelAmnt.Text) + decimal.Parse(TextBoxDriverHotelAmnt.Text) + decimal.Parse(TextBoxOtherAmnt.Text);

                            TextBoxDTotalAmnt.Text = total.ToString();
                        
                        grandtotal = grandtotal + total;
                        lblGrandTotal.Text = grandtotal.ToString();
                        }
                        decimal timeDuration = decimal.Parse(TextBoxEndTime.Text) - decimal.Parse(TextBoxStartTime.Text);
                            TextBoxMoDuration.Text=timeDuration.ToString();

                            decimal MilageDifrernce = decimal.Parse(TextBoxEndMilage.Text) - decimal.Parse(TextBoxStartMilage.Text);
                            TextBoxConsumedKM.Text = MilageDifrernce.ToString();
                           

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxBillDate.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxStartTime.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextBoxFromAddress.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextBoxMovementSpots.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = TextBoxEndTime.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = TextBoxToAddr.Text;
                        dtCurrentTable.Rows[i - 1]["Col7"] = TextBoxMoDuration.Text;
                        dtCurrentTable.Rows[i - 1]["Col8"] = TextBoxNightStay.Text;
                        dtCurrentTable.Rows[i - 1]["Col9"] = TextBoxStartMilage.Text;
                        dtCurrentTable.Rows[i - 1]["Col10"] = TextBoxEndMilage.Text;
                        dtCurrentTable.Rows[i - 1]["Col11"] = TextBoxConsumedKM.Text;
                        dtCurrentTable.Rows[i - 1]["Col12"] = dldFuelType.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col13"] = TextBoxFuelQnt.Text;
                        dtCurrentTable.Rows[i - 1]["Col14"] = TextBoxFuelCost.Text;
                        dtCurrentTable.Rows[i - 1]["Col15"] = dldTransportMode.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col16"] = TextBoxFareTaka.Text;
                        dtCurrentTable.Rows[i - 1]["Col17"] = TextBoxSupportingNo.Text;
                        dtCurrentTable.Rows[i - 1]["Col18"] = TextBoxPhotocopy.Text;
                        dtCurrentTable.Rows[i - 1]["Col19"] = TextBoxCourier.Text;
                        dtCurrentTable.Rows[i - 1]["Col20"] = dldMntCategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col21"] = TextBoxMntCost.Text;
                        dtCurrentTable.Rows[i - 1]["Col22"] = TextBoxFerryToll.Text;
                        dtCurrentTable.Rows[i - 1]["Col23"] = TextBoxOwnDA.Text;
                        dtCurrentTable.Rows[i - 1]["Col24"] = TextBoxDriverDA.Text;
                        dtCurrentTable.Rows[i - 1]["Col25"] = TextBoxOwnHotelAmnt.Text;
                        dtCurrentTable.Rows[i - 1]["Col26"] = TextBoxDriverHotelAmnt.Text;
                        dtCurrentTable.Rows[i - 1]["Col27"] = TextBoxOtherAmnt.Text;
                        dtCurrentTable.Rows[i - 1]["Col28"] = TextBoxDTotalAmnt.Text;



                        rowIndex++;
                    }




                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grvTADACarBikeUser.DataSource = dtCurrentTable;
                    grvTADACarBikeUser.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData();
  }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //int i = 0

                        TextBox TextBoxBillDate = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[1].FindControl("txtDate");
                        TextBox TextBoxStartTime = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[2].FindControl("txtStartTime");
                        TextBox TextBoxFromAddress = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[3].FindControl("txtFromAddress");
                        TextBox TextBoxMovementSpots = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[4].FindControl("txtMovementSpots");
                        TextBox TextBoxEndTime = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[5].FindControl("txtEndTime");

                        TextBox TextBoxToAddr = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[6].FindControl("txtToAddress");
                        TextBox TextBoxMoDuration = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[7].FindControl("txtDuration");
                        TextBox TextBoxNightStay = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[8].FindControl("txtNightStay");
                        TextBox TextBoxStartMilage = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[9].FindControl("txtStartMilage");
                        TextBox TextBoxEndMilage = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[10].FindControl("txtEndMilage");
                        TextBox TextBoxConsumedKM = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[11].FindControl("txtConsumedkm");
                        DropDownList dldFuelType = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[12].FindControl("drdlFuelType");
                        TextBox TextBoxFuelQnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[13].FindControl("txtFuelQnt");
                        TextBox TextBoxFuelCost = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[14].FindControl("txtFuelCost");
                        DropDownList dldTransportMode = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[15].FindControl("drpTransportMode");



                        TextBox TextBoxFareTaka = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[16].FindControl("txtFare");


                        TextBox TextBoxSupportingNo = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[17].FindControl("txtSupportingNo");
                        TextBox TextBoxPhotocopy = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[18].FindControl("txtPhotoCopy");
                        TextBox TextBoxCourier = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[19].FindControl("txtCourier");
                        DropDownList dldMntCategory = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[20].FindControl("drpMntCategory");
                        TextBox TextBoxMntCost = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[21].FindControl("txtMntCost");
                        TextBox TextBoxFerryToll = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[22].FindControl("txtFerrytoll");


                        TextBox TextBoxOwnDA = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[23].FindControl("txtOwnDA");
                        TextBox TextBoxDriverDA = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[24].FindControl("txtDriverDA");



                        TextBox TextBoxOwnHotelAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[25].FindControl("txtOwnHotel");
                        TextBox TextBoxDriverHotelAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[26].FindControl("txtDriverhotel");

                        TextBox TextBoxOtherAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[27].FindControl("txtOthers");
                        TextBox TextBoxDTotalAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[28].FindControl("txtDTotal");

                        TextBoxBillDate.Text = dt.Rows[i]["Col1"].ToString();
                        TextBoxStartTime.Text = dt.Rows[i]["Col2"].ToString();
                        TextBoxFromAddress.Text = dt.Rows[i]["Col3"].ToString();
                        TextBoxMovementSpots.Text = dt.Rows[i]["Col4"].ToString();
                        TextBoxEndTime.Text = dt.Rows[i]["Col5"].ToString();
                        TextBoxToAddr.Text = dt.Rows[i]["Col6"].ToString();
                        TextBoxMoDuration.Text = dt.Rows[i]["Col7"].ToString();
                        TextBoxNightStay.Text = dt.Rows[i]["Col8"].ToString();
                        TextBoxStartMilage.Text = dt.Rows[i]["Col9"].ToString();

                        TextBoxEndMilage.Text = dt.Rows[i]["Col10"].ToString();


                        TextBoxConsumedKM.Text = dt.Rows[i]["Col11"].ToString();
                        dldFuelType.Text = dt.Rows[i]["Col12"].ToString();
                        TextBoxFuelQnt.Text = dt.Rows[i]["Col13"].ToString();
                        TextBoxFuelCost.Text = dt.Rows[i]["Col14"].ToString();
                        dldTransportMode.Text = dt.Rows[i]["Col15"].ToString();
                        TextBoxFareTaka.Text = dt.Rows[i]["Col16"].ToString();
                        TextBoxSupportingNo.Text = dt.Rows[i]["Col17"].ToString();
                        TextBoxPhotocopy.Text = dt.Rows[i]["Col18"].ToString();
                        TextBoxCourier.Text = dt.Rows[i]["Col19"].ToString();

                        dldMntCategory.Text = dt.Rows[i]["Col20"].ToString();

                        TextBoxMntCost.Text = dt.Rows[i]["Col21"].ToString();
                        TextBoxFerryToll.Text = dt.Rows[i]["Col22"].ToString();
                        TextBoxOwnDA.Text = dt.Rows[i]["Col23"].ToString();
                        TextBoxDriverDA.Text = dt.Rows[i]["Col24"].ToString();
                        TextBoxOwnHotelAmnt.Text = dt.Rows[i]["Col25"].ToString();
                        TextBoxDriverHotelAmnt.Text = dt.Rows[i]["Col26"].ToString();
                        TextBoxOtherAmnt.Text = dt.Rows[i]["Col27"].ToString();
                        TextBoxDTotalAmnt.Text = dt.Rows[i]["Col28"].ToString();


                        rowIndex++;






                    }
                }
            }
        }






        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (grvTADACarBikeUser.Rows.Count > 0)
            {

                for (int rowIndex = 0; rowIndex < grvTADACarBikeUser.Rows.Count; rowIndex++)
                {
                    TextBox TextBoxBillDate = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    TextBox TextBoxStartTime = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[2].FindControl("txtStartTime");
                    TextBox TextBoxFromAddress = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[3].FindControl("txtFromAddress");
                    TextBox TextBoxMovementSpots = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[4].FindControl("txtMovementSpots");
                    TextBox TextBoxEndTime = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[5].FindControl("txtEndTime");

                    TextBox TextBoxToAddr = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[6].FindControl("txtToAddress");
                    TextBox TextBoxMoDuration = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[7].FindControl("txtDuration");
                    TextBox TextBoxNightStay = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[8].FindControl("txtNightStay");
                    TextBox TextBoxStartMilage = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[9].FindControl("txtStartMilage");
                    TextBox TextBoxEndMilage = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[10].FindControl("txtEndMilage");
                    TextBox TextBoxConsumedKM = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[11].FindControl("txtConsumedkm");
                    DropDownList dldFuelType = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[12].FindControl("drdlFuelType");
                    TextBox TextBoxFuelQnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[13].FindControl("txtFuelQnt");
                    TextBox TextBoxFuelCost = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[14].FindControl("txtFuelCost");
                    DropDownList dldTransportMode = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[15].FindControl("drpTransportMode");



                    TextBox TextBoxFareTaka = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[16].FindControl("txtFare");


                    TextBox TextBoxSupportingNo = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[17].FindControl("txtSupportingNo");
                    TextBox TextBoxPhotocopy = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[18].FindControl("txtPhotoCopy");
                    TextBox TextBoxCourier = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[19].FindControl("txtCourier");
                    DropDownList dldMntCategory = (DropDownList)grvTADACarBikeUser.Rows[rowIndex].Cells[20].FindControl("drpMntCategory");
                    TextBox TextBoxMntCost = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[21].FindControl("txtMntCost");
                    TextBox TextBoxFerryToll = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[22].FindControl("txtFerrytoll");


                    TextBox TextBoxOwnDA = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[23].FindControl("txtOwnDA");
                    TextBox TextBoxDriverDA = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[24].FindControl("txtDriverDA");



                    TextBox TextBoxOwnHotelAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[25].FindControl("txtOwnHotel");
                    TextBox TextBoxDriverHotelAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[26].FindControl("txtDriverhotel");

                    TextBox TextBoxOtherAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[27].FindControl("txtOthers");
                    TextBox TextBoxDTotalAmnt = (TextBox)grvTADACarBikeUser.Rows[rowIndex].Cells[28].FindControl("txtDTotal");



                   

                   



                    string dteStarttime = "9";
                    TextBoxStartTime.Text = dteStarttime.ToString();



                    if (TextBoxMovementSpots.Text == string.Empty || (TextBoxMovementSpots.Text) == "")
                    {
                        TextBoxMovementSpots.Text = "No";
                    }

                    if (TextBoxEndTime.Text == string.Empty || (TextBoxEndTime.Text) == "")
                    {
                        TextBoxEndTime.Text = "0";
                    }
                    string dteOfficeEndtime = "18";
                    TextBoxEndTime.Text = dteOfficeEndtime.ToString();


                    if (TextBoxNightStay.Text == string.Empty || (TextBoxNightStay.Text) == "")
                    {
                        TextBoxNightStay.Text = "N/A";
                    }

                    if (TextBoxStartMilage.Text == string.Empty || (TextBoxStartMilage.Text) == "")
                    {
                        TextBoxStartMilage.Text = "0";
                    }

                    if (TextBoxEndMilage.Text == string.Empty || (TextBoxEndMilage.Text) == "")
                    {
                        TextBoxEndMilage.Text = "0";
                    }



                    if (TextBoxFuelQnt.Text == string.Empty || (TextBoxFuelQnt.Text) == "")
                    {
                        TextBoxFuelQnt.Text = "0";
                    }

                    if (TextBoxFuelCost.Text == string.Empty || (TextBoxFuelCost.Text) == "")
                    {
                        TextBoxFuelCost.Text = "0";
                    }


                    if (TextBoxFareTaka.Text == string.Empty || (TextBoxFareTaka.Text) == "")
                    {
                        TextBoxFareTaka.Text = "0";
                    }

                    if (TextBoxPhotocopy.Text == string.Empty || (TextBoxPhotocopy.Text) == "")
                    {
                        TextBoxPhotocopy.Text = "0";
                    }

                    if (TextBoxCourier.Text == string.Empty || (TextBoxCourier.Text) == "")
                    {
                        TextBoxCourier.Text = "0";
                    }

                    if (TextBoxMntCost.Text == string.Empty || (TextBoxMntCost.Text) == "")
                    {
                        TextBoxMntCost.Text = "0";
                    }

                    if (TextBoxFerryToll.Text == string.Empty || (TextBoxFerryToll.Text) == "")
                    {
                        TextBoxFerryToll.Text = "0";
                    }

                    if (TextBoxOwnDA.Text == string.Empty || (TextBoxOwnDA.Text) == "")
                    {
                        TextBoxOwnDA.Text = "0";
                    }

                    if (TextBoxDriverDA.Text == string.Empty || (TextBoxDriverDA.Text) == "")
                    {
                        TextBoxDriverDA.Text = "0";
                    }

                    if (TextBoxOwnHotelAmnt.Text == string.Empty || (TextBoxOwnHotelAmnt.Text) == "")
                    {
                        TextBoxOwnHotelAmnt.Text = "0";
                    }


                    if (TextBoxDriverHotelAmnt.Text == string.Empty || (TextBoxDriverHotelAmnt.Text) == "")
                    {
                        TextBoxDriverHotelAmnt.Text = "0";
                    }

                    if (TextBoxOtherAmnt.Text == string.Empty || (TextBoxOtherAmnt.Text) == "")
                    {
                        TextBoxOtherAmnt.Text = "0";
                    }

                    if (TextBoxSupportingNo.Text == string.Empty || (TextBoxSupportingNo.Text) == "")
                    {
                        TextBoxSupportingNo.Text = "No Supporting";
                    }

                    if (TextBoxMoDuration.Text == string.Empty || (TextBoxMoDuration.Text) == "")
                    {
                        TextBoxMoDuration.Text = "0";
                    }













                    string strBilldate = TextBoxBillDate.Text;
                    string decStartTime = TextBoxStartTime.Text;
                    string strFromAddress = TextBoxFromAddress.Text;
                    string strMovementsspots = TextBoxMovementSpots.Text;
                    string decEndtime = TextBoxEndTime.Text;
                    string strToaddress = TextBoxToAddr.Text;
                    string decMovduration = TextBoxMoDuration.Text;
                    string strNightStay = TextBoxNightStay.Text;
                    string decStartMilage = TextBoxStartMilage.Text;

                    string decEndmilage = TextBoxEndMilage.Text;


                    string decConsumedKM = TextBoxConsumedKM.Text;
                    string strFueltype = dldFuelType.Text;
                    string decFuelQnt = TextBoxFuelQnt.Text;
                    string decFuelCost = TextBoxFuelCost.Text;
                    string strTransportMode = dldTransportMode.Text;
                    string decFare = TextBoxFareTaka.Text;
                    string strSupporting = TextBoxSupportingNo.Text;
                    string decPhotocopy = TextBoxPhotocopy.Text;
                    string decCourier = TextBoxCourier.Text;

                    string strMntCatg = dldMntCategory.Text;

                    string decMntCost = TextBoxMntCost.Text;
                    string decFerrytoll = TextBoxFerryToll.Text;
                    string decOwnDA = TextBoxOwnDA.Text;
                    string decDriverDA = TextBoxDriverDA.Text;
                    string decOwnhotel = TextBoxOwnHotelAmnt.Text;
                    string decDriverHotel = TextBoxDriverHotelAmnt.Text;
                    string decOtherAmnt = TextBoxOtherAmnt.Text;
                    string decTotalAmnt = TextBoxDTotalAmnt.Text;

                  
                        if (decTotalAmnt.All(c=> Char.IsNumber(c)) && decOtherAmnt.All(c=> Char.IsNumber(c)) && decDriverHotel.All(c=> Char.IsNumber(c)) && decOwnhotel.All(c=> Char.IsNumber(c)) && decDriverDA.All(c=> Char.IsNumber(c)) && decOwnDA.All(c=> Char.IsNumber(c)) && decFerrytoll.All(c=> Char.IsNumber(c)) && decMntCost.All(c=> Char.IsNumber(c)) && decCourier.All(c=> Char.IsNumber(c))  && decCourier.All(c=> Char.IsNumber(c))&& decPhotocopy.All(c=> Char.IsNumber(c))&& decFare.All(c=> Char.IsNumber(c))&& decFuelCost.All(c=> Char.IsNumber(c)) && decFuelQnt.All(c=> Char.IsNumber(c))&& decConsumedKM.All(c=> Char.IsNumber(c))&& decEndmilage.All(c=> Char.IsNumber(c))&& decStartMilage.All(c=> Char.IsNumber(c))&& decMovduration.All(c=> Char.IsNumber(c))&& decEndtime.All(c=> Char.IsNumber(c))&& decStartTime.All(c=> Char.IsNumber(c)))
                      
                        {

                            CreateTADAForBikeCarUserXml(strBilldate, decStartTime, strFromAddress, strMovementsspots, decEndtime, strToaddress, decMovduration, strNightStay, decStartMilage, decEndmilage, decConsumedKM, strFueltype, decFuelQnt, decFuelCost, strTransportMode, decFare, strSupporting, decPhotocopy, decCourier, strMntCatg, decMntCost, decFerrytoll, decOwnDA, decDriverDA, decOwnhotel, decDriverHotel, decOtherAmnt, decTotalAmnt);


                            #region ------------ Insert into dataBase -----------


                            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                     
                            hdnenroll.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                            int BikeCarUserTypeid = 1;
                            
                            Int32 enroll = Convert.ToInt32(hdnenroll.Value);

                            XmlDocument doc = new XmlDocument();
                            try
                            {
                                doc.Load(filePathForXML);
                                XmlNode dSftTm = doc.SelectSingleNode("RemoteTaDaForBikeCarUser");
                                string xmlString = dSftTm.InnerXml;
                                xmlString = "<RemoteTaDaForBikeCarUser>" + xmlString + "</RemoteTaDaForBikeCarUser>";

                                string message = bll.tadaInsertbyBikeAndCarUser(xmlString, dteTodate, enroll, BikeCarUserTypeid);
                                File.Delete(filePathForXML);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            }
                            catch
                            {

                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry .....insertion faill. Data r wrong format');", true);
                            }




                            #endregion ------------ Insertion End ----------------
                        }
                   


                }
                grvTADACarBikeUser.DataBind();
                //lblGrandTotal.Text = "0";
            }

        }

     private void   CreateTADAForBikeCarUserXml(string strBilldate,string decStartTime,string strFromAddress,string strMovementsspots,string decEndtime,string strToaddress,string decMovduration,string strNightStay,string decStartMilage,string decEndmilage,string decConsumedKM,string strFueltype,string decFuelQnt,string decFuelCost,string strTransportMode,string decFare,string strSupporting,string decPhotocopy,string decCourier,string strMntCatg,string decMntCost,string decFerrytoll,string decOwnDA,string decDriverDA,string decOwnhotel,string decDriverHotel,string decOtherAmnt,string decTotalAmnt)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemoteTaDaForBikeCarUser");
                XmlNode addItem = CreateItemNode(doc, strBilldate, decStartTime, strFromAddress, strMovementsspots, decEndtime, strToaddress, decMovduration, strNightStay, decStartMilage, decEndmilage, decConsumedKM, strFueltype, decFuelQnt, decFuelCost, strTransportMode, decFare, strSupporting, decPhotocopy, decCourier, strMntCatg, decMntCost, decFerrytoll, decOwnDA, decDriverDA, decOwnhotel, decDriverHotel, decOtherAmnt, decTotalAmnt);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteTaDaForBikeCarUser");
                XmlNode addItem = CreateItemNode(doc, strBilldate, decStartTime, strFromAddress, strMovementsspots, decEndtime, strToaddress, decMovduration, strNightStay, decStartMilage, decEndmilage, decConsumedKM, strFueltype, decFuelQnt, decFuelCost, strTransportMode, decFare, strSupporting, decPhotocopy, decCourier, strMntCatg, decMntCost, decFerrytoll, decOwnDA, decDriverDA, decOwnhotel, decDriverHotel, decOtherAmnt, decTotalAmnt);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

     private XmlNode CreateItemNode(XmlDocument doc, string strBilldate, string decStartTime, string strFromAddress, string strMovementsspots, string decEndtime, string strToaddress, string decMovduration, string strNightStay, string decStartMilage, string decEndmilage, string decConsumedKM, string strFueltype, string decFuelQnt, string decFuelCost, string strTransportMode, string decFare, string strSupporting, string decPhotocopy, string decCourier, string strMntCatg, string decMntCost, string decFerrytoll, string decOwnDA, string decDriverDA, string decOwnhotel, string decDriverHotel, string decOtherAmnt, string decTotalAmnt)
        {
            XmlNode node = doc.CreateElement("items");





            XmlAttribute STRBILLDATE = doc.CreateAttribute("strBilldate");
            STRBILLDATE.Value = strBilldate;

            XmlAttribute STRSTARTTIME = doc.CreateAttribute("decStartTime");
            STRSTARTTIME.Value = decStartTime;

            XmlAttribute STRFROMADDR = doc.CreateAttribute("strFromAddress");
            STRFROMADDR.Value = strFromAddress;

            XmlAttribute STRMOVEMENTSPOTS = doc.CreateAttribute("strMovementsspots");
            STRMOVEMENTSPOTS.Value = strMovementsspots;

            XmlAttribute STRENDTIME = doc.CreateAttribute("decEndtime");
            STRENDTIME.Value = decEndtime;



            XmlAttribute STRTOADDR = doc.CreateAttribute("strToaddress");
            STRTOADDR.Value = strToaddress;

            XmlAttribute STRMOVDURATION = doc.CreateAttribute("decMovduration");
            STRMOVDURATION.Value = decMovduration;

            XmlAttribute STRNIGHTSTAY = doc.CreateAttribute("strNightStay");
            STRNIGHTSTAY.Value = strNightStay;

            XmlAttribute STRSTARTMILAGE = doc.CreateAttribute("decStartMilage");
            STRSTARTMILAGE.Value = decStartMilage;


            XmlAttribute STRENDMILAGE = doc.CreateAttribute("decEndmilage");
            STRENDMILAGE.Value = decEndmilage;

            XmlAttribute STRCONSUMEDKM = doc.CreateAttribute("decConsumedKM");
            STRCONSUMEDKM.Value = decConsumedKM;

            XmlAttribute STRFUELTYPE = doc.CreateAttribute("strFueltype");
            STRFUELTYPE.Value = strFueltype;

            XmlAttribute STRFUELQNT = doc.CreateAttribute("decFuelQnt");
            STRFUELQNT.Value = decFuelQnt;

            XmlAttribute STRFUELCOST = doc.CreateAttribute("decFuelCost");
            STRFUELCOST.Value = decFuelCost;



            XmlAttribute STRTRANSPORTMODE = doc.CreateAttribute("strTransportMode");
            STRTRANSPORTMODE.Value = strTransportMode;

            XmlAttribute STRFARE = doc.CreateAttribute("decFare");
            STRFARE.Value = decFare;

            XmlAttribute STRSUPPORTING = doc.CreateAttribute("strSupporting");
            STRSUPPORTING.Value = strSupporting;

            XmlAttribute STRPHOTOCOPY = doc.CreateAttribute("decPhotocopy");
            STRPHOTOCOPY.Value = decPhotocopy;

            XmlAttribute STRCOURIER = doc.CreateAttribute("decCourier");
            STRCOURIER.Value = decCourier;

            XmlAttribute STRMNTCATG = doc.CreateAttribute("strMntCatg");
            STRMNTCATG.Value = strMntCatg;

            XmlAttribute STRMNTCOST = doc.CreateAttribute("decMntCost");
            STRMNTCOST.Value = decMntCost;

            XmlAttribute STRFERRYTOLL = doc.CreateAttribute("decFerrytoll");
            STRFERRYTOLL.Value = decFerrytoll;

            XmlAttribute STROWNDA = doc.CreateAttribute("decOwnDA");
            STROWNDA.Value = decOwnDA;

            XmlAttribute STRDRIVERDA = doc.CreateAttribute("decDriverDA");
            STRDRIVERDA.Value = decDriverDA;

            XmlAttribute STROWNHOTEL = doc.CreateAttribute("decOwnhotel");
            STROWNHOTEL.Value = decOwnhotel;

            XmlAttribute STRDRIVERHOTEL = doc.CreateAttribute("decDriverHotel");
            STRDRIVERHOTEL.Value = decDriverHotel;

            XmlAttribute STROTHERAMNT = doc.CreateAttribute("decOtherAmnt");
            STROTHERAMNT.Value = decOtherAmnt;

            XmlAttribute STRTOTALAMNT = doc.CreateAttribute("decTotalAmnt");
            STRTOTALAMNT.Value = decTotalAmnt;

         
         



            node.Attributes.Append(STRBILLDATE);
            node.Attributes.Append(STRSTARTTIME);
            node.Attributes.Append(STRFROMADDR);
            node.Attributes.Append(STRMOVEMENTSPOTS);
            node.Attributes.Append(STRENDTIME);

            node.Attributes.Append(STRTOADDR);
            node.Attributes.Append(STRMOVDURATION);
            node.Attributes.Append(STRNIGHTSTAY);
            node.Attributes.Append(STRSTARTMILAGE);
            node.Attributes.Append(STRENDMILAGE);


            node.Attributes.Append(STRCONSUMEDKM);
            node.Attributes.Append(STRFUELTYPE);
            node.Attributes.Append(STRFUELQNT);
            node.Attributes.Append(STRFUELCOST);
            node.Attributes.Append(STRTRANSPORTMODE);

            node.Attributes.Append(STRFARE);
            node.Attributes.Append(STRSUPPORTING);
            node.Attributes.Append(STRPHOTOCOPY);
            node.Attributes.Append(STRCOURIER);
            node.Attributes.Append(STRMNTCATG);

            node.Attributes.Append(STRMNTCOST);
            node.Attributes.Append(STRFERRYTOLL);
            node.Attributes.Append(STROWNDA);
            node.Attributes.Append(STRDRIVERDA);
            node.Attributes.Append(STROWNHOTEL);

            node.Attributes.Append(STRDRIVERHOTEL);
            node.Attributes.Append(STROTHERAMNT);
            node.Attributes.Append(STRTOTALAMNT);







            return node;



        }



     protected void Cal1_SelectionChanged(object sender, EventArgs e)
     {

         

         
         
         
         Calendar cal = (Calendar)sender;
         TextBox txtDate = (TextBox)((GridViewRow)cal.Parent.Parent).FindControl("txtDate");


         if (txtDate.Text == string.Empty || (txtDate.Text) == "")
         {

             txtDate.Text = cal.SelectedDate.ToShortDateString();
             cal.Visible = false;
         }
         else
         {
             cal.Visible = false;

         }

     }

    

    

     
    

    
    

    }
}