using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.Accounts.ChartOfAccount;
using UI.ClassFiles;

namespace UI.Accounts.ChartOfAccount
{
    //public partial class Accounts_ChartOfAccount_ChartOfAccounts : System.Web.UI.Page
    public partial class ChartOfAccounts : BasePage
    {
        string userID = "";

        string unitID = "";
        /* protected override void OnPreInit(EventArgs e)
         {
             base.OnPreInit(e);
             Session["sesUserID"] = "1";
         }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                BuildTree(0);
                Session["sesValuePath"] = null;
            }


            userID = Session[SessionParams.USER_ID].ToString();
            // userID = "1";
        }

        private void BuildTree(int paretnt)
        {

            unitID = ddlUnit.SelectedValue;//"1";
            ChartOfAcc coa = new ChartOfAcc();
            TreeNode totalTree = coa.GetCOANodes(0, int.Parse(unitID));
            treeViewCOA.Nodes.Add(totalTree);
        }

        protected void treeViewCOA_SelectedNodeChanged(object sender, EventArgs e)
        {
            string virPath = "" + Session["sesValuePath"];
            if (Session["sesValuePath"] != null)
            {
                string priviousNodeText = treeViewCOA.FindNode(Session["sesValuePath"].ToString()).Text;

                priviousNodeText = priviousNodeText.Substring(0, priviousNodeText.IndexOf("&nbsp")) + "&nbsp:.";
                treeViewCOA.FindNode(Session["sesValuePath"].ToString()).Text = priviousNodeText;
            }
            TreeNode selectedNode = treeViewCOA.SelectedNode;
            //bool act = false;
            string text = selectedNode.Text;
            string[] values = GetValue(selectedNode.Value);
            /* if (bool.Parse(values[1]))
             {*/
            text = text.Substring(0, text.IndexOf("&nbsp"));

            text = text + "&nbsp";
            if (bool.Parse(values[3]) && bool.Parse(values[2]) && !bool.Parse(values[4]))
            {
                text = text + "<input id=\"btnAdd" + values[0] + "\" type=\"button\" value=\"N\"  onclick=\"ShowDiv('" + values[0] + "','0')\" />";
            }
            text = text + "<input id=\"btnAI" + values[0] + "\" type=\"button\" value=\"" + (bool.Parse(values[2]) ? "X" : "A") + "\" onclick=\"ShowDivAct('" + values[0] + "','" + (bool.Parse(values[2]) ? false : true) + "')\" />";
            text = text + "<input id=\"btnEdit" + values[0] + "\" type=\"button\" value=\"E\"  onclick=\"ShowDiv('" + values[0] + "','1')\" />";
            selectedNode.Text = text;



            /* }
             else
             {
             }*/

            Session["sesValuePath"] = selectedNode.ValuePath;
        }

        private string[] GetValue(string selectedValue)
        {
            return selectedValue.Split('#');
        }

        /*  private string GetPriviousNodeText(string pNodeText)
          {
 
          }*/

