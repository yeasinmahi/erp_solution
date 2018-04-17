using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

using System.Xml;
using System.IO;
using System.Drawing;
using Purchase_BLL.VehicleRegRenewal_BLL;

namespace UI.Asset
{
    public partial class AssetAccountsConfigure : BasePage
    {
        AssetMaintenance configure = new AssetMaintenance();
        DataTable dt = new DataTable();
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        string filePathForXMLAssetAccoA;
       
        string xmlStringAssetAccoA = "",  code;
        AssetMaintenance rpt = new AssetMaintenance();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            filePathForXMLAssetAccoA = Server.MapPath("~/Asset/Data/AssetAccoIA_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                txtJobstationName.Attributes.Add("onkeyUp", "SearchText();");
                txtUseJobstationName.Attributes.Add("onkeyUp", "SearchTextusejobstation();");
                txtVheicleType.Attributes.Add("onkeyUp", "SearchTextBRTAVheicletype();");
                try { File.Delete(filePathForXMLAssetAccoA); }
                catch { }
                dt = configure.UnitName();
                DdlBillUnit.DataSource = dt;
                DdlBillUnit.DataTextField = "Name";
                DdlBillUnit.DataValueField = "ID";
                DdlBillUnit.DataBind();
                dt = new DataTable();
                Int32 unit = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
                //dt = configure.UitbyJobstation(unit);
                //DdlJobstation.DataSource = dt;
                //DdlJobstation.DataTextField = "Name";
                //DdlJobstation.DataValueField = "ID";
                //DdlJobstation.DataBind();
                //DdlJobstation.Items.Insert(0, new ListItem("All", "0"));
                
                hdnwh.Value = DdlBillUnit.SelectedValue.ToString();

                dt = new DataTable();
               // dt = configure.UitbyJobstation(unit);
                //DdlUseJob.DataSource = dt;
                //DdlUseJob.DataTextField = "Name";
                //DdlUseJob.DataValueField = "ID";
                //DdlUseJob.DataBind();
                //DdlUseJob.Items.Insert(0, new ListItem("None", "9999"));
                dt = new DataTable();
                //dt = configure.BRTAVehicleType();

                //DdlBRTAType.DataSource = dt;
                //DdlBRTAType.DataTextField = "Name";
                //DdlBRTAType.DataValueField = "ID";
                //DdlBRTAType.DataBind();
                //DdlBRTAType.Items.Insert(0, new ListItem("None", "9999"));
                pnlUpperControl.DataBind();
                
                

            }
        }

        
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            //Int64 coaCodeID = Int64.Parse(DdlUseJob.SelectedValue.ToString());
                string sk = txtUseJobstationName.Text;
                arrayKey = sk.Split(delimiterChars);
                string usecode = arrayKey[1].ToString();
                Int64 coaCodeID = int.Parse(usecode);
                Int32 unit = Int32.Parse(DdlBillUnit.SelectedValue.ToString());//In use Unit
                //Int32 costcenter = Int32.Parse(DdlBRTAType.SelectedValue.ToString());
                string skvhtype = txtVheicleType.Text;
                arrayKey = skvhtype.Split(delimiterChars);
                string typecod = arrayKey[1].ToString();
                Int32 costcenter = Int32.Parse(typecod);
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                string owner = TxtOwner.Text.ToString();
                if (dgvGridView.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvGridView.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvGridView.Rows[index].FindControl("chkRow")).Checked == true)
                        {

                            string assetid = ((Label)dgvGridView.Rows[index].FindControl("strAssetCode")).Text.ToString();

                            {
                                CreateVoucherXml(assetid, owner);

                                XmlDocument doc = new XmlDocument();
                                doc.Load(filePathForXMLAssetAccoA);
                                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                                string xmlStringAssetAccoA = dSftTm.InnerXml;
                                xmlStringAssetAccoA = "<voucher>" + xmlStringAssetAccoA + "</voucher>";
                                string message = rpt.UpdateAssetAccoAID(xmlStringAssetAccoA, coaCodeID, unit, costcenter, intenroll);



                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                                File.Delete(filePathForXMLAssetAccoA);

                            }
                        }


                    }

                 }
            string searchKey = txtJobstationName.Text;
            arrayKey = searchKey.Split(delimiterChars);
            string code = arrayKey[1].ToString();
            Int32 enrol1 = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            //Int32 job = Int32.Parse(DdlJobstation.SelectedValue.ToString());
            Int32 job = Int32.Parse(code);


            dt = new DataTable();
            dt = configure.ViewVehicleUnitwaise(job);
            dgvGridView.DataSource = dt;
            dgvGridView.DataBind();
        }
       
        private void CreateVoucherXml(string assetid, string owner)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAssetAccoA))
            {
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeGetpassOut(doc, assetid, owner);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeGetpassOut(doc, assetid, owner);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAssetAccoA);
        }

        private XmlNode CreateItemNodeGetpassOut(XmlDocument doc, string assetid, string owner)
        {
          
                XmlNode node = doc.CreateElement("voucherentry");
                XmlAttribute Assetid = doc.CreateAttribute("assetid");
                Assetid.Value = assetid;
                XmlAttribute Owner = doc.CreateAttribute("owner");
                Owner.Value = owner;



                node.Attributes.Append(Assetid);
                node.Attributes.Append(Owner);
               
                 

                 return node;
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string jobsname= txtJobstationName.Text;
            if (jobsname.Length > 0)
            {
                string searchKey = txtJobstationName.Text;
                arrayKey = searchKey.Split(delimiterChars);
                code = arrayKey[1].ToString();
                Int32 enrol1 = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                //Int32 job = Int32.Parse(DdlJobstation.SelectedValue.ToString());
               
            }
            else { code = "0"; }

            Int32 job = Int32.Parse(code);
            int unit = int.Parse(DdlBillUnit.SelectedValue.ToString());
            int type = int.Parse(code);
            if (job == 0)
            {
                dt = new DataTable();
                dt = configure.ViewVehicleUnit(unit);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }
            else
            {
                dt = new DataTable();
                dt = configure.ViewVehicleUnitwaise(job);
                dgvGridView.DataSource = dt;
                dgvGridView.DataBind();
            }
        }

        protected void DdlBillUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 unit = Int32.Parse(DdlBillUnit.SelectedValue.ToString());
            //dt = configure.UitbyJobstation(unit);
            //DdlJobstation.DataSource = dt;
            //DdlJobstation.DataTextField = "Name";
            //DdlJobstation.DataValueField = "ID";
            //DdlJobstation.DataBind();
            //DdlJobstation.Items.Insert(0, new ListItem("All", "0"));
            hdnwh.Value = DdlBillUnit.SelectedValue.ToString();
            //dt = new DataTable();
           // dt = configure.UitbyJobstation(unit);
            //DdlUseJob.DataSource = dt;
            //DdlUseJob.DataTextField = "Name";
            //DdlUseJob.DataValueField = "ID";
            //DdlUseJob.DataBind();
            //DdlUseJob.Items.Insert(0, new ListItem("None", "9999"));

            

           

        }

        [WebMethod]
        public static List<string> GetAutoSearchingJobStationName(string strSearchKey)
        {
            RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
            List<string> result = new List<string>();
            result = bll.AutoSearchJobStationName(strSearchKey);
            return result;
        }

        [WebMethod]
        public static List<string> GetAutoSearchingUseJobStation(string strSearchKey)
        {
            RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();
            List<string> result = new List<string>();
            result = bll.AutoSearchJobStationName(strSearchKey);
            return result;
        }

        [WebMethod]
        public static List<string> GetAutoSearchingBRTAVheicleType(string strSearchKey)
        {
            AssetMaintenance bll = new AssetMaintenance();
            List<string> result = new List<string>();
            result = bll.AutoSearchBRTAVheicleType(strSearchKey);
            return result;
        }


    }
}