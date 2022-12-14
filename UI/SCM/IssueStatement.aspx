<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueStatement.aspx.cs" Inherits="UI.SCM.IssueStatement" %>

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
       
    <script>
         function Viewdetails(dteIndent, dteDue, indentID, dept, whname) {
             window.open('IndentStatusDetalis.aspx?dteIndent=' + dteIndent + '&dteDue=' + dteDue + '&indentID=' + indentID + '&dept=' + dept + '&whname=' + whname , 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
         }
    </script>
  
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left: 70px;  margin-top:00px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
</head>

<body>

    <form id="frmselfresign" runat="server"> 
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager> 
   <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server"> --%>
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
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Issue Statement<hr /></div>
         
       <table>
           <tr>
            <td   style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"     ></asp:DropDownList></td>                                                                                      
            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Issue ID/NO: "></asp:Label></td>     
            <td><asp:TextBox ID="txtIssueNo" runat="server" ></asp:TextBox></td>
           </tr>
           <tr>  
           
            <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtDteFrom" runat="server"   CssClass="txtBox" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
            </cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtdteTo" runat="server"   CssClass="txtBox" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
            </cc1:CalendarExtender> </td>
           
            </tr>
           <tr>
               
                <td style="text-align:right" colspan="3"> <td style="text-align:left">
                    <asp:Button ID="btnStatement" runat="server" Text="Show"  OnClick="btnStatement_Click"/>
                     <asp:Button ID="btnDownloads" runat="server" CssClass="button" Text=" Excel Export" OnClick="btnDownloads_Click"   />
                   </td>
           </tr>

        </table>
        

         <table>
           <tr><td> 
            <asp:GridView ID="dgvStatement" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="SR NO" SortExpression="strSrNo"><ItemTemplate>
            <asp:Label ID="lblIndent" runat="server" Width="95px" Text='<%# Bind("strSrNo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField HeaderText="SR Date"   ItemStyle-HorizontalAlign="right" SortExpression="dteSrDate" >
            <ItemTemplate><asp:Label ID="lblItemName" Width="60px" runat="server"  Text='<%# Bind("dteSrDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Section"   ItemStyle-HorizontalAlign="right" SortExpression="strDepatrment" >
            <ItemTemplate><asp:Label ID="lblUOM" runat="server"  Text='<%# Bind("strDepatrment") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Issue Date"   ItemStyle-HorizontalAlign="right" SortExpression="dteIssueDate" >
            <ItemTemplate><asp:Label ID="lblIssueDate" runat="server" Width="60px"  Text='<%# Bind("dteIssueDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  


             <asp:TemplateField HeaderText="Product ID" ItemStyle-HorizontalAlign="right" SortExpression="intItemID" >
            <ItemTemplate><asp:Label ID="lblITemID" runat="server"   Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" /> </asp:TemplateField>

            <asp:TemplateField HeaderText="Product" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblITem" runat="server"   Text='<%# Bind("strItem","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
           
           
            <asp:TemplateField HeaderText="UOM" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strUom" >
            <ItemTemplate><asp:Label ID="lblDueDate" runat="server"  Text='<%# Bind("strUom") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            
            <asp:TemplateField HeaderText="IssueQty"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblIssQty" runat="server"  Text='<%# Bind("numQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Value"   ItemStyle-HorizontalAlign="right" SortExpression="monValue" >
            <ItemTemplate><asp:Label ID="lblValue" runat="server"  Text='<%# Bind("monValue","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

            <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strUseFor" >
            <ItemTemplate><asp:Label ID="lblDept" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strUseFor") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

            </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
        </tr> 
           
        </table>
        </div>
        

       <%-- </div>--%>

<%--=========================================End My Code From Here=================================================--%>

   </ContentTemplate>
   <%--  </asp:UpdatePanel>--%>
    </form>
</body>
</html>