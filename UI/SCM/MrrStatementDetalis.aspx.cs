﻿using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class MrrStatementDetalis : System.Web.UI.Page
    {
        MrrReceive_BLL obj = new MrrReceive_BLL();
        DataTable dt = new DataTable();
        int enroll, intWh, MrrId; string dfile, xmlData;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    MrrId = int.Parse(Request.QueryString["MrrId"].ToString());
                    lblMrrNo.Text = MrrId.ToString();
                    dt = obj.DataView(13, "", intWh, MrrId, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblChallan.Text = dt.Rows[0]["strExtnlReff"].ToString();
                        DateTime dtechallan = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
                        lblChallanDate.Text = dtechallan.ToString("dd-MM-yyyy");
                        lblWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
                        lblSupplier.Text = dt.Rows[0]["strSupplierName"].ToString();
                        DateTime dteMrr = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
                        lblMrrDate.Text = dteMrr.ToString("dd-MM-yyyy");
                        lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                        string unit = dt.Rows[0]["intUnitID"].ToString();
                        imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                    }
                    else { }
                    dt = obj.DataView(14, "", intWh, MrrId, DateTime.Now, enroll);
                    dgvMrrDetlais.DataSource = dt;
                    dgvMrrDetlais.DataBind();
                     
                }
                catch { }
               

            }
            else
            { }
        }

     
        

        
    }
}