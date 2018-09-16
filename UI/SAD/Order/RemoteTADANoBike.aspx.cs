using Flogging.Core;
using GLOBAL_BLL;
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

namespace UI.SAD.Order
{
    public partial class RemoteTADANoBike : BasePage
    {
        decimal grandtotal = 0;
        string filePathForXML;

        string xmlString = "";
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteTADANoBike";
        string stop = "stopping SAD\\Order\\RemoteTADANoBike";
        protected void Page_Load(object sender, EventArgs e)
        {


            filePathForXML = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remotetada.xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ////---------xml----------
                try { File.Delete(filePathForXML); }
                catch { }
                ////-----**----------//
              

            }


        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            FirstGridViewRow();
        }
        private void FirstGridViewRow()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADANoBike TADA No Bike car Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));
            dt.Columns.Add(new DataColumn("Col7", typeof(string)));
            dt.Columns.Add(new DataColumn("Col8", typeof(string)));
            dt.Columns.Add(new DataColumn("Col9", typeof(string)));
            dt.Columns.Add(new DataColumn("Col10", typeof(string)));



            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
            dr["Col5"] = string.Empty;
            dr["Col6"] = string.Empty;

            dr["Col7"] = string.Empty;
            dr["Col8"] = string.Empty;
            dr["Col9"] = string.Empty;
            dr["Col10"] = string.Empty;



            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            grvStudentDetails.DataSource = dt;
            grvStudentDetails.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


        protected void ButtonAdd_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADANoBike TADA No Bike car Add", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextBoxFromAddr = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtFromAddress");
                        TextBox TextBoxToAddr = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtToAddress");

                        DropDownList dldTransportMode = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpTransportMode");

                        TextBox TextBoxMoDuration = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtDuration");

                        TextBox TextBoxFareTaka = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtFare");


                        TextBox TextBoxSupportingNo = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtSupportingNo");
                        TextBox TextBoxDA = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("txtDa");
                        TextBox TextBoxHotelAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[8].FindControl("txtHotelBill");
                        TextBox TextBoxOtherAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[9].FindControl("txtOthers");
                        TextBox TextBoxDTotalAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[10].FindControl("txtDTotal");

                        

                        if (TextBoxFareTaka.Text == string.Empty || (TextBoxFareTaka.Text) == "")
                        {
                            TextBoxFareTaka.Text = "0";
                        }

                        if (TextBoxDA.Text == string.Empty || (TextBoxDA.Text) == "")
                        {
                            TextBoxDA.Text = "0";
                        }

                        if (TextBoxHotelAmnt.Text == string.Empty || (TextBoxHotelAmnt.Text) == "")
                        {
                            TextBoxHotelAmnt.Text = "0";
                        }

                        if (TextBoxOtherAmnt.Text == string.Empty || (TextBoxOtherAmnt.Text) == "")
                        {
                            TextBoxOtherAmnt.Text = "0";
                        }

                        if (TextBoxSupportingNo.Text == string.Empty || (TextBoxSupportingNo.Text) == "")
                        {
                            TextBoxSupportingNo.Text = "No Supporting";
                        }

                        if (TextBoxMoDuration.Text == string.Empty || (TextBoxMoDuration.Text) == "")
                        {
                            TextBoxMoDuration.Text = "0";
                        }

                        string strFromaddr = TextBoxFromAddr.Text;
                        string strToaddr = TextBoxToAddr.Text;
                        string strTransportMode = dldTransportMode.Text;
                        string strMovDuration = TextBoxMoDuration.Text;
                        string strFareTaka = TextBoxFareTaka.Text;
                        string strSupporting = TextBoxSupportingNo.Text;
                        string strDA = TextBoxDA.Text;
                        string strHotelBill = TextBoxHotelAmnt.Text;
                        string strOtherAmount = TextBoxOtherAmnt.Text;
                        string totalamnt = TextBoxDTotalAmnt.Text;


                        if (totalamnt.All(c => char.IsNumber(c)) && strMovDuration.All(c => char.IsNumber(c)) && strFareTaka.All(c => char.IsNumber(c)) && strDA.All(c => char.IsNumber(c)) && strHotelBill.All(c => char.IsNumber(c)) && strOtherAmount.All(c => char.IsNumber(c)))
                        {

                            decimal total = decimal.Parse(TextBoxFareTaka.Text) + decimal.Parse(TextBoxDA.Text) + decimal.Parse(TextBoxHotelAmnt.Text) +
                                decimal.Parse(TextBoxOtherAmnt.Text);
                            TextBoxDTotalAmnt.Text = total.ToString();

                            grandtotal = grandtotal + total;
                            lblGrandTotal.Text = grandtotal.ToString();
                        }
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxFromAddr.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxToAddr.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = dldTransportMode.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextBoxMoDuration.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = TextBoxFareTaka.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = TextBoxSupportingNo.Text;
                        dtCurrentTable.Rows[i - 1]["Col7"] = TextBoxDA.Text;
                        dtCurrentTable.Rows[i - 1]["Col8"] = TextBoxHotelAmnt.Text;
                        dtCurrentTable.Rows[i - 1]["Col9"] = TextBoxOtherAmnt.Text;
                        dtCurrentTable.Rows[i - 1]["Col10"] = TextBoxDTotalAmnt.Text;



                        rowIndex++;
                    }




                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grvStudentDetails.DataSource = dtCurrentTable;
                    grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }




            SetPreviousData();


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

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //int i = 0


                        TextBox TextBoxFromAddr = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtFromAddress");
                        TextBox TextBoxToAddr = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtToAddress");

                        DropDownList dldTransportMode = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpTransportMode");


                        TextBox TextBoxMoDuration = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtDuration");

                        TextBox TextBoxFareTaka = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtFare");


                        TextBox TextBoxSupportingNo = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtSupportingNo");
                        TextBox TextBoxDA = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("txtDa");
                        TextBox TextBoxHotelAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[8].FindControl("txtHotelBill");
                        TextBox TextBoxOtherAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[9].FindControl("txtOthers");
                        TextBox TextBoxDTotalAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[10].FindControl("txtDTotal");




                        TextBoxFromAddr.Text = dt.Rows[i]["Col1"].ToString();
                        TextBoxToAddr.Text = dt.Rows[i]["Col2"].ToString();
                        dldTransportMode.SelectedValue = dt.Rows[i]["Col3"].ToString();
                        TextBoxMoDuration.Text = dt.Rows[i]["Col4"].ToString();
                        TextBoxFareTaka.Text = dt.Rows[i]["Col5"].ToString();
                        TextBoxSupportingNo.Text = dt.Rows[i]["Col6"].ToString();
                        TextBoxDA.Text = dt.Rows[i]["Col7"].ToString();
                        TextBoxHotelAmnt.Text = dt.Rows[i]["Col8"].ToString();
                        TextBoxOtherAmnt.Text = dt.Rows[i]["Col9"].ToString();

                        //TextBoxDTotalAmnt.Text = total.ToString();
                        TextBoxDTotalAmnt.Text = dt.Rows[i]["Col10"].ToString();


                        rowIndex++;
                    }
                }
            }
        }



        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    grandtotal = 0; decimal aftrtotal = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][10].ToString() == "")
                        { aftrtotal = 0; }
                        else
                        {
                            aftrtotal = decimal.Parse(dt.Rows[i][10].ToString());
                        }
                        grandtotal = grandtotal + aftrtotal;
                    }

                    grvStudentDetails.DataSource = dt;
                    grvStudentDetails.DataBind();
                    for (int i = 0; i < grvStudentDetails.Rows.Count - 1; i++)
                    {
                        grvStudentDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    lblGrandTotal.Text = grandtotal.ToString();
                    SetPreviousData();
                }
            }






        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RemoteTADANoBike TADA No Bike car Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (grvStudentDetails.Rows.Count > 0)
            {

                for (int rowIndex = 0; rowIndex < grvStudentDetails.Rows.Count; rowIndex++)
                {
                    TextBox TextBoxFromAddr = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[0].FindControl("txtFromAddress");
                    TextBox TextBoxToAddr = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtToAddress");
                    DropDownList dldTransportMode = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("drpTransportMode");
                    TextBox TextBoxMoDuration = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtDuration");
                    TextBox TextBoxFareTaka = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtFare");
                    TextBox TextBoxSupportingNo = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtSupportingNo");
                    TextBox TextBoxDA = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtDa");
                    TextBox TextBoxHotelAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("txtHotelBill");
                    TextBox TextBoxOtherAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[8].FindControl("txtOthers");
                    TextBox TextBoxDTotalAmnt = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[9].FindControl("txtDTotal");
                    string strFromaddr = TextBoxFromAddr.Text;
                    string strToaddr = TextBoxToAddr.Text;
                    string strTransportMode = dldTransportMode.Text;
                    string strMovDuration = TextBoxMoDuration.Text;
                    string strFareTaka = TextBoxFareTaka.Text;
                    string strSupporting = TextBoxSupportingNo.Text;
                    string strDA = TextBoxDA.Text;
                    string strHotelBill = TextBoxHotelAmnt.Text;
                    string strOtherAmount = TextBoxOtherAmnt.Text;
                    string totalamnt = TextBoxDTotalAmnt.Text;

                    if (totalamnt.All(c => char.IsNumber(c)) && strMovDuration.All(c => char.IsNumber(c)) && strFareTaka.All(c => char.IsNumber(c)) && strDA.All(c => char.IsNumber(c)) && strHotelBill.All(c => char.IsNumber(c)) && strOtherAmount.All(c => char.IsNumber(c)))
                    {

                        CreateSalesXml(strFromaddr, strToaddr, strTransportMode, strMovDuration, strFareTaka, strSupporting, strDA, strHotelBill, strOtherAmount, totalamnt);
                    }
                }
                        #region ------------ Insert into dataBase -----------


                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                      
                        hdnenroll.Value = HttpContext.Current.Session[UI.ClassFiles.SessionParams.USER_ID].ToString();

                        Int32 enroll = Convert.ToInt32(hdnenroll.Value);
                        int NoneCarUserTypeid = 2;

                        XmlDocument doc = new XmlDocument();
                        try
                        {

                           
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("RemoteTaDa");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<RemoteTaDa>" + xmlString + "</RemoteTaDa>";
                            string message = bll.tadainsert(xmlString, enroll, dteFromDate, dteTodate, NoneCarUserTypeid);
                            //File.Delete(filePathForXML);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        }

                        catch
                        {

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert(' Sorry-- wrong format data. plz check');", true);
                        }



                        #endregion ------------ Insertion End ----------------
                


            }

           

            grvStudentDetails.DataBind();
            File.Delete(filePathForXML);
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
         

        private void CreateSalesXml(string strFromaddr, string strToaddr, string strTransportMode, string strMovDuration, string strFareTaka, string strSupporting, string strDA, string strHotelBill, string strOtherAmount, string totalamnt)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                System.Xml.XmlNode rootNode = doc.SelectSingleNode("RemoteTaDa");
                XmlNode addItem = CreateItemNode(doc, strFromaddr, strToaddr, strTransportMode, strMovDuration, strFareTaka, strSupporting, strDA, strHotelBill, strOtherAmount, totalamnt);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteTaDa");
                XmlNode addItem = CreateItemNode(doc, strFromaddr, strToaddr, strTransportMode, strMovDuration, strFareTaka, strSupporting, strDA, strHotelBill, strOtherAmount, totalamnt);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string strFromaddr, string strToaddr, string strTransportMode, string strMovDuration, string strFareTaka, string strSupporting, string strDA, string strHotelBill, string strOtherAmount, string totalamnt)
        {
            XmlNode node = doc.CreateElement("items");





            XmlAttribute STRFROMADDRES = doc.CreateAttribute("strFromaddr");
            STRFROMADDRES.Value = strFromaddr;
            XmlAttribute STRTOADDR = doc.CreateAttribute("strToaddr");
            STRTOADDR.Value = strToaddr;
            XmlAttribute STRTRANSPORTMODE = doc.CreateAttribute("strTransportMode");
            STRTRANSPORTMODE.Value = strTransportMode;
            XmlAttribute STRMOVDURATION = doc.CreateAttribute("strMovDuration");
            STRMOVDURATION.Value = strMovDuration;
            XmlAttribute STRFARETAKA = doc.CreateAttribute("strFareTaka");
            STRFARETAKA.Value = strFareTaka;



            XmlAttribute STRSUPPORTING = doc.CreateAttribute("strSupporting");
            STRSUPPORTING.Value = strSupporting;
            XmlAttribute STRDA = doc.CreateAttribute("strDA");
            STRDA.Value = strDA;
            XmlAttribute STRHOTELBILL = doc.CreateAttribute("strHotelBill");
            STRHOTELBILL.Value = strHotelBill;
            XmlAttribute STROTHERAMOUNT = doc.CreateAttribute("strOtherAmount");
            STROTHERAMOUNT.Value = strOtherAmount;
            XmlAttribute STRROWTOTAL = doc.CreateAttribute("totalamnt");
            STRROWTOTAL.Value = totalamnt;








            node.Attributes.Append(STRFROMADDRES);
            node.Attributes.Append(STRTOADDR);
            node.Attributes.Append(STRTRANSPORTMODE);
            node.Attributes.Append(STRMOVDURATION);
            node.Attributes.Append(STRFARETAKA);

            node.Attributes.Append(STRSUPPORTING);
            node.Attributes.Append(STRDA);
            node.Attributes.Append(STRHOTELBILL);
            node.Attributes.Append(STROTHERAMOUNT);
            node.Attributes.Append(STRROWTOTAL);



            return node;



        }

        protected void grvStudentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}