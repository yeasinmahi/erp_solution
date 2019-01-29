<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MrrCorrection.aspx.cs" Inherits="UI.SCM.MrrCorrection" %>

<html>
<head runat="server"><title></title>   
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/Jquery") %></asp:PlaceHolder>
<webopt:bundlereference ID="BundleReference0" runat="server" Path="~/Content/Bundle/DefaultCss" />
</head>
<body>
    <form id="frmattendance" runat="server"> 
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <%--=========== Start Code =====================================================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnWHID" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnMrrUnitID" runat="server" />

    <div class="leaveApplication_container">
    <table class="tbldecoration" style="width:auto; float:left;">
        
        <tr class="tblheader"><td class="tdheader" colspan="4"> MRR CORRECTION :</td></tr>        
        <tr class="tblheader"><td style=" height:2px; background-color:#c1bdbd;" colspan="4"> </td></tr>
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
        <tr>        
            <td class="tdheight" style="text-align:right;"><asp:Label ID="lbltotalmanpower" CssClass="lbl" runat="server" Text="MRR No. : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtMRRNo" runat="server" CssClass="txtBox" ></asp:TextBox></td>        

            <td class="tdheight" colspan="4" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Width="130px" OnClick="btnShow_Click"/></td>      
        </tr> 
        <tr> 
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="WH Name : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtWHName" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke" ></asp:TextBox></td>
                   
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Supplier Name : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtSupplierName" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke" ></asp:TextBox></td>                           
        </tr>       
        <tr>        
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="MRR Date : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtMRRDate" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke" ></asp:TextBox></td>            

            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="PO : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtPO" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke" ></asp:TextBox></td>            
        </tr>
        <tr> 
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Voucher No. : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtVoucherNo" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>        
                   
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Status : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="txtPaymentStatus" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>     
        </tr>
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
        <tr class="tblrowodd"><td colspan="4">
        <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL." ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>                
        <asp:BoundField DataField="ItemName" HeaderText="Item Name" ItemStyle-HorizontalAlign="Center" SortExpression="strItemName" HeaderStyle-HorizontalAlign="Center">
        <ItemStyle HorizontalAlign="Left" Width="350px"/></asp:BoundField>
        <asp:BoundField DataField="strUoM" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" SortExpression="strUOM">
        <ItemStyle HorizontalAlign="Left" Width="80px"/><HeaderStyle HorizontalAlign="Center" /></asp:BoundField>
        <asp:BoundField DataField="POQty" HeaderText="PO Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="POQty" HeaderStyle-HorizontalAlign="Center">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
        <asp:BoundField DataField="POValue" HeaderText="PO Value" ItemStyle-HorizontalAlign="Center" SortExpression="POValue">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>        
        </Columns>
        <FooterStyle BackColor="#CCCCCC" /><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /><SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" /> <SortedAscendingHeaderStyle BackColor="#808080" /><SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </td></tr>
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
        <tr class="tblheader"><td style=" height:2px; background-color:#c1bdbd;" colspan="4"> </td></tr>
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
        <%--<tr>        
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Challan No. : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" ></asp:TextBox></td>        

            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Challan Date : "></asp:Label></td>
            <td><asp:TextBox ID="txtCDate" runat="server" CssClass="txtBox"></asp:TextBox>
            <script type="text/javascript"> new datepickr('txtCDate', { 'dateFormat': 'Y-m-d' });</script></td>
        </tr>
        <tr>        
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="VAT Challan No. : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox" ></asp:TextBox></td>        

            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="VAT Challan Date : "></asp:Label></td>
            <td><asp:TextBox ID="txtVATCDate" runat="server" CssClass="txtBox"></asp:TextBox>
            <script type="text/javascript"> new datepickr('txtVATCDate', { 'dateFormat': 'Y-m-d' });</script></td>
        </tr>
        <tr>        
            <td class="tdheight" style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="VAT Amount : "></asp:Label></td>
            <td class="tdheight"><asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>        
            
            <td colspan="4" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="btnChange" runat="server" class="myButton" Text="Change" Width="130px"/></td>
        </tr> 
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
        <tr class="tblheader"><td style=" height:2px; background-color:#c1bdbd;" colspan="4"> </td></tr>
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>--%>
        <tr>
            <td colspan="1" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="btnDeleteJV" runat="server" class="myButton" Text="Delete JV" OnClientClick = "ConfirmAll()" OnClick="btnDeleteJV_Click"/></td>            
            <td colspan="2" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="btnFreeMRR" runat="server" class="myButton" Text="Free MRR" OnClientClick = "ConfirmAll()" OnClick="btnFreeMRR_Click" /></td>
            <td colspan="1" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="btnDeleteMRR" runat="server" class="myButton" Text="Delete MRR" Width="130px" OnClientClick = "ConfirmAll()" OnClick="btnDeleteMRR_Click"/></td>
        </tr>
        <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
    </table>
    </div>

<%--=========== End Code =====================================================================--%>
     
    </form>
</body>
</html>
