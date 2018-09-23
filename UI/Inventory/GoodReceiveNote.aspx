﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodReceiveNote.aspx.cs" Inherits="UI.Inventory.GoodReceiveNote" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Good Receive Note </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Compat.Timer.Timer.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Animation.Animations.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="ExtenderBase.BaseScripts.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Common.DateTime.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Animation.AnimationBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="PopupExtender.PopupBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Common.Threading.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Calendar.CalendarBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
        <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server">--%>
        <contenttemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel> 
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                 <div class="divbody" style="padding-right:10px;">
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Supplier Account Info Change" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        
                     <div class="row"> 
                         <div class="col-sm-4">
                              <asp:Label ID="Label20" runat="server" Text="Po Number "></asp:Label>
                              <span style="color:red; font-size:14px; text-align:left">*</span>
                             <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox>
                         </div>
                          <div class="col-sm-4">
                              <asp:Label ID="Label22" runat="server" Text="Po Number "></asp:Label>
                              <span style="color:red; font-size:14px; text-align:left">*</span>
                             <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox>
                          </div>
                          <div class="col-sm-4">
                              <asp:Label ID="Label24" runat="server" Text="Po Number "></asp:Label>
                              <span style="color:red; font-size:14px; text-align:left">*</span>
                             <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox>
                          </div>
                     </div>
                     
                     <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:Left; width:300px;">
                    <asp:Label ID="lblUnit" runat="server" Text="Po Number "></asp:Label>
                    <span style="color:red; font-size:14px; text-align:left">*</span>

                </td>
                <td style="text-align:right; ">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;">
                    <asp:Label ID="Label1" runat="server" Text="Requester Designation "></asp:Label>
                    <span style="color:red; font-size:14px; text-align:left">*</span>

                </td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtRequesterName" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtRequesterDesignation" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label4" runat="server" Text="Supplier Name "></asp:Label></td>
                <td style="text-align:right; "><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label6" runat="server" Text="Supplier Address "></asp:Label></td>
            </tr>
            <tr>
                <%--<td><asp:TextBox ID="txtSupplierName" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>--%>
                <td>
                    <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" placeholder="Search Supplier" CssClass="txtBox1" AutoPostBack="true" Width="300px"></asp:TextBox>
                               <%-- <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSupplier"
                                    ServiceMethod="GetMasterSupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>--%>
                </td>
                <td style="text-align:right; "><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtSupplierAddress" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label8" runat="server" Text="New Account Number (13 Digit MICR) "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label10" runat="server" Text="New Routing Number (9 Digit)/Branch Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtAccountNo" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtRoutingNo" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label12" runat="server" Text="Requester ID "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label14" runat="server" Text="Supervisor ID "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtRequestBy" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtSuperviseBy" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label16" runat="server" Text="Request Date "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label18" runat="server" Text="Approve Date"></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtRequestDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox>
                    <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtRequestDate"></cc1:CalendarExtender>
                </td>
                <td style="text-align:right; "><asp:Label ID="Label19" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtApproveDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox>
                    <cc1:CalendarExtender ID="appDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtApproveDate"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                 <td style='text-align: left;'>Document Upload : </td>
            </tr>
            <tr>
                 <td style='text-align: left;'>
                <asp:FileUpload ID="txtDocUpload" runat="server" /> 
                 </td>
            <td style="text-align:center;"> 
            <%--<a class="nextclick" onclick="FTPUpload" style="font-size:14px; background-color:deepskyblue; color:white;font-weight:bold; padding:5px;">Add</a>--%>
                <asp:Button ID="btnUpload" runat="server" style="font-size:12px; background-color:deepskyblue; color:white;font-weight:bold; padding:2px;" Text="Add" OnClick="btnUpload_Click" />
            </td>
            </tr>
            <tr>
                
                <td style="text-align:right; padding: 5px 0px 5px 0px" colspan="3">
                    <asp:Button ID="btnSubmit" runat="server" class="myButton" Text="Submit" Height="30px" OnClick="btnSubmit_Click"/>
                    <asp:Button ID="btnPrint" runat="server" class="myButton" Text="Print" Height="30px" OnClientClick="Print()"/>
                </td>
            </tr>
             <tr><td colspan="3"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
            <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="530px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid" >
            <ItemTemplate><asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                           
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>    

        </table>             
    </div>
                <asp:Panel ID="Panel1" runat="server">
                <div>
                    <div style="text-align:center;">Akij House, 198 Bir Uttam Mir Shawkat Sharak, Gulshan Link Road, Tejgaon, Dhaka-1208</div>
                         <table>
                             <tr>
                                 <td><asp:Label ID="Label21" runat="server" Text="Account No: "></asp:Label></td>
                                 <td><asp:Label ID="lblAccNo" runat="server" ></asp:Label></td>
                                 <td><asp:Label ID="Label23" runat="server" Text="Request Date: "></asp:Label></td>
                                 <td><asp:Label ID="lblReqDate" runat="server" ></asp:Label></td>
                             </tr>
                             <tr>
                                 <td><asp:Label ID="Label25" runat="server" Text="Requester"></asp:Label></td>
                             </tr>
                              <tr>
                                 <td><asp:Label ID="lblReqBy" runat="server" ></asp:Label></td>
                             </tr>
                              <tr>
                                 <td><asp:Label ID="Label27" runat="server" Text="Email:"></asp:Label></td>
                                  <td><asp:Label ID="Label28" runat="server"></asp:Label></td>
                             </tr>
                              <tr>
                                 <td><asp:Label ID="Label29" runat="server" Text="Approve By:"></asp:Label></td>
                                  <td><asp:Label ID="lblAppBy" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td><asp:Label ID="Label31" runat="server" Text="Approve Date:"></asp:Label></td>
                                  <td><asp:Label ID="lblAppDate" runat="server"></asp:Label></td>
                             </tr>
                            
                         </table>
                    <div>
                         
                      <asp:Image ID="Image1" runat="server" Height="150px" Width="400px" />
                    
                    </div>
                     </div>
                    </asp:Panel>
                 <%--=========================================End My Code From Here=================================================--%>
           </contenttemplate>
        <%--</asp:UpdatePanel>--%>
    </form>
</body>
</html>

