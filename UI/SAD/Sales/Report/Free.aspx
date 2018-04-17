<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Free.aspx.cs" Inherits="UI.SAD.Sales.Report.Free" %>

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
        .auto-style1 {
            height: 63px;
        }
    </style>
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
        <table>
              <tr>
                          <td class="auto-style1" style="text-align:center">
                                From
                            </td>
                            <td class="auto-style1">
                                <asp:HiddenField ID="hdnFrm" runat="server" />
                                <asp:TextBox ID="txtFrom" CssClass="txtbox" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                <asp:DropDownList ID="ddlFHour" Width="60px" runat="server">                                                                        
                                    <asp:ListItem>06 AM</asp:ListItem>
                                    <asp:ListItem>07 AM</asp:ListItem>
                                    <asp:ListItem>08 AM</asp:ListItem>
                                    <asp:ListItem>09 AM</asp:ListItem>
                                    <asp:ListItem>10 AM</asp:ListItem>
                                    <asp:ListItem>11 AM</asp:ListItem>
                                    <asp:ListItem>12 PM</asp:ListItem>
                                    <asp:ListItem>01 PM</asp:ListItem>
                                    <asp:ListItem>02 PM</asp:ListItem>
                                    <asp:ListItem>03 PM</asp:ListItem>
                                    <asp:ListItem>04 PM</asp:ListItem>
                                    <asp:ListItem>05 PM</asp:ListItem>
                                    <asp:ListItem>06 PM</asp:ListItem>
                                    <asp:ListItem>07 PM</asp:ListItem>
                                    <asp:ListItem>08 PM</asp:ListItem>
                                    <asp:ListItem>09 PM</asp:ListItem>
                                    <asp:ListItem>10 PM</asp:ListItem>
                                    <asp:ListItem>11 PM</asp:ListItem>
                                    <asp:ListItem>12 AM</asp:ListItem>
                                    <asp:ListItem>01 AM</asp:ListItem>
                                    <asp:ListItem>02 AM</asp:ListItem>
                                    <asp:ListItem>03 AM</asp:ListItem>
                                    <asp:ListItem>04 AM</asp:ListItem>
                                    <asp:ListItem>05 AM</asp:ListItem>
                                    
                                </asp:DropDownList>                                
                            </td>
                            <td class="auto-style1" style="text-align:right">
                                To
                            </td>
                            <td class="auto-style1">
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo"  runat="server" CssClass="txtbox"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                <asp:DropDownList ID="ddlTHour" Width="60px" runat="server">                                    
                                    <asp:ListItem>06 AM</asp:ListItem>
                                    <asp:ListItem>07 AM</asp:ListItem>
                                    <asp:ListItem>08 AM</asp:ListItem>
                                    <asp:ListItem>09 AM</asp:ListItem>
                                    <asp:ListItem>10 AM</asp:ListItem>
                                    <asp:ListItem>11 AM</asp:ListItem>
                                    <asp:ListItem>12 PM</asp:ListItem>
                                    <asp:ListItem>01 PM</asp:ListItem>
                                    <asp:ListItem>02 PM</asp:ListItem>
                                    <asp:ListItem>03 PM</asp:ListItem>
                                    <asp:ListItem>04 PM</asp:ListItem>
                                    <asp:ListItem>05 PM</asp:ListItem>
                                    <asp:ListItem>06 PM</asp:ListItem>
                                    <asp:ListItem>07 PM</asp:ListItem>
                                    <asp:ListItem>08 PM</asp:ListItem>
                                    <asp:ListItem>09 PM</asp:ListItem>
                                    <asp:ListItem>10 PM</asp:ListItem>
                                    <asp:ListItem>11 PM</asp:ListItem>
                                    <asp:ListItem>12 AM</asp:ListItem>
                                    <asp:ListItem>01 AM</asp:ListItem>
                                    <asp:ListItem>02 AM</asp:ListItem>
                                    <asp:ListItem>03 AM</asp:ListItem>
                                    <asp:ListItem>04 AM</asp:ListItem>
                                    <asp:ListItem>05 AM</asp:ListItem>
                                </asp:DropDownList>                               
                            </td>
                        <td></td>
                  
                        </tr>
            <tr>
                <td style="background-color:#b6b6b6">
                    <asp:RadioButton ID="Productwise" GroupName="Freeqty" Text="By Product " AutoPostBack="true" runat="server" OnCheckedChanged="Productwise_CheckedChanged" />
                </td>
                <td style="background-color:#b6b6b6">
                    <asp:RadioButton ID="CustWise" GroupName="Freeqty" Text="By Customer" AutoPostBack="true" runat="server" OnCheckedChanged="CustWise_CheckedChanged" />
                </td>
                <td style="background-color:#b6b6b6">
                  Shiping point :
                </td>
                <td style="background-color:#b6b6b6">
                    <asp:DropDownList ID="DropDownList1" Width="120px" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <asp:GridView ID="dgvReport" runat="server" PageSize="25"  AutoGenerateColumns="false" CellPadding="5">

                    <Columns>
                        <asp:BoundField DataField="custname" HeaderText="Customer Name" SortExpression="Customer Name" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="strProductName" HeaderText="Product Name" SortExpression="Product Name" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:n0}" />
                    
                    </Columns>

                    </asp:GridView>
                <asp:GridView ID="GridView1" runat="server" PageSize="25"  AutoGenerateColumns="false" CellPadding="5">

                    <Columns>
                       
                        <asp:BoundField DataField="strProductName" HeaderText="Product Name" SortExpression="Product Name" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:n0}" />
                    
                    </Columns>

                    </asp:GridView>
             </tr>
                </table>
        
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>