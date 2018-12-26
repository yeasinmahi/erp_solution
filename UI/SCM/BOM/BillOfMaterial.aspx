<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillOfMaterial.aspx.cs" Inherits="UI.SCM.BOM.BillOfMaterial" %>

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
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/JS/datepickr.min.js"></script>

    <script src="../../Content/JS/JSSettlement.js"></script>

    <link href="jquery-ui.css" rel="stylesheet" />

     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script>

    <script src="jquery-ui.min.js"></script> 
     


    <script type="text/javascript"> 
        function AddConfirm() {
                //var e = document.getElementById("ddlTransType");
                //var transferType = e.options[e.selectedIndex].value;
                //var e = document.getElementById("ddlLcation");
                //var locationId = e.options[e.selectedIndex].value;
            
                var inItem = document.getElementById("txtItem").value;
                var quantity = parseFloat(document.getElementById("txtQuantity").value);
                var wastage = parseFloat(document.getElementById("txtWastage").value);
                var code = document.getElementById("txtCode").value;
                var name =document.getElementById("txtBomName").value;
           
             if ($.trim(wastage) == 0 || $.trim(wastage) == "" || $.trim(wastage) == null || $.trim(wastage) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input wastage%'); }
             else if ($.trim(code) == 0 || $.trim(code) == "" || $.trim(code) == null || $.trim(code) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input BOM Code'); }
             else if ($.trim(inItem) == 0 || $.trim(inItem) == "" || $.trim(inItem) == null || $.trim(inItem) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select In Item'); }
             else if ($.trim(name) == 0 || $.trim(name) == "" || $.trim(name) == null || $.trim(name) == undefined || $.trim(name) =="NaN") { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input BOM Name'); }
             else if ($.trim(quantity) == 0 || $.trim(quantity) == "" || $.trim(quantity) == null || $.trim(quantity) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input Quantity'); }
              

             else {
                  document.getElementById("hdnPreConfirm").value = "1";
             }
        }

        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

        }

</script> 
    <style type="text/css">
        .auto-style2 {
            width: 46%;
            float: left;
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
       <asp:HiddenField ID="hdnPreConfirm" runat="server" />  
       <div class="tabs_container">Bill of Material From<hr/></div> 
        <div>
           <div style="Text-align:left;" class="auto-style2">
           <b><table style="width:650px">
            <tr> 
            <td style="text-align:left;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"     ></asp:DropDownList></td>                                                                                      

            <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="250px"   ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
            ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
                 
            </tr>
           <tr>
            <td style="text-align:left;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Quantity"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQuantity" CssClass="txtBox" Text="0" Font-Bold="False" AutoPostBack="false" runat="server"   ></asp:TextBox></td>                                                                                      
          <td style="text-align:right;" ><asp:Label ID="lblPurpose" runat="server" CssClass="lbl" Text="Wastage(%)"></asp:Label></td>            

            <td style="text-align:left;"><asp:TextBox ID="txtWastage" Text="0" CssClass="txtBox" Font-Bold="False"   AutoPostBack="false"   runat="server"></asp:TextBox> 
                 
            </td>                                                                                      
      
           </tr>
            <tr>
              <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="BOM Name"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtBomName" CssClass="txtBox" Font-Bold="False" Text="0" AutoPostBack="false" runat="server"></asp:TextBox></td> 
                 <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Code"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCode" CssClass="txtBox" Font-Bold="False"   Text="0" AutoPostBack="false" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
           
           <td style="text-align:right" colspan="4"><asp:Button ID="btnAdd" runat="server" Font-Bold="true" OnClientClick="AddConfirm();" Text="Add" OnClick="btnAdd_Click"     />
           <asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="true" OnClientClick="funConfirmAll();" OnClick="btnSubmit_Click"    />
               
           </td>  
            </tr>
             </table>
               <table style="width:800px"> 
            <tr><td> 

            <asp:GridView ID="dgvRecive" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="itemid"><ItemTemplate>
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Name" SortExpression="item"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>

           
             <asp:TemplateField HeaderText="uom" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="uom" >
            <ItemTemplate><asp:Label ID="lblQty" runat="server"  Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblValue" runat="server"   Text='<%# Bind("qty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Wastage" ItemStyle-HorizontalAlign="right" SortExpression="wastage" >
            <ItemTemplate><asp:Label ID="lblwastage" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("wastage") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Bom" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="bomname" > 
            <ItemTemplate><asp:Label ID="lblLOcationId" Width="150px"   runat="server"   Text='<%# Bind("bomname") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>

            <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="right" SortExpression="strCode" > 
            <ItemTemplate><asp:Label ID="lblCode" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField> 
            <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
            </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td>
        </tr> 
      </table></b></div>
          
       <div style="Text-align:right;Width:40%;float:right">
              
               <table style="width:400px">
                   <tr>
                      
              <td style="Text-align:right;"><asp:TextBox ID="txtBomItem" runat="server" AutoCompleteType="Search" Placeholder="Bom Item Search" CssClass="txtBox" AutoPostBack="true" Width="400px" OnTextChanged="txtBomItem_TextChanged"   ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtBomItem"
            ServiceMethod="GetItemBomSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
                   </tr>
                   <tr>
                       <td style="text-align:right"><asp:listbox ID="ListDatas" Width="400px" Height="300px" AutoPostBack="true"   runat="server" OnSelectedIndexChanged="ListDatas_SelectedIndexChanged"> 
             </asp:listbox> </td>
                   </tr>
               </table>
          </div>
       </div>
       
    </div>

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>