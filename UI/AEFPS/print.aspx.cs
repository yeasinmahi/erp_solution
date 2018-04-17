using System;

using System.Data;

using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;

using System.IO;

using System.Text;

using System.Web.SessionState;
using SAD_BLL.AEFPS;

namespace UI.AEFPS
{
    public partial class print : System.Web.UI.Page
    {
        int whid, empid, intpaymenttype;
        string strCustomerName, strWHName, svno;
        decimal ReceiveAmt, monCashReturn, monCredit;
        DataTable dtr;
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                   svno = (HttpContext.Current.Session["svno"].ToString());
                    empid = int.Parse(HttpContext.Current.Session["empid"].ToString());
                   
                    lblWH.Text = HttpContext.Current.Session["strWHName"].ToString();
                    lblName.Text = HttpContext.Current.Session["strCustomerName"].ToString();
                    lblGetDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    lblVoucherShow.Text = "Challan No :"+(HttpContext.Current.Session["svno"].ToString());

                    dtr = objAEFPS.getSalesVoucherPrint(empid, svno);
                    dgvPrint.DataSource = dtr;
                    dgvPrint.DataBind();
                    decimal GTotal = 0;
                    GTotal = decimal.Parse(HttpContext.Current.Session["SalesAmount"].ToString());
                    if (intpaymenttype == 2)
                    {
                        ReceiveAmt = decimal.Parse("0");
                        monCashReturn = Math.Round((ReceiveAmt - 0), 0);
                        monCredit = Math.Round(Convert.ToDecimal(dtr.Rows[0]["TCredit"].ToString()), 0);
                    }
                    else
                    {
                        ReceiveAmt = decimal.Parse(HttpContext.Current.Session["SalesAmount"].ToString());
                        monCashReturn = Math.Round((ReceiveAmt - GTotal), 0);
                        monCredit = Math.Round(Convert.ToDecimal(dtr.Rows[0]["TCredit"].ToString()), 0);
                    }
                    //lblTotalCredit.Text = HttpContext.Current.Session["monCredit"].ToString();
                    //lblPayType.Text = HttpContext.Current.Session["strPayType"].ToString();
                    //lblSalesAmounts.Text = HttpContext.Current.Session["GTotal"].ToString();
                    //lblPaidAmount.Text = HttpContext.Current.Session["ReceiveAmt"].ToString();
                    //lblChangeAmount.Text = HttpContext.Current.Session["monCashReturn"].ToString();

                    lblTotalCredit.Text = monCredit.ToString();
                    lblPayType.Text = HttpContext.Current.Session["strPayType"].ToString();
                    lblSalesAmounts.Text = GTotal.ToString();
                    lblPaidAmount.Text = ReceiveAmt.ToString();
                    lblChangeAmount.Text = monCashReturn.ToString();
                }
                catch
                { }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
        //public PrintHelper()

        //{

        //    // 

        //    // TODO: Add constructor logic here 

        //    // 

        //}

        public static void PrintWebControl(Control ctrl)

        {

            PrintWebControl(ctrl, string.Empty);

        }



        public static void PrintWebControl(Control ctrl, string Script)

        {

            StringWriter stringWrite = new StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

            if (ctrl is WebControl)

            {

                Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;

            }

            Page pg = new Page();

            pg.EnableEventValidation = false;

            if (Script != string.Empty)

            {

                pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);

            }

            HtmlForm frm = new HtmlForm();

            pg.Controls.Add(frm);

            frm.Attributes.Add("runat", "server");

            frm.Controls.Add(ctrl);

            pg.DesignerInitialize();

            pg.RenderControl(htmlWrite);

            string strHTML = stringWrite.ToString();

            HttpContext.Current.Response.Clear();

            HttpContext.Current.Response.Write(strHTML);

            HttpContext.Current.Response.Write("<script>window.print();</script>");

            HttpContext.Current.Response.End();

        }

    }
}