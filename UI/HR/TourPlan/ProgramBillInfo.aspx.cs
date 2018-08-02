using HR_BLL.TourPlan;
using SAD_BLL.Sales;
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
    public partial class ProgramBillInfo : System.Web.UI.Page
    {

        string xmlpath; string xmlString = ""; TourPlanning bll = new TourPlanning(); char[] delimiterChars = { '[', ']' };
        DataTable dtbl = new DataTable();
        SalesOrder bllso = new SalesOrder();
        int typeid, actionby, xml, id, unitid, territoryid;
        DateTime dtfromdate, dttodate;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/HR/TourPlan/Tour/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteProgramBill.xml");
            if (!IsPostBack)
            {

                try { File.Delete(xmlpath); }
                catch { }
            }
        }

        private void Clearcontrols()
        {
            txtProgramNo.Text = ""; txtAddress.Text = "";
            txtparticipantnumber.Text = "";
        }

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("RemoteProgramBill");
                xmlString = xlnd.InnerXml;
                xmlString = "<RemoteProgramBill>" + xmlString + "</RemoteProgramBill>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { grdvProgrambillinfo.DataSource = ds; } else { grdvProgrambillinfo.DataSource = ""; }
                grdvProgrambillinfo.DataBind();
            }
            catch { grdvProgrambillinfo.DataSource = ""; grdvProgrambillinfo.DataBind(); }
        }

        private void CreateXml(string programdate, string programName,string programid, string programno, string adr, string participantcatgid, string participantcatgname, string participantnumber, string foodperh, string mojoperh,string otherperh,string totalcostperh)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteProgramBill");
                XmlNode addItem = CreateNode(doc, programdate, programName, programid, programno, adr, participantcatgid, participantcatgname, participantnumber, foodperh, mojoperh, otherperh, totalcostperh);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteProgramBill");
                XmlNode addItem = CreateNode(doc, programdate, programName, programid, programno, adr, participantcatgid, participantcatgname, participantnumber, foodperh, mojoperh, otherperh, totalcostperh);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string programdate, string programName,string programid, string programno, string adr, string participantcatgid, string participantcatgname, string participantnumber, string foodperh, string mojoperh, string otherperh, string totalcostperh)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Programdate = doc.CreateAttribute("programdate");
            Programdate.Value = programdate;
            XmlAttribute ProgramName = doc.CreateAttribute("programName");
            ProgramName.Value = programName;
            XmlAttribute Programid = doc.CreateAttribute("programid");
            Programid.Value = programid;
            XmlAttribute Programno = doc.CreateAttribute("programno");
            Programno.Value = programno;
            XmlAttribute Adr = doc.CreateAttribute("adr");
            Adr.Value = adr;
            XmlAttribute Participantcatgid = doc.CreateAttribute("participantcatgid");
            Participantcatgid.Value = participantcatgid;
            XmlAttribute Participantcatgname = doc.CreateAttribute("participantcatgname");
            Participantcatgname.Value = participantcatgname;
            XmlAttribute Participantnumber = doc.CreateAttribute("participantnumber");
            Participantnumber.Value = participantnumber;
            XmlAttribute Foodperh = doc.CreateAttribute("foodperh");
            Foodperh.Value = foodperh;
            XmlAttribute Mojoperh = doc.CreateAttribute("mojoperh");
            Mojoperh.Value = mojoperh;

            XmlAttribute Otherperh = doc.CreateAttribute("otherperh");
            Otherperh.Value = otherperh;

            XmlAttribute Totalcostperh = doc.CreateAttribute("totalcostperh");
            Totalcostperh.Value = totalcostperh;


            node.Attributes.Append(Programdate);
            node.Attributes.Append(ProgramName);
            node.Attributes.Append(Programid);
            node.Attributes.Append(Programno);
            node.Attributes.Append(Adr);
            node.Attributes.Append(Participantcatgid);
            node.Attributes.Append(Participantcatgname);
            node.Attributes.Append(Participantnumber);
            node.Attributes.Append(Foodperh);
            node.Attributes.Append(Mojoperh);
            node.Attributes.Append(Otherperh);
            node.Attributes.Append(Totalcostperh);

            return node;
        }


        protected void btnProgramBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {

                    bool proceed = false;
                    //progdate,programName,  programno,  adr,  participantcatgid,  participantcatgname,  participantnumber,  foodperh,  mojoperh, otherperh, totalcostperh
                    string jobstation = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                    string unitid = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                    string prgdate = txtFromDate.Text.ToString();
                    string prgname = drdlprgname.SelectedItem.Text.ToString();
                    string prgid = drdlprgname.SelectedValue.ToString();

                    string prgno = txtProgramNo.Text.ToString();
                    string adrs = txtAddress.Text.ToString();
                    string participantcatgid = drdlCosttype.SelectedValue.ToString();

                    string partcatgname = drdlCosttype.SelectedItem.Text.ToString();
                    string particpnumber = txtparticipantnumber.Text.ToString();
                    string foodper = txtfoodcost.Text.ToString();
                    string mojoper = txtMojoCost.Text.ToString();
                    string othcostper = txtOthercost.Text.ToString();
                    string totalper = txtTotalCost.Text.ToString();
                    string regionid;
                    try { regionid = drdlRegionName.SelectedValue.ToString(); }
                    catch { regionid = "0"; }



                    int cnt = grdvProgrambillinfo.Rows.Count;
                    if (cnt == 0)
                    {
                        CreateXml(prgdate, prgname, prgid, prgno, adrs, participantcatgid, partcatgname, particpnumber, foodper, mojoper, othcostper, totalper);
                        //Clearcontrols();
                    }
                    else
                    {
                        for (int r = 0; r < cnt; r++)
                        {
                            string totp = ((HiddenField)grdvProgrambillinfo.Rows[r].FindControl("hdntotalcostperh")).Value.ToString();
                            if (totalper != totp) { proceed = true; }
                            else
                            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select another District.');", true);
                                break;
                            }
                        }
                        if (proceed == true)
                        {
                            CreateXml(prgdate, prgname, prgid, prgno, adrs, participantcatgid, partcatgname, particpnumber, foodper, mojoper, othcostper, totalper);
                            //Clearcontrols();
                        }
                    }
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }

            protected void btnProgramBillSubmit_Click(object sender, EventArgs e)
        {

            if (grdvProgrambillinfo.Rows.Count > 0)
            {
                #region ------------ Insert into dataBase -----------

                typeid = 0;

                hdnApplicantEnrol.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();
                actionby = Convert.ToInt32(hdnApplicantEnrol.Value);
                id = 0;
                dtfromdate = DateTime.Parse( txtFromDate.Text.ToString());
                dttodate = DateTime.Parse(txtFromDate.Text.ToString());
                HiddenUnit.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString();
                unitid = Convert.ToInt32(HiddenUnit.Value);
                hdnstation.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.JOBSTATION_ID].ToString();
                int jobstation = Convert.ToInt32(hdnstation.Value);
                XmlDocument doc = new XmlDocument();

                try
                {
                    //typeid,  actionby,  xml,  id,  dtfromdate,  dttodate,  unitid,  territoryid
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteProgramBill");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteProgramBill>" + xmlString + "</RemoteProgramBill>";
                    DataTable dt = bllso.getdataProgrambillcostinfo(typeid, actionby, xmlString, id, dtfromdate, dttodate, unitid, territoryid);
                    string message = dt.Rows[0]["Messages"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }

                catch
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                }



                #endregion ------------ Insertion End ----------------


            }
            grdvProgrambillinfo.DataBind();
            File.Delete(xmlpath);
            grdvProgrambillinfo.DataSource = "";
            grdvProgrambillinfo.DataBind();



        }

        protected void grdvProgrambillinfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvProgrambillinfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)grdvProgrambillinfo.DataSource;
                dsGrid.Tables[0].Rows[grdvProgrambillinfo.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)grdvProgrambillinfo.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(xmlpath); grdvProgrambillinfo.DataSource = ""; grdvProgrambillinfo.DataBind(); }
                else { LoadXml(); }
            }
            catch { }
        }
    }
}