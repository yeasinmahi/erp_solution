<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryEntry.aspx.cs" Inherits="UI.SAD.Delivery.DeliveryEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <style type="text/css"> 
        .ajax__calendar_inactive  {color:#dddddd;}
        .txtBox {}
    </style>
    <script language="javascript" type="text/javascript">

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if ((charCode > 57))
                return false;
            return true;
        }
    </script>

    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hdnConfirm").value = "0";
            }
        }
        function autoCompleteEx_ItemSelected(sender, args) {
            document.getElementById("hdnItemSeleced").value = "Selected";
        }
    </script>
    
    
</head>

<body>

    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>

                <div style="height: 30px;"></div>

                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnDA" runat="server" />
                    <div class="tabs_container">
                     <span style="color: red">Delivery Challan</span><hr />
                    </div>
                    <table style="width: 850px">
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="lblUnitName" runat="server" CssClass="lbl" Text="Unit Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList>

                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" ></asp:DropDownList>

                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblSalesOffice" runat="server" CssClass="lbl" Text="Sales Office:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSalesOffice" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"  ></asp:DropDownList>

                            </td>
                            </tr>
                             <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Type:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"  ></asp:DropDownList>

                            </td>
                                 <td style="text-align: left;">
                                     <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Date:"></asp:Label></td>
                                 <td style="text-align: left;">
                                     <asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" EnableCaching="false" autocomplete="off" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtDate">
                                     </cc1:CalendarExtender>
                                 </td>
                                 <td style="text-align: left;">
                                     <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Due Date:"></asp:Label></td>
                                 <td style="text-align: left;">
                                     <asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox"  autocomplete="off" EnableCaching="false" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtDueDate">
                                     </cc1:CalendarExtender>
                                 </td>
                                 </tr>
                       </table>
                        <table>
                                <tr> 
                            <td style="text-align: left;">
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                    ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Ship To Party: "></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItem" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                                                  ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                                                  CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                                  CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                   <%-- <td style="text-align: right;">
                                        <asp:Label ID="lblReffInfo" CssClass="lbl" runat="server" Text="Reff Info: "></asp:Label> 
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:TextBox ID="TextBox2" runat="server"   CssClass="txtBox"   ></asp:TextBox>
                                    </td>--%>
                        </tr>

                      <tr>
                          <td style="text-align: right;">
                              <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Address: "></asp:Label> 
                          </td>
                          <td style="text-align: left;" colspan="1">
                              <asp:TextBox ID="txtCustomerAddress" runat="server" EnableCaching="false"  CssClass="txtBox" Width="300px"   ></asp:TextBox>
                          </td>
                          <td style="text-align: right;">
                              <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Address: "></asp:Label> 
                          </td>
                          <td style="text-align: left;">
                              <asp:TextBox ID="txtShipToPartyAddress" runat="server" EnableCaching="false" CssClass="txtBox" Width="300px"  ></asp:TextBox>
                          </td>
                      </tr>
                            <tr><td></td></tr>
                    </table>
                     <table style="width: 530px; vertical-align: top;">
                    <tr>
                        <td>
                            <b style="color: Green;">LOGISTIC</b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdoNeedVehicle" runat="server" Width="120px" AutoPostBack="True" 
                                                 RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="true">Yes</asp:ListItem>
                                <asp:ListItem Value="false">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td  style="color: Maroon;">
                            <b>Charge</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlExtra" runat="server" AutoPostBack="True"> 
                            </asp:DropDownList>
                             
                        </td>
                        <td style="color: Blue;">
                            <b>Incentive</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIncentive" runat="server" AutoPostBack="True">
                                               
                            </asp:DropDownList>
                            
                        </td>           
                                         
                    </tr>
                </table>
                    <table>
                         <td style="width: 300px; vertical-align: top;">
                                
                                <asp:Panel ID="pnlVehicleMain" Visible="True" runat="server">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rdoVhlCompany" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                    
                                                    <asp:ListItem Selected="True" Value="1">Company</asp:ListItem>
                                                    <asp:ListItem Value="2">3rd Party</asp:ListItem>
                                                    <asp:ListItem Value="3">Customer</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                Vehicle
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnVehicle" runat="server" />
                                                <asp:HiddenField ID="hdnVehicleText" runat="server" />
                                                <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search"   CssClass="txtBox"
                                                    AutoPostBack="true" ></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtVehicle"
                                                    ServiceMethod="GetVehicleList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                Driver
                                            </td>
                        
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtDriver" runat="server"  CssClass="txtBox" Visible="true"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                ContactNo
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtDriverContact"  CssClass="txtBox" runat="server"  ></asp:TextBox>
                                            </td>  
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                            </td>
                        
                        <td style="width: 300px;">
                                <asp:Panel ID="pnlVehicle3rd" Visible="True" runat="server">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td>
                                                Supplier
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" Width="200px"
                                                    AutoPostBack="true"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtSupplier"
                                                    ServiceMethod="GetSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Charge To
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdo3rdPartyCharge" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="true">3rd Party</asp:ListItem>
                                                    <asp:ListItem Value="false">Company</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Type
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlVhlType" runat="server" AutoPostBack="True" > 
                                                </asp:DropDownList>
                                                 
                                                    
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                    </table>
                    <table>
                        
                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
