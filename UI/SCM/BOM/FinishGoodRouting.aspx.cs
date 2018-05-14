using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class FinishGoodRouting: BasePage
    {
        AssetMaintenance objWorkorderParts = new AssetMaintenance(); 
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "";


        int intItem; Int32 ysnTecnichin; int intjobid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                
            }
        }
         
    }
}