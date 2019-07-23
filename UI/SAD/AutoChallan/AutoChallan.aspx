<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoChallan.aspx.cs" Inherits="UI.SAD.AutoChallan.AutoChallan" %>

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
                                <table style="background-color:#C0C0C0;width:65%">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style5">
                                            Ship Point
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" Width="220px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShip_SelectedIndexChanged1" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;width:220px">
                                            Sales Office
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSo_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                        </td>
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
                                From
                            </td>
                            <td class="auto-style8">
                            <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Date:  "></asp:Label><span style="color:red">*</span></td>
                             <td><asp:TextBox ID="txtFrom" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
                             <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender>
                                <%--<asp:TextBox ID="txtFrom" runat="server" Enabled="false" OnTextChanged="txtFrom_TextChanged" Height="22px"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                    ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />--%>

                                <asp:RadioButton ID="RadioButton1" AutoPostBack="true" GroupName="Pending" Text="Pending" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                 <asp:RadioButton ID="RadioButton2" AutoPostBack="true" GroupName="Pending" Text="Loading Slip" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" />
                                
                                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click1" />
                                 </td>
                            <td align="right" class="auto-style8">
                                </td>
                            <td class="auto-style8">

                                <asp:Button ID="Button2" runat="server" Text="Stock" OnClick="Button2_Click1" />
                                </td>
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
                    <td><asp:Label ID="Label1" runat="server" Text="">Single Customer :</asp:Label>
                        <asp:TextBox ID="txtCustomer" onchange="javascript: Changed();"  runat="server" CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px"></asp:TextBox>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                           </td>
                    
                </tr>
                <tr>
                    <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"   OnRowDataBound="GridView1_RowDataBound" ShowFooter="True"
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                       <%-- <asp:BoundField DataField="dtedate" HeaderText="Date" ReadOnly="True" SortExpression="Date" DataFormatString="{0:d}"/>--%>
              <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("Custid") %>'></asp:Label></ItemTemplate>
              <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
              </FooterTemplate></asp:TemplateField>
            
             <asp:BoundField DataField="strline" HeaderText="line" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="strregion" HeaderText="Region" ReadOnly="True" SortExpression="strregion"/>
             <asp:BoundField DataField="strarea" HeaderText="Area" ReadOnly="True" SortExpression="strarea"/>
             <asp:BoundField DataField="strTerritory" HeaderText="Territory" ReadOnly="True" SortExpression="strTerritory"/>
             <asp:BoundField DataField="Point" HeaderText="Point" ReadOnly="True" SortExpression="Point"/>
             <asp:BoundField DataField="strName" HeaderText="strName" ReadOnly="True" SortExpression="strName"/>
             
             <asp:TemplateField HeaderText="Pending Qty" SortExpression="Pending">
             <ItemTemplate><asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("Pending","{0:n0}")) %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# Pendingtotal %>' /></FooterTemplate>
             </asp:TemplateField>
           
            <asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("Custid") %>' />
              </ItemTemplate>
            </asp:TemplateField>
                    </Columns>
                 <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

                </asp:GridView>


           
        
                        
                        
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"   OnRowDataBound="GridView2_RowDataBound" ShowFooter="True"
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                       <%-- <asp:BoundField DataField="dtedate" HeaderText="Date" ReadOnly="True" SortExpression="Date" DataFormatString="{0:d}"/>--%>
              <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("custid") %>'></asp:Label></ItemTemplate>
              <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
              </FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="strName" SortExpression="strName"><ItemTemplate><asp:Label ID="lblstrName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
              <ItemStyle HorizontalAlign="Left" Width="120px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="120px"  runat="server" /></div>
              </FooterTemplate></asp:TemplateField>

            
             <asp:BoundField DataField="Slipno" HeaderText="Slip no" ReadOnly="True" SortExpression="Slipno"/>
             <asp:BoundField DataField="Qty" HeaderText="Qty" ReadOnly="True" SortExpression="Qty"/>
         
       
             
             <asp:TemplateField HeaderText="Total Qty" SortExpression="Pending">
             <ItemTemplate><asp:Label ID="lblTotalQty" runat="server" Text='<%# (""+Eval("TotalQty","{0:n0}")) %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# TotalQtytotal %>' /></FooterTemplate></asp:TemplateField>


           <asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Updates" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("Slipno") %>' />
              </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Delete">
              <ItemTemplate>
              <asp:Button ID="Complete1" runat="server" Text="Delete" CommandName="complete"  OnClick="Updates1" OnClientClick="Registration" Font-Bold="true" BackColor="#cfcfcf"   CommandArgument='<%# Eval("Slipno") %>' />
              </ItemTemplate>
            </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
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
