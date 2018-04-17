<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesDamageEntry.aspx.cs" Inherits="UI.Inventory.SalesDamageEntry"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
   <script type="text/javascript">
        $("[id*=chkHeader]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });

        </script>

        <script type="text/javascript">
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
           var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
               if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
               else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
           }
       
</script>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="frmshvssls" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
<%--=========================================Start My Code From Here===============================================--%>
         <div>
        <table><tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblappointment" CssClass="lbl" runat="server" Text="From-Date : "> </asp:Label></td>
               
            <td style="text-align:right;">
                  <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:TextBox ID="txtFDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="FD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate">
                    </cc1:CalendarExtender> 
                </td>
             

            <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
                
            <td>
                <asp:TextBox ID="txtTo" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="TD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo">
                    </cc1:CalendarExtender> 
                </td>
             

               </tr>
        <tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "> </asp:Label>
                   

                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" CssClass="ddList" DataSourceID="odsUnitNameByEnrol" AutoPostBack="true" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
                            
            </td>
            <td>
                <asp:Label ID="lblch" runat="server" Text="Challan No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtchallan" runat="server"></asp:TextBox>
            </td>
             
        </tr>
        
            <tr>
                <td style="text-align:right"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text=" Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="drdlreportype" runat="server">
                                    <asp:ListItem Text="Damage input " Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Damage submit " Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Damage report " Value="3"></asp:ListItem>
                                       <asp:ListItem Text="Damage D.O Create report " Value="4"></asp:ListItem>
                                  <asp:ListItem Text="Damage D.O Create Submit " Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
               


                 <td style="text-align:right"><asp:Label ID="lblReason" CssClass="lbl" runat="server" Text=" Reason:  "></asp:Label></td>
                                <td><asp:DropDownList ID="drdlReason" runat="server" DataSourceID="odsUnitvsDamageinf" DataTextField="strDamageType" DataValueField="intID">
                                   
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsUnitvsDamageinf" runat="server" SelectMethod="DamageCatg" TypeName="SAD_BLL.Sales.SalesView">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="drdlUnitName" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
            </tr>
            <tr>
                <td style="text-align:right"><asp:Label ID="lblAdjustamount" CssClass="lbl" runat="server" Text=" Adjust Amount Percentage:  "></asp:Label></td>
                                <td><asp:TextBox ID="txtAdjustPercentage" runat="server" CssClass="txtbox" BackColor="#ffff66"></asp:TextBox>
                                </td>
            </tr>
            <tr>
            <td>
                <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click"/>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClick="btnSubmit_Click"  OnClientClick="Confirm()"  />
            </td>
            
        </tr>
        </table>

      



            
      
    <table class="tbldecoration" style="width:auto; float:left; "> 
    <tr><td><asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
    CellPadding="1" GridLines="Vertical" BorderColor="#999999" ForeColor="Black"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
   <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="chkHeader" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                        <asp:HiddenField ID="hdnchallan" runat="server" Value='<%# Eval("strchal") %>' />
                    <asp:HiddenField ID="hdncustid" runat="server" Value='<%# Eval("custid") %>' />
                     <asp:HiddenField ID="hdntransactiondate" runat="server" Value='<%# Eval("chaldate") %>' />
                     <asp:HiddenField ID="hdnproductid" runat="server" Value='<%# Eval("productid") %>' />
                      <asp:HiddenField ID="hdnProductRate" runat="server" Value='<%# Eval("chalanprice") %>' />
                         
                    </ItemTemplate></asp:TemplateField>

        
    
    <asp:BoundField DataField="strcustname" HeaderText="CustomerName" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerName">
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:BoundField>
    <asp:BoundField DataField="strchal" HeaderText="ChallanNo" ItemStyle-HorizontalAlign="Center" SortExpression="ChallanNo">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField> 
     <asp:BoundField DataField="productid" HeaderText="productid" ItemStyle-HorizontalAlign="Center" SortExpression="Region">
    <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
    <asp:BoundField DataField="prdctname" HeaderText="prdctname" ItemStyle-HorizontalAlign="Center" SortExpression="Area">
    <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
    <asp:BoundField DataField="chaqnt" HeaderText="chaqnt" ItemStyle-HorizontalAlign="Center" SortExpression="Teritory">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
    <asp:BoundField DataField="chalanprice" HeaderText="chalanprice" ItemStyle-HorizontalAlign="Center" SortExpression="Point">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>   
    <asp:TemplateField HeaderText="ChallanDate" SortExpression="ChallanDate" >
    <ItemTemplate><asp:Label ID="lbcdate" runat="server"  Text='<%# Eval("chaldate", "{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField>

        <asp:TemplateField  HeaderText="Damage Qnt"><ItemTemplate><asp:TextBox ID="txtDamageQnt" runat="server" 
    Width="50px" Text='<%# Bind("decinputqnt") %>'></asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Left"/></asp:TemplateField> 
  


 
    </Columns><HeaderStyle CssClass="GridviewScrollHeader"/><PagerStyle CssClass="GridviewScrollPager"/></asp:GridView>
    </td></tr>
    
    <tr><td><asp:GridView ID="dgvDamageReport" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="LightGoldenrodYellow" 
    CellPadding="2" GridLines="None" BorderColor="Tan" ForeColor="Black" BorderWidth="1px" CssClass="auto-style1">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    <Columns>

      
         <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="strcustname" HeaderText="CustomerName" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerName">
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:BoundField>
    <asp:BoundField DataField="strchal" HeaderText="ChallanNo" ItemStyle-HorizontalAlign="Center" SortExpression="ChallanNo">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField> 
     <asp:BoundField DataField="productid" HeaderText="productid" ItemStyle-HorizontalAlign="Center" SortExpression="Region">
    <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
    <asp:BoundField DataField="prdctname" HeaderText="prdctname" ItemStyle-HorizontalAlign="Center" SortExpression="Area">
    <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
    <asp:BoundField DataField="decinputqnt" HeaderText="Damage Qnt" ItemStyle-HorizontalAlign="Center" SortExpression="Teritory">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
    <asp:BoundField DataField="damagevalue" HeaderText="Damage Amount" ItemStyle-HorizontalAlign="Center" SortExpression="Point">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>   
    <asp:TemplateField HeaderText="Insertion" SortExpression="Insert Date" >
    <ItemTemplate><asp:Label ID="lbcdate" runat="server"  Text='<%# Eval("insertdate", "{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField>

  


 
    </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle CssClass="GridviewScrollHeader" BackColor="Tan" Font-Bold="True"/><PagerStyle CssClass="GridviewScrollPager" BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center"/>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
    </td></tr>
    
     <tr><td><asp:GridView ID="grdvDamageInputinfo" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" 
    CellPadding="3" GridLines="Vertical" BorderColor="#999999" BorderWidth="1px" CssClass="auto-style1" BorderStyle="None">
        <AlternatingRowStyle BackColor="#DCDCDC" />
    <Columns>

      
         <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %>
            <%-- PId,  PName,  Qnt,  ApprovedQnt,  Pr,  AccId
