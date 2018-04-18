<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdjustment.aspx.cs" Inherits="UI.Wastage.frmAdjustment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table class="tbldecoration" style="width:auto; float:left;">
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlUnitName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false" ></asp:DropDownList></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlWHName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
         </tr>
         <tr>               
            <td style="text-align:right;"><asp:Label ID="lblSODate" runat="server" CssClass="lbl" Text="Sales Order Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
            <td><asp:TextBox ID="txtSODate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
             </td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td> 
            <td style="text-align:right;">&nbsp;</td>
            <td style="text-align:left;">
                &nbsp;</td>
          </tr>
         <tr><td colspan="5"><hr /></td></tr> 
         <tr>
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Item Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlItem" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="True" ></asp:DropDownList></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Quantity" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox1" AutoPostBack="true"  onKeyUp="javascript:Add();" ></asp:TextBox></td>                 
         </tr>
         <tr>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="UOM :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
            <td style="text-align:right; width:15px;"><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Rate" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox1" Enabled="false" onkeypress="return onlyNumbers();"></asp:TextBox></td>                
         </tr>
         <tr>
            <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="30px"></asp:TextBox></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Value :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtValue" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
          </tr>
          <tr>
            <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px">&nbsp&nbsp <asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submnit" OnClick="btnSubmit_Click" /> </td>        
          </tr>
    </table>
        </div>
    </form>
</body>
</html>
