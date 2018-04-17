<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployeeCreateByMeal.aspx.cs" Inherits="UI.Factory.NewEmployeeCreateByMeal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <td style="text-align:center" colspan="2" class="auto-style2"><h3> Employee Setup By Meal /T,P</h3>
                        </td>
                     
                </tr>
                <tr> <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="">Employee Enroll :</asp:Label> </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtenroll" CssClass="txtBox" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                  <tr> <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="">Company Contribute :</asp:Label> </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtDiscount" onKeyUp="javascript:Add();" CssClass="txtBox" runat="server"></asp:TextBox>
                      </td>
                    
                </tr>
          <tr> <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="">Employee Contribute :</asp:Label> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtEmployeeContirbute" onKeyUp="javascript:Add();" CssClass="txtBox" runat="server"></asp:TextBox>
              </td>
                    
                </tr>
       <tr> <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="">Total :</asp:Label> </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txttotal" CssClass="txtBox" runat="server"></asp:TextBox>
                       
                    
                </tr>
         <tr> <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="">Employee Status :</asp:Label> </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList1" CssClass="txtBox" runat="server">
                            <asp:ListItem Value="P">Permanent </asp:ListItem>
                            <asp:ListItem Value="T">Temporary</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnShow_Click" />   </td>
                    
                </tr>
          <tr> <td class="auto-style2">
                    &nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="Button2" runat="server" Text="Permanent/Temporary Change" OnClick="btnUpdate_Click" />   </td>
                    
                </tr>
     </table>
            </center>
    </div>
    </form>
</body>
</html>
