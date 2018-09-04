<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierListUpdate.aspx.cs" Inherits="UI.SCM.SupplierReport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <script>
        function CheckShow() {}
    </script>
</head>
<body>
    <form id="frmattendancedetails" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
        <div class="leaveApplication_container"> 
        <div class="tabs_container" id="head"> Supplier List Update :<hr /></div>
            <table border="0"; style="width:Auto";>
                <tr class="tblrowodd">
                    
                    <td style="text-align: right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
                    <td><asp:DropDownList ID="ddlUnit" runat="server" CssClass="dropdownList" DataSourceID="ObjectDataSource1" DataTextField="strShortName" DataValueField="intUnitID"></asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="UnitList" TypeName="SCM_DAL.BillingTDSTableAdapters.TblWearHouseTableAdapter"></asp:ObjectDataSource>
                    </td>
                    <td style="text-align: right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Supplier Name : "></asp:Label></td>
                    <td><asp:DropDownList ID="ddlsupplier" runat="server" CssClass="dropdownList">                        
                                    <asp:ListItem Value="1">Local</asp:ListItem>
                                    <asp:ListItem Value="2">Import</asp:ListItem>
                                    <asp:ListItem Value="3">Fabrication</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    <td><asp:Button ID="btnShow" runat="server" class="nextclick" Style="font-size: 12px; cursor: pointer;" Text="Show Report" OnClientClick="CheckShow()" OnClick="btnShow_Click" /></td>

                </tr>               
        </table>
            <table>
                 <tr>
                    <asp:GridView ID="GVList" runat="server" AutoGenerateColumns="False"  Font-Size="11px" DataKeyNames="intSupplierID" OnRowEditing="GVList_RowEditing" OnRowUpdating="GVList_RowUpdating" OnRowCancelingEdit="GVList_RowCancelingEdit" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL" SortExpression="SL">
                                <ItemTemplate>
                                    <asp:Label ID="lblsl" runat="server" Text='<%# Bind("SL") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit" SortExpression="strUnit">
                                <ItemTemplate>
                                    <asp:Label ID="lblunit" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier ID" SortExpression="intSupplierID">
                                <ItemTemplate>
                                    <asp:Label ID="lblintSupplierID" runat="server" Text='<%# Bind("intSupplierID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrSupplierName" runat="server" Text='<%# Bind("strSupplierName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="Org Address" SortExpression="strOrgAddress">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrOrgAddress" runat="server" Text='<%# Bind("strOrgAddress") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Org Mail" SortExpression="strOrgMail">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrOrgMail" runat="server" Text='<%# Bind("strOrgMail") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Org. Contact No" SortExpression="strOrgContactNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrOrgContactNo" runat="server" Text='<%# Bind("strOrgContactNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Org FAX No" SortExpression="strOrgFAXNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrOrgFAXNo" runat="server" Text='<%# Bind("strOrgFAXNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Account No" SortExpression="strBankAccountNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrBankAccountNo" runat="server" Text='<%# Bind("strBankAccountNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Business Type" SortExpression="strBusinessType">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrBusinessType" runat="server" Text='<%# Bind("strBusinessType") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Service Type" SortExpression="strServiceType">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrServiceType" runat="server" Text='<%# Bind("strServiceType") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Supplier Type" SortExpression="strSupplierType">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrSupplierType" runat="server" Text='<%# Bind("strSupplierType") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="BIN" SortExpression="strBIN">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrBIN" runat="server" Text='<%# Bind("strBIN") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="TIN" SortExpression="strTIN">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrTIN" runat="server" Text='<%# Bind("strTIN") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="VAT Reg No" SortExpression="strVATRegNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrVATRegNo" runat="server" Text='<%# Bind("strVATRegNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Trade Lisence No" SortExpression="strTradeLisenceNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrTradeLisenceNo" runat="server" Text='<%# Bind("strTradeLisenceNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name" SortExpression="strReprName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtstrReprName" runat="server" Text='<%# Bind("strReprName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblstrReprName" runat="server" Text='<%# Bind("strReprName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact No" SortExpression="strReprContactNo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtstrReprContactNo" runat="server" Text='<%# Bind("strReprContactNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblstrReprContactNo" runat="server" Text='<%# Bind("strReprContactNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pay To Name" SortExpression="strPayToName">
                                <ItemTemplate>
                                    <asp:Label ID="lblstrPayToName" runat="server" Text='<%# Bind("strPayToName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="true" >
                            <ControlStyle ForeColor="#0033CC" />
                            <ItemStyle ForeColor="#0033CC" />
                            </asp:CommandField>
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
                </tr>
            </table>
        </div>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
