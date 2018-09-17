<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Indent.aspx.cs" Inherits="UI.SCM.Indent" %>

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
    <script language="javascript" type="text/javascript">

        function onlyNumbers(evt) {

            var e = event || evt; // for trans-browser compatibility

            var charCode = e.which || e.keyCode;



            if ((charCode > 57))

                return false;

            return true;

        } 

</script>


    <script type="text/javascript">

        function funConfirmAll() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

        }

</script> 
  <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
    gtag('config', 'UA-125570863-1');
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
       <asp:HiddenField ID="hdnDA" runat="server" />  
       <div class="tabs_container">Indent Entry  From :  Policy (Please create Indents between 1st to 3rd day of every month in case of Regular Items and for irregular Items  only on Saturday.)<hr/></div>
        <table>
            <td><asp:HyperLink runat="server" ForeColor="Red" ID="lblDet" Text="Policy (Please create Indents between 1st to 3rd day of every month in case of Regular Items and for irregular Items  only on Saturday.)"></asp:HyperLink></td>
        </table>
       <table>
            <tr> 
            <td style="text-align:left;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"   ></asp:DropDownList></td>                                                                                      

            <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px"   ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
            ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Qty"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQty" CssClass="txtBox" Font-Bold="False" Text="0" runat="server"></asp:TextBox></td> 
            </tr>

            <tr>
            <td style="text-align:left;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="QC Person"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlQcPersonal" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"   ></asp:DropDownList></td>                                                                                      
           
            <td style="text-align:right;" ><asp:Label ID="lblPurpose" runat="server" CssClass="lbl" Text="Purpose"></asp:Label></td>            

            <td style="text-align:left;"><asp:TextBox ID="txtPurpose" CssClass="txtBox" Font-Bold="False"   Width="300px" runat="server"></asp:TextBox> </td>                                                                                      
            <td style="text-align:left;" ><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Due Date"></asp:Label></td>
            <td style="text-align:left;">
            <asp:TextBox ID="txtDueDate" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDueDate">
            </cc1:CalendarExtender> 
            </td>  
            </tr> 
           
            <tr> 
            <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text=" Type"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"     > 
            </asp:DropDownList></td>

            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Req ID" Visible="false"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlReqId" CssClass="ddList" Font-Bold="False" Visible="false" AutoPostBack="true" runat="server"></asp:DropDownList>                                                                                      
            <asp:Button ID="btnReq" runat="server" Text="Req Add" OnClick="btnReq_Click" Visible="false"  />  <asp:Label ID="lblIndentNo" runat="server" Font-Bold="true"    Font-Size="Medium" ForeColor="#0066cc"></asp:Label>
           
            </td> 

            <td colspan="2" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"   />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"   />
            </td>  
            </tr>
            <tr><td colspan="6"> 

            <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting" 

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  >

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="itemId"><ItemTemplate>
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Name" SortExpression="itemName"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="uom" >
            <ItemTemplate><asp:Label ID="lblUoM" runat="server"  Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField>  
             <asp:TemplateField HeaderText="ReqCode" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="reqCode" >
            <ItemTemplate><asp:Label ID="lblreqCode" runat="server"  Text='<%# Bind("reqCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Stock" ItemStyle-HorizontalAlign="right" SortExpression="stock" >
            <ItemTemplate><asp:Label ID="lblStock" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("stock","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="SaftyStock" ItemStyle-HorizontalAlign="right" SortExpression="sftyStock" >
            <ItemTemplate><asp:Label ID="lblSftyStock" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("sftyStock") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Purpose" ItemStyle-HorizontalAlign="right" SortExpression="purpose" > 
            <ItemTemplate><asp:Label ID="lblpurpose" Width="200px"   runat="server"   Text='<%# Bind("purpose") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>

            <asp:TemplateField HeaderText="IndentQty" ItemStyle-HorizontalAlign="right" SortExpression="indentQty" > 
            <ItemTemplate><asp:Label ID="lblIndentQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("indentQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate" > 
            <ItemTemplate><asp:Label ID="lblRate" runat="server"  Text='<%# Bind("rate","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField> 
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
