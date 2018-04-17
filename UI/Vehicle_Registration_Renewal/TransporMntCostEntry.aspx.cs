using Purchase_BLL.VehicleRegRenewal_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class TransporMntCostEntry : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string serial;
        RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
        int unitid; int inactiveby; string message;
        string filePathForXML;
        string xmlString = "";
        int intCOAid; int RowIndex;
        protected decimal grandtotal = 0; protected decimal drvallow = 0;
        protected decimal factmnt = 0; protected decimal homnts = 0; protected decimal workshpmnt = 0;
        




        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SAD/Order/Data/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "mntcostentry.xml");

            if (!IsPostBack)
            {
                txtVheicleNumber.Attributes.Add("onkeyUp", "SearchText();");
                try { File.Delete(filePathForXML); }
                catch { }
            }
            else
            {
                if (!String.IsNullOrEmpty(txtVheicleNumber.Text))
                {
                    //string strvheiclename = txtVheicleNumber.Text;
                    //LoadFieldValue(strvheiclename);
                    string strSearchKey = txtVheicleNumber.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int id = int.Parse(code.ToString());
                    LoadFieldValue(id);

                }
                else
                {
                    //ClearControls();
                }
            }
        }
        private void LoadFieldValue(int vhclid)
        {
            try
            {
                string strvheiclename = txtVheicleNumber.Text;
                RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
                inactiveby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string strSearchKey = txtVheicleNumber.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();
                string strCustname = strSearchKey;
                int id = int.Parse(code.ToString());


                DataTable objDT = new DataTable();
                objDT = bll.Vheicleinfo(code);
                if (objDT.Rows.Count >= 0)
                {

                    //txtVheicleCatg.Text = objDT.Rows[0]["strvheiclecatg"].ToString();
                    txttype.Text = objDT.Rows[0]["strType"].ToString();
                    txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                }

            }
            catch (Exception ex) { throw ex; }
        }
        [WebMethod]
        public static List<string> GetAutoserachingVheicleName(string strSearchKey)
        {
            RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();

            List<string> result = new List<string>();
            result = bll.AutoSearchVheicleName(strSearchKey);
            return result;
        }

        private void CreateVoucherXml(string billDate, string drvallown, string factmnt, string homnt, string workmnt, string remarks, string grandtototal,string vhclid,string jobstation )
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("CompanyvhclMntCost");
                XmlNode addItem = CreateItemNode(doc, billDate,  drvallown,  factmnt,  homnt,  workmnt,  remarks, grandtototal, vhclid,  jobstation);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CompanyvhclMntCost");
                XmlNode addItem = CreateItemNode(doc, billDate, drvallown, factmnt, homnt, workmnt, remarks, grandtototal, vhclid, jobstation);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
            //Clear();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string billDate, string drvallown, string factmnt, string homnt, string workmnt, string remarks, string grandtototal, string vhclid, string jobstation)
        {
            XmlNode node = doc.CreateElement("items");

            XmlAttribute BillDate = doc.CreateAttribute("billDate");
            BillDate.Value = billDate;

            XmlAttribute Drvallown = doc.CreateAttribute("drvallown");
            Drvallown.Value = drvallown;

            XmlAttribute Factmnt = doc.CreateAttribute("factmnt");
            Factmnt.Value = factmnt;
            XmlAttribute Homnt = doc.CreateAttribute("homnt");
            Homnt.Value = homnt;
            XmlAttribute Workmnt = doc.CreateAttribute("workmnt");
            Workmnt.Value = workmnt;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Grandtototal = doc.CreateAttribute("grandtototal");
            Grandtototal.Value = grandtototal;
            XmlAttribute Vhclid = doc.CreateAttribute("vhclid");
            Vhclid.Value = vhclid;
            XmlAttribute Jobstation = doc.CreateAttribute("jobstation");
            Jobstation.Value = jobstation;



            node.Attributes.Append(BillDate);
            node.Attributes.Append(Drvallown);
            node.Attributes.Append(Factmnt);
            node.Attributes.Append(Homnt);
            node.Attributes.Append(Workmnt);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(Grandtototal);
            node.Attributes.Append(Vhclid);
            node.Attributes.Append(Jobstation);


            return node;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string drvallw = "0", fmnt = "0", hmnt = "0", wmnt = "0";
                string BillDate = txtEffectiveDate.Text;
                string strSearchKey = txtVheicleNumber.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string idvhcl = arrayKey[1].ToString();
                int vhclid = int.Parse(idvhcl.ToString());
                string drvallow = txtDriverAllowance.Text;
                string js = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

                if (drvallow.Length <= 0) { drvallow = "0"; }
                string factmnt = txtMntcostfactory.Text;
                if (factmnt.Length <= 0) { factmnt = "0"; }
                string homnt = txtMntcostHO.Text;
                if (homnt.Length <= 0) { homnt = "0"; }
                string wkshp = txtMntWSHP.Text;
                if (wkshp.Length <= 0) { wkshp = "0"; }
                string remk = textremarks.Text;
                if (remk.Length <= 0) { remk = "NA"; }
                string gtotal = txtTotal.Text;
                if (gtotal.Length <= 0) { gtotal = "0"; }
                

                CreateVoucherXml(BillDate, drvallow, factmnt, homnt, wkshp, remk, gtotal, idvhcl, js);
                //}

            }
        }

        private void LoadGridwithXml()
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePathForXML);
                System.Xml.XmlNode dSftTm = doc.SelectSingleNode("CompanyvhclMntCost");
                xmlString = dSftTm.InnerXml;
                xmlString = "<CompanyvhclMntCost>" + xmlString + "</CompanyvhclMntCost>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdvMntcostentry.DataSource = ds;
                }
                else { grdvMntcostentry.DataSource = ""; }

                grdvMntcostentry.DataBind();

            }
            catch { }
        }

        protected void grdvMntcostentry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { grandtotal += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblGrandTotal")).Text); }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { drvallow += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lbldrvallownce")).Text); }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { factmnt += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblfactorymnt")).Text); }
            }
            catch { }

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { homnts += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblhomnt")).Text); }
            }
            catch { }


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) { workshpmnt += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblcworkshp")).Text); }
            }
            catch { }

        }

        protected void grdvMntcostentry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)grdvMntcostentry.DataSource;
                dsGrid.Tables[0].Rows[grdvMntcostentry.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)grdvMntcostentry.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); grdvMntcostentry.DataSource = ""; grdvMntcostentry.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (grdvMntcostentry.Rows.Count > 0)
                {
                    #region ------------ Insert into dataBase -----------

                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtEffectiveDate.Text).Value;
                    DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtEffectiveDate.Text).Value;
                    int enrollforInsertby = int.Parse(HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString());
                    int NoneCarUserTypeid = 3;
                    HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                    int unit = Convert.ToInt32(HiddenUnit.Value);
                    hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                    int jobstation = Convert.ToInt32(hdnstation.Value);

                    XmlDocument doc = new XmlDocument();

                    try
                    {


                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("CompanyvhclMntCost");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<CompanyvhclMntCost>" + xmlString + "</CompanyvhclMntCost>";
                        string message = bll.insertmntcost(xmlString, dteFromDate,  enrollforInsertby, unit);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }

                    catch
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                    }



                    #endregion ------------ Insertion End ----------------


                }
                grdvMntcostentry.DataBind();
                File.Delete(filePathForXML);
                grdvMntcostentry.DataSource = "";
                grdvMntcostentry.DataBind();

            }
        }
    }
}