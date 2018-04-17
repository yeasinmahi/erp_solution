using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class TADATopsheetForSingleEmployee : BasePage
    {
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        string strDate; string strTodate; string UNITS; string enrol1; string ReportType;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strDate = Session["Date"].ToString();
                DateTime dtfrom = Convert.ToDateTime(strDate);
                strTodate = Session["DateTodate"].ToString();
                DateTime dtTo = Convert.ToDateTime(strTodate);

                UNITS = Session["UNIT"].ToString();
                int unit = int.Parse(UNITS);
                enrol1 = Session["enrol1"].ToString();
                int enrol = int.Parse(enrol1);



                ReportType = Session["REPORTTYPE"].ToString();
                int report = int.Parse(ReportType);


                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                dt = bll.getRptTADABikeAndCarUserAuditlebel(dtfrom, dtTo, enrol, report);

                int reporTBasic=1;
                DataTable dtBasicinfo = new DataTable();
                dtBasicinfo = bll.getEmployeeBasicInfo(dtfrom, dtTo, unit, reporTBasic, enrol);

                if (dtBasicinfo.Rows.Count > 0)
                {
                    txtName.Text = dtBasicinfo.Rows[0][2].ToString();
                    textDesg.Text = dtBasicinfo.Rows[0][4].ToString();
                    txtDept.Text = dtBasicinfo.Rows[0][5].ToString();
                    txtLMbILL.Text = dtBasicinfo.Rows[0][6].ToString();
                    txtcmbill.Text = dtBasicinfo.Rows[0][8].ToString();
                    txtIdealMilage.Text = dtBasicinfo.Rows[0][9].ToString();
                    txtConsMilage.Text = dtBasicinfo.Rows[0][10].ToString();
                    txtQnt.Text = dtBasicinfo.Rows[0][11].ToString();
                    txtRation.Text = dtBasicinfo.Rows[0][12].ToString();
                    txtPresent.Text = dtBasicinfo.Rows[0][14].ToString();
                    txtBillday.Text = dtBasicinfo.Rows[0][15].ToString();
                }

            
            }
            catch
            {

            }

            if (dt.Rows.Count > 0)
            {

                grdvTopsheetorDetaills.DataSource = dt;
                grdvTopsheetorDetaills.DataBind();
            }

            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }


        }
        public string GetJSFunctionString(object enroll, object frmDate, object unit)
        {
            string str = "";
            str = enroll.ToString() + ',' + frmDate.ToString() + ',' + unit.ToString();
            return str;
        }
        protected void Attach_OnCommand(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("obl17"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "17";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();

                }
                else  if (e.CommandName.Equals("obl2"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "2";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();

                }


                else if (e.CommandName.Equals("obl3"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "3";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl4"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "4";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl5"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "5";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl6"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "6";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl7"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "7";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl8"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "8";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl9"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "9";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl10"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "10";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl11"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "11";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl13"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "13";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl12"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "12";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl14"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "14";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl15"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "15";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl16"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "16";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                else if (e.CommandName.Equals("obl18"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "18";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }

                else if (e.CommandName.Equals("obl19"))
                {
                    string value = (e.CommandArgument).ToString();
                    string[] data = value.Split(',');
                    Session["atttp"] = "19";
                    Session["enrol1"] = data[0].ToString();
                    Session["Date"] = DateTime.Parse(data[1].ToString()).ToString("yyyy-MM-dd");
                    Session["UNIT"] = data[2].ToString();
                }


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration();", true);
            }
            catch { }
        }

        protected void CompleteAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = temp.Split(delimiterChars);
                string intEnrol = searchKey[0].ToString();
                int enrol1 = int.Parse(intEnrol);
                Session["enrol1"] = enrol1;
                string dteDate = searchKey[1].ToString();
                DateTime strDate = DateTime.Parse(dteDate.ToString());
                Session["Date"] = strDate;
                string strunit = searchKey[2].ToString();
                int unit = int.Parse(strunit);
                Session["UNIT"] = unit;
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('AuditAttahmentChecking.aspx');", true);
           }

            catch
            {


            }

        }

        //protected void btnExportToExcel_Click(object sender, EventArgs e)
        //{
        //    grdvTopsheetorDetaills.AllowPaging = false;
        //    SAD_BLL.Customer.Report.ExportClass.Export("TADADetaills.xls", grdvTopsheetorDetaills);
        //}
    }
    }
