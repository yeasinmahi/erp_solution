using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class EditRequisitionDetalis : BasePage
    {
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId, intBomStandard; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey;

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch { }
        }

        char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/ber__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML);  }
                catch { }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string  srrId = Request.QueryString["srrId"].ToString();
                string itemId = Request.QueryString["itemId"].ToString();
                int intwh = int.Parse(Request.QueryString["whid"].ToString());
                string Vtype = Request.QueryString["Vtype"].ToString();
                string dteFrom = Request.QueryString["dteFrom"].ToString();
                string dteTo = Request.QueryString["dteTo"].ToString();
                claenderDte.SelectedDate =DateTime.Parse(dteFrom.ToString());
                xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + "/></voucher>".ToString();
                if (Vtype=="Item")
                {
                    dt = objBom.GetBomData(12, xmlData, intwh, int.Parse(itemId), DateTime.Now, enroll);
                    if(dt.Rows.Count>0)
                    { 
                        dgvReq.DataSource = dt;
                        dgvReq.DataBind();
                    } 
                }
                else
                {
                    dt = objBom.GetBomData(13, xmlData, intwh, int.Parse(srrId), DateTime.Now, enroll);
                    dgvItems.DataSource = dt;
                    dgvItems.DataBind();
                }
              
                
            }

        }
    }
}