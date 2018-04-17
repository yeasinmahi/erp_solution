<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAandDADocPathList.aspx.cs" Inherits="UI.SAD.Order.TAandDADocPathList" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 
<%--=========================================Start My Code From Here===============================================--%>
              
        
        <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Document List :<asp:HiddenField ID="hdnSeprationID" runat="server" /></td></tr>

            <tr><td colspan="4">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
             
           

            <asp:BoundField DataField="strPathurl" HeaderText="File Path" ItemStyle-HorizontalAlign="Center" SortExpression="strPathurl">
            <ItemStyle HorizontalAlign="left" Width="300px"/></asp:BoundField>

          
            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnDocDownload" class="button" runat="server" Font-Size="9px" OnClick="btnDocDownload_Click"
            CommandArgument='<%# Eval("strPathurl") %>' Text="Download Document" /></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>

                </td></tr>
          

        </table>       
    </div>
    
   <%--=========================================End My Code From Here=================================================--%>

    </form>
</body>
</html>