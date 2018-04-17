<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveDetailsReport.aspx.cs" Inherits="UI.SAD.AutoChallan.ApproveDetailsReport" %>

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
            height: 17px;
        }
      
        .auto-style4 {
            width: 88px;
            height: 17px;
        }
      
        .auto-style5 {
            width: 190px;
        }
      
        .auto-style6 {
            width: 11px;
            height: 38px;
        }
        .auto-style7 {
            width: 88px;
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
            width: 11px;
            height: 17px;
        }
        .auto-style11 {
            height: 17px;
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
                         url: "AutoChallan.aspx/GetAutoCompleteData",
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
                                <table style="width:65%">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style5">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;width:220px">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style7">
                                &nbsp;</td>
                            <td class="auto-style8">
                                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

                                &nbsp;</td>
                            <td align="right" class="auto-style8">
                                </td>
                            <td class="auto-style8">

                                &nbsp;</td>
                            <td class="auto-style9">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style10">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style4">
                              
                            </td>
                            <td class="auto-style11">
                                

                                    </td>
                            <td align="right" class="auto-style11">
                                </td>
                            <td class="auto-style11">
                                </td>
                            <td class="auto-style3">
                                </td>
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
                    <td>&nbsp;</td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dgvtrgt" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>

         <asp:TemplateField HeaderText="strLine" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("strLine") %>' /><asp:HiddenField ID="HiddenField5" runat="server" Value='<%# Eval("strLine") %>' />
         <asp:Label ID="lblLine" runat="server" Text='<%# Bind("strLine") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField> 


         <asp:TemplateField HeaderText="Region" SortExpression="strName"><ItemTemplate>
        <asp:HiddenField ID="hdnRegion" runat="server" Value='<%# Eval("strRegion") %>' /><asp:HiddenField ID="Region1" runat="server" Value='<%# Eval("strRegion") %>' />
         <asp:Label ID="strName" runat="server" Text='<%# Bind("strRegion") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 


          <asp:TemplateField HeaderText="Area" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="hdnArea" runat="server" Value='<%# Eval("strArea") %>' /><asp:HiddenField ID="Area1" runat="server" Value='<%# Eval("strArea") %>' />
         <asp:Label ID="itemid" runat="server" Text='<%# Bind("strArea") %>'></asp:Label></ItemTemplate>
          <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

       
          <asp:TemplateField HeaderText="Territory" SortExpression="Territory"><ItemTemplate>
        <asp:HiddenField ID="Territory" runat="server" Value='<%# Eval("strTerritory") %>' /><asp:HiddenField ID="Territory1" runat="server" Value='<%# Eval("strTerritory") %>' />
        <asp:Label ID="lblTerritory" runat="server" Text='<%# Bind("strTerritory") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
          
                           
          <asp:TemplateField HeaderText="Point" SortExpression="Point"><ItemTemplate>
        <asp:HiddenField ID="hdnPoint" runat="server" Value='<%# Eval("strDistributor") %>' /><asp:HiddenField ID="Point" runat="server" Value='<%# Eval("strDistributor") %>' />
        <asp:Label ID="lblPoint" runat="server" Text='<%# Bind("strDistributor") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
         
        <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate>
        <asp:HiddenField ID="hdnCustid" runat="server" Value='<%# Eval("intCustID") %>' /><asp:HiddenField ID="Custid" runat="server" Value='<%# Eval("intCustID") %>' />
        <asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intCustID") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>                                            

 
        <asp:TemplateField HeaderText="intAccID" SortExpression="Custid"><ItemTemplate>
        <asp:HiddenField ID="hdnintAccID" runat="server" Value='<%# Eval("intAccID") %>' /><asp:HiddenField ID="intAccID" runat="server" Value='<%# Eval("intAccID") %>' />
        <asp:Label ID="lblintAccID" runat="server" Text='<%# Bind("intAccID") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>


         <asp:TemplateField HeaderText="Acc Name" SortExpression="CustName"><ItemTemplate>
        <asp:HiddenField ID="hdnCustName" runat="server" Value='<%# Eval("strAccName") %>' /><asp:HiddenField ID="strAccName" runat="server" Value='<%# Eval("strAccName") %>' />
        <asp:Label ID="lblCustName" runat="server" Text='<%# Bind("strAccName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>  
                           
        <asp:TemplateField HeaderText="Free Qty" SortExpression="TargetAmount"><ItemTemplate>
        <asp:HiddenField ID="hdnTargetAmount" runat="server" Value='<%# Eval("monFreeQty") %>' /><asp:HiddenField ID="TargetAmount" runat="server" Value='<%# Eval("monFreeQty") %>' />
        <asp:Label ID="lblTargetAmount" runat="server" Text='<%# Bind("monFreeQty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>                      
         
         <asp:TemplateField HeaderText="from Date" SortExpression="SalesAmount"><ItemTemplate>
        <asp:HiddenField ID="hdndtefromDate" runat="server" Value='<%# Eval("dtefromDate") %>' /><asp:HiddenField ID="SalesAmount" runat="server" Value='<%# Eval("dtefromDate","{0:d}") %>' />
        <asp:Label ID="lbldtefromDate" runat="server" Text='<%# Bind("dtefromDate","{0:d}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>                                        
                           
          
        <asp:TemplateField HeaderText="ToDate" SortExpression="Achievement"><ItemTemplate>
        <asp:HiddenField ID="hdndteToDate" runat="server" Value='<%# Eval("dteToDate") %>' /><asp:HiddenField ID="Achievement" runat="server" Value='<%# Eval("dteToDate","{0:d}") %>' />
        <asp:Label ID="lbldteToDate" runat="server" Text='<%# Bind("dteToDate","{0:d}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
            
         <asp:TemplateField HeaderText="Amount" SortExpression="Achievement"><ItemTemplate>
        <asp:HiddenField ID="hdnAmount" runat="server" Value='<%# Eval("Amount") %>' /><asp:HiddenField ID="Amount" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' />
        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                                              
                                                                            

                          
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