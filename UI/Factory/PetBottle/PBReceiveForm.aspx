<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PBReceiveForm.aspx.cs" Inherits="UI.Factory.PetBottle.PBReceiveForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pet Bottle Receive</title>
    <link href="../../Content/CSS/PropertyStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmPBReceive" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" class="top-nav">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2 div-controll">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hfConfirm" runat="server" />
                <div class="div-body" style="padding-right: 10px;">
                    <div class="div-container div-header">
                        Pet Bottle Receive
                        <hr />
                    </div>
                    <div style="width: 50%">
                        <div class="">
                            <table class="table">
                                <tr>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label1" runat="server" CssClass="lbl-txt" Text="PO No :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:DropDownList runat="server" ID="ddlPONumber" CssClass="ddl-field" 
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlPONumber_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:HiddenField runat="server" ID="hfSupplierID" />
                                    </td>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label2" CssClass="lbl-txt" runat="server" Text="Party Name :"></asp:Label></td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtPartyName" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label3" runat="server" CssClass="lbl-txt" Text="Item :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:DropDownList runat="server" ID="ddlPBItem" CssClass="ddl-field" 
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlPBItem_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label4" CssClass="lbl-txt" runat="server" Text="Challan Date :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtChallanDate" runat="server" CssClass="txt-field"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtChallanDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label5" CssClass="lbl-txt" runat="server" Text="Challan No :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtChallanNo" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label6" CssClass="lbl-txt" runat="server" Text="PO Quantity :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtPOQuantity" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label7" CssClass="lbl-txt" runat="server" Text="Pre Receive Qty :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtpreReceiveQty" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label8" CssClass="lbl-txt" runat="server" Text="Receive Qty :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtReceiveQty" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label9" CssClass="lbl-txt" runat="server" Text="Challan Qty :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl">
                                        <asp:TextBox ID="txtChallanQty" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-lbl">
                                        <asp:Label ID="Label10" CssClass="lbl-txt" runat="server" Text="Remarks :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl" colspan="3">
                                        <asp:TextBox ID="txtPBReceiveRemarks" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:Button runat="server" style="float:right" ID="btnPBReceiveAdd" CssClass="btnn" Text="ADD" OnClick="btnPBReceiveAdd_Click" />
                                        <asp:Button runat="server" style="float:right" ID="btnPBReceiveSubmit" CssClass="btnn" Text="Submit" OnClick="btnPBReceiveSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-top: 2px">
                            <asp:GridView ID="gvPBReceive" runat="server" AutoGenerateColumns="False" Width="80%"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="5" Font-Size="12px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPlotType" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPOQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numPOQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Challan Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numChallanQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receive Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceiveQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numReceiveQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numRate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnPBDelete" runat="server" OnClick="btnPBDelete_Click" Text="Delete"></asp:Button>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
