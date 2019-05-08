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
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"  > 
                                </asp:DropDownList> 
                                
                                 

                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" Font-Bold="False" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged" 
                                                  ></asp:DropDownList>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblSalesOffice" runat="server" CssClass="lbl" Text="Sales Office:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSalesOffice" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSalesOffice_SelectedIndexChanged"  ></asp:DropDownList>

                            </td>
                            </tr>
                             <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Customer Type:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCustomerType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged"   ></asp:DropDownList>

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
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Customer: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                <asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtCustomer_TextChanged" ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCustomer" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Ship To Party: "></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:HiddenField ID="hdnShipToPartyId" runat="server" />
                                        <asp:HiddenField ID="hdnShipToPartyText" runat="server" />
                                        <asp:TextBox ID="txtShipToParty" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtShipToParty_TextChanged"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtShipToParty" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                                                  ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
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
                              <asp:TextBox ID="txtCustomerAddress" runat="server" TextMode="MultiLine" EnableCaching="false"  CssClass="txtBox" Width="300px"   ></asp:TextBox>
                          </td>
                          <td style="text-align: right;">
                              <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Address: "></asp:Label> 
                          </td>
                          <td style="text-align: left;">
                              <asp:TextBox ID="txtShipToPartyAddress" TextMode="MultiLine" runat="server" EnableCaching="false" CssClass="txtBox" Width="300px"  ></asp:TextBox>
                          </td>
                      </tr>
                            <tr><td></td></tr>
                    </table>
                <hr />
                     <table style="width: 530px; vertical-align: top;">
                    <tr>
                        <td>
                            <b style="color: Green;">LOGISTIC</b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdoNeedVehicle" runat="server" Width="120px" AutoPostBack="True" 
                                                 RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoNeedVehicle_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="2" >No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td  style="color: Maroon;">
                            <b>Charge</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVehicleCharge" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVehicleCharge_SelectedIndexChanged" > 
                            </asp:DropDownList>
                             
                        </td>
                        <td style="color: Blue;">
                            <b>Incentive</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVehicleIncentive" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVehicleIncentive_SelectedIndexChanged">
                                               
                            </asp:DropDownList>
                            
                        </td>           
                                         
                    </tr>
                </table>
             
                    <table>
                         <tr>
                             <td style="width: 300px; vertical-align: top;">
                                 <asp:Panel ID="pnlVehicleMain" runat="server" Visible="True">
                                     <table style="width: 300px;">
                                         <tr>
                                             <td colspan="2">
                                                 <asp:RadioButtonList ID="rdoVehicleCompany" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoVehicleCompany_SelectedIndexChanged"  >
                                                     <asp:ListItem Selected="True" Value="1">Company</asp:ListItem>
                                                     <asp:ListItem Value="2">3rd Party</asp:ListItem>
                                                     <asp:ListItem Value="3">Customer</asp:ListItem>
                                                 </asp:RadioButtonList>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td style="text-align: right">Vehicle </td>
                                             <td>
                                                 <asp:HiddenField ID="hdnVehicle" runat="server" />
                                                 <asp:HiddenField ID="hdnVehicleText" runat="server" />
                                                 <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                                                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetVehicleList" TargetControlID="txtVehicle">
                                                 </cc1:AutoCompleteExtender>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td style="text-align: right">Driver </td>
                                             <td style="text-align: left">
                                                 <asp:TextBox ID="txtDriver" runat="server" CssClass="txtBox" Visible="true"></asp:TextBox>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td style="text-align: right">ContactNo </td>
                                             <td style="text-align: left">
                                                 <asp:TextBox ID="txtDriverContact" runat="server" CssClass="txtBox"></asp:TextBox>
                                             </td>
                                         </tr>
                                     </table>
                                 </asp:Panel>
                             </td>
                             <td>
                                 <asp:Panel ID="pnlVehicle3rd" runat="server" Visible="False">
                                     <table style="width: 300px;">
                                         <tr>
                                             <td>Supplier </td>
                                             <td>
                                                 <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" AutoPostBack="true" Width="200px"></asp:TextBox>
                                                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetSupplierList" TargetControlID="txtSupplier">
                                                 </cc1:AutoCompleteExtender>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>Charge To </td>
                                             <td>
                                                 <asp:RadioButtonList ID="rdo3rdPartyCharge" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Selected="True" Value="true">3rd Party</asp:ListItem>
                                                     <asp:ListItem Value="false">Company</asp:ListItem>
                                                 </asp:RadioButtonList>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>Type </td>
                                             <td>
                                                 <asp:DropDownList ID="ddlVehicleType" runat="server" AutoPostBack="True">
                                                 </asp:DropDownList>
                                             </td>
                                         </tr>
                                     </table>
                                 </asp:Panel>
                             </td>
                             
                             <td >
                                 <asp:Panel ID="pnlVehicleCustomer" runat="server" Visible="True">
                                     <table style="width: 300px;">
                                         <tr>
                                             <td>Supplier </td>
                                             <td>
                                                 <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Search" AutoPostBack="true" Width="200px"></asp:TextBox>
                                                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetSupplierList" TargetControlID="txtSupplier">
                                                 </cc1:AutoCompleteExtender>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>Charge To </td>
                                             <td>
                                                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Selected="True" Value="true">3rd Party</asp:ListItem>
                                                     <asp:ListItem Value="false">Company</asp:ListItem>
                                                 </asp:RadioButtonList>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>Type </td>
                                             <td>
                                                 <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                                 </asp:DropDownList>
                                             </td>
                                         </tr>
                                     </table>
                                 </asp:Panel>
                             </td>

                         </tr>
                    </table>
                <hr />
                    <table>
                        <tr><td></td></tr> 
                        <tr>
                            <td style="color: maroon">
                                CUR
                            </td>
                            <td style="color: green;">
                                <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                                
                                <asp:TextBox ID="txtConvRate" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td style="color: Olive;">
                                <asp:RadioButtonList ID="rdoSalesType" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True" >
                                                   
                                </asp:RadioButtonList>
                                
                            </td>
                        </tr>
                    </table>
                    <table> 
                        <tr style="background-color: #B0B0B0; text-align: center;">
                            <td style="color: Green;">Product</td>
                            <td>UOM</td>
                            <td>Price</td> 
                            <td> Commission</td>
                            <td style="color: Red;"> Quantity</td>
                            <td>Total</td>
                            <td style="color: Green;"> Action</td> 
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnProduct" runat="server" />
                                <asp:HiddenField ID="hdnProductText" runat="server" />
                                <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"
                                             AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"  ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtProduct"
                                                          ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                          CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                          CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnUOM" runat="server" />
                                <asp:DropDownList ID="ddlUOM" runat="server"  >
                                  
                                </asp:DropDownList>
                                 
                            </td>
                            <td  align="center">
                                <asp:TextBox ID="lblPrice" runat="server" Width="50px"></asp:TextBox>
                            </td>
                          
                            <td align="center">
                                <asp:Label ID="lblComm" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle;">
                                <asp:TextBox ID="txtQun" runat="server" Width="60px"></asp:TextBox>
                                &nbsp;
                            </td>
                            <td align="center" style="text-align: right;">
                                <asp:Label ID="lblTotal" Text="0" runat="server"></asp:Label>
                            </td>
                            
                            <td align="right">
                                <asp:Button ID="btnProductAdd" runat="server"  Text="Add" ValidationGroup="valComAdd" OnClick="btnProductAdd_Click" />
                                <asp:Button ID="btnProductAddAll" runat="server"  Text="Add-All" ValidationGroup="valComAdd" OnClick="btnProductAddAll_Click" />
                            </td>

                        </tr>
                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
