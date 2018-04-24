<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueReturn.aspx.cs" Inherits="UI.SCM.IssueReturn" %>

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
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>
     
    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
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
    
       <div class="tabs_container" style="text-align:left">Issue Return From<hr /></div>
         
       <table>
        <tr> 
        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"    ></asp:DropDownList></td>                                                                                      
         
        <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>            
        <td style="text-align:left;"  ><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px"   ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
        ServiceMethod="GetItemSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>  
        </tr> 
           <tr>
            <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteFrom"></cc1:CalendarExtender></td>

            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteTo"></cc1:CalendarExtender> 
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
           </tr>
         
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvPoApp" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="600px"  
                CssClass="GridViewStyle">            
                <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
                <asp:TemplateField HeaderText="IssueID" SortExpression="intIssueID"><ItemTemplate>
                <asp:Label ID="lblIssueId" runat="server" Width="100px" Text='<%# Bind("intIssueID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="SRNO" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strSrNo" >
                <ItemTemplate><asp:Label ID="lblSrNo" runat="server"  Text='<%# Bind("strSrNo") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

                <asp:TemplateField HeaderText="SR Date" ItemStyle-HorizontalAlign="right" SortExpression="dteSrDate" >
                <ItemTemplate><asp:Label ID="lblSrDate" runat="server"  Width="90px" Text='<%# Bind("dteSrDate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="ISSUE Date" ItemStyle-HorizontalAlign="right" SortExpression="dteIssueDate" >
                <ItemTemplate><asp:Label ID="lblIssueDate" runat="server" Width="150px"  Text='<%# Bind("dteIssueDate") %>'></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="QTY" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
                <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="monValue" >
                <ItemTemplate><asp:Label ID="lblValue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monValue") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
                <asp:TemplateField HeaderText="Issue Section" ItemStyle-HorizontalAlign="right" SortExpression="strSection" >
                <ItemTemplate><asp:Label ID="lblIssueSection" runat="server" Width="150px"  Text='<%# Bind("strSection") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="Used For" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="strUseFor" >
                <ItemTemplate><asp:Label ID="lblUsed"   runat="server"   Text='<%# Bind("strUseFor") %>' ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 

                <asp:TemplateField HeaderText="Return Qty" ItemStyle-HorizontalAlign="right"   SortExpression="strIndentType" >
                <ItemTemplate><asp:TextBox ID="txtReturnQty"   runat="server"    ></asp:TextBox></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 
            
                 <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right"    >
                <ItemTemplate><asp:TextBox ID="txtRemarks"   runat="server"    ></asp:TextBox></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 

                <asp:TemplateField HeaderText="Return">  <ItemTemplate>
                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClientClick="funConfirmAll();" OnClick="btnReturn_Click"  /></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            </Columns> 
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