        // Add New Child / Edit A Node
        protected void btnPopSubmit_Click(object sender, EventArgs e)
        {
            string addEdit = hdnAddOrEdit.Value;
            int? moduleID = null;

            string unitID = ddlUnit.SelectedValue;
            ChartOfAcc coa = new ChartOfAcc();
            TreeNode curNode = treeViewCOA.SelectedNode;
            if (ChkModule.Checked)
            {
                moduleID = int.Parse(ddlModule.SelectedValue);
            }
            if (addEdit == "0") //add
            {
                string balance = txtCB.Text;
                if (balance == "")
                {
                    balance = "0";
                }
                string accID = coa.InsertAccount(
                                                txtAcc.Text
                                                , int.Parse(hdnParent.Value)
                                                , true // subledger
                                                , false // ledger
                                                , false
                                                , chkIncSt.Checked
                                                , chkBalSht.Checked
                                                , int.Parse(userID)
                                                , int.Parse(txtChildCodeLength.Text)
                                                , moduleID
                                                , int.Parse(unitID)
                                                , decimal.Parse(balance)

                                                );
                if (accID != "-1")
                {



                    curNode.ChildNodes.Add(new TreeNode(txtAcc.Text + "&nbsp:.", (accID + "#" + "true" + "#" + "true#" + (moduleID == null ? "true" : "false") + "#false")));
                }


            }
            else if (addEdit == "1")
            {
                string text = "", value = "";
                bool ysnEditSuccess = coa.COAAccountEdit
                                    (
                                        txtAcc.Text
                                        , int.Parse(hdnParent.Value)
                                        , false
                                        , chkLed.Checked
                                        , false
                                        , chkIncSt.Checked
                                        , chkBalSht.Checked
                                        , int.Parse(userID)
                                        , int.Parse(txtChildCodeLength.Text)
                                        , moduleID
                                        , int.Parse(unitID)
                                        , ref text
                                        , ref value

                                    );


                if (ysnEditSuccess)
                {
                    curNode.Value = value;

                    string[] values = GetValue(curNode.Value);
                    if (bool.Parse(values[1]))
                    {
                        //text = text.Substring(0, text.IndexOf("&nbsp"));
                        if (bool.Parse(values[2]))
                        {
                            text = text + "&nbsp";
                        }
                        else
                        {
                            text = "<font color=\"red\">" + text + "&nbsp</font>";
                        }
                        if (bool.Parse(values[3]) && bool.Parse(values[2]) && !bool.Parse(values[4]))
                        {
                            text = text + "<input id=\"btnAdd" + values[0] + "\" type=\"button\" value=\"N\"  onclick=\"ShowDiv('" + values[0] + "','0')\" />";
                        }
                        text = text + "<input id=\"btnAI" + values[0] + "\" type=\"button\" value=\"" + (bool.Parse(values[2]) ? "X" : "A") + "\" onclick=\"ShowDivAct('" + values[0] + "','" + (bool.Parse(values[2]) ? false : true) + "')\" />";
                        text = text + "<input id=\"btnEdit" + values[0] + "\" type=\"button\" value=\"E\"  onclick=\"ShowDiv('" + values[0] + "','1')\" />";
                        curNode.Text = text;



                    }
                    Session["sesValuePath"] = curNode.ValuePath;

                }

            }

            ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);
        }

        // Active Inactive 
        protected void btnAct_Click(object sender, EventArgs e)
        {

            unitID = ddlUnit.SelectedValue;
            bool ysnSuccess = false;
            string text = "", value = "";
            ChartOfAcc coa = new ChartOfAcc();

            ysnSuccess = coa.COAAccountEnableDisable(
                                          int.Parse(hdnParent.Value)
                                         , int.Parse(userID)
                                         , int.Parse(unitID)
                                         , bool.Parse(hdnYsnEnable.Value)
                                         , chkOnlyThis.Checked
                                         , ref text
                                         , ref value
                                         );

            if (ysnSuccess) // bind the specificNodes
            {
                TreeNode selectedNode = treeViewCOA.SelectedNode;
                TreeNode newNodes = coa.GetCOANodes(int.Parse(hdnParent.Value), int.Parse(unitID));
                selectedNode.Value = value;
                string[] values = GetValue(selectedNode.Value);
                if (!bool.Parse(values[2]))
                {
                    text = "<font color=\"red\">" + text + "&nbsp</font>";

                    selectedNode.Value = value;
                }


                Session["sesValuePath"] = selectedNode.ValuePath;



                if (bool.Parse(values[1]))
                {
                    //text = text.Substring(0, text.IndexOf("&nbsp"));

                    text = text + "&nbsp";
                    if (bool.Parse(values[3]) && bool.Parse(values[2]) && !bool.Parse(values[4]))
                    {
                        text = text + "<input id=\"btnAdd" + values[0] + "\" type=\"button\" value=\"N\"  onclick=\"ShowDiv('" + values[0] + "','0')\" />";
                    }
                    text = text + "<input id=\"btnAI" + values[0] + "\" type=\"button\" value=\"" + (bool.Parse(values[2]) ? "X" : "A") + "\" onclick=\"ShowDivAct('" + values[0] + "','" + (bool.Parse(values[2]) ? false : true) + "')\" />";
                    text = text + "<input id=\"btnEdit" + values[0] + "\" type=\"button\" value=\"E\"  onclick=\"ShowDiv('" + values[0] + "','1')\" />";
                    selectedNode.Text = text;



                }


                selectedNode.ChildNodes.Clear();
                TreeNode childNode;


                while (newNodes.ChildNodes.Count != 0)
                {
                    selectedNode.ChildNodes.Add(newNodes.ChildNodes[0]);
                }



            }

            ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeViewCOA.Nodes.Clear();
            Session["sesValuePath"] = null;
            BuildTree(0);
            treeViewCOA.ExpandDepth = 2;
        }
    }
}
