using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOGIS_BLL.GetInOut;
using System.Data;
using UI.ClassFiles;

namespace UI.GetInOut
{
    public partial class MainGateReport : BasePage
    {

        GateReport Reportobj = new GateReport();
        DataTable materilas = new DataTable();
        DataTable unit = new DataTable();
        DataTable getpass = new DataTable();
        DataTable ponumber = new DataTable();
        DataTable local = new DataTable();
        DataTable getpassout = new DataTable();
        DataTable getpassin = new DataTable();
        DataTable poin = new DataTable();
        DataTable localin = new DataTable();
        DataTable challanout = new DataTable();
        DataTable localchallan = new DataTable();
        int intpart;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
             
                GridView1.Visible = true;
                GridView2.Visible = true;
                GridView3.Visible = true;
                GridView4.Visible = true;

                try { DateTime dteFrom = DateTime.Parse(TxtDteFrom.Text); }
                catch { }

                try { DateTime dteto = DateTime.Parse(TxtDteTo.Text); }
                catch { }

                string number = Txtnumber.Text.ToString();


              

                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 125 || intjobid == 131 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260)
                {
                    unit = Reportobj.Unitname();
                    DdlUnit.DataSource = unit;
                    DdlUnit.DataTextField = "strJobStationName";
                    DdlUnit.DataValueField = "intEmployeeJobStationId";
                    DdlUnit.DataBind();

                }
                else
                {
                    unit = Reportobj.Unitname(intjobid);
                    DdlUnit.DataSource = unit;
                    DdlUnit.DataTextField = "strJobStationName";
                    DdlUnit.DataValueField = "intEmployeeJobStationId";
                    DdlUnit.DataBind();
                }

            }
        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
            int ddljob = Int32.Parse(DdlUnit.SelectedValue.ToString());
            GridView1.Visible = true;
            GridView2.Visible = true;
            GridView3.Visible = true;
            GridView4.Visible = true;

            DateTime dteFrom = DateTime.Parse(TxtDteFrom.Text);

            DateTime dteto = DateTime.Parse(TxtDteTo.Text);
           
            string number= Txtnumber.Text.ToString();
           

            //materilas = Reportobj.VehicleInOutReport(dteFrom, dteto, ddljob);
            //GridView1.DataSource = materilas;
            //GridView1.DataBind();


            //DateTime dteFrom = DateTime.Parse(TxtDteFrom.Text);

            //DateTime dteto = DateTime.Parse(TxtDteTo.Text);
            int intjobid = Int32.Parse(DdlUnit.SelectedValue.ToString());
            string item = DropDownList1.SelectedItem.ToString();

            if (Txtnumber.Text != "")
            {
                intpart = 1;
                if (intpart == 1)
                {
                    if (item == "PO")
                    {
                        GridView1.Visible = true;
                        poin = Reportobj.PonumberReportWithTxtNumber(intpart,item, intjobid, dteFrom, dteto, number);
                        GridView1.DataSource = poin;
                        GridView1.DataBind();


                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        dgvVehicle.Visible = false;
                        dgvVehicle2.Visible = false;
                    }
                    else if (item == "Getpass Out")
                    {
                        GridView2.Visible = true;
                        getpassout = Reportobj.GetpassOutDataReportWithtxtNumber(intpart,item, intjobid, dteFrom, dteto, number);
                        GridView2.DataSource = getpassout;
                        GridView2.DataBind();


                        GridView1.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        dgvVehicle.Visible = false;
                        dgvVehicle2.Visible = false;

                    }

                    else if (item == "Getpass In")
                    {
                        GridView3.Visible = true;
                        getpassin = Reportobj.GetpassInDataReportwithTxtNumber(intpart,item, intjobid, dteFrom, dteto, number);
                        GridView3.DataSource = getpassin;
                        GridView3.DataBind();

                        GridView2.Visible = false;
                        GridView1.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        dgvVehicle.Visible = false;
                        dgvVehicle2.Visible = false;
                    }
                    else if (item == "Finished Product Out")
                    {
                        GridView4.Visible = true;
                        challanout = Reportobj.FinishedProductOutwithTxtNumber(intpart,item, intjobid, dteFrom, dteto, number);
                        GridView4.DataSource = challanout;
                        GridView4.DataBind();

                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;

                        GridView5.Visible = false;
                        dgvVehicle.Visible = false;
                        dgvVehicle2.Visible = false;
                    }
                    else if (item == "Local Challan")
                    {
                        GridView5.Visible = true;
                        localchallan = Reportobj.LocalChallanReportwithTxtNumber(intpart,item, intjobid, dteFrom, dteto, number);
                        GridView5.DataSource = localchallan;
                        GridView5.DataBind();
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        dgvVehicle.Visible = false;
                        dgvVehicle2.Visible = false;

                    }
                    else if (item == "Vehicle")
                    {
                        dgvVehicle.Visible = true;
                        localchallan = Reportobj.vehiclereport(intpart, item, intjobid, dteFrom, dteto, number);
                        dgvVehicle2.DataSource = localchallan;
                        dgvVehicle2.DataBind();
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        dgvVehicle2.Visible = false;

                    }
                }
            }
            else
            {
                intpart = 2;
                if (intpart==2)
                {
                if (item == "PO")
                {
                    GridView1.Visible = true;
                    poin = Reportobj.PonumberReport(intpart,item, intjobid, dteFrom, dteto, number);
                    GridView1.DataSource = poin;
                    GridView1.DataBind();


                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    dgvVehicle.Visible = false;
                    dgvVehicle2.Visible = false;
                }
                else if (item == "Getpass Out")
                {
                    GridView2.Visible = true;
                    getpassout = Reportobj.GetpassOutDataReport(intpart,item, intjobid, dteFrom, dteto, number);
                    GridView2.DataSource = getpassout;
                    GridView2.DataBind();


                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    dgvVehicle.Visible = false;
                    dgvVehicle2.Visible = false;

                }

                else if (item == "Getpass In")
                {
                    GridView3.Visible = true;
                    getpassin = Reportobj.GetpassInDataReport(intpart,item, intjobid, dteFrom, dteto, number);
                    GridView3.DataSource = getpassin;
                    GridView3.DataBind();

                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    dgvVehicle.Visible = false;
                    dgvVehicle2.Visible = false;
                }
                else if (item == "Finished Product Out")
                {
                    GridView4.Visible = true;
                    challanout = Reportobj.FinishedProductOut(intpart,item, intjobid, dteFrom, dteto, number);
                    GridView4.DataSource = challanout;
                    GridView4.DataBind();

                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;

                    GridView5.Visible = false;
                    dgvVehicle.Visible = false;
                    dgvVehicle2.Visible = false;
                }
                else if (item == "Local Challan")
                {
                    GridView5.Visible = true;
                    localchallan = Reportobj.LocalChallanReport(intpart,item, intjobid, dteFrom, dteto, number);
                    GridView5.DataSource = localchallan;
                    GridView5.DataBind();
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    dgvVehicle.Visible = false;
                    dgvVehicle2.Visible = false;
                }

                else if (item == "Vehicle")
                {
                    dgvVehicle2.Visible = true;
                    localchallan = Reportobj.vehiclereportwithtruckno(intpart, item, intjobid, dteFrom, dteto, number);
                    dgvVehicle2.DataSource = localchallan;
                    dgvVehicle2.DataBind();
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    dgvVehicle.Visible = false;

                }
                }
            }
            }


        

        //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        //{


        //    GridView1.Visible = false;
        //    GridView2.Visible = false;
        //    GridView3.Visible = true;
        //    GridView4.Visible =false;
        //    string number=Txtnumber.Text.ToString();
        //    int intjobid=Int32.Parse(DdlUnit.SelectedValue.ToString());
        //    //if (part == 2)
        //{
        //    ponumber = Reportobj.PonumberLoadData(part, number, intjobid);
        //    GridView3.DataSource = ponumber;
        //    GridView3.DataBind();
        //    RadioButton1.Checked = false;
        //}
        //}


        //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        //{

        //    GridView1.Visible = false;

        //    GridView3.Visible = false;
        //    GridView4.Visible = false;
        //    GridView2.Visible =true;

        //    int intjobid = Int32.Parse(DdlUnit.SelectedValue.ToString());
        //    string number=Txtnumber.Text.ToString();
        //    if (part==1)
        //    {
        //    getpass = Reportobj.getpassdataload(part, number, intjobid);
        //    GridView2.DataSource = getpass;
        //    GridView2.DataBind();
        //    RadioButton2.Checked = false;
        //}
        //}

        //protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        //{

        //    GridView1.Visible = false;
        //    GridView2.Visible = false;
        //    GridView3.Visible = false;
        //    GridView4.Visible = true;
        //    int intjobid = Int32.Parse(DdlUnit.SelectedValue.ToString());
        //    string number = Txtnumber.Text.ToString();
        //    //if (part == 3)
        //    //{
        //    //    local = Reportobj.LocalChallan(part, number, intjobid);
        //    //    GridView4.DataSource =local;
        //    //    GridView4.DataBind();
        //    //    RadioButton3.Checked = false;
        //    //}
        ////}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

           


            //else
            //{
            //    if (item == "PO")
            //    {
            //        poin = Reportobj.PonumberReport(item, intjobid, dteFrom, dteto);
            //        GridView1.DataSource = poin;
            //        GridView1.DataBind();

            //    }
            //    else if (item == "Getpass Out")
            //    {
            //        GridView2.Visible = true;
            //        getpassout = Reportobj.GetpassOutDataReport(item, intjobid, dteFrom, dteto);
            //        GridView2.DataSource = getpassout;
            //        GridView2.DataBind();
            //    }

            //    else if (item == "Getpass In")
            //    {
            //        GridView3.Visible = true;
            //        getpassin = Reportobj.GetpassInDataReport(item, intjobid, dteFrom, dteto);
            //        GridView3.DataSource = getpassin;
            //        GridView3.DataBind();
            //    }
            //    else if (item == "Finished Product Out")
            //    {
            //        GridView4.Visible = true;
            //        challanout = Reportobj.FinishedProductOut(item, intjobid, dteFrom, dteto);
            //        GridView4.DataSource = challanout;
            //        GridView4.DataBind();
            //    }
            //} 
        }
    }
}
    


