<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.SAD.Order.ChallanList" Codebehind="ChallanList.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">        
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=750,top=70,left=220');
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 140px; float: right;">
                    <table style="width: 1000px;">
                        <tr>
                            <td colspan="6">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            Unit
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                                                DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound"
                                                OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits"
                                                TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align: right;">
                                            Ship Point
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                                DataTextField="strName" DataValueField="intShipPointId" OnDataBound="ddlShip_DataBound"
                                                OnSelectedIndexChanged="ddlShip_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint"
                                                TypeName="SAD_BLL.Global.ShipPoint" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnVehicle" runat="server" />                                            
                                            Vehicle
                                            <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" Width="350px"
                                                AutoPostBack="true" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtVehicle"
                                                ServiceMethod="GetVehicleList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 60px">
                                From
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                To
                            </td>
                            <td>
                                <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                Trip Code
                                <asp:HiddenField ID="hdnTr" runat="server" />
                                <asp:TextBox ID="txtCode" Text="" runat="server"></asp:TextBox>
                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" Style="height: 26px" />
                            </td>
                             <td align="right">
                                DO No
                                 <asp:HiddenField ID="hdnDo" runat="server" />
                                <asp:TextBox ID="txtDoCode" Text="" runat="server"></asp:TextBox>
                                <asp:Button ID="btnGoDo" runat="server" Text="Go" Style="height: 26px" 
                                     onclick="btnGoDo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" style="height: 50px;">
                                <asp:RadioButtonList ID="rdoComplete" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal" 
                                    onselectedindexchanged="rdoComplete_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="false">Not Delivered</asp:ListItem>
                                    <asp:ListItem Value="true">Delivered</asp:ListItem>
                                </asp:RadioButtonList>
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

            <asp:GridView ID="GridView1" SkinID="sknGrid1" runat="server" 
                AutoGenerateColumns="False" CaptionAlign="Top" Caption="Trip List"
                DataKeyNames="intId" DataSourceID="ObjectDataSource3" AllowPaging="True" PageSize="20" 
                >
                <Columns>
                    <asp:BoundField DataField="strCode" HeaderText="Trip Code" 
                        SortExpression="strCode" />                                       
                    <asp:BoundField DataField="strRegNo" HeaderText="Registration No" 
                        SortExpression="strRegNo" />  
                     <asp:TemplateField HeaderText="Own" SortExpression="ysnOwn">
                         <ItemTemplate>
                         <asp:Label ID="Label7" runat="server" Text='<%# GetVhlType(Eval("ysnOwn"),Eval("int3rdPartyCOAid"),Eval("intForThisCustomer")) %>'></asp:Label>
                         </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Driver" SortExpression="strDriver">
                         <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("strDriver") %>'></asp:Label>
                            <br />
                           <asp:Label ID="Label6" runat="server" Text='<%# Eval("strContact") %>'></asp:Label>
                         </ItemTemplate>                         
                    </asp:TemplateField>                              
                    <asp:TemplateField HeaderText="Gate Time" SortExpression="dteInTime">
                        <ItemTemplate>
                            <asp:Label ID="Label1" ForeColor="#990000" runat="server" Text='<%# "In : "+Eval("dteInTime") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label2" ForeColor="#009900" runat="server" Text='<%# "Out: "+Eval("dteOutTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                        
                     <asp:TemplateField HeaderText="Loading Time" SortExpression="dteEmptyWgtTime">
                         <ItemTemplate>
                             <asp:Label ID="Label3" ForeColor="#990000" runat="server" Text='<%# "In: "+Eval("dteEmptyWgtTime") %>'></asp:Label>
                             <br />
                             <asp:Label ID="Label4" ForeColor="#009900" runat="server" Text='<%# "Out: "+Eval("dteLoadedWgtTime") %>'></asp:Label>
                         </ItemTemplate>                         
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Capacity & Load" SortExpression="dteEmptyWgtTime">
                         <ItemTemplate>
                             <asp:Label ID="Label8" ForeColor="#990000" runat="server" Text='<%# "C : "+Eval("numLoadingCapacity") %>'></asp:Label>
                             <br />
                             <asp:Label ID="Label9" ForeColor="#009900" runat="server" Text='<%# "L: "+Eval("numLoaded") %>'></asp:Label>
                         </ItemTemplate>                         
                    </asp:TemplateField>                   
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <%# GetPrintLink(Eval("intId"), Eval("ysnCompleted"))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            <%# GetEditLink(Eval("intId"), Eval("intLoadedWgtBy"))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center">                        
                        <ItemTemplate>
                            <asp:Button ID="btnCompleted" runat="server" 
                                CommandArgument='<%# ""+Eval("intId")+(""+Eval("ysnTripAssignCom") != "True"? "#c":"#r") %>' OnClick="btnCompleted_Click" 
                                Text='<%# (""+Eval("ysnTripAssignCom") != "True"? "Complete":"Rollback") %>' 
                                 Visible='<%# (""+Eval("intLoadedWgtBy") == ""? true:false) %>'
                                ValidationGroup="valCom" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetChallanInfo"
                TypeName="LOGIS_BLL.Trip.Trip" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtFrom" Name="fromDate" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="txtTo" Name="toDate" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="hdnTr" Name="code" PropertyName="Value" 
                        Type="String" />
                    <asp:ControlParameter ControlID="hdnDo" Name="DOcode" PropertyName="Value" 
                        Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                    <asp:ControlParameter ControlID="hdnVehicle" Name="vehicleId" PropertyName="Value"
                        Type="String" />
                    <asp:ControlParameter ControlID="rdoComplete" Name="isCompleted" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:Parameter Name="isTripAssignCompleted" Type="String" />
                    <asp:ControlParameter ControlID="ddlShip" Name="shippingPoint" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
                ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
