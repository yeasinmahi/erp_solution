<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pg_ProjectCreate.aspx.cs" Inherits="UI.NewProject.pg_ProjectCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .auto-style1 {
                height: 26px;
            }
            .auto-style2 {
                height: 20px;
            }
            .auto-style3 {
                width: 524px;
            }
        </style>
 
</head>
<body>
    <form id="frmreq" runat="server">
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
     <asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnupdate" runat="server" />
    <div class="leaveApplication_container"><table class="tbldecoration" border="0"; style="width:1000PX"; >
    <tr> 
    <td  colspan="2" style="color:forestgreen;height:20px;text-align:center" class="tblheader"><h2> Create New Project:</h2></td>
    </tr>
    <tr>

    <td style="vertical-align:top;border-bottom:double;border-right:double;border-radius:6px;border-left:double;border-top:double"  class="auto-style3"> 
    <table style="vertical-align:top" width="100%">
    <tr class="tblrowodd">
    <td style="text-align:right;font-size:20px"><asp:Label ID="Label8" CssClass="lbl" Font-Size="14px" runat="server" Text="Project Type :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlptype" runat="server" CssClass="ddList" >
        <asp:ListItem>Event</asp:ListItem>
        <asp:ListItem>Civil</asp:ListItem>
        <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" Font-Size="13px" runat="server" Text="Project Name :"></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtProjectName" runat="server" CssClass="txtBox"></asp:TextBox></td>  
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblProjectCode" Font-Size="13px" CssClass="lbl" runat="server" Text="Project Code: "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtProjectCode" runat="server" CssClass="txtBox"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server"  ForeColor="Green" Font-Bold="true" Text="Search" OnClick="btnSearch_Click" />
    </td>   
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblObjective" Font-Size="13px" CssClass="lbl" runat="server" Text="Objective : "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtObjective" runat="server" CssClass="txtBox"></asp:TextBox></td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblfromdate" Font-Size="13px" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px" autocomplete="off"></asp:TextBox>
    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
    ID="CalendarExtender3" runat="server" EnableViewState="true">
    </cc1:CalendarExtender> <img id="imgCal_1" src="../Content/images/img/calbtn.gif" style="border: 0px;
    width: 34px; height: 23px; vertical-align: bottom;" /></td>      
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblToDate" Font-Size="13px" CssClass="lbl" runat="server" Text="To Date :"></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtto" runat="server" Enabled="false"  Height="22px" autocomplete="off"></asp:TextBox>
    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
    </cc1:CalendarExtender> <img id="imgCal_2" src="../Content/images/img/calbtn.gif" style="border: 0px;
    width: 34px; height: 23px; vertical-align: bottom;" />
    </tr>
    </table>
    </td>
    <td  style="vertical-align:top;border:double;border-radius:6px" >
    <table style="vertical-align:top" width="100%">
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblUnit" Font-Size="13px"  CssClass="lbl" runat="server" Text="Unit :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblCostCenter" Font-Size="13px"  CssClass="lbl" runat="server" Text="Cost Center :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlCostCeneter" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlCostCeneter_SelectedIndexChanged" ></asp:DropDownList></td>  
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblAddress" Font-Size="13px"  CssClass="lbl" runat="server" Text="Address : "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox"></asp:TextBox></td>   
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblLocation" Font-Size="13px"  CssClass="lbl" runat="server" Text="Location : "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>  
    </tr>
    <tr  class='tblrowodd'>
    <td style="text-align:right" colspan="2" class="auto-style1"></td>  
    </tr>
    <tr class='tblrowodd'>
    <td style="text-align:right" colspan="2" class="auto-style1">
    <asp:Button ID="btnAdds" runat="server"  ForeColor="Green" Font-Bold="true" Text="Add" OnClick="btnAdds_Click" />
    </td>  
    </tr>
    <tr class='tblrowodd'>
    <td colspan="2" style="text-align:right;background:#f0edec">
    <div class="tabs_container"><hr /></div>
    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvlist_RowDeleting" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>       
    <asp:TemplateField HeaderText="Unit Name" SortExpression="dudt">     
    <ItemTemplate>
    <asp:HiddenField ID="hdnunitid" runat="server" Value='<%# Eval("intUnitid") %>' /><asp:HiddenField ID="hdnccid" runat="server" Value='<%# Eval("intccid") %>' />
    <asp:Label ID="lblunitname" runat="server" Text='<%# Bind("strUname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>
    <asp:BoundField DataField="strCCName" HeaderText="Cost Center" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
    <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
    <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="Address" />
    <asp:BoundField DataField="strlocation" HeaderText="Location" SortExpression="Location" />                        
  
    <asp:CommandField ShowDeleteButton="true" CancelImageUrl="~/Content/images/Cafeteria/Recycle.png" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" >                       
    <ControlStyle Font-Bold="True" ForeColor="Red"></ControlStyle>
    </asp:CommandField>            
         
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>     
    </div></td></td>
    </tr>
    </table>       
     </td>
    </tr>  
  
    <tr class='tblrowodd'><td colspan="4"><hr /> </td> </tr>
    <tr>
    <td style="vertical-align:top;border:double;border-radius:6px" class="auto-style3"> 
    <table style="vertical-align:top" width="100%">
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblType" Font-Size="13px"  CssClass="lbl" runat="server" Text="Type :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddltype" runat="server" CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" >
    <asp:ListItem Value="1">Item</asp:ListItem>
    <asp:ListItem Value="2">Service</asp:ListItem>
    </asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblItem" Font-Size="13px"  CssClass="lbl" runat="server" Text="Item :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlItem" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>    
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"  class="auto-style1"><asp:Label ID="lblqty" Font-Size="13px"  CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtqty" runat="server" CssClass="txtBox"></asp:TextBox></td>   
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblRate" Font-Size="13px"  CssClass="lbl" runat="server" Text="Rate : "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnItemAdd" 
    ForeColor="Green" Font-Bold="true" runat="server" Text="Add" OnClick="btnItemAdd_Click" /> </td>
    </tr>
    <tr class='tblrowodd'>
    <td colspan="2" style="text-align:right;background:#f0edec">
    <div class="tabs_container"><hr /></div>
        
    <asp:GridView ID="dgvitem" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvitem_RowDeleting" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>  
             
    <asp:TemplateField HeaderText="Itemt Type" SortExpression="itemtype">     
    <ItemTemplate> <asp:HiddenField ID="hdnitemid" runat="server" Value='<%# Eval("itemid") %>' />
    <asp:Label ID="lblunitname" runat="server" Text='<%# Bind("itemtype") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

    <asp:BoundField DataField="itemname" HeaderText="Item Name" ItemStyle-HorizontalAlign="Center" SortExpression="itemname">
    <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>   
     <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty" />
    <asp:BoundField DataField="rate" HeaderText="Rate" SortExpression="rate" />  
    <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />  
                               
    <asp:CommandField ShowDeleteButton="true" CancelImageUrl="~/Content/images/Cafeteria/Recycle.png" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" >                       
    <ControlStyle Font-Bold="True" ForeColor="Red"></ControlStyle>
    </asp:CommandField>              
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>     
              
     </div></td></td>  
    </tr>
    </table>
    </td>
    <td style="vertical-align:top;border:double;border-radius:6px">
    <table style="vertical-align:top" width="100%">
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblSoucre" CssClass="lbl" Font-Size="13px"  runat="server" Text="Source Of Fund :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlSource" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    </tr> 
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblAmount" Font-Size="13px"  CssClass="lbl" runat="server" Text="Amount : "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox"></asp:TextBox></td>   
    </tr>    
    <tr class='tblrowodd'><td colspan="2" style="text-align:right"  class="auto-style1"></td>     
    </tr>
    <tr class='tblrowodd'><td style="text-align:right" colspan="2"><asp:Button ID="btnfundAdd"  ForeColor="Green" Font-Bold="true" runat="server" Text="Add" OnClick="btnfundAdd_Click" /></td></tr>
    <tr class='tblrowodd'>
    <td colspan="2" style="text-align:right;background:#f0edec">
    <div class="tabs_container"><hr /></div>
        <asp:GridView ID="dgvfund" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvfund_RowDeleting" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>               
    <asp:TemplateField HeaderText="Source Of Fund" SortExpression="itemtype">     
    <ItemTemplate> <asp:HiddenField ID="hdnnewunitid" runat="server" Value='<%# Eval("unitid") %>' />
    <asp:Label ID="lblnewunitname" runat="server" Text='<%# Bind("unitname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="amount" />
                                        
    <asp:CommandField ShowDeleteButton="true" CancelImageUrl="~/Content/images/Cafeteria/Recycle.png" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" >                       
    <ControlStyle Font-Bold="True" ForeColor="Red"></ControlStyle>
    </asp:CommandField>         
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView> 
     </div></td></td>  
    </tr>
    </table>
    </td>
    </tr>     
    </tr>  
    <tr class='tblrowodd'><td colspan="4" style="text-align:right;" class="auto-style2"><hr /> </td></tr>
    <tr> <td colspan="4" style="text-align:right;border:double;border-radius:6px">
    <table width="70%" >   
    <tr class="tblrowodd">
    <td  style="text-align:right;"><asp:Label ID="lblResposible" runat="server" Font-Size="13px"  CssClass="lbl" Text="Resposible Person :"></asp:Label></td>
    <td colspan="4" style="text-align:left;" class="auto-style1"><asp:TextBox ID="txtResposible" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtResposible"
    ServiceMethod="getEmpname" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" />
    </td>
    </tr>
    <tr class="tblrowodd">
    <td  style="text-align:right;"> <asp:Label ID="lblResposibility" runat="server" Font-Size="13px"  CssClass="lbl" Text="Responsibility : "></asp:Label> </td>
    <td style="text-align:left;"  colspan="4" class="auto-style1"><asp:TextBox ID="txtResponsibility" runat="server" Width="100%" Height="70" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox> </td>
    </tr>     
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblfdate" runat="server" Font-Size="13px"  CssClass="lbl" Text="From Date : "></asp:Label></td>
    <td  style="text-align:left;">
    <asp:TextBox ID="txteFrom" runat="server" Enabled="false" Height="22px"></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_3" TargetControlID="txteFrom">
    </cc1:CalendarExtender><img id="imgCal_3" src="../Content/images/img/calbtn.gif" style="border: 0px;
    width: 34px; height: 23px; vertical-align: bottom;" />
    </td>
    <td style="text-align:right;"><asp:Label ID="lbltdate" runat="server" Font-Size="13px"  CssClass="lbl" Text="To Date : "></asp:Label></td>
    <td style="text-align:left;">
    <asp:TextBox ID="txteTo" runat="server" Enabled="false" Height="22px"></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_4" TargetControlID="txteTo">
    </cc1:CalendarExtender><img id="imgCal_4" src="../Content/images/img/calbtn.gif" style="border: 0px;
    width: 34px; height: 23px; vertical-align: bottom;" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnResponsible"  ForeColor="Green" Font-Bold="true" runat="server" Text="Add" OnClick="btnResponsible_Click" /> </td>
    </tr>  
   
    <tr>
    <td colspan="4" style="background:#f0edec"><hr />
        <asp:GridView ID="dgvemployee" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvemployee_RowDeleting" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>               
    <asp:TemplateField HeaderText="Responsible Person" SortExpression="itemtype">     
    <ItemTemplate> <asp:HiddenField ID="hdnnewempid" runat="server" Value='<%# Eval("empid") %>' />
    <asp:Label ID="lblempname" runat="server" Text='<%# Bind("empname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

    <asp:BoundField DataField="responsibility" HeaderText="Responsibility" SortExpression="amount" />
    <asp:BoundField DataField="fdate" HeaderText="From Date" SortExpression="amount" />
    <asp:BoundField DataField="tdate" HeaderText="To Date" SortExpression="amount" />                                
 
    <asp:CommandField ShowDeleteButton="true"  ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" >                       
    <ControlStyle Font-Bold="True" ForeColor="Red"></ControlStyle>
    </asp:CommandField>  
                  
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td>
    </tr>
 
    </table>
    </td></tr>
    <tr class='tblrowodd'><td colspan="4" style="text-align:right;" class="auto-style2"><hr /> </td></tr>
    <tr><td style="border:double;border-radius:6px" colspan="4">
    <table  style="vertical-align:top;width:100%">
    <tr>
    <td style="text-align:right"><asp:Label ID="Label1" runat="server" Font-Size="13px"  CssClass="lbl" Text="Remarks : "></asp:Label> </td>
    <td>  <asp:TextBox ID="txtRemarks" Width="580px" Height="70px" CssClass="txtBox" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>  
    <td  colspan="2" style="text-align:right;">
        <asp:Button ID="btnSave" runat="server" Font-Bold="true" ForeColor="Green" OnClick="btnSave_Click" Text="Submit" />
        </td>
    </tr>
    </table>
  
    </tr>
   </td></tr> 
    <table>
   </table>
    </div>

 <%--<div class="leaveSummary_container"> 
        <div class="tabs_container">Order Summary :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="dteDate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField> 
        <asp:BoundField DataField="intOrderNo" HeaderText="Order Number" ItemStyle-HorizontalAlign="Center" SortExpression="intOrderNo">
        <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:BoundField>
        <asp:BoundField DataField="strName" HeaderText="CustomerName" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
            <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty" />
            <asp:BoundField DataField="total" HeaderText="Total Price" SortExpression="total" />
                         
            <asp:TemplateField HeaderText="Detalis"><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("intOrderNo") %>' Text="Details" OnClick="btnDetails_Click"  />
        </ItemTemplate><ItemStyle HorizontalAlign="Left" />

            </asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
       
    </div>--%>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
