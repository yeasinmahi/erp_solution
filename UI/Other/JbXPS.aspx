<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="HR.Other.JbXPS" EnableEventValidation="false" Codebehind="JbXPS.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table>
                        <tr>
                            <td colspan="2" align="center" class="PageHeader">
                                Janata Bank Statement XPS File Uploader
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="fulJBXPS" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnParse" runat="server" Text="Parse" OnClick="btnParse_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" Visible="false" runat="server" Text="Update" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <asp:Label ID="lblStat" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server" SkinID="sknGrid1" Caption="Statement"
                DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" OnDataBound="GridView1_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Date" SortExpression="dteDate">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="strParti" HeaderText="Particulars" SortExpression="strParti" />
                    <asp:BoundField DataField="strChq" HeaderText="Cheque No" SortExpression="strChq" />
                    <asp:BoundField DataField="numDrAmount" HeaderText="Dr Amount" SortExpression="numDrAmount" />
                    <asp:BoundField DataField="numCrAmount" HeaderText="Cr Amount" SortExpression="numCrAmount" />
                    <asp:BoundField DataField="numBal" HeaderText="Balance" SortExpression="numBal" />
                    <asp:BoundField DataField="strAccNo" HeaderText="Account No" SortExpression="strAccNo" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataForJanataBank"
                TypeName="XPSParser.ParseXPS" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdnPath" Name="filePath" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hdnPath" runat="server" />
            
        </ContentTemplate>
        <Triggers >
        <asp:PostBackTrigger ControlID="btnParse" />
        <asp:PostBackTrigger ControlID="btnSubmit" />
        <%--<asp:PostBackTrigger ControlID="fulJBXPS" />--%>
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
