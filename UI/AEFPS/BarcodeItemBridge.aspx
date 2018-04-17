<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarcodeItemBridge.aspx.cs" Inherits="UI.AEFPS.BarcodeItemBridge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

    
 <script type="text/javascript">
     function funConfirmAll() {
         var confirm_value = document.createElement("INPUT");
         confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
         if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
         else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
     }
 </script>

 <script type="text/javascript">
     function Search_dgvservice(strKey, strGV) {

         var strData = strKey.value.toLowerCase().split(" ");
         var tblData = document.getElementById(strGV);
         var rowData;
         for (var i = 1; i < tblData.rows.length; i++) {
             rowData = tblData.rows[i].innerHTML;
             var styleDisplay = 'none';
             for (var j = 0; j < strData.length; j++) {
                 if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                     styleDisplay = '';
                 else {
                     styleDisplay = 'none';
                     break;
                 }
             }
             tblData.rows[i].style.display = styleDisplay;
         }

     }

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


    <style type="text/css">
        .auto-style1 {
            width: 193px;
        }
    </style>

</head>
<body>
    <form id="frmselfresign" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnDA" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnTFare" runat="server" />
        
       <div class="tabs_container">Item Barcode Bridge From<hr /></div>
        <table>
       <tr> 
           <%--<td style="text-align:left;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;" class="auto-style1">
            <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"  OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"  ></asp:DropDownList>                                                                                       
           </td>--%>
         
          <td style="text-align:Right;"> 
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="funConfirmAll()" OnClick="btnSubmit_Click"  /></td>
           
        </tr>

         <tr><td> 
            <asp:GridView ID="dgvBridge" runat="server" AutoGenerateColumns="False"  Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" style="margin-top: 54px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>                                 
                                       
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvBridge')"></asp:TextBox></HeaderTemplate>
                                
                         
                     <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate> <ItemStyle HorizontalAlign="Left" Width="10px"/></asp:TemplateField>            
            
            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="intItemID"><ItemTemplate>            
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                
               
            <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName"><ItemTemplate>            
            <asp:TextBox ID="txtItemName" runat="server" Width="300px" CssClass="txtBox" Text='<%# Bind("strItemName") %>'></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
            <asp:TemplateField HeaderText="Code" SortExpression="strCode"><ItemTemplate>            
            <asp:TextBox ID="lblItemCode" runat="server" CssClass="txtBox" Text='<%# Bind("strCode") %>'></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField>

             <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUoM" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
             </asp:TemplateField> 
                         
            <asp:TemplateField HeaderText="WH" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="whname" >
            <ItemTemplate><asp:Label ID="lblWH" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("whname") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Barcode" ItemStyle-HorizontalAlign="right" SortExpression="barcode" >
            <ItemTemplate><asp:TextBox ID="txtBarcode" runat="server"  Text='<%# Bind("barcode") %>'></asp:TextBox></ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="chkHeader" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
           

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
            </table>

        </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
