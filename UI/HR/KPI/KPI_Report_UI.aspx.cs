using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.KPI;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.Drawing;

namespace UI.HR.KPI
{
    public partial class KPI_Report_UI : BasePage
    {
        KPI_BLL objKPIReport = new KPI_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dt = new DataTable();
                dt = objKPIReport.TypeView();
                ddltype.DataSource = dt;
                ddltype.DataTextField = "strName";
                ddltype.DataValueField = "intID";
                ddltype.DataBind();


                dt = objKPIReport.UnitNameKPI();
                ddlunit.DataSource = dt;
                ddlunit.DataTextField = "Name";
                ddlunit.DataValueField = "ID";
                ddlunit.DataBind();

                Int32 unit = Int32.Parse(ddlunit.SelectedValue.ToString());
                dt = new DataTable();
                dt = objKPIReport.JobstaTIONNAME(unit);
                ddlJobstation.DataSource = dt;
                ddlJobstation.DataTextField = "Name";
                ddlJobstation.DataValueField = "ID";
                ddlJobstation.DataBind();
                ddlJobstation.Items.Insert(0, new ListItem("All", "0"));
                string evaluation = ddltype.SelectedItem.ToString();
                LblDtePO.Text = evaluation.ToString();

                dt = new DataTable();
                dt = objKPIReport.gradesummery();
                dgvlist.DataSource = dt;
                dgvlist.DataBind();

                pnlUpperControl.DataBind();

                
            }

        }

        protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 unit = Int32.Parse(ddlunit.SelectedValue.ToString());
            dt = new DataTable();
            dt = objKPIReport.JobstaTIONNAME(unit);
            ddlJobstation.DataSource = dt;
            ddlJobstation.DataTextField = "Name";
            ddlJobstation.DataValueField = "ID";
            ddlJobstation.DataBind();
           ddlJobstation.Items.Insert(0, new ListItem("All", "0"));
           
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string evaluation = ddltype.SelectedItem.ToString();
            LblDtePO.Text = evaluation.ToString();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var tes = (Label)e.Row.FindControl("lblGradeNumber");
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (tes.Text == "0" || tes.Text == "null" || tes.Text == "0.0000" || tes.Text == "")
                    {

                        cell.BackColor = Color.Empty;

                    }
                    else
                    {
                        cell.BackColor = Color.YellowGreen;
                    }
                }
            }






        }
        protected void btnShow_Click(object sender, EventArgs e)

        {
            Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            Int32 jobstation = int.Parse(ddlJobstation.SelectedValue.ToString());
            Int32 unit = Int32.Parse(ddlunit.SelectedValue.ToString());
            DateTime evdate = DateTime.Parse(TxtDte.Text.ToString());
            Int32 monthrange = Int32.Parse(evdate.ToString("MM"));
            int kpitype = int.Parse(ddltype.SelectedValue.ToString());
            if (RadioEmp.Checked == true)
            {
                int intType = 5;
                dt = new DataTable();
                dgvGridView.Visible = true;
                dt = objKPIReport.EmployeeKPIView(intType, 0, evdate, jobstation, unit, kpitype);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
                dgvSupervisor.Visible = false;
            }
            else if (RadioSuper.Checked == true)
            {
                dgvSupervisor.Visible = true;
                dgvGridView.Visible = false;
                dt = new DataTable();
                int intType = 6;
                dt = objKPIReport.EmployeeKPIView(intType, 0, evdate, jobstation, unit, kpitype);
                dgvSupervisor.DataSource = dt;
                dgvSupervisor.DataBind();

                decimal Assed =dt.AsEnumerable().Sum(row => row.Field<decimal>("Assesment"));
                decimal Remaing =dt.AsEnumerable().Sum(row => row.Field<decimal>("Remaining"));
                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));

                dgvSupervisor.FooterRow.Cells[3].Text = "Total";
                dgvSupervisor.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                dgvSupervisor.FooterRow.Cells[4].Text = Assed.ToString("N2");
                dgvSupervisor.FooterRow.Cells[5].Text = Remaing.ToString("N2");
                dgvSupervisor.FooterRow.Cells[6].Text = total.ToString("N2");

            }


        }

       
    }
}