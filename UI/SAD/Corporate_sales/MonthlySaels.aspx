<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlySaels.aspx.cs" Inherits="UI.SAD.Corporate_sales.MonthlySaels" %>

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
                            <td align="right" class="auto-style7">
                                &nbsp;</td>
                            <td class="auto-style8">
                                &nbsp;</td>
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
                        <table class="" style="width:676px; float:left; margin-right: 0px;">
            <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style14"><asp:Label ID="Label4"  runat="server" Text="Report Category :" Font-Bold="True" Font-Names="Calibri" Font-Size="15px"></asp:Label></td>
               <td class="auto-style11"><asp:DropDownList BackColor="#f2f2f2" CssClass="txtBox" ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                   <asp:ListItem>-Select-</asp:ListItem>
                   <asp:ListItem Value="1">Sales Report</asp:ListItem>
                   <asp:ListItem Value="2">Order Report</asp:ListItem>
                   </asp:DropDownList> </td>
               <td style="text-align:right;" class="auto-style6">&nbsp;</td>
               <td class="auto-style3">&nbsp;</td>
           </tr>
         
           
            <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style14"><asp:Label ID="Label1"  runat="server" Text="Area Name :" Font-Bold="True" Font-Names="Calibri" Font-Size="15px"></asp:Label></td>
               <td class="auto-style11"><asp:DropDownList BackColor="#f2f2f2" CssClass="txtBox" ID="ddlarea" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlarea_SelectedIndexChanged"></asp:DropDownList> </td>
               <td style="text-align:right;" class="auto-style6"></td>
               <td class="auto-style3"></td>
           </tr>

           
            <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style14"><asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Names="Calibri" Text="Territory Name :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style11"><asp:DropDownList AutoPostBack="true" BackColor="#f2f2f2" ID="ddlTerritory" CssClass="txtBox"  runat="server" OnSelectedIndexChanged="ddlTerritory_SelectedIndexChanged"></asp:DropDownList></td>
               <td style="text-align:right;" class="auto-style6">&nbsp;</td>
               <td class="auto-style3">&nbsp;</td>
           </tr>




           <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style15"><asp:Label ID="Label8" runat="server" Font-Bold="true" Font-Names="Calibri" Text="Point :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style12"> <asp:DropDownList ID="ddlCustName" BackColor="#f2f2f2" CssClass="txtBox"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustName_SelectedIndexChanged"></asp:DropDownList> </td>
               <td style="text-align:right;" class="auto-style7"></td>
               <td class="auto-style4"><asp:HiddenField ID="hdnAreanumber" runat="server" /></td>
           </tr>

           <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style2"><asp:Label ID="Label6" Font-Bold="true" Font-Names="Calibri" runat="server" Text="From Date :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style13">
                   <asp:TextBox ID="txtfromdates" CssClass="txtBox" runat="server"></asp:TextBox>
                   <asp:ImageButton ID="ImageButton1" ImageUrl="~/Content/images/img/cal.png" runat="server" Height="22px" Width="40px" OnClick="ImageButton1_Click" /></td>
               <td style="text-align:right;" class="auto-style8"><asp:Label ID="Label9" Font-Bold="true" Font-Names="Calibri" runat="server" Text="To Date :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style5"><asp:TextBox ID="txttodate" Width="150px"  BackColor="#f2f2f2" CssClass="txtBox" runat="server" OnTextChanged="txtaddress_TextChanged"></asp:TextBox><asp:ImageButton ID="ImageButton2" ImageUrl="~/Content/images/img/cal.png" runat="server" Height="22px" Width="40px" OnClick="ImageButton2_Click"  /></td>
           </tr>
            <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style2">&nbsp;</td>
               <td class="auto-style13">
                   <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="81px" Width="131px" OnSelectionChanged="Calendar1_SelectionChanged">
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
               <td style="text-align:right;" class="auto-style8">&nbsp;</td>
               <td class="auto-style5">
                   <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="81px" Width="131px" OnSelectionChanged="Calendar2_SelectionChanged">
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
           </tr>
           <tr >
               <td colspan="4" style="text-align:right;" class="auto-style1">    

                   <div> <asp:Button ID="Button2" Font-Bold="true" Font-Names="Calibri" Font-Size="15px" BackColor="White" runat="server" Text="Show" OnClick="Button1_Click" /></div> </td>
           </tr>
           
       </table>

                          


            
                             <asp:Label ID="Label2" BackColor="#ffcccc" runat="server" Text="Label" style="z-index: 1; left: 703px; top: 359px; position: absolute"></asp:Label>
                    

                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
            </p>
       
         
        
   
            </td>
    </tr> 
    </table>
        
        
        <%----------Memo start----------------------------------------------------------------%>


       <%-- ------------Memo end -----------------------------------------------------------------%>
        
         <%-- ------------Employee start -----------------------------------------------------------------%>

         <%-- ------------Employee End -----------------------------------------------------------------%>
        
     <%--   --------------Login Monitoring------------------------%>

        <%--   --------------Login Monitoring end ------------------------%>
          <%--   --------------Customer Wiser Trade offer Report Start ------------------------%> 
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
