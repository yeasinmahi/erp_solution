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
    <script type="text/javascript">
        function Confirm() {
        document.getElementById("hdnconfirm").value = "0";        
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to submit?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }
    function funvalidate() {
        if ((document.getElementById("txtCustName").value).length == 0)
        { alert("Customer Name should not be empty"); return false; }
        if ((document.getElementById("txtProduct").value).length == 0)
        { alert("Product Name should not be empty"); return false; }
        if ((document.getElementById("txtReturnVoucherNo").value).length == 0)
        { alert("Challan No should not be empty"); return false; }
        if ((document.getElementById("txtCustQty").value).length == 0)
        { alert("Customer Claim Quantity should not be empty"); return false; }
        if ((document.getElementById("txtWHQty").value).length == 0)
        { alert("WH Receive Quantity should not be empty"); return false; }
        if ((document.getElementById("txtLocation").value).length == 0)
        { alert("Location should not be empty"); return false; }
    }    
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
            <asp:HiddenField ID="hdnconfirm" runat="server" />
            <table class="tbldecoration" style="width:auto; float:left;">
                  <tr>
                      <td style="text-align:left; height:20px; background-color:black; color:white; font-weight:bold;" colspan="2"><asp:Label ID="Label1" runat="server" Text="Corporate Sales Return Entry"></asp:Label></td>
                  </tr>
                 <tr>
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblunit" runat="server" Text="Return Type "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>--%>  
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblwhdate" runat="server" Text="Warehouse Received Date "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                 </tr>
                 <tr>
                    <td><asp:DropDownList ID="ddlReport" CssClass="ddList" Font-Bold="False" runat="server" width="300px" height="24px"  AutoPostBack="true">
                        <asp:ListItem Value="2">Manufacturing Fault</asp:ListItem>
                        <asp:ListItem Value="1">Damage</asp:ListItem>
                        </asp:DropDownList></td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>--%>
                    <td><asp:TextBox ID="txtWHRDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Width="300px" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtWHRDate"></cc1:CalendarExtender>
                    </td>
                      <td style="text-align:right; "><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                 </tr>
                 <tr>
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblcust" runat="server" Text="Customer Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>--%>  
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblVno" runat="server" Text="Return Voucher Number "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtCustName" runat="server" AutoPostBack="true" CssClass="txtBox1" Enabled="true" Width="300px" OnTextChanged="txtCustName_TextChanged" ></asp:TextBox>
                         <asp:HiddenField ID="hdncustid" runat="server" /><cc1:AutoCompleteExtender ID="AutoCompleteCustomer" runat="server" TargetControlID="txtCustName"
                        ServiceMethod="GetCustomer" MinimumPrefixLength="1" CompletionSetCount="1"
                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
                         CompletionListItemCssClass="autocomplete_listItem"  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                        </cc1:AutoCompleteExtender>
                    </td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>--%>
                    <td><asp:TextBox ID="txtReturnVoucherNo" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
                </tr>
                    <tr>
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lvlPro" runat="server" Text="Product Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>--%>  
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblCRQty" runat="server" Text="Customer Return Quantity (Pcs) "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtProduct" runat="server" AutoPostBack="true" CssClass="txtBox1" Enabled="true" Width="300px" OnTextChanged="txtProduct_TextChanged" ></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteProduct" runat="server" TargetControlID="txtProduct" ServiceMethod="GetProduct" MinimumPrefixLength="1" CompletionSetCount="1"
                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>  
                        <asp:HiddenField ID="hdnprodid" runat="server" /><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" />
                    </td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>--%>
                    <td><asp:TextBox ID="txtCustQty" runat="server" AutoPostBack="false" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblWHQty" runat="server" Text="Warehouse Received Quantity (Pcs) "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>--%>  
                    <td style="text-align:Left; width:300px;"><asp:Label ID="lblLocation" runat="server" Text="Location/Point Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtWHQty" runat="server" AutoPostBack="false" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
                    <%--<td style="text-align:right; "><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>--%>
                    <td><asp:TextBox ID="txtLocation" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right; padding: 5px 0px 5px 0px" colspan="2">
                        <asp:Button ID="btnAdd" runat="server" Style="font-size: 12px; cursor: pointer;" Text="Add" CssClass="myButton" OnClick="btnAdd_Click" OnClientClick="funvalidate()"/>
                        <asp:Button ID="btnSubmit" runat="server" Style="font-size: 12px; cursor: pointer;" CssClass="myButton" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
                    </td>
                </tr>
             
             </table>
           
        </div>

        <table style="float:left;">
             <tr>
                    <td colspan="3">  
                        <asp:GridView ID="dgvrtn" runat="server"  AutoGenerateColumns="False" Font-Size="9px" BackColor="White" Width="600"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" OnRowDeleting="dgvrtn_RowDeleting" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                         <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnprodid" runat="server" Value='<%# Bind("strprodid") %>' /></ItemTemplate></asp:TemplateField>
                            <asp:TemplateField HeaderText="Report Type"><ItemTemplate ><asp:Label ID="lblreport" runat="server" Text='<%# Bind("strReportType") %>'></asp:Label></ItemTemplate>
                         <ItemStyle Width="80px" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="250px"><ItemTemplate ><asp:Label ID="lblprodname" runat="server" Text='<%# Bind("strprodname") %>'></asp:Label></ItemTemplate>
                         <ItemStyle Width="250px" /></asp:TemplateField>
                         <asp:TemplateField HeaderText="Customer Return Quantity (Pcs)"><ItemTemplate ><asp:Label ID="lblrtnqty" runat="server" Text='<%# Bind("strrtnqty") %>'></asp:Label></ItemTemplate>
                         <ItemStyle Width="80px" HorizontalAlign="Center" /></asp:TemplateField>
                         <asp:TemplateField HeaderText="WH Return Quantity (Pcs)"><ItemTemplate ><asp:Label ID="lblwhrqty" runat="server" Text='<%# Bind("strwhrqty") %>'></asp:Label></ItemTemplate>
                         <ItemStyle Width="80px" HorizontalAlign="Center" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Location/Point Name"><ItemTemplate ><asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strLocation") %>'></asp:Label></ItemTemplate>
                         <ItemStyle Width="80px" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Return Cost"><ItemTemplate ><asp:Label ID="lblcost" runat="server" Text='<%# Bind("strcost") %>'></asp:Label></ItemTemplate>
                         <ItemStyle Width="80px" HorizontalAlign="Right" />
                         </asp:TemplateField>
                         <asp:CommandField ShowDeleteButton="True" >
                            <ItemStyle ForeColor="Red" />
                            </asp:CommandField>
                         </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />

                        </asp:GridView>
                    </td></tr>
        </table>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>