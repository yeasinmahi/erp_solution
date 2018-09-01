<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankReceive.aspx.cs" Inherits="UI.Accounts.Advice.BankReceive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
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
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />

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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnWHID" runat="server" /> <asp:HiddenField ID="hdnGroupID" runat="server" /><asp:HiddenField ID="hdnCategoryID" runat="server" />
    <asp:HiddenField ID="hdnItemID" runat="server" />
        
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BANK RECEIVE <hr />
        </div>

        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td>
                    <table class="tbldecoration" style="width:auto; float:left; border:solid">
                        <tr><td style="text-align:right"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
                            <td style="text-align:center"><asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList" Font-Bold="false" width="220px" height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList>
                            <asp:Button ID="btnShow" runat="server" Text="Show" class="myButtonGrey" Width="100px" OnClick="btnShow_Click" />
                        </td>
                    </tr></table>
                </td>
            </tr>
            <tr><td>
            <table>
                <tr><td><hr /></td></tr>
                <tr><td><asp:GridView ID="dgvItem" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="Grid" FooterStyle-BackColor="#808080" FooterStyle-Font-Bold="true" FooterStyle-Font-Size="11px" FooterStyle-ForeColor="White" FooterStyle-Height="25px" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="10px" PagerStyle-CssClass="pgr" PageSize="8" ShowFooter="false" OnRowCommand="dgvItem_RowCommand" OnRowDataBound="OnRowDataBound">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>

                                <asp:TemplateField HeaderText="S/N">
                                <ItemStyle HorizontalAlign="center" Width="15px" />
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" SortExpression="intID" Visible="false">
                                <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intID") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Account ID" SortExpression="intAccountID" visible="false">
                                <ItemTemplate><asp:Label ID="lblAccountID" runat="server" Text='<%# Bind("intAccountID") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Unit ID" SortExpression="intUnitID" visible="false">
                                <ItemTemplate><asp:Label ID="lblUnitID" runat="server" Text='<%# Bind("intUnitID") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                <ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Particulars" SortExpression="strParticulars">
                                <ItemTemplate><asp:Label ID="lblParticulars" runat="server" Text='<%# Bind("strParticulars") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bank Name" SortExpression="BankName">
                                <ItemTemplate><asp:Label ID="lblBankName" runat="server" Text='<%# Bind("BankName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Account No" SortExpression="AccountNo">
                                <ItemTemplate><asp:Label ID="lblAccountNo" runat="server" Text='<%# Bind("AccountNo") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cheque No" SortExpression="strChequeNo">
                                <ItemTemplate><asp:Label ID="lblChequeNo" runat="server" Text='<%# Bind("strChequeNo") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                                <ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%# Eval("monAmount", "{0:0,0.00}") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="right" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Customer Name" SortExpression="">
                                <ItemTemplate><asp:DropDownList ID="ddlCustomer" runat="server" Width="220px"></asp:DropDownList></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks" SortExpression="">
                                <ItemTemplate><asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                <ItemTemplate><asp:Button ID="btnSubmit" runat="server" class="myButton" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Y" Font-Size="9px" Text="Submit" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>


                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </td></tr>
            <%--=========================================End My Code From Here=================================================--%>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>