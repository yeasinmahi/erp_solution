using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SAD_BLL.Item;
using SAD_DAL.Item;

namespace UI.SAD.Item
{
    public partial class ItemManagerUOM : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlBOM.Attributes.Add("onChange", "DDLChange('ddlBOM', 'lblBOM')");
                ddlSell.Attributes.Add("onChange", "DDLChange('ddlSell', 'lblSell')");
            }
        }

        protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnbDisByCatagory();
            lblSell.Text = ddlSell.SelectedItem.Text;
            lblUOM.Text = "Add unit " + ddlSell.SelectedItem.Text + " for UOM";
        }

        protected void ddlCatagory_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnbDisByCatagory();
            }
        }

        private void EnbDisByCatagory()
        {
            SAD_BLL.Item.ItemManager im = new SAD_BLL.Item.ItemManager();
            ItemManagerTDS.TblItemManagerCetagoryDataTable table = im.GetItemCatagoryByID(ddlCatagory.SelectedValue);
            if (table[0].intType == 1)//FinishGood
            {
                lblSellUOM.Text = "Selling UOM";
                pnlBOM.Visible = true;
                pnlRawOther.Visible = false;
                pnlFG.Visible = true;
            }
            else if (table[0].intType == 2)//Rawmaetrials
            {
                lblSellUOM.Text = "Counting UOM";
                pnlBOM.Visible = false;
                pnlRawOther.Visible = true;
                pnlFG.Visible = false;
            }
            else if (table[0].intType == 3)//Intermediate
            {
                lblSellUOM.Text = "Counting UOM";
                pnlBOM.Visible = false;
                pnlRawOther.Visible = false;
                pnlFG.Visible = false;
            }
        }
        protected void rdoUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBOM.DataBind();
            SelectUOM();
            lblSell.Text = ddlSell.SelectedItem.Text;
            lblUOM.Text = "Add unit " + ddlSell.SelectedItem.Text + " for UOM";
        }

        private void SelectUOM()
        {
            switch (rdoUOM.SelectedValue)
            {
                case "1":
                    ShowOrNot(pnlSize);
                    break;
                case "2":
                    ShowOrNot(pnlWeight);
                    break;
                case "5":
                    ShowOrNot(pnlVolume);
                    break;
            }
        }
        private void ShowOrNot(Control cntr)
        {
            if (pnlSize.ID == cntr.ID) pnlSize.Visible = true; else pnlSize.Visible = false;
            if (pnlVolume.ID == cntr.ID) pnlVolume.Visible = true; else pnlVolume.Visible = false;
            if (pnlWeight.ID == cntr.ID) pnlWeight.Visible = true; else pnlWeight.Visible = false;
        }
        protected void rdoUOM_DataBound(object sender, EventArgs e)
        {
            rdoUOM.SelectedIndex = 0;
            SelectUOM();
        }
        protected void ddlSell_DataBound(object sender, EventArgs e)
        {
            lblSell.Text = ddlSell.SelectedItem.Text;
            lblUOM.Text = "Add unit " + ddlSell.SelectedItem.Text + " for UOM";
        }
        protected void ddlBOM_DataBound(object sender, EventArgs e)
        {
            lblBOM.Text = ddlBOM.SelectedItem.Text;
        }
    }
}
