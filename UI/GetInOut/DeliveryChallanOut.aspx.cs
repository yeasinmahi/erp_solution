using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LOGIS_BLL.GetInOut;
using UI.ClassFiles;
using System.Xml;
using System.IO;

namespace UI.GetInOut
{
    public partial class DeliveryChallanOut :BasePage
    {
        GetInoutstatus objvechileinout = new GetInoutstatus();
      
        DataTable Finished = new DataTable();

        DataTable allGriedload = new DataTable();

        string filePathForXML;
      
        string xmlString;
      
        GetInoutstatus rpt = new GetInoutstatus();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());
            //Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
            //Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());


            filePathForXML = Server.MapPath("depotReceivefrom.xml");
            
            //filePathForXML = Server.MapPath("student" + strEnroll + ".xml");
            if (!IsPostBack)
            {

                try { File.Delete(filePathForXML); }
                catch { }
              

                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 intjobid = Int32.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

               
                pnlUpperControl.DataBind();
                Finished = objvechileinout.FinishedProductLoad(intjobid);
                Finisheddgv.DataSource = Finished;
                Finisheddgv.DataBind();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            Int32 intunitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());
          
            Int32 intuntid = int.Parse(Session[SessionParams.UNIT_ID].ToString());

            Int32 intjobid= int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            

            if (Finisheddgv.Rows.Count > 0)
            {

                for (int index = 0; index < Finisheddgv.Rows.Count; index++)
                {



                    if (((CheckBox)Finisheddgv.Rows[index].FindControl("chkSelect3")).Checked == true)
                    {
                        string code = ((Label)Finisheddgv.Rows[index].FindControl("strCode")).Text.ToString();

                        string vehicleRegNo = ((Label)Finisheddgv.Rows[index].FindControl("strVehicleRegNo")).Text.ToString();
                        //objvechileinout.getpassFinishedProductOut(code, intenroll,intuntid);
                        //objvechileinout.insertFinishedProductInfo(VehicleRegNo, intenroll, intuntid);
                        //objvechileinout.FinishedVehicleOutUpdate(code, VehicleRegNo);

                        {
                            CreateSalesXml(code, vehicleRegNo);

                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("voucher");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<voucher>" + xmlString + "</voucher>";
                            string message = rpt.Insertorderform(xmlString, intenroll, intunitid,intjobid);
                            File.Delete(filePathForXML);


                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);


                        }
                    }


                }
                Finished = objvechileinout.FinishedProductLoad(intjobid);
                Finisheddgv.DataSource = Finished;
                Finisheddgv.DataBind();
            }
        }

        private void CreateSalesXml(string code, string vehicleRegNo)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, code, vehicleRegNo);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, code, vehicleRegNo);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string code, string vehicleRegNo)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Code = doc.CreateAttribute("code");
            Code.Value = code;
            XmlAttribute VehicleRegNo = doc.CreateAttribute("vehicleRegNo");
            VehicleRegNo.Value = vehicleRegNo;


            node.Attributes.Append(Code);

            node.Attributes.Append(VehicleRegNo);


            return node;
        }

    }
}