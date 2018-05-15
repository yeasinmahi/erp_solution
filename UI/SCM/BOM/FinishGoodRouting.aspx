<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishGoodRouting.aspx.cs" Inherits="UI.SCM.BOM.FinishGoodRouting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%> 
  
    
   
    <script type="text/javascript"> 
         
        function AddConfirm() { 
            var aset = document.getElementById("txtAsset").value;
            var hours = document.getElementById("txtHour").value;
 
      
            if ($.trim(aset) == 0 || $.trim(aset) == "" || $.trim(aset) == null || $.trim(aset) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Asset name'); }
            else if ($.trim(hours) == 0 || $.trim(hours) == "" || $.trim(hours) == null || $.trim(hours) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input hour'); }
               else {
                 
                document.getElementById("hdnPreConfirm").value = "1";
            } 
        }

         function  Confirm() {  
            var hours = document.getElementById("txtHoursMan").value;
             var fgitem = document.getElementById("txtFgItem").value; 
             var qty = document.getElementById("txtQty").value; 
       
            if ($.trim(fgitem) == 0 || $.trim(fgitem) == "" || $.trim(fgitem) == null || $.trim(fgitem) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please select FG  Item'); }
            else if ($.trim(hours) == 0 || $.trim(hours) == "" || $.trim(hours) == null || $.trim(hours) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please input hour'); }
            else if ($.trim(qty) == 0 || $.trim(qty) == "" || $.trim(qty) == null || $.trim(qty) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please input Quantity'); }

            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 

               
            } 
        }
    </script> 
    <style type="text/css">
        .auto-style1 {
            width: 668px;
        }
    </style>
</head>
<body>
<form id="frmTransferOrder" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" />
        <asp:HiddenField ID="hdnPreConfirm" runat="server" /><asp:HiddenField ID="hdnTransfromValue" runat="server" /><asp:HiddenField ID="hdnInQty" runat="server" />
       <div class="tabs_container">ROUTING<hr /></div>
        
        <table    style="width:750px; text-align:center ">   
            <tr>
             <td></td><td></td>  <td></td><td></td> <td></td><td></td><td></td><td></td><td></td><td></td>
            <td style="text-align:right;">WH Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlWh"  CssClass="ddList" runat="server" AutoPostBack="True"  ></asp:DropDownList>  </td> 
        </tr>
            <tr>
                <td></td>
            </tr>
         </table>
        <table>
            <tr>
            <td style='text-align: right;'>Item Name</td>
            <td colspan="3"><asp:TextBox ID="txtFgItem" runat="server" AutoCompleteType="Search"   CssClass="txtBox" AutoPostBack="true" Width="600px"      ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtFgItem"
            ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>  

            </tr>
               <tr>
            <td style='text-align: right;'>Asset</td>
            <td style="text-align:left;"><asp:TextBox ID="txtAsset" runat="server" AutoCompleteType="Search" Width="400px"   CssClass="txtBox" AutoPostBack="true"         ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAsset"
            ServiceMethod="GetAssetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender> </td>
              <td>Hour</td>
             <td><asp:TextBox ID="txtHour" Width="130px" CssClass="txtBox" runat="server"></asp:TextBox></td> 
             
          <tr>
              <td><asp:Label ID="lblMan" runat="server" Text="Man Quantity" ></asp:Label></td>
              <td style="text-align:left" colspan="3"><asp:TextBox ID="txtQty" Width="70px" Text="0" TextMode="Number"  CssClass="txtBox" runat="server" ></asp:TextBox> 
               <asp:Label ID="Label3" runat="server" Text="Hour"   ></asp:Label> 
               <asp:TextBox ID="txtHoursMan" runat="server" Width="70px"  Text="0" TextMode="Number" CssClass="txtBox" ></asp:TextBox>
               <asp:Label ID="Label4" runat="server" Text="Code"  ></asp:Label>
               <asp:TextBox ID="txtRemarks" CssClass="txtBox" Width="360px"  runat="server" ></asp:TextBox></td>
          </tr>
            <tr> 
            <td style="text-align:right" colspan="4" >
            <asp:Button ID="btnAssetAdd" Text="Add" runat="server" OnClientClick="AddConfirm();" OnClick="btnAssetAdd_Click" />
            <asp:Button ID="btnsubmit" Text="Submit" runat="server" OnClientClick="Confirm();" OnClick="btnsubmit_Click" /><asp:Button ID="btnReport" Text="Report" runat="server" OnClick="btnReport_Click"   /></td>
            </tr> 
        </table> 
         <table style="width:800px"> 
            <tr><td> 

            <asp:GridView ID="dgvRoute" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

           
            <asp:TemplateField HeaderText="Asset Name" SortExpression="assetname"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("assetname") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="200px"/></asp:TemplateField>

           
             <asp:TemplateField HeaderText="Asset Code" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="assetId" >
            <ItemTemplate><asp:Label ID="lblCode" runat="server"  Text='<%# Bind("assetId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Hour" ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblHour" runat="server"   Text='<%# Bind("strHour") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
         
            <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
            </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td>
        </tr> 
      </table>
         <table style="width:800px"> 
            <tr><td> 

            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

           
            <asp:TemplateField HeaderText="Item Name" SortExpression="strItemName"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="200px"/></asp:TemplateField>

           
             <asp:TemplateField HeaderText="Code" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strCode" >
            <ItemTemplate><asp:Label ID="lblCode" runat="server"  Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Man Power" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
            <ItemTemplate><asp:Label ID="lblHour" runat="server"   Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

             <asp:TemplateField HeaderText="Hour" ItemStyle-HorizontalAlign="right" SortExpression="numHour" >
            <ItemTemplate><asp:Label ID="lblHour" runat="server"   Text='<%# Bind("numHour") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

          <asp:TemplateField HeaderText="Total Machine" ItemStyle-HorizontalAlign="right" SortExpression="totalm" >
            <ItemTemplate><asp:Label ID="lblHour" runat="server"   Text='<%# Bind("totalm") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
         
             </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

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
