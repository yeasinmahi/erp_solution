using System;

namespace UI.Inventory
{
    public partial class PdfViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Radpane11.ContentUrl = "ftp://erp:erp123@ftp.akij.net/SupplierDoc/1_Cheque-Statement_1250__MICRChequecopy.pdf";
            //RadWindow1.OpenerElementID = "ftp://erp:erp123@ftp.akij.net/SupplierDoc/1_Cheque-Statement_1250__MICRChequecopy.pdf";
        }
    }
}