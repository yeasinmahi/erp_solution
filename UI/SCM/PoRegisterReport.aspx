﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoRegisterReport.aspx.cs" Inherits="UI.SCM.PoRegisterReport" %>

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
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">PO  REGISTER<hr /></div>
         <table>
           <tr>
            <td   style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"  >
            <asp:ListItem Text="Local"></asp:ListItem>
            <asp:ListItem Text="Import"></asp:ListItem>
            <asp:ListItem Text="Fabrication"></asp:ListItem>
            </asp:DropDownList></td>                                                                                      

            <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Indent: "></asp:Label></td>     
            <td><asp:TextBox ID="txtIndent" runat="server" idth="100px"   CssClass="txtBox" ></asp:TextBox></td> 
            
            <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="PO: "></asp:Label></td>     
            <td><asp:TextBox ID="txtPO" runat="server" idth="100px"   CssClass="txtBox"></asp:TextBox></td> 
           
            <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Mrr: "></asp:Label></td>     
            <td><asp:TextBox ID="txtMrr" runat="server" idth="100px"   CssClass="txtBox"></asp:TextBox></td> 
            <td style="text-align:right"> <td style="text-align:left"><asp:Button ID="btnSearch" runat="server" Text="Search"  /> </td>

           </tr>

        </table>
       <table>
           <tr>
            <td   style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"     ></asp:DropDownList></td>                                                                                      
            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="View By: "></asp:Label></td>     
            <td><asp:DropDownList ID="ddlType" runat="server" CssClass="ddList" >
            <asp:ListItem Text="Indent" Value="1"></asp:ListItem>
            <asp:ListItem Text="PO" Value="2"></asp:ListItem>
            <asp:ListItem Text="MRR" Value="3"></asp:ListItem>
            <asp:ListItem Text="NO PO" Value="4"></asp:ListItem>
             <asp:ListItem Text="NO MRR" Value="5"></asp:ListItem>
                </asp:DropDownList></td>
           
           
            <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtDteFrom" runat="server" Width="100px"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
            </cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtdteTo" runat="server" Width="100px"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
            </cc1:CalendarExtender> </td> 
            <td style="text-align:right"> <td style="text-align:left"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"   /> </td>
            </tr>
           </table>
           
        

         <table>
           <tr><td> 
            <asp:GridView ID="dgvStatement" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="UNIT" SortExpression="unit"><ItemTemplate>
            <asp:Label ID="lblUnit" runat="server" Width="75px" Text='<%# Bind("unit") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Location"   ItemStyle-HorizontalAlign="right" SortExpression="dwhteSrDate" >
            <ItemTemplate><asp:Label ID="lblLocation" Width="60px" runat="server"  Text='<%# Bind("wh") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="IndentNo"   ItemStyle-HorizontalAlign="right" SortExpression="indent" >
            <ItemTemplate><asp:Label ID="lblIndentNo" runat="server"  Text='<%# Bind("indent") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Indent Date"   ItemStyle-HorizontalAlign="right" SortExpression="indDate" >
            <ItemTemplate><asp:Label ID="lblIndentDate" runat="server" Width="60px"  Text='<%# Bind("indDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Approve Date" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblInApproveDate" runat="server"   Text='<%# Bind("appDate","{0: dd-MM-YYYY}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Due date" ItemStyle-HorizontalAlign="right" SortExpression="dueDate" >
            <ItemTemplate><asp:Label ID="lblDueDate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dueDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
           
            <asp:TemplateField HeaderText="PO NO" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="po" >
            <ItemTemplate><asp:Label ID="lblPoNos" runat="server"  Text='<%# Bind("po") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PO Date"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblPoDate" runat="server"  Text='<%# Bind("poDate","{0:dd-MM-YYYY}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>    

            <asp:TemplateField HeaderText="MRR NO"   ItemStyle-HorizontalAlign="right" SortExpression="mrr" >
            <ItemTemplate><asp:Label ID="lblMrrNo" runat="server" Width="60px"  Text='<%# Bind("mrr") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="MRR Date" ItemStyle-HorizontalAlign="right" SortExpression="mrrDate" >
            <ItemTemplate><asp:Label ID="lblMrrDate" runat="server"   Text='<%# Bind("mrrDate","{0: dd-MM-YYYY}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="JV" ItemStyle-HorizontalAlign="right" SortExpression="JV" >
            <ItemTemplate><asp:Label ID="lblJV" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("JV") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Supplier" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="sup" >
            <ItemTemplate><asp:Label ID="lblSupplier" runat="server"  Text='<%# Bind("sup") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PO PrepareBy"   ItemStyle-HorizontalAlign="right" SortExpression="emp" >
            <ItemTemplate><asp:Label ID="lblPoPrepareBy" runat="server"  Text='<%# Bind("emp") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
        </tr> 
           
        </table>
        </div> 
        </div> 
<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>