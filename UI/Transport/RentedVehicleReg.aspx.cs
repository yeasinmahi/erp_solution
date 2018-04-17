using SAD_BLL.Transport;
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
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
namespace UI.Transport
{
    public partial class RentedVehicleReg : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intUnitID; string strVehicleNo; int intVehicleType; string strDriverName;
        string strDriverContactNo; string strDriverLisenceNo; string strDriverNId;
        string strHelperName; int int3rdPartyCOAid; string strVehicleSupplier;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetVehicleSupplierList(intUnitID);
                    ddlVehicleSupplier.DataTextField = "strName";
                    ddlVehicleSupplier.DataValueField = "intCOAid";
                    ddlVehicleSupplier.DataSource = dt;
                    ddlVehicleSupplier.DataBind();

                    dt = obj.GetVehicleType(intUnitID);
                    ddlVehicleType.DataTextField = "strType";
                    ddlVehicleType.DataValueField = "intTypeId";
                    ddlVehicleType.DataSource = dt;
                    ddlVehicleType.DataBind();
                    
                }
                catch
                { }
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    strVehicleNo = txtVehicleNo.Text;
                    intVehicleType = int.Parse(ddlVehicleType.SelectedValue.ToString());
                    strDriverName = txtDriverName.Text;
                    strDriverContactNo = txtDContactNo.Text;
                    strDriverLisenceNo = txtDriverLisenceNo.Text;
                    strDriverNId = txtDriverNID.Text;
                    strHelperName = txtHelperName.Text;
                    int3rdPartyCOAid = int.Parse(ddlVehicleSupplier.SelectedValue.ToString());
                    strVehicleSupplier = ddlVehicleSupplier.SelectedItem.ToString();

                    string message = obj.InsertRentedVehicleReg(strVehicleNo, intUnitID, intVehicleType, strDriverName, strDriverContactNo, strDriverNId, strDriverLisenceNo, strHelperName);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

                    txtVehicleNo.Text = "";
                    txtDriverName.Text = "";
                    txtDContactNo.Text = "";
                    txtDriverLisenceNo.Text = "";
                    txtDriverNID.Text = "";
                    txtHelperName.Text = "";
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

            dt = obj.GetVehicleSupplierList(intUnitID);
            ddlVehicleSupplier.DataTextField = "strName";
            ddlVehicleSupplier.DataValueField = "intCOAid";
            ddlVehicleSupplier.DataSource = dt;
            ddlVehicleSupplier.DataBind();

            dt = obj.GetVehicleType(intUnitID);
            ddlVehicleType.DataTextField = "strType";
            ddlVehicleType.DataValueField = "intTypeId";
            ddlVehicleType.DataSource = dt;
            ddlVehicleType.DataBind();
        }












    }
}