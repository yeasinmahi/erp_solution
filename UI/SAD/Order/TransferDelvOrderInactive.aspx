<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferDelvOrderInactive.aspx.cs" Inherits="UI.SAD.Order.TransferDelvOrderInactive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   <%--<script src="../../../../Content/JS/datepickr.min.js"></script>--%>

     <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

    <script>
       
         function isNumber(evt) {
             var iKeyCode = (evt.which) ? evt.which : evt.keyCode
             if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                 return false;

             return true;
         }
        </script>
</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   

<%--=========================================Start My Code From Here===============================================--%>
  <div class="leaveApplication_container"> 
                   
    <div class="tabs_container"> 
        <caption>
          Transfer Order Inactive :<asp:HiddenField ID="hdnenroll" runat="server" />
            <asp:HiddenField ID="hdnstation" runat="server" />
            <asp:HiddenField ID="hdnsearch" runat="server" />
            
            <asp:HiddenField ID="hdnDepartment" runat="server" />
            <hr />
        </caption>
          </div>
        <table border="0"; style="width:Auto"; >    


        
         <tr class="tblrowOdd">
                        <td style="text-align:right;">
                     <asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label>

                 </td>
                <td>
                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="true" DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound">
                </asp:DropDownList>
               
                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                        <SelectParameters>
                            <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
               
                </td>
              </tr>
           <tr class="tblrowodd">
                 <td><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" BackColor="#ffff99"  Text="Shipping Point"></asp:Label></td> 
                    <td>
                    <asp:DropDownList ID="ddlShip" runat="server"  DataSourceID="odsShippingPointlist" DataTextField="strName" DataValueField="intShipPointId">
                    </asp:DropDownList>
                                           
                   
                                           
                        <asp:ObjectDataSource ID="odsShippingPointlist" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint">
                            <SelectParameters>
                                <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                                           
                   
                                           
                    </td>
            </tr>
            
            <tr class="tblroweven"><td style="text-align:right"><asp:Label ID="lblDONumber" CssClass="lbl" runat="server" Text="Transfer D.O Number:  "></asp:Label></td>
                               <td><asp:TextBox ID="txtdonumber" runat="server" placeholder="Fill by digit"  CssClass="txtBox"></asp:TextBox></td>
         </tr>
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/></td>
              
            </tr>
            </table>
            </div>
        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    <%--strDonumbr ,dtedate ,strcustname ,strsalsoff ,strunit ,straddr ,decDOQnt ,deRestqnt--%>
                <asp:GridView ID="grdvDelvOrderInactive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#CC9966" BorderStyle="None"  
                BorderWidth="1px" CellPadding="4" ShowFooter="True" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvDelvOrderInactive_RowDataBound" >
                <Columns>
                <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="strDonumbr" HeaderText="Donumber" SortExpression="strDonumbr" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="dtedate" HeaderText="dtedate" SortExpression="dtedate" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100">
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="strcustname" HeaderText="customer Name" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="strsalsoff" HeaderText="salesoffice" SortExpression="strsalsoff" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="straddr" HeaderText="Address" SortExpression="straddr" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100">
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="decDOQnt" HeaderText="D.O Qnt" SortExpression="decDOQnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField DataField="deRestqnt" HeaderText="Rest qnt" SortExpression="deRestqnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                 <asp:BoundField DataField="strdostas" HeaderText="D.O Status" SortExpression="strdostas" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:BoundField>
                <asp:TemplateField HeaderText="Inactive">
                    <ItemTemplate>
                     <asp:Button ID="btnInactiveDO" runat="server" Text="Inactive" class="button" CommandName="complete" OnClick="btnInactiveDO_Click" CommandArgument='<%# Eval("strDonumbr")%>' /></ItemTemplate>
                   </asp:TemplateField> 
                     </Columns>

<FooterStyle HorizontalAlign="Right" BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView></td></tr>
            </table>


        </div>
         <%--=========================================End My Code From Here=================================================--%>
  
    </form>
</body>
</html>