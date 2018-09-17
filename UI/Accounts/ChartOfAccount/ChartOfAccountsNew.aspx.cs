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
using DAL.Accounts.ChartOfAccount;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.ChartOfAccount
{
    public partial class ChartOfAccountsNew : BasePage
    {
        int parentID;
        int unitID;
        string userID = "";
        ChartOfAcc acc = new ChartOfAcc();
        ArrayList arr;
        public string jsString = "";
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\ChartOfAccount\\ChartOfAccountsNew";
        string stop = "stopping Accounts\\ChartOfAccount\\ChartOfAccountsNew";
        protected void Page_Load(object sender, EventArgs e)
        {
            string h = "";
            //Session["sesUserID"] = "1";
            userID = "" + Session[SessionParams.USER_ID];
            // ddlUnit.DataBind();
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\ChartOfAccount\\ChartOfAccountsNew   Page Load ", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    string pID = "" + Request.QueryString["COAID"];
                string gridNum = "" + Request.QueryString["dataGrid"];
                string accountName = "" + Request.QueryString["accName"];
                string ysnEnable = "" + Request.QueryString["enable"];
                string ysnhasModule = "" + Request.QueryString["module"];
                string k = "" + Session["coaUnit"];
                if (k == "")
                {
                    ddlUnit.DataBind();
                    k = ddlUnit.SelectedValue;

                }
                else
                {
                    ddlUnit.SelectedIndex = int.Parse("" + Session["coaUnitIndex"]);
                }
                hdnUnit.Value = k;
                if (pID == "")
                {

                    Session["arrList"] = null;
                    parentID = 0;
                    unitID = int.Parse(k);
                }
                else
                {
                    parentID = int.Parse(pID);

                    unitID = int.Parse(k);
                    IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> tbl = acc.GetChildDataByParentID(unitID, parentID);
                    GridView2.DataSource = tbl;
                    GridView2.DataBind();
                    h = PrepareSiteMap(gridNum, pID, accountName, ysnEnable, ysnhasModule);
                }


                lblSiteMap.Text = h;
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();

            }
            //else
            //{
            //    parentID = int.Parse("" + Request.QueryString["COAID"]);

            //    unitID = int.Parse("" + ddlUnit.SelectedValue);
            //}
        }


        private string PrepareSiteMap(string gridNumber, string accountNumber, string accountName, string ysnEnable, string ysnHasModule)
        {
            arr = (ArrayList)Session["arrList"];

            if (gridNumber == "1") // comes from 1st grid
            {
                if (arr != null)
                {
                    arr.Clear();
                }
                else
                {
                    arr = new ArrayList();
                }

            }

            //arr.Add(accountNumber + "#" + GetData(accountNumber, gridNumber, accountName, "true", (ysnHasModule == "false" ? "" : ysnHasModule), ysnEnable));

            string[] k;
            string fiStr = "";
            int i;
            bool ysnNodeExists = false;
            for (i = 0; i < arr.Count; i++)
            {
                k = arr[i].ToString().Split('#');
                if (i == 0)
                {
                    fiStr = fiStr + k[1];
                }
                else
                {
                    fiStr = fiStr + " > " + k[1];
                    //k = k + ">" + ht[i];
                }
                if (k[0] == accountNumber)
                {
                    ysnNodeExists = true;
                    break;
                }

            }

            if (ysnNodeExists)
            {
                for (int j = arr.Count - 1; j > i; j--)
                {
                    arr.RemoveAt(j);
                }
            }
            else
            {
                string tmp = GetData(accountNumber, gridNumber, accountName, "true", (ysnHasModule == "false" ? "" : ysnHasModule), ysnEnable);
                arr.Add(accountNumber + "#" + tmp);
                fiStr = fiStr + "> " + tmp;
            }


            Session["arrList"] = arr;

            if (bool.Parse(ysnEnable) && !bool.Parse(ysnHasModule))
            {
                fiStr = fiStr + " <a href=\"#\" onclick=\"ShowDiv('" + accountNumber + "','0','-1')\">";
                fiStr = fiStr + "<img alt=\"\" src=\"../../Content/images/icons/Add.ico\" style=\"border: 0px;\" title=\"Add Account\" />";
                fiStr = fiStr + "</a>";


            }
            return fiStr;


        }

        // private string[] ParseString

        public string GetData(string accountID, string gridNum, string accountName, string ysnChildHas, string moduleID, string ysnEnable)
        {


            string hypaerString;
            hypaerString = "<a href=\"ChartOfAccountsNew.aspx?COAID=";
            hypaerString = hypaerString + accountID;
            hypaerString = hypaerString + "&dataGrid=";
            hypaerString = hypaerString + gridNum;
            hypaerString = hypaerString + "&accName=";
            hypaerString = hypaerString + accountName;
            hypaerString = hypaerString + "&module=";
            hypaerString = hypaerString + (moduleID == "" ? "false" : "true");
            hypaerString = hypaerString + "&enable=";
            hypaerString = hypaerString + ysnEnable;//(ysnEnable == "true" ? "1" : "0");
            hypaerString = hypaerString + "\"";
            hypaerString = hypaerString + ">";
            hypaerString = hypaerString + accountName;
            hypaerString = hypaerString + "</a>";
            return hypaerString;
        }

        public string GetDataForEdit(string accountID, string gridNum, string accountName, string ysnChildHas, string moduleID, string ysnEnable)
        {
            string fiStr = "";
            fiStr = fiStr + " <a href=\"#\" onclick=\"ShowDiv('" + accountID + "','1','" + gridNum + "')\">";
            fiStr = fiStr + "Edit";
            fiStr = fiStr + "</a>";
            return fiStr;
        }

        protected void btnPopSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\ChartOfAccount\\ChartOfAccountsNew   Submit ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string addEdit = hdnAddOrEdit.Value;
            int? moduleID = null;
            string accID = "";
            unitID = int.Parse(ddlUnit.SelectedValue);
            ChartOfAcc coa = new ChartOfAcc();
            //TreeNode curNode = treeViewCOA.SelectedNode;
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
                accID = coa.InsertAccount(
                                                 txtAcc.Text.Trim()
                                                 , int.Parse(hdnParent.Value)
                                                 , true // subledger
                                                 , false // ledger
                                                 , false
                                                 , chkIncSt.Checked
                                                 , chkBalSht.Checked
                                                 , int.Parse(userID)
                                                 , int.Parse(txtChildCodeLength.Text)
                                                 , moduleID
                                                 , unitID
                                                 , decimal.Parse(balance)

                                                 );
                if (accID != "-1")
                {
                    ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);


                    // GridView2.DataBind();



                }


            }
            else if (addEdit == "1")
            {
                string text = "", value = "";
                bool ysnEditSuccess = coa.COAAccountEdit
                                    (
                                        txtAcc.Text.Trim()
                                        , int.Parse(hdnParent.Value)
                                        , false
                                        , chkLed.Checked
                                        , false
                                        , chkIncSt.Checked
                                        , chkBalSht.Checked
                                        , int.Parse(userID)
                                        , int.Parse(txtChildCodeLength.Text)
                                        , moduleID
                                        , unitID
                                        , ref text
                                        , ref value

                                    );


                if (ysnEditSuccess)
                {
                    // GridView1.DataBind();
                    // GridView2.DataBind();

                }

            }

            ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);

            if (addEdit == "1")
            {
                if (hdnGridNum.Value == "1")
                {
                    GridView1.DataBind();
                }
                else
                {
                    arr = (ArrayList)Session["arrList"];
                    string k = arr[arr.Count - 1].ToString();
                    string id = k.Substring(0, k.IndexOf('#'));
                    //parentID = int.Parse(hdnParent.Value);
                    parentID = int.Parse(id);
                    // unitID = int.Parse(ddlUnit.SelectedValue);
                    IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> tbl = acc.GetChildDataByParentID(unitID, parentID);
                    GridView2.DataSource = tbl;
                    GridView2.DataBind();
                }
            }
            else
            {
                parentID = int.Parse(hdnParent.Value);
                if (accID != "-22")
                {
                    IEnumerable<ChartOfAccTDS.TblAccountsChartOfAccRow> tbl = acc.GetChildDataByParentID(unitID, parentID);
                    GridView2.DataSource = tbl;
                    GridView2.DataBind();
                }
                if (accID == "-22")
                {
                    pnlScript.Visible = true;

                    // jsString= "alert('Already Exists')";

                    // pnlScript.DataBind();
                }


            }
                //GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }




        protected void btnAct_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAct_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\ChartOfAccount\\ChartOfAccountsNew   btnAct_Click ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                unitID = int.Parse("" + ddlUnit.SelectedValue);
            bool ysnSuccess = false;
            string text = "", value = "";

            ChartOfAcc coaT = new ChartOfAcc();

            ysnSuccess = coaT.COAAccountEnableDisable(
                                          int.Parse(hdnParent.Value)
                                         , int.Parse(userID)
                                         , unitID
                                         , bool.Parse(hdnYsnEnable.Value)
                                         , chkOnlyThis.Checked
                                         , ref text
                                         , ref value
                                         );

            if (ysnSuccess) // bind the specificNodes
            {


            }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnAct_Click", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "btnAct_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["coaUnit"] = ddlUnit.SelectedValue;
            Session["coaUnitIndex"] = ddlUnit.SelectedIndex;
            hdnUnit.Value = ddlUnit.SelectedValue;
            GridView1.DataBind();
            GridView2.DataSource = null;
            // arr.Clear();
            lblSiteMap.Text = "";
            GridView2.DataBind();
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCOAList(string prefixText, int count)
        {
            HttpContext.Current.Session["sesCurrentUnit"] = "1";
            string l = HttpContext.Current.Session["sesCurrentUnit"].ToString();
            return ChartOfAccStaticDataProvider.GetCOAInsertSugessionDataForAutoFill(HttpContext.Current.Session["sesCurrentUnit"].ToString(), prefixText);
        }


        [System.Web.Services.WebMethod]
        public static string[] GetInfo(int parent)
        {
           
            ChartOfAcc coa = new ChartOfAcc();
            ChartOfAccTDS.TblAccountsChartOfAccDataTable tbl = coa.GetDataByAccountIDForEdit(parent);
            string[] rtnStrArr = new string[10];
            rtnStrArr[0] = tbl[0].strAccName;
            rtnStrArr[1] = tbl[0].IsintModulesAutoIDNull() ? "0" : "1";
            rtnStrArr[2] = tbl[0].IsintModulesAutoIDNull() ? "-1" : tbl[0].intModulesAutoID;
            rtnStrArr[3] = tbl[0].intChildCodeLength.ToString();
            rtnStrArr[4] = tbl[0].ysnSubLedger ? "1" : "0";
            rtnStrArr[5] = tbl[0].ysnLedger ? "1" : "0";
            rtnStrArr[6] = tbl[0].ysnTrBalance ? "1" : "0";
            rtnStrArr[7] = tbl[0].ysnIncomeSt ? "1" : "0";
            rtnStrArr[8] = tbl[0].ysnBalanceSh ? "1" : "0";
            rtnStrArr[9] = tbl[0].IsmonCurrentBalanceNull() ? "0" : tbl[0].monCurrentBalance.ToString();
          
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to register this employee !!!');", true);
           // string result1 = "himadri";
            return rtnStrArr;
        }
        protected void btnReloadCOA_Click(object sender, EventArgs e)
        {
            ChartOfAccStaticDataProvider.ReloadCOA(ddlUnit.SelectedValue);

        }
    }
}
