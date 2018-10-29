<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpSalesReturnNew.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpSalesReturnNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
   <%-- <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

      <script language="javascript" type="text/javascript">
            
        </script>
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
        <div class="divbody" style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Corporate Sales Return Entry<hr /></div>--%>
            <table class="tbldecoration" style="width:auto; float:left;">
                  <tr>
                      <td style="text-align:left; height:20px; background-color:black; color:white; font-weight:bold;" colspan="3"><asp:Label ID="Label1" runat="server" Text="Corporate Sales Return Entry"></asp:Label></td>
                  </tr>
                 <tr>
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblUnit" runat="server" Text="Return Type "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                    <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>  
                    <td style="text-align:Left; width:300px;"><asp:Label ID="Label2" runat="server" Text="Warehouse Received Date "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                 </tr>
                 <tr>
                    <td><asp:DropDownList ID="ddlUOM" CssClass="ddList" Font-Bold="False" runat="server" width="300px" height="24px"  AutoPostBack="true">
                        <asp:ListItem>Manufacturing Fault</asp:ListItem>
                        <asp:ListItem>Damage</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="text-align:right; "><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                    <td><asp:TextBox ID="txtWHRDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox>
                        <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtWHRDate"></cc1:CalendarExtender>
                    </td>
                 </tr>
                 <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label4" runat="server" Text="Customer Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label7" runat="server" Text="Return Voucher Number "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtCustName" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox>
                     <asp:HiddenField ID="hdncustid" runat="server" /><cc1:AutoCompleteExtender ID="AutoCompleteCustomer" runat="server" TargetControlID="txtCustName"
                    ServiceMethod="GetCustomer" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
                     CompletionListItemCssClass="autocomplete_listItem"  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender></td>
                </td>
                <td style="text-align:right; "><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtReturnVoucherNo" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
            </tr>
                <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label9" runat="server" Text="Product Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label11" runat="server" Text="Customer Return Quantity (Pcs) "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtProduct" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteProduct" runat="server" TargetControlID="txtProduct" ServiceMethod="GetProduct" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>  
                    <asp:HiddenField ID="hdnprodid" runat="server" /><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" />
                </td>
                <td style="text-align:right; "><asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtCustQty" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
            </tr>
                <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label13" runat="server" Text="Warehouse Received Quantity (Pcs) "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label15" runat="server" Text="Location/Point Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtWHQty" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtLocation" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; padding: 5px 0px 5px 0px" colspan="3">
                    <asp:Button ID="btnAdd" runat="server" Style="font-size: 12px; cursor: pointer;" Text="Add" CssClass="myButton" OnClick="btnAdd_Click"/>
                    <asp:Button ID="btnSubmit" runat="server" Style="font-size: 12px; cursor: pointer;" CssClass="myButton" Text="Submit"/>
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