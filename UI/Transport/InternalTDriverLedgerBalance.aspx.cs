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
using System.Text;

namespace UI.Transport
{
    public partial class InternalTDriverLedgerBalance : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intWork; DateTime dteFromDate; DateTime dteToDate; int intShipPoint; int intFuelStationid;
        int intUnitID;  int intDriverEnroll; 

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

                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();
                                        
                    dt = new DataTable();
                    dt = obj.GetDriverListForLBalance(intUnitID);
                    ddlDriverName.DataTextField = "strEmployeeName";
                    ddlDriverName.DataValueField = "intEmployeeID";
                    ddlDriverName.DataSource = dt;
                    ddlDriverName.DataBind();

                }
                catch
                { }
            }                       
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intDriverEnroll = int.Parse(ddlDriverName.SelectedValue.ToString());

                if (intDriverEnroll == 0)
                { intWork = 1; intDriverEnroll = 0; }
                else { intWork = 0; intDriverEnroll = int.Parse(ddlDriverName.SelectedValue.ToString()); }

                Label1.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                if (intDriverEnroll == 0)
                {
                    Label2.Text = "All Driver";
                    dgvDriverLadgerBalance.Columns[1].HeaderText = "Driver Name";
                }
                else
                {
                    Label2.Text = "Driver Name: " + ddlDriverName.SelectedItem.ToString();
                    dgvDriverLadgerBalance.Columns[1].HeaderText = "Trip SL No.";
                }
                Label3.Text = "Balance Statement From " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                dt = new DataTable();
                dt = obj.GetDriverLedgerBalance(intWork, intShipPoint, dteFromDate, dteToDate, intDriverEnroll);
                dgvDriverLadgerBalance.DataSource = dt;
                dgvDriverLadgerBalance.DataBind();

                if (dt.Rows.Count > 0)
                {
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true); }
            }
            catch { }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();

            dt = new DataTable();
            dt = obj.GetDriverListForLBalance(intUnitID);
            ddlDriverName.DataTextField = "strEmployeeName";
            ddlDriverName.DataValueField = "intEmployeeID";
            ddlDriverName.DataSource = dt;
            ddlDriverName.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);           
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDriverLadgerBalance.DataSource = "";
            dgvDriverLadgerBalance.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);           
        }
        protected void ddlDriverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDriverLadgerBalance.DataSource = "";
            dgvDriverLadgerBalance.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);           
        }








    }
}