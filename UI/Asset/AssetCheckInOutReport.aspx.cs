using Flogging.Core;
using Purchase_BLL.Asset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class AssetCheckInOutReport : BasePage
    {
        AssetInOut objCheck = new AssetInOut();
        DataTable dt = new DataTable();
        int intResEnroll, intWHiD, intType, intActionBy; string assetCode, strNaration, stringXml;

        

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
            else { }

        }

        protected void btnAssetStatus_Click(object sender, EventArgs e)
        {
			var fd = GetFlogDetail("starting Asset\\AssetCheckInOutReport Show", null);

			Flogger.WriteDiagnostic(fd);

			// starting performance tracker
			var tracker = new PerfTracker("Performance on Asset\\AssetCheckInOutReport Show", "", fd.UserName, fd.Location,
				fd.Product, fd.Layer);
			try
            {
              
                intType = int.Parse(ddlType.SelectedValue);
                if(txtEnroll.Text.Length > 3)
                {

                    try
                    {
                        assetCode = txtEnroll.Text.ToString();
                        intResEnroll = int.Parse(txtEnroll.Text.ToString());
                    }
                    catch { }
                    if(intType==1)
                    {
                        dt = objCheck.AssetCheckInOutDataTable(8, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                        dgvAssetStatus.DataSource = dt;
                        dgvAssetStatus.DataBind();
                    }
                   else if (intType == 4)
                    {
                        dt = objCheck.AssetCheckInOutDataTable(7, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                        dgvAssetStatus.DataSource = dt;
                        dgvAssetStatus.DataBind();
                    }
                    else if (intType == 5)
                    {
                        dt = objCheck.AssetCheckInOutDataTable(7, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                        dgvAssetStatus.DataSource = dt;
                        dgvAssetStatus.DataBind();
                    }

                }
                else
                {
                    intResEnroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    dt = objCheck.AssetCheckInOutDataTable(7, stringXml, intType, intResEnroll, assetCode, intWHiD, strNaration, intActionBy);
                    dgvAssetStatus.DataSource = dt;
                    dgvAssetStatus.DataBind();
                }
               
            }
            catch (Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}

			fd = GetFlogDetail("stopping  Asset\\AssetCheckInOutReport Show", null);
			Flogger.WriteDiagnostic(fd);
			// ends
			tracker.Stop();

			int a = 30;

		}
		protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvAssetStatus.DataSource = "";
                dgvAssetStatus.DataBind();
            }
            catch { }

        }

		private FlogDetail GetFlogDetail(string message, Exception ex)
		{
			return new FlogDetail
			{
				Product = "ERP",
				Location = "Asset",
				Layer = "AssetCheckInOutReport\\Show",
				UserName = Environment.UserName,
				Hostname = Environment.MachineName,
				Message = message,
				Exception = ex
			};
		}
	}
}