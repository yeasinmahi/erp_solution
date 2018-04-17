<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovedDetails.aspx.cs" Inherits="UI.SAD.Corporate_sales.ApprovedDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>

    <asp:GridView ID="dgvOrder" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" OnSelectedIndexChanged="dgvtrgt_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#CCCCCC" />
                       <Columns>
                            <asp:TemplateField HeaderText="strUnit" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("strUnit") %>' /><asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("strUnit") %>' />
                                 <asp:Label ID="itemid" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField> 

                              <asp:TemplateField HeaderText="OrderNo " SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="intOrderNo" runat="server" Value='<%# Eval("intOrderNo") %>' /><asp:HiddenField ID="iname2" runat="server" Value='<%# Eval("intOrderNo") %>' />
        <asp:Label ID="lblintOrderNo" runat="server" Text='<%# Bind("intOrderNo") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                
                            <asp:TemplateField HeaderText="Cust Name " SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="itemname" runat="server" Value='<%# Eval("strName") %>' /><asp:HiddenField ID="iname5" runat="server" Value='<%# Eval("strName") %>' />
        <asp:Label ID="lblitem" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>  
                            
                            <asp:TemplateField HeaderText="Cust id " SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="intCusID" runat="server" Value='<%# Eval("custid") %>' /><asp:HiddenField ID="iname6" runat="server" Value='<%# Eval("custid") %>' />
        <asp:Label ID="lblintCusID" runat="server" Text='<%# Bind("custid") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>                                           

       
        <asp:TemplateField HeaderText="Ship Point Name" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="shipointname" runat="server" Value='<%# Eval("shippingName") %>' /><asp:HiddenField ID="shipointid1" runat="server" Value='<%# Eval("shippingName") %>' />
        <asp:Label ID="lblshipointname" runat="server" Text='<%# Bind("shippingName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                                                     

                           
                            <asp:TemplateField HeaderText="Product id" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="intShipPointId" runat="server" Value='<%# Eval("intProductid") %>' /><asp:HiddenField ID="intProductid125" runat="server" Value='<%# Eval("intProductid") %>' />
        <asp:Label ID="lblintProductid" runat="server" Text='<%# Bind("intProductid") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                            <asp:TemplateField HeaderText="intShipPointId" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="intShipPointIdss" runat="server" Value='<%# Eval("intShipPointId") %>' /><asp:HiddenField ID="intShipPointIdss1" runat="server" Value='<%# Eval("intShipPointId") %>' />
        <asp:Label ID="lblintShipPointIdsss" runat="server" Text='<%# Bind("intShipPointId") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                           
         
                            <asp:TemplateField HeaderText="strProductName" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="strProductName" runat="server" Value='<%# Eval("strProductName") %>' /><asp:HiddenField ID="strProductName1" runat="server" Value='<%# Eval("strProductName") %>' />
        <asp:Label ID="lblstrProductName" runat="server" Text='<%# Bind("strProductName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                            
            
                     
                                                          
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
        <ItemTemplate>
         <asp:HiddenField  ID="rate" runat="server" Value='<%# Bind("monPrice", "{0:0.0000}") %>'></asp:HiddenField>
        <asp:TextBox ID="Quantity1" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("numQuantity") %>' AutoPostBack="false" ></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" />
        </asp:TemplateField>
  
                         

                         <asp:TemplateField HeaderText="TotalAmount" SortExpression="Pending">
                         <ItemTemplate><asp:Label ID="lblTotalAmount" runat="server" Text='<%# (""+Eval("TotalAmount","{0:n0}")) %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="90px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# TotalAmount %>' /></FooterTemplate>
                         </asp:TemplateField>
          
                                   <asp:TemplateField HeaderText="dteDate" SortExpression="itemname"><ItemTemplate>
        <asp:HiddenField ID="dteDate" runat="server" Value='<%# Eval("dteDate") %>' /><asp:HiddenField ID="dteDate1" runat="server" Value='<%# Eval("dteDate") %>' />
        <asp:Label ID="lbldteDate" runat="server" Text='<%# Bind("dteDate") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                            
                       </Columns>
                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>

<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"></asp:Button>

            </center>

       

    </div>
    </form>
</body>
</html>
