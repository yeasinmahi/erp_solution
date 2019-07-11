using SAD_BLL.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.HR.Employee
{
    public partial class PointTargetChange : BasePage
    {
        DataTable dt = new DataTable();
        CustomerGeo obj = new CustomerGeo();
        int LineId, RegionId, AreaId, TerritoryId, PointId, ProductId, ProductUOM;
        decimal Qtypcs, Qty;
        DateTime Date;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadLine();
                LoadRegion();
                RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                LoadArea(RegionId);
                AreaId= Convert.ToInt32(ddlArea.SelectedValue);
                LoadTerritory(AreaId);
                TerritoryId = Convert.ToInt32(ddlTerritory.SelectedValue);
                LoadPoint(TerritoryId);
            }
        }

        #region========Load DropDown List=====
        public void LoadLine()
        {
            dt = obj.GetLine();
            ddlLine.Loads(dt, "intFGGroupID", "strFGGroupName");
        }

        public void LoadRegion()
        {
            dt = obj.GetRegion();
            ddlRegion.LoadWithSelect(dt, "intRegionId", "strRegion");
        }

        public void LoadArea(int regionId)
        {
            dt = obj.GetArea(regionId);
            ddlArea.LoadWithSelect(dt, "intareaid", "strarea");
        }

        

        public void LoadTerritory(int areaId)
        {
            dt = obj.GetTerritory(areaId);
            ddlTerritory.LoadWithSelect(dt, "intterritoryid", "strterritory");
        }

        public void LoadPoint(int territoryId)
        {
            dt = obj.GetPoint(territoryId);
            ddlPoint.LoadWithSelect(dt, "intpointid", "strpoint");
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
            LoadArea(RegionId);
            
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaId = Convert.ToInt32(ddlArea.SelectedValue);
            LoadTerritory(AreaId);
        }

        protected void ddlTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TerritoryId = Convert.ToInt32(ddlTerritory.SelectedValue);
            LoadPoint(TerritoryId);
        }
        #endregion =======End Dropdown========

        #region========Button Operations=====

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LineId = Convert.ToInt32(ddlLine.SelectedValue);
            PointId = Convert.ToInt32(ddlPoint.SelectedValue);
            Date = CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date;

            dt = obj.GetTargetChange(1,LineId,PointId,Date,0,0,0,0);

            if(dt.Rows.Count>0)
            {
                gridView.Loads(dt);
            }
            else
            {
                Toaster("Sorry! There is no data .", "Target Change", Common.TosterType.Warning);
            }

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string ProductId = gridView.DataKeys[row.RowIndex]?.Value.ToString();


            TextBox QTY = row.FindControl("lblmontargetconvqty") as TextBox;
            Label UOM = row.FindControl("lblpackqty") as Label;

            string strqty = QTY.Text;
            string strUOM = UOM.Text;

            decimal pcs = Convert.ToDecimal(strqty) * Convert.ToDecimal(strUOM);

            Label QTYPCS = row.FindControl("lblQTYPcs") as Label;

            QTYPCS.Text = pcs.ToString();

            LineId = Convert.ToInt32(ddlLine.SelectedValue);
            PointId = Convert.ToInt32(ddlPoint.SelectedValue);
            Date = CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date;

            if(!String.IsNullOrEmpty(QTY.Text) || QTY.Text!="0.00")
            {
                dt = obj.GetTargetChange(2, LineId, PointId, Date, Convert.ToInt32(ProductId), pcs, Convert.ToDecimal(strqty), Convert.ToInt32(strUOM));
                Toaster("Updated Successfully.", "Target Change", Common.TosterType.Warning);
            }
            else
            {
                Toaster("Please Enter Quantity.", "Target Change", Common.TosterType.Warning);
            }
            



        }

        #endregion =======End Button========

        #region========Load Grid Operations=====

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void lblmontargetconvqty_TextChanged(object sender, EventArgs e)
        {
            //GridViewRow row = ((Label)sender).NamingContainer;
            //TextBox QTY = row.FindControl("lblmontargetconvqty") as TextBox;
            //Label UOM = row.FindControl("lblpackqty") as Label;

            //decimal pcs = Convert.ToDecimal(QTY) * Convert.ToDecimal(UOM);

            //Label QTYPCS = row.FindControl("lblQTYPcs") as Label;

            //QTYPCS.Text = pcs.ToString();

        }

        #endregion =======End Grid========



    }
}