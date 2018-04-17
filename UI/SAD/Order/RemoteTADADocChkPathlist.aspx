<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADADocChkPathlist.aspx.cs" Inherits="UI.SAD.Order.RemoteTADADocChkPathlist" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<%--=========================================Start My Code From Here===============================================--%>
              
        
        <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Attachement List :<asp:HiddenField ID="hdnSeprationID" runat="server" /></td></tr>

            <tr><td colspan="4">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
            BorderWidth="1px" CellPadding="4" GridLines="Vertical" ForeColor="Black">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
             
           

     
                <asp:BoundField DataField="strPathurl" HeaderText="FILE  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="strBillAttachmentType" HeaderText="Type" SortExpression="strBillAttachmentType" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                       
                    <asp:BoundField DataField="dteBilldate" HeaderText="Bill Date" SortExpression="dteBilldate" DataFormatString="{0:MMMM d, yyyy}" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>

                    <asp:BoundField DataField="strEmployeeName" HeaderText="Name" SortExpression="strEmployeeName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
          
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnDocDownload" class="button" runat="server" Font-Size="9px" OnClick="btnDocDownload_Click"
                    CommandArgument='<%# Eval("strPathurl") %>' Text="Download" /></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

                    </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>


          

        </table>       
    </div>
    
   <%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>