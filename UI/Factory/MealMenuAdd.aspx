<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealMenuAdd.aspx.cs" Inherits="UI.Factory.MealMenuAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
    </style>
    <script>
        function Add() {
            var a, b;
            a = parseFloat(document.getElementById("txtDiscount").value);

            //
            // If textbox value is null i.e empty, then the below mentioned if condition will 
            // come into picture and make the value to '0' to avoid errors.
            //

            if (isNaN(a) == true) {
                a = 0;
            }
            var b = parseFloat(document.getElementById("txtEmployeeContirbute").value);
            if (isNaN(b) == true) {
                b = 0;
            }
            //var c = parseFloat(document.getElementById("txtLabourExp").value);
            //if (isNaN(c) == true) {
            //    c = 0;
            //}
            //var d = parseFloat(document.getElementById("txtPolice").value);
            //if (isNaN(d) == true) {
            //    d = 0;
            //}
            document.getElementById("txttotal").value = a + b;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
    <table class="">
                <tr>
                    <td style="text-align:center" colspan="2" class="auto-style2"><h3>Meal Menu Add</h3>
                        </td>
                     
                </tr>
                <tr> <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="">Day Name :</asp:Label> </td>
                    <td class="auto-style10">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                            <asp:ListItem>Saturday</asp:ListItem>
                            <asp:ListItem>Sunday</asp:ListItem>
                            <asp:ListItem>Monday</asp:ListItem>
                            <asp:ListItem>Tuesday</asp:ListItem>
                            <asp:ListItem>Wednesday</asp:ListItem>
                            <asp:ListItem>Thursday</asp:ListItem>
                        </asp:DropDownList>
<asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click"></asp:Button>
                    </td>
                    
                </tr>
                  <tr> <td colspan="2" class="auto-style2">


                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowSorting="True" ForeColor="Black">
             <Columns>
                 <asp:TemplateField HeaderText="Sl."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Id">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("intid") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Day name">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Eval("strdayname") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Menu">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                      </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("strMenu") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <%--<asp:TemplateField HeaderText="PO Number">--%>
                     <%--<ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("intRTGetInPO") %>'></asp:Label>
                     </ItemTemplate>--%>
                <%-- </asp:TemplateField>--%>
               
               
                
                 <asp:CommandField HeaderText="Update" ShowEditButton="True" />
             </Columns>
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
             <RowStyle BackColor="White" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
             </asp:GridView>


         <td colspan="5">&nbsp;</td>

</td>
                    
                    
                </tr>
         
     </table>
            </center>
    </div>
    </form>
</body>
</html>