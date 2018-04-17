using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Vehicle_Registration_Renewal
{
    public partial class Template : System.Web.UI.Page
    {
       string  dts;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreateBox_Click(object sender, EventArgs e)
        {
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;

            this.CreateTextBox("txtDynamic" + index);
            //for (int i = 0; i < 6; i++)
            //{


            //    this.CreateTextBox("txtDynamic" + i);

            //    i++;

            //}
            
        }

        private void CreateTextBox(string id)
        {
            Literal lt1 = new Literal();
            Literal lt3 = new Literal();
            lt1.Text = "Name<td /> ";
            pnlTextBoxes.Controls.Add(lt1);

            TextBox txt = new TextBox();
            txt.ID = id;

            pnlTextBoxes.Controls.Add(txt);
            lt3.Text = "Address<td /> ";
            pnlTextBoxes.Controls.Add(lt3);
            TextBox sts = new TextBox();
            pnlTextBoxes.Controls.Add(sts);
           


            dts = txt.ToString();
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dts + "');", true);
           

        }

        protected void BtnLabel_Click(object sender, EventArgs e)
        {
            

            foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
            {

                dts += dts.ToString();

            }

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + dts + "');", true);
           
        }
       

        

       
    }
}