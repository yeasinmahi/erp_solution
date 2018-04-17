using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LOGIS_BLL.GetInOut;
using UI.ClassFiles;
using System.Xml;
using System.IO;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace UI.GetInOut
{
    public partial class GetpassReceive :BasePage
    {
        GetInoutstatus getpass = new GetInoutstatus();
        DataTable getpassload = new DataTable();
        DataTable vehiclelist = new DataTable();
        DataTable unitname = new DataTable();
        DataTable getpassstatus = new DataTable();
        DataTable jobstation = new DataTable();
        DataTable getpassreceive = new DataTable();


        DataTable allGriedload = new DataTable();
        DataTable corporetgetpassin = new DataTable();
        int Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intRID = Int32.Parse("0".ToString());
                string code = 0.ToString();
                string vehicleno = "0".ToString();
                string driver = "0".ToString();
                Int32 fowardenroll = Int32.Parse("0".ToString());
                pnlUpperControl.DataBind();
                Item = 3;
                if (Item == 3)
                {
                   
                    getpassreceive = getpass.GetpassreceiveConfirmationUser(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                    dgvGetpassRecieve.DataSource = getpassreceive;
                    dgvGetpassRecieve.DataBind();

                }
                Item = 5;
                getpassstatus = getpass.GetpassreceiveStatus(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                dgvStatus.DataSource = getpassstatus;
                dgvStatus.DataBind();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);

            string ordernumber1 = searchKey[0].ToString();
            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            Int32 intRID = Int32.Parse("0".ToString());
            string code = ordernumber1.ToString();
           // string code = 0.ToString();
            string vehicleno = "0".ToString();
            string driver = "0".ToString();
            Int32 fowardenroll = Int32.Parse("0".ToString());
            Item = 4;
            getpass.GetpassreceiveConfirmationConfirmation(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('GetPass Received  Successfull');", true);


            Item = 3;
            if (Item == 3)
            {
                getpassreceive = getpass.GetpassreceiveConfirmationUser(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
                dgvGetpassRecieve.DataSource = getpassreceive;
                dgvGetpassRecieve.DataBind();

            }

            Item = 5;
            getpassstatus = getpass.GetpassreceiveStatus(Item, intRID, code, vehicleno, intenroll, intuntid, intjobid, driver, fowardenroll);
            dgvStatus.DataSource = getpassstatus;
            dgvStatus.DataBind();
        }

        protected void BtnDetalis_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string getpassNo = searchKey[0].ToString();

                    
                    Session["intRTGetInGetPass"] = getpassNo;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('GetpassRecieveDetalis.aspx');", true);

                }
                catch { }
            }
        }
    }
}