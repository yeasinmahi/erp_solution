using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Imports;
using System.Data;
using UI.ClassFiles;


namespace UI.Import
{
    public partial class ImportMainApporval_UI : BasePage
    {
        Import_BLL objImport = new Import_BLL();
        DataTable dt = new DataTable();
        DataTable dtApp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //try
                //{
                    //LoadGrid();
                    pnlUpperControl.DataBind();
                    dt = objImport.UnitName();
                    DdlUnit.DataSource = dt;
                    DdlUnit.DataTextField = "strUnit";
                    DdlUnit.DataValueField = "intUnitID";
                    DdlUnit.DataBind();
                //}
                //catch
                //{
                //    pnlUpperControl.DataBind();
                //    dt = objImport.UnitName();
                //    DdlUnit.DataSource = dt;
                //    DdlUnit.DataTextField = "strUnit";
                //    DdlUnit.DataValueField = "intUnitID";
                //    DdlUnit.DataBind();

            //}

                

            }
            //else
            //{
            //    //intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            //    //intShipPointID = int.Parse(ddlShipPoint.SelectedValue.ToString());
            //    //intCheck = int.Parse(ddlReportType.SelectedValue.ToString());

            //    //HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
            //    //HttpContext.Current.Session["intShipPointID"] = intShipPointID.ToString();
            //    //HttpContext.Current.Session["intCheck"] = intCheck.ToString();
            //}
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            Int32 unit=Int32.Parse(DdlUnit.SelectedValue.ToString());
            Int32 type = Int32.Parse(DdlType.SelectedValue.ToString());
            DgvMReport.Visible = true;
            dt=objImport.MainIndentView(unit,type);
            if(dt.Rows.Count>0)
            {
                DgvMReport.DataSource = dt;
                DgvMReport.DataBind();
             }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true);
            DgvMReport.Visible = false;
            }

                
        }

       
        public string GetJSFunctionString(object intRFQID, object ysnComplete, object numQuote)
        {
            string str = "";
            str = intRFQID.ToString() + ',' + ysnComplete.ToString() + ',' + numQuote.ToString();
            return str;
        }
        protected void BtnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                string ordernumber1 = datas[0].ToString();
                string ordernumber2 = datas[1].ToString();
               string ordernumber3 = datas[2].ToString();
               if (ordernumber3 != "0")
               {
                   if (ordernumber2 == "False")
                   {
                       // Response.Write(ordernumber); 
                       Session["strRFIQID"] = ordernumber1;

                       ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocMViewDatas('ImportApproval.aspx');", true);
                   }
                   else if (ordernumber2 == "True")
                   {
                       // Response.Write(ordernumber); 
                       Session["strRFIQID"] = ordernumber1;

                       ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocMViewDatas('ImportApproveStatus.aspx');", true);
                   }

               }
               else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true); }

            }
            catch { }
        }

        protected void DdlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvMReport.Visible = false;
            
        }
    }
}