,  AccName,  ExtId,  ExtName,  ExtPr,  Uom,  UomTxt
,  Currency,  Narration,  SalesType,  LogisicId
,  Promotion,  Commission,  IncentiveId,  Incentive
,  SuppTax,  Vat,  VatPr,  PromItemId,  PromItem
,  PromUom,  PromUomText,  PromPrice,  PromItemCOAid,intcustid ,strcustname,strchallan,dtedamageinputdate,decdamagevalue--%>


            <asp:HiddenField ID="hdnPId" runat="server" Value='<%# Eval("PId") %>' />
             <asp:HiddenField ID="HiddenPName" runat="server" Value='<%# Eval("PName") %>' />
            <asp:HiddenField ID="hdnQnt" runat="server" Value='<%# Eval("Qnt") %>' />
            <asp:HiddenField ID="hdnApprovedQnt" runat="server" Value='<%# Eval("ApprovedQnt") %>' />
            <asp:HiddenField ID="hdnPr" runat="server" Value='<%# Eval("Pr") %>' />

              <asp:HiddenField ID="HiddenAccId" runat="server" Value='<%# Eval("AccId") %>' />
             <asp:HiddenField ID="HiddeAccName" runat="server" Value='<%# Eval("AccName") %>' />
            <asp:HiddenField ID="HiddenExtId" runat="server" Value='<%# Eval("ExtId") %>' />
            <asp:HiddenField ID="HiddenExtName" runat="server" Value='<%# Eval("ExtName") %>' />
            <asp:HiddenField ID="HiddenExtPr" runat="server" Value='<%# Eval("ExtPr") %>' />

               <asp:HiddenField ID="HiddenUom" runat="server" Value='<%# Eval("Uom") %>' />
           <asp:HiddenField ID="HiddenUomTxt" runat="server" Value='<%# Eval("UomTxt") %>' />
            <asp:HiddenField ID="HiddenCurrency" runat="server" Value='<%# Eval("Currency") %>' />
            <asp:HiddenField ID="HiddenNarration" runat="server" Value='<%# Eval("Narration") %>' />
            <asp:HiddenField ID="HiddenSalesType" runat="server" Value='<%# Eval("SalesType") %>' />


                 <asp:HiddenField ID="HiddenLogisicId" runat="server" Value='<%# Eval("LogisicId") %>' />
           <asp:HiddenField ID="HiddenPromotion" runat="server" Value='<%# Eval("Promotion") %>' />
            <asp:HiddenField ID="HiddenCommission" runat="server" Value='<%# Eval("Commission") %>' />
            <asp:HiddenField ID="HiddenIncentiveId" runat="server" Value='<%# Eval("IncentiveId") %>' />
            <asp:HiddenField ID="HiddenIncentive" runat="server" Value='<%# Eval("Incentive") %>' />


                <asp:HiddenField ID="HiddenSuppTax" runat="server" Value='<%# Eval("SuppTax") %>' />
           <asp:HiddenField ID="HiddenVat" runat="server" Value='<%# Eval("Vat") %>' />
            <asp:HiddenField ID="HiddenVatPr" runat="server" Value='<%# Eval("VatPr") %>' />
            <asp:HiddenField ID="HiddenPromItemId" runat="server" Value='<%# Eval("PromItemId") %>' />
            <asp:HiddenField ID="HiddenPromItem" runat="server" Value='<%# Eval("PromItem") %>' />

             <asp:HiddenField ID="HiddenPromUom" runat="server" Value='<%# Eval("PromUom") %>' />
           <asp:HiddenField ID="HiddenPromUomText" runat="server" Value='<%# Eval("PromUomText") %>' />
            <asp:HiddenField ID="HiddenPromPrice" runat="server" Value='<%# Eval("PromPrice") %>' />
            <asp:HiddenField ID="HiddenPromItemCOAid" runat="server" Value='<%# Eval("PromItemCOAid") %>' />
            <asp:HiddenField ID="Hiddenintcustid" runat="server" Value='<%# Eval("intcustid") %>' />



          </ItemTemplate>

              
         </asp:TemplateField>
        <asp:BoundField DataField="strcustname" HeaderText="CustomerName" ItemStyle-HorizontalAlign="Center" SortExpression="CustomerName">
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:BoundField>
    <asp:BoundField DataField="strchallan" HeaderText="ChallanNo" ItemStyle-HorizontalAlign="Center" SortExpression="ChallanNo">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField> 
     <asp:BoundField DataField="PId" HeaderText="productid" ItemStyle-HorizontalAlign="Center" SortExpression="Region">
    <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
    <asp:BoundField DataField="PName" HeaderText="prdctname" ItemStyle-HorizontalAlign="Center" SortExpression="Area">
    <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
    <asp:BoundField DataField="Qnt" HeaderText="Damage Qnt" ItemStyle-HorizontalAlign="Center" SortExpression="Teritory">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
    <asp:BoundField DataField="ApprovedQnt" HeaderText="D.O Qnt" ItemStyle-HorizontalAlign="Center" SortExpression="Point">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>  
     <asp:BoundField DataField="decdamagevalue" HeaderText="D.O Value" ItemStyle-HorizontalAlign="Center" SortExpression="Point">
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>      

    <asp:TemplateField HeaderText="Insertion" SortExpression="Insert Date" >
    <ItemTemplate><asp:Label ID="lbcdate" runat="server"  Text='<%# Eval("dtedamageinputdate", "{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField>

  


 
    </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle CssClass="GridviewScrollHeader" BackColor="#000084" Font-Bold="True" ForeColor="White"/><PagerStyle CssClass="GridviewScrollPager" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"/>
         <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </td></tr>


    </table>

          </form>
</body>
</html>