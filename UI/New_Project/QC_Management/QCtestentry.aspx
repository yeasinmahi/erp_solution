<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QCtestentry.aspx.cs" Inherits="UI.QC_Management.QCtestentry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }



    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="dgvtrgt" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" OnSelectedIndexChanged="dgvtrgt_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
         <asp:TemplateField HeaderText="intid" SortExpression="intItemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("intItemid") %>' /><asp:HiddenField ID="intid" runat="server" Value='<%# Eval("intItemid") %>' />
         <asp:Label ID="intidlbl" runat="server" Text='<%# Bind("intItemid") %>'></asp:Label>
          
             </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField> 

       
        <asp:TemplateField HeaderText="strItemName" SortExpression="strattributename"><ItemTemplate>
        <asp:HiddenField ID="strItemName" runat="server" Value='<%# Eval("strItemName") %>' /><asp:HiddenField ID="iname" runat="server" Value='<%# Eval("strItemName") %>' />
        <asp:Label ID="lblstrItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                                                     
        <asp:TemplateField HeaderText="strattributename" SortExpression="strattributename"><ItemTemplate>
        <asp:HiddenField ID="strattributename" runat="server" Value='<%# Eval("strattributename") %>' /><asp:HiddenField ID="inames" runat="server" Value='<%# Eval("strattributename") %>' />
        <asp:Label ID="lblstrattributename" runat="server" Text='<%# Bind("strattributename") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
          
                             
                
                  <asp:TemplateField HeaderText="strAttributesResult" SortExpression="strAttributesResult"><ItemTemplate>
        <asp:HiddenField ID="strAttributesResult" runat="server" Value='<%# Eval("strAttributesResult") %>' /><asp:HiddenField ID="isname" runat="server" Value='<%# Eval("strAttributesResult") %>' />
        <asp:Label ID="lblstrAttributesResulte" runat="server" Text='<%# Bind("strAttributesResult") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
          
        <asp:TemplateField HeaderText="File Name" SortExpression="intItemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField10154" runat="server" Value='<%# Eval("strPathfile") %>' /><asp:HiddenField ID="intidsssssss" runat="server" Value='<%# Eval("strPathfile") %>' />
         <asp:Label ID="intidlbl0sdf5" runat="server" Text='<%# Bind("strPathfile") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>                  
                            
                           
                                        
          <asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="Download" CommandName="complete"  Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("strPathfile") %>' OnClick="Complete_Click" />
              </ItemTemplate>
            </asp:TemplateField>
                         
          
                          
                       </Columns>
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>

    </div>
    </form>
</body>
</html>
