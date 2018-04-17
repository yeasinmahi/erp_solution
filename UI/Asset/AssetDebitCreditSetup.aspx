<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetDebitCreditSetup.aspx.cs" Inherits="UI.Asset.AssetDebitCreditSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 139px;
        }
        .txtBox {}
        </style>
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
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

            
    <div class="tabs_container" align="left" >Aaset Transaction Accounts Head Configure</div>
   
        <table class="tblrowodd" >
        <tr>
        <td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnit" runat="server"  CssClass="ddList" AutoPostBack="True" OnDataBound="DdlBillUnit_DataBound" OnSelectedIndexChanged="DdlBillUnit_SelectedIndexChanged"></asp:DropDownList> </td>
        <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
        <td><asp:DropDownList ID="ddltype" runat="server"  CssClass="ddList" >
        <asp:ListItem Text="Administrative" value="1"></asp:ListItem> <asp:ListItem Text="Manufacturing" value="2"></asp:ListItem> </asp:DropDownList> </td>  
        </tr>
        <tr>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Transection Type : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlTransecTionType" runat="server"  CssClass="ddList" AutoPostBack="True"> </asp:DropDownList> </td> 
   
        <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlAssetType" runat="server"  CssClass="ddList"  ></asp:DropDownList> </td>  
        </tr> 
               
       <%-- <tr><td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Asset COA : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlAssetCOA" runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="ddlAssetCOA_SelectedIndexChanged" > </asp:DropDownList> </td>                  
                            
        <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="AccountsCOA: "></asp:Label></td>
        <td><asp:DropDownList ID="ddlAccountsCOA" runat="server"  CssClass="ddList"></asp:DropDownList> </td></tr>--%>
        <tr> 
        <td style="text-align:right;" > <asp:Label ID="lblAccCoa" runat="server" CssClass="lbl" font-size="small" Text="Accounts COA:"></asp:Label></td>
        <td style="text-align:left;"> <asp:TextBox ID="txtAccCoa" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"  ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtAccCoa"
        ServiceMethod="GetAccCoaSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> 
        </tr>
        <tr> <td style="text-align:right;" colspan="2"><asp:RadioButton ID="radDebit" Text="Debit" GroupName="Dr"  runat="server" /><asp:RadioButton ID="radCredit" GroupName="Dr"  Text="Credit" runat="server" /> </td>                
        <td  style="text-align:right;" colspan="2"> <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click"   /><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"   />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  /></td> 
        </tr>  
        </table>
        
        <table>
        <tr><td><asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvGridView_RowDeleting">
        <Columns>
        <asp:TemplateField HeaderText="SL.N">                                
        <ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="ID">                          
        <ItemTemplate><asp:Label ID="lblAutoID"  runat="server" Text='<%# Bind("autoID") %>'></asp:Label></ItemTemplate>                           
        </asp:TemplateField>
        <asp:BoundField DataField="unitName" HeaderText="Unit" SortExpression="unitName"/>
        <asp:BoundField DataField="typeName" HeaderText="Type" SortExpression="typeName" />
        <asp:BoundField DataField="assetypeName" HeaderText="MajorType" SortExpression="assetypeName" />  
        <asp:BoundField DataField="accountstypeName" HeaderText="Transection Type" SortExpression="accountstypeName" />  
        <asp:BoundField DataField="debit" HeaderText="Debit" SortExpression="debit" />
        <asp:BoundField DataField="credit" HeaderText="Credit" SortExpression="credit" />
        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
        </Columns>
        </asp:GridView>
        </td></tr>
        </table> 
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>