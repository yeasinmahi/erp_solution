<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillRegistrationNew.aspx.cs" Inherits="UI.SCM.BillRegistrationOldOne" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Registration </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
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
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
                       
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblRefference" runat="server" CssClass="lbl" Text="Refference :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlRefference" runat="server" CssClass="ddList" width="120px" height="23px" OnSelectedIndexChanged="ddlRefference_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True" Value="1">PO</asp:ListItem><asp:ListItem Value="2">Others</asp:ListItem></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="Reff No.:" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtReffNo" runat="server" CssClass="txtBox1" width="120px"></asp:TextBox></td> 
                <td style="text-align:right; "><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; padding: 0px 0px 10px 0px"><asp:Button ID="btnGo" runat="server" class="myButton" Text="Go" OnClick="btnGo_Click"/></td>        
                
                <td style="text-align:right; "><asp:Label ID="Label30" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label29" runat="server" Text="Print Copies :" CssClass="lbl"></asp:Label></td>
                <td colspan="6"><asp:TextBox ID="TextBox10" runat="server" CssClass="txtBox1" width="100px"></asp:TextBox>
                <span style="padding-right:20px"><asp:Label ID="Label31" runat="server" Text=""></asp:Label></span> 
                <span style="padding-right:15px"><asp:CheckBox ID="ckbAdvance" runat="server" Text=" Advance" AutoPostBack="true" OnCheckedChanged="ckbAdvance_CheckedChanged" /></span>
                <%--<span style="padding-right:20px"><asp:Label ID="Label32" runat="server" Text="Advance" CssClass="lbl"></asp:Label>--%>
                <asp:Label ID="Label33" runat="server" Text=""></asp:Label></span>
                
                <asp:Label ID="lblPOAmount" runat="server" Text="Total PO Amount :" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtPOAmount" runat="server" CssClass="txtBox1" width="90px"></asp:TextBox></td> 
            </tr>            
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Billing Unit :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlBillingUnit" runat="server" CssClass="ddList" width="120px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlBillingUnit_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Party Type :"></asp:Label></td>
                <td style="text-align:left;" colspan="3">
                <asp:DropDownList ID="ddlPartyType" runat="server" CssClass="ddList" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1">Supplier</asp:ListItem><asp:ListItem Value="2">Employee</asp:ListItem>
                <asp:ListItem Value="3">Customer</asp:ListItem><asp:ListItem Value="4">Others</asp:ListItem>
                <asp:ListItem Value="5">Salary/Bonus</asp:ListItem><asp:ListItem Value="6">Manual Advance</asp:ListItem>
                </asp:DropDownList></td>
                
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text="" Width="25px"></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Pre Advance:" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPreAdvance" runat="server" CssClass="txtBox1" width="100px"></asp:TextBox></td> 
                <td style="text-align:right; "><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblAdvance" runat="server" Text="Total Advance:" CssClass="lbl"></asp:Label></td>
                <td colspan="3" style="padding: 10px 0px 10px 0px""><asp:TextBox ID="txtAdvance" runat="server" CssClass="txtBox1" width="205px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Party Name :" CssClass="lbl"></asp:Label></td>
                <td colspan="6">
                    <asp:TextBox ID="txtPartyName" runat="server" AutoPostBack="true" CssClass="txtBox1" width="413px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtPartyName"
                    ServiceMethod="AutoSearchSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>

                    <asp:TextBox ID="txtEmplyeeName" runat="server" AutoPostBack="true" CssClass="txtBox1" width="413px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtEmplyeeName"
                    ServiceMethod="AutoSearchEmpList" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>

                    <asp:TextBox ID="txtOtherPartyName" runat="server" AutoPostBack="true" CssClass="txtBox1" width="413px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtOtherPartyName"
                    ServiceMethod="AutoSearchOtherPartyList" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>

                    <asp:TextBox ID="txtCommonText" runat="server" CssClass="txtBox1" width="413px"></asp:TextBox>
                </td>

                <td style="text-align:right; "><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
               <%-- <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Adjust Amount :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtAdjAmount" runat="server" CssClass="txtBox1" width="100px"></asp:TextBox></td> --%>
                <td style="text-align:right; "><asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblLBalance" runat="server" Text="Ledger Balance :" CssClass="lbl"></asp:Label></td>
                <td colspan="3"><asp:TextBox ID="txtLBalance" runat="server" CssClass="txtBox1" width="205px"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="Bill No. :" CssClass="lbl"></asp:Label></td>
                <td colspan="6"><asp:TextBox ID="txtBillNo" runat="server" CssClass="txtBox1" width="90px"></asp:TextBox>
                <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label23" runat="server" Text="Bill Date :" CssClass="lbl"></asp:Label>          
                <asp:TextBox ID="txtBillDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="102px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBillDate"></cc1:CalendarExtender>
                <asp:Label ID="Label25" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label24" runat="server" Text="Amount :" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox1" width="90px"></asp:TextBox></td>

                <td style="text-align:right; "><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
                <%--<td style="text-align:right;"><asp:Label ID="lblEmployeeUnit" runat="server" CssClass="lbl" Text="Employee Of :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlEmployeeUnit" runat="server" CssClass="ddList" width="105px" height="23px" OnSelectedIndexChanged="ddlEmployeeUnit_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="lblSearch" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Search :" CssClass="lbl"></asp:Label></td>                
                <td><asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox1" width="120px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; padding: 10px 0px 20px 0px"><asp:Button ID="btnSearch" runat="server" class="myButton" Text="Go" OnClick="btnSearch_Click"/></td>--%>
            </tr>
           <%-- <tr>
                <td style="text-align:right;"><asp:Label ID="Label28" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
                <td colspan="7"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" width="413px"></asp:TextBox></td>

                <asp:Label ID="Label27" runat="server" Text=""></asp:Label>--%>
               <%-- <td style="text-align:right;"><asp:Label ID="lblCOALedger" runat="server" Text="Party Ledger :" CssClass="lbl"></asp:Label></td>
                <td colspan="6" >
                    <%--<asp:TextBox ID="txtCOALedger" runat="server" CssClass="txtBox1" width="413px"></asp:TextBox>--%>

                   <%-- <asp:TextBox ID="txtCOALedger" runat="server" AutoPostBack="true"  CssClass="txtBox1" width="413px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCOALedger"
                    ServiceMethod="AutoSearchCOAList" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>
                </td>
            </tr>
          <%--  <tr>
                <td colspan="18" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnSave" runat="server" class="myButton" Text="Save" OnClick="btnSave_Click"/></td>        
            </tr>--%>

            <tr><td colspan="18"><hr /></td></tr>
            <tr><td colspan="18">   
            <asp:GridView ID="dgvChallan" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvLoan_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Challan No." SortExpression="strExtnlReff">
            <ItemTemplate><asp:Label ID="lblChallan" runat="server" Text='<%# Bind("strExtnlReff") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="MRR No." SortExpression="intMRRID">
            <ItemTemplate><asp:Label ID="lblMRRID" runat="server" Text='<%# Bind("intMRRID") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>                
            
            <asp:TemplateField HeaderText="Amount" SortExpression="monAmo">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monAmo") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>
                            
           <%-- <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnRemove" class="myButtonGrid" Font-Bold="true" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="R"  
            Text="Remove"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>--%>

            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr> 
        </table>
     </div>




    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>