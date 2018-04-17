﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Benifit;
using System.Text.RegularExpressions;
using UI.ClassFiles;

namespace UI.HR.Benifit
{
    public partial class Bonus : BasePage
    {
        string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup", "setTimeout('__doPostBack(\'" + txtSearch.ClientID.Replace("_", "$") + "\',\'\')', 0);");
            if (!IsPostBack)
            {
                txtEffectedDate.Text = DateTime.Now.ToShortDateString();
                dgvBonusDetails.DataBind();
                btnGenerateBonus.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnGenerateBonus).ToString());
            }
        }
        protected void btnGenerateBonus_Click(object sender, EventArgs e)
        {
            try
            {
                Bonus_BLL objBonus_BLL = new Bonus_BLL();
                string strCalculateStatus = objBonus_BLL.CalculateBonus(int.Parse(ddlBonusType.SelectedValue.ToString()), DateTime.Parse(txtEffectedDate.Text), int.Parse(Session[SessionParams.USER_ID.ToString()].ToString()));//
                dgvBonusDetails.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('" + strCalculateStatus + "');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartUpScript", "alert('Sorry! Error has been occured.Please see the error details. " + ex.Message.ToString() + "');", true);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text;
        }
        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtSearch.Text.ToString();
            // Setup the regular expression and add the Or <span id="IL_AD5" class="IL_AD">operator</span>.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
            // Set the RegExp to null.
            RegExp = null;
            txtSearch.Attributes.Add("onkeyup", "setTimeout('__doPostBack(\'" + txtSearch.ClientID.Replace("_", "$") + "\',\'\')', 0);");
        }
        public string ReplaceKeyWords(Match m)
        {
            return "<span class=highlight>" + m.Value + "</span>";
        }

        
    }
}