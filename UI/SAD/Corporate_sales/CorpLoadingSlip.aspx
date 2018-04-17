<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpLoadingSlip.aspx.cs" Inherits="UI.SAD.Corporate_sales.CorpLoadingSlip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head >
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <style type="text/css">
        .auto-style2 {
            width: 4px;
        }
    </style>
          <script>
              $(document).ready(function () {
                  SearchTextemp();
              });
              function Changed() {
                  document.getElementById('HdfSearchbox').value = 'true';
              }
              function SearchTextemp() {
                  $("#txtVehicle").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              type: "POST",
                              contentType: "application/json;",
                              url: "PendingView.aspx/GetAutoCompleteDataemp",
                              data: "{'strSearchKeyemp':'" + document.getElementById('txtVehicle').value + "'}",
                              dataType: "json",
                              success: function (data) {
                                  response(data.d);
                              },
                              error: function (result) {

                              }
                          });
                      }
                  });
              }



    </script>
    <script type="text/javascript">
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("print");
           // dv.style.display = "block";

            dv = document.getElementById("btn");
           // dv.style.display = "none";
        }
    </script>
    <script>
        function Print() { document.getElementById("btnprint").style.display = "none"; window.print(); self.close(); }
</script>
        <script language="javascript" type="text/javascript">
            function printDiv(divID) {
                //Get the HTML of div
                var divElements = document.getElementById(divID).innerHTML;
                //Get the HTML of whole page
                var oldPage = document.body.innerHTML;

                //Reset the page's HTML with div's HTML only
                document.body.innerHTML =
                  "<html><head><title></title></head><body>" +
                  divElements + "</body>";

                //Print Page
                window.print();

                //Restore orignal HTML
                document.body.innerHTML = oldPage;


            }
    </script>

