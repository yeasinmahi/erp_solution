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
         
        
         function  ConfirmAdd() {  
           
             var fgitem = document.getElementById("txtFgItem").value;  
       
            if ($.trim(fgitem) == 0 || $.trim(fgitem) == "" || $.trim(fgitem) == null || $.trim(fgitem) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please select FG  Item'); }
           
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 

               
            } 
        }
          function  Confirm() {   
            
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }
    </script> 
    <script> 
         function Viewdetails( itemname,stationName,stationId,intwh) {
             window.open('FinishedGoodRoutingDetalis.aspx?itemname=' + itemname + '&stationName=' + stationName + '&stationId=' + stationId +'&intwh=' + intwh, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
               
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
        <asp:HiddenField ID="hdnPreConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnInQty" runat="server" />
       <div class="tabs_container">ROUTING<hr /></div>
        
        <table    style="width:750px; text-align:center ">   
            <tr>
             <td></td><td></td>  <td></td> 
            <td style="text-align:right;">WH Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlWh"  CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"  ></asp:DropDownList>  </td> 
        </tr>
            <tr>
                <td></td>
            </tr>
         </table>
        <table>
            <tr >
            <td style='text-align: right;'>Item Name</td>
            <td><asp:TextBox ID="txtFgItem" runat="server" AutoCompleteType="Search"   CssClass="txtBox" AutoPostBack="true" Width="600px"      ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtFgItem"
            ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>  

            </tr>
            <tr>
                <td>WorkStation</td>
                <td><asp:DropDownList ID="ddlStation" runat="server" CssClass="ddList" Width="600px"> </asp:DropDownList></td>
            </tr>
            <%--<tr>
                <td>Routing Code</td>
                <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtBox" Width="600px"> </asp:TextBox></td>
            </tr> --%>
            <tr> 
            <td style="text-align:right" colspan="2" >
            <asp:Button ID="btnAssetAdd" Text="Add" runat="server"  OnClientClick=" ConfirmAdd();"  OnClick="btnAssetAdd_Click" />
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
                 
             <asp:TemplateField HeaderText="Item Name" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="itemName" >
            <ItemTemplate><asp:Label ID="lblItem" runat="server"  Text='<%# Bind("itemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="itemId" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="itemId" >
            <ItemTemplate><asp:Label ID="lblItemId" runat="server"   Text='<%# Bind("itemId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
              
           <asp:TemplateField HeaderText="Workstation" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="workName" >
            <ItemTemplate><asp:Label ID="lblWorkstation" runat="server"  Text='<%# Bind("workName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="workId" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="workId" >
            <ItemTemplate><asp:Label ID="lblWorkId" runat="server"   Text='<%# Bind("workId") %>'></asp:Label></ItemTemplate>
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

            <asp:GridView ID="dgvRptw" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="650px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                 
             <asp:TemplateField HeaderText="Item Name" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="strItemName" >
            <ItemTemplate><asp:Label ID="lblItem" runat="server"  Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            <asp:TemplateField HeaderText="Workstation" ItemStyle-HorizontalAlign="right"   SortExpression="strSectionName" >
            <ItemTemplate><asp:Label ID="lblSectionName" runat="server"   Text='<%# Bind("strSectionName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
              
           <asp:TemplateField HeaderText="sectionId" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intAutoId" >
            <ItemTemplate><asp:Label ID="lblWorkstationId" runat="server"  Text='<%# Bind("intAutoId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                
            
           <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="right" SortExpression="strCode" >
            <ItemTemplate><asp:Label ID="lblCode" runat="server"   Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
         
            <asp:TemplateField HeaderText="Detalis" ItemStyle-HorizontalAlign="right"  > 
            <ItemTemplate><asp:Button ID="btnDetalis" runat="server" OnClick="btnDetalis_Click"      Text="Detalis"></asp:Button></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField> 
      
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
