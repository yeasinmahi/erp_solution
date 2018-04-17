<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingView.aspx.cs" Inherits="UI.SAD.AutoChallan.PendingView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
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
                 SearchText();
             });
             function Changed() {
                 document.getElementById('hdfSearchBoxTextChange').value = 'true';
             }
             function SearchText() {
                 $("#txtVehicleno").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             type: "POST",
                             contentType: "application/json;",
                             url: "TransportSet.aspx/GetAutoCompleteData",
                             data: '{"strSearchKey":"' + document.getElementById('txtVehicleno').value + '"}',
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

      <script>
          $(document).ready(function () {
              SearchTexts();
          });
          function Changeds() {
              document.getElementById('hdfSearchBoxTextChange').value = 'true';
          }
          function SearchTexts() {
              $("#txtdrivername").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          type: "POST",
                          contentType: "application/json;",
                          url: "TransportSet.aspx/GetAutoCompleteDatas",
                          data: '{"strSearchKey":"' + document.getElementById('txtdrivername').value + '"}',
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
     <script> function CloseWindow() {
     window.close();
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
Product Free
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
        <asp:HiddenField ID="HdfSearchbox" runat="server" /><asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="hdndriver" runat="server" />
         <table>
              
            <tr>
                <td style="background-color:#e9dddd"><asp:HiddenField ID="hdncustid" runat="server" /><asp:HiddenField ID="hdnvehicle" runat="server" /><asp:HiddenField ID="hdncompany" runat="server" />
                    <asp:HiddenField ID="hdnsession" runat="server" />
                    <asp:Label ID="Vehicle" runat="server" Text="">Vehicle No Search :</asp:Label><asp:TextBox ID="txtVehicleno" onchange="javascript: Changed();"  runat="server" CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                    </td>
                <td style="background-color:#e9dddd">
                    <asp:Label ID="Label1" runat="server" Text="">Driver Name         :</asp:Label><asp:TextBox ID="txtdrivername"  onchange="javascript: Changeds();"   runat="server" CssClass="txtBox" Width="150px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" OnTextChanged="txtVehicle1_TextChanged"></asp:TextBox>
                     <%--<asp:TextBox ID="txtDriverName" onchange="javascript: Changed();"   CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" runat="server"></asp:TextBox>--%>
                   </td>
                <td style="background-color:#e9dddd" class="auto-style2">
                    <asp:Button ID="Button1" Width="120px" runat="server" Text="Loading Slip Create" OnClick="Button1_Click" />
                </td>
                <td style="background-color:#e9dddd">
                    &nbsp;</td>
            </tr>
             <tr>
                 <td>
                            
                     <asp:Label ID="Label2" runat="server" Text="">Mobile No :</asp:Label><asp:TextBox ID="txtmobileno" runat="server"></asp:TextBox>
                     <asp:RadioButton ID="Company" GroupName="company" AutoPostBack="true" Text="Company" runat="server" OnCheckedChanged="Company_CheckedChanged" />
                     <asp:RadioButton ID="thardparty" GroupName="company" AutoPostBack="true" Text="Supplier" runat="server" OnCheckedChanged="thardparty_CheckedChanged" />
               
                 </td>
                  <td>
                      <asp:Label ID="suplier" runat="server">Supplier Name :</asp:Label> <asp:TextBox ID="txtsupplierName" runat="server"></asp:TextBox>
                 </td>
                  <td>

                 </td>
                  <td>

                 </td>
             </tr>
            <tr>
                <asp:GridView ID="dgvPending"  runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" OnRowDataBound="dgvPending_RowDataBound" ShowFooter="True" OnSelectedIndexChanged="dgvPending_SelectedIndexChanged2">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
               <asp:TemplateField HeaderText="Productid" SortExpression="Productid"><ItemTemplate>
               <asp:Label ID="lblProductid" runat="server" Text='<%# Bind("Productid") %>'></asp:Label></ItemTemplate>
               <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
               </FooterTemplate></asp:TemplateField>
            

             <asp:TemplateField HeaderText="strProductName" SortExpression="itemid"><ItemTemplate>
             <asp:HiddenField ID="strProductName" runat="server" Value='<%# Eval("strProductName") %>' /><asp:HiddenField ID="HiddenField12" runat="server" Value='<%# Eval("strProductName") %>' />
             <asp:Label ID="lblstrProductName" runat="server" Text='<%# Bind("strProductName","{0:n0}") %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>



         <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
        <ItemTemplate>
         <asp:HiddenField  ID="hdnFreeQty" runat="server" Value='<%# Bind("FreeQty","{0:n2}") %>'></asp:HiddenField>
        <asp:TextBox ID="Quantity1" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("pendingqty","{0:n0}") %>' AutoPostBack="true"    ></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" />
         </asp:TemplateField>
        

             <asp:TemplateField HeaderText="Free Qty" SortExpression="itemid"><ItemTemplate>
             <asp:HiddenField ID="FreeQtys" runat="server" Value='<%# Eval("FreeQty","{0:n2}") %>' /><asp:HiddenField ID="HiddenField21" runat="server" Value='<%# Eval("FreeQty","{0:n2}") %>' />
             <asp:Label ID="lblFreeQty" runat="server" Text='<%# Bind("FreeQty","{0:n2}") %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 


              <asp:TemplateField HeaderText="Total Qty" SortExpression="itemid"><ItemTemplate>
             <asp:HiddenField ID="TotalQty" runat="server" Value='<%# Eval("TotalQty") %>' /><asp:HiddenField ID="HiddenField0121" runat="server" Value='<%# Eval("TotalQty") %>' />
             <asp:Label ID="lblTotalQty" runat="server" Text='<%# Bind("TotalQty","{0:n2}") %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 


<%--                        <asp:TemplateField HeaderText="Total Qty" SortExpression="Pending">
                         <ItemTemplate><asp:Label ID="lbltotalqtys" runat="server" Text='<%# (""+Eval("TotalQty","{0:n0}")) %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="90px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# totalqtytotal %>' /></FooterTemplate>
                         </asp:TemplateField>--%>



             <asp:TemplateField HeaderText="Pakage Qty" SortExpression="itemid"><ItemTemplate>
            
             <asp:HiddenField ID="uomqty" runat="server" Value='<%# Eval("uomqty") %>' /><asp:HiddenField ID="HiddenField212130" runat="server" Value='<%# Eval("uomqty") %>' />
             <asp:Label ID="lbluomqty" runat="server" Text='<%# Bind("uomqty","{0:n0}") %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

                      </Columns>
                <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>

              <%--  <asp:GridView ID="dgvtrgt" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White"  
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black"   GridLines="Vertical" Font-Names="Calibri"  >
        <AlternatingRowStyle BackColor="#CCCCCC" />
          <Columns>
              <asp:TemplateField>   
                      <HeaderTemplate>    
                          <asp:CheckBox ID="chkAllSelect" runat="server" onclick="CheckAll(this);" />   
                       </HeaderTemplate>   
                       <ItemTemplate>   
                          <asp:CheckBox ID="chkSelect" runat="server" />   
                       </ItemTemplate>   
                   </asp:TemplateField> 
              <asp:TemplateField HeaderText="Challan No" SortExpression="strChallanNo"><ItemTemplate>
        <asp:HiddenField ID="strChallanNo" runat="server" Value='<%# Eval("strChallanNo") %>' /><asp:HiddenField ID="iname10" runat="server" Value='<%# Eval("strChallanNo") %>' />

        <asp:Label ID="lblchallan" runat="server" Text='<%# Bind("strChallanNo") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>    

              <asp:TemplateField HeaderText="Itemid" SortExpression="itemid"><ItemTemplate>
             <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("intproductid") %>' /><asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("intproductid") %>' />
            <asp:Label ID="itemid" runat="server" Text='<%# Bind("intproductid") %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

        <asp:TemplateField HeaderText="Product Name" SortExpression="strProductName"><ItemTemplate>
        <asp:HiddenField ID="itemname" runat="server" Value='<%# Eval("strProductName") %>' /><asp:HiddenField ID="iname" runat="server" Value='<%# Eval("strProductName") %>' />

        <asp:Label ID="lblitem" runat="server" Text='<%# Bind("strProductName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField> 
                  
         <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
        <ItemTemplate>
         <asp:HiddenField  ID="rate" runat="server" Value='<%# Bind("rate", "{0:0.0}") %>'></asp:HiddenField>
        <asp:TextBox ID="Quantity1" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("monqty") %>' AutoPostBack="false" onblur="Calculate(this.value)" ></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" />
         </asp:TemplateField>

         
               <asp:TemplateField HeaderText="Depot Name" SortExpression="strdepot"><ItemTemplate>
        <asp:HiddenField ID="strdepot" runat="server" Value='<%# Eval("strdepot") %>' /><asp:HiddenField ID="iname3" runat="server" Value='<%# Eval("strdepot") %>' />

        <asp:Label ID="lbldepot" runat="server" Text='<%# Bind("strdepot") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField> 
              
                                 

                       
         </Columns>
          <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>--%>

             </tr>
                </table>
        
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>