</head>
<body>
    <form id="frmshvssls" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
       <CompositeScript>
           <Scripts>
               <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

           </Scripts>
       </CompositeScript>

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;">

    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
        <asp:HiddenField ID="HdfSearchbox" runat="server" /><asp:HiddenField ID="HdfTechnicinCode" runat="server" />
        <center>
         <table>
            
              <tr>
                <td style="background-color:#e9dddd">
                     &nbsp;</td>
               
                <td style="background-color:#e9dddd" class="auto-style2">
                       <input type="button" value="Print"  onclick="javascript: printDiv('printablediv'), Print()" />
                </td>
               
            </tr>  
            <tr>
                <td>
                   
                    <div id="print">
                         <div id="printablediv" style="width: 100%; height: 582px">
                    <table>
                        <caption>
                           <tr>
                               <td style="text-align:center">
                                 <h2> AKIJ FOOD & BEVERAGE LTD.</h2> 
                               </td>
                            </tr>

                         <tr><td style="text-align:left" class="auto-style7">
                         <asp:Label ID="Label6" Font-Bold="true" runat="server" Text="Label">Distributor Name:</asp:Label>
              
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                             <td >
                   <asp:Label ID="Label3" runat="server" Text="Label">driver Name</asp:Label>
                           

                    </td>
                    <td >
                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                           

                    </td>
                           
                   

                </tr>
                 <tr><td style="text-align:left" class="auto-style7">
                 <asp:Label ID="Label12" Font-Bold="true" runat="server" Text="Label">Vehicle No &nbsp  &nbsp &nbsp  &nbsp &nbsp :</asp:Label>             
                 <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                    <label id="Label5" runat="server" >Mobile No :</label>
                    </td>
                      <td class="auto-style7">
                   <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr><td style="text-align:left" class="auto-style7">
                    <asp:Label ID="Label11" Font-Bold="true" runat="server" Text="Label">Slip No &nbsp  &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp  :</asp:Label> 
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    &nbsp&nbsp&nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="Auto Challan" OnClick="Button1_Click1"></asp:Button>
                    </td>
                    <td class="auto-style7">
                    <label id="Label8" runat="server" ></label>
                    </td>

                </tr>
                          
                       
                    </td>
                    </tr>
                    <tr>
                        <td>
                    <asp:GridView ID="GridView1"  runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" OnRowDataBound="GridView1_RowDataBound"  ShowFooter="True">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>



                         <asp:TemplateField HeaderText="SLNo" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="ids" runat="server" Value='<%# Eval("id") %>' /><asp:HiddenField ID="ids1" runat="server" Value='<%# Eval("id") %>' />
                         <asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField> 

                                                    
                        <asp:TemplateField HeaderText="Productid" SortExpression="Productid">
                        <ItemTemplate>
                        <asp:HiddenField  ID="challanno" runat="server" Value='<%# Bind("challanno", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="rate" runat="server" Value='<%# Bind("monPrice", "{0:0.0000}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="intCOAIDtxt" runat="server" Value='<%# Bind("intCOAID", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="strAccNametxt" runat="server" Value='<%# Bind("strAccName", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="Extidtxt" runat="server" Value='<%# Bind("Extid") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="ExtNametxt" runat="server" Value='<%# Bind("ExtName", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="ExtPrtxt" runat="server" Value='<%# Bind("ExtPr", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="ItemUom" runat="server" Value='<%# Bind("ItemUom", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="Cur" runat="server" Value='<%# Bind("Cur", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="Narr" runat="server" Value='<%# Bind("Narr", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="Salestype" runat="server" Value='<%# Bind("Salestype", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="Comm" runat="server" Value='<%# Bind("Comm", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="UomTxt" runat="server" Value='<%# Bind("UomTxt", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="FreeProductid" runat="server" Value='<%# Bind("FreeProductid", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="FreeproductName" runat="server" Value='<%# Bind("FreeproductName", "{0:0}") %>'></asp:HiddenField>
                       <asp:HiddenField  ID="FreeItemUom" runat="server" Value='<%# Bind("FreeItemUom", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="FreeUomTxt" runat="server" Value='<%# Bind("FreeUomTxt", "{0:0}") %>'></asp:HiddenField>
                       <asp:HiddenField  ID="freeintCOAID" runat="server" Value='<%# Bind("freeintCOAID", "{0:0}") %>'></asp:HiddenField>
                        <asp:HiddenField  ID="uomqty" runat="server" Value='<%# Bind("uomqty", "{0:0}") %>'></asp:HiddenField>
                         <asp:HiddenField  ID="numPromQnty" runat="server" Value='<%# Bind("numPromQnty", "{0:0}") %>'></asp:HiddenField>

                        <asp:Label ID="lblProductid" runat="server" Text='<%# (""+Eval("Productid")) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" BorderStyle="Inset" Height="5px" Width="90px" />
                       </asp:TemplateField> 
        


                        <asp:TemplateField HeaderText="Product Name" SortExpression="strProductName"><ItemTemplate>
                        <asp:Label ID="lblstrProductName" runat="server" Text='<%# Bind("productName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" BorderStyle="Inset" Height="5px" Width="250px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
                        </FooterTemplate></asp:TemplateField>

                        
                          <%--<asp:TemplateField HeaderText="Quantity" SortExpression="Pending">
                         <ItemTemplate><asp:Label ID="lblnumqty" runat="server" Text='<%# (""+Eval("qty","{0:n0}")) %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="90px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# numqtytotal %>' /></FooterTemplate>
                         </asp:TemplateField>--%>

                          <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                        <ItemTemplate>
                         <asp:HiddenField  ID="hdnFreeQty" runat="server" Value='<%# Bind("qty","{0:n0}") %>'></asp:HiddenField>
                        <asp:TextBox ID="lblnumqty" CssClass="txtBox" runat="server" Width="75px"  Text='<%# Bind("qty","{0:n0}") %>' AutoPostBack="true"    ></asp:TextBox></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="75px" />
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText="Total Free" SortExpression="Pending">
                         <ItemTemplate><asp:Label ID="lbltotalfree" runat="server" Text='<%# (""+Eval("Totalfreeqty","{0:n2}")) %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="90px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# totalfreetotal %>' /></FooterTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Total Qty" SortExpression="Pending">
                         <ItemTemplate><asp:Label ID="lbltotalqty" runat="server" Text='<%# (""+Eval("TotalQty","{0:n0}")) %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="90px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# totalqtytotal %>' /></FooterTemplate>
                         </asp:TemplateField>
                      
        
         



                    </Columns>
                  <FooterStyle BackColor="#F3CCC2" BorderStyle="Outset" />
                    
                    <HeaderStyle BackColor="Black" Font-Bold="True" BorderStyle="Outset" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label10" Font-Bold="true" runat="server" Text="Label">_________________</asp:Label>
                                    <br />
                                    
                                    <asp:Label ID="Label9" Font-Bold="true" runat="server" Text="Label">Authority  Signature</asp:Label>

                             </caption>
                          </div>
                </td>
             
               </tr>
             <tr>
                 <td>
                     
              </td>
             </tr>
        </table>
                        </div>
       
        </td>
             </tr>
                </table>
         </center>
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>