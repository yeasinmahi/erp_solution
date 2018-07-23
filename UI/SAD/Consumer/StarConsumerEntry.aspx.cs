using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial;
using SAD_BLL.Consumer;
using Utility;

namespace UI.SAD.Consumer
{
    public partial class StarConsumerEntry : System.Web.UI.Page
    {
        private readonly StarConsumerEntryBll _starConsumerEntryBll = new StarConsumerEntryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadTeritoryDropDown();
                LoadProgramDropDown();
            }
        }

        protected void btnAddBikeCarUser_OnClickAddBikeCarUser_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnSubmitBikeCar_OnClickCar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grdvOvertimeEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grdvOvertimeEntry_OnRowDeletingmeEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void LoadTeritoryDropDown()
        {
            DataTable dataTable =  _starConsumerEntryBll.GetTeritory("ahmed.accl@akij.net");
            ddlTeritory.DataSource = dataTable;
            ddlTeritory.DataValueField = "intID";
            ddlTeritory.DataTextField = "strText";
            ddlTeritory.DataBind();
        }
        private void LoadProgramDropDown()
        {
            DataTable dataTable = _starConsumerEntryBll.GetProgram();
            ddlProgram.DataSource = dataTable;
            ddlProgram.DataValueField = "intProgramID";
            ddlProgram.DataTextField = "strProgramName";
            ddlProgram.DataBind();
        }

        private void LoadDoubleCashOfferGridView(string teritory, DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = _starConsumerEntryBll.GetDoubleCashOffer(teritory, fromDate, toDate);
            grdvDoubleCashOffer.DataSource = dataTable;
            grdvDoubleCashOffer.DataBind();
        }
        protected void showReport_OnClick(object sender, EventArgs e)
        {
            //string teritoryName = ddlTeritory.SelectedItem.Text;
            //string fromDate = fromTextBox.Text;
            //string toDate = toTextBox.Text;
            string teritoryName = "Faridpur";
            string fromDate = "05/01/2018";
            string toDate = "07/01/2018";
            DateTime fromDateTime = DateTimeConverter.StringToDateTime(fromDate, "MM/dd/yyyy");
            fromDateTime = fromDateTime.AddHours(6);
            DateTime toDateTime = DateTimeConverter.StringToDateTime(toDate, "MM/dd/yyyy");
            toDateTime = toDateTime.AddDays(1).AddHours(6).AddMilliseconds(-1);
            
            LoadDoubleCashOfferGridView(teritoryName, fromDateTime, toDateTime);
        }


        protected void add_OnClick(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

        }
    }
}