using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LOGIS_BLL;
using UI.ClassFiles;


namespace UI.GetInOut
{
    public partial class VisitorIn : BasePage
    {
        visitorinout visitor = new visitorinout();
        DataTable view = new DataTable();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(! IsPostBack)
            {
                Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

                Int32 UnitId = int.Parse(Session[SessionParams.UNIT_ID].ToString());

                view = visitor.visitoroutinformation(UnitId);
                GridView1.DataSource = view;
                GridView1.DataBind();
                Txtvehicle.Visible = false; Lblvehicle.Visible = false;
                

            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 UnitId = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Txtenroll.Text = "00";
            string name = Txtname.Text;
            string type = Ddltype.Text;
            Int32 vienroll =Int32.Parse(Txtenroll.Text.ToString());
            string contact= Txtcontact.Text;
            string where =Txtwhere.Text;
            string objective=Txtobjective.Text;
            string transport = Ddltransport.Text;
            string area=Txtarea.Text;
            string contactperson=Txtcontactperson.Text;
            string vehicle = Txtvehicle.Text;

            visitor.visitorin(name,type,vienroll,contact,where,objective,transport,area,contactperson,enroll,UnitId,vehicle);
            Txtenroll.Text = "00";
            Txtname.Text = "";
            Txtcontact.Text = "";
            Txtenroll.Text = "";
            Txtobjective.Text = "";
            Txtvehicle.Text = "";
            Txtwhere.Text = "";
            Txtcontactperson.Text = "";
            Txtarea.Text = "";
            view = visitor.visitoroutinformation(UnitId);
            GridView1.DataSource = view;
            GridView1.DataBind();


            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 UnitId = int.Parse(Session[SessionParams.UNIT_ID].ToString());
            Int32 intId = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("Label6")).Text.ToString());

            visitor.visitorout(intId);

            view = visitor.visitoroutinformation(UnitId);
            GridView1.DataSource = view;
            GridView1.DataBind();
        }

        protected void Ddltransport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddltransport.SelectedItem.Text=="Own Vehicle")
            {
                Txtvehicle.Visible = true; Lblvehicle.Visible = true;
            }
            else
            {
                Txtvehicle.Visible = false; Lblvehicle.Visible = false;
            }
        }
    }
}