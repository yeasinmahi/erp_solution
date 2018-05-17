<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodRoutingDetalis.aspx.cs" Inherits="UI.SCM.BOM.FinishedGoodRoutingDetalis" %>

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
         
        
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }
    </script> 
    <style type="text/css">
        .auto-style2 {
            font-size: 10px;
            background-color: #FFFFFF;
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
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 10px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 10px;">&nbsp;</div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" />
        <asp:HiddenField ID="hdnPreConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnInQty" runat="server" />
       <div class="tabs_container">ROUTING<hr /></div> 
         
        <table>
            <tr>
                <td>Item Name:</td>
                <td><asp:Label ID="lblItems" ForeColor="Blue" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Workstation:</td>
                <td><asp:Label ID="lblstationName" ForeColor="Blue" runat="server"></asp:Label></td>
            </tr>
            <tr><td></td></tr>
        </table>
         <table style="border-radius:10px; width:800px; border-style:double">
             <caption style="text-align:left; color:blue;">Manpower </caption>
            <tr >
             <td>Man Quantity</td>
                <td><asp:TextBox ID="txtManpower" runat="server" Text="0" ></asp:TextBox></td>
             
             <td>Hour</td>
                <td><asp:TextBox ID="txtMahour" Text="0" runat="server"></asp:TextBox></td>
          
             <td>Rate</td>
                <td><asp:TextBox ID="txtRate" Text="0"   runat="server"></asp:TextBox> 
                <asp:Button ID="bnManpower" Text="Save" runat="server" OnClientClick="Confirm();" OnClick="bnManpower_Click"    /><td></td>
            </tr>

             <tr><td colspan="6"> 

            <asp:GridView ID="dgvMan" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
                <asp:TemplateField HeaderText="Workstation" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strSectionName" >
            <ItemTemplate><asp:Label ID="lblwork" runat="server"  Text='<%# Bind("strSectionName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Man Quantity" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
            <ItemTemplate><asp:Label ID="lblManQty" runat="server"  Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Hour" ItemStyle-HorizontalAlign="right"   SortExpression="numHour" >
            <ItemTemplate><asp:Label ID="lblHours" runat="server"   Text='<%# Bind("numHour") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
              
            <asp:TemplateField HeaderText="Rate" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="rate" >
            <ItemTemplate><asp:Label ID="lblRate" runat="server"  Text='<%# Bind("rate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>    
            
            </Columns>
            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td>
            </tr> 

            <tr><td class="auto-style2">  
                &nbsp;</td>
            </tr>
            <tr><td></td></tr>
        </table> 
        <table style="border-radius:10px; width:800px;">
            
        </table>
        <table style="border-radius:10px; width:800px; border-style:double">
             <caption style="text-align:left; color:blue">Machinery </caption>
            <tr >
             <td>Machine</td>
            <td style="text-align:left;"><asp:TextBox ID="txtAsset" runat="server" AutoCompleteType="Search" Width="300px"   CssClass="txtBox" AutoPostBack="true"         ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAsset"
            ServiceMethod="GetAssetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender> </td>
             
             <td>Hour</td>
                <td><asp:TextBox ID="txtMacHour" runat="server"></asp:TextBox> 
                <asp:Button ID="btnMAdd" Text="Add" runat="server" OnClick="btnMAdd_Click"    /><asp:Button ID="btnSubmitM" Text="Submit" runat="server" OnClick="btnSubmitM_Click"/><td>
            </tr> 

             <tr><td colspan="5">  
            <asp:GridView ID="dgvMachineRpt" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
                <asp:TemplateField HeaderText="Workstation Name" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strItemName" >
            <ItemTemplate><asp:Label ID="lblworkst" runat="server"  Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
         
                
            <asp:TemplateField HeaderText="Machine Name" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strNameOfAsset" >
            <ItemTemplate><asp:Label ID="lblMachine" runat="server"  Text='<%# Bind("strNameOfAsset") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Asset ID" ItemStyle-HorizontalAlign="right"   SortExpression="intAssetId" >
            <ItemTemplate><asp:Label ID="lblAssetId" runat="server"   Text='<%# Bind("intAssetId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
              
            <asp:TemplateField HeaderText="Hour" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="numHour" >
            <ItemTemplate><asp:Label ID="lblHour" runat="server"  Text='<%# Bind("numHour") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
            </Columns>
            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td>
            </tr> 
        </table>
          <table style="width:800px"> 
            <tr><td> 

            <asp:GridView ID="dgvMachine" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                 
             <asp:TemplateField HeaderText="Machine Name" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="asset" >
            <ItemTemplate><asp:Label ID="lblMachine" runat="server"  Text='<%# Bind("asset") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Asset ID" ItemStyle-HorizontalAlign="right"   SortExpression="intAssetId" >
            <ItemTemplate><asp:Label ID="lblAssetId" runat="server"   Text='<%# Bind("intAssetId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
              
           <asp:TemplateField HeaderText="Hour" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="hours" >
            <ItemTemplate><asp:Label ID="lblHour" runat="server"  Text='<%# Bind("hours") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            
             
            <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
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