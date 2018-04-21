<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetCheckInOutReport.aspx.cs" Inherits="UI.Asset.AssetCheckInOutReport" %>

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
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
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
        </script>
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
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
    
       <div class="tabs_container" style="text-align:left">Asset Status  From<hr /></div>
         
       <table>
        <tr> 
        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Type"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"      >
        <asp:ListItem Text="IN Use" value="1"></asp:ListItem>
        <asp:ListItem Text="IN Store" value="2"></asp:ListItem>
        <asp:ListItem Text="Expire" value="3"></asp:ListItem>
        </asp:DropDownList></td>    
                                                                                                             
        <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text=" Enroll"  ></asp:Label></td>
        <td style="text-align:left;"><asp:TextBox ID="txtEnroll" CssClass="txtBox"   Font-Bold="False"   runat="server"/> </td>
       <td> <asp:Button ID="btnAssetStatus" runat="server" Text="Asset Status" CssClass="btnButton" OnClick="btnAssetStatus_Click"   />
        </td>  
        
         <td style="text-align:left;"> 
         <asp:Button ID="btnPoUserShow" runat="server" Visible="false" Text="User Status"       />
        </td> 
      </tr> 
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvAssetStatus" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"    
                CssClass="GridViewStyle">            
                <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>

                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/>
                    
                    <HeaderTemplate> 
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvAssetStatus')"></asp:TextBox></HeaderTemplate>
                              
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
                <asp:TemplateField HeaderText="Asset ID" SortExpression="strAssetID"><ItemTemplate>
                <asp:Label ID="lblAssetID" runat="server" Width="100px" Text='<%# Bind("strAssetID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="AssetName" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strNameOfAsset" >
                <ItemTemplate><asp:Label ID="lblAssetName" runat="server"  Text='<%# Bind("strNameOfAsset") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

                <asp:TemplateField HeaderText="WH" ItemStyle-HorizontalAlign="right" SortExpression="whname" >
                <ItemTemplate><asp:Label ID="lblWH" runat="server"  Width="90px" Text='<%# Bind("whname" ) %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="right" SortExpression="transType" >
                <ItemTemplate><asp:Label ID="lblType" runat="server" Width="150px"  Text='<%# Bind("transType") %>'></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="right" SortExpression="userName" >
                <ItemTemplate><asp:Label ID="lbluser" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("userName" ) %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="total" >
                <ItemTemplate><asp:Label ID="lblTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("total") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
                 
            </Columns> 
            </asp:GridView></td> 
        </tr>  
       </table> 
        <table>
          <%--  <tr>
            <td>
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" CssClass="Grid"
      >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <img alt = "" style="cursor: pointer" src="images/plus.png" />
                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass = "ChildGrid">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="strAssetID" HeaderText="strAssetID" />
                             
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="150px" DataField="strAssetID" HeaderText="strAssetID" />
        <asp:BoundField ItemStyle-Width="150px" DataField="strNameOfAsset" HeaderText="strNameOfAsset" />
        <asp:BoundField ItemStyle-Width="150px" DataField="strAssetTypeName" HeaderText="strAssetTypeName" />
        <asp:BoundField ItemStyle-Width="150px" DataField="whname" HeaderText="whname" />
        <asp:BoundField ItemStyle-Width="150px" DataField="total" HeaderText="total" />
        <asp:BoundField ItemStyle-Width="150px" DataField="userName" HeaderText="userName" />
        <asp:BoundField ItemStyle-Width="150px" DataField="transType" HeaderText="transType" />
    </Columns>
</asp:GridView></td></tr>--%>
        </table>
        </div>

     
         

      

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>