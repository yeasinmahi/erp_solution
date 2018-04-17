using Dairy_BLL;
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

namespace UI.Dairy
{
    public partial class Milk_MR_Details_Report : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; int intCCID; DateTime dteFrom; DateTime dteTo; int intWork; int intSuppID; int intMRNo; int intPart;
        string strCCID; string strMRNo; string strMRDate; string unitname; string CCName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //intID = int.Parse(Request.QueryString["intID"].ToString());
                //HttpContext.Current.Session["intID"] = intID.ToString();

                strCCID = Request.QueryString["CCID"].ToString();
                strMRNo = Request.QueryString["MRNO"].ToString();
                strMRDate = Request.QueryString["MRDATE"].ToString();

                unitname = Session["UnitName"].ToString();
                CCName = Session["CCName"].ToString();

                LoadGrid(); 
            }
        }

        private void LoadGrid()
        {
            lblUnitName.Text = unitname.ToString();
            lblCCName.Text = CCName.ToString();
            lblFromToDate.Text = "MR No.:- " + strMRNo + " & MR Date:- " + Convert.ToDateTime(strMRDate.ToString()).ToString("yyyy-MM-dd");

            intCCID = int.Parse(strCCID.ToString());
            intWork = 2;

            dteFrom = DateTime.Parse(strMRDate.ToString());
            dteTo = DateTime.Parse(strMRDate.ToString());

            intSuppID = 0;
            intMRNo = int.Parse(strMRNo.ToString());
            intPart = 0;

            dt = new DataTable();
            dt = obj.GetMilkMRReport(intWork, dteFrom, dteTo, intCCID, intSuppID, intMRNo, intPart);
            dgvMRReport.DataSource = dt;
            dgvMRReport.DataBind();
        }

        protected decimal tmrqty = 0;
        protected decimal tdeducqtyamo = 0;
        protected decimal tdecucfatamo = 0;
        protected decimal tmramo = 0;
        protected decimal tchalanqty = 0;
        protected decimal tchalanamo = 0;

        protected void dgvMRReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    tmrqty += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblMRQty")).Text);
                    tdeducqtyamo += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblDeductAmou")).Text);
                    tdecucfatamo += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblDeductFatPAmou")).Text);
                    tmramo += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblMRAmount")).Text);
                    tchalanqty += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblChallanQty")).Text);
                    tchalanamo += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblChallanAmount")).Text);
                }
            }
            catch { }
        }














    }
}