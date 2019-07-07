using HR_BLL.TourPlan;
using Purchase_BLL.VehicleRegRenewal_BLL;
using SAD_BLL.AEFPS;
using SAD_BLL.Global;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Transport
{
    public partial class TransportVheicleInfoUpdate : System.Web.UI.Page
    {
        TourPlanning bll = new TourPlanning();
        private int _enroll;
        SetupBLL objsetup = new SetupBLL();
        DataTable dt = new DataTable();
        NewVehicleBLL objVehicle = new NewVehicleBLL();
      
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int vhclid;
        
        string Vno, DriverName, DriverNid, DriverContact, HelperName, LisenceNo, msg;
        int Unitid, enroll, Vid, helperenroll, UOMid, Locationid, Typeid, intCOAID, driverenroll;

       

        int? intCOAIDs;
        decimal DriverDA, diselperkm, HelperDA, DownTripAllowance, DownTripDA, MillageAllowance100KM, MillageAllowance100KMAbove, MillageLocal,
        MillageOutstation, CNGAllowance, DiselPerKmOutstation, DiselPerKMLocal, DiselPerKMLitter, DownTripDiselPerKM, CNGPerKM,
        LoadingCapacity, CNGPerKMOutstation;
       
        string[] arrayKeyItem; 
        protected void Page_Load(object sender, EventArgs e)
        {

      
            if (!IsPostBack)
            {
                txtVheicleNumber.Attributes.Add("onkeyUp", "SearchText();");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtVheicleNumber.Text))
                {
                    string strvheiclename = txtVheicleNumber.Text;
                  

                }
                else
                {
                   
                }
            }

        }
        protected void txtVheicleNumber_TextChanged(object sender, EventArgs e)
        {
            string strvheiclename = txtVheicleNumber.Text;
            string strSearchKey = txtVheicleNumber.Text;
            arrayKey = strSearchKey.Split(delimiterChars);

            string vhclname = arrayKey[0].ToString(); ;

            LoadFieldValue(vhclname);

        }

        [WebMethod]
        public static List<string> GetAutoserachingAssetName(string strSearchKey)
        {
            NewVehicleBLL bll = new NewVehicleBLL();

            List<string> result = new List<string>();
            result = bll.AutosearchingVhcleName(strSearchKey);
            return result;
        }


        private void LoadFieldValue(string vhclname)
        {
            //try
            //{
                string strvheiclename = txtVheicleNumber.Text;
                string strSearchKey = txtVheicleNumber.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                //string code = arrayKey[1].ToString();
                vhclname = arrayKey[0].ToString(); 
                //vhclid = int.Parse(code);
                //Session["intTSOEnroll"] = vhclid;


                NewVehicleBLL bll = new NewVehicleBLL();
                DataTable objDT = new DataTable();
                objDT = bll.GetDataVehicleInfo(vhclname);

                if (objDT.Rows.Count >= 0)
                {

                txtVheicleNumber.Text = objDT.Rows[0]["strRegNo"].ToString();
                //txtDriverName.Text = objDT.Rows[0]["strDriverName"].ToString();
                txtDriverContact.Text = objDT.Rows[0]["strDriverContact"].ToString();

                txtDriverNId.Text = objDT.Rows[0]["strDriverNID"].ToString();
                txthelperName.Text = objDT.Rows[0]["strHelperName"].ToString();
                txtLisence.Text = objDT.Rows[0]["strLisenceNo"].ToString();


                txtDriverDA.Text = objDT.Rows[0]["driverDA"].ToString();
                txtHelperdA.Text = objDT.Rows[0]["helperDA"].ToString();
                txtDowntripAllowance.Text = objDT.Rows[0]["monUpDownTripDiselPerLitter"].ToString();

                txtDownTripDA.Text = objDT.Rows[0]["DownTripDA"].ToString();
                MA100KM.Text = objDT.Rows[0]["monMillageAllow100KM"].ToString();
                txtMillageAllowance100KMAbove.Text = objDT.Rows[0]["monMillageAllow100KMAbove"].ToString();

                txtMillageLocal.Text = objDT.Rows[0]["monMillageAllowanceLocal"].ToString();
                txtOutstation.Text = objDT.Rows[0]["monMillageAllowanceOutStation"].ToString();
                txtCNGAllowance.Text = objDT.Rows[0]["monCNGAllowance"].ToString();

                txtDieselPerKMOutsation.Text = objDT.Rows[0]["monDieselPerKMOutStation"].ToString();
                txtcngperkmoutstation.Text = objDT.Rows[0]["monCNGPerKMOutStation"].ToString();
                txtDiselPerKMLitter.Text = objDT.Rows[0]["monDieselPerLitterKM"].ToString();

                txtDownTripDiselPerKM.Text = objDT.Rows[0]["monUpDownTripDiselPerLitter"].ToString();
                txtCNGPerKM.Text = objDT.Rows[0]["monCNGPerKM"].ToString();


            }


        }

    
      
     

        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

    


        [WebMethod]
        [ScriptMethod]
        public static string[] EmployeeSearch(string prefixText, int count = 0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetEmployeeSearch(prefixText);

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //if (hdnconfirm.Value == "1")
            //{



                Unitid = int.Parse(drdlUnit.SelectedValue.ToString());
                UOMid = int.Parse(ddlUOM.SelectedValue.ToString());
                Locationid = int.Parse(ddlLocation.SelectedValue.ToString());
                string strvheiclename = txtVheicleNumber.Text;
                string strSearchKey = txtVheicleNumber.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string vhclid = arrayKey[1].ToString();
                Vno = arrayKey[0].ToString();
                if (txtDriverName.Text == "0")
                {
                    driverenroll = 0;
                    DriverName = "";
                }
                else
                {
                    arrayKeyItem = txtDriverName.Text.Split(delimiterChars);
                    driverenroll = int.Parse((arrayKeyItem[1].ToString()));
                    DriverName = (arrayKeyItem[0].ToString());
                }

                if (txtDriverContact.Text == "")
                {
                    txtDriverContact.Text = "0";

                }
                else
                {
                    DriverContact = txtDriverContact.Text;
                }





                if (txtDriverNId.Text == "")
                {
                    txtDriverNId.Text = "0";

                }
                else
                {
                    DriverNid = txtDriverNId.Text;
                }



                if (txthelperName.Text == "")
                {
                    helperenroll = 0;
                    HelperName = "Na";
                }
            else
            {
                HelperName = txthelperName.Text;
            }


                //else
                //{
                //    try
                //    {
                //        arrayKeyItem = txthelperName.Text.Split(delimiterChars);
                //        helperenroll = int.Parse((arrayKeyItem[1].ToString()));
                //        HelperName = (arrayKeyItem[0].ToString());
                //    }
                //    catch { }
                //}
                if (txtLisence.Text == "")
                {
                    txtLisence.Text = "0.0";

                }
                else
                {
                    LisenceNo = txtLisence.Text;
                }

                if (txtDriverDA.Text == "")
                {
                    txtDriverDA.Text = "0.0";

                }
                else
                {
                    DriverDA = decimal.Parse(txtDriverDA.Text);
                }



                HelperDA = decimal.Parse(txtHelperdA.Text);

                if (txtDowntripAllowance.Text == "")
                {
                    txtDowntripAllowance.Text = "0.0";

                }
                else
                {
                    DownTripAllowance = decimal.Parse(txtDowntripAllowance.Text);
                }

                if (txtDownTripDA.Text == "")
                {
                    txtDownTripDA.Text = "0.0";

                }
                else
                {
                    DownTripDA = decimal.Parse(txtDownTripDA.Text);
                }

                if (MA100KM.Text == "")
                {
                    MA100KM.Text = "0.0";

                }
                else
                {
                    MillageAllowance100KM = decimal.Parse(MA100KM.Text);
                }

                if (txtMillageAllowance100KMAbove.Text == "")
                {
                    txtMillageAllowance100KMAbove.Text = "0.0";

                }
                else
                {
                    MillageAllowance100KMAbove = decimal.Parse(txtMillageAllowance100KMAbove.Text);
                }


                if (txtMillageLocal.Text == "")
                {
                    txtMillageLocal.Text = "0.0";

                }
                else
                {
                    MillageLocal = decimal.Parse(txtMillageLocal.Text);
                }

                if (txtOutstation.Text == "")
                {
                    txtOutstation.Text = "0.0";

                }
                else
                {
                    MillageOutstation = decimal.Parse(txtOutstation.Text);
                }

                if (txtCNGAllowance.Text == "")
                {
                    txtCNGAllowance.Text = "0.0";

                }
                else
                {
                    CNGAllowance = decimal.Parse(txtCNGAllowance.Text);
                }

                if (txtDieselPerKMOutsation.Text == "")
                {
                    txtDieselPerKMOutsation.Text = "0.0";

                }
                else
                {
                    DiselPerKmOutstation = decimal.Parse(txtDieselPerKMOutsation.Text);
                }




                //DiselPerKMLocal = decimal.Parse(txtDiselPerKMLocal.Text);
                UOMid = int.Parse(ddlUOM.SelectedValue.ToString());
                if (txtDiselPerKMLitter.Text == "")
                {
                    txtDiselPerKMLitter.Text = "0.0";

                }
                else
                {
                    DiselPerKMLitter = decimal.Parse(txtDiselPerKMLitter.Text);
                }

                if (txtDownTripDiselPerKM.Text == "")
                {
                    txtDownTripDiselPerKM.Text = "0.0";

                }
                else
                {
                    DownTripDiselPerKM = decimal.Parse(txtDownTripDiselPerKM.Text);
                }




                if (txtCNGPerKM.Text == "")
                {
                    txtCNGPerKM.Text = "0.0";

                }
                else
                {
                    CNGPerKM = decimal.Parse(txtCNGPerKM.Text);
                }


                intCOAID = 0;
                int unitid = int.Parse(drdlUnit.SelectedValue.ToString());
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                string msg = "";
                
                dt= objVehicle.GetvhcleInfoupdate(int.Parse(vhclid), Vno, DriverName, driverenroll, DriverContact, int.Parse(DriverNid), HelperName, LisenceNo, DriverDA
                , HelperDA, DownTripAllowance, DownTripDA
                , MillageAllowance100KM, MillageAllowance100KMAbove, MillageLocal, MillageOutstation, CNGAllowance
                , DiselPerKmOutstation, CNGPerKMOutstation, DiselPerKMLitter, DownTripDiselPerKM, CNGPerKM, enroll, unitid);
                msg = dt.Rows[0]["Messages"].ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);




            txtDriverName.Text = "";
                txtVheicleNumber.Text = "";
                txtDriverContact.Text = "";
                txtDriverNId.Text = "";
                txthelperName.Text = "";
                txtLisence.Text = "";
                txtDriverDA.Text = "";
                txtHelperdA.Text = "";
                txtDowntripAllowance.Text = "";
                txtDownTripDA.Text = "";
                MA100KM.Text = "";
                txtMillageAllowance100KMAbove.Text = "";
                txtMillageLocal.Text = "";
                txtOutstation.Text = "";
                txtCNGAllowance.Text = "";
                txtDieselPerKMOutsation.Text = "";
                //txtDiselPerKMLocal.Text = "";
                txtDiselPerKMLitter.Text = "";
                txtDownTripDiselPerKM.Text = "";
                txtCNGPerKM.Text = "";
                //txtLoadingcapacity.Text = "";
                //txtCNGPerKMOustStation.Text = "";
                //txtDiselPerKM.Text = "";
                //}

            //}

        }
    }
}