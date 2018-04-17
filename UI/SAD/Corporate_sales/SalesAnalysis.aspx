<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesAnalysis.aspx.cs" Inherits="UI.SAD.Corporate_sales.SalesAnalysis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    
     <%--<link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />--%>
    <%--<script src="../../Content/JS/datepickr.min.js"></script>--%>
   <%-- <script src="../../Content/JS/JSSettlement.js"></script>--%> 
  <%--  <link href="jquery-ui.css" rel="stylesheet" />--%>
   <%-- <script src="jquery.min.js"></script>--%>
   <%-- <script src="jquery-ui.min.js"></script>--%>
    <script type="text/javascript">
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=1000,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ShowPopUpC(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=650,width=750,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ValidateComplete(sender, args) {
            if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>

    <style type="text/css">
        .hide
        {
            display: none;
        }
        .auto-style1 {
            width: 11px;
        }
        .auto-style2 {
            width: 31px;
        }
        .auto-style3 {
            width: 67px;
        }
      
        .auto-style4 {
            width: 88px;
        }
      
        .auto-style5 {
            width: 190px;
        }
      
        .auto-style6 {
            width: 11px;
            height: 38px;
        }
        .auto-style8 {
            height: 38px;
        }
        .auto-style9 {
            width: 67px;
            height: 38px;
        }
      
        .auto-style10 {
            height: 32px;
        }
      
    </style>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=700,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }



    </script>
     <script>
         $(document).ready(function () {
             SearchText();
         });
         function Changed() {
             document.getElementById('HdfSearchbox').value = 'true';
         }
         function SearchText() {
             $("#txtCustomer").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "Corp_AutoChallan.aspx/GetAutoCompleteData",
                         data: '{"strSearchKey":"' + document.getElementById('txtCustomer').value + '"}',
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

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table style="width: 65%;">
                        <tr>                             
                            <td colspan="6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style8">
                                </td>
                            <td class="auto-style8">

                                &nbsp;</td>
                            <td class="auto-style9">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style4">
                              
                            </td>
                            <td>
                                

                                    &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5" class="auto-style1">
                                &nbsp;</td>
                           
                          
                        </tr>
                        <tr>
                            <td colspan="6" align="right" style="color:Green; height:40px; vertical-align:bottom;">    
                                <asp:HiddenField ID="hdnReport" runat="server" />          
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </asp:Panel>
            <div style="height: 170px;">

                
                
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            
            <asp:HiddenField ID="hdnFrom" runat="server" />
            <asp:HiddenField ID="hdnTo" runat="server" />
            <asp:HiddenField ID="HdfSearchbox" runat="server" />
            <asp:HiddenField ID="hdnCustomer" runat="server" />
            <table>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    
                </tr>
                <tr>
                    <td>
                        <table style="width:100%;background-color:#e2dddd">
         <tr>
                <td style="text-align:right">
                    
                
                    </td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;"></td>
                <td class="auto-style6">Report Catagory&nbsp; :

                                            </td>
                
                <td class="auto-style6">
                    
                    <asp:DropDownList  CssClass="auto-style5" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="3">Fund VS Sales Analysis</asp:ListItem>
                        <asp:ListItem Value="1">Sales Analysis In Value</asp:ListItem>
                        <asp:ListItem Value="2">Sales Analysis By Product</asp:ListItem>
                        <asp:ListItem Value="5">Employee Sales Analysis</asp:ListItem>
                    </asp:DropDownList>
                   
                </td>          
            <td>
                </td>          
               <td style="text-align:right;"></td>
             <td > </td>
            </tr> 
              
   <tr>
                <td style="text-align:right" class="row"> </td>
                <td style="text-align:right;" class="row"></td> 
                <td style="text-align:right;" class="row"></td>
                <td class="tbltd">Area : </td>
                 <td class="tbltd">
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="line" OnCheckedChanged="RadioButton2_CheckedChanged1" />   
                </td>                
            <td class="row">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>  
                    
               <td style="text-align:right;" class="row"></td>
             <td class="row" >
    
                </td>
            </tr>        
  <tr>
                <td style="text-align:right" class="row">
                    
                
                    </td>
                <td style="text-align:right;" class="row"></td>
   
                <td style="text-align:right;" class="row"></td>
                <td class="auto-style3">Territory :

                                            </td>
                
                <td class="auto-style3">
                    
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="line" OnCheckedChanged="RadioButton3_CheckedChanged" />
                </td>
      
      
            


                    
                
                
                           
            <td class="row"><asp:Label ID="Label15" BackColor="#ffcccc" runat="server" Text="Label" style="z-index: 1; left: 703px; top: 359px; position: absolute"></asp:Label></td>   

               
                    
               <td style="text-align:right;" class="row"></td>
             <td class="row" >
    
                </td>
            </tr> 
                
     <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;">&nbsp;</td>
                <td style="width:15%" class="tbltd">Point :

                                            </td>
                
                <td style="width:15%" class="tbltd">
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="line" OnCheckedChanged="RadioButton4_CheckedChanged1" />
                </td>
         
            


                    
                
                
                           
            <td></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>
         <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;">&nbsp;</td>
                <td style="width:15%" class="tbltd">&nbsp;</td>
                 <td style="width:15%" class="tbltd">
                     &nbsp;</td>            
            <td></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>
          <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;">&nbsp;</td>
                <td style="width:15%" class="tbltd">
                    <asp:Label ID="Label1" runat="server" Text="Product :"></asp:Label>
                    </td>
                 <td style="width:15%" class="tbltd">
                     <asp:DropDownList ID="DropDownList2" CssClass="txtBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                </td>            
            <td></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>
<tr>
                <td style="text-align:right" class="auto-style2">
                    
                
                    </td>
                <td style="text-align:right;" class="auto-style2"></td>
   
                <td style="text-align:right;" class="auto-style2">From date :</td>
                <td class="auto-style2" >
                    <asp:TextBox  CssClass="calendar" ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/Content/images/img/cal.png" runat="server" Height="21px" Width="46px" OnClick="ImageButton1_Click" />
                    &nbsp;

                    </td>
    
                
                <td style="text-align:right" width:15%" class="auto-style2" >
                    
               

                    To date :
                </td>
            


                    
                
                
                           
            <td class="auto-style2">
                <asp:TextBox  CssClass="calendar" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <asp:ImageButton ImageUrl="~/Content/images/img/cal.png" ID="ImageButton2" runat="server" Height="20px" Width="50px" OnClick="ImageButton2_Click" />
                <asp:Button ID="Button2" runat="server" Text="Show" OnClick="Button1_Click1" />
                </td>   

               
                    
               <td style="text-align:right;" class="auto-style2"></td>
             <td class="auto-style2" >
    
                </td>
            </tr>
<tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;">&nbsp;</td>
                <td style="width:15%" >
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="119px" OnSelectionChanged="Calendar1_SelectionChanged" Width="137px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                
                <td style="width:15%" >
                    
                    


                    &nbsp;</td>
            


                    
                
                
                           
            <td>

                
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="30px" OnSelectionChanged="Calendar2_SelectionChanged" Width="67px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>

                
            </td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>
        </table>


<asp:GridView ID="dgvtrgt" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvtrgt_RowDataBound" ShowFooter="True">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
<%--         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> --%>

      <asp:TemplateField HeaderText="Line"  HeaderStyle-Width="70px" SortExpression="Line"><ItemTemplate><asp:Label ID="lblline12121" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
    <HeaderStyle Width="7px"></HeaderStyle>
     <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="70px" runat="server" Text="Grand-Total:" /></div>
     </FooterTemplate></asp:TemplateField>
       
         <asp:TemplateField HeaderText="Region" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itemname" runat="server" Value='<%# Eval("strRegion") %>' /><asp:HiddenField ID="iname" runat="server" Value='<%# Eval("strRegion") %>' />
        <asp:Label ID="lblitem" runat="server" Text='<%# Bind("strRegion") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

          <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strArea" runat="server" Value='<%# Eval("strArea") %>' /><asp:HiddenField ID="iname4" runat="server" Value='<%# Eval("strArea") %>' />
        <asp:Label ID="lblitem4" runat="server" Text='<%# Bind("strArea") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField> 
                  
      
          
         <asp:TemplateField HeaderText="Territory" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strTerritory" runat="server" Value='<%# Eval("strTerritory") %>' /><asp:HiddenField ID="strTerritory10" runat="server" Value='<%# Eval("strTerritory") %>' />
        <asp:Label ID="lblstrTerritory" runat="server" Text='<%# Bind("strTerritory") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField> 
             
               
         <asp:TemplateField HeaderText="Distributor" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strDistributor" runat="server" Value='<%# Eval("strDistributor") %>' /><asp:HiddenField ID="strDistributor10" runat="server" Value='<%# Eval("strTerritory") %>' />
        <asp:Label ID="lblstrDistributor" runat="server" Text='<%# Bind("strDistributor") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField> 
                                                                           
     <%--    <asp:TemplateField HeaderText="strDistributor" SortExpression="rate" Visible="true">
        <ItemTemplate><asp:TextBox ID="strDistributor" CssClass="txtBox" Width="75px" runat="server" TextMode="Number" Text='<%# Bind("strDistributor") %>'></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="75px"/></asp:TemplateField>

             
     --%>   
          <%-- <asp:TemplateField HeaderText="TargetQty" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itfreeqty" runat="server" Value='<%# Eval("TargetQty") %>' /><asp:HiddenField ID="ifreeqty" runat="server" Value='<%# Eval("TargetQty","{0:n0}") %>' />
        <asp:Label ID="lblfreeqty" runat="server" Text='<%# Bind("TargetQty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> --%>

                           <asp:TemplateField HeaderText="Target" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblTargetss" Height="20px" runat="server" Text='<%# (""+Eval("TargetQty")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1qss" runat="server" Text='<%# TargetQtytotal %>' /></FooterTemplate></asp:TemplateField>
                 
        <%-- <asp:TemplateField HeaderText="Order" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="CPS1" runat="server" Value='<%# Eval("Orderqty") %>' /><asp:HiddenField ID="CPS2" runat="server" Value='<%# Eval("Orderqty","{0:0}") %>' />
        <asp:Label ID="CPS" runat="server" Text='<%# Bind("Orderqty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>--%>

                             <asp:TemplateField HeaderText="Order" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblOrder12113" Height="20px" runat="server" Text='<%# (""+Eval("Orderqty")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1q" runat="server" Text='<%# Orderqtytotal %>' /></FooterTemplate></asp:TemplateField>
       
                           
         <%--<asp:TemplateField HeaderText="Delivery qty" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Deliveryqty1" runat="server" Value='<%# Eval("Deliveryqty") %>' /><asp:HiddenField ID="Deliveryqty2" runat="server" Value='<%# Eval("Deliveryqty","{0:n0}") %>' />
        <asp:Label ID="lblDeliveryqty" runat="server" Text='<%# Bind("Deliveryqty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> --%>
          
          <asp:TemplateField HeaderText="Delivery" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblDeliveryqty1" Height="20px" runat="server" Text='<%# (""+Eval("Deliveryqty")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1q" runat="server" Text='<%# Deliveryqtytotal %>' /></FooterTemplate></asp:TemplateField>
                           
                                            
          <asp:TemplateField HeaderText="PO" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="PO1" runat="server" Value='<%# Eval("PO") %>' /><asp:HiddenField ID="PO2" runat="server" Value='<%# Eval("PO","{0:0}") %>' />
        <asp:Label ID="lblDeliveryqty10" runat="server" Text='<%# Bind("PO") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
             
                           
                           <asp:TemplateField HeaderText="PO %" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblPOFF" Height="20px" runat="server" Text='<%# (""+Eval("PO")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblFU150" runat="server" Text='<%# FFResultPOtotal %>' /></FooterTemplate></asp:TemplateField>
         
                            
          <asp:TemplateField HeaderText="Amount" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblAmount122" Height="20px" runat="server" Text='<%# (""+Eval("Amount")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1q" runat="server" Text='<%# Amounttotal %>' /></FooterTemplate></asp:TemplateField>
                
                                      
       <%--  <asp:TemplateField HeaderText="Amount" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Amount1" runat="server" Value='<%# Eval("Amount") %>' /><asp:HiddenField ID="Amount2" runat="server" Value='<%# Eval("Amount","{0:0}") %>' />
        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>  --%> 
          
        <%-- <asp:TemplateField HeaderText="Secondary_Sales" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Secondary_Sales1" runat="server" Value='<%# Eval("Secondary_Sales") %>' /><asp:HiddenField ID="Secondary_Sales2" runat="server" Value='<%# Eval("Secondary_Sales","{0:n0}") %>' />
        <asp:Label ID="lblSecondary_Sales" runat="server" Text='<%# Bind("Secondary_Sales") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> --%>
        
                             <asp:TemplateField HeaderText="Secondary_Sales" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblSecondary_Sales1" Height="20px" runat="server" Text='<%# (""+Eval("Secondary_Sales")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1q" runat="server" Text='<%# Secondary_Salestotal %>' /></FooterTemplate></asp:TemplateField>
         
                                             
          <%--  <asp:TemplateField HeaderText="SS-PO" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SS_PO" runat="server" Value='<%# Eval("SS_PO") %>' /><asp:HiddenField ID="SS_PO2" runat="server" Value='<%# Eval("SS_PO","{0:n0}") %>' />
        <asp:Label ID="lblSS_PO" runat="server" Text='<%# Bind("SS_PO") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> --%>

                         <%--   <asp:TemplateField HeaderText="SS-PO" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblSS-PO" Height="20px" runat="server" Text='<%# (""+Eval("SS_PO")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1q" runat="server" Text='<%# SS_POtotal %>' /></FooterTemplate></asp:TemplateField>
         --%>
                           <asp:TemplateField HeaderText="SS-PO" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblSS_PO" Height="20px" runat="server" Text='<%# (""+Eval("SS_PO")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblSS_PO1" runat="server" Text='<%# SS_POtotal %>' /></FooterTemplate></asp:TemplateField>
        
           
        <%-- <asp:TemplateField HeaderText="SS-FU" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SS_FU" runat="server" Value='<%# Eval("SS_FU") %>' /><asp:HiddenField ID="SS_FU2" runat="server" Value='<%# Eval("SS_FU","{0:n0}") %>' />
        <asp:Label ID="lblSS_FU" runat="server" Text='<%# Bind("SS_FU") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>                                 --%>
                                            
        <%-- <asp:TemplateField HeaderText="SS-PO" SortExpression="MQC">
         <ItemTemplate><asp:Label ID="lblSS_FU" Height="20px" runat="server" Text='<%# (""+Eval("SS_FU")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lbl1q" runat="server" Text='<%# SS_FUtotal %>' /></FooterTemplate></asp:TemplateField>
      --%>   
                           
                       <asp:TemplateField HeaderText="SS-FU" SortExpression="SS-FU">
         <ItemTemplate><asp:Label ID="lblSSFUss" Height="20px" runat="server" Text='<%# (""+Eval("SS_FU")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblSSFU" runat="server" Text='<%# SS_FUtotal %>' /></FooterTemplate></asp:TemplateField>
                     
                                                                  </Columns>
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <FooterStyle BackColor="#ffd7d7" HorizontalAlign="Right" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="13px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
        
      <asp:TemplateField HeaderText="Line"  HeaderStyle-Width="70px" SortExpression="Line"><ItemTemplate><asp:Label ID="HiddenField1fsf" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
    <HeaderStyle Width="7px"></HeaderStyle>
     <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="70px" runat="server" Text="Grand-Total:" /></div>
     </FooterTemplate></asp:TemplateField>
    

         <asp:TemplateField HeaderText="Location" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itemname" runat="server" Value='<%# Eval("Location") %>' /><asp:HiddenField ID="iname" runat="server" Value='<%# Eval("Location") %>' />
        <asp:Label ID="lblitem" runat="server" Text='<%# Bind("Location") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
  
       
     <asp:TemplateField HeaderText="Target" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblTarget25254" Height="20px" runat="server" Text='<%# (""+Eval("TargetQty")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblTargetQty1" runat="server" Text='<%# sTargetQtytotal %>' /></FooterTemplate></asp:TemplateField>
       

        <%--         
          <asp:TemplateField HeaderText="Order" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="CPS1" runat="server" Value='<%# Eval("Orderqty") %>' /><asp:HiddenField ID="CPS2" runat="server" Value='<%# Eval("Orderqty","{0:n0}") %>' />
        <asp:Label ID="CPS" runat="server" Text='<%# Bind("Orderqty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></%--asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Order" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblOrder25254" Height="20px" runat="server" Text='<%# (""+Eval("Orderqty")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblOrderqty1" runat="server" Text='<%# sOrderqtytotal %>' /></FooterTemplate></asp:TemplateField>
        
                                            
       <%--  <asp:TemplateField HeaderText="Delivery" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Deliveryqty1" runat="server" Value='<%# Eval("Deliveryqty") %>' /><asp:HiddenField ID="Deliveryqty2" runat="server" Value='<%# Eval("Deliveryqty","{0:n0}") %>' />
        <asp:Label ID="lblDeliveryqty" runat="server" Text='<%# Bind("Deliveryqty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 
       --%>   
                            <asp:TemplateField HeaderText="Delivery" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblsDeliveryqty1" Height="20px" runat="server" Text='<%# (""+Eval("Deliveryqty")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="Deliveryqty1ffssf" runat="server" Text='<%# sDeliveryqtytotal %>' /></FooterTemplate></asp:TemplateField>
        
                           
 
                                                           
        <%--  <asp:TemplateField HeaderText="PO %" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="PO1" runat="server" Value='<%# Eval("PO") %>' /><asp:HiddenField ID="PO2" runat="server" Value='<%# Eval("PO","{0:n0}") %>' />
        <asp:Label ID="lblDeliveryqty10" runat="server" Text='<%# Bind("PO") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
     --%>      
           
           <asp:TemplateField HeaderText="PO %" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblDeliveryqty10" Height="20px" runat="server" Text='<%# (""+Eval("PO")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="POsftsf" runat="server" Text='<%# ResultPOtotal %>' /></FooterTemplate></asp:TemplateField>
                          
       <%-- <asp:TemplateField HeaderText="PO" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblPobill" Height="20px" runat="server" Text='<%# (""+Eval("PO")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblpobill1" runat="server" Text='<%# Fundtotal %>' /></FooterTemplate></asp:TemplateField>
     --%>                    
                                             
             <%-- <asp:TemplateField HeaderText="Fund" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Amount1"  runat="server" Value='<%# Eval("Amount") %>' /><asp:HiddenField ID="Amount2" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' />
        <asp:Label ID="lblAmountsfs"  runat="server" Text='<%# Bind("Amount") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>  --%>
         
        <asp:TemplateField HeaderText="Fund" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblFundss" Height="20px" runat="server" Text='<%# (""+Eval("Amount")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblFundffs1" runat="server" Text='<%# sFundtotal %>' /></FooterTemplate></asp:TemplateField>
      

          <%-- <asp:TemplateField HeaderText="FU %" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="FU"  runat="server" Value='<%# Eval("FU") %>' /><asp:HiddenField ID="FU2" runat="server" Value='<%# Eval("FU") %>' />
        <asp:Label ID="lblFUss"  runat="server" Text='<%# Bind("FU") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          --%>

                           <asp:TemplateField HeaderText="FU %" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblFUssss" Height="20px" runat="server" Text='<%# (""+Eval("FU")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblFU150" runat="server" Text='<%# ResultFUtotal %>' /></FooterTemplate></asp:TemplateField>
      


      <%--   <asp:TemplateField HeaderText="Secondary_Sales" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Secondary_Sales1" runat="server" Value='<%# Eval("Secondary_Sales") %>' /><asp:HiddenField ID="Secondary_Sales2" runat="server" Value='<%# Eval("Secondary_Sales","{0:n0}") %>' />
        <asp:Label ID="lblSecondary_Sales" runat="server" Text='<%# Bind("Secondary_Sales") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>--%>
           
             <asp:TemplateField HeaderText="Secondary_Sales" SortExpression="Secondary_Sales">
         <ItemTemplate><asp:Label ID="lblSecondary_Sales" Height="20px" runat="server" Text='<%# (""+Eval("Secondary_Sales")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblSecondary_Sales1" runat="server" Text='<%# sSecondary_Salestotal %>' /></FooterTemplate></asp:TemplateField>
                     
                                           
         <%-- <asp:TemplateField HeaderText="SS %" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SS"  runat="server" Value='<%# Eval("SS") %>' /><asp:HiddenField ID="SS2" runat="server" Value='<%# Eval("SS","{0:n0}") %>' />
        <asp:Label ID="lblSS"  runat="server" Text='<%# Bind("SS") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                   
            
        --%>    
                           <asp:TemplateField HeaderText="SS %" SortExpression="SS_PO">
         <ItemTemplate><asp:Label ID="lblSSssss" Height="20px" runat="server" Text='<%# (""+Eval("SS")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblSS150" runat="server" Text='<%# ResultSStotal %>' /></FooterTemplate></asp:TemplateField>
      
                                           
                                          
           <%-- <asp:TemplateField HeaderText="SS-PO" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SS_PO" runat="server" Value='<%# Eval("SS_PO") %>' /><asp:HiddenField ID="SS_PO2" runat="server" Value='<%# Eval("SS_PO","{0:n0}") %>' />
        <asp:Label ID="lblSS_PO" runat="server" Text='<%# Bind("SS_PO") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> --%>
          
            <asp:TemplateField HeaderText="SS-PO" SortExpression="SS-PO">
         <ItemTemplate><asp:Label ID="lblSSPOffftes" Height="20px" runat="server" Text='<%# (""+Eval("SS_PO")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate > <asp:Label   ID="lblSSffPO1" runat="server" Text='<%# sSS_POtotal %>' /></FooterTemplate></asp:TemplateField>
                         
                           
                           
                            
           <%--                 <asp:TemplateField HeaderText="SS-FU" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SS_FU" runat="server" Value='<%# Eval("SS_FU") %>' /><asp:HiddenField ID="SS_FU2" runat="server" Value='<%# Eval("SS_FU","{0:n0}") %>' />
        <asp:Label ID="lblSS_FU" runat="server" Text='<%# Bind("SS_FU") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>--%>                                 
            
                 
                            <asp:TemplateField HeaderText="SS-FU" SortExpression="SS-FU">
         <ItemTemplate><asp:Label ID="lblSSFUsss" Height="20px" runat="server" Text='<%# (""+Eval("SS_FU")) %>'></asp:Label></ItemTemplate>
         <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblSSFU" runat="server" Text='<%# SS_FUtotal %>' /></FooterTemplate></asp:TemplateField>
                           
                                                           
          </Columns>
           <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"  />
                <FooterStyle BackColor="#ffe1e1" HorizontalAlign="Right" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
            
            
                             <asp:Label ID="Label2" BackColor="#ffcccc" runat="server" Text="Label" style="z-index: 1; left: 703px; top: 359px; position: absolute"></asp:Label>
                    

            </p>
       
         
        
   
            </td>
    </tr> 
    </table>
        
        
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView2_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid0" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Location" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itemname0" runat="server" Value='<%# Eval("Location") %>' /><asp:HiddenField ID="iname5" runat="server" Value='<%# Eval("Location") %>' />
        <asp:Label ID="lblitem5" runat="server" Text='<%# Bind("Location") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
  
         <asp:TemplateField HeaderText="TargetQty" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itfreeqty0" runat="server" Value='<%# Eval("TargetQty") %>' /><asp:HiddenField ID="ifreeqty0" runat="server" Value='<%# Eval("targetQty","{0:n0}") %>' />
        <asp:Label ID="lblfreeqty0" runat="server" Text='<%# Bind("TargetQty","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 

                 
          <asp:TemplateField HeaderText="Sales" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="CPS3" runat="server" Value='<%# Eval("Sales") %>' /><asp:HiddenField ID="CPS4" runat="server" Value='<%# Eval("Sales","{0:n0}") %>' />
        <asp:Label ID="CPS5" runat="server" Text='<%# Bind("Sales","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>
                           
         <asp:TemplateField HeaderText="Achievement" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Deliveryqty3" runat="server" Value='<%# Eval("Achievement") %>' /><asp:HiddenField ID="Deliveryqty4" runat="server" Value='<%# Eval("Achievement") %>' />
        <asp:Label ID="lblDeliveryqty11" runat="server" Text='<%# Bind("Achievement") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
          <asp:TemplateField HeaderText="ADT" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="ADT3" runat="server" Value='<%# Eval("ADT") %>' /><asp:HiddenField ID="ADT4" runat="server" Value='<%# Eval("ADT","{0:n0}") %>' />
        <asp:Label ID="lblADT12" runat="server" Text='<%# Bind("ADT","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
                           
         <asp:TemplateField HeaderText="ADS" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="ADS3" runat="server" Value='<%# Eval("ADS") %>' /><asp:HiddenField ID="Amount4" runat="server" Value='<%# Eval("ADS","{0:n0}") %>' />
        <asp:Label ID="lblADS0" runat="server" Text='<%# Bind("ADS","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
         <asp:TemplateField HeaderText="Achievement" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Achievement3" runat="server" Value='<%# Eval("Achievement") %>' /><asp:HiddenField ID="Achievement4" runat="server" Value='<%# Eval("Achievement") %>' />
        <asp:Label ID="lblAchievement0" runat="server" Text='<%# Bind("Achievement") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 

            <asp:TemplateField HeaderText="RDT" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="RDT3" runat="server" Value='<%# Eval("RDT") %>' /><asp:HiddenField ID="RDT4" runat="server" Value='<%# Eval("RDT","{0:n0}") %>' />
        <asp:Label ID="lblRDT0" runat="server" Text='<%# Bind("RDT","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>
                           
            <asp:TemplateField HeaderText="Stock" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="stock3" runat="server" Value='<%# Eval("stock") %>' /><asp:HiddenField ID="stock4" runat="server" Value='<%# Eval("stock","{0:n0}") %>' />
        <asp:Label ID="lblstock0" runat="server" Text='<%# Bind("stock","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
           
                            <asp:TemplateField HeaderText="Stock_Coverage" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Stock_Coverage3" runat="server" Value='<%# Eval("Stock_Coverage") %>' /><asp:HiddenField ID="SS_FU4" runat="server" Value='<%# Eval("Stock_Coverage","{0:n0}") %>' />
        <asp:Label ID="lblStock_Coverage0" runat="server" Text='<%# Bind("Stock_Coverage") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
            
            <asp:TemplateField HeaderText="Achiv.Ranks" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Ranks3" runat="server" Value='<%# Eval("Ranks") %>' /><asp:HiddenField ID="Ranks4" runat="server" Value='<%# Eval("Ranks","{0:n0}") %>' />
        <asp:Label ID="lblRanks0" runat="server" Text='<%# Bind("Ranks","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
                                              </Columns>
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
          
        
        
        
          
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView3_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid0" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="strRegion" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strRegion01" runat="server" Value='<%# Eval("strRegion") %>' /><asp:HiddenField ID="strRegion144s" runat="server" Value='<%# Eval("strRegion") %>' />
        <asp:Label ID="lblstrRegion51" runat="server" Text='<%# Bind("strRegion") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
        
        <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strstrarea01" runat="server" Value='<%# Eval("strarea") %>' /><asp:HiddenField ID="strRegion414f" runat="server" Value='<%# Eval("strarea") %>' />
        <asp:Label ID="lblstrarea51" runat="server" Text='<%# Bind("strarea") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 


                            <asp:TemplateField HeaderText="Territory" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strstrTerritory101" runat="server" Value='<%# Eval("strTerritory") %>' /><asp:HiddenField ID="strTerritory144ff" runat="server" Value='<%# Eval("strTerritory") %>' />
        <asp:Label ID="lblstrTerritory151" runat="server" Text='<%# Bind("strTerritory") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Point" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strCustName101" runat="server" Value='<%# Eval("strDistributor") %>' /><asp:HiddenField ID="strCustName144sf" runat="server" Value='<%# Eval("strDistributor") %>' />
        <asp:Label ID="lblstrCustName151" runat="server" Text='<%# Bind("strDistributor") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 


         <asp:TemplateField HeaderText="TargetQty" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itfreeqty0" runat="server" Value='<%# Eval("TargetQty") %>' /><asp:HiddenField ID="ifreeqty0" runat="server" Value='<%# Eval("targetQty","{0:n0}") %>' />
        <asp:Label ID="lblfreeqty0" runat="server" Text='<%# Bind("TargetQty","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 

                 
          <asp:TemplateField HeaderText="Sales" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="CPS3" runat="server" Value='<%# Eval("Sales") %>' /><asp:HiddenField ID="CPS4" runat="server" Value='<%# Eval("Sales","{0:n0}") %>' />
        <asp:Label ID="CPS5" runat="server" Text='<%# Bind("Sales","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>
                           
         <asp:TemplateField HeaderText="Achievement" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Deliveryqty3" runat="server" Value='<%# Eval("Achievement") %>' /><asp:HiddenField ID="Deliveryqty4sf" runat="server" Value='<%# Eval("Achievement") %>' />
        <asp:Label ID="lblDeliveryqty11" runat="server" Text='<%# Bind("Achievement") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
          <asp:TemplateField HeaderText="ADT" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="ADT3" runat="server" Value='<%# Eval("ADT") %>' /><asp:HiddenField ID="ADT4" runat="server" Value='<%# Eval("ADT","{0:n0}") %>' />
        <asp:Label ID="lblADT12" runat="server" Text='<%# Bind("ADT","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
                           
         <asp:TemplateField HeaderText="ADS" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="ADS3" runat="server" Value='<%# Eval("ADS") %>' /><asp:HiddenField ID="Amount4fs" runat="server" Value='<%# Eval("ADS","{0:n0}") %>' />
        <asp:Label ID="lblADS0" runat="server" Text='<%# Bind("ADS","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
         <asp:TemplateField HeaderText="Achievement" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Achievement3" runat="server" Value='<%# Eval("Achievement") %>' /><asp:HiddenField ID="Achievement4fs" runat="server" Value='<%# Eval("Achievement") %>' />
        <asp:Label ID="lblAchievement0" runat="server" Text='<%# Bind("Achievement") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
          
           <asp:TemplateField HeaderText="RDT" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="RDT" runat="server" Value='<%# Eval("AchiRDTevement") %>' /><asp:HiddenField ID="RDT4" runat="server" Value='<%# Eval("RDT","{0:n0}") %>' />
        <asp:Label ID="lblRDT0" runat="server" Text='<%# Bind("RDT","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                                                             
            <asp:TemplateField HeaderText="Stock" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="stock3" runat="server" Value='<%# Eval("stock") %>' /><asp:HiddenField ID="stock4fs" runat="server" Value='<%# Eval("stock","{0:n0}") %>' />
        <asp:Label ID="lblstock0" runat="server" Text='<%# Bind("stock") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
           
                            <asp:TemplateField HeaderText="Stock_Coverage" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Stock_Coverage3" runat="server" Value='<%# Eval("Stock_Coverage") %>' /><asp:HiddenField ID="SS_FU4sf" runat="server" Value='<%# Eval("Stock_Coverage","{0:n0}") %>' />
        <asp:Label ID="lblStock_Coverage0" runat="server" Text='<%# Bind("Stock_Coverage") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
             
          <asp:TemplateField HeaderText="Achiv. Ranks" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Ranks" runat="server" Value='<%# Eval("Ranks") %>' /><asp:HiddenField ID="Ranks4sf" runat="server" Value='<%# Eval("Ranks","{0:n0}") %>' />
        <asp:Label ID="lblRanks0" runat="server" Text='<%# Bind("Ranks","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
                                                                      
                                              </Columns>
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView> 
        
        <%----------Memo start----------------------------------------------------------------%>

        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView4_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid0" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Location" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Location1001" runat="server" Value='<%# Eval("Location") %>' /><asp:HiddenField ID="Location1144" runat="server" Value='<%# Eval("Location") %>' />
        <asp:Label ID="lblLocation151" runat="server" Text='<%# Bind("Location") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
       
        
                 
          <asp:TemplateField HeaderText="OutletCoverage" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="OutletCoverage" runat="server" Value='<%# Eval("OutletCoverage","{0:n0}") %>' /><asp:HiddenField ID="OutletCoverage2" runat="server" Value='<%# Eval("OutletCoverage","{0:n0}") %>' />
        <asp:Label ID="OutletCoverage1" runat="server" Text='<%# Bind("OutletCoverage","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>
                           
         <asp:TemplateField HeaderText="outletsVisite" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="outletsVisite2" runat="server" Value='<%# Eval("outletsVisite","{0:n0}") %>' /><asp:HiddenField ID="outletsVisite4" runat="server" Value='<%# Eval("outletsVisite","{0:n0}") %>' />
        <asp:Label ID="outletsVisite3" runat="server" Text='<%# Bind("outletsVisite","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 
                           
          <asp:TemplateField HeaderText="Memo" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="monMemo3" runat="server" Value='<%# Eval("monMemo","{0:n0}") %>' /><asp:HiddenField ID="monMemo14" runat="server" Value='<%# Eval("monMemo","{0:n0}") %>' />
        <asp:Label ID="monMemo4" runat="server" Text='<%# Bind("monMemo","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
                           
         <asp:TemplateField HeaderText="SKU sales" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SKUsales3" runat="server" Value='<%# Eval("SKUsales","{0:n0}") %>' /><asp:HiddenField ID="SKUsales14" runat="server" Value='<%# Eval("SKUsales","{0:n0}") %>' />
        <asp:Label ID="lblSKUsales101" runat="server" Text='<%# Bind("SKUsales","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
        
          
               <asp:TemplateField HeaderText="Strike_Rate" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Strike_Rate" runat="server" Value='<%# Eval("Strike_Rate") %>' /><asp:HiddenField ID="Strike_Rate4" runat="server" Value='<%# Eval("Strike_Rate") %>' />
        <asp:Label ID="lblStrike_Rate" runat="server" Text='<%# Bind("Strike_Rate") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                 
                                            
        <asp:TemplateField HeaderText="Call_Productivity" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Call_Productivity" runat="server" Value='<%# Eval("Call_Productivity") %>' /><asp:HiddenField ID="Call_Productivity4" runat="server" Value='<%# Eval("Call_Productivity") %>' />
        <asp:Label ID="lblCall_Productivity" runat="server" Text='<%# Bind("Call_Productivity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>     

            <%--<asp:TemplateField HeaderText="Call_Productivity" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Call_Productivity3" runat="server" Value='<%# Eval("Call_Productivity") %>' /><asp:HiddenField ID="Call_Productivity4" runat="server" Value='<%# Eval("Call_Productivity") %>' />
        <asp:Label ID="lblCall_Productivity3" runat="server" Text='<%# Bind("Call_Productivity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 
           --%>
         <asp:TemplateField HeaderText="LPC" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="LPC3" runat="server" Value='<%# Eval("LPC","{0:n0}") %>' /><asp:HiddenField ID="LPC4" runat="server" Value='<%# Eval("LPC","{0:n0}") %>' />
        <asp:Label ID="lblLPC10" runat="server" Text='<%# Bind("LPC","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
         <asp:TemplateField HeaderText="Memo_Value" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Memo_Value3" runat="server" Value='<%# Eval("Memo_Value","{0:n0}") %>' /><asp:HiddenField ID="Memo_Value4" runat="server" Value='<%# Eval("Memo_Value","{0:n0}") %>' />
        <asp:Label ID="lblMemo_Value10" runat="server" Text='<%# Bind("Memo_Value","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
        
         <asp:TemplateField HeaderText="Value_per_memo" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Value_per_memo3" runat="server" Value='<%# Eval("Value_per_memo","{0:n0}") %>' /><asp:HiddenField ID="Value_per_memo4" runat="server" Value='<%# Eval("Value_per_memo","{0:n0}") %>' />
        <asp:Label ID="lblValue_per_memo10" runat="server" Text='<%# Bind("Value_per_memo","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                                                               
         </Columns>
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>



<asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView5_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid0" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strArea2015" runat="server" Value='<%# Eval("strArea") %>' /><asp:HiddenField ID="strArea20154" runat="server" Value='<%# Eval("strArea") %>' />
        <asp:Label ID="lblstrstrArea2015" runat="server" Text='<%# Bind("strArea") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
        
         <asp:TemplateField HeaderText="Territory" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strTerritory0111" runat="server" Value='<%# Eval("strTerritory") %>' /><asp:HiddenField ID="strArea11144" runat="server" Value='<%# Eval("strTerritory") %>' />
        <asp:Label ID="lblstrTerritory11151" runat="server" Text='<%# Bind("strTerritory") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
       
         <asp:TemplateField HeaderText="Point" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strDistributor0111" runat="server" Value='<%# Eval("strDistributor") %>' /><asp:HiddenField ID="strArea111445" runat="server" Value='<%# Eval("strDistributor") %>' />
        <asp:Label ID="lblstrDistributor11151" runat="server" Text='<%# Bind("strDistributor") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

          <asp:TemplateField HeaderText="OutletCoverage" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="OutletCoverage" runat="server" Value='<%# Eval("OutletCoverage","{0:n0}") %>' /><asp:HiddenField ID="OutletCoverage2" runat="server" Value='<%# Eval("OutletCoverage","{0:n0}") %>' />
        <asp:Label ID="OutletCoverage1" runat="server" Text='<%# Bind("OutletCoverage","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>
                           
         <asp:TemplateField HeaderText="outletsVisite" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="outletsVisite2" runat="server" Value='<%# Eval("outletsVisite","{0:n0}") %>' /><asp:HiddenField ID="outletsVisite4" runat="server" Value='<%# Eval("outletsVisite","{0:n0}") %>' />
        <asp:Label ID="outletsVisite3" runat="server" Text='<%# Bind("outletsVisite","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
          <asp:TemplateField HeaderText="monMemo" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="monMemo3" runat="server" Value='<%# Eval("monMemo","{0:n0}") %>' /><asp:HiddenField ID="monMemo14" runat="server" Value='<%# Eval("monMemo","{0:n0}") %>' />
        <asp:Label ID="monMemo4" runat="server" Text='<%# Bind("monMemo","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
                           
         <asp:TemplateField HeaderText="SKU sales" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="SKUsales3" runat="server" Value='<%# Eval("SKUsales","{0:n0}") %>' /><asp:HiddenField ID="SKUsales14" runat="server" Value='<%# Eval("SKUsales","{0:n0}") %>' />
        <asp:Label ID="lblSKUsales101" runat="server" Text='<%# Bind("SKUsales","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
         <asp:TemplateField HeaderText="Strike_Rate" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Strike_Rate3" runat="server" Value='<%# Eval("Strike_Rate") %>' /><asp:HiddenField ID="Strike_Rate4" runat="server" Value='<%# Eval("Strike_Rate") %>' />
        <asp:Label ID="lblStrike_Rate3" runat="server" Text='<%# Bind("Strike_Rate") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 
                           
            <asp:TemplateField HeaderText="Call_Productivity" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Call_Productivity3" runat="server" Value='<%# Eval("Call_Productivity") %>' /><asp:HiddenField ID="Call_Productivity4" runat="server" Value='<%# Eval("Call_Productivity") %>' />
        <asp:Label ID="lblCall_Productivity3" runat="server" Text='<%# Bind("Call_Productivity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
           
         <asp:TemplateField HeaderText="LPC" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="LPC3" runat="server" Value='<%# Eval("LPC","{0:n0}") %>' /><asp:HiddenField ID="LPC4" runat="server" Value='<%# Eval("LPC","{0:n0}") %>' />
        <asp:Label ID="lblLPC10" runat="server" Text='<%# Bind("LPC","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 
                           
         <asp:TemplateField HeaderText="Memo_Value" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Memo_Value3" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' /><asp:HiddenField ID="Memo_Value4" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' />
        <asp:Label ID="lblMemo_Value10" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
        
         <asp:TemplateField HeaderText="Value_per_memo" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Value_per_memo3" runat="server" Value='<%# Eval("AvgMemoValue","{0:n0}") %>' /><asp:HiddenField ID="Value_per_memo4" runat="server" Value='<%# Eval("AvgMemoValue","{0:n0}") %>' />
        <asp:Label ID="lblValue_per_memo10" runat="server" Text='<%# Bind("AvgMemoValue","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                                                               
         </Columns>
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>


       <%-- ------------Memo end -----------------------------------------------------------------%>
        
         <%-- ------------Employee start -----------------------------------------------------------------%>

        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView6_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
     <%--    <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid0" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> --%>

         <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Location2015" runat="server" Value='<%# Eval("Location") %>' /><asp:HiddenField ID="Location201540" runat="server" Value='<%# Eval("Location") %>' />
        <asp:Label ID="lblLocation2015" runat="server" Text='<%# Bind("Location") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
        
         <asp:TemplateField HeaderText="Employee Name" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="stremployeename2015" runat="server" Value='<%# Eval("stremployeename") %>' /><asp:HiddenField ID="stremployeename201540" runat="server" Value='<%# Eval("stremployeename") %>' />
        <asp:Label ID="lblstremployeename2015" runat="server" Text='<%# Bind("stremployeename") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

          <asp:TemplateField HeaderText="Target Qty" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="TargetQty0111" runat="server" Value='<%# Eval("TargetQty") %>' /><asp:HiddenField ID="TargetQty11144" runat="server" Value='<%# Eval("TargetQty","{0:0}") %>' />
        <asp:Label ID="lblTargetQty11151" runat="server" Text='<%# Bind("TargetQty","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Target To date" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="TargetTodate0111" runat="server" Value='<%# Eval("TargetTodate") %>' /><asp:HiddenField ID="TargetTodate11144" runat="server" Value='<%# Eval("TargetTodate","{0:0}") %>' />
        <asp:Label ID="lblTargetTodate11151" runat="server" Text='<%# Bind("TargetTodate","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 
       
         <asp:TemplateField HeaderText="Sales" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Sales00111" runat="server" Value='<%# Eval("Sales") %>' /><asp:HiddenField ID="Sales1111445" runat="server" Value='<%# Eval("Sales","{0:0}") %>' />
        <asp:Label ID="lblSales111151" runat="server" Text='<%# Bind("Sales","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 

          <asp:TemplateField HeaderText="Achievement" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Achievement4040e" runat="server" Value='<%# Eval("Achievement") %>' /><asp:HiddenField ID="Achievement4140444" runat="server" Value='<%# Eval("Achievement") %>' />
        <asp:Label ID="Achievement404" runat="server" Text='<%# Bind("Achievement") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>
                           
         <asp:TemplateField HeaderText="ADT" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="ADT400" runat="server" Value='<%# Eval("ADT") %>' /><asp:HiddenField ID="ADT54040000" runat="server" Value='<%# Eval("ADT","{0:0}") %>' />
        <asp:Label ID="ADT405240" runat="server" Text='<%# Bind("ADT","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
          <asp:TemplateField HeaderText="ADS" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="ADS6546540" runat="server" Value='<%# Eval("ADS") %>' /><asp:HiddenField ID="ADS1011111" runat="server" Value='<%# Eval("ADS","{0:0}") %>' />
        <asp:Label ID="ADS65406546504" runat="server" Text='<%# Bind("ADS","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>             
                           
         <asp:TemplateField HeaderText="ADS %" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Achievement6540" runat="server" Value='<%# Eval("Achievementav") %>' /><asp:HiddenField ID="SKUsales14" runat="server" Value='<%# Eval("Achievementav") %>' />
        <asp:Label ID="lblAchievement65405" runat="server" Text='<%# Bind("Achievementav") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
         
           <asp:TemplateField HeaderText="RDT" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="RDT654" runat="server" Value='<%# Eval("RDT") %>' /><asp:HiddenField ID="RDT4" runat="server" Value='<%# Eval("RDT","{0:0}") %>' />
        <asp:Label ID="lblRDT6543" runat="server" Text='<%# Bind("RDT","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                                            
                            
         <asp:TemplateField HeaderText="Ranks" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Ranks654" runat="server" Value='<%# Eval("Ranks") %>' /><asp:HiddenField ID="Strike_Rate4" runat="server" Value='<%# Eval("Ranks","{0:0}") %>' />
        <asp:Label ID="lblRanks6543" runat="server" Text='<%# Bind("Ranks","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
        
                                                               
         </Columns>
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>

         <%-- ------------Employee End -----------------------------------------------------------------%>
        
     <%--   --------------Login Monitoring------------------------%>

        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView7_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField33" runat="server" Value='<%# Eval("Line") %>' /><asp:HiddenField ID="HiddenField410" runat="server" Value='<%# Eval("Line") %>' />
        <asp:Label ID="itemid04" runat="server" Text='<%# Bind("Line") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

        

         <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Region42015" runat="server" Value='<%# Eval("Region") %>' /><asp:HiddenField ID="Region420154" runat="server" Value='<%# Eval("Region") %>' />
        <asp:Label ID="lblRegion42015" runat="server" Text='<%# Bind("Region") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Area42015" runat="server" Value='<%# Eval("Area") %>' /><asp:HiddenField ID="Area20154" runat="server" Value='<%# Eval("Area") %>' />
        <asp:Label ID="lblArea42015" runat="server" Text='<%# Bind("Area") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
        
         <asp:TemplateField HeaderText="Territory" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Territory40111" runat="server" Value='<%# Eval("Territory") %>' /><asp:HiddenField ID="Territory411144" runat="server" Value='<%# Eval("Territory") %>' />
        <asp:Label ID="lblTerritory411151" runat="server" Text='<%# Bind("Territory") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
       
         <asp:TemplateField HeaderText="Point" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Point40111" runat="server" Value='<%# Eval("Point") %>' /><asp:HiddenField ID="strArea111445" runat="server" Value='<%# Eval("Point") %>' />
        <asp:Label ID="lblPoint411151" runat="server" Text='<%# Bind("Point") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
    
        <asp:TemplateField HeaderText="Employee Name" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="strEmployeeName43" runat="server" Value='<%# Eval("strEmployeeName") %>' /><asp:HiddenField ID="strEmployeeName444" runat="server" Value='<%# Eval("strEmployeeName") %>' />
        <asp:Label ID="strEmployeeName44" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

       <asp:TemplateField HeaderText="Designation" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="strDesignation43" runat="server" Value='<%# Eval("strDesignation") %>' /><asp:HiddenField ID="strDesignation444" runat="server" Value='<%# Eval("strDesignation") %>' />
        <asp:Label ID="strDesignation44" runat="server" Text='<%# Bind("strDesignation") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>             
                           
         <asp:TemplateField HeaderText="Working day" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Workingday454" runat="server" Value='<%# Eval("Workingday") %>' /><asp:HiddenField ID="Workingday4040" runat="server" Value='<%# Eval("Workingday") %>' />
        <asp:Label ID="lblWorkingday404" runat="server" Text='<%# Bind("Workingday") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
         <asp:TemplateField HeaderText="Use Day" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="useDay405" runat="server" Value='<%# Eval("useDay") %>' /><asp:HiddenField ID="useDay40e4" runat="server" Value='<%# Eval("useDay") %>' />
        <asp:Label ID="lbluseDay403" runat="server" Text='<%# Bind("useDay") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
            <asp:TemplateField HeaderText="Login count" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="logincount404" runat="server" Value='<%# Eval("logincount") %>' /><asp:HiddenField ID="logincount4044" runat="server" Value='<%# Eval("logincount") %>' />
        <asp:Label ID="lbllogincount403" runat="server" Text='<%# Bind("logincount") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
           
         <asp:TemplateField HeaderText="Time count" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Timecount404" runat="server" Value='<%# Eval("Timecount") %>' /><asp:HiddenField ID="Timecount4" runat="server" Value='<%# Eval("Timecount") %>' />
        <asp:Label ID="lblTimecount4040" runat="server" Text='<%# Bind("Timecount") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
         <asp:TemplateField HeaderText="Avg time" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="Avgtime404" runat="server" Value='<%# Eval("Avgtime") %>' /><asp:HiddenField ID="Avgtime40" runat="server" Value='<%# Eval("Avgtime") %>' />
        <asp:Label ID="lblAvgtime40" runat="server" Text='<%# Bind("Avgtime") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>                                 
        
                                                               
         </Columns>
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <%--   --------------Login Monitoring end ------------------------%>
          <%--   --------------Customer Wiser Trade offer Report Start ------------------------%> 
     <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView8_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
       
         <asp:TemplateField HeaderText="Line" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField3453" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField4510" runat="server" Value='<%# Eval("strLine") %>' />
        <asp:Label ID="itemid054" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

        

         <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Region420155" runat="server" Value='<%# Eval("strRegion") %>' /><asp:HiddenField ID="Region4520154" runat="server" Value='<%# Eval("strRegion") %>' />
        <asp:Label ID="lblRegion420515" runat="server" Text='<%# Bind("strRegion") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Area" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Area542015" runat="server" Value='<%# Eval("strArea") %>' /><asp:HiddenField ID="Area520154" runat="server" Value='<%# Eval("strArea") %>' />
        <asp:Label ID="lblArea542015" runat="server" Text='<%# Bind("strArea") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
        
         <asp:TemplateField HeaderText="Territory" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Territory540111" runat="server" Value='<%# Eval("strTerritory") %>' /><asp:HiddenField ID="Territory5411144" runat="server" Value='<%# Eval("strTerritory") %>' />
        <asp:Label ID="lblTerritory5411151" runat="server" Text='<%# Bind("strTerritory") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
       
         <asp:TemplateField HeaderText="Point" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Point540111" runat="server" Value='<%# Eval("strDistributor") %>' /><asp:HiddenField ID="strArea5111445" runat="server" Value='<%# Eval("strDistributor") %>' />
        <asp:Label ID="lblPoint5411151" runat="server" Text='<%# Bind("strDistributor") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

         <asp:TemplateField HeaderText="Uom" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="Uom454504504" runat="server" Value='<%# Eval("Uom","{0:n0}") %>' /><asp:HiddenField ID="startdate540545" runat="server" Value='<%# Eval("Uom","{0:0}") %>' />
        <asp:Label ID="Uom65465406" runat="server" Text='<%# Bind("Uom") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 
                
         <asp:TemplateField HeaderText="productidd" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="productidd465406" runat="server" Value='<%# Eval("productidd") %>' /><asp:HiddenField ID="endDate45401151s" runat="server" Value='<%# Eval("productidd","{0:0}") %>' />
        <asp:Label ID="endDate6450646" runat="server" Text='<%# Bind("productidd","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
         <asp:TemplateField HeaderText="freeqty" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="freeqty64065" runat="server" Value='<%# Eval("freeqty") %>' /><asp:HiddenField ID="InstractionDate6540015" runat="server" Value='<%# Eval("freeqty") %>' />
        <asp:Label ID="freeqty5406540" runat="server" Text='<%# Bind("freeqty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>  




                           
                           
                            <asp:TemplateField HeaderText="startdate" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="startdate454504504" runat="server" Value='<%# Eval("startdate","{0:d}") %>' /><asp:HiddenField ID="startdate540545s" runat="server" Value='<%# Eval("startdate","{0:d}") %>' />
        <asp:Label ID="startdate65465406" runat="server" Text='<%# Bind("startdate","{0:d}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:TemplateField> 
                
         <asp:TemplateField HeaderText="endDate" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="endDate465406" runat="server" Value='<%# Eval("enddate","{0:d}") %>' /><asp:HiddenField ID="endDate45401151" runat="server" Value='<%# Eval("enddate","{0:d}") %>' />
        <asp:Label ID="endDate6450646154" runat="server" Text='<%# Bind("enddate","{0:d}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField>   
          
         <asp:TemplateField HeaderText="Instraction Date" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="InstractionDate64065" runat="server" Value='<%# Eval("Instractiondate","{0:d}") %>' /><asp:HiddenField ID="InstractionDate6540" runat="server" Value='<%# Eval("Instractiondate","{0:d}") %>' />
        <asp:Label ID="InstractionDate5406540" runat="server" Text='<%# Bind("Instractiondate","{0:d}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="80px"/></asp:TemplateField> 
                           
                                                  
         </Columns>
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>                                
              </td>
                </tr>
            </table>
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
            ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>