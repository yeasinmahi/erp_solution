<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankReceive.aspx.cs" Inherits="UI.Accounts.Bank.BankReceive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Employee Information Report</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
     <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 50px;
            width: 100%;
        }
    </style>

    <script>
          
          function Changed() {
              document.getElementById('HdfSearchbox').value = 'true';
          }
         
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <%--<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">--%>
                <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                </div>
                -
                <%--Bank Receive Form Start--%>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <asp:Label runat="server" Text="Bank Receive" Font-Bold="true" Font-Size="16px"></asp:Label>
                                </div>
                                <div class="panel-body">
                                    <div class="row form-group">
                                        <div class="col-md-8">
                                            <asp:Label ID="Label2" runat="server" Text="Unit" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                            <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-4" style="padding-top: 20px;">
                                            <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" OnClientClick="return validation();" Text="Show" OnClick="btnShow_Click" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <%--Bank Receive Form End--%>
                <%--GridView Start--%>
                <div>
                    <asp:GridView ID="gridReport" runat="server" AutoGenerateColumns="False" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="3" ForeColor="Black" HeaderStyle-Wrap="true" OnRowDataBound="gridReport_RowDataBound" GridLines="Vertical" DataKeyNames="intID">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("intID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AccountID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccountID" runat="server" Text='<%# Bind("intAccountID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>' Width="70px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Particulars">
                                <ItemTemplate>
                                    <asp:Label ID="lblParticulars" runat="server" Text='<%# Bind("strParticulars") %>' Width="170px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBank" runat="server" Text='<%# Bind("strBankName") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccount" runat="server" Text='<%# Bind("AccountName") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cheque No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblCheque" runat="server" Text='<%# Bind("strChequeNo") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("monAmount","{0:N2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Customer List">
                                <ItemTemplate>
                               
                                <asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" placeholde="Search Customer"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCustomer" 
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOther" runat="server" CssClass="" Width="130px" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-success" Text="Submit" class="button" CommandName="submit" OnClick="btnSubmit_Click" CommandArgument='<%# Eval("intID")+","+Eval("intID")%>' />
                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
                <%--GridView End--%>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btnSubmit" />--%>
                <asp:PostBackTrigger ControlID="btnShow" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
  

    
</body>
</html>

