<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocPathList.aspx.cs" Inherits="UI.HR.Settlement.DocPathList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<%--=========================================Start My Code From Here===============================================--%>
        
        <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Document List :<asp:HiddenField ID="hdnSeprationID" runat="server" /></td></tr>

            <tr><td colspan="4">
            <asp:GridView ID="dgvDocPath" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
             
            <asp:BoundField DataField="intEnroll" HeaderText="Enroll" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="intEnroll">
            <ItemStyle HorizontalAlign="Center" Width="300px"/></asp:BoundField>

            <asp:BoundField DataField="strFilePath" HeaderText="File Path" ItemStyle-HorizontalAlign="Center" SortExpression="strFilePath">
            <ItemStyle HorizontalAlign="left" Width="300px"/></asp:BoundField>

            <asp:BoundField DataField="intSeparationID" HeaderText="intSeparationID" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="intSeparationID">
            <ItemStyle HorizontalAlign="Center" Width="300px"/></asp:BoundField>

            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnDocDownload" class="button" runat="server" Font-Size="9px" OnClick="btnDocDownload_Click"
            CommandArgument='<%# Eval("strFilePath") %>' Text="Download Document" /></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>

        </table>       
    </div>
    
   <%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>