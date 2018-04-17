using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{
    public partial class NewHotelEntry : System.Web.UI.Page
    {
        string xmlpath; string xmlString = ""; TourPlanning bll = new TourPlanning(); char[] delimiterChars = { '[', ']' };
         DataTable dtbl = new DataTable(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/HR/TourPlan/Tour/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteTourPlanAddhotel.xml");
            if (!IsPostBack)
            {
                
                try { File.Delete(xmlpath); }
                catch { }
            }
        }
        private void Clearcontrols()
        {
            txtHotelName.Text = ""; txtAddress.Text = "";  txtPhone.Text = "";
            txtRemarks.Text = "";
        }

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("RemoteTourPlanAddhotel");
                xmlString = xlnd.InnerXml;
                xmlString = "<RemoteTourPlanAddhotel>" + xmlString + "</RemoteTourPlanAddhotel>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { grdvHotelEntry.DataSource = ds; } else { grdvHotelEntry.DataSource = ""; } grdvHotelEntry.DataBind();
            }
            catch { grdvHotelEntry.DataSource = ""; grdvHotelEntry.DataBind(); }
        }

        private void CreateXml(string hotelname, string address, string districtid, string phone, string thanaid, string remarks, string districtName, string thananame,string regionid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteTourPlanAddhotel");
                XmlNode addItem = CreateNode(doc, hotelname, address, districtid, phone, thanaid,remarks, districtName,thananame,regionid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteTourPlanAddhotel");
                XmlNode addItem = CreateNode(doc, hotelname, address, districtid, phone, thanaid, remarks, districtName, thananame,regionid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string hotelname, string address, string districtid, string phone, string thanaid, string remarks, string districtName, string thananame, string regionid)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute HOTELNAME = doc.CreateAttribute("hotelname");
            HOTELNAME.Value = hotelname;
            XmlAttribute ADDRESS = doc.CreateAttribute("address");
            ADDRESS.Value = address;
            XmlAttribute DISTRICTID = doc.CreateAttribute("districtid");
            DISTRICTID.Value = districtid;
            XmlAttribute PHONE = doc.CreateAttribute("phone");
            PHONE.Value = phone;
            XmlAttribute THANAID = doc.CreateAttribute("thanaid");
            THANAID.Value = thanaid;
            XmlAttribute REMARKS = doc.CreateAttribute("remarks");
            REMARKS.Value = remarks;
            XmlAttribute DISTRICTNAME = doc.CreateAttribute("districtName");
            DISTRICTNAME.Value = districtName;
            XmlAttribute THANANAME = doc.CreateAttribute("thananame");
            THANANAME.Value = thananame;
            XmlAttribute REGIONID = doc.CreateAttribute("regionid");
            REGIONID.Value = regionid;

            node.Attributes.Append(HOTELNAME);
            node.Attributes.Append(ADDRESS);
            node.Attributes.Append(DISTRICTID);
            node.Attributes.Append(PHONE);
            node.Attributes.Append(THANAID);
            node.Attributes.Append(REMARKS);
            node.Attributes.Append(DISTRICTNAME);
            node.Attributes.Append(THANANAME);
            node.Attributes.Append(REGIONID);


            return node;
        }

        protected void btnTourAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {

                    bool proceed = false;

                    string jobstation = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                    string unitid = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                    string hotelname1 = txtHotelName.Text;
                    string thananame = drdlThanaName.SelectedItem.ToString();
                    string hotelname = hotelname1 + " " + " [ " + thananame + " ] ";
                    string asddress = txtAddress.Text;
                    string districtid = drdlDistrict.SelectedValue.ToString();
                    string phone = txtPhone.Text;
                    string thanaid = drdlThanaName.SelectedValue.ToString();
                    string r1;
                    string remarks;
                    remarks = txtRemarks.Text; 
                    string districtName=drdlDistrict.SelectedItem.ToString();
                    string regionid;
                    try { regionid = drdlRegionName.SelectedValue.ToString(); }
                    catch { regionid = "0"; }



                    int cnt = grdvHotelEntry.Rows.Count;
                    if (cnt == 0)
                    {
                        CreateXml(hotelname, asddress, districtid, phone, thanaid, remarks, districtName, thananame,regionid);
                        Clearcontrols();
                    }
                    else
                    {
                        for (int r = 0; r < cnt; r++)
                        {
                            string disid = ((HiddenField)grdvHotelEntry.Rows[r].FindControl("hdndistrictid")).Value.ToString();
                            if (districtid != disid) { proceed = true; }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select another District.');", true);
                                break;
                            }
                        }
                        if (proceed == true)
                        {
                            CreateXml(hotelname, asddress, districtid, phone, thanaid, remarks, districtName, thananame, regionid);
                            Clearcontrols();
                        }
                    }
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
           }

        protected void grdvHotelEntry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvHotelEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)grdvHotelEntry.DataSource;
                dsGrid.Tables[0].Rows[grdvHotelEntry.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)grdvHotelEntry.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(xmlpath); grdvHotelEntry.DataSource = ""; grdvHotelEntry.DataBind(); }
                else { LoadXml(); }
            }
            catch { }
        }

        protected void btnTourSubmit_Click(object sender, EventArgs e)
        {

            if (grdvHotelEntry.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------


                hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                Int32 enroll = Convert.ToInt32(hdnApplicantEnrol.Value);

                HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                int unit = Convert.ToInt32(HiddenUnit.Value);
                hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                int jobstation = Convert.ToInt32(hdnstation.Value);
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteTourPlanAddhotel");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteTourPlanAddhotel>" + xmlString + "</RemoteTourPlanAddhotel>";
                    string message = bll.tourNewHotelIns(xmlString, enroll, unit);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                 }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }

            #endregion ------------ Insertion End ----------------
         }
            grdvHotelEntry.DataBind();
            File.Delete(xmlpath);
            grdvHotelEntry.DataSource = "";
            grdvHotelEntry.DataBind();

     }
    }
}