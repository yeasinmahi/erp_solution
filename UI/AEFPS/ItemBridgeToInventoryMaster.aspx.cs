
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class ItemBridgeToInventoryMaster : System.Web.UI.Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();
        int _intEnroll=0;
        DataTable _dt = new DataTable();
        FPSSalesEntryBLL objFPS = new FPSSalesEntryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           // _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
               
               // LoadInActiveGridView();

                GetItemList();
            }
        }

        private void GetItemList()
        {
           //_dt=
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            //string itemName = txtItemName.Text;
            //if (!string.IsNullOrWhiteSpace(itemName))
            //{
            string itemNameFull = txtItemname.Text;
            int itemId = Utility.Common.GetIdFromString(itemNameFull);
            string[] arrayKeyItem; char[] delimiterChars = { '[', ']' };
            char[] delimiterCharss = { '[', ']' };
            arrayKeyItem = txtItemname.Text.Split(delimiterCharss);
            string ItemName = (arrayKeyItem[0].ToString());
           

            objFPS.getinsert(itemId, itemId, ItemName,0);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Successfully Add.');", true);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] ItemnameSearch(string prefixText, int count = 0)
        {
            FPSSalesEntryBLL objFPSSaleEntry = new FPSSalesEntryBLL();
            return objFPSSaleEntry.GetItemSearchMaster(prefixText);

        }
        
        [WebMethod]
        public static List<string> GetItem(string prefix)
        {
            return Receive_BLL.GetItem(prefix);
        }

        
    }
}